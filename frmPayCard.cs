using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static thepos.frmSale;

namespace thepos
{

    public partial class frmPayCard : Form
    {
        [DllImport("C:\\TossPGPos\\TossPGPOSClient64.dll", EntryPoint = "UPay_Init", CallingConvention = CallingConvention.StdCall)]
        extern static int UPay_Init();
        [DllImport("C:\\TossPGPos\\TossPGPOSClient64.dll", EntryPoint = "UPay_Set", CallingConvention = CallingConvention.StdCall)]
        extern static int UPay_Set(string name, string value);
        [DllImport("C:\\TossPGPos\\TossPGPOSClient64.dll", EntryPoint = "UPay_TX", CallingConvention = CallingConvention.StdCall)]
        extern static int UPay_TX();
        [DllImport("C:\\TossPGPos\\TossPGPOSClient64.dll", EntryPoint = "UPayResNameCount", CallingConvention = CallingConvention.StdCall)]
        extern static int UPayResNameCount();
        [DllImport("C:\\TossPGPos\\TossPGPOSClient64.dll", EntryPoint = "UPayResName", CallingConvention = CallingConvention.StdCall)]
        extern static IntPtr UPayResName(int index);
        [DllImport("C:\\TossPGPos\\TossPGPOSClient64.dll", EntryPoint = "UPayResponse", CallingConvention = CallingConvention.StdCall)]
        extern static IntPtr UPayResponse(int index);
        [DllImport("C:\\TossPGPos\\TossPGPOSClient64.dll", EntryPoint = "UPayFinal", CallingConvention = CallingConvention.StdCall)]
        extern static int UPayFinal();

        //
        string mErrorMsg = "";


        RadioButton[] rbCard = new RadioButton[9];





        public struct TossResponse
        {
            public String Respcode;
            public string Msg;
            public string Trancode;
            public string Mid;
            public string Oid;
            public string Tamt;
            public string Tran_serial;
            public string Trandate;
            public string Financecode;
            public string Financename;
            public string Cardno;
            public string Halbu;
            public string Authno;
            public string Stlinst;
            public string Reqinst;
            public string Merno;
            public string Signpath;
            public string Cardgubun;
            public string Giftchange;
        }
        public TossResponse mTossResponse = new TossResponse();





        public frmPayCard()
        {
            InitializeComponent();

            initialize_font();
            initial_the();

        }

        void initialize_font()
        {
            lblTitle.Font = font12;

            lblT1.Font = font10;
            lblT2.Font = font10;

            lblNetAmount.Font = font12;
            lblInstall.Font = font12;

            btnKeyInputInstall.Font = font10;

            btnInstall00.Font = font10;
            btnInstall03.Font = font10;
            btnInstall06.Font = font10;
            btnInstall12.Font = font10;

            btnCardRequest.Font = font10;

            lblT3.Font = font10;
            lblT4.Font = font10;

            btnKeyInputCardNo.Font = font10;
            btnKeyInputAuthNo.Font = font10;

            btnCardTemp.Font = font10;

            btnClose.Font = font12;
        }

        private void initial_the()
        {
            lblNetAmount.Text = mNetAmount.ToString("N0");

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
            lblInstall.Text = mLblKeyDisplay.Text;
        }

        private void btnKeyInputCardNo_Click(object sender, EventArgs e)
        {
            lblCardNo.Text = mLblKeyDisplay.Text;
        }

        private void btnKeyInputAuthNo_Click(object sender, EventArgs e)
        {
            lblAuthNo.Text = mLblKeyDisplay.Text;
        }

