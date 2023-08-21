namespace thepos._9SysAdmin
{
    partial class frmSysGoods
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
            this.lvwList = new System.Windows.Forms.ListView();
            this.item_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ticket = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taxfree = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.usage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbGoodsName = new System.Windows.Forms.TextBox();
            this.tbGoodsAmt = new System.Windows.Forms.TextBox();
            this.lblGoodsNameTitle = new System.Windows.Forms.Label();
            this.lblGoodsAmtTitle = new System.Windows.Forms.Label();
            this.lblTaxFreeTitle = new System.Windows.Forms.Label();
            this.lblTicketTitle = new System.Windows.Forms.Label();
            this.cbTicket = new System.Windows.Forms.CheckBox();
            this.cbTaxFree = new System.Windows.Forms.CheckBox();
            this.lblActiveTitle = new System.Windows.Forms.Label();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbMemo = new System.Windows.Forms.TextBox();
            this.lblMemoTitle = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwList
            // 
            this.lvwList.BackColor = System.Drawing.SystemColors.Window;
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.item_name,
            this.amt,
            this.ticket,
            this.taxfree,
            this.usage,
            this.memo});
            this.lvwList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(94, 58);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(489, 613);
            this.lvwList.TabIndex = 39;
            this.lvwList.TabStop = false;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            this.lvwList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwList_ColumnClick);
            this.lvwList.SelectedIndexChanged += new System.EventHandler(this.lvwList_SelectedIndexChanged);
            // 
            // item_name
            // 
            this.item_name.Text = "상품명";
            this.item_name.Width = 110;
            // 
            // amt
            // 
            this.amt.Text = "단가";
            this.amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amt.Width = 70;
            // 
            // ticket
            // 
            this.ticket.Text = "티켓";
            this.ticket.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ticket.Width = 50;
            // 
            // taxfree
            // 
            this.taxfree.Text = "면세";
            this.taxfree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.taxfree.Width = 50;
            // 
            // usage
            // 
            this.usage.Text = "사용";
            this.usage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.usage.Width = 50;
            // 
            // memo
            // 
            this.memo.Text = "비고";
            this.memo.Width = 130;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.Location = new System.Drawing.Point(96, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(136, 19);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "기초상품 관리";
            // 
            // tbGoodsName
            // 
            this.tbGoodsName.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbGoodsName.ForeColor = System.Drawing.Color.Black;
            this.tbGoodsName.Location = new System.Drawing.Point(95, 28);
            this.tbGoodsName.MaxLength = 30;
            this.tbGoodsName.Name = "tbGoodsName";
            this.tbGoodsName.Size = new System.Drawing.Size(105, 26);
            this.tbGoodsName.TabIndex = 41;
            // 
            // tbGoodsAmt
            // 
            this.tbGoodsAmt.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbGoodsAmt.ForeColor = System.Drawing.Color.Black;
            this.tbGoodsAmt.Location = new System.Drawing.Point(95, 66);
            this.tbGoodsAmt.MaxLength = 16;
            this.tbGoodsAmt.Name = "tbGoodsAmt";
            this.tbGoodsAmt.Size = new System.Drawing.Size(105, 26);
            this.tbGoodsAmt.TabIndex = 42;
            // 
            // lblGoodsNameTitle
            // 
            this.lblGoodsNameTitle.AutoSize = true;
            this.lblGoodsNameTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGoodsNameTitle.ForeColor = System.Drawing.Color.Black;
            this.lblGoodsNameTitle.Location = new System.Drawing.Point(14, 35);
            this.lblGoodsNameTitle.Name = "lblGoodsNameTitle";
            this.lblGoodsNameTitle.Size = new System.Drawing.Size(49, 14);
            this.lblGoodsNameTitle.TabIndex = 43;
            this.lblGoodsNameTitle.Text = "상품명";
            // 
            // lblGoodsAmtTitle
            // 
            this.lblGoodsAmtTitle.AutoSize = true;
            this.lblGoodsAmtTitle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGoodsAmtTitle.ForeColor = System.Drawing.Color.Black;
            this.lblGoodsAmtTitle.Location = new System.Drawing.Point(14, 75);
            this.lblGoodsAmtTitle.Name = "lblGoodsAmtTitle";
            this.lblGoodsAmtTitle.Size = new System.Drawing.Size(39, 16);
            this.lblGoodsAmtTitle.TabIndex = 44;
            this.lblGoodsAmtTitle.Text = "단가";
            // 
            // lblTaxFreeTitle
            // 
            this.lblTaxFreeTitle.AutoSize = true;
            this.lblTaxFreeTitle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTaxFreeTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTaxFreeTitle.Location = new System.Drawing.Point(14, 161);
            this.lblTaxFreeTitle.Name = "lblTaxFreeTitle";
            this.lblTaxFreeTitle.Size = new System.Drawing.Size(71, 16);
            this.lblTaxFreeTitle.TabIndex = 44;
            this.lblTaxFreeTitle.Text = "면세상품";
            // 
            // lblTicketTitle
            // 
            this.lblTicketTitle.AutoSize = true;
            this.lblTicketTitle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTicketTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTicketTitle.Location = new System.Drawing.Point(14, 123);
            this.lblTicketTitle.Name = "lblTicketTitle";
            this.lblTicketTitle.Size = new System.Drawing.Size(71, 16);
            this.lblTicketTitle.TabIndex = 43;
            this.lblTicketTitle.Text = "티켓상품";
            // 
            // cbTicket
            // 
            this.cbTicket.AutoSize = true;
            this.cbTicket.Location = new System.Drawing.Point(98, 125);
            this.cbTicket.Name = "cbTicket";
            this.cbTicket.Size = new System.Drawing.Size(15, 14);
            this.cbTicket.TabIndex = 45;
            this.cbTicket.UseVisualStyleBackColor = true;
            // 
            // cbTaxFree
            // 
            this.cbTaxFree.AutoSize = true;
            this.cbTaxFree.Location = new System.Drawing.Point(98, 161);
            this.cbTaxFree.Name = "cbTaxFree";
            this.cbTaxFree.Size = new System.Drawing.Size(15, 14);
            this.cbTaxFree.TabIndex = 45;
            this.cbTaxFree.UseVisualStyleBackColor = true;
            // 
            // lblActiveTitle
            // 
            this.lblActiveTitle.AutoSize = true;
            this.lblActiveTitle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblActiveTitle.ForeColor = System.Drawing.Color.Black;
            this.lblActiveTitle.Location = new System.Drawing.Point(14, 200);
            this.lblActiveTitle.Name = "lblActiveTitle";
            this.lblActiveTitle.Size = new System.Drawing.Size(55, 16);
            this.lblActiveTitle.TabIndex = 44;
            this.lblActiveTitle.Text = "사용중";
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(98, 200);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(15, 14);
            this.cbActive.TabIndex = 45;
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.Location = new System.Drawing.Point(615, 393);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(182, 50);
            this.btnAdd.TabIndex = 46;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.Location = new System.Drawing.Point(615, 449);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(182, 50);
            this.btnUpdate.TabIndex = 46;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbMemo);
            this.groupBox1.Controls.Add(this.lblMemoTitle);
            this.groupBox1.Controls.Add(this.tbGoodsAmt);
            this.groupBox1.Controls.Add(this.lblGoodsAmtTitle);
            this.groupBox1.Controls.Add(this.lblTaxFreeTitle);
            this.groupBox1.Controls.Add(this.cbActive);
            this.groupBox1.Controls.Add(this.lblGoodsNameTitle);
            this.groupBox1.Controls.Add(this.cbTaxFree);
            this.groupBox1.Controls.Add(this.lblActiveTitle);
            this.groupBox1.Controls.Add(this.cbTicket);
            this.groupBox1.Controls.Add(this.lblTicketTitle);
            this.groupBox1.Controls.Add(this.tbGoodsName);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(598, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 306);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // tbMemo
            // 
            this.tbMemo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbMemo.ForeColor = System.Drawing.Color.Black;
            this.tbMemo.Location = new System.Drawing.Point(18, 261);
            this.tbMemo.MaxLength = 16;
            this.tbMemo.Name = "tbMemo";
            this.tbMemo.Size = new System.Drawing.Size(182, 26);
            this.tbMemo.TabIndex = 42;
            // 
            // lblMemoTitle
            // 
            this.lblMemoTitle.AutoSize = true;
            this.lblMemoTitle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMemoTitle.ForeColor = System.Drawing.Color.Black;
            this.lblMemoTitle.Location = new System.Drawing.Point(14, 241);
            this.lblMemoTitle.Name = "lblMemoTitle";
            this.lblMemoTitle.Size = new System.Drawing.Size(39, 16);
            this.lblMemoTitle.TabIndex = 44;
            this.lblMemoTitle.Text = "비고";
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Location = new System.Drawing.Point(615, 505);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(182, 30);
            this.btnDelete.TabIndex = 49;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmSysGoods
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(870, 710);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lvwList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSysGoods";
            this.Text = "frmSysGoods";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader item_name;
        private System.Windows.Forms.ColumnHeader amt;
        private System.Windows.Forms.ColumnHeader ticket;
        private System.Windows.Forms.ColumnHeader taxfree;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbGoodsName;
        private System.Windows.Forms.TextBox tbGoodsAmt;
        private System.Windows.Forms.Label lblGoodsNameTitle;
        private System.Windows.Forms.Label lblGoodsAmtTitle;
        private System.Windows.Forms.Label lblTaxFreeTitle;
        private System.Windows.Forms.Label lblTicketTitle;
        private System.Windows.Forms.CheckBox cbTicket;
        private System.Windows.Forms.CheckBox cbTaxFree;
        private System.Windows.Forms.Label lblActiveTitle;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.ColumnHeader usage;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader memo;
        private System.Windows.Forms.TextBox tbMemo;
        private System.Windows.Forms.Label lblMemoTitle;
        private System.Windows.Forms.Button btnDelete;
    }
}