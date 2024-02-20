namespace thepos._9SysAdmin
{
    partial class frmSysSoldout
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
            this.lblGoodsTitle = new System.Windows.Forms.Label();
            this.lvwGoodsList = new System.Windows.Forms.ListView();
            this.shop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goods_soldout = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGoodsUpdate = new System.Windows.Forms.Button();
            this.cbGoodsSoldout = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbGroupSoldout = new System.Windows.Forms.CheckBox();
            this.btnGroupUpdate = new System.Windows.Forms.Button();
            this.lvwGroupList = new System.Windows.Forms.ListView();
            this.pos_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.group_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.group_soldout = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblGroupTitle = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGoodsTitle
            // 
            this.lblGoodsTitle.AutoSize = true;
            this.lblGoodsTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGoodsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGoodsTitle.Location = new System.Drawing.Point(25, 23);
            this.lblGoodsTitle.Name = "lblGoodsTitle";
            this.lblGoodsTitle.Size = new System.Drawing.Size(35, 14);
            this.lblGoodsTitle.TabIndex = 50;
            this.lblGoodsTitle.Text = "상품";
            // 
            // lvwGoodsList
            // 
            this.lvwGoodsList.BackColor = System.Drawing.SystemColors.Window;
            this.lvwGoodsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.shop,
            this.name,
            this.goods_amt,
            this.goods_soldout});
            this.lvwGoodsList.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwGoodsList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwGoodsList.FullRowSelect = true;
            this.lvwGoodsList.GridLines = true;
            this.lvwGoodsList.HideSelection = false;
            this.lvwGoodsList.Location = new System.Drawing.Point(25, 58);
            this.lvwGoodsList.MultiSelect = false;
            this.lvwGoodsList.Name = "lvwGoodsList";
            this.lvwGoodsList.Size = new System.Drawing.Size(395, 460);
            this.lvwGoodsList.TabIndex = 51;
            this.lvwGoodsList.TabStop = false;
            this.lvwGoodsList.UseCompatibleStateImageBehavior = false;
            this.lvwGoodsList.View = System.Windows.Forms.View.Details;
            this.lvwGoodsList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwGoodsList_ColumnClick);
            this.lvwGoodsList.SelectedIndexChanged += new System.EventHandler(this.lvwGoodsList_SelectedIndexChanged);
            // 
            // shop
            // 
            this.shop.Text = "업장";
            // 
            // name
            // 
            this.name.Text = "상품명";
            this.name.Width = 179;
            // 
            // goods_amt
            // 
            this.goods_amt.Text = "단가";
            this.goods_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.goods_amt.Width = 70;
            // 
            // goods_soldout
            // 
            this.goods_soldout.Text = "품절";
            this.goods_soldout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.goods_soldout.Width = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGoodsUpdate);
            this.groupBox1.Controls.Add(this.cbGoodsSoldout);
            this.groupBox1.Location = new System.Drawing.Point(25, 535);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 115);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            // 
            // btnGoodsUpdate
            // 
            this.btnGoodsUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGoodsUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoodsUpdate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGoodsUpdate.ForeColor = System.Drawing.Color.White;
            this.btnGoodsUpdate.Location = new System.Drawing.Point(102, 53);
            this.btnGoodsUpdate.Name = "btnGoodsUpdate";
            this.btnGoodsUpdate.Size = new System.Drawing.Size(120, 40);
            this.btnGoodsUpdate.TabIndex = 56;
            this.btnGoodsUpdate.TabStop = false;
            this.btnGoodsUpdate.Text = "상품수정";
            this.btnGoodsUpdate.UseVisualStyleBackColor = false;
            this.btnGoodsUpdate.Click += new System.EventHandler(this.btnGoodsUpdate_Click);
            // 
            // cbGoodsSoldout
            // 
            this.cbGoodsSoldout.AutoSize = true;
            this.cbGoodsSoldout.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbGoodsSoldout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.cbGoodsSoldout.Location = new System.Drawing.Point(102, 23);
            this.cbGoodsSoldout.Name = "cbGoodsSoldout";
            this.cbGoodsSoldout.Size = new System.Drawing.Size(82, 18);
            this.cbGoodsSoldout.TabIndex = 55;
            this.cbGoodsSoldout.TabStop = false;
            this.cbGoodsSoldout.Text = "상품품절";
            this.cbGoodsSoldout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbGoodsSoldout.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbGroupSoldout);
            this.groupBox3.Controls.Add(this.btnGroupUpdate);
            this.groupBox3.Location = new System.Drawing.Point(446, 535);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(330, 115);
            this.groupBox3.TabIndex = 66;
            this.groupBox3.TabStop = false;
            // 
            // cbGroupSoldout
            // 
            this.cbGroupSoldout.AutoSize = true;
            this.cbGroupSoldout.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbGroupSoldout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.cbGroupSoldout.Location = new System.Drawing.Point(115, 24);
            this.cbGroupSoldout.Name = "cbGroupSoldout";
            this.cbGroupSoldout.Size = new System.Drawing.Size(82, 18);
            this.cbGroupSoldout.TabIndex = 56;
            this.cbGroupSoldout.TabStop = false;
            this.cbGroupSoldout.Text = "그룹품절";
            this.cbGroupSoldout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbGroupSoldout.UseVisualStyleBackColor = true;
            // 
            // btnGroupUpdate
            // 
            this.btnGroupUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGroupUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGroupUpdate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGroupUpdate.ForeColor = System.Drawing.Color.White;
            this.btnGroupUpdate.Location = new System.Drawing.Point(115, 53);
            this.btnGroupUpdate.Name = "btnGroupUpdate";
            this.btnGroupUpdate.Size = new System.Drawing.Size(120, 40);
            this.btnGroupUpdate.TabIndex = 39;
            this.btnGroupUpdate.TabStop = false;
            this.btnGroupUpdate.Text = "그룹수정";
            this.btnGroupUpdate.UseVisualStyleBackColor = false;
            this.btnGroupUpdate.Click += new System.EventHandler(this.btnGroupUpdate_Click);
            // 
            // lvwGroupList
            // 
            this.lvwGroupList.BackColor = System.Drawing.Color.White;
            this.lvwGroupList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pos_no,
            this.group_name,
            this.group_soldout});
            this.lvwGroupList.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwGroupList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwGroupList.FullRowSelect = true;
            this.lvwGroupList.GridLines = true;
            this.lvwGroupList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwGroupList.HideSelection = false;
            this.lvwGroupList.Location = new System.Drawing.Point(446, 58);
            this.lvwGroupList.MultiSelect = false;
            this.lvwGroupList.Name = "lvwGroupList";
            this.lvwGroupList.Size = new System.Drawing.Size(385, 460);
            this.lvwGroupList.TabIndex = 65;
            this.lvwGroupList.TabStop = false;
            this.lvwGroupList.UseCompatibleStateImageBehavior = false;
            this.lvwGroupList.View = System.Windows.Forms.View.Details;
            this.lvwGroupList.SelectedIndexChanged += new System.EventHandler(this.lvwGroupList_SelectedIndexChanged);
            // 
            // pos_no
            // 
            this.pos_no.Text = "포스번호";
            this.pos_no.Width = 70;
            // 
            // group_name
            // 
            this.group_name.Text = "그룹명";
            this.group_name.Width = 120;
            // 
            // group_soldout
            // 
            this.group_soldout.Text = "품절";
            this.group_soldout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.group_soldout.Width = 50;
            // 
            // lblGroupTitle
            // 
            this.lblGroupTitle.AutoSize = true;
            this.lblGroupTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGroupTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGroupTitle.Location = new System.Drawing.Point(443, 23);
            this.lblGroupTitle.Name = "lblGroupTitle";
            this.lblGroupTitle.Size = new System.Drawing.Size(35, 14);
            this.lblGroupTitle.TabIndex = 68;
            this.lblGroupTitle.Text = "그룹";
            // 
            // frmSysSoldout
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(854, 671);
            this.Controls.Add(this.lblGroupTitle);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lvwGroupList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvwGoodsList);
            this.Controls.Add(this.lblGoodsTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSysSoldout";
            this.Text = "frmSoldout";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGoodsTitle;
        private System.Windows.Forms.ListView lvwGoodsList;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader goods_soldout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbGoodsSoldout;
        private System.Windows.Forms.ColumnHeader goods_amt;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnGroupUpdate;
        private System.Windows.Forms.ListView lvwGroupList;
        private System.Windows.Forms.ColumnHeader group_name;
        private System.Windows.Forms.ColumnHeader group_soldout;
        private System.Windows.Forms.Label lblGroupTitle;
        private System.Windows.Forms.Button btnGoodsUpdate;
        private System.Windows.Forms.CheckBox cbGroupSoldout;
        private System.Windows.Forms.ColumnHeader pos_no;
        private System.Windows.Forms.ColumnHeader shop;
    }
}