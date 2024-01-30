namespace thepos._1Sales
{
    partial class frmSysPayConsole
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("현금결제");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("카드결제");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("포인트결제");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("복합결제");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("간편결제");
            this.tableLayoutPanelPayControl = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.lblPosNo = new System.Windows.Forms.Label();
            this.comboPosNo = new System.Windows.Forms.ComboBox();
            this.lvwConsole = new System.Windows.Forms.ListView();
            this.item_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwConsoleLink = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.locX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.locY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.szX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.szY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnLink = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbLocateX = new System.Windows.Forms.TextBox();
            this.lblT6 = new System.Windows.Forms.Label();
            this.lblT5 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblT3 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblT4 = new System.Windows.Forms.Label();
            this.tbSizeY = new System.Windows.Forms.TextBox();
            this.tbSizeX = new System.Windows.Forms.TextBox();
            this.tbLocateY = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelPayControlSelected = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelPayControl
            // 
            this.tableLayoutPanelPayControl.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelPayControl.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelPayControl.ColumnCount = 10;
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanelPayControl.Location = new System.Drawing.Point(192, 535);
            this.tableLayoutPanelPayControl.Name = "tableLayoutPanelPayControl";
            this.tableLayoutPanelPayControl.RowCount = 4;
            this.tableLayoutPanelPayControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPayControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPayControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPayControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPayControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPayControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPayControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPayControl.Size = new System.Drawing.Size(530, 156);
            this.tableLayoutPanelPayControl.TabIndex = 60;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(159, 29);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(91, 14);
            this.lblTitle.TabIndex = 64;
            this.lblTitle.Text = "결제버튼배치";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnView);
            this.groupBox2.Controls.Add(this.lblPosNo);
            this.groupBox2.Controls.Add(this.comboPosNo);
            this.groupBox2.Location = new System.Drawing.Point(348, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 63);
            this.groupBox2.TabIndex = 66;
            this.groupBox2.TabStop = false;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnView.Location = new System.Drawing.Point(144, 19);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 30);
            this.btnView.TabIndex = 46;
            this.btnView.Text = "조회";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblPosNo
            // 
            this.lblPosNo.AutoSize = true;
            this.lblPosNo.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPosNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPosNo.Location = new System.Drawing.Point(5, 28);
            this.lblPosNo.Name = "lblPosNo";
            this.lblPosNo.Size = new System.Drawing.Size(63, 14);
            this.lblPosNo.TabIndex = 41;
            this.lblPosNo.Text = "포스번호";
            // 
            // comboPosNo
            // 
            this.comboPosNo.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboPosNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboPosNo.FormattingEnabled = true;
            this.comboPosNo.Location = new System.Drawing.Point(82, 24);
            this.comboPosNo.Name = "comboPosNo";
            this.comboPosNo.Size = new System.Drawing.Size(56, 21);
            this.comboPosNo.TabIndex = 45;
            // 
            // lvwConsole
            // 
            this.lvwConsole.BackColor = System.Drawing.SystemColors.Window;
            this.lvwConsole.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.item_name});
            this.lvwConsole.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwConsole.FullRowSelect = true;
            this.lvwConsole.GridLines = true;
            this.lvwConsole.HideSelection = false;
            listViewItem1.Tag = "CASH";
            listViewItem2.Tag = "CARD";
            listViewItem3.Tag = "POINT";
            listViewItem4.Tag = "COMPLEX";
            listViewItem5.Tag = "EASY";
            this.lvwConsole.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.lvwConsole.Location = new System.Drawing.Point(152, 90);
            this.lvwConsole.MultiSelect = false;
            this.lvwConsole.Name = "lvwConsole";
            this.lvwConsole.Size = new System.Drawing.Size(109, 263);
            this.lvwConsole.TabIndex = 84;
            this.lvwConsole.TabStop = false;
            this.lvwConsole.UseCompatibleStateImageBehavior = false;
            this.lvwConsole.View = System.Windows.Forms.View.Details;
            // 
            // item_name
            // 
            this.item_name.Text = "항목명";
            this.item_name.Width = 100;
            // 
            // lvwConsoleLink
            // 
            this.lvwConsoleLink.BackColor = System.Drawing.SystemColors.Window;
            this.lvwConsoleLink.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.locX,
            this.locY,
            this.szX,
            this.szY});
            this.lvwConsoleLink.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwConsoleLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwConsoleLink.FullRowSelect = true;
            this.lvwConsoleLink.GridLines = true;
            this.lvwConsoleLink.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwConsoleLink.HideSelection = false;
            this.lvwConsoleLink.Location = new System.Drawing.Point(271, 90);
            this.lvwConsoleLink.MultiSelect = false;
            this.lvwConsoleLink.Name = "lvwConsoleLink";
            this.lvwConsoleLink.Size = new System.Drawing.Size(328, 263);
            this.lvwConsoleLink.TabIndex = 83;
            this.lvwConsoleLink.TabStop = false;
            this.lvwConsoleLink.UseCompatibleStateImageBehavior = false;
            this.lvwConsoleLink.View = System.Windows.Forms.View.Details;
            this.lvwConsoleLink.SelectedIndexChanged += new System.EventHandler(this.lvwConsoleLink_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.Text = "항목명";
            this.name.Width = 100;
            // 
            // locX
            // 
            this.locX.Text = "LocX";
            this.locX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.locX.Width = 50;
            // 
            // locY
            // 
            this.locY.Text = "LocY";
            this.locY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.locY.Width = 50;
            // 
            // szX
            // 
            this.szX.Text = "SzX";
            this.szX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.szX.Width = 50;
            // 
            // szY
            // 
            this.szY.Text = "SzY";
            this.szY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.szY.Width = 50;
            // 
            // btnLink
            // 
            this.btnLink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLink.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLink.ForeColor = System.Drawing.Color.White;
            this.btnLink.Location = new System.Drawing.Point(622, 91);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(100, 40);
            this.btnLink.TabIndex = 99;
            this.btnLink.Text = "항목연결";
            this.btnLink.UseVisualStyleBackColor = false;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.White;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnApply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnApply.Location = new System.Drawing.Point(622, 323);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 30);
            this.btnApply.TabIndex = 101;
            this.btnApply.Text = "적용보기";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(611, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 182);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            // 
            // tbLocateX
            // 
            this.tbLocateX.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbLocateX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbLocateX.Location = new System.Drawing.Point(41, 33);
            this.tbLocateX.MaxLength = 1;
            this.tbLocateX.Name = "tbLocateX";
            this.tbLocateX.Size = new System.Drawing.Size(31, 23);
            this.tbLocateX.TabIndex = 75;
            // 
            // lblT6
            // 
            this.lblT6.AutoSize = true;
            this.lblT6.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblT6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblT6.Location = new System.Drawing.Point(82, 13);
            this.lblT6.Name = "lblT6";
            this.lblT6.Size = new System.Drawing.Size(17, 16);
            this.lblT6.TabIndex = 70;
            this.lblT6.Text = "Y";
            // 
            // lblT5
            // 
            this.lblT5.AutoSize = true;
            this.lblT5.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblT5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblT5.Location = new System.Drawing.Point(45, 15);
            this.lblT5.Name = "lblT5";
            this.lblT5.Size = new System.Drawing.Size(16, 14);
            this.lblT5.TabIndex = 70;
            this.lblT5.Text = "X";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(11, 141);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 88;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblT3
            // 
            this.lblT3.AutoSize = true;
            this.lblT3.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblT3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblT3.Location = new System.Drawing.Point(9, 40);
            this.lblT3.Name = "lblT3";
            this.lblT3.Size = new System.Drawing.Size(27, 14);
            this.lblT3.TabIndex = 69;
            this.lblT3.Text = "loc";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(11, 96);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 40);
            this.btnUpdate.TabIndex = 89;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblT4
            // 
            this.lblT4.AutoSize = true;
            this.lblT4.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblT4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblT4.Location = new System.Drawing.Point(5, 68);
            this.lblT4.Name = "lblT4";
            this.lblT4.Size = new System.Drawing.Size(34, 14);
            this.lblT4.TabIndex = 68;
            this.lblT4.Text = "size";
            // 
            // tbSizeY
            // 
            this.tbSizeY.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSizeY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSizeY.Location = new System.Drawing.Point(78, 62);
            this.tbSizeY.MaxLength = 1;
            this.tbSizeY.Name = "tbSizeY";
            this.tbSizeY.Size = new System.Drawing.Size(31, 23);
            this.tbSizeY.TabIndex = 78;
            // 
            // tbSizeX
            // 
            this.tbSizeX.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSizeX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSizeX.Location = new System.Drawing.Point(41, 62);
            this.tbSizeX.MaxLength = 1;
            this.tbSizeX.Name = "tbSizeX";
            this.tbSizeX.Size = new System.Drawing.Size(31, 23);
            this.tbSizeX.TabIndex = 77;
            // 
            // tbLocateY
            // 
            this.tbLocateY.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbLocateY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbLocateY.Location = new System.Drawing.Point(78, 33);
            this.tbLocateY.MaxLength = 1;
            this.tbLocateY.Name = "tbLocateY";
            this.tbLocateY.Size = new System.Drawing.Size(31, 23);
            this.tbLocateY.TabIndex = 76;
            // 
            // tableLayoutPanelPayControlSelected
            // 
            this.tableLayoutPanelPayControlSelected.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelPayControlSelected.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelPayControlSelected.ColumnCount = 10;
            this.tableLayoutPanelPayControlSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControlSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControlSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControlSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControlSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControlSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControlSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControlSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControlSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControlSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControlSelected.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanelPayControlSelected.Location = new System.Drawing.Point(192, 366);
            this.tableLayoutPanelPayControlSelected.Name = "tableLayoutPanelPayControlSelected";
            this.tableLayoutPanelPayControlSelected.RowCount = 4;
            this.tableLayoutPanelPayControlSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPayControlSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPayControlSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPayControlSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPayControlSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPayControlSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPayControlSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPayControlSelected.Size = new System.Drawing.Size(530, 156);
            this.tableLayoutPanelPayControlSelected.TabIndex = 103;
            // 
            // frmSysPayConsole
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(870, 710);
            this.Controls.Add(this.tableLayoutPanelPayControlSelected);
            this.Controls.Add(this.btnLink);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvwConsole);
            this.Controls.Add(this.lvwConsoleLink);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tableLayoutPanelPayControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSysPayConsole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "결제콘솔";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPayControl;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblPosNo;
        private System.Windows.Forms.ComboBox comboPosNo;
        private System.Windows.Forms.ListView lvwConsole;
        private System.Windows.Forms.ColumnHeader item_name;
        private System.Windows.Forms.ListView lvwConsoleLink;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader locX;
        private System.Windows.Forms.ColumnHeader locY;
        private System.Windows.Forms.ColumnHeader szX;
        private System.Windows.Forms.ColumnHeader szY;
        private System.Windows.Forms.Button btnLink;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbLocateX;
        private System.Windows.Forms.Label lblT6;
        private System.Windows.Forms.Label lblT5;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblT3;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblT4;
        private System.Windows.Forms.TextBox tbSizeY;
        private System.Windows.Forms.TextBox tbSizeX;
        private System.Windows.Forms.TextBox tbLocateY;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPayControlSelected;
    }
}