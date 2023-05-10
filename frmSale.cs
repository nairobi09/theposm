using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Windows.Forms.VisualStyles;
using System.Collections.Generic;



/* 과제
    + 마우스 포인터 표시 : pc pos 구분필요 
    + 리스트뷰 아이템외 클릭시 selected item의 highlight(backcolor)가 사라지는 현상 수정필요
    + 리스트뷰 HeaderColumn backcolor 변경필요 - DrawColumnHeader
    
panelProduct : 488, 56 529, 547

*/

// ▲△◀◁▶▷▼▽  <＋－＜＞↵ ↵ ⏎  ＋ ＜＜＞ △	▲	▽	▼ ⪤ □ ◻ ■ ▽ ◇ △ ▯ ▭ ▬ ▮ ◆ ◇ □ ◪

namespace thepos
{
    public partial class frmSale : Form
    {
        thepos the = new thepos();

        String last_groupcode = "";  // 상품그룹을 클릭했을 경우 눌려진버튼을 또 눌렀는지 비교하기 위함.

        Color groupColor = SystemColors.Highlight;
        Color itemColor = SystemColors.Highlight;
        Color pickColor;


        public static String runningOrderNo = "";

        int waiting_count = 0;


        Button[] btnGoodsGroup;


       public struct OrderItem
        {
            public String code;     // 상품code(6) or 전체할인코드고정("DC")
            public String name;     // 상품name or 전체할인명("할인")
            public int cnt;
            public int amt;
            public int amount;      // 실결제금액*
            public int dc_amount;   // 실할인금액
            public String dc_type;  // type - "A" : 정액, "B" : 정율 
            public String dc_rate;     // 정액: "" or 정율값("20") - 20%경우
            public String memo;
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
                {"108","단체","G01"},
                {"109","기본","G01"},
                {"110","기부","G01"},
                {"111","서비스","G01"},
                {"112","학습","G01"},
                {"113","온라인","G01"},
                {"114","이벤트","G01"},
                {"115","","G01"},
                {"116","단체","G01"},
                {"117","임시권","G01"},
                {"118","주차","G01"},
                {"119","단체","G01"},
                {"120","일반","G01"},
                {"121","단체","G01"},
                {"122","아동","G01"},
                {"123","청소년","G01"},
                {"124","출근","G01"},
                {"125","연예인","G01"},
                {"126","정기권","G01"}
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
                /*     
                { "101101","바닐라라떼","8000", "0","0", "2","2"},
                { "101102","카푸치노","6000", "2","0", "2","2"},
                { "101103","에스프레소","7000", "4","0", "2","2"},
                { "101104","아이스라떼","6500", "6","0", "2","2"},
                { "101105","아메리카노","5000", "0","2", "2","2"},
                { "101106","맥심커피","8000", "2","2", "2","2"},
                { "101108","카페라떼","7000", "4","2", "2","2"},
                { "101107","캬라멜","6000", "6","2", "2","2"},
                { "101109","모카","5000", "0","4", "2","2"},
                { "101110","아리스카페모카","5000", "2","4", "2","2"},

                { "100001","종일자유","10000", "0","0", "2","2"},
                { "100002","종일어린이","8000", "2","0", "2","2"},

                */           
                { "101101","바닐라라떼","8000", "0","0", "2","2"},
                { "101102","카푸치노","6000", "2","0", "1","2"},
                { "101103","에스프레소","7000", "3","0", "3","2"},
                { "101104","아이스라떼","6500", "6","1", "2","1"},
                { "101105","아메리카노","5000", "0","2", "4","3"},
                { "101106","맥심커피","8000", "4","2", "4","4"},
                { "101108","카페라떼","7000", "0","5", "3","3"},
                { "101107","캬라멜","6000", "3","5", "1","3"},
                { "101109","모카","5000", "4","6", "1","1"},
                { "101110","아리스카페모카","5000", "4","7", "3","1"},

                { "100001","종일성인","10000", "0","1", "4","5"},
                { "100002","종일어린이","8000", "4","1", "4","5"},
            };


            int len = item.Length / 7;

            mGoodsItem = new GoodsItem[len];

            for (int i = 0; i < len; i++)
            {
                mGoodsItem[i].code = item[i, 0];
                mGoodsItem[i].name = item[i, 1];
                mGoodsItem[i].amt = Int32.Parse(item[i, 2]);

                mGoodsItem[i].column = Int32.Parse(item[i, 3]);
                mGoodsItem[i].row = Int32.Parse(item[i, 4]);
                mGoodsItem[i].columnspan = Int32.Parse(item[i, 5]);
                mGoodsItem[i].rowspan = Int32.Parse(item[i, 6]);
            }
        }


