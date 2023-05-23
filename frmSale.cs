using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Windows.Forms.VisualStyles;
using System.Collections.Generic;
using thepos.pay;



/* 과제
    + 마우스 포인터 표시 : pc pos 구분필요 
    + 리스트뷰 아이템외 클릭시 selected item의 highlight(backcolor)가 사라지는 현상 수정필요
    + 리스트뷰 HeaderColumn backcolor 변경필요 - DrawColumnHeader
    
panelProduct : 488, 56 529, 547

*/

// ▲△◀◁▶▷▼▽  <＋－＜＞↵ ↵ ⏎  ＋ ＜＜＞ △	▲	▽	▼ ⪤ □×× ◻ ■ ▽ ◇ △ ▯ ▭ ▬ ▮ ◆ ◇ □ ◪  ₩ ◆ ⁜ ⁘ ⌂ □ ■ ◆ ◇

namespace thepos
{
    public partial class frmSale : Form
    {
        //thepos the = new thepos();

        public static Font font9;
        public static Font font10;
        public static Font font14;

        public static Font font8bold;
        public static Font font10bold;  // 일반버튼
        public static Font font12bold;
        public static Font font14bold;
        public static Font font20bold;

        public static PrivateFontCollection fontCollection = new PrivateFontCollection();


        public static String mCustomerId = "";
        public static String mPosNo = "";
        public static String mBussinessDate = "";
        public int mSrerialNo = 0;


        String last_groupcode = "";  // 상품그룹을 클릭했을 경우 눌려진버튼을 또 눌렀는지 비교하기 위함.

        public static String mRunningOrderNo = "";

        int waiting_count = 0;


        Button[] btnGoodsGroup;


        public static Panel mPanelTitleConsole;
        public static Panel mPanelOrderConsole;
        public static Panel mPanelProductConsole;
        public static Label mLblDisplayAlarm;
        public static Label mLblKeyDisplay;
        public static ListView mLvwOrderItem;
        public static Label mLblOrderAmount;
        public static Label mLblOrderAmountDC;
        public static Label mLblOrderAmountNet;
        public static int mNetAmount = 0;
        public static Timer mTimerAlarm;


        public struct OrderItem
        {
            public String code;     // 상품code(6) or 전체할인코드고정("DC")
            public String name;     // 상품name or 전체할인명("할인")
            public int cnt;
            public int amt;
            public int dc_amount;       // 실할인금액
            public String dcr_type;     // type - "A" : 정액, "R" : 정율 
            public String dcr_des;      // 전체"E", 선택"S"
            public int dcr_value;       // 할인금액 or 할인율
        }

        struct GoodsGroup
        {
            public string code;  // 3
            public string name;
            public string type;  // 사용가능한 pos_type : 모든POS = "ALL", 그룹POS= "G00"
        }
        GoodsGroup[] mGoodsGroup;

        struct GoodsItem
        {
            public string code;  // 6
            public string name;
            public int amt;
            public int column;
            public int row;
            public int columnspan;
            public int rowspan;
        }
        GoodsItem[] mGoodsItem;

        struct PayItem
        {
            public string code; // CASH, CARD, COMPLEX, CERT, EASY
                                // 현금  카드   복합결제  인증   간편결제
            public int column;
            public int row;
            public int columnspan;
            public int rowspan;
        }
        PayItem[] mPayItem;


        public struct Waiting
        {
            public int waiting_no;
            public String order_no;  // 대기번호 = order_no(20) : 00000yymmddHHMMSS000 
            public int cnt;         // 항목수
            public DateTime dt;
            public int amount;      //합계
            public int rcv_amount;  //받은금액
            public String type;     // 주문중(1)  결제중(2)
        }
        public static List<Waiting> listWaiting = new List<Waiting>();

        public struct WaitingItem
        {
            public String order_no;
            public OrderItem order_item;
        }
        public static List<WaitingItem> listWaitingItem = new List<WaitingItem>();


        void get_goodsgroup()
        {

            String[,] group = new String[,]
            {
                {"101","커피","G01"},
                {"100","티켓","ALL"},
                {"102","식사","G02"},
                {"103","후식","G01"},
                {"104","직원방문","G01"},
                {"105","야간","G01"},
                {"106","VIP","G01"},
                {"107","장애인","G01"},
                {"108","","G01"},
                {"109","기본","G01"},
            };


            int len = group.Length / 3;


            mGoodsGroup = new GoodsGroup[len];

            for (int i = 0; i < len; i++)
            {
                mGoodsGroup[i].code = group[i, 0];
                mGoodsGroup[i].name = group[i, 1];
                mGoodsGroup[i].type = group[i, 2];
            }

        }

