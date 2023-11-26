namespace thepos
{
    partial class frmOrderDCR
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
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.btnAllRate = new System.Windows.Forms.Button();
            this.btnAllAmount = new System.Windows.Forms.Button();
            this.btnSelRate = new System.Windows.Forms.Button();
            this.btnSelAmount = new System.Windows.Forms.Button();
            this.flowLayoutPanelDCR = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDCCancel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelback.SuspendLayout();
            this.flowLayoutPanelDCR.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.lblTitle2);
            this.panelback.Controls.Add(this.btnAllRate);
            this.panelback.Controls.Add(this.btnAllAmount);
            this.panelback.Controls.Add(this.btnSelRate);
            this.panelback.Controls.Add(this.btnSelAmount);
            this.panelback.Controls.Add(this.flowLayoutPanelDCR);
            this.panelback.Controls.Add(this.lblTitle1);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.btnDCCancel);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 3;
            // 
            // lblTitle2
            // 
            this.lblTitle2.AutoSize = true;
            this.lblTitle2.Location = new System.Drawing.Point(105, 91);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(115, 14);
            this.lblTitle2.TabIndex = 51;
            this.lblTitle2.Text = "★ 할인 즐겨찾기";
            this.lblTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAllRate
            // 
            this.btnAllRate.BackColor = System.Drawing.Color.White;
            this.btnAllRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnAllRate.Location = new System.Drawing.Point(354, 445);
            this.btnAllRate.Name = "btnAllRate";
            this.btnAllRate.Size = new System.Drawing.Size(120, 80);
            this.btnAllRate.TabIndex = 47;
            this.btnAllRate.TabStop = false;
            this.btnAllRate.Text = "전체 % 적용";
            this.btnAllRate.UseVisualStyleBackColor = false;
            this.btnAllRate.Click += new System.EventHandler(this.btnAllRate_Click);
            // 
            // btnAllAmount
            // 
            this.btnAllAmount.BackColor = System.Drawing.Color.White;
            this.btnAllAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnAllAmount.Location = new System.Drawing.Point(354, 349);
            this.btnAllAmount.Name = "btnAllAmount";
            this.btnAllAmount.Size = new System.Drawing.Size(120, 80);
            this.btnAllAmount.TabIndex = 48;
            this.btnAllAmount.TabStop = false;
            this.btnAllAmount.Text = "전체 ₩ 적용";
            this.btnAllAmount.UseVisualStyleBackColor = false;
            this.btnAllAmount.Click += new System.EventHandler(this.btnAllAmount_Click);
            // 
            // btnSelRate
            // 
            this.btnSelRate.BackColor = System.Drawing.Color.White;
            this.btnSelRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnSelRate.Location = new System.Drawing.Point(354, 245);
            this.btnSelRate.Name = "btnSelRate";
            this.btnSelRate.Size = new System.Drawing.Size(120, 80);
            this.btnSelRate.TabIndex = 49;
            this.btnSelRate.TabStop = false;
            this.btnSelRate.Text = "선택 % 적용";
            this.btnSelRate.UseVisualStyleBackColor = false;
            this.btnSelRate.Click += new System.EventHandler(this.btnSelRate_Click);
            // 
            // btnSelAmount
            // 
            this.btnSelAmount.BackColor = System.Drawing.Color.White;
            this.btnSelAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnSelAmount.Location = new System.Drawing.Point(354, 146);
            this.btnSelAmount.Name = "btnSelAmount";
            this.btnSelAmount.Size = new System.Drawing.Size(120, 80);
            this.btnSelAmount.TabIndex = 50;
            this.btnSelAmount.TabStop = false;
            this.btnSelAmount.Text = "선택 ₩ 적용";
            this.btnSelAmount.UseVisualStyleBackColor = false;
            this.btnSelAmount.Click += new System.EventHandler(this.btnSelAmount_Click);
            // 
            // flowLayoutPanelDCR
            // 
            this.flowLayoutPanelDCR.AutoScroll = true;
            this.flowLayoutPanelDCR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelDCR.Controls.Add(this.button1);
            this.flowLayoutPanelDCR.Controls.Add(this.button2);
            this.flowLayoutPanelDCR.Controls.Add(this.button3);
            this.flowLayoutPanelDCR.Controls.Add(this.button4);
            this.flowLayoutPanelDCR.Location = new System.Drawing.Point(23, 146);
            this.flowLayoutPanelDCR.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelDCR.Name = "flowLayoutPanelDCR";
            this.flowLayoutPanelDCR.Padding = new System.Windows.Forms.Padding(20);
            this.flowLayoutPanelDCR.Size = new System.Drawing.Size(280, 510);
            this.flowLayoutPanelDCR.TabIndex = 46;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(25, 25);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 50);
            this.button1.TabIndex = 45;
            this.button1.TabStop = false;
            this.button1.Text = "선택 10%";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SteelBlue;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(25, 85);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(230, 50);
            this.button2.TabIndex = 45;
            this.button2.TabStop = false;
            this.button2.Text = "선택 20%";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SteelBlue;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(25, 145);
            this.button3.Margin = new System.Windows.Forms.Padding(5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(230, 50);
            this.button3.TabIndex = 46;
            this.button3.TabStop = false;
            this.button3.Text = "선택 20%";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.SteelBlue;
            this.button4.FlatAppearance.BorderSize = 2;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(25, 205);
            this.button4.Margin = new System.Windows.Forms.Padding(5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(230, 50);
            this.button4.TabIndex = 47;
            this.button4.TabStop = false;
            this.button4.Text = "선택 20%";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.Location = new System.Drawing.Point(364, 91);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(87, 14);
            this.lblTitle1.TabIndex = 44;
            this.lblTitle1.Text = "☑ 할인 적용";
            this.lblTitle1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
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
            // btnDCCancel
            // 
            this.btnDCCancel.BackColor = System.Drawing.Color.White;
            this.btnDCCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDCCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDCCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnDCCancel.Location = new System.Drawing.Point(354, 576);
            this.btnDCCancel.Name = "btnDCCancel";
            this.btnDCCancel.Size = new System.Drawing.Size(120, 80);
            this.btnDCCancel.TabIndex = 42;
            this.btnDCCancel.TabStop = false;
            this.btnDCCancel.Text = "할인취소";
            this.btnDCCancel.UseVisualStyleBackColor = false;
            this.btnDCCancel.Click += new System.EventHandler(this.btnDCCancel_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(482, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "할인";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmOrderDCR
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOrderDCR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmDC";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAmountDC_FormClosed);
            this.panelback.ResumeLayout(false);
            this.panelback.PerformLayout();
            this.flowLayoutPanelDCR.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDCCancel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDCR;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.Button btnAllRate;
        private System.Windows.Forms.Button btnAllAmount;
        private System.Windows.Forms.Button btnSelRate;
        private System.Windows.Forms.Button btnSelAmount;
    }
}