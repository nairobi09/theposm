namespace thepos
{
    partial class frmPayCash
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
            this.gbCashReceipt = new System.Windows.Forms.GroupBox();
            this.gbInputType = new System.Windows.Forms.GroupBox();
            this.lbl5 = new System.Windows.Forms.Label();
            this.rb카드거래 = new System.Windows.Forms.RadioButton();
            this.rbKeyin = new System.Windows.Forms.RadioButton();
            this.rb화면입력 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl4 = new System.Windows.Forms.Label();
            this.rbTypeSelf = new System.Windows.Forms.RadioButton();
            this.rbTypeIndividual = new System.Windows.Forms.RadioButton();
            this.rbTypeBusiness = new System.Windows.Forms.RadioButton();
            this.lblAuthNo = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.btnCashRecept = new System.Windows.Forms.Button();
            this.gbCashSimple = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCashSimple = new System.Windows.Forms.Button();
            this.lblRestAmount = new System.Windows.Forms.Label();
            this.lblRcvAmount = new System.Windows.Forms.Label();
            this.btn1t = new System.Windows.Forms.Button();
            this.lbl3 = new System.Windows.Forms.Label();
            this.btn5t = new System.Windows.Forms.Button();
            this.lbl2 = new System.Windows.Forms.Label();
            this.btn10t = new System.Windows.Forms.Button();
            this.btn50t = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.panelback.SuspendLayout();
            this.gbCashReceipt.SuspendLayout();
            this.gbInputType.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbCashSimple.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.gbCashReceipt);
            this.panelback.Controls.Add(this.gbCashSimple);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Controls.Add(this.lblNetAmount);
            this.panelback.Controls.Add(this.lbl1);
            this.panelback.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 4;
            // 
            // gbCashReceipt
            // 
            this.gbCashReceipt.Controls.Add(this.gbInputType);
            this.gbCashReceipt.Controls.Add(this.groupBox3);
            this.gbCashReceipt.Controls.Add(this.lblAuthNo);
            this.gbCashReceipt.Controls.Add(this.lbl6);
            this.gbCashReceipt.Controls.Add(this.btnCashRecept);
            this.gbCashReceipt.Location = new System.Drawing.Point(22, 360);
            this.gbCashReceipt.Name = "gbCashReceipt";
            this.gbCashReceipt.Size = new System.Drawing.Size(480, 317);
            this.gbCashReceipt.TabIndex = 50;
            this.gbCashReceipt.TabStop = false;
            // 
            // gbInputType
            // 
            this.gbInputType.Controls.Add(this.lbl5);
            this.gbInputType.Controls.Add(this.rb카드거래);
            this.gbInputType.Controls.Add(this.rbKeyin);
            this.gbInputType.Controls.Add(this.rb화면입력);
            this.gbInputType.Location = new System.Drawing.Point(15, 97);
            this.gbInputType.Name = "gbInputType";
            this.gbInputType.Size = new System.Drawing.Size(450, 74);
            this.gbInputType.TabIndex = 54;
            this.gbInputType.TabStop = false;
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(22, 36);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(63, 14);
            this.lbl5.TabIndex = 45;
            this.lbl5.Text = "입력수단";
            // 
            // rb카드거래
            // 
            this.rb카드거래.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb카드거래.Location = new System.Drawing.Point(225, 21);
            this.rb카드거래.Name = "rb카드거래";
            this.rb카드거래.Size = new System.Drawing.Size(91, 41);
            this.rb카드거래.TabIndex = 50;
            this.rb카드거래.Text = "카드리더";
            this.rb카드거래.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb카드거래.UseVisualStyleBackColor = true;
            // 
            // rbKeyin
            // 
            this.rbKeyin.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbKeyin.Checked = true;
            this.rbKeyin.Location = new System.Drawing.Point(126, 21);
            this.rbKeyin.Name = "rbKeyin";
            this.rbKeyin.Size = new System.Drawing.Size(91, 41);
            this.rbKeyin.TabIndex = 50;
            this.rbKeyin.TabStop = true;
            this.rbKeyin.Text = "키패드";
            this.rbKeyin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbKeyin.UseVisualStyleBackColor = true;
            // 
            // rb화면입력
            // 
            this.rb화면입력.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb화면입력.Location = new System.Drawing.Point(323, 21);
            this.rb화면입력.Name = "rb화면입력";
            this.rb화면입력.Size = new System.Drawing.Size(91, 41);
            this.rb화면입력.TabIndex = 50;
            this.rb화면입력.Text = "화면터치";
            this.rb화면입력.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb화면입력.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl4);
            this.groupBox3.Controls.Add(this.rbTypeSelf);
            this.groupBox3.Controls.Add(this.rbTypeIndividual);
            this.groupBox3.Controls.Add(this.rbTypeBusiness);
            this.groupBox3.Location = new System.Drawing.Point(15, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(451, 75);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(22, 35);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(63, 14);
            this.lbl4.TabIndex = 45;
            this.lbl4.Text = "발급구분";
            // 
            // rbTypeSelf
            // 
            this.rbTypeSelf.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbTypeSelf.Location = new System.Drawing.Point(323, 21);
            this.rbTypeSelf.Name = "rbTypeSelf";
            this.rbTypeSelf.Size = new System.Drawing.Size(91, 41);
            this.rbTypeSelf.TabIndex = 52;
            this.rbTypeSelf.Text = "자진발급";
            this.rbTypeSelf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbTypeSelf.UseVisualStyleBackColor = true;
            // 
            // rbTypeIndividual
            // 
            this.rbTypeIndividual.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbTypeIndividual.Checked = true;
            this.rbTypeIndividual.Location = new System.Drawing.Point(126, 21);
            this.rbTypeIndividual.Name = "rbTypeIndividual";
            this.rbTypeIndividual.Size = new System.Drawing.Size(91, 41);
            this.rbTypeIndividual.TabIndex = 52;
            this.rbTypeIndividual.TabStop = true;
            this.rbTypeIndividual.Text = "개인";
            this.rbTypeIndividual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbTypeIndividual.UseVisualStyleBackColor = true;
            // 
            // rbTypeBusiness
            // 
            this.rbTypeBusiness.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbTypeBusiness.Location = new System.Drawing.Point(225, 21);
            this.rbTypeBusiness.Name = "rbTypeBusiness";
            this.rbTypeBusiness.Size = new System.Drawing.Size(91, 41);
            this.rbTypeBusiness.TabIndex = 52;
            this.rbTypeBusiness.Text = "사업자";
            this.rbTypeBusiness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbTypeBusiness.UseVisualStyleBackColor = true;
            // 
            // lblAuthNo
            // 
            this.lblAuthNo.AutoSize = true;
            this.lblAuthNo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAuthNo.Location = new System.Drawing.Point(150, 235);
            this.lblAuthNo.Name = "lblAuthNo";
            this.lblAuthNo.Size = new System.Drawing.Size(0, 16);
            this.lblAuthNo.TabIndex = 45;
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.Location = new System.Drawing.Point(37, 213);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(63, 14);
            this.lbl6.TabIndex = 45;
            this.lbl6.Text = "승인번호";
            // 
            // btnCashRecept
            // 
            this.btnCashRecept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnCashRecept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCashRecept.ForeColor = System.Drawing.Color.White;
            this.btnCashRecept.Location = new System.Drawing.Point(307, 213);
            this.btnCashRecept.Name = "btnCashRecept";
            this.btnCashRecept.Size = new System.Drawing.Size(140, 60);
            this.btnCashRecept.TabIndex = 44;
            this.btnCashRecept.Text = "현금영수증";
            this.btnCashRecept.UseVisualStyleBackColor = false;
            this.btnCashRecept.Click += new System.EventHandler(this.btnCashRecept_Click);
            // 
            // gbCashSimple
            // 
            this.gbCashSimple.Controls.Add(this.btnReset);
            this.gbCashSimple.Controls.Add(this.btnCashSimple);
            this.gbCashSimple.Controls.Add(this.lblRestAmount);
            this.gbCashSimple.Controls.Add(this.lblRcvAmount);
            this.gbCashSimple.Controls.Add(this.btn1t);
            this.gbCashSimple.Controls.Add(this.lbl3);
            this.gbCashSimple.Controls.Add(this.btn5t);
            this.gbCashSimple.Controls.Add(this.lbl2);
            this.gbCashSimple.Controls.Add(this.btn10t);
            this.gbCashSimple.Controls.Add(this.btn50t);
            this.gbCashSimple.Location = new System.Drawing.Point(22, 152);
            this.gbCashSimple.Name = "gbCashSimple";
            this.gbCashSimple.Size = new System.Drawing.Size(478, 182);
            this.gbCashSimple.TabIndex = 47;
            this.gbCashSimple.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnReset.Location = new System.Drawing.Point(228, 106);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(59, 40);
            this.btnReset.TabIndex = 51;
            this.btnReset.Text = "초기화";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCashSimple
            // 
            this.btnCashSimple.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnCashSimple.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCashSimple.ForeColor = System.Drawing.Color.White;
            this.btnCashSimple.Location = new System.Drawing.Point(307, 105);
            this.btnCashSimple.Name = "btnCashSimple";
            this.btnCashSimple.Size = new System.Drawing.Size(140, 42);
            this.btnCashSimple.TabIndex = 44;
            this.btnCashSimple.Text = "단순현금";
            this.btnCashSimple.UseVisualStyleBackColor = false;
            this.btnCashSimple.Click += new System.EventHandler(this.btnCashSimple_Click);
            // 
            // lblRestAmount
            // 
            this.lblRestAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRestAmount.Location = new System.Drawing.Point(116, 57);
            this.lblRestAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblRestAmount.Name = "lblRestAmount";
            this.lblRestAmount.Size = new System.Drawing.Size(162, 26);
            this.lblRestAmount.TabIndex = 46;
            this.lblRestAmount.Tag = "0";
            this.lblRestAmount.Text = "0";
            this.lblRestAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRcvAmount
            // 
            this.lblRcvAmount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRcvAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRcvAmount.Location = new System.Drawing.Point(116, 27);
            this.lblRcvAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblRcvAmount.Name = "lblRcvAmount";
            this.lblRcvAmount.Size = new System.Drawing.Size(162, 26);
            this.lblRcvAmount.TabIndex = 46;
            this.lblRcvAmount.Tag = "0";
            this.lblRcvAmount.Text = "0";
            this.lblRcvAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn1t
            // 
            this.btn1t.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1t.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btn1t.Location = new System.Drawing.Point(16, 106);
            this.btn1t.Name = "btn1t";
            this.btn1t.Size = new System.Drawing.Size(50, 40);
            this.btn1t.TabIndex = 44;
            this.btn1t.Text = "천";
            this.btn1t.UseVisualStyleBackColor = true;
            this.btn1t.Click += new System.EventHandler(this.btn1t_Click);
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(27, 64);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(63, 14);
            this.lbl3.TabIndex = 45;
            this.lbl3.Text = "거스름돈";
            // 
            // btn5t
            // 
            this.btn5t.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5t.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btn5t.Location = new System.Drawing.Point(69, 106);
            this.btn5t.Name = "btn5t";
            this.btn5t.Size = new System.Drawing.Size(50, 40);
            this.btn5t.TabIndex = 44;
            this.btn5t.Text = "오천";
            this.btn5t.UseVisualStyleBackColor = true;
            this.btn5t.Click += new System.EventHandler(this.btn5t_Click);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(27, 35);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(63, 14);
            this.lbl2.TabIndex = 45;
            this.lbl2.Text = "받은금액";
            // 
            // btn10t
            // 
            this.btn10t.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn10t.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btn10t.Location = new System.Drawing.Point(122, 106);
            this.btn10t.Name = "btn10t";
            this.btn10t.Size = new System.Drawing.Size(50, 40);
            this.btn10t.TabIndex = 44;
            this.btn10t.Text = "만";
            this.btn10t.UseVisualStyleBackColor = true;
            this.btn10t.Click += new System.EventHandler(this.btn10t_Click);
            // 
            // btn50t
            // 
            this.btn50t.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn50t.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btn50t.Location = new System.Drawing.Point(175, 106);
            this.btn50t.Name = "btn50t";
            this.btn50t.Size = new System.Drawing.Size(50, 40);
            this.btn50t.TabIndex = 44;
            this.btn50t.Text = "오만";
            this.btn50t.UseVisualStyleBackColor = true;
            this.btn50t.Click += new System.EventHandler(this.btn50t_Click);
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
            this.lblTitle.Location = new System.Drawing.Point(19, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(483, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "현금결제";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNetAmount.Location = new System.Drawing.Point(138, 91);
            this.lblNetAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Size = new System.Drawing.Size(162, 26);
            this.lblNetAmount.TabIndex = 46;
            this.lblNetAmount.Tag = "0";
            this.lblNetAmount.Text = "0";
            this.lblNetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(49, 97);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(63, 14);
            this.lbl1.TabIndex = 45;
            this.lbl1.Text = "결제금액";
            // 
            // frmPayCash
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPayCash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmPayCash";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPayCash_FormClosed);
            this.panelback.ResumeLayout(false);
            this.panelback.PerformLayout();
            this.gbCashReceipt.ResumeLayout(false);
            this.gbCashReceipt.PerformLayout();
            this.gbInputType.ResumeLayout(false);
            this.gbInputType.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbCashSimple.ResumeLayout(false);
            this.gbCashSimple.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbCashSimple;
        private System.Windows.Forms.Button btnCashSimple;
        private System.Windows.Forms.Label lblRestAmount;
        private System.Windows.Forms.Label lblRcvAmount;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btn1t;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Button btn5t;
        private System.Windows.Forms.Button btn10t;
        private System.Windows.Forms.Button btn50t;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.Button btnCashRecept;
        private System.Windows.Forms.GroupBox gbCashReceipt;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblAuthNo;
        private System.Windows.Forms.RadioButton rbTypeSelf;
        private System.Windows.Forms.RadioButton rbTypeBusiness;
        private System.Windows.Forms.RadioButton rbTypeIndividual;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gbInputType;
        private System.Windows.Forms.RadioButton rb화면입력;
        private System.Windows.Forms.RadioButton rb카드거래;
        private System.Windows.Forms.RadioButton rbKeyin;
        private System.Windows.Forms.Label lbl5;
    }
}