        void get_goodsitem()
        {
            String[,] item = new String[,]
            {
                { "101101","바닐라라떼","1", "0","0", "2","2"},
                { "101102","카푸치노","6000", "2","0", "1","2"},
                { "101103","에스프레소","7000", "3","0", "3","2"},
                { "101104","아이스라떼","6500", "6","1", "2","1"},
                { "101105","아메리카노","5000", "0","2", "4","3"},
                { "101106","맥심커피","8000", "4","2", "4","4"},
                { "101108","카페라떼","7000", "0","5", "3","3"},
                { "101107","캬라멜","6000", "3","5", "1","3"},
                { "101109","아리스카페모카","5000", "4","6", "2","1"},
                { "101110","모카","5000", "4","7", "3","1"},

                { "100001","종일성인","10000", "0","1", "4","5"},
                { "100002","종일어린이","8000", "4","1", "4","5"},

            };


            int len = item.Length / 7;

            mGoodsItem = new GoodsItem[len];

            for (int i = 0; i < len; i++)
            {
                mGoodsItem[i].code = item[i, 0];
                mGoodsItem[i].name = item[i, 1];
                mGoodsItem[i].amt = int.Parse(item[i, 2]);

                mGoodsItem[i].column = int.Parse(item[i, 3]);
                mGoodsItem[i].row = int.Parse(item[i, 4]);
                mGoodsItem[i].columnspan = int.Parse(item[i, 5]);
                mGoodsItem[i].rowspan = int.Parse(item[i, 6]);
            }
        }

        void get_payItem()
        {
            String[,] item = new String[,]
            {
                { "CASH", "0", "0", "3","4"},
                { "CARD", "3", "0", "3","4"},
                { "COMPLEX", "6", "0", "1","2"},
                { "CERT", "7", "0", "1","2"},
                { "EASY", "6", "2", "2","2"},
                { "MANAGER", "8", "0", "2","4"},
            };

            int len = item.Length / 5;
            mPayItem = new PayItem[len];

            for (int i = 0; i < len; i++)
            {
                mPayItem[i].code = item[i, 0];
                mPayItem[i].column = int.Parse(item[i, 1]);
                mPayItem[i].row = int.Parse(item[i, 2]);
                mPayItem[i].columnspan = int.Parse(item[i, 3]);
                mPayItem[i].rowspan = int.Parse(item[i, 4]);
            }
        }


        public frmSale()
        {
            InitializeComponent();

            //? PC가 아니면 마우스 포인터 표시안함.
            //Cursor.Hide();

            initialize_font();
            initialize_the();

            // 사업장코드, POS_NO
            mCustomerId = "CUST";
            mPosNo = "01";

            get_payItem();
            display_payconsol();

            get_goodsgroup();
            get_goodsitem();
            display_goodsgroup();
            ClickedGoodsGroup(mGoodsGroup[0].code);   // 최초실행후 첮 구룹을 선택한 화면을 보여주자...
        }



        private void initialize_font()
        {
            fontCollection.AddFontFile("Font\\TossProductSansTTF-Regular.ttf");


            font9 = new Font(fontCollection.Families[0], 9f);
            font10 = new Font(fontCollection.Families[0], 10f);
            font14 = new Font(fontCollection.Families[0], 14f);

            font8bold = new Font(fontCollection.Families[0], 8f, FontStyle.Bold);
            font10bold = new Font(fontCollection.Families[0], 10f, FontStyle.Bold);
            font12bold = new Font(fontCollection.Families[0], 12f, FontStyle.Bold);
            font14bold = new Font(fontCollection.Families[0], 14f, FontStyle.Bold);
            font20bold = new Font(fontCollection.Families[0], 20f, FontStyle.Bold);


            lblTitle01.Font = font9;
            lblTitle02.Font = font9;
            lblTitle03.Font = font9;
            lblTitle04.Font = font9;
            
            lblPosName.Font = font9;
            lblPosNo.Font = font9;
            lblBusinessDate.Font = font9;
            lblWorker.Font = font9;


            lblDate.Font = font10;
            lblTime.Font = font12bold;

            lvwOrderItem.Font = font10bold;

            btnOrderCancelAll.Font = font10;
            btnOrderCancelSelect.Font = font10;
            btnOrderCntDn.Font = font10;
            btnOrderCntUp.Font = font10;
            btnOrderCntChange.Font = font10;
            btnOrderItemScrollUp.Font = font10;
            btnOrderItemScrollDn.Font = font10;

            lblOrderAmountSumTitle.Font = font10;
            lblOrderAmountDCTitle.Font = font10;
            lblOrderAmountChargeTitle.Font = font10;
            lblOrderAmountReceiveTitle.Font = font10;
            lblOrderAmountRestTitle.Font = font10;

            lblOrderAmount.Font = font14bold;
            lblOrderAmountDC.Font = font14bold;
            lblOrderAmountNet.Font = font14bold;
            lblOrderAmountReceive.Font = font14bold;
            lblOrderAmountRest.Font = font14bold;

            lblKeyDisplay.Font = font14bold;
            btnKey1.Font = font14bold;
            btnKey2.Font = font14bold;
            btnKey3.Font = font14bold;
            btnKey4.Font = font14bold;
            btnKey5.Font = font14bold;
            btnKey6.Font = font14bold;
            btnKey7.Font = font14bold;
            btnKey8.Font = font14bold;
            btnKey9.Font = font14bold;
            btnKey0.Font = font14bold;
            btnKey00.Font = font14bold;
            btnKeyBS.Font = font14bold;
            btnKeyClear.Font = font14bold;

            btnOrderAmountDC.Font = font10bold;
            btnOrderWaiting.Font = font10bold;

            btnTicketing.Font = font10bold;
            btnCharging.Font = font10bold;
            btnSettlement.Font = font10bold;
            btnLocker.Font = font10bold;

        }
        private void initialize_the()
        {
            //Title에 일자 요일을 표시
            setDateTitle();


            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 32);

