using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.theSale;
using static thepos.frmSale;

namespace thepos
{
    public partial class frmPayComplex : Form
    {

        int mPaySeq = 1; // 선결제 후Upcount  - 복합결제망 사용하고, 단독결제는 항상 1

        public static int mComplexNetAmount = 0;
        public static int mComplexRcvAmount = 0;
        public static int mComplexNestAmount = 0;

        public static Label mComplexLblNetAmount;
        public static Label mComplexLblRcvAmount;
        public static Label mComplexLblNestAmount;

        public static TextBox mComplexTbReqAmount;

        public static ListView mComplexLvwPay;


        public frmPayComplex()
        {
            InitializeComponent();

            initialize_font();
            initial_the();


            mComplexNetAmount = mNetAmount;
            mComplexRcvAmount = 0;
            mComplexNestAmount = mNetAmount;

            mComplexLblNetAmount.Text = mComplexNetAmount.ToString("N0");
            mComplexLblRcvAmount.Text = mComplexRcvAmount.ToString("N0");
            mComplexLblNestAmount.Text = mComplexNestAmount.ToString("N0");

        }

        void initialize_font()
        {
            lblTitle.Font = font12;
            btnClose.Font = font12;

            lblNetAmount.Font = font12;

            lblT1.Font = font10;
            lblT4.Font = font10;

            tbReqAmount.Font = font12;
            btnKeyInput.Font = font10;

            btnRequestCash.Font = font12;
            btnRequestCard.Font = font12;

        }

        private void initial_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwPay.SmallImageList = imgList;

            mComplexLblNetAmount = lblNetAmount;
            mComplexLblRcvAmount = lblRcvAmount;
            mComplexLblNestAmount = lblNestAmount;

            mComplexTbReqAmount = tbReqAmount;

            mComplexLvwPay = lvwPay;
        }

        private void btnKeyInputInstall_Click(object sender, EventArgs e)
        {
            tbReqAmount.Text = int.Parse(mLblKeyDisplay.Text).ToString("N0");
            tbReqAmount.Tag = mLblKeyDisplay.Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayComplex_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSale.ConsoleEnable();
        }

        private void btnRequestCash_Click(object sender, EventArgs e)
        {

            int reqAmount;

            if (!int.TryParse(tbReqAmount.Tag.ToString(), out reqAmount))
            {
                SetDisplayAlarm("W", "결제요청금액 오류.");
                return;
            }


            if (mComplexNestAmount < reqAmount)
            {
                SetDisplayAlarm("W", "결제요청금액 오류.");
                return;
            }

            Boolean is_last = false;
            if (mComplexNestAmount == reqAmount)
            {
                is_last = true;
            }


            Form fPay;
            fPay = new frmPayCash(reqAmount, true, mPaySeq, is_last); // int amount, bool is_complex, int pay_seq, bool is_last

            fPay.Left = this.Location.X;
            fPay.Top = this.Location.Y;

            fPay.Show();

        }

        private void btnRequestCard_Click(object sender, EventArgs e)
        {
            int amount;
            if (int.TryParse(tbReqAmount.Text.Replace(",", ""), out amount))
            {
                Form fPay;
                fPay = new frmPayCard();

                fPay.Left = this.Location.X;
                fPay.Top = this.Location.Y;

                fPay.ShowDialog();
            }
            else
            {

            }


        }

        private void btnRequestEasy_Click(object sender, EventArgs e)
        {

        }
    }
}
