namespace thepos._1Sales
{
    partial class frmDisplayBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDisplayBill));
            this.lblLayoutBill = new System.Windows.Forms.TextBox();
            this.btnPrintBillex = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrintBill = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLayoutBill
            // 
            this.lblLayoutBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLayoutBill.Font = new System.Drawing.Font("굴림체", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLayoutBill.Location = new System.Drawing.Point(13, 13);
            this.lblLayoutBill.Multiline = true;
            this.lblLayoutBill.Name = "lblLayoutBill";
            this.lblLayoutBill.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblLayoutBill.Size = new System.Drawing.Size(358, 663);
            this.lblLayoutBill.TabIndex = 56;
            this.lblLayoutBill.TabStop = false;
            this.lblLayoutBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPrintBillex
            // 
            this.btnPrintBillex.BackColor = System.Drawing.Color.White;
            this.btnPrintBillex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintBillex.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrintBillex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnPrintBillex.Location = new System.Drawing.Point(377, 77);
            this.btnPrintBillex.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrintBillex.Name = "btnPrintBillex";
            this.btnPrintBillex.Size = new System.Drawing.Size(119, 55);
            this.btnPrintBillex.TabIndex = 84;
            this.btnPrintBillex.TabStop = false;
            this.btnPrintBillex.Text = "영수증\r\n(상품제외)";
            this.btnPrintBillex.UseVisualStyleBackColor = false;
            this.btnPrintBillex.Click += new System.EventHandler(this.btnPrintBillex_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnClose.Location = new System.Drawing.Point(377, 145);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 50);
            this.btnClose.TabIndex = 83;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.BackColor = System.Drawing.Color.White;
            this.btnPrintBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintBill.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrintBill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnPrintBill.Location = new System.Drawing.Point(377, 14);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.Size = new System.Drawing.Size(120, 60);
            this.btnPrintBill.TabIndex = 82;
            this.btnPrintBill.TabStop = false;
            this.btnPrintBill.Text = "영수증";
            this.btnPrintBill.UseVisualStyleBackColor = false;
            this.btnPrintBill.Click += new System.EventHandler(this.btnPrintBill_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblLayoutBill);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnPrintBillex);
            this.panel1.Controls.Add(this.btnPrintBill);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 696);
            this.panel1.TabIndex = 85;
            // 
            // frmDisplayBill
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(520, 702);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDisplayBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDisplayBill";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox lblLayoutBill;
        private System.Windows.Forms.Button btnPrintBillex;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrintBill;
        private System.Windows.Forms.Panel panel1;
    }
}