namespace thepos
{
    partial class frmSetupDbSync
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.lblServerVersion = new System.Windows.Forms.Label();
            this.lblLocalVersion = new System.Windows.Forms.Label();
            this.lblVersionTitle = new System.Windows.Forms.Label();
            this.lblServerTitle = new System.Windows.Forms.Label();
            this.lblLocalTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.Location = new System.Drawing.Point(37, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(110, 14);
            this.lblTitle.TabIndex = 48;
            this.lblTitle.Text = "기초원장 동기화";
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDownload.ForeColor = System.Drawing.Color.White;
            this.btnDownload.Location = new System.Drawing.Point(593, 278);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(140, 50);
            this.btnDownload.TabIndex = 55;
            this.btnDownload.TabStop = false;
            this.btnDownload.Text = "다운로드";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnView.Location = new System.Drawing.Point(593, 234);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(140, 40);
            this.btnView.TabIndex = 54;
            this.btnView.TabStop = false;
            this.btnView.Text = "버전보기";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblServerVersion
            // 
            this.lblServerVersion.BackColor = System.Drawing.Color.LightGray;
            this.lblServerVersion.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblServerVersion.ForeColor = System.Drawing.Color.Black;
            this.lblServerVersion.Location = new System.Drawing.Point(247, 244);
            this.lblServerVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lblServerVersion.Name = "lblServerVersion";
            this.lblServerVersion.Padding = new System.Windows.Forms.Padding(5);
            this.lblServerVersion.Size = new System.Drawing.Size(260, 40);
            this.lblServerVersion.TabIndex = 76;
            this.lblServerVersion.Text = "0";
            this.lblServerVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLocalVersion
            // 
            this.lblLocalVersion.BackColor = System.Drawing.Color.LightGray;
            this.lblLocalVersion.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLocalVersion.ForeColor = System.Drawing.Color.Black;
            this.lblLocalVersion.Location = new System.Drawing.Point(247, 288);
            this.lblLocalVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lblLocalVersion.Name = "lblLocalVersion";
            this.lblLocalVersion.Padding = new System.Windows.Forms.Padding(5);
            this.lblLocalVersion.Size = new System.Drawing.Size(260, 40);
            this.lblLocalVersion.TabIndex = 75;
            this.lblLocalVersion.Text = "0";
            this.lblLocalVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVersionTitle
            // 
            this.lblVersionTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVersionTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblVersionTitle.ForeColor = System.Drawing.Color.White;
            this.lblVersionTitle.Location = new System.Drawing.Point(247, 200);
            this.lblVersionTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblVersionTitle.Name = "lblVersionTitle";
            this.lblVersionTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblVersionTitle.Size = new System.Drawing.Size(260, 40);
            this.lblVersionTitle.TabIndex = 70;
            this.lblVersionTitle.Text = "버전";
            this.lblVersionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblServerTitle
            // 
            this.lblServerTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblServerTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblServerTitle.ForeColor = System.Drawing.Color.White;
            this.lblServerTitle.Location = new System.Drawing.Point(118, 244);
            this.lblServerTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblServerTitle.Name = "lblServerTitle";
            this.lblServerTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblServerTitle.Size = new System.Drawing.Size(125, 40);
            this.lblServerTitle.TabIndex = 69;
            this.lblServerTitle.Text = "서버DB";
            this.lblServerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLocalTitle
            // 
            this.lblLocalTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLocalTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLocalTitle.ForeColor = System.Drawing.Color.White;
            this.lblLocalTitle.Location = new System.Drawing.Point(118, 288);
            this.lblLocalTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblLocalTitle.Name = "lblLocalTitle";
            this.lblLocalTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblLocalTitle.Size = new System.Drawing.Size(125, 40);
            this.lblLocalTitle.TabIndex = 67;
            this.lblLocalTitle.Text = "로컬DB";
            this.lblLocalTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSetupDbSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 700);
            this.Controls.Add(this.lblServerVersion);
            this.Controls.Add(this.lblLocalVersion);
            this.Controls.Add(this.lblVersionTitle);
            this.Controls.Add(this.lblServerTitle);
            this.Controls.Add(this.lblLocalTitle);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSetupDbSync";
            this.Text = "frmSetupDbSync";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblServerVersion;
        private System.Windows.Forms.Label lblLocalVersion;
        private System.Windows.Forms.Label lblVersionTitle;
        private System.Windows.Forms.Label lblServerTitle;
        private System.Windows.Forms.Label lblLocalTitle;
    }
}