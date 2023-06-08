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
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnReader = new System.Windows.Forms.Button();
            this.tbTicketNo = new System.Windows.Forms.TextBox();
            this.cbPosNo = new System.Windows.Forms.ComboBox();
            this.btnView = new System.Windows.Forms.Button();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.dtBusiness = new System.Windows.Forms.DateTimePicker();
            this.lvwFlow = new System.Windows.Forms.ListView();
            this.stat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ticket_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ticket_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cancel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelback.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.LightGray;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.btnReader);
            this.panelback.Controls.Add(this.tbTicketNo);
            this.panelback.Controls.Add(this.cbPosNo);
            this.panelback.Controls.Add(this.btnView);
            this.panelback.Controls.Add(this.lbl2);
            this.panelback.Controls.Add(this.lbl3);
            this.panelback.Controls.Add(this.lbl1);
            this.panelback.Controls.Add(this.dtBusiness);
            this.panelback.Controls.Add(this.lvwFlow);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Font = new System.Drawing.Font("GulimChe", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 539);
            this.panelback.TabIndex = 5;
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
            // btnReader
            // 
            this.btnReader.BackColor = System.Drawing.Color.White;
            this.btnReader.Image = ((System.Drawing.Image)(resources.GetObject("btnReader.Image")));
            this.btnReader.Location = new System.Drawing.Point(277, 104);
            this.btnReader.Name = "btnReader";
            this.btnReader.Size = new System.Drawing.Size(79, 30);
            this.btnReader.TabIndex = 75;
            this.btnReader.UseVisualStyleBackColor = false;
            // 
            // tbTicketNo
            // 
            this.tbTicketNo.BackColor = System.Drawing.Color.LemonChiffon;
            this.tbTicketNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTicketNo.Font = new System.Drawing.Font("GulimChe", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbTicketNo.Location = new System.Drawing.Point(77, 106);
            this.tbTicketNo.MaxLength = 4;
            this.tbTicketNo.Name = "tbTicketNo";
            this.tbTicketNo.Size = new System.Drawing.Size(194, 26);
            this.tbTicketNo.TabIndex = 74;
            this.tbTicketNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.cbPosNo.Location = new System.Drawing.Point(231, 72);
            this.cbPosNo.Name = "cbPosNo";
            this.cbPosNo.Size = new System.Drawing.Size(40, 21);
            this.cbPosNo.TabIndex = 73;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(402, 71);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 61);
            this.btnView.TabIndex = 72;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl2.Location = new System.Drawing.Point(196, 77);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(29, 12);
            this.lbl2.TabIndex = 69;
            this.lbl2.Text = "포스";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl3.Location = new System.Drawing.Point(21, 114);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(53, 12);
            this.lbl3.TabIndex = 70;
            this.lbl3.Text = "발권번호";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl1.Location = new System.Drawing.Point(21, 77);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(53, 12);
            this.lbl1.TabIndex = 71;
            this.lbl1.Text = "영업일자";
            // 
            // dtBusiness
            // 
            this.dtBusiness.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBusiness.Location = new System.Drawing.Point(77, 71);
            this.dtBusiness.Name = "dtBusiness";
            this.dtBusiness.Size = new System.Drawing.Size(97, 22);
            this.dtBusiness.TabIndex = 68;
            this.dtBusiness.Value = new System.DateTime(2023, 5, 19, 1, 4, 57, 0);
            // 
            // lvwFlow
            // 
            this.lvwFlow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.stat,
            this.goods,
            this.cnt,
            this.ticket_no,
            this.ticket_dt,
            this.cancel});
            this.lvwFlow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwFlow.FullRowSelect = true;
            this.lvwFlow.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwFlow.HideSelection = false;
            this.lvwFlow.Location = new System.Drawing.Point(20, 146);
            this.lvwFlow.MultiSelect = false;
            this.lvwFlow.Name = "lvwFlow";
            this.lvwFlow.Size = new System.Drawing.Size(483, 313);
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
            // cnt
            // 
            this.cnt.Text = "수량";
            this.cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cnt.Width = 50;
            // 
            // ticket_no
            // 
            this.ticket_no.Text = "발권번호";
            this.ticket_no.Width = 100;
            // 
            // ticket_dt
            // 
            this.ticket_dt.Text = "발권시간";
            this.ticket_dt.Width = 70;
            // 
            // cancel
            // 
            this.cancel.Text = "취소";
            this.cancel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnReader;
        private System.Windows.Forms.TextBox tbTicketNo;
        private System.Windows.Forms.ComboBox cbPosNo;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.DateTimePicker dtBusiness;
        private System.Windows.Forms.ListView lvwFlow;
        private System.Windows.Forms.ColumnHeader stat;
        private System.Windows.Forms.ColumnHeader goods;
        private System.Windows.Forms.ColumnHeader cnt;
        private System.Windows.Forms.ColumnHeader ticket_no;
        private System.Windows.Forms.ColumnHeader ticket_dt;
        private System.Windows.Forms.ColumnHeader cancel;
    }
}