using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;
using static thepos.frmSales;
using Newtonsoft.Json.Linq;
using System.Security.Policy;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;
using System.Drawing.Drawing2D;
using static thepos.frmSub;

namespace thepos
{
    public partial class frmFlowSettlement : Form
    {
        TextBox saveKeyDisplay;

        TicketFlow mThisTicketFlow = new TicketFlow();
        public static String mThisBizDt = "";
        public static String mThisPosNo = "";
        public static String mThisTicketNo = "";
        public static String mSelectedTicketNo = "";

        public static ListView mLvwTicketFlow;
        public static ListView mLvwTicketSettle;


        public frmFlowSettlement()
        {
            InitializeComponent();
            initialize_font();
            initialize_the();
        }

        private void initialize_font()
        {
            lblTitle.Font = font12;
            btnClose.Font = font12;

            lblBizDtTitle.Font = font9;
            dtBizDt.Font = font10;

            lblPosNoTitle.Font = font9;
            cbPosNo.Font = font10;

            lblTicketNoTitle.Font = font9;
            tbTicketNo.Font = font10;

            btnView.Font = font10;
            lvwTicketFlow.Font = font10;

            lblTicketSettleTitle.Font = font9;
            lvwTicketSettle.Font = font10;

            btnCancelReq.Font = font10;
            btnSettleBill.Font = font10;
        }

        private void initialize_the()
        {
            mLvwTicketFlow = lvwTicketFlow;
            mLvwTicketSettle = lvwTicketSettle;


            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwTicketFlow.SmallImageList = imgList;
            lvwTicketSettle.SmallImageList = imgList;

            dtBizDt.Value = new DateTime(convert_number(mBizDate.Substring(0, 4)), convert_number(mBizDate.Substring(4, 2)), convert_number(mBizDate.Substring(6, 2)));


            cbPosNo.Items.Clear();
            for (int i = 0; i < mPosNoList.Length; i++)
            {
                cbPosNo.Items.Add(mPosNoList[i]);
            }
            cbPosNo.Items.Add("");
            cbPosNo.SelectedIndex = cbPosNo.Items.Count - 1;


            saveKeyDisplay = mTbKeyDisplayController;
            mTbKeyDisplayController = tbTicketNo;

            mPayClass = "ST"; // 정산 settement


            // 후불식이이면 취소버튼을 안보이게한다.. 
            if (mTicketType == "PD") btnCancelReq.Visible = false;

            // 결제버튼
            mTableLayoutPanelPayControl.Enabled = false;

        }


        struct point_back
        {
            public string pay_type;
            public string the_no;
            public int pay_seq;
            public string pay_class;
            public int amount;
            public string result_code;
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            if (cbPosNo.SelectedIndex < 0) return;

            mSelectedTicketNo = "";
            mThisBizDt = dtBizDt.Value.ToString("yyyyMMdd");
            mThisPosNo = cbPosNo.Text;

            mThisTicketNo = "";
            String t8No = tbTicketNo.Text;

            if (t8No.Length == 8 & mThisPosNo.Length == 2)
            {
                mThisTicketNo = mSiteId + dtBizDt.Value.ToString("yyyyMMdd") + mThisPosNo + t8No;
            }

            view_ticket_flow(mThisBizDt, mThisPosNo, mThisTicketNo);

            // 결제버튼
            mTableLayoutPanelPayControl.Enabled = false;

        }


