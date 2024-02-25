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
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbGoodsName = new System.Windows.Forms.TextBox();
            this.tbGoodsAmt = new System.Windows.Forms.TextBox();
            this.lblGoodsAmtTitle = new System.Windows.Forms.Label();
            this.cbTicket = new System.Windows.Forms.CheckBox();
            this.cbTaxFree = new System.Windows.Forms.CheckBox();
            this.cbCutout = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbBadges = new System.Windows.Forms.ComboBox();
            this.lblBadgesTitle = new System.Windows.Forms.Label();
            this.lblNoticeTitle = new System.Windows.Forms.Label();
            this.tbGoodsNotice = new System.Windows.Forms.TextBox();
            this.cbOptionTemplate = new System.Windows.Forms.ComboBox();
            this.lblOptionTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblJP = new System.Windows.Forms.Label();
            this.lblCH = new System.Windows.Forms.Label();
            this.lblEN = new System.Windows.Forms.Label();
            this.lblKR = new System.Windows.Forms.Label();
            this.tbGoodsNameJP = new System.Windows.Forms.TextBox();
            this.tbGoodsNameCH = new System.Windows.Forms.TextBox();
            this.tbGoodsNameEN = new System.Windows.Forms.TextBox();
            this.cbSoldout = new System.Windows.Forms.CheckBox();
            this.btnX = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.cbShop = new System.Windows.Forms.ComboBox();
            this.tbMemo = new System.Windows.Forms.TextBox();
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
            this.cutout = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goodscode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwList = new System.Windows.Forms.ListView();
            this.goodsnameEN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goodsnameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.goodsnameJP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.notice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.soldout = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.option_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.option_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.badges_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.badges_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(34, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(96, 14);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "기초상품 관리";
            // 
            // tbGoodsName
            // 
            this.tbGoodsName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbGoodsName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbGoodsName.Location = new System.Drawing.Point(58, 19);
            this.tbGoodsName.MaxLength = 30;
            this.tbGoodsName.Name = "tbGoodsName";
            this.tbGoodsName.Size = new System.Drawing.Size(117, 23);
            this.tbGoodsName.TabIndex = 1;
            // 
            // tbGoodsAmt
            // 
            this.tbGoodsAmt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbGoodsAmt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbGoodsAmt.Location = new System.Drawing.Point(306, 21);
            this.tbGoodsAmt.MaxLength = 16;
            this.tbGoodsAmt.Name = "tbGoodsAmt";
            this.tbGoodsAmt.Size = new System.Drawing.Size(117, 23);
            this.tbGoodsAmt.TabIndex = 10;
            // 
            // lblGoodsAmtTitle
            // 
            this.lblGoodsAmtTitle.AutoSize = true;
            this.lblGoodsAmtTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGoodsAmtTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGoodsAmtTitle.Location = new System.Drawing.Point(271, 27);
            this.lblGoodsAmtTitle.Name = "lblGoodsAmtTitle";
            this.lblGoodsAmtTitle.Size = new System.Drawing.Size(29, 12);
            this.lblGoodsAmtTitle.TabIndex = 44;
            this.lblGoodsAmtTitle.Text = "단가";
            // 
            // cbTicket
            // 
            this.cbTicket.AutoSize = true;
            this.cbTicket.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbTicket.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbTicket.Location = new System.Drawing.Point(197, 24);
            this.cbTicket.Name = "cbTicket";
            this.cbTicket.Size = new System.Drawing.Size(54, 18);
            this.cbTicket.TabIndex = 6;
            this.cbTicket.Text = "티켓";
            this.cbTicket.UseVisualStyleBackColor = true;
            // 
            // cbTaxFree
            // 
            this.cbTaxFree.AutoSize = true;
            this.cbTaxFree.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbTaxFree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbTaxFree.Location = new System.Drawing.Point(197, 52);
            this.cbTaxFree.Name = "cbTaxFree";
            this.cbTaxFree.Size = new System.Drawing.Size(54, 18);
            this.cbTaxFree.TabIndex = 7;
            this.cbTaxFree.Text = "면세";
            this.cbTaxFree.UseVisualStyleBackColor = true;
            // 
            // cbCutout
            // 
            this.cbCutout.AutoSize = true;
            this.cbCutout.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbCutout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbCutout.Location = new System.Drawing.Point(197, 80);
            this.cbCutout.Name = "cbCutout";
            this.cbCutout.Size = new System.Drawing.Size(54, 18);
            this.cbCutout.TabIndex = 8;
            this.cbCutout.Text = "중지";
            this.cbCutout.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(721, 557);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(121, 50);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(721, 611);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(121, 35);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbBadges);
            this.groupBox1.Controls.Add(this.lblBadgesTitle);
            this.groupBox1.Controls.Add(this.lblNoticeTitle);
            this.groupBox1.Controls.Add(this.tbGoodsNotice);
            this.groupBox1.Controls.Add(this.cbOptionTemplate);
            this.groupBox1.Controls.Add(this.lblOptionTitle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblJP);
            this.groupBox1.Controls.Add(this.lblCH);
            this.groupBox1.Controls.Add(this.lblEN);
            this.groupBox1.Controls.Add(this.lblKR);
            this.groupBox1.Controls.Add(this.tbGoodsNameJP);
            this.groupBox1.Controls.Add(this.tbGoodsNameCH);
            this.groupBox1.Controls.Add(this.tbGoodsNameEN);
            this.groupBox1.Controls.Add(this.cbSoldout);
            this.groupBox1.Controls.Add(this.btnX);
            this.groupBox1.Controls.Add(this.pbImage);
            this.groupBox1.Controls.Add(this.cbShop);
            this.groupBox1.Controls.Add(this.tbMemo);
            this.groupBox1.Controls.Add(this.lblMemoTitle);
            this.groupBox1.Controls.Add(this.tbGoodsAmt);
            this.groupBox1.Controls.Add(this.lblGoodsAmtTitle);
            this.groupBox1.Controls.Add(this.cbCutout);
            this.groupBox1.Controls.Add(this.cbTaxFree);
            this.groupBox1.Controls.Add(this.lblShopTitle);
            this.groupBox1.Controls.Add(this.cbTicket);
            this.groupBox1.Controls.Add(this.tbGoodsName);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(20, 533);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(681, 158);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // cbBadges
            // 
            this.cbBadges.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbBadges.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbBadges.FormattingEnabled = true;
            this.cbBadges.Items.AddRange(new object[] {
            "",
            "NEW",
            "BEST",
            "사장픽"});
            this.cbBadges.Location = new System.Drawing.Point(306, 100);
            this.cbBadges.Name = "cbBadges";
            this.cbBadges.Size = new System.Drawing.Size(145, 21);
            this.cbBadges.TabIndex = 13;
            // 
            // lblBadgesTitle
            // 
            this.lblBadgesTitle.AutoSize = true;
            this.lblBadgesTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBadgesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBadgesTitle.Location = new System.Drawing.Point(271, 106);
            this.lblBadgesTitle.Name = "lblBadgesTitle";
            this.lblBadgesTitle.Size = new System.Drawing.Size(29, 12);
            this.lblBadgesTitle.TabIndex = 66;
            this.lblBadgesTitle.Text = "배지";
            // 
            // lblNoticeTitle
            // 
            this.lblNoticeTitle.AutoSize = true;
            this.lblNoticeTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNoticeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNoticeTitle.Location = new System.Drawing.Point(13, 133);
            this.lblNoticeTitle.Name = "lblNoticeTitle";
            this.lblNoticeTitle.Size = new System.Drawing.Size(41, 12);
            this.lblNoticeTitle.TabIndex = 64;
            this.lblNoticeTitle.Text = "노티스";
            // 
            // tbGoodsNotice
            // 
            this.tbGoodsNotice.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbGoodsNotice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbGoodsNotice.Location = new System.Drawing.Point(58, 127);
            this.tbGoodsNotice.MaxLength = 30;
            this.tbGoodsNotice.Name = "tbGoodsNotice";
            this.tbGoodsNotice.Size = new System.Drawing.Size(117, 23);
            this.tbGoodsNotice.TabIndex = 5;
            // 
            // cbOptionTemplate
            // 
            this.cbOptionTemplate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbOptionTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbOptionTemplate.FormattingEnabled = true;
            this.cbOptionTemplate.Location = new System.Drawing.Point(306, 74);
            this.cbOptionTemplate.Name = "cbOptionTemplate";
            this.cbOptionTemplate.Size = new System.Drawing.Size(145, 21);
            this.cbOptionTemplate.TabIndex = 12;
            // 
            // lblOptionTitle
            // 
            this.lblOptionTitle.AutoSize = true;
            this.lblOptionTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOptionTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblOptionTitle.Location = new System.Drawing.Point(271, 80);
            this.lblOptionTitle.Name = "lblOptionTitle";
            this.lblOptionTitle.Size = new System.Drawing.Size(29, 12);
            this.lblOptionTitle.TabIndex = 62;
            this.lblOptionTitle.Text = "옵션";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(608, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 12);
            this.label2.TabIndex = 60;
            this.label2.Text = "jpg";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(605, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 60;
            this.label1.Text = "240 × 240";
            // 
            // lblJP
            // 
            this.lblJP.AutoSize = true;
            this.lblJP.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblJP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblJP.Location = new System.Drawing.Point(16, 105);
            this.lblJP.Name = "lblJP";
            this.lblJP.Size = new System.Drawing.Size(39, 12);
            this.lblJP.TabIndex = 59;
            this.lblJP.Text = "(일문)";
            // 
            // lblCH
            // 
            this.lblCH.AutoSize = true;
            this.lblCH.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCH.Location = new System.Drawing.Point(16, 79);
            this.lblCH.Name = "lblCH";
            this.lblCH.Size = new System.Drawing.Size(39, 12);
            this.lblCH.TabIndex = 58;
            this.lblCH.Text = "(중문)";
            // 
            // lblEN
            // 
            this.lblEN.AutoSize = true;
            this.lblEN.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEN.Location = new System.Drawing.Point(16, 52);
            this.lblEN.Name = "lblEN";
            this.lblEN.Size = new System.Drawing.Size(39, 12);
            this.lblEN.TabIndex = 57;
            this.lblEN.Text = "(영문)";
            // 
            // lblKR
            // 
            this.lblKR.AutoSize = true;
            this.lblKR.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblKR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblKR.Location = new System.Drawing.Point(14, 25);
            this.lblKR.Name = "lblKR";
            this.lblKR.Size = new System.Drawing.Size(41, 12);
            this.lblKR.TabIndex = 56;
            this.lblKR.Text = "상품명";
            // 
            // tbGoodsNameJP
            // 
            this.tbGoodsNameJP.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbGoodsNameJP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbGoodsNameJP.Location = new System.Drawing.Point(58, 100);
            this.tbGoodsNameJP.MaxLength = 30;
            this.tbGoodsNameJP.Name = "tbGoodsNameJP";
            this.tbGoodsNameJP.Size = new System.Drawing.Size(117, 23);
            this.tbGoodsNameJP.TabIndex = 4;
            // 
            // tbGoodsNameCH
            // 
            this.tbGoodsNameCH.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbGoodsNameCH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbGoodsNameCH.Location = new System.Drawing.Point(58, 73);
            this.tbGoodsNameCH.MaxLength = 30;
            this.tbGoodsNameCH.Name = "tbGoodsNameCH";
            this.tbGoodsNameCH.Size = new System.Drawing.Size(117, 23);
            this.tbGoodsNameCH.TabIndex = 3;
            // 
            // tbGoodsNameEN
            // 
            this.tbGoodsNameEN.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbGoodsNameEN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbGoodsNameEN.Location = new System.Drawing.Point(58, 46);
            this.tbGoodsNameEN.MaxLength = 30;
            this.tbGoodsNameEN.Name = "tbGoodsNameEN";
            this.tbGoodsNameEN.Size = new System.Drawing.Size(117, 23);
            this.tbGoodsNameEN.TabIndex = 2;
            // 
            // cbSoldout
            // 
            this.cbSoldout.AutoSize = true;
            this.cbSoldout.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbSoldout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbSoldout.Location = new System.Drawing.Point(197, 106);
            this.cbSoldout.Name = "cbSoldout";
            this.cbSoldout.Size = new System.Drawing.Size(54, 18);
            this.cbSoldout.TabIndex = 9;
            this.cbSoldout.Text = "품절";
            this.cbSoldout.UseVisualStyleBackColor = true;
            // 
            // btnX
            // 
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnX.ForeColor = System.Drawing.Color.DimGray;
            this.btnX.Location = new System.Drawing.Point(608, 83);
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
            this.pbImage.Location = new System.Drawing.Point(482, 30);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(120, 120);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 48;
            this.pbImage.TabStop = false;
            this.pbImage.Click += new System.EventHandler(this.pbImage_Click);
            // 
            // cbShop
            // 
            this.cbShop.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbShop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbShop.FormattingEnabled = true;
            this.cbShop.Location = new System.Drawing.Point(306, 48);
            this.cbShop.Name = "cbShop";
            this.cbShop.Size = new System.Drawing.Size(117, 21);
            this.cbShop.TabIndex = 11;
            // 
            // tbMemo
            // 
            this.tbMemo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbMemo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbMemo.Location = new System.Drawing.Point(306, 127);
            this.tbMemo.MaxLength = 16;
            this.tbMemo.Name = "tbMemo";
            this.tbMemo.Size = new System.Drawing.Size(145, 23);
            this.tbMemo.TabIndex = 14;
            // 
            // lblMemoTitle
            // 
            this.lblMemoTitle.AutoSize = true;
            this.lblMemoTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMemoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMemoTitle.Location = new System.Drawing.Point(271, 134);
            this.lblMemoTitle.Name = "lblMemoTitle";
            this.lblMemoTitle.Size = new System.Drawing.Size(29, 12);
            this.lblMemoTitle.TabIndex = 44;
            this.lblMemoTitle.Text = "비고";
            // 
            // lblShopTitle
            // 
            this.lblShopTitle.AutoSize = true;
            this.lblShopTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblShopTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblShopTitle.Location = new System.Drawing.Point(271, 56);
            this.lblShopTitle.Name = "lblShopTitle";
            this.lblShopTitle.Size = new System.Drawing.Size(17, 12);
            this.lblShopTitle.TabIndex = 44;
            this.lblShopTitle.Text = "샵";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(721, 650);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(121, 35);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
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
            this.goodsname.Text = "상품명";
            this.goodsname.Width = 140;
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
            this.shopname.Width = 70;
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
            // cutout
            // 
            this.cutout.Text = "절판";
            this.cutout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cutout.Width = 40;
            // 
            // memo
            // 
            this.memo.Text = "비고";
            this.memo.Width = 70;
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
            this.notice,
            this.goodscode,
            this.amt,
            this.shopcode,
            this.shopname,
            this.ticket,
            this.taxfree,
            this.cutout,
            this.soldout,
            this.option_id,
            this.option_name,
            this.badges_id,
            this.badges_name,
            this.memo});
            this.lvwList.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(20, 58);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(828, 471);
            this.lvwList.SmallImageList = this.imageList1;
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
            this.goodsnameEN.Width = 0;
            // 
            // goodsnameCH
            // 
            this.goodsnameCH.Text = "(중문)";
            this.goodsnameCH.Width = 0;
            // 
            // goodsnameJP
            // 
            this.goodsnameJP.Text = "(일문)";
            this.goodsnameJP.Width = 0;
            // 
            // notice
            // 
            this.notice.Text = "노티스";
            this.notice.Width = 120;
            // 
            // soldout
            // 
            this.soldout.Text = "품절";
            this.soldout.Width = 40;
            // 
            // option_id
            // 
            this.option_id.Text = "";
            this.option_id.Width = 0;
            // 
            // option_name
            // 
            this.option_name.Text = "옵션";
            this.option_name.Width = 120;
            // 
            // badges_id
            // 
            this.badges_id.Text = "";
            this.badges_id.Width = 0;
            // 
            // badges_name
            // 
            this.badges_name.Text = "배지";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "image_add_32x32.png");
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
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbGoodsName;
        private System.Windows.Forms.TextBox tbGoodsAmt;
        private System.Windows.Forms.Label lblGoodsAmtTitle;
        private System.Windows.Forms.CheckBox cbTicket;
        private System.Windows.Forms.CheckBox cbTaxFree;
        private System.Windows.Forms.CheckBox cbCutout;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbMemo;
        private System.Windows.Forms.Label lblMemoTitle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbShop;
        private System.Windows.Forms.Label lblShopTitle;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.CheckBox cbSoldout;
        private System.Windows.Forms.ColumnHeader goodsname;
        private System.Windows.Forms.ColumnHeader amt;
        private System.Windows.Forms.ColumnHeader shopcode;
        private System.Windows.Forms.ColumnHeader shopname;
        private System.Windows.Forms.ColumnHeader ticket;
        private System.Windows.Forms.ColumnHeader taxfree;
        private System.Windows.Forms.ColumnHeader cutout;
        private System.Windows.Forms.ColumnHeader memo;
        private System.Windows.Forms.ColumnHeader goodscode;
        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader soldout;
        private System.Windows.Forms.TextBox tbGoodsNameEN;
        private System.Windows.Forms.TextBox tbGoodsNameJP;
        private System.Windows.Forms.TextBox tbGoodsNameCH;
        private System.Windows.Forms.ColumnHeader goodsnameEN;
        private System.Windows.Forms.ColumnHeader goodsnameCH;
        private System.Windows.Forms.ColumnHeader goodsnameJP;
        private System.Windows.Forms.Label lblJP;
        private System.Windows.Forms.Label lblCH;
        private System.Windows.Forms.Label lblEN;
        private System.Windows.Forms.Label lblKR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbOptionTemplate;
        private System.Windows.Forms.Label lblOptionTitle;
        private System.Windows.Forms.ColumnHeader option_name;
        private System.Windows.Forms.ColumnHeader option_id;
        private System.Windows.Forms.Label lblNoticeTitle;
        private System.Windows.Forms.TextBox tbGoodsNotice;
        private System.Windows.Forms.ComboBox cbBadges;
        private System.Windows.Forms.Label lblBadgesTitle;
        private System.Windows.Forms.ColumnHeader badges_id;
        private System.Windows.Forms.ColumnHeader badges_name;
        private System.Windows.Forms.ColumnHeader notice;
    }
}