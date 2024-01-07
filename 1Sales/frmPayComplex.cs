using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;
using static thepos.frmSales;

namespace thepos
{
    public partial class frmPayComplex : Form
    {
        public static int mComplexNetAmount = 0;
        public static int mComplexRcvAmount = 0;
        public static int mComplexNestAmount = 0;

        public static Label mComplexLblNetAmount;
        public static Label mComplexLblRcvAmount;
        public static Label mComplexLblNestAmount;

        public static TextBox mComplexTbReqAmount;

        public static ListView mComplexLvwPay;

        public static int mPaySeq = 1; // 선결제 후Upcount  - 복합결제망 사용하고, 단독결제는 항상 1

        TextBox saveKeyDisplay;
        String saveRightFace;

        public static TextBox mTbReqAmount;

        public static Panel mPanelHigh;

        int selectIdx = -1;

        int t과세금액 = 0;
        int t면세금액 = 0;


        public frmPayComplex(int r과세금액, int r면세금액, int select_index)
        {
            InitializeComponent();

            initialize_font();
            initial_the();

            selectIdx = select_index;


            mComplexNetAmount = mNetAmount;
            mComplexRcvAmount = 0;
            mComplexNestAmount = mNetAmount;

            mComplexLblNetAmount.Text = mComplexNetAmount.ToString("N0");
            mComplexLblRcvAmount.Text = mComplexRcvAmount.ToString("N0");
            mComplexLblNestAmount.Text = mComplexNestAmount.ToString("N0");


            t과세금액 = r과세금액;
            t면세금액 = r면세금액;



            if (mLvwOrderItem.SelectedItems.Count > 0)
            {
                MemOrderItem orderItem = mOrderItemList[0];

                int amt = orderItem.cnt * (orderItem.amt + orderItem.option_amt) - orderItem.dc_amount;

                mTbReqAmount.Text = amt.ToString("N0");
            }

        }

        void initialize_font()
        {
            lblTitle.Font = font12;
            btnClose.Font = font12;


            lblNetAmount.Font = font10;
            lblRcvAmount.Font = font10;
            lblNestAmount.Font = font10;

            lblT1.Font = font10;
            lblT2.Font = font10;
            lblT3.Font = font10;
            lblT4.Font = font10;

            tbReqAmount.Font = font12;

            btnRequestCash.Font = font10;
            btnRequestCard.Font = font10;
            btnRequestEasy.Font = font10;

            mTbReqAmount = tbReqAmount;

            lvwPay.Font = font10;


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

            //
            saveKeyDisplay = mTbKeyDisplayController;
            mTbKeyDisplayController = tbReqAmount;


            //복합결제인 경우 리스트뷰 상품을 클릭하면 클릭된 금액을 복합결제 결제할 금액에 표시한다.
            saveRightFace = mRightFace;
            mRightFace = "PayComplex";


            mPanelHigh = panelHigh;
            mPanelHigh.Width = this.Width;
            mPanelHigh.Height = this.Height;



            if (mTheMode == "Local")
                btnRequestEasy.Enabled = false;
            else
                btnRequestEasy.Enabled = true;


        }



        private void btnRequestCash_Click(object sender, EventArgs e)
        {

            RequestPay("CASH");
        }

        private void btnRequestCard_Click(object sender, EventArgs e)
        {
            RequestPay("CARD");
        }

        private void btnRequestEasy_Click(object sender, EventArgs e)
        {
            RequestPay("EASY");
        }


        private void RequestPay(String pay_type)
        {
            if (mTheMode == "Local")
            {
                if (pay_type == "EASY")
                {
                    SetDisplayAlarm("W", "로컬모드에서 사용불가.");
                    return;
                }
            }



            int reqAmount;

            if (!int.TryParse(tbReqAmount.Text.Replace(",",""), out reqAmount))
            {
                SetDisplayAlarm("W", "결제요청금액 오류.");
                return;
            }

            if (mComplexNestAmount < reqAmount)
            {
                SetDisplayAlarm("W", "결제요청금액 오류.");
                return;
            }

            if (mComplexNestAmount == 0)
            {
                SetDisplayAlarm("W", "결제요청금액이 없습니다..");
                return;
            }




            Boolean is_last = false;
            if (mComplexNestAmount == reqAmount)
            {
                is_last = true;
            }


            int req과세금액 = 0;
            int req면세금액 = 0;




            if (t면세금액 == 0)
            {
                req과세금액 = reqAmount;
                req면세금액 = 0;
            }
            else if (t과세금액 == 0)
            {
                req과세금액 = 0;
                req면세금액 = reqAmount;
            }
            else
            {
                req과세금액 = reqAmount * ((t과세금액 * 1000) / (t과세금액 + t면세금액)) / 1000;
                req면세금액 = reqAmount - req과세금액;
            }




            //#
            Form fForm;
            panelHigh.Controls.Clear();
            panelHigh.Visible = true;

            if (pay_type == "CARD")
                fForm = new frmPayCard(reqAmount, req과세금액, req면세금액, true, mPaySeq, is_last, selectIdx) { TopLevel = false, TopMost = true }; // int amount, bool is_complex, int pay_seq, bool is_last, int select_idx
            else if (pay_type == "CASH")
                fForm = new frmPayCash(reqAmount, req과세금액, req면세금액, true, mPaySeq, is_last, selectIdx) { TopLevel = false, TopMost = true };
            else if (pay_type == "EASY")
                fForm = new frmPayEasy(reqAmount, req과세금액, req면세금액, true, mPaySeq, is_last, selectIdx) { TopLevel = false, TopMost = true };
            else return;

            panelHigh.Controls.Add(fForm);
            fForm.Show();
        }


        private void lvwPay_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvwPay.Columns[e.ColumnIndex].Width;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (mComplexNestAmount == 0) // 복합결제 완료
            {
                mClearSaleForm();
                this.Close();
            }
            else if (mComplexNetAmount == mComplexNestAmount) // 시작전
            {
                //
                ConsoleEnable();
                this.Close();
            }
            else  // 부분결제 진행중
            {
                SetDisplayAlarm("W", "복합결제 진행중에는 화면을 닫을 수 없습니다.");
            }
        }

        private void frmPayComplex_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mPayClass == "ST" | mPayClass == "CH")  // 정산창위에  떠있는 경우.
            {
            }
            else
            {
                //mClearSaleForm();
                //frmSales.ConsoleEnable();
            }


            mTbKeyDisplayController = saveKeyDisplay;
            mRightFace = saveRightFace;

            mPanelPayment.Visible = false;

        }

    }

}