        public static void view_ticket_flow(String biz_date, String pos_no, String t_no)
        { 

            mLvwTicketFlow.Items.Clear();
            mLvwTicketSettle.Items.Clear();
            mLvwOrderItem.Items.Clear();



            String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + biz_date + "&posNo=" + pos_no + "&ticketNo=" + t_no;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["ticketFlows"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        TicketFlow ticketFlow = new TicketFlow();

                        ticketFlow.site_id = arr[i]["siteId"].ToString();
                        ticketFlow.biz_dt = arr[i]["bizDt"].ToString();
                        ticketFlow.the_no = arr[i]["theNo"].ToString();
                        ticketFlow.ref_no = arr[i]["refNo"].ToString();

                        ticketFlow.ticket_no = arr[i]["ticketNo"].ToString();
                        ticketFlow.ticketing_dt = arr[i]["ticketingDt"].ToString();
                        ticketFlow.charge_dt = arr[i]["chargeDt"].ToString();
                        ticketFlow.settlement_dt = arr[i]["settlementDt"].ToString();

                        ticketFlow.point_charge_cnt = convert_number(arr[i]["pointChargeCnt"].ToString());
                        ticketFlow.point_usage_cnt = convert_number(arr[i]["pointUsageCnt"].ToString());

                        ticketFlow.point_charge = convert_number(arr[i]["pointCharge"].ToString());
                        ticketFlow.point_usage = convert_number(arr[i]["pointUsage"].ToString());

                        ticketFlow.settle_point_charge = convert_number(arr[i]["settlePointCharge"].ToString());
                        ticketFlow.settle_point_usage = convert_number(arr[i]["settlePointUsage"].ToString());

                        ticketFlow.goods_code = arr[i]["goodsCode"].ToString();
                        ticketFlow.flow_step = arr[i]["flowStep"].ToString();

                        ticketFlow.locker_no = arr[i]["lockerNo"].ToString();
                        ticketFlow.open_locker = arr[i]["openLocker"].ToString();


                        //
                        ListViewItem item = new ListViewItem();

                        String ticket_no = ticketFlow.ticket_no;
                        String tStat = "";

                        if (ticketFlow.flow_step == "0") tStat = "접수";
                        else if (ticketFlow.flow_step == "1") tStat = "발권";
                        else if (ticketFlow.flow_step == "2") tStat = "충전";
                        else if (ticketFlow.flow_step == "3") tStat = "사용중";
                        else if (ticketFlow.flow_step == "4") tStat = "정산중";
                        else if (ticketFlow.flow_step == "9") tStat = "정산완료";


                        item.Tag = ticketFlow;
                        item.Text = ticket_no.Substring(14, 6) + "-" + ticket_no.Substring(20, 2);
                        item.SubItems.Add(ticketFlow.point_charge.ToString("N0"));
                        item.SubItems.Add(ticketFlow.point_usage.ToString("N0"));
                        item.SubItems.Add(tStat);
                        item.SubItems.Add(ticketFlow.settle_point_charge.ToString("N0"));
                        item.SubItems.Add(ticketFlow.settle_point_usage.ToString("N0"));


                        // 정산완료이면 ForeColor=gray로 변경
                        if (ticketFlow.flow_step == "9")
                        {
                            item.ForeColor = Color.Gray;
                            item.SubItems[1].ForeColor = Color.Gray;
                            item.SubItems[2].ForeColor = Color.Gray;
                            item.SubItems[3].ForeColor = Color.Gray;
                            item.SubItems[4].ForeColor = Color.Gray;
                            item.SubItems[5].ForeColor = Color.Gray;
                        }


                        mLvwTicketFlow.Items.Add(item);

                        if (ticket_no == mSelectedTicketNo)
                        {
                            mLvwTicketFlow.Items[i].Selected = true;
                        }
                    }
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


        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFlowSettlement_FormClosed(object sender, FormClosedEventArgs e)
        {
            mClearSaleForm();

            mTbKeyDisplayController = saveKeyDisplay;
            mPayClass = "OR"; // 원복: order

            mPanelMiddle.Visible = false;
            mPanelMiddle.Controls.Clear();

            // 결제버튼
            mTableLayoutPanelPayControl.Enabled = true;


        }

        private void lvwTicketFlow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwTicketFlow.SelectedItems.Count == 0) return;

            //
            mThisTicketFlow = (TicketFlow)lvwTicketFlow.SelectedItems[0].Tag;
            mSelectedTicketNo = mThisTicketFlow.ticket_no;


            view_on_order();
            view_on_ticketpay();

            // 결제버튼
            mTableLayoutPanelPayControl.Enabled = false;

        }


