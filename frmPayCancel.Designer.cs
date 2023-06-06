namespace thepos
{
    partial class frmPayCancel
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
            this.lblNestAmount = new System.Windows.Forms.Label();
            this.lblCancelAmount = new System.Windows.Forms.Label();
            this.lblT3 = new System.Windows.Forms.Label();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.lblT2 = new System.Windows.Forms.Label();
            this.lblT1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lvwPay = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pay_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tran = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.t_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.p_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.t_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelback.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.LightGray;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.lblNestAmount);
            this.panelback.Controls.Add(this.lblCancelAmount);
            this.panelback.Controls.Add(this.lblT3);
            this.panelback.Controls.Add(this.lblNetAmount);
            this.panelback.Controls.Add(this.lblT2);
            this.panelback.Controls.Add(this.lblT1);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Controls.Add(this.btnCancel);
            this.panelback.Controls.Add(this.lvwPay);
            this.panelback.Font = new System.Drawing.Font("GulimChe", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 4;
            // 
            // lblNestAmount
            // 
            this.lblNestAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNestAmount.Location = new System.Drawing.Point(122, 133);
            this.lblNestAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblNestAmount.Name = "lblNestAmount";
            this.lblNestAmount.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblNestAmount.Size = new System.Drawing.Size(141, 24);
            this.lblNestAmount.TabIndex = 54;
            this.lblNestAmount.Tag = "0";
            this.lblNestAmount.Text = "0";
            this.lblNestAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCancelAmount
            // 
            this.lblCancelAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCancelAmount.Location = new System.Drawing.Point(122, 105);
            this.lblCancelAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblCancelAmount.Name = "lblCancelAmount";
            this.lblCancelAmount.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblCancelAmount.Size = new System.Drawing.Size(141, 24);
            this.lblCancelAmount.TabIndex = 54;
            this.lblCancelAmount.Tag = "0";
            this.lblCancelAmount.Text = "0";
            this.lblCancelAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblT3
            // 
            this.lblT3.AutoSize = true;
            this.lblT3.Location = new System.Drawing.Point(28, 140);
            this.lblT3.Name = "lblT3";
            this.lblT3.Size = new System.Drawing.Size(77, 13);
            this.lblT3.TabIndex = 52;
            this.lblT3.Text = "미취소금액";
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNetAmount.Location = new System.Drawing.Point(122, 77);
            this.lblNetAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblNetAmount.Size = new System.Drawing.Size(141, 24);
            this.lblNetAmount.TabIndex = 55;
            this.lblNetAmount.Tag = "0";
            this.lblNetAmount.Text = "0";
            this.lblNetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblT2
            // 
            this.lblT2.AutoSize = true;
            this.lblT2.Location = new System.Drawing.Point(28, 112);
            this.lblT2.Name = "lblT2";
            this.lblT2.Size = new System.Drawing.Size(63, 13);
            this.lblT2.TabIndex = 52;
            this.lblT2.Text = "취소금액";
            // 
            // lblT1
            // 
            this.lblT1.AutoSize = true;
            this.lblT1.Location = new System.Drawing.Point(28, 82);
            this.lblT1.Name = "lblT1";
            this.lblT1.Size = new System.Drawing.Size(91, 13);
            this.lblT1.TabIndex = 53;
            this.lblT1.Text = "취소대상금액";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(460, 20);
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
            this.lblTitle.Location = new System.Drawing.Point(17, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(485, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "반품";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(372, 421);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 57);
            this.btnCancel.TabIndex = 48;
            this.btnCancel.Text = "취소처리";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lvwPay
            // 
            this.lvwPay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.pay_dt,
            this.pay_type,
            this.tran,
            this.amount,
            this.cc,
            this.t_no,
            this.p_type,
            this.t_type});
            this.lvwPay.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwPay.FullRowSelect = true;
            this.lvwPay.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwPay.HideSelection = false;
            this.lvwPay.Location = new System.Drawing.Point(17, 178);
            this.lvwPay.MultiSelect = false;
            this.lvwPay.Name = "lvwPay";
            this.lvwPay.Size = new System.Drawing.Size(485, 236);
            this.lvwPay.TabIndex = 44;
            this.lvwPay.UseCompatibleStateImageBehavior = false;
            this.lvwPay.View = System.Windows.Forms.View.Details;
            // 
            // no
            // 
            this.no.Text = "#";
            this.no.Width = 30;
            // 
            // pay_dt
            // 
            this.pay_dt.Text = "결제시간";
            this.pay_dt.Width = 90;
            // 
            // pay_type
            // 
            this.pay_type.Text = "결제";
            this.pay_type.Width = 100;
            // 
            // tran
            // 
            this.tran.Text = "구분";
            this.tran.Width = 50;
            // 
            // amount
            // 
            this.amount.Text = "금액";
            this.amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount.Width = 90;
            // 
            // cc
            // 
            this.cc.Text = "취소";
            // 
            // t_no
            // 
            this.t_no.Width = 0;
            // 
            // p_type
            // 
            this.p_type.Width = 0;
            // 
            // t_type
            // 
            this.t_type.Width = 0;
            // 
            // frmPayCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPayCancel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmPayCancel";
            this.TopMost = true;
            this.panelback.ResumeLayout(false);
            this.panelback.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView lvwPay;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader pay_dt;
        private System.Windows.Forms.ColumnHeader pay_type;
        private System.Windows.Forms.ColumnHeader amount;
        private System.Windows.Forms.ColumnHeader cc;
        private System.Windows.Forms.ColumnHeader tran;
        private System.Windows.Forms.ColumnHeader t_no;
        private System.Windows.Forms.ColumnHeader p_type;
        private System.Windows.Forms.Label lblCancelAmount;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.Label lblT2;
        private System.Windows.Forms.Label lblT1;
        private System.Windows.Forms.Label lblNestAmount;
        private System.Windows.Forms.Label lblT3;
        private System.Windows.Forms.ColumnHeader t_type;
    }
}