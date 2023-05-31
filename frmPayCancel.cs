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
using System.Xml.Linq;

namespace thepos
{
    public partial class frmPayCancel : Form
    {
        String the_no;

        public frmPayCancel(String tno)
        {
            InitializeComponent();
            initialize_font();
            initial_the();

            the_no = tno;

            //? 서버API로 전환
            for (int i = 0; i < mPaymentCards.Count; i++)
            {
                if (mPaymentCards[i].the_no == the_no)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Tag = mPaymentCards[i].the_no;
                    lvItem.Text = mPaymentCards[i].pay_seq.ToString();
                    lvItem.SubItems.Add(mPaymentCards[i].dt.ToString("yyyy-MM-dd hh:mm:dd"));
                    lvItem.SubItems.Add(get_pay_type_name(mPaymentCards[i].pay_type));
                    lvItem.SubItems.Add(get_tran_type_name(mPaymentCards[i].tran_type));
                    lvItem.SubItems.Add(mPaymentCards[i].amount.ToString("N0"));
                    lvItem.SubItems.Add(mPaymentCards[i].is_cancel);
                    lvwPay.Items.Add(lvItem);
                }
            }

            for (int i = 0; i < mPaymentCashs.Count; i++)
            {
                if (mPaymentCashs[i].the_no == the_no)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Tag = mPaymentCashs[i].the_no;
                    lvItem.Text = mPaymentCashs[i].pay_seq.ToString();
                    lvItem.SubItems.Add(mPaymentCashs[i].dt.ToString("yyyy-MM-dd hh:mm:dd"));
                    lvItem.SubItems.Add(get_pay_type_name(mPaymentCashs[i].pay_type));
                    lvItem.SubItems.Add(get_tran_type_name(mPaymentCashs[i].tran_type));
                    lvItem.SubItems.Add(mPaymentCashs[i].amount.ToString("N0"));
                    lvItem.SubItems.Add(mPaymentCashs[i].is_cancel);
                    lvwPay.Items.Add(lvItem);
                }
            }
        }

        private String get_pay_type_name(String code)
        {
            String name = "";

            if (code == "C1") name = "카드승인결제";
            else if (code == "C1") name = "카드임의등록";

            else if (code == "R0") name = "단순현금";
            else if (code == "R1") name = "현금영수증";
            else if (code == "R9") name = "임의등록";

            return name;
        }

        private String get_tran_type_name(String code)
        {
            String name = "";
            if (code == "A") name = "승인";
            else if (code == "C") name = "취소";
            return name;
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





        private void btnCancel_Click(object sender, EventArgs e)
        {
            //? 원거래다 이미 취소된 거래인지 선확인
            //? 복합결제인 경우 취소가 미완료인지도 확인필요

            String the_no = lvwPay.SelectedItems[0].Tag.ToString();
            int pay_seq = int.Parse(lvwPay.SelectedItems[0].Text);
            int idx = 0;

            for (int i = 0; i < mPaymentCards.Count; i++)
            {
                if (mPaymentCards[i].the_no == the_no & mPaymentCards[i].pay_seq == pay_seq)
                {
                    idx = i; break;
                }
            }


            if (mPaymentCards[idx].pay_type == "C1")  // 카드결제
            {
                if (requestTossCardCancel(mPaymentCards[idx]) != 0)  // Toss process
                {
                    display_error_msg(mErrorMsg);
                }
                else
                {

                    SetCancelOrderAndPayment(the_no, pay_seq);  // 주문과 원승인결제 : 취소로 마킹

                    SaveTossCardCancel(mPaymentCards[idx], mTossResponse); // 결제저장

                    SetDisplayAlarm("I", "카드 취소 완료.");
                }

            }
            else if (mPaymentCards[idx].pay_type == "C9")  // 임의 등록
            {
                //? 자동취소

                SetDisplayAlarm("I", "임의등록 취소 완료.");
            }


        }
        void display_error_msg(string msg)
        {
            MessageBox.Show(msg, "thepos");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
