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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysGoods));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbGoodsName = new System.Windows.Forms.TextBox();
            this.tbGoodsAmt = new System.Windows.Forms.TextBox();
            this.lblGoodsNameTitle = new System.Windows.Forms.Label();
            this.lblGoodsAmtTitle = new System.Windows.Forms.Label();
            this.cbTicket = new System.Windows.Forms.CheckBox();
            this.cbTaxFree = new System.Windows.Forms.CheckBox();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbGoodsNameJP = new System.Windows.Forms.TextBox();
            this.tbGoodsNameCH = new System.Windows.Forms.TextBox();
            this.tbGoodsNameEN = new System.Windows.Forms.TextBox();
            this.cbSoldout = new System.Windows.Forms.CheckBox();
            this.btnX = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.cbShop = new System.Windows.Forms.ComboBox();
            this.tbMemo = new System.Windows.Forms.TextBox();
            this.lblImageTitle = new System.Windows.Forms.Label();
            this.lblMemoTitle = new System.Windows.Forms.Label();
            this.lblShopTitle = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.goodsname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.shopcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.shopname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ticket = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taxfree = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.active = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goodscode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwList = new System.Windows.Forms.ListView();
            this.goodsnameEN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goodsnameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goodsnameJP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.soldout = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "photo.png");
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.Location = new System.Drawing.Point(34, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(103, 14);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "기초상품 관리";
            // 
            // tbGoodsName
            // 
            this.tbGoodsName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbGoodsName.ForeColor = System.Drawing.Color.Black;
            this.tbGoodsName.Location = new System.Drawing.Point(39, 38);
            this.tbGoodsName.MaxLength = 30;
            this.tbGoodsName.Name = "tbGoodsName";
            this.tbGoodsName.Size = new System.Drawing.Size(117, 23);
            this.tbGoodsName.TabIndex = 1;
            // 
            // tbGoodsAmt
            // 
            this.tbGoodsAmt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbGoodsAmt.ForeColor = System.Drawing.Color.Black;
            this.tbGoodsAmt.Location = new System.Drawing.Point(222, 67);
            this.tbGoodsAmt.MaxLength = 16;
            this.tbGoodsAmt.Name = "tbGoodsAmt";
            this.tbGoodsAmt.Size = new System.Drawing.Size(117, 23);
            this.tbGoodsAmt.TabIndex = 5;
            // 
            // lblGoodsNameTitle
            // 
            this.lblGoodsNameTitle.AutoSize = true;
            this.lblGoodsNameTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGoodsNameTitle.ForeColor = System.Drawing.Color.Black;
            this.lblGoodsNameTitle.Location = new System.Drawing.Point(37, 20);
            this.lblGoodsNameTitle.Name = "lblGoodsNameTitle";
            this.lblGoodsNameTitle.Size = new System.Drawing.Size(41, 12);
            this.lblGoodsNameTitle.TabIndex = 43;
            this.lblGoodsNameTitle.Text = "상품명";
            // 
            // lblGoodsAmtTitle
            // 
            this.lblGoodsAmtTitle.AutoSize = true;
            this.lblGoodsAmtTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGoodsAmtTitle.ForeColor = System.Drawing.Color.Black;
            this.lblGoodsAmtTitle.Location = new System.Drawing.Point(187, 73);
            this.lblGoodsAmtTitle.Name = "lblGoodsAmtTitle";
            this.lblGoodsAmtTitle.Size = new System.Drawing.Size(29, 12);
            this.lblGoodsAmtTitle.TabIndex = 44;
            this.lblGoodsAmtTitle.Text = "단가";
            // 
            // cbTicket
            // 
            this.cbTicket.AutoSize = true;
            this.cbTicket.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbTicket.Location = new System.Drawing.Point(189, 28);
            this.cbTicket.Name = "cbTicket";
            this.cbTicket.Size = new System.Drawing.Size(54, 18);
            this.cbTicket.TabIndex = 7;
            this.cbTicket.Text = "티켓";
            this.cbTicket.UseVisualStyleBackColor = true;
            // 
            // cbTaxFree
            // 
            this.cbTaxFree.AutoSize = true;
            this.cbTaxFree.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbTaxFree.Location = new System.Drawing.Point(251, 28);
            this.cbTaxFree.Name = "cbTaxFree";
            this.cbTaxFree.Size = new System.Drawing.Size(54, 18);
            this.cbTaxFree.TabIndex = 9;
            this.cbTaxFree.Text = "면세";
            this.cbTaxFree.UseVisualStyleBackColor = true;
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbActive.Location = new System.Drawing.Point(313, 28);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(54, 18);
            this.cbActive.TabIndex = 8;
            this.cbActive.Text = "사용";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.Location = new System.Drawing.Point(702, 557);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(140, 40);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.Location = new System.Drawing.Point(702, 603);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(140, 40);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.tbGoodsNameJP);
            this.groupBox1.Controls.Add(this.tbGoodsNameCH);
            this.groupBox1.Controls.Add(this.tbGoodsNameEN);
            this.groupBox1.Controls.Add(this.cbSoldout);
            this.groupBox1.Controls.Add(this.btnX);
            this.groupBox1.Controls.Add(this.pbImage);
            this.groupBox1.Controls.Add(this.cbShop);
            this.groupBox1.Controls.Add(this.tbMemo);
            this.groupBox1.Controls.Add(this.lblImageTitle);
            this.groupBox1.Controls.Add(this.lblMemoTitle);
            this.groupBox1.Controls.Add(this.tbGoodsAmt);
            this.groupBox1.Controls.Add(this.lblGoodsAmtTitle);
            this.groupBox1.Controls.Add(this.cbActive);
            this.groupBox1.Controls.Add(this.lblGoodsNameTitle);
            this.groupBox1.Controls.Add(this.cbTaxFree);
            this.groupBox1.Controls.Add(this.lblShopTitle);
            this.groupBox1.Controls.Add(this.cbTicket);
            this.groupBox1.Controls.Add(this.tbGoodsName);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(28, 521);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 166);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::thepos.Properties.Resources.flag_jp1;
            this.pictureBox4.Location = new System.Drawing.Point(10, 129);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 16);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 55;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::thepos.Properties.Resources.flag_ch2;
            this.pictureBox3.Location = new System.Drawing.Point(10, 100);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 15);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 54;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::thepos.Properties.Resources.flag_en1;
            this.pictureBox2.Location = new System.Drawing.Point(10, 71);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 53;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::thepos.Properties.Resources.flag_kr;
            this.pictureBox1.Location = new System.Drawing.Point(10, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            // 
            // tbGoodsNameJP
            // 
            this.tbGoodsNameJP.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbGoodsNameJP.ForeColor = System.Drawing.Color.Black;
            this.tbGoodsNameJP.Location = new System.Drawing.Point(39, 125);
            this.tbGoodsNameJP.MaxLength = 30;
            this.tbGoodsNameJP.Name = "tbGoodsNameJP";
            this.tbGoodsNameJP.Size = new System.Drawing.Size(117, 23);
            this.tbGoodsNameJP.TabIndex = 4;
            // 
            // tbGoodsNameCH
            // 
            this.tbGoodsNameCH.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbGoodsNameCH.ForeColor = System.Drawing.Color.Black;
            this.tbGoodsNameCH.Location = new System.Drawing.Point(39, 96);
            this.tbGoodsNameCH.MaxLength = 30;
            this.tbGoodsNameCH.Name = "tbGoodsNameCH";
            this.tbGoodsNameCH.Size = new System.Drawing.Size(117, 23);
            this.tbGoodsNameCH.TabIndex = 3;
            // 
            // tbGoodsNameEN
            // 
            this.tbGoodsNameEN.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbGoodsNameEN.ForeColor = System.Drawing.Color.Black;
            this.tbGoodsNameEN.Location = new System.Drawing.Point(39, 67);
            this.tbGoodsNameEN.MaxLength = 30;
            this.tbGoodsNameEN.Name = "tbGoodsNameEN";
            this.tbGoodsNameEN.Size = new System.Drawing.Size(117, 23);
            this.tbGoodsNameEN.TabIndex = 2;
            // 
            // cbSoldout
            // 
            this.cbSoldout.AutoSize = true;
            this.cbSoldout.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbSoldout.Location = new System.Drawing.Point(375, 28);
            this.cbSoldout.Name = "cbSoldout";
            this.cbSoldout.Size = new System.Drawing.Size(54, 18);
            this.cbSoldout.TabIndex = 10;
            this.cbSoldout.Text = "품절";
            this.cbSoldout.UseVisualStyleBackColor = true;
            // 
            // btnX
            // 
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnX.ForeColor = System.Drawing.Color.DimGray;
            this.btnX.Location = new System.Drawing.Point(582, 128);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(33, 30);
            this.btnX.TabIndex = 12;
            this.btnX.TabStop = false;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = true;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // pbImage
            // 
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(456, 38);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(120, 120);
            this.pbImage.TabIndex = 48;
            this.pbImage.TabStop = false;
            this.pbImage.Click += new System.EventHandler(this.pbImage_Click);
            // 
            // cbShop
            // 
            this.cbShop.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbShop.FormattingEnabled = true;
            this.cbShop.Location = new System.Drawing.Point(222, 96);
            this.cbShop.Name = "cbShop";
            this.cbShop.Size = new System.Drawing.Size(117, 21);
            this.cbShop.TabIndex = 6;
            // 
            // tbMemo
            // 
            this.tbMemo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbMemo.ForeColor = System.Drawing.Color.Black;
            this.tbMemo.Location = new System.Drawing.Point(222, 125);
            this.tbMemo.MaxLength = 16;
            this.tbMemo.Name = "tbMemo";
            this.tbMemo.Size = new System.Drawing.Size(169, 23);
            this.tbMemo.TabIndex = 11;
            // 
            // lblImageTitle
            // 
            this.lblImageTitle.AutoSize = true;
            this.lblImageTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblImageTitle.ForeColor = System.Drawing.Color.Black;
            this.lblImageTitle.Location = new System.Drawing.Point(455, 22);
            this.lblImageTitle.Name = "lblImageTitle";
            this.lblImageTitle.Size = new System.Drawing.Size(41, 12);
            this.lblImageTitle.TabIndex = 44;
            this.lblImageTitle.Text = "이미지";
            // 
            // lblMemoTitle
            // 
            this.lblMemoTitle.AutoSize = true;
            this.lblMemoTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMemoTitle.ForeColor = System.Drawing.Color.Black;
            this.lblMemoTitle.Location = new System.Drawing.Point(187, 132);
            this.lblMemoTitle.Name = "lblMemoTitle";
            this.lblMemoTitle.Size = new System.Drawing.Size(29, 12);
            this.lblMemoTitle.TabIndex = 44;
            this.lblMemoTitle.Text = "비고";
            // 
            // lblShopTitle
            // 
            this.lblShopTitle.AutoSize = true;
            this.lblShopTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblShopTitle.ForeColor = System.Drawing.Color.Black;
            this.lblShopTitle.Location = new System.Drawing.Point(187, 102);
            this.lblShopTitle.Name = "lblShopTitle";
            this.lblShopTitle.Size = new System.Drawing.Size(17, 12);
            this.lblShopTitle.TabIndex = 44;
            this.lblShopTitle.Text = "샵";
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Location = new System.Drawing.Point(702, 649);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(140, 30);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "이미지 파일 (*.png, *.jpg, *.gif, *.bmp) | *.png; *.jpg; *.gif; *.bmp; | 모든 파일 (*.*) |" +
    " *.*";
            this.openFileDialog.Title = "상품 이미지 파일";
            // 
            // goodsname
            // 
            this.goodsname.Text = "상품명(국문)";
            this.goodsname.Width = 120;
            // 
            // amt
            // 
            this.amt.Text = "단가";
            this.amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // shopcode
            // 
            this.shopcode.Text = "";
            this.shopcode.Width = 0;
            // 
            // shopname
            // 
            this.shopname.Text = "업장";
            // 
            // ticket
            // 
            this.ticket.Text = "티켓";
            this.ticket.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ticket.Width = 40;
            // 
            // taxfree
            // 
            this.taxfree.Text = "면세";
            this.taxfree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.taxfree.Width = 40;
            // 
            // active
            // 
            this.active.Text = "사용";
            this.active.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.active.Width = 40;
            // 
            // memo
            // 
            this.memo.Text = "비고";
            this.memo.Width = 100;
            // 
            // goodscode
            // 
            this.goodscode.Text = "";
            this.goodscode.Width = 0;
            // 
            // lvwList
            // 
            this.lvwList.BackColor = System.Drawing.SystemColors.Window;
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.goodsname,
            this.goodsnameEN,
            this.goodsnameCH,
            this.goodsnameJP,
            this.goodscode,
            this.amt,
            this.shopcode,
            this.shopname,
            this.ticket,
            this.taxfree,
            this.active,
            this.soldout,
            this.memo});
            this.lvwList.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(28, 58);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(814, 457);
            this.lvwList.SmallImageList = this.imageList;
            this.lvwList.TabIndex = 39;
            this.lvwList.TabStop = false;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            this.lvwList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwList_ColumnClick);
            this.lvwList.SelectedIndexChanged += new System.EventHandler(this.lvwList_SelectedIndexChanged);
            // 
            // goodsnameEN
            // 
            this.goodsnameEN.Text = "(영문)";
            this.goodsnameEN.Width = 90;
            // 
            // goodsnameCH
            // 
            this.goodsnameCH.Text = "(중문)";
            this.goodsnameCH.Width = 90;
            // 
            // goodsnameJP
            // 
            this.goodsnameJP.Text = "(일문)";
            this.goodsnameJP.Width = 90;
            // 
            // soldout
            // 
            this.soldout.Text = "품절";
            this.soldout.Width = 40;
            // 
            // frmSysGoods
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(869, 710);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbGoodsName;
        private System.Windows.Forms.TextBox tbGoodsAmt;
        private System.Windows.Forms.Label lblGoodsNameTitle;
        private System.Windows.Forms.Label lblGoodsAmtTitle;
        private System.Windows.Forms.CheckBox cbTicket;
        private System.Windows.Forms.CheckBox cbTaxFree;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbMemo;
        private System.Windows.Forms.Label lblMemoTitle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbShop;
        private System.Windows.Forms.Label lblShopTitle;
        private System.Windows.Forms.Label lblImageTitle;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.CheckBox cbSoldout;
        private System.Windows.Forms.ColumnHeader goodsname;
        private System.Windows.Forms.ColumnHeader amt;
        private System.Windows.Forms.ColumnHeader shopcode;
        private System.Windows.Forms.ColumnHeader shopname;
        private System.Windows.Forms.ColumnHeader ticket;
        private System.Windows.Forms.ColumnHeader taxfree;
        private System.Windows.Forms.ColumnHeader active;
        private System.Windows.Forms.ColumnHeader memo;
        private System.Windows.Forms.ColumnHeader goodscode;
        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader soldout;
        private System.Windows.Forms.TextBox tbGoodsNameEN;
        private System.Windows.Forms.TextBox tbGoodsNameJP;
        private System.Windows.Forms.TextBox tbGoodsNameCH;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ColumnHeader goodsnameEN;
        private System.Windows.Forms.ColumnHeader goodsnameCH;
        private System.Windows.Forms.ColumnHeader goodsnameJP;
    }
}