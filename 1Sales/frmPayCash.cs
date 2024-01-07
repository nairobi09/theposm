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
using static thepos.frmFlowSettlement;
using static thepos.frmPayComplex;
using System.IO;
using System.Diagnostics;
using thepos._1Sales;

namespace thepos
{
    public partial class frmPayCash : Form
    {
        //mNetAmount
        int netAmount = 0;
        int rcvAmount = 0;
        int restAmount = 0;

        int t과세금액 = 0;
        int t면세금액 = 0;


        bool isReset = true;


        bool isComplex = false;
        int paySeq = 0;
        bool isLast = false;
        int selectIdx = -1;


        String ticketNo = "";

        public frmPayCash(int net_amount, int r과세금액, int r면세금액, bool is_complex, int seq, bool is_last, int select_index)
        {
            InitializeComponent();
            initialize_font();

            isComplex = is_complex;
            paySeq = seq;
            isLast = is_last;
            selectIdx = select_index;

            netAmount = net_amount;
            rcvAmount = 0;
            restAmount = netAmount;

            t과세금액 = r과세금액;
            t면세금액 = r면세금액;


            reset_amount();



            // 밴이 나이스만 입력수단을 표시한다...
            if (mVanCode == "NICE")
            {
                gbInputType.Visible = true;
            }
            else
            {
                gbInputType.Visible = false;
            }
            


            if (mPayClass == "OR")
            {

            }
            else if (mPayClass == "CH")
            {
                MemOrderItem orderItem = mOrderItemList[0];
                mRefNo = orderItem.ticket_no.Substring(0, 20);
                ticketNo = orderItem.ticket_no;
            }
            else if (mPayClass == "US")
            {
                // 해당없음.
            }
            else if (mPayClass == "ST")
            {
                //?
                ticketNo = frmFlowSettlement.mSelectedTicketNo;
                mRefNo = ticketNo.Substring(0, 20);
            }


            //
            if (mTheMode == "Local")
            {
                gbCashReceipt.Visible = false;
            }
            else
            {
                gbCashReceipt.Visible = true;
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

            btnCashSimple.Font = font10;

            btn1t.Font = font10;
            btn5t.Font = font10;
            btn10t.Font = font10;
            btn50t.Font = font10;
            btnReset.Font = font10;

            lbl4.Font = font10;
            lbl5.Font = font10;
            lbl6.Font = font10;

            rbTypeIndividual.Font = font10;
            rbTypeBusiness.Font = font10;
            rbTypeSelf.Font = font10;
            
            rb화면입력.Font = font10;
            rbKeyin.Font = font10;
            rb카드거래.Font = font10;

            lblAuthNo.Font = font10;
            btnCashRecept.Font = font10;

            btnClose.Font = font12;
        }



        private void btnCashSimple_Click(object sender, EventArgs e)
        {
            //!
            int order_cnt = 0;
            int dcAmount = 0;


            // 리스트뷰 -> 메모리배열 생성 : [ 업장코드로 정렬 + 업장주문번호 부여 ]
            //MemOrderItem[] memOrderItemArr = getMemOrderItemArr(out dcAmount);

            set_shop_order_no_on_orderitem(out dcAmount);


            if (paySeq == 1)
            {
                if (mPayClass == "ST")
                {
                    // 포인트사용분의 정산 : order, orderItem
                    // 1. 기사용분 취소마킹
                    // 2. 취소건 추가
                    // 3. 신규 승인추가
                    CancelOrderSettle(ticketNo);
                }


                // orders, orderItem 
                order_cnt = SaveOrder(ticketNo);  // order. orderitem  ->  업장주문서 출력은 제외
                if (order_cnt == -1)
                {
                    return; // 재로그인 요구
                }
            }


            //  payment
            if (!SavePayment(paySeq, "Cash", netAmount, dcAmount))
            {
                return;
            }


            PaymentCash mPaymentCash = new PaymentCash();
            mPaymentCash.site_id = mSiteId;
            mPaymentCash.biz_dt = mBizDate;
            mPaymentCash.pos_no = mPosNo;
            mPaymentCash.the_no = mTheNo;
            mPaymentCash.ref_no = mRefNo; // 

            mPaymentCash.pay_date = get_today_date();
            mPaymentCash.pay_time = get_today_time();
            mPaymentCash.pay_type = "R0";       // 결제구분 : 단순현금(R0), 현금영수중(R1)
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
            mPaymentCash.van_code = "";


            // 결제 항목 저장
            if (mTheMode == "Local")
            {
                if (!SavePaymentCash_Local(mPaymentCash))
                {
                    return;
                }
            }
            else
            { 
                if (!SavePaymentCash_Server(mPaymentCash))
                {
                    return;
                }
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
                if (mTheMode == "Local")
                {
                    // 로컬모드에서는 티켓플로우 관리하지 않습니다.

                }
                else
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
                        if (mPayClass == "OR") // 주문(접수-발권)
                        {
                            // 티켓 출력은 SaveTicketFlow()내에서 함.

                        }
                        else if (mPayClass == "CH") // 충전
                        {
                            strAlarm += " 티켓충전 완료.";

                            // 충전화면 리스트뷰
                            frmFlowCharging.review_flow(ticketNo, selectIdx);
                        }
                        else if (mPayClass == "ST") // 정산
                        {
                            strAlarm += " 티켓정산 등록.";

                            // 정산화면 리스트뷰 갱신
                            frmFlowSettlement.view_ticket_flow(frmFlowSettlement.mThisBizDt, frmFlowSettlement.mThisPosNo, frmFlowSettlement.mThisTicketNo);
                        }

                        SetDisplayAlarm("I", strAlarm);
                    }


                    // 정산-포인트사용분에 대해 취소
                    if (mPayClass == "ST")
                    {
                        cancel_point_payment(ticketNo);
                    }
                }



                // 주문서 출력 : 업장용 + 고객용
                if (mPayClass == "OR")
                {
                    print_order();
                }


                // 영수증 출력
                if (mPaySeq == 1)
                    print_bill(mTheNo, "A", "", "1000", true); // cash
                else
                    print_bill(mTheNo, "A", "", "1101", true); // cash card point easy



                if (mPayClass == "ST" | mPayClass == "CH")  // 정산창위에  떠있는 경우.
                {
                }
                else
                {
                     if (isComplex == false)
                     {
                         mClearSaleForm();
                     }                   
                }



                mPaySeq = 1;
            }

