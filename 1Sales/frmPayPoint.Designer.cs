namespace thepos
{
    partial class frmPayPoint
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbTicketNo = new System.Windows.Forms.TextBox();
            this.btnRequestAuth = new System.Windows.Forms.Button();
            this.lblTicketNoTitle = new System.Windows.Forms.Label();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.lblNetAmountTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelback.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.groupBox1);
            this.panelback.Controls.Add(this.lblNetAmount);
            this.panelback.Controls.Add(this.lblNetAmountTitle);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbTicketNo);
            this.groupBox1.Controls.Add(this.btnRequestAuth);
            this.groupBox1.Controls.Add(this.lblTicketNoTitle);
            this.groupBox1.Location = new System.Drawing.Point(23, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 179);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            // 
            // tbTicketNo
            // 
            this.tbTicketNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTicketNo.Location = new System.Drawing.Point(106, 40);
            this.tbTicketNo.Name = "tbTicketNo";
            this.tbTicketNo.Size = new System.Drawing.Size(341, 23);
            this.tbTicketNo.TabIndex = 0;
            // 
            // btnRequestAuth
            // 
            this.btnRequestAuth.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnRequestAuth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestAuth.ForeColor = System.Drawing.Color.White;
            this.btnRequestAuth.Location = new System.Drawing.Point(307, 97);
            this.btnRequestAuth.Name = "btnRequestAuth";
            this.btnRequestAuth.Size = new System.Drawing.Size(140, 50);
            this.btnRequestAuth.TabIndex = 58;
            this.btnRequestAuth.Text = "승인요청";
            this.btnRequestAuth.UseVisualStyleBackColor = false;
            this.btnRequestAuth.Click += new System.EventHandler(this.btnRequestPoint_Click);
            // 
            // lblTicketNoTitle
            // 
            this.lblTicketNoTitle.AutoSize = true;
            this.lblTicketNoTitle.Location = new System.Drawing.Point(37, 45);
            this.lblTicketNoTitle.Name = "lblTicketNoTitle";
            this.lblTicketNoTitle.Size = new System.Drawing.Size(63, 14);
            this.lblTicketNoTitle.TabIndex = 48;
            this.lblTicketNoTitle.Text = "티켓번호";
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNetAmount.Location = new System.Drawing.Point(129, 121);
            this.lblNetAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Padding = new System.Windows.Forms.Padding(5);
            this.lblNetAmount.Size = new System.Drawing.Size(131, 29);
            this.lblNetAmount.TabIndex = 49;
            this.lblNetAmount.Tag = "0";
            this.lblNetAmount.Text = "0";
            this.lblNetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNetAmountTitle
            // 
            this.lblNetAmountTitle.AutoSize = true;
            this.lblNetAmountTitle.Location = new System.Drawing.Point(35, 128);
            this.lblNetAmountTitle.Name = "lblNetAmountTitle";
            this.lblNetAmountTitle.Size = new System.Drawing.Size(91, 14);
            this.lblNetAmountTitle.TabIndex = 48;
            this.lblNetAmountTitle.Text = "결제대상금액";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SaddleBrown;
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
            this.lblTitle.BackColor = System.Drawing.Color.SaddleBrown;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(483, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "포인트사용";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPayPoint
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPayPoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmPayPoint";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPayPoint_FormClosed);
            this.panelback.ResumeLayout(false);
            this.panelback.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.Label lblNetAmountTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRequestAuth;
        private System.Windows.Forms.Label lblTicketNoTitle;
        private System.Windows.Forms.TextBox tbTicketNo;
    }
}