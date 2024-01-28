namespace thepos
{
    partial class frmSysAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysAdmin));
            this.panelView = new System.Windows.Forms.Panel();
            this.panelAdminConsole = new System.Windows.Forms.Panel();
            this.btnSysOption = new System.Windows.Forms.Button();
            this.btnSysSoldout = new System.Windows.Forms.Button();
            this.btnSysGoodsItem2 = new System.Windows.Forms.Button();
            this.btnSysGoodsGroup2 = new System.Windows.Forms.Button();
            this.btnDcrFavorite = new System.Windows.Forms.Button();
            this.btnSysSite = new System.Windows.Forms.Button();
            this.btnSysShop = new System.Windows.Forms.Button();
            this.btnSysPayConsole = new System.Windows.Forms.Button();
            this.btnSysGoodsItem = new System.Windows.Forms.Button();
            this.btnSysGoods = new System.Windows.Forms.Button();
            this.btnSysGoodsGroup = new System.Windows.Forms.Button();
            this.btnPos = new System.Windows.Forms.Button();
            this.panelCertConsole = new System.Windows.Forms.Panel();
            this.btnPosMac = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.panelAdminConsole.SuspendLayout();
            this.panelCertConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelView
            // 
            this.panelView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelView.Location = new System.Drawing.Point(130, 10);
            this.panelView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(870, 710);
            this.panelView.TabIndex = 1;
            // 
            // panelAdminConsole
            // 
            this.panelAdminConsole.Controls.Add(this.btnSysOption);
            this.panelAdminConsole.Controls.Add(this.btnSysSoldout);
            this.panelAdminConsole.Controls.Add(this.btnSysGoodsItem2);
            this.panelAdminConsole.Controls.Add(this.btnSysGoodsGroup2);
            this.panelAdminConsole.Controls.Add(this.btnDcrFavorite);
            this.panelAdminConsole.Controls.Add(this.btnSysSite);
            this.panelAdminConsole.Controls.Add(this.btnSysShop);
            this.panelAdminConsole.Controls.Add(this.btnSysPayConsole);
            this.panelAdminConsole.Controls.Add(this.btnSysGoodsItem);
            this.panelAdminConsole.Controls.Add(this.btnSysGoods);
            this.panelAdminConsole.Controls.Add(this.btnSysGoodsGroup);
            this.panelAdminConsole.Font = new System.Drawing.Font("굴림", 10F);
            this.panelAdminConsole.Location = new System.Drawing.Point(0, 70);
            this.panelAdminConsole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelAdminConsole.Name = "panelAdminConsole";
            this.panelAdminConsole.Size = new System.Drawing.Size(123, 558);
            this.panelAdminConsole.TabIndex = 2;
            this.panelAdminConsole.Visible = false;
            // 
            // btnSysOption
            // 
            this.btnSysOption.BackColor = System.Drawing.Color.White;
            this.btnSysOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysOption.Location = new System.Drawing.Point(7, 141);
            this.btnSysOption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysOption.Name = "btnSysOption";
            this.btnSysOption.Size = new System.Drawing.Size(112, 40);
            this.btnSysOption.TabIndex = 7;
            this.btnSysOption.TabStop = false;
            this.btnSysOption.Text = "상품옵션";
            this.btnSysOption.UseVisualStyleBackColor = false;
            this.btnSysOption.Click += new System.EventHandler(this.btnSysOption_Click);
            // 
            // btnSysSoldout
            // 
            this.btnSysSoldout.BackColor = System.Drawing.Color.White;
            this.btnSysSoldout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysSoldout.Location = new System.Drawing.Point(7, 424);
            this.btnSysSoldout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysSoldout.Name = "btnSysSoldout";
            this.btnSysSoldout.Size = new System.Drawing.Size(112, 50);
            this.btnSysSoldout.TabIndex = 6;
            this.btnSysSoldout.TabStop = false;
            this.btnSysSoldout.Text = "품절";
            this.btnSysSoldout.UseVisualStyleBackColor = false;
            this.btnSysSoldout.Click += new System.EventHandler(this.btnSoldout_Click);
            // 
            // btnSysGoodsItem2
            // 
            this.btnSysGoodsItem2.BackColor = System.Drawing.Color.White;
            this.btnSysGoodsItem2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysGoodsItem2.Location = new System.Drawing.Point(7, 362);
            this.btnSysGoodsItem2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysGoodsItem2.Name = "btnSysGoodsItem2";
            this.btnSysGoodsItem2.Size = new System.Drawing.Size(112, 50);
            this.btnSysGoodsItem2.TabIndex = 5;
            this.btnSysGoodsItem2.TabStop = false;
            this.btnSysGoodsItem2.Text = "상품배치\r\n(KIOSK)";
            this.btnSysGoodsItem2.UseVisualStyleBackColor = false;
            this.btnSysGoodsItem2.Click += new System.EventHandler(this.btnSysGoodsItem2_Click);
            // 
            // btnSysGoodsGroup2
            // 
            this.btnSysGoodsGroup2.BackColor = System.Drawing.Color.White;
            this.btnSysGoodsGroup2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysGoodsGroup2.Location = new System.Drawing.Point(7, 247);
            this.btnSysGoodsGroup2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSysGoodsGroup2.Name = "btnSysGoodsGroup2";
            this.btnSysGoodsGroup2.Size = new System.Drawing.Size(112, 50);
            this.btnSysGoodsGroup2.TabIndex = 4;
            this.btnSysGoodsGroup2.TabStop = false;
            this.btnSysGoodsGroup2.Text = "상품그룹\r\n(KIOSK)";
            this.btnSysGoodsGroup2.UseVisualStyleBackColor = false;
            this.btnSysGoodsGroup2.Click += new System.EventHandler(this.btnSysGoodsGroup2_Click);
            // 
            // btnDcrFavorite
            // 
            this.btnDcrFavorite.BackColor = System.Drawing.Color.White;
            this.btnDcrFavorite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDcrFavorite.Location = new System.Drawing.Point(7, 485);
            this.btnDcrFavorite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDcrFavorite.Name = "btnDcrFavorite";
            this.btnDcrFavorite.Size = new System.Drawing.Size(112, 30);
            this.btnDcrFavorite.TabIndex = 3;
            this.btnDcrFavorite.TabStop = false;
            this.btnDcrFavorite.Text = "할인즐겨찾기";
            this.btnDcrFavorite.UseVisualStyleBackColor = false;
            this.btnDcrFavorite.Click += new System.EventHandler(this.btnDcrFavorite_Click);
            // 
            // btnSysSite
            // 
            this.btnSysSite.BackColor = System.Drawing.Color.White;
            this.btnSysSite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysSite.Location = new System.Drawing.Point(7, 0);
            this.btnSysSite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysSite.Name = "btnSysSite";
            this.btnSysSite.Size = new System.Drawing.Size(112, 30);
            this.btnSysSite.TabIndex = 2;
            this.btnSysSite.TabStop = false;
            this.btnSysSite.Text = "사업장\r\n";
            this.btnSysSite.UseVisualStyleBackColor = false;
            this.btnSysSite.Click += new System.EventHandler(this.btnSysSite_Click);
            // 
            // btnSysShop
            // 
            this.btnSysShop.BackColor = System.Drawing.Color.White;
            this.btnSysShop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysShop.Location = new System.Drawing.Point(7, 38);
            this.btnSysShop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysShop.Name = "btnSysShop";
            this.btnSysShop.Size = new System.Drawing.Size(112, 40);
            this.btnSysShop.TabIndex = 1;
            this.btnSysShop.TabStop = false;
            this.btnSysShop.Text = "업장";
            this.btnSysShop.UseVisualStyleBackColor = false;
            this.btnSysShop.Click += new System.EventHandler(this.btnSysShop_Click);
            // 
            // btnSysPayConsole
            // 
            this.btnSysPayConsole.BackColor = System.Drawing.Color.White;
            this.btnSysPayConsole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysPayConsole.Location = new System.Drawing.Point(7, 523);
            this.btnSysPayConsole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysPayConsole.Name = "btnSysPayConsole";
            this.btnSysPayConsole.Size = new System.Drawing.Size(112, 30);
            this.btnSysPayConsole.TabIndex = 0;
            this.btnSysPayConsole.TabStop = false;
            this.btnSysPayConsole.Text = "결제버튼배치";
            this.btnSysPayConsole.UseVisualStyleBackColor = false;
            this.btnSysPayConsole.Click += new System.EventHandler(this.btnSysPayConsole_Click);
            // 
            // btnSysGoodsItem
            // 
            this.btnSysGoodsItem.BackColor = System.Drawing.Color.White;
            this.btnSysGoodsItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysGoodsItem.Location = new System.Drawing.Point(7, 309);
            this.btnSysGoodsItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysGoodsItem.Name = "btnSysGoodsItem";
            this.btnSysGoodsItem.Size = new System.Drawing.Size(112, 50);
            this.btnSysGoodsItem.TabIndex = 0;
            this.btnSysGoodsItem.TabStop = false;
            this.btnSysGoodsItem.Text = "상품배치\r\n(POS)";
            this.btnSysGoodsItem.UseVisualStyleBackColor = false;
            this.btnSysGoodsItem.Click += new System.EventHandler(this.btnSysGoodsItem_Click);
            // 
            // btnSysGoods
            // 
            this.btnSysGoods.BackColor = System.Drawing.Color.White;
            this.btnSysGoods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysGoods.Location = new System.Drawing.Point(7, 88);
            this.btnSysGoods.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysGoods.Name = "btnSysGoods";
            this.btnSysGoods.Size = new System.Drawing.Size(112, 50);
            this.btnSysGoods.TabIndex = 0;
            this.btnSysGoods.TabStop = false;
            this.btnSysGoods.Text = "기초상품";
            this.btnSysGoods.UseVisualStyleBackColor = false;
            this.btnSysGoods.Click += new System.EventHandler(this.btnSysGoods_Click);
            // 
            // btnSysGoodsGroup
            // 
            this.btnSysGoodsGroup.BackColor = System.Drawing.Color.White;
            this.btnSysGoodsGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysGoodsGroup.Location = new System.Drawing.Point(7, 194);
            this.btnSysGoodsGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysGoodsGroup.Name = "btnSysGoodsGroup";
            this.btnSysGoodsGroup.Size = new System.Drawing.Size(112, 50);
            this.btnSysGoodsGroup.TabIndex = 0;
            this.btnSysGoodsGroup.TabStop = false;
            this.btnSysGoodsGroup.Text = "상품그룹\r\n(POS)";
            this.btnSysGoodsGroup.UseVisualStyleBackColor = false;
            this.btnSysGoodsGroup.Click += new System.EventHandler(this.btnSysGoodsGroup_Click);
            // 
            // btnPos
            // 
            this.btnPos.BackColor = System.Drawing.Color.White;
            this.btnPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPos.Font = new System.Drawing.Font("굴림", 10F);
            this.btnPos.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnPos.Location = new System.Drawing.Point(7, 10);
            this.btnPos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPos.Name = "btnPos";
            this.btnPos.Size = new System.Drawing.Size(112, 50);
            this.btnPos.TabIndex = 0;
            this.btnPos.TabStop = false;
            this.btnPos.Text = "기기등록신청";
            this.btnPos.UseVisualStyleBackColor = false;
            this.btnPos.Click += new System.EventHandler(this.btnPos_Click);
            // 
            // panelCertConsole
            // 
            this.panelCertConsole.Controls.Add(this.btnPosMac);
            this.panelCertConsole.Controls.Add(this.btnUser);
            this.panelCertConsole.Font = new System.Drawing.Font("굴림", 10F);
            this.panelCertConsole.Location = new System.Drawing.Point(0, 639);
            this.panelCertConsole.Name = "panelCertConsole";
            this.panelCertConsole.Size = new System.Drawing.Size(122, 68);
            this.panelCertConsole.TabIndex = 3;
            this.panelCertConsole.Visible = false;
            // 
            // btnPosMac
            // 
            this.btnPosMac.BackColor = System.Drawing.Color.White;
            this.btnPosMac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPosMac.ForeColor = System.Drawing.Color.Red;
            this.btnPosMac.Location = new System.Drawing.Point(7, 0);
            this.btnPosMac.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPosMac.Name = "btnPosMac";
            this.btnPosMac.Size = new System.Drawing.Size(112, 30);
            this.btnPosMac.TabIndex = 1;
            this.btnPosMac.TabStop = false;
            this.btnPosMac.Text = "포스기기인증";
            this.btnPosMac.UseVisualStyleBackColor = false;
            this.btnPosMac.Click += new System.EventHandler(this.btnPosMac_Click);
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.White;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.ForeColor = System.Drawing.Color.Red;
            this.btnUser.Location = new System.Drawing.Point(7, 33);
            this.btnUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(112, 30);
            this.btnUser.TabIndex = 2;
            this.btnUser.TabStop = false;
            this.btnUser.Text = "사용자인증";
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // frmSysAdmin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panelCertConsole);
            this.Controls.Add(this.btnPos);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.panelAdminConsole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSysAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "사용자어드민";
            this.panelAdminConsole.ResumeLayout(false);
            this.panelCertConsole.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.Panel panelAdminConsole;
        private System.Windows.Forms.Button btnPos;
        private System.Windows.Forms.Button btnSysGoodsGroup;
        private System.Windows.Forms.Button btnSysGoods;
        private System.Windows.Forms.Button btnSysGoodsItem;
        private System.Windows.Forms.Button btnSysPayConsole;
        private System.Windows.Forms.Button btnSysShop;
        private System.Windows.Forms.Button btnSysSite;
        private System.Windows.Forms.Panel panelCertConsole;
        private System.Windows.Forms.Button btnPosMac;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnDcrFavorite;
        private System.Windows.Forms.Button btnSysGoodsItem2;
        private System.Windows.Forms.Button btnSysGoodsGroup2;
        private System.Windows.Forms.Button btnSysSoldout;
        private System.Windows.Forms.Button btnSysOption;
    }
}