using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Collections.Generic;




/* 과제
    + 마우스 포인터 표시 : pc pos 구분필요 
    + 리스트뷰 아이템외 클릭시 selected item의 highlight(backcolor)가 사라지는 현상 수정필요
    + 리스트뷰 HeaderColumn backcolor 변경필요 - DrawColumnHeader
    
panelProduct : 488, 56 529, 547

*/

// ▲ △ ◀ ◁ ▶ ▷ ▼ ▽  <＋－＜＞↵ ↵ ⏎  ＋ ＜＞ △	▲	▽	▼ ⪤ □ × × ◻ ■ ▽ ◇ △ ▯ ▭ ▬ ▮ ◆ ◇ □ ◪  ₩ ◆ ⁜ ⁘ ⌂ □ ■ ◆ ◇
// (*‿*✿) \\\٩(✪ꀾ⍟༶)و/// ♡◟(●•ᴗ•●)◞♡ ◄:•D .ᐟ ヾ(・ᆺ・✿)ﾉﾞ φ(◎◎ヘ)  ☑☆★☘︎ ☁︎ ⚑ 🟨 
// ð ✕ ◈ ◆ ⬅ 〈 ˂
// Music Title In Here
// 0:00 ━━●─── 4:00
// ⇆      ◁ ❚❚ ▷     ↻


namespace thepos
{
    public partial class frmSale : Form
    {
        public static Font font8;
        public static Font font9;
        public static Font font10;
        public static Font font12;
        public static Font font14;
        public static Font font16;
        public static Font font20;

        public static PrivateFontCollection fontCollection = new PrivateFontCollection();



        // //////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // 로그인후 다운로드되어야할 환경값들
        //
        public static String mCustomerId = "";
        public static String mPosNo = "";
        public static String mBussinessDate = "";

        // mTheNo : 선생성 - 후반영
        public static String mTheNo = "";


        // (후불) 발권  사용  정산 [락커]
        // (선불) 발권 [충전] 사용  정산

        // 발권형태 : 선불형 AP-advanced payment  후불형 DP-deferred payment
        public static String mTicketType;  // "AP" "DP"









        // ////////////////////////////////////////////////////////////////////////////////////////////////////




        public static int mSerialTheNo = 0;
        int mWaitingNoCounter = 0;
        public static int mSelectedWaitingNo = 0;

        String last_groupcode = "";  // 상품그룹을 클릭했을 경우 눌려진버튼을 또 눌렀는지 비교하기 위함.


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





        //
        // 서버관리
        struct GoodsGroup
        {
            public string code;  // 3
            public string name;
            public int column;
            public int row;
            public int columnspan;
            public int rowspan;
        }
        GoodsGroup[] mGoodsGroup;

        struct GoodsItem
        {
            public string code;  // 6
            public string name;
            public int amt;
            public String ticket; // 일반상품 0 티켓상품 1
            public String taxfree; // 면세품:"1", 과세:"" 등
            public int column;
            public int row;
            public int columnspan;
            public int rowspan;
        }
        GoodsItem[] mGoodsItem;



        public struct Order
        {
            public int order_no;        // 대기번호 [대기]을 위해
            public DateTime dt;         // 대기일시
            public int cnt;             // 항목수
            public int amount;          // 합계
        }
        public static List<Order> listWaiting = new List<Order>();
        
        public struct OrderItem
        {
            public int order_no;       // 대기번호 [대기]을 위해
            public String code;         // 상품code(6) or 전체할인코드고정("EDC")
            public String name;         // 상품name or 전체할인명("할인")
            public int cnt;
            public int amt;
            public String ticket;
            public String taxfree;
            public int dc_amount;       // 실할인금액
            public String dcr_type;     // type - "A" : 정액, "R" : 정율 
            public String dcr_des;      // 전체"E", 선택"S"
            public int dcr_value;       // 할인금액 or 할인율
        }
        public static List<OrderItem> listWaitingItem = new List<OrderItem>();


        //? 서버API로 대체한다.
        public struct dbOrder
        {
            public String the_no;          // 
            public DateTime dt;         // 대기일시
            public String customer_id;
            public String pos_no;
            public int cnt;             // 항목수
        }
        public static List<dbOrder> listOrder = new List<dbOrder>();

