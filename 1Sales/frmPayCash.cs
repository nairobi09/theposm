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
using static thepos.frmPayComplex;
using static thepos.paymentToss;
using System.IO;
using System.Diagnostics;

namespace thepos
{
    public partial class frmPayCash : Form
    {
        //mNetAmount
        int netAmount = 0;
        int rcvAmount = 0;
        int restAmount = 0;

        bool isReset = true;


        bool isComplex = false;
        int paySeq = 0;
        bool isLast = false;

        TextBox saveKeyDisplay;

        String ticketNo = "";

        public frmPayCash(int net_amount, bool is_complex, int seq, bool is_last)
        {
            InitializeComponent();
            initialize_font();

            isComplex = is_complex;
            paySeq = seq;
            isLast = is_last;

            netAmount = net_amount;
            rcvAmount = 0;
            restAmount = netAmount;

            reset_amount();

            saveKeyDisplay = mTbKeyDisplayController;
            mTbKeyDisplayController = tbIssuedMethodNo;



            if (mPayClass == "OR")
            {

            }
            else if (mPayClass == "CH")
            {
                MemOrderItem orderItem = (MemOrderItem)mLvwOrderItem.Items[0].Tag;
                mRefNo = orderItem.ticket_no.Substring(0,18);
                ticketNo = orderItem.ticket_no;

            }
            else if (mPayClass == "US")
            {
                // 해당없음.
            }
            else if (mPayClass == "ST")
            {
                MemOrderItem orderItem = (MemOrderItem)mLvwOrderItem.Items[0].Tag;
                mRefNo = orderItem.ticket_no.Substring(0, 18);
                ticketNo = orderItem.ticket_no;
            }


        }

        private void initialize_font()
        {
            lblTitle.Font = font12;

            lbl1.Font = font10;
            lbl2.Font = font10;
            lbl3.Font = font10;

            lblNetAmount.Font = font10;
            lblRcvAmount.Font = font10;
            lblRestAmount.Font = font10;

            btnCashSimple.Font = font12;

            btn1t.Font = font10;
            btn5t.Font = font10;
            btn10t.Font = font10;
            btn50t.Font = font10;
            btn100t.Font = font10;
            btnReset.Font = font10;

            lbl4.Font = font10;
            lbl5.Font = font10;
            lbl6.Font = font8;

            tbIssuedMethodNo.Font = font12;

            lbl7.Font = font10;

            rbTypeIndividual.Font = font12;
            rbTypeBusiness.Font = font12;
            rbTypeSelf.Font = font12;

            lbl8.Font = font10;

            lblAuthNo.Font = font12;

            btnCashRecept.Font = font12;


            btnClose.Font = font12;
        }



        private void btnCashSimple_Click(object sender, EventArgs e)
        {



            //? 서버API로 교체
            int order_cnt = 0;

            if (paySeq == 1)
            {
                // 주문 저장 1
                order_cnt = SaveOrder(ticketNo);  // order. orderitem
            }


            SavePayment(paySeq, "Cash", netAmount);  // payment - 신규, 수정 포함



            // 결제 항목 저장
            PaymentCash mPaymentCash = new PaymentCash();
            mPaymentCash.site_id = mSiteId;
            mPaymentCash.biz_dt = mBizDate;
            mPaymentCash.pos_no = mPosNo;
            mPaymentCash.the_no = mTheNo;
            mPaymentCash.ref_no = mRefNo; // 

            mPaymentCash.pay_date = get_today_date();
            mPaymentCash.pay_time = get_today_time();
            mPaymentCash.pay_type = "R0";       // 결제구분 : 단순현금(R0), 현금영수중(R1), 임의등록(R9)
            mPaymentCash.tran_type = "A";       // 승인 A 취소 C
            mPaymentCash.pay_class = mPayClass;
            mPaymentCash.ticket_no = ticketNo;
            mPaymentCash.pay_seq = paySeq; // 
            mPaymentCash.tran_date = "";
            mPaymentCash.amount = netAmount;    // 결제금액
            mPaymentCash.receipt_type = "";     // 현금영수증 : 개인 소득공제 1 사업자 지출증빙 2
            mPaymentCash.issued_method_no = ""; // 현금영수증 고객 식별번호
            mPaymentCash.auth_no = "";          // 승인번호
            mPaymentCash.tran_serial = "";      // tran_serial -> 취소시 tid입력
            mPaymentCash.is_cancel = "";        // 취소여부
            mPaymentCashs.Add(mPaymentCash);


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
                lvItem.SubItems.Add(get_MMddHHmm(mPaymentCash.pay_date, mPaymentCash.pay_time));
                lvItem.SubItems.Add(thePos.get_pay_type_name(mPaymentCash.pay_type));  
                lvItem.SubItems.Add(thePos.get_tran_type_name(mPaymentCash.tran_type));  
                lvItem.SubItems.Add(mPaymentCash.issued_method_no);   
                lvItem.SubItems.Add(mPaymentCash.amount.ToString("N0")); 
                lvItem.SubItems.Add(mPaymentCash.auth_no); 
                mComplexLvwPay.Items.Add(lvItem);

                // 복합결제인 경우 seq 관리
                mPaySeq++;
            }



