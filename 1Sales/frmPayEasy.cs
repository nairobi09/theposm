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
using static thepos.frmFlowCharging;
using static thepos.frmPayComplex;
using System.Collections;
using System.Numerics;

namespace thepos
{
    public partial class frmPayEasy : Form
    {

        TextBox saveKeyDisplay;

        int netAmount = 0;

        int t과세금액 = 0;
        int t면세금액 = 0;

        bool isComplex = false;
        int paySeq = 1;
        bool isLast = false;
        int selectIdx = -1;

        String ticketNo = "";


        public frmPayEasy(int net_amount, int r과세금액, int r면세금액, bool is_complex, int seq, bool is_last, int select_index)
        {
            InitializeComponent();

            initialize_font();

            initial_the();

            isComplex = is_complex;
            paySeq = seq;
            isLast = is_last;
            selectIdx = select_index;

            netAmount = net_amount;

            t과세금액 = r과세금액;
            t면세금액 = r면세금액;


            lblNetAmount.Text = netAmount.ToString("N0");

            saveKeyDisplay = mTbKeyDisplayController;
            mTbKeyDisplayController = mTbKeyDisplaySales;

            if (mPayClass == "OR")
            {

            }
            else if (mPayClass == "CH")
            {
                MemOrderItem orderItem = (MemOrderItem)mLvwOrderItem.Items[0].Tag;
                mRefNo = orderItem.ticket_no.Substring(0, 20);
                ticketNo = orderItem.ticket_no;
            }
            else if (mPayClass == "US")
            {
                // 해당없음.
            }
            else if (mPayClass == "ST")
            {
                MemOrderItem orderItem = (MemOrderItem)mLvwOrderItem.Items[0].Tag;
                mRefNo = orderItem.ticket_no.Substring(0, 20);
                ticketNo = orderItem.ticket_no;
            }



        }
        private void initialize_font()
        {
            lblTitle.Font = font12;
            btnClose.Font = font12;

            lblNetAmountTitle.Font = font10;
            lblNetAmount.Font = font12;

            lblBarcodeNoTitle.Font = font10;
            tbBarcodeNo.Font = font12;

            chkKakao.Font = font12;

            btnEasyAuth.Font = font12;
        }

        private void initial_the()
        {


        }


        private void btnEasyAuth_Click(object sender, EventArgs e)
        {

            int dcAmount = 0;

            int tAmount = netAmount;
            int tFreeAmount = 0;
            int tTaxAmount = 0;
            int tTax = 0;
            int tServiceAmt = 0;

            String barcode_no = tbBarcodeNo.Text;
            String is_kakaopay = "";

            PaymentEasy mPaymentEasy = new PaymentEasy();


            if (chkKakao.Checked == true) is_kakaopay = "1";

            tTax = t과세금액 / 11;
            tTaxAmount = t과세금액 - tTax;
            tFreeAmount = t면세금액;


            if (requestEasyAuth(tAmount, tFreeAmount, tTaxAmount, tTax, tServiceAmt, barcode_no, is_kakaopay, out mPaymentEasy) != 0)
            {
                display_error_msg(mErrorMsg);
            }
            else
            {
                //정상승인
                int order_cnt = 0;

                if (paySeq == 1)
                {
                    order_cnt = SaveOrder_Server(ticketNo, out dcAmount);// 주문 저장 1
                    if (order_cnt == -1)
                    {
                        return; // 심각한 에러..
                    }
                }

                // 서버저장 payment
                if (!SavePayment_Server(paySeq, "Easy", netAmount, dcAmount))
                {
                    return;
                }



                // 서버저장 paymentCard
                mPaymentEasy.site_id = mSiteId;
                mPaymentEasy.biz_dt = mBizDate;
                mPaymentEasy.pos_no = mPosNo;
                mPaymentEasy.the_no = mTheNo;
                mPaymentEasy.ref_no = mRefNo;
                mPaymentEasy.pay_date = get_today_date();
                mPaymentEasy.pay_time = get_today_time();
                mPaymentEasy.pay_type = "E1";       // 결제구분 : , 간편결제(E1)
                mPaymentEasy.tran_type = "A";       // 승인 A 취소 C
                mPaymentEasy.pay_class = mPayClass;
                mPaymentEasy.ticket_no = ticketNo;
                mPaymentEasy.pay_seq = paySeq;
                mPaymentEasy.sign_path = "";
                mPaymentEasy.is_cancel = "";
                mPaymentEasy.van_code = mVanCode;
                // 밴에서 응답으로 받은건 payChannel 모듈에서 세팅

                if (!SavePaymentEasy(mPaymentEasy))
                {
                    return;
                }



                if (isComplex)
                {
                    // frmComplex화면의 금액들 업데이트
                    mComplexRcvAmount += netAmount;
                    mComplexNestAmount -= netAmount;

                    mComplexLblRcvAmount.Text = mComplexRcvAmount.ToString("N0");
                    mComplexLblNestAmount.Text = mComplexNestAmount.ToString("N0");

                    mComplexTbReqAmount.Text = mComplexNestAmount.ToString("N0");

                    // 리스트뷰 추가
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Tag = "";
                    lvItem.Text = paySeq.ToString();
                    lvItem.SubItems.Add(get_MMddHHmm(mPaymentEasy.pay_date, mPaymentEasy.pay_time));
                    lvItem.SubItems.Add(thePos.get_pay_type_name(mPaymentEasy.pay_type));
                    lvItem.SubItems.Add(thePos.get_tran_type_name(mPaymentEasy.tran_type));
                    lvItem.SubItems.Add(mPaymentEasy.card_no);
                    lvItem.SubItems.Add(mPaymentEasy.amount.ToString("N0"));
                    lvItem.SubItems.Add(mPaymentEasy.auth_no);
                    mComplexLvwPay.Items.Add(lvItem);

                    // 복합결제인 경우 seq 관리
                    mPaySeq++;
                }


                String strAlarm = "";

                if (paySeq == 1)
                {
                    strAlarm = "주문" + order_cnt + "건 간편결제승인 완료.";
                }
                else
                {
                    strAlarm = "간편결제승인 완료.";
                }
                SetDisplayAlarm("I", strAlarm);



                if (isLast)     // 복합결제 마지막이거나 단독결제라면...
                {
                    int settel_amt = netAmount;
                    if (isComplex)
                    {
                        settel_amt = mComplexRcvAmount;
                    }

                    // 티켓 저장
                    int ticket_cnt = SaveTicketFlow(ticketNo, mPayClass, "US", settel_amt);


                    if (ticket_cnt > 0)
                    {
                        if (mPayClass == "OR")
                        {
                            strAlarm += " 티켓발권 " + ticket_cnt + "건 출력.";

                            // 티켓출력은 SaveTicketFlow() 내에서 한다.
                        }
                        else if (mPayClass == "CH")
                        {
                            strAlarm += " 티켓충전 완료.";

                            // 충전화면 리스트뷰
                            frmFlowCharging.review_flow(ticketNo, selectIdx);

                        }
                        else if (mPayClass == "ST")
                        {
                            strAlarm += " 티켓정산 등록.";

                            // 정산화면 리스트뷰 갱신
                            frmFlowSettlement.view_ticket_flow(frmFlowSettlement.mThisBizDt, frmFlowSettlement.mThisPosNo, frmFlowSettlement.mThisTicketNo);
                        }

                        SetDisplayAlarm("I", strAlarm);
                    }


                    // 영수증 출력
                    // 안에서 여부를 물어보고 출력한다. 
                    print_bill(mTheNo, "A", "", "1101"); // cash card point easy



                    mClearSaleForm();

                    mPaySeq = 1;
                }

                this.Close();
            }

        }


