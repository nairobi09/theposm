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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayManager));
            this.panelback = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnReader = new System.Windows.Forms.Button();
            this.dtBusiness = new System.Windows.Forms.DateTimePicker();
            this.tbBillNo = new System.Windows.Forms.TextBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.cbPosNo = new System.Windows.Forms.ComboBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.lblLayoutBill = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cbwithoutGoods = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lvwPayManager = new System.Windows.Forms.ListView();
            this.pay_class = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.order_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tran_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pos_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bill_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cancel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.trantype = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.panelback.Controls.Add(this.cbwithoutGoods);
            this.panelback.Controls.Add(this.button4);
            this.panelback.Controls.Add(this.button1);
            this.panelback.Controls.Add(this.btnCancel);
            this.panelback.Controls.Add(this.btnPrint);
            this.panelback.Controls.Add(this.lvwPayManager);
            this.panelback.Font = new System.Drawing.Font("GulimChe", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Controls.Add(this.btnReader);
            this.panel1.Controls.Add(this.dtBusiness);
            this.panel1.Controls.Add(this.tbBillNo);
            this.panel1.Controls.Add(this.lbl3);
            this.panel1.Controls.Add(this.cbPosNo);
            this.panel1.Controls.Add(this.lbl2);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Location = new System.Drawing.Point(20, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 67);
            this.panel1.TabIndex = 77;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl1.Location = new System.Drawing.Point(12, 14);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(53, 12);
            this.lbl1.TabIndex = 71;
            this.lbl1.Text = "영업일자";
            // 
            // btnReader
            // 
            this.btnReader.BackColor = System.Drawing.Color.White;
            this.btnReader.Image = ((System.Drawing.Image)(resources.GetObject("btnReader.Image")));
            this.btnReader.Location = new System.Drawing.Point(382, 8);
            this.btnReader.Name = "btnReader";
            this.btnReader.Size = new System.Drawing.Size(85, 50);
            this.btnReader.TabIndex = 75;
            this.btnReader.UseVisualStyleBackColor = false;
            // 
            // dtBusiness
            // 
            this.dtBusiness.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBusiness.Location = new System.Drawing.Point(68, 8);
            this.dtBusiness.Name = "dtBusiness";
            this.dtBusiness.Size = new System.Drawing.Size(97, 22);
            this.dtBusiness.TabIndex = 68;
            this.dtBusiness.Value = new System.DateTime(2023, 5, 19, 1, 4, 57, 0);
            // 
            // tbBillNo
            // 
            this.tbBillNo.BackColor = System.Drawing.Color.LemonChiffon;
            this.tbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBillNo.Font = new System.Drawing.Font("GulimChe", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbBillNo.Location = new System.Drawing.Point(221, 10);
            this.tbBillNo.MaxLength = 4;
            this.tbBillNo.Name = "tbBillNo";
            this.tbBillNo.Size = new System.Drawing.Size(54, 30);
            this.tbBillNo.TabIndex = 74;
            this.tbBillNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl3.Location = new System.Drawing.Point(174, 14);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(41, 24);
            this.lbl3.TabIndex = 70;
            this.lbl3.Text = "영수증\r\n번호";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbPosNo
            // 
            this.cbPosNo.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbPosNo.FormattingEnabled = true;
            this.cbPosNo.Items.AddRange(new object[] {
            "",
            "01",
            "02",
            "03"});
            this.cbPosNo.Location = new System.Drawing.Point(68, 37);
            this.cbPosNo.Name = "cbPosNo";
            this.cbPosNo.Size = new System.Drawing.Size(40, 21);
            this.cbPosNo.TabIndex = 73;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl2.Location = new System.Drawing.Point(12, 42);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(53, 12);
            this.lbl2.TabIndex = 69;
            this.lbl2.Text = "포스번호";
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(287, 8);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(85, 50);
            this.btnView.TabIndex = 72;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblLayoutBill
            // 
            this.lblLayoutBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLayoutBill.Font = new System.Drawing.Font("GulimChe", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLayoutBill.Location = new System.Drawing.Point(20, 422);
            this.lblLayoutBill.Multiline = true;
            this.lblLayoutBill.Name = "lblLayoutBill";
            this.lblLayoutBill.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblLayoutBill.Size = new System.Drawing.Size(363, 255);
            this.lblLayoutBill.TabIndex = 55;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))));
            this.lblTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(483, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "결제내역관리";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbwithoutGoods
            // 
            this.cbwithoutGoods.AutoSize = true;
            this.cbwithoutGoods.Font = new System.Drawing.Font("Gulim", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbwithoutGoods.Location = new System.Drawing.Point(398, 432);
            this.cbwithoutGoods.Name = "cbwithoutGoods";
            this.cbwithoutGoods.Size = new System.Drawing.Size(105, 15);
            this.cbwithoutGoods.TabIndex = 49;
            this.cbwithoutGoods.Text = "상품내역 미출력";
            this.cbwithoutGoods.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbwithoutGoods.UseVisualStyleBackColor = true;
            this.cbwithoutGoods.CheckedChanged += new System.EventHandler(this.cbwithoutGoods_CheckedChanged);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(398, 626);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 48);
            this.button4.TabIndex = 48;
            this.button4.Text = "현금영수증";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(398, 572);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 48);
            this.button1.TabIndex = 48;
            this.button1.Text = "반품재매출";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(398, 518);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 48);
            this.btnCancel.TabIndex = 48;
            this.btnCancel.Text = "반품";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(398, 464);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(105, 48);
            this.btnPrint.TabIndex = 48;
            this.btnPrint.Text = "재출력";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lvwPayManager
            // 
            this.lvwPayManager.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.bill_no,
            this.pay_class,
            this.order_dt,
            this.tran_type,
            this.pos_no,
            this.amount,
            this.dc,
            this.cancel,
            this.trantype});
            this.lvwPayManager.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwPayManager.FullRowSelect = true;
            this.lvwPayManager.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwPayManager.HideSelection = false;
            this.lvwPayManager.Location = new System.Drawing.Point(20, 139);
            this.lvwPayManager.MultiSelect = false;
            this.lvwPayManager.Name = "lvwPayManager";
            this.lvwPayManager.Size = new System.Drawing.Size(483, 279);
            this.lvwPayManager.TabIndex = 44;
            this.lvwPayManager.UseCompatibleStateImageBehavior = false;
            this.lvwPayManager.View = System.Windows.Forms.View.Details;
            this.lvwPayManager.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvwPayManager_ColumnWidthChanging);
            this.lvwPayManager.SelectedIndexChanged += new System.EventHandler(this.lvwPayManager_SelectedIndexChanged);
            // 
            // pay_class
            // 
            this.pay_class.Text = "유형";
            this.pay_class.Width = 40;
            // 
            // order_dt
            // 
            this.order_dt.Text = "거래시간";
            this.order_dt.Width = 90;
            // 
            // tran_type
            // 
            this.tran_type.Text = "구분";
            this.tran_type.Width = 40;
            // 
            // pos_no
            // 
            this.pos_no.Text = "포스";
            this.pos_no.Width = 40;
            // 
            // bill_no
            // 
            this.bill_no.Text = "영수번호";
            this.bill_no.Width = 70;
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
            // 
            // trantype
            // 
            this.trantype.Text = "trantype";
            this.trantype.Width = 0;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(488, 56);
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
        private System.Windows.Forms.CheckBox cbwithoutGoods;
        private System.Windows.Forms.Button button4;
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
        private System.Windows.Forms.ColumnHeader tran_type;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox lblLayoutBill;
        private System.Windows.Forms.ColumnHeader trantype;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnReader;
        private System.Windows.Forms.DateTimePicker dtBusiness;
        private System.Windows.Forms.TextBox tbBillNo;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.ComboBox cbPosNo;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Button btnView;
    }
}