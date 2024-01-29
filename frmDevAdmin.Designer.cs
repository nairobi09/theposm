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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbSiteID = new System.Windows.Forms.TextBox();
            this.tbPosNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbTest
            // 
            this.cbTest.AutoSize = true;
            this.cbTest.Checked = true;
            this.cbTest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTest.ForeColor = System.Drawing.Color.LightGray;
            this.cbTest.Location = new System.Drawing.Point(60, 57);
            this.cbTest.Name = "cbTest";
            this.cbTest.Size = new System.Drawing.Size(56, 16);
            this.cbTest.TabIndex = 2;
            this.cbTest.Text = "TEST";
            this.cbTest.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(87, 84);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(62, 27);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(19, 84);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(62, 27);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbSiteID
            // 
            this.tbSiteID.BackColor = System.Drawing.Color.DarkGray;
            this.tbSiteID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSiteID.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSiteID.Location = new System.Drawing.Point(60, 15);
            this.tbSiteID.Name = "tbSiteID";
            this.tbSiteID.Size = new System.Drawing.Size(89, 15);
            this.tbSiteID.TabIndex = 0;
            // 
            // tbPosNo
            // 
            this.tbPosNo.BackColor = System.Drawing.Color.DarkGray;
            this.tbPosNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPosNo.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPosNo.Location = new System.Drawing.Point(60, 36);
            this.tbPosNo.Name = "tbPosNo";
            this.tbPosNo.Size = new System.Drawing.Size(89, 15);
            this.tbPosNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "SiteID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "PosNo";
            // 
            // frmDevAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(172, 123);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbTest);
            this.Controls.Add(this.tbPosNo);
            this.Controls.Add(this.tbSiteID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDevAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmDevAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cbTest;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.TextBox tbSiteID;
        public System.Windows.Forms.TextBox tbPosNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}