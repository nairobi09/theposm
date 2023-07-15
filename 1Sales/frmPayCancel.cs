using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static thepos.thePos;
using static thepos.frmSales;
using static thepos.paymentToss;

namespace thepos
{
    public partial class frmPayCancel : Form
    {
        String theNo;
        String ticketNo;

        int netAmount = 0;
        int cancelAmount = 0;
        int nestAmount = 0;

        public frmPayCancel(String the_no, String ticket_no)
        {
            InitializeComponent();
            initialize_font();
            initial_the();

            theNo = the_no;
            ticketNo = ticket_no;

            viewPayList();
        }

        private void viewPayList()
        {
            //? 서버API로 전환
            netAmount = 0;
            cancelAmount = 0;
            nestAmount = 0;

            lvwPay.Items.Clear();

            for (int i = 0; i < mPaymentCards.Count; i++)
            {
                if (mPaymentCards[i].the_no == theNo)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Text = mPaymentCards[i].pay_seq.ToString();
                    lvItem.SubItems.Add(get_MMddHHmm(mPaymentCards[i].pay_date, mPaymentCards[i].pay_time));
                    lvItem.SubItems.Add(get_pay_type_name(mPaymentCards[i].pay_type));
                    lvItem.SubItems.Add(get_tran_type_name(mPaymentCards[i].tran_type));

                    if (mPaymentCards[i].tran_type == "C")
                        lvItem.SubItems.Add((-mPaymentCards[i].amount).ToString("N0"));
                    else
                        lvItem.SubItems.Add(mPaymentCards[i].amount.ToString("N0"));

                    //lvItem.SubItems.Add(mPaymentCards[i].amount.ToString("N0"));

                    lvItem.SubItems.Add(mPaymentCards[i].is_cancel);
                    lvItem.SubItems.Add(mPaymentCards[i].the_no);
                    lvItem.SubItems.Add(mPaymentCards[i].pay_type);
                    lvItem.SubItems.Add(mPaymentCards[i].tran_type);
                    lvwPay.Items.Add(lvItem);

                    if (mPaymentCards[i].tran_type == "A") { netAmount += mPaymentCards[i].amount; }

                    if (mPaymentCards[i].tran_type == "C") { cancelAmount += mPaymentCards[i].amount; }

                }
            }

            for (int i = 0; i < mPaymentCashs.Count; i++)
            {
                if (mPaymentCashs[i].the_no == theNo)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Tag = mPaymentCashs[i].the_no;
                    lvItem.Text = mPaymentCashs[i].pay_seq.ToString();
                    lvItem.SubItems.Add(get_MMddHHmm(mPaymentCashs[i].pay_date, mPaymentCashs[i].pay_time));
                    lvItem.SubItems.Add(get_pay_type_name(mPaymentCashs[i].pay_type));
                    lvItem.SubItems.Add(get_tran_type_name(mPaymentCashs[i].tran_type));

                    if (mPaymentCashs[i].tran_type == "C")
                        lvItem.SubItems.Add((-mPaymentCashs[i].amount).ToString("N0"));
                    else
                        lvItem.SubItems.Add(mPaymentCashs[i].amount.ToString("N0"));

                    //lvItem.SubItems.Add(mPaymentCashs[i].amount.ToString("N0"));
                    
                    lvItem.SubItems.Add(mPaymentCashs[i].is_cancel);
                    lvItem.SubItems.Add(mPaymentCashs[i].the_no);
                    lvItem.SubItems.Add(mPaymentCashs[i].pay_type);
                    lvItem.SubItems.Add(mPaymentCashs[i].tran_type);
                    lvwPay.Items.Add(lvItem);

                    if (mPaymentCashs[i].tran_type == "A") { netAmount += mPaymentCashs[i].amount; }

                    if (mPaymentCashs[i].tran_type == "C") { cancelAmount += mPaymentCashs[i].amount; }

                }
            }