            this.Close();
        }



        private void btnCashRecept_Click(object sender, EventArgs e)
        {

            String receipt_type = "";

            int tAmount = netAmount;
            int tFreeAmount = 0;
            int tTaxAmount = 0;
            int tTax = 0;
            int tServiceAmt = 0;
            int dcAmount = 0;

            tTax = t과세금액 / 11;
            tTaxAmount = t과세금액 - tTax;
            tFreeAmount = t면세금액;


            if (rbTypeIndividual.Checked == true) receipt_type = "1";
            else if (rbTypeBusiness.Checked == true) receipt_type = "2";
            else receipt_type = "S";

            String issues_method_no = "";


            PaymentCash paymentCash = new PaymentCash();


            int input_type = 0;

            if (rb화면입력.Checked) input_type = 0;
            else if (rbKeyin.Checked) input_type = 1;
            else if (rb카드거래.Checked) input_type = 2;



            if (requestCashAuth(tAmount, tFreeAmount, tTaxAmount, tTax, tServiceAmt, receipt_type, input_type, out paymentCash) != 0)  // Toss process
            {
                display_error_msg(mErrorMsg);
            }
            else
            {
                //정상승인
                int order_cnt = 0;

                // 리스트뷰 -> 메모리배열 생성 : [ 업장코드로 정렬 + 업장주문번호 부여 ]
                //MemOrderItem[] memOrderItemArr = getMemOrderItemArr(out dcAmount);


                set_shop_order_no_on_orderitem(out dcAmount);


                if (paySeq == 1)
                {
                    if (mPayClass == "ST")
                    {
                        //
                        CancelOrderSettle(ticketNo);
                    }


                    // orders, orderItem 
                    order_cnt = SaveOrder(ticketNo);  // order. orderitem  ->  업장주문서 출력은 제외
                    if (order_cnt == -1)
                    {
                        return; // 재로그인 요구
                    }
                }

                //  payment
                if (!SavePayment(paySeq, "Cash", netAmount, dcAmount))
                {
                    return;
                }


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
                paymentCash.is_cancel = "";        // 취소여부
                paymentCash.van_code = mVanCode;

                
                if (!SavePaymentCash_Server(paymentCash))
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
                            // 티켓 출력은 SaveTicketFlow()내에서 함.
                        }
                        else if (mPayClass == "CH")
                        {
                            strAlarm += " 티켓충전 완료.";

                            // 충전화면 리스트뷰 갱신
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


                    // 주문서 출력
                    if (mPayClass == "OR")
                    {
                        print_order();
                    }


                    // 영수증 출력
                    if (mPaySeq == 1)
                        print_bill(mTheNo, "A", "", "1000", true); // cash
                    else
                        print_bill(mTheNo, "A", "", "1101", true); // cash card point easy


                    // 정산-포인트사용분에 대해 취소마킹
                    if (mPayClass == "ST")
                    {
                        cancel_point_payment(ticketNo);
                    }


                    if (mPayClass == "ST" | mPayClass == "CH")  // 정산창위에  떠있는 경우.
                    {
                    }
                    else
                    {
                        if (isComplex == false)
                        {
                            mClearSaleForm();
                        }
                    }

                    mPaySeq = 1;
                }

                this.Close();
            }

        }



        private bool SavePaymentCash_Local(PaymentCash mPaymentCash)
        {

            String sql = "INSERT INTO paymentCash (siteId, posNo, bizDt, theNo, refNo, payDate, payTime, payType, tranType, payClass, ticketNo, paySeq, tranDate, amount, receiptType, issuedMethodNo, authNo, tranSerial, isCancel, vanCode) " +
                "values ('" + mPaymentCash.site_id + "','" + mPaymentCash.pos_no + "','" + mPaymentCash.biz_dt + "','" + mPaymentCash.the_no + "','" + mPaymentCash.ref_no + "','" + mPaymentCash.pay_date + "','" + mPaymentCash.pay_time + "','" + mPaymentCash.pay_type + "','" + mPaymentCash.tran_type + "','" + mPaymentCash.pay_class + "','" +
                              mPaymentCash.ticket_no + "'," + mPaymentCash.pay_seq + ",'" + mPaymentCash.tran_date + "'," + mPaymentCash.amount + ",'" + mPaymentCash.receipt_type + "','" + mPaymentCash.issued_method_no + "','" + mPaymentCash.auth_no + "','" + mPaymentCash.tran_serial + "','" + mPaymentCash.is_cancel + "','" + mPaymentCash.van_code + "')";
            int ret = sql_excute_local_db(sql);


            return true;

        }


        private bool SavePaymentCash_Server(PaymentCash mPaymentCash)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Clear();
            parameters["siteId"] = mPaymentCash.site_id;
            parameters["posNo"] = mPaymentCash.pos_no;
            parameters["bizDt"] = mPaymentCash.biz_dt;
            parameters["theNo"] = mPaymentCash.the_no;
            parameters["refNo"] = mPaymentCash.ref_no;

            parameters["payDate"] = mPaymentCash.pay_date;
            parameters["payTime"] = mPaymentCash.pay_time;
            parameters["payType"] = mPaymentCash.pay_type;
            parameters["tranType"] = mPaymentCash.tran_type;
            parameters["payClass"] = mPaymentCash.pay_class;

            parameters["ticketNo"] = mPaymentCash.ticket_no;
            parameters["paySeq"] = mPaymentCash.pay_seq + "";
            parameters["tranDate"] = mPaymentCash.tran_date;
            parameters["amount"] = mPaymentCash.amount + "";
            parameters["receiptType"] = mPaymentCash.receipt_type;

            parameters["issuedMethodNo"] = mPaymentCash.issued_method_no;
            parameters["authNo"] = mPaymentCash.auth_no;
            parameters["tranSerial"] = mPaymentCash.tran_serial;
            parameters["isCancel"] = mPaymentCash.is_cancel;
            parameters["vanCode"] = mPaymentCash.van_code; ;

            if (mRequestPost("paymentCash", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {

                }
                else
                {
                    MessageBox.Show("오류 paymentCash\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("시스템오류 paymentCash\n\n" + mErrorMsg, "thepos");
                return false;
            }

            return true;

        }



        int requestCashAuth(int tAmount, int tFreeAmount, int tTaxAmount, int tTax, int tServiceAmt, String receipt_type, int input_type, out PaymentCash mPaymentCash)
        {
            int ret = -1;

            PaymentCash mPaymentCash2 = new PaymentCash();


            if (mVanCode == "NICE")
            {
                paymentNice p = new paymentNice();
                ret = p.requestNiceCashAuth(tAmount, tFreeAmount, tTaxAmount, tTax, tServiceAmt, receipt_type, input_type, out mPaymentCash2);
            }
            else if (mVanCode == "KCP")
            {
                paymentKCP p = new paymentKCP();
                ret = p.requestKcpCashAuth(tAmount, tFreeAmount, tTaxAmount, tTax, tServiceAmt, receipt_type, out mPaymentCash2);
            }
            else if (mVanCode == "KOVAN")
            {
                paymentKovan p = new paymentKovan();
                ret = p.requestKovanCashAuth(tAmount, tFreeAmount, tTaxAmount, tTax, tServiceAmt, receipt_type, out mPaymentCash2);
            }



            mPaymentCash = mPaymentCash2;


            return ret;
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
            if (mPayClass == "ST" | mPayClass == "CH")  // 정산창위에  떠있는 경우.
            {

            }
            else
            {
                //frmSales.ConsoleEnable();
            }


            if (isComplex == true)
                mPanelHigh.Visible = false;
            else
            {
                mPanelPayment.Visible = false;
                frmSales.ConsoleEnable();
            }

        }



    }
}