        public struct dbOrderItem
        {
            public String the_no;       // 
            public String code;         // 상품code(6) or 전체할인코드고정("EDC")
            public String name;         // 상품name or 전체할인명("할인")
            public int cnt;
            public int amt;
            public String ticket;
            public String taxfree;
            public int dc_amount;       // 실할인금액
            public String dcr_type;     // type - "A" : 정액, "R" : 정율 
            public String dcr_des;      // 전체"E", 선택"S"
            public int dcr_value;       // 할인금액 or 할인율
        }
        public static List<dbOrderItem> listOrderItem = new List<dbOrderItem>();









        public struct Cert
        {
            public String the_no;       // 
        }


        public struct Ticket
        {
            public String the_no;           // 

            public String ticket_no;

            public DateTime ticketing_dt;   // 발권일시
            public DateTime charge_dt;      // 충전일시
            public DateTime settlement_dt;  // 정산일시

            public int charge_point;        // 충전금액
            public int usage_point;         // 사용금액(누적)

            public String ticket_step;      // 진행상황 : 접수0 - 발급1 - *충전2 - 사용3 - 정산(완료)4 : 정산완료일 경우 라커를 오픈한다.
            public String open_locker;      // 락커 수기 개방 설정 0:폐쇄(기본값), 1:개방
        }




        public struct Payment
        {
            public String the_no;
            public String business_dt;  // yyyyMMdd
            public DateTime dt;
            public String tran_type;    // 승인 A, 취소 C
            public String pay_class;    // Order 0, charge 1, settlement 2
            public string pos_no;
            public String serial_no;    // 4자리 
            public int net_amount;
            public int amount_cash;
            public int amount_card;
            public int amount_point;
            public String is_dc;       // 할인여부
            public String is_cancel;   // 취소여부
        }
        public static List<Payment> mPayments = new List<Payment>();

        public struct PaymentCard
        {
            public String the_no;       // 
            public String business_dt;
            public DateTime dt;
            public String pay_type;     // 결제구분 : 신용카드(C1), 임의등록(C9)
            public String tran_type;    // 승인 A 취소 C
            public String tran_date;
            public int amount;          // 결제금액
            public String install;      // 할부개월 00 03
            public String auth_no;      // 승인번호
            public String card_no;      // 카드번호
            public String card_name;    // 카드종류
            public String isu_code;     // 발급사코드
            public String acq_code;     // 매입사코드
            public String merchant_no;  // 가맹점번호
            public String tid;          // tran_serial -> 취소시 tid입력
            public String is_cancel;    // 취소여부
        }
        public static List<PaymentCard> mPaymentCards = new List<PaymentCard>();

        public struct PaymentCash
        {
            public String the_no;       // 
            public String business_dt;
            public DateTime dt;
            public String pay_type;     // 결제구분 : 단순현금(R0), 현금영수중(R1), 임의등록(R9)
            public String tran_type;    // 승인 A 취소 C
            public String tran_date;
            public int amount;          // 결제금액
            public String receipt_type; // 현금영수증 : 개인 소득공제 1 사업자 지출증빙 2
            public String cashcard_no;  // 현금영수증 고객 식별번호
            public String auth_no;      // 승인번호
            public String tid;          // tran_serial -> 취소시 tid입력
            public String is_cancel;    // 취소여부
        }
        public static List<PaymentCash> mPaymentCashs = new List<PaymentCash>();

        public struct PaymentPoint           // 선불 후불 사용
        {
            public String the_no;       // 
            public DateTime dt;
            public String pay_type;     // 결제구분 : 포인트(P0)
            public String tran_type;    // 승인 A 취소 C
            public String tran_date;
            public int amount;          // 금액
            public String ticket_no;
            public String is_cancel;    // 취소여부
        }


        //
        // 로컬포스내 관리
        //
        struct PayConsol
        {
            public string code; // CASH, CARD, COMPLEX, CERT, EASY
                                // 현금  카드   복합결제  인증   간편결제
            public int column;
            public int row;
            public int columnspan;
            public int rowspan;
        }
        PayConsol[] mPayConsol;







