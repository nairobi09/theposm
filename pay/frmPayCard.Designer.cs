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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblInstall = new System.Windows.Forms.Label();
            this.btnInstall00 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInstall03 = new System.Windows.Forms.Button();
            this.btnKeyInput = new System.Windows.Forms.Button();
            this.btnInstall06 = new System.Windows.Forms.Button();
            this.btnInstall12 = new System.Windows.Forms.Button();
            this.btmCardTemp = new System.Windows.Forms.Button();
            this.btnCardRequest = new System.Windows.Forms.Button();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.panelback.Controls.Add(this.btmCardTemp);
            this.panelback.Controls.Add(this.btnCardRequest);
            this.panelback.Controls.Add(this.lblNetAmount);
            this.panelback.Controls.Add(this.label1);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblInstall);
            this.groupBox1.Controls.Add(this.btnInstall00);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnInstall03);
            this.groupBox1.Controls.Add(this.btnKeyInput);
            this.groupBox1.Controls.Add(this.btnInstall06);
            this.groupBox1.Controls.Add(this.btnInstall12);
            this.groupBox1.Location = new System.Drawing.Point(23, 194);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 134);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            // 
            // lblInstall
            // 
            this.lblInstall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInstall.Location = new System.Drawing.Point(137, 26);
            this.lblInstall.Margin = new System.Windows.Forms.Padding(0);
            this.lblInstall.Name = "lblInstall";
            this.lblInstall.Padding = new System.Windows.Forms.Padding(5);
            this.lblInstall.Size = new System.Drawing.Size(162, 26);
            this.lblInstall.TabIndex = 49;
            this.lblInstall.Tag = "0";
            this.lblInstall.Text = "0";
            this.lblInstall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnInstall00
            // 
            this.btnInstall00.Location = new System.Drawing.Point(136, 73);
            this.btnInstall00.Name = "btnInstall00";
            this.btnInstall00.Size = new System.Drawing.Size(90, 46);
            this.btnInstall00.TabIndex = 52;
            this.btnInstall00.Text = "일시불";
            this.btnInstall00.UseVisualStyleBackColor = true;
            this.btnInstall00.Click += new System.EventHandler(this.btnInstall00_Click);
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
            // btnInstall03
            // 
            this.btnInstall03.Location = new System.Drawing.Point(228, 73);
            this.btnInstall03.Name = "btnInstall03";
            this.btnInstall03.Size = new System.Drawing.Size(61, 46);
            this.btnInstall03.TabIndex = 53;
            this.btnInstall03.Text = "3개월";
            this.btnInstall03.UseVisualStyleBackColor = true;
            this.btnInstall03.Click += new System.EventHandler(this.btnInstall03_Click);
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
            this.btnKeyInput.Click += new System.EventHandler(this.btnKeyInput_Click);
            // 
            // btnInstall06
            // 
            this.btnInstall06.Location = new System.Drawing.Point(291, 73);
            this.btnInstall06.Name = "btnInstall06";
            this.btnInstall06.Size = new System.Drawing.Size(61, 46);
            this.btnInstall06.TabIndex = 54;
            this.btnInstall06.Text = "6개월";
            this.btnInstall06.UseVisualStyleBackColor = true;
            this.btnInstall06.Click += new System.EventHandler(this.btnInstall06_Click);
            // 
            // btnInstall12
            // 
            this.btnInstall12.Location = new System.Drawing.Point(354, 73);
            this.btnInstall12.Name = "btnInstall12";
            this.btnInstall12.Size = new System.Drawing.Size(61, 46);
            this.btnInstall12.TabIndex = 55;
            this.btnInstall12.Text = "12개월";
            this.btnInstall12.UseVisualStyleBackColor = true;
            this.btnInstall12.Click += new System.EventHandler(this.btnInstall12_Click);
            // 
            // btmCardTemp
            // 
            this.btmCardTemp.Location = new System.Drawing.Point(193, 349);
            this.btmCardTemp.Name = "btmCardTemp";
            this.btmCardTemp.Size = new System.Drawing.Size(137, 57);
            this.btmCardTemp.TabIndex = 50;
            this.btmCardTemp.Text = "임의등록";
            this.btmCardTemp.UseVisualStyleBackColor = true;
            // 
            // btnCardRequest
            // 
            this.btnCardRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnCardRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCardRequest.ForeColor = System.Drawing.Color.White;
            this.btnCardRequest.Location = new System.Drawing.Point(336, 348);
            this.btnCardRequest.Name = "btnCardRequest";
            this.btnCardRequest.Size = new System.Drawing.Size(137, 57);
            this.btnCardRequest.TabIndex = 47;
            this.btnCardRequest.Text = "승인요청";
            this.btnCardRequest.UseVisualStyleBackColor = false;
            this.btnCardRequest.Click += new System.EventHandler(this.btnCardRequest_Click);
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNetAmount.Location = new System.Drawing.Point(159, 144);
            this.lblNetAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Padding = new System.Windows.Forms.Padding(5);
            this.lblNetAmount.Size = new System.Drawing.Size(162, 26);
            this.lblNetAmount.TabIndex = 49;
            this.lblNetAmount.Tag = "0";
            this.lblNetAmount.Text = "0";
            this.lblNetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 14);
            this.label1.TabIndex = 48;
            this.label1.Text = "⁜결제대상금액";
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
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.lblTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(425, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "카드결제";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
        private System.Windows.Forms.Button btnCardRequest;
        private System.Windows.Forms.Label lblInstall;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btmCardTemp;
        private System.Windows.Forms.Button btnKeyInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInstall00;
        private System.Windows.Forms.Button btnInstall03;
        private System.Windows.Forms.Button btnInstall06;
        private System.Windows.Forms.Button btnInstall12;
    }
}