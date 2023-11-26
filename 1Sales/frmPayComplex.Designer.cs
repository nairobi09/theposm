namespace thepos
{
    partial class frmPayComplex
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
            this.tbReqAmount = new System.Windows.Forms.TextBox();
            this.btnRequestEasy = new System.Windows.Forms.Button();
            this.btnRequestCard = new System.Windows.Forms.Button();
            this.btnRequestCash = new System.Windows.Forms.Button();
            this.lvwPay = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tran = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cardno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.authno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblNestAmount = new System.Windows.Forms.Label();
            this.lblRcvAmount = new System.Windows.Forms.Label();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.lblT3 = new System.Windows.Forms.Label();
            this.lblT4 = new System.Windows.Forms.Label();
            this.lblT2 = new System.Windows.Forms.Label();
            this.lblT1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelHigh = new System.Windows.Forms.Panel();
            this.panelback.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.LightGray;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.tbReqAmount);
            this.panelback.Controls.Add(this.btnRequestEasy);
            this.panelback.Controls.Add(this.btnRequestCard);
            this.panelback.Controls.Add(this.btnRequestCash);
            this.panelback.Controls.Add(this.lvwPay);
            this.panelback.Controls.Add(this.lblNestAmount);
            this.panelback.Controls.Add(this.lblRcvAmount);
            this.panelback.Controls.Add(this.lblNetAmount);
            this.panelback.Controls.Add(this.lblT3);
            this.panelback.Controls.Add(this.lblT4);
            this.panelback.Controls.Add(this.lblT2);
            this.panelback.Controls.Add(this.lblT1);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 6;
            // 
            // tbReqAmount
            // 
            this.tbReqAmount.BackColor = System.Drawing.Color.White;
            this.tbReqAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbReqAmount.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbReqAmount.Location = new System.Drawing.Point(130, 201);
            this.tbReqAmount.Margin = new System.Windows.Forms.Padding(2);
            this.tbReqAmount.Name = "tbReqAmount";
            this.tbReqAmount.Size = new System.Drawing.Size(141, 26);
            this.tbReqAmount.TabIndex = 56;
            this.tbReqAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnRequestEasy
            // 
            this.btnRequestEasy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnRequestEasy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestEasy.ForeColor = System.Drawing.Color.White;
            this.btnRequestEasy.Location = new System.Drawing.Point(366, 276);
            this.btnRequestEasy.Name = "btnRequestEasy";
            this.btnRequestEasy.Size = new System.Drawing.Size(120, 50);
            this.btnRequestEasy.TabIndex = 54;
            this.btnRequestEasy.Text = "간편결제";
            this.btnRequestEasy.UseVisualStyleBackColor = false;
            this.btnRequestEasy.Click += new System.EventHandler(this.btnRequestEasy_Click);
            // 
            // btnRequestCard
            // 
            this.btnRequestCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnRequestCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestCard.ForeColor = System.Drawing.Color.White;
            this.btnRequestCard.Location = new System.Drawing.Point(240, 276);
            this.btnRequestCard.Name = "btnRequestCard";
            this.btnRequestCard.Size = new System.Drawing.Size(120, 50);
            this.btnRequestCard.TabIndex = 54;
            this.btnRequestCard.Text = "카드";
            this.btnRequestCard.UseVisualStyleBackColor = false;
            this.btnRequestCard.Click += new System.EventHandler(this.btnRequestCard_Click);
            // 
            // btnRequestCash
            // 
            this.btnRequestCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnRequestCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestCash.ForeColor = System.Drawing.Color.White;
            this.btnRequestCash.Location = new System.Drawing.Point(113, 276);
            this.btnRequestCash.Name = "btnRequestCash";
            this.btnRequestCash.Size = new System.Drawing.Size(120, 50);
            this.btnRequestCash.TabIndex = 54;
            this.btnRequestCash.Text = "현금";
            this.btnRequestCash.UseVisualStyleBackColor = false;
            this.btnRequestCash.Click += new System.EventHandler(this.btnRequestCash_Click);
            // 
            // lvwPay
            // 
            this.lvwPay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.pay_dt,
            this.pay_type,
            this.tran,
            this.cardno,
            this.amount,
            this.authno});
            this.lvwPay.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwPay.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwPay.FullRowSelect = true;
            this.lvwPay.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwPay.HideSelection = false;
            this.lvwPay.Location = new System.Drawing.Point(20, 360);
            this.lvwPay.MultiSelect = false;
            this.lvwPay.Name = "lvwPay";
            this.lvwPay.Size = new System.Drawing.Size(483, 243);
            this.lvwPay.TabIndex = 52;
            this.lvwPay.UseCompatibleStateImageBehavior = false;
            this.lvwPay.View = System.Windows.Forms.View.Details;
            this.lvwPay.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvwPay_ColumnWidthChanging);
            // 
            // no
            // 
            this.no.Text = "#";
            this.no.Width = 20;
            // 
            // pay_dt
            // 
            this.pay_dt.Text = "결제시간";
            this.pay_dt.Width = 87;
            // 
            // pay_type
            // 
            this.pay_type.Text = "결제";
            this.pay_type.Width = 71;
            // 
            // tran
            // 
            this.tran.Text = "구분";
            this.tran.Width = 40;
            // 
            // cardno
            // 
            this.cardno.Text = "카드/번호";
            this.cardno.Width = 100;
            // 
            // amount
            // 
            this.amount.Text = "금액";
            this.amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount.Width = 70;
            // 
            // authno
            // 
            this.authno.Text = "승인번호";
            this.authno.Width = 90;
            // 
            // lblNestAmount
            // 
            this.lblNestAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNestAmount.Location = new System.Drawing.Point(130, 149);
            this.lblNestAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblNestAmount.Name = "lblNestAmount";
            this.lblNestAmount.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblNestAmount.Size = new System.Drawing.Size(141, 24);
            this.lblNestAmount.TabIndex = 51;
            this.lblNestAmount.Tag = "0";
            this.lblNestAmount.Text = "0";
            this.lblNestAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRcvAmount
            // 
            this.lblRcvAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRcvAmount.Location = new System.Drawing.Point(130, 119);
            this.lblRcvAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblRcvAmount.Name = "lblRcvAmount";
            this.lblRcvAmount.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblRcvAmount.Size = new System.Drawing.Size(141, 24);
            this.lblRcvAmount.TabIndex = 51;
            this.lblRcvAmount.Tag = "0";
            this.lblRcvAmount.Text = "0";
            this.lblRcvAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNetAmount.Location = new System.Drawing.Point(130, 89);
            this.lblNetAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblNetAmount.Size = new System.Drawing.Size(141, 24);
            this.lblNetAmount.TabIndex = 51;
            this.lblNetAmount.Tag = "0";
            this.lblNetAmount.Text = "0";
            this.lblNetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblT3
            // 
            this.lblT3.AutoSize = true;
            this.lblT3.Location = new System.Drawing.Point(36, 156);
            this.lblT3.Name = "lblT3";
            this.lblT3.Size = new System.Drawing.Size(63, 14);
            this.lblT3.TabIndex = 50;
            this.lblT3.Text = "남은금액";
            // 
            // lblT4
            // 
            this.lblT4.AutoSize = true;
            this.lblT4.Location = new System.Drawing.Point(36, 206);
            this.lblT4.Name = "lblT4";
            this.lblT4.Size = new System.Drawing.Size(91, 14);
            this.lblT4.TabIndex = 50;
            this.lblT4.Text = "결제요청금액";
            // 
            // lblT2
            // 
            this.lblT2.AutoSize = true;
            this.lblT2.Location = new System.Drawing.Point(36, 125);
            this.lblT2.Name = "lblT2";
            this.lblT2.Size = new System.Drawing.Size(77, 14);
            this.lblT2.TabIndex = 50;
            this.lblT2.Text = "결제한금액";
            // 
            // lblT1
            // 
            this.lblT1.AutoSize = true;
            this.lblT1.Location = new System.Drawing.Point(36, 94);
            this.lblT1.Name = "lblT1";
            this.lblT1.Size = new System.Drawing.Size(91, 14);
            this.lblT1.TabIndex = 50;
            this.lblT1.Text = "결제대상금액";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(483, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "복합결제";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHigh
            // 
            this.panelHigh.Location = new System.Drawing.Point(0, 0);
            this.panelHigh.Name = "panelHigh";
            this.panelHigh.Size = new System.Drawing.Size(68, 43);
            this.panelHigh.TabIndex = 58;
            this.panelHigh.Visible = false;
            // 
            // frmPayComplex
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelHigh);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPayComplex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmPayComplex";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPayComplex_FormClosed);
            this.panelback.ResumeLayout(false);
            this.panelback.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.Label lblT1;
        private System.Windows.Forms.ListView lvwPay;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader pay_dt;
        private System.Windows.Forms.ColumnHeader pay_type;
        private System.Windows.Forms.ColumnHeader cardno;
        private System.Windows.Forms.ColumnHeader amount;
        private System.Windows.Forms.ColumnHeader authno;
        private System.Windows.Forms.Label lblT4;
        private System.Windows.Forms.Button btnRequestCard;
        private System.Windows.Forms.Button btnRequestCash;
        private System.Windows.Forms.TextBox tbReqAmount;
        private System.Windows.Forms.Button btnRequestEasy;
        private System.Windows.Forms.Label lblNestAmount;
        private System.Windows.Forms.Label lblRcvAmount;
        private System.Windows.Forms.Label lblT3;
        private System.Windows.Forms.Label lblT2;
        private System.Windows.Forms.ColumnHeader tran;
        private System.Windows.Forms.Panel panelHigh;
    }
}