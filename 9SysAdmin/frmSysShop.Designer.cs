namespace thepos._9SysAdmin
{
    partial class frmSysShop
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbShopName = new System.Windows.Forms.TextBox();
            this.lblGoodsAmtTitle = new System.Windows.Forms.Label();
            this.lblGoodsNameTitle = new System.Windows.Forms.Label();
            this.tbShopCode = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lvwList = new System.Windows.Forms.ListView();
            this.shop_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.shop_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Location = new System.Drawing.Point(501, 314);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(146, 30);
            this.btnDelete.TabIndex = 55;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbShopName);
            this.groupBox1.Controls.Add(this.lblGoodsAmtTitle);
            this.groupBox1.Controls.Add(this.lblGoodsNameTitle);
            this.groupBox1.Controls.Add(this.tbShopCode);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(465, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 122);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            // 
            // tbShopName
            // 
            this.tbShopName.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbShopName.ForeColor = System.Drawing.Color.Black;
            this.tbShopName.Location = new System.Drawing.Point(77, 70);
            this.tbShopName.MaxLength = 16;
            this.tbShopName.Name = "tbShopName";
            this.tbShopName.Size = new System.Drawing.Size(105, 26);
            this.tbShopName.TabIndex = 42;
            // 
            // lblGoodsAmtTitle
            // 
            this.lblGoodsAmtTitle.AutoSize = true;
            this.lblGoodsAmtTitle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGoodsAmtTitle.ForeColor = System.Drawing.Color.Black;
            this.lblGoodsAmtTitle.Location = new System.Drawing.Point(14, 77);
            this.lblGoodsAmtTitle.Name = "lblGoodsAmtTitle";
            this.lblGoodsAmtTitle.Size = new System.Drawing.Size(55, 16);
            this.lblGoodsAmtTitle.TabIndex = 44;
            this.lblGoodsAmtTitle.Text = "샵이름";
            // 
            // lblGoodsNameTitle
            // 
            this.lblGoodsNameTitle.AutoSize = true;
            this.lblGoodsNameTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGoodsNameTitle.ForeColor = System.Drawing.Color.Black;
            this.lblGoodsNameTitle.Location = new System.Drawing.Point(14, 39);
            this.lblGoodsNameTitle.Name = "lblGoodsNameTitle";
            this.lblGoodsNameTitle.Size = new System.Drawing.Size(49, 14);
            this.lblGoodsNameTitle.TabIndex = 43;
            this.lblGoodsNameTitle.Text = "샵코드";
            // 
            // tbShopCode
            // 
            this.tbShopCode.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbShopCode.ForeColor = System.Drawing.Color.Black;
            this.tbShopCode.Location = new System.Drawing.Point(77, 32);
            this.tbShopCode.MaxLength = 2;
            this.tbShopCode.Name = "tbShopCode";
            this.tbShopCode.Size = new System.Drawing.Size(105, 26);
            this.tbShopCode.TabIndex = 41;
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.Location = new System.Drawing.Point(501, 258);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(146, 50);
            this.btnUpdate.TabIndex = 52;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.Location = new System.Drawing.Point(501, 202);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(146, 50);
            this.btnAdd.TabIndex = 53;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.Location = new System.Drawing.Point(206, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(76, 19);
            this.lblTitle.TabIndex = 51;
            this.lblTitle.Text = "샵 관리";
            // 
            // lvwList
            // 
            this.lvwList.BackColor = System.Drawing.SystemColors.Window;
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.shop_code,
            this.shop_name});
            this.lvwList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(204, 66);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(255, 279);
            this.lvwList.TabIndex = 50;
            this.lvwList.TabStop = false;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            this.lvwList.SelectedIndexChanged += new System.EventHandler(this.lvwList_SelectedIndexChanged);
            // 
            // shop_code
            // 
            this.shop_code.Text = "샵코드";
            // 
            // shop_name
            // 
            this.shop_name.Text = "샵이름";
            this.shop_name.Width = 100;
            // 
            // frmSysShop
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
            this.Name = "frmSysShop";
            this.Text = "frmSysShop";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbShopName;
        private System.Windows.Forms.Label lblGoodsAmtTitle;
        private System.Windows.Forms.Label lblGoodsNameTitle;
        private System.Windows.Forms.TextBox tbShopCode;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader shop_code;
        private System.Windows.Forms.ColumnHeader shop_name;
    }
}