        void get_goodsgroup()
        {

            String[,] group = new String[,]
            {
                {"101","커피", "0","0", "3","2"},
                {"100","티켓", "3","0", "2","2"},
                {"102","식사", "4","0", "2","1"},
                {"103","후식", "4","1", "1","1"},
                {"106","VIP", "7","0", "1","1"},
                {"109","기본", "6","1", "2","1"},
            };


            int len = group.Length / 6;


            mGoodsGroup = new GoodsGroup[len];

            for (int i = 0; i < len; i++)
            {
                mGoodsGroup[i].code = group[i, 0];
                mGoodsGroup[i].name = group[i, 1];

                mGoodsGroup[i].column = int.Parse(group[i, 2]);
                mGoodsGroup[i].row = int.Parse(group[i, 3]);
                mGoodsGroup[i].columnspan = int.Parse(group[i, 4]);
                mGoodsGroup[i].rowspan = int.Parse(group[i, 5]);
            }

        }

        void get_goodsitem()
        {
            String[,] item = new String[,]
            {
                { "101101","바닐라라떼","1", "0", "", "0","0", "2","2"},
                { "101102","카푸치노","6000", "0", "", "2","0", "1","2"},
                { "101103","에스프레소","7000", "0", "", "3","0", "3","2"},
                { "101104","아이스라떼","6500", "0", "", "6","1", "2","1"},
                { "101105","아메리카노","5000", "0", "", "0","2", "4","3"},
                { "101106","맥심커피","8000", "0", "", "4","2", "4","4"},
                { "101108","농산물1","7000", "0", "1", "0","5", "3","3"},
                { "101107","채소1","6000", "0", "1", "3","5", "1","3"},  // 면세
                { "101109","야채2", "5000", "0", "1", "4","6", "2","1"}, // 면세
                { "101110","모카","5000", "0", "", "4","7", "3","1"},

                { "100001","종일성인","10000", "1", "", "0","1", "4","5"},  // 발권대상
                { "100002","종일어린이","8000", "1", "", "4","1", "4","5"}, // 발권대상
            };


            int len = item.Length / 9;

            mGoodsItem = new GoodsItem[len];

            for (int i = 0; i < len; i++)
            {
                mGoodsItem[i].code = item[i, 0];
                mGoodsItem[i].name = item[i, 1];
                mGoodsItem[i].amt = int.Parse(item[i, 2]);
                mGoodsItem[i].ticket = item[i, 3];
                mGoodsItem[i].taxfree = item[i, 4];
                mGoodsItem[i].column = int.Parse(item[i, 5]);
                mGoodsItem[i].row = int.Parse(item[i, 6]);
                mGoodsItem[i].columnspan = int.Parse(item[i, 7]);
                mGoodsItem[i].rowspan = int.Parse(item[i, 8]);

                // 면세상픔은 상품명앞에 *을 붙인다.
                if (mGoodsItem[i].taxfree == "1")
                {
                    mGoodsItem[i].name = "*" + mGoodsItem[i].name;
                }


            }
        }

        void get_payConsol()
        {
            String[,] item = new String[,]
            {
                { "CASH", "0", "0", "3","4"},
                { "CARD", "3", "0", "3","4"},
                { "COMPLEX", "6", "0", "2","2"},
                { "EASY", "6", "2", "2","2"},
                { "MANAGER", "8", "0", "2","4"},
            };

            int len = item.Length / 5;
            mPayConsol = new PayConsol[len];

            for (int i = 0; i < len; i++)
            {
                mPayConsol[i].code = item[i, 0];
                mPayConsol[i].column = int.Parse(item[i, 1]);
                mPayConsol[i].row = int.Parse(item[i, 2]);
                mPayConsol[i].columnspan = int.Parse(item[i, 3]);
                mPayConsol[i].rowspan = int.Parse(item[i, 4]);
            }
        }


        public frmSale()
        {
            InitializeComponent();

            //? PC가 아니면 마우스 포인터 표시안함.
            //Cursor.Hide();

            initialize_font();

            initialize_the();


            get_payConsol();
            display_payconsol();

            get_goodsgroup();
            get_goodsitem();
            display_goodsgroup();
            ClickedGoodsGroup(mGoodsGroup[0].code);   // 최초실행후 첮 구룹을 선택한 화면을 보여주자...
        }



