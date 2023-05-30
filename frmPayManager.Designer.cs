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
            this.lblLayoutBill = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnKeyInput = new System.Windows.Forms.Button();
            this.tbBillNo = new System.Windows.Forms.TextBox();
            this.cbPosNo = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.dtBusiness = new System.Windows.Forms.DateTimePicker();
            this.lvwPayManager = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.order_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tran_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pos_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bill_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cash_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.card_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.etc_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cancel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount_etc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount_card = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelback.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.LightGray;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.lblLayoutBill);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Controls.Add(this.btnKeyInput);
            this.panelback.Controls.Add(this.tbBillNo);
            this.panelback.Controls.Add(this.cbPosNo);
            this.panelback.Controls.Add(this.checkBox1);
            this.panelback.Controls.Add(this.button4);
            this.panelback.Controls.Add(this.button1);
            this.panelback.Controls.Add(this.button3);
            this.panelback.Controls.Add(this.btnCancel);
            this.panelback.Controls.Add(this.btnPrint);
            this.panelback.Controls.Add(this.btnView);
            this.panelback.Controls.Add(this.lbl2);
            this.panelback.Controls.Add(this.lbl3);
            this.panelback.Controls.Add(this.lbl1);
            this.panelback.Controls.Add(this.dtBusiness);
            this.panelback.Controls.Add(this.lvwPayManager);
            this.panelback.Font = new System.Drawing.Font("GulimChe", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(4, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(618, 698);
            this.panelback.TabIndex = 3;
            // 
            // lblLayoutBill
            // 
            this.lblLayoutBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLayoutBill.Font = new System.Drawing.Font("GulimChe", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLayoutBill.Location = new System.Drawing.Point(14, 424);
            this.lblLayoutBill.Multiline = true;
            this.lblLayoutBill.Name = "lblLayoutBill";
            this.lblLayoutBill.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblLayoutBill.Size = new System.Drawing.Size(340, 255);
            this.lblLayoutBill.TabIndex = 55;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(559, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 43;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))));
            this.lblTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitle.Location = new System.Drawing.Point(16, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(582, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "결제내역관리";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnKeyInput
            // 
            this.btnKeyInput.BackColor = System.Drawing.Color.Gray;
            this.btnKeyInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyInput.ForeColor = System.Drawing.Color.White;
            this.btnKeyInput.Location = new System.Drawing.Point(430, 72);
            this.btnKeyInput.Name = "btnKeyInput";
            this.btnKeyInput.Size = new System.Drawing.Size(69, 39);
            this.btnKeyInput.TabIndex = 52;
            this.btnKeyInput.Text = "키입력";
            this.btnKeyInput.UseVisualStyleBackColor = false;
            this.btnKeyInput.Click += new System.EventHandler(this.btnKeyInput_Click);
            // 
            // tbBillNo
            // 
            this.tbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBillNo.Font = new System.Drawing.Font("Gulim", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbBillNo.Location = new System.Drawing.Point(369, 81);
            this.tbBillNo.MaxLength = 4;
            this.tbBillNo.Name = "tbBillNo";
            this.tbBillNo.Size = new System.Drawing.Size(46, 24);
            this.tbBillNo.TabIndex = 51;
            this.tbBillNo.Text = "0009";
            this.tbBillNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbPosNo
            // 
            this.cbPosNo.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbPosNo.FormattingEnabled = true;
            this.cbPosNo.Location = new System.Drawing.Point(250, 81);
            this.cbPosNo.Name = "cbPosNo";
            this.cbPosNo.Size = new System.Drawing.Size(40, 21);
            this.cbPosNo.TabIndex = 50;
            this.cbPosNo.Text = "01";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Gulim", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBox1.Location = new System.Drawing.Point(437, 653);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(68, 26);
            this.checkBox1.TabIndex = 49;
            this.checkBox1.Text = "상품내역\r\n미출력";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(514, 586);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 48);
            this.button4.TabIndex = 48;
            this.button4.Text = "현금영수증";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(514, 640);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 48);
            this.button1.TabIndex = 48;
            this.button1.Text = "반품재매출";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(514, 532);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 48);
            this.button3.TabIndex = 48;
            this.button3.Text = "결제변경";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(514, 478);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 48);
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
            this.btnPrint.Location = new System.Drawing.Point(514, 424);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(87, 48);
            this.btnPrint.TabIndex = 48;
            this.btnPrint.Text = "재출력";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(512, 72);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(87, 39);
            this.btnView.TabIndex = 48;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl2.Location = new System.Drawing.Point(196, 86);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(53, 12);
            this.lbl2.TabIndex = 47;
            this.lbl2.Text = "포스번호";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl3.Location = new System.Drawing.Point(306, 86);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(65, 12);
            this.lbl3.TabIndex = 47;
            this.lbl3.Text = "영수증번호";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl1.Location = new System.Drawing.Point(36, 86);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(53, 12);
            this.lbl1.TabIndex = 47;
            this.lbl1.Text = "영업일자";
            // 
            // dtBusiness
            // 
            this.dtBusiness.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBusiness.Location = new System.Drawing.Point(88, 81);
            this.dtBusiness.Name = "dtBusiness";
            this.dtBusiness.Size = new System.Drawing.Size(94, 22);
            this.dtBusiness.TabIndex = 46;
            this.dtBusiness.Value = new System.DateTime(2023, 5, 19, 1, 4, 57, 0);
            // 
            // lvwPayManager
            // 
            this.lvwPayManager.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.order_dt,
            this.tran_type,
            this.pos_no,
            this.bill_no,
            this.cash_amount,
            this.card_amount,
            this.etc_amount,
            this.dc,
            this.cancel});
            this.lvwPayManager.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwPayManager.FullRowSelect = true;
            this.lvwPayManager.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwPayManager.HideSelection = false;
            this.lvwPayManager.Location = new System.Drawing.Point(14, 122);
            this.lvwPayManager.MultiSelect = false;
            this.lvwPayManager.Name = "lvwPayManager";
            this.lvwPayManager.Size = new System.Drawing.Size(586, 296);
            this.lvwPayManager.TabIndex = 44;
            this.lvwPayManager.UseCompatibleStateImageBehavior = false;
            this.lvwPayManager.View = System.Windows.Forms.View.Details;
            this.lvwPayManager.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvwPayManager_ColumnWidthChanging);
            this.lvwPayManager.SelectedIndexChanged += new System.EventHandler(this.lvwPayManager_SelectedIndexChanged);
            // 
            // no
            // 
            this.no.Text = "#";
            this.no.Width = 30;
            // 
            // order_dt
            // 
            this.order_dt.Text = "주문시간";
            this.order_dt.Width = 70;
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
            // cash_amount
            // 
            this.cash_amount.Text = "현금";
            this.cash_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cash_amount.Width = 70;
            // 
            // card_amount
            // 
            this.card_amount.Text = "카드";
            this.card_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.card_amount.Width = 70;
            // 
            // etc_amount
            // 
            this.etc_amount.Text = "기타";
            this.etc_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.etc_amount.Width = 70;
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
            this.cancel.Width = 40;
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
            this.ClientSize = new System.Drawing.Size(624, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(393, 56);
            this.Name = "frmPayManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmSetup";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPayManager_FormClosed);
            this.panelback.ResumeLayout(false);
            this.panelback.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvwPayManager;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.DateTimePicker dtBusiness;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader pos_no;
        private System.Windows.Forms.ColumnHeader bill_no;
        private System.Windows.Forms.ColumnHeader amount_etc;
        private System.Windows.Forms.ColumnHeader cash_amount;
        private System.Windows.Forms.ColumnHeader amount_card;
        private System.Windows.Forms.TextBox tbBillNo;
        private System.Windows.Forms.ComboBox cbPosNo;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.ColumnHeader dc;
        private System.Windows.Forms.ColumnHeader cancel;
        private System.Windows.Forms.ColumnHeader order_dt;
        private System.Windows.Forms.ColumnHeader tran_type;
        private System.Windows.Forms.Button btnKeyInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader card_amount;
        private System.Windows.Forms.ColumnHeader etc_amount;
        private System.Windows.Forms.TextBox lblLayoutBill;
    }
}