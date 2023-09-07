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
            this.lvwOrderItem = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dc_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.net_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelOrderSumBlack.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOrderSumBlack
            // 
            this.panelOrderSumBlack.BackColor = System.Drawing.Color.WhiteSmoke;
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
            this.panelOrderSumBlack.Location = new System.Drawing.Point(622, 60);
            this.panelOrderSumBlack.Name = "panelOrderSumBlack";
            this.panelOrderSumBlack.Size = new System.Drawing.Size(344, 648);
            this.panelOrderSumBlack.TabIndex = 2;
            // 
            // lblOrderAmountRest
            // 
            this.lblOrderAmountRest.Font = new System.Drawing.Font("Gulim", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountRest.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblOrderAmountRest.Location = new System.Drawing.Point(208, 428);
            this.lblOrderAmountRest.Name = "lblOrderAmountRest";
            this.lblOrderAmountRest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmountRest.Size = new System.Drawing.Size(102, 29);
            this.lblOrderAmountRest.TabIndex = 1;
            this.lblOrderAmountRest.Text = "0";
            // 
            // lblOrderAmountReceive
            // 
            this.lblOrderAmountReceive.Font = new System.Drawing.Font("Gulim", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountReceive.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountReceive.Location = new System.Drawing.Point(208, 356);
            this.lblOrderAmountReceive.Name = "lblOrderAmountReceive";
            this.lblOrderAmountReceive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmountReceive.Size = new System.Drawing.Size(103, 29);
            this.lblOrderAmountReceive.TabIndex = 1;
            this.lblOrderAmountReceive.Text = "0";
            // 
            // lblOrderAmountNet
            // 
            this.lblOrderAmountNet.Font = new System.Drawing.Font("Gulim", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountNet.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblOrderAmountNet.Location = new System.Drawing.Point(208, 284);
            this.lblOrderAmountNet.Name = "lblOrderAmountNet";
            this.lblOrderAmountNet.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmountNet.Size = new System.Drawing.Size(103, 29);
            this.lblOrderAmountNet.TabIndex = 1;
            this.lblOrderAmountNet.Text = "0";
            // 
            // lblOrderAmountDC
            // 
            this.lblOrderAmountDC.Font = new System.Drawing.Font("Gulim", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountDC.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountDC.Location = new System.Drawing.Point(208, 206);
            this.lblOrderAmountDC.Name = "lblOrderAmountDC";
            this.lblOrderAmountDC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmountDC.Size = new System.Drawing.Size(103, 29);
            this.lblOrderAmountDC.TabIndex = 1;
            this.lblOrderAmountDC.Text = "0";
            // 
            // lblOrderAmount
            // 
            this.lblOrderAmount.Font = new System.Drawing.Font("Gulim", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmount.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmount.Location = new System.Drawing.Point(208, 127);
            this.lblOrderAmount.Name = "lblOrderAmount";
            this.lblOrderAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmount.Size = new System.Drawing.Size(103, 29);
            this.lblOrderAmount.TabIndex = 1;
            this.lblOrderAmount.Text = "0";
            // 
            // lblOrderAmountRestTitle
            // 
            this.lblOrderAmountRestTitle.AutoSize = true;
            this.lblOrderAmountRestTitle.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountRestTitle.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblOrderAmountRestTitle.Location = new System.Drawing.Point(22, 437);
            this.lblOrderAmountRestTitle.Name = "lblOrderAmountRestTitle";
            this.lblOrderAmountRestTitle.Size = new System.Drawing.Size(89, 19);
            this.lblOrderAmountRestTitle.TabIndex = 0;
            this.lblOrderAmountRestTitle.Text = "반환금액";
            // 
            // lblOrderAmountReceiveTitle
            // 
            this.lblOrderAmountReceiveTitle.AutoSize = true;
            this.lblOrderAmountReceiveTitle.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountReceiveTitle.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountReceiveTitle.Location = new System.Drawing.Point(24, 365);
            this.lblOrderAmountReceiveTitle.Name = "lblOrderAmountReceiveTitle";
            this.lblOrderAmountReceiveTitle.Size = new System.Drawing.Size(89, 19);
            this.lblOrderAmountReceiveTitle.TabIndex = 0;
            this.lblOrderAmountReceiveTitle.Text = "받은금액";
            // 
            // lblOrderAmountChargeTitle
            // 
            this.lblOrderAmountChargeTitle.AutoSize = true;
            this.lblOrderAmountChargeTitle.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountChargeTitle.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblOrderAmountChargeTitle.Location = new System.Drawing.Point(24, 293);
            this.lblOrderAmountChargeTitle.Name = "lblOrderAmountChargeTitle";
            this.lblOrderAmountChargeTitle.Size = new System.Drawing.Size(89, 19);
            this.lblOrderAmountChargeTitle.TabIndex = 0;
            this.lblOrderAmountChargeTitle.Text = "받을금액";
            // 
            // lblOrderAmountDCTitle
            // 
            this.lblOrderAmountDCTitle.AutoSize = true;
            this.lblOrderAmountDCTitle.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountDCTitle.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountDCTitle.Location = new System.Drawing.Point(24, 215);
            this.lblOrderAmountDCTitle.Name = "lblOrderAmountDCTitle";
            this.lblOrderAmountDCTitle.Size = new System.Drawing.Size(89, 19);
            this.lblOrderAmountDCTitle.TabIndex = 0;
            this.lblOrderAmountDCTitle.Text = "할인금액";
            // 
            // lblOrderAmountSumTitle
            // 
            this.lblOrderAmountSumTitle.AutoSize = true;
            this.lblOrderAmountSumTitle.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountSumTitle.ForeColor = System.Drawing.Color.Black;
            this.lblOrderAmountSumTitle.Location = new System.Drawing.Point(24, 136);
            this.lblOrderAmountSumTitle.Name = "lblOrderAmountSumTitle";
            this.lblOrderAmountSumTitle.Size = new System.Drawing.Size(89, 19);
            this.lblOrderAmountSumTitle.TabIndex = 0;
            this.lblOrderAmountSumTitle.Text = "합계금액";
            // 
            // lvwOrderItem
            // 
            this.lvwOrderItem.BackColor = System.Drawing.SystemColors.Window;
            this.lvwOrderItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.no,
            this.name,
            this.amt,
            this.cnt,
            this.dc_amount,
            this.net_amount});
            this.lvwOrderItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwOrderItem.FullRowSelect = true;
            this.lvwOrderItem.GridLines = true;
            this.lvwOrderItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwOrderItem.HideSelection = false;
            this.lvwOrderItem.Location = new System.Drawing.Point(42, 60);
            this.lvwOrderItem.MultiSelect = false;
            this.lvwOrderItem.Name = "lvwOrderItem";
            this.lvwOrderItem.Size = new System.Drawing.Size(557, 648);
            this.lvwOrderItem.TabIndex = 38;
            this.lvwOrderItem.TabStop = false;
            this.lvwOrderItem.UseCompatibleStateImageBehavior = false;
            this.lvwOrderItem.View = System.Windows.Forms.View.Details;
            // 
            // no
            // 
            this.no.Text = "#";
            this.no.Width = 32;
            // 
            // name
            // 
            this.name.Text = "상품명";
            this.name.Width = 110;
            // 
            // amt
            // 
            this.amt.Text = "단가";
            this.amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amt.Width = 104;
            // 
            // cnt
            // 
            this.cnt.Text = "수량";
            this.cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cnt.Width = 78;
            // 
            // dc_amount
            // 
            this.dc_amount.Text = "할인";
            this.dc_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dc_amount.Width = 100;
            // 
            // net_amount
            // 
            this.net_amount.Text = "금액";
            this.net_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.net_amount.Width = 116;
            // 
            // frmSub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.lvwOrderItem);
            this.Controls.Add(this.panelOrderSumBlack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSub";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmSub";
            this.panelOrderSumBlack.ResumeLayout(false);
            this.panelOrderSumBlack.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.ListView lvwOrderItem;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader amt;
        private System.Windows.Forms.ColumnHeader cnt;
        private System.Windows.Forms.ColumnHeader dc_amount;
        private System.Windows.Forms.ColumnHeader net_amount;
    }
}