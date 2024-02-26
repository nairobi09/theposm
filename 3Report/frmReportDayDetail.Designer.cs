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
            this.dc_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.net_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.is_cancel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.paykeep = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.trantype = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.lvwOrder = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dc_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.net_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwPayment = new System.Windows.Forms.ListView();
            this.p_seq_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.p_tran_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.p_pay_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.p_net_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.p_cardno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.acq_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.p_authno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.p_is_cancel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtpBizDate = new System.Windows.Forms.DateTimePicker();
            this.btnView = new System.Windows.Forms.Button();
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
            this.paykeep,
            this.trantype});
            this.lvwList.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(20, 70);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(760, 353);
            this.lvwList.TabIndex = 0;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            this.lvwList.SelectedIndexChanged += new System.EventHandler(this.lvwList_SelectedIndexChanged);
            // 
            // the_no
            // 
            this.the_no.Text = "######";
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
            // dc_amt
            // 
            this.dc_amt.Text = "할인";
            this.dc_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dc_amt.Width = 80;
            // 
            // net_amt
            // 
            this.net_amt.Text = "금액";
            this.net_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.net_amt.Width = 80;
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
            // trantype
            // 
            this.trantype.Text = "";
            this.trantype.Width = 0;
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReportTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.lblReportTitle.Location = new System.Drawing.Point(25, 33);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(91, 14);
            this.lblReportTitle.TabIndex = 1;
            this.lblReportTitle.Text = "일별매출상세";
            this.lblReportTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lvwOrder.GridLines = true;
            this.lvwOrder.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwOrder.HideSelection = false;
            this.lvwOrder.Location = new System.Drawing.Point(20, 431);
            this.lvwOrder.MultiSelect = false;
            this.lvwOrder.Name = "lvwOrder";
            this.lvwOrder.Size = new System.Drawing.Size(760, 139);
            this.lvwOrder.TabIndex = 2;
            this.lvwOrder.UseCompatibleStateImageBehavior = false;
            this.lvwOrder.View = System.Windows.Forms.View.Details;
            // 
            // no
            // 
            this.no.Text = "#주문";
            this.no.Width = 50;
            // 
            // name
            // 
            this.name.Text = "상품명";
            this.name.Width = 200;
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
            this.lvwPayment.GridLines = true;
            this.lvwPayment.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwPayment.HideSelection = false;
            this.lvwPayment.Location = new System.Drawing.Point(20, 574);
            this.lvwPayment.MultiSelect = false;
            this.lvwPayment.Name = "lvwPayment";
            this.lvwPayment.Size = new System.Drawing.Size(760, 106);
            this.lvwPayment.TabIndex = 3;
            this.lvwPayment.UseCompatibleStateImageBehavior = false;
            this.lvwPayment.View = System.Windows.Forms.View.Details;
            // 
            // p_seq_no
            // 
            this.p_seq_no.Text = "#결제";
            this.p_seq_no.Width = 50;
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
            this.p_cardno.Width = 100;
            // 
            // type2
            // 
            this.type2.Text = "유형";
            this.type2.Width = 80;
            // 
            // acq_name
            // 
            this.acq_name.Text = "기관";
            this.acq_name.Width = 110;
            // 
            // p_authno
            // 
            this.p_authno.Text = "승인번호";
            this.p_authno.Width = 90;
            // 
            // p_is_cancel
            // 
            this.p_is_cancel.Text = "취소";
            // 
            // dtpBizDate
            // 
            this.dtpBizDate.CalendarFont = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpBizDate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpBizDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBizDate.Location = new System.Drawing.Point(270, 27);
            this.dtpBizDate.Name = "dtpBizDate";
            this.dtpBizDate.Size = new System.Drawing.Size(110, 23);
            this.dtpBizDate.TabIndex = 4;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnView.Location = new System.Drawing.Point(386, 27);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 27);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // frmReportDayDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.dtpBizDate);
            this.Controls.Add(this.lvwPayment);
            this.Controls.Add(this.lvwOrder);
            this.Controls.Add(this.lblReportTitle);
            this.Controls.Add(this.lvwList);
            this.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
        private System.Windows.Forms.DateTimePicker dtpBizDate;
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
        private System.Windows.Forms.ColumnHeader trantype;
    }
}