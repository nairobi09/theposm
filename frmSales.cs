using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Collections.Generic;
using static thepos.thePos;
using static thepos.frmPayComplex;
using System.Diagnostics;
using PrinterUtility;
using System.IO.Ports;
using System.Text;
using thepos._1Sales;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;



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
// ⇆      ◁ ❚▮▮||||||||❚ ▷     ↻       ▮


namespace thepos
{
    public partial class frmSales : Form
    {

        public static int mBillTheNo = 0;
        int mWaitingNoCounter = 0;
        public static int mSelectedWaitingNo = 0;

        String last_groupcode = "";  // 상품그룹을 클릭했을 경우 눌려진버튼을 또 눌렀는지 비교하기 위함.


        public static String mRightFace = "";

        public static String mPayClass = "OR"; // order


        public static TextBox mTbKeyDisplaySales;            // Sales화면의 key display
        public static TextBox mTbKeyDisplayController;  // 공용컨트롤러


        public static Panel mPanelTitleConsole;
        public static Panel mPanelOrderConsole;
        public static Panel mPanelProductConsole;
        public static Label mLblDisplayAlarm;
        //public static Label mLblKeyDisplay;
        public static ListView mLvwOrderItem;
        public static Label mLblOrderAmount;
        public static Label mLblOrderAmountDC;
        public static Label mLblOrderAmountNet;
        public static Label mLblOrderAmountReceive;
        public static Label mLblOrderAmountRest;


        public static int mNetAmount = 0;
        public static Timer mTimerAlarm;


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




        public frmSales()
        {
            InitializeComponent();

            //? PC가 아니면 마우스 포인터 표시안함.
            //Cursor.Hide();

            initialize_font();
            initialize_the();

            get_display_payConsol();
            get_goodsgroup();
            get_goodsitem();
            display_goodsgroup();
            ClickedGoodsGroup(mGoodsGroup[0].group_code);   // 최초실행후 첮 그룹을 선택한 화면을 보여주자...
                        
            get_last_theno();  // 서버에서 최종 theno를 구한다. -> mBillTheNo 세팅

            get_pos_setup();


            // Sub Screen 
            if (fSub != null)
            {
                mPanelOrderInfo.Visible = true;
            }


        }


        private void initialize_font()
        {

            lblSiteNameTitle.Font = font10;
            lblSiteName.Font = font10;

            lblPosNoTitle.Font = font10;
            lblPosNo.Font = font10;

            lblUserNameTitle.Font = font10;
            lblUserName.Font = font10;

            lblBusinessDateTitle.Font = font10;
            lblBizDate.Font = font12bold;

            lblDate.Font = font10;
            lblTime.Font = font12bold;

            btnClose.Font = font12;

            lvwOrderItem.Font = font10;
            lblDisplayAlarm.Font = font10;

            btnOrderCancelAll.Font = font10;
            btnOrderCancelSelect.Font = font10;
            btnOrderCntDn.Font = font14;
            btnOrderCntUp.Font = font16;
            btnOrderCntChange.Font = font10;
            btnOrderItemScrollUp.Font = font8;
            btnOrderItemScrollDn.Font = font8;

            lblOrderAmountSumTitle.Font = font9;
            lblOrderAmountDCTitle.Font = font9;
            lblOrderAmountChargeTitle.Font = font9;
            lblOrderAmountReceiveTitle.Font = font9;
            lblOrderAmountRestTitle.Font = font9;

            lblOrderAmount.Font = font14;
            lblOrderAmountDC.Font = font14;
            lblOrderAmountNet.Font = font14;
            lblOrderAmountReceive.Font = font14;
            lblOrderAmountRest.Font = font14;
            
            //lblKeyDisplay.Font = font13;
            tbKeyDisplay.Font = font14;

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
            setCurrentDateTitle();

            lblSiteName.Text = mSiteAlias;
            lblPosNo.Text = mPosNo;

            lblBizDate.Text = mBizDate.Substring(0, 4) + "-" + mBizDate.Substring(4, 2) + "-" + mBizDate.Substring(6, 2);
            lblUserName.Text = mUserName;


            
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 32);

            lvwOrderItem.SmallImageList = imgList;
            lvwOrderItem.HideSelection = true;


            //? 리스트뷰 항목이 추가 변경될때 합계를 다시 계산하기위해 
            //  리스트뷰 변경 이벤트 추가


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


            //? 최초세팅 - 이후 개별창이 뜰때마다 각각창의 KeyDisplay로 세팅을 변경할 수 있다. 
            // 서브창이 열리면서 Sale창의 콘트롤 Enable/Disable 관리를 위해서...
            mTbKeyDisplaySales = tbKeyDisplay;
            mTbKeyDisplayController = mTbKeyDisplaySales;


            mPanelTitleConsole = panelTitleConsole;
            mPanelOrderConsole = panelOrderConsole;
            mPanelProductConsole = panelFlowConsole;

            mLblDisplayAlarm = lblDisplayAlarm;
            mTimerAlarm = timerAlarmDisplay;

            //mLblKeyDisplay = lblKeyDisplay;
            mLvwOrderItem = lvwOrderItem;

            mLblOrderAmount = lblOrderAmount;
            mLblOrderAmountDC = lblOrderAmountDC;
            mLblOrderAmountNet = lblOrderAmountNet;
            mLblOrderAmountReceive = lblOrderAmountReceive;
            mLblOrderAmountRest = lblOrderAmountRest;

        }


        private void get_last_theno()
        {
            String sUrl = "orderLastNo?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&posNo=" + mPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orders"].ToString();
                    JArray arr = JArray.Parse(data);

                    String theno = arr[0]["theNo"].ToString();

                    mBillTheNo = int.Parse(theno.Substring(14, 4));

                    //? 이후 삭제요망
                    //MessageBox.Show("orderLastNo = " + theno, "//?");


                }
                else
                {
                    MessageBox.Show("영업개시마감 데이터 오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
            }
        }


        private void get_pos_setup()
        {




        }