        private void btnCardRequest_Click(object sender, EventArgs e)
        {
            //int d= mNetAmount;

            if (lblInstall.Text.Length != 2)
            {
                SetDisplayAlarm("W", "할부개월 오류.");
                return;
            }

            int install = int.Parse(lblInstall.Text);

            if (requestCardAuth(mNetAmount, install) != 0)  // Toss process
            {
                display_error_msg(mErrorMsg);
            }
            else
            {
                //정상승인
                //? 서버API로 교체

                int order_cnt = SaveOrder();

                Payment mPayment = new Payment();
                mPayment.the_no = mTheNo;
                mPayment.dt = DateTime.Now;
                mPayment.business_dt = mBussinessDate;
                mPayment.tran_type = "A";
                mPayment.pay_class = "0";    // Order 0, charge 1, settlement 2
                mPayment.pos_no = mPosNo;
                mPayment.serial_no = mTheNo.Substring(14, 4);
                mPayment.net_amount = mNetAmount;
                mPayment.amount_cash = 0;
                mPayment.amount_card = mNetAmount;
                mPayment.amount_point = 0;
                mPayment.is_dc = "";       // 할인여부
                mPayment.is_cancel = "";   // 취소여부
                mPayments.Add(mPayment);

                PaymentCard mPaymentCard = new PaymentCard();
                mPaymentCard.the_no = mTheNo;
                mPaymentCard.business_dt = mBussinessDate;
                mPaymentCard.dt = DateTime.Now;
                mPaymentCard.pay_type = "C1";       // 결제구분 : , 현금영수중(C1), 임의등록(C9)
                mPaymentCard.tran_type = "A";       // 승인 A 취소 C
                mPaymentCard.amount = mNetAmount;
                mPaymentCard.card_no = mTossResponse.Cardno;
                mPaymentCard.auth_no = mTossResponse.Authno;
                mPaymentCard.install = mTossResponse.Halbu;
                mPaymentCard.card_name = mTossResponse.Financename;
                mPaymentCard.isu_code = mTossResponse.Stlinst;
                mPaymentCard.acq_code = mTossResponse.Reqinst;
                mPaymentCard.merchant_no = mTossResponse.Merno;
                mPaymentCard.tid = mTossResponse.Tran_serial;              // tran_serial -> 취소시 tid입력
                mPaymentCard.is_cancel = "";        // 취소여부
                mPaymentCards.Add(mPaymentCard);

                mClearSaleForm();
                SetDisplayAlarm("I", "주문" + order_cnt + "건 카드 임의등록 완료.");

                countup_the_no();

                this.Close();


            }
        }


        public int requestCardAuth(int amount, int install)
        {
            int ret = 0;

            try
            {
                ret = UPay_Init();
            }
            catch (Exception e)
            {
                mErrorMsg = e.Message;
                return -1;
            }


            if (ret == -9)
            {
                mErrorMsg = "Toss DLL 초기화 오류";
                return -1;
            }

            Random random = new Random();
            int randomValue = random.Next(10000000, 99999999);

            ret = UPay_Set("LGD_TXNAME", "CardAuthOfflinePos");
            ret = UPay_Set("LGD_REQTYPE", "APPR");
            //ret = UPay_Set("LGD_MID", "");
            ret = UPay_Set("LGD_OID", mCustomerId + mPosNo + randomValue);
            ret = UPay_Set("LGD_AMOUNT", amount.ToString());
            ret = UPay_Set("LGD_INSTALL", install.ToString("00"));
            ret = UPay_Set("LGD_TAXFREEAMOUNT", "0");
            ret = UPay_Set("LGD_VAT", "0");
            ret = UPay_Set("VAN_SFEEAMOUNT", "0");
            ret = UPay_Set("VAN_TRANTYPE", "S0");

            ret = UPay_TX();

            int cnt = UPayResNameCount();

            string display_msg = "";

            String name;
            String value;

            for (int i = 0; i < cnt; i++)
            {
                name = Marshal.PtrToStringAnsi(UPayResName(i));
                value = Marshal.PtrToStringAnsi(UPayResponse(i));

                // 응답메시지 파싱
                if (name == "Respcode") mTossResponse.Respcode = value;
                else if (name == "Msg") mTossResponse.Msg = value;
                else if (name == "Trancode") mTossResponse.Trancode = value;
                else if (name == "Mid") mTossResponse.Mid = value;
                else if (name == "Oid") mTossResponse.Oid = value;
                else if (name == "Tamt") mTossResponse.Tamt = value;
                else if (name == "Tran_serial") mTossResponse.Tran_serial = value; //최소필요 TID
                else if (name == "Trandate") mTossResponse.Trandate = value;       //취소필요 원거래일
                else if (name == "Financecode") mTossResponse.Financecode = value; // 카드사코드
                else if (name == "Financename") mTossResponse.Financename = value; // 카드명
                else if (name == "Cardno") mTossResponse.Cardno = value;
                else if (name == "Halbu") mTossResponse.Halbu = value;
                else if (name == "Authno") mTossResponse.Authno = value;
                else if (name == "Stlinst") mTossResponse.Stlinst = value;
                else if (name == "Reqinst") mTossResponse.Reqinst = value;
                else if (name == "Merno") mTossResponse.Merno = value;
                else if (name == "Signpath") mTossResponse.Signpath = value;
                else if (name == "Cardgubun") mTossResponse.Cardgubun = value;
                else if (name == "Giftchange") mTossResponse.Giftchange = value;

                display_msg += name + ": " + value + "\n";
            }
            // TossPaymentsPOS_Client 자원반환
            ret = UPayFinal();

            if (mTossResponse.Respcode == "00")
            {
                return 0;
            }
            else
            {
                mErrorMsg = mTossResponse.Msg;
                return -1;
            }

        }








