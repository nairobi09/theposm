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
        }


        private void initialize_font()
        {

            lblTitle01.Font = font9;
            lblTitle02.Font = font9;
            lblTitle03.Font = font9;
            lblTitle04.Font = font9;
            
            lblSiteName.Font = font9;
            lblPosNo.Font = font9;
            lblBusinessDate.Font = font9;
            lblUserName.Font = font9;


            lblDate.Font = font10;
            lblTime.Font = font14;

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

            lblSiteName.Text = mSiteName;
            lblPosNo.Text = mPosNo;

            lblBusinessDate.Text = mBizDate.Substring(0, 4) + "-" + mBizDate.Substring(4, 2) + "-" + mBizDate.Substring(6, 2);
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


                        
            get_last_theno();  // 서버에서 최종 theno를 구한다. -> mBillTheNo 세팅

            get_pos_setup();

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
                    MessageBox.Show("orderLastNo = " + theno, "//?");


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


            mPayChannel = "NICE";







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
                        mGoodsGroup[i].group_name = arr[i]["goodsGroupName"].ToString();
                        mGoodsGroup[i].column = int.Parse(arr[i]["locateX"].ToString());
                        mGoodsGroup[i].row = int.Parse(arr[i]["locateY"].ToString());
                        mGoodsGroup[i].columnspan = int.Parse(arr[i]["sizeX"].ToString());
                        mGoodsGroup[i].rowspan = int.Parse(arr[i]["sizeY"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("상품그룹정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
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
                    MessageBox.Show("상품그룹정보 오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
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
                //?? 복합결제 서버save 필요
                for (int i = 0; i < mPayments.Count; i++)
                {
                    if (mPayments[i].the_no == mTheNo)
                    {
                        Payment p = new Payment();
                        p = mPayments[i];
                        p.net_amount += amount;

                        if (payType == "Cash") p.amount_cash += amount;
                        else if (payType == "Card") p.amount_card += amount;
                        else if (payType == "Easy") p.amount_easy += amount;
                        else if (payType == "Point") p.amount_point += amount;

                        mPayments[i] = p;

                    }
                }
            }

            return true;

        }




        public static int SaveTicket(String ticket_no, String subClass)  // subClass : 사용 US,  충전 CH
        {
            //? 서버API로 대체한다..

            // Order 0, charge 1, settlement 2



            if (mPayClass == "OR") // 주문(접수-발권)
            {
                int ticket_seq = 0;

                for (int i = 0; i < mLvwOrderItem.Items.Count; i++)
                {
                    TicketFlow ticketFlow = new TicketFlow();
                    MemOrderItem orderItem = (MemOrderItem)mLvwOrderItem.Items[i].Tag;

                    if (orderItem.ticket == "1")
                    {

                        //? 띠지 or 팔찌 -> 구분하여 
                        if (mTicketMedia == "BC")
                        {
                            for (int k = 0; k < orderItem.cnt; k++)
                            {
                                ticket_seq++;

                                ticketFlow.site_id = mSiteId;
                                ticketFlow.biz_dt = mBizDate;
                                ticketFlow.the_no = mTheNo;
                                ticketFlow.ref_no = mTheNo;
                                ticketFlow.ticket_no = mTheNo + ticket_seq.ToString("000");
                                ticketFlow.ticketing_dt = get_today_date() + get_today_time();
                                ticketFlow.charge_dt = "";
                                ticketFlow.settlement_dt = "";
                                ticketFlow.point_charge = 0;
                                ticketFlow.point_usage = 0;
                                ticketFlow.goods_code = orderItem.code;
                                ticketFlow.flow_step = "1";                // 발권1 - *충전2 - 사용중3 - 정산(완료)4
                                ticketFlow.locker_no = "";
                                ticketFlow.open_locker = "1";              // 최초 open -> 충전 close, 사용 close -> 정산 open
                                mTicketFlowList.Add(ticketFlow);

                                //? 띠지 출력 필요



                            } 
                        }
                        else
                        {
                            //? 팔찌이면 스케너 입력로직 필요

                        }

                    }
                }

                return ticket_seq;

            }
            else if (mPayClass == "CH") // 충전
            {

                MemOrderItem orderItem = (MemOrderItem)mLvwOrderItem.Items[0].Tag;
                int charge_amt = orderItem.amt;

                for (int i = 0; i < mTicketFlowList.Count; i++)
                {
                    if (mTicketFlowList[i].ticket_no == orderItem.ticket_no)
                    {
                        TicketFlow ticketFlow = new TicketFlow();
                        ticketFlow = mTicketFlowList[i];
                        ticketFlow.charge_dt = get_today_date() + get_today_time();
                        ticketFlow.point_charge += charge_amt;
                        ticketFlow.flow_step = "2";                // 접수0 - 발급1 - *충전2 - 사용중3 - 정산(완료)4
                        mTicketFlowList[i] = ticketFlow;

                        return 1;
                    }
                }

            }
            else if (mPayClass == "US") // 포인트 사용
            {
                MemOrderItem orderItem = (MemOrderItem)mLvwOrderItem.Items[0].Tag;
                int usage_amout = orderItem.amt;


                for (int i = 0; i < mTicketFlowList.Count; i++)
                {
                    if (mTicketFlowList[i].ticket_no == ticket_no)
                    {
                        TicketFlow ticketFlow = new TicketFlow();
                        ticketFlow = mTicketFlowList[i];
                        ticketFlow.charge_dt = get_today_date() + get_today_time();
                        ticketFlow.point_usage += usage_amout;
                        ticketFlow.flow_step = "3";                // 접수0 - 발급1 - *충전2 - 사용중3 - 정산(완료)4


                        if (mTicketType == "PD") // 후불
                        {
                            ticketFlow.open_locker = "0"; // 폐쇄0 개방1
                        }

                        mTicketFlowList[i] = ticketFlow;

                        return 1;
                    }
                }


            }
            else if (mPayClass == "ST") // 정산
            {
                MemOrderItem orderItem = (MemOrderItem)mLvwOrderItem.Items[0].Tag;
                int settle_amt = orderItem.amt;

                for (int i = 0; i < mTicketFlowList.Count; i++)
                {
                    if (mTicketFlowList[i].ticket_no == ticket_no)
                    {
                        TicketFlow ticketFlow = new TicketFlow();
                        ticketFlow = mTicketFlowList[i];
                        ticketFlow.settlement_dt = get_today_date() + get_today_time();


                        //? ???
                        if (subClass == "US")
                        {
                            ticketFlow.settle_point_usage += settle_amt;
                        }
                        else if (subClass == "CH")
                        {
                            ticketFlow.settle_point_charge += settle_amt;
                        }
                        



                        if (ticketFlow.point_usage == ticketFlow.settle_point_usage & ticketFlow.point_charge == ticketFlow.settle_point_charge)
                        {
                            ticketFlow.flow_step = "4";                // 접수0 - 발급1 - *충전2 - 사용중3 - 정산(완료)4


                            if (mTicketType == "PD") // 후불
                            {
                                ticketFlow.open_locker = "0"; // 폐쇄0 개방1
                            }

                        }

                        mTicketFlowList[i] = ticketFlow;

                        return 1;
                    }
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

            mLblOrderAmount.Text =Amount.ToString("N0");
            mLblOrderAmountDC.Text = dcAmount.ToString("N0");
            mLblOrderAmountNet.Text = mNetAmount.ToString("N0");
            mLblOrderAmountReceive.Text = "";
            mLblOrderAmountRest.Text = "";
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
            //? 재기동시 초기화된 이후의 연속성을 고민한다.. -> 서버에 물어본다.

            mTheNo = mSiteId + mBizDate + mPosNo + (++mBillTheNo).ToString("0000");
            mRefNo = mTheNo;
            

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



        private void picLogo_Click(object sender, EventArgs e)
        {
            ContextMenu m = new ContextMenu();
            m.MenuItems.Add(new MenuItem("메모리상태", MenuItemMemoryStatus_Click));
            m.MenuItems.Add(new MenuItem("상품그룹등록", MenuItemGoodsGroup_Click));
            m.MenuItems.Add(new MenuItem("상품등록", MenuItemGoods_Click));
            m.MenuItems.Add(new MenuItem("결제콘솔", MenuItemPayConsol_Click));

            picLogo.ContextMenu = m;
        }

        private void MenuItemMemoryStatus_Click(Object sender, System.EventArgs e)
        {
            Form fFlow;
            fFlow = new frmSysMemoryStatus();
            fFlow.Show();
        }

        private void MenuItemGoodsGroup_Click(Object sender, System.EventArgs e)
        {
            Form fFlow;
            fFlow = new frmSysGoodsGroup();
            fFlow.Show();
        }

        private void MenuItemGoods_Click(Object sender, System.EventArgs e)
        {
            Form fFlow;
            fFlow = new frmSysGoodsItem();
            fFlow.Show();
        }

        private void MenuItemPayConsol_Click(Object sender, System.EventArgs e)
        {
            Form fFlow;
            fFlow = new frmSysPayConsole();
            fFlow.Show();
        }
    }
}
