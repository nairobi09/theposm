namespace thepos
{
    partial class frmSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetup));
            this.panelSetup = new System.Windows.Forms.Panel();
            this.panelTitleConsole = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.panelTitleWhite = new System.Windows.Forms.Panel();
            this.btnSetupPos = new System.Windows.Forms.Button();
            this.btnSetupLocalMode = new System.Windows.Forms.Button();
            this.btnSetupDbSync = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTitleConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panelTitleWhite.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSetup
            // 
            this.panelSetup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSetup.Location = new System.Drawing.Point(7, 61);
            this.panelSetup.Name = "panelSetup";
            this.panelSetup.Size = new System.Drawing.Size(850, 700);
            this.panelSetup.TabIndex = 42;
            // 
            // panelTitleConsole
            // 
            this.panelTitleConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.panelTitleConsole.Controls.Add(this.picLogo);
            this.panelTitleConsole.Controls.Add(this.btnClose);
            this.panelTitleConsole.Controls.Add(this.lblReportTitle);
            this.panelTitleConsole.Location = new System.Drawing.Point(0, 0);
            this.panelTitleConsole.Name = "panelTitleConsole";
            this.panelTitleConsole.Size = new System.Drawing.Size(1009, 42);
            this.panelTitleConsole.TabIndex = 32;
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("picLogo.InitialImage")));
            this.picLogo.Location = new System.Drawing.Point(7, 4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Padding = new System.Windows.Forms.Padding(8);
            this.picLogo.Size = new System.Drawing.Size(80, 35);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 39;
            this.picLogo.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.LightGray;
            this.btnClose.Location = new System.Drawing.Point(968, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(39, 38);
            this.btnClose.TabIndex = 38;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReportTitle.ForeColor = System.Drawing.Color.White;
            this.lblReportTitle.Location = new System.Drawing.Point(456, 11);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(49, 19);
            this.lblReportTitle.TabIndex = 26;
            this.lblReportTitle.Text = "설정";
            // 
            // panelTitleWhite
            // 
            this.panelTitleWhite.BackColor = System.Drawing.Color.Gray;
            this.panelTitleWhite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitleWhite.Controls.Add(this.panelTitleConsole);
            this.panelTitleWhite.ForeColor = System.Drawing.Color.White;
            this.panelTitleWhite.Location = new System.Drawing.Point(6, 8);
            this.panelTitleWhite.Margin = new System.Windows.Forms.Padding(1);
            this.panelTitleWhite.Name = "panelTitleWhite";
            this.panelTitleWhite.Padding = new System.Windows.Forms.Padding(1);
            this.panelTitleWhite.Size = new System.Drawing.Size(1011, 44);
            this.panelTitleWhite.TabIndex = 43;
            // 
            // btnSetupPos
            // 
            this.btnSetupPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSetupPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetupPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnSetupPos.ForeColor = System.Drawing.Color.White;
            this.btnSetupPos.Location = new System.Drawing.Point(0, 0);
            this.btnSetupPos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSetupPos.Name = "btnSetupPos";
            this.btnSetupPos.Size = new System.Drawing.Size(150, 80);
            this.btnSetupPos.TabIndex = 27;
            this.btnSetupPos.TabStop = false;
            this.btnSetupPos.Text = "포스기기";
            this.btnSetupPos.UseVisualStyleBackColor = false;
            this.btnSetupPos.Click += new System.EventHandler(this.btnSetupPos_Click);
            // 
            // btnSetupLocalMode
            // 
            this.btnSetupLocalMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSetupLocalMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetupLocalMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnSetupLocalMode.ForeColor = System.Drawing.Color.White;
            this.btnSetupLocalMode.Location = new System.Drawing.Point(0, 168);
            this.btnSetupLocalMode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSetupLocalMode.Name = "btnSetupLocalMode";
            this.btnSetupLocalMode.Size = new System.Drawing.Size(150, 80);
            this.btnSetupLocalMode.TabIndex = 27;
            this.btnSetupLocalMode.TabStop = false;
            this.btnSetupLocalMode.Text = "긴급사용\r\n대이터";
            this.btnSetupLocalMode.UseVisualStyleBackColor = false;
            this.btnSetupLocalMode.Click += new System.EventHandler(this.btnSetupLocalMode_Click);
            // 
            // btnSetupDbSync
            // 
            this.btnSetupDbSync.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSetupDbSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetupDbSync.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnSetupDbSync.ForeColor = System.Drawing.Color.White;
            this.btnSetupDbSync.Location = new System.Drawing.Point(0, 84);
            this.btnSetupDbSync.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSetupDbSync.Name = "btnSetupDbSync";
            this.btnSetupDbSync.Size = new System.Drawing.Size(150, 80);
            this.btnSetupDbSync.TabIndex = 27;
            this.btnSetupDbSync.TabStop = false;
            this.btnSetupDbSync.Text = "기초원장";
            this.btnSetupDbSync.UseVisualStyleBackColor = false;
            this.btnSetupDbSync.Click += new System.EventHandler(this.btnSetupDbSync_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSetupLocalMode);
            this.panel1.Controls.Add(this.btnSetupDbSync);
            this.panel1.Controls.Add(this.btnSetupPos);
            this.panel1.Location = new System.Drawing.Point(864, 61);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(155, 700);
            this.panel1.TabIndex = 41;
            // 
            // frmSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.panelSetup);
            this.Controls.Add(this.panelTitleWhite);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSetup";
            this.panelTitleConsole.ResumeLayout(false);
            this.panelTitleConsole.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panelTitleWhite.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSetup;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel panelTitleConsole;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.Panel panelTitleWhite;
        private System.Windows.Forms.Button btnSetupPos;
        private System.Windows.Forms.Button btnSetupLocalMode;
        private System.Windows.Forms.Button btnSetupDbSync;
        private System.Windows.Forms.Panel panel1;
    }
}