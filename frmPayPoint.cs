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
using static thepos.frmSale;
using System.Collections;

namespace thepos
{
    public partial class frmPayPoint : Form
    {

        int netAmount = 0;



        public frmPayPoint()
        {
            InitializeComponent();

            initialize_font();
            initial_the();


            netAmount = mNetAmount;

            lblNetAmount.Text = netAmount.ToString("N0");


        }


        void initialize_font()
        {
            lblTitle.Font = font12;
            btnClose.Font = font12;

            lblNetAmount.Font = font10;

            lblT1.Font = font10;

        }

        private void initial_the()
        {


            mPayClass = "US";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayPoint_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSale.ConsoleEnable();
            mPayClass = "OR"; // 원복: order

        }

        private void btnReader_Click(object sender, EventArgs e)
        {

        }

        private void btnRequestPoint_Click(object sender, EventArgs e)
        {
            String ticketNo = tbTicketNo.Text.ToString();

            if (ticketNo.Length != 21)
            {
                SetDisplayAlarm("W", "티켓번호 오류");
                return;
            }


            mRefNo = ticketNo.Substring(0, 18);


            if (mTicketType == "PA") //  포인트선불
            {
                //? 서버요청으로 대체
                for (int i = 0; i < mTicketFlowList.Count; i++)
                {
                    if (mTicketFlowList[i].ticket_no == ticketNo)
                    {
                        if (mTicketFlowList[i].point_charge < mTicketFlowList[i].point_usage + netAmount)
                        {
                            MessageBox.Show("포인트 잔액 부족.", "thepos");
                            return;
                        }
                    }
                }
            }
            else
            {
                // 후불이면 검증안함.
            }




            //? 서버API로 교체
            int order_cnt = 0;

            int paySeq = 1;


            // 주문 저장 1
            order_cnt = SaveOrder(ticketNo);  // order. orderitem

            SavePayment(paySeq, "Point", netAmount);  // payment - 신규, 수정 포함



            // 결제 항목 저장
            PaymentPoint mPaymentPoint = new PaymentPoint();
            mPaymentPoint.site_id = mSiteId;
            mPaymentPoint.biz_dt = mBizDate;
            mPaymentPoint.pos_no = mPosNo;
            mPaymentPoint.the_no = mTheNo;
            mPaymentPoint.ref_no = mRefNo;

            mPaymentPoint.pay_date = get_today_date();
            mPaymentPoint.pay_time = get_today_time();
            mPaymentPoint.pay_type = mTicketType;       // 결제구분 : 포인트 선불:PA 후불:PD
            mPaymentPoint.tran_type = "A";       // 승인 A 취소 C
            mPaymentPoint.pay_class = mPayClass;
            mPaymentPoint.ticket_no = ticketNo;
            mPaymentPoint.usage_no = get_point_usage_no();               // 포인트는 다른결제(복합결제)와 달리 포인트 사용건의 구분번호
            mPaymentPoint.amount = netAmount;    // 결제금액
            mPaymentPoint.is_cancel = "";        // 취소여부
            mPaymentPoints.Add(mPaymentPoint);


            SetDisplayAlarm("I", "주문" + order_cnt + "건 포인트 결제 등록.");



            // 티켓 저장
            int ticket_cnt = SaveTicket(ticketNo, "");

            if (ticket_cnt > 0)
            {
                SetDisplayAlarm("I", " 포인트 사용등록 완료.");

                //? 
                // 영수증 출력 개발요망
            }


            mClearSaleForm();


            this.Close();

        }


        String get_point_usage_no()
        {
            String str = get_today_time();
            String r_str = "";

            for (int i = str.Length - 1; i >= 0; i--)
            {
                r_str += str.Substring(i, 1);
            }


            Random random = new Random();
            String c_str = random.Next(11, 99) + "";

            return c_str + r_str;

        }


    }
}
