using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace GmailNotifier
{
    public partial class SettingsForm : Form
    {

        MainForm _mainForm;
        string _currentSound;
        bool _comboReady;

        public SettingsForm(MainForm mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;

            intervalTracker.Value = _mainForm._checkInterval / 60000;

            _currentSound = _mainForm._newMailSound;

            // get startup value from registry

            RegistryKey registry = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            string value;
            using (registry)
                value = (string)registry.GetValue("GmailNotifier");
            if (value == Application.ExecutablePath)
                startupChk.Checked = true;


            soundCombo.Text = ValueToLabel(_mainForm._newMailSound);

            ResetFileOpener();

            _comboReady = true;

        }

        private void ResetFileOpener()
        {
            if (_currentSound == "none" || _currentSound == null)
                openFile.InitialDirectory = Environment.ExpandEnvironmentVariables(@"%WinDir%\Media");
            else
            {
                openFile.InitialDirectory = Path.GetDirectoryName(_currentSound);
                openFile.FileName = Path.GetFileName(_currentSound);
            }
        }

        private string ValueToLabel(string value)
        {

            if (value == "none")
                 return "None";

            else if (value == null)
                return "System Default";

            else
                return "Custom Sound";

        }


        private void saveButton_Click(object sender, EventArgs e)
        {

            RegistryKey registry;

            registry = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

            using (registry)
            {
                if (startupChk.Checked)
                    registry.SetValue("GmailNotifier", Application.ExecutablePath);
                else
                    registry.DeleteValue("GmailNotifier");
            }

            registry = Registry.CurrentUser.CreateSubKey(@"Software\GmailNotifier");

            using (registry)
            {

                registry.SetValue("interval", intervalTracker.Value);

                if (_currentSound != null)
                    registry.SetValue("newmailsound", _currentSound);
                else
                    registry.DeleteValue("newmailsound");

            }

            _mainForm._newMailSound = _currentSound;
            _mainForm._checkInterval = intervalTracker.Value * 60000;
            _mainForm.RestartTimer();

            Close();

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            intervalTracker.Value = 1;
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            intervalTracker.Value = 2;
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            intervalTracker.Value = 5;
        }

        private void HourButton_Click(object sender, EventArgs e)
        {
            intervalTracker.Value = 60;
        }

        private void soundCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            playButton.Enabled = soundCombo.Text != "None" ? true : false;

            if (!_comboReady) return;

            if ((soundCombo.Text == "None"))
                _currentSound = "none";

            else if ((soundCombo.Text == "System Default"))
                _currentSound = null;

            else
            {

                ResetFileOpener();

                DialogResult result = openFile.ShowDialog();

                if (result == DialogResult.OK)
                    _currentSound = openFile.FileName;
                else
                    soundCombo.Text = ValueToLabel(_currentSound);

            }   

        }

        private void playButton_Click(object sender, EventArgs e)
        {

            if (_currentSound == "none")
                return;

            if (_currentSound == null)
                SoundUtil.PlayWindowsSound("MailBeep");

            else
                SoundUtil.PlaySound(_currentSound);


        }

        private void intervalTracker_ValueChanged(object sender, EventArgs e)
        {
            intervalTip.SetToolTip(intervalTracker, intervalTracker.Value.ToString());
        }




    }
}