            lvwOrderItem.SmallImageList = imgList;
            lvwOrderItem.HideSelection = true;

            btnKey1.Click += (sender, args) => ClickedKey("1");
            btnKey2.Click += (sender, args) => ClickedKey("2");
            btnKey3.Click += (sender, args) => ClickedKey("3");
            btnKey4.Click += (sender, args) => ClickedKey("4");
            btnKey5.Click += (sender, args) => ClickedKey("5");
            btnKey6.Click += (sender, args) => ClickedKey("6");
            btnKey7.Click += (sender, args) => ClickedKey("7");
            btnKey8.Click += (sender, args) => ClickedKey("8");
            btnKey9.Click += (sender, args) => ClickedKey("9");
            btnKey0.Click += (sender, args) => ClickedKey("0");
            btnKey00.Click += (sender, args) => ClickedKey("00");
            btnKeyBS.Click += (sender, args) => ClickedKey("BS");
            btnKeyClear.Click += (sender, args) => ClickedKey("Clear");
            btnKeyEnter.Click += (sender, args) => ClickedKey("Enter");


            // 서브창이 열리면서 Sale창의 콘트롤 Enable/Disable 관리를 위해서...
            mPanelTitleConsole = panelTitleConsole;
            mPanelOrderConsole = panelOrderConsole;
            mPanelProductConsole = panelProductConsole;

            mLblDisplayAlarm = lblDisplayAlarm;
            mTimerAlarm = timerAlarmDisplay;

            mLblKeyDisplay = lblKeyDisplay;
            mLvwOrderItem = lvwOrderItem;

            mLblOrderAmount = lblOrderAmount;
            mLblOrderAmountDC = lblOrderAmountDC;
            mLblOrderAmountNet = lblOrderAmountNet;

        }

        private void display_goodsgroup()
        {
            btnGoodsGroup = new Button[mGoodsGroup.Length];


            flowLayoutPanelGoodsGroup.Controls.Clear();

            for (int i = 0; i < mGoodsGroup.Length; i++)
            {
                String groupcode = mGoodsGroup[i].code;
                btnGoodsGroup[i] = new Button();
                btnGoodsGroup[i].Text = mGoodsGroup[i].name;
                btnGoodsGroup[i].Tag = mGoodsGroup[i].code;
                btnGoodsGroup[i].Height = 60;
                btnGoodsGroup[i].Width = 92;
                btnGoodsGroup[i].Font = font12bold;

                btnGoodsGroup[i].FlatStyle = FlatStyle.Flat;
                btnGoodsGroup[i].ForeColor = SystemColors.Highlight;
                btnGoodsGroup[i].BackColor = Color.White;
                btnGoodsGroup[i].FlatAppearance.BorderSize = 2;

                btnGoodsGroup[i].Margin = new Padding(2, 2, 2, 2);

                btnGoodsGroup[i].Click += (sender, args) => ClickedGoodsGroup(groupcode);
                flowLayoutPanelGoodsGroup.Controls.Add(btnGoodsGroup[i]);
            }

        }

        private void display_payconsol()
        {
            System.Windows.Forms.Button btnPayItem = new System.Windows.Forms.Button();

            tableLayoutPanelPayControl.Controls.Clear();

            this.tableLayoutPanelPayControl.VerticalScroll.Value = 0;
            tableLayoutPanelPayControl.PerformLayout();

            for (int i = 0; i < mPayItem.Length; i++)
            {
                btnPayItem = new System.Windows.Forms.Button();
                btnPayItem.Tag = mPayItem[i].code;
                btnPayItem.FlatStyle = FlatStyle.Flat;
                btnPayItem.TabStop = false;
                btnPayItem.Margin = new Padding(2, 2, 2, 2);
                btnPayItem.Padding = new Padding(0, 0, 0, 0);
                btnPayItem.Dock = DockStyle.Fill;
                btnPayItem.ForeColor = Color.White;
                btnPayItem.BackColor = Color.FromArgb(68, 87, 96);

                btnPayItem.Font = font12bold;

                if (mPayItem[i].code == "CASH") btnPayItem.Text = "현금";
                else if (mPayItem[i].code == "CARD") btnPayItem.Text = "카드";
                else if (mPayItem[i].code == "COMPLEX") btnPayItem.Text = "복합\r결제";
                else if (mPayItem[i].code == "CERT") btnPayItem.Text = "인증";
                else if (mPayItem[i].code == "EASY") btnPayItem.Text = "간편\r결제";
                else if (mPayItem[i].code == "MANAGER") btnPayItem.Text = "결제내역\r관리";
                else btnPayItem.Text = "";

                string code = mPayItem[i].code;
                btnPayItem.Click += (sender, args) => ClickedPayItem(code);


                tableLayoutPanelPayControl.Controls.Add(btnPayItem, mPayItem[i].column, mPayItem[i].row);
                tableLayoutPanelPayControl.SetColumnSpan(btnPayItem, mPayItem[i].columnspan);
                tableLayoutPanelPayControl.SetRowSpan(btnPayItem, mPayItem[i].rowspan);
            }
        }

