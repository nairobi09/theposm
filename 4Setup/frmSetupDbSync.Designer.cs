namespace thepos
{
    partial class frmSetupDbSync
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSyncDataServerToLocalAndMemory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.Location = new System.Drawing.Point(37, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(110, 14);
            this.lblTitle.TabIndex = 48;
            this.lblTitle.Text = "기초원장 동기화";
            // 
            // btnSyncDataServerToLocalAndMemory
            // 
            this.btnSyncDataServerToLocalAndMemory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnSyncDataServerToLocalAndMemory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSyncDataServerToLocalAndMemory.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSyncDataServerToLocalAndMemory.ForeColor = System.Drawing.Color.LightGray;
            this.btnSyncDataServerToLocalAndMemory.Location = new System.Drawing.Point(287, 324);
            this.btnSyncDataServerToLocalAndMemory.Margin = new System.Windows.Forms.Padding(1);
            this.btnSyncDataServerToLocalAndMemory.Name = "btnSyncDataServerToLocalAndMemory";
            this.btnSyncDataServerToLocalAndMemory.Size = new System.Drawing.Size(126, 49);
            this.btnSyncDataServerToLocalAndMemory.TabIndex = 49;
            this.btnSyncDataServerToLocalAndMemory.TabStop = false;
            this.btnSyncDataServerToLocalAndMemory.Text = "Download";
            this.btnSyncDataServerToLocalAndMemory.UseVisualStyleBackColor = false;
            this.btnSyncDataServerToLocalAndMemory.Click += new System.EventHandler(this.btnSyncDataServerToLocalAndMemory_Click);
            // 
            // frmSetupDbSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 700);
            this.Controls.Add(this.btnSyncDataServerToLocalAndMemory);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSetupDbSync";
            this.Text = "frmSetupDbSync";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSyncDataServerToLocalAndMemory;
    }
}