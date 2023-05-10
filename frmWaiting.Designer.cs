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
            this.btnWaitingClose = new System.Windows.Forms.Button();
            this.btnWaitingDelete = new System.Windows.Forms.Button();
            this.btnWaitingOK = new System.Windows.Forms.Button();
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
            this.panelback.Controls.Add(this.btnWaitingClose);
            this.panelback.Controls.Add(this.btnWaitingDelete);
            this.panelback.Controls.Add(this.btnWaitingOK);
            this.panelback.Controls.Add(this.lvwWaiting);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 2;
            // 
            // btnWaitingClose
            // 
            this.btnWaitingClose.Location = new System.Drawing.Point(412, 470);
            this.btnWaitingClose.Name = "btnWaitingClose";
            this.btnWaitingClose.Size = new System.Drawing.Size(85, 48);
            this.btnWaitingClose.TabIndex = 43;
            this.btnWaitingClose.Text = "닫기";
            this.btnWaitingClose.UseVisualStyleBackColor = true;
            this.btnWaitingClose.Click += new System.EventHandler(this.btnWaitingClose_Click);
            // 
            // btnWaitingDelete
            // 
            this.btnWaitingDelete.Location = new System.Drawing.Point(22, 470);
            this.btnWaitingDelete.Name = "btnWaitingDelete";
            this.btnWaitingDelete.Size = new System.Drawing.Size(85, 48);
            this.btnWaitingDelete.TabIndex = 43;
            this.btnWaitingDelete.Text = "삭제";
            this.btnWaitingDelete.UseVisualStyleBackColor = true;
            this.btnWaitingDelete.Click += new System.EventHandler(this.btnWaitingDelete_Click);
            // 
            // btnWaitingOK
            // 
            this.btnWaitingOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnWaitingOK.Location = new System.Drawing.Point(113, 470);
            this.btnWaitingOK.Name = "btnWaitingOK";
            this.btnWaitingOK.Size = new System.Drawing.Size(293, 48);
            this.btnWaitingOK.TabIndex = 42;
            this.btnWaitingOK.Text = "선택";
            this.btnWaitingOK.UseVisualStyleBackColor = true;
            this.btnWaitingOK.Click += new System.EventHandler(this.btnWaitingOK_Click);
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
            this.status.Width = 110;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))));
            this.lblTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitle.Location = new System.Drawing.Point(22, 24);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(475, 39);
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
        private System.Windows.Forms.Button btnWaitingClose;
        private System.Windows.Forms.Button btnWaitingDelete;
        private System.Windows.Forms.Button btnWaitingOK;
        private System.Windows.Forms.ListView lvwWaiting;
        private System.Windows.Forms.ColumnHeader waiting_no;
        private System.Windows.Forms.ColumnHeader item_cnt;
        private System.Windows.Forms.ColumnHeader dt;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader rcv_amount;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.Label lblTitle;
    }
}