        private void initialize_font()
        {
            fontCollection.AddFontFile("Font\\TossProductSansTTF-Regular.ttf");

            font8 = new Font(fontCollection.Families[0], 8f);
            font9 = new Font(fontCollection.Families[0], 9f);
            font10 = new Font(fontCollection.Families[0], 10f);
            font12 = new Font(fontCollection.Families[0], 12f);
            font14 = new Font(fontCollection.Families[0], 14f);
            font16 = new Font(fontCollection.Families[0], 16f);
            font20 = new Font(fontCollection.Families[0], 20f);


            lblTitle01.Font = font9;
            lblTitle02.Font = font9;
            lblTitle03.Font = font9;
            lblTitle04.Font = font9;
            
            lblPosName.Font = font9;
            lblPosNo.Font = font9;
            lblBusinessDate.Font = font9;
            lblWorker.Font = font9;


            lblDate.Font = font10;
            lblTime.Font = font12;

            btnClose.Font = font12;

            lvwOrderItem.Font = font10;
            lblDisplayAlarm.Font = font10;

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

            lblOrderAmount.Font = font14;
            lblOrderAmountDC.Font = font14;
            lblOrderAmountNet.Font = font14;
            lblOrderAmountReceive.Font = font14;
            lblOrderAmountRest.Font = font14;
            
            lblKeyDisplay.Font = font16;
            btnKey1.Font = font14;
            btnKey2.Font = font14;
            btnKey3.Font = font14;
            btnKey4.Font = font14;
            btnKey5.Font = font14;
            btnKey6.Font = font14;
            btnKey7.Font = font14;
            btnKey8.Font = font14;
            btnKey9.Font = font14;
            btnKey0.Font = font14;
            btnKey00.Font = font14;
            btnKeyBS.Font = font14;
            btnKeyClear.Font = font14;
            btnKeyEnter.Font = font14;

            btnOrderAmountDC.Font = font10;
            btnOrderWaiting.Font = font10;

            btnFlowTicketing.Font = font10;
            btnFlowCharging.Font = font10;
            btnFlowSettlement.Font = font10;
            btnFlowLocker.Font = font10;

        }
        private void initialize_the()
        {
            //Title에 일자 요일을 표시
            setDateTitle();


            // 최초로드?
            //
            // 영업일자
            //
            mBussinessDate = DateTime.Now.ToString("yyyyMMdd");
            mCustomerId = "CUST";
            mPosNo = "01";

            countup_the_no();



            lblBusinessDate.Text = mBussinessDate.Substring(0, 4) + "-" + mBussinessDate.Substring(4, 2) + "-" + mBussinessDate.Substring(6, 2);

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


            // 서브창이 열리면서 Sale창의 콘트롤 Enable/Disable 관리를 위해서...
            mPanelTitleConsole = panelTitleConsole;
            mPanelOrderConsole = panelOrderConsole;
            mPanelProductConsole = panelFlowConsole;

            mLblDisplayAlarm = lblDisplayAlarm;
            mTimerAlarm = timerAlarmDisplay;

            mLblKeyDisplay = lblKeyDisplay;
            mLvwOrderItem = lvwOrderItem;

            mLblOrderAmount = lblOrderAmount;
            mLblOrderAmountDC = lblOrderAmountDC;
            mLblOrderAmountNet = lblOrderAmountNet;

        }

        private void display_payconsol()
        {
            System.Windows.Forms.Button btnPayItem;

            tableLayoutPanelPayControl.Controls.Clear();

            this.tableLayoutPanelPayControl.VerticalScroll.Value = 0;
            tableLayoutPanelPayControl.PerformLayout();

            for (int i = 0; i < mPayConsol.Length; i++)
            {
                btnPayItem = new Button();
                btnPayItem.Tag = mPayConsol[i].code;
                btnPayItem.FlatStyle = FlatStyle.Flat;
                btnPayItem.TabStop = false;
                btnPayItem.Margin = new Padding(2, 2, 2, 2);
                btnPayItem.Padding = new Padding(0, 0, 0, 0);
                btnPayItem.Dock = DockStyle.Fill;
                btnPayItem.ForeColor = Color.White;
                btnPayItem.BackColor = Color.FromArgb(68, 87, 96);

                btnPayItem.Font = font12;

                if (mPayConsol[i].code == "CASH")
                {
                    btnPayItem.Text = "현금";
                    btnPayItem.Click += (sender, args) => ClickedPayCash();
                }
                else if (mPayConsol[i].code == "CARD")
                {
                    btnPayItem.Text = "카드";
                    btnPayItem.Click += (sender, args) => ClickedPayCard();
                }
                else if (mPayConsol[i].code == "COMPLEX")
                {
                    btnPayItem.Text = "복합\r결제";
                    btnPayItem.Click += (sender, args) => ClickedPayComplex();
                }
                else if (mPayConsol[i].code == "EASY")
                {
                    btnPayItem.Text = "간편\r결제";
                    btnPayItem.Click += (sender, args) => ClickedPayEasy();
                }
                else if (mPayConsol[i].code == "MANAGER")
                {
                    btnPayItem.BackColor = Color.FromArgb(52, 86, 156);
                    btnPayItem.Text = "결제내역\r관리";
                    btnPayItem.Click += (sender, args) => ClickedPayManager();
                }
                else btnPayItem.Text = "";

                tableLayoutPanelPayControl.Controls.Add(btnPayItem, mPayConsol[i].column, mPayConsol[i].row);
                tableLayoutPanelPayControl.SetColumnSpan(btnPayItem, mPayConsol[i].columnspan);
                tableLayoutPanelPayControl.SetRowSpan(btnPayItem, mPayConsol[i].rowspan);
            }
        }

