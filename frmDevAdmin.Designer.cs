namespace thepos
{
    partial class frmDevAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDevAdmin));
            this.cbTest = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbSiteID = new System.Windows.Forms.TextBox();
            this.tbPosNo = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLoginDev = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbTest
            // 
            this.cbTest.AutoSize = true;
            this.cbTest.Checked = true;
            this.cbTest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTest.ForeColor = System.Drawing.Color.LightGray;
            this.cbTest.Location = new System.Drawing.Point(13, 68);
            this.cbTest.Margin = new System.Windows.Forms.Padding(4);
            this.cbTest.Name = "cbTest";
            this.cbTest.Size = new System.Drawing.Size(56, 16);
            this.cbTest.TabIndex = 2;
            this.cbTest.Text = "TEST";
            this.cbTest.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(104, 67);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 25);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbSiteID
            // 
            this.tbSiteID.BackColor = System.Drawing.Color.DarkGray;
            this.tbSiteID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSiteID.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSiteID.Location = new System.Drawing.Point(13, 12);
            this.tbSiteID.Margin = new System.Windows.Forms.Padding(4);
            this.tbSiteID.Name = "tbSiteID";
            this.tbSiteID.Size = new System.Drawing.Size(73, 15);
            this.tbSiteID.TabIndex = 0;
            // 
            // tbPosNo
            // 
            this.tbPosNo.BackColor = System.Drawing.Color.DarkGray;
            this.tbPosNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPosNo.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPosNo.Location = new System.Drawing.Point(13, 35);
            this.tbPosNo.Margin = new System.Windows.Forms.Padding(4);
            this.tbPosNo.Name = "tbPosNo";
            this.tbPosNo.Size = new System.Drawing.Size(73, 15);
            this.tbPosNo.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(104, 40);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(70, 25);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLoginDev
            // 
            this.btnLoginDev.Location = new System.Drawing.Point(104, 13);
            this.btnLoginDev.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoginDev.Name = "btnLoginDev";
            this.btnLoginDev.Size = new System.Drawing.Size(70, 25);
            this.btnLoginDev.TabIndex = 3;
            this.btnLoginDev.Text = "loginDev";
            this.btnLoginDev.UseVisualStyleBackColor = true;
            this.btnLoginDev.Click += new System.EventHandler(this.btnLoginDev_Click);
            // 
            // frmDevAdmin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(180, 100);
            this.Controls.Add(this.btnLoginDev);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbTest);
            this.Controls.Add(this.tbPosNo);
            this.Controls.Add(this.tbSiteID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDevAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmDevAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cbTest;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.TextBox tbSiteID;
        public System.Windows.Forms.TextBox tbPosNo;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLoginDev;
    }
}