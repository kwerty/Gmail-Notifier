using System;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Taskbar;
using Microsoft.WindowsAPICodePack.Shell;


namespace GmailNotifier
{

    public partial class MainForm : Form
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);

        [DllImport("User32")]
        private static extern int SetForegroundWindow(IntPtr hwnd);

        [DllImportAttribute("User32.DLL")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_RESTORE = 9;

        internal ProcessMessaging _processMsg;
        internal bool _processMsgClosed;

        internal SettingsForm _settingsForm;
        internal ThumbForm _thumbForm;

        internal object _timerLock = new object();
        internal bool _timerOn;
        internal System.Timers.Timer _timer;

        internal string _newMailSound;

        internal int _checkInterval = 120000;
        internal int _errorInterval = 600000; // every 10 minutes if there's an account error
        internal int _connRetryInterval = 60000; // every minute if there's a connection problem

        internal JumpList _jumpList;
        internal TabbedThumbnail _thumb;

        internal ThumbnailToolBarButton _prevButton;
        internal ThumbnailToolBarButton _openButton;
        internal ThumbnailToolBarButton _nextButton;

        internal GmailClient _gmailClient;

        internal int _currentlyViewing;

        internal bool _loggedIn;

        internal string _baseUrl;

        public MainForm()
        {
            InitializeComponent();

        }


        private void MainForm_Shown(object sender, EventArgs e)
        {


            if (DateTime.Today >= DateTime.Parse("2014/01/01"))
                MessageBox.Show("Please download a newer version of Gmail Notifier at http://kwerty.com", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            Refresh();

            RegistryKey registry = Registry.CurrentUser.CreateSubKey(@"Software\KwertyGmailNotifier");
            string username;
            byte[] passwordEnc;
            int interval;

            using (registry)
            {
                username = (string)registry.GetValue("username");
                passwordEnc = (byte[])registry.GetValue("password");
                interval = (int)registry.GetValue("interval", 2);
                _newMailSound = (string)registry.GetValue("newmailsound");
            }

            string password = null;

            if (passwordEnc != null)
                password = UTF8Encoding.UTF8.GetString(ProtectedData.Unprotect(passwordEnc, null, DataProtectionScope.CurrentUser));

            if (interval > 0 && interval <= 60)
                _checkInterval = interval * 60000;

            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                LoginForm loginForm = new LoginForm(this);
                loginForm.Show();
                return;
            }

            _loggedIn = true;

            _gmailClient = new GmailClient(username, password);

            Setup();

            RefreshAndRestartTimer();

        }

        public void MessageReceived(object sender, MessageEventArgs e)
        {

            if (_processMsgClosed) return;

            if (e.Message == "refresh")
                RefreshMail();

            else if (e.Message == "inbox")
                Process.Start(_baseUrl);

            else if (e.Message == "settings")
                Invoke(new Action(ShowSettingsForm));

            else if (e.Message == "logout")
                Invoke(new Action(ChangeUser));


        }

        internal void ChangeUser()
        {

            Logout();

            RegistryKey registry = Registry.CurrentUser.CreateSubKey(@"Software\KwertyGmailNotifier");

            using (registry)
            {
                registry.DeleteValue("username");
                registry.DeleteValue("password");
            }

            ShowLoginForm();
        }

        internal void DetectBaseUrl()
        {

            string domain = null;

            string match = Regex.Match(_gmailClient.Username, ".+@(.+)").Groups[1].Value;

            if ((match != String.Empty) && !(new string[] { "gmail.com", "googlemail.com", "googlemail.co.uk" }.Contains(match)))
                domain = match;

            _baseUrl = "http://mail.google.com" + (domain != null ? "/a/" + domain : null);

        }
        
        

        internal void Setup()
        {

            DetectBaseUrl();

            _processMsgClosed = false;
            _processMsg = new ProcessMessaging();
            _processMsg.MessageReceived +=new MessageReceivedEventHandler(MessageReceived);
            _processMsg.ReceieveMessages();

            SetupThumbAndButtons();

            EnableAppropriateButtons();

            AddJumpList();

            UpdateIcon();

            if (_gmailClient.Emails.Count > 0)
            {
                _thumbForm.Invoke(new Action<int>(_thumbForm.UpdatePreviewThumb), 0);
                _thumbForm.Invoke(new Action<bool>(_thumbForm.ShowAppropriateThumb), false);
            }

            _timer = new System.Timers.Timer();
            _timer.Interval = _checkInterval;
            _timerOn = true;
            _timer.Elapsed += TimerElapsed;

        }


        public void RestartTimer()
        {

            lock (_timerLock)
            {
                _timer.Interval = _checkInterval;
                _timer.Stop();
                _timer.Start();
            }

        }

        public void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            lock (_timerLock)
            {
                if (_timerOn == false)
                    return;

                RefreshAndRestartTimer();

            }
            
        }

        internal void ShowProgress()
        {

            // show green in taskbar for 10 seconds
            System.Timers.Timer timer = new System.Timers.Timer(10000);

            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
            TaskbarManager.Instance.SetProgressValue(100, 100);

            timer.Elapsed += delegate(object sender, System.Timers.ElapsedEventArgs e)
            {
                TaskbarManager.Instance.SetProgressValue(0, 0);
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                timer.Stop();
                timer.Close();
            };

            timer.Start();

        }


        public void RefreshAndRestartTimer()
        {

            lock (_timerLock)
            {

                DisableButtons();

                _thumbForm.Invoke(new Action<bool>(_thumbForm.ShowAppropriateThumb), true);

                int currCount = _gmailClient.Emails.Count;
                CheckEmailResult currResult = _gmailClient.LastResult;

                _gmailClient.CheckEmail();

                //if status has changed or the number of emails has changed
                if ((currResult != _gmailClient.LastResult) || (currCount != _gmailClient.Emails.Count))
                    UpdateIcon();

                //
                if (_gmailClient.Updated && _gmailClient.Emails.Count > 0)
                    _thumbForm.Invoke(new Action<int>(_thumbForm.UpdatePreviewThumb), 0);

                //if we got mail, and it's not the first time
                if (_gmailClient.GotMail && (currResult != CheckEmailResult.None))
                {
                    ShowProgress();

                    NewMailSound();
                }

                _thumbForm.Invoke(new Action<bool>(_thumbForm.ShowAppropriateThumb), false);

                EnableAppropriateButtons();

                int interval = _checkInterval;

                if (_gmailClient.LastResult == CheckEmailResult.AccountError)
                    interval = _errorInterval;
                else if (_gmailClient.LastResult == CheckEmailResult.NetworkError)
                    interval = _connRetryInterval;

                _timer.Interval = interval;
                _timer.Start();


            }

        }

        private void NewMailSound()
        {

            if (_newMailSound == "none")
                return;

            if (_newMailSound == null)
                SoundUtil.PlayWindowsSound("MailBeep");
            else
            {
                SoundUtil.PlaySound(_newMailSound);
            }

        }


        private void Logout() {


            _processMsgClosed = true;
            _processMsg.Close();

            lock (_timerLock)
            {
                _timerOn = false;
                _timer.Elapsed -= TimerElapsed;
                _timer.Stop();
                _timer.Close();
            }

            _gmailClient = null;
            _loggedIn = false;

            DestroySettingsForm();

            RemoveJumpList();

            RemoveThumbAndButtons();

            UpdateIcon();

        }

        private void ShowLoginForm()
        {

            LoginForm loginForm = new LoginForm(this);

            loginForm.Show();

            StealFocus(loginForm.Handle);

        }


        private void RefreshMail()
        {

            lock (_timerLock)
            {
                _timer.Stop();

                RefreshAndRestartTimer();

            }

        }


        void NextButtonClicked(object sender, ThumbnailButtonClickedEventArgs e)
        {

            if (_currentlyViewing == _gmailClient.Emails.Count - 1)
                return;

            _thumbForm.Invoke(new Action<int>(_thumbForm.UpdatePreviewThumb), _currentlyViewing + 1);

            EnableAppropriateButtons();

        }

        void PrevButtonClicked(object sender, ThumbnailButtonClickedEventArgs e)
        {

            if (_currentlyViewing == 0)
                return;

            _thumbForm.Invoke(new Action<int>(_thumbForm.UpdatePreviewThumb), _currentlyViewing - 1);

            EnableAppropriateButtons();

        }

        void OpenButtonClicked(object sender, ThumbnailButtonClickedEventArgs e)
        {

            Email email = _gmailClient.Emails[_currentlyViewing];

            string id = HttpUtility.ParseQueryString(email.Link)["message_id"];

            string link = String.Format("{0}?message_id={1}", _baseUrl, id);

            Process.Start(link);

        }

        internal void ShowSettingsForm()
        {
            if (_settingsForm == null || _settingsForm.IsDisposed) _settingsForm = new SettingsForm(this);

            _settingsForm.Show();
            StealFocus(_settingsForm.Handle);

        }

        internal void DestroySettingsForm()
        {
            if (_settingsForm == null || _settingsForm.IsDisposed)
                return;

            _settingsForm.Close();
        }


        internal void AddJumpList()
        {
            
            _jumpList = JumpList.CreateJumpList();

            //do i need this?
            _jumpList.ClearAllUserTasks();
            _jumpList.Refresh();

            JumpListLink openTask = new JumpListLink(_baseUrl, "Open inbox")
            {
                IconReference = new IconReference(Application.ExecutablePath, 2),
            };

            JumpListLink composeTask = new JumpListLink(_baseUrl + "#compose", "Compose mail")
            {
                IconReference = new IconReference(Application.ExecutablePath, 1),
            };

            JumpListLink refreshTask = new JumpListLink(Application.ExecutablePath, "Check for new mail")
            {
                Arguments = "refresh",
                IconReference = new IconReference(Application.ExecutablePath, 4),
            };

            JumpListLink settingsTask = new JumpListLink(Application.ExecutablePath, "Settings")
            {
                Arguments = "settings",
                IconReference = new IconReference(Application.ExecutablePath, 5),
            };

            JumpListLink logoutTask = new JumpListLink(Application.ExecutablePath, "Logout")
            {
                Arguments = "logout",
                IconReference = new IconReference(Application.ExecutablePath, 3),
            };

            _jumpList.AddUserTasks(new JumpListTask[] { openTask, composeTask, refreshTask, settingsTask, logoutTask }); //new JumpListSeparator(),

            _jumpList.Refresh(); // do i need this?

        }

        internal void RemoveJumpList()
        {
            _jumpList.ClearAllUserTasks();
            _jumpList.Refresh();

        }

        internal void SetupThumbAndButtons()
        {

            _thumbForm = new ThumbForm(this);
            
            _thumb = new TabbedThumbnail(this.Handle, _thumbForm);
            _thumb.Title = _gmailClient.Username;
            _thumb.SetWindowIcon((Icon)this.Icon.Clone());

            _thumb.TabbedThumbnailClosed += (sender, e) =>
            {
                //ideally what i would like to here is cancel the close event
                //unfortunately it appears there is a bug in the WindowsAPICodePack which is not receiving any attention from Microsoft
                //the next best alternative is just to close the entire application, otherwise it will crash next time we try to update the thumbnail preview
                Close();
                
            };

            _thumbForm.Show();
            _thumbForm.Render();

            _prevButton = new ThumbnailToolBarButton(Properties.Resources.Previous, "Previous") { Enabled = false };
            _openButton = new ThumbnailToolBarButton(Properties.Resources.Open, "Open") { Enabled = false };
            _nextButton = new ThumbnailToolBarButton(Properties.Resources.Next, "Next") { Enabled = false };

            _prevButton.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(PrevButtonClicked);
            _openButton.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(OpenButtonClicked);
            _nextButton.Click += new EventHandler<ThumbnailButtonClickedEventArgs>(NextButtonClicked);

            TaskbarManager.Instance.TabbedThumbnail.AddThumbnailPreview(_thumb);

            TaskbarManager.Instance.ThumbnailToolBars.AddButtons(_thumbForm.Handle, _prevButton, _openButton, _nextButton);

        }

        internal void RemoveThumbAndButtons()
        {

            TaskbarManager.Instance.TabbedThumbnail.RemoveThumbnailPreview(_thumb);

            _thumbForm.Close();
            _thumbForm = null;

        }

        internal void DisableButtons()
        {
            _prevButton.Enabled = false;
            _openButton.Enabled = false;
            _nextButton.Enabled = false;
        }

        internal void EnableAppropriateButtons()
        {
            _prevButton.Enabled = _currentlyViewing > 0 ? true : false;
            _nextButton.Enabled = _currentlyViewing < (_gmailClient.Emails.Count - 1) ? true : false;
            _openButton.Enabled = _gmailClient.Emails.Count > 0 ? true : false;
        }

        internal void UpdateIcon()
        {

            if (_gmailClient == null)
                TaskbarManager.Instance.SetOverlayIcon(null, null);

            else if (_gmailClient.LastResult == CheckEmailResult.AccountError)
                TaskbarManager.Instance.SetOverlayIcon(Properties.Resources.Logout, "Account error");

            else if (_gmailClient.LastResult == CheckEmailResult.NetworkError)
                TaskbarManager.Instance.SetOverlayIcon(Properties.Resources.Exclamation, "Connection problem");

            else

                if (_gmailClient.Emails.Count > 0)
                    ShowUnreadIcon(_gmailClient.Emails.Count);

                else
                    TaskbarManager.Instance.SetOverlayIcon(null, null);


        }

        internal void ShowUnreadIcon(int unreadEmails)
        {

            Bitmap bmp = new Bitmap(16, 16);

            using (bmp)
            {
                using (Graphics gfx = Graphics.FromImage(bmp))
                {

                    gfx.SmoothingMode = SmoothingMode.AntiAlias;

                    LinearGradientBrush grad = new LinearGradientBrush(new Point(0, 0), new Point(0, 16), ColorTranslator.FromHtml("#17d300"), ColorTranslator.FromHtml("#168b08"));

                    gfx.FillEllipse(grad, (float)0.25, (float)0.25, (float)15.25, (float)15.25);

                    StringFormat stringFormat = new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center,
                    };

                    gfx.DrawString(unreadEmails < 100 ? unreadEmails.ToString() : "~", new Font("Arial", unreadEmails < 10 ? 9 : 6, FontStyle.Bold), new SolidBrush(Color.White), new RectangleF(0, 0, 16, 16), stringFormat);

                }

                Icon ico = Icon.FromHandle(bmp.GetHicon());

                try
                {
                    TaskbarManager.Instance.SetOverlayIcon(ico, String.Format("{0} unread emails", unreadEmails));
                }
                finally
                {
                    DestroyIcon(ico.Handle);
                }

            }

        }

        private static void StealFocus(IntPtr handle)
        {
            ShowWindow(handle, SW_RESTORE);
            SetForegroundWindow(handle);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (_loggedIn)
                Logout();

        }

    }
}