        private void display_goodsgroup()
        {
            tableLayoutPanelGoodsGroup.Controls.Clear();
            tableLayoutPanelGoodsGroup.PerformLayout();

            for (int i = 0; i < mGoodsGroup.Length; i++)
            {
                Button btnGoodsGroup = new Button();
                String group_code = mGoodsGroup[i].code;
                btnGoodsGroup.Tag = mGoodsGroup[i].code;
                btnGoodsGroup.Text = mGoodsGroup[i].name;
                btnGoodsGroup.FlatStyle = FlatStyle.Flat;

                btnGoodsGroup.ForeColor = SystemColors.Highlight; 
                btnGoodsGroup.BackColor = Color.White;
                btnGoodsGroup.TabStop = false;
                btnGoodsGroup.Margin = new Padding(2, 2, 2, 2);
                btnGoodsGroup.Padding = new Padding(0, 0, 0, 0);
                btnGoodsGroup.Dock = DockStyle.Fill;

                if (mGoodsGroup[i].columnspan > 1 & mGoodsGroup[i].rowspan > 1)
                {
                    btnGoodsGroup.Font = font16;
                }
                else
                {
                    btnGoodsGroup.Font = font12;
                }

                btnGoodsGroup.Click += (sender, args) => ClickedGoodsGroup(group_code);

                tableLayoutPanelGoodsItem.Controls.Add(btnGoodsGroup, mGoodsGroup[i].column, mGoodsGroup[i].row);
                tableLayoutPanelGoodsItem.SetColumnSpan(btnGoodsGroup, mGoodsGroup[i].columnspan);
                tableLayoutPanelGoodsItem.SetRowSpan(btnGoodsGroup, mGoodsGroup[i].rowspan);

                tableLayoutPanelGoodsGroup.Controls.Add(btnGoodsGroup);
            }

        }

