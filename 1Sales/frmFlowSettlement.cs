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

namespace thepos
{
    public partial class frmFlowSettlement : Form
    {
        TextBox saveKeyDisplay;

        TicketFlow mThisTicketFlow = new TicketFlow();


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
            lvwTicketPay.Font = font10;

        }

        private void initialize_the()
        {
            dtBizDt.Value = DateTime.Now;


            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwTicketFlow.SmallImageList = imgList;
            lvwTicketPay.SmallImageList = imgList;

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
            public string tran_type;
            public int amount;
            public string result_code;
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            if (cbPosNo.SelectedIndex < 0) return;


            String biz_date = dtBizDt.Value.ToString("yyyyMMdd");
            String pos_no = cbPosNo.Text;

            String ticketNo = "";
            String t7No = tbTicketNo.Text;

            if (t7No.Length == 7 & pos_no.Length == 2)
            {
                ticketNo = mSiteId + dtBizDt.Value.ToString("yyyyMMdd") + pos_no + t7No;
            }


            view_flow(biz_date, pos_no, ticketNo);

        }


        public void view_flow(String biz_date, String pos_no, String t_no)
        { 

            lvwTicketFlow.Items.Clear();
            lvwTicketPay.Items.Clear();
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
                        int charge_amt = ticketFlow.point_charge;
                        int usage_amt = ticketFlow.point_usage;

                        if (ticketFlow.flow_step == "0") tStat = "접수";
                        else if (ticketFlow.flow_step == "1") tStat = "발권";
                        else if (ticketFlow.flow_step == "2") tStat = "충전";
                        else if (ticketFlow.flow_step == "3") tStat = "사용중";
                        else if (ticketFlow.flow_step == "4") tStat = "정산완료";


                        item.Tag = ticketFlow;
                        item.Text = ticket_no.Substring(14, 4) + "-" + ticket_no.Substring(18, 3);
                        item.SubItems.Add(charge_amt.ToString("N0"));
                        item.SubItems.Add(usage_amt.ToString("N0"));
                        item.SubItems.Add(tStat);

                        lvwTicketFlow.Items.Add(item);

                        if (ticket_no == t_no)
                        {
                            lvwTicketFlow.Items[i].Selected = true;
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
        }

        private void lvwTicketFlow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwTicketFlow.SelectedItems.Count == 0) return;

            //
            mThisTicketFlow = (TicketFlow)lvwTicketFlow.SelectedItems[0].Tag;
            String ticket_no = mThisTicketFlow.ticket_no;

            //?
            여기서 정산 순서, 프로세스를 고민...
            //
            view_orderitem(ticket_no);

