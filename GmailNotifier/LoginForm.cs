using System;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace GmailNotifier
{
    public partial class LoginForm : Form
    {

        MainForm _mainForm;
        bool _closed;

        public LoginForm(MainForm mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;
        }

        private void ErrorBox(string message)
        {
            MessageBox.Show(message, "Problem logging in", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(usernameBox.Text) || String.IsNullOrEmpty(passwordBox.Text))
            {
                ErrorBox("Please enter your username and password");
                return;
            }

            mainPanel.Enabled = false;

            GmailClient gmailClient = new GmailClient(usernameBox.Text, passwordBox.Text);

            if (gmailClient.CheckEmail() != CheckEmailResult.Success)
            {
                mainPanel.Enabled = true;
                ErrorBox("Could not login");
                return;
            }

            byte[] pass = System.Security.Cryptography.ProtectedData.Protect(UTF8Encoding.UTF8.GetBytes(passwordBox.Text), null, System.Security.Cryptography.DataProtectionScope.CurrentUser);

            RegistryKey registry = Registry.CurrentUser.CreateSubKey(@"Software\Kwerty Gmail Notifier");

            using (registry)
            {
                registry.SetValue("username", usernameBox.Text);
                registry.SetValue("password", pass);
            }

            _mainForm._gmailClient = gmailClient;

            _mainForm.Setup();

            _mainForm._timer.Start();

            _closed = true;
            Close();

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CloseWholeApplication();
        }

        private void CloseWholeApplication()
        {

            _closed = true;

            Close();

            _mainForm.Close();

        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!_closed)
                CloseWholeApplication();

        }

        private void passwordBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                loginButton_Click(null, null);
                
        }


    }
}