        private void ClickedGoodsGroup(String groupcode)
        {
            if (last_groupcode == groupcode)
            {
                return;
            }

            Button btnGoodsItem = new Button();
            
            tableLayoutPanelGoodsItem.Controls.Clear();
            tableLayoutPanelGoodsItem.PerformLayout();

            setGroupButtonColor(last_groupcode, false);
            setGroupButtonColor(groupcode, true);

            for (int i = 0; i < mGoodsItem.Length; i++)
            {
                if (groupcode == mGoodsItem[i].code.Substring(0,3))
                {
                    int idx = i;
                    btnGoodsItem = new Button();

                    btnGoodsItem.Tag = mGoodsItem[i].code;
                    btnGoodsItem.FlatStyle = FlatStyle.Flat;
                    btnGoodsItem.ForeColor = Color.White;
                    btnGoodsItem.BackColor = SystemColors.Highlight;
                    btnGoodsItem.TabStop = false;
                    btnGoodsItem.Margin = new Padding(2, 2, 2, 2);
                    btnGoodsItem.Padding = new Padding(0, 0, 0, 0);
                    btnGoodsItem.Text = mGoodsItem[i].name + "\n" + mGoodsItem[i].amt.ToString("N0");
                    btnGoodsItem.Dock = DockStyle.Fill;

                    if (mGoodsItem[i].columnspan == 1 | mGoodsItem[i].rowspan == 1)
                    {
                        btnGoodsItem.Font = font8;
                    }
                    else if (mGoodsItem[i].columnspan == 2 | mGoodsItem[i].rowspan == 2)
                    {
                        btnGoodsItem.Font = font14;
                    }
                    else
                    {
                        btnGoodsItem.Font = font20;
                    }
                    
                    btnGoodsItem.Click += (sender, args) => ClickedGoodsItem(idx);


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
                ListViewItem lvItem = new ListViewItem();

                orderItem.order_no = 0;
                orderItem.code = mGoodsItem[i].code.ToString();
                orderItem.name = mGoodsItem[i].name.ToString();
                orderItem.ticket = mGoodsItem[i].ticket;
                orderItem.taxfree = mGoodsItem[i].taxfree;
                orderItem.amt = mGoodsItem[i].amt;
                orderItem.cnt = 1;
                orderItem.dc_amount = 0;
                orderItem.dcr_type = "";
                orderItem.dcr_des = "";
                orderItem.dcr_value = 0;

                lvItem.Tag = orderItem;
                lvItem.Text = (lvwOrderItem.Items.Count + 1).ToString();
                lvItem.SubItems.Add(orderItem.name);                // 1: name 상품명
                lvItem.SubItems.Add(orderItem.amt.ToString("N0"));  // 2: amt 단가
                lvItem.SubItems.Add("1");                               // 3: cnt 수량
                lvItem.SubItems.Add("");                                // 4: dc_amount 할인
                lvItem.SubItems.Add(orderItem.amt.ToString("N0"));  // 5: net_amount 금액
                lvItem.SubItems.Add("");                                // 6: 비고

                lvwOrderItem.Items.Add(lvItem);
                lvwOrderItem.Items[lvwOrderItem.Items.Count - 1].EnsureVisible();
                lvwOrderItem.Items[lvwOrderItem.Items.Count - 1].Selected = true;

                // 전체할인이 있으면 주문항목 가장 아래로 이동???
                move_dcr_e_last();

            }
            else
            {
                set_item_change_ordercnt(lv_idx, "add", 1);
                lvwOrderItem.Items[lv_idx].Selected = true;
            }

            ReCalculateAmount();
        }


        private void ClickedPayCash()
        {
            ConsoleDisable();

            Form fPay;
            fPay = new frmPayCash();

            fPay.Left += this.Location.X;
            fPay.Top += this.Location.Y;

            fPay.Show();
        }

        private void ClickedPayCard()
        {
            ConsoleDisable();

            Form fPay;
            fPay = new frmPayCard();

            fPay.Left += this.Location.X;
            fPay.Top += this.Location.Y;

            fPay.Show();
        }

        private void ClickedPayComplex()
        {
            ConsoleDisable();

            Form fPay;
            fPay = new frmPayComplex();

            fPay.Left += this.Location.X;
            fPay.Top += this.Location.Y;

            fPay.Show();
        }

        private void ClickedPayEasy()
        {

        }

        private void ClickedPayManager()
        {
            ConsoleDisable();

            Form fPay;
            fPay = new frmPayManager();

            fPay.Left += this.Location.X;
            fPay.Top += this.Location.Y;

            fPay.Show();
        }


        
        public static int SaveOrder()
        {
            //? 서버API로 대체한다..

            for (int i = 0; i < mLvwOrderItem.Items.Count; i++)
            {
                dbOrderItem dborderItem = new dbOrderItem();
                OrderItem orderItem = (OrderItem)mLvwOrderItem.Items[i].Tag;
                dborderItem.the_no = mTheNo;
                dborderItem.code = orderItem.code;
                dborderItem.name = orderItem.name;
                dborderItem.cnt = orderItem.cnt;
                dborderItem.amt = orderItem.amt;
                dborderItem.ticket = orderItem.ticket;
                dborderItem.taxfree = orderItem.taxfree;
                dborderItem.dc_amount = orderItem.dc_amount;
                dborderItem.dcr_type = orderItem.dcr_type;
                dborderItem.dcr_des = orderItem.dcr_des;
                dborderItem.dcr_value = orderItem.dcr_value;
                listOrderItem.Add(dborderItem);
            }

            dbOrder dborder = new dbOrder();
            dborder.the_no = mTheNo;
            dborder.dt = DateTime.Now;
            dborder.customer_id = mCustomerId;
            dborder.pos_no = mPosNo;
            dborder.cnt = mLvwOrderItem.Items.Count;
            listOrder.Add(dborder);

            return mLvwOrderItem.Items.Count;

        }



        public static void mClearSaleForm()
        {
            mLvwOrderItem.Items.Clear();
            ReCalculateAmount();
            ConsoleEnable();
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
                        SetDisplayAlarm("W", "단가 입력값 확인요망.");
                        return;
                    }
                }
                else
                {
                    SetDisplayAlarm("E", "단가 입력값 오류.");
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

                frmOrderDCR fAmountDC = new frmOrderDCR();

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
                Order waiting = new Order();

                waiting.order_no = ++mWaitingNoCounter;

                waiting.cnt = 0;
                waiting.dt = DateTime.Now;
                waiting.amount = 0;

                for (int i = 0; i < lvwOrderItem.Items.Count; i++)
                {
                    OrderItem orderItem = (OrderItem)lvwOrderItem.Items[i].Tag;
                    orderItem.order_no = mWaitingNoCounter;

                    waiting.cnt++;
                    waiting.amount += (orderItem.cnt * orderItem.amt);

                    listWaitingItem.Add(orderItem);
                }

                listWaiting.Add(waiting);

                lvwOrderItem.Items.Clear();
                btnOrderWaiting.Text = "대기\n" + listWaiting.Count + "";

                lvwOrderItem.Items.Clear();
                ReCalculateAmount();


            }
            else
            {
                if (listWaiting.Count > 0)
                {
                    ConsoleDisable();

                    frmOrderWaiting fWaiting = new frmOrderWaiting();
                    fWaiting.Left += this.Location.X;
                    fWaiting.Top += this.Location.Y;

                    var result = fWaiting.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        int lv_no = 0;
                        for (int i = 0; i < listWaitingItem.Count; i++)
                        {
                            if (listWaitingItem[i].order_no == mSelectedWaitingNo)
                            {
                                lv_no++;

                                ListViewItem lvItem = new ListViewItem();

                                lvItem.Tag = listWaitingItem[i];

                                OrderItem orderItem = new OrderItem();
                                orderItem = listWaitingItem[i];

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
                            if (listWaitingItem[i].order_no == mSelectedWaitingNo)
                            {
                                listWaitingItem.RemoveAt(i);
                            }
                        }

                        for (int i = 0; i < listWaiting.Count; i++)
                        {
                            if (listWaiting[i].order_no == mSelectedWaitingNo)
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
            panelFlowConsole.Enabled = false;
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
                memo += "₩" + orderItem.dcr_value;
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


            if (orderItem.dcr_des == "E")
            {
                SetDisplayAlarm("W", "전체할인 수량변경 불가.");
                return;
            }


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


            orderItem.dc_amount = get_dc_amount(orderItem);


            int net_amount = (orderItem.cnt * orderItem.amt) - orderItem.dc_amount;
            lvwOrderItem.Items[lv_idx].SubItems[4].Text = orderItem.dc_amount.ToString("###,###,###");
            lvwOrderItem.Items[lv_idx].SubItems[5].Text = net_amount.ToString("N0");        // net_amount

            lvwOrderItem.Items[lv_idx].Tag = orderItem;
        }


        public static int get_dc_amount(OrderItem orderItem)
        {
            int amount = orderItem.amt * orderItem.cnt;
            int tdcamount = 0;

            if (orderItem.dcr_type == "A")
            {
                tdcamount = orderItem.dcr_value;
            }
            else if (orderItem.dcr_type == "R")
            {
                tdcamount = (amount * orderItem.dcr_value) / 100;
            }
            else return 0;



            if (tdcamount > amount)
            {
                return amount;
            }
            else
            {
                return tdcamount;
            }

        }

        void move_dcr_e_last()
        {



        }

        public static bool isExist_DCR(String des)  // des = E or S
        {
            for (int i = mLvwOrderItem.Items.Count - 1; i >= 0; i--)
            {
                if (((OrderItem)mLvwOrderItem.Items[i].Tag).dcr_des == des)
                {
                    return true;
                }
            }

            return false;
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


            Button btn = (Button)tableLayoutPanelGoodsGroup.Controls[button_idx];

            
            if (!isPressed)
            {
                btn.ForeColor = SystemColors.Highlight;
                btn.BackColor = Color.White;
                btn.FlatAppearance.BorderSize = 2;
            }
            else
            {
                btn.ForeColor = Color.White;
                btn.BackColor = SystemColors.Highlight;
                btn.FlatAppearance.BorderSize = 0;
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

        public static void countup_the_no()
        {
            //? 재기동시 초기화된 이후의 연속성을 고민한다.. 
            Random rand = new Random();
            mTheNo = mCustomerId + mBussinessDate + mPosNo + (++mSerialTheNo).ToString("0000") + rand.Next(100, 999);
        }




    }
}
