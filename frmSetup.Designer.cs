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
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelTitleWhite = new System.Windows.Forms.Panel();
            this.btnSetupPos = new System.Windows.Forms.Button();
            this.btnLocalDbUp = new System.Windows.Forms.Button();
            this.btnBasicDbDown = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTitleConsole.SuspendLayout();
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
            this.panelTitleConsole.Controls.Add(this.btnClose);
            this.panelTitleConsole.Controls.Add(this.lblTitle);
            this.panelTitleConsole.Location = new System.Drawing.Point(0, 0);
            this.panelTitleConsole.Name = "panelTitleConsole";
            this.panelTitleConsole.Size = new System.Drawing.Size(1009, 42);
            this.panelTitleConsole.TabIndex = 32;
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
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(456, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(49, 19);
            this.lblTitle.TabIndex = 26;
            this.lblTitle.Text = "설정";
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
            this.btnSetupPos.Text = "내기기설정";
            this.btnSetupPos.UseVisualStyleBackColor = false;
            this.btnSetupPos.Click += new System.EventHandler(this.btnSetupPos_Click);
            // 
            // btnLocalDbUp
            // 
            this.btnLocalDbUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLocalDbUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocalDbUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnLocalDbUp.ForeColor = System.Drawing.Color.White;
            this.btnLocalDbUp.Location = new System.Drawing.Point(0, 168);
            this.btnLocalDbUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLocalDbUp.Name = "btnLocalDbUp";
            this.btnLocalDbUp.Size = new System.Drawing.Size(150, 80);
            this.btnLocalDbUp.TabIndex = 27;
            this.btnLocalDbUp.TabStop = false;
            this.btnLocalDbUp.Text = "긴급사용\r\n대이터";
            this.btnLocalDbUp.UseVisualStyleBackColor = false;
            this.btnLocalDbUp.Click += new System.EventHandler(this.btnSetupLocalMode_Click);
            // 
            // btnBasicDbDown
            // 
            this.btnBasicDbDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBasicDbDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBasicDbDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnBasicDbDown.ForeColor = System.Drawing.Color.White;
            this.btnBasicDbDown.Location = new System.Drawing.Point(0, 84);
            this.btnBasicDbDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBasicDbDown.Name = "btnBasicDbDown";
            this.btnBasicDbDown.Size = new System.Drawing.Size(150, 80);
            this.btnBasicDbDown.TabIndex = 27;
            this.btnBasicDbDown.TabStop = false;
            this.btnBasicDbDown.Text = "기초원장";
            this.btnBasicDbDown.UseVisualStyleBackColor = false;
            this.btnBasicDbDown.Click += new System.EventHandler(this.btnSetupDbSync_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnLocalDbUp);
            this.panel1.Controls.Add(this.btnBasicDbDown);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSetup";
            this.panelTitleConsole.ResumeLayout(false);
            this.panelTitleConsole.PerformLayout();
            this.panelTitleWhite.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSetup;
        private System.Windows.Forms.Panel panelTitleConsole;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelTitleWhite;
        private System.Windows.Forms.Button btnSetupPos;
        private System.Windows.Forms.Button btnLocalDbUp;
        private System.Windows.Forms.Button btnBasicDbDown;
        private System.Windows.Forms.Panel panel1;
    }
}