        void view_on_order()
        {
            // 여기는 이후 데이터 처리는 없고, 과정상 화면보이기 기능만 있음.

            mOrderItemList.Clear();


            // 포인트 사용 건수 총액
            if (mThisTicketFlow.point_usage > 0)
            {
                MemOrderItem orderItem = new MemOrderItem();

                orderItem.lv_order_no = mOrderItemList.Count + 1;
                orderItem.lv_goods_name = "포인트사용";
                orderItem.lv_cnt = mThisTicketFlow.point_usage_cnt.ToString("N0");
                orderItem.lv_amt = "";
                orderItem.lv_dc_amount = "";
                orderItem.lv_net_amount = mThisTicketFlow.point_usage.ToString("N0");

                orderItem.option_name_description = "";
                orderItem.option_amt_description = "";
                orderItem.option_dc_amount_description = "";
                
                mOrderItemList.Add(orderItem);
            }

            // 선불식이면 충전을 표시
            if (mTicketType == "PA")
            {
                if (mThisTicketFlow.point_charge > 0)
                {
                    MemOrderItem orderItem = new MemOrderItem();

                    orderItem.lv_order_no = mOrderItemList.Count + 1;
                    orderItem.lv_goods_name = "포인트충전";
                    orderItem.lv_cnt = mThisTicketFlow.point_charge_cnt.ToString("N0");
                    orderItem.lv_amt = "";
                    orderItem.lv_dc_amount = "";
                    orderItem.lv_net_amount = mThisTicketFlow.point_charge.ToString("N0");

                    orderItem.option_name_description = "";
                    orderItem.option_amt_description = "";
                    orderItem.option_dc_amount_description = "";

                    mOrderItemList.Add(orderItem);
                }
            }

            mLvwOrderItem.SetObjects(mOrderItemList);



            // 총괄상황표시때는 직접 아래를 
            //ReCalculateAmount();

            mLblOrderAmount.Text = "";  // 총금액
            mLblOrderAmountDC.Text = "";
            mLblOrderAmountNet.Text = mThisTicketFlow.point_usage.ToString("N0");       // 받을금액
            mLblOrderAmountReceive.Text = mThisTicketFlow.point_charge.ToString("N0");  // 받은금액      

            if (mTicketType == "PA")  // 선불
                mLblOrderAmountRest.Text = (mThisTicketFlow.point_charge - mThisTicketFlow.point_usage).ToString("N0"); // 환불금액
            else
                mLblOrderAmountRest.Text = "";

            // Sub Screen 표시
            DisplaySubScreen();


        }


        void view_on_ticketpay()
        {
            lvwTicketSettle.Items.Clear();


            if (mThisTicketFlow.point_usage > 0)
            {
                ListViewItem item = new ListViewItem();
                point_back bpoint = new point_back();

                item.Text = mThisTicketFlow.ticket_no.Substring(14, 6) + "-" + mThisTicketFlow.ticket_no.Substring(20, 2);
                item.SubItems.Add("포인트사용");
                item.SubItems.Add(mThisTicketFlow.point_usage_cnt.ToString("N0"));
                item.SubItems.Add(mThisTicketFlow.point_usage.ToString("N0"));

                if (mThisTicketFlow.settle_point_usage == 0)
                {
                    item.SubItems.Add("승인요망");
                    bpoint.result_code = "0";
                }
                else
                {
                    item.SubItems.Add("승인 - 완료");
                    bpoint.result_code = "1";

                    item.ForeColor = Color.Gray;
                    item.SubItems[1].ForeColor = Color.Gray;
                    item.SubItems[2].ForeColor = Color.Gray;
                    item.SubItems[3].ForeColor = Color.Gray;
                    item.SubItems[4].ForeColor = Color.Gray;
                }

                bpoint.pay_type = mTicketType;
                bpoint.pay_seq = 1;
                bpoint.the_no = "";
                bpoint.amount = mThisTicketFlow.point_usage;
                bpoint.pay_class = "US";

                item.Tag = bpoint;

                lvwTicketSettle.Items.Add(item);
            }


            if (mTicketType == "PA")
            {
                if (mThisTicketFlow.point_charge > 0)
                {
                    ListViewItem item = new ListViewItem();
                    point_back bpoint = new point_back();

                    item.Text = mThisTicketFlow.ticket_no.Substring(14, 6) + "-" + mThisTicketFlow.ticket_no.Substring(20, 2);
                    item.SubItems.Add("포인트충전");
                    item.SubItems.Add(mThisTicketFlow.point_charge_cnt.ToString("N0"));
                    item.SubItems.Add(mThisTicketFlow.point_charge.ToString("N0"));

                    if (mThisTicketFlow.point_charge > mThisTicketFlow.settle_point_charge)
                    {
                        item.SubItems.Add("취소요망");
                        bpoint.result_code = "0";
                    }
                    else
                    {
                        item.SubItems.Add("취소 - 완료");
                        bpoint.result_code = "1";

                        item.ForeColor = Color.Gray;
                        item.SubItems[1].ForeColor = Color.Gray;
                        item.SubItems[2].ForeColor = Color.Gray;
                        item.SubItems[3].ForeColor = Color.Gray;
                        item.SubItems[4].ForeColor = Color.Gray;

                    }

                    bpoint.pay_type = mTicketType;
                    bpoint.pay_seq = 1;
                    bpoint.the_no = "";
                    bpoint.amount = mThisTicketFlow.point_charge;
                    bpoint.pay_class = "CH";

                    item.Tag = bpoint;


                    lvwTicketSettle.Items.Add(item);
                }
            }
        }


