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
            tbTicketNo.Font = font10bold;

            btnView.Font = font10;
            lvwTicketFlow.Font = font10;
            lvwTicketSettle.Font = font10;

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


            //? 후불식이이면 취소버튼을 안보이게한다.. 
            if (mTicketType == "PD") btnCancelReq.Visible = false;

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
            String t7No = tbTicketNo.Text;

            if (t7No.Length == 6 & mThisPosNo.Length == 2)
            {
                mThisTicketNo = mSiteId + dtBizDt.Value.ToString("yyyyMMdd") + mThisPosNo + t7No;
            }

            view_ticket_flow(mThisBizDt, mThisPosNo, mThisTicketNo);

        }


        public static void view_ticket_flow(String biz_date, String pos_no, String t_no)
        { 

            mLvwTicketFlow.Items.Clear();
            mLvwTicketSettle.Items.Clear();
            mLvwOrderItem.Items.Clear();

            // 결제버튼... 충전취소 상황때 결제로 들어가는걸 막기위해서.. 보였다 안보였다...
            mTableLayoutPanelPayControl.Enabled = true;


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

                        ticketFlow.goods_code = arr[i]["itemCode"].ToString();
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

                        //? 정산완료이면 ForeColor=gray로 변경

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
                    MessageBox.Show("티켓데이터 오류.\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
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

        }


        void view_on_order()
        {
            mLvwOrderItem.Items.Clear();

            // 포인트 사용 건수 총액
            if (mThisTicketFlow.point_usage > 0)
            {
                ListViewItem lvwitem = new ListViewItem();
                lvwitem.Text = "";
                lvwitem.SubItems.Add("포인트사용");                            // 1: name 상품명
                lvwitem.SubItems.Add("");              // 2: amt 단가
                lvwitem.SubItems.Add(mThisTicketFlow.point_usage_cnt.ToString("N0"));                  // 3: cnt 수량
                lvwitem.SubItems.Add("");     // 4: dc_amount 할인

                lvwitem.SubItems.Add(mThisTicketFlow.point_usage.ToString("N0"));                 // 5: net_amount 금액
                lvwitem.SubItems.Add("");                     // 6: 메모
                lvwitem.SubItems.Add("");
                mLvwOrderItem.Items.Add(lvwitem);
            }

            // 선불식이면 충전을 표시
            if (mTicketType == "PA")
            {
                if (mThisTicketFlow.point_charge > 0)
                {
                    ListViewItem lvwitem = new ListViewItem();
                    lvwitem.Text = "";
                    lvwitem.SubItems.Add("포인트충전");                            // 1: name 상품명
                    lvwitem.SubItems.Add("");              // 2: amt 단가
                    lvwitem.SubItems.Add(mThisTicketFlow.point_charge_cnt.ToString("N0"));                  // 3: cnt 수량
                    lvwitem.SubItems.Add("");     // 4: dc_amount 할인

                    lvwitem.SubItems.Add(mThisTicketFlow.point_charge.ToString("N0"));                 // 5: net_amount 금액
                    lvwitem.SubItems.Add("");                     // 6: 메모
                    lvwitem.SubItems.Add("");
                    mLvwOrderItem.Items.Add(lvwitem);
                }
            }


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
            mLvwOrderItem.Items.Clear();
            

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
                                if (arr[i]["payClass"].ToString() == "US" & arr[i]["isCancel"].ToString() != "Y")
                                {
                                    MemOrderItem memOrderItem = new MemOrderItem();

                                    memOrderItem.code = arr[i]["itemCode"].ToString();
                                    memOrderItem.name = arr[i]["itemName"].ToString();
                                    memOrderItem.cnt = convert_number(arr[i]["cnt"].ToString());
                                    memOrderItem.amt = convert_number(arr[i]["amt"].ToString());
                                    memOrderItem.dc_amount = convert_number(arr[i]["dcAmount"].ToString());
                                    memOrderItem.dcr_des = arr[i]["dcrDes"].ToString();
                                    memOrderItem.dcr_type = arr[i]["dcrType"].ToString();
                                    memOrderItem.dcr_value = convert_number(arr[i]["dcrValue"].ToString());
                                    memOrderItem.ticket = arr[i]["ticketYn"].ToString();
                                    memOrderItem.taxfree = arr[i]["taxFree"].ToString();
                                    memOrderItem.pay_class = arr[i]["payClass"].ToString();
                                    memOrderItem.ticket_no = arr[i]["ticketNo"].ToString();
                                    memOrderItem.shop_code = arr[i]["shopCode"].ToString();;


                                    ListViewItem lvwitem = new ListViewItem();
                                    lvwitem.Tag = memOrderItem;

                                    lvwitem.Text = "1";
                                    lvwitem.SubItems.Add(memOrderItem.name);                            // 1: name 상품명
                                    lvwitem.SubItems.Add(memOrderItem.amt.ToString("N0"));              // 2: amt 단가
                                    lvwitem.SubItems.Add(memOrderItem.cnt.ToString());                  // 3: cnt 수량
                                    lvwitem.SubItems.Add(memOrderItem.dc_amount.ToString("##,###"));     // 4: dc_amount 할인

                                    int net_amount = (memOrderItem.amt * memOrderItem.cnt) - memOrderItem.dc_amount;
                                    lvwitem.SubItems.Add(net_amount.ToString("N0"));                 // 5: net_amount 금액
                                    lvwitem.SubItems.Add(getDCRmemo(memOrderItem));                     // 6: 메모
                                    lvwitem.SubItems.Add(lvwTicketFlow.SelectedItems[0].Tag.ToString());
                                    mLvwOrderItem.Items.Add(lvwitem);
                                }
                            }

                            //
                            ReCalculateAmount();

                            mTableLayoutPanelPayControl.Enabled = true;

                        }
                        else
                        {
                            MessageBox.Show("결제데이터 오류. paymentCard\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
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
                                if (arr[i]["payClass"].ToString() == "CH" & arr[i]["isCancel"].ToString() != "Y")
                                {
                                    MemOrderItem memOrderItem = new MemOrderItem();

                                    memOrderItem.code = arr[i]["itemCode"].ToString();
                                    memOrderItem.name = arr[i]["itemName"].ToString();
                                    memOrderItem.cnt = convert_number(arr[i]["cnt"].ToString());
                                    memOrderItem.amt = convert_number(arr[i]["amt"].ToString());
                                    memOrderItem.dc_amount = convert_number(arr[i]["dcAmount"].ToString());
                                    memOrderItem.dcr_des = arr[i]["dcrDes"].ToString();
                                    memOrderItem.dcr_type = arr[i]["dcrType"].ToString();
                                    memOrderItem.dcr_value = convert_number(arr[i]["dcrValue"].ToString());
                                    memOrderItem.ticket = arr[i]["ticketYn"].ToString();
                                    memOrderItem.pay_class = arr[i]["payClass"].ToString();
                                    memOrderItem.ticket_no = arr[i]["ticketNo"].ToString();


                                    ListViewItem lvwitem = new ListViewItem();
                                    lvwitem.Tag = memOrderItem;

                                    lvwitem.Text = "1";
                                    lvwitem.SubItems.Add(memOrderItem.name);                            // 1: name 상품명
                                    lvwitem.SubItems.Add(memOrderItem.amt.ToString("N0"));              // 2: amt 단가
                                    lvwitem.SubItems.Add(memOrderItem.cnt.ToString());                  // 3: cnt 수량
                                    lvwitem.SubItems.Add(memOrderItem.dc_amount.ToString("#,###"));     // 4: dc_amount 할인

                                    int net_amount = (memOrderItem.amt * memOrderItem.cnt) - memOrderItem.dc_amount;
                                    lvwitem.SubItems.Add(net_amount.ToString("N0"));                 // 5: net_amount 금액
                                    lvwitem.SubItems.Add(getDCRmemo(memOrderItem));                     // 6: 메모
                                    lvwitem.SubItems.Add(lvwTicketFlow.SelectedItems[0].Tag.ToString());
                                    mLvwOrderItem.Items.Add(lvwitem);
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
                            mTableLayoutPanelPayControl.Enabled = false;


                        }
                        else
                        {
                            MessageBox.Show("결제데이터 오류. paymentCard\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
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




            //?
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
                    String t7no = mScanString.Substring(14, 6);

                    int yyyy = int.Parse(dt.Substring(0, 4));
                    int mm = int.Parse(dt.Substring(4, 2));
                    int dd = int.Parse(dt.Substring(6, 2));

                    dtBizDt.Value = new DateTime(yyyy, mm, dd);

                    for (int i = 0; i < cbPosNo.Items.Count; i++)
                    {
                        if (cbPosNo.Items[i].ToString() == posno)
                        {
                            cbPosNo.SelectedIndex = i;
                        }
                    }

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
            String[] the_no_set = new string[50];
            int the_no_set_count = 0;

            String sUrl = "paymentPoint?siteId=" + mSiteId + "&bizDt=" + mThisBizDt + "&ticketNo=" + mSelectedTicketNo + "&payClass=US";
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["paymentPoints"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        the_no_set[i] = arr[i]["theNo"].ToString();
                    }
                    the_no_set_count = arr.Count;

                }
                else
                {
                    MessageBox.Show("결제데이터 오류. paymentPoint\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. paymentPoint\n\n" + mErrorMsg, "thepos");
            }



            // 2 
            for (int i = 0;i < the_no_set_count; i++) 
            {
                // Payment 취소건 추가
                sUrl = "payment?siteId=" + mSiteId + "&bizDt=" + mThisBizDt + "&theNo=" + the_no_set[i];
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["payments"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count == 1)
                        {
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
                            param["isCancel"] = "Y";

                            if (mRequestPost("payment", param))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {}
                                else
                                {
                                    MessageBox.Show("오류 payment\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("시스템오류 payment\n\n" + mErrorMsg, "thepos");
                                return;
                            }

                        }
                        else
                        {
                            MessageBox.Show("결제데이터 오류. payment\n\n aee.Count=" + arr.Count, "thepos");
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("결제데이터 오류. payment\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
                    return;
                }


                // payment 승인건 취소마킹
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["bizDt"] = mThisBizDt;
                parameters["theNo"] = the_no_set[i];
                parameters["tranType"] = "A";
                parameters["isCancel"] = "Y";

                if (mRequestPatch("payment", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                    }
                    else
                    {
                        MessageBox.Show("오류. paymentPoint\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. paymentPoint\n\n" + mErrorMsg, "thepos");
                    return;
                }




                // paymentPoint승인건 취소마킹
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["bizDt"] = mThisBizDt;
                parameters["theNo"] = the_no_set[i];
                parameters["payType"] = mTicketType;
                parameters["isCancel"] = "Y";

                if (mRequestPatch("paymentPoint", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                    }
                    else
                    {
                        MessageBox.Show("오류. paymentPoint\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
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

        private void btnSettleBill_Click(object sender, EventArgs e)
        {

        }
    }
}
