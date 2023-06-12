using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static thepos.theSale;
using static thepos.frmSale;
using static thepos.frmPayComplex;
using static thepos.paymentToss;

namespace thepos
{

    public partial class frmPayCard : Form
    {
        RadioButton[] rbCard = new RadioButton[9];

        int netAmount = 0;

        bool isComplex = false;
        int paySeq = 1;
        bool isLast = false;

        TextBox saveKeyDisplay;


        public frmPayCard(int net_amount, bool is_complex, int seq, bool is_last)
        {
            InitializeComponent();

            initialize_font();
            initial_the();

            isComplex = is_complex;
            paySeq = seq;
            isLast = is_last;

            netAmount = net_amount;
            lblNetAmount.Text = netAmount.ToString("N0");

            saveKeyDisplay = mTbKeyDisplayController;
            mTbKeyDisplayController = mTbKeyDisplaySales;
        }

        void initialize_font()
        {
            lblTitle.Font = font12;
            btnClose.Font = font12;

            lblT1.Font = font10;
            lblT2.Font = font10;

            lblNetAmount.Font = font12;
            tbInstall.Font = font12;

            btnKeyInputInstall.Font = font10;

            btnInstall00.Font = font10;
            btnInstall03.Font = font10;
            btnInstall06.Font = font10;
            btnInstall12.Font = font10;

            btnCardRequest.Font = font10;

            lblT3.Font = font10;
            lblT4.Font = font10;

            tbCardNo.Font = font12;
            tbAuthNo.Font = font12;

            btnKeyInputCardNo.Font = font10;
            btnKeyInputAuthNo.Font = font10;

            btnCardTemp.Font = font10;


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



            //? 서버API로 교체
            int order_cnt = 0;

            if (paySeq == 1)
            {
                // 주문 저장 1
                order_cnt = SaveOrder();

            }

            // pay_class
            String payClass = "0";  // 주문
            //payClass = "1";       // 충전
            //payClass = "2";       // 정산

            SavePayment(paySeq, payClass, "Card", netAmount);  // payment



            PaymentCard mPaymentCard = new PaymentCard();
            mPaymentCard.the_no = mTheNo;
            mPaymentCard.pay_seq = paySeq;
            mPaymentCard.business_dt = mBussinessDate;
            mPaymentCard.pay_date = get_today_date();
            mPaymentCard.pay_time = get_today_time();
            mPaymentCard.pay_type = "C9";       // 결제구분 : 카드걀제(C1), 임의등록(C9)
            mPaymentCard.tran_type = "A";       // 승인 A 취소 C
            mPaymentCard.amount = netAmount;
            mPaymentCard.card_no = tbCardNo.Text;
            mPaymentCard.auth_no = tbAuthNo.Text;
            mPaymentCard.install = tbInstall.Text;
            mPaymentCard.card_name = rbSel.Text;
            mPaymentCard.isu_code = rbSel.Tag.ToString();
            mPaymentCard.acq_code = "";
            mPaymentCard.merchant_no = "";
            mPaymentCard.tran_serial = "";              // tran_serial -> 취소시 tid입력
            mPaymentCard.is_cancel = "";        // 취소여부
            mPaymentCards.Add(mPaymentCard);



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
                lvItem.SubItems.Add(theSale.get_pay_type_name(mPaymentCard.pay_type));
                lvItem.SubItems.Add(theSale.get_tran_type_name(mPaymentCard.tran_type));
                lvItem.SubItems.Add(mPaymentCard.card_no);
                lvItem.SubItems.Add(mPaymentCard.amount.ToString("N0"));
                lvItem.SubItems.Add(mPaymentCard.auth_no);
                mComplexLvwPay.Items.Add(lvItem);

                // 복합결제인 경우 seq 관리
                mPaySeq++;
            }
            else
            {
                // 단독결제인 Sales화면 클리어. 
                // 복합결제는 Complex화면에서 Sales화면을 클리어
                mClearSaleForm();
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
                // 티켓 저장
                int ticket_cnt = SaveTicket();

                if (ticket_cnt > 0)
                {
                    strAlarm += " 티켓발권 " + ticket_cnt + "건 출력.";
                    SetDisplayAlarm("I", strAlarm);

                    //? 
                    // 티켓 출력 개발요망

                }

                mClearSaleForm();

                countup_the_no();
                mPaySeq = 1;
            }

