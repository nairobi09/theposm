namespace thepos
{
    partial class frmReqPos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbPosNo = new System.Windows.Forms.TextBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.lblPosNoTitle = new System.Windows.Forms.Label();
            this.lblMacTitle = new System.Windows.Forms.Label();
            this.lblMac = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.tbPosNo);
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.lblMac);
            this.panel1.Controls.Add(this.lblMacTitle);
            this.panel1.Controls.Add(this.lblPosNoTitle);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(590, 340);
            this.panel1.TabIndex = 5;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(135, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "포스기기등록신청";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(335, 254);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 44);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbPosNo
            // 
            this.tbPosNo.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPosNo.Location = new System.Drawing.Point(282, 73);
            this.tbPosNo.MaxLength = 4;
            this.tbPosNo.Name = "tbPosNo";
            this.tbPosNo.Size = new System.Drawing.Size(127, 29);
            this.tbPosNo.TabIndex = 1;
            // 
            // btnEnter
            // 
            this.btnEnter.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEnter.Location = new System.Drawing.Point(202, 254);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(127, 44);
            this.btnEnter.TabIndex = 5;
            this.btnEnter.Text = "요청";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // lblPosNoTitle
            // 
            this.lblPosNoTitle.AutoSize = true;
            this.lblPosNoTitle.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPosNoTitle.ForeColor = System.Drawing.Color.White;
            this.lblPosNoTitle.Location = new System.Drawing.Point(201, 79);
            this.lblPosNoTitle.Name = "lblPosNoTitle";
            this.lblPosNoTitle.Size = new System.Drawing.Size(63, 14);
            this.lblPosNoTitle.TabIndex = 1;
            this.lblPosNoTitle.Text = "포스번호";
            // 
            // lblMacTitle
            // 
            this.lblMacTitle.AutoSize = true;
            this.lblMacTitle.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMacTitle.ForeColor = System.Drawing.Color.White;
            this.lblMacTitle.Location = new System.Drawing.Point(201, 129);
            this.lblMacTitle.Name = "lblMacTitle";
            this.lblMacTitle.Size = new System.Drawing.Size(63, 14);
            this.lblMacTitle.TabIndex = 1;
            this.lblMacTitle.Text = "포스번호";
            // 
            // lblMac
            // 
            this.lblMac.AutoSize = true;
            this.lblMac.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMac.ForeColor = System.Drawing.Color.White;
            this.lblMac.Location = new System.Drawing.Point(288, 129);
            this.lblMac.Name = "lblMac";
            this.lblMac.Size = new System.Drawing.Size(63, 14);
            this.lblMac.TabIndex = 1;
            this.lblMac.Text = "포스번호";
            // 
            // frmReqPos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReqPos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbPosNo;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label lblPosNoTitle;
        private System.Windows.Forms.Label lblMacTitle;
        private System.Windows.Forms.Label lblMac;
    }
}