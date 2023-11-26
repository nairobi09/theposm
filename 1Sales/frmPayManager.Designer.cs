namespace thepos
{
    partial class frmPayManager
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
            this.panelback = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnScanner = new System.Windows.Forms.Button();
            this.dtBizDt = new System.Windows.Forms.DateTimePicker();
            this.tbBillNo = new System.Windows.Forms.TextBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.cbPosNo = new System.Windows.Forms.ComboBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.lblLayoutBill = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cbGoodsExcept = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lvwPayManager = new System.Windows.Forms.ListView();
            this.bill_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay_class = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.order_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pos_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cancel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.paykeep = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount_etc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount_card = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelback.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.LightGray;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.panel1);
            this.panelback.Controls.Add(this.lblLayoutBill);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Controls.Add(this.cbGoodsExcept);
            this.panelback.Controls.Add(this.btnCancel);
            this.panelback.Controls.Add(this.btnPrint);
            this.panelback.Controls.Add(this.lvwPayManager);
            this.panelback.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Controls.Add(this.btnScanner);
            this.panel1.Controls.Add(this.dtBizDt);
            this.panel1.Controls.Add(this.tbBillNo);
            this.panel1.Controls.Add(this.lbl3);
            this.panel1.Controls.Add(this.cbPosNo);
            this.panel1.Controls.Add(this.lbl2);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Location = new System.Drawing.Point(20, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 67);
            this.panel1.TabIndex = 77;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.lbl1.Location = new System.Drawing.Point(12, 13);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(53, 12);
            this.lbl1.TabIndex = 71;
            this.lbl1.Text = "영업일자";
            // 
            // btnScanner
            // 
            this.btnScanner.BackColor = System.Drawing.Color.White;
            this.btnScanner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScanner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnScanner.Image = global::thepos.Properties.Resources.scanbar2;
            this.btnScanner.Location = new System.Drawing.Point(386, 13);
            this.btnScanner.Name = "btnScanner";
            this.btnScanner.Size = new System.Drawing.Size(80, 40);
            this.btnScanner.TabIndex = 75;
            this.btnScanner.TabStop = false;
            this.btnScanner.UseVisualStyleBackColor = false;
            this.btnScanner.Click += new System.EventHandler(this.btnScanner_Click);
            // 
            // dtBizDt
            // 
            this.dtBizDt.CalendarFont = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtBizDt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtBizDt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBizDt.Location = new System.Drawing.Point(14, 30);
            this.dtBizDt.Name = "dtBizDt";
            this.dtBizDt.Size = new System.Drawing.Size(100, 23);
            this.dtBizDt.TabIndex = 68;
            this.dtBizDt.TabStop = false;
            this.dtBizDt.Value = new System.DateTime(2023, 5, 19, 0, 0, 0, 0);
            // 
            // tbBillNo
            // 
            this.tbBillNo.BackColor = System.Drawing.Color.White;
            this.tbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBillNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbBillNo.Location = new System.Drawing.Point(190, 30);
            this.tbBillNo.MaxLength = 6;
            this.tbBillNo.Name = "tbBillNo";
            this.tbBillNo.Size = new System.Drawing.Size(60, 23);
            this.tbBillNo.TabIndex = 74;
            this.tbBillNo.TabStop = false;
            this.tbBillNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.lbl3.Location = new System.Drawing.Point(190, 13);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(41, 12);
            this.lbl3.TabIndex = 70;
            this.lbl3.Text = "######";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbPosNo
            // 
            this.cbPosNo.BackColor = System.Drawing.Color.White;
            this.cbPosNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbPosNo.FormattingEnabled = true;
            this.cbPosNo.ItemHeight = 13;
            this.cbPosNo.Items.AddRange(new object[] {
            "",
            "01",
            "02",
            "03"});
            this.cbPosNo.Location = new System.Drawing.Point(125, 32);
            this.cbPosNo.Name = "cbPosNo";
            this.cbPosNo.Size = new System.Drawing.Size(50, 21);
            this.cbPosNo.TabIndex = 73;
            this.cbPosNo.TabStop = false;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.lbl2.Location = new System.Drawing.Point(121, 13);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(53, 12);
            this.lbl2.TabIndex = 69;
            this.lbl2.Text = "포스번호";
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnView.Location = new System.Drawing.Point(280, 13);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 40);
            this.btnView.TabIndex = 72;
            this.btnView.TabStop = false;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblLayoutBill
            // 
            this.lblLayoutBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLayoutBill.Font = new System.Drawing.Font("굴림체", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLayoutBill.Location = new System.Drawing.Point(20, 430);
            this.lblLayoutBill.Multiline = true;
            this.lblLayoutBill.Name = "lblLayoutBill";
            this.lblLayoutBill.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblLayoutBill.Size = new System.Drawing.Size(358, 244);
            this.lblLayoutBill.TabIndex = 55;
            this.lblLayoutBill.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(463, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 43;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.lblTitle.Font = new System.Drawing.Font("굴림체", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(483, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "결제내역관리";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbGoodsExcept
            // 
            this.cbGoodsExcept.AutoSize = true;
            this.cbGoodsExcept.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbGoodsExcept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.cbGoodsExcept.Location = new System.Drawing.Point(392, 439);
            this.cbGoodsExcept.Name = "cbGoodsExcept";
            this.cbGoodsExcept.Size = new System.Drawing.Size(110, 18);
            this.cbGoodsExcept.TabIndex = 49;
            this.cbGoodsExcept.TabStop = false;
            this.cbGoodsExcept.Text = "상품내역제외";
            this.cbGoodsExcept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbGoodsExcept.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(392, 512);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 50);
            this.btnCancel.TabIndex = 48;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "결제취소";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.White;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnPrint.Location = new System.Drawing.Point(392, 466);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(110, 40);
            this.btnPrint.TabIndex = 48;
            this.btnPrint.TabStop = false;
            this.btnPrint.Text = "재출력";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lvwPayManager
            // 
            this.lvwPayManager.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.bill_no,
            this.pay_class,
            this.pay_type,
            this.order_dt,
            this.pos_no,
            this.amount,
            this.dc,
            this.cancel,
            this.paykeep});
            this.lvwPayManager.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwPayManager.FullRowSelect = true;
            this.lvwPayManager.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwPayManager.HideSelection = false;
            this.lvwPayManager.Location = new System.Drawing.Point(20, 140);
            this.lvwPayManager.MultiSelect = false;
            this.lvwPayManager.Name = "lvwPayManager";
            this.lvwPayManager.Size = new System.Drawing.Size(483, 284);
            this.lvwPayManager.TabIndex = 44;
            this.lvwPayManager.TabStop = false;
            this.lvwPayManager.UseCompatibleStateImageBehavior = false;
            this.lvwPayManager.View = System.Windows.Forms.View.Details;
            this.lvwPayManager.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvwPayManager_ColumnWidthChanging);
            this.lvwPayManager.SelectedIndexChanged += new System.EventHandler(this.lvwPayManager_SelectedIndexChanged);
            // 
            // bill_no
            // 
            this.bill_no.Text = "######";
            this.bill_no.Width = 67;
            // 
            // pay_class
            // 
            this.pay_class.Text = "유형";
            this.pay_class.Width = 50;
            // 
            // pay_type
            // 
            this.pay_type.Text = "결제";
            this.pay_type.Width = 50;
            // 
            // order_dt
            // 
            this.order_dt.Text = "거래시간";
            this.order_dt.Width = 90;
            // 
            // pos_no
            // 
            this.pos_no.Text = "포스";
            this.pos_no.Width = 40;
            // 
            // amount
            // 
            this.amount.Text = "금액";
            this.amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount.Width = 70;
            // 
            // dc
            // 
            this.dc.Text = "할인";
            this.dc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dc.Width = 40;
            // 
            // cancel
            // 
            this.cancel.Text = "취소";
            this.cancel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cancel.Width = 50;
            // 
            // paykeep
            // 
            this.paykeep.Text = "";
            this.paykeep.Width = 0;
            // 
            // amount_etc
            // 
            this.amount_etc.Text = "기타";
            this.amount_etc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount_etc.Width = 40;
            // 
            // amount_card
            // 
            this.amount_card.Text = "금액";
            this.amount_card.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount_card.Width = 80;
            // 
            // frmPayManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPayManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmSetup";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPayManager_FormClosed);
            this.panelback.ResumeLayout(false);
            this.panelback.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvwPayManager;
        private System.Windows.Forms.CheckBox cbGoodsExcept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ColumnHeader pay_class;
        private System.Windows.Forms.ColumnHeader pos_no;
        private System.Windows.Forms.ColumnHeader bill_no;
        private System.Windows.Forms.ColumnHeader amount_etc;
        private System.Windows.Forms.ColumnHeader amount;
        private System.Windows.Forms.ColumnHeader amount_card;
        private System.Windows.Forms.ColumnHeader dc;
        private System.Windows.Forms.ColumnHeader cancel;
        private System.Windows.Forms.ColumnHeader order_dt;
        private System.Windows.Forms.TextBox lblLayoutBill;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnScanner;
        private System.Windows.Forms.DateTimePicker dtBizDt;
        private System.Windows.Forms.TextBox tbBillNo;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.ComboBox cbPosNo;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ColumnHeader paykeep;
        private System.Windows.Forms.ColumnHeader pay_type;
    }
}