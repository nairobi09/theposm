namespace thepos
{
    partial class frmFlowTicketing
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
            this.btnTicketReact = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBusinessTitle = new System.Windows.Forms.Label();
            this.dtBusiness = new System.Windows.Forms.DateTimePicker();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lvwList = new System.Windows.Forms.ListView();
            this.stat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ticket_dt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ticket_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bangle_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelback.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.LightGray;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.btnTicketReact);
            this.panelback.Controls.Add(this.panel1);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Controls.Add(this.lvwList);
            this.panelback.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 4;
            // 
            // btnTicketReact
            // 
            this.btnTicketReact.BackColor = System.Drawing.Color.White;
            this.btnTicketReact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTicketReact.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnTicketReact.Location = new System.Drawing.Point(362, 625);
            this.btnTicketReact.Name = "btnTicketReact";
            this.btnTicketReact.Size = new System.Drawing.Size(140, 50);
            this.btnTicketReact.TabIndex = 78;
            this.btnTicketReact.Text = "띠지출력/팔찌등록";
            this.btnTicketReact.UseVisualStyleBackColor = false;
            this.btnTicketReact.Click += new System.EventHandler(this.btnTicketReact_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblBusinessTitle);
            this.panel1.Controls.Add(this.dtBusiness);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Location = new System.Drawing.Point(20, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 67);
            this.panel1.TabIndex = 77;
            // 
            // lblBusinessTitle
            // 
            this.lblBusinessTitle.AutoSize = true;
            this.lblBusinessTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBusinessTitle.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblBusinessTitle.Location = new System.Drawing.Point(12, 26);
            this.lblBusinessTitle.Name = "lblBusinessTitle";
            this.lblBusinessTitle.Size = new System.Drawing.Size(63, 14);
            this.lblBusinessTitle.TabIndex = 71;
            this.lblBusinessTitle.Text = "영업일자";
            this.lblBusinessTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtBusiness
            // 
            this.dtBusiness.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtBusiness.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBusiness.Location = new System.Drawing.Point(84, 22);
            this.dtBusiness.Name = "dtBusiness";
            this.dtBusiness.Size = new System.Drawing.Size(100, 23);
            this.dtBusiness.TabIndex = 68;
            this.dtBusiness.Value = new System.DateTime(2023, 5, 19, 1, 4, 57, 0);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnView.Location = new System.Drawing.Point(367, 13);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 40);
            this.btnView.TabIndex = 72;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SaddleBrown;
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
            this.lblTitle.BackColor = System.Drawing.Color.SaddleBrown;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(483, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "티켓";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvwList
            // 
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.stat,
            this.goods,
            this.ticket_dt,
            this.ticket_no,
            this.bangle_no,
            this.goods_code});
            this.lvwList.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwList.FullRowSelect = true;
            this.lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(20, 140);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(483, 468);
            this.lvwList.TabIndex = 44;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            // 
            // stat
            // 
            this.stat.Text = "상태";
            // 
            // goods
            // 
            this.goods.Text = "상품";
            this.goods.Width = 90;
            // 
            // ticket_dt
            // 
            this.ticket_dt.Text = "발권시간";
            this.ticket_dt.Width = 90;
            // 
            // ticket_no
            // 
            this.ticket_no.Text = "티켓번호";
            this.ticket_no.Width = 90;
            // 
            // bangle_no
            // 
            this.bangle_no.Text = "팔찌번호";
            this.bangle_no.Width = 90;
            // 
            // goods_code
            // 
            this.goods_code.Text = "goodsCode";
            this.goods_code.Width = 0;
            // 
            // frmFlowTicketing
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFlowTicketing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmFlowTicketing";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFlowTicketing_FormClosed);
            this.panelback.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader stat;
        private System.Windows.Forms.ColumnHeader goods;
        private System.Windows.Forms.ColumnHeader ticket_dt;
        private System.Windows.Forms.ColumnHeader ticket_no;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBusinessTitle;
        private System.Windows.Forms.DateTimePicker dtBusiness;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnTicketReact;
        private System.Windows.Forms.ColumnHeader bangle_no;
        private System.Windows.Forms.ColumnHeader goods_code;
    }
}