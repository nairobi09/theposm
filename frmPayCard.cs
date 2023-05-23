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

    public struct order
    {
        public String the_no;       // 영수중번호, Unique, reference_no, CUSTNO(4) + POSNO(2) + DateTimeOffset_Milliseconds(13)
        public String custimer_id;  //
        public String pos_no;       //
        public String business_date;// 영업일자
        public DateTime order_dt;   // 주문일시
        public int net_amount;      // 금액
    }

    public struct orderItem
    {
        public String the_no;       // 
        public String code;         // 상품code(6) or 전체할인코드고정("EDC")
        public String name;         // 상품name or 전체할인명("할인")
        public int cnt;
        public int amt;
        public int dc_amount;       // 실할인금액
        public String dcr_type;     // type - "A" : 정액, "R" : 정율 
        //public String dcr_des;      // 전체"E", 선택"S"
        public int dcr_value;       // 할인금액 or 할인율
    }

    public struct payment
    {
        public String the_no;       // 
        public String pay_type;     // 결제구분 : 신용카드(C0), 단순현금(R0), 현금영수중(R1)
        public int amount;          // 결제금액
        public String install;      // 할부개월 00 03
        public String auth_no;      //
        public String tran_date;    //
        public String card_no;      //
        public String card_name;    // 카드종류
        public String merchant_no;  // 가맹점번호
        public String isu_code;     //
        public String acq_code;     //

    }
    /*
    string Respcode = "";
    string Msg = "";
    string Trancode = "";
    string Mid = "";
    string Oid = "";
    string Tamt = "";
    string Tran_serial = "";
    string Trandate = "";
    string Financecode = "";
    string Financename = "";
    string Cardno = "";
    string Halbu = "";
    string Authno = "";
    string Stlinst = "";
    string Reqinst = "";
    string Merno = "";
    string Signpath = "";
    string Cardgubun = "";
    string Giftchange = "";
    */



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




        public frmPayCard()
        {
            InitializeComponent();

            initialize_font();
            initial_the();

        }

        void initialize_font()
        {
            lblTitle.Font = font12bold;

            lblT1.Font = font10;
            lblT2.Font = font10;

            lblNetAmount.Font = font12bold;
            lblInstall.Font = font12bold;

            btnKeyInput.Font = font10;

            btnInstall00.Font = font10;
            btnInstall03.Font = font10;
            btnInstall06.Font = font10;
            btnInstall12.Font = font10;

            btnCardTemp.Font = font10bold;
            btnCardRequest.Font = font10bold;

            btnClose.Font = font12bold;
        }

        private void initial_the()
        {
            lblNetAmount.Text = mNetAmount.ToString("N0");
        }




        private void btnCardRequest_Click(object sender, EventArgs e)
        {


            //int d= mNetAmount;
            int install = int.Parse(lblInstall.Text);

            if (requestCardAuth(mNetAmount, install) != 0)
            {
                display_error_msg(mErrorMsg);
            }
            else
            {
                //정상승인
                // 데이터 저장후 화면 닫기

            }

            

        }


        private int requestCardAuth(int amount, int install)
        {
            int ret = UPay_Init();
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


            string Respcode = "";
            string Msg = "";
            string Trancode = "";
            string Mid = "";
            string Oid = "";
            string Tamt = "";
            string Tran_serial = "";
            string Trandate = "";
            string Financecode = "";
            string Financename = "";
            string Cardno = "";
            string Halbu = "";
            string Authno = "";
            string Stlinst = "";
            string Reqinst = "";
            string Merno = "";
            string Signpath = "";
            string Cardgubun = "";
            string Giftchange = "";

            string display_msg = "";

            string name;
            string value;

            for (int i = 0; i < cnt; i++)
            {
                name = Marshal.PtrToStringAnsi(UPayResName(i));
                value = Marshal.PtrToStringAnsi(UPayResponse(i));

                // 응답메시지 파싱
                if (name == "Respcode") Respcode = value;
                else if (name == "Respcode") Respcode = value;
                else if (name == "Msg") Msg = value;
                else if (name == "Trancode") Trancode = value;
                else if (name == "Mid") Mid = value;
                else if (name == "Oid") Oid = value;
                else if (name == "Tamt") Tamt = value;
                else if (name == "Tran_serial") Tran_serial = value; //최소필요 TID
                else if (name == "Trandate") Trandate = value;       //취소필요 원거래일
                else if (name == "Financecode") Financecode = value; // 카드사코드
                else if (name == "Financename") Financename = value; // 카드명
                else if (name == "Cardno") Cardno = value;
                else if (name == "Halbu") Halbu = value;
                else if (name == "Authno") Authno = value;
                else if (name == "Stlinst") Stlinst = value;
                else if (name == "Reqinst") Reqinst = value;
                else if (name == "Merno") Merno = value;
                else if (name == "Signpath") Signpath = value;
                else if (name == "Cardgubun") Cardgubun = value;
                else if (name == "Giftchange") Giftchange = value;

                display_msg += name + ": " + value + "\n";
            }
            // TossPaymentsPOS_Client 자원반환
            ret = UPayFinal();

            MessageBox.Show(display_msg);

            if (Respcode == "00")
            {
                return 0;
            }
            else
            {
                mErrorMsg = Msg;
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

        private void btnKeyInput_Click(object sender, EventArgs e)
        {
            lblInstall.Text = mLblKeyDisplay.Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSale.ConsoleEnable();
        }


    }
}
