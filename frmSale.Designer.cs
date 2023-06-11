
namespace thepos
{
    partial class frmSale
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSale));
            this.btnFlowSettlement = new System.Windows.Forms.Button();
            this.btnFlowCharging = new System.Windows.Forms.Button();
            this.btnFlowTicketing = new System.Windows.Forms.Button();
            this.panelNumpad = new System.Windows.Forms.Panel();
            this.panelKeyDisplayWhite = new System.Windows.Forms.Panel();
            this.tbKeyDisplay = new System.Windows.Forms.TextBox();
            this.lblKeyDisplayXX = new System.Windows.Forms.Label();
            this.btnKey1 = new System.Windows.Forms.Button();
            this.btnKey2 = new System.Windows.Forms.Button();
            this.btnKey0 = new System.Windows.Forms.Button();
            this.btnKey3 = new System.Windows.Forms.Button();
            this.btnKey4 = new System.Windows.Forms.Button();
            this.btnKey00 = new System.Windows.Forms.Button();
            this.btnKeyEnter = new System.Windows.Forms.Button();
            this.btnKeyBS = new System.Windows.Forms.Button();
            this.btnKey5 = new System.Windows.Forms.Button();
            this.btnKey9 = new System.Windows.Forms.Button();
            this.btnKey6 = new System.Windows.Forms.Button();
            this.btnKey8 = new System.Windows.Forms.Button();
            this.btnKey7 = new System.Windows.Forms.Button();
            this.btnKeyClear = new System.Windows.Forms.Button();
            this.panelOrderConsole = new System.Windows.Forms.Panel();
            this.btnOrderCntUp = new System.Windows.Forms.Button();
            this.btnOrderCntDn = new System.Windows.Forms.Button();
            this.btnOrderCntChange = new System.Windows.Forms.Button();
            this.btnOrderAmtChange = new System.Windows.Forms.Button();
            this.btnOrderCancelSelect = new System.Windows.Forms.Button();
            this.btnOrderCancelAll = new System.Windows.Forms.Button();
            this.btnOrderItemScrollDn = new System.Windows.Forms.Button();
            this.btnOrderItemScrollUp = new System.Windows.Forms.Button();
            this.btnOrderAmountDC = new System.Windows.Forms.Button();
            this.btnOrderWaiting = new System.Windows.Forms.Button();
            this.btnPay1 = new System.Windows.Forms.Button();
            this.btnPay2 = new System.Windows.Forms.Button();
            this.btnPayManager = new System.Windows.Forms.Button();
            this.timerSecondEvent = new System.Windows.Forms.Timer(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.panelTitleWhite = new System.Windows.Forms.Panel();
            this.panelTitleConsole = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle02 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblPosNo = new System.Windows.Forms.Label();
            this.lblPosName = new System.Windows.Forms.Label();
            this.lblTitle01 = new System.Windows.Forms.Label();
            this.lblTitle04 = new System.Windows.Forms.Label();
            this.lblWorker = new System.Windows.Forms.Label();
            this.lblBusinessDate = new System.Windows.Forms.Label();
            this.lblTitle03 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.panelOrderSumWhile = new System.Windows.Forms.Panel();
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
            this.panelFlowConsole = new System.Windows.Forms.Panel();
            this.btnFlowLocker = new System.Windows.Forms.Button();
            this.btnFlowCert = new System.Windows.Forms.Button();
            this.panelDisplayAlarmWhite = new System.Windows.Forms.Panel();
            this.lblDisplayAlarm = new System.Windows.Forms.Label();
            this.lvwOrderItem = new System.Windows.Forms.ListView();
            this.no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dc_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.net_amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelOrderLvw = new System.Windows.Forms.Panel();
            this.panelGoodsItem = new System.Windows.Forms.Panel();
            this.panelGoodsItemWhite2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanelGoodsItem = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelGoodsItemWhite = new System.Windows.Forms.Panel();
            this.panelGoodsGroup = new System.Windows.Forms.Panel();
            this.panelGoodsGroupWhite2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanelGoodsGroup = new System.Windows.Forms.TableLayoutPanel();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.panelGoodsGroupWhite = new System.Windows.Forms.Panel();
            this.tableLayoutPanelPayControl = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPay4 = new System.Windows.Forms.Button();
            this.btnPay3 = new System.Windows.Forms.Button();
            this.timerAlarmDisplay = new System.Windows.Forms.Timer(this.components);
            this.panelNumpad.SuspendLayout();
            this.panelKeyDisplayWhite.SuspendLayout();
            this.panelOrderConsole.SuspendLayout();
            this.panelTitleWhite.SuspendLayout();
            this.panelTitleConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelOrderSumWhile.SuspendLayout();
            this.panelOrderSumBlack.SuspendLayout();
            this.panelFlowConsole.SuspendLayout();
            this.panelDisplayAlarmWhite.SuspendLayout();
            this.panelOrderLvw.SuspendLayout();
            this.panelGoodsItem.SuspendLayout();
            this.panelGoodsItemWhite2.SuspendLayout();
            this.tableLayoutPanelGoodsItem.SuspendLayout();
            this.panelGoodsItemWhite.SuspendLayout();
            this.panelGoodsGroup.SuspendLayout();
            this.panelGoodsGroupWhite2.SuspendLayout();
            this.tableLayoutPanelGoodsGroup.SuspendLayout();
            this.panelGoodsGroupWhite.SuspendLayout();
            this.tableLayoutPanelPayControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFlowSettlement
            // 
            this.btnFlowSettlement.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnFlowSettlement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlowSettlement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFlowSettlement.ForeColor = System.Drawing.Color.White;
            this.btnFlowSettlement.Location = new System.Drawing.Point(0, 264);
            this.btnFlowSettlement.Name = "btnFlowSettlement";
            this.btnFlowSettlement.Size = new System.Drawing.Size(87, 48);
            this.btnFlowSettlement.TabIndex = 0;
            this.btnFlowSettlement.TabStop = false;
            this.btnFlowSettlement.Text = "정산";
            this.btnFlowSettlement.UseVisualStyleBackColor = false;
            this.btnFlowSettlement.Click += new System.EventHandler(this.btnFlowSettlement_Click);
            // 
            // btnFlowCharging
            // 
            this.btnFlowCharging.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnFlowCharging.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlowCharging.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFlowCharging.ForeColor = System.Drawing.Color.White;
            this.btnFlowCharging.Location = new System.Drawing.Point(0, 212);
            this.btnFlowCharging.Name = "btnFlowCharging";
            this.btnFlowCharging.Size = new System.Drawing.Size(87, 48);
            this.btnFlowCharging.TabIndex = 0;
            this.btnFlowCharging.TabStop = false;
            this.btnFlowCharging.Text = "충전";
            this.btnFlowCharging.UseVisualStyleBackColor = false;
            this.btnFlowCharging.Click += new System.EventHandler(this.btnFlowCharging_Click);
            // 
            // btnFlowTicketing
            // 
            this.btnFlowTicketing.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnFlowTicketing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlowTicketing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFlowTicketing.ForeColor = System.Drawing.Color.White;
            this.btnFlowTicketing.Location = new System.Drawing.Point(0, 160);
            this.btnFlowTicketing.Name = "btnFlowTicketing";
            this.btnFlowTicketing.Size = new System.Drawing.Size(87, 48);
            this.btnFlowTicketing.TabIndex = 0;
            this.btnFlowTicketing.TabStop = false;
            this.btnFlowTicketing.Text = "발권";
            this.btnFlowTicketing.UseVisualStyleBackColor = false;
            this.btnFlowTicketing.Click += new System.EventHandler(this.btnFlowTicketing_Click);
            // 
            // panelNumpad
            // 
            this.panelNumpad.Controls.Add(this.panelKeyDisplayWhite);
            this.panelNumpad.Controls.Add(this.btnKey1);
            this.panelNumpad.Controls.Add(this.btnKey2);
            this.panelNumpad.Controls.Add(this.btnKey0);
            this.panelNumpad.Controls.Add(this.btnKey3);
            this.panelNumpad.Controls.Add(this.btnKey4);
            this.panelNumpad.Controls.Add(this.btnKey00);
            this.panelNumpad.Controls.Add(this.btnKeyEnter);
            this.panelNumpad.Controls.Add(this.btnKeyBS);
            this.panelNumpad.Controls.Add(this.btnKey5);
            this.panelNumpad.Controls.Add(this.btnKey9);
            this.panelNumpad.Controls.Add(this.btnKey6);
            this.panelNumpad.Controls.Add(this.btnKey8);
            this.panelNumpad.Controls.Add(this.btnKey7);
            this.panelNumpad.Controls.Add(this.btnKeyClear);
            this.panelNumpad.Location = new System.Drawing.Point(199, 450);
            this.panelNumpad.Margin = new System.Windows.Forms.Padding(30);
            this.panelNumpad.Name = "panelNumpad";
            this.panelNumpad.Padding = new System.Windows.Forms.Padding(30);
            this.panelNumpad.Size = new System.Drawing.Size(190, 316);
            this.panelNumpad.TabIndex = 23;
            // 
            // panelKeyDisplayWhite
            // 
            this.panelKeyDisplayWhite.BackColor = System.Drawing.Color.White;
            this.panelKeyDisplayWhite.Controls.Add(this.tbKeyDisplay);
            this.panelKeyDisplayWhite.Controls.Add(this.lblKeyDisplayXX);
            this.panelKeyDisplayWhite.Location = new System.Drawing.Point(0, 0);
            this.panelKeyDisplayWhite.Name = "panelKeyDisplayWhite";
            this.panelKeyDisplayWhite.Size = new System.Drawing.Size(189, 48);
            this.panelKeyDisplayWhite.TabIndex = 37;
            // 
            // tbKeyDisplay
            // 
            this.tbKeyDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.tbKeyDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbKeyDisplay.ForeColor = System.Drawing.Color.White;
            this.tbKeyDisplay.Location = new System.Drawing.Point(2, 14);
            this.tbKeyDisplay.Name = "tbKeyDisplay";
            this.tbKeyDisplay.Size = new System.Drawing.Size(180, 23);
            this.tbKeyDisplay.TabIndex = 0;
            this.tbKeyDisplay.TabStop = false;
            this.tbKeyDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblKeyDisplayXX
            // 
            this.lblKeyDisplayXX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.lblKeyDisplayXX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblKeyDisplayXX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblKeyDisplayXX.ForeColor = System.Drawing.Color.Gold;
            this.lblKeyDisplayXX.Location = new System.Drawing.Point(1, 1);
            this.lblKeyDisplayXX.Name = "lblKeyDisplayXX";
            this.lblKeyDisplayXX.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.lblKeyDisplayXX.Size = new System.Drawing.Size(187, 46);
            this.lblKeyDisplayXX.TabIndex = 3;
            this.lblKeyDisplayXX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnKey1
            // 
            this.btnKey1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey1.ForeColor = System.Drawing.Color.White;
            this.btnKey1.Location = new System.Drawing.Point(0, 53);
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
            this.btnKey2.Location = new System.Drawing.Point(64, 53);
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
            this.btnKey0.Location = new System.Drawing.Point(64, 209);
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
            this.btnKey3.Location = new System.Drawing.Point(128, 53);
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
            this.btnKey4.Location = new System.Drawing.Point(0, 105);
            this.btnKey4.Name = "btnKey4";
            this.btnKey4.Size = new System.Drawing.Size(60, 48);
            this.btnKey4.TabIndex = 1;
            this.btnKey4.TabStop = false;
            this.btnKey4.Text = "4";
            this.btnKey4.UseVisualStyleBackColor = false;
            // 
            // btnKey00
            // 
            this.btnKey00.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKey00.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKey00.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKey00.ForeColor = System.Drawing.Color.White;
            this.btnKey00.Location = new System.Drawing.Point(128, 209);
            this.btnKey00.Name = "btnKey00";
            this.btnKey00.Size = new System.Drawing.Size(60, 48);
            this.btnKey00.TabIndex = 1;
            this.btnKey00.TabStop = false;
            this.btnKey00.Text = "00";
            this.btnKey00.UseVisualStyleBackColor = false;
            // 
            // btnKeyEnter
            // 
            this.btnKeyEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnKeyEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKeyEnter.ForeColor = System.Drawing.Color.White;
            this.btnKeyEnter.Location = new System.Drawing.Point(64, 261);
            this.btnKeyEnter.Name = "btnKeyEnter";
            this.btnKeyEnter.Size = new System.Drawing.Size(124, 48);
            this.btnKeyEnter.TabIndex = 1;
            this.btnKeyEnter.TabStop = false;
            this.btnKeyEnter.Text = "Enter";
            this.btnKeyEnter.UseVisualStyleBackColor = false;
            this.btnKeyEnter.Click += new System.EventHandler(this.btnKeyEnter_Click);
            // 
            // btnKeyBS
            // 
            this.btnKeyBS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.btnKeyBS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyBS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKeyBS.ForeColor = System.Drawing.Color.White;
            this.btnKeyBS.Location = new System.Drawing.Point(0, 209);
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
            this.btnKey5.Location = new System.Drawing.Point(64, 105);
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
            this.btnKey9.Location = new System.Drawing.Point(128, 157);
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
            this.btnKey6.Location = new System.Drawing.Point(128, 105);
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
            this.btnKey8.Location = new System.Drawing.Point(64, 157);
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
            this.btnKey7.Location = new System.Drawing.Point(0, 157);
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
            this.btnKeyClear.Location = new System.Drawing.Point(0, 261);
            this.btnKeyClear.Name = "btnKeyClear";
            this.btnKeyClear.Size = new System.Drawing.Size(60, 48);
            this.btnKeyClear.TabIndex = 1;
            this.btnKeyClear.TabStop = false;
            this.btnKeyClear.Text = "C";
            this.btnKeyClear.UseVisualStyleBackColor = false;
            // 
            // panelOrderConsole
            // 
            this.panelOrderConsole.Controls.Add(this.btnOrderCntUp);
            this.panelOrderConsole.Controls.Add(this.btnOrderCntDn);
            this.panelOrderConsole.Controls.Add(this.btnOrderCntChange);
            this.panelOrderConsole.Controls.Add(this.btnOrderAmtChange);
            this.panelOrderConsole.Controls.Add(this.btnOrderCancelSelect);
            this.panelOrderConsole.Controls.Add(this.btnOrderCancelAll);
            this.panelOrderConsole.Location = new System.Drawing.Point(6, 397);
            this.panelOrderConsole.Name = "panelOrderConsole";
            this.panelOrderConsole.Size = new System.Drawing.Size(384, 48);
            this.panelOrderConsole.TabIndex = 25;
            // 
            // btnOrderCntUp
            // 
            this.btnOrderCntUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnOrderCntUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderCntUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOrderCntUp.ForeColor = System.Drawing.Color.White;
            this.btnOrderCntUp.Location = new System.Drawing.Point(257, 0);
            this.btnOrderCntUp.Name = "btnOrderCntUp";
            this.btnOrderCntUp.Size = new System.Drawing.Size(60, 48);
            this.btnOrderCntUp.TabIndex = 0;
            this.btnOrderCntUp.TabStop = false;
            this.btnOrderCntUp.Text = "＋";
            this.btnOrderCntUp.UseVisualStyleBackColor = false;
            this.btnOrderCntUp.Click += new System.EventHandler(this.btnOrderCntUp_Click);
            // 
            // btnOrderCntDn
            // 
            this.btnOrderCntDn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnOrderCntDn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderCntDn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOrderCntDn.ForeColor = System.Drawing.Color.White;
            this.btnOrderCntDn.Location = new System.Drawing.Point(193, 0);
            this.btnOrderCntDn.Name = "btnOrderCntDn";
            this.btnOrderCntDn.Size = new System.Drawing.Size(60, 48);
            this.btnOrderCntDn.TabIndex = 0;
            this.btnOrderCntDn.TabStop = false;
            this.btnOrderCntDn.Text = "－";
            this.btnOrderCntDn.UseVisualStyleBackColor = false;
            this.btnOrderCntDn.Click += new System.EventHandler(this.btnOrderCntDn_Click);
            // 
            // btnOrderCntChange
            // 
            this.btnOrderCntChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnOrderCntChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderCntChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOrderCntChange.ForeColor = System.Drawing.Color.White;
            this.btnOrderCntChange.Location = new System.Drawing.Point(321, 0);
            this.btnOrderCntChange.Name = "btnOrderCntChange";
            this.btnOrderCntChange.Size = new System.Drawing.Size(60, 48);
            this.btnOrderCntChange.TabIndex = 0;
            this.btnOrderCntChange.TabStop = false;
            this.btnOrderCntChange.Text = "수량\r\n변경";
            this.btnOrderCntChange.UseVisualStyleBackColor = false;
            this.btnOrderCntChange.Click += new System.EventHandler(this.btnOrderCntChange_Click);
            // 
            // btnOrderAmtChange
            // 
            this.btnOrderAmtChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnOrderAmtChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderAmtChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOrderAmtChange.ForeColor = System.Drawing.Color.White;
            this.btnOrderAmtChange.Location = new System.Drawing.Point(128, 0);
            this.btnOrderAmtChange.Name = "btnOrderAmtChange";
            this.btnOrderAmtChange.Size = new System.Drawing.Size(58, 48);
            this.btnOrderAmtChange.TabIndex = 0;
            this.btnOrderAmtChange.TabStop = false;
            this.btnOrderAmtChange.Text = "단가\r\n변경";
            this.btnOrderAmtChange.UseVisualStyleBackColor = false;
            this.btnOrderAmtChange.Click += new System.EventHandler(this.btnOrderAmtChange_Click);
            // 
            // btnOrderCancelSelect
            // 
            this.btnOrderCancelSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnOrderCancelSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderCancelSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOrderCancelSelect.ForeColor = System.Drawing.Color.White;
            this.btnOrderCancelSelect.Location = new System.Drawing.Point(64, 0);
            this.btnOrderCancelSelect.Name = "btnOrderCancelSelect";
            this.btnOrderCancelSelect.Size = new System.Drawing.Size(59, 48);
            this.btnOrderCancelSelect.TabIndex = 0;
            this.btnOrderCancelSelect.TabStop = false;
            this.btnOrderCancelSelect.Text = "선택\r\n취소";
            this.btnOrderCancelSelect.UseVisualStyleBackColor = false;
            this.btnOrderCancelSelect.Click += new System.EventHandler(this.btnOrderCancelSelect_Click);
            // 
            // btnOrderCancelAll
            // 
            this.btnOrderCancelAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnOrderCancelAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderCancelAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOrderCancelAll.ForeColor = System.Drawing.Color.White;
            this.btnOrderCancelAll.Location = new System.Drawing.Point(0, 0);
            this.btnOrderCancelAll.Name = "btnOrderCancelAll";
            this.btnOrderCancelAll.Size = new System.Drawing.Size(59, 48);
            this.btnOrderCancelAll.TabIndex = 0;
            this.btnOrderCancelAll.TabStop = false;
            this.btnOrderCancelAll.Text = "전체\r\n취소";
            this.btnOrderCancelAll.UseVisualStyleBackColor = false;
            this.btnOrderCancelAll.Click += new System.EventHandler(this.btnOrderCancelAll_Click);
            // 
            // btnOrderItemScrollDn
            // 
            this.btnOrderItemScrollDn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnOrderItemScrollDn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderItemScrollDn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOrderItemScrollDn.ForeColor = System.Drawing.Color.White;
            this.btnOrderItemScrollDn.Location = new System.Drawing.Point(439, 352);
            this.btnOrderItemScrollDn.Name = "btnOrderItemScrollDn";
            this.btnOrderItemScrollDn.Size = new System.Drawing.Size(42, 40);
            this.btnOrderItemScrollDn.TabIndex = 0;
            this.btnOrderItemScrollDn.TabStop = false;
            this.btnOrderItemScrollDn.Text = "▼";
            this.btnOrderItemScrollDn.UseVisualStyleBackColor = false;
            this.btnOrderItemScrollDn.Click += new System.EventHandler(this.btnOrderItemScrollDn_Click);
            // 
            // btnOrderItemScrollUp
            // 
            this.btnOrderItemScrollUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnOrderItemScrollUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderItemScrollUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOrderItemScrollUp.ForeColor = System.Drawing.Color.White;
            this.btnOrderItemScrollUp.Location = new System.Drawing.Point(394, 352);
            this.btnOrderItemScrollUp.Name = "btnOrderItemScrollUp";
            this.btnOrderItemScrollUp.Size = new System.Drawing.Size(41, 40);
            this.btnOrderItemScrollUp.TabIndex = 0;
            this.btnOrderItemScrollUp.TabStop = false;
            this.btnOrderItemScrollUp.Text = "▲";
            this.btnOrderItemScrollUp.UseVisualStyleBackColor = false;
            this.btnOrderItemScrollUp.Click += new System.EventHandler(this.btnOrderItemScrollUp_Click);
            // 
            // btnOrderAmountDC
            // 
            this.btnOrderAmountDC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnOrderAmountDC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderAmountDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOrderAmountDC.ForeColor = System.Drawing.Color.White;
            this.btnOrderAmountDC.Location = new System.Drawing.Point(0, 2);
            this.btnOrderAmountDC.Name = "btnOrderAmountDC";
            this.btnOrderAmountDC.Size = new System.Drawing.Size(87, 48);
            this.btnOrderAmountDC.TabIndex = 0;
            this.btnOrderAmountDC.TabStop = false;
            this.btnOrderAmountDC.Text = "할인";
            this.btnOrderAmountDC.UseVisualStyleBackColor = false;
            this.btnOrderAmountDC.Click += new System.EventHandler(this.btnOrderAmountDC_Click);
            // 
            // btnOrderWaiting
            // 
            this.btnOrderWaiting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnOrderWaiting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOrderWaiting.ForeColor = System.Drawing.Color.White;
            this.btnOrderWaiting.Location = new System.Drawing.Point(0, 55);
            this.btnOrderWaiting.Name = "btnOrderWaiting";
            this.btnOrderWaiting.Size = new System.Drawing.Size(87, 48);
            this.btnOrderWaiting.TabIndex = 0;
            this.btnOrderWaiting.TabStop = false;
            this.btnOrderWaiting.Text = "대기\r\n";
            this.btnOrderWaiting.UseVisualStyleBackColor = false;
            this.btnOrderWaiting.Click += new System.EventHandler(this.btnOrderWaiting_Click);
            // 
            // btnPay1
            // 
            this.btnPay1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.tableLayoutPanelPayControl.SetColumnSpan(this.btnPay1, 2);
            this.btnPay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPay1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPay1.ForeColor = System.Drawing.Color.White;
            this.btnPay1.Location = new System.Drawing.Point(2, 2);
            this.btnPay1.Margin = new System.Windows.Forms.Padding(2);
            this.btnPay1.Name = "btnPay1";
            this.tableLayoutPanelPayControl.SetRowSpan(this.btnPay1, 4);
            this.btnPay1.Size = new System.Drawing.Size(102, 152);
            this.btnPay1.TabIndex = 0;
            this.btnPay1.TabStop = false;
            this.btnPay1.Text = "현금\r\n결제";
            this.btnPay1.UseVisualStyleBackColor = false;
            // 
            // btnPay2
            // 
            this.btnPay2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.tableLayoutPanelPayControl.SetColumnSpan(this.btnPay2, 2);
            this.btnPay2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPay2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPay2.ForeColor = System.Drawing.Color.White;
            this.btnPay2.Location = new System.Drawing.Point(214, 2);
            this.btnPay2.Margin = new System.Windows.Forms.Padding(2);
            this.btnPay2.Name = "btnPay2";
            this.tableLayoutPanelPayControl.SetRowSpan(this.btnPay2, 4);
            this.btnPay2.Size = new System.Drawing.Size(102, 152);
            this.btnPay2.TabIndex = 0;
            this.btnPay2.TabStop = false;
            this.btnPay2.Text = "포인트\r\n결제\r\n";
            this.btnPay2.UseVisualStyleBackColor = false;
            // 
            // btnPayManager
            // 
            this.btnPayManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(86)))), ((int)(((byte)(156)))));
            this.tableLayoutPanelPayControl.SetColumnSpan(this.btnPayManager, 2);
            this.btnPayManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPayManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPayManager.ForeColor = System.Drawing.Color.White;
            this.btnPayManager.Location = new System.Drawing.Point(426, 2);
            this.btnPayManager.Margin = new System.Windows.Forms.Padding(2);
            this.btnPayManager.Name = "btnPayManager";
            this.tableLayoutPanelPayControl.SetRowSpan(this.btnPayManager, 4);
            this.btnPayManager.Size = new System.Drawing.Size(102, 152);
            this.btnPayManager.TabIndex = 0;
            this.btnPayManager.TabStop = false;
            this.btnPayManager.Text = "결제내역\r\n관리";
            this.btnPayManager.UseVisualStyleBackColor = false;
            this.btnPayManager.Click += new System.EventHandler(this.btnPayManager_Click);
            // 
            // timerSecondEvent
            // 
            this.timerSecondEvent.Enabled = true;
            this.timerSecondEvent.Interval = 1000;
            this.timerSecondEvent.Tag = "\"0\"";
            this.timerSecondEvent.Tick += new System.EventHandler(this.timerSecondEvent_Tick);
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTime.ForeColor = System.Drawing.Color.Gold;
            this.lblTime.Location = new System.Drawing.Point(887, 9);
            this.lblTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(80, 26);
            this.lblTime.TabIndex = 31;
            this.lblTime.Text = "00:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelTitleWhite
            // 
            this.panelTitleWhite.BackColor = System.Drawing.Color.Gray;
            this.panelTitleWhite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTitleWhite.Controls.Add(this.panelTitleConsole);
            this.panelTitleWhite.ForeColor = System.Drawing.Color.White;
            this.panelTitleWhite.Location = new System.Drawing.Point(5, 4);
            this.panelTitleWhite.Margin = new System.Windows.Forms.Padding(1);
            this.panelTitleWhite.Name = "panelTitleWhite";
            this.panelTitleWhite.Padding = new System.Windows.Forms.Padding(1);
            this.panelTitleWhite.Size = new System.Drawing.Size(1013, 46);
            this.panelTitleWhite.TabIndex = 33;
            // 
            // panelTitleConsole
            // 
            this.panelTitleConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.panelTitleConsole.Controls.Add(this.pictureBox1);
            this.panelTitleConsole.Controls.Add(this.lblTitle02);
            this.panelTitleConsole.Controls.Add(this.btnClose);
            this.panelTitleConsole.Controls.Add(this.lblPosNo);
            this.panelTitleConsole.Controls.Add(this.lblPosName);
            this.panelTitleConsole.Controls.Add(this.lblTitle01);
            this.panelTitleConsole.Controls.Add(this.lblTitle04);
            this.panelTitleConsole.Controls.Add(this.lblWorker);
            this.panelTitleConsole.Controls.Add(this.lblBusinessDate);
            this.panelTitleConsole.Controls.Add(this.lblTitle03);
            this.panelTitleConsole.Controls.Add(this.lblDate);
            this.panelTitleConsole.Controls.Add(this.lblTime);
            this.panelTitleConsole.Location = new System.Drawing.Point(1, 1);
            this.panelTitleConsole.Name = "panelTitleConsole";
            this.panelTitleConsole.Size = new System.Drawing.Size(1009, 42);
            this.panelTitleConsole.TabIndex = 32;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(8);
            this.pictureBox1.Size = new System.Drawing.Size(80, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle02
            // 
            this.lblTitle02.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle02.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblTitle02.ForeColor = System.Drawing.Color.White;
            this.lblTitle02.Location = new System.Drawing.Point(136, 23);
            this.lblTitle02.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle02.Name = "lblTitle02";
            this.lblTitle02.Size = new System.Drawing.Size(69, 15);
            this.lblTitle02.TabIndex = 31;
            this.lblTitle02.Text = "포스번호 :";
            this.lblTitle02.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Gulim", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            this.lblPosNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPosNo.ForeColor = System.Drawing.Color.Gold;
            this.lblPosNo.Location = new System.Drawing.Point(202, 23);
            this.lblPosNo.Margin = new System.Windows.Forms.Padding(0);
            this.lblPosNo.Name = "lblPosNo";
            this.lblPosNo.Size = new System.Drawing.Size(21, 15);
            this.lblPosNo.TabIndex = 31;
            this.lblPosNo.Text = "01";
            this.lblPosNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPosName
            // 
            this.lblPosName.AutoSize = true;
            this.lblPosName.BackColor = System.Drawing.Color.Transparent;
            this.lblPosName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPosName.ForeColor = System.Drawing.Color.Gold;
            this.lblPosName.Location = new System.Drawing.Point(202, 5);
            this.lblPosName.Margin = new System.Windows.Forms.Padding(0);
            this.lblPosName.Name = "lblPosName";
            this.lblPosName.Size = new System.Drawing.Size(79, 15);
            this.lblPosName.TabIndex = 31;
            this.lblPosName.Text = "미리내곰상주";
            this.lblPosName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle01
            // 
            this.lblTitle01.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle01.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle01.ForeColor = System.Drawing.Color.White;
            this.lblTitle01.Location = new System.Drawing.Point(136, 5);
            this.lblTitle01.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle01.Name = "lblTitle01";
            this.lblTitle01.Size = new System.Drawing.Size(69, 15);
            this.lblTitle01.TabIndex = 31;
            this.lblTitle01.Text = "매장명 :";
            this.lblTitle01.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle04
            // 
            this.lblTitle04.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle04.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblTitle04.ForeColor = System.Drawing.Color.White;
            this.lblTitle04.Location = new System.Drawing.Point(397, 23);
            this.lblTitle04.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle04.Name = "lblTitle04";
            this.lblTitle04.Size = new System.Drawing.Size(69, 15);
            this.lblTitle04.TabIndex = 31;
            this.lblTitle04.Text = "담당자 :";
            this.lblTitle04.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWorker
            // 
            this.lblWorker.AutoSize = true;
            this.lblWorker.BackColor = System.Drawing.Color.Transparent;
            this.lblWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblWorker.ForeColor = System.Drawing.Color.Gold;
            this.lblWorker.Location = new System.Drawing.Point(466, 23);
            this.lblWorker.Margin = new System.Windows.Forms.Padding(0);
            this.lblWorker.Name = "lblWorker";
            this.lblWorker.Size = new System.Drawing.Size(43, 15);
            this.lblWorker.TabIndex = 31;
            this.lblWorker.Text = "김토스";
            this.lblWorker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBusinessDate
            // 
            this.lblBusinessDate.AutoSize = true;
            this.lblBusinessDate.BackColor = System.Drawing.Color.Transparent;
            this.lblBusinessDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblBusinessDate.ForeColor = System.Drawing.Color.Gold;
            this.lblBusinessDate.Location = new System.Drawing.Point(466, 5);
            this.lblBusinessDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblBusinessDate.Name = "lblBusinessDate";
            this.lblBusinessDate.Size = new System.Drawing.Size(69, 15);
            this.lblBusinessDate.TabIndex = 31;
            this.lblBusinessDate.Text = "2023.05.22";
            this.lblBusinessDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle03
            // 
            this.lblTitle03.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle03.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblTitle03.ForeColor = System.Drawing.Color.White;
            this.lblTitle03.Location = new System.Drawing.Point(397, 5);
            this.lblTitle03.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle03.Name = "lblTitle03";
            this.lblTitle03.Size = new System.Drawing.Size(69, 15);
            this.lblTitle03.TabIndex = 31;
            this.lblTitle03.Text = "영업일자 :";
            this.lblTitle03.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(750, 8);
            this.lblDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(134, 29);
            this.lblDate.TabIndex = 31;
            this.lblDate.Text = "2020.00.00 [일]";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelOrderSumWhile
            // 
            this.panelOrderSumWhile.BackColor = System.Drawing.Color.White;
            this.panelOrderSumWhile.Controls.Add(this.panelOrderSumBlack);
            this.panelOrderSumWhile.ForeColor = System.Drawing.Color.White;
            this.panelOrderSumWhile.Location = new System.Drawing.Point(6, 451);
            this.panelOrderSumWhile.Margin = new System.Windows.Forms.Padding(1);
            this.panelOrderSumWhile.Name = "panelOrderSumWhile";
            this.panelOrderSumWhile.Padding = new System.Windows.Forms.Padding(2);
            this.panelOrderSumWhile.Size = new System.Drawing.Size(187, 308);
            this.panelOrderSumWhile.TabIndex = 34;
            // 
            // panelOrderSumBlack
            // 
            this.panelOrderSumBlack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
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
            this.panelOrderSumBlack.Location = new System.Drawing.Point(1, 1);
            this.panelOrderSumBlack.Name = "panelOrderSumBlack";
            this.panelOrderSumBlack.Size = new System.Drawing.Size(185, 306);
            this.panelOrderSumBlack.TabIndex = 0;
            // 
            // lblOrderAmountRest
            // 
            this.lblOrderAmountRest.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountRest.ForeColor = System.Drawing.Color.Gold;
            this.lblOrderAmountRest.Location = new System.Drawing.Point(69, 214);
            this.lblOrderAmountRest.Name = "lblOrderAmountRest";
            this.lblOrderAmountRest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmountRest.Size = new System.Drawing.Size(108, 21);
            this.lblOrderAmountRest.TabIndex = 1;
            this.lblOrderAmountRest.Text = "0";
            // 
            // lblOrderAmountReceive
            // 
            this.lblOrderAmountReceive.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountReceive.Location = new System.Drawing.Point(69, 179);
            this.lblOrderAmountReceive.Name = "lblOrderAmountReceive";
            this.lblOrderAmountReceive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmountReceive.Size = new System.Drawing.Size(109, 21);
            this.lblOrderAmountReceive.TabIndex = 1;
            this.lblOrderAmountReceive.Text = "0";
            // 
            // lblOrderAmountNet
            // 
            this.lblOrderAmountNet.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountNet.ForeColor = System.Drawing.Color.Gold;
            this.lblOrderAmountNet.Location = new System.Drawing.Point(69, 144);
            this.lblOrderAmountNet.Name = "lblOrderAmountNet";
            this.lblOrderAmountNet.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmountNet.Size = new System.Drawing.Size(109, 21);
            this.lblOrderAmountNet.TabIndex = 1;
            this.lblOrderAmountNet.Text = "0";
            // 
            // lblOrderAmountDC
            // 
            this.lblOrderAmountDC.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountDC.Location = new System.Drawing.Point(69, 109);
            this.lblOrderAmountDC.Name = "lblOrderAmountDC";
            this.lblOrderAmountDC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmountDC.Size = new System.Drawing.Size(109, 21);
            this.lblOrderAmountDC.TabIndex = 1;
            this.lblOrderAmountDC.Text = "0";
            // 
            // lblOrderAmount
            // 
            this.lblOrderAmount.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmount.Location = new System.Drawing.Point(69, 75);
            this.lblOrderAmount.Name = "lblOrderAmount";
            this.lblOrderAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblOrderAmount.Size = new System.Drawing.Size(109, 21);
            this.lblOrderAmount.TabIndex = 1;
            this.lblOrderAmount.Text = "0";
            // 
            // lblOrderAmountRestTitle
            // 
            this.lblOrderAmountRestTitle.AutoSize = true;
            this.lblOrderAmountRestTitle.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountRestTitle.ForeColor = System.Drawing.Color.Gold;
            this.lblOrderAmountRestTitle.Location = new System.Drawing.Point(5, 217);
            this.lblOrderAmountRestTitle.Name = "lblOrderAmountRestTitle";
            this.lblOrderAmountRestTitle.Size = new System.Drawing.Size(63, 14);
            this.lblOrderAmountRestTitle.TabIndex = 0;
            this.lblOrderAmountRestTitle.Text = "거스름돈";
            // 
            // lblOrderAmountReceiveTitle
            // 
            this.lblOrderAmountReceiveTitle.AutoSize = true;
            this.lblOrderAmountReceiveTitle.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountReceiveTitle.Location = new System.Drawing.Point(5, 182);
            this.lblOrderAmountReceiveTitle.Name = "lblOrderAmountReceiveTitle";
            this.lblOrderAmountReceiveTitle.Size = new System.Drawing.Size(63, 14);
            this.lblOrderAmountReceiveTitle.TabIndex = 0;
            this.lblOrderAmountReceiveTitle.Text = "받은금액";
            // 
            // lblOrderAmountChargeTitle
            // 
            this.lblOrderAmountChargeTitle.AutoSize = true;
            this.lblOrderAmountChargeTitle.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountChargeTitle.ForeColor = System.Drawing.Color.Gold;
            this.lblOrderAmountChargeTitle.Location = new System.Drawing.Point(5, 147);
            this.lblOrderAmountChargeTitle.Name = "lblOrderAmountChargeTitle";
            this.lblOrderAmountChargeTitle.Size = new System.Drawing.Size(63, 14);
            this.lblOrderAmountChargeTitle.TabIndex = 0;
            this.lblOrderAmountChargeTitle.Text = "받을금액";
            // 
            // lblOrderAmountDCTitle
            // 
            this.lblOrderAmountDCTitle.AutoSize = true;
            this.lblOrderAmountDCTitle.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountDCTitle.Location = new System.Drawing.Point(5, 112);
            this.lblOrderAmountDCTitle.Name = "lblOrderAmountDCTitle";
            this.lblOrderAmountDCTitle.Size = new System.Drawing.Size(63, 14);
            this.lblOrderAmountDCTitle.TabIndex = 0;
            this.lblOrderAmountDCTitle.Text = "할인금액";
            // 
            // lblOrderAmountSumTitle
            // 
            this.lblOrderAmountSumTitle.AutoSize = true;
            this.lblOrderAmountSumTitle.Font = new System.Drawing.Font("Gulim", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrderAmountSumTitle.Location = new System.Drawing.Point(5, 78);
            this.lblOrderAmountSumTitle.Name = "lblOrderAmountSumTitle";
            this.lblOrderAmountSumTitle.Size = new System.Drawing.Size(63, 14);
            this.lblOrderAmountSumTitle.TabIndex = 0;
            this.lblOrderAmountSumTitle.Text = "합계금액";
            // 
            // panelFlowConsole
            // 
            this.panelFlowConsole.Controls.Add(this.btnFlowLocker);
            this.panelFlowConsole.Controls.Add(this.btnFlowSettlement);
            this.panelFlowConsole.Controls.Add(this.btnFlowCharging);
            this.panelFlowConsole.Controls.Add(this.btnFlowCert);
            this.panelFlowConsole.Controls.Add(this.btnFlowTicketing);
            this.panelFlowConsole.Controls.Add(this.btnOrderWaiting);
            this.panelFlowConsole.Controls.Add(this.btnOrderAmountDC);
            this.panelFlowConsole.Location = new System.Drawing.Point(394, 395);
            this.panelFlowConsole.Name = "panelFlowConsole";
            this.panelFlowConsole.Size = new System.Drawing.Size(90, 369);
            this.panelFlowConsole.TabIndex = 27;
            // 
            // btnFlowLocker
            // 
            this.btnFlowLocker.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnFlowLocker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlowLocker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFlowLocker.ForeColor = System.Drawing.Color.White;
            this.btnFlowLocker.Location = new System.Drawing.Point(0, 316);
            this.btnFlowLocker.Name = "btnFlowLocker";
            this.btnFlowLocker.Size = new System.Drawing.Size(87, 48);
            this.btnFlowLocker.TabIndex = 0;
            this.btnFlowLocker.TabStop = false;
            this.btnFlowLocker.Text = "락커";
            this.btnFlowLocker.UseVisualStyleBackColor = false;
            // 
            // btnFlowCert
            // 
            this.btnFlowCert.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnFlowCert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlowCert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFlowCert.ForeColor = System.Drawing.Color.White;
            this.btnFlowCert.Location = new System.Drawing.Point(0, 108);
            this.btnFlowCert.Name = "btnFlowCert";
            this.btnFlowCert.Size = new System.Drawing.Size(87, 48);
            this.btnFlowCert.TabIndex = 0;
            this.btnFlowCert.TabStop = false;
            this.btnFlowCert.Text = "인증";
            this.btnFlowCert.UseVisualStyleBackColor = false;
            // 
            // panelDisplayAlarmWhite
            // 
            this.panelDisplayAlarmWhite.BackColor = System.Drawing.Color.White;
            this.panelDisplayAlarmWhite.Controls.Add(this.lblDisplayAlarm);
            this.panelDisplayAlarmWhite.Location = new System.Drawing.Point(6, 353);
            this.panelDisplayAlarmWhite.Name = "panelDisplayAlarmWhite";
            this.panelDisplayAlarmWhite.Size = new System.Drawing.Size(382, 39);
            this.panelDisplayAlarmWhite.TabIndex = 36;
            // 
            // lblDisplayAlarm
            // 
            this.lblDisplayAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.lblDisplayAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDisplayAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDisplayAlarm.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblDisplayAlarm.Location = new System.Drawing.Point(1, 1);
            this.lblDisplayAlarm.Name = "lblDisplayAlarm";
            this.lblDisplayAlarm.Padding = new System.Windows.Forms.Padding(5);
            this.lblDisplayAlarm.Size = new System.Drawing.Size(380, 37);
            this.lblDisplayAlarm.TabIndex = 3;
            this.lblDisplayAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.net_amount,
            this.memo});
            this.lvwOrderItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lvwOrderItem.FullRowSelect = true;
            this.lvwOrderItem.GridLines = true;
            this.lvwOrderItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwOrderItem.HideSelection = false;
            this.lvwOrderItem.Location = new System.Drawing.Point(-4, 0);
            this.lvwOrderItem.MultiSelect = false;
            this.lvwOrderItem.Name = "lvwOrderItem";
            this.lvwOrderItem.Size = new System.Drawing.Size(510, 293);
            this.lvwOrderItem.TabIndex = 37;
            this.lvwOrderItem.TabStop = false;
            this.lvwOrderItem.UseCompatibleStateImageBehavior = false;
            this.lvwOrderItem.View = System.Windows.Forms.View.Details;
            this.lvwOrderItem.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvwOrderItem_ColumnWidthChanging);
            this.lvwOrderItem.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvwOrderItem_DrawItem);
            this.lvwOrderItem.SelectedIndexChanged += new System.EventHandler(this.lvwOrderItem_SelectedIndexChanged);
            // 
            // no
            // 
            this.no.Text = "#";
            this.no.Width = 30;
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
            this.amt.Width = 70;
            // 
            // cnt
            // 
            this.cnt.Text = "수량";
            this.cnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cnt.Width = 50;
            // 
            // dc_amount
            // 
            this.dc_amount.Text = "할인";
            this.dc_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dc_amount.Width = 70;
            // 
            // net_amount
            // 
            this.net_amount.Text = "금액";
            this.net_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.net_amount.Width = 80;
            // 
            // memo
            // 
            this.memo.Text = "비고";
            this.memo.Width = 62;
            // 
            // panelOrderLvw
            // 
            this.panelOrderLvw.Controls.Add(this.lvwOrderItem);
            this.panelOrderLvw.Location = new System.Drawing.Point(7, 55);
            this.panelOrderLvw.Name = "panelOrderLvw";
            this.panelOrderLvw.Size = new System.Drawing.Size(474, 295);
            this.panelOrderLvw.TabIndex = 39;
            // 
            // panelGoodsItem
            // 
            this.panelGoodsItem.BackColor = System.Drawing.Color.DimGray;
            this.panelGoodsItem.Controls.Add(this.panelGoodsItemWhite2);
            this.panelGoodsItem.Location = new System.Drawing.Point(1, 1);
            this.panelGoodsItem.Margin = new System.Windows.Forms.Padding(0);
            this.panelGoodsItem.Name = "panelGoodsItem";
            this.panelGoodsItem.Size = new System.Drawing.Size(527, 398);
            this.panelGoodsItem.TabIndex = 44;
            // 
            // panelGoodsItemWhite2
            // 
            this.panelGoodsItemWhite2.BackColor = System.Drawing.Color.White;
            this.panelGoodsItemWhite2.Controls.Add(this.tableLayoutPanelGoodsItem);
            this.panelGoodsItemWhite2.Location = new System.Drawing.Point(1, 1);
            this.panelGoodsItemWhite2.Margin = new System.Windows.Forms.Padding(0);
            this.panelGoodsItemWhite2.Name = "panelGoodsItemWhite2";
            this.panelGoodsItemWhite2.Size = new System.Drawing.Size(525, 396);
            this.panelGoodsItemWhite2.TabIndex = 3;
            // 
            // tableLayoutPanelGoodsItem
            // 
            this.tableLayoutPanelGoodsItem.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelGoodsItem.ColumnCount = 8;
            this.tableLayoutPanelGoodsItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGoodsItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGoodsItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGoodsItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGoodsItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGoodsItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGoodsItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGoodsItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGoodsItem.Controls.Add(this.button3, 2, 0);
            this.tableLayoutPanelGoodsItem.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanelGoodsItem.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanelGoodsItem.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanelGoodsItem.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelGoodsItem.Name = "tableLayoutPanelGoodsItem";
            this.tableLayoutPanelGoodsItem.RowCount = 8;
            this.tableLayoutPanelGoodsItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanelGoodsItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanelGoodsItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanelGoodsItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanelGoodsItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanelGoodsItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanelGoodsItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanelGoodsItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanelGoodsItem.Size = new System.Drawing.Size(521, 393);
            this.tableLayoutPanelGoodsItem.TabIndex = 22;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(92)))), ((int)(((byte)(159)))));
            this.tableLayoutPanelGoodsItem.SetColumnSpan(this.button3, 2);
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(132, 2);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.tableLayoutPanelGoodsItem.SetRowSpan(this.button3, 2);
            this.button3.Size = new System.Drawing.Size(126, 94);
            this.button3.TabIndex = 1;
            this.button3.Text = "카푸치노\r\n6,000";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Highlight;
            this.tableLayoutPanelGoodsItem.SetColumnSpan(this.button2, 2);
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(2, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.tableLayoutPanelGoodsItem.SetRowSpan(this.button2, 2);
            this.button2.Size = new System.Drawing.Size(126, 94);
            this.button2.TabIndex = 0;
            this.button2.Text = "바닐라라떼\r\n1";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // panelGoodsItemWhite
            // 
            this.panelGoodsItemWhite.BackColor = System.Drawing.Color.White;
            this.panelGoodsItemWhite.Controls.Add(this.panelGoodsItem);
            this.panelGoodsItemWhite.Location = new System.Drawing.Point(488, 200);
            this.panelGoodsItemWhite.Margin = new System.Windows.Forms.Padding(0);
            this.panelGoodsItemWhite.Name = "panelGoodsItemWhite";
            this.panelGoodsItemWhite.Size = new System.Drawing.Size(529, 400);
            this.panelGoodsItemWhite.TabIndex = 45;
            // 
            // panelGoodsGroup
            // 
            this.panelGoodsGroup.BackColor = System.Drawing.Color.DimGray;
            this.panelGoodsGroup.Controls.Add(this.panelGoodsGroupWhite2);
            this.panelGoodsGroup.Location = new System.Drawing.Point(1, 1);
            this.panelGoodsGroup.Margin = new System.Windows.Forms.Padding(0);
            this.panelGoodsGroup.Name = "panelGoodsGroup";
            this.panelGoodsGroup.Size = new System.Drawing.Size(527, 136);
            this.panelGoodsGroup.TabIndex = 32;
            // 
            // panelGoodsGroupWhite2
            // 
            this.panelGoodsGroupWhite2.BackColor = System.Drawing.Color.White;
            this.panelGoodsGroupWhite2.Controls.Add(this.tableLayoutPanelGoodsGroup);
            this.panelGoodsGroupWhite2.Location = new System.Drawing.Point(1, 1);
            this.panelGoodsGroupWhite2.Margin = new System.Windows.Forms.Padding(0);
            this.panelGoodsGroupWhite2.Name = "panelGoodsGroupWhite2";
            this.panelGoodsGroupWhite2.Size = new System.Drawing.Size(525, 133);
            this.panelGoodsGroupWhite2.TabIndex = 0;
            // 
            // tableLayoutPanelGoodsGroup
            // 
            this.tableLayoutPanelGoodsGroup.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelGoodsGroup.ColumnCount = 8;
            this.tableLayoutPanelGoodsGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGoodsGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGoodsGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGoodsGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGoodsGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGoodsGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGoodsGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGoodsGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelGoodsGroup.Controls.Add(this.button19, 0, 0);
            this.tableLayoutPanelGoodsGroup.Controls.Add(this.button20, 3, 0);
            this.tableLayoutPanelGoodsGroup.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanelGoodsGroup.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanelGoodsGroup.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelGoodsGroup.Name = "tableLayoutPanelGoodsGroup";
            this.tableLayoutPanelGoodsGroup.RowCount = 2;
            this.tableLayoutPanelGoodsGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGoodsGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGoodsGroup.Size = new System.Drawing.Size(521, 130);
            this.tableLayoutPanelGoodsGroup.TabIndex = 0;
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.SystemColors.Highlight;
            this.button19.CausesValidation = false;
            this.tableLayoutPanelGoodsGroup.SetColumnSpan(this.button19, 3);
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button19.ForeColor = System.Drawing.Color.White;
            this.button19.Location = new System.Drawing.Point(2, 2);
            this.button19.Margin = new System.Windows.Forms.Padding(2);
            this.button19.Name = "button19";
            this.tableLayoutPanelGoodsGroup.SetRowSpan(this.button19, 2);
            this.button19.Size = new System.Drawing.Size(191, 125);
            this.button19.TabIndex = 0;
            this.button19.Text = "커피";
            this.button19.UseVisualStyleBackColor = false;
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.White;
            this.button20.CausesValidation = false;
            this.tableLayoutPanelGoodsGroup.SetColumnSpan(this.button20, 2);
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button20.Location = new System.Drawing.Point(197, 2);
            this.button20.Margin = new System.Windows.Forms.Padding(2);
            this.button20.Name = "button20";
            this.tableLayoutPanelGoodsGroup.SetRowSpan(this.button20, 2);
            this.button20.Size = new System.Drawing.Size(126, 125);
            this.button20.TabIndex = 0;
            this.button20.Text = "티켓";
            this.button20.UseVisualStyleBackColor = false;
            // 
            // panelGoodsGroupWhite
            // 
            this.panelGoodsGroupWhite.BackColor = System.Drawing.Color.White;
            this.panelGoodsGroupWhite.Controls.Add(this.panelGoodsGroup);
            this.panelGoodsGroupWhite.Location = new System.Drawing.Point(488, 56);
            this.panelGoodsGroupWhite.Margin = new System.Windows.Forms.Padding(0);
            this.panelGoodsGroupWhite.Name = "panelGoodsGroupWhite";
            this.panelGoodsGroupWhite.Size = new System.Drawing.Size(529, 138);
            this.panelGoodsGroupWhite.TabIndex = 46;
            // 
            // tableLayoutPanelPayControl
            // 
            this.tableLayoutPanelPayControl.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelPayControl.ColumnCount = 10;
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelPayControl.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanelPayControl.Controls.Add(this.btnPay4, 6, 2);
            this.tableLayoutPanelPayControl.Controls.Add(this.btnPay1, 0, 0);
            this.tableLayoutPanelPayControl.Controls.Add(this.btnPay2, 2, 0);
            this.tableLayoutPanelPayControl.Controls.Add(this.btnPay3, 6, 0);
            this.tableLayoutPanelPayControl.Controls.Add(this.btnPayManager, 8, 0);
            this.tableLayoutPanelPayControl.Location = new System.Drawing.Point(487, 605);
            this.tableLayoutPanelPayControl.Name = "tableLayoutPanelPayControl";
            this.tableLayoutPanelPayControl.RowCount = 4;
            this.tableLayoutPanelPayControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPayControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPayControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPayControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPayControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPayControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPayControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPayControl.Size = new System.Drawing.Size(530, 156);
            this.tableLayoutPanelPayControl.TabIndex = 47;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.tableLayoutPanelPayControl.SetColumnSpan(this.button1, 2);
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(108, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.tableLayoutPanelPayControl.SetRowSpan(this.button1, 4);
            this.button1.Size = new System.Drawing.Size(102, 152);
            this.button1.TabIndex = 2;
            this.button1.TabStop = false;
            this.button1.Text = "카드\r\n결제";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnPay4
            // 
            this.btnPay4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.tableLayoutPanelPayControl.SetColumnSpan(this.btnPay4, 2);
            this.btnPay4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPay4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPay4.ForeColor = System.Drawing.Color.White;
            this.btnPay4.Location = new System.Drawing.Point(320, 80);
            this.btnPay4.Margin = new System.Windows.Forms.Padding(2);
            this.btnPay4.Name = "btnPay4";
            this.tableLayoutPanelPayControl.SetRowSpan(this.btnPay4, 2);
            this.btnPay4.Size = new System.Drawing.Size(102, 74);
            this.btnPay4.TabIndex = 1;
            this.btnPay4.TabStop = false;
            this.btnPay4.Text = "간편\r\n결제";
            this.btnPay4.UseVisualStyleBackColor = false;
            // 
            // btnPay3
            // 
            this.btnPay3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(87)))), ((int)(((byte)(96)))));
            this.tableLayoutPanelPayControl.SetColumnSpan(this.btnPay3, 2);
            this.btnPay3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPay3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPay3.ForeColor = System.Drawing.Color.White;
            this.btnPay3.Location = new System.Drawing.Point(320, 2);
            this.btnPay3.Margin = new System.Windows.Forms.Padding(2);
            this.btnPay3.Name = "btnPay3";
            this.tableLayoutPanelPayControl.SetRowSpan(this.btnPay3, 2);
            this.btnPay3.Size = new System.Drawing.Size(102, 74);
            this.btnPay3.TabIndex = 0;
            this.btnPay3.TabStop = false;
            this.btnPay3.Text = "복합\r\n결제";
            this.btnPay3.UseVisualStyleBackColor = false;
            // 
            // timerAlarmDisplay
            // 
            this.timerAlarmDisplay.Interval = 5000;
            this.timerAlarmDisplay.Tick += new System.EventHandler(this.timerAlarm_Tick);
            // 
            // frmSale
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(63)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(1025, 770);
            this.ControlBox = false;
            this.Controls.Add(this.btnOrderItemScrollDn);
            this.Controls.Add(this.tableLayoutPanelPayControl);
            this.Controls.Add(this.panelGoodsGroupWhite);
            this.Controls.Add(this.panelGoodsItemWhite);
            this.Controls.Add(this.btnOrderItemScrollUp);
            this.Controls.Add(this.panelOrderLvw);
            this.Controls.Add(this.panelDisplayAlarmWhite);
            this.Controls.Add(this.panelOrderSumWhile);
            this.Controls.Add(this.panelTitleWhite);
            this.Controls.Add(this.panelFlowConsole);
            this.Controls.Add(this.panelNumpad);
            this.Controls.Add(this.panelOrderConsole);
            this.Font = new System.Drawing.Font("Gulim", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSale";
            this.ShowIcon = false;
            this.Text = "thepos";
            this.panelNumpad.ResumeLayout(false);
            this.panelKeyDisplayWhite.ResumeLayout(false);
            this.panelKeyDisplayWhite.PerformLayout();
            this.panelOrderConsole.ResumeLayout(false);
            this.panelTitleWhite.ResumeLayout(false);
            this.panelTitleConsole.ResumeLayout(false);
            this.panelTitleConsole.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelOrderSumWhile.ResumeLayout(false);
            this.panelOrderSumBlack.ResumeLayout(false);
            this.panelOrderSumBlack.PerformLayout();
            this.panelFlowConsole.ResumeLayout(false);
            this.panelDisplayAlarmWhite.ResumeLayout(false);
            this.panelOrderLvw.ResumeLayout(false);
            this.panelGoodsItem.ResumeLayout(false);
            this.panelGoodsItemWhite2.ResumeLayout(false);
            this.tableLayoutPanelGoodsItem.ResumeLayout(false);
            this.panelGoodsItemWhite.ResumeLayout(false);
            this.panelGoodsGroup.ResumeLayout(false);
            this.panelGoodsGroupWhite2.ResumeLayout(false);
            this.tableLayoutPanelGoodsGroup.ResumeLayout(false);
            this.panelGoodsGroupWhite.ResumeLayout(false);
            this.tableLayoutPanelPayControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnFlowSettlement;
        private System.Windows.Forms.Button btnFlowCharging;
        private System.Windows.Forms.Button btnFlowTicketing;
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
        private System.Windows.Forms.Panel panelOrderConsole;
        private System.Windows.Forms.Button btnOrderItemScrollDn;
        private System.Windows.Forms.Button btnOrderItemScrollUp;
        private System.Windows.Forms.Button btnOrderCntUp;
        private System.Windows.Forms.Button btnOrderCntDn;
        private System.Windows.Forms.Button btnOrderCntChange;
        private System.Windows.Forms.Button btnOrderAmountDC;
        private System.Windows.Forms.Button btnOrderCancelSelect;
        private System.Windows.Forms.Button btnOrderCancelAll;
        private System.Windows.Forms.Button btnPay2;
        private System.Windows.Forms.Button btnPayManager;
        private System.Windows.Forms.Button btnPay1;
        private System.Windows.Forms.Button btnOrderWaiting;
        private System.Windows.Forms.Timer timerSecondEvent;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Panel panelTitleWhite;
        private System.Windows.Forms.Panel panelOrderSumWhile;
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
        private System.Windows.Forms.Panel panelFlowConsole;
        private System.Windows.Forms.Button btnFlowLocker;
        private System.Windows.Forms.Panel panelDisplayAlarmWhite;
        private System.Windows.Forms.Panel panelTitleConsole;
        private System.Windows.Forms.Label lblTitle02;
        private System.Windows.Forms.Label lblTitle01;
        private System.Windows.Forms.Label lblTitle04;
        private System.Windows.Forms.Label lblTitle03;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel panelKeyDisplayWhite;
        private System.Windows.Forms.Label lblKeyDisplayXX;
        private System.Windows.Forms.ListView lvwOrderItem;
        private System.Windows.Forms.ColumnHeader no;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader amt;
        private System.Windows.Forms.ColumnHeader cnt;
        private System.Windows.Forms.ColumnHeader dc_amount;
        private System.Windows.Forms.ColumnHeader net_amount;
        private System.Windows.Forms.ColumnHeader memo;
        private System.Windows.Forms.Label lblDisplayAlarm;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelOrderLvw;
        private System.Windows.Forms.Panel panelGoodsItem;
        private System.Windows.Forms.Panel panelGoodsItemWhite;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGoodsItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelGoodsGroup;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Panel panelGoodsGroupWhite;
        private System.Windows.Forms.Panel panelGoodsGroupWhite2;
        private System.Windows.Forms.Panel panelGoodsItemWhite2;
        private System.Windows.Forms.Button btnOrderAmtChange;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPayControl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPay3;
        private System.Windows.Forms.Button btnPay4;
        private System.Windows.Forms.Timer timerAlarmDisplay;
        private System.Windows.Forms.Label lblPosNo;
        private System.Windows.Forms.Label lblPosName;
        private System.Windows.Forms.Label lblWorker;
        private System.Windows.Forms.Label lblBusinessDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGoodsGroup;
        private System.Windows.Forms.Button btnKey00;
        private System.Windows.Forms.Button btnKeyEnter;
        private System.Windows.Forms.Button btnFlowCert;
        private System.Windows.Forms.TextBox tbKeyDisplay;
        private System.Windows.Forms.Button button1;
    }
}