        public frmSale()
        {
            InitializeComponent();

            //? PC가 아니면 마우스 포인터 표시안함.
            //Cursor.Hide();

            initialize_the();

            get_goodsgroup();
            get_goodsitem();

            display_goodsgroup();
            ClickedGoodsGroup(mGoodsGroup[0].code);   // 최초실행후 첮 구룹을 선택한 화면을 보여주자...


        }



        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 32);

            lvwOrderItem.SmallImageList = imgList;
            lvwOrderItem.HideSelection = true;


            lblTitle01.Font = the.fontMedium_8;
            lblTitle02.Font = the.fontMedium_8;
            lblTitle03.Font = the.fontMedium_8;
            lblTitle04.Font = the.fontMedium_8;

            lblDate.Font = the.fontMedium_10;
            lblTime.Font = the.fontMedium_15;

            lvwOrderItem.Font = the.fontMedium_12;

            btnOrderCancelAll.Font = the.fontMedium_10;
            btnOrderCancelSelect.Font = the.fontMedium_10;
            btnOrderCntDn.Font = the.fontMedium_15;
            btnOrderCntUp.Font = the.fontMedium_15;
            btnOrderCntChange.Font = the.fontMedium_10;
            btnOrderItemScrollUp.Font = the.fontMedium_10;
            btnOrderItemScrollDn.Font = the.fontMedium_10;

            btnOrderAmountDC.Font = the.fontMedium_10;
            btnOrderWaiting.Font = the.fontMedium_10;

            lblOrderAmountSumTitle.Font = the.fontMedium_10;
            lblOrderAmountDCTitle.Font = the.fontMedium_10;
            lblOrderAmountChargeTitle.Font = the.fontMedium_10;
            lblOrderAmountReceiveTitle.Font = the.fontMedium_10;
            lblOrderAmountRestTitle.Font = the.fontMedium_10;

            lblOrderGoodsAmount.Font = the.fontBold_14;
            lblOrderAmountDC.Font = the.fontBold_14;
            lblOrderAmountCharge.Font = the.fontBold_14;
            lblOrderAmountReceive.Font = the.fontBold_14;
            lblOrderAmountRest.Font = the.fontBold_14;


            lblKeyDisplay.Font = the.fontBold_14;
            btnKey1.Font = the.fontBold_12;
            btnKey2.Font = the.fontBold_12;
            btnKey3.Font = the.fontBold_12;
            btnKey4.Font = the.fontBold_12;
            btnKey5.Font = the.fontBold_12;
            btnKey6.Font = the.fontBold_12;
            btnKey7.Font = the.fontBold_12;
            btnKey8.Font = the.fontBold_12;
            btnKey9.Font = the.fontBold_12;
            btnKey0.Font = the.fontBold_12;
            btnKey00.Font = the.fontBold_12;
            btnKeyBS.Font = the.fontBold_12;
            btnKeyClear.Font = the.fontBold_12;


            btnPayCash.Font = the.fontMedium_10;
            btnPayCredit.Font = the.fontMedium_10;
            btnPayComplex.Font = the.fontMedium_10;
            btnPayEasy.Font = the.fontMedium_10;
            btnPayManager.Font = the.fontMedium_10;


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
                btnGoodsGroup[i].Font = the.fontBold_12;

                btnGoodsGroup[i].FlatStyle = FlatStyle.Flat;
                btnGoodsGroup[i].ForeColor = groupColor;
                btnGoodsGroup[i].BackColor = Color.White;
                btnGoodsGroup[i].FlatAppearance.BorderSize = 2;

                btnGoodsGroup[i].Margin = new Padding(2, 2, 2, 2);

                btnGoodsGroup[i].Click += (sender, args) => ClickedGoodsGroup(groupcode);
                flowLayoutPanelGoodsGroup.Controls.Add(btnGoodsGroup[i]);
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

                    btnGoodsItem.Height = 76;
                    btnGoodsItem.Width = 60;

                    btnGoodsItem.FlatStyle = FlatStyle.Flat;
                    btnGoodsItem.ForeColor = Color.White;
                    btnGoodsItem.BackColor = itemColor;
                    btnGoodsItem.TabStop = false;
                    btnGoodsItem.Margin = new Padding(2, 2, 2, 2);
                    btnGoodsItem.Text = mGoodsItem[i].name + "\n" + mGoodsItem[i].amt.ToString("N0");

                    if (mGoodsItem[i].columnspan == 1 | mGoodsItem[i].rowspan == 1)
                    {
                        btnGoodsItem.Font = the.fontMedium_8;
                    }
                    else if (mGoodsItem[i].columnspan == 2 | mGoodsItem[i].rowspan == 2)
                    {
                        btnGoodsItem.Font = the.fontMedium_12;
                    }
                    else
                    {
                        btnGoodsItem.Font = the.fontMedium_18;
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
                orderItem.amount = mGoodsItem[i].amt;
                orderItem.dc_type = "";
                orderItem.dc_rate = "";
                orderItem.memo = "";

                item.Tag = orderItem;

                item.Text = (lvwOrderItem.Items.Count + 1).ToString();
                item.SubItems.Add(mGoodsItem[i].name);                // 1: name 상품명
                item.SubItems.Add(mGoodsItem[i].amt.ToString("N0"));  // 2: amt 단가
                item.SubItems.Add("1");                               // 3: cnt 수량
                item.SubItems.Add("");                                // 4: dc_amount 할인
                item.SubItems.Add(mGoodsItem[i].amt.ToString("N0"));  // 5: amount 금액
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

        private void btnOrderCntDn_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.SelectedItems.Count > 0)
            {
                int lv_idx = lvwOrderItem.SelectedItems[0].Index;
                set_item_change_ordercnt(lv_idx, "add", -1);
                ReCalculateAmount();
            }
        }

        private void btnOrderCntUp_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.SelectedItems.Count > 0)
            {
                int lv_idx = lvwOrderItem.SelectedItems[0].Index;
                set_item_change_ordercnt(lv_idx, "add", 1);
                ReCalculateAmount();
            }
        }

        private void btnOrderCntChange_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.SelectedItems.Count > 0)
            {
                if (lblKeyDisplay.Text.Length > 3) return;

                int cnt = 0;
                bool result = int.TryParse(lblKeyDisplay.Text, out cnt);

                if (result)
                {
                    if (cnt > 0 & cnt < 1000)
                    {
                        set_item_change_ordercnt(lvwOrderItem.SelectedItems[0].Index, "set", cnt);
                        lblKeyDisplay.Text = "";
                        ReCalculateAmount();
                    }
                }
            }
        }



        private void btnOrderAmountDC_Click(object sender, EventArgs e)
        {


        }





        // ///////////////////////////////////////////////////////////////////////////////////////////////////////
        // 대기 기능
        private void btnOrderWaiting_Click(object sender, EventArgs e)
        {
            // 웨이팅 저장, 불러오기 겸용버튼
            if (lvwOrderItem.Items.Count > 0)
            {
                Waiting waiting = new Waiting();

                if (runningOrderNo == "")
                {
                    runningOrderNo = create_order_no();
                }

                waiting.order_no = runningOrderNo;
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

                runningOrderNo = "";

            }
            else
            {
                if (listWaiting.Count > 0)
                {
                    frmWaiting fWaiting = new frmWaiting();

                    fWaiting.Left += this.Location.X;
                    fWaiting.Top += this.Location.Y;

                    var result = fWaiting.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        for (int i = 0; i < listWaitingItem.Count; i++)
                        {
                            if (listWaitingItem[i].order_no == runningOrderNo)
                            {
                                ListViewItem item = new ListViewItem();

                                item.Tag = listWaitingItem[i].order_item;

                                OrderItem orderItem = new OrderItem();
                                orderItem = listWaitingItem[i].order_item;

                                item.Text = (i + 1).ToString();
                                item.SubItems.Add(orderItem.name);                      // 1: name 상품명
                                item.SubItems.Add(orderItem.amt.ToString("N0"));        // 2: amt 단가
                                item.SubItems.Add(orderItem.cnt.ToString());            // 3: cnt 수량
                                item.SubItems.Add(orderItem.dc_amount.ToString("#,###"));  // 4: dc_amount 할인
                                item.SubItems.Add(orderItem.amt.ToString("N0"));        // 5: amount 금액
                                item.SubItems.Add(orderItem.memo);                      // 6: 메모

                                lvwOrderItem.Items.Add(item);
                                lvwOrderItem.Items[lvwOrderItem.Items.Count - 1].EnsureVisible();
                            }
                        }
                        lvwOrderItem.Items[lvwOrderItem.Items.Count - 1].Selected = true;




                        for (int i = listWaitingItem.Count - 1; i >= 0; i--)
                        {
                            if (listWaitingItem[i].order_no == runningOrderNo)
                            {
                                listWaitingItem.RemoveAt(i);
                            }
                        }

                        for (int i = 0; i < listWaiting.Count; i++)
                        {
                            if (listWaiting[i].order_no == runningOrderNo)
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


                }
            }
        }


        // ///////////////////////////////////////////////////////////////////////////////////////////////////////









        // ///////////////////////////////////////////////////////////////////////////////////////////////////////
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

            orderItem.amount = (orderItem.cnt * orderItem.amt) - orderItem.dc_amount;

            lvwOrderItem.Items[lv_idx].SubItems[3].Text = orderItem.cnt.ToString("N0");           // cnt
            lvwOrderItem.Items[lv_idx].SubItems[5].Text = orderItem.amount.ToString("N0");        // amount

            lvwOrderItem.Items[lv_idx].Tag = orderItem;
        }

        private void ReCalculateAmount()
        {
            Int32 goodsAmount = 0;
            Int32 dcAmount = 0;
            Int32 Amount = 0;

            OrderItem orderItemInfo;

            for (int i = 0; i < lvwOrderItem.Items.Count; i++)
            {
                orderItemInfo = (OrderItem)lvwOrderItem.Items[i].Tag;
                goodsAmount += (orderItemInfo.cnt * orderItemInfo.amt);
                dcAmount += orderItemInfo.dc_amount;
                Amount += orderItemInfo.amount;
            }

            lblOrderGoodsAmount.Text = goodsAmount.ToString("N0");
            lblOrderAmountDC.Text = dcAmount.ToString("N0");
            lblOrderAmountCharge.Text = Amount.ToString("N0");

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
            else if (sKey == "0" | sKey == "00")
            {
                if (lblKeyDisplay.Text.Length > 0)
                {
                    lblKeyDisplay.Text += sKey;
                }
            }
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
                btnGoodsGroup[button_idx].ForeColor = groupColor;
                btnGoodsGroup[button_idx].BackColor = Color.White;
                btnGoodsGroup[button_idx].FlatAppearance.BorderSize = 2;
            }
            else
            {
                btnGoodsGroup[button_idx].ForeColor = Color.White;
                btnGoodsGroup[button_idx].BackColor = groupColor;
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
            if (timerSecondEvent.Tag.ToString() == "0")
            {
                lblTime.Text = DateTime.Now.ToString("HH:mm");
                timerSecondEvent.Tag = "1";

            }
            else
            {
                lblTime.Text = DateTime.Now.ToString("HH mm");
                timerSecondEvent.Tag = "0";
            }



            String strWeek = "";
            DateTime nowDt = DateTime.Now;

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


        private void btnGoodsItemMode_Click(object sender, EventArgs e)
        {
            // location 488, 55
            /*
            frmSetup frmSetup = new frmSetup();
            frmSetup.Owner = this;
            frmSetup.StartPosition = FormStartPosition.Manual;

            Point p = new Point(488, 55);

            Point p1 = this.Location;

            frmSetup.Location = Point.Add(p1, (Size)p);

            frmSetup.Show(this);
            */

            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = itemColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                pickColor = MyDialog.Color;

                if (pickColor != itemColor)
                {
                    ReflashColor();
                }

                
            }

        }

        private void ReflashColor()
        {
            itemColor = pickColor;
            groupColor = pickColor;


            ///
            int button_idx = -1;

            for (int i = 0; i < mGoodsGroup.Length; i++)
            {
                if (mGoodsGroup[i].code == last_groupcode)
                {
                    button_idx = i;
                }
            }

            for (int i = 0; i < flowLayoutPanelGoodsGroup.Controls.Count; i++)
            {
                if (button_idx == i)
                {
                    flowLayoutPanelGoodsGroup.Controls[i].BackColor = itemColor;
                }
                else
                {
                    flowLayoutPanelGoodsGroup.Controls[i].ForeColor = itemColor;
                }
            }

            ///
            for (int i = 0; i < tableLayoutPanelGoodsItem.Controls.Count; i++)
            {
                tableLayoutPanelGoodsItem.Controls[i].BackColor = itemColor;
            }

            ///
            if (lvwOrderItem.SelectedItems.Count > 0)
                lvwOrderItem.SelectedItems[0].BackColor = itemColor;



        }


        private void btnScrollItemUp_Click(object sender, EventArgs e)
        {
            if (this.tableLayoutPanelGoodsItem.VerticalScroll.Value > 0)
            {
                this.tableLayoutPanelGoodsItem.VerticalScroll.Value -= 49;
                tableLayoutPanelGoodsItem.PerformLayout();
            }
        }

        private void btnScrollItemDn_Click(object sender, EventArgs e)
        {
            this.tableLayoutPanelGoodsItem.VerticalScroll.Value += 49;
            tableLayoutPanelGoodsItem.PerformLayout();
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
                    item.BackColor = itemColor;
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



        public String create_order_no()
        {
            // 사업장코드(3) + POS코드(2) + TIMESTAMP(10) 
            return the.mCustomerCode + the.mPosNo + ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds().ToString();
        }


    }
}
