namespace thepos
{
    partial class frmSysGoodsGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysGoodsGroup));
            this.tableLayoutPanelGroup = new System.Windows.Forms.TableLayoutPanel();
            this.lvwList = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.locX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.locY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.szX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.szY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblGroupNameTitle = new System.Windows.Forms.Label();
            this.lblLocXTitle = new System.Windows.Forms.Label();
            this.lblLocYTitle = new System.Windows.Forms.Label();
            this.lblSzXTitle = new System.Windows.Forms.Label();
            this.lblSzYTitle = new System.Windows.Forms.Label();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.tbLocateX = new System.Windows.Forms.TextBox();
            this.tbLocateY = new System.Windows.Forms.TextBox();
            this.tbSizeX = new System.Windows.Forms.TextBox();
            this.tbSizeY = new System.Windows.Forms.TextBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanelGroupSelected = new System.Windows.Forms.TableLayoutPanel();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.comboPosNo = new System.Windows.Forms.ComboBox();
            this.lblPosNo = new System.Windows.Forms.Label();
            this.btnViewPosNo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelGroup
            // 
            this.tableLayoutPanelGroup.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelGroup.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelGroup.ColumnCount = 8;
            this.tableLayoutPanelGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroup.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanelGroup.Location = new System.Drawing.Point(83, 514);
            this.tableLayoutPanelGroup.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelGroup.Name = "tableLayoutPanelGroup";
            this.tableLayoutPanelGroup.RowCount = 2;
            this.tableLayoutPanelGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGroup.Size = new System.Drawing.Size(521, 130);
            this.tableLayoutPanelGroup.TabIndex = 1;
            // 
            // lvwList
            // 
            this.lvwList.BackColor = System.Drawing.SystemColors.Window;
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.locX,
            this.locY,
            this.szX,
            this.szY});
            this.lvwList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(83, 58);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(342, 303);
            this.lvwList.TabIndex = 38;
            this.lvwList.TabStop = false;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            this.lvwList.SelectedIndexChanged += new System.EventHandler(this.lvwGoodsGroup_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.Text = "그룹명";
            this.name.Width = 110;
            // 
            // locX
            // 
            this.locX.Text = "locX";
            this.locX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.locX.Width = 50;
            // 
            // locY
            // 
            this.locY.Text = "locY";
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
            // lblGroupNameTitle
            // 
            this.lblGroupNameTitle.AutoSize = true;
            this.lblGroupNameTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGroupNameTitle.Location = new System.Drawing.Point(12, 35);
            this.lblGroupNameTitle.Name = "lblGroupNameTitle";
            this.lblGroupNameTitle.Size = new System.Drawing.Size(49, 14);
            this.lblGroupNameTitle.TabIndex = 41;
            this.lblGroupNameTitle.Text = "그룹명";
            // 
            // lblLocXTitle
            // 
            this.lblLocXTitle.AutoSize = true;
            this.lblLocXTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLocXTitle.Location = new System.Drawing.Point(12, 69);
            this.lblLocXTitle.Name = "lblLocXTitle";
            this.lblLocXTitle.Size = new System.Drawing.Size(41, 14);
            this.lblLocXTitle.TabIndex = 41;
            this.lblLocXTitle.Text = "LocX";
            // 
            // lblLocYTitle
            // 
            this.lblLocYTitle.AutoSize = true;
            this.lblLocYTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLocYTitle.Location = new System.Drawing.Point(12, 98);
            this.lblLocYTitle.Name = "lblLocYTitle";
            this.lblLocYTitle.Size = new System.Drawing.Size(40, 14);
            this.lblLocYTitle.TabIndex = 41;
            this.lblLocYTitle.Text = "LocY";
            // 
            // lblSzXTitle
            // 
            this.lblSzXTitle.AutoSize = true;
            this.lblSzXTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSzXTitle.Location = new System.Drawing.Point(12, 127);
            this.lblSzXTitle.Name = "lblSzXTitle";
            this.lblSzXTitle.Size = new System.Drawing.Size(45, 14);
            this.lblSzXTitle.TabIndex = 41;
            this.lblSzXTitle.Text = "SizeX";
            // 
            // lblSzYTitle
            // 
            this.lblSzYTitle.AutoSize = true;
            this.lblSzYTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSzYTitle.Location = new System.Drawing.Point(12, 156);
            this.lblSzYTitle.Name = "lblSzYTitle";
            this.lblSzYTitle.Size = new System.Drawing.Size(44, 14);
            this.lblSzYTitle.TabIndex = 41;
            this.lblSzYTitle.Text = "SizeY";
            // 
            // tbGroupName
            // 
            this.tbGroupName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbGroupName.Location = new System.Drawing.Point(74, 28);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.Size = new System.Drawing.Size(113, 23);
            this.tbGroupName.TabIndex = 40;
            // 
            // tbLocateX
            // 
            this.tbLocateX.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbLocateX.Location = new System.Drawing.Point(74, 62);
            this.tbLocateX.MaxLength = 1;
            this.tbLocateX.Name = "tbLocateX";
            this.tbLocateX.Size = new System.Drawing.Size(113, 23);
            this.tbLocateX.TabIndex = 40;
            // 
            // tbLocateY
            // 
            this.tbLocateY.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbLocateY.Location = new System.Drawing.Point(74, 91);
            this.tbLocateY.MaxLength = 1;
            this.tbLocateY.Name = "tbLocateY";
            this.tbLocateY.Size = new System.Drawing.Size(113, 23);
            this.tbLocateY.TabIndex = 40;
            // 
            // tbSizeX
            // 
            this.tbSizeX.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSizeX.Location = new System.Drawing.Point(74, 120);
            this.tbSizeX.MaxLength = 1;
            this.tbSizeX.Name = "tbSizeX";
            this.tbSizeX.Size = new System.Drawing.Size(113, 23);
            this.tbSizeX.TabIndex = 40;
            // 
            // tbSizeY
            // 
            this.tbSizeY.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSizeY.Location = new System.Drawing.Point(74, 149);
            this.tbSizeY.MaxLength = 1;
            this.tbSizeY.Name = "tbSizeY";
            this.tbSizeY.Size = new System.Drawing.Size(113, 23);
            this.tbSizeY.TabIndex = 40;
            // 
            // btnInput
            // 
            this.btnInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInput.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInput.Location = new System.Drawing.Point(204, 50);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(120, 40);
            this.btnInput.TabIndex = 39;
            this.btnInput.Text = "입력";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.Location = new System.Drawing.Point(204, 96);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 40);
            this.btnUpdate.TabIndex = 39;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.Location = new System.Drawing.Point(85, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(103, 14);
            this.lblTitle.TabIndex = 42;
            this.lblTitle.Text = "상품그룹 관리";
            // 
            // tableLayoutPanelGroupSelected
            // 
            this.tableLayoutPanelGroupSelected.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelGroupSelected.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelGroupSelected.ColumnCount = 8;
            this.tableLayoutPanelGroupSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroupSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroupSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroupSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroupSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroupSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroupSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroupSelected.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGroupSelected.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanelGroupSelected.Location = new System.Drawing.Point(83, 376);
            this.tableLayoutPanelGroupSelected.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelGroupSelected.Name = "tableLayoutPanelGroupSelected";
            this.tableLayoutPanelGroupSelected.RowCount = 2;
            this.tableLayoutPanelGroupSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGroupSelected.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGroupSelected.Size = new System.Drawing.Size(521, 130);
            this.tableLayoutPanelGroupSelected.TabIndex = 1;
            // 
            // btnApply
            // 
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnApply.Location = new System.Drawing.Point(648, 376);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(120, 40);
            this.btnApply.TabIndex = 43;
            this.btnApply.Text = "적용보기";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.tbGroupName);
            this.groupBox1.Controls.Add(this.tbLocateX);
            this.groupBox1.Controls.Add(this.lblSzYTitle);
            this.groupBox1.Controls.Add(this.tbLocateY);
            this.groupBox1.Controls.Add(this.lblSzXTitle);
            this.groupBox1.Controls.Add(this.tbSizeX);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnInput);
            this.groupBox1.Controls.Add(this.lblLocYTitle);
            this.groupBox1.Controls.Add(this.tbSizeY);
            this.groupBox1.Controls.Add(this.lblLocXTitle);
            this.groupBox1.Controls.Add(this.lblGroupNameTitle);
            this.groupBox1.Location = new System.Drawing.Point(443, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 216);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Location = new System.Drawing.Point(204, 142);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 30);
            this.btnDelete.TabIndex = 42;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // comboPosNo
            // 
            this.comboPosNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboPosNo.FormattingEnabled = true;
            this.comboPosNo.Location = new System.Drawing.Point(82, 24);
            this.comboPosNo.Name = "comboPosNo";
            this.comboPosNo.Size = new System.Drawing.Size(104, 21);
            this.comboPosNo.TabIndex = 45;
            // 
            // lblPosNo
            // 
            this.lblPosNo.AutoSize = true;
            this.lblPosNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPosNo.Location = new System.Drawing.Point(5, 28);
            this.lblPosNo.Name = "lblPosNo";
            this.lblPosNo.Size = new System.Drawing.Size(63, 14);
            this.lblPosNo.TabIndex = 41;
            this.lblPosNo.Text = "포스번호";
            // 
            // btnViewPosNo
            // 
            this.btnViewPosNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewPosNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewPosNo.Location = new System.Drawing.Point(204, 19);
            this.btnViewPosNo.Name = "btnViewPosNo";
            this.btnViewPosNo.Size = new System.Drawing.Size(120, 40);
            this.btnViewPosNo.TabIndex = 46;
            this.btnViewPosNo.Text = "조회";
            this.btnViewPosNo.UseVisualStyleBackColor = true;
            this.btnViewPosNo.Click += new System.EventHandler(this.btnViewPosNo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnViewPosNo);
            this.groupBox2.Controls.Add(this.lblPosNo);
            this.groupBox2.Controls.Add(this.comboPosNo);
            this.groupBox2.Location = new System.Drawing.Point(444, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 78);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            // 
            // frmSysGoodsGroup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(870, 710);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lvwList);
            this.Controls.Add(this.tableLayoutPanelGroupSelected);
            this.Controls.Add(this.tableLayoutPanelGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSysGoodsGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "상품그룹등록";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGroup;
        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader locX;
        private System.Windows.Forms.ColumnHeader locY;
        private System.Windows.Forms.ColumnHeader szX;
        private System.Windows.Forms.ColumnHeader szY;
        private System.Windows.Forms.Label lblGroupNameTitle;
        private System.Windows.Forms.Label lblLocXTitle;
        private System.Windows.Forms.Label lblLocYTitle;
        private System.Windows.Forms.Label lblSzXTitle;
        private System.Windows.Forms.Label lblSzYTitle;
        private System.Windows.Forms.TextBox tbGroupName;
        private System.Windows.Forms.TextBox tbLocateX;
        private System.Windows.Forms.TextBox tbLocateY;
        private System.Windows.Forms.TextBox tbSizeX;
        private System.Windows.Forms.TextBox tbSizeY;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGroupSelected;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboPosNo;
        private System.Windows.Forms.Label lblPosNo;
        private System.Windows.Forms.Button btnViewPosNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDelete;
    }
}