            String strAlarm = "";

            if (paySeq == 1)
            {
                strAlarm = "주문" + order_cnt + "건 단순현금 결제완료.";
            }
            else
            {
                strAlarm = "단순현금 결제완료.";
            }

            SetDisplayAlarm("I", strAlarm);



            if (isLast)     // 복합결제 마지막이거나 단독결제라면...
            {
                // 티켓 저장
                int ticket_cnt = SaveTicket(ticketNo, "US"); // 정산애먼  subClass 사용

                if (ticket_cnt > 0)
                {

                    if (mPayClass == "OR") // 주문(접수-발권)
                    {
                        strAlarm += " 티켓발권 " + ticket_cnt + "건 출력.";

                        //? 티켓 출력 필요


                    }
                    else if (mPayClass == "CH") // 충전
                    {
                        strAlarm += " 티켓충전 완료.";

                        //? 충전화면 리스트뷰 갱신 필요


                    }
                    else if (mPayClass == "ST") // 정산
                    {
                        strAlarm += " 티켓정산 등록.";

                        //? 정산화면 리스트뷰 갱신 필요
                        

                    }
   
                    SetDisplayAlarm("I", strAlarm);




                    // 영수증 출력
                    String headerBill = make_bill_header();
                    String bodyBill = make_bill_body(mTheNo, "A", "");
                    String trailerBill = make_bill_trailer();


                    PrintBill(headerBill, bodyBill, trailerBill, mTheNo);



                }


                mClearSaleForm();

                mPaySeq = 1;
            }

            this.Close();
        }



