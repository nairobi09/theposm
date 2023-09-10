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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayEasy));
            this.panelback = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEasyAuth = new System.Windows.Forms.Button();
            this.lblT3 = new System.Windows.Forms.Label();
            this.tbCardNo = new System.Windows.Forms.TextBox();
            this.btnReader = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.lblT1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelback.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.groupBox1);
            this.panelback.Controls.Add(this.groupBox2);
            this.panelback.Controls.Add(this.lblNetAmount);
            this.panelback.Controls.Add(this.lblT1);
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
            this.groupBox1.Controls.Add(this.btnEasyAuth);
            this.groupBox1.Controls.Add(this.lblT3);
            this.groupBox1.Controls.Add(this.tbCardNo);
            this.groupBox1.Controls.Add(this.btnReader);
            this.groupBox1.Location = new System.Drawing.Point(23, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 171);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            // 
            // btnEasyAuth
            // 
            this.btnEasyAuth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnEasyAuth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEasyAuth.ForeColor = System.Drawing.Color.White;
            this.btnEasyAuth.Location = new System.Drawing.Point(334, 86);
            this.btnEasyAuth.Name = "btnEasyAuth";
            this.btnEasyAuth.Size = new System.Drawing.Size(121, 54);
            this.btnEasyAuth.TabIndex = 58;
            this.btnEasyAuth.Text = "승인요청";
            this.btnEasyAuth.UseVisualStyleBackColor = false;
            this.btnEasyAuth.Click += new System.EventHandler(this.btnEasyAuth_Click);
            // 
            // lblT3
            // 
            this.lblT3.AutoSize = true;
            this.lblT3.Location = new System.Drawing.Point(28, 44);
            this.lblT3.Name = "lblT3";
            this.lblT3.Size = new System.Drawing.Size(63, 14);
            this.lblT3.TabIndex = 48;
            this.lblT3.Text = "카드번호";
            // 
            // tbCardNo
            // 
            this.tbCardNo.BackColor = System.Drawing.Color.LemonChiffon;
            this.tbCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCardNo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbCardNo.Location = new System.Drawing.Point(121, 39);
            this.tbCardNo.MaxLength = 20;
            this.tbCardNo.Name = "tbCardNo";
            this.tbCardNo.Size = new System.Drawing.Size(190, 26);
            this.tbCardNo.TabIndex = 52;
            // 
            // btnReader
            // 
            this.btnReader.BackColor = System.Drawing.Color.White;
            this.btnReader.Image = ((System.Drawing.Image)(resources.GetObject("btnReader.Image")));
            this.btnReader.Location = new System.Drawing.Point(209, 86);
            this.btnReader.Name = "btnReader";
            this.btnReader.Size = new System.Drawing.Size(102, 54);
            this.btnReader.TabIndex = 50;
            this.btnReader.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(23, 471);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(479, 173);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(352, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 67);
            this.label9.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(258, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 67);
            this.label8.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(164, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 67);
            this.label7.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(350, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "Prompt Pay";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(53, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "페이코";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "Alipay";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(41, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "네이버페이";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "WeChat Pay";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkOrange;
            this.label1.Location = new System.Drawing.Point(42, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "카카오페이";
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
            // lblT1
            // 
            this.lblT1.AutoSize = true;
            this.lblT1.Location = new System.Drawing.Point(50, 128);
            this.lblT1.Name = "lblT1";
            this.lblT1.Size = new System.Drawing.Size(91, 14);
            this.lblT1.TabIndex = 48;
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
            this.lblTitle.ForeColor = System.Drawing.Color.Gainsboro;
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
            this.Location = new System.Drawing.Point(488, 56);
            this.Name = "frmPayEasy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmPayEasy";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPayEasy_FormClosed);
            this.panelback.ResumeLayout(false);
            this.panelback.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnReader;
        private System.Windows.Forms.TextBox tbCardNo;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.Label lblT1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblT3;
        private System.Windows.Forms.Button btnEasyAuth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}