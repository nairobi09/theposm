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

        int mPaySeq = 1; // 선결제 후Upcount

        public frmPayComplex()
        {
            InitializeComponent();

            initialize_font();
            initial_the();
        }

        void initialize_font()
        {
            lblTitle.Font = font12;
            btnClose.Font = font12;

            lblNetAmount.Font = font12;

            lblT1.Font = font10;
            lblT2.Font = font10;

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

            lblNetAmount.Text = mNetAmount.ToString("N0");

        }

        private void btnKeyInputInstall_Click(object sender, EventArgs e)
        {
            tbReqAmount.Text = int.Parse(mLblKeyDisplay.Text).ToString("N0");
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
            int amount;
            if (int.TryParse(tbReqAmount.Text.Replace(",", ""), out amount))
            {
                Form fPay;
                fPay = new frmPayCash(amount, mPaySeq);

                fPay.Left = this.Location.X;
                fPay.Top = this.Location.Y;

                fPay.Show();

                // 개별결제화면에서 결제성공인 경우
                if (mReturn)
                {
                    mPaySeq++;
                }

                

            }
            else
            {

            }




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

        private void btnRequestSimple_Click(object sender, EventArgs e)
        {

        }
    }
}
