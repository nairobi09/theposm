namespace thepos
{
    partial class frmFlowCharging
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFlowCharging));
            this.panelback = new System.Windows.Forms.Panel();
            this.tbChargeAmt = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCharge = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn1t = new System.Windows.Forms.Button();
            this.btn10t = new System.Windows.Forms.Button();
            this.btn5t = new System.Windows.Forms.Button();
            this.btn50t = new System.Windows.Forms.Button();
            this.btn100t = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBizDtTitle = new System.Windows.Forms.Label();
            this.btnScanner = new System.Windows.Forms.Button();
            this.dtBizDt = new System.Windows.Forms.DateTimePicker();
            this.tbTicketNo = new System.Windows.Forms.TextBox();
            this.lblTicketNoTitle = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.lvwFlow = new System.Windows.Forms.ListView();
            this.stat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ticket_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.charege_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cbPosNo = new System.Windows.Forms.ComboBox();
            this.lblPosNoTitle = new System.Windows.Forms.Label();
            this.panelback.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.LightGray;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.tbChargeAmt);
            this.panelback.Controls.Add(this.btnReset);
            this.panelback.Controls.Add(this.btnCharge);
            this.panelback.Controls.Add(this.label1);
            this.panelback.Controls.Add(this.btn1t);
            this.panelback.Controls.Add(this.btn10t);
            this.panelback.Controls.Add(this.btn5t);
            this.panelback.Controls.Add(this.btn50t);
            this.panelback.Controls.Add(this.btn100t);
            this.panelback.Controls.Add(this.panel1);
            this.panelback.Controls.Add(this.lvwFlow);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 539);
            this.panelback.TabIndex = 5;
            // 
            // tbChargeAmt
            // 
            this.tbChargeAmt.Location = new System.Drawing.Point(355, 351);
            this.tbChargeAmt.Name = "tbChargeAmt";
            this.tbChargeAmt.Size = new System.Drawing.Size(132, 22);
            this.tbChargeAmt.TabIndex = 84;
            this.tbChargeAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Gray;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(184, 403);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(66, 46);
            this.btnReset.TabIndex = 83;
            this.btnReset.Text = "초기화";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCharge
            // 
            this.btnCharge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCharge.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCharge.Location = new System.Drawing.Point(355, 403);
            this.btnCharge.Name = "btnCharge";
            this.btnCharge.Size = new System.Drawing.Size(133, 46);
            this.btnCharge.TabIndex = 82;
            this.btnCharge.Text = "충전";
            this.btnCharge.UseVisualStyleBackColor = false;
            this.btnCharge.Click += new System.EventHandler(this.btnCharge_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 358);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "충전금액";
            // 
            // btn1t
            // 
            this.btn1t.Location = new System.Drawing.Point(40, 403);
            this.btn1t.Name = "btn1t";
            this.btn1t.Size = new System.Drawing.Size(66, 46);
            this.btn1t.TabIndex = 77;
            this.btn1t.Text = "천원";
            this.btn1t.UseVisualStyleBackColor = true;
            this.btn1t.Click += new System.EventHandler(this.btn1t_Click);
            // 
            // btn10t
            // 
            this.btn10t.Location = new System.Drawing.Point(40, 351);
            this.btn10t.Name = "btn10t";
            this.btn10t.Size = new System.Drawing.Size(66, 46);
            this.btn10t.TabIndex = 77;
            this.btn10t.Text = "만원";
            this.btn10t.UseVisualStyleBackColor = true;
            this.btn10t.Click += new System.EventHandler(this.btn10t_Click);
            // 
            // btn5t
            // 
            this.btn5t.Location = new System.Drawing.Point(112, 403);
            this.btn5t.Name = "btn5t";
            this.btn5t.Size = new System.Drawing.Size(66, 46);
            this.btn5t.TabIndex = 78;
            this.btn5t.Text = "오천원";
            this.btn5t.UseVisualStyleBackColor = true;
            this.btn5t.Click += new System.EventHandler(this.btn5t_Click);
            // 
            // btn50t
            // 
            this.btn50t.Location = new System.Drawing.Point(112, 351);
            this.btn50t.Name = "btn50t";
            this.btn50t.Size = new System.Drawing.Size(66, 46);
            this.btn50t.TabIndex = 78;
            this.btn50t.Text = "오만원";
            this.btn50t.UseVisualStyleBackColor = true;
            this.btn50t.Click += new System.EventHandler(this.btn50t_Click);
            // 
            // btn100t
            // 
            this.btn100t.Location = new System.Drawing.Point(184, 351);
            this.btn100t.Name = "btn100t";
            this.btn100t.Size = new System.Drawing.Size(66, 46);
            this.btn100t.TabIndex = 79;
            this.btn100t.Text = "십만원";
            this.btn100t.UseVisualStyleBackColor = true;
            this.btn100t.Click += new System.EventHandler(this.btn100t_Click);
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
            this.panel1.Location = new System.Drawing.Point(20, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 74);
            this.panel1.TabIndex = 76;
            // 
            // lblBizDtTitle
            // 
            this.lblBizDtTitle.AutoSize = true;
            this.lblBizDtTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBizDtTitle.Location = new System.Drawing.Point(12, 19);
            this.lblBizDtTitle.Name = "lblBizDtTitle";
            this.lblBizDtTitle.Size = new System.Drawing.Size(53, 12);
            this.lblBizDtTitle.TabIndex = 71;
            this.lblBizDtTitle.Text = "영업일자";
            // 
            // btnScanner
            // 
            this.btnScanner.BackColor = System.Drawing.Color.White;
            this.btnScanner.Image = ((System.Drawing.Image)(resources.GetObject("btnScanner.Image")));
            this.btnScanner.Location = new System.Drawing.Point(382, 16);
            this.btnScanner.Name = "btnScanner";
            this.btnScanner.Size = new System.Drawing.Size(85, 40);
            this.btnScanner.TabIndex = 75;
            this.btnScanner.UseVisualStyleBackColor = false;
            this.btnScanner.Click += new System.EventHandler(this.btnScanner_Click);
            // 
            // dtBizDt
            // 
            this.dtBizDt.Font = new System.Drawing.Font("굴림체", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtBizDt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBizDt.Location = new System.Drawing.Point(14, 34);
            this.dtBizDt.Name = "dtBizDt";
            this.dtBizDt.Size = new System.Drawing.Size(97, 23);
            this.dtBizDt.TabIndex = 68;
            this.dtBizDt.Value = new System.DateTime(2023, 5, 19, 1, 4, 57, 0);
            // 
            // tbTicketNo
            // 
            this.tbTicketNo.BackColor = System.Drawing.Color.LemonChiffon;
            this.tbTicketNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTicketNo.Font = new System.Drawing.Font("굴림체", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbTicketNo.Location = new System.Drawing.Point(189, 33);
            this.tbTicketNo.MaxLength = 7;
            this.tbTicketNo.Name = "tbTicketNo";
            this.tbTicketNo.Size = new System.Drawing.Size(74, 23);
            this.tbTicketNo.TabIndex = 74;
            this.tbTicketNo.Text = "0000000";
            this.tbTicketNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTicketNoTitle
            // 
            this.lblTicketNoTitle.AutoSize = true;
            this.lblTicketNoTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTicketNoTitle.Location = new System.Drawing.Point(187, 19);
            this.lblTicketNoTitle.Name = "lblTicketNoTitle";
            this.lblTicketNoTitle.Size = new System.Drawing.Size(53, 12);
            this.lblTicketNoTitle.TabIndex = 70;
            this.lblTicketNoTitle.Text = "발권번호";
            this.lblTicketNoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(287, 16);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(85, 40);
            this.btnView.TabIndex = 72;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lvwFlow
            // 
            this.lvwFlow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.stat,
            this.goods,
            this.ticket_no,
            this.charege_dt,
            this.amt});
            this.lvwFlow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwFlow.FullRowSelect = true;
            this.lvwFlow.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwFlow.HideSelection = false;
            this.lvwFlow.Location = new System.Drawing.Point(20, 145);
            this.lvwFlow.MultiSelect = false;
            this.lvwFlow.Name = "lvwFlow";
            this.lvwFlow.Size = new System.Drawing.Size(483, 183);
            this.lvwFlow.TabIndex = 67;
            this.lvwFlow.UseCompatibleStateImageBehavior = false;
            this.lvwFlow.View = System.Windows.Forms.View.Details;
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
            // charege_dt
            // 
            this.charege_dt.Text = "충전시간";
            this.charege_dt.Width = 70;
            // 
            // amt
            // 
            this.amt.Text = "충전금액";
            this.amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amt.Width = 80;
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
            this.lblTitle.Text = "충전";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbPosNo
            // 
            this.cbPosNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbPosNo.FormattingEnabled = true;
            this.cbPosNo.Items.AddRange(new object[] {
            "",
            "01",
            "02",
            "03"});
            this.cbPosNo.Location = new System.Drawing.Point(127, 35);
            this.cbPosNo.Name = "cbPosNo";
            this.cbPosNo.Size = new System.Drawing.Size(40, 21);
            this.cbPosNo.TabIndex = 73;
            // 
            // lblPosNoTitle
            // 
            this.lblPosNoTitle.AutoSize = true;
            this.lblPosNoTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPosNoTitle.Location = new System.Drawing.Point(121, 19);
            this.lblPosNoTitle.Name = "lblPosNoTitle";
            this.lblPosNoTitle.Size = new System.Drawing.Size(53, 12);
            this.lblPosNoTitle.TabIndex = 69;
            this.lblPosNoTitle.Text = "포스번호";
            // 
            // frmFlowCharging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 545);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(488, 56);
            this.Name = "frmFlowCharging";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmFlowCharging";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFlowCharging_FormClosed);
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
        private System.Windows.Forms.Button btnScanner;
        private System.Windows.Forms.TextBox tbTicketNo;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblTicketNoTitle;
        private System.Windows.Forms.Label lblBizDtTitle;
        private System.Windows.Forms.DateTimePicker dtBizDt;
        private System.Windows.Forms.ListView lvwFlow;
        private System.Windows.Forms.ColumnHeader stat;
        private System.Windows.Forms.ColumnHeader goods;
        private System.Windows.Forms.ColumnHeader ticket_no;
        private System.Windows.Forms.ColumnHeader charege_dt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn10t;
        private System.Windows.Forms.Button btn50t;
        private System.Windows.Forms.Button btn100t;
        private System.Windows.Forms.Button btnCharge;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btn1t;
        private System.Windows.Forms.Button btn5t;
        private System.Windows.Forms.ColumnHeader amt;
        private System.Windows.Forms.TextBox tbChargeAmt;
        private System.Windows.Forms.ComboBox cbPosNo;
        private System.Windows.Forms.Label lblPosNoTitle;
    }
}