            for (int i = 0; i < mPaymentPoints.Count; i++)
            {
                if (mPaymentPoints[i].the_no == theNo)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Tag = mPaymentPoints[i].the_no;
                    lvItem.Text = "1";
                    lvItem.SubItems.Add(get_MMddHHmm(mPaymentPoints[i].pay_date, mPaymentPoints[i].pay_time));
                    lvItem.SubItems.Add(get_pay_type_name(mPaymentPoints[i].pay_type));
                    lvItem.SubItems.Add(get_tran_type_name(mPaymentPoints[i].tran_type));

                    if (mPaymentPoints[i].tran_type == "C")
                        lvItem.SubItems.Add((-mPaymentPoints[i].amount).ToString("N0"));
                    else
                        lvItem.SubItems.Add(mPaymentPoints[i].amount.ToString("N0"));


                    lvItem.SubItems.Add(mPaymentPoints[i].is_cancel);
                    lvItem.SubItems.Add(mPaymentPoints[i].the_no);
                    lvItem.SubItems.Add(mPaymentPoints[i].pay_type);
                    lvItem.SubItems.Add(mPaymentPoints[i].tran_type);
                    lvwPay.Items.Add(lvItem);

                    if (mPaymentPoints[i].tran_type == "A") { netAmount += mPaymentPoints[i].amount; }

                    if (mPaymentPoints[i].tran_type == "C") { cancelAmount += mPaymentPoints[i].amount; }

                }
            }

            nestAmount = netAmount - cancelAmount;

            lblNetAmount.Text = netAmount.ToString("N0");
            lblCancelAmount.Text = cancelAmount.ToString("N0");
            lblNestAmount.Text = nestAmount.ToString("N0");
        }

        private void initialize_font()
        {
            lblTitle.Font = font12;
            btnClose.Font = font12;

            lblT1.Font = font10;
            lblT2.Font = font10;
            lblT3.Font = font10;

            lblNetAmount.Font = font10;
            lblCancelAmount.Font = font10;
            lblNestAmount.Font = font10;

            lvwPay.Font = font10;

            btnCancel.Font = font10;
        }

        private void initial_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwPay.SmallImageList = imgList;

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwPay.SelectedItems.Count == 0) { return; }

            String the_no = lvwPay.SelectedItems[0].SubItems[6].Text.ToString();
            String pay_type = lvwPay.SelectedItems[0].SubItems[7].Text.ToString();
            int pay_seq = int.Parse(lvwPay.SelectedItems[0].Text);
            int idx = 0;



            //if (lvwPay.SelectedItems[0].SubItems[8].Text == "C") return;  // 취소건 제외

            if (lvwPay.SelectedItems[0].SubItems[5].Text == "Y")
            {
                SetDisplayAlarm("W", "취소된 승인 or 취소건.");
                return;  // 취소건, 취소된 승인건 - 제외
            }


            if (pay_type == "C0" | pay_type == "C1" | pay_type == "C9")
            {

                for (int i = 0; i < mPaymentCards.Count; i++)
                {
                    if (mPaymentCards[i].the_no == the_no & mPaymentCards[i].pay_seq == pay_seq)
                    {
                        idx = i; break;
                    }
                }

                //
                if (mPaymentCards[idx].pay_type == "C1")  // 카드결제취소
                {

                    PaymentCard pCardCancel = new PaymentCard();

                    if (requestCardCancel(mPaymentCards[idx], out pCardCancel) != 0)  // Toss process
                    {
                        display_error_msg(mErrorMsg);
                    }
                    else
                    {
                        //
                        cancel_order_and_payments(mPaymentCards[idx].amount);


                        //

                        pCardCancel.site_id = mSiteId;
                        pCardCancel.biz_dt = mBizDate;
                        pCardCancel.pos_no = mPosNo;
                        pCardCancel.the_no = mPaymentCards[idx].the_no;
                        pCardCancel.ref_no = mPaymentCards[idx].ref_no;

                        pCardCancel.pay_date = get_today_date();
                        pCardCancel.pay_time = get_today_time();
                        pCardCancel.pay_type = "C1";       // 결제구분 : , 카드승인(C1), 임의등록(C9)
                        pCardCancel.tran_type = "C";       // 승인 A 취소 C
                        pCardCancel.pay_class = mPayClass;
                        pCardCancel.ticket_no = mPaymentCards[idx].ticket_no;
                        pCardCancel.pay_seq = mPaymentCards[idx].pay_seq;
                        pCardCancel.install = mPaymentCards[idx].install;  //
                        pCardCancel.auth_no = mPaymentCards[idx].auth_no; //
                        pCardCancel.card_name = mPaymentCards[idx].card_name;  //

                        // 

                        pCardCancel.is_cancel = "Y";        // 취소여부
                        mPaymentCards.Add(pCardCancel);


                        // 승인건에 취소마킹
                        PaymentCard pc = new PaymentCard();
                        pc = mPaymentCards[idx];
                        pc.is_cancel = "Y";
                        mPaymentCards[idx] = pc;


                        SetDisplayAlarm("I", "카드결제 취소.");
                        MessageBox.Show("카드결제 취소 성공", "thepos");
                    }
                }
                else if (mPaymentCards[idx].pay_type == "C9")  // 임의 등록
                {
                    //? 자동취소
                    cancel_order_and_payments(mPaymentCards[idx].amount);

                    //
                    PaymentCard paymentCard = new PaymentCard();
                    paymentCard.site_id = mSiteId;
                    paymentCard.biz_dt = mBizDate;
                    paymentCard.pos_no = mPosNo;
                    paymentCard.the_no = mPaymentCards[idx].the_no;
                    paymentCard.ref_no = mPaymentCards[idx].ref_no;

                    paymentCard.pay_date = get_today_date();
                    paymentCard.pay_time = get_today_time();
                    paymentCard.pay_type = "C9";       // 결제구분 : , 카드승인(C1), 임의등록(C9)
                    paymentCard.tran_type = "C";       // 승인 A 취소 C
                    paymentCard.pay_class = mPayClass;
                    paymentCard.ticket_no = mPaymentCards[idx].ticket_no;
                    paymentCard.pay_seq = mPaymentCards[idx].pay_seq;
                    paymentCard.tran_date = "";
                    paymentCard.amount = mPaymentCards[idx].amount;
                    paymentCard.install = mPaymentCards[idx].install;
                    paymentCard.auth_no = mPaymentCards[idx].auth_no;
                    paymentCard.card_no = mPaymentCards[idx].card_no;
                    paymentCard.card_name = mPaymentCards[idx].card_name;
                    paymentCard.isu_code = mPaymentCards[idx].isu_code;
                    paymentCard.acq_code = mPaymentCards[idx].acq_code;
                    paymentCard.merchant_no = mPaymentCards[idx].merchant_no;
                    paymentCard.tran_serial = mPaymentCards[idx].tran_serial;     // tran_serial -> 취소시 tid입력
                    paymentCard.is_cancel = "Y";        // 취소여부
                    mPaymentCards.Add(paymentCard);


                    // 승인건에 취소마킹
                    PaymentCard pc = new PaymentCard();
                    pc = mPaymentCards[idx];
                    pc.is_cancel = "Y";
                    mPaymentCards[idx] = pc;



                    SetDisplayAlarm("I", "카드임의등록 취소.");
                    MessageBox.Show("카드임의등록 취소 성공", "thepos");
                }
            }
            else if (pay_type == "R0" | pay_type == "R1")
            {

                for (int i = 0; i < mPaymentCashs.Count; i++)
                {
                    if (mPaymentCashs[i].the_no == the_no & mPaymentCashs[i].pay_seq == pay_seq)
                    {
                        idx = i; break;
                    }
                }

                //
                if (mPaymentCashs[idx].pay_type == "R1")  // 현금영수증 취소
                {
                    PaymentCash pCashCancel = new PaymentCash();

                    if (requestCashCancel(mPaymentCashs[idx], out pCashCancel) != 0)  // Toss process
                    {
                        display_error_msg(mErrorMsg);
                    }
                    else
                    {
                        //
                        cancel_order_and_payments(mPaymentCashs[idx].amount);


                        pCashCancel.site_id = mSiteId;
                        pCashCancel.biz_dt = mBizDate;
                        pCashCancel.pos_no = mPosNo;
                        pCashCancel.the_no = mPaymentCashs[idx].the_no;
                        pCashCancel.ref_no = mPaymentCashs[idx].ref_no;

                        pCashCancel.pay_date = get_today_date();
                        pCashCancel.pay_time = get_today_time();
                        pCashCancel.pay_type = "R1";       // 결제구분 : , 카드승인(C1), 임의등록(C9)
                        pCashCancel.tran_type = "C";       // 승인 A 취소 C
                        pCashCancel.pay_class = mPayClass;
                        pCashCancel.ticket_no = mPaymentCashs[idx].ticket_no;
                        pCashCancel.pay_seq = mPaymentCashs[idx].pay_seq;
                        pCashCancel.amount = mPaymentCashs[idx].amount;
                        pCashCancel.receipt_type = mPaymentCashs[idx].receipt_type;

                        //

                        pCashCancel.is_cancel = "Y";        // 취소여부
                        mPaymentCashs.Add(pCashCancel);


                        // 승인건에 취소마킹
                        PaymentCash pc = new PaymentCash();
                        pc = mPaymentCashs[idx];
                        pc.is_cancel = "Y";
                        mPaymentCashs[idx] = pc;


                        SetDisplayAlarm("I", "현금영수증 취소.");
                        MessageBox.Show("현금영수증 취소 성공", "thepos");
                    }
                }
                else if (mPaymentCashs[idx].pay_type == "R0")  // 단순현금
                {
                    //? 자동취소
                    cancel_order_and_payments(mPaymentCashs[idx].amount);

                    //
                    PaymentCash paymentCash = new PaymentCash();
                    paymentCash.site_id = mSiteId;
                    paymentCash.biz_dt = mBizDate;
                    paymentCash.pos_no = mPosNo;
                    paymentCash.the_no = mPaymentCashs[idx].the_no;
                    paymentCash.ref_no = mPaymentCashs[idx].ref_no;

                    paymentCash.pay_date = get_today_date();
                    paymentCash.pay_time = get_today_time();
                    paymentCash.pay_type = "R0";       // 결제구분
                    paymentCash.tran_type = "C";       // 승인 A 취소 C
                    paymentCash.pay_class = mPayClass;
                    paymentCash.ticket_no = mPaymentCashs[idx].ticket_no;
                    paymentCash.pay_seq = mPaymentCashs[idx].pay_seq;
                    paymentCash.tran_date = "";
                    paymentCash.amount = mPaymentCashs[idx].amount;
                    paymentCash.issued_method_no = mPaymentCashs[idx].issued_method_no;
                    paymentCash.auth_no = mPaymentCashs[idx].auth_no;
                    paymentCash.is_cancel = "Y";        // 취소여부
                    mPaymentCashs.Add(paymentCash);


                    // 승인건에 취소마킹
                    PaymentCash pc = new PaymentCash();
                    pc = mPaymentCashs[idx];
                    pc.is_cancel = "Y";
                    mPaymentCashs[idx] = pc;



                    SetDisplayAlarm("I", "현금영수증 취소.");
                    MessageBox.Show("현금영수증 취소 성공", "thepos");
                }
            }
            else if (pay_type == "PA" | pay_type == "PD")
            {

                for (int i = 0; i < mPaymentPoints.Count; i++)
                {
                    if (mPaymentPoints[i].the_no == the_no)
                    {
                        idx = i; break;
                    }
                }

 

                //? 자동취소
                cancel_order_and_payments(mPaymentPoints[idx].amount);

                //
                PaymentPoint paymentPoint = new PaymentPoint();
                paymentPoint.site_id = mSiteId;
                paymentPoint.biz_dt = mBizDate;
                paymentPoint.pos_no = mPosNo;
                paymentPoint.the_no = mPaymentPoints[idx].the_no;
                paymentPoint.ref_no = mPaymentPoints[idx].ref_no;

                paymentPoint.pay_date = get_today_date();
                paymentPoint.pay_time = get_today_time();
                paymentPoint.pay_type = mPaymentPoints[idx].pay_type;       // 결제구분
                paymentPoint.tran_type = "C";       // 승인 A 취소 C
                paymentPoint.pay_class = mPayClass;
                paymentPoint.ticket_no = mPaymentPoints[idx].ticket_no;
                paymentPoint.usage_no = mPaymentPoints[idx].usage_no;
                paymentPoint.amount = mPaymentPoints[idx].amount;
                paymentPoint.is_cancel = "Y";        // 취소여부
                mPaymentPoints.Add(paymentPoint);


                // 승인건에 취소마킹
                PaymentPoint pc = new PaymentPoint();
                pc = mPaymentPoints[idx];
                pc.is_cancel = "Y";
                mPaymentPoints[idx] = pc;




                //
                for (int i = 0; i < mTicketFlowList.Count; i++)
                {
                    if (mTicketFlowList[i].ticket_no == mPaymentPoints[idx].ticket_no)
                    {
                        TicketFlow ticketFlow = new TicketFlow();
                        ticketFlow = mTicketFlowList[i];
                        ticketFlow.point_usage -= mPaymentPoints[idx].amount;

                        mTicketFlowList[i] = ticketFlow;
                    }
                }


                SetDisplayAlarm("I", "포인트 취소.");
                MessageBox.Show("포인트 취소 성공", "thepos");

            }


            if (mPayClass == "ST")
            {
                SaveTicket(ticketNo, "CH");  // CH 충전

            }



            // 다시 불러오기
            viewPayList();

        }

        void cancel_order_and_payments(int amount)
        {
            // 주문건 취소 세트
            for (int i = 0; i < listOrder.Count; i++)
            {
                if (listOrder[i].the_no == theNo)
                {
                    dbOrder order = listOrder[i];
                    order.is_cancel = "Y";
                    listOrder[i] = order;
                    break;
                }
            }

            for (int i = 0; i < listOrderItem.Count; i++)
            {
                if (listOrderItem[i].the_no == theNo)
                {
                    dbOrderItem orderItem = listOrderItem[i];
                    orderItem.is_cancel = "Y";
                    listOrderItem[i] = orderItem;
                    break;
                }
            }


            // 취소상태를 세팅
            for (int i = 0; i < mPayments.Count; i++)
            {
                Payment payment = new Payment();

                if (mPayments[i].the_no == theNo & mPayments[i].tran_type =="A")
                {
                    payment = mPayments[i];

                    // 승인건의 취소상태를 세팅
                    if (netAmount == cancelAmount + amount)
                    {
                        payment.is_cancel = "Y";   // 취소
                    }
                    else
                    {
                        payment.is_cancel = "0";    //취소중
                    }

                    mPayments[i] = payment;



                    // 취소건을 추가함
                    if (cancelAmount == 0)  //최초
                    {
                        payment.tran_type = "C";
                        payment.pay_date = get_today_date();
                        payment.pay_time = get_today_time();
                        mPayments.Add(payment);
                    }
                    else
                    {
                        for (int k = 0; k < mPayments.Count; k++)
                        {
                            if (mPayments[k].the_no == theNo & mPayments[k].tran_type == "C")
                            {
                                payment = mPayments[k];

                                if (netAmount == cancelAmount + amount)
                                {
                                    payment.is_cancel = "Y";   // 취소
                                }
                                else
                                {
                                    payment.is_cancel = "0";    //취소중
                                }

                                mPayments[k] = payment;
                                break;
                            }
                        }
                    }
                    break;
                }
            }


            // 취소건 추가


        }




        int requestCardCancel(PaymentCard mPaymentCards, out PaymentCard pCardCancel)
        {
            int ret = 0;
            PaymentCard cardCancel = new PaymentCard();
            pCardCancel = cardCancel;

            if (mPayChannel == "KCP")
            {
                ret = paymentKCP.requestKcpCardCancel(mPaymentCards, out pCardCancel);
            }
            else if (mPayChannel == "TOSS")
            {
                ret = paymentToss.requestTossCardCancel(mPaymentCards, out pCardCancel);
            }
            else
            {

            }

            return 0;

        }

        int requestCashCancel(PaymentCash paymentCash, out PaymentCash pCashCancel)
        {
            int ret = 0;
            PaymentCash cashCancel = new PaymentCash();
            pCashCancel = cashCancel;

            if (mPayChannel == "KCP")
            {

            }
            else if (mPayChannel == "TOSS")
            {
                ret = paymentToss.requestTossCashCancel(paymentCash, out pCashCancel);
            }


            return 0;

        }


        void display_error_msg(string msg)
        {
            MessageBox.Show(msg, "thepos");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }





    }
}
