namespace thepos._9SysAdmin
{
    partial class frmSysAdminMac
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lvwList = new System.Windows.Forms.ListView();
            this.PosNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.lblMacValue = new System.Windows.Forms.Label();
            this.lblMacTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(262, 331);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 44);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnEnter
            // 
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEnter.Location = new System.Drawing.Point(149, 331);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(107, 44);
            this.btnEnter.TabIndex = 25;
            this.btnEnter.TabStop = false;
            this.btnEnter.Text = "등록";
            this.btnEnter.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.Location = new System.Drawing.Point(24, 27);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(129, 19);
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "포스기기등록";
            // 
            // lvwList
            // 
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PosNo,
            this.mac,
            this.date});
            this.lvwList.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwList.FullRowSelect = true;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(92, 113);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(378, 197);
            this.lvwList.TabIndex = 28;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            // 
            // PosNo
            // 
            this.PosNo.Text = "포스번호";
            this.PosNo.Width = 80;
            // 
            // mac
            // 
            this.mac.Text = "Mac Address";
            this.mac.Width = 160;
            // 
            // date
            // 
            this.date.Text = "등록일";
            this.date.Width = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(17, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "포스목록";
            // 
            // lblMacValue
            // 
            this.lblMacValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMacValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMacValue.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMacValue.Location = new System.Drawing.Point(92, 74);
            this.lblMacValue.Name = "lblMacValue";
            this.lblMacValue.Size = new System.Drawing.Size(317, 29);
            this.lblMacValue.TabIndex = 27;
            this.lblMacValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMacTitle
            // 
            this.lblMacTitle.AutoSize = true;
            this.lblMacTitle.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMacTitle.Location = new System.Drawing.Point(17, 83);
            this.lblMacTitle.Name = "lblMacTitle";
            this.lblMacTitle.Size = new System.Drawing.Size(35, 14);
            this.lblMacTitle.TabIndex = 16;
            this.lblMacTitle.Text = "Mac";
            // 
            // frmSysAdminMac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lvwList);
            this.Controls.Add(this.lblMacValue);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMacTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSysAdminMac";
            this.Text = "frmSysAdminMac";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader PosNo;
        private System.Windows.Forms.ColumnHeader mac;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMacValue;
        private System.Windows.Forms.Label lblMacTitle;
    }
}