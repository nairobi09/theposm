using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.frmSale;

namespace thepos.pay
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
        extern static string UPayResName(int index);

        [DllImport("C:\\TossPGPos\\TossPGPOSClient64.dll", EntryPoint = "UPayResponse", CallingConvention = CallingConvention.StdCall)]
        extern static string UPayResponse(int index);

        [DllImport("C:\\TossPGPos\\TossPGPOSClient64.dll", EntryPoint = "UPayFinal", CallingConvention = CallingConvention.StdCall)]
        extern static int UPayFinal();

        public frmPayCard()
        {
            InitializeComponent();

            initial_the();


        }

        private void initial_the()
        {
            lblNetAmount.Text = mNetAmount.ToString("N0");
        }




        private void btnCardRequest_Click(object sender, EventArgs e)
        {
            int ret = UPay_Init();
            if (ret == -9)
            {
                MessageBox.Show("Toss DLL 초기화 오류");
                return;
            }

            ret = UPay_Set("LGD_TXNAME", "CardAuthOfflinePos");
            ret = UPay_Set("LGD_REQTYPE", "APPR");
            ret = UPay_Set("LGD_MID", "");
            ret = UPay_Set("LGD_OID", "");
            ret = UPay_Set("LGD_AMOUNT", mNetAmount.ToString());
            ret = UPay_Set("LGD_INSTALL", lblInstall.Text);
            ret = UPay_Set("LGD_TAXFREEAMOUNT", "0");
            ret = UPay_Set("LGD_VAT", "0");
            ret = UPay_Set("VAN_SFEEAMOUNT", "0");
            ret = UPay_Set("VAN_TRANTYPE", "S0");








            ret = UPay_TX();

            int cnt = UPayResNameCount();

            string Rname;
            string Rvalue;

            for (int i = 0; i < cnt; i++)
            {
                // 응답 메시지 리턴
                Rname = UPayResName(i);
                Rvalue = UPayResponse(i);

                // 응답메시지 파싱
                if (Rname == "Respcode") { string rRespcode = Rvalue; }

            }
            // TossPaymentsPOS_Client 자원반환
            ret = UPayFinal();

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
