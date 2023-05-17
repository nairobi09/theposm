namespace thepos.pay
{
    partial class frmPayCard
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
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCashRecept = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btmCashTemp = new System.Windows.Forms.Button();
            this.btnKeyInput = new System.Windows.Forms.Button();
            this.btn1t = new System.Windows.Forms.Button();
            this.btn5t = new System.Windows.Forms.Button();
            this.btn10t = new System.Windows.Forms.Button();
            this.btn50t = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelback.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.groupBox1);
            this.panelback.Controls.Add(this.btmCashTemp);
            this.panelback.Controls.Add(this.btnCashRecept);
            this.panelback.Controls.Add(this.label4);
            this.panelback.Controls.Add(this.label1);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(336, 623);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(138, 46);
            this.btnClose.TabIndex = 43;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.lblTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitle.Location = new System.Drawing.Point(22, 24);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(475, 39);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "카드결제";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCashRecept
            // 
            this.btnCashRecept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnCashRecept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCashRecept.ForeColor = System.Drawing.Color.White;
            this.btnCashRecept.Location = new System.Drawing.Point(336, 348);
            this.btnCashRecept.Name = "btnCashRecept";
            this.btnCashRecept.Size = new System.Drawing.Size(137, 57);
            this.btnCashRecept.TabIndex = 47;
            this.btnCashRecept.Text = "승인요청";
            this.btnCashRecept.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(179, 144);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5);
            this.label4.Size = new System.Drawing.Size(162, 26);
            this.label4.TabIndex = 49;
            this.label4.Tag = "0";
            this.label4.Text = "0";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 14);
            this.label1.TabIndex = 48;
            this.label1.Text = "⁜결제대상금액";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 14);
            this.label2.TabIndex = 48;
            this.label2.Text = "⁜할부개월";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(137, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5);
            this.label3.Size = new System.Drawing.Size(162, 26);
            this.label3.TabIndex = 49;
            this.label3.Tag = "0";
            this.label3.Text = "0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btmCashTemp
            // 
            this.btmCashTemp.Location = new System.Drawing.Point(193, 349);
            this.btmCashTemp.Name = "btmCashTemp";
            this.btmCashTemp.Size = new System.Drawing.Size(137, 57);
            this.btmCashTemp.TabIndex = 50;
            this.btmCashTemp.Text = "임의등록";
            this.btmCashTemp.UseVisualStyleBackColor = true;
            // 
            // btnKeyInput
            // 
            this.btnKeyInput.BackColor = System.Drawing.Color.Gray;
            this.btnKeyInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyInput.ForeColor = System.Drawing.Color.White;
            this.btnKeyInput.Location = new System.Drawing.Point(331, 20);
            this.btnKeyInput.Name = "btnKeyInput";
            this.btnKeyInput.Size = new System.Drawing.Size(100, 40);
            this.btnKeyInput.TabIndex = 51;
            this.btnKeyInput.Text = "키입력";
            this.btnKeyInput.UseVisualStyleBackColor = false;
            // 
            // btn1t
            // 
            this.btn1t.Location = new System.Drawing.Point(136, 73);
            this.btn1t.Name = "btn1t";
            this.btn1t.Size = new System.Drawing.Size(90, 46);
            this.btn1t.TabIndex = 52;
            this.btn1t.Text = "일시불";
            this.btn1t.UseVisualStyleBackColor = true;
            // 
            // btn5t
            // 
            this.btn5t.Location = new System.Drawing.Point(228, 73);
            this.btn5t.Name = "btn5t";
            this.btn5t.Size = new System.Drawing.Size(61, 46);
            this.btn5t.TabIndex = 53;
            this.btn5t.Text = "3개월";
            this.btn5t.UseVisualStyleBackColor = true;
            // 
            // btn10t
            // 
            this.btn10t.Location = new System.Drawing.Point(291, 73);
            this.btn10t.Name = "btn10t";
            this.btn10t.Size = new System.Drawing.Size(61, 46);
            this.btn10t.TabIndex = 54;
            this.btn10t.Text = "6개월";
            this.btn10t.UseVisualStyleBackColor = true;
            // 
            // btn50t
            // 
            this.btn50t.Location = new System.Drawing.Point(354, 73);
            this.btn50t.Name = "btn50t";
            this.btn50t.Size = new System.Drawing.Size(61, 46);
            this.btn50t.TabIndex = 55;
            this.btn50t.Text = "12개월";
            this.btn50t.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn1t);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn5t);
            this.groupBox1.Controls.Add(this.btnKeyInput);
            this.groupBox1.Controls.Add(this.btn10t);
            this.groupBox1.Controls.Add(this.btn50t);
            this.groupBox1.Location = new System.Drawing.Point(42, 194);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 134);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            // 
            // frmPayCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(488, 56);
            this.Name = "frmPayCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmPayCard";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPayCard_FormClosed);
            this.panelback.ResumeLayout(false);
            this.panelback.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCashRecept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btmCashTemp;
        private System.Windows.Forms.Button btnKeyInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn1t;
        private System.Windows.Forms.Button btn5t;
        private System.Windows.Forms.Button btn10t;
        private System.Windows.Forms.Button btn50t;
    }
}