using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.theSale;
using static thepos.frmSale;

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

            dtBusiness.Font = font10;

            lbl1.Font = font9;
            lbl2.Font = font9;
            lbl3.Font = font9;
            lbl4.Font = font9;

            dtBusiness.Font = font10;
            cbPosNo.Font = font10;
            tbBillNo.Font = font14;

            btnView.Font = font10;
            lvwFlow.Font = font10;
            lvwFlowPay.Font = font10;




        }

        private void initialize_the()
        {
            dtBusiness.Value = DateTime.Now;


            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwFlow.SmallImageList = imgList;
            lvwFlowPay.SmallImageList = imgList;

            cbPosNo.Items.Clear();
            for (int i = 0; i < mPosNoList.Length; i++)
            {
                cbPosNo.Items.Add(mPosNoList[i]);
                if (mPosNoList[i] == mPosNo) cbPosNo.SelectedIndex = i;
            }


            saveKeyDisplay = mTbKeyDisplayController;
            mTbKeyDisplayController = tbBillNo;

            mPayClass = "ST"; // 정산 settement

        }



        private void btnView_Click(object sender, EventArgs e)
        {
            lvwFlow.Items.Clear();
            lvwFlowPay.Items.Clear();
            mLvwOrderItem.Items.Clear();

            for (int i = 0; i < mTicketFlowList.Count; i++)
            {
                ListViewItem item = new ListViewItem();

                item.Tag = mTicketFlowList[i].ticket_no;
                item.Text = mTicketFlowList[i].ticket_no.Substring(14, 4) + "-" + mTicketFlowList[i].ticket_no.Substring(18, 3);
                item.SubItems.Add(mTicketFlowList[i].point_charge.ToString("N0"));
                item.SubItems.Add(mTicketFlowList[i].point_usage.ToString("N0"));

                String tStat = "";
                if (mTicketFlowList[i].flow_step == "0") tStat = "접수";
                else if (mTicketFlowList[i].flow_step == "1") tStat = "발권";
                else if (mTicketFlowList[i].flow_step == "2") tStat = "충전";
                else if (mTicketFlowList[i].flow_step == "3") tStat = "사용중";
                else if (mTicketFlowList[i].flow_step == "4") tStat = "정산완료";

                item.SubItems.Add(tStat);

                lvwFlow.Items.Add(item);
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
        }

        private void lvwFlow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwFlow.SelectedItems.Count == 0) return;


            String ticket_no = lvwFlow.SelectedItems[0].Tag.ToString();

            for (int i = 0; i < mTicketFlowList.Count; i++)
            {
                if (mTicketFlowList[i].ticket_no == ticket_no)
                {
                    mThisTicketFlow = mTicketFlowList[i];  // 저장해둔다...
                }

            }



            view_orderitem(ticket_no);

            //
            view_flowpay(ticket_no);

        }



        void view_orderitem(String ticket_no)
        {


            mLvwOrderItem.Items.Clear();



            //? 서버요청으로 변경 - 발생시간 순서, 
            for (int i = 0; i < listOrderItem.Count; i++)
            {
                if (listOrderItem[i].ticket_no == ticket_no)
                {

                    MemOrderItem memOrderItem = new MemOrderItem();

                    memOrderItem.code = listOrderItem[i].code;
                    memOrderItem.name = listOrderItem[i].name;
                    memOrderItem.cnt = listOrderItem[i].cnt;
                    memOrderItem.amt = listOrderItem[i].amt;
                    memOrderItem.dc_amount = listOrderItem[i].dc_amount;
                    memOrderItem.dcr_des = listOrderItem[i].dcr_des;
                    memOrderItem.dcr_type = listOrderItem[i].dcr_type;
                    memOrderItem.dcr_value = listOrderItem[i].dcr_value;
                    memOrderItem.ticket = "";
                    memOrderItem.pay_class = listOrderItem[i].pay_class; ;
                    memOrderItem.ticket_no = listOrderItem[i].ticket_no;


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
                    lvwitem.SubItems.Add(lvwFlow.SelectedItems[0].Tag.ToString());
                    mLvwOrderItem.Items.Add(lvwitem);

                }

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
            mLblOrderAmountRest.Text = restAmount.ToString("N0");
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



        void view_flowpay(String ticket_no)
        {

            // 정산 후처리
            // 결제할 금액(포인트사용) -> 승인요청
            // 취소할 금액(충전금액) 




            lvwFlowPay.Items.Clear();



            if (mThisTicketFlow.point_usage > 0)
            {

                ListViewItem item = new ListViewItem();
                point_back bpoint = new point_back();

                item.Text = "";
                item.SubItems.Add("포인트사용");
                item.SubItems.Add(get_ticket_type_name(mTicketType));
                item.SubItems.Add(mThisTicketFlow.point_usage.ToString("N0"));

                if (mThisTicketFlow.settle_point_usage == 0)
                {
                    item.SubItems.Add("승인요망");
                    bpoint.result_code = "0";
                }
                else
                {
                    item.SubItems.Add("승인-완료");
                    bpoint.result_code = "1";
                }

                bpoint.pay_type = mTicketType;
                bpoint.pay_seq = 1;
                bpoint.the_no = "";
                bpoint.amount = mThisTicketFlow.point_usage;
                bpoint.result_code = "";
                bpoint.tran_type = "";



                item.Tag = bpoint;

                lvwFlowPay.Items.Add(item);

            }


            //? 서버API로 변경
            for (int i = 0; i < mPaymentCards.Count; i++)
            {
                if (mPaymentCards[i].ticket_no == ticket_no & mPaymentCards[i].tran_type == "A" & mPaymentCards[i].pay_class == "CH")
                {
                    ListViewItem item = new ListViewItem();
                    point_back bpoint = new point_back();

                    item.Text = mPaymentCards[i].the_no.Substring(14, 4);
                    item.SubItems.Add(get_pay_class_name(mPaymentCards[i].pay_class));
                    item.SubItems.Add(get_pay_type_name(mPaymentCards[i].pay_type));
                    item.SubItems.Add(mPaymentCards[i].amount.ToString("N0"));

                    if (mPaymentCards[i].is_cancel == "Y")
                    {
                        item.SubItems.Add("취소-완료");
                        bpoint.result_code = "1";
                    }
                    else
                    {
                        item.SubItems.Add("취소필요");
                        bpoint.result_code = "0";
                    }

                    bpoint.pay_type = mPaymentCards[i].pay_type;
                    bpoint.pay_seq = mPaymentCards[i].pay_seq;
                    bpoint.the_no = mPaymentCards[i].the_no;
                    bpoint.amount = mPaymentCards[i].amount;
                    bpoint.result_code = "";
                    bpoint.tran_type = "";

                    item.Tag = bpoint;

                    lvwFlowPay.Items.Add(item);
                }
            }


            for (int i = 0; i < mPaymentCashs.Count; i++)
            {
                if (mPaymentCashs[i].ticket_no == ticket_no & mPaymentCashs[i].tran_type == "A" & mPaymentCashs[i].pay_class == "CH")
                {
                    ListViewItem item = new ListViewItem();
                    point_back bpoint = new point_back();

                    item.Text = mPaymentCashs[i].the_no.Substring(14, 4);
                    item.SubItems.Add(get_pay_class_name(mPaymentCashs[i].pay_class));
                    item.SubItems.Add(get_pay_type_name(mPaymentCashs[i].pay_type));
                    item.SubItems.Add(mPaymentCashs[i].amount.ToString("N0"));

                    if (mPaymentCashs[i].is_cancel == "Y")
                    {
                        item.SubItems.Add("취소-완료");
                        bpoint.result_code = "1";
                    }
                    else
                    {
                        item.SubItems.Add("취소필요");
                        bpoint.result_code = "0";
                    }

                    bpoint.pay_type = mPaymentCashs[i].pay_type;
                    bpoint.pay_seq = mPaymentCashs[i].pay_seq;
                    bpoint.the_no = mPaymentCashs[i].the_no;
                    bpoint.amount = mPaymentCashs[i].amount;
                    bpoint.result_code = "";
                    bpoint.tran_type = "";

                    item.Tag = bpoint;

                    lvwFlowPay.Items.Add(item);
                }
            }

            //? 간편결제 추가
            //






        }

        private void lvwFlowPay_SelectedIndexChanged(object sender, EventArgs e)
        {

            mLvwOrderItem.Items.Clear();


            if (lvwFlowPay.SelectedItems.Count < 1) { return; }

            point_back bpoint = (point_back)lvwFlowPay.SelectedItems[0].Tag;


            if (bpoint.pay_type == "PA" | bpoint.pay_type == "PD") // 승인대상-포인트사용
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
                    lvwitem.SubItems.Add(lvwFlow.SelectedItems[0].Tag.ToString());
                    mLvwOrderItem.Items.Add(lvwitem);

                    ReCalculateAmount();
                }
            }
            else
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
                lvwitem.SubItems.Add(lvwFlow.SelectedItems[0].Tag.ToString());
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
                mLblOrderAmountRest.Text = Amount.ToString("N0");



            }

        }

        private void btnCancelReq_Click(object sender, EventArgs e)
        {

            if (lvwFlowPay.SelectedItems.Count < 1) { return; }

            point_back bpoint = (point_back)lvwFlowPay.SelectedItems[0].Tag;

            if (bpoint.result_code == "1") return;


            if (bpoint.pay_type == "PA" | bpoint.pay_type == "PD") return;



            frmPayCancel fPayCancel = new frmPayCancel(bpoint.the_no, mThisTicketFlow.ticket_no);
            fPayCancel.Left += this.Location.X;
            fPayCancel.Top += this.Location.Y;
            fPayCancel.ShowDialog();

            //? 화면갱신






        }
    }
}