        private void lvwTicketSettle_SelectedIndexChanged(object sender, EventArgs e)
        {
            mOrderItemList.Clear();
            mLvwOrderItem.SetObjects(mOrderItemList);

            if (lvwTicketSettle.SelectedItems.Count < 1) { return; }


            point_back bpoint = (point_back)lvwTicketSettle.SelectedItems[0].Tag;



            if (bpoint.pay_class == "US")
            {
                if (bpoint.result_code == "1")  // 정산완료-승인완료
                {
                    //
                }
                else
                {
                    String sUrl = "orderItem?siteId=" + mSiteId + "&bizDt=" + mThisBizDt + "&ticketNo=" + mThisTicketFlow.ticket_no;
                    if (mRequestGet(sUrl))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                            String data = mObj["orderItems"].ToString();
                            JArray arr = JArray.Parse(data);

                            for (int i = 0; i < arr.Count; i++)
                            {
                                if (arr[i]["payClass"].ToString() == "US" & (arr[i]["isCancel"].ToString() != "Y" & arr[i]["isCancel"].ToString() != "y"))
                                {
                                    MemOrderItem orderItem = new MemOrderItem();

                                    orderItem.goods_code = arr[i]["goodsCode"].ToString();
                                    orderItem.goods_name = arr[i]["goodsName"].ToString();
                                    orderItem.cnt = convert_number(arr[i]["cnt"].ToString());
                                    orderItem.amt = convert_number(arr[i]["amt"].ToString());
                                    orderItem.option_amt = convert_number(arr[i]["optionAmt"].ToString());
                                    orderItem.dc_amount = convert_number(arr[i]["dcAmount"].ToString());
                                    orderItem.dcr_des = arr[i]["dcrDes"].ToString();
                                    orderItem.dcr_type = arr[i]["dcrType"].ToString();
                                    orderItem.dcr_value = convert_number(arr[i]["dcrValue"].ToString());
                                    orderItem.ticket = arr[i]["ticketYn"].ToString();
                                    orderItem.taxfree = arr[i]["taxFree"].ToString();
                                    orderItem.pay_class = arr[i]["payClass"].ToString();
                                    orderItem.ticket_no = arr[i]["ticketNo"].ToString();
                                    orderItem.shop_code = arr[i]["shopCode"].ToString();
                                    orderItem.option_no = arr[i]["optionNo"].ToString();

                                    List<orderOptionItem> orderOptionItemList = new List<orderOptionItem>();

                                    orderOptionItem orderOptionItem = new orderOptionItem();


                                    if (arr[i]["optionNo"].ToString() != "")
                                    {
                                        sUrl = "orderOptionItem?siteId=" + mSiteId + "&bizDt=" + mThisBizDt + "&optionNo=" + arr[i]["optionNo"].ToString();
                                        if (mRequestGet(sUrl))
                                        {
                                            if (mObj["resultCode"].ToString() == "200")
                                            {
                                                String data2 = mObj["orderOptionItems"].ToString();
                                                JArray arr2 = JArray.Parse(data2);

                                                for (int k = 0; k < arr2.Count; k++)
                                                {
                                                    orderOptionItem.option_item_no = convert_number(arr2[k]["optionItemNo"].ToString());
                                                    orderOptionItem.option_item_name = arr2[k]["optionItemName"].ToString();
                                                    orderOptionItem.option_code = arr2[k]["optionCode"].ToString();
                                                    orderOptionItem.option_name = arr2[k]["optionName"].ToString();
                                                    orderOptionItem.amt = convert_number(arr2[k]["amt"].ToString());

                                                    orderOptionItemList.Add(orderOptionItem);

                                                    orderItem.option_name_description += " " + arr2[k]["optionItemName"].ToString();
                                                }

                                                orderItem.orderOptionItemList = orderOptionItemList;
                                                orderItem.option_item_cnt = mOrderOptionItemList.Count;

                                                //
                                                if (orderOptionItemList.Count > 0)
                                                {
                                                    orderItem.option_amt_description = orderItem.option_amt.ToString("N0");
                                                }
                                                else
                                                {
                                                    orderItem.option_amt_description = "";
                                                }


                                            }
                                            else
                                            {
                                                MessageBox.Show("결제데이터 오류. paymentCard\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("시스템오류. paymentCard\n\n" + mErrorMsg, "thepos");
                                        }
                                    }

                                    //
                                    replace_mem_order_item(ref orderItem, "add");

                                    mOrderItemList.Add(orderItem);
                                    mLvwOrderItem.SetObjects(mOrderItemList);
                                }
                            }

                            //
                            ReCalculateAmount();

                            // 결제버튼
                            mTableLayoutPanelPayControl.Enabled = true;

                        }
                        else
                        {
                            MessageBox.Show("결제데이터 오류. paymentCard\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류. paymentCard\n\n" + mErrorMsg, "thepos");
                    }
                }
            }
            else  // 충전 - 취소대상
            {
                if (bpoint.result_code == "1")  // 정산완료-승인완료
                {
                    //
                }
                else
                {
                    String sUrl = "orderItem?siteId=" + mSiteId + "&bizDt=" + mThisBizDt + "&ticketNo=" + mThisTicketFlow.ticket_no;
                    if (mRequestGet(sUrl))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                            String data = mObj["orderItems"].ToString();
                            JArray arr = JArray.Parse(data);

                            for (int i = 0; i < arr.Count; i++)
                            {
                                if (arr[i]["payClass"].ToString() == "CH" & (arr[i]["isCancel"].ToString() != "Y" & arr[i]["isCancel"].ToString() != "y"))
                                {
                                    MemOrderItem orderItem = new MemOrderItem();

                                    orderItem.goods_code = arr[i]["goodsCode"].ToString();
                                    orderItem.goods_name = arr[i]["goodsName"].ToString();
                                    orderItem.cnt = convert_number(arr[i]["cnt"].ToString());
                                    orderItem.amt = convert_number(arr[i]["amt"].ToString());
                                    orderItem.option_amt = convert_number(arr[i]["optionAmt"].ToString());
                                    orderItem.dc_amount = convert_number(arr[i]["dcAmount"].ToString());
                                    orderItem.dcr_des = arr[i]["dcrDes"].ToString();
                                    orderItem.dcr_type = arr[i]["dcrType"].ToString();
                                    orderItem.dcr_value = convert_number(arr[i]["dcrValue"].ToString());
                                    orderItem.ticket = arr[i]["ticketYn"].ToString();
                                    orderItem.pay_class = arr[i]["payClass"].ToString();
                                    orderItem.ticket_no = arr[i]["ticketNo"].ToString();


                                    //
                                    replace_mem_order_item(ref orderItem, "add");

                                    mOrderItemList.Add(orderItem);
                                    mLvwOrderItem.SetObjects(mOrderItemList);
                                }
                            }



                            //
                            //ReCalculateAmount();
                            // 충전취소상황표시때는 직접 아래를 
                            //ReCalculateAmount();
                            mLblOrderAmount.Text = "";  // 총금액
                            mLblOrderAmountDC.Text = "";
                            mLblOrderAmountNet.Text = "";       // 받을금액
                            mLblOrderAmountReceive.Text = "";  // 받은금액      
                            mLblOrderAmountRest.Text = mThisTicketFlow.point_charge.ToString("N0"); // 환불금액

                            // Sub Screen 표시
                            DisplaySubScreen();



                            // 충전건 취소에 해당함으로 결제버튼을 잠근다.
                            // 결제버튼
                            mTableLayoutPanelPayControl.Enabled = false;


                        }
                        else
                        {
                            MessageBox.Show("결제데이터 오류. paymentCard\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류. paymentCard\n\n" + mErrorMsg, "thepos");
                    }

                }

            }

        }

