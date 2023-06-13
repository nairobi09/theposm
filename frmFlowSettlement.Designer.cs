namespace thepos
{
    partial class frmFlowSettlement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFlowSettlement));
            this.panelback = new System.Windows.Forms.Panel();
            this.lbl4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOrderAmountDC = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnReader = new System.Windows.Forms.Button();
            this.dtBusiness = new System.Windows.Forms.DateTimePicker();
            this.tbBillNo = new System.Windows.Forms.TextBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.cbPosNo = new System.Windows.Forms.ComboBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwFlow = new System.Windows.Forms.ListView();
            this.stat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ticket_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.charge_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.usage_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSettlement = new System.Windows.Forms.Button();
            this.panelback.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.LightGray;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.lbl4);
            this.panelback.Controls.Add(this.button1);
            this.panelback.Controls.Add(this.btnOrderAmountDC);
            this.panelback.Controls.Add(this.panel1);
            this.panelback.Controls.Add(this.listView1);
            this.panelback.Controls.Add(this.lvwFlow);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Controls.Add(this.btnSettlement);
            this.panelback.Font = new System.Drawing.Font("GulimChe", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 6;
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl4.Location = new System.Drawing.Point(21, 360);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(53, 12);
            this.lbl4.TabIndex = 71;
            this.lbl4.Text = "정산경과";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(395, 570);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 48);
            this.button1.TabIndex = 77;
            this.button1.TabStop = false;
            this.button1.Text = "개별재요청";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnOrderAmountDC
            // 
            this.btnOrderAmountDC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnOrderAmountDC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderAmountDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOrderAmountDC.ForeColor = System.Drawing.Color.White;
            this.btnOrderAmountDC.Location = new System.Drawing.Point(395, 624);
            this.btnOrderAmountDC.Name = "btnOrderAmountDC";
            this.btnOrderAmountDC.Size = new System.Drawing.Size(108, 48);
            this.btnOrderAmountDC.TabIndex = 77;
            this.btnOrderAmountDC.TabStop = false;
            this.btnOrderAmountDC.Text = "결제변경";
            this.btnOrderAmountDC.UseVisualStyleBackColor = false;
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
            this.panel1.Size = new System.Drawing.Size(482, 74);
            this.panel1.TabIndex = 76;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl1.Location = new System.Drawing.Point(12, 16);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(53, 12);
            this.lbl1.TabIndex = 71;
            this.lbl1.Text = "영업일자";
            // 
            // btnReader
            // 
            this.btnReader.BackColor = System.Drawing.Color.White;
            this.btnReader.Image = ((System.Drawing.Image)(resources.GetObject("btnReader.Image")));
            this.btnReader.Location = new System.Drawing.Point(382, 10);
            this.btnReader.Name = "btnReader";
            this.btnReader.Size = new System.Drawing.Size(85, 50);
            this.btnReader.TabIndex = 75;
            this.btnReader.UseVisualStyleBackColor = false;
            // 
            // dtBusiness
            // 
            this.dtBusiness.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBusiness.Location = new System.Drawing.Point(68, 10);
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
            this.tbBillNo.Location = new System.Drawing.Point(194, 30);
            this.tbBillNo.MaxLength = 7;
            this.tbBillNo.Name = "tbBillNo";
            this.tbBillNo.Size = new System.Drawing.Size(85, 30);
            this.tbBillNo.TabIndex = 74;
            this.tbBillNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl3.Location = new System.Drawing.Point(138, 43);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(53, 12);
            this.lbl3.TabIndex = 70;
            this.lbl3.Text = "발권번호";
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
            this.cbPosNo.Location = new System.Drawing.Point(68, 39);
            this.cbPosNo.Name = "cbPosNo";
            this.cbPosNo.Size = new System.Drawing.Size(40, 21);
            this.cbPosNo.TabIndex = 73;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl2.Location = new System.Drawing.Point(12, 44);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(53, 12);
            this.lbl2.TabIndex = 69;
            this.lbl2.Text = "포스번호";
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(287, 10);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(85, 50);
            this.btnView.TabIndex = 72;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(20, 375);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(357, 297);
            this.listView1.TabIndex = 67;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "구분";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "결제";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "금액";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "결과";
            this.columnHeader4.Width = 80;
            // 
            // lvwFlow
            // 
            this.lvwFlow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.stat,
            this.goods,
            this.ticket_no,
            this.charge_amt,
            this.usage_amt});
            this.lvwFlow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwFlow.FullRowSelect = true;
            this.lvwFlow.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwFlow.HideSelection = false;
            this.lvwFlow.Location = new System.Drawing.Point(20, 145);
            this.lvwFlow.MultiSelect = false;
            this.lvwFlow.Name = "lvwFlow";
            this.lvwFlow.Size = new System.Drawing.Size(483, 195);
            this.lvwFlow.TabIndex = 67;
            this.lvwFlow.UseCompatibleStateImageBehavior = false;
            this.lvwFlow.View = System.Windows.Forms.View.Details;
            this.lvwFlow.SelectedIndexChanged += new System.EventHandler(this.lvwFlow_SelectedIndexChanged);
            // 
            // stat
            // 
            this.stat.Text = "상태";
            // 
            // goods
            // 
            this.goods.Text = "상품";
            this.goods.Width = 90;
            // 
            // ticket_no
            // 
            this.ticket_no.Text = "발권번호";
            this.ticket_no.Width = 100;
            // 
            // charge_amt
            // 
            this.charge_amt.Text = "충전금액";
            this.charge_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.charge_amt.Width = 80;
            // 
            // usage_amt
            // 
            this.usage_amt.Text = "사용금액";
            this.usage_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.usage_amt.Width = 80;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SaddleBrown;
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
            this.lblTitle.BackColor = System.Drawing.Color.SaddleBrown;
            this.lblTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(483, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "정산";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSettlement
            // 
            this.btnSettlement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnSettlement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettlement.ForeColor = System.Drawing.Color.White;
            this.btnSettlement.Location = new System.Drawing.Point(394, 375);
            this.btnSettlement.Name = "btnSettlement";
            this.btnSettlement.Size = new System.Drawing.Size(108, 69);
            this.btnSettlement.TabIndex = 72;
            this.btnSettlement.Text = "일괄정산";
            this.btnSettlement.UseVisualStyleBackColor = false;
            this.btnSettlement.Click += new System.EventHandler(this.btnView_Click);
            // 
            // frmFlowSettlement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(488, 56);
            this.Name = "frmFlowSettlement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmFlowSettlement";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFlowSettlement_FormClosed);
            this.panelback.ResumeLayout(false);
            this.panelback.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnReader;
        private System.Windows.Forms.DateTimePicker dtBusiness;
        private System.Windows.Forms.TextBox tbBillNo;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.ComboBox cbPosNo;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ListView lvwFlow;
        private System.Windows.Forms.ColumnHeader stat;
        private System.Windows.Forms.ColumnHeader goods;
        private System.Windows.Forms.ColumnHeader ticket_no;
        private System.Windows.Forms.ColumnHeader charge_amt;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ColumnHeader usage_amt;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Button btnOrderAmountDC;
        private System.Windows.Forms.Button btnSettlement;
        private System.Windows.Forms.Button button1;
    }
}