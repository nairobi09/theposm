namespace thepos
{
    partial class frmSysAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysAdmin));
            this.btnPosMac = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.panelView = new System.Windows.Forms.Panel();
            this.panelConsole = new System.Windows.Forms.Panel();
            this.btnSite = new System.Windows.Forms.Button();
            this.btnPos = new System.Windows.Forms.Button();
            this.panelConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPosMac
            // 
            this.btnPosMac.Location = new System.Drawing.Point(3, 59);
            this.btnPosMac.Name = "btnPosMac";
            this.btnPosMac.Size = new System.Drawing.Size(100, 50);
            this.btnPosMac.TabIndex = 0;
            this.btnPosMac.Text = "포스기기등록";
            this.btnPosMac.UseVisualStyleBackColor = true;
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(3, 115);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(100, 50);
            this.btnUser.TabIndex = 0;
            this.btnUser.Text = "사용자인증";
            this.btnUser.UseVisualStyleBackColor = true;
            // 
            // panelView
            // 
            this.panelView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelView.Location = new System.Drawing.Point(8, 2);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(500, 400);
            this.panelView.TabIndex = 1;
            // 
            // panelConsole
            // 
            this.panelConsole.Controls.Add(this.btnSite);
            this.panelConsole.Controls.Add(this.btnPos);
            this.panelConsole.Controls.Add(this.btnPosMac);
            this.panelConsole.Controls.Add(this.btnUser);
            this.panelConsole.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelConsole.Location = new System.Drawing.Point(511, 0);
            this.panelConsole.Name = "panelConsole";
            this.panelConsole.Size = new System.Drawing.Size(110, 410);
            this.panelConsole.TabIndex = 2;
            // 
            // btnSite
            // 
            this.btnSite.Location = new System.Drawing.Point(3, 348);
            this.btnSite.Name = "btnSite";
            this.btnSite.Size = new System.Drawing.Size(100, 50);
            this.btnSite.TabIndex = 0;
            this.btnSite.Text = "SITE등록";
            this.btnSite.UseVisualStyleBackColor = true;
            this.btnSite.Click += new System.EventHandler(this.btnSite_Click);
            // 
            // btnPos
            // 
            this.btnPos.Location = new System.Drawing.Point(3, 3);
            this.btnPos.Name = "btnPos";
            this.btnPos.Size = new System.Drawing.Size(100, 50);
            this.btnPos.TabIndex = 0;
            this.btnPos.Text = "POS등록";
            this.btnPos.UseVisualStyleBackColor = true;
            // 
            // frmSysAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 410);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.panelConsole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSysAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SysAdmin";
            this.panelConsole.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPosMac;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.Panel panelConsole;
        private System.Windows.Forms.Button btnSite;
        private System.Windows.Forms.Button btnPos;
    }
}