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
    public partial class frmPayCancel : Form
    {
        public frmPayCancel(String the_no)
        {
            InitializeComponent();
            initialize_font();
            initial_the();


            String dd = the_no;


        }

        private void initial_the()
        { 

        }

        private void initialize_font()
        {
            lblTitle.Font = font12;
            btnClose.Font = font12;

            lvwPay.Font = font10;

            btnCancel.Font = font10;

        }



        private int get_origin_auth(String the_no)
        {
            for (int i = 0; i < mPaymentCards.Count; i++)
            {
                if (mPaymentCards[i].the_no == the_no)
                {
                    return i;
                }
            }
            return -1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //? 원거래 유형에 따라 취소프로세스가 달라진다. 카드 현금 or 복합결제...
            // 원거래다 이미 취소된 거래인지 선확인
            // 복합결제인 경우 취소가 미완료인지도 확인필요


            String the_no = lvwPay.SelectedItems[0].Tag.ToString();

            int idx = get_origin_auth(the_no);

            if (requestTossCardCancel(mPaymentCards[idx]) != 0)  // Toss process
            {
                display_error_msg(mErrorMsg);
            }
            else
            {
                //정상승인
                //? 서버API로 교체

                //int order_cnt = SaveOrder();  // 주문저장


                SetCancelOrderAndPayment(the_no);  // 주문과 원승인결제 : 취소로 마킹

                SaveTossCardCancel(mPaymentCards[idx], mTossResponse); // 결제저장


                SetDisplayAlarm("I", "카드 취소 완료.");
            }
        }
        void display_error_msg(string msg)
        {
            MessageBox.Show(msg, "thepos");
        }

    }
}
