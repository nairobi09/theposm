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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panelFront = new System.Windows.Forms.Panel();
            this.dtpBizDate = new System.Windows.Forms.DateTimePicker();
            this.lblBizDtTitle = new System.Windows.Forms.Label();
            this.panelNumpad = new System.Windows.Forms.Panel();
            this.btnKey1 = new System.Windows.Forms.Button();
            this.btnKey2 = new System.Windows.Forms.Button();
            this.btnKey0 = new System.Windows.Forms.Button();
            this.btnKey3 = new System.Windows.Forms.Button();
            this.btnKey4 = new System.Windows.Forms.Button();
            this.btnKeyBS = new System.Windows.Forms.Button();
            this.btnKey5 = new System.Windows.Forms.Button();
            this.btnKey9 = new System.Windows.Forms.Button();
            this.btnKey6 = new System.Windows.Forms.Button();
            this.btnKey8 = new System.Windows.Forms.Button();
            this.btnKey7 = new System.Windows.Forms.Button();
            this.btnKeyClear = new System.Windows.Forms.Button();
            this.lblPW = new System.Windows.Forms.Label();
            this.panelKeyOrange = new System.Windows.Forms.Panel();
            this.panelKeyWhite = new System.Windows.Forms.Panel();
            this.tbPW = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panelOrange = new System.Windows.Forms.Panel();
            this.lblLocalDbVersionTitle = new System.Windows.Forms.Label();
            this.lblLocalDbVersion = new System.Windows.Forms.Label();
            this.panelFront.SuspendLayout();
            this.panelNumpad.SuspendLayout();
            this.panelKeyOrange.SuspendLayout();
            this.panelKeyWhite.SuspendLayout();
            this.panelOrange.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblTitle.Location = new System.Drawing.Point(270, 55);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(97, 14);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "긴급사용모드";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInfo.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblInfo.Location = new System.Drawing.Point(270, 97);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(345, 140);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "인터넷 네트워크 장애로 서버와 통신이 불가능할 경우\r\n\r\n- 거래데이터를 로컬에 임시 보관 \r\n- 네트워크가 정상화 된 이후 데이터를 서버로 업로" +
    "드\r\n\r\n긴급사용모드에서 기능은 최소한으로 제한됨.\r\n\r\n- 상품주문 및 단순현금결제, 카드임의등록(가능)\r\n- 원장관리, 밴사를 통한 결제승인" +
    " (불가.)\r\n- 원장관리, 영업관리, 매출관리 (불가.)";
            // 
            // panelFront
            // 
            this.panelFront.BackColor = System.Drawing.Color.White;
            this.panelFront.Controls.Add(this.lblLocalDbVersion);
            this.panelFront.Controls.Add(this.lblLocalDbVersionTitle);
            this.panelFront.Controls.Add(this.dtpBizDate);
            this.panelFront.Controls.Add(this.lblBizDtTitle);
            this.panelFront.Controls.Add(this.panelNumpad);
            this.panelFront.Controls.Add(this.lblPW);
            this.panelFront.Controls.Add(this.panelKeyOrange);
            this.panelFront.Controls.Add(this.btnCancel);
            this.panelFront.Controls.Add(this.btnOK);
            this.panelFront.Controls.Add(this.lblTitle);
            this.panelFront.Controls.Add(this.lblInfo);
            this.panelFront.ForeColor = System.Drawing.Color.Black;
            this.panelFront.Location = new System.Drawing.Point(1, 1);
            this.panelFront.Name = "panelFront";
            this.panelFront.Size = new System.Drawing.Size(688, 488);
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
            this.dtpBizDate.Location = new System.Drawing.Point(378, 331);
            this.dtpBizDate.Name = "dtpBizDate";
            this.dtpBizDate.Size = new System.Drawing.Size(142, 23);
            this.dtpBizDate.TabIndex = 44;
            this.dtpBizDate.TabStop = false;
            // 
            // lblBizDtTitle
            // 
            this.lblBizDtTitle.AutoSize = true;
            this.lblBizDtTitle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBizDtTitle.ForeColor = System.Drawing.Color.Black;
            this.lblBizDtTitle.Location = new System.Drawing.Point(301, 334);
            this.lblBizDtTitle.Name = "lblBizDtTitle";
            this.lblBizDtTitle.Size = new System.Drawing.Size(71, 16);
            this.lblBizDtTitle.TabIndex = 43;
            this.lblBizDtTitle.Text = "영업일자";
            // 
            // panelNumpad
            // 
            this.panelNumpad.Controls.Add(this.btnKey1);
            this.panelNumpad.Controls.Add(this.btnKey2);
            this.panelNumpad.Controls.Add(this.btnKey0);
            this.panelNumpad.Controls.Add(this.btnKey3);
            this.panelNumpad.Controls.Add(this.btnKey4);
            this.panelNumpad.Controls.Add(this.btnKeyBS);
            this.panelNumpad.Controls.Add(this.btnKey5);
            this.panelNumpad.Controls.Add(this.btnKey9);
            this.panelNumpad.Controls.Add(this.btnKey6);
            this.panelNumpad.Controls.Add(this.btnKey8);
            this.panelNumpad.Controls.Add(this.btnKey7);
            this.panelNumpad.Controls.Add(this.btnKeyClear);
            this.panelNumpad.Location = new System.Drawing.Point(42, 168);
            this.panelNumpad.Margin = new System.Windows.Forms.Padding(30);
            this.panelNumpad.Name = "panelNumpad";
            this.panelNumpad.Padding = new System.Windows.Forms.Padding(30);
            this.panelNumpad.Size = new System.Drawing.Size(167, 204);
            this.panelNumpad.TabIndex = 42;
            // 
            // btnKey1
            // 
            this.btnKey1.BackColor = System.Drawing.Color.DarkOrange;
            this.btnKey1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey1.ForeColor = System.Drawing.Color.White;
            this.btnKey1.Location = new System.Drawing.Point(0, 3);
            this.btnKey1.Margin = new System.Windows.Forms.Padding(0);
            this.btnKey1.Name = "btnKey1";
            this.btnKey1.Size = new System.Drawing.Size(54, 47);
            this.btnKey1.TabIndex = 1;
            this.btnKey1.TabStop = false;
            this.btnKey1.Text = "1";
            this.btnKey1.UseVisualStyleBackColor = false;
            // 
            // btnKey2
            // 
            this.btnKey2.BackColor = System.Drawing.Color.DarkOrange;
            this.btnKey2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey2.ForeColor = System.Drawing.Color.White;
            this.btnKey2.Location = new System.Drawing.Point(56, 3);
            this.btnKey2.Name = "btnKey2";
            this.btnKey2.Size = new System.Drawing.Size(54, 47);
            this.btnKey2.TabIndex = 1;
            this.btnKey2.TabStop = false;
            this.btnKey2.Text = "2";
            this.btnKey2.UseVisualStyleBackColor = false;
            // 
            // btnKey0
            // 
            this.btnKey0.BackColor = System.Drawing.Color.DarkOrange;
            this.btnKey0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey0.ForeColor = System.Drawing.Color.White;
            this.btnKey0.Location = new System.Drawing.Point(112, 150);
            this.btnKey0.Name = "btnKey0";
            this.btnKey0.Size = new System.Drawing.Size(54, 47);
            this.btnKey0.TabIndex = 1;
            this.btnKey0.TabStop = false;
            this.btnKey0.Text = "0";
            this.btnKey0.UseVisualStyleBackColor = false;
            // 
            // btnKey3
            // 
            this.btnKey3.BackColor = System.Drawing.Color.DarkOrange;
            this.btnKey3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey3.ForeColor = System.Drawing.Color.White;
            this.btnKey3.Location = new System.Drawing.Point(112, 3);
            this.btnKey3.Name = "btnKey3";
            this.btnKey3.Size = new System.Drawing.Size(54, 47);
            this.btnKey3.TabIndex = 1;
            this.btnKey3.TabStop = false;
            this.btnKey3.Text = "3";
            this.btnKey3.UseVisualStyleBackColor = false;
            // 
            // btnKey4
            // 
            this.btnKey4.BackColor = System.Drawing.Color.DarkOrange;
            this.btnKey4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey4.ForeColor = System.Drawing.Color.White;
            this.btnKey4.Location = new System.Drawing.Point(0, 52);
            this.btnKey4.Name = "btnKey4";
            this.btnKey4.Size = new System.Drawing.Size(54, 47);
            this.btnKey4.TabIndex = 1;
            this.btnKey4.TabStop = false;
            this.btnKey4.Text = "4";
            this.btnKey4.UseVisualStyleBackColor = false;
            // 
            // btnKeyBS
            // 
            this.btnKeyBS.BackColor = System.Drawing.Color.DarkOrange;
            this.btnKeyBS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyBS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKeyBS.ForeColor = System.Drawing.Color.White;
            this.btnKeyBS.Location = new System.Drawing.Point(56, 150);
            this.btnKeyBS.Name = "btnKeyBS";
            this.btnKeyBS.Size = new System.Drawing.Size(54, 47);
            this.btnKeyBS.TabIndex = 1;
            this.btnKeyBS.TabStop = false;
            this.btnKeyBS.Text = "<";
            this.btnKeyBS.UseVisualStyleBackColor = false;
            // 
            // btnKey5
            // 
            this.btnKey5.BackColor = System.Drawing.Color.DarkOrange;
            this.btnKey5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey5.ForeColor = System.Drawing.Color.White;
            this.btnKey5.Location = new System.Drawing.Point(56, 52);
            this.btnKey5.Name = "btnKey5";
            this.btnKey5.Size = new System.Drawing.Size(54, 47);
            this.btnKey5.TabIndex = 1;
            this.btnKey5.TabStop = false;
            this.btnKey5.Text = "5";
            this.btnKey5.UseVisualStyleBackColor = false;
            // 
            // btnKey9
            // 
            this.btnKey9.BackColor = System.Drawing.Color.DarkOrange;
            this.btnKey9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey9.ForeColor = System.Drawing.Color.White;
            this.btnKey9.Location = new System.Drawing.Point(112, 101);
            this.btnKey9.Name = "btnKey9";
            this.btnKey9.Size = new System.Drawing.Size(54, 47);
            this.btnKey9.TabIndex = 1;
            this.btnKey9.TabStop = false;
            this.btnKey9.Text = "9";
            this.btnKey9.UseVisualStyleBackColor = false;
            // 
            // btnKey6
            // 
            this.btnKey6.BackColor = System.Drawing.Color.DarkOrange;
            this.btnKey6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey6.ForeColor = System.Drawing.Color.White;
            this.btnKey6.Location = new System.Drawing.Point(112, 52);
            this.btnKey6.Name = "btnKey6";
            this.btnKey6.Size = new System.Drawing.Size(54, 47);
            this.btnKey6.TabIndex = 1;
            this.btnKey6.TabStop = false;
            this.btnKey6.Text = "6";
            this.btnKey6.UseVisualStyleBackColor = false;
            // 
            // btnKey8
            // 
            this.btnKey8.BackColor = System.Drawing.Color.DarkOrange;
            this.btnKey8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey8.ForeColor = System.Drawing.Color.White;
            this.btnKey8.Location = new System.Drawing.Point(56, 101);
            this.btnKey8.Name = "btnKey8";
            this.btnKey8.Size = new System.Drawing.Size(54, 47);
            this.btnKey8.TabIndex = 1;
            this.btnKey8.TabStop = false;
            this.btnKey8.Text = "8";
            this.btnKey8.UseVisualStyleBackColor = false;
            // 
            // btnKey7
            // 
            this.btnKey7.BackColor = System.Drawing.Color.DarkOrange;
            this.btnKey7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey7.ForeColor = System.Drawing.Color.White;
            this.btnKey7.Location = new System.Drawing.Point(0, 101);
            this.btnKey7.Name = "btnKey7";
            this.btnKey7.Size = new System.Drawing.Size(54, 47);
            this.btnKey7.TabIndex = 1;
            this.btnKey7.TabStop = false;
            this.btnKey7.Text = "7";
            this.btnKey7.UseVisualStyleBackColor = false;
            // 
            // btnKeyClear
            // 
            this.btnKeyClear.BackColor = System.Drawing.Color.DarkOrange;
            this.btnKeyClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKeyClear.ForeColor = System.Drawing.Color.White;
            this.btnKeyClear.Location = new System.Drawing.Point(0, 150);
            this.btnKeyClear.Name = "btnKeyClear";
            this.btnKeyClear.Size = new System.Drawing.Size(54, 47);
            this.btnKeyClear.TabIndex = 1;
            this.btnKeyClear.TabStop = false;
            this.btnKeyClear.Text = "C";
            this.btnKeyClear.UseVisualStyleBackColor = false;
            // 
            // lblPW
            // 
            this.lblPW.AutoSize = true;
            this.lblPW.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPW.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblPW.Location = new System.Drawing.Point(41, 94);
            this.lblPW.Margin = new System.Windows.Forms.Padding(1);
            this.lblPW.Name = "lblPW";
            this.lblPW.Padding = new System.Windows.Forms.Padding(1);
            this.lblPW.Size = new System.Drawing.Size(65, 16);
            this.lblPW.TabIndex = 41;
            this.lblPW.Text = "인증번호";
            this.lblPW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelKeyOrange
            // 
            this.panelKeyOrange.BackColor = System.Drawing.Color.DarkOrange;
            this.panelKeyOrange.Controls.Add(this.panelKeyWhite);
            this.panelKeyOrange.Location = new System.Drawing.Point(43, 119);
            this.panelKeyOrange.Name = "panelKeyOrange";
            this.panelKeyOrange.Size = new System.Drawing.Size(164, 41);
            this.panelKeyOrange.TabIndex = 40;
            // 
            // panelKeyWhite
            // 
            this.panelKeyWhite.BackColor = System.Drawing.Color.White;
            this.panelKeyWhite.Controls.Add(this.tbPW);
            this.panelKeyWhite.Location = new System.Drawing.Point(1, 1);
            this.panelKeyWhite.Name = "panelKeyWhite";
            this.panelKeyWhite.Size = new System.Drawing.Size(162, 39);
            this.panelKeyWhite.TabIndex = 4;
            // 
            // tbPW
            // 
            this.tbPW.BackColor = System.Drawing.Color.White;
            this.tbPW.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPW.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPW.ForeColor = System.Drawing.Color.DarkOrange;
            this.tbPW.Location = new System.Drawing.Point(9, 8);
            this.tbPW.MaxLength = 4;
            this.tbPW.Name = "tbPW";
            this.tbPW.PasswordChar = '*';
            this.tbPW.Size = new System.Drawing.Size(145, 23);
            this.tbPW.TabIndex = 38;
            this.tbPW.TabStop = false;
            this.tbPW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(431, 389);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 48);
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
            this.btnOK.Location = new System.Drawing.Point(301, 390);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(124, 48);
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
            this.panelOrange.Size = new System.Drawing.Size(690, 490);
            this.panelOrange.TabIndex = 3;
            // 
            // lblLocalDbVersionTitle
            // 
            this.lblLocalDbVersionTitle.AutoSize = true;
            this.lblLocalDbVersionTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLocalDbVersionTitle.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblLocalDbVersionTitle.Location = new System.Drawing.Point(270, 269);
            this.lblLocalDbVersionTitle.Margin = new System.Windows.Forms.Padding(1);
            this.lblLocalDbVersionTitle.Name = "lblLocalDbVersionTitle";
            this.lblLocalDbVersionTitle.Padding = new System.Windows.Forms.Padding(1);
            this.lblLocalDbVersionTitle.Size = new System.Drawing.Size(100, 16);
            this.lblLocalDbVersionTitle.TabIndex = 45;
            this.lblLocalDbVersionTitle.Text = "로컬 DB버전 :";
            this.lblLocalDbVersionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLocalDbVersion
            // 
            this.lblLocalDbVersion.AutoSize = true;
            this.lblLocalDbVersion.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLocalDbVersion.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblLocalDbVersion.Location = new System.Drawing.Point(375, 269);
            this.lblLocalDbVersion.Margin = new System.Windows.Forms.Padding(1);
            this.lblLocalDbVersion.Name = "lblLocalDbVersion";
            this.lblLocalDbVersion.Padding = new System.Windows.Forms.Padding(1);
            this.lblLocalDbVersion.Size = new System.Drawing.Size(152, 16);
            this.lblLocalDbVersion.TabIndex = 46;
            this.lblLocalDbVersion.Text = "2023-10-15 11:45:13";
            this.lblLocalDbVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmLocalModeInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.panelOrange);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLocalModeInfo";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmLocalModeInfo";
            this.panelFront.ResumeLayout(false);
            this.panelFront.PerformLayout();
            this.panelNumpad.ResumeLayout(false);
            this.panelKeyOrange.ResumeLayout(false);
            this.panelKeyWhite.ResumeLayout(false);
            this.panelKeyWhite.PerformLayout();
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
        private System.Windows.Forms.Label lblPW;
        private System.Windows.Forms.Panel panelKeyOrange;
        private System.Windows.Forms.TextBox tbPW;
        private System.Windows.Forms.Panel panelNumpad;
        private System.Windows.Forms.Button btnKey1;
        private System.Windows.Forms.Button btnKey2;
        private System.Windows.Forms.Button btnKey0;
        private System.Windows.Forms.Button btnKey3;
        private System.Windows.Forms.Button btnKey4;
        private System.Windows.Forms.Button btnKeyBS;
        private System.Windows.Forms.Button btnKey5;
        private System.Windows.Forms.Button btnKey9;
        private System.Windows.Forms.Button btnKey6;
        private System.Windows.Forms.Button btnKey8;
        private System.Windows.Forms.Button btnKey7;
        private System.Windows.Forms.Button btnKeyClear;
        private System.Windows.Forms.Panel panelKeyWhite;
        private System.Windows.Forms.DateTimePicker dtpBizDate;
        private System.Windows.Forms.Label lblBizDtTitle;
        private System.Windows.Forms.Label lblLocalDbVersion;
        private System.Windows.Forms.Label lblLocalDbVersionTitle;
    }
}