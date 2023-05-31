using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static thepos.theSale;
using static thepos.frmSale;

namespace thepos
{

    public partial class frmPayCard : Form
    {


        RadioButton[] rbCard = new RadioButton[9];




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

            if (requestTossCardAuth(mNetAmount, install) != 0)  // Toss process
            {
                display_error_msg(mErrorMsg);
            }
            else
            {
                //정상승인
                //? 서버API로 교체
                int order_cnt = SaveOrder();  // 주문저장

                SaveTossCardAuth(mTossResponse); // 결제저장


                mClearSaleForm();
                SetDisplayAlarm("I", "주문" + order_cnt + "건 카드 임의등록 완료.");

                countup_the_no();
                this.Close();
            }
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


            CardTemp cardTemp = new CardTemp();
            cardTemp.amount = mNetAmount;
            cardTemp.card_no = lblCardNo.Text;
            cardTemp.auth_no = lblAuthNo.Text;
            cardTemp.install = lblInstall.Text;
            cardTemp.card_name = rbSel.Text;
            cardTemp.isu_code = rbSel.Tag.ToString();


            SaveTossCardTemp(cardTemp); // 임의등록


            mClearSaleForm();
            SetDisplayAlarm("I", "주문" + order_cnt + "건 카드 임의등록 완료.");

            countup_the_no();
            this.Close();
        }


        void display_error_msg(string msg)
        {
            MessageBox.Show(msg, "thepos");
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

    }
}
