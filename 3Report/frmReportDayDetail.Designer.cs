namespace thepos
{
    partial class frmReportDayDetail
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
            this.the_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tran_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pos_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay_class = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.net_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dc_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.is_cancel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.paykeep = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.lvwOrder = new System.Windows.Forms.ListView();
            this.lvwPayment = new System.Windows.Forms.ListView();
            this.dpkBizDate = new System.Windows.Forms.DateTimePicker();
            this.btnView = new System.Windows.Forms.Button();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dc_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.net_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.p_seq_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.p_tran_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.p_pay_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.p_net_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.p_cardno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.acq_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.p_authno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.p_is_cancel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwList
            // 
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.the_no,
            this.tran_type,
            this.pos_no,
            this.dt,
            this.pay_class,
            this.pay,
            this.dc_amt,
            this.net_amt,
            this.is_cancel,
            this.paykeep});
            this.lvwList.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(20, 70);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(760, 333);
            this.lvwList.TabIndex = 0;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            this.lvwList.SelectedIndexChanged += new System.EventHandler(this.lvwList_SelectedIndexChanged);
            // 
            // the_no
            // 
            this.the_no.Text = "####";
            // 
            // tran_type
            // 
            this.tran_type.Text = "구분";
            // 
            // pos_no
            // 
            this.pos_no.Text = "포스";
            this.pos_no.Width = 45;
            // 
            // dt
            // 
            this.dt.Text = "일시";
            this.dt.Width = 100;
            // 
            // pay_class
            // 
            this.pay_class.Text = "구분";
            // 
            // pay
            // 
            this.pay.Text = "결제";
            // 
            // net_amt
            // 
            this.net_amt.Text = "금액";
            this.net_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.net_amt.Width = 80;
            // 
            // dc_amt
            // 
            this.dc_amt.Text = "할인";
            this.dc_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dc_amt.Width = 80;
            // 
            // is_cancel
            // 
            this.is_cancel.Text = "취소";
            // 
            // paykeep
            // 
            this.paykeep.Text = "";
            this.paykeep.Width = 0;
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReportTitle.ForeColor = System.Drawing.Color.Black;
            this.lblReportTitle.Location = new System.Drawing.Point(26, 31);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(85, 13);
            this.lblReportTitle.TabIndex = 1;
            this.lblReportTitle.Text = "일별매출상세";
            // 
            // lvwOrder
            // 
            this.lvwOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.name,
            this.amt,
            this.cnt,
            this.dc_amount,
            this.net_amount,
            this.memo,
            this.tip});
            this.lvwOrder.FullRowSelect = true;
            this.lvwOrder.GridLines = true;
            this.lvwOrder.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwOrder.Location = new System.Drawing.Point(20, 409);
            this.lvwOrder.MultiSelect = false;
            this.lvwOrder.Name = "lvwOrder";
            this.lvwOrder.Size = new System.Drawing.Size(586, 139);
            this.lvwOrder.TabIndex = 2;
            this.lvwOrder.UseCompatibleStateImageBehavior = false;
            this.lvwOrder.View = System.Windows.Forms.View.Details;
            // 
            // lvwPayment
            // 
            this.lvwPayment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.p_seq_no,
            this.p_tran_type,
            this.p_pay_type,
            this.p_net_amt,
            this.p_cardno,
            this.type2,
            this.acq_name,
            this.p_authno,
            this.p_is_cancel});
            this.lvwPayment.HideSelection = false;
            this.lvwPayment.Location = new System.Drawing.Point(20, 554);
            this.lvwPayment.Name = "lvwPayment";
            this.lvwPayment.Size = new System.Drawing.Size(760, 124);
            this.lvwPayment.TabIndex = 3;
            this.lvwPayment.UseCompatibleStateImageBehavior = false;
            this.lvwPayment.View = System.Windows.Forms.View.Details;
            // 
            // dpkBizDate
            // 
            this.dpkBizDate.CalendarFont = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dpkBizDate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dpkBizDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpkBizDate.Location = new System.Drawing.Point(318, 24);
            this.dpkBizDate.Name = "dpkBizDate";
            this.dpkBizDate.Size = new System.Drawing.Size(139, 23);
            this.dpkBizDate.TabIndex = 4;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(482, 21);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(103, 26);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // no
            // 
            this.no.Text = "#";
            this.no.Width = 30;
            // 
            // name
            // 
            this.name.Text = "상품명";
            this.name.Width = 120;
            // 
            // amt
            // 
            this.amt.Text = "단가";
            this.amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amt.Width = 80;
            // 
            // cnt
            // 
            this.cnt.Text = "수량";
            this.cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cnt.Width = 50;
            // 
            // dc_amount
            // 
            this.dc_amount.Text = "할인";
            this.dc_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dc_amount.Width = 70;
            // 
            // net_amount
            // 
            this.net_amount.Text = "금액";
            this.net_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.net_amount.Width = 70;
            // 
            // memo
            // 
            this.memo.Text = "비고";
            this.memo.Width = 140;
            // 
            // tip
            // 
            this.tip.Text = "";
            this.tip.Width = 0;
            // 
            // p_seq_no
            // 
            this.p_seq_no.Text = "#";
            this.p_seq_no.Width = 30;
            // 
            // p_tran_type
            // 
            this.p_tran_type.Text = "구분";
            // 
            // p_pay_type
            // 
            this.p_pay_type.Text = "결제";
            this.p_pay_type.Width = 100;
            // 
            // p_net_amt
            // 
            this.p_net_amt.Text = "금액";
            this.p_net_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.p_net_amt.Width = 80;
            // 
            // p_cardno
            // 
            this.p_cardno.Text = "번호";
            this.p_cardno.Width = 120;
            // 
            // type2
            // 
            this.type2.Text = "유형";
            this.type2.Width = 80;
            // 
            // acq_name
            // 
            this.acq_name.Text = "기관";
            // 
            // p_authno
            // 
            this.p_authno.Text = "승인번호";
            this.p_authno.Width = 80;
            // 
            // p_is_cancel
            // 
            this.p_is_cancel.Text = "취소";
            // 
            // frmReportDayDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.dpkBizDate);
            this.Controls.Add(this.lvwPayment);
            this.Controls.Add(this.lvwOrder);
            this.Controls.Add(this.lblReportTitle);
            this.Controls.Add(this.lvwList);
            this.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportDayDetail";
            this.Text = "frmReportDayDetail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.ListView lvwOrder;
        private System.Windows.Forms.ListView lvwPayment;
        private System.Windows.Forms.DateTimePicker dpkBizDate;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ColumnHeader the_no;
        private System.Windows.Forms.ColumnHeader pos_no;
        private System.Windows.Forms.ColumnHeader dt;
        private System.Windows.Forms.ColumnHeader tran_type;
        private System.Windows.Forms.ColumnHeader pay_class;
        private System.Windows.Forms.ColumnHeader net_amt;
        private System.Windows.Forms.ColumnHeader dc_amt;
        private System.Windows.Forms.ColumnHeader is_cancel;
        private System.Windows.Forms.ColumnHeader pay;
        private System.Windows.Forms.ColumnHeader paykeep;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader amt;
        private System.Windows.Forms.ColumnHeader cnt;
        private System.Windows.Forms.ColumnHeader dc_amount;
        private System.Windows.Forms.ColumnHeader net_amount;
        private System.Windows.Forms.ColumnHeader memo;
        private System.Windows.Forms.ColumnHeader tip;
        private System.Windows.Forms.ColumnHeader p_seq_no;
        private System.Windows.Forms.ColumnHeader p_tran_type;
        private System.Windows.Forms.ColumnHeader p_pay_type;
        private System.Windows.Forms.ColumnHeader p_net_amt;
        private System.Windows.Forms.ColumnHeader p_cardno;
        private System.Windows.Forms.ColumnHeader type2;
        private System.Windows.Forms.ColumnHeader acq_name;
        private System.Windows.Forms.ColumnHeader p_authno;
        private System.Windows.Forms.ColumnHeader p_is_cancel;
    }
}