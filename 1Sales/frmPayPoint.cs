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
using System.Collections;
using Newtonsoft.Json.Linq;

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
            lblTitle.Font = font10;
            btnClose.Font = font10;


            lblNetAmountTitle.Font = font10;
            lblNetAmount.Font = font10;


            lblTicketNoTitle.Font = font10;
            tbTicketNo.Font = font10;

            btnRequestAuth.Font = font10;

            btnClose.Font = font12;

        }

        private void initial_the()
        {
            mPayClass = "US";       // 포인트사용은 주문만 가능하지만, 결국 정산에서 주문으로 다시 결제하게됨.

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayPoint_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSales.ConsoleEnable();
            mPayClass = "OR"; // 원복: order
            mPanelPayment.Visible = false;
        }


        private void btnRequestPoint_Click(object sender, EventArgs e)
        {
            String ticketNo = tbTicketNo.Text.ToString();

            if (ticketNo.Length != 22)
            {
                SetDisplayAlarm("W", "티켓번호 오류");
                return;
            }



            // (충전금액 사용금액 비교) 충전금액 - 사용금액 => 사용가능금액
            String sUrl = "ticketFlow?siteId=" + mSiteId + "&ticketNo=" + ticketNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["ticketFlows"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count == 1)
                    {
                        int charge = convert_number(arr[0]["pointCharge"].ToString());
                        int usage = convert_number( arr[0]["pointUsage"].ToString());
                        int flowstep = convert_number(arr[0]["flowStep"].ToString());


                        if (flowstep > 3)  // 4:정산중, 9:정산완료
                        {
                            MessageBox.Show("정산이후 포인트사용 불가.", "thepos");
                            return;
                        }


                        //  선불 경우만 검증함
                        if (mTicketType == "PA") 
                        {
                            if (charge < usage + netAmount)
                            {
                                MessageBox.Show("포인트 잔액 부족.", "thepos");
                                return;
                            }
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("티켓정보 오류. ticketFlow", "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("티켓데이터 오류.\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. ticketFlow\n\n" + mErrorMsg, "thepos");
                return;
            }




            // 
            mRefNo = ticketNo.Substring(0, 20);

            int dcAmount = 0;
            int order_cnt = 0;
            int paySeq = 1;


            // 리스트뷰 -> 메모리배열 생성 : [ 업장코드로 정렬 + 업장주문번호 부여 ]
            //MemOrderItem[] memOrderItemArr = getMemOrderItemArr(out dcAmount);

            set_shop_order_no_on_orderitem(out dcAmount);


            // 주문 저장 1
            order_cnt = SaveOrder(ticketNo);  // order. orderitem  ->  업장주문서 출력은 제외
            if (order_cnt == -1)
            {
                return; // 재로그인 요구
            }


            //  payment
            if (!SavePayment(paySeq, "Point", netAmount, dcAmount))
            {
                return;
            }



            PaymentPoint paymentPoint = new PaymentPoint();

            paymentPoint.site_id = mSiteId;
            paymentPoint.biz_dt = mBizDate;
            paymentPoint.pos_no = mPosNo;
            paymentPoint.the_no = mTheNo;
            paymentPoint.ref_no = ticketNo.Substring(0, 20);

            paymentPoint.pay_date = get_today_date();
            paymentPoint.pay_time = get_today_time();
            paymentPoint.pay_type = mTicketType;        // 선불 후불
            paymentPoint.tran_type = "A";               // 승인 A 취소 C
            paymentPoint.pay_class = mPayClass;
            paymentPoint.ticket_no = ticketNo;
            paymentPoint.usage_no = "";
            paymentPoint.amount = netAmount;
            paymentPoint.is_cancel = "";                // 취소여부

            SavePaymentPoint(paymentPoint);


            SetDisplayAlarm("I", "주문" + order_cnt + "건 포인트 결제 등록.");


            // 티켓 저장
            int ticket_cnt = SaveTicketFlow(ticketNo, mPayClass, "", 0);

            if (ticket_cnt > 0)
            {
                SetDisplayAlarm("I", " 포인트 사용등록 완료.");
            }


            // 주문서 출력
            print_order();



            // 영수증 출력
            // 안에서 여부를 물어보고 출력한다. 
            print_bill(mTheNo, "A", "", "0010", true); // cash card point easy



            mClearSaleForm();

            this.Close();
        }



        private bool SavePaymentPoint(PaymentPoint mPaymentPoint)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Clear();
            parameters["siteId"] = mPaymentPoint.site_id;
            parameters["posNo"] = mPaymentPoint.pos_no;
            parameters["bizDt"] = mPaymentPoint.biz_dt;
            parameters["theNo"] = mPaymentPoint.the_no;
            parameters["refNo"] = mPaymentPoint.ref_no;

            parameters["payDate"] = mPaymentPoint.pay_date;
            parameters["payTime"] = mPaymentPoint.pay_time;
            parameters["payType"] = mPaymentPoint.pay_type;
            parameters["tranType"] = mPaymentPoint.tran_type;
            parameters["payClass"] = mPaymentPoint.pay_class;

            parameters["ticketNo"] = mPaymentPoint.ticket_no;
            parameters["usage_no"] = mPaymentPoint.usage_no;
            parameters["amount"] = mPaymentPoint.amount + "";
            parameters["isCancel"] = mPaymentPoint.is_cancel;

            if (mRequestPost("paymentPoint", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {

                }
                else
                {
                    MessageBox.Show("오류 paymentPoint\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("시스템오류 paymentPointd\n\n" + mErrorMsg, "thepos");
                return false;
            }

            return true;

        }

    }
}
