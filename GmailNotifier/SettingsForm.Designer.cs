namespace GmailNotifier
{
    partial class SettingsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.intervalTracker = new System.Windows.Forms.TrackBar();
            this.oneButton = new System.Windows.Forms.Button();
            this.TwoButton = new System.Windows.Forms.Button();
            this.FiveButton = new System.Windows.Forms.Button();
            this.HourButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.soundCombo = new System.Windows.Forms.ComboBox();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.playButton = new System.Windows.Forms.Button();
            this.intervalTip = new System.Windows.Forms.ToolTip(this.components);
            this.startupChk = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.intervalTracker)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(158, 209);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(151, 36);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save changes";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(12, 219);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(58, 26);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sound notification:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Check every:";
            // 
            // intervalTracker
            // 
            this.intervalTracker.Location = new System.Drawing.Point(12, 91);
            this.intervalTracker.Maximum = 60;
            this.intervalTracker.Minimum = 1;
            this.intervalTracker.Name = "intervalTracker";
            this.intervalTracker.Size = new System.Drawing.Size(297, 45);
            this.intervalTracker.TabIndex = 2;
            this.intervalTracker.Value = 1;
            this.intervalTracker.ValueChanged += new System.EventHandler(this.intervalTracker_ValueChanged);
            // 
            // oneButton
            // 
            this.oneButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oneButton.Location = new System.Drawing.Point(18, 124);
            this.oneButton.Name = "oneButton";
            this.oneButton.Size = new System.Drawing.Size(21, 24);
            this.oneButton.TabIndex = 3;
            this.oneButton.Text = "1";
            this.oneButton.UseVisualStyleBackColor = true;
            this.oneButton.Click += new System.EventHandler(this.oneButton_Click);
            // 
            // TwoButton
            // 
            this.TwoButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TwoButton.Location = new System.Drawing.Point(44, 124);
            this.TwoButton.Name = "TwoButton";
            this.TwoButton.Size = new System.Drawing.Size(29, 24);
            this.TwoButton.TabIndex = 4;
            this.TwoButton.Text = "2";
            this.TwoButton.UseVisualStyleBackColor = true;
            this.TwoButton.Click += new System.EventHandler(this.TwoButton_Click);
            // 
            // FiveButton
            // 
            this.FiveButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiveButton.Location = new System.Drawing.Point(79, 124);
            this.FiveButton.Name = "FiveButton";
            this.FiveButton.Size = new System.Drawing.Size(53, 24);
            this.FiveButton.TabIndex = 5;
            this.FiveButton.Text = "5";
            this.FiveButton.UseVisualStyleBackColor = true;
            this.FiveButton.Click += new System.EventHandler(this.FiveButton_Click);
            // 
            // HourButton
            // 
            this.HourButton.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HourButton.Location = new System.Drawing.Point(138, 124);
            this.HourButton.Name = "HourButton";
            this.HourButton.Size = new System.Drawing.Size(120, 24);
            this.HourButton.TabIndex = 6;
            this.HourButton.Text = "60";
            this.HourButton.UseVisualStyleBackColor = true;
            this.HourButton.Click += new System.EventHandler(this.HourButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(264, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "mins";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // soundCombo
            // 
            this.soundCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.soundCombo.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soundCombo.FormattingEnabled = true;
            this.soundCombo.Items.AddRange(new object[] {
            "None",
            "System Default",
            "Custom Sound"});
            this.soundCombo.Location = new System.Drawing.Point(12, 30);
            this.soundCombo.Name = "soundCombo";
            this.soundCombo.Size = new System.Drawing.Size(257, 26);
            this.soundCombo.TabIndex = 0;
            this.soundCombo.SelectedIndexChanged += new System.EventHandler(this.soundCombo_SelectedIndexChanged);
            // 
            // openFile
            // 
            this.openFile.DefaultExt = "wav";
            this.openFile.Filter = "WAV Files|*.wav|All files|*.*";
            this.openFile.Title = "Select a custom sound";
            // 
            // playButton
            // 
            this.playButton.Font = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.playButton.Location = new System.Drawing.Point(275, 30);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(34, 26);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "X";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // startupChk
            // 
            this.startupChk.AutoSize = true;
            this.startupChk.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.startupChk.Location = new System.Drawing.Point(15, 165);
            this.startupChk.Name = "startupChk";
            this.startupChk.Size = new System.Drawing.Size(195, 22);
            this.startupChk.TabIndex = 17;
            this.startupChk.Text = "Run automatically on startup";
            this.startupChk.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 260);
            this.Controls.Add(this.startupChk);
            this.Controls.Add(this.HourButton);
            this.Controls.Add(this.FiveButton);
            this.Controls.Add(this.TwoButton);
            this.Controls.Add(this.oneButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.intervalTracker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.soundCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.intervalTracker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar intervalTracker;
        private System.Windows.Forms.Button oneButton;
        private System.Windows.Forms.Button TwoButton;
        private System.Windows.Forms.Button FiveButton;
        private System.Windows.Forms.Button HourButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox soundCombo;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.ToolTip intervalTip;
        private System.Windows.Forms.CheckBox startupChk;


    }
}