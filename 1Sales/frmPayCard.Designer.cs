namespace thepos
{
    partial class frmPayCard
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
            this.panelback = new System.Windows.Forms.Panel();
            this.gbCardTemp = new System.Windows.Forms.GroupBox();
            this.tbAuthNo = new System.Windows.Forms.TextBox();
            this.tbCardNo = new System.Windows.Forms.TextBox();
            this.rbCard7 = new System.Windows.Forms.RadioButton();
            this.lblAuthNoTitle = new System.Windows.Forms.Label();
            this.btnKeyInputAuthNo = new System.Windows.Forms.Button();
            this.btnKeyInputCardNo = new System.Windows.Forms.Button();
            this.rbCard8 = new System.Windows.Forms.RadioButton();
            this.lblCardNoTitle = new System.Windows.Forms.Label();
            this.btnCardTemp = new System.Windows.Forms.Button();
            this.rbCard5 = new System.Windows.Forms.RadioButton();
            this.rbCard6 = new System.Windows.Forms.RadioButton();
            this.rbCard3 = new System.Windows.Forms.RadioButton();
            this.rbCard4 = new System.Windows.Forms.RadioButton();
            this.rbCard2 = new System.Windows.Forms.RadioButton();
            this.rbCard1 = new System.Windows.Forms.RadioButton();
            this.rbCard0 = new System.Windows.Forms.RadioButton();
            this.gbCardAuth = new System.Windows.Forms.GroupBox();
            this.chkCUP = new System.Windows.Forms.CheckBox();
            this.tbInstall = new System.Windows.Forms.TextBox();
            this.btnInstall00 = new System.Windows.Forms.Button();
            this.btnCardRequest = new System.Windows.Forms.Button();
            this.lblInstallTitle = new System.Windows.Forms.Label();
            this.btnInstall03 = new System.Windows.Forms.Button();
            this.btnKeyInputInstall = new System.Windows.Forms.Button();
            this.btnInstall06 = new System.Windows.Forms.Button();
            this.btnInstall12 = new System.Windows.Forms.Button();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.lblNetAmountTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelback.SuspendLayout();
            this.gbCardTemp.SuspendLayout();
            this.gbCardAuth.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelback
            // 
            this.panelback.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelback.Controls.Add(this.gbCardTemp);
            this.panelback.Controls.Add(this.gbCardAuth);
            this.panelback.Controls.Add(this.lblNetAmount);
            this.panelback.Controls.Add(this.lblNetAmountTitle);
            this.panelback.Controls.Add(this.btnClose);
            this.panelback.Controls.Add(this.lblTitle);
            this.panelback.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelback.Location = new System.Drawing.Point(3, 3);
            this.panelback.Name = "panelback";
            this.panelback.Size = new System.Drawing.Size(523, 698);
            this.panelback.TabIndex = 5;
            // 
            // gbCardTemp
            // 
            this.gbCardTemp.Controls.Add(this.tbAuthNo);
            this.gbCardTemp.Controls.Add(this.tbCardNo);
            this.gbCardTemp.Controls.Add(this.rbCard7);
            this.gbCardTemp.Controls.Add(this.lblAuthNoTitle);
            this.gbCardTemp.Controls.Add(this.btnKeyInputAuthNo);
            this.gbCardTemp.Controls.Add(this.btnKeyInputCardNo);
            this.gbCardTemp.Controls.Add(this.rbCard8);
            this.gbCardTemp.Controls.Add(this.lblCardNoTitle);
            this.gbCardTemp.Controls.Add(this.btnCardTemp);
            this.gbCardTemp.Controls.Add(this.rbCard5);
            this.gbCardTemp.Controls.Add(this.rbCard6);
            this.gbCardTemp.Controls.Add(this.rbCard3);
            this.gbCardTemp.Controls.Add(this.rbCard4);
            this.gbCardTemp.Controls.Add(this.rbCard2);
            this.gbCardTemp.Controls.Add(this.rbCard1);
            this.gbCardTemp.Controls.Add(this.rbCard0);
            this.gbCardTemp.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gbCardTemp.Location = new System.Drawing.Point(20, 148);
            this.gbCardTemp.Name = "gbCardTemp";
            this.gbCardTemp.Size = new System.Drawing.Size(480, 258);
            this.gbCardTemp.TabIndex = 57;
            this.gbCardTemp.TabStop = false;
            // 
            // tbAuthNo
            // 
            this.tbAuthNo.BackColor = System.Drawing.Color.LemonChiffon;
            this.tbAuthNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAuthNo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbAuthNo.Location = new System.Drawing.Point(120, 72);
            this.tbAuthNo.Name = "tbAuthNo";
            this.tbAuthNo.Size = new System.Drawing.Size(187, 26);
            this.tbAuthNo.TabIndex = 53;
            // 
            // tbCardNo
            // 
            this.tbCardNo.BackColor = System.Drawing.Color.LemonChiffon;
            this.tbCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCardNo.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbCardNo.Location = new System.Drawing.Point(120, 33);
            this.tbCardNo.MaxLength = 20;
            this.tbCardNo.Name = "tbCardNo";
            this.tbCardNo.Size = new System.Drawing.Size(187, 26);
            this.tbCardNo.TabIndex = 52;
            // 
            // rbCard7
            // 
            this.rbCard7.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCard7.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rbCard7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbCard7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.rbCard7.Location = new System.Drawing.Point(138, 200);
            this.rbCard7.Name = "rbCard7";
            this.rbCard7.Size = new System.Drawing.Size(82, 32);
            this.rbCard7.TabIndex = 0;
            this.rbCard7.Tag = "91";
            this.rbCard7.Text = "농협";
            this.rbCard7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCard7.UseVisualStyleBackColor = true;
            // 
            // lblAuthNoTitle
            // 
            this.lblAuthNoTitle.AutoSize = true;
            this.lblAuthNoTitle.Location = new System.Drawing.Point(42, 78);
            this.lblAuthNoTitle.Name = "lblAuthNoTitle";
            this.lblAuthNoTitle.Size = new System.Drawing.Size(63, 14);
            this.lblAuthNoTitle.TabIndex = 48;
            this.lblAuthNoTitle.Text = "승인번호";
            // 
            // btnKeyInputAuthNo
            // 
            this.btnKeyInputAuthNo.BackColor = System.Drawing.Color.White;
            this.btnKeyInputAuthNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyInputAuthNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnKeyInputAuthNo.Location = new System.Drawing.Point(331, 68);
            this.btnKeyInputAuthNo.Name = "btnKeyInputAuthNo";
            this.btnKeyInputAuthNo.Size = new System.Drawing.Size(40, 30);
            this.btnKeyInputAuthNo.TabIndex = 51;
            this.btnKeyInputAuthNo.Text = "◇";
            this.btnKeyInputAuthNo.UseVisualStyleBackColor = false;
            this.btnKeyInputAuthNo.Click += new System.EventHandler(this.btnKeyInputAuthNo_Click);
            // 
            // btnKeyInputCardNo
            // 
            this.btnKeyInputCardNo.BackColor = System.Drawing.Color.White;
            this.btnKeyInputCardNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyInputCardNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnKeyInputCardNo.Location = new System.Drawing.Point(331, 29);
            this.btnKeyInputCardNo.Name = "btnKeyInputCardNo";
            this.btnKeyInputCardNo.Size = new System.Drawing.Size(40, 30);
            this.btnKeyInputCardNo.TabIndex = 51;
            this.btnKeyInputCardNo.Text = "◇";
            this.btnKeyInputCardNo.UseVisualStyleBackColor = false;
            this.btnKeyInputCardNo.Click += new System.EventHandler(this.btnKeyInputCardNo_Click);
            // 
            // rbCard8
            // 
            this.rbCard8.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCard8.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rbCard8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbCard8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.rbCard8.Location = new System.Drawing.Point(226, 200);
            this.rbCard8.Name = "rbCard8";
            this.rbCard8.Size = new System.Drawing.Size(82, 32);
            this.rbCard8.TabIndex = 0;
            this.rbCard8.Tag = "00";
            this.rbCard8.Text = "기타";
            this.rbCard8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCard8.UseVisualStyleBackColor = true;
            // 
            // lblCardNoTitle
            // 
            this.lblCardNoTitle.AutoSize = true;
            this.lblCardNoTitle.Location = new System.Drawing.Point(42, 42);
            this.lblCardNoTitle.Name = "lblCardNoTitle";
            this.lblCardNoTitle.Size = new System.Drawing.Size(63, 14);
            this.lblCardNoTitle.TabIndex = 48;
            this.lblCardNoTitle.Text = "카드번호";
            // 
            // btnCardTemp
            // 
            this.btnCardTemp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnCardTemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCardTemp.ForeColor = System.Drawing.Color.White;
            this.btnCardTemp.Location = new System.Drawing.Point(331, 124);
            this.btnCardTemp.Name = "btnCardTemp";
            this.btnCardTemp.Size = new System.Drawing.Size(130, 50);
            this.btnCardTemp.TabIndex = 50;
            this.btnCardTemp.Text = "임의등록";
            this.btnCardTemp.UseVisualStyleBackColor = false;
            this.btnCardTemp.Click += new System.EventHandler(this.btnCardTemp_Click);
            // 
            // rbCard5
            // 
            this.rbCard5.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCard5.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rbCard5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbCard5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.rbCard5.Location = new System.Drawing.Point(226, 162);
            this.rbCard5.Name = "rbCard5";
            this.rbCard5.Size = new System.Drawing.Size(82, 32);
            this.rbCard5.TabIndex = 0;
            this.rbCard5.Tag = "31";
            this.rbCard5.Text = "비씨";
            this.rbCard5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCard5.UseVisualStyleBackColor = true;
            // 
            // rbCard6
            // 
            this.rbCard6.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCard6.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rbCard6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbCard6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.rbCard6.Location = new System.Drawing.Point(50, 200);
            this.rbCard6.Name = "rbCard6";
            this.rbCard6.Size = new System.Drawing.Size(82, 32);
            this.rbCard6.TabIndex = 0;
            this.rbCard6.Tag = "71";
            this.rbCard6.Text = "롯데";
            this.rbCard6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCard6.UseVisualStyleBackColor = true;
            // 
            // rbCard3
            // 
            this.rbCard3.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCard3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rbCard3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbCard3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.rbCard3.Location = new System.Drawing.Point(50, 162);
            this.rbCard3.Name = "rbCard3";
            this.rbCard3.Size = new System.Drawing.Size(82, 32);
            this.rbCard3.TabIndex = 0;
            this.rbCard3.Tag = "51";
            this.rbCard3.Text = "삼성";
            this.rbCard3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCard3.UseVisualStyleBackColor = true;
            // 
            // rbCard4
            // 
            this.rbCard4.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCard4.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rbCard4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbCard4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.rbCard4.Location = new System.Drawing.Point(138, 162);
            this.rbCard4.Name = "rbCard4";
            this.rbCard4.Size = new System.Drawing.Size(82, 32);
            this.rbCard4.TabIndex = 0;
            this.rbCard4.Tag = "61";
            this.rbCard4.Text = "현대";
            this.rbCard4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCard4.UseVisualStyleBackColor = true;
            // 
            // rbCard2
            // 
            this.rbCard2.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCard2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rbCard2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.rbCard2.Location = new System.Drawing.Point(226, 124);
            this.rbCard2.Name = "rbCard2";
            this.rbCard2.Size = new System.Drawing.Size(82, 32);
            this.rbCard2.TabIndex = 0;
            this.rbCard2.Tag = "41";
            this.rbCard2.Text = "신한";
            this.rbCard2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCard2.UseVisualStyleBackColor = true;
            // 
            // rbCard1
            // 
            this.rbCard1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCard1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rbCard1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.rbCard1.Location = new System.Drawing.Point(138, 124);
            this.rbCard1.Name = "rbCard1";
            this.rbCard1.Size = new System.Drawing.Size(82, 32);
            this.rbCard1.TabIndex = 0;
            this.rbCard1.Tag = "32";
            this.rbCard1.Text = "하나";
            this.rbCard1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCard1.UseVisualStyleBackColor = true;
            // 
            // rbCard0
            // 
            this.rbCard0.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCard0.Checked = true;
            this.rbCard0.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rbCard0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbCard0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.rbCard0.Location = new System.Drawing.Point(50, 124);
            this.rbCard0.Name = "rbCard0";
            this.rbCard0.Size = new System.Drawing.Size(82, 32);
            this.rbCard0.TabIndex = 0;
            this.rbCard0.TabStop = true;
            this.rbCard0.Tag = "11";
            this.rbCard0.Text = "국민";
            this.rbCard0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCard0.UseVisualStyleBackColor = true;
            // 
            // gbCardAuth
            // 
            this.gbCardAuth.Controls.Add(this.chkCUP);
            this.gbCardAuth.Controls.Add(this.tbInstall);
            this.gbCardAuth.Controls.Add(this.btnInstall00);
            this.gbCardAuth.Controls.Add(this.btnCardRequest);
            this.gbCardAuth.Controls.Add(this.lblInstallTitle);
            this.gbCardAuth.Controls.Add(this.btnInstall03);
            this.gbCardAuth.Controls.Add(this.btnKeyInputInstall);
            this.gbCardAuth.Controls.Add(this.btnInstall06);
            this.gbCardAuth.Controls.Add(this.btnInstall12);
            this.gbCardAuth.Location = new System.Drawing.Point(20, 424);
            this.gbCardAuth.Name = "gbCardAuth";
            this.gbCardAuth.Size = new System.Drawing.Size(480, 245);
            this.gbCardAuth.TabIndex = 56;
            this.gbCardAuth.TabStop = false;
            // 
            // chkCUP
            // 
            this.chkCUP.AutoSize = true;
            this.chkCUP.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkCUP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.chkCUP.Location = new System.Drawing.Point(196, 183);
            this.chkCUP.Name = "chkCUP";
            this.chkCUP.Size = new System.Drawing.Size(82, 18);
            this.chkCUP.TabIndex = 57;
            this.chkCUP.Text = "은련카드";
            this.chkCUP.UseVisualStyleBackColor = true;
            // 
            // tbInstall
            // 
            this.tbInstall.BackColor = System.Drawing.Color.LemonChiffon;
            this.tbInstall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInstall.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbInstall.Location = new System.Drawing.Point(121, 56);
            this.tbInstall.MaxLength = 2;
            this.tbInstall.Name = "tbInstall";
            this.tbInstall.Size = new System.Drawing.Size(95, 26);
            this.tbInstall.TabIndex = 56;
            this.tbInstall.Text = "00";
            this.tbInstall.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnInstall00
            // 
            this.btnInstall00.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstall00.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnInstall00.Location = new System.Drawing.Point(55, 113);
            this.btnInstall00.Name = "btnInstall00";
            this.btnInstall00.Size = new System.Drawing.Size(77, 46);
            this.btnInstall00.TabIndex = 52;
            this.btnInstall00.Text = "일시불";
            this.btnInstall00.UseVisualStyleBackColor = true;
            this.btnInstall00.Click += new System.EventHandler(this.btnInstall00_Click);
            // 
            // btnCardRequest
            // 
            this.btnCardRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnCardRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCardRequest.ForeColor = System.Drawing.Color.White;
            this.btnCardRequest.Location = new System.Drawing.Point(331, 113);
            this.btnCardRequest.Name = "btnCardRequest";
            this.btnCardRequest.Size = new System.Drawing.Size(130, 60);
            this.btnCardRequest.TabIndex = 47;
            this.btnCardRequest.Text = "승인요청";
            this.btnCardRequest.UseVisualStyleBackColor = false;
            this.btnCardRequest.Click += new System.EventHandler(this.btnCardRequest_Click);
            // 
            // lblInstallTitle
            // 
            this.lblInstallTitle.AutoSize = true;
            this.lblInstallTitle.Location = new System.Drawing.Point(43, 62);
            this.lblInstallTitle.Name = "lblInstallTitle";
            this.lblInstallTitle.Size = new System.Drawing.Size(63, 14);
            this.lblInstallTitle.TabIndex = 48;
            this.lblInstallTitle.Text = "할부개월";
            // 
            // btnInstall03
            // 
            this.btnInstall03.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstall03.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnInstall03.Location = new System.Drawing.Point(137, 113);
            this.btnInstall03.Name = "btnInstall03";
            this.btnInstall03.Size = new System.Drawing.Size(54, 46);
            this.btnInstall03.TabIndex = 53;
            this.btnInstall03.Text = "03";
            this.btnInstall03.UseVisualStyleBackColor = true;
            this.btnInstall03.Click += new System.EventHandler(this.btnInstall03_Click);
            // 
            // btnKeyInputInstall
            // 
            this.btnKeyInputInstall.BackColor = System.Drawing.Color.White;
            this.btnKeyInputInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyInputInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnKeyInputInstall.Location = new System.Drawing.Point(222, 54);
            this.btnKeyInputInstall.Name = "btnKeyInputInstall";
            this.btnKeyInputInstall.Size = new System.Drawing.Size(40, 30);
            this.btnKeyInputInstall.TabIndex = 51;
            this.btnKeyInputInstall.Text = "◇";
            this.btnKeyInputInstall.UseVisualStyleBackColor = false;
            this.btnKeyInputInstall.Click += new System.EventHandler(this.btnKeyInputInstall_Click);
            // 
            // btnInstall06
            // 
            this.btnInstall06.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstall06.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnInstall06.Location = new System.Drawing.Point(195, 113);
            this.btnInstall06.Name = "btnInstall06";
            this.btnInstall06.Size = new System.Drawing.Size(54, 46);
            this.btnInstall06.TabIndex = 54;
            this.btnInstall06.Text = "06";
            this.btnInstall06.UseVisualStyleBackColor = true;
            this.btnInstall06.Click += new System.EventHandler(this.btnInstall06_Click);
            // 
            // btnInstall12
            // 
            this.btnInstall12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstall12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnInstall12.Location = new System.Drawing.Point(253, 113);
            this.btnInstall12.Name = "btnInstall12";
            this.btnInstall12.Size = new System.Drawing.Size(54, 46);
            this.btnInstall12.TabIndex = 55;
            this.btnInstall12.Text = "12";
            this.btnInstall12.UseVisualStyleBackColor = true;
            this.btnInstall12.Click += new System.EventHandler(this.btnInstall12_Click);
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNetAmount.Location = new System.Drawing.Point(143, 91);
            this.lblNetAmount.Margin = new System.Windows.Forms.Padding(0);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Padding = new System.Windows.Forms.Padding(5);
            this.lblNetAmount.Size = new System.Drawing.Size(131, 30);
            this.lblNetAmount.TabIndex = 49;
            this.lblNetAmount.Tag = "0";
            this.lblNetAmount.Text = "0";
            this.lblNetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNetAmountTitle
            // 
            this.lblNetAmountTitle.AutoSize = true;
            this.lblNetAmountTitle.Location = new System.Drawing.Point(70, 100);
            this.lblNetAmountTitle.Name = "lblNetAmountTitle";
            this.lblNetAmountTitle.Size = new System.Drawing.Size(63, 14);
            this.lblNetAmountTitle.TabIndex = 48;
            this.lblNetAmountTitle.Text = "결제금액";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(462, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 43;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(480, 40);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "카드결제";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPayCard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(529, 704);
            this.Controls.Add(this.panelback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPayCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmPayCard";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPayCard_FormClosed);
            this.panelback.ResumeLayout(false);
            this.panelback.PerformLayout();
            this.gbCardTemp.ResumeLayout(false);
            this.gbCardTemp.PerformLayout();
            this.gbCardAuth.ResumeLayout(false);
            this.gbCardAuth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelback;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCardRequest;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.Label lblInstallTitle;
        private System.Windows.Forms.Label lblNetAmountTitle;
        private System.Windows.Forms.Button btnCardTemp;
        private System.Windows.Forms.Button btnKeyInputInstall;
        private System.Windows.Forms.GroupBox gbCardAuth;
        private System.Windows.Forms.Button btnInstall00;
        private System.Windows.Forms.Button btnInstall03;
        private System.Windows.Forms.Button btnInstall06;
        private System.Windows.Forms.Button btnInstall12;
        private System.Windows.Forms.GroupBox gbCardTemp;
        private System.Windows.Forms.Label lblAuthNoTitle;
        private System.Windows.Forms.Button btnKeyInputAuthNo;
        private System.Windows.Forms.Button btnKeyInputCardNo;
        private System.Windows.Forms.Label lblCardNoTitle;
        private System.Windows.Forms.RadioButton rbCard7;
        private System.Windows.Forms.RadioButton rbCard8;
        private System.Windows.Forms.RadioButton rbCard5;
        private System.Windows.Forms.RadioButton rbCard6;
        private System.Windows.Forms.RadioButton rbCard3;
        private System.Windows.Forms.RadioButton rbCard4;
        private System.Windows.Forms.RadioButton rbCard2;
        private System.Windows.Forms.RadioButton rbCard1;
        private System.Windows.Forms.RadioButton rbCard0;
        private System.Windows.Forms.TextBox tbInstall;
        private System.Windows.Forms.TextBox tbAuthNo;
        private System.Windows.Forms.TextBox tbCardNo;
        private System.Windows.Forms.CheckBox chkCUP;
    }
}