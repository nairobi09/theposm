namespace thepos
{
    partial class frmWaiting
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lvwWaiting = new System.Windows.Forms.ListView();
            this.waiting_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.item_cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rcv_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelback.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.LightGray;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.btnDelete);
            this.panelback.Controls.Add(this.btnOK);
            this.panelback.Controls.Add(this.lvwWaiting);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(457, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 44;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "×";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(398, 600);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 48);
            this.btnDelete.TabIndex = 43;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOK.Location = new System.Drawing.Point(132, 600);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(260, 48);
            this.btnOK.TabIndex = 42;
            this.btnOK.Text = "선택";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lvwWaiting
            // 
            this.lvwWaiting.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.waiting_no,
            this.item_cnt,
            this.dt,
            this.columnHeader1,
            this.rcv_amount,
            this.status});
            this.lvwWaiting.FullRowSelect = true;
            this.lvwWaiting.HideSelection = false;
            this.lvwWaiting.Location = new System.Drawing.Point(22, 76);
            this.lvwWaiting.MultiSelect = false;
            this.lvwWaiting.Name = "lvwWaiting";
            this.lvwWaiting.Size = new System.Drawing.Size(475, 373);
            this.lvwWaiting.TabIndex = 41;
            this.lvwWaiting.UseCompatibleStateImageBehavior = false;
            this.lvwWaiting.View = System.Windows.Forms.View.Details;
            this.lvwWaiting.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvwWaiting_ColumnWidthChanging);
            // 
            // waiting_no
            // 
            this.waiting_no.Text = "#";
            this.waiting_no.Width = 30;
            // 
            // item_cnt
            // 
            this.item_cnt.Text = "항목수";
            this.item_cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dt
            // 
            this.dt.Text = "대기일시";
            this.dt.Width = 110;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "주문금액";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader1.Width = 80;
            // 
            // rcv_amount
            // 
            this.rcv_amount.Text = "받은금액";
            this.rcv_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rcv_amount.Width = 80;
            // 
            // status
            // 
            this.status.Text = "상태";
            this.status.Width = 90;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.lblTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(423, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "대기";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmWaiting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(488, 56);
            this.Name = "frmWaiting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmWaiting";
            this.panelback.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListView lvwWaiting;
        private System.Windows.Forms.ColumnHeader waiting_no;
        private System.Windows.Forms.ColumnHeader item_cnt;
        private System.Windows.Forms.ColumnHeader dt;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader rcv_amount;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
    }
}