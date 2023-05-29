namespace thepos
{
    partial class frmLayoutBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLayoutBill));
            this.lblLayoutBill = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLayoutBill
            // 
            this.lblLayoutBill.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblLayoutBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLayoutBill.Font = new System.Drawing.Font("GulimChe", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLayoutBill.Location = new System.Drawing.Point(225, 149);
            this.lblLayoutBill.Name = "lblLayoutBill";
            this.lblLayoutBill.Size = new System.Drawing.Size(283, 537);
            this.lblLayoutBill.TabIndex = 53;
            this.lblLayoutBill.Text = resources.GetString("lblLayoutBill.Text");
            // 
            // frmLayoutBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 834);
            this.Controls.Add(this.lblLayoutBill);
            this.Name = "frmLayoutBill";
            this.Text = "frmLayoutBill";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLayoutBill;
    }
}