        private void btnCashRecept_Click(object sender, EventArgs e)
        {

            String receipt_type = "";

            if (rbTypeIndividual.Checked == true) receipt_type = "1";
            else if (rbTypeBusiness.Checked == true) receipt_type = "2";
            else receipt_type = "S";

            String issues_method_no = tbIssuedMethodNo.Text.Trim();


            PaymentCash paymentCash = new PaymentCash();

            if (requestCashAuth(netAmount, receipt_type, issues_method_no, out paymentCash) != 0)  // Toss process
            {
                display_error_msg(mErrorMsg);
            }
            else
            {
                //정상승인
                //? 서버API로 교체
                int order_cnt = 0;

                if (paySeq == 1)
                {
                    // 주문 저장 1
                    order_cnt = SaveOrder(ticketNo);  // order. orderitem
                }

                SavePayment(paySeq, "Cash", netAmount);  // payment


                paymentCash.site_id = mSiteId;
                paymentCash.biz_dt = mBizDate;
                paymentCash.pos_no = mPosNo;
                paymentCash.the_no = mTheNo;
                paymentCash.ref_no = mRefNo;

                paymentCash.pay_date = get_today_date();
                paymentCash.pay_time = get_today_time();
                paymentCash.pay_type = "R1";
                paymentCash.tran_type = "A";       // 승인 A 취소 C
                paymentCash.pay_class = mPayClass;
                paymentCash.ticket_no = ticketNo;
                paymentCash.pay_seq = paySeq; // 
                paymentCash.amount = netAmount;
                paymentCash.receipt_type = receipt_type;

                //

                paymentCash.is_cancel = "";        // 취소여부
                mPaymentCashs.Add(paymentCash);


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
                    lvItem.SubItems.Add(get_MMddHHmm(paymentCash.pay_date, paymentCash.pay_time));
                    lvItem.SubItems.Add(thePos.get_pay_type_name(paymentCash.pay_type));
                    lvItem.SubItems.Add(thePos.get_tran_type_name(paymentCash.tran_type));
                    lvItem.SubItems.Add(paymentCash.issued_method_no);
                    lvItem.SubItems.Add(paymentCash.amount.ToString("N0"));
                    lvItem.SubItems.Add(paymentCash.auth_no);
                    mComplexLvwPay.Items.Add(lvItem);

                    // 복합결제인 경우 seq 관리
                    mPaySeq++;
                }



                String strAlarm = "";

                if (paySeq == 1)
                {
                    strAlarm = "주문" + order_cnt + "건 현금영수증 승인 완료.";
                }
                else
                {
                    strAlarm = "현금영수증 승인 완료.";
                }

                SetDisplayAlarm("I", strAlarm);



                if (isLast)     // 복합결제 마지막이거나 단독결제라면...
                {
                    // 티켓 저장
                    int ticket_cnt = SaveTicket("", "");

                    if (ticket_cnt > 0)
                    {
                        strAlarm += " 티켓발권 " + ticket_cnt + "건 출력.";
                        SetDisplayAlarm("I", strAlarm);

                        //? 
                        // 티켓 출력 개발요망

                    }

                    mClearSaleForm();

                    mPaySeq = 1;
                }

                this.Close();
            }

        }


        private void btnCashSelf_Click(object sender, EventArgs e)
        {

        }




        int requestCashAuth(int netAmount, String receipt_type, String issues_method_no, out PaymentCash mPaymentCash)
        {
            int ret = 0;
            PaymentCash paymentCash = new PaymentCash();
            mPaymentCash = paymentCash;


            if (mPayChannel == "KCP")
            {
                //ret = paymentKCP.requestTossCardAuth(netAmount, install);
            }
            else if (mPayChannel == "TOSS")
            {
                ret = paymentToss.requestTossCashAuth(netAmount, receipt_type, issues_method_no, out mPaymentCash);
            }
            else
            {

            }


            return 0;
        }




        void display_error_msg(string msg)
        {
            MessageBox.Show(msg, "thepos");
        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            reset_amount();
        }

        void reset_amount()
        {
            rcvAmount = netAmount;
            restAmount = 0;

            lblNetAmount.Text = netAmount.ToString("N0");
            lblRcvAmount.Text = rcvAmount.ToString("N0");
            lblRestAmount.Text = restAmount.ToString("N0");

            isReset = true;
        }

        private void btn1t_Click(object sender, EventArgs e) { reDisplayAmount(1000); }
        private void btn5t_Click(object sender, EventArgs e) { reDisplayAmount(5000); }
        private void btn10t_Click(object sender, EventArgs e) { reDisplayAmount(10000); }
        private void btn50t_Click(object sender, EventArgs e) { reDisplayAmount(50000); }
        private void btn100t_Click(object sender, EventArgs e) { reDisplayAmount(100000); }

        private void reDisplayAmount(Int32 amount)
        {
            if (isReset)
            {
                isReset = false;
                rcvAmount = 0;
            }

            rcvAmount += amount;

            restAmount = rcvAmount - netAmount;
            lblRcvAmount.Text = rcvAmount.ToString("N0");
            lblRestAmount.Text = restAmount.ToString("N0");
        }






        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayCash_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSales.ConsoleEnable();

            mTbKeyDisplayController = saveKeyDisplay;
        }

    }
}
