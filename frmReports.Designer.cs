namespace thepos
{
    partial class frmReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReports));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReportDayDetail = new System.Windows.Forms.Button();
            this.btnReportDayShop = new System.Windows.Forms.Button();
            this.btnReportDayPos = new System.Windows.Forms.Button();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.panelTitleWhite = new System.Windows.Forms.Panel();
            this.panelTitleConsole = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelReport = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnReportList1 = new System.Windows.Forms.Button();
            this.btnReportChart1 = new System.Windows.Forms.Button();
            this.btnReportCalendar1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelTitleWhite.SuspendLayout();
            this.panelTitleConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnReportDayDetail);
            this.panel1.Controls.Add(this.btnReportDayShop);
            this.panel1.Controls.Add(this.btnReportList1);
            this.panel1.Controls.Add(this.btnReportChart1);
            this.panel1.Controls.Add(this.btnReportCalendar1);
            this.panel1.Controls.Add(this.btnReportDayPos);
            this.panel1.Location = new System.Drawing.Point(811, 59);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 700);
            this.panel1.TabIndex = 38;
            // 
            // btnReportDayDetail
            // 
            this.btnReportDayDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnReportDayDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportDayDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnReportDayDetail.ForeColor = System.Drawing.Color.White;
            this.btnReportDayDetail.Location = new System.Drawing.Point(0, 168);
            this.btnReportDayDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReportDayDetail.Name = "btnReportDayDetail";
            this.btnReportDayDetail.Size = new System.Drawing.Size(110, 80);
            this.btnReportDayDetail.TabIndex = 27;
            this.btnReportDayDetail.TabStop = false;
            this.btnReportDayDetail.Text = "일별매출상세";
            this.btnReportDayDetail.UseVisualStyleBackColor = false;
            this.btnReportDayDetail.Click += new System.EventHandler(this.btnReportDayDetail_Click);
            // 
            // btnReportDayShop
            // 
            this.btnReportDayShop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnReportDayShop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportDayShop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnReportDayShop.ForeColor = System.Drawing.Color.White;
            this.btnReportDayShop.Location = new System.Drawing.Point(0, 84);
            this.btnReportDayShop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReportDayShop.Name = "btnReportDayShop";
            this.btnReportDayShop.Size = new System.Drawing.Size(110, 80);
            this.btnReportDayShop.TabIndex = 27;
            this.btnReportDayShop.TabStop = false;
            this.btnReportDayShop.Text = "업장별 매출";
            this.btnReportDayShop.UseVisualStyleBackColor = false;
            this.btnReportDayShop.Click += new System.EventHandler(this.btnReportDayShop_Click);
            // 
            // btnReportDayPos
            // 
            this.btnReportDayPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnReportDayPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportDayPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnReportDayPos.ForeColor = System.Drawing.Color.White;
            this.btnReportDayPos.Location = new System.Drawing.Point(0, 0);
            this.btnReportDayPos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReportDayPos.Name = "btnReportDayPos";
            this.btnReportDayPos.Size = new System.Drawing.Size(110, 80);
            this.btnReportDayPos.TabIndex = 27;
            this.btnReportDayPos.TabStop = false;
            this.btnReportDayPos.Text = "포스별 매출";
            this.btnReportDayPos.UseVisualStyleBackColor = false;
            this.btnReportDayPos.Click += new System.EventHandler(this.btnReportDayPos_Click);
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReportTitle.ForeColor = System.Drawing.Color.White;
            this.lblReportTitle.Location = new System.Drawing.Point(456, 11);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(89, 19);
            this.lblReportTitle.TabIndex = 26;
            this.lblReportTitle.Text = "매출관리";
            // 
            // panelTitleWhite
            // 
            this.panelTitleWhite.BackColor = System.Drawing.Color.Gray;
            this.panelTitleWhite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitleWhite.Controls.Add(this.panelTitleConsole);
            this.panelTitleWhite.ForeColor = System.Drawing.Color.White;
            this.panelTitleWhite.Location = new System.Drawing.Point(6, 6);
            this.panelTitleWhite.Margin = new System.Windows.Forms.Padding(1);
            this.panelTitleWhite.Name = "panelTitleWhite";
            this.panelTitleWhite.Padding = new System.Windows.Forms.Padding(1);
            this.panelTitleWhite.Size = new System.Drawing.Size(1011, 44);
            this.panelTitleWhite.TabIndex = 40;
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
            // panelReport
            // 
            this.panelReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReport.Location = new System.Drawing.Point(7, 59);
            this.panelReport.Name = "panelReport";
            this.panelReport.Size = new System.Drawing.Size(800, 700);
            this.panelReport.TabIndex = 39;
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
            // btnReportList1
            // 
            this.btnReportList1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnReportList1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnReportList1.ForeColor = System.Drawing.Color.White;
            this.btnReportList1.Image = ((System.Drawing.Image)(resources.GetObject("btnReportList1.Image")));
            this.btnReportList1.Location = new System.Drawing.Point(113, 168);
            this.btnReportList1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReportList1.Name = "btnReportList1";
            this.btnReportList1.Size = new System.Drawing.Size(90, 80);
            this.btnReportList1.TabIndex = 27;
            this.btnReportList1.TabStop = false;
            this.btnReportList1.UseVisualStyleBackColor = false;
            this.btnReportList1.Click += new System.EventHandler(this.btnReportList1_Click);
            // 
            // btnReportChart1
            // 
            this.btnReportChart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnReportChart1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportChart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnReportChart1.ForeColor = System.Drawing.Color.White;
            this.btnReportChart1.Image = ((System.Drawing.Image)(resources.GetObject("btnReportChart1.Image")));
            this.btnReportChart1.Location = new System.Drawing.Point(113, 84);
            this.btnReportChart1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReportChart1.Name = "btnReportChart1";
            this.btnReportChart1.Size = new System.Drawing.Size(90, 80);
            this.btnReportChart1.TabIndex = 27;
            this.btnReportChart1.TabStop = false;
            this.btnReportChart1.UseVisualStyleBackColor = false;
            this.btnReportChart1.Click += new System.EventHandler(this.btnReportChart1_Click);
            // 
            // btnReportCalendar1
            // 
            this.btnReportCalendar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnReportCalendar1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportCalendar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnReportCalendar1.ForeColor = System.Drawing.Color.White;
            this.btnReportCalendar1.Image = ((System.Drawing.Image)(resources.GetObject("btnReportCalendar1.Image")));
            this.btnReportCalendar1.Location = new System.Drawing.Point(113, 0);
            this.btnReportCalendar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReportCalendar1.Name = "btnReportCalendar1";
            this.btnReportCalendar1.Size = new System.Drawing.Size(90, 80);
            this.btnReportCalendar1.TabIndex = 27;
            this.btnReportCalendar1.TabStop = false;
            this.btnReportCalendar1.UseVisualStyleBackColor = false;
            this.btnReportCalendar1.Click += new System.EventHandler(this.btnReportCalendar1_Click);
            // 
            // frmReports
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.panelTitleWhite);
            this.Controls.Add(this.panelReport);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmReports";
            this.panel1.ResumeLayout(false);
            this.panelTitleWhite.ResumeLayout(false);
            this.panelTitleConsole.ResumeLayout(false);
            this.panelTitleConsole.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReportDayDetail;
        private System.Windows.Forms.Button btnReportDayShop;
        private System.Windows.Forms.Button btnReportList1;
        private System.Windows.Forms.Button btnReportChart1;
        private System.Windows.Forms.Button btnReportCalendar1;
        private System.Windows.Forms.Button btnReportDayPos;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.Panel panelTitleWhite;
        private System.Windows.Forms.Panel panelTitleConsole;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelReport;
    }
}