            this.Close();
        }


        private void btnCardRequest_Click(object sender, EventArgs e)
        {
            //int d= mNetAmount;

            if (tbInstall.Text.Length != 2)
            {
                SetDisplayAlarm("W", "할부개월 오류.");
                return;
            }

            int install = int.Parse(tbInstall.Text);



            if (paymentToss.requestTossCardAuth(netAmount, install) != 0)  // Toss process
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
                    order_cnt = SaveOrder();

                }


                // pay_class
                String payClass = "0";  // 주문
                //payClass = "1";       // 충전
                //payClass = "2";       // 정산

                SavePayment(paySeq, payClass, "Card", netAmount);  // payment


                PaymentCard mPaymentCard = new PaymentCard();
                mPaymentCard.the_no = mTheNo;
                mPaymentCard.pay_seq = paySeq;
                mPaymentCard.business_dt = mBussinessDate;
                mPaymentCard.pay_date = get_today_date();
                mPaymentCard.pay_time = get_today_time();
                mPaymentCard.pay_type = "C1";       // 결제구분 : , 카드결제(C1), 임의등록(C9)
                mPaymentCard.tran_type = "A";       // 승인 A 취소 C
                mPaymentCard.tran_date = mTossResponse.Trandate;
                mPaymentCard.amount = int.Parse(mTossResponse.Tamt);
                mPaymentCard.card_no = mTossResponse.Cardno;
                mPaymentCard.auth_no = mTossResponse.Authno;
                mPaymentCard.install = mTossResponse.Halbu;
                mPaymentCard.card_name = mTossResponse.Financename;
                mPaymentCard.isu_code = mTossResponse.Stlinst;
                mPaymentCard.acq_code = mTossResponse.Reqinst;
                mPaymentCard.merchant_no = mTossResponse.Merno;
                mPaymentCard.tran_serial = mTossResponse.Tran_serial;              // tran_serial -> 취소시 tid입력
                mPaymentCard.sign_path = mTossResponse.Signpath;
                mPaymentCard.is_cancel = "";        // 취소여부
                mPaymentCards.Add(mPaymentCard);



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
                    lvItem.SubItems.Add(theSale.get_pay_type_name(mPaymentCard.pay_type));
                    lvItem.SubItems.Add(theSale.get_tran_type_name(mPaymentCard.tran_type));
                    lvItem.SubItems.Add(mPaymentCard.card_no);
                    lvItem.SubItems.Add(mPaymentCard.amount.ToString("N0"));
                    lvItem.SubItems.Add(mPaymentCard.auth_no);
                    mComplexLvwPay.Items.Add(lvItem);

                    // 복합결제인 경우 seq 관리
                    mPaySeq++;
                }
                else
                {
                    // 단독결제인 Sales화면 클리어. 
                    // 복합결제는 Complex화면에서 Sales화면을 클리어
                    mClearSaleForm();
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
                    // 티켓 저장
                    int ticket_cnt = SaveTicket();

                    if (ticket_cnt > 0)
                    {
                        strAlarm += " 티켓발권 " + ticket_cnt + "건 출력.";
                        SetDisplayAlarm("I", strAlarm);

                        //? 
                        // 티켓 출력 개발요망

                    }

                    mClearSaleForm();

                    countup_the_no();
                    mPaySeq = 1;
                }

                this.Close();
            }
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
            frmSale.ConsoleEnable();

            mTbKeyDisplayController = saveKeyDisplay;
        }

    }
}
