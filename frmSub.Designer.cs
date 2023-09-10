namespace thepos
{
    partial class frmSub
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
            this.panelOrderSumBlack = new System.Windows.Forms.Panel();
            this.lblOrderAmountRest = new System.Windows.Forms.Label();
            this.lblOrderAmountReceive = new System.Windows.Forms.Label();
            this.lblOrderAmountNet = new System.Windows.Forms.Label();
            this.lblOrderAmountDC = new System.Windows.Forms.Label();
            this.lblOrderAmount = new System.Windows.Forms.Label();
            this.lblOrderAmountRestTitle = new System.Windows.Forms.Label();
            this.lblOrderAmountReceiveTitle = new System.Windows.Forms.Label();
            this.lblOrderAmountChargeTitle = new System.Windows.Forms.Label();
            this.lblOrderAmountDCTitle = new System.Windows.Forms.Label();
            this.lblOrderAmountSumTitle = new System.Windows.Forms.Label();
            this.panelOrderInfo = new System.Windows.Forms.Panel();
            this.panel_in_0 = new System.Windows.Forms.Panel();
            this.lblSiteAlias = new System.Windows.Forms.Label();
            this.lblSiteName = new System.Windows.Forms.Label();
            this.lvwOrderItem = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dc_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.net_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelOrderSumBlack.SuspendLayout();
            this.panelOrderInfo.SuspendLayout();
            this.panel_in_0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelOrderSumBlack
            // 
            this.panelOrderSumBlack.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelOrderSumBlack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOrderSumBlack.Controls.Add(this.lblOrderAmountRest);
            this.panelOrderSumBlack.Controls.Add(this.lblOrderAmountReceive);
            this.panelOrderSumBlack.Controls.Add(this.lblOrderAmountNet);
            this.panelOrderSumBlack.Controls.Add(this.lblOrderAmountDC);
            this.panelOrderSumBlack.Controls.Add(this.lblOrderAmount);
            this.panelOrderSumBlack.Controls.Add(this.lblOrderAmountRestTitle);
            this.panelOrderSumBlack.Controls.Add(this.lblOrderAmountReceiveTitle);
            this.panelOrderSumBlack.Controls.Add(this.lblOrderAmountChargeTitle);
            this.panelOrderSumBlack.Controls.Add(this.lblOrderAmountDCTitle);
            this.panelOrderSumBlack.Controls.Add(this.lblOrderAmountSumTitle);
            this.panelOrderSumBlack.Location = new System.Drawing.Point(674, 274);
            this.panelOrderSumBlack.Name = "panelOrderSumBlack";
            this.panelOrderSumBlack.Size = new System.Drawing.Size(343, 489);
            this.panelOrderSumBlack.TabIndex = 2;
            // 
            // lblOrderAmountRest
            // 
            this.lblOrderAmountRest.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountRest.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblOrderAmountRest.Location = new System.Drawing.Point(151, 297);
            this.lblOrderAmountRest.Name = "lblOrderAmountRest";
            this.lblOrderAmountRest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmountRest.Size = new System.Drawing.Size(153, 34);
            this.lblOrderAmountRest.TabIndex = 1;
            this.lblOrderAmountRest.Text = "0";
            // 
            // lblOrderAmountReceive
            // 
            this.lblOrderAmountReceive.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountReceive.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountReceive.Location = new System.Drawing.Point(151, 244);
            this.lblOrderAmountReceive.Name = "lblOrderAmountReceive";
            this.lblOrderAmountReceive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmountReceive.Size = new System.Drawing.Size(154, 34);
            this.lblOrderAmountReceive.TabIndex = 1;
            this.lblOrderAmountReceive.Text = "0";
            // 
            // lblOrderAmountNet
            // 
            this.lblOrderAmountNet.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountNet.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblOrderAmountNet.Location = new System.Drawing.Point(151, 190);
            this.lblOrderAmountNet.Name = "lblOrderAmountNet";
            this.lblOrderAmountNet.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmountNet.Size = new System.Drawing.Size(154, 34);
            this.lblOrderAmountNet.TabIndex = 1;
            this.lblOrderAmountNet.Text = "0";
            // 
            // lblOrderAmountDC
            // 
            this.lblOrderAmountDC.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountDC.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountDC.Location = new System.Drawing.Point(151, 134);
            this.lblOrderAmountDC.Name = "lblOrderAmountDC";
            this.lblOrderAmountDC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmountDC.Size = new System.Drawing.Size(154, 34);
            this.lblOrderAmountDC.TabIndex = 1;
            this.lblOrderAmountDC.Text = "0";
            // 
            // lblOrderAmount
            // 
            this.lblOrderAmount.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmount.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmount.Location = new System.Drawing.Point(151, 75);
            this.lblOrderAmount.Name = "lblOrderAmount";
            this.lblOrderAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmount.Size = new System.Drawing.Size(154, 34);
            this.lblOrderAmount.TabIndex = 1;
            this.lblOrderAmount.Text = "0";
            // 
            // lblOrderAmountRestTitle
            // 
            this.lblOrderAmountRestTitle.AutoSize = true;
            this.lblOrderAmountRestTitle.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountRestTitle.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblOrderAmountRestTitle.Location = new System.Drawing.Point(23, 301);
            this.lblOrderAmountRestTitle.Name = "lblOrderAmountRestTitle";
            this.lblOrderAmountRestTitle.Size = new System.Drawing.Size(124, 27);
            this.lblOrderAmountRestTitle.TabIndex = 0;
            this.lblOrderAmountRestTitle.Text = "반환금액";
            // 
            // lblOrderAmountReceiveTitle
            // 
            this.lblOrderAmountReceiveTitle.AutoSize = true;
            this.lblOrderAmountReceiveTitle.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountReceiveTitle.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountReceiveTitle.Location = new System.Drawing.Point(25, 248);
            this.lblOrderAmountReceiveTitle.Name = "lblOrderAmountReceiveTitle";
            this.lblOrderAmountReceiveTitle.Size = new System.Drawing.Size(124, 27);
            this.lblOrderAmountReceiveTitle.TabIndex = 0;
            this.lblOrderAmountReceiveTitle.Text = "받은금액";
            // 
            // lblOrderAmountChargeTitle
            // 
            this.lblOrderAmountChargeTitle.AutoSize = true;
            this.lblOrderAmountChargeTitle.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountChargeTitle.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblOrderAmountChargeTitle.Location = new System.Drawing.Point(25, 194);
            this.lblOrderAmountChargeTitle.Name = "lblOrderAmountChargeTitle";
            this.lblOrderAmountChargeTitle.Size = new System.Drawing.Size(124, 27);
            this.lblOrderAmountChargeTitle.TabIndex = 0;
            this.lblOrderAmountChargeTitle.Text = "받을금액";
            // 
            // lblOrderAmountDCTitle
            // 
            this.lblOrderAmountDCTitle.AutoSize = true;
            this.lblOrderAmountDCTitle.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountDCTitle.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountDCTitle.Location = new System.Drawing.Point(25, 138);
            this.lblOrderAmountDCTitle.Name = "lblOrderAmountDCTitle";
            this.lblOrderAmountDCTitle.Size = new System.Drawing.Size(124, 27);
            this.lblOrderAmountDCTitle.TabIndex = 0;
            this.lblOrderAmountDCTitle.Text = "할인금액";
            // 
            // lblOrderAmountSumTitle
            // 
            this.lblOrderAmountSumTitle.AutoSize = true;
            this.lblOrderAmountSumTitle.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountSumTitle.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountSumTitle.Location = new System.Drawing.Point(25, 79);
            this.lblOrderAmountSumTitle.Name = "lblOrderAmountSumTitle";
            this.lblOrderAmountSumTitle.Size = new System.Drawing.Size(124, 27);
            this.lblOrderAmountSumTitle.TabIndex = 0;
            this.lblOrderAmountSumTitle.Text = "합계금액";
            // 
            // panelOrderInfo
            // 
            this.panelOrderInfo.BackColor = System.Drawing.Color.GhostWhite;
            this.panelOrderInfo.Controls.Add(this.panel_in_0);
            this.panelOrderInfo.Controls.Add(this.lvwOrderItem);
            this.panelOrderInfo.Controls.Add(this.panelOrderSumBlack);
            this.panelOrderInfo.Location = new System.Drawing.Point(1, 1);
            this.panelOrderInfo.Name = "panelOrderInfo";
            this.panelOrderInfo.Size = new System.Drawing.Size(1022, 766);
            this.panelOrderInfo.TabIndex = 39;
            this.panelOrderInfo.Visible = false;
            // 
            // panel_in_0
            // 
            this.panel_in_0.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel_in_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_in_0.Controls.Add(this.lblSiteAlias);
            this.panel_in_0.Controls.Add(this.lblSiteName);
            this.panel_in_0.Location = new System.Drawing.Point(674, 4);
            this.panel_in_0.Name = "panel_in_0";
            this.panel_in_0.Size = new System.Drawing.Size(343, 264);
            this.panel_in_0.TabIndex = 40;
            // 
            // lblSiteAlias
            // 
            this.lblSiteAlias.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSiteAlias.ForeColor = System.Drawing.Color.Black;
            this.lblSiteAlias.Location = new System.Drawing.Point(19, 83);
            this.lblSiteAlias.Name = "lblSiteAlias";
            this.lblSiteAlias.Size = new System.Drawing.Size(297, 33);
            this.lblSiteAlias.TabIndex = 3;
            this.lblSiteAlias.Text = "___";
            this.lblSiteAlias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSiteName
            // 
            this.lblSiteName.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSiteName.ForeColor = System.Drawing.Color.Black;
            this.lblSiteName.Location = new System.Drawing.Point(22, 137);
            this.lblSiteName.Name = "lblSiteName";
            this.lblSiteName.Size = new System.Drawing.Size(294, 27);
            this.lblSiteName.TabIndex = 3;
            this.lblSiteName.Text = "___";
            this.lblSiteName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvwOrderItem
            // 
            this.lvwOrderItem.BackColor = System.Drawing.Color.GhostWhite;
            this.lvwOrderItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.name,
            this.amt,
            this.cnt,
            this.dc_amount,
            this.net_amount});
            this.lvwOrderItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwOrderItem.ForeColor = System.Drawing.Color.OrangeRed;
            this.lvwOrderItem.FullRowSelect = true;
            this.lvwOrderItem.GridLines = true;
            this.lvwOrderItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwOrderItem.HideSelection = false;
            this.lvwOrderItem.Location = new System.Drawing.Point(4, 4);
            this.lvwOrderItem.MultiSelect = false;
            this.lvwOrderItem.Name = "lvwOrderItem";
            this.lvwOrderItem.Size = new System.Drawing.Size(665, 758);
            this.lvwOrderItem.TabIndex = 39;
            this.lvwOrderItem.TabStop = false;
            this.lvwOrderItem.UseCompatibleStateImageBehavior = false;
            this.lvwOrderItem.View = System.Windows.Forms.View.Details;
            // 
            // no
            // 
            this.no.Text = "#";
            this.no.Width = 30;
            // 
            // name
            // 
            this.name.Text = "상품명";
            this.name.Width = 160;
            // 
            // amt
            // 
            this.amt.Text = "단가";
            this.amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amt.Width = 120;
            // 
            // cnt
            // 
            this.cnt.Text = "수량";
            this.cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cnt.Width = 80;
            // 
            // dc_amount
            // 
            this.dc_amount.Text = "할인";
            this.dc_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dc_amount.Width = 120;
            // 
            // net_amount
            // 
            this.net_amount.Text = "금액";
            this.net_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.net_amount.Width = 120;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::thepos.Properties.Resources.thepos;
            this.pictureBox1.Location = new System.Drawing.Point(319, 330);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(386, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // frmSub
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.panelOrderInfo);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSub";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmSub";
            this.panelOrderSumBlack.ResumeLayout(false);
            this.panelOrderSumBlack.PerformLayout();
            this.panelOrderInfo.ResumeLayout(false);
            this.panel_in_0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelOrderSumBlack;
        private System.Windows.Forms.Label lblOrderAmountRest;
        private System.Windows.Forms.Label lblOrderAmountReceive;
        private System.Windows.Forms.Label lblOrderAmountNet;
        private System.Windows.Forms.Label lblOrderAmountDC;
        private System.Windows.Forms.Label lblOrderAmount;
        private System.Windows.Forms.Label lblOrderAmountRestTitle;
        private System.Windows.Forms.Label lblOrderAmountReceiveTitle;
        private System.Windows.Forms.Label lblOrderAmountChargeTitle;
        private System.Windows.Forms.Label lblOrderAmountDCTitle;
        private System.Windows.Forms.Label lblOrderAmountSumTitle;
        private System.Windows.Forms.Panel panelOrderInfo;
        private System.Windows.Forms.ListView lvwOrderItem;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader amt;
        private System.Windows.Forms.ColumnHeader cnt;
        private System.Windows.Forms.ColumnHeader dc_amount;
        private System.Windows.Forms.ColumnHeader net_amount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel_in_0;
        private System.Windows.Forms.Label lblSiteAlias;
        private System.Windows.Forms.Label lblSiteName;
    }
}