        private void btnCancelReq_Click(object sender, EventArgs e)
        {

            if (lvwTicketSettle.SelectedItems.Count < 1) { return; }

            point_back bpoint = (point_back)lvwTicketSettle.SelectedItems[0].Tag;

            if (bpoint.result_code == "1") return;


            if (bpoint.pay_class != "CH") return;




            //
            int select_idx = 0;

            mPanelCancel.Controls.Clear();
            mPanelCancel.Visible = true;

            Form fForm = new frmFlowSettleChargeCancel(mThisTicketFlow.biz_dt, mThisTicketFlow.ticket_no) { TopLevel = false, TopMost = true };

            mPanelCancel.Controls.Add(fForm);
            fForm.Show();

            mPanelCancel.BringToFront();




            //? 화면갱신
            //view_on_ticketpay();


        }

        private void btnScanner_Click(object sender, EventArgs e)
        {
            btnScanner.Enabled = false;

            Form fFlow;
            fFlow = new frmScanner(22);  // ticket_no
            fFlow.ShowDialog();


            if (mIsScanOK)
            {
                try
                {
                    String dt = mScanString.Substring(4, 8);
                    String posno = mScanString.Substring(12, 2);
                    String t7no = mScanString.Substring(14, 8);

                    int yyyy = int.Parse(dt.Substring(0, 4));
                    int mm = int.Parse(dt.Substring(4, 2));
                    int dd = int.Parse(dt.Substring(6, 2));

                    dtBizDt.Value = new DateTime(yyyy, mm, dd);
                    mThisBizDt = dtBizDt.Value.ToString("yyyyMMdd");

                    for (int i = 0; i < cbPosNo.Items.Count; i++)
                    {
                        if (cbPosNo.Items[i].ToString() == posno)
                        {
                            cbPosNo.SelectedIndex = i;
                        }
                    }

                    mThisPosNo = cbPosNo.Text;

                    tbTicketNo.Text = t7no;

                    view_ticket_flow(dt, posno, mScanString);
                }
                catch
                {
                    SetDisplayAlarm("W", "스캔데이터 포멧 오류.");
                    //return;
                }
            }

            btnScanner.Enabled = true;

        }


