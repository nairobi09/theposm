namespace thepos
{
    partial class frmPayEasy
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
            this.chkKakao = new System.Windows.Forms.CheckBox();
            this.btnEasyAuth = new System.Windows.Forms.Button();
            this.lblBarcodeNoTitle = new System.Windows.Forms.Label();
            this.tbBarcodeNo = new System.Windows.Forms.TextBox();
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
            this.groupBox1.Controls.Add(this.chkKakao);
            this.groupBox1.Controls.Add(this.btnEasyAuth);
            this.groupBox1.Controls.Add(this.lblBarcodeNoTitle);
            this.groupBox1.Controls.Add(this.tbBarcodeNo);
            this.groupBox1.Location = new System.Drawing.Point(23, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 223);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            // 
            // chkKakao
            // 
            this.chkKakao.AutoSize = true;
            this.chkKakao.Location = new System.Drawing.Point(121, 99);
            this.chkKakao.Name = "chkKakao";
            this.chkKakao.Size = new System.Drawing.Size(96, 18);
            this.chkKakao.TabIndex = 59;
            this.chkKakao.Text = "카카오페이";
            this.chkKakao.UseVisualStyleBackColor = true;
            this.chkKakao.Visible = false;
            // 
            // btnEasyAuth
            // 
            this.btnEasyAuth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnEasyAuth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEasyAuth.ForeColor = System.Drawing.Color.White;
            this.btnEasyAuth.Location = new System.Drawing.Point(299, 127);
            this.btnEasyAuth.Name = "btnEasyAuth";
            this.btnEasyAuth.Size = new System.Drawing.Size(140, 60);
            this.btnEasyAuth.TabIndex = 58;
            this.btnEasyAuth.Text = "승인요청";
            this.btnEasyAuth.UseVisualStyleBackColor = false;
            this.btnEasyAuth.Click += new System.EventHandler(this.btnEasyAuth_Click);
            // 
            // lblBarcodeNoTitle
            // 
            this.lblBarcodeNoTitle.AutoSize = true;
            this.lblBarcodeNoTitle.Location = new System.Drawing.Point(28, 44);
            this.lblBarcodeNoTitle.Name = "lblBarcodeNoTitle";
            this.lblBarcodeNoTitle.Size = new System.Drawing.Size(77, 14);
            this.lblBarcodeNoTitle.TabIndex = 48;
            this.lblBarcodeNoTitle.Text = "바코드번호";
            // 
            // tbBarcodeNo
            // 
            this.tbBarcodeNo.BackColor = System.Drawing.Color.LemonChiffon;
            this.tbBarcodeNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBarcodeNo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbBarcodeNo.Location = new System.Drawing.Point(121, 39);
            this.tbBarcodeNo.MaxLength = 250;
            this.tbBarcodeNo.Name = "tbBarcodeNo";
            this.tbBarcodeNo.Size = new System.Drawing.Size(318, 26);
            this.tbBarcodeNo.TabIndex = 0;
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNetAmount.Location = new System.Drawing.Point(144, 118);
            this.lblNetAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Padding = new System.Windows.Forms.Padding(5);
            this.lblNetAmount.Size = new System.Drawing.Size(131, 33);
            this.lblNetAmount.TabIndex = 49;
            this.lblNetAmount.Tag = "0";
            this.lblNetAmount.Text = "0";
            this.lblNetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNetAmountTitle
            // 
            this.lblNetAmountTitle.AutoSize = true;
            this.lblNetAmountTitle.Location = new System.Drawing.Point(50, 128);
            this.lblNetAmountTitle.Name = "lblNetAmountTitle";
            this.lblNetAmountTitle.Size = new System.Drawing.Size(63, 14);
            this.lblNetAmountTitle.TabIndex = 48;
            this.lblNetAmountTitle.Text = "결제금액";
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
            this.lblTitle.Text = "간편결제";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPayEasy
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPayEasy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmPayEasy";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPayEasy_FormClosed);
            this.panelback.ResumeLayout(false);
            this.panelback.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.TextBox tbBarcodeNo;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.Label lblNetAmountTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblBarcodeNoTitle;
        private System.Windows.Forms.Button btnEasyAuth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkKakao;
    }
}