namespace thepos._9SysAdmin
{
    partial class frmSysSite
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSiteName = new System.Windows.Forms.Label();
            this.tbSiteName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbBizTelNo = new System.Windows.Forms.TextBox();
            this.tbBizAddr = new System.Windows.Forms.TextBox();
            this.tbCapName = new System.Windows.Forms.TextBox();
            this.tbRegistNo = new System.Windows.Forms.TextBox();
            this.tbSiteAlias = new System.Windows.Forms.TextBox();
            this.lblBizTelNo = new System.Windows.Forms.Label();
            this.lblBizAddr = new System.Windows.Forms.Label();
            this.lblCapName = new System.Windows.Forms.Label();
            this.lblRegistNo = new System.Windows.Forms.Label();
            this.lblSiteAlias = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbVanCode = new System.Windows.Forms.ComboBox();
            this.cbTicketMedia = new System.Windows.Forms.ComboBox();
            this.cbTicketType = new System.Windows.Forms.ComboBox();
            this.tbCallCenter = new System.Windows.Forms.TextBox();
            this.lblCallCenter = new System.Windows.Forms.Label();
            this.lblVanCode = new System.Windows.Forms.Label();
            this.lblTicketMedia = new System.Windows.Forms.Label();
            this.lblTicketType = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnX1 = new System.Windows.Forms.Button();
            this.pbBillImage = new System.Windows.Forms.PictureBox();
            this.lblBillImage = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblCutoffTime1 = new System.Windows.Forms.Label();
            this.lblCutoffTime2 = new System.Windows.Forms.Label();
            this.cbCutoffType = new System.Windows.Forms.ComboBox();
            this.tbCutoffTime = new System.Windows.Forms.TextBox();
            this.lblCutoffTime = new System.Windows.Forms.Label();
            this.lblCutoffType = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbAllimTN = new System.Windows.Forms.ComboBox();
            this.tbSenderProfile = new System.Windows.Forms.TextBox();
            this.lblSenderProfile = new System.Windows.Forms.Label();
            this.lblAllimTN = new System.Windows.Forms.Label();
            this.btnViewProfile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBillImage)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(658, 600);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(156, 50);
            this.btnUpdate.TabIndex = 52;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle.Location = new System.Drawing.Point(29, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(82, 14);
            this.lblTitle.TabIndex = 51;
            this.lblTitle.Text = "사업자 정보";
            // 
            // lblSiteName
            // 
            this.lblSiteName.AutoSize = true;
            this.lblSiteName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSiteName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSiteName.Location = new System.Drawing.Point(13, 24);
            this.lblSiteName.Name = "lblSiteName";
            this.lblSiteName.Size = new System.Drawing.Size(77, 14);
            this.lblSiteName.TabIndex = 53;
            this.lblSiteName.Text = "사업자원명";
            // 
            // tbSiteName
            // 
            this.tbSiteName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSiteName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSiteName.Location = new System.Drawing.Point(98, 18);
            this.tbSiteName.Name = "tbSiteName";
            this.tbSiteName.Size = new System.Drawing.Size(157, 23);
            this.tbSiteName.TabIndex = 54;
            this.tbSiteName.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbBizTelNo);
            this.groupBox1.Controls.Add(this.tbBizAddr);
            this.groupBox1.Controls.Add(this.tbCapName);
            this.groupBox1.Controls.Add(this.tbRegistNo);
            this.groupBox1.Controls.Add(this.tbSiteAlias);
            this.groupBox1.Controls.Add(this.tbSiteName);
            this.groupBox1.Controls.Add(this.lblBizTelNo);
            this.groupBox1.Controls.Add(this.lblBizAddr);
            this.groupBox1.Controls.Add(this.lblCapName);
            this.groupBox1.Controls.Add(this.lblRegistNo);
            this.groupBox1.Controls.Add(this.lblSiteAlias);
            this.groupBox1.Controls.Add(this.lblSiteName);
            this.groupBox1.Location = new System.Drawing.Point(33, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 193);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            // 
            // tbBizTelNo
            // 
            this.tbBizTelNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbBizTelNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbBizTelNo.Location = new System.Drawing.Point(98, 158);
            this.tbBizTelNo.Name = "tbBizTelNo";
            this.tbBizTelNo.Size = new System.Drawing.Size(157, 23);
            this.tbBizTelNo.TabIndex = 54;
            this.tbBizTelNo.TabStop = false;
            // 
            // tbBizAddr
            // 
            this.tbBizAddr.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbBizAddr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbBizAddr.Location = new System.Drawing.Point(98, 130);
            this.tbBizAddr.Name = "tbBizAddr";
            this.tbBizAddr.Size = new System.Drawing.Size(353, 23);
            this.tbBizAddr.TabIndex = 54;
            this.tbBizAddr.TabStop = false;
            // 
            // tbCapName
            // 
            this.tbCapName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbCapName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbCapName.Location = new System.Drawing.Point(98, 102);
            this.tbCapName.Name = "tbCapName";
            this.tbCapName.Size = new System.Drawing.Size(157, 23);
            this.tbCapName.TabIndex = 54;
            this.tbCapName.TabStop = false;
            // 
            // tbRegistNo
            // 
            this.tbRegistNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbRegistNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbRegistNo.Location = new System.Drawing.Point(98, 74);
            this.tbRegistNo.Name = "tbRegistNo";
            this.tbRegistNo.Size = new System.Drawing.Size(157, 23);
            this.tbRegistNo.TabIndex = 54;
            this.tbRegistNo.TabStop = false;
            // 
            // tbSiteAlias
            // 
            this.tbSiteAlias.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSiteAlias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSiteAlias.Location = new System.Drawing.Point(98, 46);
            this.tbSiteAlias.Name = "tbSiteAlias";
            this.tbSiteAlias.Size = new System.Drawing.Size(157, 23);
            this.tbSiteAlias.TabIndex = 54;
            this.tbSiteAlias.TabStop = false;
            // 
            // lblBizTelNo
            // 
            this.lblBizTelNo.AutoSize = true;
            this.lblBizTelNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBizTelNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBizTelNo.Location = new System.Drawing.Point(13, 164);
            this.lblBizTelNo.Name = "lblBizTelNo";
            this.lblBizTelNo.Size = new System.Drawing.Size(63, 14);
            this.lblBizTelNo.TabIndex = 53;
            this.lblBizTelNo.Text = "전화번호";
            // 
            // lblBizAddr
            // 
            this.lblBizAddr.AutoSize = true;
            this.lblBizAddr.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBizAddr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBizAddr.Location = new System.Drawing.Point(23, 145);
            this.lblBizAddr.Name = "lblBizAddr";
            this.lblBizAddr.Size = new System.Drawing.Size(35, 14);
            this.lblBizAddr.TabIndex = 53;
            this.lblBizAddr.Text = "주소";
            // 
            // lblCapName
            // 
            this.lblCapName.AutoSize = true;
            this.lblCapName.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCapName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCapName.Location = new System.Drawing.Point(13, 108);
            this.lblCapName.Name = "lblCapName";
            this.lblCapName.Size = new System.Drawing.Size(63, 14);
            this.lblCapName.TabIndex = 53;
            this.lblCapName.Text = "대표자명";
            // 
            // lblRegistNo
            // 
            this.lblRegistNo.AutoSize = true;
            this.lblRegistNo.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRegistNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRegistNo.Location = new System.Drawing.Point(13, 80);
            this.lblRegistNo.Name = "lblRegistNo";
            this.lblRegistNo.Size = new System.Drawing.Size(77, 14);
            this.lblRegistNo.TabIndex = 53;
            this.lblRegistNo.Text = "사업자번호";
            // 
            // lblSiteAlias
            // 
            this.lblSiteAlias.AutoSize = true;
            this.lblSiteAlias.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSiteAlias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSiteAlias.Location = new System.Drawing.Point(13, 52);
            this.lblSiteAlias.Name = "lblSiteAlias";
            this.lblSiteAlias.Size = new System.Drawing.Size(77, 14);
            this.lblSiteAlias.TabIndex = 53;
            this.lblSiteAlias.Text = "사업자약명";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbVanCode);
            this.groupBox2.Controls.Add(this.cbTicketMedia);
            this.groupBox2.Controls.Add(this.cbTicketType);
            this.groupBox2.Controls.Add(this.tbCallCenter);
            this.groupBox2.Controls.Add(this.lblCallCenter);
            this.groupBox2.Controls.Add(this.lblVanCode);
            this.groupBox2.Controls.Add(this.lblTicketMedia);
            this.groupBox2.Controls.Add(this.lblTicketType);
            this.groupBox2.Location = new System.Drawing.Point(33, 241);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 140);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            // 
            // cbVanCode
            // 
            this.cbVanCode.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbVanCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbVanCode.FormattingEnabled = true;
            this.cbVanCode.Location = new System.Drawing.Point(98, 75);
            this.cbVanCode.Name = "cbVanCode";
            this.cbVanCode.Size = new System.Drawing.Size(156, 21);
            this.cbVanCode.TabIndex = 58;
            this.cbVanCode.TabStop = false;
            // 
            // cbTicketMedia
            // 
            this.cbTicketMedia.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbTicketMedia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbTicketMedia.FormattingEnabled = true;
            this.cbTicketMedia.Location = new System.Drawing.Point(98, 47);
            this.cbTicketMedia.Name = "cbTicketMedia";
            this.cbTicketMedia.Size = new System.Drawing.Size(156, 21);
            this.cbTicketMedia.TabIndex = 57;
            this.cbTicketMedia.TabStop = false;
            // 
            // cbTicketType
            // 
            this.cbTicketType.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbTicketType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbTicketType.FormattingEnabled = true;
            this.cbTicketType.Location = new System.Drawing.Point(98, 19);
            this.cbTicketType.Name = "cbTicketType";
            this.cbTicketType.Size = new System.Drawing.Size(156, 21);
            this.cbTicketType.TabIndex = 56;
            this.cbTicketType.TabStop = false;
            // 
            // tbCallCenter
            // 
            this.tbCallCenter.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbCallCenter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbCallCenter.Location = new System.Drawing.Point(98, 104);
            this.tbCallCenter.Name = "tbCallCenter";
            this.tbCallCenter.Size = new System.Drawing.Size(352, 23);
            this.tbCallCenter.TabIndex = 55;
            this.tbCallCenter.TabStop = false;
            // 
            // lblCallCenter
            // 
            this.lblCallCenter.AutoSize = true;
            this.lblCallCenter.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCallCenter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCallCenter.Location = new System.Drawing.Point(13, 109);
            this.lblCallCenter.Name = "lblCallCenter";
            this.lblCallCenter.Size = new System.Drawing.Size(77, 14);
            this.lblCallCenter.TabIndex = 54;
            this.lblCallCenter.Text = "콜센터표시";
            // 
            // lblVanCode
            // 
            this.lblVanCode.AutoSize = true;
            this.lblVanCode.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblVanCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVanCode.Location = new System.Drawing.Point(13, 78);
            this.lblVanCode.Name = "lblVanCode";
            this.lblVanCode.Size = new System.Drawing.Size(63, 14);
            this.lblVanCode.TabIndex = 54;
            this.lblVanCode.Text = "결제밴사";
            // 
            // lblTicketMedia
            // 
            this.lblTicketMedia.AutoSize = true;
            this.lblTicketMedia.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTicketMedia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTicketMedia.Location = new System.Drawing.Point(13, 50);
            this.lblTicketMedia.Name = "lblTicketMedia";
            this.lblTicketMedia.Size = new System.Drawing.Size(63, 14);
            this.lblTicketMedia.TabIndex = 54;
            this.lblTicketMedia.Text = "티켓수단";
            // 
            // lblTicketType
            // 
            this.lblTicketType.AutoSize = true;
            this.lblTicketType.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTicketType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTicketType.Location = new System.Drawing.Point(13, 22);
            this.lblTicketType.Name = "lblTicketType";
            this.lblTicketType.Size = new System.Drawing.Size(63, 14);
            this.lblTicketType.TabIndex = 54;
            this.lblTicketType.Text = "티켓유형";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnX1);
            this.groupBox3.Controls.Add(this.pbBillImage);
            this.groupBox3.Controls.Add(this.lblBillImage);
            this.groupBox3.Location = new System.Drawing.Point(34, 488);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(464, 102);
            this.groupBox3.TabIndex = 57;
            this.groupBox3.TabStop = false;
            // 
            // btnX1
            // 
            this.btnX1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnX1.ForeColor = System.Drawing.Color.DimGray;
            this.btnX1.Location = new System.Drawing.Point(382, 60);
            this.btnX1.Name = "btnX1";
            this.btnX1.Size = new System.Drawing.Size(33, 30);
            this.btnX1.TabIndex = 55;
            this.btnX1.TabStop = false;
            this.btnX1.Text = "X";
            this.btnX1.UseVisualStyleBackColor = true;
            this.btnX1.Click += new System.EventHandler(this.btnX1_Click);
            // 
            // pbBillImage
            // 
            this.pbBillImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBillImage.Location = new System.Drawing.Point(98, 19);
            this.pbBillImage.Name = "pbBillImage";
            this.pbBillImage.Size = new System.Drawing.Size(259, 71);
            this.pbBillImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBillImage.TabIndex = 56;
            this.pbBillImage.TabStop = false;
            this.pbBillImage.Click += new System.EventHandler(this.pbBillImage_Click);
            // 
            // lblBillImage
            // 
            this.lblBillImage.AutoSize = true;
            this.lblBillImage.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBillImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBillImage.Location = new System.Drawing.Point(13, 19);
            this.lblBillImage.Name = "lblBillImage";
            this.lblBillImage.Size = new System.Drawing.Size(49, 42);
            this.lblBillImage.TabIndex = 54;
            this.lblBillImage.Text = "영수증\r\n이미지\r\n(JPG)";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblCutoffTime1);
            this.groupBox4.Controls.Add(this.lblCutoffTime2);
            this.groupBox4.Controls.Add(this.cbCutoffType);
            this.groupBox4.Controls.Add(this.tbCutoffTime);
            this.groupBox4.Controls.Add(this.lblCutoffTime);
            this.groupBox4.Controls.Add(this.lblCutoffType);
            this.groupBox4.Location = new System.Drawing.Point(32, 383);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(465, 102);
            this.groupBox4.TabIndex = 58;
            this.groupBox4.TabStop = false;
            // 
            // lblCutoffTime1
            // 
            this.lblCutoffTime1.AutoSize = true;
            this.lblCutoffTime1.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCutoffTime1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCutoffTime1.Location = new System.Drawing.Point(233, 55);
            this.lblCutoffTime1.Name = "lblCutoffTime1";
            this.lblCutoffTime1.Size = new System.Drawing.Size(102, 14);
            this.lblCutoffTime1.TabIndex = 57;
            this.lblCutoffTime1.Text = "00:00 ~ 23:59";
            // 
            // lblCutoffTime2
            // 
            this.lblCutoffTime2.AutoSize = true;
            this.lblCutoffTime2.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCutoffTime2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCutoffTime2.Location = new System.Drawing.Point(98, 78);
            this.lblCutoffTime2.Name = "lblCutoffTime2";
            this.lblCutoffTime2.Size = new System.Drawing.Size(162, 14);
            this.lblCutoffTime2.TabIndex = 57;
            this.lblCutoffTime2.Text = "Ex} 02:30 -> 0230입력";
            // 
            // cbCutoffType
            // 
            this.cbCutoffType.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbCutoffType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbCutoffType.FormattingEnabled = true;
            this.cbCutoffType.Location = new System.Drawing.Point(98, 18);
            this.cbCutoffType.Name = "cbCutoffType";
            this.cbCutoffType.Size = new System.Drawing.Size(129, 21);
            this.cbCutoffType.TabIndex = 56;
            this.cbCutoffType.TabStop = false;
            // 
            // tbCutoffTime
            // 
            this.tbCutoffTime.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbCutoffTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbCutoffTime.Location = new System.Drawing.Point(98, 49);
            this.tbCutoffTime.MaxLength = 4;
            this.tbCutoffTime.Name = "tbCutoffTime";
            this.tbCutoffTime.Size = new System.Drawing.Size(131, 23);
            this.tbCutoffTime.TabIndex = 55;
            this.tbCutoffTime.TabStop = false;
            // 
            // lblCutoffTime
            // 
            this.lblCutoffTime.AutoSize = true;
            this.lblCutoffTime.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCutoffTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCutoffTime.Location = new System.Drawing.Point(13, 54);
            this.lblCutoffTime.Name = "lblCutoffTime";
            this.lblCutoffTime.Size = new System.Drawing.Size(63, 14);
            this.lblCutoffTime.TabIndex = 54;
            this.lblCutoffTime.Text = "마감시간";
            // 
            // lblCutoffType
            // 
            this.lblCutoffType.AutoSize = true;
            this.lblCutoffType.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCutoffType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCutoffType.Location = new System.Drawing.Point(13, 22);
            this.lblCutoffType.Name = "lblCutoffType";
            this.lblCutoffType.Size = new System.Drawing.Size(63, 14);
            this.lblCutoffType.TabIndex = 54;
            this.lblCutoffType.Text = "마감유형";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnViewProfile);
            this.groupBox5.Controls.Add(this.cbAllimTN);
            this.groupBox5.Controls.Add(this.tbSenderProfile);
            this.groupBox5.Controls.Add(this.lblSenderProfile);
            this.groupBox5.Controls.Add(this.lblAllimTN);
            this.groupBox5.Location = new System.Drawing.Point(516, 47);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(287, 159);
            this.groupBox5.TabIndex = 59;
            this.groupBox5.TabStop = false;
            // 
            // cbAllimTN
            // 
            this.cbAllimTN.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbAllimTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbAllimTN.FormattingEnabled = true;
            this.cbAllimTN.Location = new System.Drawing.Point(107, 21);
            this.cbAllimTN.Name = "cbAllimTN";
            this.cbAllimTN.Size = new System.Drawing.Size(156, 21);
            this.cbAllimTN.TabIndex = 57;
            this.cbAllimTN.TabStop = false;
            // 
            // tbSenderProfile
            // 
            this.tbSenderProfile.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbSenderProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSenderProfile.Location = new System.Drawing.Point(107, 52);
            this.tbSenderProfile.Name = "tbSenderProfile";
            this.tbSenderProfile.Size = new System.Drawing.Size(157, 23);
            this.tbSenderProfile.TabIndex = 56;
            this.tbSenderProfile.TabStop = false;
            // 
            // lblSenderProfile
            // 
            this.lblSenderProfile.AutoSize = true;
            this.lblSenderProfile.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSenderProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSenderProfile.Location = new System.Drawing.Point(23, 55);
            this.lblSenderProfile.Name = "lblSenderProfile";
            this.lblSenderProfile.Size = new System.Drawing.Size(77, 14);
            this.lblSenderProfile.TabIndex = 54;
            this.lblSenderProfile.Text = "발신프로필";
            // 
            // lblAllimTN
            // 
            this.lblAllimTN.AutoSize = true;
            this.lblAllimTN.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAllimTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAllimTN.Location = new System.Drawing.Point(23, 25);
            this.lblAllimTN.Name = "lblAllimTN";
            this.lblAllimTN.Size = new System.Drawing.Size(77, 14);
            this.lblAllimTN.TabIndex = 54;
            this.lblAllimTN.Text = "알림톡사용";
            // 
            // btnViewProfile
            // 
            this.btnViewProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewProfile.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewProfile.ForeColor = System.Drawing.Color.DimGray;
            this.btnViewProfile.Location = new System.Drawing.Point(107, 102);
            this.btnViewProfile.Name = "btnViewProfile";
            this.btnViewProfile.Size = new System.Drawing.Size(109, 30);
            this.btnViewProfile.TabIndex = 58;
            this.btnViewProfile.TabStop = false;
            this.btnViewProfile.Text = "프로필보기";
            this.btnViewProfile.UseVisualStyleBackColor = true;
            this.btnViewProfile.Click += new System.EventHandler(this.btnViewProfile_Click);
            // 
            // frmSysSite
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(870, 710);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSysSite";
            this.Text = "frmSysShop";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBillImage)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSiteName;
        private System.Windows.Forms.TextBox tbSiteName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRegistNo;
        private System.Windows.Forms.TextBox tbRegistNo;
        private System.Windows.Forms.TextBox tbSiteAlias;
        private System.Windows.Forms.Label lblCapName;
        private System.Windows.Forms.Label lblSiteAlias;
        private System.Windows.Forms.TextBox tbCapName;
        private System.Windows.Forms.TextBox tbBizTelNo;
        private System.Windows.Forms.TextBox tbBizAddr;
        private System.Windows.Forms.Label lblBizTelNo;
        private System.Windows.Forms.Label lblBizAddr;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbCallCenter;
        private System.Windows.Forms.Label lblCallCenter;
        private System.Windows.Forms.Label lblVanCode;
        private System.Windows.Forms.Label lblTicketMedia;
        private System.Windows.Forms.Label lblTicketType;
        private System.Windows.Forms.ComboBox cbVanCode;
        private System.Windows.Forms.ComboBox cbTicketMedia;
        private System.Windows.Forms.ComboBox cbTicketType;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblBillImage;
        private System.Windows.Forms.Button btnX1;
        private System.Windows.Forms.PictureBox pbBillImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbCutoffType;
        private System.Windows.Forms.TextBox tbCutoffTime;
        private System.Windows.Forms.Label lblCutoffTime;
        private System.Windows.Forms.Label lblCutoffType;
        private System.Windows.Forms.Label lblCutoffTime1;
        private System.Windows.Forms.Label lblCutoffTime2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cbAllimTN;
        private System.Windows.Forms.TextBox tbSenderProfile;
        private System.Windows.Forms.Label lblSenderProfile;
        private System.Windows.Forms.Label lblAllimTN;
        private System.Windows.Forms.Button btnViewProfile;
    }
}