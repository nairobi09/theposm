namespace thepos
{
    partial class frmReportDayPos
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
            this.lvwList = new System.Windows.Forms.ListView();
            this.pos_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.net_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount_cash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount_card = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount_easy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnView = new System.Windows.Forms.Button();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.dtpBizDate = new System.Windows.Forms.DateTimePicker();
            this.amount_cert = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwList
            // 
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pos_no,
            this.net_amount,
            this.amount_cash,
            this.amount_card,
            this.amount_easy,
            this.amount_cert});
            this.lvwList.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(20, 70);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(760, 610);
            this.lvwList.TabIndex = 87;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            // 
            // pos_no
            // 
            this.pos_no.Text = "포스번호";
            this.pos_no.Width = 80;
            // 
            // net_amount
            // 
            this.net_amount.Text = "매출금액";
            this.net_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.net_amount.Width = 100;
            // 
            // amount_cash
            // 
            this.amount_cash.Text = "현금금액";
            this.amount_cash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount_cash.Width = 90;
            // 
            // amount_card
            // 
            this.amount_card.Text = "카드금액";
            this.amount_card.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount_card.Width = 90;
            // 
            // amount_easy
            // 
            this.amount_easy.Text = "간편금액";
            this.amount_easy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount_easy.Width = 90;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnView.Location = new System.Drawing.Point(410, 27);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 27);
            this.btnView.TabIndex = 86;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReportTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.lblReportTitle.Location = new System.Drawing.Point(25, 33);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(110, 14);
            this.lblReportTitle.TabIndex = 85;
            this.lblReportTitle.Text = "포스별 매출현황";
            this.lblReportTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpBizDate
            // 
            this.dtpBizDate.CalendarFont = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpBizDate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpBizDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBizDate.Location = new System.Drawing.Point(284, 29);
            this.dtpBizDate.Name = "dtpBizDate";
            this.dtpBizDate.Size = new System.Drawing.Size(110, 23);
            this.dtpBizDate.TabIndex = 88;
            // 
            // amount_cert
            // 
            this.amount_cert.Text = "쿠폰금액";
            this.amount_cert.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount_cert.Width = 90;
            // 
            // frmReportDayPos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.lvwList);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lblReportTitle);
            this.Controls.Add(this.dtpBizDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportDayPos";
            this.Text = "frmReportDayPos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader pos_no;
        private System.Windows.Forms.ColumnHeader net_amount;
        private System.Windows.Forms.ColumnHeader amount_cash;
        private System.Windows.Forms.ColumnHeader amount_card;
        private System.Windows.Forms.ColumnHeader amount_easy;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.DateTimePicker dtpBizDate;
        private System.Windows.Forms.ColumnHeader amount_cert;
    }
}