        private void ClickedGoodsGroup(String groupcode)
        {
            if (last_groupcode == groupcode)
            {
                return;
            }

            System.Windows.Forms.Button btnGoodsItem = new System.Windows.Forms.Button();
            
            tableLayoutPanelGoodsItem.Controls.Clear();
            setGroupButtonColor(last_groupcode, false);
            setGroupButtonColor(groupcode, true);


            this.tableLayoutPanelGoodsItem.VerticalScroll.Value = 0;
            tableLayoutPanelGoodsItem.PerformLayout();


            for (int i = 0; i < mGoodsItem.Length; i++)
            {
                if (groupcode == mGoodsItem[i].code.Substring(0,3))
                {
                    int idx = i;
                    btnGoodsItem = new System.Windows.Forms.Button();

                    btnGoodsItem.Tag = mGoodsItem[i].code;
                    btnGoodsItem.FlatStyle = FlatStyle.Flat;
                    btnGoodsItem.ForeColor = Color.White;
                    btnGoodsItem.BackColor = SystemColors.Highlight;
                    btnGoodsItem.TabStop = false;
                    btnGoodsItem.Margin = new Padding(2, 2, 2, 2);
                    btnGoodsItem.Padding = new Padding(0, 0, 0, 0);
                    btnGoodsItem.Text = mGoodsItem[i].name + "\n" + mGoodsItem[i].amt.ToString("N0");

                    
                    if (mGoodsItem[i].columnspan == 1 | mGoodsItem[i].rowspan == 1)
                    {
                        btnGoodsItem.Font = font8bold;
                    }
                    else if (mGoodsItem[i].columnspan == 2 | mGoodsItem[i].rowspan == 2)
                    {
                        btnGoodsItem.Font = font14bold;
                    }
                    else
                    {
                        btnGoodsItem.Font = font20bold;
                    }
                    

                    btnGoodsItem.Click += (sender, args) => ClickedGoodsItem(idx);
                    btnGoodsItem.Dock = DockStyle.Fill;

                    tableLayoutPanelGoodsItem.Controls.Add(btnGoodsItem, mGoodsItem[i].column, mGoodsItem[i].row);
                    tableLayoutPanelGoodsItem.SetColumnSpan(btnGoodsItem, mGoodsItem[i].columnspan);
                    tableLayoutPanelGoodsItem.SetRowSpan(btnGoodsItem, mGoodsItem[i].rowspan);
                }
            }
 
            last_groupcode = groupcode;
        }

        private void ClickedGoodsItem(int i)
        {
            OrderItem orderItem = new OrderItem();
            int lv_idx = (get_lvitem_idx(mGoodsItem[i].code));  // 이미  동일 상품이 주문리스트뷰에 있는지

            if (lv_idx == -1)
            {
                ListViewItem item = new ListViewItem();

                orderItem.code = mGoodsItem[i].code.ToString();
                orderItem.name = mGoodsItem[i].name.ToString();
                orderItem.amt = mGoodsItem[i].amt;
                orderItem.cnt = 1;
                orderItem.dc_amount = 0;
                orderItem.dcr_type = "";
                //orderItem.dcr_des = "";
                orderItem.dcr_value = 0;

                item.Tag = orderItem;
                item.Text = (lvwOrderItem.Items.Count + 1).ToString();
                item.SubItems.Add(orderItem.name);                // 1: name 상품명
                item.SubItems.Add(orderItem.amt.ToString("N0"));  // 2: amt 단가
                item.SubItems.Add("1");                               // 3: cnt 수량
                item.SubItems.Add("");                                // 4: dc_amount 할인
                item.SubItems.Add(orderItem.amt.ToString("N0"));  // 5: net_amount 금액
                item.SubItems.Add("");                                // 6: 비고

                lvwOrderItem.Items.Add(item);
                lvwOrderItem.Items[lvwOrderItem.Items.Count - 1].EnsureVisible();
                lvwOrderItem.Items[lvwOrderItem.Items.Count - 1].Selected = true;
            }
            else
            {
                set_item_change_ordercnt(lv_idx, "add", 1);
                lvwOrderItem.Items[lv_idx].Selected = true;
            }

            ReCalculateAmount();
        }

