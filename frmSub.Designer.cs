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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSub));
            this.lblOrderAmountNet = new System.Windows.Forms.Label();
            this.lblOrderAmountDC = new System.Windows.Forms.Label();
            this.lblOrderAmount = new System.Windows.Forms.Label();
            this.lblOrderAmountNetTitle = new System.Windows.Forms.Label();
            this.lblOrderAmountDCTitle = new System.Windows.Forms.Label();
            this.lblOrderAmountSumTitle = new System.Windows.Forms.Label();
            this.panelOrderInfo = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lvwOrderItem = new BrightIdeasSoftware.ObjectListView();
            this.lv_no = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lv_name = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lv_amt = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lv_cnt = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lv_dc_amount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lv_net_amount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lv_memo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblOrderAmountRestTitle = new System.Windows.Forms.Label();
            this.lblOrderAmountRest = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblOrderAmountReceiveTitle = new System.Windows.Forms.Label();
            this.lblOrderAmountReceive = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelOrderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvwOrderItem)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOrderAmountNet
            // 
            this.lblOrderAmountNet.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountNet.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblOrderAmountNet.Location = new System.Drawing.Point(291, 13);
            this.lblOrderAmountNet.Name = "lblOrderAmountNet";
            this.lblOrderAmountNet.Size = new System.Drawing.Size(303, 50);
            this.lblOrderAmountNet.TabIndex = 1;
            this.lblOrderAmountNet.Text = "0";
            this.lblOrderAmountNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrderAmountDC
            // 
            this.lblOrderAmountDC.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountDC.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountDC.Location = new System.Drawing.Point(100, 5);
            this.lblOrderAmountDC.Name = "lblOrderAmountDC";
            this.lblOrderAmountDC.Size = new System.Drawing.Size(163, 40);
            this.lblOrderAmountDC.TabIndex = 1;
            this.lblOrderAmountDC.Text = "0";
            this.lblOrderAmountDC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrderAmount
            // 
            this.lblOrderAmount.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmount.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmount.Location = new System.Drawing.Point(99, 8);
            this.lblOrderAmount.Name = "lblOrderAmount";
            this.lblOrderAmount.Size = new System.Drawing.Size(163, 37);
            this.lblOrderAmount.TabIndex = 1;
            this.lblOrderAmount.Text = "0";
            this.lblOrderAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrderAmountNetTitle
            // 
            this.lblOrderAmountNetTitle.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountNetTitle.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblOrderAmountNetTitle.Location = new System.Drawing.Point(25, 13);
            this.lblOrderAmountNetTitle.Name = "lblOrderAmountNetTitle";
            this.lblOrderAmountNetTitle.Size = new System.Drawing.Size(124, 50);
            this.lblOrderAmountNetTitle.TabIndex = 0;
            this.lblOrderAmountNetTitle.Text = "내실금액";
            this.lblOrderAmountNetTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrderAmountDCTitle
            // 
            this.lblOrderAmountDCTitle.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountDCTitle.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountDCTitle.Location = new System.Drawing.Point(24, 12);
            this.lblOrderAmountDCTitle.Name = "lblOrderAmountDCTitle";
            this.lblOrderAmountDCTitle.Size = new System.Drawing.Size(47, 27);
            this.lblOrderAmountDCTitle.TabIndex = 0;
            this.lblOrderAmountDCTitle.Text = "할인";
            this.lblOrderAmountDCTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrderAmountSumTitle
            // 
            this.lblOrderAmountSumTitle.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountSumTitle.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountSumTitle.Location = new System.Drawing.Point(23, 13);
            this.lblOrderAmountSumTitle.Name = "lblOrderAmountSumTitle";
            this.lblOrderAmountSumTitle.Size = new System.Drawing.Size(47, 27);
            this.lblOrderAmountSumTitle.TabIndex = 0;
            this.lblOrderAmountSumTitle.Text = "합계";
            this.lblOrderAmountSumTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelOrderInfo
            // 
            this.panelOrderInfo.BackColor = System.Drawing.Color.Lavender;
            this.panelOrderInfo.Controls.Add(this.picLogo);
            this.panelOrderInfo.Controls.Add(this.lvwOrderItem);
            this.panelOrderInfo.Controls.Add(this.panel5);
            this.panelOrderInfo.Controls.Add(this.panel4);
            this.panelOrderInfo.Controls.Add(this.panel3);
            this.panelOrderInfo.Controls.Add(this.panel2);
            this.panelOrderInfo.Controls.Add(this.panel1);
            this.panelOrderInfo.Location = new System.Drawing.Point(1, 1);
            this.panelOrderInfo.Name = "panelOrderInfo";
            this.panelOrderInfo.Size = new System.Drawing.Size(1022, 766);
            this.panelOrderInfo.TabIndex = 39;
            this.panelOrderInfo.Visible = false;
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(31, 35);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(300, 700);
            this.picLogo.TabIndex = 47;
            this.picLogo.TabStop = false;
            // 
            // lvwOrderItem
            // 
            this.lvwOrderItem.AllColumns.Add(this.lv_no);
            this.lvwOrderItem.AllColumns.Add(this.lv_name);
            this.lvwOrderItem.AllColumns.Add(this.lv_amt);
            this.lvwOrderItem.AllColumns.Add(this.lv_cnt);
            this.lvwOrderItem.AllColumns.Add(this.lv_dc_amount);
            this.lvwOrderItem.AllColumns.Add(this.lv_net_amount);
            this.lvwOrderItem.AllColumns.Add(this.lv_memo);
            this.lvwOrderItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwOrderItem.CellEditUseWholeCell = false;
            this.lvwOrderItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lv_no,
            this.lv_name,
            this.lv_amt,
            this.lv_cnt,
            this.lv_dc_amount,
            this.lv_net_amount,
            this.lv_memo});
            this.lvwOrderItem.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvwOrderItem.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwOrderItem.FullRowSelect = true;
            this.lvwOrderItem.GridLines = true;
            this.lvwOrderItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwOrderItem.HideSelection = false;
            this.lvwOrderItem.Location = new System.Drawing.Point(358, 35);
            this.lvwOrderItem.MultiSelect = false;
            this.lvwOrderItem.Name = "lvwOrderItem";
            this.lvwOrderItem.RowHeight = 50;
            this.lvwOrderItem.ShowGroups = false;
            this.lvwOrderItem.Size = new System.Drawing.Size(637, 505);
            this.lvwOrderItem.TabIndex = 46;
            this.lvwOrderItem.TabStop = false;
            this.lvwOrderItem.UseCompatibleStateImageBehavior = false;
            this.lvwOrderItem.View = System.Windows.Forms.View.Details;
            // 
            // lv_no
            // 
            this.lv_no.AspectName = "lv_order_no";
            this.lv_no.CellPadding = new System.Drawing.Rectangle(0, -10, 0, 0);
            this.lv_no.Text = "#";
            this.lv_no.Width = 30;
            // 
            // lv_name
            // 
            this.lv_name.AspectName = "lv_goods_name";
            this.lv_name.CellPadding = new System.Drawing.Rectangle(0, 10, 0, 0);
            this.lv_name.Text = "상품명";
            this.lv_name.Width = 211;
            this.lv_name.WordWrap = true;
            // 
            // lv_amt
            // 
            this.lv_amt.AspectName = "lv_amt";
            this.lv_amt.CellPadding = new System.Drawing.Rectangle(0, 10, 0, 0);
            this.lv_amt.Text = "단가";
            this.lv_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lv_amt.Width = 86;
            // 
            // lv_cnt
            // 
            this.lv_cnt.AspectName = "lv_cnt";
            this.lv_cnt.CellPadding = new System.Drawing.Rectangle(0, -10, 0, 0);
            this.lv_cnt.Text = "수량";
            this.lv_cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lv_cnt.Width = 59;
            // 
            // lv_dc_amount
            // 
            this.lv_dc_amount.AspectName = "lv_dc_amount";
            this.lv_dc_amount.CellPadding = new System.Drawing.Rectangle(0, -10, 0, 0);
            this.lv_dc_amount.Text = "할인";
            this.lv_dc_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lv_dc_amount.Width = 86;
            // 
            // lv_net_amount
            // 
            this.lv_net_amount.AspectName = "lv_net_amount";
            this.lv_net_amount.CellPadding = new System.Drawing.Rectangle(0, -10, 0, 0);
            this.lv_net_amount.Text = "금액";
            this.lv_net_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lv_net_amount.Width = 99;
            // 
            // lv_memo
            // 
            this.lv_memo.AspectName = "lv_memo";
            this.lv_memo.CellPadding = new System.Drawing.Rectangle(0, -10, 0, 0);
            this.lv_memo.Text = "비고";
            this.lv_memo.Width = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblOrderAmountDCTitle);
            this.panel5.Controls.Add(this.lblOrderAmountDC);
            this.panel5.Location = new System.Drawing.Point(358, 601);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(317, 55);
            this.panel5.TabIndex = 44;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblOrderAmountRestTitle);
            this.panel4.Controls.Add(this.lblOrderAmountRest);
            this.panel4.Location = new System.Drawing.Point(674, 601);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(321, 55);
            this.panel4.TabIndex = 45;
            // 
            // lblOrderAmountRestTitle
            // 
            this.lblOrderAmountRestTitle.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountRestTitle.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblOrderAmountRestTitle.Location = new System.Drawing.Point(20, 12);
            this.lblOrderAmountRestTitle.Name = "lblOrderAmountRestTitle";
            this.lblOrderAmountRestTitle.Size = new System.Drawing.Size(85, 27);
            this.lblOrderAmountRestTitle.TabIndex = 2;
            this.lblOrderAmountRestTitle.Text = "반환금액";
            this.lblOrderAmountRestTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrderAmountRest
            // 
            this.lblOrderAmountRest.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountRest.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblOrderAmountRest.Location = new System.Drawing.Point(125, 6);
            this.lblOrderAmountRest.Name = "lblOrderAmountRest";
            this.lblOrderAmountRest.Size = new System.Drawing.Size(154, 39);
            this.lblOrderAmountRest.TabIndex = 3;
            this.lblOrderAmountRest.Text = "0";
            this.lblOrderAmountRest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblOrderAmountReceiveTitle);
            this.panel3.Controls.Add(this.lblOrderAmountReceive);
            this.panel3.Location = new System.Drawing.Point(674, 547);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(321, 55);
            this.panel3.TabIndex = 44;
            // 
            // lblOrderAmountReceiveTitle
            // 
            this.lblOrderAmountReceiveTitle.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountReceiveTitle.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountReceiveTitle.Location = new System.Drawing.Point(17, 13);
            this.lblOrderAmountReceiveTitle.Name = "lblOrderAmountReceiveTitle";
            this.lblOrderAmountReceiveTitle.Size = new System.Drawing.Size(85, 27);
            this.lblOrderAmountReceiveTitle.TabIndex = 43;
            this.lblOrderAmountReceiveTitle.Text = "받은금액";
            this.lblOrderAmountReceiveTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrderAmountReceive
            // 
            this.lblOrderAmountReceive.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountReceive.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountReceive.Location = new System.Drawing.Point(124, 7);
            this.lblOrderAmountReceive.Name = "lblOrderAmountReceive";
            this.lblOrderAmountReceive.Size = new System.Drawing.Size(154, 39);
            this.lblOrderAmountReceive.TabIndex = 44;
            this.lblOrderAmountReceive.Text = "0";
            this.lblOrderAmountReceive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblOrderAmountSumTitle);
            this.panel2.Controls.Add(this.lblOrderAmount);
            this.panel2.Location = new System.Drawing.Point(358, 547);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(317, 55);
            this.panel2.TabIndex = 43;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblOrderAmountNetTitle);
            this.panel1.Controls.Add(this.lblOrderAmountNet);
            this.panel1.Location = new System.Drawing.Point(358, 655);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 80);
            this.panel1.TabIndex = 42;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::theposw.Properties.Resources.thepos;
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSub";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmSub";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSub_FormClosed);
            this.panelOrderInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvwOrderItem)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOrderAmountReceive;
        private System.Windows.Forms.Label lblOrderAmountReceiveTitle;
        private System.Windows.Forms.Label lblOrderAmountRestTitle;
        private System.Windows.Forms.Label lblOrderAmountRest;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private BrightIdeasSoftware.ObjectListView lvwOrderItem;
        private BrightIdeasSoftware.OLVColumn lv_no;
        private BrightIdeasSoftware.OLVColumn lv_name;
        private BrightIdeasSoftware.OLVColumn lv_amt;
        private BrightIdeasSoftware.OLVColumn lv_cnt;
        private BrightIdeasSoftware.OLVColumn lv_dc_amount;
        private BrightIdeasSoftware.OLVColumn lv_net_amount;
        private BrightIdeasSoftware.OLVColumn lv_memo;
        private System.Windows.Forms.PictureBox picLogo;
    }
}