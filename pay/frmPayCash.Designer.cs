namespace thepos.pay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayCash));
            this.panelback = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblIssuedMethodNo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbTypeBusiness = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbtypeIndividual = new System.Windows.Forms.CheckBox();
            this.btnKeyInput = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCashSimple = new System.Windows.Forms.Button();
            this.lblRestAmount = new System.Windows.Forms.Label();
            this.lblRcvAmount = new System.Windows.Forms.Label();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btn1t = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btn5t = new System.Windows.Forms.Button();
            this.btn100t = new System.Windows.Forms.Button();
            this.btn10t = new System.Windows.Forms.Button();
            this.btnCashRecept = new System.Windows.Forms.Button();
            this.btmCashTemp = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btn50t = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panelback.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.btnReset);
            this.panelback.Controls.Add(this.groupBox2);
            this.panelback.Controls.Add(this.groupBox1);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.btn1t);
            this.panelback.Controls.Add(this.label7);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Controls.Add(this.btn5t);
            this.panelback.Controls.Add(this.btn100t);
            this.panelback.Controls.Add(this.btn10t);
            this.panelback.Controls.Add(this.btnCashRecept);
            this.panelback.Controls.Add(this.btmCashTemp);
            this.panelback.Controls.Add(this.button7);
            this.panelback.Controls.Add(this.btn50t);
            this.panelback.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 4;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Gray;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(406, 242);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(66, 46);
            this.btnReset.TabIndex = 51;
            this.btnReset.Text = "초기화";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblIssuedMethodNo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cbTypeBusiness);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbtypeIndividual);
            this.groupBox2.Controls.Add(this.btnKeyInput);
            this.groupBox2.Location = new System.Drawing.Point(23, 363);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 152);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Gulim", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(27, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 11);
            this.label11.TabIndex = 45;
            this.label11.Text = "(휴대전화, 카드번호 등)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(27, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 14);
            this.label8.TabIndex = 45;
            this.label8.Text = "발급수단번호";
            // 
            // lblIssuedMethodNo
            // 
            this.lblIssuedMethodNo.BackColor = System.Drawing.Color.White;
            this.lblIssuedMethodNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIssuedMethodNo.Location = new System.Drawing.Point(159, 32);
            this.lblIssuedMethodNo.Margin = new System.Windows.Forms.Padding(0);
            this.lblIssuedMethodNo.Name = "lblIssuedMethodNo";
            this.lblIssuedMethodNo.Padding = new System.Windows.Forms.Padding(5);
            this.lblIssuedMethodNo.Size = new System.Drawing.Size(162, 26);
            this.lblIssuedMethodNo.TabIndex = 46;
            this.lblIssuedMethodNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 45;
            this.label9.Text = "사용구분";
            // 
            // cbTypeBusiness
            // 
            this.cbTypeBusiness.AutoSize = true;
            this.cbTypeBusiness.Location = new System.Drawing.Point(231, 83);
            this.cbTypeBusiness.Name = "cbTypeBusiness";
            this.cbTypeBusiness.Size = new System.Drawing.Size(68, 18);
            this.cbTypeBusiness.TabIndex = 48;
            this.cbTypeBusiness.Text = "사업자";
            this.cbTypeBusiness.UseVisualStyleBackColor = true;
            this.cbTypeBusiness.CheckedChanged += new System.EventHandler(this.cbTypeBusiness_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 14);
            this.label10.TabIndex = 45;
            this.label10.Text = "승인번호";
            // 
            // cbtypeIndividual
            // 
            this.cbtypeIndividual.AutoSize = true;
            this.cbtypeIndividual.Checked = true;
            this.cbtypeIndividual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbtypeIndividual.Location = new System.Drawing.Point(162, 83);
            this.cbtypeIndividual.Name = "cbtypeIndividual";
            this.cbtypeIndividual.Size = new System.Drawing.Size(54, 18);
            this.cbtypeIndividual.TabIndex = 48;
            this.cbtypeIndividual.Text = "개인";
            this.cbtypeIndividual.UseVisualStyleBackColor = true;
            this.cbtypeIndividual.CheckedChanged += new System.EventHandler(this.cbtypeIndividual_CheckedChanged);
            // 
            // btnKeyInput
            // 
            this.btnKeyInput.BackColor = System.Drawing.Color.Gray;
            this.btnKeyInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyInput.ForeColor = System.Drawing.Color.White;
            this.btnKeyInput.Location = new System.Drawing.Point(337, 24);
            this.btnKeyInput.Name = "btnKeyInput";
            this.btnKeyInput.Size = new System.Drawing.Size(112, 39);
            this.btnKeyInput.TabIndex = 44;
            this.btnKeyInput.Text = "키입력";
            this.btnKeyInput.UseVisualStyleBackColor = false;
            this.btnKeyInput.Click += new System.EventHandler(this.btnKeyInput_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCashSimple);
            this.groupBox1.Controls.Add(this.lblRestAmount);
            this.groupBox1.Controls.Add(this.lblRcvAmount);
            this.groupBox1.Controls.Add(this.lblNetAmount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(23, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 118);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // btnCashSimple
            // 
            this.btnCashSimple.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnCashSimple.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCashSimple.ForeColor = System.Drawing.Color.White;
            this.btnCashSimple.Location = new System.Drawing.Point(311, 19);
            this.btnCashSimple.Name = "btnCashSimple";
            this.btnCashSimple.Size = new System.Drawing.Size(136, 88);
            this.btnCashSimple.TabIndex = 44;
            this.btnCashSimple.Text = "단순현금";
            this.btnCashSimple.UseVisualStyleBackColor = false;
            // 
            // lblRestAmount
            // 
            this.lblRestAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRestAmount.Location = new System.Drawing.Point(116, 80);
            this.lblRestAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblRestAmount.Name = "lblRestAmount";
            this.lblRestAmount.Padding = new System.Windows.Forms.Padding(5);
            this.lblRestAmount.Size = new System.Drawing.Size(162, 26);
            this.lblRestAmount.TabIndex = 46;
            this.lblRestAmount.Tag = "0";
            this.lblRestAmount.Text = "0";
            this.lblRestAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRcvAmount
            // 
            this.lblRcvAmount.BackColor = System.Drawing.Color.White;
            this.lblRcvAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRcvAmount.Location = new System.Drawing.Point(116, 50);
            this.lblRcvAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblRcvAmount.Name = "lblRcvAmount";
            this.lblRcvAmount.Padding = new System.Windows.Forms.Padding(5);
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
            this.lblNetAmount.Padding = new System.Windows.Forms.Padding(5);
            this.lblNetAmount.Size = new System.Drawing.Size(162, 26);
            this.lblNetAmount.TabIndex = 46;
            this.lblNetAmount.Tag = "0";
            this.lblNetAmount.Text = "0";
            this.lblNetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 14);
            this.label3.TabIndex = 45;
            this.label3.Text = "⁜거스름돈";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 14);
            this.label2.TabIndex = 45;
            this.label2.Text = "⁜받은금액";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 14);
            this.label1.TabIndex = 45;
            this.label1.Text = "⁜받을금액";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(463, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 43;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "×";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btn1t
            // 
            this.btn1t.Location = new System.Drawing.Point(55, 242);
            this.btn1t.Name = "btn1t";
            this.btn1t.Size = new System.Drawing.Size(66, 46);
            this.btn1t.TabIndex = 44;
            this.btn1t.Text = "천원";
            this.btn1t.UseVisualStyleBackColor = true;
            this.btn1t.Click += new System.EventHandler(this.btn1t_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 346);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 14);
            this.label7.TabIndex = 45;
            this.label7.Text = "⁜현금영수증";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.lblTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(423, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "현금결제";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn5t
            // 
            this.btn5t.Location = new System.Drawing.Point(125, 242);
            this.btn5t.Name = "btn5t";
            this.btn5t.Size = new System.Drawing.Size(66, 46);
            this.btn5t.TabIndex = 44;
            this.btn5t.Text = "오천원";
            this.btn5t.UseVisualStyleBackColor = true;
            this.btn5t.Click += new System.EventHandler(this.btn5t_Click);
            // 
            // btn100t
            // 
            this.btn100t.Location = new System.Drawing.Point(335, 242);
            this.btn100t.Name = "btn100t";
            this.btn100t.Size = new System.Drawing.Size(66, 46);
            this.btn100t.TabIndex = 44;
            this.btn100t.Text = "십만원";
            this.btn100t.UseVisualStyleBackColor = true;
            this.btn100t.Click += new System.EventHandler(this.btn100t_Click);
            // 
            // btn10t
            // 
            this.btn10t.Location = new System.Drawing.Point(195, 242);
            this.btn10t.Name = "btn10t";
            this.btn10t.Size = new System.Drawing.Size(66, 46);
            this.btn10t.TabIndex = 44;
            this.btn10t.Text = "만원";
            this.btn10t.UseVisualStyleBackColor = true;
            this.btn10t.Click += new System.EventHandler(this.btn10t_Click);
            // 
            // btnCashRecept
            // 
            this.btnCashRecept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnCashRecept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCashRecept.ForeColor = System.Drawing.Color.White;
            this.btnCashRecept.Location = new System.Drawing.Point(337, 521);
            this.btnCashRecept.Name = "btnCashRecept";
            this.btnCashRecept.Size = new System.Drawing.Size(133, 57);
            this.btnCashRecept.TabIndex = 44;
            this.btnCashRecept.Text = "승인요청";
            this.btnCashRecept.UseVisualStyleBackColor = false;
            // 
            // btmCashTemp
            // 
            this.btmCashTemp.Location = new System.Drawing.Point(196, 521);
            this.btmCashTemp.Name = "btmCashTemp";
            this.btmCashTemp.Size = new System.Drawing.Size(137, 57);
            this.btmCashTemp.TabIndex = 44;
            this.btmCashTemp.Text = "임의등록";
            this.btmCashTemp.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(55, 521);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(137, 57);
            this.button7.TabIndex = 44;
            this.button7.Text = "입력요청";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // btn50t
            // 
            this.btn50t.Location = new System.Drawing.Point(265, 242);
            this.btn50t.Name = "btn50t";
            this.btn50t.Size = new System.Drawing.Size(66, 46);
            this.btn50t.TabIndex = 44;
            this.btn50t.Text = "오만원";
            this.btn50t.UseVisualStyleBackColor = true;
            this.btn50t.Click += new System.EventHandler(this.btn50t_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // frmPayCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(488, 56);
            this.Name = "frmPayCash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmPayCash";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPayCash_FormClosed);
            this.panelback.ResumeLayout(false);
            this.panelback.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckBox cbTypeBusiness;
        private System.Windows.Forms.CheckBox cbtypeIndividual;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCashSimple;
        private System.Windows.Forms.Label lblRestAmount;
        private System.Windows.Forms.Label lblRcvAmount;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn1t;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn5t;
        private System.Windows.Forms.Button btn100t;
        private System.Windows.Forms.Button btn10t;
        private System.Windows.Forms.Button btn50t;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCashRecept;
        private System.Windows.Forms.Button btmCashTemp;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblIssuedMethodNo;
        private System.Windows.Forms.Button btnKeyInput;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnReset;
    }
}