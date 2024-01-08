namespace thepos
{
    partial class frmReportShopOrder
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
            this.btnView = new System.Windows.Forms.Button();
            this.lvwList = new System.Windows.Forms.ListView();
            this.shop_order_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.shop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pos_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.item_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.item_cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.is_cancel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtpBizDate = new System.Windows.Forms.DateTimePicker();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.cbShop = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnView.Location = new System.Drawing.Point(475, 24);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 27);
            this.btnView.TabIndex = 11;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lvwList
            // 
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.shop_order_no,
            this.shop,
            this.dt,
            this.pos_no,
            this.item_name,
            this.item_cnt,
            this.is_cancel});
            this.lvwList.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(20, 70);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(760, 604);
            this.lvwList.TabIndex = 6;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            // 
            // shop_order_no
            // 
            this.shop_order_no.Text = "주문번호";
            this.shop_order_no.Width = 70;
            // 
            // shop
            // 
            this.shop.Text = "업장";
            this.shop.Width = 70;
            // 
            // dt
            // 
            this.dt.Text = "일시";
            this.dt.Width = 100;
            // 
            // pos_no
            // 
            this.pos_no.Text = "포스";
            this.pos_no.Width = 45;
            // 
            // item_name
            // 
            this.item_name.Text = "상품명";
            this.item_name.Width = 100;
            // 
            // item_cnt
            // 
            this.item_cnt.Text = "수량";
            this.item_cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // is_cancel
            // 
            this.is_cancel.Text = "취소";
            // 
            // dtpBizDate
            // 
            this.dtpBizDate.CalendarFont = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpBizDate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpBizDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBizDate.Location = new System.Drawing.Point(261, 26);
            this.dtpBizDate.Name = "dtpBizDate";
            this.dtpBizDate.Size = new System.Drawing.Size(110, 23);
            this.dtpBizDate.TabIndex = 10;
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReportTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.lblReportTitle.Location = new System.Drawing.Point(25, 33);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(110, 14);
            this.lblReportTitle.TabIndex = 7;
            this.lblReportTitle.Text = "업장별 주문내역";
            this.lblReportTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbShop
            // 
            this.cbShop.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbShop.FormattingEnabled = true;
            this.cbShop.Location = new System.Drawing.Point(377, 26);
            this.cbShop.Name = "cbShop";
            this.cbShop.Size = new System.Drawing.Size(92, 24);
            this.cbShop.TabIndex = 93;
            this.cbShop.TabStop = false;
            // 
            // frmReportShopOrder
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.cbShop);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lvwList);
            this.Controls.Add(this.dtpBizDate);
            this.Controls.Add(this.lblReportTitle);
            this.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportShopOrder";
            this.Text = "frmReportShopOreder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader shop_order_no;
        private System.Windows.Forms.ColumnHeader pos_no;
        private System.Windows.Forms.ColumnHeader dt;
        private System.Windows.Forms.ColumnHeader is_cancel;
        private System.Windows.Forms.ColumnHeader item_cnt;
        private System.Windows.Forms.ColumnHeader shop;
        private System.Windows.Forms.DateTimePicker dtpBizDate;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.ColumnHeader item_name;
        private System.Windows.Forms.ComboBox cbShop;
    }
}