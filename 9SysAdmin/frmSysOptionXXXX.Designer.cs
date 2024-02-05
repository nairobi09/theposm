namespace thepos
{
    partial class frmSysOptionXXXX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysOptionXXXX));
            this.goodsname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.shopname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwGoods = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblJP = new System.Windows.Forms.Label();
            this.lblCH = new System.Windows.Forms.Label();
            this.lblEN = new System.Windows.Forms.Label();
            this.lblKR = new System.Windows.Forms.Label();
            this.tbOptionNameJP = new System.Windows.Forms.TextBox();
            this.tbOptionNameCH = new System.Windows.Forms.TextBox();
            this.tbOptionNameEN = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOptionUp = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnOptionDn = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbOptionName = new System.Windows.Forms.TextBox();
            this.lvwOption = new System.Windows.Forms.ListView();
            this.option_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.option_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.option_name_en = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.option_name_ch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.option_name_jp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwOptionItem = new System.Windows.Forms.ListView();
            this.option_item_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.option_item_name_kr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.option_item_name_en = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.option_item_name_ch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.option_item_name_jp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.option_item_amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbOptionItemAmt = new System.Windows.Forms.TextBox();
            this.lblJP2 = new System.Windows.Forms.Label();
            this.btnOptionItemUp = new System.Windows.Forms.Button();
            this.btnAdd2 = new System.Windows.Forms.Button();
            this.btnOptionItemDn = new System.Windows.Forms.Button();
            this.btnUpdate2 = new System.Windows.Forms.Button();
            this.lblCH2 = new System.Windows.Forms.Label();
            this.btnDelete2 = new System.Windows.Forms.Button();
            this.lblAmtTitle = new System.Windows.Forms.Label();
            this.lblEN2 = new System.Windows.Forms.Label();
            this.lblKR2 = new System.Windows.Forms.Label();
            this.tbOptionItemNameJP = new System.Windows.Forms.TextBox();
            this.tbOptionItemNameCH = new System.Windows.Forms.TextBox();
            this.tbOptionItemNameEN = new System.Windows.Forms.TextBox();
            this.tbOptionItemName = new System.Windows.Forms.TextBox();
            this.btnOptionCopy = new System.Windows.Forms.Button();
            this.cbSourceGoods = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // goodsname
            // 
            this.goodsname.Text = "상품명";
            this.goodsname.Width = 120;
            // 
            // amt
            // 
            this.amt.Text = "단가";
            this.amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // shopname
            // 
            this.shopname.Text = "업장";
            // 
            // lvwGoods
            // 
            this.lvwGoods.BackColor = System.Drawing.SystemColors.Window;
            this.lvwGoods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.goodsname,
            this.amt,
            this.shopname});
            this.lvwGoods.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwGoods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwGoods.FullRowSelect = true;
            this.lvwGoods.GridLines = true;
            this.lvwGoods.HideSelection = false;
            this.lvwGoods.Location = new System.Drawing.Point(19, 58);
            this.lvwGoods.MultiSelect = false;
            this.lvwGoods.Name = "lvwGoods";
            this.lvwGoods.Size = new System.Drawing.Size(276, 621);
            this.lvwGoods.SmallImageList = this.imageList1;
            this.lvwGoods.TabIndex = 0;
            this.lvwGoods.UseCompatibleStateImageBehavior = false;
            this.lvwGoods.View = System.Windows.Forms.View.Details;
            this.lvwGoods.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwGoods_ColumnClick);
            this.lvwGoods.SelectedIndexChanged += new System.EventHandler(this.lvwGoods_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "option.png");
            // 
            // lblJP
            // 
            this.lblJP.AutoSize = true;
            this.lblJP.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblJP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblJP.Location = new System.Drawing.Point(7, 105);
            this.lblJP.Name = "lblJP";
            this.lblJP.Size = new System.Drawing.Size(29, 12);
            this.lblJP.TabIndex = 59;
            this.lblJP.Text = "일문";
            // 
            // lblCH
            // 
            this.lblCH.AutoSize = true;
            this.lblCH.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCH.Location = new System.Drawing.Point(7, 79);
            this.lblCH.Name = "lblCH";
            this.lblCH.Size = new System.Drawing.Size(29, 12);
            this.lblCH.TabIndex = 58;
            this.lblCH.Text = "중문";
            // 
            // lblEN
            // 
            this.lblEN.AutoSize = true;
            this.lblEN.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEN.Location = new System.Drawing.Point(7, 52);
            this.lblEN.Name = "lblEN";
            this.lblEN.Size = new System.Drawing.Size(29, 12);
            this.lblEN.TabIndex = 57;
            this.lblEN.Text = "영문";
            // 
            // lblKR
            // 
            this.lblKR.AutoSize = true;
            this.lblKR.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblKR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblKR.Location = new System.Drawing.Point(7, 25);
            this.lblKR.Name = "lblKR";
            this.lblKR.Size = new System.Drawing.Size(29, 12);
            this.lblKR.TabIndex = 56;
            this.lblKR.Text = "국문";
            // 
            // tbOptionNameJP
            // 
            this.tbOptionNameJP.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbOptionNameJP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbOptionNameJP.Location = new System.Drawing.Point(39, 100);
            this.tbOptionNameJP.MaxLength = 30;
            this.tbOptionNameJP.Name = "tbOptionNameJP";
            this.tbOptionNameJP.Size = new System.Drawing.Size(117, 23);
            this.tbOptionNameJP.TabIndex = 4;
            // 
            // tbOptionNameCH
            // 
            this.tbOptionNameCH.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbOptionNameCH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbOptionNameCH.Location = new System.Drawing.Point(39, 73);
            this.tbOptionNameCH.MaxLength = 30;
            this.tbOptionNameCH.Name = "tbOptionNameCH";
            this.tbOptionNameCH.Size = new System.Drawing.Size(117, 23);
            this.tbOptionNameCH.TabIndex = 3;
            // 
            // tbOptionNameEN
            // 
            this.tbOptionNameEN.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbOptionNameEN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbOptionNameEN.Location = new System.Drawing.Point(39, 46);
            this.tbOptionNameEN.MaxLength = 30;
            this.tbOptionNameEN.Name = "tbOptionNameEN";
            this.tbOptionNameEN.Size = new System.Drawing.Size(117, 23);
            this.tbOptionNameEN.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(34, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(96, 14);
            this.lblTitle.TabIndex = 52;
            this.lblTitle.Text = "상품옵션 관리";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblJP);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnOptionUp);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnOptionDn);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.lblCH);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.lblEN);
            this.groupBox1.Controls.Add(this.lblKR);
            this.groupBox1.Controls.Add(this.tbOptionNameJP);
            this.groupBox1.Controls.Add(this.tbOptionNameCH);
            this.groupBox1.Controls.Add(this.tbOptionNameEN);
            this.groupBox1.Controls.Add(this.tbOptionName);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(305, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 134);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(422, 60);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 63);
            this.btnSave.TabIndex = 62;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOptionUp
            // 
            this.btnOptionUp.BackColor = System.Drawing.Color.White;
            this.btnOptionUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptionUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOptionUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOptionUp.Location = new System.Drawing.Point(248, 40);
            this.btnOptionUp.Name = "btnOptionUp";
            this.btnOptionUp.Size = new System.Drawing.Size(40, 40);
            this.btnOptionUp.TabIndex = 57;
            this.btnOptionUp.TabStop = false;
            this.btnOptionUp.Text = "▲";
            this.btnOptionUp.UseVisualStyleBackColor = false;
            this.btnOptionUp.Click += new System.EventHandler(this.btnOptionUp_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAdd.Location = new System.Drawing.Point(294, 26);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 59;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnOptionDn
            // 
            this.btnOptionDn.BackColor = System.Drawing.Color.White;
            this.btnOptionDn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptionDn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOptionDn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOptionDn.Location = new System.Drawing.Point(248, 83);
            this.btnOptionDn.Name = "btnOptionDn";
            this.btnOptionDn.Size = new System.Drawing.Size(40, 40);
            this.btnOptionDn.TabIndex = 56;
            this.btnOptionDn.TabStop = false;
            this.btnOptionDn.Text = "▼";
            this.btnOptionDn.UseVisualStyleBackColor = false;
            this.btnOptionDn.Click += new System.EventHandler(this.btnOptionDn_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUpdate.Location = new System.Drawing.Point(294, 60);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 58;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDelete.Location = new System.Drawing.Point(294, 93);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 60;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tbOptionName
            // 
            this.tbOptionName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbOptionName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbOptionName.Location = new System.Drawing.Point(39, 19);
            this.tbOptionName.MaxLength = 30;
            this.tbOptionName.Name = "tbOptionName";
            this.tbOptionName.Size = new System.Drawing.Size(117, 23);
            this.tbOptionName.TabIndex = 1;
            // 
            // lvwOption
            // 
            this.lvwOption.BackColor = System.Drawing.SystemColors.Window;
            this.lvwOption.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.option_no,
            this.option_name,
            this.option_name_en,
            this.option_name_ch,
            this.option_name_jp});
            this.lvwOption.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwOption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwOption.FullRowSelect = true;
            this.lvwOption.GridLines = true;
            this.lvwOption.HideSelection = false;
            this.lvwOption.Location = new System.Drawing.Point(305, 58);
            this.lvwOption.MultiSelect = false;
            this.lvwOption.Name = "lvwOption";
            this.lvwOption.Size = new System.Drawing.Size(424, 140);
            this.lvwOption.TabIndex = 54;
            this.lvwOption.TabStop = false;
            this.lvwOption.UseCompatibleStateImageBehavior = false;
            this.lvwOption.View = System.Windows.Forms.View.Details;
            this.lvwOption.SelectedIndexChanged += new System.EventHandler(this.lvwOption_SelectedIndexChanged);
            // 
            // option_no
            // 
            this.option_no.Text = "#";
            this.option_no.Width = 30;
            // 
            // option_name
            // 
            this.option_name.Text = "옵션(국문)";
            this.option_name.Width = 100;
            // 
            // option_name_en
            // 
            this.option_name_en.Text = "(영문)";
            this.option_name_en.Width = 90;
            // 
            // option_name_ch
            // 
            this.option_name_ch.Text = "(중문)";
            this.option_name_ch.Width = 90;
            // 
            // option_name_jp
            // 
            this.option_name_jp.Text = "(일문)";
            this.option_name_jp.Width = 90;
            // 
            // lvwOptionItem
            // 
            this.lvwOptionItem.BackColor = System.Drawing.SystemColors.Window;
            this.lvwOptionItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.option_item_no,
            this.option_item_name_kr,
            this.option_item_name_en,
            this.option_item_name_ch,
            this.option_item_name_jp,
            this.option_item_amt});
            this.lvwOptionItem.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwOptionItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwOptionItem.FullRowSelect = true;
            this.lvwOptionItem.GridLines = true;
            this.lvwOptionItem.HideSelection = false;
            this.lvwOptionItem.Location = new System.Drawing.Point(305, 406);
            this.lvwOptionItem.MultiSelect = false;
            this.lvwOptionItem.Name = "lvwOptionItem";
            this.lvwOptionItem.Size = new System.Drawing.Size(537, 140);
            this.lvwOptionItem.TabIndex = 55;
            this.lvwOptionItem.TabStop = false;
            this.lvwOptionItem.UseCompatibleStateImageBehavior = false;
            this.lvwOptionItem.View = System.Windows.Forms.View.Details;
            this.lvwOptionItem.SelectedIndexChanged += new System.EventHandler(this.lvwOptionItem_SelectedIndexChanged);
            // 
            // option_item_no
            // 
            this.option_item_no.Text = "#";
            this.option_item_no.Width = 30;
            // 
            // option_item_name_kr
            // 
            this.option_item_name_kr.Text = "옵션항목(국문)";
            this.option_item_name_kr.Width = 120;
            // 
            // option_item_name_en
            // 
            this.option_item_name_en.Text = "(영문)";
            this.option_item_name_en.Width = 90;
            // 
            // option_item_name_ch
            // 
            this.option_item_name_ch.Text = "(중문)";
            this.option_item_name_ch.Width = 90;
            // 
            // option_item_name_jp
            // 
            this.option_item_name_jp.Text = "(일문)";
            this.option_item_name_jp.Width = 90;
            // 
            // option_item_amt
            // 
            this.option_item_amt.Text = "단가";
            this.option_item_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSave2
            // 
            this.btnSave2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave2.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave2.ForeColor = System.Drawing.Color.White;
            this.btnSave2.Location = new System.Drawing.Point(420, 62);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(100, 62);
            this.btnSave2.TabIndex = 64;
            this.btnSave2.TabStop = false;
            this.btnSave2.Text = "저장";
            this.btnSave2.UseVisualStyleBackColor = false;
            this.btnSave2.Click += new System.EventHandler(this.btnSave2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbOptionItemAmt);
            this.groupBox2.Controls.Add(this.btnSave2);
            this.groupBox2.Controls.Add(this.lblJP2);
            this.groupBox2.Controls.Add(this.btnOptionItemUp);
            this.groupBox2.Controls.Add(this.btnAdd2);
            this.groupBox2.Controls.Add(this.btnOptionItemDn);
            this.groupBox2.Controls.Add(this.btnUpdate2);
            this.groupBox2.Controls.Add(this.lblCH2);
            this.groupBox2.Controls.Add(this.btnDelete2);
            this.groupBox2.Controls.Add(this.lblAmtTitle);
            this.groupBox2.Controls.Add(this.lblEN2);
            this.groupBox2.Controls.Add(this.lblKR2);
            this.groupBox2.Controls.Add(this.tbOptionItemNameJP);
            this.groupBox2.Controls.Add(this.tbOptionItemNameCH);
            this.groupBox2.Controls.Add(this.tbOptionItemNameEN);
            this.groupBox2.Controls.Add(this.tbOptionItemName);
            this.groupBox2.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(307, 546);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(535, 133);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            // 
            // tbOptionItemAmt
            // 
            this.tbOptionItemAmt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbOptionItemAmt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbOptionItemAmt.Location = new System.Drawing.Point(162, 100);
            this.tbOptionItemAmt.MaxLength = 30;
            this.tbOptionItemAmt.Name = "tbOptionItemAmt";
            this.tbOptionItemAmt.Size = new System.Drawing.Size(78, 23);
            this.tbOptionItemAmt.TabIndex = 61;
            this.tbOptionItemAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblJP2
            // 
            this.lblJP2.AutoSize = true;
            this.lblJP2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblJP2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblJP2.Location = new System.Drawing.Point(7, 105);
            this.lblJP2.Name = "lblJP2";
            this.lblJP2.Size = new System.Drawing.Size(29, 12);
            this.lblJP2.TabIndex = 59;
            this.lblJP2.Text = "일문";
            // 
            // btnOptionItemUp
            // 
            this.btnOptionItemUp.BackColor = System.Drawing.Color.White;
            this.btnOptionItemUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptionItemUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOptionItemUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOptionItemUp.Location = new System.Drawing.Point(246, 40);
            this.btnOptionItemUp.Name = "btnOptionItemUp";
            this.btnOptionItemUp.Size = new System.Drawing.Size(40, 40);
            this.btnOptionItemUp.TabIndex = 57;
            this.btnOptionItemUp.TabStop = false;
            this.btnOptionItemUp.Text = "▲";
            this.btnOptionItemUp.UseVisualStyleBackColor = false;
            this.btnOptionItemUp.Click += new System.EventHandler(this.btnOptionItemUp_Click);
            // 
            // btnAdd2
            // 
            this.btnAdd2.BackColor = System.Drawing.Color.White;
            this.btnAdd2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd2.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAdd2.Location = new System.Drawing.Point(292, 26);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(100, 30);
            this.btnAdd2.TabIndex = 59;
            this.btnAdd2.TabStop = false;
            this.btnAdd2.Text = "추가";
            this.btnAdd2.UseVisualStyleBackColor = false;
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd2_Click);
            // 
            // btnOptionItemDn
            // 
            this.btnOptionItemDn.BackColor = System.Drawing.Color.White;
            this.btnOptionItemDn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptionItemDn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOptionItemDn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOptionItemDn.Location = new System.Drawing.Point(246, 83);
            this.btnOptionItemDn.Name = "btnOptionItemDn";
            this.btnOptionItemDn.Size = new System.Drawing.Size(40, 40);
            this.btnOptionItemDn.TabIndex = 56;
            this.btnOptionItemDn.TabStop = false;
            this.btnOptionItemDn.Text = "▼";
            this.btnOptionItemDn.UseVisualStyleBackColor = false;
            this.btnOptionItemDn.Click += new System.EventHandler(this.btnOptionItemDn_Click);
            // 
            // btnUpdate2
            // 
            this.btnUpdate2.BackColor = System.Drawing.Color.White;
            this.btnUpdate2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate2.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUpdate2.Location = new System.Drawing.Point(292, 60);
            this.btnUpdate2.Name = "btnUpdate2";
            this.btnUpdate2.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate2.TabIndex = 58;
            this.btnUpdate2.TabStop = false;
            this.btnUpdate2.Text = "수정";
            this.btnUpdate2.UseVisualStyleBackColor = false;
            this.btnUpdate2.Click += new System.EventHandler(this.btnUpdate2_Click);
            // 
            // lblCH2
            // 
            this.lblCH2.AutoSize = true;
            this.lblCH2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCH2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCH2.Location = new System.Drawing.Point(7, 79);
            this.lblCH2.Name = "lblCH2";
            this.lblCH2.Size = new System.Drawing.Size(29, 12);
            this.lblCH2.TabIndex = 58;
            this.lblCH2.Text = "중문";
            // 
            // btnDelete2
            // 
            this.btnDelete2.BackColor = System.Drawing.Color.White;
            this.btnDelete2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete2.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDelete2.Location = new System.Drawing.Point(292, 94);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(100, 30);
            this.btnDelete2.TabIndex = 60;
            this.btnDelete2.TabStop = false;
            this.btnDelete2.Text = "삭제";
            this.btnDelete2.UseVisualStyleBackColor = false;
            this.btnDelete2.Click += new System.EventHandler(this.btnDelete2_Click);
            // 
            // lblAmtTitle
            // 
            this.lblAmtTitle.AutoSize = true;
            this.lblAmtTitle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAmtTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAmtTitle.Location = new System.Drawing.Point(162, 83);
            this.lblAmtTitle.Name = "lblAmtTitle";
            this.lblAmtTitle.Size = new System.Drawing.Size(29, 12);
            this.lblAmtTitle.TabIndex = 57;
            this.lblAmtTitle.Text = "단가";
            // 
            // lblEN2
            // 
            this.lblEN2.AutoSize = true;
            this.lblEN2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEN2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEN2.Location = new System.Drawing.Point(7, 52);
            this.lblEN2.Name = "lblEN2";
            this.lblEN2.Size = new System.Drawing.Size(29, 12);
            this.lblEN2.TabIndex = 57;
            this.lblEN2.Text = "영문";
            // 
            // lblKR2
            // 
            this.lblKR2.AutoSize = true;
            this.lblKR2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblKR2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblKR2.Location = new System.Drawing.Point(7, 25);
            this.lblKR2.Name = "lblKR2";
            this.lblKR2.Size = new System.Drawing.Size(29, 12);
            this.lblKR2.TabIndex = 56;
            this.lblKR2.Text = "국문";
            // 
            // tbOptionItemNameJP
            // 
            this.tbOptionItemNameJP.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbOptionItemNameJP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbOptionItemNameJP.Location = new System.Drawing.Point(39, 100);
            this.tbOptionItemNameJP.MaxLength = 30;
            this.tbOptionItemNameJP.Name = "tbOptionItemNameJP";
            this.tbOptionItemNameJP.Size = new System.Drawing.Size(117, 23);
            this.tbOptionItemNameJP.TabIndex = 4;
            // 
            // tbOptionItemNameCH
            // 
            this.tbOptionItemNameCH.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbOptionItemNameCH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbOptionItemNameCH.Location = new System.Drawing.Point(39, 73);
            this.tbOptionItemNameCH.MaxLength = 30;
            this.tbOptionItemNameCH.Name = "tbOptionItemNameCH";
            this.tbOptionItemNameCH.Size = new System.Drawing.Size(117, 23);
            this.tbOptionItemNameCH.TabIndex = 3;
            // 
            // tbOptionItemNameEN
            // 
            this.tbOptionItemNameEN.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbOptionItemNameEN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbOptionItemNameEN.Location = new System.Drawing.Point(39, 46);
            this.tbOptionItemNameEN.MaxLength = 30;
            this.tbOptionItemNameEN.Name = "tbOptionItemNameEN";
            this.tbOptionItemNameEN.Size = new System.Drawing.Size(117, 23);
            this.tbOptionItemNameEN.TabIndex = 2;
            // 
            // tbOptionItemName
            // 
            this.tbOptionItemName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbOptionItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbOptionItemName.Location = new System.Drawing.Point(39, 19);
            this.tbOptionItemName.MaxLength = 30;
            this.tbOptionItemName.Name = "tbOptionItemName";
            this.tbOptionItemName.Size = new System.Drawing.Size(117, 23);
            this.tbOptionItemName.TabIndex = 1;
            // 
            // btnOptionCopy
            // 
            this.btnOptionCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOptionCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptionCopy.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOptionCopy.ForeColor = System.Drawing.Color.White;
            this.btnOptionCopy.Location = new System.Drawing.Point(742, 109);
            this.btnOptionCopy.Name = "btnOptionCopy";
            this.btnOptionCopy.Size = new System.Drawing.Size(96, 29);
            this.btnOptionCopy.TabIndex = 66;
            this.btnOptionCopy.TabStop = false;
            this.btnOptionCopy.Text = "옵션복사";
            this.btnOptionCopy.UseVisualStyleBackColor = false;
            this.btnOptionCopy.Click += new System.EventHandler(this.btnOptionCopy_Click);
            // 
            // cbSourceGoods
            // 
            this.cbSourceGoods.BackColor = System.Drawing.Color.White;
            this.cbSourceGoods.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbSourceGoods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbSourceGoods.FormattingEnabled = true;
            this.cbSourceGoods.Location = new System.Drawing.Point(742, 82);
            this.cbSourceGoods.Name = "cbSourceGoods";
            this.cbSourceGoods.Size = new System.Drawing.Size(95, 21);
            this.cbSourceGoods.TabIndex = 83;
            // 
            // frmSysOption
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(870, 710);
            this.Controls.Add(this.cbSourceGoods);
            this.Controls.Add(this.btnOptionCopy);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lvwOptionItem);
            this.Controls.Add(this.lvwOption);
            this.Controls.Add(this.lvwGoods);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSysOption";
            this.Text = "frmSysOption";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader goodsname;
        private System.Windows.Forms.ColumnHeader amt;
        private System.Windows.Forms.ColumnHeader shopname;
        private System.Windows.Forms.ListView lvwGoods;
        private System.Windows.Forms.Label lblJP;
        private System.Windows.Forms.Label lblCH;
        private System.Windows.Forms.Label lblEN;
        private System.Windows.Forms.Label lblKR;
        private System.Windows.Forms.TextBox tbOptionNameJP;
        private System.Windows.Forms.TextBox tbOptionNameCH;
        private System.Windows.Forms.TextBox tbOptionNameEN;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbOptionName;
        private System.Windows.Forms.ListView lvwOption;
        private System.Windows.Forms.ColumnHeader option_name;
        private System.Windows.Forms.ColumnHeader option_no;
        private System.Windows.Forms.ListView lvwOptionItem;
        private System.Windows.Forms.ColumnHeader option_item_no;
        private System.Windows.Forms.ColumnHeader option_item_name_kr;
        private System.Windows.Forms.Button btnOptionUp;
        private System.Windows.Forms.Button btnOptionDn;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSave2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbOptionItemAmt;
        private System.Windows.Forms.Label lblJP2;
        private System.Windows.Forms.Button btnOptionItemUp;
        private System.Windows.Forms.Button btnAdd2;
        private System.Windows.Forms.Button btnOptionItemDn;
        private System.Windows.Forms.Button btnUpdate2;
        private System.Windows.Forms.Label lblCH2;
        private System.Windows.Forms.Button btnDelete2;
        private System.Windows.Forms.Label lblAmtTitle;
        private System.Windows.Forms.Label lblEN2;
        private System.Windows.Forms.Label lblKR2;
        private System.Windows.Forms.TextBox tbOptionItemNameJP;
        private System.Windows.Forms.TextBox tbOptionItemNameCH;
        private System.Windows.Forms.TextBox tbOptionItemNameEN;
        private System.Windows.Forms.TextBox tbOptionItemName;
        private System.Windows.Forms.ColumnHeader option_name_en;
        private System.Windows.Forms.ColumnHeader option_name_ch;
        private System.Windows.Forms.ColumnHeader option_name_jp;
        private System.Windows.Forms.ColumnHeader option_item_name_en;
        private System.Windows.Forms.ColumnHeader option_item_name_ch;
        private System.Windows.Forms.ColumnHeader option_item_name_jp;
        private System.Windows.Forms.ColumnHeader option_item_amt;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnOptionCopy;
        private System.Windows.Forms.ComboBox cbSourceGoods;
    }
}