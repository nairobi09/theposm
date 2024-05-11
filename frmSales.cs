using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Collections.Generic;
using static thepos.thePos;
using static thepos.frmMain;
using static thepos.frmFlowCharging;
using static thepos.frmPayComplex;
using System.Diagnostics;
using PrinterUtility;
using System.IO.Ports;
using System.Text;
using thepos._1Sales;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.IO;
using System.Web.UI.WebControls.Expressions;
using System.Security.Policy;
using System.Diagnostics.Eventing.Reader;
using System.Data.SQLite;
using System.Collections;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using static BrightIdeasSoftware.ObjectListView;
using BrightIdeasSoftware;
using System.Web;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Net;
using System.Windows.Forms.DataVisualization.Charting;



/* 과제
    + 마우스 포인터 표시 : pc pos 구분필요 
    + 리스트뷰 아이템외 클릭시 selected item의 highlight(backcolor)가 사라지는 현상 수정필요
    + 리스트뷰 HeaderColumn backcolor 변경필요 - DrawColumnHeader
    
panelProduct : 488, 56 529, 547

*/




namespace thepos
{
    public partial class frmSales : Form
    {



        public static int mBillTheNo = 0;
        int mWaitingNoCounter = 0;
        public static int mSelectedWaitingNo = 0;

        String last_groupcode = "";  // 상품그룹을 클릭했을 경우 눌려진버튼을 또 눌렀는지 비교하기 위함.

        public static String mRightFace = "";



        public static TextBox mTbKeyDisplaySales;            // Sales화면의 key display
        public static TextBox mTbKeyDisplayController;  // 공용컨트롤러

        public static Panel mPanelTitleConsole;
        public static Panel mPanelOrderConsole;
        public static Label mLblDisplayAlarm;
        //public static Label mLblKeyDisplay;

        //public static ListView mLvwOrderItem;
        public static BrightIdeasSoftware.ObjectListView mLvwOrderItem;

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


        public static Panel mPanelMiddle;
        public static Panel mPanelPayment;
        public static Panel mPanelCancel;

        public static Button mBtnOrderWaiting;

        public static TableLayoutPanel mTableLayoutPanelPayControl;




        public frmSales()
        {
            InitializeComponent();

            //? PC가 아니면 마우스 포인터 표시안함.
            //Cursor.Hide();

            initialize_font();
            initialize_the();

            display_paymentConsol();

            int default_click_no = display_goodsgroup();


            if (default_click_no > -1)
            {
                ClickedGoodsGroup(mGoodsGroup[default_click_no].group_code);   // 디폴트로 설정된 그룹을 첫화면에 보여주자
            }

                        
            // 일련번호(4) 대신 Time(6)으로 변경
            //get_last_theno();  // 서버에서 최종 theno를 구한다. -> mBillTheNo 세팅


            if (mPosType == "POS-Ticket" |  mPosType == "PC-Ticket")
            {
                // 티켓버튼 레이아웃으로 변경


                // 티켓플로패널
                panelFlowConsole.Visible = true;

                btnOrderWaiting.Size = new Size(124, 48);


                // 결제내역관리
                btnPayManager.Location = new Point(350, 313);
                btnPayManager.Size = new Size(124, 48);

            }



            // Sub Screen 
            if (fSub != null)
            {
                mPanelOrderInfo.Visible = true;
            }


        }

        private void frmSales_Shown(object sender, EventArgs e)
        {
            ChangeTheMode(true);
        }



        private void initialize_font()
        {

            lblLocalModeTitle.Font = font10;

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


            lvwOrderItem.Font = new Font("굴림", 11, FontStyle.Bold);
            //lvwOrderItem.Font = font10;
            lblDisplayAlarm.Font = font10;

            btnOrderCancelAll.Font = font10;
            btnOrderCancelSelect.Font = font10;
            btnOrderCntDn.Font = font12;
            btnOrderCntUp.Font = font12;
            btnOrderCntChange.Font = font10;
            btnOrderItemScrollUp.Font = font8;
            btnOrderItemScrollDn.Font = font8;
            btnOrderAmtChange.Font = font10;

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
            btnKeyBS.Font = font14;
            btnKeyClear.Font = font14;

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
            btnKeyBS.Click += (sender, args) => ClickedKey("BS");
            btnKeyClear.Click += (sender, args) => ClickedKey("Clear");


            // 최초세팅 - 이후 개별창이 뜰때마다 각각창의 KeyDisplay로 세팅을 변경할 수 있다. 
            // 서브창이 열리면서 Sale창의 콘트롤 Enable/Disable 관리를 위해서...
            mTbKeyDisplaySales = tbKeyDisplay;
            mTbKeyDisplayController = mTbKeyDisplaySales;


            mPanelTitleConsole = panelTitleConsole;
            mPanelOrderConsole = panelOrderConsole;

            mLblDisplayAlarm = lblDisplayAlarm;
            mTimerAlarm = timerAlarmDisplay;

            //mLblKeyDisplay = lblKeyDisplay;
            mLvwOrderItem = lvwOrderItem;

            mBtnOrderWaiting = btnOrderWaiting;

            mLblOrderAmount = lblOrderAmount;
            mLblOrderAmountDC = lblOrderAmountDC;
            mLblOrderAmountNet = lblOrderAmountNet;
            mLblOrderAmountReceive = lblOrderAmountReceive;
            mLblOrderAmountRest = lblOrderAmountRest;


            // 아래순서가 Z-order인것같음.
            mPanelCancel = panelCancel;
            mPanelCancel.Width = 529;
            mPanelCancel.Height = 704;

            mPanelPayment = panelPayment;
            mPanelPayment.Width = 529;
            mPanelPayment.Height = 704;

            mPanelMiddle = panelMiddle;
            mPanelMiddle.Width = 529;
            mPanelMiddle.Height = 704;


            mTableLayoutPanelPayControl = tableLayoutPanelPayControl;



            // 
            mLblTheModeStatus.VisibleChanged += (sender, args) => ChangeTheMode(false);

            // 메모리 초기화
            mOrderItemList.Clear();


            this.lv_name.Renderer = rendererName();
            this.lv_amt.Renderer = rendererAmt();
            this.lv_dc_amount.Renderer = rendererDcAmount();

        }

        public DescribedTaskRenderer rendererName()
        {
            DescribedTaskRenderer renderer = new DescribedTaskRenderer();
            renderer.DescriptionAspectName = "option_name_description";

            renderer.TitleFont = new Font("굴림", 11, FontStyle.Bold);
            renderer.DescriptionFont = new Font("굴림", 8, FontStyle.Regular);
            renderer.DescriptionColor = Color.Gray;
            renderer.ImageTextSpace = 0;
            renderer.TitleDescriptionSpace = 0;

            renderer.UseGdiTextRendering = false;

            return (renderer);
        }

        public DescribedTaskRenderer rendererAmt()
        {
            DescribedTaskRenderer renderer = new DescribedTaskRenderer();
            renderer.DescriptionAspectName = "option_amt_description";

            renderer.TitleFont = new Font("굴림", 11, FontStyle.Bold);
            renderer.DescriptionFont = new Font("굴림", 8, FontStyle.Regular);
            renderer.DescriptionColor = Color.Gray;
            renderer.ImageTextSpace = 0;
            renderer.TitleDescriptionSpace = 0;

            renderer.UseGdiTextRendering = false;

            return (renderer);
        }

        public DescribedTaskRenderer rendererDcAmount()
        {
            DescribedTaskRenderer renderer = new DescribedTaskRenderer();
            renderer.DescriptionAspectName = "option_dc_amount_description";

            renderer.TitleFont = new Font("굴림", 11, FontStyle.Bold);
            renderer.DescriptionFont = new Font("굴림", 8, FontStyle.Regular);
            renderer.DescriptionColor = Color.Gray;
            renderer.ImageTextSpace = 0;
            renderer.TitleDescriptionSpace = 0;

            renderer.UseGdiTextRendering = false;


            return (renderer);
        }

        public void ChangeTheMode(bool isFirst)
        {
            // 네트워크 상태 : 정상이미지를 보이기/숨기기
            //pbNetworkConn.BeginInvoke(new Action(() => pbNetworkConn.Visible = NetworkInterface.GetIsNetworkAvailable()));
            pbNetworkConn.Visible = NetworkInterface.GetIsNetworkAvailable();
            pbNetworkDisconn.Visible = !pbNetworkConn.Visible;

            if (mTheMode == "Server")
            {
                lblLocalModeTitle.Visible = false;

                if (isFirst) 
                { 

                }
                else
                {
                    SetDisplayAlarm("W", "모드변경 : 로컬 -> 서버");
                }
                
            }
            else
            {
                lblLocalModeTitle.Visible = true;

                if (isFirst)
                {
                    
                }
                else
                {
                    SetDisplayAlarm("W", "모드변경 : 서버 -> 로걸");
                }
                
            }


        }


        private void display_paymentConsol()
        {
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
                    btnPayItem.Name = "btnPayConsoleCash";
                    btnPayItem.Text = "현금\r결제";
                    btnPayItem.Click += (sender, args) => ClickedPayCash();
                }
                else if (mPayConsol[i].code == "CARD")
                {
                    btnPayItem.Name = "btnPayConsoleCard";
                    btnPayItem.Text = "카드\r결제";
                    btnPayItem.Click += (sender, args) => ClickedPayCard();
                }
                else if (mPayConsol[i].code == "POINT")
                {
                    //btnPayItem.BackColor = Color.SaddleBrown;
                    btnPayItem.Name = "btnPayConsolePoint";
                    btnPayItem.Text = "포인트\r사용";
                    btnPayItem.Click += (sender, args) => ClickedPayPoint();
                }
                else if (mPayConsol[i].code == "COMPLEX")
                {
                    btnPayItem.Name = "btnPayConsoleComplex";
                    btnPayItem.Text = "복합\r결제";
                    btnPayItem.Click += (sender, args) => ClickedPayComplex();
                }
                else if (mPayConsol[i].code == "EASY")
                {
                    btnPayItem.Name = "btnPayConsoleEasy";
                    btnPayItem.Text = "간편\r결제";
                    btnPayItem.Click += (sender, args) => ClickedPayEasy();
                }
                else btnPayItem.Text = "";

