using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GmailNotifier
{
    public partial class ThumbForm : Form
    {

        MainForm _mainForm;

        public ThumbForm(MainForm mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;

            Owner = _mainForm;
            Size = new Size(200, 119);
            Location = new Point(Owner.Location.X + 200, Owner.Location.Y + 150);

            // we're not in designer land anymore toto
            foreach (Panel panel in this.Controls.OfType<Panel>())
                panel.Location = new Point(0, 0);

        }

        public void UpdatePreviewThumb(int index)
        {

            _mainForm._currentlyViewing = index;

            Email email = _mainForm._gmailClient.Emails[_mainForm._currentlyViewing];

            subjectLabel.Text = email.Subject != String.Empty ? email.Subject : "(no subject)";
            fromLabel.Text = String.Format("{0} <{1}>", email.Sender, email.SenderAddress);
            messageLabel.Text = email.Body;
            dateLabel.Text = String.Format("{0} {1}", email.Date.ToShortDateString(), email.Date.ToShortTimeString());
            indexLabel.Text = String.Format("{0}/{1}", _mainForm._currentlyViewing + 1, _mainForm._gmailClient.Emails.Count);
            
            Render();

        }

        public void ShowAppropriateThumb(bool currentlyRefreshing = false)
        {

            Control activePanel;

            if (currentlyRefreshing)
                activePanel = checkingPanel;
            else if (_mainForm._gmailClient.LastResult == CheckEmailResult.NetworkError)
                activePanel = networkErrorPanel;
            else if (_mainForm._gmailClient.LastResult == CheckEmailResult.AccountError)
                activePanel = accountErrorPanel;
            else
                activePanel = _mainForm._gmailClient.Emails.Count > 0 ? previewPanel : noMailPanel;

            activePanel.Visible = true;

            //for each panel which is not active
            foreach (Panel panel in this.Controls.OfType<Panel>().Where(c => c != activePanel))
                panel.Visible = false;

            Render();

        }

        internal void Render()
        {
            Refresh();
            _mainForm._thumb.InvalidatePreview();
        }

    }
}
