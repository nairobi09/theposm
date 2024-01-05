namespace thepos
{
    partial class frmLocalModeInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocalModeInfo));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panelFront = new System.Windows.Forms.Panel();
            this.dtpBizDate = new System.Windows.Forms.DateTimePicker();
            this.lblBizDtTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panelOrange = new System.Windows.Forms.Panel();
            this.panelFront.SuspendLayout();
            this.panelOrange.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblTitle.Location = new System.Drawing.Point(232, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(67, 14);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "로컬모드";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInfo.ForeColor = System.Drawing.Color.Black;
            this.lblInfo.Location = new System.Drawing.Point(111, 53);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(345, 140);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "인터넷 네트워크 장애로 서버와 통신이 불가능할 경우\r\n\r\n- 거래데이터를 로컬에 임시 보관 \r\n- 네트워크가 정상화 된 이후 데이터를 서버로 업로" +
    "드\r\n\r\n긴급사용모드에서 기능은 최소한으로 제한됨.\r\n\r\n- 상품주문 및 단순현금결제, 카드임의등록(가능)\r\n- 원장관리, 밴사를 통한 결제승인" +
    " (불가.)\r\n- 원장관리, 영업관리, 매출관리 (불가)";
            // 
            // panelFront
            // 
            this.panelFront.BackColor = System.Drawing.Color.White;
            this.panelFront.Controls.Add(this.dtpBizDate);
            this.panelFront.Controls.Add(this.lblBizDtTitle);
            this.panelFront.Controls.Add(this.btnCancel);
            this.panelFront.Controls.Add(this.btnOK);
            this.panelFront.Controls.Add(this.lblTitle);
            this.panelFront.Controls.Add(this.lblInfo);
            this.panelFront.ForeColor = System.Drawing.Color.Black;
            this.panelFront.Location = new System.Drawing.Point(1, 1);
            this.panelFront.Name = "panelFront";
            this.panelFront.Size = new System.Drawing.Size(553, 366);
            this.panelFront.TabIndex = 2;
            // 
            // dtpBizDate
            // 
            this.dtpBizDate.CalendarForeColor = System.Drawing.Color.DarkOrange;
            this.dtpBizDate.CalendarMonthBackground = System.Drawing.Color.Moccasin;
            this.dtpBizDate.CalendarTitleForeColor = System.Drawing.Color.DarkOrange;
            this.dtpBizDate.CalendarTrailingForeColor = System.Drawing.Color.DarkOrange;
            this.dtpBizDate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpBizDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBizDate.Location = new System.Drawing.Point(246, 253);
            this.dtpBizDate.Name = "dtpBizDate";
            this.dtpBizDate.Size = new System.Drawing.Size(110, 23);
            this.dtpBizDate.TabIndex = 44;
            this.dtpBizDate.TabStop = false;
            // 
            // lblBizDtTitle
            // 
            this.lblBizDtTitle.AutoSize = true;
            this.lblBizDtTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBizDtTitle.ForeColor = System.Drawing.Color.Black;
            this.lblBizDtTitle.Location = new System.Drawing.Point(179, 257);
            this.lblBizDtTitle.Name = "lblBizDtTitle";
            this.lblBizDtTitle.Size = new System.Drawing.Size(63, 14);
            this.lblBizDtTitle.TabIndex = 43;
            this.lblBizDtTitle.Text = "영업일자";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnCancel.Location = new System.Drawing.Point(153, 300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.DarkOrange;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(279, 299);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(122, 42);
            this.btnOK.TabIndex = 3;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "사용";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panelOrange
            // 
            this.panelOrange.BackColor = System.Drawing.Color.DarkOrange;
            this.panelOrange.Controls.Add(this.panelFront);
            this.panelOrange.Location = new System.Drawing.Point(5, 5);
            this.panelOrange.Name = "panelOrange";
            this.panelOrange.Size = new System.Drawing.Size(555, 368);
            this.panelOrange.TabIndex = 3;
            // 
            // frmLocalModeInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(567, 380);
            this.Controls.Add(this.panelOrange);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLocalModeInfo";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmLocalModeInfo";
            this.panelFront.ResumeLayout(false);
            this.panelFront.PerformLayout();
            this.panelOrange.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel panelFront;
        private System.Windows.Forms.Panel panelOrange;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DateTimePicker dtpBizDate;
        private System.Windows.Forms.Label lblBizDtTitle;
    }
}