                tableLayoutPanelPayControl.Controls.Add(btnPayItem, mPayConsol[i].column, mPayConsol[i].row);
                tableLayoutPanelPayControl.SetColumnSpan(btnPayItem, mPayConsol[i].columnspan);
                tableLayoutPanelPayControl.SetRowSpan(btnPayItem, mPayConsol[i].rowspan);
            }

        }


        private int display_goodsgroup()
        {
            int sum_colunm_row = 8;
            int default_click_no = -1;  // 일단 클릭없음

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

                btnGoodsGroup.FlatAppearance.BorderSize = 2;


                if (mGoodsGroup[i].columnspan == 1)
                {
                    btnGoodsGroup.Font = font9;
                }
                else if (mGoodsGroup[i].rowspan == 1)
                {
                    btnGoodsGroup.Font = font12;
            }
                else if (mGoodsGroup[i].columnspan >= 3 & mGoodsGroup[i].rowspan >= 2)
                {
                    btnGoodsGroup.Font = font20;
                }
                else
                {
                    btnGoodsGroup.Font = font14;
                }


                // 품절처리
                if (mGoodsGroup[i].soldout == "Y")
                {
                    btnGoodsGroup.ForeColor = Color.Gray;
                }
                else
                {
                    btnGoodsGroup.Click += (sender, args) => ClickedGoodsGroup(group_code);

                    // 디폴트로 클릭될 그룹을 찾는다.
                    if (sum_colunm_row > mGoodsGroup[i].column + mGoodsGroup[i].row)
                    {
                        sum_colunm_row = mGoodsGroup[i].column + mGoodsGroup[i].row;
                        default_click_no = i;
                    }
                }


                tableLayoutPanelGoodsItem.Controls.Add(btnGoodsGroup, mGoodsGroup[i].column, mGoodsGroup[i].row);
                tableLayoutPanelGoodsItem.SetColumnSpan(btnGoodsGroup, mGoodsGroup[i].columnspan);
                tableLayoutPanelGoodsItem.SetRowSpan(btnGoodsGroup, mGoodsGroup[i].rowspan);

                tableLayoutPanelGoodsGroup.Controls.Add(btnGoodsGroup);

            }

            //
            return default_click_no;

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
                    btnGoodsItem.Text = mGoodsItem[i].goods_name + "\n" + mGoodsItem[i].amt.ToString("N0");
                    btnGoodsItem.Tag = mGoodsItem[i].goods_code;
                    btnGoodsItem.FlatStyle = FlatStyle.Flat;

                    btnGoodsItem.ForeColor = Color.White;
                    btnGoodsItem.BackColor = SystemColors.Highlight;
                    btnGoodsItem.TabStop = false;
                    btnGoodsItem.Margin = new Padding(2, 2, 2, 2);
                    btnGoodsItem.Padding = new Padding(0, 0, 0, 0);
                    btnGoodsItem.Dock = DockStyle.Fill;


                    if (mGoodsItem[i].columnspan == 1 | mGoodsItem[i].rowspan == 1)
                    {
                        btnGoodsItem.Font = font9;
                    }
                    else if (mGoodsItem[i].columnspan >= 3 & mGoodsItem[i].rowspan >= 3)
                    {
                        btnGoodsItem.Font = font20;
                    }
                    else
                    {
                        btnGoodsItem.Font = font12;
                    }


                    
                    if (mGoodsItem[i].cutout == "Y")  // 중지
                    {
                        btnGoodsItem.ForeColor = Color.White;
                        btnGoodsItem.BackColor = Color.White;

                        btnGoodsItem.Text = mGoodsItem[i].goods_name + "\n" + "[절판]";
                    }
                    else if (mGoodsItem[i].soldout == "Y")  // 품절
                    {
                        btnGoodsItem.ForeColor = Color.Gray;
                        btnGoodsItem.BackColor = Color.White;

                        btnGoodsItem.Text = mGoodsItem[i].goods_name + "\n" + "[품절]";
                    }
                    else
                    {
                        btnGoodsItem.Click += (sender, args) => ClickedGoodsItem(idx);
                    }
                    


                    tableLayoutPanelGoodsItem.Controls.Add(btnGoodsItem, mGoodsItem[i].column, mGoodsItem[i].row);
                    tableLayoutPanelGoodsItem.SetColumnSpan(btnGoodsItem, mGoodsItem[i].columnspan);
                    tableLayoutPanelGoodsItem.SetRowSpan(btnGoodsItem, mGoodsItem[i].rowspan);
                }
            }
 
            last_groupcode = groupcode;
        }



        private void ClickedGoodsItem(int i)
        {
            // 옵션항목 목록: frmOrderOption에서 채운다.

            mOrderOptionItemList.Clear();

            int order_cnt = 1;

            if (mGoodsItem[i].option_template_id != "")
            {
                frmOrderOption fForm = new frmOrderOption(mGoodsItem[i]);
                DialogResult ret = fForm.ShowDialog();

                if (ret == DialogResult.Cancel)
                {
                    return;
                }

                // 수량을 전역변수에서 받음 : fk30fgu9w04ufgw
                order_cnt = mOrderCntInOption;

            }


            MemOrderItem orderItem = new MemOrderItem();
            int lv_idx = (get_lvitem_idx(mGoodsItem[i].goods_code));  // 이미  동일 상품이 주문리스트뷰에 있는지

            if (lv_idx == -1)
            {

                //
                orderItem.option_name_description = "";   // 리스트뷰 상품항목 아랫줄에 표시
                orderItem.option_amt_description = "";    // 리스트뷰 단가항목 아랫줄에 표시


                
                // DB저장후에  : orderItem.optionNo 이 생김...
                

                if (mOrderOptionItemList.Count > 0)
                {
                    for (int k = 0;  k < mOrderOptionItemList.Count; k++)
                    {
                        orderItem.option_name_description += " " + mOrderOptionItemList[k].option_item_name;

                        orderItem.option_amt += (int)mOrderOptionItemList[k].amt;
                    }
                }

                //
                if (mOrderOptionItemList.Count > 0)
                {
                    orderItem.option_amt_description = orderItem.option_amt.ToString("N0");
                }
                else
                {
                    orderItem.option_amt_description = "";
                }

                //
                orderItem.option_item_cnt = mOrderOptionItemList.Count;
                orderItem.option_no = "";
                orderItem.orderOptionItemList = mOrderOptionItemList.ToList();  // ToList() : 리스트 복사, 참조가 아니고..

                orderItem.order_no = mOrderItemList.Count + 1;
                orderItem.goods_code = mGoodsItem[i].goods_code.ToString();
                orderItem.goods_name = mGoodsItem[i].goods_name;
                orderItem.ticket = mGoodsItem[i].ticket;
                orderItem.taxfree = mGoodsItem[i].taxfree;


                orderItem.cnt = order_cnt;

                orderItem.amt = mGoodsItem[i].amt;
                //orderItem.option_amt    // 위에서 세팅

                orderItem.dcr_type = "";
                orderItem.dcr_des = "";
                orderItem.dcr_value = 0;
                orderItem.shop_code = mGoodsItem[i].shop_code;

                //
                replace_mem_order_item(ref orderItem, "add");

                mOrderItemList.Add(orderItem);
                lvwOrderItem.SetObjects(mOrderItemList);

                lvwOrderItem.Items[lvwOrderItem.Items.Count - 1].EnsureVisible();
                lvwOrderItem.Items[lvwOrderItem.Items.Count - 1].Selected = true;

                // 전체할인이 있으면 주문항목 가장 아래로 이동???
                //move_dcr_e_last();

            }
            else
            {
                set_item_change_ordercnt(lv_idx, "add", 1);
                lvwOrderItem.Items[lv_idx].EnsureVisible();
                lvwOrderItem.Items[lv_idx].Selected = true;
            }

            ReCalculateAmount();
        }

        public static void replace_mem_order_item(ref MemOrderItem orderItem, String job)
        {
            //
            if (job == "add")
            {
                orderItem.lv_order_no = mOrderItemList.Count + 1;
            }
            else
            {
                // 유지
            }


            if (orderItem.dcr_des == "E")
            {
                // 전체할인 금액은 이전에 계산해서 들어옴
            }
            else
            {
                orderItem.dc_amount = get_dc_amount(orderItem);
            }
            


            orderItem.net_amount = ((orderItem.amt + orderItem.option_amt) * orderItem.cnt) - orderItem.dc_amount;

            orderItem.lv_goods_name = orderItem.goods_name;

            if (orderItem.dcr_des == "E")
            {
                orderItem.lv_cnt = "";
                orderItem.lv_amt = "";
                orderItem.lv_net_amount = "";
            }
            else
            {
                orderItem.lv_cnt = orderItem.cnt.ToString("N0");
                orderItem.lv_amt = orderItem.amt.ToString("N0");
                orderItem.lv_net_amount = orderItem.net_amount.ToString("N0");
            }

            orderItem.lv_dc_amount = orderItem.dc_amount.ToString("N0");


            //
            if (orderItem.dcr_type == "A")
            {
                orderItem.option_dc_amount_description = "₩" + orderItem.dcr_value.ToString("N0");
            }
            else if (orderItem.dcr_type == "R")
            {
                orderItem.option_dc_amount_description = orderItem.dcr_value + "%";
            }
            else
            {
                orderItem.option_dc_amount_description = "";
            }


        }

        //
        private void btnFlowCert_Click(object sender, EventArgs e)
        {
            if (mTheMode == "Local")
            {
                SetDisplayAlarm("W", "로컬모드에서 사용불가.");
                return;
            }


            ConsoleDisable();


            mPanelMiddle.Controls.Clear();
            mPanelMiddle.Visible = true;

            frmFlowCert fForm = new frmFlowCert() { TopLevel = false, TopMost = true };
            mPanelMiddle.Height = fForm.Height;
            mPanelMiddle.Controls.Add(fForm);
            fForm.Show();
        }

        private void btnFlowTicketing_Click(object sender, EventArgs e)
        {
            if (mTheMode == "Local")
            {
                SetDisplayAlarm("W", "로컬모드에서 사용불가.");
                return;
            }


            ConsoleDisable();

            mPanelMiddle.Controls.Clear();
            mPanelMiddle.Visible = true;

            frmFlowTicketing fForm = new frmFlowTicketing() { TopLevel = false, TopMost = true };
            mPanelMiddle.Height = fForm.Height;
            mPanelMiddle.Controls.Add(fForm);
            fForm.Show();

        }

        private void btnFlowCharging_Click(object sender, EventArgs e)
        {
            if (mTheMode == "Local")
            {
                SetDisplayAlarm("W", "로컬모드에서 사용불가.");
                return;
            }


            if (mTicketType == "PA")  //선불형
            {

            }
            else
            {
                MessageBox.Show("티켓유형 후불형으로 설정되어있습니다. \n선불형인 경우만 충전할 수 있습니다.", "thepos");
                return;
            }


            if (lvwOrderItem.Items.Count > 0)
            {
                SetDisplayAlarm("W", "주문항목이 있습니다. 항목을 취소하거나 완료 요망.");
                return;
            }

            ConsoleDisable();

            //#
            mPanelMiddle.Controls.Clear();
            mPanelMiddle.Visible = true;

            frmFlowCharging fForm = new frmFlowCharging() { TopLevel = false, TopMost = true };
            mPanelMiddle.Height = fForm.Height;
            mPanelMiddle.Controls.Add(fForm);
            fForm.Show();

        }

        private void btnFlowSettlement_Click(object sender, EventArgs e)
        {
            if (mTheMode == "Local")
            {
                SetDisplayAlarm("W", "로컬모드에서 사용불가.");
                return;
            }


            if (lvwOrderItem.Items.Count > 0)
            {
                SetDisplayAlarm("W", "주문항목이 있습니다. 항목을 취소하거나 완료 요망.");
                return;
            }

            ConsoleDisable();

            mPanelMiddle.Controls.Clear();
            mPanelMiddle.Visible = true;

            frmFlowSettlement fForm = new frmFlowSettlement() { TopLevel = false, TopMost = true };
            mPanelMiddle.Height = fForm.Height;
            mPanelMiddle.Controls.Add(fForm);
            fForm.Show();

        }

        private void btnFlowLocker_Click(object sender, EventArgs e)
        {
            if (mTheMode == "Local")
            {
                SetDisplayAlarm("W", "로컬모드에서 사용불가.");
                return;
            }


            ConsoleDisable();

            mPanelMiddle.Controls.Clear();
            mPanelMiddle.Visible = true;

            frmFlowLocker fForm = new frmFlowLocker() { TopLevel = false, TopMost = true };
            mPanelMiddle.Height = fForm.Height;
            mPanelMiddle.Controls.Add(fForm);
            fForm.Show();
        }


        //
        private void ClickedPayCash()
        {
            if (mLvwOrderItem.Items.Count == 0)
            {
                return;
            }


            if (mNetAmount < 0)
            {
                SetDisplayAlarm("W", "유효한 결제금액인지 확인요망.");
                return;
            }


            if (!get_amounts(out int t과세금액, out int t면세금액))
            {
                MessageBox.Show("과세금액, 면세금액 계산오류");
                return;
            }


            // 영업일자 등 선체크 
            if (!isPreCheck(out String error_msg))
            {
                MessageBox.Show(error_msg, "thepos");
                return;
            }



            countup_the_no();
            ConsoleDisable();

            //#
            int select_idx = -1;

            if (mPayClass == "CH")
            {
                select_idx = frmFlowCharging.mLvwFlow.SelectedItems[0].Index;
            }
            else if (mPayClass == "ST")
            {

            }

            mPanelPayment.Visible = true;
            mPanelPayment.Controls.Clear();


            frmPayCash fForm = new frmPayCash(mNetAmount, t과세금액, t면세금액, false, 1, true, select_idx) { TopLevel = false, TopMost = true };
            mPanelPayment.Height = fForm.Height;
            mPanelPayment.Controls.Add(fForm);
            fForm.Show();
            mPanelPayment.BringToFront();
        }

        private void ClickedPayCard()
        {
            if (mOrderItemList.Count == 0)
            {
                return;
            }


            if (mNetAmount < 0)
            {
                SetDisplayAlarm("W", "유효한 결제금액인지 확인요망.");
                return;
            }


            if (!get_amounts(out int t과세금액, out int t면세금액))
            {
                MessageBox.Show("과세금액, 면세금액 계산오류");
                return;
            }


            // 영업일자 등 선체크 
            if (!isPreCheck(out String error_msg))
            {
                MessageBox.Show(error_msg, "thepos");
                return;
            }


            countup_the_no();
            ConsoleDisable();

            //#
            int select_idx = -1;

            if (mPayClass == "CH")
            {
                select_idx = frmFlowCharging.mLvwFlow.SelectedItems[0].Index;
            }
            else if (mPayClass == "ST")
            {

            }

            mPanelPayment.Visible = true;
            mPanelPayment.Controls.Clear();

            frmPayCard fForm = new frmPayCard(mNetAmount, t과세금액, t면세금액, false, 1, true, select_idx) { TopLevel = false, TopMost = true };
            mPanelPayment.Height = fForm.Height;
            mPanelPayment.Controls.Add(fForm);
            fForm.Show();
            mPanelPayment.BringToFront();
        }

        private void ClickedPayPoint()
        {
            if (mTheMode == "Local")
            {
                SetDisplayAlarm("W", "로컬모드에서 사용불가.");
                return;
            }


            if (mOrderItemList.Count == 0)
            {
                return;
            }


            // 
            if (mPayClass != "OR")
            {
                MessageBox.Show("[충전, 정산]의 결제는 [포인트사용]을 할 수 없습니다.", "thepos");
                return;
            }


            if (mNetAmount == 0) return;


            // 영업일자 등 선체크 
            if (!isPreCheck(out String error_msg))
            {
                MessageBox.Show(error_msg, "thepos");
                return;
            }



            countup_the_no();
            ConsoleDisable();

            //#
            mPanelPayment.Visible = true;
            mPanelPayment.Controls.Clear();

            frmPayPoint fForm = new frmPayPoint() { TopLevel = false, TopMost = true };
            mPanelPayment.Height = fForm.Height;
            mPanelPayment.Controls.Add(fForm);
            fForm.Show();
            mPanelPayment.BringToFront();
        }

        private void ClickedPayComplex()
        {
            if (mOrderItemList.Count == 0)
            {
                return;
            }


            if (mNetAmount < 0)
            {
                SetDisplayAlarm("W", "유효한 결제금액인지 확인요망.");
                return;
            }


            if (!get_amounts(out int t과세금액, out int t면세금액))
            {
                MessageBox.Show("과세금액, 면세금액 계산오류");
                return;
            }


            // 영업일자 등 선체크 
            if (!isPreCheck(out String error_msg))
            {
                MessageBox.Show(error_msg, "thepos");
                return;
            }


            countup_the_no();
            ConsoleDisable();

            //#
            int select_idx = -1;

            if (mPayClass == "CH")
            {
                select_idx = frmFlowCharging.mLvwFlow.SelectedItems[0].Index;
            }
            else if (mPayClass == "ST")
            {

            }



            mPanelPayment.Visible = true;
            mPanelPayment.Controls.Clear();

            frmPayComplex fForm = new frmPayComplex(t과세금액, t면세금액, select_idx) { TopLevel = false, TopMost = true };
            mPanelPayment.Height = fForm.Height;
            mPanelPayment.Controls.Add(fForm);
            fForm.Show();
            mPanelPayment.BringToFront();

        }

        private void ClickedPayEasy()
        {
            if (mTheMode == "Local")
            {
                SetDisplayAlarm("W", "로컬모드에서 사용불가.");
                return;
            }


            if (mOrderItemList.Count == 0)
            {
                return;
            }


            if (mNetAmount < 0)
            {
                SetDisplayAlarm("W", "유효한 결제금액인지 확인요망.");
                return;
            }

            if (!get_amounts(out int t과세금액, out int t면세금액))
            {
                MessageBox.Show("과세금액, 면세금액 계산오류");
                return;
            }


            // 영업일자 등 선체크 
            if (!isPreCheck(out String error_msg))
            {
                MessageBox.Show(error_msg, "thepos");
                return;
            }


            countup_the_no();
            ConsoleDisable();

            //#
            int select_idx = -1;

            if (mPayClass == "CH")
            {
                select_idx = frmFlowCharging.mLvwFlow.SelectedItems[0].Index;
            }
            else if (mPayClass == "ST")
            {

            }

            mPanelPayment.Visible = true;
            mPanelPayment.Controls.Clear();

            frmPayEasy fForm = new frmPayEasy(mNetAmount, t과세금액, t면세금액, false, 1, true, select_idx) { TopLevel = false, TopMost = true };
            mPanelPayment.Height = fForm.Height;
            mPanelPayment.Controls.Add(fForm);
            fForm.Show();
            mPanelPayment.BringToFront();

        }



        public static Boolean isPreCheck(out String error_msg)
        {
            error_msg = "";

            String sUrl = "preCheck?siteId=" + mSiteId + "&posNo=" + mPosNo + "&bizDt=" + mBizDate;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["preCheck"].ToString();
                    JArray arr = JArray.Parse(data);

                    String resp_code = arr[0]["respCode"].ToString();

                    if (resp_code == "00")
                    {
                        return true;
                    }
                    else
                    {
                        error_msg = "관리자 문의바랍니다.\r\n" + arr[0]["respMsg"].ToString(); // 99 : 마감후 집계완료상태입니다. 
                        return false;
                    }
                }
                else if (mObj["resultCode"].ToString() == "660")
                {
                    error_msg = "관리자 문의바랍니다.\r\n영업일자 검증 오류. 재로그인 필요합니다.";
                    return false;
                }
                else
                {
                    error_msg = "관리자 문의바랍니다.\r\n시스템오류. 영업개시 검증 오류";
                    return false;
                }
            }
            else
            {
                error_msg = "관리자 문의바랍니다.\r\n시스템오류. 영업개시 검증 오류";
                return false;
            }
        }



        public static bool CancelOrderSettle( String ticket_no)
        {
            List<String> list_the_no = new List<String>();
            int the_no_cnt = 0;
            

            // orderItem
            String sUrl = "orderItem?siteId=" + mSiteId + "&ticketNo=" + ticket_no + "&payClass=US&tranType=A";
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orderItems"].ToString();
                    JArray arr = JArray.Parse(data);


                    for (int i = 0; i < arr.Count; i++)
                    {

                        if (arr[i]["isCancel"].ToString() != "Y")   // 이미 취소된 포인트 사용은 제외.
                        {
                            MemOrderItem orderItem = new MemOrderItem();



                            // 취소추가
                            Dictionary<string, string> parameters = new Dictionary<string, string>();
                            parameters.Clear();
                            parameters["siteId"] = mSiteId;
                            parameters["posNo"] = mPosNo;
                            parameters["bizDt"] = mBizDate;
                            parameters["theNo"] = arr[i]["theNo"].ToString();
                            parameters["refNo"] = arr[i]["refNo"].ToString();
                            parameters["tranType"] = "C";
                            parameters["orderDate"] = get_today_date();
                            parameters["orderTime"] = get_today_time();
                            parameters["goodsCode"] = arr[i]["goodsCode"].ToString();
                            parameters["goodsName"] = arr[i]["goodsName"].ToString();
                            parameters["cnt"] = arr[i]["cnt"].ToString();
                            parameters["amt"] = arr[i]["amt"].ToString();
                            parameters["optionAmt"] = arr[i]["optionAmt"].ToString();  //#

                            parameters["ticketYn"] = arr[i]["ticketYn"].ToString();
                            parameters["taxFree"] = arr[i]["taxFree"].ToString();
                            parameters["dcAmount"] = arr[i]["dcAmount"].ToString();
                            parameters["dcrType"] = arr[i]["dcrType"].ToString();
                            parameters["dcrDes"] = arr[i]["dcrDes"].ToString();
                            parameters["dcrValue"] = arr[i]["dcrValue"].ToString();
                            parameters["payClass"] = arr[i]["payClass"].ToString();
                            parameters["ticketNo"] = arr[i]["ticketNo"].ToString();
                            
                            parameters["isCancel"] = "y";                       // y 정산취소 Y 일반취소
                            parameters["shopCode"] = arr[i]["shopCode"].ToString();
                            parameters["shopOrderNo"] = arr[i]["shopOrderNo"].ToString(); // 포인트사용시 부여된 번호를 정산에 그대로 복사
                            parameters["optionNo"] = arr[i]["optionNo"].ToString();      // 포인트사용시 부여된 번호를 정산에 그대로 복사

                            if (mRequestPost("orderItem", parameters))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {
                                }
                                else
                                {
                                    MessageBox.Show("오류 orderItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                                return false;
                            }


                            //
                            //  한번에 orderItem 취소 마킹 -> 이러면 안됨.. 일반취소건이 있을경우 덮어쓰게됨. 개별로 전환...
                            Dictionary<string, string> param = new Dictionary<string, string>();
                            param.Clear();
                            param["siteId"] = mSiteId;
                            param["bizDt"] = ticket_no.Substring(4, 8);
                            param["ticketNo"] = ticket_no;
                            param["theNo"] = arr[i]["theNo"].ToString();
                            param["tranType"] = "A";
                            param["payClass"] = "US";
                            param["isCancel"] = "y";   // y 정산취소

                            if (mRequestPatch("orderItem", param))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {
                                }
                                else
                                {
                                    MessageBox.Show("오류 order\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                                return false;
                            }



                            list_the_no.Add(arr[i]["theNo"].ToString());
                        }

                    }
                }
                else
                {
                    MessageBox.Show("데이터 오류. orderItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orderItem\n\n" + mErrorMsg, "thepos");
                return false;
            }





            // order
            list_the_no.Distinct().ToList();

            for (int i = 0; i < list_the_no.Count; i++)
            {
                sUrl = "orders?siteId=" + mSiteId + "&theNo=" + list_the_no[i] + "&tranType=A";
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        dbOrder order = new dbOrder();

                        String data = mObj["orders"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count == 1)
                        {
                            order.site_id = arr[0]["siteId"].ToString();
                            order.pos_no = arr[0]["posNo"].ToString();
                            order.biz_dt = arr[0]["bizDt"].ToString();
                            order.the_no = arr[0]["theNo"].ToString();
                            order.ref_no = arr[0]["refNo"].ToString();
                            order.tran_type = arr[0]["tranType"].ToString();
                            order.order_date = arr[0]["orderDate"].ToString();
                            order.order_time = arr[0]["orderTime"].ToString();
                            order.cnt = convert_number(arr[0]["cnt"].ToString());
                            order.is_cancel = arr[0]["isCancel"].ToString();


                            // 취소추가
                            Dictionary<string, string> parameters = new Dictionary<string, string>();
                            parameters.Clear();
                            parameters["siteId"] = mSiteId;
                            parameters["posNo"] = order.pos_no;
                            parameters["bizDt"] = mBizDate;
                            parameters["theNo"] = order.the_no;
                            parameters["refNo"] = order.ref_no;
                            parameters["tranType"] = "C";
                            parameters["orderDate"] = get_today_date();
                            parameters["orderTime"] = get_today_time();
                            parameters["cnt"] = order.cnt + "";
                            parameters["isCancel"] = "y";

                            if (mRequestPost("orders", parameters))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {
                                }
                                else
                                {
                                    MessageBox.Show("오류 orders\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("시스템오류. orders\n\n" + mErrorMsg, "thepos");
                                return false;
                            }


                            // 취소 마킹
                            parameters.Clear();
                            parameters["siteId"] = mSiteId;
                            parameters["bizDt"] = mBizDate;
                            parameters["theNo"] = order.the_no;
                            parameters["tranType"] = "A";
                            parameters["isCancel"] = "y";

                            if (mRequestPatch("orders", parameters))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {
                                }
                                else
                                {
                                    MessageBox.Show("오류 orders\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("시스템오류. orders\n\n" + mErrorMsg, "thepos");
                                return false;
                            }

                        }
                        else
                        {
                            MessageBox.Show("오류. order\n\n arr.Count = " + arr.Count);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                        return false;
                    }

                }
            }


            return true;
        }


        public static void set_shop_order_no_on_orderitem(out int dcAmount)
        {
            dcAmount = 0;

            List<String> shop_code_list = new List<String>();
            List<String> order_no_list = new List<String>();


            for (int i = 0; i < mOrderItemList.Count; i++)
            {
                if (isExistOrderPrinter(mOrderItemList[i].shop_code) & mOrderItemList[i].ticket != "Y")
                {
                    shop_code_list.Add(mOrderItemList[i].shop_code);
                }

                dcAmount += mOrderItemList[i].dc_amount;
            }

            //#  이거때문에 주문번호가 시리얼하지않고 중간에 빈다. 2024-03-07
            //shop_code_list.Distinct().ToList();
            shop_code_list = shop_code_list.Distinct().ToList();


            for (int i = 0; i < shop_code_list.Count; i++)
            {
                order_no_list.Add(get_new_order_no());
            }


            for (int i = 0; i < mOrderItemList.Count; i++)
            {
                for (int k = 0; k < order_no_list.Count; k++)
                {
                    if (mOrderItemList[i].shop_code == shop_code_list[k] & mOrderItemList[i].ticket != "Y")
                    {
                        MemOrderItem orderItem = mOrderItemList[i];
                        orderItem.shop_order_no = order_no_list[k];
                        mOrderItemList[i] = orderItem;
                    }
                }
            }
        }


        public static MemOrderItem[] getMemOrderItemArr(out int dcAmount)
        {
            dcAmount = 0;


            // OrderItem 테이블
            // 주문 리스트뷰를 배열로 변환
            MemOrderItem[] memOrderItemArr = new MemOrderItem[mOrderItemList.Count];

            for (int i = 0; i < mOrderItemList.Count; i++)
            {
                memOrderItemArr[i] = mOrderItemList[i];

                dcAmount += memOrderItemArr[i].dc_amount;
            }
            

            // 업장코드별로 정렬
            bool order_sort_complete = false;
            MemOrderItem memOrderItemTemp;

            while (!order_sort_complete)
            {
                order_sort_complete = true;
                for (int i = 0; i < memOrderItemArr.Length - 1; i++)
                {
                    if (string.Compare(memOrderItemArr[i].shop_code, memOrderItemArr[i + 1].shop_code) == 1)  // ascending
                    {
                        memOrderItemTemp = memOrderItemArr[i];
                        memOrderItemArr[i] = memOrderItemArr[i + 1];
                        memOrderItemArr[i + 1] = memOrderItemTemp;

                        order_sort_complete = false;
                    }
                }
            }


            // 업장주문번호 부여
            // - 조건에 맞는 건만 부여함.
            if (mPayClass == "OR" | mPayClass == "US")
            {
                if (isExistOrderPrinter(memOrderItemArr[0].shop_code) & memOrderItemArr[0].ticket != "Y")
                    memOrderItemArr[0].shop_order_no = get_new_order_no();
                else
                    memOrderItemArr[0].shop_order_no = "";


                for (int i = 0; i < memOrderItemArr.Length - 1; i++)
                {
                    if (string.Compare(memOrderItemArr[i].shop_code, memOrderItemArr[i + 1].shop_code) == 0)
                    {
                        memOrderItemArr[i + 1].shop_order_no = memOrderItemArr[i].shop_order_no;
                    }
                    else
                    {
                        if (isExistOrderPrinter(memOrderItemArr[i+ 1].shop_code) & memOrderItemArr[i + 1].ticket != "Y")
                            memOrderItemArr[i + 1].shop_order_no = get_new_order_no();
                        else
                            memOrderItemArr[i + 1].shop_order_no = "";
                    }
                }
            }

            return memOrderItemArr;
        }


        public static bool isExistOrderPrinter(String shop_code)
        {
            if (shop_code == "")
            {
                return false;
            }

            //
            for (int i = 0; i < mShop.Length; i++)
            {
                if (mShop[i].shop_code == shop_code)
                {
                    if (mShop[i].printer_type == "")
                        return false;
                    else
                        return true;
                }
            }

            return false;
        }



        public static int SaveOrder(String ticket_no)
        {

            int return_cnt = 0;

            if (mTheMode == "Local")
            {
                return_cnt = SaveOrder_Local(ticket_no);  // order. orderitem
            }
            else
            {
                return_cnt = SaveOrder_Server(ticket_no);  // order. orderitem
            }


            return return_cnt;  // 주문항목수
        }

        public static int SaveOrder_Local(String ticket_no)
        {
            try
            {
                String sql = "INSERT INTO orders (siteId, posNo, bizDt, theNo, refNo, tranType, orderDate, orderTime, cnt, isCancel) " +
                                "values ('" + mSiteId + "','" + mPosNo + "','" + mBizDate + "','" + mTheNo + "','" + mRefNo + "','A','" + get_today_date() + "','" + get_today_time() + "'," + mOrderItemList.Count + ", '')";
                sql_excute_local_db(sql);

                //
                for (int i = 0; i < mOrderItemList.Count; i++)
                {
                    String t_option_no = "";

                    if (mOrderItemList[i].orderOptionItemList.Count > 0)
                    {
                        t_option_no = mTheNo + i.ToString("00");
                    }


                    sql = "INSERT INTO orderItem (siteId, posNo, bizDt, theNo, refNo, tranType, orderDate, orderTime, goodsCode, goodsName, cnt, amt, optionAmt, ticketYn, taxFree, dcAmount, dcrType, dcrDes, dcrValue, payClass, ticketNo, isCancel, shopCode, shopOrderNo, optionNo) " +
                                "values ('" + mSiteId + "','" + mPosNo + "','" + mBizDate + "','" + mTheNo + "','" + mRefNo + "','A','" + get_today_date() + "','" + get_today_time() + "','" + mOrderItemList[i].goods_code + "','" + mOrderItemList[i].goods_name + "'," + mOrderItemList[i].cnt + "," + mOrderItemList[i].amt + "," + mOrderItemList[i].option_amt + "," +
                                "'" + mOrderItemList[i].ticket + "','" + mOrderItemList[i].taxfree + "'," + mOrderItemList[i].dc_amount + ",'" + mOrderItemList[i].dcr_type + "','" + mOrderItemList[i].dcr_des + "'," + mOrderItemList[i].dcr_value + ",'" + mPayClass + "','" + ticket_no + "','" + "','" + mOrderItemList[i].shop_code + "','" + mOrderItemList[i].shop_order_no + "','" + t_option_no + "')";
                    sql_excute_local_db(sql);


                    //// 옵션상품이 경우
                    for (int k = 0; k < mOrderItemList[i].orderOptionItemList.Count; k++)
                    {
                        sql = "INSERT INTO orderOptionItem (siteId, posNo, bizDt, theNo, refNo, optionNo, orderDate, orderTime, goodsCode, optionCode, optionName, optionItemNo, optionItemName, cnt, amt, isCancel) " +
                                    "values ('" + mSiteId + "','" + mPosNo + "','" + mBizDate + "','" + mTheNo + "','" + mRefNo + "','" + t_option_no + "','" + get_today_date() + "','" + get_today_time() + "','" +
                                    mOrderItemList[i].goods_code + "','" + mOrderItemList[i].orderOptionItemList[k].option_code + "','" + mOrderItemList[i].orderOptionItemList[k].option_name + "'," + mOrderItemList[i].orderOptionItemList[k].option_item_no + ",'" + mOrderItemList[i].orderOptionItemList[k].option_item_name + "'," + mOrderItemList[i].cnt + "," + mOrderItemList[i].amt + ",'')";
                        sql_excute_local_db(sql);
                    }
                }
            }
            catch (Exception e) 
            {
                MessageBox.Show("로컬데이터 오류. " + e.Message);
                return -1;
            }

            return mOrderItemList.Count;

        }

        public static int SaveOrder_Server(String ticket_no)
        {

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Clear();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = mPosNo;
            parameters["bizDt"] = mBizDate;
            parameters["theNo"] = mTheNo;
            parameters["refNo"] = mRefNo;
            parameters["tranType"] = "A";
            parameters["orderDate"] = get_today_date();
            parameters["orderTime"] = get_today_time();
            parameters["cnt"] = mOrderItemList.Count + "";
            parameters["isCancel"] = "";
            if (mRequestPost("orders", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                }
                else
                {
                    MessageBox.Show("오류 order\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return -1;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return -1;
            }



            // 서버저장
            for (int i = 0; i < mOrderItemList.Count; i++)
            {
                String t_option_no = "";

                //??
                if (mOrderItemList[i].option_item_cnt > 0)
                {
                    if (mOrderItemList[i].orderOptionItemList.Count > 0)
                    {
                        t_option_no = mTheNo + i.ToString("00");
                    }
                }



                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["posNo"] = mPosNo;
                parameters["bizDt"] = mBizDate;
                parameters["theNo"] = mTheNo;
                parameters["refNo"] = mRefNo;
                parameters["tranType"] = "A";
                parameters["orderDate"] = get_today_date();
                parameters["orderTime"] = get_today_time();
                parameters["goodsCode"] = mOrderItemList[i].goods_code;
                parameters["goodsName"] = mOrderItemList[i].goods_name;
                parameters["cnt"] = mOrderItemList[i].cnt + "";
                parameters["amt"] = mOrderItemList[i].amt + "";
                parameters["optionAmt"] = mOrderItemList[i].option_amt + "";   //
                parameters["ticketYn"] = mOrderItemList[i].ticket;
                parameters["taxFree"] = mOrderItemList[i].taxfree;
                parameters["dcAmount"] = mOrderItemList[i].dc_amount + "";
                parameters["dcrType"] = mOrderItemList[i].dcr_type;
                parameters["dcrDes"] = mOrderItemList[i].dcr_des;
                parameters["dcrValue"] = mOrderItemList[i].dcr_value + "";
                parameters["payClass"] = mPayClass;  //
                parameters["ticketNo"] = ticket_no;  //
                parameters["isCancel"] = "";
                parameters["shopCode"] = mOrderItemList[i].shop_code;

                parameters["shopOrderNo"] = mOrderItemList[i].shop_order_no;  // 업장주문번호
                parameters["optionNo"] = t_option_no;

                if (mRequestPost("orderItem", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                    }
                    else
                    {
                        MessageBox.Show("오류 orderItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return -1;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return -1;
                }

                // 옵션상품 경우
                for (int k = 0; k < mOrderItemList[i].orderOptionItemList.Count; k++)
                {
                    parameters.Clear();
                    parameters["siteId"] = mSiteId;
                    parameters["posNo"] = mPosNo;
                    parameters["bizDt"] = mBizDate;
                    parameters["theNo"] = mTheNo;
                    parameters["refNo"] = mRefNo;
                    parameters["optionNo"] = t_option_no;

                    parameters["orderDate"] = get_today_date();
                    parameters["orderTime"] = get_today_time();

                    parameters["goodsCode"] = mOrderItemList[i].goods_code;

                    parameters["optionCode"] = mOrderItemList[i].orderOptionItemList[k].option_code;
                    parameters["optionName"] = mOrderItemList[i].orderOptionItemList[k].option_name;
                    parameters["optionItemNo"] = mOrderItemList[i].orderOptionItemList[k].option_item_no + "";
                    parameters["optionItemName"] = mOrderItemList[i].orderOptionItemList[k].option_item_name;

                    parameters["cnt"] = mOrderItemList[i].cnt + "";
                    parameters["amt"] = mOrderItemList[i].orderOptionItemList[k].amt + "";
                    parameters["isCancel"] = "";


                    if (mRequestPost("orderOptionItem", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                        }
                        else
                        {
                            MessageBox.Show("오류 orderOptionItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                            return -1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                        return -1;
                    }
                }
            }

            return mOrderItemList.Count;
        }


        public static bool SavePayment(int paySeq, String payType, int netAmount, int dcAmount)
        {
            if (mTheMode == "Local")
            {
                if (!SavePayment_Local(paySeq, payType, netAmount, dcAmount))
                {
                    return false;
                }
            }
            else
            {
                if (!SavePayment_Server(paySeq, payType, netAmount, dcAmount))
                {
                    return false;
                }
            }

            return true;
        }


        public static bool SavePayment_Local(int paySeq, String payType, int amount, int dcAmount)
        {
            //!

            if (paySeq == 1)
            {
                int amount_cash = 0, amount_card = 0, amount_easy = 0, amount_point = 0;

                if (payType == "Cash") amount_cash = amount;
                else if (payType == "Card") amount_card = amount;
                else if (payType == "Easy") amount_easy = amount;
                else if (payType == "Point") amount_point = amount;

                String sql = "INSERT INTO payment (siteId, posNo, bizDt, theNo, refNo, payDate, payTime, tranType, payClass, billNo, netAmount, amountCash, amountCard, amountEasy, amountPoint, dcAmount, isCancel) " +
                             "values ('" + mSiteId + "','" + mPosNo + "','" + mBizDate + "','" + mTheNo + "','" + mRefNo + "','" + get_today_date() + "','" + get_today_time() + "','A','" + mPayClass + "','" + mTheNo.Substring(14, 6) + "'," + amount + "," + amount_cash + "," + amount_card + "," + amount_easy + "," + amount_point + "," + dcAmount + ",'')";
                sql_excute_local_db(sql);

            }
            else
            {
                int amount_net = 0;
                int amount_cash = 0;
                int amount_card = 0;
                int amount_easy = 0;
                int amount_point = 0;



                SQLiteDataReader dr = sql_select_local_db("SELECT * FROM payment WHERE theNo='" + mTheNo + "'");
                if (dr.Read())
                {
                    amount_net = convert_number(dr["netAmount"].ToString());
                    amount_cash = convert_number(dr["amountCash"].ToString());
                    amount_card = convert_number(dr["amountCard"].ToString());
                    amount_easy = convert_number(dr["amountEasy"].ToString());
                    amount_point = convert_number(dr["amountPoint"].ToString());
                }
                else
                {
                    MessageBox.Show("결제데이터 오류. payment", "thepos");
                    return false;
                }

                dr.Close();




                amount_net += amount;

                if (payType == "Cash") amount_cash += amount;
                else if (payType == "Card") amount_card += amount;
                else if (payType == "Easy") amount_easy += amount;
                else if (payType == "Point") amount_point += amount;




                String sql = "UPDATE payment SET netAmount = " + amount_net + ", amountCash = " + amount_cash + ", amountCard = " + amount_card + ", amountEasy = " + amount_easy + ", amountPoint = " + amount_point +
                            " WHERE theNo='" + mTheNo + "' AND tranType = 'A' ";
                int ret = sql_excute_local_db(sql);


            }

            return true;

        }

        public static bool SavePayment_Server(int paySeq, String payType, int amount, int dcAmount)
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
                parameters["billNo"] = mTheNo.Substring(14, 6);
                parameters["netAmount"] = amount + "";


                int amount_cash = 0, amount_card = 0, amount_easy = 0, amount_point = 0, amount_cert = 0;

                if (payType == "Cash") amount_cash = amount;
                else if (payType == "Card") amount_card = amount;
                else if (payType == "Easy") amount_easy = amount;
                else if (payType == "Point") amount_point = amount;
                else if (payType == "Cert") amount_cert = amount;

                parameters["amountCash"] = amount_cash + "";
                parameters["amountCard"] = amount_card + "";
                parameters["amountEasy"] = amount_easy + "";
                parameters["amountPoint"] = amount_point + "";
                parameters["amountCert"] = amount_cert + "";

                parameters["dcAmount"] = dcAmount + "";
                parameters["isCancel"] = "";


                if (mRequestPost("payment", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {

                    }
                    else
                    {
                        MessageBox.Show("오류 payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return false;
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
                int amount_cert = 0;


                // GET
                String sUrl = "payment?siteId=" + mSiteId + "&theNo=" + mTheNo;

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
                        amount_cert = convert_number(arr[0]["amountCert"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("결제데이터 오류. payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
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
                else if (payType == "Cert") amount_cert += amount;


                //
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["siteId"] = mSiteId;
                parameters["bizDt"] = mBizDate;
                parameters["theNo"] = mTheNo;
                parameters["tranType"] = "A";

                parameters["netAmount"] = amount_net + "";
                parameters["amountCash"] = amount_cash + "";
                parameters["amountCard"] = amount_card + "";
                parameters["amountEasy"] = amount_easy + "";
                parameters["amountPoint"] = amount_point + "";
                parameters["amountCert"] = amount_cert + "";

                if (mRequestPatch("payment", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {

                    }
                    else
                    {
                        MessageBox.Show("결제데이터 오류. payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
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

        public static int SaveTicketFlow(String ticket_no, String pay_class, String settle_class, int settle_amt)  
        {
            // settle_class, settel_amt 는 정상시에만 사용
            // 정산의 경우 subClass : 사용 US,  충전 CH
            // 사용승인, 충전취소 -> 구분하여 업데이트


            if (pay_class == "OR") // 주문(접수-발권)
            {
                int ticket_seq = 0;
                String t_ticket_no = "";

                for (int i = 0; i < mOrderItemList.Count; i++)
                {
                    MemOrderItem orderItem = mOrderItemList[i];

                    if (orderItem.ticket == "Y")
                    {
                        for (int k = 0; k < orderItem.cnt; k++)
                        {
                            ticket_seq++;

                            if (mTicketMedia == "BC")  // 띠지
                            {
                                // 티켓번호 + 2자리로 변경
                                //t_ticket_no = mTheNo + ticket_seq.ToString("000");
                                t_ticket_no = mTheNo + ticket_seq.ToString("00");
                            }
                            else  // 팔찌
                            {
                                //? 팔찌이면 스케너 입력로직 필요
                                MessageBox.Show("스캐너 팔찌 입력입니다... ");

                                //t_ticket_no = "";  //? 스캐너로 읽어서 여기에...   theno + 팔찌번호?
                                t_ticket_no = mTheNo + ticket_seq.ToString("00");  //? 임시
                            }

                            Dictionary<string, string> parameters = new Dictionary<string, string>();
                            parameters.Clear();
                            parameters["siteId"] = mSiteId;
                            parameters["bizDt"] = mBizDate;
                            parameters["posNo"] = mPosNo;
                            parameters["theNo"] = mTheNo;
                            parameters["refNo"] = mRefNo;

                            parameters["ticketNo"] = t_ticket_no;
                            parameters["bangleNo"] = "";  //? 팔찌인 경우 - 값변경 필요
                            parameters["ticketingDt"] = get_today_date() + get_today_time();
                            parameters["chargeDt"] = "";
                            parameters["settlementDt"] = "";

                            parameters["pointChargeCnt"] = "0";
                            parameters["pointUsageCnt"] = "0";

                            parameters["pointCharge"] = "0";
                            parameters["pointUsage"] = "0";
                            parameters["settlePointCharge"] = "0";
                            parameters["settlePointUsage"] = "0";

                            parameters["goodsCode"] = orderItem.goods_code;
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
                                    MessageBox.Show("오류 ticketFlow\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                    return -1;
                                }
                            }
                            else
                            {
                                MessageBox.Show("시스템오류 ticketFlow\n\n" + mErrorMsg, "thepos");
                                return -1;
                            }

                            //
                            // 에러발생에 대비해서 인쇄출력은 가능한 마지막에 순서...
                            if (mTicketMedia == "BC")  // 띠지
                            {
                                print_ticket(t_ticket_no, orderItem.goods_code);
                            }
                        } 
                    }
                }

                return ticket_seq;

            }
            else if (pay_class == "CH") // 충전
            {
                MemOrderItem orderItem = mOrderItemList[0];
                int charge_amt = orderItem.amt;
                String t_no = orderItem.ticket_no;

                int prev_point_charge_cnt = 0;
                int prev_point_charge = 0;

                // GET
                String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&ticketNo=" + t_no;

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

                        prev_point_charge_cnt = convert_number(arr[0]["pointChargeCnt"].ToString());
                        prev_point_charge = convert_number(arr[0]["pointCharge"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("티켓데이터 충전 오류.\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. ticketFlow\n\n" + mErrorMsg, "thepos");
                }


                // PATCH
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["bizDt"] = mBizDate;
                parameters["ticketNo"] = t_no;
                parameters["flowStep"] = "2";
                parameters["pointChargeCnt"] = (++prev_point_charge_cnt) + "";
                parameters["pointCharge"] = (prev_point_charge + charge_amt) + "";
                parameters["chargeDt"] = get_today_date() + get_today_time();


                if (mRequestPatch("ticketFlow", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        //MessageBox.Show("정상 충전 완료.", "thepos");
                        return 1;
                    }
                    else
                    {
                        MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return -1;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return -1;
                }


            }
            else if (pay_class == "US") // 포인트 사용
            {
                
                int usage_amout = mNetAmount;
                String t_no = ticket_no;

                int prev_point_usage_cnt = 0;
                int prev_point_usage = 0;

                // GET
                String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&ticketNo=" + t_no;

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

                        prev_point_usage_cnt = convert_number(arr[0]["pointUsageCnt"].ToString());
                        prev_point_usage = convert_number(arr[0]["pointUsage"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("티켓데이터 오류.\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. ticketFlow\n\n" + mErrorMsg, "thepos");
                }



                // PATCH
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["bizDt"] = mBizDate;
                parameters["ticketNo"] = t_no;
                parameters["flowStep"] = "3";
                parameters["pointUsageCnt"] = (++prev_point_usage_cnt) + "";
                parameters["pointUsage"] = prev_point_usage + usage_amout + "";

                if (mRequestPatch("ticketFlow", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        //MessageBox.Show("정상 사용 완료.", "thepos");
                        return 1;
                    }
                    else
                    {
                        MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return -1;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return -1;
                }

            }
            else if (pay_class == "ST") // 정산
            {

                String t_no = ticket_no;

                int settle_point_usage = 0;
                int settle_point_charge = 0;
                int point_usage = 0;
                int point_charge = 0;
                String flow_step = "";
                String open_locker = "";



                // GET
                String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&ticketNo=" + t_no;

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["ticketFlows"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count != 1)
                        {
                            MessageBox.Show("티켓데이터 정산 오류 \n ticketFlowCnt=" + arr.Count, "thepos");
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
                        MessageBox.Show("티켓데이터 오류.\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. ticketFlow\n\n" + mErrorMsg, "thepos");
                }



                if (settle_class == "US")  // 정산시 사용분 결제
                {
                    settle_point_usage += settle_amt;
                }
                else if (settle_class == "CH")  // 정산시 충전분 취소
                {
                    settle_point_charge += settle_amt;
                }


                if (point_usage == settle_point_usage & point_charge == settle_point_charge)
                {
                    flow_step = "9";                // 접수0 - 발급1 - *충전2 - 사용중3 - 정산중4 - 정산(완료)9

                    if (mTicketType == "PD") // 후불
                    {
                        open_locker = "1"; //? 락커  폐쇄0 개방1
                    }
                }
                else
                {
                    flow_step = "4"; 
                }


                // PATCH
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["bizDt"] = mBizDate;
                parameters["ticketNo"] = t_no;
                parameters["settlement_dt"] = get_today_date() + get_today_time();

                parameters["settlePointCharge"] = settle_point_charge + "";
                parameters["settlePointUsage"] = settle_point_usage + "";

                parameters["flowStep"] = flow_step;



                if (mRequestPatch("ticketFlow", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        //MessageBox.Show("정상 정산 완료.", "thepos");
                        return 1;
                    }
                    else
                    {
                        MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
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

        public static int CheckCancelTicketFlow(String auth_pay_class, String the_no, String ticket_no)
        {
            // return int
            // 1 취소대상, 0 취소대상없음, -1 취소불가, -9 error


            //발급(기본) 1 - *충전2 - 사용중3 - 정산중4 - 정산완료9

            if (auth_pay_class == "OR")  // 주문건의 취소
            {
                String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&theNo=" + the_no;

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["ticketFlows"].ToString();
                        JArray arr = JArray.Parse(data);

                        int MaxflowStep = 0;

                        if (arr.Count > 0)
                        {
                            for (int i = 0; i < arr.Count; i++)
                            {
                                if (convert_number(arr[i]["flowStep"].ToString()) > MaxflowStep)
                                {
                                    MaxflowStep = convert_number(arr[0]["flowStep"].ToString());
                                }
                            }

                            if (MaxflowStep == 1)
                            {
                                return 1;
                            }
                            else
                            {
                                MessageBox.Show("티켓사용이후 주문취소불가.", "thepos");
                                return -1;
                            }
                        }
                        else
                        {
                            // 티켓 대상없음
                            return 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("데이터 오류2. ticketFlow", "thepos");
                        return -9;
                    }
                }
                else
                {
                    MessageBox.Show("데이터 오류3. ticketFlow", "thepos");
                    return -9;
                }

            }
            else if (auth_pay_class == "CH")  // 충전건의 취소
            {
                int flowstep = get_flowstep_by_ticketno(ticket_no);
                // X : step,  -9 :error,  0 : 대상없음, -1 : 취소불가

                if (flowstep == -9)
                {
                    MessageBox.Show("티켓데이터 오류. ticketFlow.", "thepos");
                    return -9;
                }

                if (flowstep == 0) // 취소대상없음
                {
                    return 0;
                }

                //
                if (flowstep > 2)
                {
                    MessageBox.Show("포인트사용이후 충전취소불가.", "thepos");
                    return -1;
                }

                return 1;  // 정상취소 가능 

            }
            else if (auth_pay_class == "US")  // 포인트사용건의 취소
            {
                int flowstep = get_flowstep_by_ticketno(ticket_no);
                // X : step,  -9 :error,  0 : 대상없음, -1 : 취소불가

                if (flowstep == -9)
                {
                    MessageBox.Show("티켓데이터 오류. ticketFlow.", "thepos");
                    return -9;
                }

                if (flowstep == 0) // 취소대상없음
                {
                    return 0;
                }

                //
                if (flowstep > 3)
                {
                    MessageBox.Show("정산이후 포인트사용 취소불가.", "thepos");
                    return -1;
                }

                return 1;

            }
            else if (auth_pay_class == "ST")  // 포인트사용분의 승인건의 취소
            {
                //? 고민중.. 취소불가 or 취소가능(정산중일경우)


                int flowstep = get_flowstep_by_ticketno(ticket_no);
                // X : step,  -9 :error,  0 : 대상없음, -1 : 취소불가

                if (flowstep == -9)
                {
                    MessageBox.Show("티켓데이터 오류. ticketFlow.", "thepos");
                    return -9;
                }

                if (flowstep == 0) // 취소대상없음
                {
                    return 0;
                }


                //
                if (flowstep > 4) // 9:정산완료
                {
                    MessageBox.Show("정산완료된 건입니다. 단독 취소불가.", "thepos");
                    return -1;
                }

                return 1;
            }

            return 0;
        }


        public static void CancelTicketFlow(String auth_pay_class, String the_no, String ticket_no, int cancel_amount)
        {
            //접수0 - 발급1 - *충전2 - 사용중3 - 정산중4 - 정산완료9

            if (auth_pay_class == "OR")  // 주문건의 취소
            {
                // 주문취소의 Action의 delete
                String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&theNo=" + the_no;

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["ticketFlows"].ToString();
                        JArray arr = JArray.Parse(data);

                        int MaxflowStep = 0;

                        if (arr.Count > 0)
                        {
                            for (int i = 0; i < arr.Count; i++)
                            {
                                if (convert_number(arr[i]["flowStep"].ToString()) > MaxflowStep)
                                {
                                    MaxflowStep = convert_number(arr[0]["flowStep"].ToString());
                                }
                            }

                            if (MaxflowStep == 1)
                            {
                                // delete
                                Dictionary<string, string> parameters = new Dictionary<string, string>();
                                parameters["siteId"] = mSiteId;
                                parameters["bizDt"] = mBizDate;
                                parameters["theNo"] = the_no;

                                if (mRequestDelete("ticketFlow", parameters))
                                {
                                    if (mObj["resultCode"].ToString() == "200")
                                    {



                                        MessageBox.Show("티켓취소 완료.", "thepos");
                                    }
                                    else
                                    {
                                        MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                                }
                                //
                            }
                            else
                            {
                                MessageBox.Show("티켓사용이후 주문취소불가.", "thepos");
                            }
                        }
                        else
                        {
                            // 티켓 대상없음
                        }
                    }
                    else
                    {
                        MessageBox.Show("데이터 오류2. ticketFlow", "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("데이터 오류3. ticketFlow", "thepos");
                }


            }
            else if (auth_pay_class == "CH")  // 충전건의 취소
            {
                int charge_amount = 0;
                int charge_cnt = 0;
                String flow_step = "";

                String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&ticketNo=" + ticket_no;

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["ticketFlows"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count == 1)
                        {
                            charge_amount = convert_number(arr[0]["pointCharge"].ToString());
                            charge_cnt = convert_number(arr[0]["pointChargeCnt"].ToString());

                            charge_amount -= cancel_amount;
                            charge_cnt--;

                            if (charge_cnt == 0)
                            {
                                flow_step = "1";
                            }
                            else
                            {
                                flow_step = "2";
                            }


                            // 수정
                            Dictionary<string, string> parameters = new Dictionary<string, string>();
                            parameters.Clear();
                            parameters["siteId"] = mSiteId;

                            //? 원승인일자를 넣어야
                            parameters["bizDt"] = mBizDate;

                            parameters["ticketNo"] = ticket_no;

                            parameters["pointCharge"] = charge_amount + "";
                            parameters["pointChargeCnt"] = charge_cnt + "";
                            parameters["flowStep"] = flow_step;
                            
                            if (mRequestPatch("ticketFlow", parameters))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {
                                    return;
                                }
                            }
                        }
                    }
                }

                MessageBox.Show("티켓데이터 포인트충전취소 오류. ticketFlow", "thepos");
                return;

            }
            else if (auth_pay_class == "US")  // 포인트사용건의 취소
            {
                int usage_amount = 0;
                int usage_cnt = 0;
                String flow_step = "";


                //?? mBisDate 와 실재 bizdate가 다르면 오류발생 -> 전일자 포인트 추가가 가능해야하는가?
                String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&ticketNo=" + ticket_no;

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["ticketFlows"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count == 1)
                        {
                            usage_amount = convert_number(arr[0]["pointUsage"].ToString());
                            usage_cnt = convert_number(arr[0]["pointUsageCnt"].ToString());

                            usage_amount -= cancel_amount;
                            usage_cnt--;

                            if (usage_cnt == 0)
                            {
                                if (mTicketType == "PA")  //선불
                                {
                                    flow_step = "2";
                                }
                                else  // 후불
                                { 
                                    flow_step = "1";
                                }
                            }
                            else
                            {
                                flow_step = "3";
                            }

                            // 수정
                            Dictionary<string, string> parameters = new Dictionary<string, string>();
                            parameters.Clear();
                            parameters["siteId"] = mSiteId;
                            parameters["bizDt"] = mBizDate;
                            parameters["ticketNo"] = ticket_no;

                            parameters["pointUsage"] = usage_amount + "";
                            parameters["pointUsageCnt"] = usage_cnt + "";
                            parameters["flowStep"] = flow_step;

                            if (mRequestPatch("ticketFlow", parameters))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {
                                    return;
                                }
                            }
                        }
                    }
                }

                MessageBox.Show("티켓데이터 포인트사용취소 오류. ticketFlow", "thepos");
                return;

            }
            else if (auth_pay_class == "ST")  // 포인트사용분의 승인건의 취소
            {

                //? 취소가 가능한게 맞는가?

                int settle_charge_amount = 0;
                int settle_usage_amount = 0;
                int charge_amount = 0;
                int usage_amount = 0;

                String flow_step = "";

                String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&ticketNo=" + ticket_no;

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["ticketFlows"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count == 1)
                        {
                            settle_charge_amount = convert_number(arr[0]["settlePointCharge"].ToString());
                            settle_usage_amount = convert_number(arr[0]["settlePointUsage"].ToString());

                            settle_usage_amount -= cancel_amount;


                            if (settle_usage_amount == 0 & settle_charge_amount == 0)
                            {
                                flow_step = "3";  // 사용중
                            }
                            else
                            {
                                flow_step = "4";  // 정산중
                            }

                            // 수정
                            Dictionary<string, string> parameters = new Dictionary<string, string>();
                            parameters.Clear();
                            parameters["siteId"] = mSiteId;
                            parameters["ticketNo"] = ticket_no;

                            parameters["settlePointUsage"] = settle_usage_amount + "";
                            parameters["flowStep"] = flow_step;
                            // bizDt 추가요망
                            if (mRequestPatch("ticketFlow", parameters))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {
                                    return;
                                }
                            }
                        }
                    }
                }

                MessageBox.Show("정산완료후 취소불가. ticketFlow", "thepos");
                return;

            }

        }



        public static int get_flowstep_by_ticketno(String ticket_no)
        {
            String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&ticketNo=" + ticket_no;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["ticketFlows"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count == 1)
                    {
                        return convert_number(arr[0]["flowStep"].ToString());
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return -9;
                }
            }
            else
            {
                return -9;
            }
        }




        public static void mClearSaleForm()
        {
            mOrderItemList.Clear();
            mLvwOrderItem.SetObjects(mOrderItemList);

            ReCalculateAmount();
            ConsoleEnable();
        }



        // OrderItem ListView 관련 버튼들
        private void btnOrderCancelAll_Click(object sender, EventArgs e)
        {
            mOrderItemList.Clear();
            lvwOrderItem.SetObjects(mOrderItemList);

            ReCalculateAmount();
        }

        private void btnOrderCancelSelect_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.SelectedItems.Count > 0)
            {
                int idx = lvwOrderItem.SelectedItems[0].Index;

                mOrderItemList.Remove(mOrderItemList[idx]);

                // renumbering
                for (int i = idx; i < mOrderItemList.Count; i++)
                {
                    MemOrderItem orderItem = mOrderItemList[i];

                    orderItem.order_no = i + 1;
                    orderItem.lv_order_no = i + 1;

                    mOrderItemList[i] =orderItem;
                }
                

                lvwOrderItem.SetObjects(mOrderItemList);


                //lvwOrderItem.SelectedItems[0].Remove();

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


                ReCalculateAmount();
            }
        }

        private void btnOrderAmtChange_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.SelectedItems.Count != 1)
            {
                return;
            }

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

        private void btnOrderCntDn_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.SelectedItems.Count != 1)
            {
                return;
            }


            int lv_idx = lvwOrderItem.SelectedItems[0].Index;

            if (mOrderItemList[lv_idx].cnt == 1)
            {
                SetDisplayAlarm("W", "수량은 0이하로 입력할 수 없습니다.");
                return;
            }

            set_item_change_ordercnt(lv_idx, "add", -1);
            ReCalculateAmount();

        }

        private void btnOrderCntUp_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.SelectedItems.Count != 1)
            {
                return;
            }


            int lv_idx = lvwOrderItem.SelectedItems[0].Index;

            if (mOrderItemList[lv_idx].cnt >= 999)
            {
                SetDisplayAlarm("W", "수량은 1000이상 입력할 수 없습니다.");
                return;
            }

            set_item_change_ordercnt(lv_idx, "add", 1);
            ReCalculateAmount();
            
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

                //#
                mPanelMiddle.Controls.Clear();
                mPanelMiddle.Visible = true;

                frmOrderDCR fForm = new frmOrderDCR() { TopLevel = false, TopMost = true };
                mPanelMiddle.Height = fForm.Height;
                mPanelMiddle.Controls.Add(fForm);
                fForm.Show();

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

                for (int i = 0; i < mOrderItemList.Count; i++)
                {
                    MemOrderItem orderItem = mOrderItemList[i];
                    orderItem.order_no = mWaitingNoCounter;

                    waiting.cnt++;
                    waiting.amount += orderItem.net_amount;

                    listWaitingItem.Add(orderItem);
                }

                listWaiting.Add(waiting);

                mOrderItemList.Clear();
                lvwOrderItem.SetObjects(mOrderItemList);


                btnOrderWaiting.Text = "대기\n" + listWaiting.Count + "";


                ReCalculateAmount();


            }
            else
            {
                if (listWaiting.Count > 0)
                {
                    ConsoleDisable();

                    //#
                    mPanelMiddle.Visible = true;
                    mPanelMiddle.Controls.Clear();

                    frmOrderWaiting fForm = new frmOrderWaiting() { TopLevel = false, TopMost = true };
                    mPanelMiddle.Height = fForm.Height;
                    mPanelMiddle.Controls.Add(fForm);
                    fForm.Show();

                }
            }

        }


        public static void set_wating_data()
        {
            int lv_no = 0;
            for (int i = 0; i < listWaitingItem.Count; i++)
            {
                if (listWaitingItem[i].order_no == mSelectedWaitingNo)
                {
                    lv_no++;

                    ListViewItem lvItem = new ListViewItem();

                    lvItem.Tag = listWaitingItem[i];

                    MemOrderItem orderItem = listWaitingItem[i];
                    mOrderItemList.Add(orderItem);
                }
            }

            mLvwOrderItem.SetObjects(mOrderItemList);

            mLvwOrderItem.Items[mLvwOrderItem.Items.Count - 1].EnsureVisible();



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


            //
            if (listWaiting.Count > 0)
            {
                mBtnOrderWaiting.Text = "대기\n" + listWaiting.Count + "";
            }
            else
            {
                mBtnOrderWaiting.Text = "대기";
            }

            ReCalculateAmount();

        }


        private void btnPayManager_Click(object sender, EventArgs e)
        {
            ConsoleDisable();

            //#
            mPanelMiddle.Controls.Clear();
            mPanelMiddle.Visible = true;

            frmPayManager fForm = new frmPayManager() { TopLevel = false, TopMost = true };
            mPanelMiddle.Height = fForm.Height;
            mPanelMiddle.Controls.Add(fForm);
            fForm.Show();

        }



        // ///////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void ConsoleEnable()
        {
            mPanelTitleConsole.Enabled = true;
            mPanelOrderConsole.Enabled = true;
        }

        void ConsoleDisable()
        {
            panelTitleConsole.Enabled = false;
            panelOrderConsole.Enabled = false;
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
            MemOrderItem orderItem = mOrderItemList[lv_idx];

            if (jobtype == "set")
            {
                orderItem.amt = amt;
            }
            else
            {
                return;
            }

            //
            replace_mem_order_item(ref orderItem, "update");


            mOrderItemList[lv_idx] = orderItem;

            lvwOrderItem.SetObjects(mOrderItemList);

            lvwOrderItem.Items[lv_idx].Selected = true;
        }

        private void set_item_change_ordercnt(int lv_idx, String jobtype, int cnt)
        {
            if (mOrderItemList[lv_idx].dcr_des == "E")
            {
                SetDisplayAlarm("W", "전체할인 수량변경 불가.");
                return;
            }


            MemOrderItem orderItem = mOrderItemList[lv_idx];

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

            // 
            replace_mem_order_item(ref orderItem, "update");

            mOrderItemList[lv_idx] = orderItem;

            lvwOrderItem.SetObjects(mOrderItemList);

            lvwOrderItem.Items[lv_idx].Selected = true;


        }


        public static int get_dc_amount(MemOrderItem orderItem)
        {
            int amount = (orderItem.amt + orderItem.option_amt) * orderItem.cnt;
            int tdcamount = 0;


            if (orderItem.dcr_type == "A")
            {
                tdcamount = orderItem.dcr_value * orderItem.cnt;
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


        public static bool isExist_DCR(String des)  // des = E or S
        {
            for (int i = mOrderItemList.Count - 1; i >= 0; i--)
            {
                if (mOrderItemList[i].dcr_des == des)
                {
                    return true;
                }
            }

            return false;
        }

        public static int get_lv_DCR(String des)  // des = E or S
        {
            for (int i = mOrderItemList.Count - 1; i >= 0; i--)
            {
                if (mOrderItemList[i].dcr_des == des)
                {
                    return i;
                }
            }

            return -1;
        }


        public static void ReCalculateAmount()
        {
            int Amount = 0;
            int dcAmount = 0;
            mNetAmount = 0;

            MemOrderItem orderItem;

            for (int i = 0; i < mOrderItemList.Count; i++)
            {
                orderItem = mOrderItemList[i];
                Amount += (orderItem.amt + orderItem.option_amt) * orderItem.cnt;      // 주문금액
                dcAmount += orderItem.dc_amount;                    // 할인금액
                mNetAmount += orderItem.net_amount;      // 결제금액
            }

            mLblOrderAmount.Text = Amount.ToString("N0");
            mLblOrderAmountDC.Text = dcAmount.ToString("N0");
            mLblOrderAmountNet.Text = mNetAmount.ToString("N0");
            mLblOrderAmountReceive.Text = "0";
            mLblOrderAmountRest.Text = "0";

            // Sub Screen 표시
            DisplaySubScreen();

        }


        public static bool get_amounts(out int t과세금액, out int t면세금액)
        { 
            // 결제진행시 과세 면세 부가세 계산을 위해서..
            // 주문금액 과세금액 부가세액 면세금액

            t과세금액 = 0;// 부가세 포함 금액
            t면세금액 = 0;
            int t전체할인금액 = 0;

            for (int i = 0; i < mOrderItemList.Count; i++)
            {
                MemOrderItem orderItemInfo = mOrderItemList[i];

                if (orderItemInfo.dcr_des == "E") // 전체할인
                {
                    t전체할인금액 = orderItemInfo.dc_amount;
                }
                else
                {
                    if (orderItemInfo.taxfree == "Y")
                    {
                        t면세금액 += (((orderItemInfo.amt + orderItemInfo.option_amt) * orderItemInfo.cnt) - orderItemInfo.dc_amount);
                    }
                    else
                    {
                        t과세금액 += (((orderItemInfo.amt + orderItemInfo.option_amt) * orderItemInfo.cnt) - orderItemInfo.dc_amount);
                    }
                }
            }

            if (t전체할인금액 > 0)
            {
                if (t전체할인금액 < t과세금액)
                {
                    t과세금액 -= t전체할인금액;
                }
                else
                {
                    t면세금액 -= (t전체할인금액 - t과세금액);
                    t과세금액 = 0;
                }
            }

            return true;
        }
    

        public static void DisplaySubScreen()
        {
            if (fSub != null)
            {
                mPanelOrderInfo.Visible = true;

                mSublvwOrderItem.SetObjects(mOrderItemList);



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
                    if (sel_idx - top_idx > 4 & sel_idx < lvwOrderItem.Items.Count - 1)
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
            // 옵션이 있는 항목은 상품코드가 동일해도 다른 상품으로 간주한다.


            for (int i = 0; i < mOrderItemList.Count; i++)
            {
                if (code == mOrderItemList[i].goods_code & mOrderItemList[i].option_item_cnt == 0)
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

            // 메모리 초기화
            mOrderItemList.Clear();

            this.Close();

            mPanelDivision.Visible = false;

        }

        private void lvwOrderItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mRightFace == "PayComplex")
            {
                if (lvwOrderItem.SelectedItems.Count > 0)
                {
                    MemOrderItem orderItem = mOrderItemList[lvwOrderItem.SelectedIndex];

                    int amt = ((orderItem.amt + orderItem.option_amt) * orderItem.cnt) - orderItem.dc_amount;

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
            //! 재기동시 초기화된 이후의 연속성. -> 서버에 물어본다.  last_the_no(); xxxxx
            //mTheNo = mSiteId + mBizDate + mPosNo + (++mBillTheNo).ToString("0000"); XXXX
            //mTheNo = mSiteId + mBizDate + mPosNo + get_today_time();  xxxx

            // 일련번호 -> Time(6) 변경
            // 일련번호 -> 일초누적(5) + 1/10초(1)
   

            var timeSpan = (DateTime.Now - new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 0));
            String seconddiff = ((long)timeSpan.TotalMilliseconds).ToString("00000000").Substring(0, 6);


            mTheNo = mSiteId + mBizDate + mPosNo + seconddiff;


            // 동잀하게 세팅후 -> 이후 필요시 별도세팅
            mRefNo = mTheNo;
            // the_no : 결제단위 - cash card complex point easy 결제버튼을 누른경우 새로운 the_no부여
            // ref_no : 입장단위 - 포인트 충전 정산의 경우 티켓번호 18자리로 세트
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


        public static String make_bill_body(String tTheNo, String tranType, String except_order, String pay_keep)
        {
            if (mTheMode == "Local")
                return make_bill_body_local(tTheNo, tranType, except_order, pay_keep);
            else
                return make_bill_body_server(tTheNo, tranType, except_order, pay_keep);

        }

        public static String make_bill_body_local(String tTheNo, String tranType, String except_order, String pay_keep)
        {
            String strPrintHeader = "";
            String strPrintOrder = "";
            String strPrintPayment = "";

            String tOrderDt = "";
            int t과세가액 = 0;
            int t면세가액 = 0;
            int t할인금액 = 0;

            String pay_keep_cash = pay_keep.Substring(0, 1);
            String pay_keep_card = pay_keep.Substring(1, 1);

            String pay_keep_cert = pay_keep.Substring(4, 1); //?# 쿠폰인증


            //!
            SQLiteDataReader dr = sql_select_local_db("SELECT * FROM orders WHERE theNo='" + tTheNo + "'");
            if (dr.Read())
            {
                String d = dr["orderDate"].ToString();
                String t = dr["orderTime"].ToString();
                tOrderDt = d.Substring(0, 4) + "/" + d.Substring(4, 2) + "/" + d.Substring(6, 2) + " " +
                            t.Substring(0, 2) + ":" + t.Substring(2, 2) + ":" + t.Substring(4, 2);
            }
            else
            {
                MessageBox.Show("데이터오류. local orders\n\n" + mErrorMsg, "thepos");
            }
            dr.Close();



            String tStr = tTheNo.Substring(4, 8) + "-" + tTheNo.Substring(12, 2) + "-" + tTheNo.Substring(14, 6);
            int space_cnt = 42 - (encodelen(tOrderDt) + encodelen(tStr));
            strPrintHeader = tOrderDt + Space(space_cnt) + tStr;
            strPrintHeader += "\r\n";



            //!
            strPrintOrder = "==========================================\r\n";  // 42
            strPrintOrder += "상품명                 단가  수량     금액\r\n";
            strPrintOrder += "------------------------------------------\r\n";  // 42


            dr = sql_select_local_db("SELECT * FROM orderItem WHERE theNo='" + tTheNo + "' AND tranType='A'");
            while (dr.Read())
            {
                int amt = convert_number(dr["amt"].ToString());
                int option_amt = convert_number(dr["optionAmt"].ToString());
                int cnt = convert_number(dr["cnt"].ToString());
                int dc_amt = convert_number(dr["dcAmount"].ToString());
                String dcr_des = dr["dcrDes"].ToString();
                String dcr_type = dr["dcrType"].ToString();
                String dcr_value = dr["dcrValue"].ToString();

                if (dcr_des == "E") // 전체할인
                {
                    if (dcr_type == "A")
                    {
                        tStr = dr["itemName"].ToString();
                        strPrintOrder += tStr + Space(21 - encodelen(tStr));

                        tStr = (-dc_amt).ToString("N0");        // 할인 정액
                        strPrintOrder += Space(21 - encodelen(tStr)) + tStr;
                    }
                    else if (dcr_type == "R")
                    {
                        tStr = dr["goodsName"].ToString() + "-" + dcr_value + "%";
                        strPrintOrder += tStr + Space(21 - encodelen(tStr));

                        tStr = (-dc_amt).ToString("N0");        // 할인 정액
                        strPrintOrder += Space(21 - encodelen(tStr)) + tStr;
                    }
                    strPrintOrder += "\r\n";
                }
                else                                 // 일반상품항목
                {
                    // 상품아이템
                    
                    String tGoodsName = "";

                    if (dr["taxFree"].ToString() == "Y")
                        tGoodsName = "*" + dr["goodsName"].ToString();
                    else
                        tGoodsName = dr["goodsName"].ToString();

                    String tGoodsAmt = amt.ToString("N0");     //단가


                    int tLenGoodsNameAmt = encodelen(tGoodsName) + encodelen(tGoodsAmt);

                    if (tLenGoodsNameAmt > 26)
                    {
                        strPrintOrder += tGoodsName + "\r\n";
                        strPrintOrder += Space(18) + Space(9 - encodelen(tGoodsAmt)) + tGoodsAmt;
                    }
                    else
                    {
                        strPrintOrder += tGoodsName + Space(27 - tLenGoodsNameAmt) + tGoodsAmt;
                    }


                    tStr = cnt.ToString("N0");     // 수량
                    strPrintOrder += Space(6 - encodelen(tStr)) + tStr;

                    tStr = (amt * cnt).ToString("N0");     // 금액 = 단가*수량
                    strPrintOrder += Space(9 - encodelen(tStr)) + tStr;

                    strPrintOrder += "\r\n";



                    // 옵션아이템
                    if (dr["optionNo"].ToString().Length > 0)
                    {
                        String tOptionName = "  ";
                        SQLiteDataReader dr2 = sql_select_local_db("SELECT * FROM orderOptionItem WHERE optionNo='" + dr["optionNo"].ToString() + "'");
                        while (dr2.Read())
                        {
                            tOptionName += dr2["optionItemName"].ToString() + " ";
                        }

                        String tOptionAmt = option_amt.ToString("N0");     //단가

                        int tLenOptionNameAmt = encodelen(tOptionName) + encodelen(tOptionAmt);


                        if (tLenOptionNameAmt > 27)
                        {
                            if (encodelen(tOptionName) > 42)
                                strPrintOrder += tOptionName + "\r\n";
                            else
                                strPrintOrder += tOptionName + Space(42 - encodelen(tOptionName)) + "\r\n";


                            strPrintOrder += Space(18) + Space(9 - encodelen(tOptionAmt)) + tOptionAmt;
                        }
                        else
                        {
                            strPrintOrder += tOptionName + Space(27 - tLenOptionNameAmt) + tOptionAmt;
                        }


                        tStr = cnt.ToString("N0");     // 수량
                        strPrintOrder += Space(6 - encodelen(tStr)) + tStr;

                        tStr = (option_amt * cnt).ToString("N0");     // 금액 = 단가*수량
                        strPrintOrder += Space(9 - encodelen(tStr)) + tStr;

                        strPrintOrder += "\r\n";
                    }
                    
                    
                    // 할인
                    if (dcr_type == "A")
                    {
                        tStr = "  할인";
                        strPrintOrder += tStr + Space(21 - encodelen(tStr));

                        tStr = (-dc_amt).ToString("N0");        // 할인 정액
                        strPrintOrder += Space(21 - encodelen(tStr)) + tStr;

                        strPrintOrder += "\r\n";
                    }
                    else if (dr["dcrType"].ToString() == "R")
                    {
                        tStr = "  할인-" + dr["dcrValue"].ToString() + "%";
                        strPrintOrder += tStr + Space(21 - encodelen(tStr));

                        tStr = (-dc_amt).ToString("N0");        // 할인 정액
                        strPrintOrder += Space(21 - encodelen(tStr)) + tStr;

                        strPrintOrder += "\r\n";
                    }
                }

                if (dr["taxFree"].ToString() == "Y") t면세가액 += ((cnt * amt) - dc_amt);
                else t과세가액 += ((cnt * amt) - dc_amt);

                t할인금액 += dc_amt;

            }



            //
            strPrintPayment = "------------------------------------------\r\n";  // 42

            if (t면세가액 > 0)
            {
                tStr = "*면세품목가액";
                strPrintPayment += tStr + Space(21 - encodelen(tStr));

                tStr = (t면세가액).ToString("N0");
                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;

                strPrintPayment += "\r\n";
            }

            if (t과세가액 > 0)  // 공급가액
            {
                int t_tax = t과세가액 / 11;   // 부가세액
                int t_amt = t과세가액 - t_tax; // 공급가액

                tStr = "과세품목가액";
                strPrintPayment += tStr + Space(21 - encodelen(tStr));
                tStr = (t_amt).ToString("N0");
                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                strPrintPayment += "\r\n";

                tStr = "부가세액";
                strPrintPayment += tStr + Space(21 - encodelen(tStr));
                tStr = (t_tax).ToString("N0");
                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                strPrintPayment += "\r\n";
            }

            strPrintPayment += "------------------------------------------\r\n";  // 42

            int tsum = t과세가액 + t면세가액 + t할인금액;
            int tnet = tsum - t할인금액;


            tStr = "총합계";
            strPrintPayment += tStr + Space(21 - encodelen(tStr));
            tStr = (tsum).ToString("N0");
            strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
            strPrintPayment += "\r\n";

            tStr = "할인계";
            strPrintPayment += tStr + Space(21 - encodelen(tStr));
            tStr = (-t할인금액).ToString("N0");
            strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
            strPrintPayment += "\r\n";

            tStr = "결제대상금액";
            strPrintPayment += tStr + Space(21 - encodelen(tStr));
            tStr = (tnet).ToString("N0");
            strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
            strPrintPayment += "\r\n";

            strPrintPayment += "------------------------------------------\r\n";  // 42



            //! 현금결제
            if (pay_keep_cash == "1")
            {
                dr = sql_select_local_db("SELECT * FROM paymentCash WHERE theNo='" + tTheNo + "'");
                while (dr.Read())
                {
                    if (dr["tranType"].ToString() == tranType)
                    {
                        int amount = convert_number(dr["amount"].ToString());


                        if (dr["payType"].ToString() == "R0") // 단순현금
                        {

                            tStr = "현금";
                            strPrintPayment += tStr + Space(21 - encodelen(tStr));

                            if (tranType == "C")
                                tStr = (-amount).ToString("N0");
                            else
                                tStr = amount.ToString("N0");

                            strPrintPayment += Space(21 - encodelen(tStr)) + tStr;

                        }
                        else if (dr["payType"].ToString() == "R1") // 현금영수증
                        {
                            tStr = "현금영수증";
                            strPrintPayment += tStr + Space(21 - encodelen(tStr));

                            if (tranType == "C")
                                tStr = (-amount).ToString("N0");
                            else
                                tStr = amount.ToString("N0");

                            strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                            strPrintPayment += "\r\n";

                            if (dr["receiptType"].ToString() == "1") // 소득공제
                            {
                                tStr = "소득공제";
                            }
                            else if (dr["receiptType"].ToString() == "2") // 지출증빙
                            {
                                tStr = "지출증빙";
                            }
                            else if (dr["receiptType"].ToString() == "S") //? 자진밝급
                            {
                                tStr = "자진발급";
                            }

                            strPrintPayment += tStr + Space(21 - encodelen(tStr));

                            String no = dr["issuedMethodNo"].ToString() + "";

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


            //! 카드결제
            if (pay_keep_card == "1")
            {
                dr = sql_select_local_db("SELECT * FROM paymentCard WHERE theNo='" + tTheNo + "'");
                while (dr.Read())
                {
                    if (dr["tranType"].ToString() == tranType)
                    {
                        if (dr["payType"].ToString() == "C1") tStr = "카드결제";
                        else if (dr["payType"].ToString() == "C0") tStr = "카드결제";  // 임의등록

                        if (tranType == "C")
                        {
                            tStr += "취소";
                        }

                        int amount = convert_number(dr["amount"].ToString());


                        strPrintPayment += tStr + Space(21 - encodelen(tStr));

                        if (tranType == "C")
                            tStr = (-amount).ToString("N0");
                        else
                            tStr = amount.ToString("N0");

                        strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                        strPrintPayment += "\r\n";

                        tStr = dr["cardName"].ToString();
                        strPrintPayment += tStr + Space(21 - encodelen(tStr));

                        String no = dr["cardNo"].ToString();


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

                        if (dr["install"].ToString() == "00")
                            tStr = "할부개월:일시불";
                        else
                            tStr = "할부개월:" + dr["install"].ToString();

                        strPrintPayment += tStr + Space(21 - encodelen(tStr));
                        tStr = "승인번호:" + dr["authNo"].ToString().Trim();
                        strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                        strPrintPayment += "\r\n";
                        strPrintPayment += "\r\n";

                    }
                }
            }


            //! 쿠폰
            if (pay_keep_cert == "1")
            {
                dr = sql_select_local_db("SELECT * FROM paymentCert WHERE theNo='" + tTheNo + "'");
                while (dr.Read())
                {
                    if (dr["tranType"].ToString() == tranType)
                    {
                        if (dr["payType"].ToString() == "M0") tStr = "쿠폰";

                        if (tranType == "C")
                        {
                            tStr += "취소";
                        }

                        int amount = convert_number(dr["amount"].ToString());


                        strPrintPayment += tStr + Space(21 - encodelen(tStr));

                        if (tranType == "C")
                            tStr = (-amount).ToString("N0");
                        else
                            tStr = amount.ToString("N0");

                        strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                        strPrintPayment += "\r\n";


                        tStr = dr["vanCode"].ToString();
                        strPrintPayment += tStr + Space(21 - encodelen(tStr));

                        tStr = dr["couponNo"].ToString();
                        strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                        strPrintPayment += "\r\n";

                        strPrintPayment += "\r\n";

                    }
                }
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


        public static String make_bill_body_server(String tTheNo, String tranType, String except_order, String pay_keep)
        {
            String strPrintHeader = "";
            String strPrintOrder = "";
            String strPrintPayment = "";

            String tOrderDt = "";
            int t과세가액 = 0;
            int t면세가액 = 0;
            int t할인금액 = 0;

            String pay_keep_cash = pay_keep.Substring(0, 1);
            String pay_keep_card = pay_keep.Substring(1, 1);
            String pay_keep_point = pay_keep.Substring(2, 1);
            String pay_keep_easy = pay_keep.Substring(3, 1);
            String pay_keep_cert = pay_keep.Substring(4, 1);   //?# 쿠폰인증


            //!
            String sUrl = "orders?siteId=" + mSiteId + "&theNo=" + tTheNo;
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
                        tOrderDt = d.Substring(0, 4) + "/" + d.Substring(4, 2) + "/" +d.Substring(6, 2) + " " +
                                   t.Substring(0, 2) + ":" + t.Substring(2, 2) + ":" + t.Substring(4, 2);
                    }
                }
                else
                {
                    MessageBox.Show("주문 데이터 오류. orders\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orders\n\n" + mErrorMsg, "thepos");
            }


            String tStr = tTheNo.Substring(4, 8) + "-" + tTheNo.Substring(12, 2) + "-" + tTheNo.Substring(14, 6);
            int space_cnt = 42 - (encodelen(tOrderDt) + encodelen(tStr));
            strPrintHeader = tOrderDt + Space(space_cnt) + tStr;
            strPrintHeader += "\r\n";



            //!
            strPrintOrder = "==========================================\r\n";  // 42
            strPrintOrder += "상품명                 단가  수량     금액\r\n";
            strPrintOrder += "------------------------------------------\r\n";  // 42

            sUrl = "orderItem?siteId=" + mSiteId + "&theNo=" + tTheNo + "&tranType=" + tranType;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orderItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        int amt = convert_number(arr[i]["amt"].ToString());
                        int option_amt = convert_number(arr[i]["optionAmt"].ToString());
                        int cnt = convert_number(arr[i]["cnt"].ToString());
                        int dc_amt = convert_number(arr[i]["dcAmount"].ToString());
                        String dcr_des = arr[i]["dcrDes"].ToString();
                        String dcr_type = arr[i]["dcrType"].ToString();
                        String dcr_value = arr[i]["dcrValue"].ToString();

                        if (dcr_des == "E") // 전체할인
                        {
                            if (dcr_type == "A")
                            {
                                tStr = arr[i]["goodsName"].ToString();
                                strPrintOrder += tStr + Space(21 - encodelen(tStr));

                                tStr = (-dc_amt).ToString("N0");        // 할인 정액
                                strPrintOrder += Space(21 - encodelen(tStr)) + tStr;
                            }
                            else if (dcr_type == "R")
                            {
                                tStr = arr[i]["goodsName"].ToString() + "-" + dcr_value + "%";
                                strPrintOrder += tStr + Space(21 - encodelen(tStr));

                                tStr = (-dc_amt).ToString("N0");        // 할인 정액
                                strPrintOrder += Space(21 - encodelen(tStr)) + tStr;
                            }
                            strPrintOrder += "\r\n";
                        }
                        else                                 // 일반상품항목
                        {
                            // 상품아이템

                            String tGoodsName = "";

                            if (arr[i]["taxFree"].ToString() == "Y")
                                tGoodsName = "*" + arr[i]["goodsName"].ToString();
                            else
                                tGoodsName = arr[i]["goodsName"].ToString();

                            String tGoodsAmt = amt.ToString("N0");     //단가


                            int tLenGoodsNameAmt = encodelen(tGoodsName) + encodelen(tGoodsAmt);

                            if (tLenGoodsNameAmt > 27)
                            {
                                strPrintOrder += tGoodsName + Space(42 - encodelen(tGoodsName)) + "\r\n";
                                strPrintOrder += Space(18) + Space(9 - encodelen(tGoodsAmt)) + tGoodsAmt;
                            }
                            else
                            {
                                strPrintOrder += tGoodsName + Space(27 - tLenGoodsNameAmt) + tGoodsAmt;
                            }



                            tStr = cnt.ToString("N0");     // 수량
                            strPrintOrder += Space(6 - encodelen(tStr)) + tStr;

                            tStr = (amt * cnt).ToString("N0");     // 금액 = 단가*수량
                            strPrintOrder += Space(9 - encodelen(tStr)) + tStr;

                            strPrintOrder += "\r\n";


                            // 옵션아이템
                            if (arr[i]["optionNo"].ToString() != "")
                            {
                                sUrl = "orderOptionItem?siteId=" + mSiteId + "&optionNo=" + arr[i]["optionNo"].ToString();
                                if (mRequestGet(sUrl))
                                {
                                    if (mObj["resultCode"].ToString() == "200")
                                    {
                                        String data2 = mObj["orderOptionItems"].ToString();
                                        JArray arr2 = JArray.Parse(data2);

                                        
                                        String tOptionName = "  ";
                                        for (int k = 0; k < arr2.Count; k++)
                                        {
                                            tOptionName += arr2[k]["optionItemName"].ToString() + " ";
                                        }

                                        String tOptionAmt = option_amt.ToString("N0");     //단가


                                        int tLenOptionNameAmt = encodelen(tOptionName) + encodelen(tOptionAmt);

                                        
                                        if (tLenOptionNameAmt > 27)
                                        {
                                            if (encodelen(tOptionName) > 42) 
                                                strPrintOrder += tOptionName + "\r\n";
                                            else
                                                strPrintOrder += tOptionName + Space(42 - encodelen(tOptionName)) + "\r\n";

                                            
                                            strPrintOrder += Space(18) + Space(9 - encodelen(tOptionAmt)) + tOptionAmt;
                                        }
                                        else
                                        {
                                            strPrintOrder += tOptionName + Space(27 - tLenOptionNameAmt) + tOptionAmt;
                                        }


                                        tStr = cnt.ToString("N0");     // 수량
                                        strPrintOrder += Space(6 - encodelen(tStr)) + tStr;

                                        tStr = (option_amt * cnt).ToString("N0");     // 금액 = 단가*수량
                                        strPrintOrder += Space(9 - encodelen(tStr)) + tStr;

                                        strPrintOrder += "\r\n";
                                    }
                                }
                            }


                            // 할인
                            if (dcr_type == "A")
                            {
                                tStr = "  할인";
                                strPrintOrder += tStr + Space(21 - encodelen(tStr));

                                tStr = (-dc_amt).ToString("N0");        // 할인 정액
                                strPrintOrder += Space(21 - encodelen(tStr)) + tStr;

                                strPrintOrder += "\r\n";
                            }
                            else if (arr[i]["dcrType"].ToString() == "R")
                            {
                                tStr = "  할인-" + arr[i]["dcrValue"].ToString() + "%";
                                strPrintOrder += tStr + Space(21 - encodelen(tStr));

                                tStr = (-dc_amt).ToString("N0");        // 할인 정액
                                strPrintOrder += Space(21 - encodelen(tStr)) + tStr;

                                strPrintOrder += "\r\n";
                            }

                            // [여기]
                        }

                        
                        //?  전체할인인 경우 과세가액 계산.. 아래로직을 [여기]로 옮겨야하나??
                        if (arr[i]["taxFree"].ToString() == "Y") t면세가액 += ((cnt * (amt + option_amt)) - dc_amt);
                        else t과세가액 += ((cnt * (amt + option_amt)) - dc_amt);

                        //
                        t할인금액 += dc_amt;
                    }
                }
                else
                {
                    MessageBox.Show("주문 데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orderItem\n\n" + mErrorMsg, "thepos");
            }
            

            //
            strPrintPayment = "------------------------------------------\r\n";  // 42

            if (t면세가액 > 0)
            {
                tStr = "*면세품목가액";
                strPrintPayment += tStr + Space(21 - encodelen(tStr));

                tStr = (t면세가액).ToString("N0");
                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;

                strPrintPayment += "\r\n";
            }

            if (t과세가액 > 0)  // 공급가액
            {
                int t_tax = t과세가액 / 11;   // 부가세액
                int t_amt = t과세가액 - t_tax; // 공급가액

                tStr = "과세품목가액";
                strPrintPayment += tStr + Space(21 - encodelen(tStr));
                tStr = (t_amt).ToString("N0");
                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                strPrintPayment += "\r\n";

                tStr = "부가세액";
                strPrintPayment += tStr + Space(21 - encodelen(tStr));
                tStr = (t_tax).ToString("N0");
                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                strPrintPayment += "\r\n";
            }

            strPrintPayment += "------------------------------------------\r\n";  // 42

            int tsum = t과세가액 + t면세가액 + t할인금액;
            int tnet = tsum - t할인금액;


            tStr = "총합계";
            strPrintPayment += tStr + Space(21 - encodelen(tStr));
            tStr = (tsum).ToString("N0");
            strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
            strPrintPayment += "\r\n";

            tStr = "할인계";
            strPrintPayment += tStr + Space(21 - encodelen(tStr));
            tStr = (-t할인금액).ToString("N0");
            strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
            strPrintPayment += "\r\n";

            tStr = "결제대상금액";
            strPrintPayment += tStr + Space(21 - encodelen(tStr));
            tStr = (tnet).ToString("N0");
            strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
            strPrintPayment += "\r\n";

            strPrintPayment += "------------------------------------------\r\n";  // 42



            //! 현금결제
            if (pay_keep_cash == "1")
            {
                sUrl = "paymentCash?siteId=" + mSiteId + "&theNo=" + tTheNo;
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

                                    if (tranType == "C")
                                    {
                                        tStr += "취소";
                                    }

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

                                    if (tranType == "C")
                                    {
                                        tStr += "취소";
                                    }

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
            if (pay_keep_card == "1")
            {
                sUrl = "paymentCard?siteId=" + mSiteId + "&theNo=" + tTheNo;
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
                                else if (arr[i]["payType"].ToString() == "C0") tStr = "카드결제";  // 임의등록

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

                                tStr = arr[i]["cardName"].ToString().Trim();
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
                                tStr = "승인번호:" + arr[i]["authNo"].ToString().Trim();
                                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                                strPrintPayment += "\r\n";
                                strPrintPayment += "\r\n";

                            }

                        }
                    }
                }
            }


            //! 포인트
            if (pay_keep_point == "1")
            {
                sUrl = "paymentPoint?siteId=" + mSiteId + "&theNo=" + tTheNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentPoints"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {

                            //? 포인트 취소인 경우 잘되는지 다시 확인바람
                            int amount = convert_number(arr[i]["amount"].ToString());

                            if (arr[i]["payType"].ToString() == "PA") // 선불 포인트
                            {
                                tStr = "포인트";
                            }
                            else if (arr[i]["payType"].ToString() == "PD") // 후불 포인트
                            {
                                tStr = "포인트";
                            }

                            
                            if (arr[i]["isCancel"].ToString() == "Y" | arr[i]["isCancel"].ToString() == "y")
                                {
                                tStr += "취소";
                            }

                            strPrintPayment += tStr + Space(21 - encodelen(tStr));

                            if (arr[i]["isCancel"].ToString() == "Y" | arr[i]["isCancel"].ToString() == "y")
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


            //? 간편결제
            if (pay_keep_easy == "1")
            {
                sUrl = "paymentEasy?siteId=" + mSiteId + "&theNo=" + tTheNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentEasys"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i]["tranType"].ToString() == tranType)
                            {
                                tStr = "";
                                if (arr[i]["payType"].ToString() == "E1") tStr = "간편결제";

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


                                tStr = "";
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

            //?#  쿠폰인증 추가개발 필요
            if (pay_keep_cert == "1")
            {
                sUrl = "paymentCert?siteId=" + mSiteId + "&theNo=" + tTheNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCerts"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i]["tranType"].ToString() == tranType)
                            {
                                tStr = "";
                                if (arr[i]["payType"].ToString() == "M0") tStr = "쿠폰";

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


                                tStr = arr[i]["vanCode"].ToString();
                                strPrintPayment += tStr + Space(21 - encodelen(tStr));

                                tStr = arr[i]["couponNo"].ToString();
                                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                                strPrintPayment += "\r\n";

                                strPrintPayment += "\r\n";

                            }
                        }
                    }
                }
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







        public static byte[] CutPage()
        {
            byte[] partial_cut = new byte[3] { 0x1D, 0x56, 0x00 };
            return partial_cut;
        }

        public static byte[] sizeLine()
        {
            byte[] charSize = new byte[3] { 0x1B, Convert.ToByte('3'), 0x30 };
            return charSize;
        }

        public static byte[] sizeCharLarge()
        {
            byte[] charSize = new byte[3] { 0x1D, Convert.ToByte('!'), 0x33 };
            return charSize;
        }

        public static byte[] sizeCharMedium()
        {
            byte[] charSize = new byte[3] { 0x1D, Convert.ToByte('!'), 0x11 };
            return charSize;
        }

        public static byte[] sizeCharMedium2()
        {
            byte[] charSize = new byte[3] { 0x1D, Convert.ToByte('!'), 16 };
            return charSize;
        }



        public static void print_ticket(String t_ticket_no, String t_goods_code)
        {

            if (mTicketPrinterPort.Trim().Length == 0)
            {
                SetDisplayAlarm("W", "티켓프린터 미설정으로 티켓출력불가..");
                return;
            }


            try
            {
                const string ESC = "\u001B";
                const string InitializePrinter = ESC + "@";

                PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();

                byte[] BytesValue = new byte[100];

                BytesValue = PrintExtensions.AddBytes(BytesValue, InitializePrinter);


                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());


                String strPrint = mSiteName;
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                strPrint = get_goods_name(t_goods_code);
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                strPrint = mBizDate.Substring(0,4) + "-" + mBizDate.Substring(4, 2) + "-" + mBizDate.Substring(6, 2);
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                // 티켓번호 :  바코드, str

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.BarCode.Code128(t_ticket_no));
                //BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(t_ticket_no));
                //BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());


                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                BytesValue = PrintExtensions.AddBytes(BytesValue, CutPage());

                //
                PrintExtensions.Print(BytesValue, mTicketPrinterPort);


            }
            catch (Exception ex)
            {
                MessageBox.Show("티켓프린터 인쇄중 에러.\r\n" + ex.Message);  // 파일이 이미 있으므로 만들 수 없습니다.
                return;
            }

        }


        public static void print_bill(String the_no, String tran_type, String except_order, String pay_keep, bool isQuestion)
        {

            if (mBillPrinterPort.Trim().Length == 0)
            {
                SetDisplayAlarm("W", "영수증프린터 미설정으로 영수증출력불가..");
                return;
            }


            if (isQuestion == true)
            {
                frmYesNo fYesNo = new frmYesNo();
                var result = fYesNo.ShowDialog();
                if (result == DialogResult.Yes)
                {

                }
                else
                {
                    return;
                }
            }

            String headerBill = make_bill_header();
            String bodyBill = make_bill_body(the_no, tran_type, except_order, pay_keep);
            String trailerBill = make_bill_trailer();



            try
            {
                const string ESC = "\u001B";
                const string InitializePrinter = ESC + "@";

                PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();


                byte[] BytesValue = new byte[0];
                BytesValue = PrintExtensions.AddBytes(BytesValue, InitializePrinter);

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
                //BytesValue = PrintExtensions.AddBytes(BytesValue, sizeLine());  


                // 로고이미지 서버등록 이미지로 교체
                if (mByteLogoImage == null)
                {

                }
                else
                {
                    BytesValue = PrintExtensions.AddBytes(BytesValue, mByteLogoImage);
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                }


                //

                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(headerBill));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());

                //              
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(bodyBill));

                //
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(trailerBill));

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                // 바코드
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.BarCode.Code128(the_no));

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                BytesValue = PrintExtensions.AddBytes(BytesValue, CutPage());

                try
                {
                    SerialPort mySerialPort = new SerialPort();
                    mySerialPort.PortName = mBillPrinterPort;
                    mySerialPort.BaudRate = convert_number(mBillPrinterSpeed);
                    mySerialPort.Parity = Parity.None;
                    mySerialPort.StopBits = StopBits.One;
                    mySerialPort.DataBits = 8;
                    mySerialPort.Handshake = Handshake.None;

                    mySerialPort.Open();

                    mySerialPort.Write(BytesValue, 0, BytesValue.Length);
                    mySerialPort.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("프린터 출력 오류.\r\n" + ex.Message);
                    return;
                }


                //PrintExtensions.Print(BytesValue, mBillPrinterPort);
                

            }
            catch
            {
                MessageBox.Show("영수증 출력 오류.\r\n헬프데스크로 문의바랍니다.");  // 파일이 이미 있으므로 만들 수 없습니다.
                return;
            }
        }


        public static byte[] GetImage(Bitmap bill_image, int printWidth)
        {
            List<byte> byteList = new List<byte>();

            BitmapData data = GetBitmapData(bill_image, printWidth);

            BitArray dots = data.Dots;
            byte[] width = BitConverter.GetBytes(data.Width);

            int offset = 0;
            //byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
            //byteList.Add(Convert.ToByte('@'));
            byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
            byteList.Add(Convert.ToByte('3'));
            byteList.Add((byte)24);
            while (offset < data.Height)
            {
                byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
                byteList.Add(Convert.ToByte('*'));
                byteList.Add((byte)33);
                byteList.Add(width[0]);
                byteList.Add(width[1]);

                for (int x = 0; x < data.Width; ++x)
                {
                    for (int k = 0; k < 3; ++k)
                    {
                        byte slice = 0;
                        for (int b = 0; b < 8; ++b)
                        {
                            int y = (((offset / 8) + k) * 8) + b;
                            int i = (y * data.Width) + x;

                            bool v = false;
                            if (i < dots.Length)
                                v = dots[i];

                            slice |= (byte)((v ? 1 : 0) << (7 - b));
                        }
                        byteList.Add(slice);
                    }
                }
                offset += 24;
                byteList.Add(Convert.ToByte(0x0A));
            }
            byteList.Add(Convert.ToByte(0x1B));
            byteList.Add(Convert.ToByte('3'));
            byteList.Add((byte)30);
            return byteList.ToArray();
        }

        private static BitmapData GetBitmapData(Bitmap bill_image, int width)
        {
            using (var bitmap = bill_image)
            {
                var threshold = 127;
                var index = 0;
                double multiplier = width; // 이미지 width조정
                double scale = (double)(multiplier / (double)bitmap.Width);
                int xheight = (int)(bitmap.Height * scale);
                int xwidth = (int)(bitmap.Width * scale);
                var dimensions = xwidth * xheight;
                var dots = new BitArray(dimensions);

                for (var y = 0; y < xheight; y++)
                {
                    for (var x = 0; x < xwidth; x++)
                    {
                        var _x = (int)(x / scale);
                        var _y = (int)(y / scale);
                        var color = bitmap.GetPixel(_x, _y);
                        var luminance = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                        dots[index] = (luminance < threshold);
                        index++;
                    }
                }

                return new BitmapData()
                {
                    Dots = dots,
                    Height = (int)(bitmap.Height * scale),
                    Width = (int)(bitmap.Width * scale)
                };
            }
        }


        private class BitmapData
        {
            public BitArray Dots
            {
                get;
                set;
            }

            public int Height
            {
                get;
                set;
            }

            public int Width
            {
                get;
                set;
            }
        }
    


        private static String get_new_order_no() 
        {
            String order_no = "";

            if (mTheMode == "Local")
            {

                SQLiteDataReader dr;


                int local_order_cnt = 0;

                dr = sql_select_local_db("SELECT * FROM localOrderCnt WHERE biz_dt = '" + mBizDate + "'");
                if (dr.Read())
                {
                    local_order_cnt = int.Parse(dr["cnt"].ToString());
                    local_order_cnt++;

                    String sql = "UPDATE localOrderCnt SET cnt = " + local_order_cnt + " WHERE biz_dt='" + mBizDate + "'";
                    int ret = sql_excute_local_db(sql);
                }
                else
                {
                    local_order_cnt = 1;

                    String sql = "INSERT INTO localOrderCnt (biz_dt, cnt) values ('" + mBizDate + "', " + local_order_cnt + ")";
                    int ret = sql_excute_local_db(sql);
                }
                dr.Close();


                // 로컬모드 주문번호는 5자리
                order_no = mPosNo + local_order_cnt.ToString("000");

            }
            else
            {
                String sUrl = "orderNo?siteId=" + mSiteId + "&bizDt=" + mBizDate;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["orderNo"].ToString();
                        JArray arr = JArray.Parse(data);
                        order_no = convert_number(arr[0]["orderNo"].ToString()).ToString("0000");
                    }
                    else
                    {
                        MessageBox.Show("데이터 오류. orderNo\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. orderNo\n\n" + mErrorMsg, "thepos");
                }
            }

            //
            return order_no;
        }



        public struct order_pack
        {
            public string goods_name;
            public int goods_cnt;
            public List<string> option_name;
            public List<string> option_item_name;
        }
        


        public static void print_order()
        {
            int shop_order_count = 0;

            for (int i = 0; i < mOrderItemList.Count; i++)
            {
                if (mOrderItemList[i].shop_order_no != "" & mOrderItemList[i].ticket != "Y" & mOrderItemList[i].dcr_des != "E")  // "E" 전체할인
                {
                    shop_order_count++;
                }
            }



            MemOrderItem[] orderItemArr = new MemOrderItem[shop_order_count];

            int t_cnt = 0;

            for (int i = 0; i < mOrderItemList.Count; i++)
            {
                if (mOrderItemList[i].shop_order_no != "" & mOrderItemList[i].ticket != "Y" & mOrderItemList[i].dcr_des != "E")  // "E" 전체할인
                {
                    orderItemArr[t_cnt] = mOrderItemList[i];
                    t_cnt++;
                }
            }


            if (orderItemArr.Length == 0)
                return;



             
            // 업장코드별로 정렬
            bool order_sort_complete = false;
            MemOrderItem memOrderItemTemp;

            while (!order_sort_complete)
            {
                order_sort_complete = true;
                for (int i = 0; i < orderItemArr.Length - 1; i++)
                {
                    if (string.Compare(orderItemArr[i].shop_order_no, orderItemArr[i + 1].shop_order_no) == 1)  // ascending
                    {
                        memOrderItemTemp = orderItemArr[i];
                        orderItemArr[i] = orderItemArr[i + 1];
                        orderItemArr[i + 1] = memOrderItemTemp;

                        order_sort_complete = false;
                    }
                }
            }


            //
            List<order_pack> order_pack_list = new List<order_pack>();
            order_pack orderPack = new order_pack();
            List<String> option_name_list = new List<String>();
            List<String> option_item_name_list = new List<String>();

            String t_shop_code = "";
            String t_order_no = "";
            String t_order_dt = get_today_date() + get_today_time();

            t_shop_code = orderItemArr[0].shop_code;
            t_order_no = orderItemArr[0].shop_order_no;



            //
            orderPack.goods_name = orderItemArr[0].goods_name;
            orderPack.goods_cnt = orderItemArr[0].cnt;

            for (int k = 0; k < orderItemArr[0].orderOptionItemList.Count; k++)
            {
                option_name_list.Add(orderItemArr[0].orderOptionItemList[k].option_name);
                option_item_name_list.Add(orderItemArr[0].orderOptionItemList[k].option_item_name);
            }

            orderPack.option_name = option_name_list.ToList();
            orderPack.option_item_name = option_item_name_list.ToList();

            order_pack_list.Add(orderPack);



            for (int i = 0; i < orderItemArr.Length - 1; i++)
            {
                if (string.Compare(orderItemArr[i].shop_order_no, orderItemArr[i + 1].shop_order_no) == 0)
                {

                }
                else
                {

                    // 업장주문서 출력 -> shop 등록정보 프린터
                    print_order_str("to_shop", t_shop_code, "주문서", t_order_no, order_pack_list, t_order_dt);


                    // 주문교환권 출력 -> 영수증프린터 : 함수내부에서 출력타입 Print Display 구분한다. 
                    print_order_str("to_local", t_shop_code, "교환권", t_order_no, order_pack_list, t_order_dt);


                    //
                    order_pack_list.Clear();
                    t_shop_code = orderItemArr[i + 1].shop_code;
                    t_order_no = orderItemArr[i + 1].shop_order_no;
                }



                //
                orderPack.goods_name = orderItemArr[i + 1].goods_name;
                orderPack.goods_cnt = orderItemArr[i + 1].cnt;

                option_name_list.Clear();
                option_item_name_list.Clear();

                for (int k = 0; k < orderItemArr[i + 1].orderOptionItemList.Count; k++)
                {
                    option_name_list.Add(orderItemArr[i + 1].orderOptionItemList[k].option_name);
                    option_item_name_list.Add(orderItemArr[i + 1].orderOptionItemList[k].option_item_name);
                }

                orderPack.option_name = option_name_list.ToList();
                orderPack.option_item_name = option_item_name_list.ToList();

                order_pack_list.Add(orderPack);

            }

            // 업장주문서 출력 -> shop 등록정보 프린터
            print_order_str("to_shop", t_shop_code, "주문서", t_order_no, order_pack_list, t_order_dt);


            // 주문교환권 출력 -> 영수증프린터 : 함수내부에서 출력타입 Print Display 구분한다. 
            print_order_str("to_local", t_shop_code, "교환권", t_order_no, order_pack_list, t_order_dt);

        }

        public static void print_order_str(String to_printer, String shop, String title, String order_no, List<order_pack> orderPackList, String order_dt)  // 주문서
        {
            String printer_type = "";
            String printer_name = "";


            if (to_printer == "to_shop")  // 주문서
            {
                for (int i = 0; i < mShop.Length; i++ )
                {
                    if (mShop[i].shop_code == shop)
                    {
                        printer_type = mShop[i].printer_type;

                        if (mShop[i].printer_type == "N")      printer_name = mShop[i].network_printer_name;    // Network
                        else if (mShop[i].printer_type == "R") printer_name = mBillPrinterPort;                 // Recept
                        else
                        {
                            return;
                        }
                    }
                }                
            }
            else if (to_printer == "to_local")  // 교환권
            {
                for (int i = 0; i < mShop.Length; i++)
                {
                    if (mShop[i].shop_code == shop)
                    {
                        if (mShop[i].printer_type != "")
                        {
                            if (mOrderPrintType == "Print") 
                            {
                                printer_name = mBillPrinterPort;
                                
                            }
                            else if (mOrderPrintType == "Display")
                            {
                                // 화면출력
                                //MessageBox.Show("교환권 화면출력", "thepos");
                                return;
                            }
                            else
                            {
                                // "" 출력없음.
                                return;
                            }
                        }
                        else
                        {
                            // "" 출력없음. - 주문서가 없으니 교환권도 없다.
                            return;
                        }
                    }
                }
            }


            // 프린터를 못핮으면 패스
            if (printer_name.Trim().Length == 0)
            {
                SetDisplayAlarm("E", title + "프린터 미설정");
                return;
            }


            //
            const string ESC = "\u001B";
            const string InitializePrinter = ESC + "@";

            PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();

            byte[] BytesValue = new byte[0];

            BytesValue = PrintExtensions.AddBytes(BytesValue, InitializePrinter);
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());

            BytesValue = PrintExtensions.AddBytes(BytesValue, sizeCharMedium());
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(title));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

            BytesValue = PrintExtensions.AddBytes(BytesValue, sizeCharLarge());   // 주문번호 크게 인쇄
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(order_no));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());


            /* 삼삼공카페 : 단독업장이기에 일단 코너명 제외. 추후 멀티업장인 경우 업장명 출력 개발예정
             
            // 멀티업장인 경우만 코너명을 출력한다.
            if (mShop.Length > 2)  // 콤보박스 첫칸 공백을 주기위해 [0]번 포함해서 단독업장이면 배열 2가 됨.
            {
                BytesValue = PrintExtensions.AddBytes(BytesValue, sizeCharMedium());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes("코너 : " + get_shop_name(shop)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
            }

            */


            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
            String strPrint = "------------------------------------------\r\n";  // 21 * 2
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));


            for (int i = 0; i < orderPackList.Count; i++)
            {
                //
                BytesValue = PrintExtensions.AddBytes(BytesValue, sizeCharMedium());


                String strName = orderPackList[i].goods_name;
                String strCnt = orderPackList[i].goods_cnt.ToString("N0");     // 수량

                int len = encodelen(orderPackList[i].goods_name) + encodelen(strCnt);

                if (len > 20)
                {
                    strPrint = strName + Space(41 - len) + strCnt; // 2줄
                }
                else
                {
                    strPrint = strName + Space(21 - len) + strCnt;
                }


                strPrint += "\r\n";

                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));


                //
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());

                for (int k = 0; k < orderPackList[i].option_name.Count; k++)
                {
                    strPrint = "     [" + orderPackList[i].option_name[k] + "]" + Space(18 - encodelen(orderPackList[i].option_name[k]));
                    String strTmp= orderPackList[i].option_item_name[k];     // 수량
                    strPrint += strTmp;
                    strPrint += "\r\n";

                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));
                }
            }


            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
            strPrint = "------------------------------------------\r\n";  // 21 * 2
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));



            strPrint = "주문시간 : " + order_dt.Substring(0, 4) + "-" + order_dt.Substring(4, 2) + "-" + order_dt.Substring(6, 2) + " " + order_dt.Substring(8, 2) + ":" + order_dt.Substring(10, 2) + "\r\n";
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));


            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

            BytesValue = PrintExtensions.AddBytes(BytesValue, CutPage());


            if (printer_type == "N")
            {
                try
                {
                    TcpClient client = new TcpClient();

                    var result = client.BeginConnect(printer_name, 9100, null, null);
                    var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));
                    if (!success)
                    {
                        throw new Exception("Failed to connect.");
                    }

                    //client.Connect(printer_name, 9100);

                    NetworkStream stream = client.GetStream();
                    stream.Write(BytesValue, 0, BytesValue.Length);

                    stream.Flush();
                    stream.Close();

                    //client.EndConnect(result);
                    client.Close();
                }
                catch
                {
                    MessageBox.Show("주문서 출력 오류. \r\n 헬프데스크로 문의바랍니다.");
                }
            }
            else
            {
                try
                {
                    SerialPort mySerialPort = new SerialPort();
                    mySerialPort.PortName = mBillPrinterPort;
                    mySerialPort.BaudRate = convert_number(mBillPrinterSpeed);
                    mySerialPort.Parity = Parity.None;
                    mySerialPort.StopBits = StopBits.One;
                    mySerialPort.DataBits = 8;
                    mySerialPort.Handshake = Handshake.None;

                    mySerialPort.Open();

                    mySerialPort.Write(BytesValue, 0, BytesValue.Length);
                    mySerialPort.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("프린터 출력 오류.\r\n" + ex.Message);
                    return;
                }

            }

        }


        // 취소용
        public static void print_order_str(String to_printer, String shop, String title, String order_no, List<String> name, List<int> cnt, String order_dt)  // 주문서
        {
            String printer_type = "";
            String printer_name = "";

            if (to_printer == "to_shop")
            {
                for (int i = 0; i < mShop.Length; i++)
                {
                    if (mShop[i].shop_code == shop)
                    {
                        printer_type = mShop[i].printer_type;

                        if (mShop[i].printer_type == "N") printer_name = mShop[i].network_printer_name;    // Network
                        else if (mShop[i].printer_type == "L") printer_name = mBillPrinterPort;                 // Recept
                        else
                        {
                            return;
                        }
                    }
                }
            }
            else if (to_printer == "to_local")
            {
                for (int i = 0; i < mShop.Length; i++)
                {
                    if (mShop[i].shop_code == shop)
                    {
                        if (mShop[i].printer_type != "")
                        {
                            if (mOrderPrintType == "Print")
                            {
                                printer_name = mBillPrinterPort;

                            }
                            else if (mOrderPrintType == "Display")
                            {
                                // 화면출력 -> 현재 없음
                                //MessageBox.Show("교환권 화면출력", "thepos");
                                return;
                            }
                            else
                            {
                                // "" 출력없음.
                                return;
                            }
                        }
                        else
                        {
                            // "" 출력없음. - 주문서가 없으니 교환권도 없다.
                            return;
                        }
                    }
                }
            }


            // 프린터를 못핮으면 패스
            if (printer_name.Trim().Length == 0)
            {
                SetDisplayAlarm("E", title + "프린터 미설정");
                return;
            }


            //
            const string ESC = "\u001B";
            const string InitializePrinter = ESC + "@";

            PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();

            byte[] BytesValue = new byte[0];

            BytesValue = PrintExtensions.AddBytes(BytesValue, InitializePrinter);
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());

            BytesValue = PrintExtensions.AddBytes(BytesValue, sizeCharMedium());
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(title));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

            BytesValue = PrintExtensions.AddBytes(BytesValue, sizeCharLarge());   // 주문번호 크게 인쇄
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(order_no));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());



            /* 삼삼공카페 : 단독업장이기에 일단 코너명 제외. 추후 멀티업장인 경우 업장명 출력 개발예정
             
            // 멀티업장인 경우만 코너명을 출력한다.
            if (mShop.Length > 2)  // 콤보박스 첫칸 공백을 주기위해 [0]번 포함해서 단독업장이면 배열 2가 됨.
            {
                BytesValue = PrintExtensions.AddBytes(BytesValue, sizeCharMedium());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes("코너 : " + get_shop_name(shop)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
            }
            */



            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
            String strPrint = "------------------------------------------\r\n";  // 21 * 2
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));

            for (int i = 0; i < name.Count; i++)
            {
                BytesValue = PrintExtensions.AddBytes(BytesValue, sizeCharMedium());


                String strName = name[i];
                String strCnt = cnt[i].ToString("N0");     // 수량

                int len = encodelen(strName) + encodelen(strCnt);

                if (len > 20)
                {
                    strPrint = strName + Space(41 - len) + strCnt; // 2줄
                }
                else
                {
                    strPrint = strName + Space(21 - len) + strCnt;
                }


                strPrint += "\r\n";

                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));

            }

            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
            strPrint = "------------------------------------------\r\n";  // 21 * 2
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));


            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
            strPrint = "주문시간 : " + order_dt.Substring(0, 4) + "-" + order_dt.Substring(4, 2) + "-" + order_dt.Substring(6, 2) + " " + order_dt.Substring(8, 2) + ":" + order_dt.Substring(10, 2) + "\r\n";
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(strPrint));


            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

            BytesValue = PrintExtensions.AddBytes(BytesValue, CutPage());


            if (printer_type == "N")
            {
                try
                {
                    TcpClient client = new TcpClient();
                    client.Connect(printer_name, 9100);

                    NetworkStream stream = client.GetStream();
                    stream.Write(BytesValue, 0, BytesValue.Length);

                    stream.Flush();
                    stream.Close();
                    client.Close();
                }
                catch
                {
                    MessageBox.Show("주문서 출력 오류. \r\n 헬프데스크로 문의바랍니다.");
                }
            }
            else
            {
                try
                {
                    SerialPort mySerialPort = new SerialPort();
                    mySerialPort.PortName = mBillPrinterPort;
                    mySerialPort.BaudRate = convert_number(mBillPrinterSpeed);
                    mySerialPort.Parity = Parity.None;
                    mySerialPort.StopBits = StopBits.One;
                    mySerialPort.DataBits = 8;
                    mySerialPort.Handshake = Handshake.None;

                    mySerialPort.Open();

                    mySerialPort.Write(BytesValue, 0, BytesValue.Length);
                    mySerialPort.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("프린터 출력 오류.\r\n" + ex.Message);
                    return;
                }

                //PrintExtensions.Print(BytesValue, printer_name);
            }

        }


        public static int requestCardCancel(PaymentCard pCardAuth, out PaymentCard pCardCancel)
        {
            int ret = 0;
            PaymentCard cardCancel = new PaymentCard();
            pCardCancel = cardCancel;

            if (mVanCode == "KCP")
            {
                paymentKCP p = new paymentKCP();
                ret = p.requestKcpCardCancel(pCardAuth, out pCardCancel);
            }
            else if (mVanCode == "NICE")
            {
                paymentNice p = new paymentNice();
                ret = p.requestNiceCardCancel(pCardAuth, out pCardCancel);
            }
            else if (mVanCode == "KOVAN")
            {
                paymentKovan p = new paymentKovan();
                ret = p.requestKovanCardCancel(pCardAuth, out pCardCancel);
            }
            else if (mVanCode == "TOSS")
            {
                paymentToss p = new paymentToss();
                ret = p.requestTossCardCancel(pCardAuth, out pCardCancel);
            }


            return ret;
        }


        public static int requestCashCancel(PaymentCash paymentCash, out PaymentCash pCashCancel)
        {
            int ret = 0;
            PaymentCash cashCancel = new PaymentCash();
            pCashCancel = cashCancel;

            if (mVanCode == "KCP")
            {
                paymentKCP p = new paymentKCP();
                ret = p.requestKcpCashCancel(paymentCash, out pCashCancel);
            }
            else if (mVanCode == "NICE")
            {
                paymentNice p = new paymentNice();
                ret = p.requestNiceCashCancel(paymentCash, out pCashCancel);
            }
            else if (mVanCode == "KOVAN")
            {
                paymentKovan p = new paymentKovan();
                ret = p.requestKovanCashCancel(paymentCash, out pCashCancel);
            }
            else if (mVanCode == "TOSS")
            {
                paymentToss p = new paymentToss();
                ret = p.requestTossCashCancel(paymentCash, out pCashCancel);
            }

            return ret;
        }


        public static int requestEasyCancel(PaymentEasy paymentEasy, out PaymentEasy pEasyCancel)
        {
            int ret = 0;
            PaymentEasy easyCancel = new PaymentEasy();
            pEasyCancel = easyCancel;

            if (mVanCode == "KCP")
            {
                paymentKCP p = new paymentKCP();
                ret = p.requestKcpEasyCancel(paymentEasy, out pEasyCancel);
            }
            else if (mVanCode == "NICE")
            {
                paymentNice p = new paymentNice();
                ret = p.requestNiceEasyCancel(paymentEasy, out pEasyCancel);
            }
            else if (mVanCode == "KOVAN")
            {
                //

            }
            else if (mVanCode == "TOSS")
            {
                // 

            }

            return ret;
        }


        public static int requestCertCancel(PaymentCert paymentCert, out PaymentCert pCertCancel)
        {
            int ret = 0;
            PaymentCert certCancel = new PaymentCert();
            pCertCancel = certCancel;

            if (paymentCert.van_code == "PM")
            {
                couponPM p = new couponPM();
                ret = p.requestPmCertCancel(paymentCert.coupon_no);
            }

            return ret;
        }

        public static void display_error_msg(string msg)
        {
            MessageBox.Show(msg, "thepos");
        }

    }
}
