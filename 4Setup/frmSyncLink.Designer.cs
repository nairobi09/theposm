namespace thepos
{
    partial class frmSyncLink
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
            this.lblDetail = new System.Windows.Forms.Label();
            this.lblServerVersion = new System.Windows.Forms.Label();
            this.lblLocalVersion = new System.Windows.Forms.Label();
            this.lblVersionTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblServerTitle = new System.Windows.Forms.Label();
            this.lblLocalTitle = new System.Windows.Forms.Label();
            this.btnViewVer = new System.Windows.Forms.Button();
            this.lblPaymentCardCnt = new System.Windows.Forms.Label();
            this.lblPaymentCashCnt = new System.Windows.Forms.Label();
            this.lblOrderItemCnt = new System.Windows.Forms.Label();
            this.lblOrdersCnt = new System.Windows.Forms.Label();
            this.lblPaymentCardTitle = new System.Windows.Forms.Label();
            this.lblPaymentCashTitle = new System.Windows.Forms.Label();
            this.lblPaymentTitle = new System.Windows.Forms.Label();
            this.lblOrderItemTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOrdersTitle = new System.Windows.Forms.Label();
            this.lblCntTitle = new System.Windows.Forms.Label();
            this.lblPaymentCnt = new System.Windows.Forms.Label();
            this.btnViewRecord = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPaymentCertCnt = new System.Windows.Forms.Label();
            this.lblPaymentCertTitle = new System.Windows.Forms.Label();
            this.btnDbLoad = new System.Windows.Forms.Button();
            this.lblOrderOptionItemCnt = new System.Windows.Forms.Label();
            this.lblOrderOptionItemTitle = new System.Windows.Forms.Label();
            this.lblTitle3 = new System.Windows.Forms.Label();
            this.lblTitle2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteLog = new System.Windows.Forms.Button();
            this.dtViewDate = new System.Windows.Forms.DateTimePicker();
            this.lvwSyncLink = new System.Windows.Forms.ListView();
            this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.msg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSyncLink = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(37, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(96, 14);
            this.lblTitle.TabIndex = 66;
            this.lblTitle.Text = "데이터 동기화";
            // 
            // lblDetail
            // 
            this.lblDetail.AutoSize = true;
            this.lblDetail.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDetail.Location = new System.Drawing.Point(23, 34);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(198, 84);
            this.lblDetail.TabIndex = 70;
            this.lblDetail.Text = "SyncLink\r\n데이터 동기화 프로그램\r\n\r\n1. 모드 자동전환\r\n2. 서버원장 자동다운로드\r\n3. 로컬거래데이터 자동업로드";
            // 
            // lblServerVersion
            // 
            this.lblServerVersion.BackColor = System.Drawing.Color.LightGray;
            this.lblServerVersion.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblServerVersion.ForeColor = System.Drawing.Color.Black;
            this.lblServerVersion.Location = new System.Drawing.Point(134, 103);
            this.lblServerVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lblServerVersion.Name = "lblServerVersion";
            this.lblServerVersion.Padding = new System.Windows.Forms.Padding(5);
            this.lblServerVersion.Size = new System.Drawing.Size(214, 30);
            this.lblServerVersion.TabIndex = 84;
            this.lblServerVersion.Text = "0";
            this.lblServerVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLocalVersion
            // 
            this.lblLocalVersion.BackColor = System.Drawing.Color.LightGray;
            this.lblLocalVersion.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLocalVersion.ForeColor = System.Drawing.Color.Black;
            this.lblLocalVersion.Location = new System.Drawing.Point(134, 136);
            this.lblLocalVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lblLocalVersion.Name = "lblLocalVersion";
            this.lblLocalVersion.Padding = new System.Windows.Forms.Padding(5);
            this.lblLocalVersion.Size = new System.Drawing.Size(214, 30);
            this.lblLocalVersion.TabIndex = 83;
            this.lblLocalVersion.Text = "0";
            this.lblLocalVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVersionTitle
            // 
            this.lblVersionTitle.BackColor = System.Drawing.Color.DarkGray;
            this.lblVersionTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblVersionTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVersionTitle.Location = new System.Drawing.Point(134, 70);
            this.lblVersionTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblVersionTitle.Name = "lblVersionTitle";
            this.lblVersionTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblVersionTitle.Size = new System.Drawing.Size(214, 30);
            this.lblVersionTitle.TabIndex = 82;
            this.lblVersionTitle.Text = "버전";
            this.lblVersionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkGray;
            this.label1.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(26, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(104, 30);
            this.label1.TabIndex = 80;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblServerTitle
            // 
            this.lblServerTitle.BackColor = System.Drawing.Color.DarkGray;
            this.lblServerTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblServerTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblServerTitle.Location = new System.Drawing.Point(26, 103);
            this.lblServerTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblServerTitle.Name = "lblServerTitle";
            this.lblServerTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblServerTitle.Size = new System.Drawing.Size(104, 30);
            this.lblServerTitle.TabIndex = 81;
            this.lblServerTitle.Text = "서버DB";
            this.lblServerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLocalTitle
            // 
            this.lblLocalTitle.BackColor = System.Drawing.Color.DarkGray;
            this.lblLocalTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLocalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLocalTitle.Location = new System.Drawing.Point(26, 136);
            this.lblLocalTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblLocalTitle.Name = "lblLocalTitle";
            this.lblLocalTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblLocalTitle.Size = new System.Drawing.Size(104, 30);
            this.lblLocalTitle.TabIndex = 79;
            this.lblLocalTitle.Text = "로컬DB";
            this.lblLocalTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnViewVer
            // 
            this.btnViewVer.BackColor = System.Drawing.Color.White;
            this.btnViewVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewVer.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewVer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnViewVer.Location = new System.Drawing.Point(208, 33);
            this.btnViewVer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewVer.Name = "btnViewVer";
            this.btnViewVer.Size = new System.Drawing.Size(140, 30);
            this.btnViewVer.TabIndex = 77;
            this.btnViewVer.TabStop = false;
            this.btnViewVer.Text = "버전보기";
            this.btnViewVer.UseVisualStyleBackColor = false;
            this.btnViewVer.Click += new System.EventHandler(this.btnViewVer_Click);
            // 
            // lblPaymentCardCnt
            // 
            this.lblPaymentCardCnt.BackColor = System.Drawing.Color.LightGray;
            this.lblPaymentCardCnt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPaymentCardCnt.ForeColor = System.Drawing.Color.Blue;
            this.lblPaymentCardCnt.Location = new System.Drawing.Point(134, 458);
            this.lblPaymentCardCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblPaymentCardCnt.Name = "lblPaymentCardCnt";
            this.lblPaymentCardCnt.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaymentCardCnt.Size = new System.Drawing.Size(214, 30);
            this.lblPaymentCardCnt.TabIndex = 105;
            this.lblPaymentCardCnt.Text = "0";
            this.lblPaymentCardCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPaymentCashCnt
            // 
            this.lblPaymentCashCnt.BackColor = System.Drawing.Color.LightGray;
            this.lblPaymentCashCnt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPaymentCashCnt.ForeColor = System.Drawing.Color.Blue;
            this.lblPaymentCashCnt.Location = new System.Drawing.Point(134, 424);
            this.lblPaymentCashCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblPaymentCashCnt.Name = "lblPaymentCashCnt";
            this.lblPaymentCashCnt.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaymentCashCnt.Size = new System.Drawing.Size(214, 30);
            this.lblPaymentCashCnt.TabIndex = 103;
            this.lblPaymentCashCnt.Text = "0";
            this.lblPaymentCashCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrderItemCnt
            // 
            this.lblOrderItemCnt.BackColor = System.Drawing.Color.LightGray;
            this.lblOrderItemCnt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderItemCnt.ForeColor = System.Drawing.Color.Blue;
            this.lblOrderItemCnt.Location = new System.Drawing.Point(134, 322);
            this.lblOrderItemCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrderItemCnt.Name = "lblOrderItemCnt";
            this.lblOrderItemCnt.Padding = new System.Windows.Forms.Padding(5);
            this.lblOrderItemCnt.Size = new System.Drawing.Size(214, 30);
            this.lblOrderItemCnt.TabIndex = 101;
            this.lblOrderItemCnt.Text = "0";
            this.lblOrderItemCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrdersCnt
            // 
            this.lblOrdersCnt.BackColor = System.Drawing.Color.LightGray;
            this.lblOrdersCnt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrdersCnt.ForeColor = System.Drawing.Color.Blue;
            this.lblOrdersCnt.Location = new System.Drawing.Point(134, 288);
            this.lblOrdersCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrdersCnt.Name = "lblOrdersCnt";
            this.lblOrdersCnt.Padding = new System.Windows.Forms.Padding(5);
            this.lblOrdersCnt.Size = new System.Drawing.Size(214, 30);
            this.lblOrdersCnt.TabIndex = 99;
            this.lblOrdersCnt.Text = "0";
            this.lblOrdersCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPaymentCardTitle
            // 
            this.lblPaymentCardTitle.BackColor = System.Drawing.Color.DarkGray;
            this.lblPaymentCardTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPaymentCardTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPaymentCardTitle.Location = new System.Drawing.Point(26, 458);
            this.lblPaymentCardTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblPaymentCardTitle.Name = "lblPaymentCardTitle";
            this.lblPaymentCardTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaymentCardTitle.Size = new System.Drawing.Size(104, 30);
            this.lblPaymentCardTitle.TabIndex = 96;
            this.lblPaymentCardTitle.Text = "카드결제";
            this.lblPaymentCardTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentCashTitle
            // 
            this.lblPaymentCashTitle.BackColor = System.Drawing.Color.DarkGray;
            this.lblPaymentCashTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPaymentCashTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPaymentCashTitle.Location = new System.Drawing.Point(26, 424);
            this.lblPaymentCashTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblPaymentCashTitle.Name = "lblPaymentCashTitle";
            this.lblPaymentCashTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaymentCashTitle.Size = new System.Drawing.Size(104, 30);
            this.lblPaymentCashTitle.TabIndex = 97;
            this.lblPaymentCashTitle.Text = "현금결제";
            this.lblPaymentCashTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentTitle
            // 
            this.lblPaymentTitle.BackColor = System.Drawing.Color.DarkGray;
            this.lblPaymentTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPaymentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPaymentTitle.Location = new System.Drawing.Point(26, 390);
            this.lblPaymentTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblPaymentTitle.Name = "lblPaymentTitle";
            this.lblPaymentTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaymentTitle.Size = new System.Drawing.Size(104, 30);
            this.lblPaymentTitle.TabIndex = 95;
            this.lblPaymentTitle.Text = "결제";
            this.lblPaymentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrderItemTitle
            // 
            this.lblOrderItemTitle.BackColor = System.Drawing.Color.DarkGray;
            this.lblOrderItemTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderItemTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblOrderItemTitle.Location = new System.Drawing.Point(26, 322);
            this.lblOrderItemTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrderItemTitle.Name = "lblOrderItemTitle";
            this.lblOrderItemTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblOrderItemTitle.Size = new System.Drawing.Size(104, 30);
            this.lblOrderItemTitle.TabIndex = 94;
            this.lblOrderItemTitle.Text = "주문항목";
            this.lblOrderItemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(26, 254);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(104, 30);
            this.label2.TabIndex = 93;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrdersTitle
            // 
            this.lblOrdersTitle.BackColor = System.Drawing.Color.DarkGray;
            this.lblOrdersTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrdersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblOrdersTitle.Location = new System.Drawing.Point(26, 288);
            this.lblOrdersTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrdersTitle.Name = "lblOrdersTitle";
            this.lblOrdersTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblOrdersTitle.Size = new System.Drawing.Size(104, 30);
            this.lblOrdersTitle.TabIndex = 92;
            this.lblOrdersTitle.Text = "주문";
            this.lblOrdersTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCntTitle
            // 
            this.lblCntTitle.BackColor = System.Drawing.Color.DarkGray;
            this.lblCntTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCntTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCntTitle.Location = new System.Drawing.Point(134, 254);
            this.lblCntTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblCntTitle.Name = "lblCntTitle";
            this.lblCntTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblCntTitle.Size = new System.Drawing.Size(214, 30);
            this.lblCntTitle.TabIndex = 91;
            this.lblCntTitle.Text = "로컬 건수";
            this.lblCntTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPaymentCnt
            // 
            this.lblPaymentCnt.BackColor = System.Drawing.Color.LightGray;
            this.lblPaymentCnt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPaymentCnt.ForeColor = System.Drawing.Color.Blue;
            this.lblPaymentCnt.Location = new System.Drawing.Point(134, 390);
            this.lblPaymentCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblPaymentCnt.Name = "lblPaymentCnt";
            this.lblPaymentCnt.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaymentCnt.Size = new System.Drawing.Size(214, 30);
            this.lblPaymentCnt.TabIndex = 90;
            this.lblPaymentCnt.Text = "0";
            this.lblPaymentCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnViewRecord
            // 
            this.btnViewRecord.BackColor = System.Drawing.Color.White;
            this.btnViewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewRecord.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewRecord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnViewRecord.Location = new System.Drawing.Point(208, 216);
            this.btnViewRecord.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnViewRecord.Name = "btnViewRecord";
            this.btnViewRecord.Size = new System.Drawing.Size(140, 30);
            this.btnViewRecord.TabIndex = 85;
            this.btnViewRecord.TabStop = false;
            this.btnViewRecord.Text = "건수보기";
            this.btnViewRecord.UseVisualStyleBackColor = false;
            this.btnViewRecord.Click += new System.EventHandler(this.btnViewRecord_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPaymentCertCnt);
            this.groupBox1.Controls.Add(this.lblPaymentCertTitle);
            this.groupBox1.Controls.Add(this.btnDbLoad);
            this.groupBox1.Controls.Add(this.lblOrderOptionItemCnt);
            this.groupBox1.Controls.Add(this.lblOrderOptionItemTitle);
            this.groupBox1.Controls.Add(this.lblTitle3);
            this.groupBox1.Controls.Add(this.lblTitle2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblPaymentCardCnt);
            this.groupBox1.Controls.Add(this.btnViewVer);
            this.groupBox1.Controls.Add(this.lblPaymentCashCnt);
            this.groupBox1.Controls.Add(this.lblLocalTitle);
            this.groupBox1.Controls.Add(this.lblServerTitle);
            this.groupBox1.Controls.Add(this.lblOrderItemCnt);
            this.groupBox1.Controls.Add(this.lblVersionTitle);
            this.groupBox1.Controls.Add(this.lblLocalVersion);
            this.groupBox1.Controls.Add(this.lblOrdersCnt);
            this.groupBox1.Controls.Add(this.lblServerVersion);
            this.groupBox1.Controls.Add(this.btnViewRecord);
            this.groupBox1.Controls.Add(this.lblPaymentCardTitle);
            this.groupBox1.Controls.Add(this.lblPaymentCashTitle);
            this.groupBox1.Controls.Add(this.lblPaymentTitle);
            this.groupBox1.Controls.Add(this.lblOrderItemTitle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblPaymentCnt);
            this.groupBox1.Controls.Add(this.lblOrdersTitle);
            this.groupBox1.Controls.Add(this.lblCntTitle);
            this.groupBox1.Location = new System.Drawing.Point(441, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 618);
            this.groupBox1.TabIndex = 106;
            this.groupBox1.TabStop = false;
            // 
            // lblPaymentCertCnt
            // 
            this.lblPaymentCertCnt.BackColor = System.Drawing.Color.LightGray;
            this.lblPaymentCertCnt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPaymentCertCnt.ForeColor = System.Drawing.Color.Blue;
            this.lblPaymentCertCnt.Location = new System.Drawing.Point(134, 492);
            this.lblPaymentCertCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblPaymentCertCnt.Name = "lblPaymentCertCnt";
            this.lblPaymentCertCnt.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaymentCertCnt.Size = new System.Drawing.Size(214, 30);
            this.lblPaymentCertCnt.TabIndex = 112;
            this.lblPaymentCertCnt.Text = "0";
            this.lblPaymentCertCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPaymentCertTitle
            // 
            this.lblPaymentCertTitle.BackColor = System.Drawing.Color.DarkGray;
            this.lblPaymentCertTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPaymentCertTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPaymentCertTitle.Location = new System.Drawing.Point(26, 492);
            this.lblPaymentCertTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblPaymentCertTitle.Name = "lblPaymentCertTitle";
            this.lblPaymentCertTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaymentCertTitle.Size = new System.Drawing.Size(104, 30);
            this.lblPaymentCertTitle.TabIndex = 111;
            this.lblPaymentCertTitle.Text = "쿠폰인증";
            this.lblPaymentCertTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDbLoad
            // 
            this.btnDbLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDbLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDbLoad.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDbLoad.ForeColor = System.Drawing.Color.White;
            this.btnDbLoad.Location = new System.Drawing.Point(137, 544);
            this.btnDbLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDbLoad.Name = "btnDbLoad";
            this.btnDbLoad.Size = new System.Drawing.Size(211, 50);
            this.btnDbLoad.TabIndex = 110;
            this.btnDbLoad.TabStop = false;
            this.btnDbLoad.Text = "수동 다운로드/업로드";
            this.btnDbLoad.UseVisualStyleBackColor = false;
            this.btnDbLoad.Click += new System.EventHandler(this.btnDbLoad_Click);
            // 
            // lblOrderOptionItemCnt
            // 
            this.lblOrderOptionItemCnt.BackColor = System.Drawing.Color.LightGray;
            this.lblOrderOptionItemCnt.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderOptionItemCnt.ForeColor = System.Drawing.Color.Blue;
            this.lblOrderOptionItemCnt.Location = new System.Drawing.Point(134, 356);
            this.lblOrderOptionItemCnt.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrderOptionItemCnt.Name = "lblOrderOptionItemCnt";
            this.lblOrderOptionItemCnt.Padding = new System.Windows.Forms.Padding(5);
            this.lblOrderOptionItemCnt.Size = new System.Drawing.Size(214, 30);
            this.lblOrderOptionItemCnt.TabIndex = 109;
            this.lblOrderOptionItemCnt.Text = "0";
            this.lblOrderOptionItemCnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrderOptionItemTitle
            // 
            this.lblOrderOptionItemTitle.BackColor = System.Drawing.Color.DarkGray;
            this.lblOrderOptionItemTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderOptionItemTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblOrderOptionItemTitle.Location = new System.Drawing.Point(26, 356);
            this.lblOrderOptionItemTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblOrderOptionItemTitle.Name = "lblOrderOptionItemTitle";
            this.lblOrderOptionItemTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblOrderOptionItemTitle.Size = new System.Drawing.Size(104, 30);
            this.lblOrderOptionItemTitle.TabIndex = 108;
            this.lblOrderOptionItemTitle.Text = "주문옵션항목";
            this.lblOrderOptionItemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle3
            // 
            this.lblTitle3.AutoSize = true;
            this.lblTitle3.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle3.Location = new System.Drawing.Point(26, 228);
            this.lblTitle3.Name = "lblTitle3";
            this.lblTitle3.Size = new System.Drawing.Size(105, 14);
            this.lblTitle3.TabIndex = 107;
            this.lblTitle3.Text = "로컬거래데이터";
            // 
            // lblTitle2
            // 
            this.lblTitle2.AutoSize = true;
            this.lblTitle2.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle2.Location = new System.Drawing.Point(25, 45);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(60, 14);
            this.lblTitle2.TabIndex = 106;
            this.lblTitle2.Text = "원장 DB";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteLog);
            this.groupBox2.Controls.Add(this.dtViewDate);
            this.groupBox2.Controls.Add(this.lvwSyncLink);
            this.groupBox2.Controls.Add(this.btnSyncLink);
            this.groupBox2.Controls.Add(this.lblDetail);
            this.groupBox2.Location = new System.Drawing.Point(34, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(401, 618);
            this.groupBox2.TabIndex = 107;
            this.groupBox2.TabStop = false;
            // 
            // btnDeleteLog
            // 
            this.btnDeleteLog.BackColor = System.Drawing.Color.White;
            this.btnDeleteLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteLog.Font = new System.Drawing.Font("굴림", 9F);
            this.btnDeleteLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDeleteLog.Location = new System.Drawing.Point(316, 159);
            this.btnDeleteLog.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteLog.Name = "btnDeleteLog";
            this.btnDeleteLog.Size = new System.Drawing.Size(68, 27);
            this.btnDeleteLog.TabIndex = 83;
            this.btnDeleteLog.TabStop = false;
            this.btnDeleteLog.Text = "로그삭제";
            this.btnDeleteLog.UseVisualStyleBackColor = false;
            this.btnDeleteLog.Click += new System.EventHandler(this.btnDeleteLog_Click);
            // 
            // dtViewDate
            // 
            this.dtViewDate.CalendarFont = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtViewDate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtViewDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtViewDate.Location = new System.Drawing.Point(26, 159);
            this.dtViewDate.Name = "dtViewDate";
            this.dtViewDate.Size = new System.Drawing.Size(100, 23);
            this.dtViewDate.TabIndex = 82;
            this.dtViewDate.TabStop = false;
            this.dtViewDate.Value = new System.DateTime(2023, 12, 4, 0, 0, 0, 0);
            // 
            // lvwSyncLink
            // 
            this.lvwSyncLink.BackColor = System.Drawing.Color.White;
            this.lvwSyncLink.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.time,
            this.msg});
            this.lvwSyncLink.Font = new System.Drawing.Font("굴림체", 9F);
            this.lvwSyncLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lvwSyncLink.FullRowSelect = true;
            this.lvwSyncLink.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwSyncLink.HideSelection = false;
            this.lvwSyncLink.Location = new System.Drawing.Point(26, 193);
            this.lvwSyncLink.MultiSelect = false;
            this.lvwSyncLink.Name = "lvwSyncLink";
            this.lvwSyncLink.Size = new System.Drawing.Size(358, 401);
            this.lvwSyncLink.TabIndex = 81;
            this.lvwSyncLink.TabStop = false;
            this.lvwSyncLink.UseCompatibleStateImageBehavior = false;
            this.lvwSyncLink.View = System.Windows.Forms.View.Details;
            // 
            // time
            // 
            this.time.Text = "발생";
            this.time.Width = 70;
            // 
            // msg
            // 
            this.msg.Text = "실행";
            this.msg.Width = 260;
            // 
            // btnSyncLink
            // 
            this.btnSyncLink.BackColor = System.Drawing.Color.White;
            this.btnSyncLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSyncLink.Font = new System.Drawing.Font("굴림", 9F);
            this.btnSyncLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSyncLink.Location = new System.Drawing.Point(132, 159);
            this.btnSyncLink.Margin = new System.Windows.Forms.Padding(0);
            this.btnSyncLink.Name = "btnSyncLink";
            this.btnSyncLink.Size = new System.Drawing.Size(106, 27);
            this.btnSyncLink.TabIndex = 78;
            this.btnSyncLink.TabStop = false;
            this.btnSyncLink.Text = "이력보기";
            this.btnSyncLink.UseVisualStyleBackColor = false;
            this.btnSyncLink.Click += new System.EventHandler(this.btnSyncLink_Click);
            // 
            // frmSyncLink
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(850, 700);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("굴림", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSyncLink";
            this.Text = "frmSyncLink";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Label lblServerVersion;
        private System.Windows.Forms.Label lblLocalVersion;
        private System.Windows.Forms.Label lblVersionTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblServerTitle;
        private System.Windows.Forms.Label lblLocalTitle;
        private System.Windows.Forms.Button btnViewVer;
        private System.Windows.Forms.Label lblPaymentCardCnt;
        private System.Windows.Forms.Label lblPaymentCashCnt;
        private System.Windows.Forms.Label lblOrderItemCnt;
        private System.Windows.Forms.Label lblOrdersCnt;
        private System.Windows.Forms.Label lblPaymentCardTitle;
        private System.Windows.Forms.Label lblPaymentCashTitle;
        private System.Windows.Forms.Label lblPaymentTitle;
        private System.Windows.Forms.Label lblOrderItemTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOrdersTitle;
        private System.Windows.Forms.Label lblCntTitle;
        private System.Windows.Forms.Label lblPaymentCnt;
        private System.Windows.Forms.Button btnViewRecord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTitle2;
        private System.Windows.Forms.Label lblTitle3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSyncLink;
        private System.Windows.Forms.ListView lvwSyncLink;
        private System.Windows.Forms.ColumnHeader time;
        private System.Windows.Forms.ColumnHeader msg;
        private System.Windows.Forms.DateTimePicker dtViewDate;
        private System.Windows.Forms.Button btnDeleteLog;
        private System.Windows.Forms.Label lblOrderOptionItemCnt;
        private System.Windows.Forms.Label lblOrderOptionItemTitle;
        private System.Windows.Forms.Button btnDbLoad;
        private System.Windows.Forms.Label lblPaymentCertCnt;
        private System.Windows.Forms.Label lblPaymentCertTitle;
    }
}