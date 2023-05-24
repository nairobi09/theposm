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
            lblTitle.Font = font12;

            lblT1.Font = font10;
            lblT2.Font = font10;

            lblNetAmount.Font = font12;
            lblInstall.Font = font12;

            btnKeyInput.Font = font10;

            btnInstall00.Font = font10;
            btnInstall03.Font = font10;
            btnInstall06.Font = font10;
            btnInstall12.Font = font10;

            btnCardTemp.Font = font10;
            btnCardRequest.Font = font10;

            btnClose.Font = font12;
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
