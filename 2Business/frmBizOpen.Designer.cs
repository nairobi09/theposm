namespace thepos
{
    partial class frmBizOpen
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
            this.panelBizOpen = new System.Windows.Forms.Panel();
            this.gbBizOpen = new System.Windows.Forms.GroupBox();
            this.btnBizOpenInput = new System.Windows.Forms.Button();
            this.lblBizOpenUserTitle = new System.Windows.Forms.Label();
            this.dtpBizDate = new System.Windows.Forms.DateTimePicker();
            this.lblBizOpenAmountTitle = new System.Windows.Forms.Label();
            this.tbBizOpenAmount = new System.Windows.Forms.TextBox();
            this.lblBizDateTitle = new System.Windows.Forms.Label();
            this.lblBizOpenUser = new System.Windows.Forms.Label();
            this.lblBizCloseUserTitle = new System.Windows.Forms.Label();
            this.lblLastBizDtInputTitle = new System.Windows.Forms.Label();
            this.lblLastBizCloseDateTitle = new System.Windows.Forms.Label();
            this.lblT11 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblBizCloseUser = new System.Windows.Forms.Label();
            this.lblLastBizDtInput = new System.Windows.Forms.Label();
            this.lblLastBizCloseDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBizOpen.SuspendLayout();
            this.gbBizOpen.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBizOpen
            // 
            this.panelBizOpen.BackColor = System.Drawing.SystemColors.Control;
            this.panelBizOpen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelBizOpen.Controls.Add(this.gbBizOpen);
            this.panelBizOpen.Controls.Add(this.lblBizCloseUserTitle);
            this.panelBizOpen.Controls.Add(this.lblLastBizDtInputTitle);
            this.panelBizOpen.Controls.Add(this.lblLastBizCloseDateTitle);
            this.panelBizOpen.Controls.Add(this.lblT11);
            this.panelBizOpen.Controls.Add(this.lblTitle);
            this.panelBizOpen.Controls.Add(this.lblBizCloseUser);
            this.panelBizOpen.Controls.Add(this.lblLastBizDtInput);
            this.panelBizOpen.Controls.Add(this.lblLastBizCloseDate);
            this.panelBizOpen.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panelBizOpen.Location = new System.Drawing.Point(0, 0);
            this.panelBizOpen.Name = "panelBizOpen";
            this.panelBizOpen.Size = new System.Drawing.Size(751, 701);
            this.panelBizOpen.TabIndex = 11;
            // 
            // gbBizOpen
            // 
            this.gbBizOpen.Controls.Add(this.tbBizOpenAmount);
            this.gbBizOpen.Controls.Add(this.label1);
            this.gbBizOpen.Controls.Add(this.btnBizOpenInput);
            this.gbBizOpen.Controls.Add(this.lblBizOpenUserTitle);
            this.gbBizOpen.Controls.Add(this.dtpBizDate);
            this.gbBizOpen.Controls.Add(this.lblBizOpenAmountTitle);
            this.gbBizOpen.Controls.Add(this.lblBizDateTitle);
            this.gbBizOpen.Controls.Add(this.lblBizOpenUser);
            this.gbBizOpen.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gbBizOpen.ForeColor = System.Drawing.Color.SaddleBrown;
            this.gbBizOpen.Location = new System.Drawing.Point(121, 311);
            this.gbBizOpen.Name = "gbBizOpen";
            this.gbBizOpen.Size = new System.Drawing.Size(487, 307);
            this.gbBizOpen.TabIndex = 102;
            this.gbBizOpen.TabStop = false;
            this.gbBizOpen.Text = "영업개시";
            // 
            // btnBizOpenInput
            // 
            this.btnBizOpenInput.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnBizOpenInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBizOpenInput.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBizOpenInput.ForeColor = System.Drawing.Color.White;
            this.btnBizOpenInput.Location = new System.Drawing.Point(316, 102);
            this.btnBizOpenInput.Name = "btnBizOpenInput";
            this.btnBizOpenInput.Size = new System.Drawing.Size(140, 50);
            this.btnBizOpenInput.TabIndex = 3;
            this.btnBizOpenInput.Text = "개시입력";
            this.btnBizOpenInput.UseVisualStyleBackColor = false;
            this.btnBizOpenInput.Click += new System.EventHandler(this.btnBizOpenInput_Click);
            // 
            // lblBizOpenUserTitle
            // 
            this.lblBizOpenUserTitle.BackColor = System.Drawing.Color.Peru;
            this.lblBizOpenUserTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBizOpenUserTitle.ForeColor = System.Drawing.Color.White;
            this.lblBizOpenUserTitle.Location = new System.Drawing.Point(32, 122);
            this.lblBizOpenUserTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblBizOpenUserTitle.Name = "lblBizOpenUserTitle";
            this.lblBizOpenUserTitle.Size = new System.Drawing.Size(100, 30);
            this.lblBizOpenUserTitle.TabIndex = 101;
            this.lblBizOpenUserTitle.Text = "담당자";
            this.lblBizOpenUserTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpBizDate
            // 
            this.dtpBizDate.CalendarMonthBackground = System.Drawing.Color.Moccasin;
            this.dtpBizDate.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpBizDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBizDate.Location = new System.Drawing.Point(139, 52);
            this.dtpBizDate.Name = "dtpBizDate";
            this.dtpBizDate.Size = new System.Drawing.Size(136, 26);
            this.dtpBizDate.TabIndex = 2;
            // 
            // lblBizOpenAmountTitle
            // 
            this.lblBizOpenAmountTitle.BackColor = System.Drawing.Color.Peru;
            this.lblBizOpenAmountTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBizOpenAmountTitle.ForeColor = System.Drawing.Color.White;
            this.lblBizOpenAmountTitle.Location = new System.Drawing.Point(32, 86);
            this.lblBizOpenAmountTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblBizOpenAmountTitle.Name = "lblBizOpenAmountTitle";
            this.lblBizOpenAmountTitle.Size = new System.Drawing.Size(100, 30);
            this.lblBizOpenAmountTitle.TabIndex = 100;
            this.lblBizOpenAmountTitle.Text = "개시준비금";
            this.lblBizOpenAmountTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbBizOpenAmount
            // 
            this.tbBizOpenAmount.BackColor = System.Drawing.Color.White;
            this.tbBizOpenAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBizOpenAmount.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbBizOpenAmount.Location = new System.Drawing.Point(146, 92);
            this.tbBizOpenAmount.MaxLength = 10;
            this.tbBizOpenAmount.Name = "tbBizOpenAmount";
            this.tbBizOpenAmount.Size = new System.Drawing.Size(118, 19);
            this.tbBizOpenAmount.TabIndex = 1;
            this.tbBizOpenAmount.Text = "0";
            this.tbBizOpenAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBizDateTitle
            // 
            this.lblBizDateTitle.BackColor = System.Drawing.Color.Peru;
            this.lblBizDateTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBizDateTitle.ForeColor = System.Drawing.Color.White;
            this.lblBizDateTitle.Location = new System.Drawing.Point(32, 50);
            this.lblBizDateTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblBizDateTitle.Name = "lblBizDateTitle";
            this.lblBizDateTitle.Size = new System.Drawing.Size(100, 30);
            this.lblBizDateTitle.TabIndex = 99;
            this.lblBizDateTitle.Text = "영업일자";
            this.lblBizDateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBizOpenUser
            // 
            this.lblBizOpenUser.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblBizOpenUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBizOpenUser.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBizOpenUser.ForeColor = System.Drawing.Color.Black;
            this.lblBizOpenUser.Location = new System.Drawing.Point(139, 122);
            this.lblBizOpenUser.Name = "lblBizOpenUser";
            this.lblBizOpenUser.Size = new System.Drawing.Size(136, 30);
            this.lblBizOpenUser.TabIndex = 4;
            this.lblBizOpenUser.Text = "0001 - 김토스";
            this.lblBizOpenUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBizCloseUserTitle
            // 
            this.lblBizCloseUserTitle.BackColor = System.Drawing.Color.Peru;
            this.lblBizCloseUserTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBizCloseUserTitle.ForeColor = System.Drawing.Color.White;
            this.lblBizCloseUserTitle.Location = new System.Drawing.Point(151, 199);
            this.lblBizCloseUserTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblBizCloseUserTitle.Name = "lblBizCloseUserTitle";
            this.lblBizCloseUserTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblBizCloseUserTitle.Size = new System.Drawing.Size(100, 30);
            this.lblBizCloseUserTitle.TabIndex = 64;
            this.lblBizCloseUserTitle.Text = "담당자";
            this.lblBizCloseUserTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastBizDtInputTitle
            // 
            this.lblLastBizDtInputTitle.BackColor = System.Drawing.Color.Peru;
            this.lblLastBizDtInputTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLastBizDtInputTitle.ForeColor = System.Drawing.Color.White;
            this.lblLastBizDtInputTitle.Location = new System.Drawing.Point(151, 163);
            this.lblLastBizDtInputTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblLastBizDtInputTitle.Name = "lblLastBizDtInputTitle";
            this.lblLastBizDtInputTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblLastBizDtInputTitle.Size = new System.Drawing.Size(100, 30);
            this.lblLastBizDtInputTitle.TabIndex = 63;
            this.lblLastBizDtInputTitle.Text = "마감입력";
            this.lblLastBizDtInputTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastBizCloseDateTitle
            // 
            this.lblLastBizCloseDateTitle.BackColor = System.Drawing.Color.Peru;
            this.lblLastBizCloseDateTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLastBizCloseDateTitle.ForeColor = System.Drawing.Color.White;
            this.lblLastBizCloseDateTitle.Location = new System.Drawing.Point(151, 127);
            this.lblLastBizCloseDateTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblLastBizCloseDateTitle.Name = "lblLastBizCloseDateTitle";
            this.lblLastBizCloseDateTitle.Padding = new System.Windows.Forms.Padding(5);
            this.lblLastBizCloseDateTitle.Size = new System.Drawing.Size(100, 30);
            this.lblLastBizCloseDateTitle.TabIndex = 62;
            this.lblLastBizCloseDateTitle.Text = "영업일자";
            this.lblLastBizCloseDateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblT11
            // 
            this.lblT11.AutoSize = true;
            this.lblT11.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblT11.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblT11.Location = new System.Drawing.Point(135, 97);
            this.lblT11.Name = "lblT11";
            this.lblT11.Size = new System.Drawing.Size(63, 14);
            this.lblT11.TabIndex = 0;
            this.lblT11.Text = "마감현황";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.SaddleBrown;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(120, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(492, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "영업개시";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBizCloseUser
            // 
            this.lblBizCloseUser.BackColor = System.Drawing.Color.White;
            this.lblBizCloseUser.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBizCloseUser.ForeColor = System.Drawing.Color.Black;
            this.lblBizCloseUser.Location = new System.Drawing.Point(258, 199);
            this.lblBizCloseUser.Name = "lblBizCloseUser";
            this.lblBizCloseUser.Size = new System.Drawing.Size(170, 30);
            this.lblBizCloseUser.TabIndex = 4;
            this.lblBizCloseUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastBizDtInput
            // 
            this.lblLastBizDtInput.BackColor = System.Drawing.Color.White;
            this.lblLastBizDtInput.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLastBizDtInput.ForeColor = System.Drawing.Color.Black;
            this.lblLastBizDtInput.Location = new System.Drawing.Point(258, 163);
            this.lblLastBizDtInput.Name = "lblLastBizDtInput";
            this.lblLastBizDtInput.Size = new System.Drawing.Size(170, 30);
            this.lblLastBizDtInput.TabIndex = 4;
            this.lblLastBizDtInput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastBizCloseDate
            // 
            this.lblLastBizCloseDate.BackColor = System.Drawing.Color.White;
            this.lblLastBizCloseDate.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLastBizCloseDate.ForeColor = System.Drawing.Color.Black;
            this.lblLastBizCloseDate.Location = new System.Drawing.Point(258, 127);
            this.lblLastBizCloseDate.Name = "lblLastBizCloseDate";
            this.lblLastBizCloseDate.Size = new System.Drawing.Size(170, 30);
            this.lblLastBizCloseDate.TabIndex = 4;
            this.lblLastBizCloseDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(140, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 30);
            this.label1.TabIndex = 102;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBizOpen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(750, 700);
            this.Controls.Add(this.panelBizOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBizOpen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmBizOpen";
            this.TopMost = true;
            this.panelBizOpen.ResumeLayout(false);
            this.panelBizOpen.PerformLayout();
            this.gbBizOpen.ResumeLayout(false);
            this.gbBizOpen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBizOpen;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblT11;
        private System.Windows.Forms.Label lblBizOpenUser;
        private System.Windows.Forms.Label lblBizCloseUser;
        private System.Windows.Forms.Label lblLastBizCloseDate;
        private System.Windows.Forms.Button btnBizOpenInput;
        private System.Windows.Forms.DateTimePicker dtpBizDate;
        private System.Windows.Forms.TextBox tbBizOpenAmount;
        private System.Windows.Forms.Label lblLastBizDtInput;
        private System.Windows.Forms.Label lblBizCloseUserTitle;
        private System.Windows.Forms.Label lblLastBizDtInputTitle;
        private System.Windows.Forms.Label lblLastBizCloseDateTitle;
        private System.Windows.Forms.Label lblBizOpenUserTitle;
        private System.Windows.Forms.Label lblBizOpenAmountTitle;
        private System.Windows.Forms.Label lblBizDateTitle;
        private System.Windows.Forms.GroupBox gbBizOpen;
        private System.Windows.Forms.Label label1;
    }
}