        private void get_display_payConsol()
        {

            String sUrl = "paymentConsole?siteId=" + mSiteId + "&posNo=" + mPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["paymentConsoles"].ToString();
                    JArray arr = JArray.Parse(data);

                    mPayConsol = new PayConsol[arr.Count];

                    for (int i = 0; i < arr.Count; i++)
                    {
                        mPayConsol[i].column = int.Parse(arr[i]["locateX"].ToString());
                        mPayConsol[i].row = int.Parse(arr[i]["locateY"].ToString());
                        mPayConsol[i].columnspan = int.Parse(arr[i]["sizeX"].ToString());
                        mPayConsol[i].rowspan = int.Parse(arr[i]["sizeY"].ToString());
                        mPayConsol[i].code = arr[i]["buttonCode"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("상품정보 오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

            //
            Button btnPayItem;

            tableLayoutPanelPayControl.Controls.Clear();
            tableLayoutPanelPayControl.VerticalScroll.Value = 0;
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
                    btnPayItem.Text = "현금\r결제";
                    btnPayItem.Click += (sender, args) => ClickedPayCash();
                }
                else if (mPayConsol[i].code == "CARD")
                {
                    btnPayItem.Text = "카드\r결제";
                    btnPayItem.Click += (sender, args) => ClickedPayCard();
                }
                else if (mPayConsol[i].code == "POINT")
                {
                    btnPayItem.Text = "포인트\r결제";
                    btnPayItem.Click += (sender, args) => ClickedPayPoint();
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
                else btnPayItem.Text = "";

                tableLayoutPanelPayControl.Controls.Add(btnPayItem, mPayConsol[i].column, mPayConsol[i].row);
                tableLayoutPanelPayControl.SetColumnSpan(btnPayItem, mPayConsol[i].columnspan);
                tableLayoutPanelPayControl.SetRowSpan(btnPayItem, mPayConsol[i].rowspan);
            }



        }

        private void get_goodsgroup()
        {
            String sUrl = "goodsGroup?siteId=" + mSiteId + "&posNo=" + mPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String goods_group = mObj["goodsGroups"].ToString();
                    JArray arr = JArray.Parse(goods_group);

                    mGoodsGroup = new GoodsGroup[arr.Count];

                    for (int i = 0; i < arr.Count; i++)
                    {
                        mGoodsGroup[i].group_code = arr[i]["groupCode"].ToString();
                        mGoodsGroup[i].group_name = arr[i]["groupName"].ToString();
                        mGoodsGroup[i].column = int.Parse(arr[i]["locateX"].ToString());
                        mGoodsGroup[i].row = int.Parse(arr[i]["locateY"].ToString());
                        mGoodsGroup[i].columnspan = int.Parse(arr[i]["sizeX"].ToString());
                        mGoodsGroup[i].rowspan = int.Parse(arr[i]["sizeY"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("상품그룹정보 오류. goodsGroup\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }


        }

        private void get_goodsitem()
        {
            String sUrl = "goodsItemAndGoods?siteId=" + mSiteId + "&posNo=" + mPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String goods_item = mObj["goodsItems"].ToString();
                    JArray arr = JArray.Parse(goods_item);

                    mGoodsItem = new GoodsItem[arr.Count];

                    for (int i = 0; i < arr.Count; i++)
                    {
                        mGoodsItem[i].group_code = arr[i]["groupCode"].ToString();
                        mGoodsItem[i].item_code = arr[i]["itemCode"].ToString();
                        mGoodsItem[i].item_name = arr[i]["itemName"].ToString();
                        mGoodsItem[i].shop_code = arr[i]["shopCode"].ToString();
                        mGoodsItem[i].amt = int.Parse(arr[i]["amt"].ToString());
                        mGoodsItem[i].ticket = arr[i]["ticketYn"].ToString();
                        mGoodsItem[i].taxfree = arr[i]["taxFree"].ToString();
                        mGoodsItem[i].column = int.Parse(arr[i]["locateX"].ToString());
                        mGoodsItem[i].row = int.Parse(arr[i]["locateY"].ToString());
                        mGoodsItem[i].columnspan = int.Parse(arr[i]["sizeX"].ToString());
                        mGoodsItem[i].rowspan = int.Parse(arr[i]["sizeY"].ToString());

                        // 면세상픔은 상품명앞에 *을 붙인다.
                        if (mGoodsItem[i].taxfree == "1")
                        {
                            mGoodsItem[i].item_name = "*" + mGoodsItem[i].item_name;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("상품정보 오류. goodsItemAndGoods\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

        }

        private void display_goodsgroup()
        {
            tableLayoutPanelGoodsGroup.Controls.Clear();
            tableLayoutPanelGoodsGroup.PerformLayout();

            for (int i = 0; i < mGoodsGroup.Length; i++)
            {
                Button btnGoodsGroup = new Button();
                String group_code = mGoodsGroup[i].group_code;
                btnGoodsGroup.Tag = mGoodsGroup[i].group_code;
                btnGoodsGroup.Text = mGoodsGroup[i].group_name;
                btnGoodsGroup.FlatStyle = FlatStyle.Flat;

                btnGoodsGroup.ForeColor = SystemColors.Highlight; 
                btnGoodsGroup.BackColor = Color.White;
                btnGoodsGroup.TabStop = false;
                btnGoodsGroup.Margin = new Padding(2, 2, 2, 2);
                btnGoodsGroup.Padding = new Padding(0, 0, 0, 0);
                btnGoodsGroup.Dock = DockStyle.Fill;

                
                if (mGoodsGroup[i].columnspan == 1)
                {
                    btnGoodsGroup.Font = font9;
                }
                else if (mGoodsGroup[i].columnspan >= 3 & mGoodsGroup[i].rowspan >= 2)
                {
                    btnGoodsGroup.Font = font20;
                }
                else
                {
                    btnGoodsGroup.Font = font14;
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
                if (groupcode == mGoodsItem[i].group_code)
                {
                    int idx = i;
                    btnGoodsItem = new Button();

                    btnGoodsItem.Tag = mGoodsItem[i].item_code;
                    btnGoodsItem.FlatStyle = FlatStyle.Flat;
                    btnGoodsItem.ForeColor = Color.White;
                    btnGoodsItem.BackColor = SystemColors.Highlight;
                    btnGoodsItem.TabStop = false;
                    btnGoodsItem.Margin = new Padding(2, 2, 2, 2);
                    btnGoodsItem.Padding = new Padding(0, 0, 0, 0);
                    btnGoodsItem.Text = mGoodsItem[i].item_name + "\n" + mGoodsItem[i].amt.ToString("N0");
                    btnGoodsItem.Dock = DockStyle.Fill;

                    if (mGoodsItem[i].columnspan == 1 | mGoodsItem[i].rowspan == 1)
                    {
                        btnGoodsItem.Font = font9;
                    }
                    else if (mGoodsItem[i].rowspan == 2)
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
            MemOrderItem orderItem = new MemOrderItem();
            int lv_idx = (get_lvitem_idx(mGoodsItem[i].item_code));  // 이미  동일 상품이 주문리스트뷰에 있는지

            if (lv_idx == -1)
            {
                ListViewItem lvItem = new ListViewItem();

                orderItem.order_no = 0;
                orderItem.code = mGoodsItem[i].item_code.ToString();
                orderItem.name = mGoodsItem[i].item_name.ToString();
                orderItem.ticket = mGoodsItem[i].ticket;
                orderItem.taxfree = mGoodsItem[i].taxfree;
                orderItem.amt = mGoodsItem[i].amt;
                orderItem.cnt = 1;
                orderItem.dc_amount = 0;
                orderItem.dcr_type = "";
                orderItem.dcr_des = "";
                orderItem.dcr_value = 0;
                orderItem.shop_code = mGoodsItem[i].shop_code;

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
            if (mNetAmount == 0) return;

            //?
            countup_the_no();


            ConsoleDisable();

            Form fPay;
            fPay = new frmPayCash(mNetAmount, false, 1, true); // int amount, bool is_complex, int pay_seq, bool is_last

            fPay.Left += this.Location.X;
            fPay.Top += this.Location.Y;

            fPay.Show();
        }

        private void ClickedPayCard()
        {
            if (mNetAmount == 0) return;

            
            //
            countup_the_no();


            ConsoleDisable();

            Form fPay;
            fPay = new frmPayCard(mNetAmount, false, 1, true);

            fPay.Left += this.Location.X;
            fPay.Top += this.Location.Y;

            fPay.Show();
        }

        private void ClickedPayPoint()
        {
            if (mNetAmount == 0) return;

            //
            countup_the_no();


            ConsoleDisable();

            Form fPay;
            fPay = new frmPayPoint();

            fPay.Left += this.Location.X;
            fPay.Top += this.Location.Y;

            fPay.Show();
        }

        private void ClickedPayComplex()
        {
            if (mNetAmount == 0) return;


            //
            countup_the_no();


            ConsoleDisable();

            Form fPay;
            fPay = new frmPayComplex();

            fPay.Left += this.Location.X;
            fPay.Top += this.Location.Y;

            fPay.Show();
        }

        private void ClickedPayEasy()
        {
            if (mNetAmount == 0) return;



            //
            countup_the_no();


            ConsoleDisable();

            Form fPay;
            fPay = new frmPayEasy();

            fPay.Left += this.Location.X;
            fPay.Top += this.Location.Y;

            fPay.Show();
        }


        
        public static int SaveOrder(String ticket_no)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Clear();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = mPosNo;
            parameters["bizDt"] = mBizDate;
            parameters["theNo"] = mTheNo;
            parameters["refNo"] = mRefNo;
            parameters["orderDate"] = get_today_date();
            parameters["orderTime"] = get_today_time();
            parameters["cnt"] = mLvwOrderItem.Items.Count + "";
            parameters["isCancel"] = "";

            if (mRequestPost("orders", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {

                }
                else
                {
                    MessageBox.Show("오류 order\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return -1;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return -1;
            }




            for (int i = 0; i < mLvwOrderItem.Items.Count; i++)
            {
                MemOrderItem memOrderItem = (MemOrderItem)mLvwOrderItem.Items[i].Tag;
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["posNo"] = mPosNo;
                parameters["bizDt"] = mBizDate;
                parameters["theNo"] = mTheNo;
                parameters["refNo"] = mRefNo;
                parameters["orderDate"] = get_today_date();
                parameters["orderTime"] = get_today_time();
                parameters["itemCode"] = memOrderItem.code;
                parameters["itemName"] = memOrderItem.name;
                parameters["cnt"] = memOrderItem.cnt + "";
                parameters["amt"] = memOrderItem.amt + "";
                parameters["shopCode"] = memOrderItem.shop_code;
                parameters["ticketYn"] = memOrderItem.ticket;
                parameters["taxFree"] = memOrderItem.taxfree;
                parameters["dcAmount"] = memOrderItem.dc_amount + "";
                parameters["dcrType"] = memOrderItem.dcr_type;
                parameters["dcrDes"] = memOrderItem.dcr_des;
                parameters["dcrValue"] = memOrderItem.dcr_value + "";
                parameters["payClass"] = mPayClass;  //
                parameters["ticketNo"] = ticket_no;  //
                parameters["isCancel"] = "";

                if (mRequestPost("orderItem", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        
                    }
                    else
                    {
                        MessageBox.Show("오류 orderItem\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return -1;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return -1;
                }
            }

            return mLvwOrderItem.Items.Count;

        }

        public static bool SavePayment(int paySeq, String payType, int amount)
        {
            //!
            if (paySeq == 1)
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["posNo"] = mPosNo;
                parameters["bizDt"] = mBizDate;
                parameters["theNo"] = mTheNo;
                parameters["refNo"] = mRefNo;
                parameters["payDate"] = get_today_date();
                parameters["payTime"] = get_today_time();
                parameters["tranType"] = "A";
                parameters["payClass"] = mPayClass;
                parameters["billNo"] = mTheNo.Substring(14, 4);
                parameters["netAmount"] = amount + "";


                int amount_cash = 0, amount_card = 0, amount_easy = 0, amount_point = 0;

                if (payType == "Cash") amount_cash = amount;
                else if (payType == "Card") amount_card = amount;
                else if (payType == "Easy") amount_easy = amount;
                else if (payType == "Point") amount_point = amount;

                parameters["amountCash"] = amount_cash + "";
                parameters["amountCard"] = amount_card + "";
                parameters["amountEasy"] = amount_easy + "";
                parameters["amountPoint"] = amount_point + "";

                parameters["isDc"] = "";
                parameters["isCancel"] = "";


                if (mRequestPost("payment", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {

                    }
                    else
                    {
                        MessageBox.Show("오류 payment\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return false ;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류 payment\n\n" + mErrorMsg, "thepos");
                    return false;
                }
            }
            else
            {
                int amount_net = 0;
                int amount_cash = 0;
                int amount_card = 0;
                int amount_easy = 0;
                int amount_point = 0;


                // GET
                String sUrl = "payment?theNo=" + mTheNo;

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["payments"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count != 1)
                        {
                            MessageBox.Show("결제데이터 오류 \n Cnt=" + arr.Count, "thepos");
                            return false;
                        }

                        amount_net = convert_number(arr[0]["netAmount"].ToString());
                        amount_cash = convert_number(arr[0]["amountCash"].ToString());
                        amount_card = convert_number(arr[0]["amountCard"].ToString());
                        amount_easy = convert_number(arr[0]["amountEasy"].ToString());
                        amount_point = convert_number(arr[0]["amountPoint"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("결제데이터 오류. payment\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. ticketFlow\n\n" + mErrorMsg, "thepos");
                }



                amount_net += amount;

                if (payType == "Cash") amount_cash += amount;
                else if (payType == "Card") amount_card += amount;
                else if (payType == "Easy") amount_easy += amount;
                else if (payType == "Point") amount_point += amount;



                //
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["theNo"] = mTheNo;
                parameters["tranType"] = "A";

                parameters["netAmount"] = amount_net + "";
                parameters["amountCash"] = amount_cash + "";
                parameters["amountCard"] = amount_card + "";
                parameters["amountEasy"] = amount_easy + "";
                parameters["amountPoint"] = amount_point + "";

                if (mRequestPatch("payment", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {

                    }
                    else
                    {
                        MessageBox.Show("결제데이터 오류. payment\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
                    return false;
                }
            }

            return true;

        }


        public static int SaveTicket(String ticket_no, String subClass)  // subClass : 사용 US,  충전 CH
        {
            // Order 0, charge 1, settlement 2
            
            if (mPayClass == "OR") // 주문(접수-발권)
            {
                int ticket_seq = 0;
                String t_ticket_no = "";

                for (int i = 0; i < mLvwOrderItem.Items.Count; i++)
                {
                    MemOrderItem orderItem = (MemOrderItem)mLvwOrderItem.Items[i].Tag;

                    if (orderItem.ticket == "Y")
                    {
                        for (int k = 0; k < orderItem.cnt; k++)
                        {
                            ticket_seq++;

                            if (mTicketMedia == "BC")  // 띠지
                            {
                                t_ticket_no = mTheNo + ticket_seq.ToString("000");

                                //? 띠지 출력 필요
                                MessageBox.Show("띠지 출력입니다... " + t_ticket_no);

                            }
                            else  // 팔찌
                            {
                                //? 팔찌이면 스케너 입력로직 필요
                                MessageBox.Show("스캐너 입력입니다... ");

                                //t_ticket_no = "";  //? 스캐너로 읽어서 여기에...   theno + 팔찌번호?
                                t_ticket_no = mTheNo + ticket_seq.ToString("000");  //? 임시

                            }


                            Dictionary<string, string> parameters = new Dictionary<string, string>();
                            parameters.Clear();
                            parameters["siteId"] = mSiteId;
                            parameters["bizDt"] = mBizDate;
                            parameters["theNo"] = mTheNo;
                            parameters["refNo"] = mRefNo;

                            parameters["ticketNo"] = t_ticket_no;
                            parameters["ticketingDt"] = get_today_date() + get_today_time();
                            parameters["chargeDt"] = "";
                            parameters["settlementDt"] = "";

                            parameters["pointCharge"] = "0";
                            parameters["pointUsage"] = "0";
                            parameters["settlePointCharge"] = "0";
                            parameters["settlePointUsage"] = "0";

                            parameters["itemCode"] = orderItem.code;
                            parameters["flowStep"] = "1";               // 발권1 - *충전2 - 사용중3 - 정산(완료)4
                            parameters["lockerNo"] = "";
                            parameters["openLocker"] = "1";             // 선불 :  항상 open
                                                                        // 후불 :  최초 open -> 사용 close -> 정산 open
                            if (mRequestPost("ticketFlow", parameters))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {

                                }
                                else
                                {
                                    MessageBox.Show("오류 ticketFlow\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                                    return -1;
                                }
                            }
                            else
                            {
                                MessageBox.Show("시스템오류 ticketFlow\n\n" + mErrorMsg, "thepos");
                                return -1;
                            }
                        } 

                    }
                }

                return ticket_seq;

            }
            else if (mPayClass == "CH") // 충전
            {
                MemOrderItem orderItem = (MemOrderItem)mLvwOrderItem.Items[0].Tag;
                int charge_amt = orderItem.amt;
                String t_no = orderItem.ticket_no;

                int prev_point_charge = 0;

                // GET
                String sUrl = "ticketFlow?ticketNo=" + t_no;

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["ticketFlows"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count != 1)
                        {
                            MessageBox.Show("티켓데이터 오류 \n ticketFlowCnt=" + arr.Count, "thepos");
                            return -1;
                        }

                        prev_point_charge = convert_number(arr[0]["pointCharge"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("티켓데이터 충전 오류.\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. ticketFlow\n\n" + mErrorMsg, "thepos");
                }


                // PATCH
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["ticketNo"] = t_no;
                parameters["flowStep"] = "2";
                parameters["pointCharge"] = (prev_point_charge + charge_amt) + "";
                parameters["chargeDt"] = get_today_date() + get_today_time();


                if (mRequestPatch("ticketFlow", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        MessageBox.Show("정상 충전 완료.", "thepos");
                        return 1;
                    }
                    else
                    {
                        MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return -1;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return -1;
                }


            }
            else if (mPayClass == "US") // 포인트 사용
            {
                
                int usage_amout = mNetAmount;
                String t_no = ticket_no;

                int prev_point_usage = 0;

                // GET
                String sUrl = "ticketFlow?ticketNo=" + t_no;

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["ticketFlows"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count != 1)
                        {
                            MessageBox.Show("티켓데이터 사용 오류 \n ticketFlowCnt=" + arr.Count, "thepos");
                            return -1;
                        }

                        prev_point_usage = convert_number(arr[0]["pointUsage"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("티켓데이터 오류.\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. ticketFlow\n\n" + mErrorMsg, "thepos");
                }





                // PATCH
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["ticketNo"] = t_no;
                parameters["flowStep"] = "3";
                parameters["pointUsage"] = prev_point_usage + usage_amout + "";

                if (mRequestPatch("ticketFlow", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        MessageBox.Show("정상 사용 완료.", "thepos");
                        return 1;
                    }
                    else
                    {
                        MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return -1;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return -1;
                }



            }
            else if (mPayClass == "ST") // 정산
            {
                MemOrderItem orderItem = (MemOrderItem)mLvwOrderItem.Items[0].Tag;
                int settle_amt = orderItem.amt;

                String t_no = ticket_no;

                int settle_point_usage = 0;
                int settle_point_charge = 0;
                int point_usage = 0;
                int point_charge = 0;
                String flow_step = "";
                String open_locker = "";



                // GET
                String sUrl = "ticketFlow?ticketNo=" + t_no;

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["ticketFlows"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count != 1)
                        {
                            MessageBox.Show("티켓데이터 사용 오류 \n ticketFlowCnt=" + arr.Count, "thepos");
                            return -1;
                        }

                        point_charge = convert_number(arr[0]["pointCharge"].ToString());
                        point_usage = convert_number(arr[0]["pointUsage"].ToString());
                        settle_point_charge = convert_number(arr[0]["settlePointCharge"].ToString());
                        settle_point_usage = convert_number(arr[0]["settlePointUsage"].ToString());
                        flow_step = arr[0]["flowStep"].ToString();
                        open_locker = arr[0]["openLocker"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("티켓데이터 오류.\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. ticketFlow\n\n" + mErrorMsg, "thepos");
                }



                if (subClass == "US")
                {
                    settle_point_usage += settle_amt;
                }
                else if (subClass == "CH")
                {
                    settle_point_charge += settle_amt;
                }



                if (point_usage == settle_point_usage & point_charge == settle_point_charge)
                {
                    flow_step = "4";                // 접수0 - 발급1 - *충전2 - 사용중3 - 정산(완료)4

                    if (mTicketType == "PD") // 후불
                    {
                        open_locker = "1"; // 폐쇄0 개방1
                    }

                }


                // PATCH
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["ticketNo"] = t_no;
                parameters["settlement_dt"] = get_today_date() + get_today_time();

                parameters["settlePointCharge"] = settle_point_charge + "";
                parameters["settlePointUsage"] = settle_point_usage + "";

                parameters["flowStep"] = flow_step;



                if (mRequestPatch("ticketFlow", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        MessageBox.Show("정상 사용 완료.", "thepos");
                        return 1;
                    }
                    else
                    {
                        MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return -1;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return -1;
                }

            }

            return 0;
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
                if (int.TryParse(tbKeyDisplay.Text, out int amt))
                {
                    if (amt > 0 & amt < 100000000)
                    {
                        set_item_change_orderamt(lvwOrderItem.SelectedItems[0].Index, "set", amt);
                        tbKeyDisplay.Text = "";
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
                if (((MemOrderItem)lvwOrderItem.SelectedItems[0].Tag).cnt == 1)
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
                if (((MemOrderItem)lvwOrderItem.SelectedItems[0].Tag).cnt >= 999)
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
                if (int.TryParse(tbKeyDisplay.Text, out int cnt))
                {
                    if (cnt > 0 & cnt < 1000)
                    {
                        set_item_change_ordercnt(lvwOrderItem.SelectedItems[0].Index, "set", cnt);
                        tbKeyDisplay.Text = "";
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
                MemOrder waiting = new MemOrder();

                waiting.order_no = ++mWaitingNoCounter;

                waiting.cnt = 0;
                waiting.dt = DateTime.Now;
                waiting.amount = 0;

                for (int i = 0; i < lvwOrderItem.Items.Count; i++)
                {
                    MemOrderItem orderItem = (MemOrderItem)lvwOrderItem.Items[i].Tag;
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

                                MemOrderItem orderItem = new MemOrderItem();
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

            fLogo.Show();
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

        public static String getDCRmemo(MemOrderItem orderItem)
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
            MemOrderItem orderItem = (MemOrderItem)lvwOrderItem.Items[lv_idx].Tag;

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
            MemOrderItem orderItem = (MemOrderItem)lvwOrderItem.Items[lv_idx].Tag;


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


        public static int get_dc_amount(MemOrderItem orderItem)
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
            //? 전체할인인 경우 리스트뷰 가장 아래줄로 내린다..



        }

        public static bool isExist_DCR(String des)  // des = E or S
        {
            for (int i = mLvwOrderItem.Items.Count - 1; i >= 0; i--)
            {
                if (((MemOrderItem)mLvwOrderItem.Items[i].Tag).dcr_des == des)
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

            MemOrderItem orderItemInfo;

            for (int i = 0; i < mLvwOrderItem.Items.Count; i++)
            {
                orderItemInfo = (MemOrderItem)mLvwOrderItem.Items[i].Tag;
                Amount += (orderItemInfo.cnt * orderItemInfo.amt);
                dcAmount += orderItemInfo.dc_amount;
                mNetAmount += ((orderItemInfo.cnt * orderItemInfo.amt) - orderItemInfo.dc_amount);
            }

            mLblOrderAmount.Text = Amount.ToString("N0");
            mLblOrderAmountDC.Text = dcAmount.ToString("N0");
            mLblOrderAmountNet.Text = mNetAmount.ToString("N0");
            mLblOrderAmountReceive.Text = "";
            mLblOrderAmountRest.Text = "";

            // Sub Screen 표시
            DisplaySubScreen();
        }

    


        public static void DisplaySubScreen()
        {
            if (fSub != null)
            {
                mPanelOrderInfo.Visible = true;

                mSublvwOrderItem.Items.Clear();

                for (int i = 0; i < mLvwOrderItem.Items.Count; i++)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Text = mLvwOrderItem.Items[i].Text;
                    lvItem.SubItems.Add(mLvwOrderItem.Items[i].SubItems[1]);
                    lvItem.SubItems.Add(mLvwOrderItem.Items[i].SubItems[2]);
                    lvItem.SubItems.Add(mLvwOrderItem.Items[i].SubItems[3]);
                    lvItem.SubItems.Add(mLvwOrderItem.Items[i].SubItems[4]);
                    lvItem.SubItems.Add(mLvwOrderItem.Items[i].SubItems[5]);
                    mSublvwOrderItem.Items.Add(lvItem);
                }

                mSublblOrderAmount.Text = mLblOrderAmount.Text;
                mSublblOrderAmountDC.Text = mLblOrderAmountDC.Text;
                mSublblOrderAmountNet.Text = mLblOrderAmountNet.Text;
                mSublblOrderAmountReceive.Text = mLblOrderAmountReceive.Text;
                mSublblOrderAmountRest.Text = mLblOrderAmountRest.Text;
            }
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
                if (mTbKeyDisplayController.Text.Length > 0 )
                {
                    mTbKeyDisplayController.Text = mTbKeyDisplayController.Text.Substring(0, mTbKeyDisplayController.Text.Length - 1);
                }
            }
            else if (sKey == "Clear")
            {
                mTbKeyDisplayController.Text = "";
            }
            else if (sKey == "Enter")
            {
                //
            }
            else
            {
                mTbKeyDisplayController.Text += sKey;
            }
        }

        private void setGroupButtonColor(String groupcode, bool isPressed)
        {
            int button_idx = -1;

            for (int i = 0; i < mGoodsGroup.Length; i++)
            {
                if (mGoodsGroup[i].group_code == groupcode)
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

        public static int get_lvitem_idx(string code)
        {
            for (int i = 0; i < mLvwOrderItem.Items.Count; i++)
            {
                if (code == ((MemOrderItem)(mLvwOrderItem.Items[i].Tag)).code)
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
                lblTime.Text = nowDt.ToString("HH mm");
                timerSecondEvent.Tag = "0";
            }


            if (nowDt.ToString("HHmms0") == "000000")
            {
                setCurrentDateTitle();
            }
        }

        void setCurrentDateTitle()
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

            if (fSub != null)
            {
                mPanelOrderInfo.Visible = false;
            }


            this.Close();
        }

        private void lvwOrderItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mRightFace == "PayComplex")
            {

                if (lvwOrderItem.SelectedItems.Count > 0)
                {
                    MemOrderItem orderItem = (MemOrderItem)(lvwOrderItem.SelectedItems[0].Tag);

                    int amt = orderItem.cnt * orderItem.amt - orderItem.dc_amount;

                    frmPayComplex.mTbReqAmount.Text = amt.ToString("N0");
                }
            }



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
            //! 재기동시 초기화된 이후의 연속성. -> 서버에 물어본다.  last_the_no();
            mTheNo = mSiteId + mBizDate + mPosNo + (++mBillTheNo).ToString("0000");


            //? 이렇게 하면 안됨. 
            mRefNo = mTheNo;
            


            // the_no : 결제단위 - cash card complex point easy 결제버튼을 누른경우 새로운 the_no부여
            // ref_no : 입장단위 - 포인트 충전 정산의 경우 티켓번호 18자리로 세트


        }

        private void btnFlowTicketing_Click(object sender, EventArgs e)
        {
            ConsoleDisable();

            Form fFlow;
            fFlow = new frmFlowTicketing();

            fFlow.Left += this.Location.X;
            fFlow.Top += this.Location.Y;

            fFlow.Show();
        }

        private void btnFlowCharging_Click(object sender, EventArgs e)
        {
            if (mTicketType == "PA")  //선불형
            {

            }
            else
            {
                MessageBox.Show("선불형인 경우만 충전할 수 있습니다.", "thepos");
                return;
            }




            if (lvwOrderItem.Items.Count > 0)
            {
                SetDisplayAlarm("W", "주문항목이 있습니다. 항목을 취소하거나 완료 요망.");
                return;
            }


            ConsoleDisable();

            Form fFlow;
            fFlow = new frmFlowCharging();

            fFlow.Left += this.Location.X;
            fFlow.Top += this.Location.Y;

            fFlow.Show();
        }

        private void btnFlowSettlement_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.Items.Count > 0)
            {
                SetDisplayAlarm("W", "주문항목이 있습니다. 항목을 취소하거나 완료 요망.");
                return;
            }

            ConsoleDisable();

            Form fFlow;
            fFlow = new frmFlowSettlement();

            fFlow.Left += this.Location.X;
            fFlow.Top += this.Location.Y;

            fFlow.Show();
        }



        private void btnKeyEnter_Click(object sender, EventArgs e)
        {
            //? 열린창에 따라서 순번대로 입력하는 UI로 기능 개발
            // 카드결제 창 - 3개 입력항목 감안
        }





        // 
        public static String make_bill_header()
        {
            String strPrint = "";

            String tStr = mSiteName + " " + mBizTelNo;
            strPrint += tStr;
            strPrint += "\r\n";

            tStr = mBizAddr;
            strPrint += tStr;
            strPrint += "\r\n";

            tStr = mCapName + " ";

            if (mRegistNo.Length == 10)
            {
                tStr += mRegistNo.Substring(0, 3) + "-" + mRegistNo.Substring(3, 2) + "-" + mRegistNo.Substring(5, 5);
            }
            else
            {
                tStr += mRegistNo;
            }

            strPrint += tStr;
            strPrint += "\r\n";
            strPrint += "\r\n";


            return strPrint;
        }

        public static String make_bill_trailer()
        {
            String strPrint = "";

            String tStr = "  물품반품시 본 영수증을 필히 지참하여";
            strPrint += tStr;
            strPrint += "\r\n";

            tStr = "  주시기 바랍니다.";
            strPrint += tStr;
            strPrint += "\r\n";

            return strPrint;

        }

        public static String make_bill_body(String tTheNo, String tranType, String except_order, String is_payment)
        {
            String strPrintHeader = "";
            String strPrintOrder = "";
            String strPrintPayment = "";

            String tOrderDt = "";
            int tax_amount = 0;
            int tfree_amount = 0;
            int dc_amount = 0;

            String is_payment_cash = is_payment.Substring(0, 1);
            String is_payment_card = is_payment.Substring(1, 1);
            String is_payment_point = is_payment.Substring(2, 1);
            String is_payment_easy = is_payment.Substring(3, 1);



            //!
            String sUrl = "orders?theNo=" + tTheNo;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orders"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        String d = arr[i]["orderDate"].ToString();
                        String t = arr[i]["orderTime"].ToString();
                        tOrderDt = d.Substring(0, 4) + "/" +
                                   d.Substring(4, 2) + "/" +
                                   d.Substring(6, 2) + " " +
                                   t.Substring(0, 2) + ":" +
                                   t.Substring(2, 2) + ":" +
                                   t.Substring(4, 2);
                    }
                }
                else
                {
                    MessageBox.Show("주문 데이터 오류. \n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orders\n\n" + mErrorMsg, "thepos");
            }


            String tStr = tTheNo.Substring(4, 8) + "-" + tTheNo.Substring(12, 2) + "-" + tTheNo.Substring(14, 4);
            int space_cnt = 42 - (encodelen(tOrderDt) + encodelen(tStr));
            strPrintHeader = tOrderDt + Space(space_cnt) + tStr;
            strPrintHeader += "\r\n";

            strPrintOrder = "==========================================\r\n";  // 42
            strPrintOrder += "상품명                 단가  수량     금액\r\n";
            strPrintOrder += "------------------------------------------\r\n";  // 42


            //!
            sUrl = "orderItem?theNo=" + tTheNo;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orderItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        int amt = convert_number(arr[i]["amt"].ToString());
                        int cnt = convert_number(arr[i]["cnt"].ToString());
                        int dc_amt = convert_number(arr[i]["dcAmount"].ToString());
                        String dcr_des = arr[i]["dcrDes"].ToString();
                        String dcr_type = arr[i]["dcrType"].ToString();
                        String dcr_value = arr[i]["dcrValue"].ToString();

                        if (dcr_des == "E") // 전체할인
                        {
                            if (dcr_type == "A")
                            {
                                tStr = "전체할인";
                                strPrintOrder += tStr + Space(21 - encodelen(tStr));

                                tStr = (-dc_amt).ToString("N0");        // 할인 정액
                                strPrintOrder += Space(21 - encodelen(tStr)) + tStr;
                            }
                            else if (listOrderItem[i].dcr_type == "R")
                            {
                                tStr = "전체할인-" + listOrderItem[i].dcr_value + "%";
                                strPrintOrder += tStr + Space(21 - encodelen(tStr));

                                tStr = (-dc_amt).ToString("N0");        // 할인 정액
                                strPrintOrder += Space(21 - encodelen(tStr)) + tStr;
                            }
                            strPrintOrder += "\r\n";
                        }
                        else                                 // 일반상품항목
                        {

                            tStr = arr[i]["itemName"].ToString();
                            strPrintOrder += tStr + Space(18 - encodelen(tStr));

                            tStr = amt.ToString("N0");     //단가
                            strPrintOrder += Space(9 - encodelen(tStr)) + tStr;

                            tStr = cnt.ToString("N0");     // 수량
                            strPrintOrder += Space(6 - encodelen(tStr)) + tStr;

                            tStr = (amt * cnt).ToString("N0");     // 금액 = 단가*수량
                            strPrintOrder += Space(9 - encodelen(tStr)) + tStr;

                            strPrintOrder += "\r\n";

                            if (dcr_type == "A")
                            {
                                tStr = "    할인";
                                strPrintOrder += tStr + Space(21 - encodelen(tStr));

                                tStr = (-dc_amt).ToString("N0");        // 할인 정액
                                strPrintOrder += Space(21 - encodelen(tStr)) + tStr;

                                strPrintOrder += "\r\n";
                            }
                            else if (arr[i]["dcrType"].ToString() == "R")
                            {
                                tStr = "    할인-" + arr[i]["dcrValue"].ToString() + "%";
                                strPrintOrder += tStr + Space(21 - encodelen(tStr));

                                tStr = (-dc_amt).ToString("N0");        // 할인 정액
                                strPrintOrder += Space(21 - encodelen(tStr)) + tStr;

                                strPrintOrder += "\r\n";
                            }
                        }

                        if (arr[i]["taxFree"].ToString() == "Y") tfree_amount += (cnt * amt);
                        else tax_amount += (cnt * amt);

                        dc_amount += dc_amt;
                    }
                }
                else
                {
                    MessageBox.Show("주문 데이터 오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orderItem\n\n" + mErrorMsg, "thepos");
            }



            //
            strPrintPayment = "------------------------------------------\r\n";  // 42

            if (tfree_amount > 0)
            {
                tStr = "*면세품목가액";
                strPrintPayment += tStr + Space(21 - encodelen(tStr));

                tStr = (tfree_amount).ToString("N0");
                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;

                strPrintPayment += "\r\n";
            }

            if (tax_amount > 0)
            {
                int t_tax = tax_amount / 11;   // 부가세액
                int t_amt = tax_amount - t_tax; // 공급가액

                tStr = "과세품목가액";
                strPrintPayment += tStr + Space(21 - encodelen(tStr));
                tStr = (t_amt).ToString("N0");
                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                strPrintPayment += "\r\n";

                tStr = "부 가 세 액";
                strPrintPayment += tStr + Space(21 - encodelen(tStr));
                tStr = (t_tax).ToString("N0");
                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                strPrintPayment += "\r\n";
            }

            strPrintPayment += "------------------------------------------\r\n";  // 42

            int tsum = tfree_amount + tax_amount;
            int tnet = tsum - dc_amount;


            tStr = "총합계";
            strPrintPayment += tStr + Space(21 - encodelen(tStr));
            tStr = (tsum).ToString("N0");
            strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
            strPrintPayment += "\r\n";

            tStr = "할인계";
            strPrintPayment += tStr + Space(21 - encodelen(tStr));
            tStr = (-dc_amount).ToString("N0");
            strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
            strPrintPayment += "\r\n";

            tStr = "결제대상금액";
            strPrintPayment += tStr + Space(21 - encodelen(tStr));
            tStr = (tnet).ToString("N0");
            strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
            strPrintPayment += "\r\n";

            strPrintPayment += "------------------------------------------\r\n";  // 42



            //! 현금결제
            if (is_payment_cash == "1")
            {
                sUrl = "paymentCash?theNo=" + tTheNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCashs"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i]["tranType"].ToString() == tranType)
                            {
                                int amount = convert_number(arr[i]["amount"].ToString());


                                if (arr[i]["payType"].ToString() == "R0") // 단순현금
                                {

                                    tStr = "현금";
                                    strPrintPayment += tStr + Space(21 - encodelen(tStr));

                                    if (tranType == "C")
                                        tStr = (-amount).ToString("N0");
                                    else
                                        tStr = amount.ToString("N0");

                                    strPrintPayment += Space(21 - encodelen(tStr)) + tStr;

                                }
                                else if (arr[i]["payType"].ToString() == "R1") // 현금영수증
                                {
                                    tStr = "현금영수증";
                                    strPrintPayment += tStr + Space(21 - encodelen(tStr));

                                    if (tranType == "C")
                                        tStr = (-amount).ToString("N0");
                                    else
                                        tStr = amount.ToString("N0");

                                    strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                                    strPrintPayment += "\r\n";

                                    if (arr[i]["receiptType"].ToString() == "1") // 소득공제
                                    {
                                        tStr = "소득공제";
                                    }
                                    else if (arr[i]["receiptType"].ToString() == "2") // 지출증빙
                                    {
                                        tStr = "지출증빙";
                                    }
                                    else if (arr[i]["receiptType"].ToString() == "S") //? 자진밝급
                                    {
                                        tStr = "자진발급";
                                    }

                                    strPrintPayment += tStr + Space(21 - encodelen(tStr));

                                    String no = arr[i]["issuedMethodNo"].ToString() + "";

                                    if (no.Contains('*'))
                                    {
                                        tStr = no;
                                    }
                                    else if (no.Length == 16)
                                    {
                                        tStr = no.Substring(0, 4) + "-" + no.Substring(4, 4) + "-****-" + no.Substring(12, 3) + "*";
                                    }
                                    else if (no.Length == 11)
                                    {
                                        if (no.Substring(0, 3) == "010")
                                        {
                                            tStr = no.Substring(0, 3) + "-****-" + no.Substring(6, 4);
                                        }
                                        else
                                        {
                                            tStr = no.Substring(0, 8) + CharCount('*', no.Length - 8);
                                        }
                                    }
                                    else if (no.Length > 8)
                                    {
                                        tStr = no.Substring(0, 8) + CharCount('*', no.Length - 8);
                                    }
                                    else
                                    {
                                        tStr = no;
                                    }

                                    strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                                }

                                strPrintPayment += "\r\n";
                                strPrintPayment += "\r\n";
                            }
                        }
                    }
                }
            }


            //! 카드결제
            if (is_payment_card == "1")
            {
                sUrl = "paymentCard?theNo=" + tTheNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCards"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i]["tranType"].ToString() == tranType)
                            {
                                if (arr[i]["payType"].ToString() == "C1") tStr = "카드결제";
                                else if (arr[i]["payType"].ToString() == "C9") tStr = "카드결제";  //? 임의등록

                                if (tranType == "C")
                                {
                                    tStr += "취소";
                                }

                                int amount = convert_number(arr[i]["amount"].ToString());


                                strPrintPayment += tStr + Space(21 - encodelen(tStr));

                                if (tranType == "C")
                                    tStr = (-amount).ToString("N0");
                                else
                                    tStr = amount.ToString("N0");

                                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                                strPrintPayment += "\r\n";

                                tStr = arr[i]["cardName"].ToString();
                                strPrintPayment += tStr + Space(21 - encodelen(tStr));

                                String no = arr[i]["cardNo"].ToString();


                                if (no.Contains('*'))
                                {
                                    tStr = no;
                                }
                                else if (no.Length == 16)
                                {
                                    tStr = no.Substring(0, 4) + "-" + no.Substring(4, 4) + "-****-" + no.Substring(12, 3) + "*";
                                }
                                else if (no.Length > 8)
                                {
                                    tStr = no.Substring(0, 8) + CharCount('*', no.Length - 8);
                                }
                                else
                                {
                                    tStr = no;
                                }

                                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                                strPrintPayment += "\r\n";

                                if (arr[i]["install"].ToString() == "00")
                                    tStr = "할부개월:일시불";
                                else
                                    tStr = "할부개월:" + arr[i]["install"].ToString();

                                strPrintPayment += tStr + Space(21 - encodelen(tStr));
                                tStr = "승인번호:" + arr[i]["authNo"].ToString();
                                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                                strPrintPayment += "\r\n";
                                strPrintPayment += "\r\n";

                            }

                        }
                    }
                }
            }


            //! 포인트
            if (is_payment_point == "1")
            {
                sUrl = "paymentPoint?theNo=" + tTheNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentPoints"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i]["tranType"].ToString() == tranType)
                            {
                                int amount = convert_number(arr[i]["amount"].ToString());

                                if (arr[i]["payType"].ToString() == "PA") // 선불 포인트  //? 잔여포인트 표시
                                {
                                    tStr = "포인트";
                                }
                                else if (arr[i]["payType"].ToString() == "PD") // 후불 포인트
                                {
                                    tStr = "포인트";
                                }

                                strPrintPayment += tStr + Space(21 - encodelen(tStr));

                                if (tranType == "C")
                                    tStr = (-amount).ToString("N0");
                                else
                                    tStr = amount.ToString("N0");

                                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;

                                strPrintPayment += "\r\n";
                                strPrintPayment += "\r\n";
                            }
                        }
                    }
                }
            }


            //? 간편결제
            if (is_payment_easy == "1")
            {


            }




            strPrintPayment += "------------------------------------------\r\n";  // 42

            if (except_order == "Y")
            {
                return strPrintHeader + strPrintPayment;
            }
            else
            {
                return strPrintHeader + strPrintOrder + strPrintPayment;
            }
        }

        public static string Space(int count)
        {
            return new String(' ', count);
        }

        public static string CharCount(char c, int count)
        {
            return new String(c, count);
        }

        public static int encodelen(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }

        public static void PrintBill(String headerBill, String bodyBill, String trailerBill, String theNo)
        {

            try
            {

                SerialPort port = new SerialPort();

                if (port.IsOpen)
                    port.Close();


                port.PortName = mBillPrinterPort;
                port.BaudRate = (int)9600; //고정
                port.DataBits = (int)8;
                port.Parity = Parity.None;
                port.StopBits = StopBits.One;

                port.Open();
                port.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("영수증프린터 에러.\r\n" + ex.Message);
                return;
            }


            try
            {
                const string ESC = "\u001B";
                const string InitializePrinter = ESC + "@";

                PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();

                byte[] BytesValue = new byte[100];

                BytesValue = PrintExtensions.AddBytes(BytesValue, InitializePrinter);

                //
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(headerBill));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());

                //              
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(bodyBill));

                //
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(trailerBill));



                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                // 바코드
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.BarCode.Code128(theNo));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());


                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                BytesValue = PrintExtensions.AddBytes(BytesValue, CutPage());

                //? 영수증출력
                PrintExtensions.Print(BytesValue, mBillPrinterPort);



            }
            catch (Exception ex)
            {
                MessageBox.Show("인쇄중 에러.\r\n" + ex.Message);
                return;
            }

        }

        private static string strPosTitle(string title)
        {
            int blen = Encoding.Default.GetBytes(title).Length;
            int slen = title.Length;
            int len = 16 - (blen - slen);

            return string.Format("{0,-" + len + "}{1,3}", title, 1) + " : ";
        }

        public static byte[] CutPage()
        {

            byte[] partial_cut = new byte[3] { 0x1D, 0x56, 0x00 };

            return partial_cut;


        }
    }
}
