namespace thepos
{
    partial class frmProductWaiting
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lvwWaiting = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rcv_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.order_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelback.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.Silver;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.lvwWaiting);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 541);
            this.panelback.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.MediumBlue;
            this.lblTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitle.Location = new System.Drawing.Point(11, 11);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(451, 39);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "대기";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.Navy;
            this.btnClose.Location = new System.Drawing.Point(470, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 38);
            this.btnClose.TabIndex = 39;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "×";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvwWaiting
            // 
            this.lvwWaiting.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.order_no,
            this.dt,
            this.amount,
            this.rcv_amount});
            this.lvwWaiting.FullRowSelect = true;
            this.lvwWaiting.HideSelection = false;
            this.lvwWaiting.Location = new System.Drawing.Point(11, 63);
            this.lvwWaiting.MultiSelect = false;
            this.lvwWaiting.Name = "lvwWaiting";
            this.lvwWaiting.Size = new System.Drawing.Size(501, 382);
            this.lvwWaiting.TabIndex = 41;
            this.lvwWaiting.UseCompatibleStateImageBehavior = false;
            this.lvwWaiting.View = System.Windows.Forms.View.Details;
            // 
            // no
            // 
            this.no.Text = "#";
            this.no.Width = 40;
            // 
            // dt
            // 
            this.dt.Text = "일시";
            this.dt.Width = 80;
            // 
            // amount
            // 
            this.amount.Text = "주문금액";
            this.amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amount.Width = 90;
            // 
            // rcv_amount
            // 
            this.rcv_amount.Text = "받은금액";
            this.rcv_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rcv_amount.Width = 90;
            // 
            // order_no
            // 
            this.order_no.Text = "주문번호";
            this.order_no.Width = 80;
            // 
            // frmProductWaiting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(529, 547);
            this.Controls.Add(this.panelback);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(488, 56);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmProductWaiting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmProductWaiting";
            this.panelback.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvwWaiting;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader dt;
        private System.Windows.Forms.ColumnHeader amount;
        private System.Windows.Forms.ColumnHeader rcv_amount;
        private System.Windows.Forms.ColumnHeader order_no;
    }
}