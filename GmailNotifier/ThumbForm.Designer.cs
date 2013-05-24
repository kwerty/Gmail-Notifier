namespace GmailNotifier
{
    partial class ThumbForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThumbForm));
            this.noMailPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.panelLine = new System.Windows.Forms.Panel();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.indexLabel = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.networkErrorPanel = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.checkingPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.accountErrorPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.noMailPanel.SuspendLayout();
            this.previewPanel.SuspendLayout();
            this.networkErrorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.checkingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.accountErrorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // noMailPanel
            // 
            this.noMailPanel.BackColor = System.Drawing.Color.White;
            this.noMailPanel.Controls.Add(this.label1);
            this.noMailPanel.Location = new System.Drawing.Point(25, 23);
            this.noMailPanel.Name = "noMailPanel";
            this.noMailPanel.Size = new System.Drawing.Size(200, 119);
            this.noMailPanel.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "No new mail";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previewPanel
            // 
            this.previewPanel.BackColor = System.Drawing.Color.White;
            this.previewPanel.Controls.Add(this.panelLine);
            this.previewPanel.Controls.Add(this.subjectLabel);
            this.previewPanel.Controls.Add(this.fromLabel);
            this.previewPanel.Controls.Add(this.indexLabel);
            this.previewPanel.Controls.Add(this.messageLabel);
            this.previewPanel.Controls.Add(this.dateLabel);
            this.previewPanel.Location = new System.Drawing.Point(25, 147);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(200, 119);
            this.previewPanel.TabIndex = 17;
            this.previewPanel.Visible = false;
            // 
            // panelLine
            // 
            this.panelLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(213)))), ((int)(((byte)(223)))));
            this.panelLine.Location = new System.Drawing.Point(6, 39);
            this.panelLine.Name = "panelLine";
            this.panelLine.Size = new System.Drawing.Size(186, 1);
            this.panelLine.TabIndex = 21;
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoEllipsis = true;
            this.subjectLabel.BackColor = System.Drawing.Color.Transparent;
            this.subjectLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))));
            this.subjectLabel.Location = new System.Drawing.Point(3, 4);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(189, 17);
            this.subjectLabel.TabIndex = 19;
            this.subjectLabel.Text = "(no subject)";
            // 
            // fromLabel
            // 
            this.fromLabel.AutoEllipsis = true;
            this.fromLabel.BackColor = System.Drawing.Color.Transparent;
            this.fromLabel.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromLabel.ForeColor = System.Drawing.Color.Gray;
            this.fromLabel.Location = new System.Drawing.Point(4, 21);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(191, 15);
            this.fromLabel.TabIndex = 20;
            this.fromLabel.Text = "Tim";
            // 
            // indexLabel
            // 
            this.indexLabel.BackColor = System.Drawing.Color.Transparent;
            this.indexLabel.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indexLabel.ForeColor = System.Drawing.Color.Gray;
            this.indexLabel.Location = new System.Drawing.Point(120, 103);
            this.indexLabel.Margin = new System.Windows.Forms.Padding(0);
            this.indexLabel.Name = "indexLabel";
            this.indexLabel.Size = new System.Drawing.Size(75, 12);
            this.indexLabel.TabIndex = 18;
            this.indexLabel.Text = "0/0";
            this.indexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoEllipsis = true;
            this.messageLabel.BackColor = System.Drawing.Color.Transparent;
            this.messageLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.Location = new System.Drawing.Point(3, 43);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(192, 59);
            this.messageLabel.TabIndex = 17;
            this.messageLabel.Text = "Hello";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.BackColor = System.Drawing.Color.Transparent;
            this.dateLabel.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLabel.ForeColor = System.Drawing.Color.Gray;
            this.dateLabel.Location = new System.Drawing.Point(4, 103);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(43, 12);
            this.dateLabel.TabIndex = 16;
            this.dateLabel.Text = "1/4/2012";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // networkErrorPanel
            // 
            this.networkErrorPanel.BackColor = System.Drawing.Color.White;
            this.networkErrorPanel.BackgroundImage = global::GmailNotifier.Properties.Resources.ThumbBackgroundWarning;
            this.networkErrorPanel.Controls.Add(this.pictureBox7);
            this.networkErrorPanel.Controls.Add(this.label4);
            this.networkErrorPanel.Controls.Add(this.pictureBox5);
            this.networkErrorPanel.Location = new System.Drawing.Point(25, 272);
            this.networkErrorPanel.Name = "networkErrorPanel";
            this.networkErrorPanel.Size = new System.Drawing.Size(200, 119);
            this.networkErrorPanel.TabIndex = 17;
            this.networkErrorPanel.Visible = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Image = global::GmailNotifier.Properties.Resources.Disconnected;
            this.pictureBox7.Location = new System.Drawing.Point(42, 3);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(119, 81);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox7.TabIndex = 19;
            this.pictureBox7.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Connection failed";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Location = new System.Drawing.Point(0, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(200, 119);
            this.pictureBox5.TabIndex = 18;
            this.pictureBox5.TabStop = false;
            // 
            // checkingPanel
            // 
            this.checkingPanel.BackColor = System.Drawing.Color.White;
            this.checkingPanel.BackgroundImage = global::GmailNotifier.Properties.Resources.ThumbBackground;
            this.checkingPanel.Controls.Add(this.pictureBox1);
            this.checkingPanel.Controls.Add(this.label3);
            this.checkingPanel.Controls.Add(this.pictureBox4);
            this.checkingPanel.Location = new System.Drawing.Point(240, 23);
            this.checkingPanel.Name = "checkingPanel";
            this.checkingPanel.Size = new System.Drawing.Size(200, 119);
            this.checkingPanel.TabIndex = 17;
            this.checkingPanel.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::GmailNotifier.Properties.Resources.Refreshing;
            this.pictureBox1.Location = new System.Drawing.Point(51, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Checking for new mail";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(200, 119);
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // accountErrorPanel
            // 
            this.accountErrorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.accountErrorPanel.BackgroundImage = global::GmailNotifier.Properties.Resources.ThumbBackgroundError;
            this.accountErrorPanel.Controls.Add(this.label5);
            this.accountErrorPanel.Controls.Add(this.label2);
            this.accountErrorPanel.Controls.Add(this.pictureBox6);
            this.accountErrorPanel.Location = new System.Drawing.Point(240, 148);
            this.accountErrorPanel.Name = "accountErrorPanel";
            this.accountErrorPanel.Size = new System.Drawing.Size(200, 119);
            this.accountErrorPanel.TabIndex = 17;
            this.accountErrorPanel.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 53);
            this.label5.MaximumSize = new System.Drawing.Size(180, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 36);
            this.label5.TabIndex = 1;
            this.label5.Text = "Your username and password were rejected by Gmail.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Account Error";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Location = new System.Drawing.Point(0, 0);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(200, 119);
            this.pictureBox6.TabIndex = 2;
            this.pictureBox6.TabStop = false;
            // 
            // ThumbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(471, 408);
            this.Controls.Add(this.noMailPanel);
            this.Controls.Add(this.accountErrorPanel);
            this.Controls.Add(this.checkingPanel);
            this.Controls.Add(this.networkErrorPanel);
            this.Controls.Add(this.previewPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(-32000, -32000);
            this.Name = "ThumbForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Preview";
            this.noMailPanel.ResumeLayout(false);
            this.noMailPanel.PerformLayout();
            this.previewPanel.ResumeLayout(false);
            this.previewPanel.PerformLayout();
            this.networkErrorPanel.ResumeLayout(false);
            this.networkErrorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.checkingPanel.ResumeLayout(false);
            this.checkingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.accountErrorPanel.ResumeLayout(false);
            this.accountErrorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel noMailPanel;
        internal System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.Panel panelLine;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label indexLabel;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Panel networkErrorPanel;
        internal System.Windows.Forms.Panel checkingPanel;
        internal System.Windows.Forms.Panel accountErrorPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}