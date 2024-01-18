namespace thepos
{
    partial class frmSetupPos
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
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.change = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblNameTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblValueTitle = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblValueTitle2 = new System.Windows.Forms.Label();
            this.lblPosNoTitle = new System.Windows.Forms.Label();
            this.lblPosNo = new System.Windows.Forms.Label();
            this.lblSiteName = new System.Windows.Forms.Label();
            this.lblSiteNameTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbValue = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMemo = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLocalMode = new System.Windows.Forms.Label();
            this.ischange = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwList
            // 
            this.lvwList.BackColor = System.Drawing.SystemColors.Window;
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.value,
            this.change,
            this.memo,
            this.ischange});
            this.lvwList.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwList.FullRowSelect = true;
            this.lvwList.GridLines = true;
            this.lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwList.HideSelection = false;
            this.lvwList.Location = new System.Drawing.Point(20, 70);
            this.lvwList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvwList.MultiSelect = false;
            this.lvwList.Name = "lvwList";
            this.lvwList.Size = new System.Drawing.Size(547, 611);
            this.lvwList.TabIndex = 38;
            this.lvwList.TabStop = false;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.Details;
            this.lvwList.SelectedIndexChanged += new System.EventHandler(this.lvwList_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.Text = "항목";
            this.name.Width = 200;
            // 
            // value
            // 
            this.value.Text = "설정값";
            this.value.Width = 130;
            // 
            // change
            // 
            this.change.Text = "변경값";
            this.change.Width = 130;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.White;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLoad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLoad.Location = new System.Drawing.Point(84, 91);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(139, 40);
            this.btnLoad.TabIndex = 39;
            this.btnLoad.TabStop = false;
            this.btnLoad.Text = "설정보기";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(667, 608);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(138, 50);
            this.btnSave.TabIndex = 39;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "설정저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.AutoSize = true;
            this.lblNameTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNameTitle.ForeColor = System.Drawing.Color.Black;
            this.lblNameTitle.Location = new System.Drawing.Point(14, 29);
            this.lblNameTitle.Name = "lblNameTitle";
            this.lblNameTitle.Size = new System.Drawing.Size(35, 14);
            this.lblNameTitle.TabIndex = 41;
            this.lblNameTitle.Text = "항목";
            this.lblNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(81, 29);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(14, 14);
            this.lblName.TabIndex = 41;
            this.lblName.Text = "_";
            // 
            // lblValueTitle
            // 
            this.lblValueTitle.AutoSize = true;
            this.lblValueTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblValueTitle.ForeColor = System.Drawing.Color.Black;
            this.lblValueTitle.Location = new System.Drawing.Point(14, 65);
            this.lblValueTitle.Name = "lblValueTitle";
            this.lblValueTitle.Size = new System.Drawing.Size(49, 14);
            this.lblValueTitle.TabIndex = 41;
            this.lblValueTitle.Text = "설정값";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblValue.ForeColor = System.Drawing.Color.Black;
            this.lblValue.Location = new System.Drawing.Point(80, 65);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(14, 14);
            this.lblValue.TabIndex = 41;
            this.lblValue.Text = "_";
            // 
            // lblValueTitle2
            // 
            this.lblValueTitle2.AutoSize = true;
            this.lblValueTitle2.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblValueTitle2.ForeColor = System.Drawing.Color.Black;
            this.lblValueTitle2.Location = new System.Drawing.Point(14, 103);
            this.lblValueTitle2.Name = "lblValueTitle2";
            this.lblValueTitle2.Size = new System.Drawing.Size(49, 14);
            this.lblValueTitle2.TabIndex = 41;
            this.lblValueTitle2.Text = "변경값";
            // 
            // lblPosNoTitle
            // 
            this.lblPosNoTitle.AutoSize = true;
            this.lblPosNoTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPosNoTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPosNoTitle.ForeColor = System.Drawing.Color.Black;
            this.lblPosNoTitle.Location = new System.Drawing.Point(12, 52);
            this.lblPosNoTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblPosNoTitle.Name = "lblPosNoTitle";
            this.lblPosNoTitle.Size = new System.Drawing.Size(63, 14);
            this.lblPosNoTitle.TabIndex = 31;
            this.lblPosNoTitle.Text = "포스번호";
            this.lblPosNoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPosNo
            // 
            this.lblPosNo.AutoSize = true;
            this.lblPosNo.BackColor = System.Drawing.Color.Transparent;
            this.lblPosNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPosNo.ForeColor = System.Drawing.Color.Black;
            this.lblPosNo.Location = new System.Drawing.Point(90, 52);
            this.lblPosNo.Margin = new System.Windows.Forms.Padding(0);
            this.lblPosNo.Name = "lblPosNo";
            this.lblPosNo.Size = new System.Drawing.Size(14, 14);
            this.lblPosNo.TabIndex = 31;
            this.lblPosNo.Text = "_";
            this.lblPosNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSiteName
            // 
            this.lblSiteName.AutoSize = true;
            this.lblSiteName.BackColor = System.Drawing.Color.Transparent;
            this.lblSiteName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSiteName.ForeColor = System.Drawing.Color.Black;
            this.lblSiteName.Location = new System.Drawing.Point(90, 22);
            this.lblSiteName.Margin = new System.Windows.Forms.Padding(0);
            this.lblSiteName.Name = "lblSiteName";
            this.lblSiteName.Size = new System.Drawing.Size(14, 14);
            this.lblSiteName.TabIndex = 31;
            this.lblSiteName.Text = "_";
            this.lblSiteName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSiteNameTitle
            // 
            this.lblSiteNameTitle.AutoSize = true;
            this.lblSiteNameTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSiteNameTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSiteNameTitle.ForeColor = System.Drawing.Color.Black;
            this.lblSiteNameTitle.Location = new System.Drawing.Point(12, 22);
            this.lblSiteNameTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblSiteNameTitle.Name = "lblSiteNameTitle";
            this.lblSiteNameTitle.Size = new System.Drawing.Size(63, 14);
            this.lblSiteNameTitle.TabIndex = 31;
            this.lblSiteNameTitle.Text = "사업장명";
            this.lblSiteNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblPosNoTitle);
            this.panel1.Controls.Add(this.lblSiteNameTitle);
            this.panel1.Controls.Add(this.lblSiteName);
            this.panel1.Controls.Add(this.lblPosNo);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Location = new System.Drawing.Point(581, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 150);
            this.panel1.TabIndex = 44;
            // 
            // cbValue
            // 
            this.cbValue.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbValue.FormattingEnabled = true;
            this.cbValue.Location = new System.Drawing.Point(84, 100);
            this.cbValue.Name = "cbValue";
            this.cbValue.Size = new System.Drawing.Size(138, 21);
            this.cbValue.TabIndex = 45;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblMemo);
            this.panel2.Controls.Add(this.tbValue);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.lblNameTitle);
            this.panel2.Controls.Add(this.cbValue);
            this.panel2.Controls.Add(this.lblValueTitle);
            this.panel2.Controls.Add(this.lblValueTitle2);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Controls.Add(this.lblValue);
            this.panel2.Location = new System.Drawing.Point(582, 240);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 346);
            this.panel2.TabIndex = 46;
            // 
            // lblMemo
            // 
            this.lblMemo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMemo.ForeColor = System.Drawing.Color.Gray;
            this.lblMemo.Location = new System.Drawing.Point(32, 144);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(190, 96);
            this.lblMemo.TabIndex = 48;
            // 
            // tbValue
            // 
            this.tbValue.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbValue.Location = new System.Drawing.Point(84, 100);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(138, 23);
            this.tbValue.TabIndex = 47;
            this.tbValue.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAdd.Location = new System.Drawing.Point(84, 274);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(139, 40);
            this.btnAdd.TabIndex = 46;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "변경";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(69, 12);
            this.lblTitle.TabIndex = 47;
            this.lblTitle.Text = "내기기 설정";
            // 
            // lblLocalMode
            // 
            this.lblLocalMode.AutoSize = true;
            this.lblLocalMode.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLocalMode.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblLocalMode.Location = new System.Drawing.Point(663, 41);
            this.lblLocalMode.Name = "lblLocalMode";
            this.lblLocalMode.Size = new System.Drawing.Size(67, 14);
            this.lblLocalMode.TabIndex = 48;
            this.lblLocalMode.Text = "로컬모드";
            // 
            // ischange
            // 
            this.ischange.Text = "";
            this.ischange.Width = 50;
            // 
            // memo
            // 
            this.memo.Text = "";
            this.memo.Width = 0;
            // 
            // frmSetupPos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(850, 700);
            this.Controls.Add(this.lblLocalMode);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lvwList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSetupPos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSetupPos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader value;
        private System.Windows.Forms.ColumnHeader change;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblNameTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblValueTitle;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblValueTitle2;
        private System.Windows.Forms.Label lblPosNoTitle;
        private System.Windows.Forms.Label lblPosNo;
        private System.Windows.Forms.Label lblSiteName;
        private System.Windows.Forms.Label lblSiteNameTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbValue;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLocalMode;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Label lblMemo;
        private System.Windows.Forms.ColumnHeader ischange;
        private System.Windows.Forms.ColumnHeader memo;
    }
}