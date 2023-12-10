namespace thepos._1Sales
{
    partial class frmSysDcrFavorite
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
            this.btnDn = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.lvwList = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.des = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.des1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTitle = new System.Windows.Forms.Label();
            this.cbDes = new System.Windows.Forms.ComboBox();
            this.lblNameTitle = new System.Windows.Forms.Label();
            this.lblDesTitle = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lblTypeTitle = new System.Windows.Forms.Label();
            this.lblValueTitle = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDn
            // 
            this.btnDn.BackColor = System.Drawing.Color.White;
            this.btnDn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDn.Location = new System.Drawing.Point(10, 101);
            this.btnDn.Name = "btnDn";
            this.btnDn.Size = new System.Drawing.Size(40, 50);
            this.btnDn.TabIndex = 46;
            this.btnDn.TabStop = false;
            this.btnDn.Text = "▼";
            this.btnDn.UseVisualStyleBackColor = false;
            this.btnDn.Click += new System.EventHandler(this.btnDn_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.White;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUp.Location = new System.Drawing.Point(10, 45);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(40, 50);
            this.btnUp.TabIndex = 47;
            this.btnUp.TabStop = false;
            this.btnUp.Text = "▲";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // lvwList
            // 
            this.lvwList.BackColor = System.Drawing.SystemColors.Window;
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.name,
            this.des,
            this.type,
            this.value,
            this.des1,
            this.type1});
            this.lvwList.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(118, 58);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(382, 333);
            this.lvwList.TabIndex = 48;
            this.lvwList.TabStop = false;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            this.lvwList.SelectedIndexChanged += new System.EventHandler(this.lvwList_SelectedIndexChanged);
            // 
            // no
            // 
            this.no.Text = "#";
            this.no.Width = 30;
            // 
            // name
            // 
            this.name.Text = "할인명";
            this.name.Width = 142;
            // 
            // des
            // 
            this.des.Text = "대상";
            this.des.Width = 50;
            // 
            // type
            // 
            this.type.Text = "유형";
            // 
            // value
            // 
            this.value.Text = "할인값";
            this.value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.value.Width = 70;
            // 
            // des1
            // 
            this.des1.Width = 0;
            // 
            // type1
            // 
            this.type1.Width = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(114, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(96, 14);
            this.lblTitle.TabIndex = 49;
            this.lblTitle.Text = "할인 즐겨찾기";
            // 
            // cbDes
            // 
            this.cbDes.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbDes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbDes.FormattingEnabled = true;
            this.cbDes.Location = new System.Drawing.Point(583, 90);
            this.cbDes.Name = "cbDes";
            this.cbDes.Size = new System.Drawing.Size(141, 21);
            this.cbDes.TabIndex = 53;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.AutoSize = true;
            this.lblNameTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNameTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNameTitle.Location = new System.Drawing.Point(517, 64);
            this.lblNameTitle.Name = "lblNameTitle";
            this.lblNameTitle.Size = new System.Drawing.Size(49, 14);
            this.lblNameTitle.TabIndex = 51;
            this.lblNameTitle.Text = "할인명";
            // 
            // lblDesTitle
            // 
            this.lblDesTitle.AutoSize = true;
            this.lblDesTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDesTitle.Location = new System.Drawing.Point(517, 94);
            this.lblDesTitle.Name = "lblDesTitle";
            this.lblDesTitle.Size = new System.Drawing.Size(63, 14);
            this.lblDesTitle.TabIndex = 52;
            this.lblDesTitle.Text = "할인대상";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbName.Location = new System.Drawing.Point(583, 58);
            this.tbName.MaxLength = 30;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(141, 23);
            this.tbName.TabIndex = 50;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDelete.Location = new System.Drawing.Point(71, 121);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(138, 30);
            this.btnDelete.TabIndex = 56;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUpdate.Location = new System.Drawing.Point(71, 75);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(138, 40);
            this.btnUpdate.TabIndex = 54;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAdd.Location = new System.Drawing.Point(71, 29);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(138, 40);
            this.btnAdd.TabIndex = 55;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbType
            // 
            this.cbType.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(583, 120);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(141, 21);
            this.cbType.TabIndex = 58;
            // 
            // lblTypeTitle
            // 
            this.lblTypeTitle.AutoSize = true;
            this.lblTypeTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTypeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTypeTitle.Location = new System.Drawing.Point(517, 124);
            this.lblTypeTitle.Name = "lblTypeTitle";
            this.lblTypeTitle.Size = new System.Drawing.Size(63, 14);
            this.lblTypeTitle.TabIndex = 57;
            this.lblTypeTitle.Text = "할인유형";
            // 
            // lblValueTitle
            // 
            this.lblValueTitle.AutoSize = true;
            this.lblValueTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblValueTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblValueTitle.Location = new System.Drawing.Point(517, 156);
            this.lblValueTitle.Name = "lblValueTitle";
            this.lblValueTitle.Size = new System.Drawing.Size(49, 14);
            this.lblValueTitle.TabIndex = 60;
            this.lblValueTitle.Text = "할인값";
            // 
            // tbValue
            // 
            this.tbValue.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbValue.Location = new System.Drawing.Point(583, 150);
            this.tbValue.MaxLength = 30;
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(141, 23);
            this.tbValue.TabIndex = 59;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(586, 410);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(138, 50);
            this.btnSave.TabIndex = 61;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblInfo.Location = new System.Drawing.Point(231, 404);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(203, 14);
            this.lblInfo.TabIndex = 62;
            this.lblInfo.Text = "최대 8개 까지 등록가능합니다.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnUp);
            this.groupBox1.Controls.Add(this.btnDn);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Location = new System.Drawing.Point(515, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 172);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            // 
            // frmSysDcrFavorite
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(870, 710);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblValueTitle);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.lblTypeTitle);
            this.Controls.Add(this.cbDes);
            this.Controls.Add(this.lblNameTitle);
            this.Controls.Add(this.lblDesTitle);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lvwList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSysDcrFavorite";
            this.Text = "frmOrderDcrFavorite";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDn;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader des;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cbDes;
        private System.Windows.Forms.Label lblNameTitle;
        private System.Windows.Forms.Label lblDesTitle;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblTypeTitle;
        private System.Windows.Forms.Label lblValueTitle;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ColumnHeader value;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ColumnHeader des1;
        private System.Windows.Forms.ColumnHeader type1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}