        void display_error_msg(string msg)
        {
            MessageBox.Show(msg);
        }


        private void btnInstall00_Click(object sender, EventArgs e) { lblInstall.Text = "00"; }
        private void btnInstall03_Click(object sender, EventArgs e) { lblInstall.Text = "03"; }
        private void btnInstall06_Click(object sender, EventArgs e) { lblInstall.Text = "06"; }
        private void btnInstall12_Click(object sender, EventArgs e) { lblInstall.Text = "12"; }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSale.ConsoleEnable();
        }

        private void btnCardTemp_Click(object sender, EventArgs e)
        {
            //? 서버API로 교체


            if (lblInstall.Text.Length != 2)
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



            int order_cnt = SaveOrder();

            Payment mPayment = new Payment();
            mPayment.the_no = mTheNo;
            mPayment.dt = DateTime.Now;
            mPayment.business_dt = mBussinessDate;
            mPayment.tran_type = "A";
            mPayment.pay_class = "0";    // Order 0, charge 1, settlement 2
            mPayment.pos_no = mPosNo;
            mPayment.serial_no = mTheNo.Substring(14, 4);
            mPayment.net_amount = mNetAmount;
            mPayment.amount_cash = 0;
            mPayment.amount_card = mNetAmount;
            mPayment.amount_point = 0;
            mPayment.is_dc = "";       // 할인여부
            mPayment.is_cancel = "";   // 취소여부
            mPayments.Add(mPayment);

            PaymentCard mPaymentCard = new PaymentCard();
            mPaymentCard.the_no = mTheNo;
            mPaymentCard.business_dt = mBussinessDate;
            mPaymentCard.dt = DateTime.Now;
            mPaymentCard.pay_type = "C9";       // 결제구분 : 카드걀제(C1), 임의등록(C9)
            mPaymentCard.tran_type = "A";       // 승인 A 취소 C
            mPaymentCard.amount = mNetAmount;
            mPaymentCard.card_no = lblCardNo.Text;
            mPaymentCard.auth_no = lblAuthNo.Text;
            mPaymentCard.install = lblInstall.Text;
            mPaymentCard.card_name = rbSel.Text;
            mPaymentCard.isu_code = rbSel.Tag.ToString();
            mPaymentCard.acq_code = "";
            mPaymentCard.merchant_no = "";
            mPaymentCard.tid = "";              // tran_serial -> 취소시 tid입력
            mPaymentCard.is_cancel = "";        // 취소여부
            mPaymentCards.Add(mPaymentCard);

            mClearSaleForm();
            SetDisplayAlarm("I", "주문" + order_cnt + "건 카드 임의등록 완료.");

            countup_the_no();

            this.Close();




        }
    }
}
