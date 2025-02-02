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
using static thepos.frmFlowSettlement;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace thepos
{
    public partial class frmFlowSettleChargeCancel : Form
    {

        String thisBizDt;
        String ticket_no;

        bool is_apply = false;
        int netAmount = 0;
        int cancelAmount = 0;
        int nestAmount = 0;

        int select_idx;


        public frmFlowSettleChargeCancel(String biz_dt, String ticket_no)
        {
            InitializeComponent();

            initialize_font();
            initial_the();


            this.thisBizDt = biz_dt;
            this.ticket_no = ticket_no;

            viewList();

        }


        private void initialize_font()
        {
            lblTitle.Font = font12;
            btnClose.Font = font12;

            lvwList.Font = font10;

            btnCancel.Font = font10;
        }

        private void initial_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwList.SmallImageList = imgList;
        }



        private void viewList()
        {
            netAmount = 0;
            cancelAmount = 0;
            nestAmount = 0;

            lvwList.Items.Clear();


            //#
            String url = "paymentCash?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&ticketNo=" + ticket_no + "&tranType=A&payClass=CH";
            if (mRequestGet(url))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["paymentCashs"].ToString();
                    add_listview(data);
                }
                else
                {
                    MessageBox.Show("결제 데이터 오류. paymentCash\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. paymentCash\n\n" + mErrorMsg, "thepos");
            }

            //#
            url = "paymentCard?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&ticketNo=" + ticket_no + "&tranType=A&payClass=CH";
            if (mRequestGet(url))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["paymentCards"].ToString();
                    add_listview(data);
                }
                else
                {
                    MessageBox.Show("결제 데이터 오류. paymentCard\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. paymentCard\n\n" + mErrorMsg, "thepos");
            }


            //#
            url = "paymentEasy?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&ticketNo=" + ticket_no + "&tranType=A&payClass=CH";
            if (mRequestGet(url))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["paymentEasys"].ToString();
                    add_listview(data);
                }
                else
                {
                    MessageBox.Show("결제 데이터 오류. paymentEasy\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. paymentEasy\n\n" + mErrorMsg, "thepos");
            }




            // 한건이면 선택한걸로
            if (lvwList.Items.Count == 1)
            {
                lvwList.Items[0].Selected = true;
            }


            //
            void add_listview(String data)
            {
                JArray arr = JArray.Parse(data);

                for (int i = 0; i < arr.Count; i++)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Tag = arr[i]["theNo"].ToString();

                    lvItem.SubItems.Add(get_MMddHHmm(arr[i]["payDate"].ToString(), arr[i]["payTime"].ToString()));
                    lvItem.SubItems.Add(get_pay_type_name(arr[i]["payType"].ToString()));
                    lvItem.SubItems.Add(get_tran_type_name(arr[i]["tranType"].ToString()));

                    if (arr[i]["tranType"].ToString() == "C")
                        lvItem.SubItems.Add("-" + convert_number(arr[i]["amount"].ToString()).ToString("N0"));
                    else
                        lvItem.SubItems.Add(convert_number(arr[i]["amount"].ToString()).ToString("N0"));


                    if (arr[i]["isCancel"].ToString() == "Y" | arr[i]["isCancel"].ToString() == "y")
                        lvItem.SubItems.Add("취소됨");
                    else if (arr[i]["isCancel"].ToString() == "0")
                        lvItem.SubItems.Add("취소중");
                    else
                        lvItem.SubItems.Add("");


                    lvItem.SubItems.Add(arr[i]["theNo"].ToString());
                    lvItem.SubItems.Add(arr[i]["payType"].ToString());
                    lvItem.SubItems.Add(arr[i]["tranType"].ToString());



                    if (arr[i]["payType"].ToString() == "PA" | arr[i]["payType"].ToString() == "PD")
                        lvItem.Text = "1";
                    else
                        lvItem.Text = arr[i]["paySeq"].ToString();



                    if (arr[i]["isCancel"].ToString() == "Y" | arr[i]["isCancel"].ToString() == "y")
                    {
                        lvItem.ForeColor = Color.Gray;
                        lvItem.SubItems[1].ForeColor = Color.Gray;
                        lvItem.SubItems[2].ForeColor = Color.Gray;
                        lvItem.SubItems[3].ForeColor = Color.Gray;
                        lvItem.SubItems[4].ForeColor = Color.Gray;
                        lvItem.SubItems[5].ForeColor = Color.Gray;
                        lvItem.SubItems[6].ForeColor = Color.Gray;
                        lvItem.SubItems[7].ForeColor = Color.Gray;
                        lvItem.SubItems[8].ForeColor = Color.Gray;
                    }

                    lvwList.Items.Add(lvItem);

                }
            }
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFlowSettleChargeCancel_FormClosed(object sender, FormClosedEventArgs e)
        {
            //
            frmFlowSettlement.view_ticket_flow(frmFlowSettlement.mThisBizDt, frmFlowSettlement.mThisPosNo, frmFlowSettlement.mThisTicketNo);


            mPanelCancel.Visible = false;
            mPanelCancel.Controls.Clear();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            String selected_the_no = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(theno)].Text.ToString();
            String pay_type = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(paytype)].Text.ToString();
            int pay_seq = int.Parse(lvwList.SelectedItems[0].Text);


            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(cc)].Text == "Y" | lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(cc)].Text == "취소됨")
            {
                SetDisplayAlarm("W", "기취소건.");
                return;  // 취소건, 취소된 승인건 - 제외
            }


            //
            if (pay_type == "C1" | pay_type == "C0")
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                PaymentCard pCardAuth = new PaymentCard();

                String sUrl = "paymentCard?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&theNo=" + selected_the_no + "&tranType=A&paySeq=" + pay_seq;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCards"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count == 1)
                        {
                            pCardAuth.site_id = arr[0]["siteId"].ToString();
                            pCardAuth.biz_dt = arr[0]["bizDt"].ToString();
                            pCardAuth.pos_no = arr[0]["posNo"].ToString();
                            pCardAuth.the_no = arr[0]["theNo"].ToString();
                            pCardAuth.ref_no = arr[0]["refNo"].ToString();

                            pCardAuth.pay_date = arr[0]["payDate"].ToString();
                            pCardAuth.pay_time = arr[0]["payTime"].ToString();
                            pCardAuth.pay_type = arr[0]["payType"].ToString();
                            pCardAuth.tran_type = arr[0]["tranType"].ToString();
                            pCardAuth.pay_class = arr[0]["payClass"].ToString();

                            pCardAuth.ticket_no = arr[0]["ticketNo"].ToString();
                            pCardAuth.pay_seq = convert_number(arr[0]["paySeq"].ToString());
                            pCardAuth.tran_date = arr[0]["tranDate"].ToString();
                            pCardAuth.amount = convert_number(arr[0]["amount"].ToString());
                            pCardAuth.install = arr[0]["install"].ToString();

                            pCardAuth.auth_no = arr[0]["authNo"].ToString();
                            pCardAuth.card_no = arr[0]["cardNo"].ToString();

                            pCardAuth.card_name = arr[0]["cardName"].ToString();
                            pCardAuth.isu_code = arr[0]["isuCode"].ToString();
                            pCardAuth.acq_code = arr[0]["acqCode"].ToString();
                            pCardAuth.merchant_no = arr[0]["merchantNo"].ToString();
                            pCardAuth.tran_serial = arr[0]["tranSerial"].ToString();

                            pCardAuth.tax_amount = 0;
                            pCardAuth.tfree_amount = 0;
                            pCardAuth.service_amount = 0;
                            pCardAuth.tax = 0;
                        }
                        else
                        {
                            MessageBox.Show("결제자료 오류. paymentCash\n\n", "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("결제자료 오류. payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
                    return;
                }


                if (pCardAuth.pay_type == "C1")  // 카드결제취소
                {
                    //
                    PaymentCard pCardCancel = new PaymentCard();

                    if (requestCardCancel(pCardAuth, out pCardCancel) != 0)  // Toss process
                    {
                        display_error_msg(mErrorMsg);
                    }
                    else
                    {
                        cancel_order_and_payments(pCardAuth.the_no, pCardAuth.amount, pay_seq, pCardAuth.pay_type);


                        parameters["siteId"] = mSiteId;
                        parameters["posNo"] = mPosNo;
                        parameters["bizDt"] = mBizDate;
                        parameters["theNo"] = pCardAuth.the_no;
                        parameters["refNo"] = pCardAuth.ref_no;
                        parameters["payDate"] = get_today_date();
                        parameters["payTime"] = get_today_time();
                        parameters["payType"] = "C1";       // 결제구분 : , 카드승인(C1), 임의등록(C0)
                        parameters["tranType"] = "C";       // 승인 A 취소 C
                        parameters["payClass"] = pCardAuth.pay_class;
                        parameters["ticketNo"] = pCardAuth.ticket_no;
                        parameters["paySeq"] = pCardAuth.pay_seq + "";
                        parameters["tranDate"] = pCardCancel.tran_date;
                        parameters["amount"] = pCardAuth.amount + "";
                        parameters["install"] = pCardAuth.install;
                        parameters["authNo"] = pCardCancel.auth_no;
                        parameters["cardNo"] = pCardCancel.card_no;
                        parameters["cardName"] = pCardCancel.card_name;
                        parameters["isuCode"] = pCardCancel.isu_code;
                        parameters["acqCode"] = pCardCancel.acq_code;
                        parameters["merchantNo"] = pCardCancel.merchant_no;
                        parameters["tranSerial"] = pCardCancel.tran_serial;     // tran_serial -> 취소시 tid입력
                        parameters["signPath"] = "";
                        parameters["giftChange"] = "";
                        parameters["isCancel"] = "y";
                        parameters["vanCode"] = mVanCode;

                        if (mRequestPost("paymentCard", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                                is_apply = true;
                            }
                            else
                            {
                                MessageBox.Show("오류 paymentCard\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("시스템오류 paymentCard\n\n" + mErrorMsg, "thepos");
                            return;
                        }



                        //! 승인건에 취소마킹
                        parameters.Clear();
                        parameters["siteId"] = mSiteId;
                        parameters["bizDt"] = mBizDate;
                        parameters["theNo"] = pCardAuth.the_no;
                        parameters["payType"] = "C1";
                        parameters["tranType"] = "A";
                        parameters["paySeq"] = pCardAuth.pay_seq + "";
                        parameters["isCancel"] = "y";

                        if (mRequestPatch("paymentCard", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                            }
                            else
                            {
                                MessageBox.Show("오류. paymentCash\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("시스템오류. paymentCash\n\n" + mErrorMsg, "thepos");
                            return;
                        }



                        SetDisplayAlarm("I", "카드결제 취소.");
                        //MessageBox.Show("카드결제 취소 성공", "thepos");
                    }
                }
                else if (pCardAuth.pay_type == "C0")  // 임의 등록
                {
                    cancel_order_and_payments(pCardAuth.the_no, pCardAuth.amount, pay_seq, pCardAuth.pay_type);

                    //!
                    parameters["siteId"] = mSiteId;
                    parameters["posNo"] = mPosNo;
                    parameters["bizDt"] = mBizDate;
                    parameters["theNo"] = pCardAuth.the_no;
                    parameters["refNo"] = pCardAuth.ref_no;
                    parameters["payDate"] = get_today_date();
                    parameters["payTime"] = get_today_time();
                    parameters["payType"] = "C0";       // 결제구분 : , 카드승인(C1), 임의등록(C0)
                    parameters["tranType"] = "C";       // 승인 A 취소 C
                    parameters["payClass"] = pCardAuth.pay_class;
                    parameters["ticketNo"] = pCardAuth.ticket_no;
                    parameters["paySeq"] = pCardAuth.pay_seq + "";
                    parameters["tranDate"] = "";
                    parameters["amount"] = pCardAuth.amount + "";
                    parameters["install"] = pCardAuth.install;
                    parameters["authNo"] = pCardAuth.auth_no;
                    parameters["cardNo"] = pCardAuth.card_no;
                    parameters["cardName"] = pCardAuth.card_name;
                    parameters["isuCode"] = pCardAuth.isu_code;
                    parameters["acqCode"] = pCardAuth.acq_code;
                    parameters["merchantNo"] = pCardAuth.merchant_no;
                    parameters["tranSerial"] = pCardAuth.tran_serial;     // tran_serial -> 취소시 tid입력
                    parameters["signPath"] = "";
                    parameters["giftChange"] = "";
                    parameters["isCancel"] = "y";
                    parameters["vanCode"] = "";

                    if (mRequestPost("paymentCard", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                            is_apply = true;
                        }
                        else
                        {
                            MessageBox.Show("오류 paymentCard\n\n" + mObj["resultMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류 paymentCard\n\n" + mErrorMsg, "thepos");
                        return;
                    }


                    //! 승인건에 취소마킹
                    parameters.Clear();
                    parameters["siteId"] = mSiteId;
                    parameters["bizDt"] = mBizDate;
                    parameters["theNo"] = pCardAuth.the_no;
                    parameters["payType"] = "C0";
                    parameters["tranType"] = "A";
                    parameters["paySeq"] = pCardAuth.pay_seq + "";
                    parameters["isCancel"] = "y";

                    if (mRequestPatch("paymentCard", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                        }
                        else
                        {
                            MessageBox.Show("오류. paymentCash\n\n" + mObj["resultMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류. paymentCash\n\n" + mErrorMsg, "thepos");
                        return;
                    }


                    SetDisplayAlarm("I", "카드임의등록 취소.");
                    //MessageBox.Show("카드임의등록 취소 성공", "thepos");
                }


                // 티켓
                settle_charge_TicketFlow(pCardAuth.ticket_no, pCardAuth.amount);


            }
            else if (pay_type == "R0" | pay_type == "R1")
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                PaymentCash pCashAuth = new PaymentCash();

                String sUrl = "paymentCash?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&theNo=" + selected_the_no + "&tranType=A&paySeq=" + pay_seq;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCashs"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count == 1)
                        {
                            pCashAuth.site_id = arr[0]["siteId"].ToString();
                            pCashAuth.pos_no = arr[0]["posNo"].ToString();
                            pCashAuth.biz_dt = arr[0]["bizDt"].ToString();
                            pCashAuth.the_no = arr[0]["theNo"].ToString();
                            pCashAuth.ref_no = arr[0]["refNo"].ToString();
                            pCashAuth.pay_date = arr[0]["payDate"].ToString();
                            pCashAuth.pay_time = arr[0]["payTime"].ToString();
                            pCashAuth.pay_type = arr[0]["payType"].ToString();
                            pCashAuth.tran_type = arr[0]["tranType"].ToString();
                            pCashAuth.pay_class = arr[0]["payClass"].ToString();
                            pCashAuth.ticket_no = arr[0]["ticketNo"].ToString();
                            pCashAuth.pay_seq = convert_number(arr[0]["paySeq"].ToString());
                            pCashAuth.tran_date = arr[0]["tranDate"].ToString();
                            pCashAuth.amount = convert_number(arr[0]["amount"].ToString());
                            pCashAuth.receipt_type = arr[0]["receiptType"].ToString();
                            pCashAuth.issued_method_no = arr[0]["issuedMethodNo"].ToString();
                            pCashAuth.auth_no = arr[0]["authNo"].ToString();
                            pCashAuth.tran_serial = arr[0]["tranSerial"].ToString();
                            pCashAuth.is_cancel = arr[0]["isCancel"].ToString();
                            pCashAuth.van_code = arr[0]["vanCode"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("결제자료 오류. paymentCash\n\n", "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("결제자료 오류. payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
                    return;
                }



                if (pCashAuth.pay_type == "R1")  // 현금영수증 취소
                {

                    //? input_type을 구하는 창이 필요한가?

                    PaymentCash pCashCancel = new PaymentCash();

                    if (requestCashCancel(pCashAuth, out pCashCancel) != 0)  // Toss process
                    {
                        display_error_msg(mErrorMsg);
                    }
                    else
                    {
                        //
                        cancel_order_and_payments(pCashAuth.the_no, pCashAuth.amount, pay_seq, pCashAuth.pay_type);


                        //! 취소건 추가
                        parameters.Clear();
                        parameters["siteId"] = mSiteId;
                        parameters["bizDt"] = mBizDate;
                        parameters["posNo"] = mPosNo;
                        parameters["theNo"] = pCashCancel.the_no;
                        parameters["refNo"] = pCashCancel.ref_no;

                        parameters["payDate"] = get_today_date();
                        parameters["payTime"] = get_today_time();
                        parameters["payType"] = "R1";       // 결제구분
                        parameters["tranType"] = "C";       // 승인 A 취소 C
                        parameters["payClass"] = pCashCancel.pay_class;

                        parameters["ticketNo"] = pCashCancel.ticket_no;
                        parameters["paySeq"] = pCashCancel.pay_seq + "";
                        parameters["tranDate"] = pCashCancel.tran_date;
                        parameters["amount"] = pCashCancel.amount + "";
                        parameters["receiptType"] = pCashCancel.receipt_type + "";

                        parameters["issuedMethodNo"] = pCashCancel.issued_method_no;
                        parameters["authNo"] = pCashCancel.auth_no;
                        parameters["tranSerial"] = pCashCancel.tran_serial;
                        parameters["isCancel"] = "y";
                        parameters["vanCode"] = mVanCode;

                        if (mRequestPost("paymentCash", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                                is_apply = true;
                            }
                            else
                            {
                                MessageBox.Show("오류 paymentCash\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("시스템오류 paymentCash\n\n" + mErrorMsg, "thepos");
                            return;
                        }


                        //! 승인건에 취소마킹
                        parameters.Clear();
                        parameters["siteId"] = mSiteId;
                        parameters["bizDt"] = mBizDate;
                        parameters["theNo"] = selected_the_no;
                        parameters["payType"] = "R1";
                        parameters["tranType"] = "A";
                        parameters["paySeq"] = pCashAuth.pay_seq + "";
                        parameters["isCancel"] = "y";

                        if (mRequestPatch("paymentCash", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {

                            }
                            else
                            {
                                MessageBox.Show("오류. paymentCash\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("시스템오류. paymentCash\n\n" + mErrorMsg, "thepos");
                            return;
                        }

                        SetDisplayAlarm("I", "현금영수증 취소.");
                        //MessageBox.Show("현금영수증 취소 성공", "thepos");


                        // 영수증 출력
                        if (is_last_cancel_in_the_no(selected_the_no))
                        {
                            _print_bill(selected_the_no, "C", "", "10000", true); // cash
                        }

                    }

                }
                else if (pCashAuth.pay_type == "R0")  // 단순현금
                {
                    // 단순현금은 자동취소


                    // 정상 취소용 - 일반취소용과 다름
                    cancel_order_and_payments(pCashAuth.the_no, pCashAuth.amount, pay_seq, pCashAuth.pay_type);

                    // 취소건 추가
                    parameters.Clear();
                    parameters["siteId"] = mSiteId;
                    parameters["bizDt"] = mBizDate;
                    parameters["posNo"] = mPosNo;
                    parameters["theNo"] = pCashAuth.the_no;
                    parameters["refNo"] = pCashAuth.ref_no;

                    parameters["payDate"] = get_today_date();
                    parameters["payTime"] = get_today_time();
                    parameters["payType"] = "R0";       // 결제구분
                    parameters["tranType"] = "C";       // 승인 A 취소 C
                    parameters["payClass"] = pCashAuth.pay_class; ;

                    parameters["ticketNo"] = pCashAuth.ticket_no;
                    parameters["paySeq"] = pCashAuth.pay_seq + "";
                    parameters["tranDate"] = pCashAuth.tran_date;
                    parameters["amount"] = pCashAuth.amount + "";
                    parameters["receiptType"] = pCashAuth.receipt_type + "";

                    parameters["issuedMethodNo"] = pCashAuth.issued_method_no;
                    parameters["authNo"] = pCashAuth.auth_no;
                    parameters["tranSerial"] = pCashAuth.tran_serial;
                    parameters["isCancel"] = "y";
                    parameters["vanCode"] = "";

                    if (mRequestPost("paymentCash", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                            is_apply = true;
                        }
                        else
                        {
                            MessageBox.Show("오류 paymentCash\n\n" + mObj["resultMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류 paymentCash\n\n" + mErrorMsg, "thepos");
                        return;
                    }

                    // 승인건에 취소마킹
                    parameters.Clear();
                    parameters["siteId"] = mSiteId;
                    parameters["bizDt"] = mBizDate;
                    parameters["theNo"] = selected_the_no;
                    parameters["payType"] = "R0";
                    parameters["tranType"] = "A";
                    parameters["paySeq"] = pCashAuth.pay_seq + "";
                    parameters["isCancel"] = "y";

                    if (mRequestPatch("paymentCash", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                        }
                        else
                        {
                            MessageBox.Show("오류. paymentCash\n\n" + mObj["resultMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류. paymentCash\n\n" + mErrorMsg, "thepos");
                        return;
                    }


                    SetDisplayAlarm("I", "단순현금 취소.");
                    //MessageBox.Show("단순현금 취소 성공", "thepos");
                }


                // 티켓
                settle_charge_TicketFlow(pCashAuth.ticket_no, pCashAuth.amount);


            }
            else if (pay_type == "E1")
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                PaymentEasy pEasyAuth = new PaymentEasy();

                String sUrl = "paymentEasy?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&theNo=" + selected_the_no + "&tranType=A&paySeq=" + pay_seq;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentEasys"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count == 1)
                        {
                            pEasyAuth.site_id = arr[0]["siteId"].ToString();
                            pEasyAuth.biz_dt = arr[0]["bizDt"].ToString();
                            pEasyAuth.pos_no = arr[0]["posNo"].ToString();
                            pEasyAuth.the_no = arr[0]["theNo"].ToString();
                            pEasyAuth.ref_no = arr[0]["refNo"].ToString();

                            pEasyAuth.pay_date = arr[0]["payDate"].ToString();
                            pEasyAuth.pay_time = arr[0]["payTime"].ToString();
                            pEasyAuth.pay_type = arr[0]["payType"].ToString();
                            pEasyAuth.tran_type = arr[0]["tranType"].ToString();
                            pEasyAuth.pay_class = arr[0]["payClass"].ToString();

                            pEasyAuth.ticket_no = arr[0]["ticketNo"].ToString();
                            pEasyAuth.pay_seq = convert_number(arr[0]["paySeq"].ToString());
                            pEasyAuth.tran_date = arr[0]["tranDate"].ToString();
                            pEasyAuth.amount = convert_number(arr[0]["amount"].ToString());
                            pEasyAuth.install = arr[0]["install"].ToString();

                            pEasyAuth.auth_no = arr[0]["authNo"].ToString();
                            pEasyAuth.card_no = arr[0]["cardNo"].ToString();

                            pEasyAuth.card_name = arr[0]["cardName"].ToString();
                            pEasyAuth.isu_code = arr[0]["isuCode"].ToString();
                            pEasyAuth.acq_code = arr[0]["acqCode"].ToString();
                            pEasyAuth.merchant_no = arr[0]["merchantNo"].ToString();
                            pEasyAuth.tran_serial = arr[0]["tranSerial"].ToString();

                            pEasyAuth.tax_amount = 0;
                            pEasyAuth.tfree_amount = 0;
                            pEasyAuth.service_amount = 0;
                            pEasyAuth.tax = 0;

                            pEasyAuth.pay_type2 = arr[0]["payType2"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("결제자료 오류. paymentEasy\n\n", "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("결제자료 오류. paymentEasy\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. paymentEasy\n\n" + mErrorMsg, "thepos");
                    return;
                }



                if (pEasyAuth.pay_type == "E1")
                {
                    //
                    PaymentEasy pEasyCancel = new PaymentEasy();

                    if (requestEasyCancel(pEasyAuth, out pEasyCancel) != 0)  // Toss process
                    {
                        display_error_msg(mErrorMsg);
                    }
                    else
                    {
                        cancel_order_and_payments(pEasyAuth.the_no,pEasyAuth.amount, pay_seq, pEasyAuth.pay_type);


                        parameters["siteId"] = mSiteId;
                        parameters["posNo"] = mPosNo;
                        parameters["bizDt"] = mBizDate;
                        parameters["theNo"] = pEasyAuth.the_no;
                        parameters["refNo"] = pEasyAuth.ref_no;
                        parameters["payDate"] = get_today_date();
                        parameters["payTime"] = get_today_time();
                        parameters["payType"] = "E1";       // 결제구분 : , 간편결제(E1)
                        parameters["tranType"] = "C";       // 승인 A 취소 C
                        parameters["payClass"] = pEasyAuth.pay_class;
                        parameters["ticketNo"] = pEasyAuth.ticket_no;
                        parameters["paySeq"] = pEasyAuth.pay_seq + "";
                        parameters["tranDate"] = pEasyCancel.tran_date;
                        parameters["amount"] = pEasyAuth.amount + "";
                        parameters["install"] = pEasyAuth.install;
                        parameters["authNo"] = pEasyCancel.auth_no;
                        parameters["cardNo"] = pEasyCancel.card_no;
                        parameters["cardName"] = pEasyCancel.card_name;
                        parameters["isuCode"] = pEasyCancel.isu_code;
                        parameters["acqCode"] = pEasyCancel.acq_code;
                        parameters["merchantNo"] = pEasyCancel.merchant_no;
                        parameters["tranSerial"] = pEasyCancel.tran_serial;     // tran_serial -> 취소시 tid입력
                        parameters["signPath"] = "";
                        parameters["giftChange"] = "";
                        parameters["isCancel"] = "y";
                        parameters["vanCode"] = mVanCode;
                        parameters["PatTypr2"] = pEasyCancel.pay_type2;

                        if (mRequestPost("paymentEasy", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                                is_apply = true;
                            }
                            else
                            {
                                MessageBox.Show("오류 paymentEasy\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("시스템오류 paymentEasy\n\n" + mErrorMsg, "thepos");
                            return;
                        }


                        //! 승인건에 취소마킹
                        parameters.Clear();
                        parameters["siteId"] = mSiteId;
                        parameters["bizDt"] = mBizDate;
                        parameters["theNo"] = pEasyAuth.the_no;
                        parameters["payType"] = "E1";
                        parameters["tranType"] = "A";
                        parameters["paySeq"] = pEasyAuth.pay_seq + "";
                        parameters["isCancel"] = "y";

                        if (mRequestPatch("paymentEasy", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                            }
                            else
                            {
                                MessageBox.Show("오류. paymentEasy\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("시스템오류. paymentEasy\n\n" + mErrorMsg, "thepos");
                            return;
                        }


                        SetDisplayAlarm("I", "간편결제 취소.");
                        //MessageBox.Show("간편결제 취소 성공", "thepos");
                    }
                }

                // 티켓
                settle_charge_TicketFlow(pEasyAuth.ticket_no, pEasyAuth.amount);

            }


            // 리로드
            viewList();


            // 
            if (is_last_cancel_in_the_no(selected_the_no))
            {
                _print_bill(selected_the_no, "C", "", "11010", true);
            }


        }


        private bool is_last_cancel_in_the_no(String selected_the_no)
        {
            bool is_all_cancel = true;

            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                if (lvwList.Items[i].Tag.ToString() == selected_the_no)
                {
                    if (lvwList.Items[i].SubItems[5].Text == "취소됨")
                    {

                    }
                    else
                    {
                        is_all_cancel = false;
                    }
                }

            }

            return is_all_cancel;
        }




        void cancel_order_and_payments(String the_no, int amount, int pay_seq, String pay_type)
        {
            if (pay_seq == 1)
            {
                if (!cancel_order(the_no))
                {
                    return;
                }

                if (!cancel_order_item(the_no))
                {
                    return;
                }
            }

            if (!cancel_payment(the_no, amount, pay_type))
            {
                return;
            }
        }


        bool cancel_order(String the_no)
        {
            String sUrl = "orders?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&theNo=" + the_no + "&tranType=A";
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orders"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count == 1)
                    {
                        Dictionary<string, string> param = new Dictionary<string, string>();
                        param["siteId"] = mSiteId;
                        param["posNo"] = mPosNo;
                        param["bizDt"] = mBizDate;
                        param["theNo"] = arr[0]["theNo"].ToString();
                        param["refNo"] = arr[0]["refNo"].ToString();
                        param["tranType"] = "C";
                        param["orderDate"] = get_today_date();
                        param["orderTime"] = get_today_time();
                        param["cnt"] = arr[0]["cnt"].ToString();
                        param["isCancel"] = "y";
                        if (mRequestPost("orders", param))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                            }
                            else
                            {
                                MessageBox.Show("오류 orders\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("시스템오류 orders\n\n" + mErrorMsg, "thepos");
                            return false;
                        }

                    }
                    else
                    {
                        MessageBox.Show("오류. orders\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("오류. orders\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orders\n\n" + mErrorMsg, "thepos");
                return false;
            }



            // 주문건 취소 마킹
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["bizDt"] = mBizDate;
            parameters["theNo"] = the_no;
            parameters["tranType"] = "A";
            parameters["isCancel"] = "y";

            if (mRequestPatch("orders", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("오류. orders\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orders\n\n" + mErrorMsg, "thepos");
                return false;
            }
        }


        bool cancel_order_item(String the_no)
        {
            //String sUrl = "orderItem?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&theNo=" + the_no + "&tranType=A";
            String sUrl = "orderItem?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&theNo=" + the_no + "&tranType=A";
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orderItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count == 1)
                    {
                        Dictionary<string, string> param = new Dictionary<string, string>();
                        param["siteId"] = mSiteId;
                        param["posNo"] = mPosNo;
                        param["bizDt"] = mBizDate;
                        param["theNo"] = arr[0]["theNo"].ToString();
                        param["refNo"] = arr[0]["refNo"].ToString();
                        param["tranType"] = "C";
                        param["orderDate"] = get_today_date();
                        param["orderTime"] = get_today_time();

                        param["goodsCode"] = arr[0]["goodsCode"].ToString();
                        param["goodsName"] = arr[0]["goodsName"].ToString();
                        param["cnt"] = arr[0]["cnt"].ToString();
                        param["amt"] = arr[0]["amt"].ToString();
                        param["ticketYn"] = arr[0]["ticketYn"].ToString();
                        param["taxFree"] = arr[0]["taxFree"].ToString();
                        param["dcAmount"] = arr[0]["dcAmount"].ToString();
                        param["dcrType"] = arr[0]["dcrType"].ToString();
                        param["dcrDes"] = arr[0]["dcrDes"].ToString();
                        param["dcrValue"] = arr[0]["dcrValue"].ToString();
                        param["payClass"] = arr[0]["payClass"].ToString();
                        param["ticketNo"] = arr[0]["ticketNo"].ToString();
                        param["isCancel"] = "y";
                        param["shopCode"] = arr[0]["shopCode"].ToString();

                        if (mRequestPost("orderItem", param))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                            }
                            else
                            {
                                MessageBox.Show("오류 orderItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("시스템오류 orderItem\n\n" + mErrorMsg, "thepos");
                            return false;
                        }

                    }
                    else
                    {
                        MessageBox.Show("오류. orderItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("오류. orderItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orderItem\n\n" + mErrorMsg, "thepos");
                return false;
            }



            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Clear();
            parameters["siteId"] = mSiteId;
            parameters["bizDt"] = mBizDate;
            parameters["theNo"] = the_no;
            parameters["tranType"] = "A";
            parameters["isCancel"] = "y";

            if (mRequestPatch("orderItem", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("오류. orderItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orderItem\n\n" + mErrorMsg, "thepos");
                return false;
            }

        }


        bool cancel_payment(String the_no, int amount, String pay_type)
        {
            // 승인건 
            Payment paymentAuth = new Payment();
            if (get_payment(thisBizDt, the_no, "A", out paymentAuth) != 1)
            {
                return false;
            }


            // 취소건
            Payment paymentCancel = new Payment();
            int cnt = get_payment(mBizDate, the_no, "C", out paymentCancel);
            if (cnt == 1)
            {

                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Clear();
                param["siteId"] = mSiteId;
                param["bizDt"] = mBizDate;
                param["theNo"] = the_no;
                param["tranType"] = "C";

                param["netAmount"] = (paymentCancel.net_amount + amount) + "";

                if (pay_type.Substring(0,1) == "R") param["amountCash"] = (paymentCancel.amount_cash + amount) + "";
                else if (pay_type.Substring(0, 1) == "C") param["amountCard"] = (paymentCancel.amount_card + amount) + "";
                else if (pay_type.Substring(0, 1) == "E") param["amountEasy"] = (paymentCancel.amount_easy + amount) + "";

                if (!patch_payment(param))
                {
                    return false;
                }

            }
            else if (cnt == 0)
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param["siteId"] = mSiteId;
                param["posNo"] = mPosNo;
                param["bizDt"] = mBizDate;
                param["theNo"] = paymentAuth.the_no;
                param["refNo"] = paymentAuth.ref_no;
                param["tranType"] = "C";
                param["payDate"] = get_today_date();
                param["payTime"] = get_today_time();
                param["payClass"] = paymentAuth.pay_class;
                param["billNo"] = paymentAuth.bill_no;

                param["netAmount"] = amount + "";

                int amt_cash = 0;
                int amt_card = 0;
                int amt_easy = 0;
                int amt_point = 0;

                if (pay_type.Substring(0, 1) == "R") amt_cash = amount;
                else if (pay_type.Substring(0, 1) == "C") amt_card = amount;
                else if (pay_type.Substring(0, 1) == "E") amt_easy = amount;

                param["amountCash"] = amt_cash + "";
                param["amountCard"] = amt_card + "";
                param["amountEasy"] = amt_easy + "";
                param["amountPoint"] = amt_point + "";

                param["dcAmount"] = paymentAuth.dc_amount + "";
                param["isCancel"] = "y";

                if (!post_payment(param))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }



            // 승인건 취소마킹
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Clear();
            parameters["siteId"] = mSiteId;
            parameters["bizDt"] = thisBizDt;
            parameters["theNo"] = the_no;
            parameters["tranType"] = "A";
            parameters["isCancel"] = "y";

            if (patch_payment(parameters))
            {
                return false;
            }

            return true;

        }



        int get_payment(String biz_dt, String the_no, String tran_type, out Payment payment)
        {
            payment = new Payment();

            String sUrl = "payment?siteId=" + mSiteId + "&bizDt=" + biz_dt + "&theNo=" + the_no + "&tranType=" + tran_type;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["payments"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count == 0)
                    {
                        return 0;
                    }
                    else if (arr.Count == 1)
                    {
                        payment.site_id = arr[0]["siteId"].ToString();
                        payment.biz_dt = arr[0]["bizDt"].ToString();
                        payment.pos_no = arr[0]["posNo"].ToString();
                        payment.the_no = arr[0]["theNo"].ToString();
                        payment.ref_no = arr[0]["refNo"].ToString();
                        payment.pay_date = arr[0]["payDate"].ToString();
                        payment.pay_time = arr[0]["payTime"].ToString();
                        payment.tran_type = arr[0]["tranType"].ToString();
                        payment.pay_class = arr[0]["payClass"].ToString();
                        payment.bill_no = arr[0]["billNo"].ToString();
                        payment.net_amount = convert_number(arr[0]["netAmount"].ToString());
                        payment.amount_cash = convert_number(arr[0]["amountCash"].ToString());
                        payment.amount_card = convert_number(arr[0]["amountCard"].ToString());
                        payment.amount_easy = convert_number(arr[0]["amountEasy"].ToString());
                        payment.amount_point = convert_number(arr[0]["amountPoint"].ToString());
                        payment.dc_amount = convert_number(arr[0]["dcAmount"].ToString());
                        payment.is_cancel = arr[0]["isCancel"].ToString();

                        return 1;
                    }
                    else
                    {
                        MessageBox.Show("오류. payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return arr.Count;
                    }
                }
                else
                {
                    MessageBox.Show("오류. payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return -1;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
                return -1;
            }

        }



        bool post_payment(Dictionary<string, string> parameters)
        {


            if (mRequestPost("payment", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("오류 payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("시스템오류 payment\n\n" + mErrorMsg, "thepos");
                return false;
            }
        }


        bool patch_payment(Dictionary<string, string> parameters)
        {
            //  승인건 -> 취소마킹
            if (mRequestPatch("payment", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("오류. payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
                return false;
            }

        }




        void settle_charge_TicketFlow(String ticket_no, int settle_amount)
        {
            //접수0 - 발급1 - *충전2 - 사용중3 - 정산중4 - 정산완료9

            int usage_amount = 0;
            int settle_usage_amount = 0;

            int charge_amount = 0;
            int settle_charge_amount = 0;
            String flow_step = "";

            String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&ticketNo=" + ticket_no;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["ticketFlows"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count == 1)
                    {
                        usage_amount = convert_number(arr[0]["pointUsage"].ToString());
                        settle_usage_amount = convert_number(arr[0]["settlePointUsage"].ToString());

                        charge_amount = convert_number(arr[0]["pointCharge"].ToString());
                        settle_charge_amount = convert_number(arr[0]["settlePointCharge"].ToString());

                        settle_charge_amount += settle_amount;


                        if (charge_amount == settle_charge_amount & usage_amount == settle_usage_amount)
                        {
                            flow_step = "9";  // 정산완료
                        }
                        else
                        {
                            flow_step = "4";  // 정산중
                        }


                        // 수정
                        Dictionary<string, string> parameters = new Dictionary<string, string>();
                        parameters.Clear();
                        parameters["siteId"] = mSiteId;
                        parameters["bizDt"] = mBizDate;
                        parameters["ticketNo"] = ticket_no;

                        parameters["settlePointCharge"] = settle_charge_amount + "";
                        parameters["flowStep"] = flow_step;

                        if (mRequestPatch("ticketFlow", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                                return;
                            }
                        }
                    }
                }
            }

            MessageBox.Show("티켓데이터 충전취소 오류. ticketFlow", "thepos");
            return;

        }

    }
}
