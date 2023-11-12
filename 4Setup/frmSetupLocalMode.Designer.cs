namespace thepos
{
    partial class frmSetupLocalMode
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblPaymentCnt0 = new System.Windows.Forms.Label();
            this.lblCnt0Title = new System.Windows.Forms.Label();
            this.lblCntTitle = new System.Windows.Forms.Label();
            this.lblPaymentCnt = new System.Windows.Forms.Label();
            this.lblOrdersCnt = new System.Windows.Forms.Label();
            this.lblOrdersCnt0 = new System.Windows.Forms.Label();
            this.lblOrderItemCnt = new System.Windows.Forms.Label();
            this.lblOrderItemCnt0 = new System.Windows.Forms.Label();
            this.lblPaymentCashCnt = new System.Windows.Forms.Label();
            this.lblPaymentCashCnt0 = new System.Windows.Forms.Label();
            this.lblPaymentCardCnt = new System.Windows.Forms.Label();
            this.lblPaymentCardCnt0 = new System.Windows.Forms.Label();
            this.lblOrdersTitle = new System.Windows.Forms.Label();
            this.lblOrderItemTitle = new System.Windows.Forms.Label();
            this.lblPaymentTitle = new System.Windows.Forms.Label();
            this.lblPaymentCashTitle = new System.Windows.Forms.Label();
            this.lblPaymentCardTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(37, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(110, 14);
            this.lblTitle.TabIndex = 49;
            this.lblTitle.Text = "긴급사용 데이터";
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnView.Location = new System.Drawing.Point(581, 231);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(140, 40);
            this.btnView.TabIndex = 51;
            this.btnView.TabStop = false;
            this.btnView.Text = "보기";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.Location = new System.Drawing.Point(581, 277);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(140, 50);
            this.btnUpload.TabIndex = 52;
            this.btnUpload.TabStop = false;
            this.btnUpload.Text = "업로드";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(581, 331);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(140, 30);
            this.btnDelete.TabIndex = 53;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblPaymentCnt0
            // 
            this.lblPaymentCnt0.BackColor = System.Drawing.Color.LightGray;
            this.lblPaymentCnt0.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPaymentCnt0.ForeColor = System.Drawing.Color.Red;
            this.lblPaymentCnt0.Location = new System.Drawing.Point(406, 233);
            this.lblPaymentCnt0.Margin = new System.Windows.Forms.Padding(0);
            this.lblPaymentCnt0.Name = "lblPaymentCnt0";
            this.lblPaymentCnt0.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaymentCnt0.Size = new System.Drawing.Size(136, 40);
            this.lblPaymentCnt0.TabIndex = 54;
            this.lblPaymentCnt0.Text = "0";
            this.lblPaymentCnt0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCnt0Title
            // 
            this.lblCnt0Title.BackColor = System.Drawing.Color.DarkGray;
            this.lblCnt0Title.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCnt0Title.ForeColor = System.Drawing.Color.Black;
            this.lblCnt0Title.Location = new System.Drawing.Point(406, 101);
            this.lblCnt0Title.Margin = new System.Windows.Forms.Padding(0);
            this.lblCnt0Title.Name = "lblCnt0Title";
            this.lblCnt0Title.Padding = new System.Windows.Forms.Padding(5);
            this.lblCnt0Title.Size = new System.Drawing.Size(136, 40);
            this.lblCnt0Title.TabIndex = 55;
            this.lblCnt0Title.Text = "업로드할 레코드수";
            this.lblCnt0Title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCntTitle
            // 
            this.lblCntTitle.BackColor = System.Drawing.Color.DarkGray;
            this.lblCntTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCntTitle.ForeColor = System.Drawing.Color.Black;
            this.lblCntTitle.Location = new System.Drawing.Point(268, 101);
            this.lblCntTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblCntTitle.Name = "lblCntTitle";
            this.lblCntTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblCntTitle.Size = new System.Drawing.Size(135, 40);
            this.lblCntTitle.TabIndex = 57;
            this.lblCntTitle.Text = "로컬 총 레코드수";
            this.lblCntTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPaymentCnt
            // 
            this.lblPaymentCnt.BackColor = System.Drawing.Color.LightGray;
            this.lblPaymentCnt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPaymentCnt.ForeColor = System.Drawing.Color.Blue;
            this.lblPaymentCnt.Location = new System.Drawing.Point(268, 233);
            this.lblPaymentCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblPaymentCnt.Name = "lblPaymentCnt";
            this.lblPaymentCnt.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaymentCnt.Size = new System.Drawing.Size(135, 40);
            this.lblPaymentCnt.TabIndex = 56;
            this.lblPaymentCnt.Text = "0";
            this.lblPaymentCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrdersCnt
            // 
            this.lblOrdersCnt.BackColor = System.Drawing.Color.LightGray;
            this.lblOrdersCnt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrdersCnt.ForeColor = System.Drawing.Color.Blue;
            this.lblOrdersCnt.Location = new System.Drawing.Point(268, 145);
            this.lblOrdersCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrdersCnt.Name = "lblOrdersCnt";
            this.lblOrdersCnt.Padding = new System.Windows.Forms.Padding(5);
            this.lblOrdersCnt.Size = new System.Drawing.Size(135, 40);
            this.lblOrdersCnt.TabIndex = 59;
            this.lblOrdersCnt.Text = "0";
            this.lblOrdersCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrdersCnt0
            // 
            this.lblOrdersCnt0.BackColor = System.Drawing.Color.LightGray;
            this.lblOrdersCnt0.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrdersCnt0.ForeColor = System.Drawing.Color.Red;
            this.lblOrdersCnt0.Location = new System.Drawing.Point(406, 145);
            this.lblOrdersCnt0.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrdersCnt0.Name = "lblOrdersCnt0";
            this.lblOrdersCnt0.Padding = new System.Windows.Forms.Padding(5);
            this.lblOrdersCnt0.Size = new System.Drawing.Size(136, 40);
            this.lblOrdersCnt0.TabIndex = 58;
            this.lblOrdersCnt0.Text = "0";
            this.lblOrdersCnt0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrderItemCnt
            // 
            this.lblOrderItemCnt.BackColor = System.Drawing.Color.LightGray;
            this.lblOrderItemCnt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderItemCnt.ForeColor = System.Drawing.Color.Blue;
            this.lblOrderItemCnt.Location = new System.Drawing.Point(268, 189);
            this.lblOrderItemCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrderItemCnt.Name = "lblOrderItemCnt";
            this.lblOrderItemCnt.Padding = new System.Windows.Forms.Padding(5);
            this.lblOrderItemCnt.Size = new System.Drawing.Size(135, 40);
            this.lblOrderItemCnt.TabIndex = 61;
            this.lblOrderItemCnt.Text = "0";
            this.lblOrderItemCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrderItemCnt0
            // 
            this.lblOrderItemCnt0.BackColor = System.Drawing.Color.LightGray;
            this.lblOrderItemCnt0.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderItemCnt0.ForeColor = System.Drawing.Color.Red;
            this.lblOrderItemCnt0.Location = new System.Drawing.Point(406, 189);
            this.lblOrderItemCnt0.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrderItemCnt0.Name = "lblOrderItemCnt0";
            this.lblOrderItemCnt0.Padding = new System.Windows.Forms.Padding(5);
            this.lblOrderItemCnt0.Size = new System.Drawing.Size(136, 40);
            this.lblOrderItemCnt0.TabIndex = 60;
            this.lblOrderItemCnt0.Text = "0";
            this.lblOrderItemCnt0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPaymentCashCnt
            // 
            this.lblPaymentCashCnt.BackColor = System.Drawing.Color.LightGray;
            this.lblPaymentCashCnt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPaymentCashCnt.ForeColor = System.Drawing.Color.Blue;
            this.lblPaymentCashCnt.Location = new System.Drawing.Point(268, 277);
            this.lblPaymentCashCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblPaymentCashCnt.Name = "lblPaymentCashCnt";
            this.lblPaymentCashCnt.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaymentCashCnt.Size = new System.Drawing.Size(135, 40);
            this.lblPaymentCashCnt.TabIndex = 63;
            this.lblPaymentCashCnt.Text = "0";
            this.lblPaymentCashCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPaymentCashCnt0
            // 
            this.lblPaymentCashCnt0.BackColor = System.Drawing.Color.LightGray;
            this.lblPaymentCashCnt0.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPaymentCashCnt0.ForeColor = System.Drawing.Color.Red;
            this.lblPaymentCashCnt0.Location = new System.Drawing.Point(406, 277);
            this.lblPaymentCashCnt0.Margin = new System.Windows.Forms.Padding(0);
            this.lblPaymentCashCnt0.Name = "lblPaymentCashCnt0";
            this.lblPaymentCashCnt0.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaymentCashCnt0.Size = new System.Drawing.Size(136, 40);
            this.lblPaymentCashCnt0.TabIndex = 62;
            this.lblPaymentCashCnt0.Text = "0";
            this.lblPaymentCashCnt0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPaymentCardCnt
            // 
            this.lblPaymentCardCnt.BackColor = System.Drawing.Color.LightGray;
            this.lblPaymentCardCnt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPaymentCardCnt.ForeColor = System.Drawing.Color.Blue;
            this.lblPaymentCardCnt.Location = new System.Drawing.Point(268, 321);
            this.lblPaymentCardCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblPaymentCardCnt.Name = "lblPaymentCardCnt";
            this.lblPaymentCardCnt.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaymentCardCnt.Size = new System.Drawing.Size(135, 40);
            this.lblPaymentCardCnt.TabIndex = 65;
            this.lblPaymentCardCnt.Text = "0";
            this.lblPaymentCardCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPaymentCardCnt0
            // 
            this.lblPaymentCardCnt0.BackColor = System.Drawing.Color.LightGray;
            this.lblPaymentCardCnt0.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPaymentCardCnt0.ForeColor = System.Drawing.Color.Red;
            this.lblPaymentCardCnt0.Location = new System.Drawing.Point(406, 321);
            this.lblPaymentCardCnt0.Margin = new System.Windows.Forms.Padding(0);
            this.lblPaymentCardCnt0.Name = "lblPaymentCardCnt0";
            this.lblPaymentCardCnt0.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaymentCardCnt0.Size = new System.Drawing.Size(136, 40);
            this.lblPaymentCardCnt0.TabIndex = 64;
            this.lblPaymentCardCnt0.Text = "0";
            this.lblPaymentCardCnt0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrdersTitle
            // 
            this.lblOrdersTitle.BackColor = System.Drawing.Color.DarkGray;
            this.lblOrdersTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrdersTitle.ForeColor = System.Drawing.Color.Black;
            this.lblOrdersTitle.Location = new System.Drawing.Point(131, 145);
            this.lblOrdersTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrdersTitle.Name = "lblOrdersTitle";
            this.lblOrdersTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblOrdersTitle.Size = new System.Drawing.Size(134, 40);
            this.lblOrdersTitle.TabIndex = 57;
            this.lblOrdersTitle.Text = "주문";
            this.lblOrdersTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrderItemTitle
            // 
            this.lblOrderItemTitle.BackColor = System.Drawing.Color.DarkGray;
            this.lblOrderItemTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderItemTitle.ForeColor = System.Drawing.Color.Black;
            this.lblOrderItemTitle.Location = new System.Drawing.Point(131, 189);
            this.lblOrderItemTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrderItemTitle.Name = "lblOrderItemTitle";
            this.lblOrderItemTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblOrderItemTitle.Size = new System.Drawing.Size(134, 40);
            this.lblOrderItemTitle.TabIndex = 57;
            this.lblOrderItemTitle.Text = "주문항목";
            this.lblOrderItemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentTitle
            // 
            this.lblPaymentTitle.BackColor = System.Drawing.Color.DarkGray;
            this.lblPaymentTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPaymentTitle.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentTitle.Location = new System.Drawing.Point(131, 233);
            this.lblPaymentTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblPaymentTitle.Name = "lblPaymentTitle";
            this.lblPaymentTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaymentTitle.Size = new System.Drawing.Size(134, 40);
            this.lblPaymentTitle.TabIndex = 57;
            this.lblPaymentTitle.Text = "결제";
            this.lblPaymentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentCashTitle
            // 
            this.lblPaymentCashTitle.BackColor = System.Drawing.Color.DarkGray;
            this.lblPaymentCashTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPaymentCashTitle.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentCashTitle.Location = new System.Drawing.Point(131, 277);
            this.lblPaymentCashTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblPaymentCashTitle.Name = "lblPaymentCashTitle";
            this.lblPaymentCashTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaymentCashTitle.Size = new System.Drawing.Size(134, 40);
            this.lblPaymentCashTitle.TabIndex = 57;
            this.lblPaymentCashTitle.Text = "현금결제";
            this.lblPaymentCashTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentCardTitle
            // 
            this.lblPaymentCardTitle.BackColor = System.Drawing.Color.DarkGray;
            this.lblPaymentCardTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPaymentCardTitle.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentCardTitle.Location = new System.Drawing.Point(131, 321);
            this.lblPaymentCardTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblPaymentCardTitle.Name = "lblPaymentCardTitle";
            this.lblPaymentCardTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaymentCardTitle.Size = new System.Drawing.Size(134, 40);
            this.lblPaymentCardTitle.TabIndex = 57;
            this.lblPaymentCardTitle.Text = "카드결제";
            this.lblPaymentCardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkGray;
            this.label1.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(131, 101);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(134, 40);
            this.label1.TabIndex = 57;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSetupLocalMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 700);
            this.Controls.Add(this.lblPaymentCardCnt);
            this.Controls.Add(this.lblPaymentCardCnt0);
            this.Controls.Add(this.lblPaymentCashCnt);
            this.Controls.Add(this.lblPaymentCashCnt0);
            this.Controls.Add(this.lblOrderItemCnt);
            this.Controls.Add(this.lblOrderItemCnt0);
            this.Controls.Add(this.lblOrdersCnt);
            this.Controls.Add(this.lblOrdersCnt0);
            this.Controls.Add(this.lblPaymentCardTitle);
            this.Controls.Add(this.lblPaymentCashTitle);
            this.Controls.Add(this.lblPaymentTitle);
            this.Controls.Add(this.lblOrderItemTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOrdersTitle);
            this.Controls.Add(this.lblCntTitle);
            this.Controls.Add(this.lblPaymentCnt);
            this.Controls.Add(this.lblCnt0Title);
            this.Controls.Add(this.lblPaymentCnt0);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lblTitle);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSetupLocalMode";
            this.Text = "frmSetupLocalMode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblPaymentCnt0;
        private System.Windows.Forms.Label lblCnt0Title;
        private System.Windows.Forms.Label lblCntTitle;
        private System.Windows.Forms.Label lblPaymentCnt;
        private System.Windows.Forms.Label lblOrdersCnt;
        private System.Windows.Forms.Label lblOrdersCnt0;
        private System.Windows.Forms.Label lblOrderItemCnt;
        private System.Windows.Forms.Label lblOrderItemCnt0;
        private System.Windows.Forms.Label lblPaymentCashCnt;
        private System.Windows.Forms.Label lblPaymentCashCnt0;
        private System.Windows.Forms.Label lblPaymentCardCnt;
        private System.Windows.Forms.Label lblPaymentCardCnt0;
        private System.Windows.Forms.Label lblOrdersTitle;
        private System.Windows.Forms.Label lblOrderItemTitle;
        private System.Windows.Forms.Label lblPaymentTitle;
        private System.Windows.Forms.Label lblPaymentCashTitle;
        private System.Windows.Forms.Label lblPaymentCardTitle;
        private System.Windows.Forms.Label label1;
    }
}