        public static void cancel_point_payment(String ticket_no)
        {
            // 1
            List<String> list_the_no = new List<string>();

            // get
            String sUrl = "paymentPoint?siteId=" + mSiteId + "&bizDt=" + mThisBizDt + "&ticketNo=" + mSelectedTicketNo + "&payClass=US";
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["paymentPoints"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        //
                        list_the_no.Add(arr[i]["theNo"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("결제데이터 오류. paymentPoint\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. paymentPoint\n\n" + mErrorMsg, "thepos");
            }



            // 2 
            for (int i = 0;i < list_the_no.Count; i++) 
            {
                // Payment 취소건 추가
                sUrl = "payment?siteId=" + mSiteId + "&bizDt=" + mThisBizDt + "&theNo=" + list_the_no[i];
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["payments"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr[0]["isCancel"].ToString() != "Y" & arr[0]["isCancel"].ToString() != "y")
                        {
                            // Payment 취소건 추가
                            Dictionary<string, string> param = new Dictionary<string, string>();
                            param.Clear();
                            param["siteId"] = mSiteId;
                            param["posNo"] = mPosNo;
                            param["bizDt"] = mBizDate;
                            param["theNo"] = arr[0]["theNo"].ToString();
                            param["refNo"] = arr[0]["refNo"].ToString();
                            param["payDate"] = get_today_date();
                            param["payTime"] = get_today_time();
                            param["tranType"] = "C";
                            param["payClass"] = arr[0]["payClass"].ToString();
                            param["billNo"] = arr[0]["billNo"].ToString();
                            param["netAmount"] = arr[0]["netAmount"].ToString();
                            param["amountCash"] = arr[0]["amountCash"].ToString();
                            param["amountCard"] = arr[0]["amountCard"].ToString();
                            param["amountEasy"] = arr[0]["amountEasy"].ToString();
                            param["amountPoint"] = arr[0]["amountPoint"].ToString();
                            param["dcAmount"] = arr[0]["dcAmount"].ToString();
                            param["isCancel"] = "y";

                            if (mRequestPost("payment", param))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {
                                }
                                else
                                {
                                    MessageBox.Show("오류. 취소건추가. payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("시스템오류 payment\n\n" + mErrorMsg, "thepos");
                                return;
                            }


                            // payment 승인건 취소마킹
                            Dictionary<string, string> parameters = new Dictionary<string, string>();
                            parameters.Clear();
                            parameters["siteId"] = mSiteId;
                            parameters["bizDt"] = mThisBizDt;
                            parameters["theNo"] = list_the_no[i];
                            parameters["tranType"] = "A";
                            parameters["isCancel"] = "y";

                            if (mRequestPatch("payment", parameters))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {
                                }
                                else
                                {
                                    MessageBox.Show("오류. 취소마킹. payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
                                return;
                            }


                            // paymentPoint 취소마킹
                            parameters.Clear();
                            parameters["siteId"] = mSiteId;
                            parameters["bizDt"] = mThisBizDt;
                            parameters["theNo"] = list_the_no[i];
                            parameters["payType"] = "PA";
                            parameters["isCancel"] = "y";

                            if (mRequestPatch("paymentPoint", parameters))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {
                                }
                                else
                                {
                                    MessageBox.Show("오류. 취소마킹. paymentPoint\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("시스템오류. paymentPoint\n\n" + mErrorMsg, "thepos");
                                return;
                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("결제데이터 오류. payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
                    return;
                }



            }

        }

        private void btnSettleBill_Click(object sender, EventArgs e)
        {
            if (lvwTicketSettle.SelectedItems.Count < 1) { return; }

            point_back bpoint = (point_back)lvwTicketSettle.SelectedItems[0].Tag;

            if (bpoint.result_code != "1") return;


            List<String> theNoList = new List<String>();


            //
            if (bpoint.pay_class == "CH") // 충전 취소영수증
            {

                theNoList.Clear();

                // 찾아라 the_no 목록
                get_the_no("C", "CH");

                // 출력
                for (int j = 0; j < theNoList.Count; j++)
                {
                    _print_bill(theNoList[j], "C", "", "11010", false);
                }

            }
            else if (bpoint.pay_class == "US") // 포인트사용분 승인영수증
            {
                theNoList.Clear();

                // 찾아라 the_no 목록
                get_the_no("A", "ST");

                // 출력
                for (int j = 0; j < theNoList.Count; j++)
                {
                    _print_bill(theNoList[j], "A", "", "11010", false);
                }

            }




            //
            void get_the_no(String tran_type, String pay_class)
            {
                //#
                String url = "paymentCash?siteId=" + mSiteId + "&bizDt=" + mThisBizDt + "&ticketNo=" + mSelectedTicketNo + "&tranType=" + tran_type + "&payClass=" + pay_class;
                if (mRequestGet(url))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCashs"].ToString();
                        add_the_no_list(data);
                    }
                    else
                    {
                        MessageBox.Show("결제 데이터 오류. paymentCash\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. paymentCash\n\n" + mErrorMsg, "thepos");
                }

                //#
                url = "paymentCard?siteId=" + mSiteId + "&bizDt=" + mThisBizDt + "&ticketNo=" + mSelectedTicketNo + "&&tranType=" + tran_type + "&payClass=" + pay_class;
                if (mRequestGet(url))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCards"].ToString();
                        add_the_no_list(data);
                    }
                    else
                    {
                        MessageBox.Show("결제 데이터 오류. paymentCard\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. paymentCard\n\n" + mErrorMsg, "thepos");
                }

                //#
                url = "paymentEasy?siteId=" + mSiteId + "&bizDt=" + mThisBizDt + "&ticketNo=" + mSelectedTicketNo + "&&tranType=" + tran_type + "&payClass=" + pay_class;
                if (mRequestGet(url))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentEasys"].ToString();
                        add_the_no_list(data);
                    }
                    else
                    {
                        MessageBox.Show("결제 데이터 오류. paymentEasy\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. paymentEasy\n\n" + mErrorMsg, "thepos");
                }
            }


            //
            void add_the_no_list(String data)
            {
                JArray arr = JArray.Parse(data);

                for (int i = 0; i < arr.Count; i++)
                {
                    ListViewItem lvItem = new ListViewItem();
                    String t_the_no = arr[i]["theNo"].ToString();

                    bool is_find_no = false;

                    for (int j = 0; j < theNoList.Count; j++)
                    {
                        if (theNoList[j] == t_the_no)
                        {
                            is_find_no = true;
                        }
                    }

                    if (is_find_no == false)
                    {
                        theNoList.Add(t_the_no);
                    }
                }
            }


        }

    }
}
