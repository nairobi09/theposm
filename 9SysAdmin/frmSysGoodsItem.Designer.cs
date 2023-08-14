namespace thepos
{
    partial class frmSysGoodsItem
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
            this.lvwGoodsLink = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.locateX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.locateY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanelItemSelected = new System.Windows.Forms.TableLayoutPanel();
            this.comboGroup = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblT4 = new System.Windows.Forms.Label();
            this.lblT3 = new System.Windows.Forms.Label();
            this.lblT5 = new System.Windows.Forms.Label();
            this.tbLocateX = new System.Windows.Forms.TextBox();
            this.tbLocateY = new System.Windows.Forms.TextBox();
            this.tbSizeX = new System.Windows.Forms.TextBox();
            this.tbSizeY = new System.Windows.Forms.TextBox();
            this.lvwGoods = new System.Windows.Forms.ListView();
            this.item_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amt1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ticket = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taxfree = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboPosNo = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelItem = new System.Windows.Forms.TableLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnLink = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblT6 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblT1 = new System.Windows.Forms.Label();
            this.lblT2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwGoodsLink
            // 
            this.lvwGoodsLink.BackColor = System.Drawing.SystemColors.Window;
            this.lvwGoodsLink.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.amt,
            this.locateX,
            this.locateY,
            this.sizeX,
            this.sizeY});
            this.lvwGoodsLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwGoodsLink.FullRowSelect = true;
            this.lvwGoodsLink.GridLines = true;
            this.lvwGoodsLink.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwGoodsLink.HideSelection = false;
            this.lvwGoodsLink.Location = new System.Drawing.Point(353, 55);
            this.lvwGoodsLink.MultiSelect = false;
            this.lvwGoodsLink.Name = "lvwGoodsLink";
            this.lvwGoodsLink.Size = new System.Drawing.Size(387, 247);
            this.lvwGoodsLink.TabIndex = 43;
            this.lvwGoodsLink.TabStop = false;
            this.lvwGoodsLink.UseCompatibleStateImageBehavior = false;
            this.lvwGoodsLink.View = System.Windows.Forms.View.Details;
            this.lvwGoodsLink.SelectedIndexChanged += new System.EventHandler(this.lvwGoodsLink_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.Text = "상품명";
            this.name.Width = 100;
            // 
            // amt
            // 
            this.amt.Text = "단가";
            this.amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // locateX
            // 
            this.locateX.Text = "LocX";
            this.locateX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.locateX.Width = 50;
            // 
            // locateY
            // 
            this.locateY.Text = "LocY";
            this.locateY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.locateY.Width = 50;
            // 
            // sizeX
            // 
            this.sizeX.Text = "SzX";
            this.sizeX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sizeX.Width = 50;
            // 
            // sizeY
            // 
            this.sizeY.Text = "SzY";
            this.sizeY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sizeY.Width = 50;
            // 
            // tableLayoutPanelItemSelected
            // 
            this.tableLayoutPanelItemSelected.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelItemSelected.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelItemSelected.ColumnCount = 8;
            this.tableLayoutPanelItemSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanelItemSelected.Location = new System.Drawing.Point(353, 311);
            this.tableLayoutPanelItemSelected.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelItemSelected.Name = "tableLayoutPanelItemSelected";
            this.tableLayoutPanelItemSelected.RowCount = 8;
            this.tableLayoutPanelItemSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItemSelected.Size = new System.Drawing.Size(521, 393);
            this.tableLayoutPanelItemSelected.TabIndex = 60;
            // 
            // comboGroup
            // 
            this.comboGroup.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboGroup.FormattingEnabled = true;
            this.comboGroup.Location = new System.Drawing.Point(159, 14);
            this.comboGroup.Name = "comboGroup";
            this.comboGroup.Size = new System.Drawing.Size(114, 24);
            this.comboGroup.TabIndex = 61;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.Location = new System.Drawing.Point(17, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(96, 19);
            this.lblTitle.TabIndex = 62;
            this.lblTitle.Text = "상품 관리";
            // 
            // lblT4
            // 
            this.lblT4.AutoSize = true;
            this.lblT4.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblT4.Location = new System.Drawing.Point(10, 65);
            this.lblT4.Name = "lblT4";
            this.lblT4.Size = new System.Drawing.Size(34, 14);
            this.lblT4.TabIndex = 68;
            this.lblT4.Text = "size";
            // 
            // lblT3
            // 
            this.lblT3.AutoSize = true;
            this.lblT3.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblT3.Location = new System.Drawing.Point(12, 38);
            this.lblT3.Name = "lblT3";
            this.lblT3.Size = new System.Drawing.Size(27, 14);
            this.lblT3.TabIndex = 69;
            this.lblT3.Text = "loc";
            // 
            // lblT5
            // 
            this.lblT5.AutoSize = true;
            this.lblT5.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblT5.Location = new System.Drawing.Point(45, 15);
            this.lblT5.Name = "lblT5";
            this.lblT5.Size = new System.Drawing.Size(16, 14);
            this.lblT5.TabIndex = 70;
            this.lblT5.Text = "X";
            // 
            // tbLocateX
            // 
            this.tbLocateX.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbLocateX.Location = new System.Drawing.Point(41, 33);
            this.tbLocateX.MaxLength = 1;
            this.tbLocateX.Name = "tbLocateX";
            this.tbLocateX.Size = new System.Drawing.Size(31, 26);
            this.tbLocateX.TabIndex = 75;
            // 
            // tbLocateY
            // 
            this.tbLocateY.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbLocateY.Location = new System.Drawing.Point(78, 33);
            this.tbLocateY.MaxLength = 1;
            this.tbLocateY.Name = "tbLocateY";
            this.tbLocateY.Size = new System.Drawing.Size(31, 26);
            this.tbLocateY.TabIndex = 76;
            // 
            // tbSizeX
            // 
            this.tbSizeX.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSizeX.Location = new System.Drawing.Point(41, 62);
            this.tbSizeX.MaxLength = 1;
            this.tbSizeX.Name = "tbSizeX";
            this.tbSizeX.Size = new System.Drawing.Size(31, 26);
            this.tbSizeX.TabIndex = 77;
            // 
            // tbSizeY
            // 
            this.tbSizeY.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSizeY.Location = new System.Drawing.Point(78, 62);
            this.tbSizeY.MaxLength = 1;
            this.tbSizeY.Name = "tbSizeY";
            this.tbSizeY.Size = new System.Drawing.Size(31, 26);
            this.tbSizeY.TabIndex = 78;
            // 
            // lvwGoods
            // 
            this.lvwGoods.BackColor = System.Drawing.SystemColors.Window;
            this.lvwGoods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.item_name,
            this.amt1,
            this.ticket,
            this.taxfree,
            this.memo});
            this.lvwGoods.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwGoods.FullRowSelect = true;
            this.lvwGoods.GridLines = true;
            this.lvwGoods.HideSelection = false;
            this.lvwGoods.Location = new System.Drawing.Point(14, 55);
            this.lvwGoods.MultiSelect = false;
            this.lvwGoods.Name = "lvwGoods";
            this.lvwGoods.Size = new System.Drawing.Size(330, 382);
            this.lvwGoods.TabIndex = 80;
            this.lvwGoods.TabStop = false;
            this.lvwGoods.UseCompatibleStateImageBehavior = false;
            this.lvwGoods.View = System.Windows.Forms.View.Details;
            // 
            // item_name
            // 
            this.item_name.Text = "상품명";
            this.item_name.Width = 80;
            // 
            // amt1
            // 
            this.amt1.Text = "단가";
            this.amt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amt1.Width = 50;
            // 
            // ticket
            // 
            this.ticket.Text = "티";
            this.ticket.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ticket.Width = 30;
            // 
            // taxfree
            // 
            this.taxfree.Text = "면";
            this.taxfree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.taxfree.Width = 30;
            // 
            // memo
            // 
            this.memo.Text = "비고";
            this.memo.Width = 110;
            // 
            // comboPosNo
            // 
            this.comboPosNo.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboPosNo.FormattingEnabled = true;
            this.comboPosNo.Location = new System.Drawing.Point(51, 15);
            this.comboPosNo.Name = "comboPosNo";
            this.comboPosNo.Size = new System.Drawing.Size(56, 24);
            this.comboPosNo.TabIndex = 82;
            this.comboPosNo.SelectedIndexChanged += new System.EventHandler(this.comboPosNo_SelectedIndexChanged);
            // 
            // tableLayoutPanelItem
            // 
            this.tableLayoutPanelItem.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelItem.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelItem.ColumnCount = 8;
            this.tableLayoutPanelItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanelItem.Location = new System.Drawing.Point(14, 447);
            this.tableLayoutPanelItem.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelItem.Name = "tableLayoutPanelItem";
            this.tableLayoutPanelItem.RowCount = 8;
            this.tableLayoutPanelItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelItem.Size = new System.Drawing.Size(330, 257);
            this.tableLayoutPanelItem.TabIndex = 84;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Location = new System.Drawing.Point(13, 137);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 24);
            this.btnDelete.TabIndex = 88;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.Location = new System.Drawing.Point(13, 96);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(96, 35);
            this.btnUpdate.TabIndex = 89;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnLink
            // 
            this.btnLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLink.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLink.Location = new System.Drawing.Point(764, 224);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(96, 35);
            this.btnLink.TabIndex = 90;
            this.btnLink.Text = "상품연결";
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbLocateX);
            this.groupBox1.Controls.Add(this.lblT6);
            this.groupBox1.Controls.Add(this.lblT5);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.lblT3);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.lblT4);
            this.groupBox1.Controls.Add(this.tbSizeY);
            this.groupBox1.Controls.Add(this.tbSizeX);
            this.groupBox1.Controls.Add(this.tbLocateY);
            this.groupBox1.Location = new System.Drawing.Point(751, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 167);
            this.groupBox1.TabIndex = 93;
            this.groupBox1.TabStop = false;
            // 
            // lblT6
            // 
            this.lblT6.AutoSize = true;
            this.lblT6.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblT6.Location = new System.Drawing.Point(82, 13);
            this.lblT6.Name = "lblT6";
            this.lblT6.Size = new System.Drawing.Size(17, 16);
            this.lblT6.TabIndex = 70;
            this.lblT6.Text = "Y";
            // 
            // btnApply
            // 
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnApply.Location = new System.Drawing.Point(764, 265);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(96, 35);
            this.btnApply.TabIndex = 95;
            this.btnApply.Text = "적용보기";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblT1
            // 
            this.lblT1.AutoSize = true;
            this.lblT1.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblT1.Location = new System.Drawing.Point(8, 19);
            this.lblT1.Name = "lblT1";
            this.lblT1.Size = new System.Drawing.Size(39, 16);
            this.lblT1.TabIndex = 97;
            this.lblT1.Text = "포스";
            // 
            // lblT2
            // 
            this.lblT2.AutoSize = true;
            this.lblT2.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblT2.Location = new System.Drawing.Point(120, 18);
            this.lblT2.Name = "lblT2";
            this.lblT2.Size = new System.Drawing.Size(39, 16);
            this.lblT2.TabIndex = 97;
            this.lblT2.Text = "그룹";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnView);
            this.groupBox2.Controls.Add(this.comboGroup);
            this.groupBox2.Controls.Add(this.lblT2);
            this.groupBox2.Controls.Add(this.comboPosNo);
            this.groupBox2.Controls.Add(this.lblT1);
            this.groupBox2.Location = new System.Drawing.Point(353, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 46);
            this.groupBox2.TabIndex = 98;
            this.groupBox2.TabStop = false;
            // 
            // btnView
            // 
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.Location = new System.Drawing.Point(279, 13);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(90, 27);
            this.btnView.TabIndex = 98;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // frmSysGoodsItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 720);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLink);
            this.Controls.Add(this.tableLayoutPanelItem);
            this.Controls.Add(this.lvwGoods);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tableLayoutPanelItemSelected);
            this.Controls.Add(this.lvwGoodsLink);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSysGoodsItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "상품등록";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvwGoodsLink;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader amt;
        private System.Windows.Forms.ColumnHeader locateX;
        private System.Windows.Forms.ColumnHeader locateY;
        private System.Windows.Forms.ColumnHeader sizeX;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelItemSelected;
        private System.Windows.Forms.ColumnHeader sizeY;
        private System.Windows.Forms.ComboBox comboGroup;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblT4;
        private System.Windows.Forms.Label lblT3;
        private System.Windows.Forms.Label lblT5;
        private System.Windows.Forms.TextBox tbLocateX;
        private System.Windows.Forms.TextBox tbLocateY;
        private System.Windows.Forms.TextBox tbSizeX;
        private System.Windows.Forms.TextBox tbSizeY;
        private System.Windows.Forms.ListView lvwGoods;
        private System.Windows.Forms.ColumnHeader item_name;
        private System.Windows.Forms.ColumnHeader amt1;
        private System.Windows.Forms.ColumnHeader ticket;
        private System.Windows.Forms.ColumnHeader taxfree;
        private System.Windows.Forms.ColumnHeader memo;
        private System.Windows.Forms.ComboBox comboPosNo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelItem;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnLink;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblT6;
        private System.Windows.Forms.Label lblT1;
        private System.Windows.Forms.Label lblT2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnView;
    }
}