namespace thepos
{
    partial class frmBusiness
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusiness));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBizClose = new System.Windows.Forms.Button();
            this.btnBizCloseCancel = new System.Windows.Forms.Button();
            this.btnBizOpen = new System.Windows.Forms.Button();
            this.lblBusinessTitle = new System.Windows.Forms.Label();
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
            this.panelBiz = new System.Windows.Forms.Panel();
            this.panelTitleWhite = new System.Windows.Forms.Panel();
            this.panelTitleConsole = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblPosNoTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblPosNo = new System.Windows.Forms.Label();
            this.lblSiteName = new System.Windows.Forms.Label();
            this.lblSiteNameTitle = new System.Windows.Forms.Label();
            this.lblUserNameTitle = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblBizDate = new System.Windows.Forms.Label();
            this.lblBusinessDateTitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelNumpad.SuspendLayout();
            this.panelTitleWhite.SuspendLayout();
            this.panelTitleConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnBizClose);
            this.panel1.Controls.Add(this.btnBizCloseCancel);
            this.panel1.Controls.Add(this.btnBizOpen);
            this.panel1.Controls.Add(this.lblBusinessTitle);
            this.panel1.Controls.Add(this.panelNumpad);
            this.panel1.Location = new System.Drawing.Point(767, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 700);
            this.panel1.TabIndex = 9;
            // 
            // btnBizClose
            // 
            this.btnBizClose.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnBizClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBizClose.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBizClose.ForeColor = System.Drawing.Color.White;
            this.btnBizClose.Location = new System.Drawing.Point(15, 217);
            this.btnBizClose.Name = "btnBizClose";
            this.btnBizClose.Size = new System.Drawing.Size(130, 80);
            this.btnBizClose.TabIndex = 27;
            this.btnBizClose.TabStop = false;
            this.btnBizClose.Text = "영업마감";
            this.btnBizClose.UseVisualStyleBackColor = false;
            this.btnBizClose.Click += new System.EventHandler(this.btnBizClose_Click);
            // 
            // btnBizCloseCancel
            // 
            this.btnBizCloseCancel.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnBizCloseCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBizCloseCancel.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBizCloseCancel.ForeColor = System.Drawing.Color.White;
            this.btnBizCloseCancel.Location = new System.Drawing.Point(151, 217);
            this.btnBizCloseCancel.Name = "btnBizCloseCancel";
            this.btnBizCloseCancel.Size = new System.Drawing.Size(80, 80);
            this.btnBizCloseCancel.TabIndex = 27;
            this.btnBizCloseCancel.TabStop = false;
            this.btnBizCloseCancel.Text = "마감취소";
            this.btnBizCloseCancel.UseVisualStyleBackColor = false;
            this.btnBizCloseCancel.Click += new System.EventHandler(this.btnBizCloseCancel_Click);
            // 
            // btnBizOpen
            // 
            this.btnBizOpen.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnBizOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBizOpen.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBizOpen.ForeColor = System.Drawing.Color.White;
            this.btnBizOpen.Location = new System.Drawing.Point(15, 131);
            this.btnBizOpen.Name = "btnBizOpen";
            this.btnBizOpen.Size = new System.Drawing.Size(130, 80);
            this.btnBizOpen.TabIndex = 27;
            this.btnBizOpen.TabStop = false;
            this.btnBizOpen.Text = "영업개시";
            this.btnBizOpen.UseVisualStyleBackColor = false;
            this.btnBizOpen.Click += new System.EventHandler(this.btnBizOpen_Click);
            // 
            // lblBusinessTitle
            // 
            this.lblBusinessTitle.AutoSize = true;
            this.lblBusinessTitle.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBusinessTitle.ForeColor = System.Drawing.Color.White;
            this.lblBusinessTitle.Location = new System.Drawing.Point(66, 36);
            this.lblBusinessTitle.Name = "lblBusinessTitle";
            this.lblBusinessTitle.Size = new System.Drawing.Size(102, 22);
            this.lblBusinessTitle.TabIndex = 26;
            this.lblBusinessTitle.Text = "영업관리";
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
            this.panelNumpad.Location = new System.Drawing.Point(25, 461);
            this.panelNumpad.Margin = new System.Windows.Forms.Padding(30);
            this.panelNumpad.Name = "panelNumpad";
            this.panelNumpad.Padding = new System.Windows.Forms.Padding(30);
            this.panelNumpad.Size = new System.Drawing.Size(190, 218);
            this.panelNumpad.TabIndex = 25;
            // 
            // btnKey1
            // 
            this.btnKey1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey1.ForeColor = System.Drawing.Color.White;
            this.btnKey1.Location = new System.Drawing.Point(0, 3);
            this.btnKey1.Margin = new System.Windows.Forms.Padding(0);
            this.btnKey1.Name = "btnKey1";
            this.btnKey1.Size = new System.Drawing.Size(60, 48);
            this.btnKey1.TabIndex = 1;
            this.btnKey1.TabStop = false;
            this.btnKey1.Text = "1";
            this.btnKey1.UseVisualStyleBackColor = false;
            // 
            // btnKey2
            // 
            this.btnKey2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey2.ForeColor = System.Drawing.Color.White;
            this.btnKey2.Location = new System.Drawing.Point(64, 3);
            this.btnKey2.Name = "btnKey2";
            this.btnKey2.Size = new System.Drawing.Size(60, 48);
            this.btnKey2.TabIndex = 1;
            this.btnKey2.TabStop = false;
            this.btnKey2.Text = "2";
            this.btnKey2.UseVisualStyleBackColor = false;
            // 
            // btnKey0
            // 
            this.btnKey0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey0.ForeColor = System.Drawing.Color.White;
            this.btnKey0.Location = new System.Drawing.Point(128, 159);
            this.btnKey0.Name = "btnKey0";
            this.btnKey0.Size = new System.Drawing.Size(60, 48);
            this.btnKey0.TabIndex = 1;
            this.btnKey0.TabStop = false;
            this.btnKey0.Text = "0";
            this.btnKey0.UseVisualStyleBackColor = false;
            // 
            // btnKey3
            // 
            this.btnKey3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey3.ForeColor = System.Drawing.Color.White;
            this.btnKey3.Location = new System.Drawing.Point(128, 3);
            this.btnKey3.Name = "btnKey3";
            this.btnKey3.Size = new System.Drawing.Size(60, 48);
            this.btnKey3.TabIndex = 1;
            this.btnKey3.TabStop = false;
            this.btnKey3.Text = "3";
            this.btnKey3.UseVisualStyleBackColor = false;
            // 
            // btnKey4
            // 
            this.btnKey4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey4.ForeColor = System.Drawing.Color.White;
            this.btnKey4.Location = new System.Drawing.Point(0, 55);
            this.btnKey4.Name = "btnKey4";
            this.btnKey4.Size = new System.Drawing.Size(60, 48);
            this.btnKey4.TabIndex = 1;
            this.btnKey4.TabStop = false;
            this.btnKey4.Text = "4";
            this.btnKey4.UseVisualStyleBackColor = false;
            // 
            // btnKeyBS
            // 
            this.btnKeyBS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKeyBS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyBS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKeyBS.ForeColor = System.Drawing.Color.White;
            this.btnKeyBS.Location = new System.Drawing.Point(64, 159);
            this.btnKeyBS.Name = "btnKeyBS";
            this.btnKeyBS.Size = new System.Drawing.Size(60, 48);
            this.btnKeyBS.TabIndex = 1;
            this.btnKeyBS.TabStop = false;
            this.btnKeyBS.Text = "<";
            this.btnKeyBS.UseVisualStyleBackColor = false;
            // 
            // btnKey5
            // 
            this.btnKey5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey5.ForeColor = System.Drawing.Color.White;
            this.btnKey5.Location = new System.Drawing.Point(64, 55);
            this.btnKey5.Name = "btnKey5";
            this.btnKey5.Size = new System.Drawing.Size(60, 48);
            this.btnKey5.TabIndex = 1;
            this.btnKey5.TabStop = false;
            this.btnKey5.Text = "5";
            this.btnKey5.UseVisualStyleBackColor = false;
            // 
            // btnKey9
            // 
            this.btnKey9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey9.ForeColor = System.Drawing.Color.White;
            this.btnKey9.Location = new System.Drawing.Point(128, 107);
            this.btnKey9.Name = "btnKey9";
            this.btnKey9.Size = new System.Drawing.Size(60, 48);
            this.btnKey9.TabIndex = 1;
            this.btnKey9.TabStop = false;
            this.btnKey9.Text = "9";
            this.btnKey9.UseVisualStyleBackColor = false;
            // 
            // btnKey6
            // 
            this.btnKey6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey6.ForeColor = System.Drawing.Color.White;
            this.btnKey6.Location = new System.Drawing.Point(128, 55);
            this.btnKey6.Name = "btnKey6";
            this.btnKey6.Size = new System.Drawing.Size(60, 48);
            this.btnKey6.TabIndex = 1;
            this.btnKey6.TabStop = false;
            this.btnKey6.Text = "6";
            this.btnKey6.UseVisualStyleBackColor = false;
            // 
            // btnKey8
            // 
            this.btnKey8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey8.ForeColor = System.Drawing.Color.White;
            this.btnKey8.Location = new System.Drawing.Point(64, 107);
            this.btnKey8.Name = "btnKey8";
            this.btnKey8.Size = new System.Drawing.Size(60, 48);
            this.btnKey8.TabIndex = 1;
            this.btnKey8.TabStop = false;
            this.btnKey8.Text = "8";
            this.btnKey8.UseVisualStyleBackColor = false;
            // 
            // btnKey7
            // 
            this.btnKey7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey7.ForeColor = System.Drawing.Color.White;
            this.btnKey7.Location = new System.Drawing.Point(0, 107);
            this.btnKey7.Name = "btnKey7";
            this.btnKey7.Size = new System.Drawing.Size(60, 48);
            this.btnKey7.TabIndex = 1;
            this.btnKey7.TabStop = false;
            this.btnKey7.Text = "7";
            this.btnKey7.UseVisualStyleBackColor = false;
            // 
            // btnKeyClear
            // 
            this.btnKeyClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKeyClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKeyClear.ForeColor = System.Drawing.Color.White;
            this.btnKeyClear.Location = new System.Drawing.Point(0, 159);
            this.btnKeyClear.Name = "btnKeyClear";
            this.btnKeyClear.Size = new System.Drawing.Size(60, 48);
            this.btnKeyClear.TabIndex = 1;
            this.btnKeyClear.TabStop = false;
            this.btnKeyClear.Text = "C";
            this.btnKeyClear.UseVisualStyleBackColor = false;
            // 
            // panelBiz
            // 
            this.panelBiz.Location = new System.Drawing.Point(7, 58);
            this.panelBiz.Name = "panelBiz";
            this.panelBiz.Size = new System.Drawing.Size(750, 700);
            this.panelBiz.TabIndex = 10;
            // 
            // panelTitleWhite
            // 
            this.panelTitleWhite.BackColor = System.Drawing.Color.Gray;
            this.panelTitleWhite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitleWhite.Controls.Add(this.panelTitleConsole);
            this.panelTitleWhite.ForeColor = System.Drawing.Color.White;
            this.panelTitleWhite.Location = new System.Drawing.Point(6, 5);
            this.panelTitleWhite.Margin = new System.Windows.Forms.Padding(1);
            this.panelTitleWhite.Name = "panelTitleWhite";
            this.panelTitleWhite.Padding = new System.Windows.Forms.Padding(1);
            this.panelTitleWhite.Size = new System.Drawing.Size(1011, 44);
            this.panelTitleWhite.TabIndex = 34;
            // 
            // panelTitleConsole
            // 
            this.panelTitleConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.panelTitleConsole.Controls.Add(this.picLogo);
            this.panelTitleConsole.Controls.Add(this.lblPosNoTitle);
            this.panelTitleConsole.Controls.Add(this.btnClose);
            this.panelTitleConsole.Controls.Add(this.lblPosNo);
            this.panelTitleConsole.Controls.Add(this.lblSiteName);
            this.panelTitleConsole.Controls.Add(this.lblSiteNameTitle);
            this.panelTitleConsole.Controls.Add(this.lblUserNameTitle);
            this.panelTitleConsole.Controls.Add(this.lblUserName);
            this.panelTitleConsole.Controls.Add(this.lblBizDate);
            this.panelTitleConsole.Controls.Add(this.lblBusinessDateTitle);
            this.panelTitleConsole.Controls.Add(this.lblDate);
            this.panelTitleConsole.Controls.Add(this.lblTime);
            this.panelTitleConsole.Location = new System.Drawing.Point(0, 0);
            this.panelTitleConsole.Name = "panelTitleConsole";
            this.panelTitleConsole.Size = new System.Drawing.Size(1009, 42);
            this.panelTitleConsole.TabIndex = 33;
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("picLogo.InitialImage")));
            this.picLogo.Location = new System.Drawing.Point(7, 4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Padding = new System.Windows.Forms.Padding(8);
            this.picLogo.Size = new System.Drawing.Size(80, 35);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 39;
            this.picLogo.TabStop = false;
            // 
            // lblPosNoTitle
            // 
            this.lblPosNoTitle.AutoSize = true;
            this.lblPosNoTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPosNoTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPosNoTitle.ForeColor = System.Drawing.Color.White;
            this.lblPosNoTitle.Location = new System.Drawing.Point(292, 13);
            this.lblPosNoTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblPosNoTitle.Name = "lblPosNoTitle";
            this.lblPosNoTitle.Size = new System.Drawing.Size(56, 17);
            this.lblPosNoTitle.TabIndex = 31;
            this.lblPosNoTitle.Text = "포스번호";
            this.lblPosNoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.Color.LightGray;
            this.btnClose.Location = new System.Drawing.Point(968, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(39, 38);
            this.btnClose.TabIndex = 38;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblPosNo
            // 
            this.lblPosNo.AutoSize = true;
            this.lblPosNo.BackColor = System.Drawing.Color.Transparent;
            this.lblPosNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPosNo.ForeColor = System.Drawing.Color.Gold;
            this.lblPosNo.Location = new System.Drawing.Point(348, 13);
            this.lblPosNo.Margin = new System.Windows.Forms.Padding(0);
            this.lblPosNo.Name = "lblPosNo";
            this.lblPosNo.Size = new System.Drawing.Size(24, 17);
            this.lblPosNo.TabIndex = 31;
            this.lblPosNo.Text = "01";
            this.lblPosNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSiteName
            // 
            this.lblSiteName.AutoSize = true;
            this.lblSiteName.BackColor = System.Drawing.Color.Transparent;
            this.lblSiteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSiteName.ForeColor = System.Drawing.Color.Gold;
            this.lblSiteName.Location = new System.Drawing.Point(174, 13);
            this.lblSiteName.Margin = new System.Windows.Forms.Padding(0);
            this.lblSiteName.Name = "lblSiteName";
            this.lblSiteName.Size = new System.Drawing.Size(16, 17);
            this.lblSiteName.TabIndex = 31;
            this.lblSiteName.Text = "_";
            this.lblSiteName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSiteNameTitle
            // 
            this.lblSiteNameTitle.AutoSize = true;
            this.lblSiteNameTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSiteNameTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSiteNameTitle.ForeColor = System.Drawing.Color.White;
            this.lblSiteNameTitle.Location = new System.Drawing.Point(118, 13);
            this.lblSiteNameTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblSiteNameTitle.Name = "lblSiteNameTitle";
            this.lblSiteNameTitle.Size = new System.Drawing.Size(56, 17);
            this.lblSiteNameTitle.TabIndex = 31;
            this.lblSiteNameTitle.Text = "사업장명";
            this.lblSiteNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserNameTitle
            // 
            this.lblUserNameTitle.AutoSize = true;
            this.lblUserNameTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblUserNameTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblUserNameTitle.ForeColor = System.Drawing.Color.White;
            this.lblUserNameTitle.Location = new System.Drawing.Point(408, 13);
            this.lblUserNameTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblUserNameTitle.Name = "lblUserNameTitle";
            this.lblUserNameTitle.Size = new System.Drawing.Size(56, 17);
            this.lblUserNameTitle.TabIndex = 31;
            this.lblUserNameTitle.Text = "담당자명";
            this.lblUserNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblUserName.ForeColor = System.Drawing.Color.Gold;
            this.lblUserName.Location = new System.Drawing.Point(464, 13);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(16, 17);
            this.lblUserName.TabIndex = 31;
            this.lblUserName.Text = "_";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBizDate
            // 
            this.lblBizDate.AutoSize = true;
            this.lblBizDate.BackColor = System.Drawing.Color.Transparent;
            this.lblBizDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblBizDate.ForeColor = System.Drawing.Color.Gold;
            this.lblBizDate.Location = new System.Drawing.Point(624, 12);
            this.lblBizDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblBizDate.Name = "lblBizDate";
            this.lblBizDate.Size = new System.Drawing.Size(101, 20);
            this.lblBizDate.TabIndex = 31;
            this.lblBizDate.Text = "2023-08-25";
            this.lblBizDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBusinessDateTitle
            // 
            this.lblBusinessDateTitle.AutoSize = true;
            this.lblBusinessDateTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblBusinessDateTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblBusinessDateTitle.ForeColor = System.Drawing.Color.White;
            this.lblBusinessDateTitle.Location = new System.Drawing.Point(568, 13);
            this.lblBusinessDateTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblBusinessDateTitle.Name = "lblBusinessDateTitle";
            this.lblBusinessDateTitle.Size = new System.Drawing.Size(56, 17);
            this.lblBusinessDateTitle.TabIndex = 31;
            this.lblBusinessDateTitle.Text = "영업일자";
            this.lblBusinessDateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(782, 13);
            this.lblDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(104, 17);
            this.lblDate.TabIndex = 31;
            this.lblDate.Text = "2020.00.00 [일]";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTime.ForeColor = System.Drawing.Color.Gold;
            this.lblTime.Location = new System.Drawing.Point(893, 12);
            this.lblTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(54, 20);
            this.lblTime.TabIndex = 31;
            this.lblTime.Text = "00:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBusiness
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.panelTitleWhite);
            this.Controls.Add(this.panelBiz);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBusiness";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmBusiness";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelNumpad.ResumeLayout(false);
            this.panelTitleWhite.ResumeLayout(false);
            this.panelTitleConsole.ResumeLayout(false);
            this.panelTitleConsole.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelBiz;
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
        private System.Windows.Forms.Label lblBusinessTitle;
        private System.Windows.Forms.Panel panelTitleWhite;
        private System.Windows.Forms.Button btnBizOpen;
        private System.Windows.Forms.Button btnBizClose;
        private System.Windows.Forms.Button btnBizCloseCancel;
        private System.Windows.Forms.Panel panelTitleConsole;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblPosNoTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblPosNo;
        private System.Windows.Forms.Label lblSiteName;
        private System.Windows.Forms.Label lblSiteNameTitle;
        private System.Windows.Forms.Label lblUserNameTitle;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblBizDate;
        private System.Windows.Forms.Label lblBusinessDateTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
    }
}