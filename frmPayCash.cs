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
    public partial class frmPayCash : Form
    {
        //mNetAmount
        Int32 rcvAmount = 0;
        Int32 restAmount = 0;

        bool isReset = true;





        public frmPayCash()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();

            reset_amount();

        }

        private void initialize_font()
        {
            lblTitle.Font = font12;

            lbl1.Font = font10;
            lbl2.Font = font10;
            lbl3.Font = font10;

            lblNetAmount.Font = font10;
            lblRcvAmount.Font = font10;
            lblRestAmount.Font = font10;

            btnCashSimple.Font = font12;

            btnKeyInput.Font = font10;

            btn1t.Font = font10;
            btn5t.Font = font10;
            btn10t.Font = font10;
            btn50t.Font = font10;
            btn100t.Font = font10;
            btnReset.Font = font10;

            lbl4.Font = font10;
            lbl5.Font = font10;
            lbl6.Font = font8;

            lblIssuedMethodNo.Font = font12;

            lbl7.Font = font10;

            cbtypeIndividual.Font = font12;
            cbTypeBusiness.Font = font12;

            lbl8.Font = font10;

            lblAuthNo.Font = font12;

            btmCashSelf.Font = font12;
            btmCashTemp.Font = font12;
            btnCashRecept.Font = font12;


            btnClose.Font = font12;
        }

        private void initialize_the()
        {

        }



        private void btnCashSimple_Click(object sender, EventArgs e)
        {
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
            mPayment.amount_cash = mNetAmount;
            mPayment.amount_card = 0;
            mPayment.amount_point = 0;
            mPayment.is_dc = "";       // 할인여부
            mPayment.is_cancel = "";   // 취소여부
            mPayments.Add(mPayment);

            PaymentCash mPaymentCash = new PaymentCash();
            mPaymentCash.the_no = mTheNo;
            mPaymentCash.business_dt = mBussinessDate;
            mPaymentCash.dt = DateTime.Now;
            mPaymentCash.pay_type = "R0";       // 결제구분 : 단순현금(R0), 현금영수중(R1), 임의등록(R9)
            mPaymentCash.tran_type = "A";       // 승인 A 취소 C
            mPaymentCash.amount = mNetAmount;   // 결제금액
            mPaymentCash.receipt_type = "";     // 현금영수증 : 개인 소득공제 1 사업자 지출증빙 2
            mPaymentCash.cashcard_no = "";      // 현금영수증 고객 식별번호
            mPaymentCash.auth_no = "";          // 승인번호
            mPaymentCash.tid = "";              // tran_serial -> 취소시 tid입력
            mPaymentCash.is_cancel = "";        // 취소여부
            mPaymentCashs.Add(mPaymentCash);

            mClearSaleForm();
            SetDisplayAlarm("I", "주문" + order_cnt + "건 단순현금 결제완료.");

            countup_the_no();

            this.Close();
        }



        private void btnCashRecept_Click(object sender, EventArgs e)
        {

        }







        private void reset_amount()
        {
            rcvAmount = mNetAmount;
            restAmount = 0;

            lblNetAmount.Text = mNetAmount.ToString("N0");
            lblRcvAmount.Text = rcvAmount.ToString("N0");
            lblRestAmount.Text = "0";

            isReset = true;
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            reset_amount();
        }

        private void btn1t_Click(object sender, EventArgs e) { reDisplayAmount(1000); }
        private void btn5t_Click(object sender, EventArgs e) { reDisplayAmount(5000); }
        private void btn10t_Click(object sender, EventArgs e) { reDisplayAmount(10000); }
        private void btn50t_Click(object sender, EventArgs e) { reDisplayAmount(50000); }
        private void btn100t_Click(object sender, EventArgs e) { reDisplayAmount(100000); }

        private void reDisplayAmount(Int32 amount)
        {
            if (isReset)
            {
                isReset = false;
                rcvAmount = 0;
            }

            rcvAmount += amount;

            restAmount = rcvAmount - mNetAmount;
            lblRcvAmount.Text = rcvAmount.ToString("N0");
            lblRestAmount.Text = restAmount.ToString("N0");
        }


        private void cbtypeIndividual_CheckedChanged(object sender, EventArgs e)
        {
            cbTypeBusiness.Checked = !cbtypeIndividual.Checked;
        }

        private void cbTypeBusiness_CheckedChanged(object sender, EventArgs e)
        {
            cbtypeIndividual.Checked = !cbTypeBusiness.Checked;
        }



        private void btnKeyInput_Click(object sender, EventArgs e)
        {
            lblIssuedMethodNo.Text = mLblKeyDisplay.Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayCash_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSale.ConsoleEnable();
        }

    }
}