            //
            view_flowpay(ticket_no);

        }



        void view_orderitem(String ticket_no)
        {
            mLvwOrderItem.Items.Clear();


            //?  - 발생시간 순서, 

            //충전 사용 - 표시


            String sUrl = "orderItem?ticketNo=" + ticket_no;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orderItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {

                        if ((arr[i]["payClass"].ToString() == "CH" | arr[i]["payClass"].ToString() == "US") & arr[i]["isCancel"].ToString() != "Y")
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
                            memOrderItem.ticket = "";
                            memOrderItem.pay_class = arr[i]["payClass"].ToString();
                            memOrderItem.ticket_no = arr[i]["ticketNo"].ToString();


                            ListViewItem lvwitem = new ListViewItem();
                            lvwitem.Tag = memOrderItem;

                            lvwitem.Text = (i + 1).ToString();
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


            //  ReCalculate...

            int Amount = 0;     // 합계금액
            int dcAmount = 0;     // 할인금액
            int netAmount = 0;     // 받을금액
            int receiveAmount = 0;   // 받은금액
            int restAmount = 0;   // 거스름

            MemOrderItem orderItem;

            for (int i = 0; i < mLvwOrderItem.Items.Count; i++)
            {
                orderItem = (MemOrderItem)mLvwOrderItem.Items[i].Tag;

                if (orderItem.pay_class == "CH")
                {
                    receiveAmount += ((orderItem.cnt * orderItem.amt) - orderItem.dc_amount);
                }
                else if (orderItem.pay_class == "US")
                {
                    Amount += (orderItem.cnt * orderItem.amt);
                    dcAmount += orderItem.dc_amount;
                }
            }

            netAmount = Amount - dcAmount;
            restAmount = receiveAmount - netAmount;

            mLblOrderAmount.Text = netAmount.ToString("N0");
            mLblOrderAmountDC.Text = dcAmount.ToString("N0");
            mLblOrderAmountNet.Text = netAmount.ToString("N0");
            mLblOrderAmountReceive.Text = receiveAmount.ToString("N0");
            

            // Sub Screen 표시
            DisplaySubScreen();

        }




        void view_flowpay(String ticket_no)
        {
            // 정산 후처리
            // 결제할 금액(포인트사용) -> 승인요청
            // 취소할 금액(충전금액) 



            lvwTicketPay.Items.Clear();

            if (mThisTicketFlow.point_usage > 0)
            {

                ListViewItem item = new ListViewItem();
                point_back bpoint = new point_back();

                item.Text = mThisTicketFlow.the_no.Substring(14, 4);
                item.SubItems.Add("사용");
                item.SubItems.Add("포인트");
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
                }

                bpoint.pay_type = mTicketType;
                bpoint.pay_seq = 1;
                bpoint.the_no = "";
                bpoint.amount = mThisTicketFlow.point_usage;
                bpoint.result_code = "";
                bpoint.tran_type = "";

                item.Tag = bpoint;

                lvwTicketPay.Items.Add(item);
            }



            //!
            String sUrl = "paymentCard?ticketNo=" + ticket_no + "&tranType=A&payClass=CH";
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["paymentCards"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        point_back bpoint = new point_back();

                        item.Text = arr[i]["theNo"].ToString().Substring(14, 4);
                        item.SubItems.Add(get_pay_class_name(arr[i]["payClass"].ToString()));
                        item.SubItems.Add(get_pay_type_name(arr[i]["payType"].ToString()));
                        item.SubItems.Add(convert_number(arr[i]["amount"].ToString()).ToString("N0"));

                        if (arr[i]["isCancel"].ToString() == "Y")
                        {
                            item.SubItems.Add("취소 - 완료");
                            bpoint.result_code = "1";
                        }
                        else
                        {
                            item.SubItems.Add("취소요망");
                            bpoint.result_code = "0";
                        }

                        bpoint.pay_type = arr[i]["payType"].ToString();
                        bpoint.pay_seq = convert_number(arr[i]["paySeq"].ToString());
                        bpoint.the_no = arr[i]["theNo"].ToString();
                        bpoint.amount = convert_number(arr[i]["amount"].ToString());
                        bpoint.result_code = "";
                        bpoint.tran_type = "";

                        item.Tag = bpoint;

                        lvwTicketPay.Items.Add(item);
                    }
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



            //!
            sUrl = "paymentCash?ticketNo=" + ticket_no + "&tranType=A&payClass=CH";
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["paymentCashs"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        point_back bpoint = new point_back();

                        item.Text = arr[i]["theNo"].ToString().Substring(14, 4);
                        item.SubItems.Add(get_pay_class_name(arr[i]["payClass"].ToString()));
                        item.SubItems.Add(get_pay_type_name(arr[i]["payType"].ToString()));
                        item.SubItems.Add(convert_number(arr[i]["amount"].ToString()).ToString("N0"));

                        if (arr[i]["isCancel"].ToString() == "Y")
                        {
                            item.SubItems.Add("취소-완료");
                            bpoint.result_code = "1";
                        }
                        else
                        {
                            item.SubItems.Add("취소요망");
                            bpoint.result_code = "0";
                        }

                        bpoint.pay_type = arr[i]["payType"].ToString();
                        bpoint.pay_seq = convert_number(arr[i]["paySeq"].ToString());
                        bpoint.the_no = arr[i]["theNo"].ToString();
                        bpoint.amount = convert_number(arr[i]["amount"].ToString());
                        bpoint.result_code = "";
                        bpoint.tran_type = "";

                        item.Tag = bpoint;

                        lvwTicketPay.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("결제데이터 오류. paymentCash\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. paymentCash\n\n" + mErrorMsg, "thepos");
            }



            //? 간편결제 추가
            //


        }

        private void lvwTicketPay_SelectedIndexChanged(object sender, EventArgs e)
        {

            mLvwOrderItem.Items.Clear();
            

            if (lvwTicketPay.SelectedItems.Count < 1) { return; }

            point_back bpoint = (point_back)lvwTicketPay.SelectedItems[0].Tag;





            if (bpoint.pay_type == "PA" | bpoint.pay_type == "PD") // 포인트사용 - 승인대상
            {
                if (bpoint.result_code == "1")  // 완료
                {
                    //
                }
                else
                {
                    MemOrderItem memOrderItem = new MemOrderItem();
                    memOrderItem.code = "SETTLE";
                    memOrderItem.name = "포인트사용";
                    memOrderItem.cnt = 1;
                    memOrderItem.amt = mThisTicketFlow.point_usage;
                    memOrderItem.dc_amount = 0;
                    memOrderItem.dcr_des = "";
                    memOrderItem.dcr_type = "";
                    memOrderItem.dcr_value = 0;
                    memOrderItem.ticket = "";
                    memOrderItem.pay_class = mPayClass;
                    memOrderItem.ticket_no = mThisTicketFlow.ticket_no;


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

                    ReCalculateAmount();
                }
            }
            else  // 충전 - 취소대상
            {

                MemOrderItem memOrderItem = new MemOrderItem();

                memOrderItem.code = "SETTLE";
                memOrderItem.name = "충전취소";
                memOrderItem.cnt = 1;
                memOrderItem.amt = bpoint.amount;
                memOrderItem.dc_amount = 0;
                memOrderItem.dcr_des = "";
                memOrderItem.dcr_type = "";
                memOrderItem.dcr_value = 0;
                memOrderItem.ticket = "";
                memOrderItem.pay_class = mPayClass;
                memOrderItem.ticket_no = mThisTicketFlow.ticket_no;


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



                //ReCalculateAmount();
                // 대신한다.

                int Amount = 0;

                mNetAmount = 0;

                MemOrderItem orderItemInfo;

                orderItemInfo = (MemOrderItem)mLvwOrderItem.Items[0].Tag;
                Amount += (orderItemInfo.cnt * orderItemInfo.amt);


                mLblOrderAmount.Text = "";
                mLblOrderAmountDC.Text = "";
                mLblOrderAmountNet.Text = "0";
                mLblOrderAmountReceive.Text = Amount.ToString("N0");
                
                DisplaySubScreen();

            }

        }

        private void btnCancelReq_Click(object sender, EventArgs e)
        {

            if (lvwTicketPay.SelectedItems.Count < 1) { return; }

            point_back bpoint = (point_back)lvwTicketPay.SelectedItems[0].Tag;

            if (bpoint.result_code == "1") return;


            if (bpoint.pay_type == "PA" | bpoint.pay_type == "PD") return;


            //?
            int select_idx = 0;

            frmPayCancel fPayCancel = new frmPayCancel(bpoint.the_no, mThisTicketFlow.ticket_no, "1111", select_idx);
            fPayCancel.Left += this.Location.X;
            fPayCancel.Top += this.Location.Y;
            fPayCancel.ShowDialog();


            //? 화면갱신
            view_flowpay(mThisTicketFlow.ticket_no);





        }

        private void btnScanner_Click(object sender, EventArgs e)
        {
            btnScanner.Enabled = false;

            Form fFlow;
            fFlow = new frmScanner(21);  // ticket_no
            fFlow.ShowDialog();


            if (mIsScanOK)
            {
                try
                {
                    String dt = mScanString.Substring(4, 8);
                    String posno = mScanString.Substring(12, 2);
                    String t7no = mScanString.Substring(14, 7);

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

                    view_flow(dt, posno, mScanString);
                }
                catch
                {
                    SetDisplayAlarm("W", "스캔데이터 포멧 오류.");
                    //return;
                }
            }

            btnScanner.Enabled = true;

        }

    }
}
