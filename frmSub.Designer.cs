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
            this.lblOrderAmountNet = new System.Windows.Forms.Label();
            this.lblOrderAmountDC = new System.Windows.Forms.Label();
            this.lblOrderAmount = new System.Windows.Forms.Label();
            this.lblOrderAmountNetTitle = new System.Windows.Forms.Label();
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
            this.lblTitle1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOrderAmountReceive = new System.Windows.Forms.Label();
            this.lblOrderAmountReceiveTitle = new System.Windows.Forms.Label();
            this.lblOrderAmountRestTitle = new System.Windows.Forms.Label();
            this.lblOrderAmountRest = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panelOrderInfo.SuspendLayout();
            this.panel_in_0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOrderAmountNet
            // 
            this.lblOrderAmountNet.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountNet.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblOrderAmountNet.Location = new System.Drawing.Point(261, 22);
            this.lblOrderAmountNet.Name = "lblOrderAmountNet";
            this.lblOrderAmountNet.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmountNet.Size = new System.Drawing.Size(249, 34);
            this.lblOrderAmountNet.TabIndex = 1;
            this.lblOrderAmountNet.Text = "0";
            // 
            // lblOrderAmountDC
            // 
            this.lblOrderAmountDC.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountDC.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountDC.Location = new System.Drawing.Point(100, 16);
            this.lblOrderAmountDC.Name = "lblOrderAmountDC";
            this.lblOrderAmountDC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmountDC.Size = new System.Drawing.Size(129, 23);
            this.lblOrderAmountDC.TabIndex = 1;
            this.lblOrderAmountDC.Text = "0";
            // 
            // lblOrderAmount
            // 
            this.lblOrderAmount.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmount.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmount.Location = new System.Drawing.Point(99, 16);
            this.lblOrderAmount.Name = "lblOrderAmount";
            this.lblOrderAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmount.Size = new System.Drawing.Size(129, 23);
            this.lblOrderAmount.TabIndex = 1;
            this.lblOrderAmount.Text = "0";
            // 
            // lblOrderAmountNetTitle
            // 
            this.lblOrderAmountNetTitle.AutoSize = true;
            this.lblOrderAmountNetTitle.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountNetTitle.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblOrderAmountNetTitle.Location = new System.Drawing.Point(25, 24);
            this.lblOrderAmountNetTitle.Name = "lblOrderAmountNetTitle";
            this.lblOrderAmountNetTitle.Size = new System.Drawing.Size(124, 27);
            this.lblOrderAmountNetTitle.TabIndex = 0;
            this.lblOrderAmountNetTitle.Text = "내실금액";
            // 
            // lblOrderAmountDCTitle
            // 
            this.lblOrderAmountDCTitle.AutoSize = true;
            this.lblOrderAmountDCTitle.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountDCTitle.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountDCTitle.Location = new System.Drawing.Point(24, 16);
            this.lblOrderAmountDCTitle.Name = "lblOrderAmountDCTitle";
            this.lblOrderAmountDCTitle.Size = new System.Drawing.Size(47, 19);
            this.lblOrderAmountDCTitle.TabIndex = 0;
            this.lblOrderAmountDCTitle.Text = "할인";
            // 
            // lblOrderAmountSumTitle
            // 
            this.lblOrderAmountSumTitle.AutoSize = true;
            this.lblOrderAmountSumTitle.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountSumTitle.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountSumTitle.Location = new System.Drawing.Point(23, 17);
            this.lblOrderAmountSumTitle.Name = "lblOrderAmountSumTitle";
            this.lblOrderAmountSumTitle.Size = new System.Drawing.Size(47, 19);
            this.lblOrderAmountSumTitle.TabIndex = 0;
            this.lblOrderAmountSumTitle.Text = "합계";
            // 
            // panelOrderInfo
            // 
            this.panelOrderInfo.BackColor = System.Drawing.Color.Lavender;
            this.panelOrderInfo.Controls.Add(this.panel5);
            this.panelOrderInfo.Controls.Add(this.panel4);
            this.panelOrderInfo.Controls.Add(this.panel3);
            this.panelOrderInfo.Controls.Add(this.panel2);
            this.panelOrderInfo.Controls.Add(this.lblTitle1);
            this.panelOrderInfo.Controls.Add(this.panel_in_0);
            this.panelOrderInfo.Controls.Add(this.lvwOrderItem);
            this.panelOrderInfo.Controls.Add(this.panel1);
            this.panelOrderInfo.Location = new System.Drawing.Point(1, 1);
            this.panelOrderInfo.Name = "panelOrderInfo";
            this.panelOrderInfo.Size = new System.Drawing.Size(1022, 766);
            this.panelOrderInfo.TabIndex = 39;
            this.panelOrderInfo.Visible = false;
            // 
            // panel_in_0
            // 
            this.panel_in_0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.panel_in_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_in_0.Controls.Add(this.label2);
            this.panel_in_0.Controls.Add(this.lblSiteAlias);
            this.panel_in_0.Controls.Add(this.lblSiteName);
            this.panel_in_0.Location = new System.Drawing.Point(550, 33);
            this.panel_in_0.Name = "panel_in_0";
            this.panel_in_0.Size = new System.Drawing.Size(460, 700);
            this.panel_in_0.TabIndex = 40;
            // 
            // lblSiteAlias
            // 
            this.lblSiteAlias.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSiteAlias.ForeColor = System.Drawing.Color.White;
            this.lblSiteAlias.Location = new System.Drawing.Point(78, 211);
            this.lblSiteAlias.Name = "lblSiteAlias";
            this.lblSiteAlias.Size = new System.Drawing.Size(297, 33);
            this.lblSiteAlias.TabIndex = 3;
            this.lblSiteAlias.Text = "___";
            this.lblSiteAlias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSiteName
            // 
            this.lblSiteName.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSiteName.ForeColor = System.Drawing.Color.White;
            this.lblSiteName.Location = new System.Drawing.Point(81, 265);
            this.lblSiteName.Name = "lblSiteName";
            this.lblSiteName.Size = new System.Drawing.Size(294, 27);
            this.lblSiteName.TabIndex = 3;
            this.lblSiteName.Text = "___";
            this.lblSiteName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvwOrderItem
            // 
            this.lvwOrderItem.BackColor = System.Drawing.Color.AliceBlue;
            this.lvwOrderItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.name,
            this.amt,
            this.cnt,
            this.dc_amount,
            this.net_amount});
            this.lvwOrderItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwOrderItem.ForeColor = System.Drawing.Color.Black;
            this.lvwOrderItem.FullRowSelect = true;
            this.lvwOrderItem.GridLines = true;
            this.lvwOrderItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwOrderItem.HideSelection = false;
            this.lvwOrderItem.Location = new System.Drawing.Point(9, 33);
            this.lvwOrderItem.MultiSelect = false;
            this.lvwOrderItem.Name = "lvwOrderItem";
            this.lvwOrderItem.Size = new System.Drawing.Size(530, 506);
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
            this.amt.Width = 90;
            // 
            // cnt
            // 
            this.cnt.Text = "수량";
            this.cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dc_amount
            // 
            this.dc_amount.Text = "할인";
            this.dc_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dc_amount.Width = 90;
            // 
            // net_amount
            // 
            this.net_amount.Text = "금액";
            this.net_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.net_amount.Width = 90;
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
            // lblTitle1
            // 
            this.lblTitle1.AutoSize = true;
            this.lblTitle1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle1.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitle1.Location = new System.Drawing.Point(11, 16);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(59, 13);
            this.lblTitle1.TabIndex = 41;
            this.lblTitle1.Text = "구매목록";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkOrange;
            this.label2.Location = new System.Drawing.Point(128, 675);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "최대 이미지 사이즈 : 460 x 700";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblOrderAmountNetTitle);
            this.panel1.Controls.Add(this.lblOrderAmountNet);
            this.panel1.Location = new System.Drawing.Point(9, 653);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 80);
            this.panel1.TabIndex = 42;
            // 
            // lblOrderAmountReceive
            // 
            this.lblOrderAmountReceive.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountReceive.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountReceive.Location = new System.Drawing.Point(122, 16);
            this.lblOrderAmountReceive.Name = "lblOrderAmountReceive";
            this.lblOrderAmountReceive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmountReceive.Size = new System.Drawing.Size(129, 23);
            this.lblOrderAmountReceive.TabIndex = 44;
            this.lblOrderAmountReceive.Text = "0";
            // 
            // lblOrderAmountReceiveTitle
            // 
            this.lblOrderAmountReceiveTitle.AutoSize = true;
            this.lblOrderAmountReceiveTitle.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountReceiveTitle.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountReceiveTitle.Location = new System.Drawing.Point(17, 18);
            this.lblOrderAmountReceiveTitle.Name = "lblOrderAmountReceiveTitle";
            this.lblOrderAmountReceiveTitle.Size = new System.Drawing.Size(85, 19);
            this.lblOrderAmountReceiveTitle.TabIndex = 43;
            this.lblOrderAmountReceiveTitle.Text = "받은금액";
            // 
            // lblOrderAmountRestTitle
            // 
            this.lblOrderAmountRestTitle.AutoSize = true;
            this.lblOrderAmountRestTitle.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountRestTitle.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblOrderAmountRestTitle.Location = new System.Drawing.Point(20, 18);
            this.lblOrderAmountRestTitle.Name = "lblOrderAmountRestTitle";
            this.lblOrderAmountRestTitle.Size = new System.Drawing.Size(85, 19);
            this.lblOrderAmountRestTitle.TabIndex = 2;
            this.lblOrderAmountRestTitle.Text = "반환금액";
            // 
            // lblOrderAmountRest
            // 
            this.lblOrderAmountRest.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountRest.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblOrderAmountRest.Location = new System.Drawing.Point(125, 16);
            this.lblOrderAmountRest.Name = "lblOrderAmountRest";
            this.lblOrderAmountRest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmountRest.Size = new System.Drawing.Size(129, 23);
            this.lblOrderAmountRest.TabIndex = 3;
            this.lblOrderAmountRest.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblOrderAmountSumTitle);
            this.panel2.Controls.Add(this.lblOrderAmount);
            this.panel2.Location = new System.Drawing.Point(9, 545);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(255, 55);
            this.panel2.TabIndex = 43;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.AliceBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblOrderAmountReceiveTitle);
            this.panel3.Controls.Add(this.lblOrderAmountReceive);
            this.panel3.Location = new System.Drawing.Point(263, 545);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(276, 55);
            this.panel3.TabIndex = 44;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.AliceBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblOrderAmountRestTitle);
            this.panel4.Controls.Add(this.lblOrderAmountRest);
            this.panel4.Location = new System.Drawing.Point(261, 599);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(278, 55);
            this.panel4.TabIndex = 45;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.AliceBlue;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblOrderAmountDCTitle);
            this.panel5.Controls.Add(this.lblOrderAmountDC);
            this.panel5.Location = new System.Drawing.Point(9, 599);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(255, 55);
            this.panel5.TabIndex = 44;
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
            this.panelOrderInfo.ResumeLayout(false);
            this.panelOrderInfo.PerformLayout();
            this.panel_in_0.ResumeLayout(false);
            this.panel_in_0.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblOrderAmountNet;
        private System.Windows.Forms.Label lblOrderAmountDC;
        private System.Windows.Forms.Label lblOrderAmount;
        private System.Windows.Forms.Label lblOrderAmountNetTitle;
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
        private System.Windows.Forms.Label lblTitle1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOrderAmountReceive;
        private System.Windows.Forms.Label lblOrderAmountReceiveTitle;
        private System.Windows.Forms.Label lblOrderAmountRestTitle;
        private System.Windows.Forms.Label lblOrderAmountRest;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
    }
}