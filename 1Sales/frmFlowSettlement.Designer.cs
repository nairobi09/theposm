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
            this.panelback = new System.Windows.Forms.Panel();
            this.btnSettleBill = new System.Windows.Forms.Button();
            this.lblTicketSettleTitle = new System.Windows.Forms.Label();
            this.btnCancelReq = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBizDtTitle = new System.Windows.Forms.Label();
            this.btnScanner = new System.Windows.Forms.Button();
            this.dtBizDt = new System.Windows.Forms.DateTimePicker();
            this.tbTicketNo = new System.Windows.Forms.TextBox();
            this.lblTicketNoTitle = new System.Windows.Forms.Label();
            this.cbPosNo = new System.Windows.Forms.ComboBox();
            this.lblPosNoTitle = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.lvwTicketSettle = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.payclass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.result = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwTicketFlow = new System.Windows.Forms.ListView();
            this.ticket_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.charge_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.usage_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.settle_charge_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.settle_usage_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelback.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.LightGray;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.btnSettleBill);
            this.panelback.Controls.Add(this.lblTicketSettleTitle);
            this.panelback.Controls.Add(this.btnCancelReq);
            this.panelback.Controls.Add(this.panel1);
            this.panelback.Controls.Add(this.lvwTicketSettle);
            this.panelback.Controls.Add(this.lvwTicketFlow);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 539);
            this.panelback.TabIndex = 6;
            // 
            // btnSettleBill
            // 
            this.btnSettleBill.BackColor = System.Drawing.Color.White;
            this.btnSettleBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettleBill.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSettleBill.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSettleBill.Location = new System.Drawing.Point(382, 483);
            this.btnSettleBill.Name = "btnSettleBill";
            this.btnSettleBill.Size = new System.Drawing.Size(120, 40);
            this.btnSettleBill.TabIndex = 78;
            this.btnSettleBill.TabStop = false;
            this.btnSettleBill.Text = "영수증";
            this.btnSettleBill.UseVisualStyleBackColor = false;
            this.btnSettleBill.Click += new System.EventHandler(this.btnSettleBill_Click);
            // 
            // lblTicketSettleTitle
            // 
            this.lblTicketSettleTitle.AutoSize = true;
            this.lblTicketSettleTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTicketSettleTitle.Location = new System.Drawing.Point(21, 351);
            this.lblTicketSettleTitle.Name = "lblTicketSettleTitle";
            this.lblTicketSettleTitle.Size = new System.Drawing.Size(53, 12);
            this.lblTicketSettleTitle.TabIndex = 71;
            this.lblTicketSettleTitle.Text = "정산대상";
            // 
            // btnCancelReq
            // 
            this.btnCancelReq.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnCancelReq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelReq.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancelReq.ForeColor = System.Drawing.Color.White;
            this.btnCancelReq.Location = new System.Drawing.Point(256, 483);
            this.btnCancelReq.Name = "btnCancelReq";
            this.btnCancelReq.Size = new System.Drawing.Size(120, 40);
            this.btnCancelReq.TabIndex = 77;
            this.btnCancelReq.TabStop = false;
            this.btnCancelReq.Text = "충전취소";
            this.btnCancelReq.UseVisualStyleBackColor = false;
            this.btnCancelReq.Click += new System.EventHandler(this.btnCancelReq_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblBizDtTitle);
            this.panel1.Controls.Add(this.btnScanner);
            this.panel1.Controls.Add(this.dtBizDt);
            this.panel1.Controls.Add(this.tbTicketNo);
            this.panel1.Controls.Add(this.lblTicketNoTitle);
            this.panel1.Controls.Add(this.cbPosNo);
            this.panel1.Controls.Add(this.lblPosNoTitle);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Location = new System.Drawing.Point(20, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 67);
            this.panel1.TabIndex = 76;
            // 
            // lblBizDtTitle
            // 
            this.lblBizDtTitle.AutoSize = true;
            this.lblBizDtTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBizDtTitle.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblBizDtTitle.Location = new System.Drawing.Point(12, 13);
            this.lblBizDtTitle.Name = "lblBizDtTitle";
            this.lblBizDtTitle.Size = new System.Drawing.Size(53, 12);
            this.lblBizDtTitle.TabIndex = 71;
            this.lblBizDtTitle.Text = "영업일자";
            // 
            // btnScanner
            // 
            this.btnScanner.BackColor = System.Drawing.Color.White;
            this.btnScanner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScanner.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnScanner.Image = global::theposw.Properties.Resources.scanbar5;
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
            this.dtBizDt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtBizDt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBizDt.Location = new System.Drawing.Point(14, 30);
            this.dtBizDt.Name = "dtBizDt";
            this.dtBizDt.Size = new System.Drawing.Size(100, 23);
            this.dtBizDt.TabIndex = 68;
            this.dtBizDt.TabStop = false;
            this.dtBizDt.Value = new System.DateTime(2023, 5, 19, 1, 4, 57, 0);
            // 
            // tbTicketNo
            // 
            this.tbTicketNo.BackColor = System.Drawing.SystemColors.Window;
            this.tbTicketNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTicketNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbTicketNo.Location = new System.Drawing.Point(190, 30);
            this.tbTicketNo.MaxLength = 8;
            this.tbTicketNo.Name = "tbTicketNo";
            this.tbTicketNo.Size = new System.Drawing.Size(80, 23);
            this.tbTicketNo.TabIndex = 74;
            this.tbTicketNo.TabStop = false;
            this.tbTicketNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTicketNoTitle
            // 
            this.lblTicketNoTitle.AutoSize = true;
            this.lblTicketNoTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTicketNoTitle.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblTicketNoTitle.Location = new System.Drawing.Point(190, 13);
            this.lblTicketNoTitle.Name = "lblTicketNoTitle";
            this.lblTicketNoTitle.Size = new System.Drawing.Size(59, 12);
            this.lblTicketNoTitle.TabIndex = 70;
            this.lblTicketNoTitle.Text = "######-##";
            this.lblTicketNoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbPosNo
            // 
            this.cbPosNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbPosNo.FormattingEnabled = true;
            this.cbPosNo.Location = new System.Drawing.Point(125, 32);
            this.cbPosNo.Name = "cbPosNo";
            this.cbPosNo.Size = new System.Drawing.Size(50, 21);
            this.cbPosNo.TabIndex = 73;
            this.cbPosNo.TabStop = false;
            // 
            // lblPosNoTitle
            // 
            this.lblPosNoTitle.AutoSize = true;
            this.lblPosNoTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPosNoTitle.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblPosNoTitle.Location = new System.Drawing.Point(121, 13);
            this.lblPosNoTitle.Name = "lblPosNoTitle";
            this.lblPosNoTitle.Size = new System.Drawing.Size(53, 12);
            this.lblPosNoTitle.TabIndex = 69;
            this.lblPosNoTitle.Text = "포스번호";
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnView.Location = new System.Drawing.Point(280, 13);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 40);
            this.btnView.TabIndex = 72;
            this.btnView.TabStop = false;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lvwTicketSettle
            // 
            this.lvwTicketSettle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.payclass,
            this.cnt,
            this.amt,
            this.result});
            this.lvwTicketSettle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwTicketSettle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwTicketSettle.FullRowSelect = true;
            this.lvwTicketSettle.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwTicketSettle.HideSelection = false;
            this.lvwTicketSettle.Location = new System.Drawing.Point(20, 366);
            this.lvwTicketSettle.MultiSelect = false;
            this.lvwTicketSettle.Name = "lvwTicketSettle";
            this.lvwTicketSettle.Size = new System.Drawing.Size(482, 104);
            this.lvwTicketSettle.TabIndex = 67;
            this.lvwTicketSettle.UseCompatibleStateImageBehavior = false;
            this.lvwTicketSettle.View = System.Windows.Forms.View.Details;
            this.lvwTicketSettle.SelectedIndexChanged += new System.EventHandler(this.lvwTicketSettle_SelectedIndexChanged);
            // 
            // no
            // 
            this.no.Text = "발권번호";
            this.no.Width = 88;
            // 
            // payclass
            // 
            this.payclass.Text = "결제유형";
            this.payclass.Width = 80;
            // 
            // cnt
            // 
            this.cnt.Text = "회";
            this.cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cnt.Width = 40;
            // 
            // amt
            // 
            this.amt.Text = "금액";
            this.amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amt.Width = 80;
            // 
            // result
            // 
            this.result.Text = "경과";
            this.result.Width = 120;
            // 
            // lvwTicketFlow
            // 
            this.lvwTicketFlow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ticket_no,
            this.charge_amt,
            this.usage_amt,
            this.stat,
            this.settle_charge_amt,
            this.settle_usage_amt});
            this.lvwTicketFlow.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwTicketFlow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwTicketFlow.FullRowSelect = true;
            this.lvwTicketFlow.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwTicketFlow.HideSelection = false;
            this.lvwTicketFlow.Location = new System.Drawing.Point(20, 140);
            this.lvwTicketFlow.MultiSelect = false;
            this.lvwTicketFlow.Name = "lvwTicketFlow";
            this.lvwTicketFlow.Size = new System.Drawing.Size(483, 195);
            this.lvwTicketFlow.TabIndex = 67;
            this.lvwTicketFlow.UseCompatibleStateImageBehavior = false;
            this.lvwTicketFlow.View = System.Windows.Forms.View.Details;
            this.lvwTicketFlow.SelectedIndexChanged += new System.EventHandler(this.lvwTicketFlow_SelectedIndexChanged);
            // 
            // ticket_no
            // 
            this.ticket_no.Text = "발권번호";
            this.ticket_no.Width = 87;
            // 
            // charge_amt
            // 
            this.charge_amt.Text = "충전금액";
            this.charge_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.charge_amt.Width = 70;
            // 
            // usage_amt
            // 
            this.usage_amt.Text = "사용금액";
            this.usage_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.usage_amt.Width = 70;
            // 
            // stat
            // 
            this.stat.Text = "상태";
            this.stat.Width = 80;
            // 
            // settle_charge_amt
            // 
            this.settle_charge_amt.Text = "정산충전";
            this.settle_charge_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.settle_charge_amt.Width = 70;
            // 
            // settle_usage_amt
            // 
            this.settle_usage_amt.Text = "정산사용";
            this.settle_usage_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.settle_usage_amt.Width = 70;
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
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(483, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "정산";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmFlowSettlement
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(529, 545);
            this.Controls.Add(this.panelback);
            this.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
        private System.Windows.Forms.Label lblBizDtTitle;
        private System.Windows.Forms.Button btnScanner;
        private System.Windows.Forms.DateTimePicker dtBizDt;
        private System.Windows.Forms.TextBox tbTicketNo;
        private System.Windows.Forms.Label lblTicketNoTitle;
        private System.Windows.Forms.ComboBox cbPosNo;
        private System.Windows.Forms.Label lblPosNoTitle;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ListView lvwTicketFlow;
        private System.Windows.Forms.ColumnHeader stat;
        private System.Windows.Forms.ColumnHeader ticket_no;
        private System.Windows.Forms.ColumnHeader charge_amt;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ColumnHeader usage_amt;
        private System.Windows.Forms.ListView lvwTicketSettle;
        private System.Windows.Forms.ColumnHeader amt;
        private System.Windows.Forms.ColumnHeader result;
        private System.Windows.Forms.Label lblTicketSettleTitle;
        private System.Windows.Forms.Button btnCancelReq;
        private System.Windows.Forms.ColumnHeader payclass;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader cnt;
        private System.Windows.Forms.ColumnHeader settle_charge_amt;
        private System.Windows.Forms.ColumnHeader settle_usage_amt;
        private System.Windows.Forms.Button btnSettleBill;
    }
}