        private static int requestEasyAuth(int tAmount, int tFreeAmount, int tTaxAmount, int tTax, int tServiceAmt, String barcode_no, String is_kakaoPay, out PaymentEasy mPaymentEasy)
        {
            int ret = 0;


            PaymentEasy mPaymentEasy2 = new PaymentEasy();

            if (mVanCode == "NICE")
            {
                paymentNice p = new paymentNice();
                ret = p.requestNiceEasyAuth(tAmount, tFreeAmount, tTaxAmount, tTax, tServiceAmt, barcode_no, out mPaymentEasy2);
            }
            else if (mVanCode == "KCP")
            {
                paymentKCP p = new paymentKCP();
                ret = p.requestKcpEasyAuth(tAmount, tFreeAmount, tTaxAmount, tTax, tServiceAmt, barcode_no, is_kakaoPay, out mPaymentEasy2);
            }
            else if (mVanCode == "TOSS")
            {
                paymentToss p = new paymentToss();
            }

            mPaymentEasy = mPaymentEasy2;

            return ret;

        }

        private bool SavePaymentEasy(PaymentEasy mPaymentEasy)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Clear();
            parameters["siteId"] = mPaymentEasy.site_id;
            parameters["posNo"] = mPaymentEasy.pos_no;
            parameters["bizDt"] = mPaymentEasy.biz_dt;
            parameters["theNo"] = mPaymentEasy.the_no;
            parameters["refNo"] = mPaymentEasy.ref_no;

            parameters["payDate"] = mPaymentEasy.pay_date;
            parameters["payTime"] = mPaymentEasy.pay_time;
            parameters["payType"] = mPaymentEasy.pay_type;
            parameters["tranType"] = mPaymentEasy.tran_type;
            parameters["payClass"] = mPaymentEasy.pay_class;

            parameters["ticketNo"] = mPaymentEasy.ticket_no;
            parameters["paySeq"] = mPaymentEasy.pay_seq + "";
            parameters["tranDate"] = mPaymentEasy.tran_date;
            parameters["amount"] = mPaymentEasy.amount + "";

            parameters["authNo"] = mPaymentEasy.auth_no;
            parameters["cardNo"] = mPaymentEasy.card_no;
            parameters["cardName"] = mPaymentEasy.card_name;
            parameters["isuCode"] = mPaymentEasy.isu_code;
            parameters["acqCode"] = mPaymentEasy.acq_code;

            parameters["merchantNo"] = mPaymentEasy.merchant_no;
            parameters["tranSerial"] = mPaymentEasy.tran_serial;
            parameters["signPath"] = mPaymentEasy.sign_path;
            parameters["giftChange"] = mPaymentEasy.gift_change + "";
            parameters["isCancel"] = mPaymentEasy.is_cancel;
            parameters["vanCode"] = mPaymentEasy.van_code;
            parameters["payType2"] = mPaymentEasy.pay_type2;
            parameters["barcodeNo"] = mPaymentEasy.barcode_no;

            if (mRequestPost("paymentEasy", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {

                }
                else
                {
                    MessageBox.Show("오류 paymentEasy\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("시스템오류 paymentEasy\n\n" + mErrorMsg, "thepos");
                return false;
            }

            return true;

        }

        void display_error_msg(string msg)
        {
            MessageBox.Show(msg, "thepos");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayEasy_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mPayClass == "ST" | mPayClass == "CH")  // 정산창위에  떠있는 경우.
            {
            }
            else
            {
                frmSales.ConsoleEnable();
            }

            mTbKeyDisplayController = saveKeyDisplay;

            if (isComplex == true)
                mPanelHigh.Visible = false;
            else
                mPanelPayment.Visible = false;
        }
    }
}
