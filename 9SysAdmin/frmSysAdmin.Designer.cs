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
            this.panelCertConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPosMac
            // 
            this.btnPosMac.BackColor = System.Drawing.Color.LightGray;
            this.btnPosMac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPosMac.Location = new System.Drawing.Point(6, 255);
            this.btnPosMac.Name = "btnPosMac";
            this.btnPosMac.Size = new System.Drawing.Size(100, 50);
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
            this.btnUser.Location = new System.Drawing.Point(6, 309);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(100, 50);
            this.btnUser.TabIndex = 0;
            this.btnUser.TabStop = false;
            this.btnUser.Text = "사용자인증";
            this.btnUser.UseVisualStyleBackColor = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // panelView
            // 
            this.panelView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelView.Location = new System.Drawing.Point(114, 5);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(890, 720);
            this.panelView.TabIndex = 1;
            // 
            // panelCertConsole
            // 
            this.panelCertConsole.Controls.Add(this.btnPosMac);
            this.panelCertConsole.Controls.Add(this.btnSysPayConsole);
            this.panelCertConsole.Controls.Add(this.btnSysGoodsLayout);
            this.panelCertConsole.Controls.Add(this.btnSysGoods);
            this.panelCertConsole.Controls.Add(this.btnSysGoodsGroup);
            this.panelCertConsole.Controls.Add(this.btnUser);
            this.panelCertConsole.Location = new System.Drawing.Point(1, 75);
            this.panelCertConsole.Name = "panelCertConsole";
            this.panelCertConsole.Size = new System.Drawing.Size(110, 403);
            this.panelCertConsole.TabIndex = 2;
            this.panelCertConsole.Visible = false;
            // 
            // btnSysPayConsole
            // 
            this.btnSysPayConsole.BackColor = System.Drawing.Color.LightGray;
            this.btnSysPayConsole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysPayConsole.Location = new System.Drawing.Point(6, 179);
            this.btnSysPayConsole.Name = "btnSysPayConsole";
            this.btnSysPayConsole.Size = new System.Drawing.Size(100, 50);
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
            this.btnSysGoodsLayout.Location = new System.Drawing.Point(6, 113);
            this.btnSysGoodsLayout.Name = "btnSysGoodsLayout";
            this.btnSysGoodsLayout.Size = new System.Drawing.Size(100, 50);
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
            this.btnSysGoods.Location = new System.Drawing.Point(6, 3);
            this.btnSysGoods.Name = "btnSysGoods";
            this.btnSysGoods.Size = new System.Drawing.Size(100, 50);
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
            this.btnSysGoodsGroup.Location = new System.Drawing.Point(6, 58);
            this.btnSysGoodsGroup.Name = "btnSysGoodsGroup";
            this.btnSysGoodsGroup.Size = new System.Drawing.Size(100, 50);
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
            this.btnPos.Location = new System.Drawing.Point(6, 9);
            this.btnPos.Name = "btnPos";
            this.btnPos.Size = new System.Drawing.Size(100, 50);
            this.btnPos.TabIndex = 0;
            this.btnPos.TabStop = false;
            this.btnPos.Text = "포스기기\r\n등록신청";
            this.btnPos.UseVisualStyleBackColor = false;
            this.btnPos.Click += new System.EventHandler(this.btnPos_Click);
            // 
            // frmSysAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.btnPos);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.panelCertConsole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
    }
}