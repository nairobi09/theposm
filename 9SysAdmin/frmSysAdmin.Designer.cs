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
            this.btnPosMac = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.panelView = new System.Windows.Forms.Panel();
            this.panelCertConsole = new System.Windows.Forms.Panel();
            this.btnSysPayConsole = new System.Windows.Forms.Button();
            this.btnSysGoodsLayout = new System.Windows.Forms.Button();
            this.btnSysGoods = new System.Windows.Forms.Button();
            this.btnSysGoodsGroup = new System.Windows.Forms.Button();
            this.btnPos = new System.Windows.Forms.Button();
            this.btnSysShop = new System.Windows.Forms.Button();
            this.panelCertConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPosMac
            // 
            this.btnPosMac.BackColor = System.Drawing.Color.LightGray;
            this.btnPosMac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPosMac.ForeColor = System.Drawing.Color.Red;
            this.btnPosMac.Location = new System.Drawing.Point(7, 395);
            this.btnPosMac.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPosMac.Name = "btnPosMac";
            this.btnPosMac.Size = new System.Drawing.Size(112, 62);
            this.btnPosMac.TabIndex = 0;
            this.btnPosMac.TabStop = false;
            this.btnPosMac.Text = "포스기기\r\n인증";
            this.btnPosMac.UseVisualStyleBackColor = false;
            this.btnPosMac.Click += new System.EventHandler(this.btnPosMac_Click);
            // 
            // btnUser
            // 
            this.btnUser.BackColor = System.Drawing.Color.LightGray;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.ForeColor = System.Drawing.Color.Red;
            this.btnUser.Location = new System.Drawing.Point(7, 464);
            this.btnUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(112, 62);
            this.btnUser.TabIndex = 0;
            this.btnUser.TabStop = false;
            this.btnUser.Text = "사용자인증";
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
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
            // panelCertConsole
            // 
            this.panelCertConsole.Controls.Add(this.btnSysShop);
            this.panelCertConsole.Controls.Add(this.btnPosMac);
            this.panelCertConsole.Controls.Add(this.btnSysPayConsole);
            this.panelCertConsole.Controls.Add(this.btnSysGoodsLayout);
            this.panelCertConsole.Controls.Add(this.btnSysGoods);
            this.panelCertConsole.Controls.Add(this.btnSysGoodsGroup);
            this.panelCertConsole.Controls.Add(this.btnUser);
            this.panelCertConsole.Location = new System.Drawing.Point(1, 92);
            this.panelCertConsole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelCertConsole.Name = "panelCertConsole";
            this.panelCertConsole.Size = new System.Drawing.Size(123, 599);
            this.panelCertConsole.TabIndex = 2;
            this.panelCertConsole.Visible = false;
            // 
            // btnSysPayConsole
            // 
            this.btnSysPayConsole.BackColor = System.Drawing.Color.LightGray;
            this.btnSysPayConsole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysPayConsole.Location = new System.Drawing.Point(7, 309);
            this.btnSysPayConsole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysPayConsole.Name = "btnSysPayConsole";
            this.btnSysPayConsole.Size = new System.Drawing.Size(112, 62);
            this.btnSysPayConsole.TabIndex = 0;
            this.btnSysPayConsole.TabStop = false;
            this.btnSysPayConsole.Text = "결제버튼배치";
            this.btnSysPayConsole.UseVisualStyleBackColor = false;
            this.btnSysPayConsole.Click += new System.EventHandler(this.btnSysPayConsole_Click);
            // 
            // btnSysGoodsLayout
            // 
            this.btnSysGoodsLayout.BackColor = System.Drawing.Color.LightGray;
            this.btnSysGoodsLayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysGoodsLayout.Location = new System.Drawing.Point(7, 225);
            this.btnSysGoodsLayout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysGoodsLayout.Name = "btnSysGoodsLayout";
            this.btnSysGoodsLayout.Size = new System.Drawing.Size(112, 62);
            this.btnSysGoodsLayout.TabIndex = 0;
            this.btnSysGoodsLayout.TabStop = false;
            this.btnSysGoodsLayout.Text = "상품배치";
            this.btnSysGoodsLayout.UseVisualStyleBackColor = false;
            this.btnSysGoodsLayout.Click += new System.EventHandler(this.btnSysGoodsItem_Click);
            // 
            // btnSysGoods
            // 
            this.btnSysGoods.BackColor = System.Drawing.Color.LightGray;
            this.btnSysGoods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysGoods.Location = new System.Drawing.Point(7, 89);
            this.btnSysGoods.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysGoods.Name = "btnSysGoods";
            this.btnSysGoods.Size = new System.Drawing.Size(112, 62);
            this.btnSysGoods.TabIndex = 0;
            this.btnSysGoods.TabStop = false;
            this.btnSysGoods.Text = "기초상품\r\n관리";
            this.btnSysGoods.UseVisualStyleBackColor = false;
            this.btnSysGoods.Click += new System.EventHandler(this.btnSysGoods_Click);
            // 
            // btnSysGoodsGroup
            // 
            this.btnSysGoodsGroup.BackColor = System.Drawing.Color.LightGray;
            this.btnSysGoodsGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysGoodsGroup.Location = new System.Drawing.Point(7, 157);
            this.btnSysGoodsGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysGoodsGroup.Name = "btnSysGoodsGroup";
            this.btnSysGoodsGroup.Size = new System.Drawing.Size(112, 62);
            this.btnSysGoodsGroup.TabIndex = 0;
            this.btnSysGoodsGroup.TabStop = false;
            this.btnSysGoodsGroup.Text = "상품그룹";
            this.btnSysGoodsGroup.UseVisualStyleBackColor = false;
            this.btnSysGoodsGroup.Click += new System.EventHandler(this.btnSysGoodsGroup_Click);
            // 
            // btnPos
            // 
            this.btnPos.BackColor = System.Drawing.Color.LightGray;
            this.btnPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPos.Location = new System.Drawing.Point(7, 11);
            this.btnPos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPos.Name = "btnPos";
            this.btnPos.Size = new System.Drawing.Size(112, 62);
            this.btnPos.TabIndex = 0;
            this.btnPos.TabStop = false;
            this.btnPos.Text = "포스기기\r\n등록신청";
            this.btnPos.UseVisualStyleBackColor = false;
            this.btnPos.Click += new System.EventHandler(this.btnPos_Click);
            // 
            // btnSysShop
            // 
            this.btnSysShop.BackColor = System.Drawing.Color.LightGray;
            this.btnSysShop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysShop.Location = new System.Drawing.Point(6, 4);
            this.btnSysShop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSysShop.Name = "btnSysShop";
            this.btnSysShop.Size = new System.Drawing.Size(112, 62);
            this.btnSysShop.TabIndex = 1;
            this.btnSysShop.TabStop = false;
            this.btnSysShop.Text = "샵관리";
            this.btnSysShop.UseVisualStyleBackColor = false;
            // 
            // frmSysAdmin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.btnPos);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.panelCertConsole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSysAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "thepos Admin";
            this.panelCertConsole.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPosMac;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.Panel panelCertConsole;
        private System.Windows.Forms.Button btnPos;
        private System.Windows.Forms.Button btnSysGoodsGroup;
        private System.Windows.Forms.Button btnSysGoods;
        private System.Windows.Forms.Button btnSysGoodsLayout;
        private System.Windows.Forms.Button btnSysPayConsole;
        private System.Windows.Forms.Button btnSysShop;
    }
}