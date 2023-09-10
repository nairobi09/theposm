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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayPoint));
            this.panelback = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbTicketNo = new System.Windows.Forms.TextBox();
            this.btnRequestAuth = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReader = new System.Windows.Forms.Button();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.lblT1 = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.tbTicketNo);
            this.groupBox1.Controls.Add(this.btnRequestAuth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnReader);
            this.groupBox1.Location = new System.Drawing.Point(23, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 179);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            // 
            // tbTicketNo
            // 
            this.tbTicketNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTicketNo.Location = new System.Drawing.Point(121, 38);
            this.tbTicketNo.Name = "tbTicketNo";
            this.tbTicketNo.Size = new System.Drawing.Size(209, 23);
            this.tbTicketNo.TabIndex = 60;
            // 
            // btnRequestAuth
            // 
            this.btnRequestAuth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnRequestAuth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestAuth.ForeColor = System.Drawing.Color.White;
            this.btnRequestAuth.Location = new System.Drawing.Point(273, 79);
            this.btnRequestAuth.Name = "btnRequestAuth";
            this.btnRequestAuth.Size = new System.Drawing.Size(102, 54);
            this.btnRequestAuth.TabIndex = 58;
            this.btnRequestAuth.Text = "승인요청";
            this.btnRequestAuth.UseVisualStyleBackColor = false;
            this.btnRequestAuth.Click += new System.EventHandler(this.btnRequestPoint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 48;
            this.label1.Text = "티켓번호";
            // 
            // btnReader
            // 
            this.btnReader.BackColor = System.Drawing.Color.White;
            this.btnReader.Image = ((System.Drawing.Image)(resources.GetObject("btnReader.Image")));
            this.btnReader.Location = new System.Drawing.Point(150, 79);
            this.btnReader.Name = "btnReader";
            this.btnReader.Size = new System.Drawing.Size(102, 54);
            this.btnReader.TabIndex = 50;
            this.btnReader.UseVisualStyleBackColor = false;
            this.btnReader.Click += new System.EventHandler(this.btnReader_Click);
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
            this.lblTitle.Text = "포인트결제";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPayPoint
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(488, 56);
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
        private System.Windows.Forms.Label lblT1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRequestAuth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReader;
        private System.Windows.Forms.TextBox tbTicketNo;
    }
}