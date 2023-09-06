using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static thepos.thePos;
using static thepos.frmSales;
using static thepos.paymentToss;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace thepos
{
    public partial class frmPayCancel : Form
    {
        String theNo;
        String ticketNo;

        int netAmount = 0;
        int cancelAmount = 0;
        int nestAmount = 0;

        public frmPayCancel(String the_no, String ticket_no)
        {
            InitializeComponent();
            initialize_font();
            initial_the();

            theNo = the_no;
            ticketNo = ticket_no;

            viewPayList();
        }

        private void viewPayList()
        {
            netAmount = 0;
            cancelAmount = 0;
            nestAmount = 0;
            lvwPay.Items.Clear();

            //!
            //String sUrl = "paymentCard?theNo=" + theNo + "&tranType=A";
            String sUrl = "paymentCard?theNo=" + theNo;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["paymentCards"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Tag = arr[i]["theNo"].ToString();
                        lvItem.Text = arr[i]["paySeq"].ToString();
                        lvItem.SubItems.Add(get_MMddHHmm(arr[i]["payDate"].ToString(), arr[i]["payTime"].ToString()));
                        lvItem.SubItems.Add(get_pay_type_name(arr[i]["payType"].ToString()));
                        lvItem.SubItems.Add(get_tran_type_name(arr[i]["tranType"].ToString()));

                        if (arr[i]["tranType"].ToString() == "C")
                            lvItem.SubItems.Add("-" + convert_number(arr[i]["amount"].ToString()).ToString("N0"));
                        else
                            lvItem.SubItems.Add(convert_number(arr[i]["amount"].ToString()).ToString("N0"));

                        if (arr[i]["isCancel"].ToString() == "Y")
                            lvItem.SubItems.Add("취소됨");
                        else if (arr[i]["isCancel"].ToString() == "0")
                            lvItem.SubItems.Add("취소중");
                        else
                            lvItem.SubItems.Add("");

                        lvItem.SubItems.Add(arr[i]["theNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["payType"].ToString());
                        lvItem.SubItems.Add(arr[i]["tranType"].ToString());

                        if (arr[i]["isCancel"].ToString() == "Y")
                        {
                            lvItem.ForeColor = Color.Silver;
                            lvItem.SubItems[1].ForeColor = Color.Silver;
                            lvItem.SubItems[2].ForeColor = Color.Silver;
                            lvItem.SubItems[3].ForeColor = Color.Silver;
                            lvItem.SubItems[4].ForeColor = Color.Silver;
                            lvItem.SubItems[5].ForeColor = Color.Silver;
                            lvItem.SubItems[6].ForeColor = Color.Silver;
                            lvItem.SubItems[7].ForeColor = Color.Silver;
                            lvItem.SubItems[8].ForeColor = Color.Silver;
                        }

                        lvwPay.Items.Add(lvItem);

                        if (arr[i]["tranType"].ToString() == "A") { netAmount += convert_number(arr[i]["amount"].ToString()); }

                        if (arr[i]["tranType"].ToString() == "C") { cancelAmount += convert_number(arr[i]["amount"].ToString()); }
                    }
                }
                else
                {
                    MessageBox.Show("결제 데이터 오류. paymentCashs\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. paymentCashs\n\n" + mErrorMsg, "thepos");
            }



            //!
            //sUrl = "paymentCash?theNo=" + theNo + "&tranType=A";
            sUrl = "paymentCash?theNo=" + theNo;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["paymentCashs"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    { 
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Tag = arr[i]["theNo"].ToString();
                        lvItem.Text = arr[i]["paySeq"].ToString();
                        lvItem.SubItems.Add(get_MMddHHmm(arr[i]["payDate"].ToString(), arr[i]["payTime"].ToString()));
                        lvItem.SubItems.Add(get_pay_type_name(arr[i]["payType"].ToString()));
                        lvItem.SubItems.Add(get_tran_type_name(arr[i]["tranType"].ToString()));

                        if (arr[i]["tranType"].ToString() == "C")
                            lvItem.SubItems.Add("-" + convert_number(arr[i]["amount"].ToString()).ToString("N0"));
                        else
                            lvItem.SubItems.Add(convert_number(arr[i]["amount"].ToString()).ToString("N0"));

                        
                        if (arr[i]["isCancel"].ToString() == "Y")
                            lvItem.SubItems.Add("취소됨");
                        else if (arr[i]["isCancel"].ToString() == "0")
                            lvItem.SubItems.Add("취소중");
                        else 
                            lvItem.SubItems.Add("");


                        lvItem.SubItems.Add(arr[i]["theNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["payType"].ToString());
                        lvItem.SubItems.Add(arr[i]["tranType"].ToString());

                        if (arr[i]["isCancel"].ToString() == "Y")
                        {
                            lvItem.ForeColor = Color.Silver;
                            lvItem.SubItems[1].ForeColor = Color.Silver;
                            lvItem.SubItems[2].ForeColor = Color.Silver;
                            lvItem.SubItems[3].ForeColor = Color.Silver;
                            lvItem.SubItems[4].ForeColor = Color.Silver;
                            lvItem.SubItems[5].ForeColor = Color.Silver;
                            lvItem.SubItems[6].ForeColor = Color.Silver;
                            lvItem.SubItems[7].ForeColor = Color.Silver;
                            lvItem.SubItems[8].ForeColor = Color.Silver;
                        }

                        lvwPay.Items.Add(lvItem);

                        if (arr[i]["tranType"].ToString() == "A") { netAmount += convert_number(arr[i]["amount"].ToString()); }

                        if (arr[i]["tranType"].ToString() == "C") { cancelAmount += convert_number(arr[i]["amount"].ToString()); }
                    }
                }
                else
                {
                    MessageBox.Show("결제 데이터 오류. paymentCashs\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. paymentCashs\n\n" + mErrorMsg, "thepos");
            }





            //?
            for (int i = 0; i < mPaymentPoints.Count; i++)
            {
                if (mPaymentPoints[i].the_no == theNo)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Tag = mPaymentPoints[i].the_no;
                    lvItem.Text = "1";
                    lvItem.SubItems.Add(get_MMddHHmm(mPaymentPoints[i].pay_date, mPaymentPoints[i].pay_time));
                    lvItem.SubItems.Add(get_pay_type_name(mPaymentPoints[i].pay_type));
                    lvItem.SubItems.Add(get_tran_type_name(mPaymentPoints[i].tran_type));

                    if (mPaymentPoints[i].tran_type == "C")
                        lvItem.SubItems.Add((-mPaymentPoints[i].amount).ToString("N0"));
                    else
                        lvItem.SubItems.Add(mPaymentPoints[i].amount.ToString("N0"));


                    lvItem.SubItems.Add(mPaymentPoints[i].is_cancel);
                    lvItem.SubItems.Add(mPaymentPoints[i].the_no);
                    lvItem.SubItems.Add(mPaymentPoints[i].pay_type);
                    lvItem.SubItems.Add(mPaymentPoints[i].tran_type);
                    lvwPay.Items.Add(lvItem);

                    if (mPaymentPoints[i].tran_type == "A") { netAmount += mPaymentPoints[i].amount; }

                    if (mPaymentPoints[i].tran_type == "C") { cancelAmount += mPaymentPoints[i].amount; }

                }
            }

            nestAmount = netAmount - cancelAmount;

            lblNetAmount.Text = netAmount.ToString("N0");
            lblCancelAmount.Text = cancelAmount.ToString("N0");
            lblNestAmount.Text = nestAmount.ToString("N0");
        }

        private void initialize_font()
        {
            lblTitle.Font = font12;
            btnClose.Font = font12;

            lblT1.Font = font10;
            lblT2.Font = font10;
            lblT3.Font = font10;

            lblNetAmount.Font = font10;
            lblCancelAmount.Font = font10;
            lblNestAmount.Font = font10;

            lvwPay.Font = font10;

            btnCancel.Font = font10;
        }

        private void initial_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwPay.SmallImageList = imgList;

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwPay.SelectedItems.Count == 0) { return; }

            String the_no = lvwPay.SelectedItems[0].SubItems[6].Text.ToString();
            String pay_type = lvwPay.SelectedItems[0].SubItems[7].Text.ToString();
            int pay_seq = int.Parse(lvwPay.SelectedItems[0].Text);
            int idx = 0;



            //if (lvwPay.SelectedItems[0].SubItems[8].Text == "C") return;  // 취소건 제외

            if (lvwPay.SelectedItems[0].SubItems[5].Text == "Y" | lvwPay.SelectedItems[0].SubItems[5].Text == "취소됨")
            {
                SetDisplayAlarm("W", "취소된 승인 or 취소건.");
                return;  // 취소건, 취소된 승인건 - 제외
            }


            if (pay_type == "C1" | pay_type == "C9")
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                PaymentCard pCardAuth = new PaymentCard();

                String sUrl = "paymentCard?siteId=" + mSiteId + "&theNo=" + theNo + "&tranType=A&paySeq=" + pay_seq;
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
                        MessageBox.Show("결제자료 오류. payment\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
                    return;
                }




                //
                if (pCardAuth.pay_type == "C1")  // 카드결제취소
                {
                    //?
                    PaymentCard pCardCancel = new PaymentCard();

                    if (requestCardCancel(pCardAuth, out pCardCancel) != 0)  // Toss process
                    {
                        display_error_msg(mErrorMsg);
                    }
                    else
                    {
                        //
                        cancel_order_and_payments(pCardAuth.amount);


                        //!
                        parameters["siteId"] = mSiteId;
                        parameters["posNo"] = mPosNo;
                        parameters["bizDt"] = mBizDate;
                        parameters["theNo"] = pCardAuth.the_no;
                        parameters["refNo"] = pCardAuth.ref_no;
                        parameters["payDate"] = get_today_date();
                        parameters["payTime"] = get_today_time();
                        parameters["payType"] = "C1";       // 결제구분 : , 카드승인(C1), 임의등록(C9)
                        parameters["tranType"] = "C";       // 승인 A 취소 C
                        parameters["payClass"] = mPayClass;
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
                        parameters["isCancel"] = "Y";
                        parameters["vanCode"] = mVanCode;

                        if (mRequestPost("paymentCard", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                            }
                            else
                            {
                                MessageBox.Show("오류 paymentCard\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
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
                        parameters["theNo"] = pCardAuth.the_no;
                        parameters["payType"] = "C1";
                        parameters["tranType"] = "A";
                        parameters["paySeq"] = pCardAuth.pay_seq + "";
                        parameters["isCancel"] = "Y";

                        if (mRequestPatch("paymentCard", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                            }
                            else
                            {
                                MessageBox.Show("오류. paymentCash\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("시스템오류. paymentCash\n\n" + mErrorMsg, "thepos");
                            return;
                        }



                        SetDisplayAlarm("I", "카드결제 취소.");
                        MessageBox.Show("카드결제 취소 성공", "thepos");
                    }
                }
                else if (pCardAuth.pay_type == "C9")  // 임의 등록
                {
                    cancel_order_and_payments(pCardAuth.amount);


                    //!
                    parameters["siteId"] = mSiteId;
                    parameters["posNo"] = mPosNo;
                    parameters["bizDt"] = mBizDate;
                    parameters["theNo"] = pCardAuth.the_no;
                    parameters["refNo"] = pCardAuth.ref_no;
                    parameters["payDate"] = get_today_date();
                    parameters["payTime"] = get_today_time();
                    parameters["payType"] = "C9";       // 결제구분 : , 카드승인(C1), 임의등록(C9)
                    parameters["tranType"] = "C";       // 승인 A 취소 C
                    parameters["payClass"] = mPayClass;
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
                    parameters["isCancel"] = "Y";
                    parameters["vanCode"] = mVanCode;

                    if (mRequestPost("paymentCard", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                        }
                        else
                        {
                            MessageBox.Show("오류 paymentCard\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
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
                    parameters["theNo"] = pCardAuth.the_no;
                    parameters["payType"] = "C9";
                    parameters["tranType"] = "A";
                    parameters["paySeq"] = pCardAuth.pay_seq + "";
                    parameters["isCancel"] = "Y";

                    if (mRequestPatch("paymentCard", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                        }
                        else
                        {
                            MessageBox.Show("오류. paymentCash\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류. paymentCash\n\n" + mErrorMsg, "thepos");
                        return;
                    }


                    SetDisplayAlarm("I", "카드임의등록 취소.");
                    MessageBox.Show("카드임의등록 취소 성공", "thepos");
                }
            }
            else if (pay_type == "R0" | pay_type == "R1")
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                PaymentCash pCashAuth = new PaymentCash();

                String sUrl = "paymentCash?siteId=" + mSiteId + "&theNo=" + theNo + "&tranType=A&paySeq=" + pay_seq;
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
                        MessageBox.Show("결제자료 오류. payment\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
                    return;
                }



                //
                if (pCashAuth.pay_type == "R1")  // 현금영수증 취소
                {
                    PaymentCash pCashCancel = new PaymentCash();

                    //? input_type을 구하는 창이 필요한가?



                    if (requestCashCancel(pCashAuth, out pCashCancel) != 0)  // Toss process
                    {
                        display_error_msg(mErrorMsg);
                    }
                    else
                    {
                        //
                        cancel_order_and_payments(pCashAuth.amount);


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
                        parameters["payClass"] = mPayClass;

                        parameters["ticketNo"] = pCashCancel.ticket_no;
                        parameters["paySeq"] = pCashCancel.pay_seq + "";
                        parameters["tranDate"] = pCashCancel.tran_date;
                        parameters["amount"] = pCashCancel.amount + "";
                        parameters["receiptType"] = pCashCancel.receipt_type + "";

                        parameters["issuedMethodNo"] = pCashCancel.issued_method_no;
                        parameters["authNo"] = pCashCancel.auth_no;
                        parameters["tranSerial"] = pCashCancel.tran_serial;
                        parameters["isCancel"] = "Y";
                        parameters["vanCode"] = mVanCode;

                        if (mRequestPost("paymentCash", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                            }
                            else
                            {
                                MessageBox.Show("오류 paymentCash\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
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
                        parameters["theNo"] = theNo;
                        parameters["payType"] = "R1";
                        parameters["tranType"] = "A";
                        parameters["paySeq"] = pCashAuth.pay_seq + "";
                        parameters["isCancel"] = "Y";

                        if (mRequestPatch("paymentCash", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                            }
                            else
                            {
                                MessageBox.Show("오류. paymentCash\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("시스템오류. paymentCash\n\n" + mErrorMsg, "thepos");
                            return;
                        }

                        SetDisplayAlarm("I", "현금영수증 취소.");
                        MessageBox.Show("현금영수증 취소 성공", "thepos");
                    }
                }
                else if (pCashAuth.pay_type == "R0")  // 단순현금
                {
                    // 단순현금은 자동취소

                    cancel_order_and_payments(pCashAuth.amount);

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
                    parameters["payClass"] = mPayClass;

                    parameters["ticketNo"] = pCashAuth.ticket_no;
                    parameters["paySeq"] = pCashAuth.pay_seq + "";
                    parameters["tranDate"] = pCashAuth.tran_date;
                    parameters["amount"] = pCashAuth.amount + "";
                    parameters["receiptType"] = pCashAuth.receipt_type + "";

                    parameters["issuedMethodNo"] = pCashAuth.issued_method_no;
                    parameters["authNo"] = pCashAuth.auth_no;
                    parameters["tranSerial"] = pCashAuth.tran_serial;
                    parameters["isCancel"] = "Y";
                    parameters["vanCode"] = mVanCode;

                    if (mRequestPost("paymentCash", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                        }
                        else
                        {
                            MessageBox.Show("오류 paymentCash\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
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
                    parameters["theNo"] = theNo;
                    parameters["payType"] = "R0";
                    parameters["tranType"] = "A";
                    parameters["paySeq"] = pCashAuth.pay_seq + "";
                    parameters["isCancel"] = "Y";

                    if (mRequestPatch("paymentCash", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                        }
                        else
                        {
                            MessageBox.Show("오류. paymentCash\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류. paymentCash\n\n" + mErrorMsg, "thepos");
                        return;
                    }


                    SetDisplayAlarm("I", "단순현금 취소.");
                    MessageBox.Show("단순현금 취소 성공", "thepos");
                }
            }
            else if (pay_type == "PA" | pay_type == "PD")
            {

                for (int i = 0; i < mPaymentPoints.Count; i++)
                {
                    if (mPaymentPoints[i].the_no == the_no)
                    {
                        idx = i; break;
                    }
                }

 

                //? 자동취소
                cancel_order_and_payments(mPaymentPoints[idx].amount);

                //
                PaymentPoint paymentPoint = new PaymentPoint();
                paymentPoint.site_id = mSiteId;
                paymentPoint.biz_dt = mBizDate;
                paymentPoint.pos_no = mPosNo;
                paymentPoint.the_no = mPaymentPoints[idx].the_no;
                paymentPoint.ref_no = mPaymentPoints[idx].ref_no;

                paymentPoint.pay_date = get_today_date();
                paymentPoint.pay_time = get_today_time();
                paymentPoint.pay_type = mPaymentPoints[idx].pay_type;       // 결제구분
                paymentPoint.tran_type = "C";       // 승인 A 취소 C
                paymentPoint.pay_class = mPayClass;
                paymentPoint.ticket_no = mPaymentPoints[idx].ticket_no;
                paymentPoint.usage_no = mPaymentPoints[idx].usage_no;
                paymentPoint.amount = mPaymentPoints[idx].amount;
                paymentPoint.is_cancel = "Y";        // 취소여부
                mPaymentPoints.Add(paymentPoint);


                // 승인건에 취소마킹
                PaymentPoint pc = new PaymentPoint();
                pc = mPaymentPoints[idx];
                pc.is_cancel = "Y";
                mPaymentPoints[idx] = pc;




                //
                for (int i = 0; i < mTicketFlowList.Count; i++)
                {
                    if (mTicketFlowList[i].ticket_no == mPaymentPoints[idx].ticket_no)
                    {
                        TicketFlow ticketFlow = new TicketFlow();
                        ticketFlow = mTicketFlowList[i];
                        ticketFlow.point_usage -= mPaymentPoints[idx].amount;

                        mTicketFlowList[i] = ticketFlow;
                    }
                }


                SetDisplayAlarm("I", "포인트 취소.");
                MessageBox.Show("포인트 취소 성공", "thepos");

            }


            if (mPayClass == "ST")
            {
                SaveTicket(ticketNo, "CH");  // CH 충전

            }



            // 다시 불러오기
            viewPayList();

        }

        void cancel_order_and_payments(int amount)
        {
            // 주문건 취소 세트
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["theNo"] = theNo;
            parameters["isCancel"] = "Y";

            if (mRequestPatch("orders", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    
                }
                else
                {
                    MessageBox.Show("오류. orders\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orders\n\n" + mErrorMsg, "thepos");
                return;
            }

            //
            parameters.Clear();
            parameters["siteId"] = mSiteId;
            parameters["theNo"] = theNo;
            parameters["isCancel"] = "Y";

            if (mRequestPatch("orderItem", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {

                }
                else
                {
                    MessageBox.Show("오류. orderItem\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orderItem\n\n" + mErrorMsg, "thepos");
                return;
            }




            // payment
            // 1. 승인건 -> 취소마킹
            parameters.Clear();
            parameters["siteId"] = mSiteId;
            parameters["theNo"] = theNo;
            parameters["tranType"] = "A";

            if (netAmount == cancelAmount + amount) 
                parameters["isCancel"] = "Y";
            else 
                parameters["isCancel"] = "0";

            if (mRequestPatch("payment", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                }
                else
                {
                    MessageBox.Show("오류. payment\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
                return;
            }


            // 2. 승인건 불러와서 취소건 추가.
            if (cancelAmount == 0)  //최초
            {
                String sUrl = "payment?siteId=" + mSiteId + "&theNo=" + theNo + "&tranType=A";

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["payments"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count == 1)
                        {
                            parameters["siteId"] = arr[0]["siteId"].ToString();
                            parameters["posNo"] = arr[0]["posNo"].ToString();
                            parameters["bizDt"] = arr[0]["bizDt"].ToString();
                            parameters["theNo"] = arr[0]["theNo"].ToString();
                            parameters["refNo"] = arr[0]["refNo"].ToString();
                            parameters["payDate"] = get_today_date();
                            parameters["payTime"] = get_today_time();
                            parameters["tranType"] = "C";
                            parameters["payClass"] = arr[0]["payClass"].ToString();
                            parameters["billNo"] = arr[0]["billNo"].ToString();
                            parameters["netAmount"] = arr[0]["netAmount"].ToString();
                            parameters["amountCash"] = arr[0]["amountCash"].ToString();
                            parameters["amountCard"] = arr[0]["amountCard"].ToString();
                            parameters["amountEasy"] = arr[0]["amountEasy"].ToString();
                            parameters["amountPoint"] = arr[0]["amountPoint"].ToString();
                            parameters["isDc"] = arr[0]["isDc"].ToString();
                            parameters["isCancel"] = arr[0]["isCancel"].ToString();

                            if (mRequestPost("payment", parameters))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {
                                }
                                else
                                {
                                    MessageBox.Show("오류. payment\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
                                return;
                            }

                        }
                        else
                        {
                            MessageBox.Show("결제자료 오류. payment\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("결제자료 오류. payment\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }
            else
            {
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["theNo"] = theNo;
                parameters["tranType"] = "C";

                if (netAmount == cancelAmount + amount)
                {
                    parameters["isCancel"] = "Y";
                }
                else
                {
                    parameters["isCancel"] = "0";
                }

                if (mRequestPatch("payment", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                    }
                    else
                    {
                        MessageBox.Show("오류. payment\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }
        }



        int requestCardCancel(PaymentCard pCardAuth, out PaymentCard pCardCancel)
        {
            int ret = 0;
            PaymentCard cardCancel = new PaymentCard();
            pCardCancel = cardCancel;

            if (mVanCode == "KCP")
            {
                paymentKCP p = new paymentKCP();
                ret = p.requestKcpCardCancel(pCardAuth, out pCardCancel);
            }
            else if (mVanCode == "NICE")
            {
                paymentNice p = new paymentNice();
                ret = p.requestNiceCardCancel(pCardAuth, out pCardCancel);
            }
            else if (mVanCode == "TOSS")
            {
                paymentToss p = new paymentToss();
                ret = p.requestTossCardCancel(pCardAuth, out pCardCancel);
            }


            return ret;
        }

        int requestCashCancel(PaymentCash paymentCash, out PaymentCash pCashCancel)
        {
            int ret = 0;
            PaymentCash cashCancel = new PaymentCash();
            pCashCancel = cashCancel;

            if (mVanCode == "KCP")
            {
                paymentKCP p = new paymentKCP();
                ret = p.requestKcpCashCancel(paymentCash, out pCashCancel);
            }
            else if (mVanCode == "NICE")
            {
                paymentNice p = new paymentNice();
                ret = p.requestNiceCashCancel(paymentCash, out pCashCancel);
            }
            else if (mVanCode == "TOSS")
            {
                paymentToss p = new paymentToss();
                ret = p.requestTossCashCancel(paymentCash, out pCashCancel);
            }

            return 0;
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
