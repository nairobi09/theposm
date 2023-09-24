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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbl5 = new System.Windows.Forms.Label();
            this.rb카드거래 = new System.Windows.Forms.RadioButton();
            this.rbKeyin = new System.Windows.Forms.RadioButton();
            this.rb고객식별번호 = new System.Windows.Forms.RadioButton();
            this.tbIssuedMethodNo = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl4 = new System.Windows.Forms.Label();
            this.rbTypeSelf = new System.Windows.Forms.RadioButton();
            this.rbTypeIndividual = new System.Windows.Forms.RadioButton();
            this.rbTypeBusiness = new System.Windows.Forms.RadioButton();
            this.lblAuthNo = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.btnCashRecept = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCashSimple = new System.Windows.Forms.Button();
            this.lblRestAmount = new System.Windows.Forms.Label();
            this.lblRcvAmount = new System.Windows.Forms.Label();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.btn1t = new System.Windows.Forms.Button();
            this.lbl3 = new System.Windows.Forms.Label();
            this.btn5t = new System.Windows.Forms.Button();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btn10t = new System.Windows.Forms.Button();
            this.btn50t = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelback.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.groupBox2);
            this.panelback.Controls.Add(this.groupBox1);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.lblAuthNo);
            this.groupBox2.Controls.Add(this.lbl6);
            this.groupBox2.Controls.Add(this.btnCashRecept);
            this.groupBox2.Location = new System.Drawing.Point(22, 328);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 343);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbl5);
            this.groupBox4.Controls.Add(this.rb카드거래);
            this.groupBox4.Controls.Add(this.rbKeyin);
            this.groupBox4.Controls.Add(this.rb고객식별번호);
            this.groupBox4.Controls.Add(this.tbIssuedMethodNo);
            this.groupBox4.Location = new System.Drawing.Point(15, 80);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(450, 125);
            this.groupBox4.TabIndex = 54;
            this.groupBox4.TabStop = false;
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(20, 61);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(63, 14);
            this.lbl5.TabIndex = 45;
            this.lbl5.Text = "입력수단";
            // 
            // rb카드거래
            // 
            this.rb카드거래.AutoSize = true;
            this.rb카드거래.Location = new System.Drawing.Point(136, 84);
            this.rb카드거래.Name = "rb카드거래";
            this.rb카드거래.Size = new System.Drawing.Size(81, 18);
            this.rb카드거래.TabIndex = 50;
            this.rb카드거래.Text = "카드거래";
            this.rb카드거래.UseVisualStyleBackColor = true;
            // 
            // rbKeyin
            // 
            this.rbKeyin.AutoSize = true;
            this.rbKeyin.Checked = true;
            this.rbKeyin.Location = new System.Drawing.Point(136, 56);
            this.rbKeyin.Name = "rbKeyin";
            this.rbKeyin.Size = new System.Drawing.Size(60, 18);
            this.rbKeyin.TabIndex = 50;
            this.rbKeyin.TabStop = true;
            this.rbKeyin.Text = "Keyin";
            this.rbKeyin.UseVisualStyleBackColor = true;
            // 
            // rb고객식별번호
            // 
            this.rb고객식별번호.AutoSize = true;
            this.rb고객식별번호.Location = new System.Drawing.Point(136, 27);
            this.rb고객식별번호.Name = "rb고객식별번호";
            this.rb고객식별번호.Size = new System.Drawing.Size(109, 18);
            this.rb고객식별번호.TabIndex = 50;
            this.rb고객식별번호.Text = "고객식별번호";
            this.rb고객식별번호.UseVisualStyleBackColor = true;
            // 
            // tbIssuedMethodNo
            // 
            this.tbIssuedMethodNo.BackColor = System.Drawing.Color.LemonChiffon;
            this.tbIssuedMethodNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbIssuedMethodNo.Location = new System.Drawing.Point(257, 22);
            this.tbIssuedMethodNo.MaxLength = 20;
            this.tbIssuedMethodNo.Name = "tbIssuedMethodNo";
            this.tbIssuedMethodNo.Size = new System.Drawing.Size(161, 23);
            this.tbIssuedMethodNo.TabIndex = 49;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl4);
            this.groupBox3.Controls.Add(this.rbTypeSelf);
            this.groupBox3.Controls.Add(this.rbTypeIndividual);
            this.groupBox3.Controls.Add(this.rbTypeBusiness);
            this.groupBox3.Location = new System.Drawing.Point(15, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(451, 53);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(22, 24);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(63, 14);
            this.lbl4.TabIndex = 45;
            this.lbl4.Text = "발급구분";
            // 
            // rbTypeSelf
            // 
            this.rbTypeSelf.AutoSize = true;
            this.rbTypeSelf.Location = new System.Drawing.Point(286, 20);
            this.rbTypeSelf.Name = "rbTypeSelf";
            this.rbTypeSelf.Size = new System.Drawing.Size(81, 18);
            this.rbTypeSelf.TabIndex = 52;
            this.rbTypeSelf.Text = "자진발급";
            this.rbTypeSelf.UseVisualStyleBackColor = true;
            // 
            // rbTypeIndividual
            // 
            this.rbTypeIndividual.AutoSize = true;
            this.rbTypeIndividual.Checked = true;
            this.rbTypeIndividual.Location = new System.Drawing.Point(138, 20);
            this.rbTypeIndividual.Name = "rbTypeIndividual";
            this.rbTypeIndividual.Size = new System.Drawing.Size(53, 18);
            this.rbTypeIndividual.TabIndex = 52;
            this.rbTypeIndividual.TabStop = true;
            this.rbTypeIndividual.Text = "개인";
            this.rbTypeIndividual.UseVisualStyleBackColor = true;
            // 
            // rbTypeBusiness
            // 
            this.rbTypeBusiness.AutoSize = true;
            this.rbTypeBusiness.Location = new System.Drawing.Point(208, 20);
            this.rbTypeBusiness.Name = "rbTypeBusiness";
            this.rbTypeBusiness.Size = new System.Drawing.Size(67, 18);
            this.rbTypeBusiness.TabIndex = 52;
            this.rbTypeBusiness.Text = "사업자";
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
            this.lbl6.Location = new System.Drawing.Point(43, 235);
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
            this.btnCashRecept.Location = new System.Drawing.Point(314, 234);
            this.btnCashRecept.Name = "btnCashRecept";
            this.btnCashRecept.Size = new System.Drawing.Size(133, 63);
            this.btnCashRecept.TabIndex = 44;
            this.btnCashRecept.Text = "승인요청";
            this.btnCashRecept.UseVisualStyleBackColor = false;
            this.btnCashRecept.Click += new System.EventHandler(this.btnCashRecept_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnCashSimple);
            this.groupBox1.Controls.Add(this.lblRestAmount);
            this.groupBox1.Controls.Add(this.lblRcvAmount);
            this.groupBox1.Controls.Add(this.lblNetAmount);
            this.groupBox1.Controls.Add(this.btn1t);
            this.groupBox1.Controls.Add(this.lbl3);
            this.groupBox1.Controls.Add(this.btn5t);
            this.groupBox1.Controls.Add(this.lbl2);
            this.groupBox1.Controls.Add(this.lbl1);
            this.groupBox1.Controls.Add(this.btn10t);
            this.groupBox1.Controls.Add(this.btn50t);
            this.groupBox1.Location = new System.Drawing.Point(22, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 219);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Gray;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(228, 131);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(59, 46);
            this.btnReset.TabIndex = 51;
            this.btnReset.Text = "초기화";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCashSimple
            // 
            this.btnCashSimple.BackColor = System.Drawing.Color.White;
            this.btnCashSimple.ForeColor = System.Drawing.Color.Black;
            this.btnCashSimple.Location = new System.Drawing.Point(311, 113);
            this.btnCashSimple.Name = "btnCashSimple";
            this.btnCashSimple.Size = new System.Drawing.Size(136, 64);
            this.btnCashSimple.TabIndex = 44;
            this.btnCashSimple.Text = "단순현금";
            this.btnCashSimple.UseVisualStyleBackColor = false;
            this.btnCashSimple.Click += new System.EventHandler(this.btnCashSimple_Click);
            // 
            // lblRestAmount
            // 
            this.lblRestAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRestAmount.Location = new System.Drawing.Point(116, 80);
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
            this.lblRcvAmount.Location = new System.Drawing.Point(116, 50);
            this.lblRcvAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblRcvAmount.Name = "lblRcvAmount";
            this.lblRcvAmount.Size = new System.Drawing.Size(162, 26);
            this.lblRcvAmount.TabIndex = 46;
            this.lblRcvAmount.Tag = "0";
            this.lblRcvAmount.Text = "0";
            this.lblRcvAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNetAmount.Location = new System.Drawing.Point(116, 20);
            this.lblNetAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Size = new System.Drawing.Size(162, 26);
            this.lblNetAmount.TabIndex = 46;
            this.lblNetAmount.Tag = "0";
            this.lblNetAmount.Text = "0";
            this.lblNetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn1t
            // 
            this.btn1t.Location = new System.Drawing.Point(16, 131);
            this.btn1t.Name = "btn1t";
            this.btn1t.Size = new System.Drawing.Size(50, 46);
            this.btn1t.TabIndex = 44;
            this.btn1t.Text = "천";
            this.btn1t.UseVisualStyleBackColor = true;
            this.btn1t.Click += new System.EventHandler(this.btn1t_Click);
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(27, 87);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(63, 14);
            this.lbl3.TabIndex = 45;
            this.lbl3.Text = "거스름돈";
            // 
            // btn5t
            // 
            this.btn5t.Location = new System.Drawing.Point(69, 131);
            this.btn5t.Name = "btn5t";
            this.btn5t.Size = new System.Drawing.Size(50, 46);
            this.btn5t.TabIndex = 44;
            this.btn5t.Text = "오천";
            this.btn5t.UseVisualStyleBackColor = true;
            this.btn5t.Click += new System.EventHandler(this.btn5t_Click);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(27, 58);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(63, 14);
            this.lbl2.TabIndex = 45;
            this.lbl2.Text = "받은금액";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(27, 26);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(63, 14);
            this.lbl1.TabIndex = 45;
            this.lbl1.Text = "받을금액";
            // 
            // btn10t
            // 
            this.btn10t.Location = new System.Drawing.Point(122, 131);
            this.btn10t.Name = "btn10t";
            this.btn10t.Size = new System.Drawing.Size(50, 46);
            this.btn10t.TabIndex = 44;
            this.btn10t.Text = "만";
            this.btn10t.UseVisualStyleBackColor = true;
            this.btn10t.Click += new System.EventHandler(this.btn10t_Click);
            // 
            // btn50t
            // 
            this.btn50t.Location = new System.Drawing.Point(175, 131);
            this.btn50t.Name = "btn50t";
            this.btn50t.Size = new System.Drawing.Size(50, 46);
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
            this.lblTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitle.Location = new System.Drawing.Point(19, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(483, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "현금결제";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblAuthNo;
        private System.Windows.Forms.TextBox tbIssuedMethodNo;
        private System.Windows.Forms.RadioButton rbTypeSelf;
        private System.Windows.Forms.RadioButton rbTypeBusiness;
        private System.Windows.Forms.RadioButton rbTypeIndividual;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rb고객식별번호;
        private System.Windows.Forms.RadioButton rb카드거래;
        private System.Windows.Forms.RadioButton rbKeyin;
        private System.Windows.Forms.Label lbl5;
    }
}