        private void ClickedPayItem(string code)
        {
            ConsoleDisable();

            Form fPay;

            if (code == "CASH") fPay = new frmPayCash();
            else if (code == "CARD") fPay = new frmPayCard();
//            else if (code == "COMPLEX") fPay = new frmPayComplex();
//            else if (code == "CERT") fPay = new frmPayCert();
//            else if (code == "EASY") fPay = new frmPayEasy();
            else if (code == "MANAGER") fPay = new frmPayManager();
            else return;

            fPay.Left += this.Location.X;
            fPay.Top += this.Location.Y;

            fPay.Show();
        }

        // OrderItem ListView 관련 버튼들
        private void btnOrderCancelAll_Click(object sender, EventArgs e)
        {
            lvwOrderItem.Items.Clear();

            ReCalculateAmount();
        }

        private void btnOrderCancelSelect_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.SelectedItems.Count > 0)
            {
                int idx = lvwOrderItem.SelectedItems[0].Index;

                lvwOrderItem.SelectedItems[0].Remove();

                if (idx == lvwOrderItem.Items.Count & idx == 0)
                {
                    // 
                }
                else if (idx == lvwOrderItem.Items.Count)
                {
                    lvwOrderItem.Items[idx - 1].Selected = true;
                }
                else
                {
                    lvwOrderItem.Items[idx].Selected = true;
                }

                // renumbering
                for (int i = idx; i < lvwOrderItem.Items.Count; i++)
                {
                    lvwOrderItem.Items[i].Text = (i+1).ToString();
                }

                ReCalculateAmount();
            }
        }

        private void btnOrderAmtChange_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.SelectedItems.Count > 0)
            {
                if (int.TryParse(lblKeyDisplay.Text, out int amt))
                {
                    if (amt > 0 & amt < 100000000)
                    {
                        set_item_change_orderamt(lvwOrderItem.SelectedItems[0].Index, "set", amt);
                        lblKeyDisplay.Text = "";
                        ReCalculateAmount();
                    }
                    else
                    {
                        SetDisplayAlarm("W", "수량은 1000이상 입력할 수 없습니다.");
                        return;
                    }
                }
                else
                {
                    SetDisplayAlarm("E", "수량 입력값 오류.");
                    return;
                }
            }


        }

            private void btnOrderCntDn_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.SelectedItems.Count > 0)
            {
                if (((OrderItem)lvwOrderItem.SelectedItems[0].Tag).cnt == 1)
                {
                    SetDisplayAlarm("W", "수량은 0이하로 입력할 수 없습니다.");
                    return;
                }

                int lv_idx = lvwOrderItem.SelectedItems[0].Index;
                set_item_change_ordercnt(lv_idx, "add", -1);
                ReCalculateAmount();
            }
        }

        private void btnOrderCntUp_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.SelectedItems.Count > 0)
            {
                if (((OrderItem)lvwOrderItem.SelectedItems[0].Tag).cnt >= 999)
                {
                    SetDisplayAlarm("W", "수량은 1000이상 입력할 수 없습니다.");
                    return;
                }

                int lv_idx = lvwOrderItem.SelectedItems[0].Index;
                set_item_change_ordercnt(lv_idx, "add", 1);
                ReCalculateAmount();
            }
        }

        private void btnOrderCntChange_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.SelectedItems.Count > 0)
            {
                if (int.TryParse(lblKeyDisplay.Text, out int cnt))
                {
                    if (cnt > 0 & cnt < 1000)
                    {
                        set_item_change_ordercnt(lvwOrderItem.SelectedItems[0].Index, "set", cnt);
                        lblKeyDisplay.Text = "";
                        ReCalculateAmount();
                    }
                    else
                    {
                        SetDisplayAlarm("W", "수량은 1000이상 입력할 수 없습니다.");
                        return;
                    }
                }
                else
                {
                    SetDisplayAlarm("E", "수량 입력값 오류.");
                    return;
                }
            }
        }


        // ///////////////////////////////////////////////////////////////////////////////////////////////////////

        // 할인
        private void btnOrderAmountDC_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.Items.Count > 0)
            {
                ConsoleDisable();

                frmAmountDC fAmountDC = new frmAmountDC();

                fAmountDC.Left += this.Location.X;
                fAmountDC.Top += this.Location.Y;

                fAmountDC.Show();
            }
        }



 
        // 대기
        private void btnOrderWaiting_Click(object sender, EventArgs e)
        {
            // 웨이팅 저장, 불러오기 겸용버튼
            if (lvwOrderItem.Items.Count > 0)
            {
                Waiting waiting = new Waiting();

                if (mRunningOrderNo == "")
                {
                    mRunningOrderNo = create_the_no();
                }

                waiting.order_no = mRunningOrderNo;
                waiting.waiting_no = ++waiting_count;

                waiting.cnt = 0;
                waiting.dt = DateTime.Now;
                waiting.amount = 0;
                waiting.rcv_amount = 0;
                waiting.type = "1";    // 주문중

                for (int i = 0; i < lvwOrderItem.Items.Count; i++)
                {
                    OrderItem orderItem = (OrderItem)lvwOrderItem.Items[i].Tag;

                    waiting.cnt++;
                    waiting.amount += (orderItem.cnt * orderItem.amt);

                    WaitingItem waitingItem = new WaitingItem();
                    waitingItem.order_no = waiting.order_no;
                    waitingItem.order_item = orderItem;
                    listWaitingItem.Add(waitingItem);
                }

                listWaiting.Add(waiting);

                lvwOrderItem.Items.Clear();
                btnOrderWaiting.Text = "대기\n" + listWaiting.Count + "";

                mRunningOrderNo = "";


                lvwOrderItem.Items.Clear();
                ReCalculateAmount();


            }
            else
            {
                if (listWaiting.Count > 0)
                {
                    ConsoleDisable();

                    frmWaiting fWaiting = new frmWaiting();
                    fWaiting.Left += this.Location.X;
                    fWaiting.Top += this.Location.Y;

                    var result = fWaiting.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        int lv_no = 0;
                        for (int i = 0; i < listWaitingItem.Count; i++)
                        {
                            if (listWaitingItem[i].order_no == mRunningOrderNo)
                            {
                                lv_no++;

                                ListViewItem lvItem = new ListViewItem();

                                lvItem.Tag = listWaitingItem[i].order_item;

                                OrderItem orderItem = new OrderItem();
                                orderItem = listWaitingItem[i].order_item;

                                lvItem.Text = (lv_no).ToString();
                                lvItem.SubItems.Add(orderItem.name);                            // 1: name 상품명
                                lvItem.SubItems.Add(orderItem.amt.ToString("N0"));              // 2: amt 단가
                                lvItem.SubItems.Add(orderItem.cnt.ToString());                  // 3: cnt 수량
                                lvItem.SubItems.Add(orderItem.dc_amount.ToString("#,###"));     // 4: dc_amount 할인
                                
                                int net_amount = (orderItem.amt * orderItem.cnt) - orderItem.dc_amount;
                                lvItem.SubItems.Add(net_amount.ToString("N0"));                 // 5: net_amount 금액

                                lvItem.SubItems.Add(getDCRmemo(orderItem));                     // 6: 메모

                                lvwOrderItem.Items.Add(lvItem);
                                lvwOrderItem.Items[lvwOrderItem.Items.Count - 1].EnsureVisible();
                            }
                        }
                        lvwOrderItem.Items[lvwOrderItem.Items.Count - 1].Selected = true;


                        for (int i = listWaitingItem.Count - 1; i >= 0; i--)
                        {
                            if (listWaitingItem[i].order_no == mRunningOrderNo)
                            {
                                listWaitingItem.RemoveAt(i);
                            }
                        }

                        for (int i = 0; i < listWaiting.Count; i++)
                        {
                            if (listWaiting[i].order_no == mRunningOrderNo)
                            {
                                listWaiting.RemoveAt(i);
                            }
                        }
                    }

                    //
                    if (listWaiting.Count > 0)
                    {
                        btnOrderWaiting.Text = "대기\n" + listWaiting.Count + "";
                    }
                    else
                    {
                        btnOrderWaiting.Text = "대기";
                    }

                    ReCalculateAmount();

                    ConsoleEnable();
                }
            }

        }










        private void btnPayManager_Click(object sender, EventArgs e)
        {
            ConsoleDisable();

            frmPayManager fLogo = new frmPayManager();

            fLogo.Left += this.Location.X;
            fLogo.Top += this.Location.Y;

            fLogo.ShowDialog();
        }











        // ///////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void ConsoleEnable()
        {
            mPanelTitleConsole.Enabled = true;
            mPanelOrderConsole.Enabled = true;
            mPanelProductConsole.Enabled = true;
        }

        void ConsoleDisable()
        {
            panelTitleConsole.Enabled = false;
            panelOrderConsole.Enabled = false;
            panelProductConsole.Enabled = false;
        }

        public static String getDCRmemo(OrderItem orderItem)
        {
            string memo = "";
            
            if (orderItem.dcr_type == "R")
            {
                memo += orderItem.dcr_value + "%";
            }
            else if (orderItem.dcr_type == "A")
            {
                memo += "₩";
            }

            return memo;
        }

        public static void SetDisplayAlarm(String Level, String msg)
        {
            if (Level == "E") mLblDisplayAlarm.ForeColor = Color.OrangeRed;
            else if (Level == "W") mLblDisplayAlarm.ForeColor = Color.Orange;
            else mLblDisplayAlarm.ForeColor = Color.LightGray;

            mLblDisplayAlarm.Text = msg;

            mTimerAlarm.Enabled = false;
            mTimerAlarm.Enabled = true;
        }

        private void timerAlarm_Tick(object sender, EventArgs e)
        {
            lblDisplayAlarm.Text = "";
            timerAlarmDisplay.Enabled = false;
        }

        private void set_item_change_orderamt(int lv_idx, String jobtype, int amt)
        {
            OrderItem orderItem = (OrderItem)lvwOrderItem.Items[lv_idx].Tag;

            if (jobtype == "set")
            {
                orderItem.amt = amt;
            }
            else
            {
                return;
            }

            lvwOrderItem.Items[lv_idx].SubItems[2].Text = orderItem.amt.ToString("N0");           // amt

            if (orderItem.dcr_type == "R")
            {
                orderItem.dc_amount = ((orderItem.cnt * orderItem.amt) * orderItem.dcr_value) / 100;
            }

            int net_amount = (orderItem.cnt * orderItem.amt) - orderItem.dc_amount;
            lvwOrderItem.Items[lv_idx].SubItems[4].Text = orderItem.dc_amount.ToString("N0");
            lvwOrderItem.Items[lv_idx].SubItems[5].Text = net_amount.ToString("N0");        // net_amount

            lvwOrderItem.Items[lv_idx].Tag = orderItem;
        }

        private void set_item_change_ordercnt(int lv_idx, String jobtype, int cnt)
        {
            OrderItem orderItem = (OrderItem)lvwOrderItem.Items[lv_idx].Tag;

            if (jobtype == "add")
            {
                orderItem.cnt += cnt;
            }
            else if (jobtype == "set")
            {
                orderItem.cnt = cnt;
            }
            else
            {
                return;
            }

            lvwOrderItem.Items[lv_idx].SubItems[3].Text = orderItem.cnt.ToString("N0");           // cnt

            if (orderItem.dcr_type == "R")
            {
                orderItem.dc_amount = ((orderItem.cnt * orderItem.amt) * orderItem.dcr_value) / 100;
            }


            int net_amount = (orderItem.cnt * orderItem.amt) - orderItem.dc_amount;
            lvwOrderItem.Items[lv_idx].SubItems[4].Text = orderItem.dc_amount.ToString("###,###,###");
            lvwOrderItem.Items[lv_idx].SubItems[5].Text = net_amount.ToString("N0");        // net_amount

            lvwOrderItem.Items[lv_idx].Tag = orderItem;
        }

        public static void ReCalculateAmount()
        {
            int Amount = 0;
            int dcAmount = 0;
            mNetAmount = 0;

            OrderItem orderItemInfo;

            for (int i = 0; i < mLvwOrderItem.Items.Count; i++)
            {
                orderItemInfo = (OrderItem)mLvwOrderItem.Items[i].Tag;
                Amount += (orderItemInfo.cnt * orderItemInfo.amt);
                dcAmount += orderItemInfo.dc_amount;
                mNetAmount += ((orderItemInfo.cnt * orderItemInfo.amt) - orderItemInfo.dc_amount);
            }

            mLblOrderAmount.Text =Amount.ToString("N0");
            mLblOrderAmountDC.Text = dcAmount.ToString("N0");
            mLblOrderAmountNet.Text = mNetAmount.ToString("N0");
        }


        //  스크롤 selected up down
        private void btnOrderItemScrollUp_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.SelectedItems.Count > 0)
            {
                int sel_idx = lvwOrderItem.SelectedItems[0].Index;

                if (sel_idx > 0)
                {
                    lvwOrderItem.Items[sel_idx - 1].Selected = true;

                    if (lvwOrderItem.TopItem.Index > sel_idx - 1)
                    {
                        lvwOrderItem.TopItem = lvwOrderItem.Items[sel_idx - 1];
                    }
                }
            }
            else
            {
                if (lvwOrderItem.Items.Count > 0)
                {
                    int top_idx = this.lvwOrderItem.TopItem.Index;
                    if (top_idx > 0 & top_idx < lvwOrderItem.Items.Count - 1)
                    {
                        lvwOrderItem.TopItem = lvwOrderItem.Items[top_idx - 1];
                    }
                }
            }
        }

        private void btnOrderItemScrollDn_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.SelectedItems.Count > 0)
            {
                int sel_idx = lvwOrderItem.SelectedItems[0].Index;

                if (sel_idx < lvwOrderItem.Items.Count - 1)
                {
                    lvwOrderItem.Items[sel_idx + 1].Selected = true;

                    int top_idx = this.lvwOrderItem.TopItem.Index;
                    if (sel_idx - top_idx > 6 & sel_idx < lvwOrderItem.Items.Count - 1)
                    {
                        lvwOrderItem.TopItem = lvwOrderItem.Items[top_idx + 1];
                    }
                }
            }
            else
            {
                if (lvwOrderItem.Items.Count > 0)
                {
                    int curItem = this.lvwOrderItem.TopItem.Index;
                    if (curItem < this.lvwOrderItem.Items.Count - 1)
                    {
                        this.lvwOrderItem.TopItem = this.lvwOrderItem.Items[curItem + 1];
                    }
                }
            }
        }

        //  지원서브루트

        private void ClickedKey(string sKey)
        {
            if (sKey == "BS")
            {
                if (lblKeyDisplay.Text.Length > 0 )
                {
                    lblKeyDisplay.Text = lblKeyDisplay.Text.Substring(0, lblKeyDisplay.Text.Length - 1);
                }
            }
            else if (sKey == "Clear")
            {
                lblKeyDisplay.Text = "";
            }
            else if (sKey == "Enter")
            {
                //
            }
            /*
            else if (sKey == "0" | sKey == "00")
            {
                if (lblKeyDisplay.Text.Length > 0)
                {
                    lblKeyDisplay.Text += sKey;
                }
            }
            */
            else
            {
                lblKeyDisplay.Text += sKey;
            }
        }

        private void setGroupButtonColor(String groupcode, bool isPressed)
        {
            int button_idx = -1;

            for (int i = 0; i < mGoodsGroup.Length; i++)
            {
                if (mGoodsGroup[i].code == groupcode)
                {
                    button_idx = i;
                }
            }


            if (button_idx == -1) return;


            if (!isPressed)
            {
                btnGoodsGroup[button_idx].ForeColor = SystemColors.Highlight;
                btnGoodsGroup[button_idx].BackColor = Color.White;
                btnGoodsGroup[button_idx].FlatAppearance.BorderSize = 2;
            }
            else
            {
                btnGoodsGroup[button_idx].ForeColor = Color.White;
                btnGoodsGroup[button_idx].BackColor = SystemColors.Highlight;
                btnGoodsGroup[button_idx].FlatAppearance.BorderSize = 0;
            }
        }

        private int get_lvitem_idx(string code)
        {
            for (int i = 0; i < lvwOrderItem.Items.Count; i++)
            {
                if (code == ((OrderItem)(lvwOrderItem.Items[i].Tag)).code)
                { return i; }
            }
            return -1;
        }

        private void timerSecondEvent_Tick(object sender, EventArgs e)
        {
            DateTime nowDt = DateTime.Now;

            if (timerSecondEvent.Tag.ToString() == "0")
            {
                lblTime.Text = nowDt.ToString("HH:mm");
                timerSecondEvent.Tag = "1";
            }
            else
            {
                lblTime.Text = nowDt.ToString("HH  mm");
                timerSecondEvent.Tag = "0";
            }


            if (nowDt.ToString("HHmms0") == "000000")
            {
                setDateTitle();
            }
        }

        void setDateTitle()
        {
            DateTime nowDt = DateTime.Now;
            String strWeek = "";
            if (nowDt.DayOfWeek == DayOfWeek.Monday) strWeek = "월";
            else if (nowDt.DayOfWeek == DayOfWeek.Tuesday) strWeek = "화";
            else if (nowDt.DayOfWeek == DayOfWeek.Wednesday) strWeek = "수";
            else if (nowDt.DayOfWeek == DayOfWeek.Thursday) strWeek = "목";
            else if (nowDt.DayOfWeek == DayOfWeek.Friday) strWeek = " 금";
            else if (nowDt.DayOfWeek == DayOfWeek.Saturday) strWeek = "토";
            else if (nowDt.DayOfWeek == DayOfWeek.Sunday) strWeek = "일";

            lblDate.Text = DateTime.Now.ToString("yyyy.MM.dd") + " [" + strWeek + "]";
        }

        private void lvwOrderItem_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvwOrderItem.Columns[e.ColumnIndex].Width;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnScrollGroupUp_Click(object sender, EventArgs e)
        {
            if (this.flowLayoutPanelGoodsGroup.VerticalScroll.Value > 0)
            {
                this.flowLayoutPanelGoodsGroup.VerticalScroll.Value -= 64;
                flowLayoutPanelGoodsGroup.PerformLayout();
            }
        }

        private void btnScrollGroupDn_Click(object sender, EventArgs e)
        {
            this.flowLayoutPanelGoodsGroup.VerticalScroll.Value += 64;
            flowLayoutPanelGoodsGroup.PerformLayout();
        }

        private void lvwOrderItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lvwOrderItem.Items.Cast<ListViewItem>()
                .ToList().ForEach(item =>
                {
                    item.BackColor = SystemColors.Window;
                    item.ForeColor = SystemColors.WindowText;
                });
            this.lvwOrderItem.SelectedItems.Cast<ListViewItem>()
                .ToList().ForEach(item =>
                {
                    item.BackColor = SystemColors.Highlight;
                    item.ForeColor = SystemColors.HighlightText;
                });
        }

        private void lvwOrderItem_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
            e.DrawText();
        }

        private void lvwOrderItem_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lvwOrderItem_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        public String create_the_no()
        {

            return mBussinessDate(8) + mPosNo + (++mSerialNo).ToString("0000") + Random(3);
        }





    }
}
