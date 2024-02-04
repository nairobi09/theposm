using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static thepos.thePos;
using static thepos.frmSales;
using static thepos.frmFlowCharging;
using static thepos.frmFlowSettlement;
using static thepos.frmPayComplex;

namespace thepos
{
    public partial class frmPayCard : Form
    {
        RadioButton[] rbCard = new RadioButton[9];

        int netAmount = 0;

        int t과세금액 = 0;
        int t면세금액 = 0;

        bool isComplex = false;
        int paySeq = 1;
        bool isLast = false;
        int selectIdx = -1;

        TextBox saveKeyDisplay;

        String ticketNo = "";


        public frmPayCard(int net_amount, int r과세금액, int r면세금액, bool is_complex, int seq, bool is_last, int select_index)
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
                //
                ticketNo = frmFlowSettlement.mSelectedTicketNo;
                mRefNo = ticketNo.Substring(0, 20);

            }


            if (mTheMode == "Local")
            {
                gbCardAuth.Visible = false;
            }
            else
            {
                gbCardAuth.Visible = true;
            }

        }

        void initialize_font()
        {
            lblTitle.Font = font12;
            btnClose.Font = font12;

            lblNetAmountTitle.Font = font10;
            lblNetAmount.Font = font12;

            //
            lblCardNoTitle.Font = font10;
            tbCardNo.Font = font12;
            btnKeyInputCardNo.Font = font10;

            lblAuthNoTitle.Font = font10;
            tbAuthNo.Font = font12;
            btnKeyInputAuthNo.Font = font10;

            rbCard0.Font = font10;
            rbCard1.Font = font10;
            rbCard2.Font = font10;
            rbCard3.Font = font10;
            rbCard4.Font = font10;
            rbCard5.Font = font10;
            rbCard6.Font = font10;
            rbCard7.Font = font10;
            rbCard8.Font = font10;

            btnCardTemp.Font = font10;

            //
            lblInstallTitle.Font = font10;
            tbInstall.Font = font10;
            btnKeyInputInstall.Font = font10;

            btnInstall00.Font = font10;
            btnInstall03.Font = font10;
            btnInstall06.Font = font10;
            btnInstall12.Font = font10;

            chkCUP.Font = font10;

            btnCardRequest.Font = font10;

        }

        private void initial_the()
        {
            rbCard[0] = rbCard0;
            rbCard[1] = rbCard1;
            rbCard[2] = rbCard2;
            rbCard[3] = rbCard3;
            rbCard[4] = rbCard4;
            rbCard[5] = rbCard5;
            rbCard[6] = rbCard6;
            rbCard[7] = rbCard7;
            rbCard[8] = rbCard8;
        }

        private void btnKeyInputInstall_Click(object sender, EventArgs e)
        {
            tbInstall.Text = mTbKeyDisplaySales.Text;

        }

        private void btnKeyInputCardNo_Click(object sender, EventArgs e)
        {
            tbCardNo.Text = mTbKeyDisplaySales.Text;
            mTbKeyDisplaySales.Text = "";
        }

        private void btnKeyInputAuthNo_Click(object sender, EventArgs e)
        {
            tbAuthNo.Text = mTbKeyDisplaySales.Text;
            mTbKeyDisplaySales.Text = "";
        }



        private void btnCardTemp_Click(object sender, EventArgs e)
        {

            if (tbInstall.Text.Length != 2)
            {
                SetDisplayAlarm("W", "할부개월 오류.");
                return;
            }

            RadioButton rbSel = rbCard.FirstOrDefault(r => r.Checked);

            if (rbSel == null)
            {
                SetDisplayAlarm("W", "카드선택 오류.");
                return;
            }


            int order_cnt = 0;
            int dcAmount = 0;


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
            if (!SavePayment(paySeq, "Card", netAmount, dcAmount))
            {
                return;
            }



            //서버저장 paymentCard
            PaymentCard mPaymentCard = new PaymentCard();
            mPaymentCard.site_id = mSiteId;
            mPaymentCard.biz_dt = mBizDate;
            mPaymentCard.pos_no = mPosNo;
            mPaymentCard.the_no = mTheNo;
            mPaymentCard.ref_no = mRefNo;

            mPaymentCard.pay_date = get_today_date();
            mPaymentCard.pay_time = get_today_time();
            mPaymentCard.pay_type = "C0";       // 결제구분 : 임의등록(C0), 카드걀제(C1)
            mPaymentCard.tran_type = "A";       // 승인 A 취소 C
            mPaymentCard.pay_class = mPayClass;

            mPaymentCard.ticket_no = ticketNo;
            mPaymentCard.pay_seq = paySeq;
            mPaymentCard.tran_date = "";
            mPaymentCard.amount = netAmount;
            mPaymentCard.install = tbInstall.Text;
            mPaymentCard.auth_no = tbAuthNo.Text;
            mPaymentCard.card_no = tbCardNo.Text;
            mPaymentCard.card_name = rbSel.Text;
            mPaymentCard.isu_code = rbSel.Tag.ToString();
            mPaymentCard.acq_code = "";
            mPaymentCard.merchant_no = "";
            mPaymentCard.tran_serial = "";              // tran_serial -> 취소시 tid입력
            mPaymentCard.sign_path = "";
            mPaymentCard.is_cancel = "";        // 취소여부
            mPaymentCard.van_code = "";


            // 결제 항목 저장
            if (mTheMode == "Local")
            {
                if (!SavePaymentCard_Local(mPaymentCard))
                {
                    return;
                }
            }
            else
            {
                if (!SavePaymentCard_Server(mPaymentCard))
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
                lvItem.SubItems.Add(get_MMddHHmm(mPaymentCard.pay_date, mPaymentCard.pay_time));
                lvItem.SubItems.Add(thePos.get_pay_type_name(mPaymentCard.pay_type));
                lvItem.SubItems.Add(thePos.get_tran_type_name(mPaymentCard.tran_type));
                lvItem.SubItems.Add(mPaymentCard.card_no);
                lvItem.SubItems.Add(mPaymentCard.amount.ToString("N0"));
                lvItem.SubItems.Add(mPaymentCard.auth_no);
                mComplexLvwPay.Items.Add(lvItem);

                // 복합결제인 경우 seq 관리
                mPaySeq++;
            }


            String strAlarm = "";

            if (paySeq == 1)
            {
                strAlarm = "주문" + order_cnt + "건 카드임의등록 완료.";
            }
            else
            {
                strAlarm = "카드임의등록 완료.";
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
                        if (mPayClass == "OR")
                        {
                            // 티켓출력은 SaveTicketFlow() 내에서 한다.
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


                    // 정산-포인트사용분에 대해 취소마킹
                    if (mPayClass == "ST")
                    {
                        cancel_point_payment(ticketNo);
                    }

                }


                // 주문서 출력
                if (mPayClass == "OR")
                {
                    print_order();
                }


                // 영수증 출력
                if (mPaySeq == 1)
                    print_bill(mTheNo, "A", "", "0100", true); // card
                else
                    print_bill(mTheNo, "A", "", "1101", true); // cash card point easy


                if (mPayClass == "ST")  // 정산창위에  떠있는 경우.
                {
                }
                else if (mPayClass == "CH")
                {
                    mClearSaleForm();
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


        private void btnCardRequest_Click(object sender, EventArgs e)
        {
            if (tbInstall.Text.Length != 2)
            {
                SetDisplayAlarm("W", "할부개월 오류.");
                return;
            }


            String is_cup = "0";

            if (chkCUP.Checked == true) { is_cup = "1"; }


            int dcAmount = 0;


            //?? 결제시 금액 세팅 - 면세금액 세금 봉사료


            int tAmount = netAmount;    // 결제금액
            int tFreeAmount = 0;        // 면세금액
            int tTaxAmount = 0;         // 과세금액
            int tTax = 0;               // 세금
            int tServiceAmt = 0;
            int install = int.Parse(tbInstall.Text);
            PaymentCard mPaymentCard = new PaymentCard();


            tTax = t과세금액 / 11;
            tTaxAmount = t과세금액 - tTax;
            tFreeAmount = t면세금액;



            if (requestCardAuth(tAmount, tFreeAmount, tTaxAmount, tTax, tServiceAmt, install, is_cup, out mPaymentCard) != 0)
            {
                display_error_msg(mErrorMsg);
            }
            else
            {
                //정상승인
                int order_cnt = 0;

                
                // 리스트뷰 -> 메모리배열 생성 : [ 업장코드로 정렬 + 업장주문번호 부여 ]
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
                if (!SavePayment(paySeq, "Card", netAmount, dcAmount))
                {
                    return;
                }



                // 서버저장 paymentCard
                mPaymentCard.site_id = mSiteId;
                mPaymentCard.biz_dt = mBizDate;
                mPaymentCard.pos_no = mPosNo;
                mPaymentCard.the_no = mTheNo;
                mPaymentCard.ref_no = mRefNo;
                mPaymentCard.pay_date = get_today_date();
                mPaymentCard.pay_time = get_today_time();
                mPaymentCard.pay_type = "C1";       // 결제구분 : , 카드결제(C1), 임의등록(C0)
                mPaymentCard.tran_type = "A";       // 승인 A 취소 C
                mPaymentCard.pay_class = mPayClass;
                mPaymentCard.ticket_no = ticketNo;
                mPaymentCard.pay_seq = paySeq;
                mPaymentCard.sign_path = "";
                mPaymentCard.is_cancel = "";
                mPaymentCard.van_code = mVanCode;
                mPaymentCard.is_cup = is_cup;

                // 밴에서 응답으로 받은건 payChannel 모듈에서 세팅

                if (!SavePaymentCard_Server(mPaymentCard))
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
                    lvItem.SubItems.Add(get_MMddHHmm(mPaymentCard.pay_date, mPaymentCard.pay_time));
                    lvItem.SubItems.Add(thePos.get_pay_type_name(mPaymentCard.pay_type));
                    lvItem.SubItems.Add(thePos.get_tran_type_name(mPaymentCard.tran_type));
                    lvItem.SubItems.Add(mPaymentCard.card_no);
                    lvItem.SubItems.Add(mPaymentCard.amount.ToString("N0"));
                    lvItem.SubItems.Add(mPaymentCard.auth_no);
                    mComplexLvwPay.Items.Add(lvItem);

                    // 복합결제인 경우 seq 관리
                    mPaySeq++;
                }


                String strAlarm = "";

                if (paySeq == 1)
                {
                    strAlarm = "주문" + order_cnt + "건 카드결제승인 완료.";
                }
                else
                {
                    strAlarm = "카드결제승인 완료.";
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
                        print_bill(mTheNo, "A", "", "0100", true); // card
                    else
                        print_bill(mTheNo, "A", "", "1101", true); // cash card point easy

                    
                    // 정산-포인트사용분에 대해 취소마킹
                    if (mPayClass == "ST")
                    {
                        cancel_point_payment(ticketNo);
                    }


                    if (mPayClass == "ST")  // 정산창위에  떠있는 경우.
                    {
                    }
                    else if (mPayClass == "CH")
                    {
                        mClearSaleForm();
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


        private bool SavePaymentCard_Local(PaymentCard mPaymentCard)
        {

            String sql = "INSERT INTO paymentCard (siteId, posNo, bizDt, theNo, refNo, payDate, payTime, payType, tranType, payClass, ticketNo, paySeq, tranDate, amount, taxAmount, freeAmount, serviceAmt, tax, install, authNo, cardNo, cardName, isuCode, acqCode, merchantNo, tranSerial, signPath, giftChange, isCancel, vanCode) " +
                "values ('" + mPaymentCard.site_id + "','" + mPaymentCard.pos_no + "','" + mPaymentCard.biz_dt + "','" + mPaymentCard.the_no + "','" + mPaymentCard.ref_no + "'," + 
                        "'" + mPaymentCard.pay_date + "','" + mPaymentCard.pay_time + "','" + mPaymentCard.pay_type + "','" + mPaymentCard.tran_type + "','" + mPaymentCard.pay_class + "'," +
                        "'" + mPaymentCard.ticket_no + "'," + mPaymentCard.pay_seq + ",'" + mPaymentCard.tran_date + "'," + mPaymentCard.amount + "," + mPaymentCard.tax_amount + "," +
                        "" + mPaymentCard.tfree_amount + "," +  mPaymentCard.service_amount + "," + mPaymentCard.tax + ",'" + mPaymentCard.install + "','" + mPaymentCard.auth_no + "'," +
                        "'" + mPaymentCard.card_no + "','" + mPaymentCard.card_name + "','" + mPaymentCard.isu_code + "','" + mPaymentCard.acq_code + "','" + mPaymentCard.merchant_no + "'," +
                        "'" + mPaymentCard.tran_serial + "','" + mPaymentCard.sign_path + "','" + mPaymentCard.gift_change + "','" + mPaymentCard.is_cancel + "','" + mPaymentCard.van_code + "')";
            int ret = sql_excute_local_db(sql);


            return true;

        }


        private bool SavePaymentCard_Server(PaymentCard mPaymentCard)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Clear();
            parameters["siteId"] = mPaymentCard.site_id;
            parameters["posNo"] = mPaymentCard.pos_no;
            parameters["bizDt"] = mPaymentCard.biz_dt;
            parameters["theNo"] = mPaymentCard.the_no;
            parameters["refNo"] = mPaymentCard.ref_no;

            parameters["payDate"] = mPaymentCard.pay_date;
            parameters["payTime"] = mPaymentCard.pay_time;
            parameters["payType"] = mPaymentCard.pay_type;
            parameters["tranType"] = mPaymentCard.tran_type;
            parameters["payClass"] = mPaymentCard.pay_class;

            parameters["ticketNo"] = mPaymentCard.ticket_no;
            parameters["paySeq"] = mPaymentCard.pay_seq + "";
            parameters["tranDate"] = mPaymentCard.tran_date;
            parameters["amount"] = mPaymentCard.amount + "";
            parameters["taxAmount"] = mPaymentCard.tax_amount + "";

            parameters["freeAmount"] = mPaymentCard.tfree_amount + "";
            parameters["serviceAmt"] = mPaymentCard.service_amount + "";
            parameters["tax"] = mPaymentCard.tax + "";
            parameters["install"] = mPaymentCard.install;
            parameters["authNo"] = mPaymentCard.auth_no;

            parameters["cardNo"] = mPaymentCard.card_no;
            parameters["cardName"] = mPaymentCard.card_name;
            parameters["isuCode"] = mPaymentCard.isu_code;
            parameters["acqCode"] = mPaymentCard.acq_code;
            parameters["merchantNo"] = mPaymentCard.merchant_no;

            parameters["tranSerial"] = mPaymentCard.tran_serial;
            parameters["signPath"] = mPaymentCard.sign_path;
            parameters["giftChange"] = mPaymentCard.gift_change + "";
            parameters["isCancel"] = mPaymentCard.is_cancel;
            parameters["vanCode"] = mPaymentCard.van_code; ;
            parameters["isCup"] = mPaymentCard.is_cup;

            if (mRequestPost("paymentCard", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {

                }
                else
                {
                    MessageBox.Show("오류 paymentCard\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("시스템오류 paymentCard\n\n" + mErrorMsg, "thepos");
                return false;
            }

            return true;

        }


        private static int requestCardAuth(int tAmount, int tFreeAmount, int tTaxAmount, int tTax, int tServiceAmt, int install, String is_cup, out PaymentCard mPaymentCard)
        {
            int ret = 0;


            PaymentCard mPaymentCard2 = new PaymentCard();

            if (mVanCode == "NICE")
            {
                paymentNice p = new paymentNice();
                ret = p.requestNiceCardAuth(tAmount, tFreeAmount, tTaxAmount, tTax, tServiceAmt, install, is_cup, out mPaymentCard2);
            }
            else if (mVanCode == "KCP")
            {
                paymentKCP p = new paymentKCP();
                ret = p.requestKcpCardAuth(tAmount, tFreeAmount, tTaxAmount, tTax, tServiceAmt, install, is_cup, out mPaymentCard2);
            }
            else if (mVanCode == "KOVAN")
            {
                paymentKovan p = new paymentKovan();
                ret = p.requestKovanCardAuth(tAmount, tFreeAmount, tTaxAmount, tTax, tServiceAmt, install, is_cup, out mPaymentCard2);
            }

            mPaymentCard = mPaymentCard2;

            return ret;

        }


        void display_error_msg(string msg)
        {
            MessageBox.Show(msg, "thepos");
        }


        private void btnInstall00_Click(object sender, EventArgs e) { tbInstall.Text = "00"; }
        private void btnInstall03_Click(object sender, EventArgs e) { tbInstall.Text = "03"; }
        private void btnInstall06_Click(object sender, EventArgs e) { tbInstall.Text = "06"; }
        private void btnInstall12_Click(object sender, EventArgs e) { tbInstall.Text = "12"; }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmPayCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mPayClass == "ST" | mPayClass == "CH")  // 정산창위에  떠있는 경우.
            {
            }
            else
            {
                //frmSales.ConsoleEnable();
            }

            mTbKeyDisplayController = saveKeyDisplay;

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
