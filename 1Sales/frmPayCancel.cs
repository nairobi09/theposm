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
using Newtonsoft.Json.Linq;
using static thepos.thePos;
using static thepos.frmSales;
using static thepos.frmPayManager;
using System.Security.Cryptography;
using System.Drawing.Text;

namespace thepos
{
    public partial class frmPayCancel : Form
    {
        String theNo;
        String ticketNo;
        String pay_keep = "";

        int netAmount = 0;
        int cancelAmount = 0;
        int nestAmount = 0;

        bool is_apply = false;
        int selectIdx;

        public frmPayCancel(String the_no, String ticket_no, String pay_keep, int select_idx)
        {
            InitializeComponent();
            initialize_font();
            initial_the();

            theNo = the_no;
            ticketNo = ticket_no;
            this.pay_keep = pay_keep;
            selectIdx= select_idx;

            viewPayList();
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



        private void viewPayList()
        {
            netAmount = 0;
            cancelAmount = 0;
            nestAmount = 0;
            lvwPay.Items.Clear();

            
            // pay_keep = is_cash + is_card + is_point + is_easy;
            if (pay_keep.Substring(0, 1) == "1") // cash
            {
                //#
                String url = "paymentCash?theNo=" + theNo + "&tranType=A";
                if (mRequestGet(url))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCashs"].ToString();
                        add_listview(data);
                    }
                    else
                    {
                        MessageBox.Show("결제 데이터 오류. paymentCash\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. paymentCash\n\n" + mErrorMsg, "thepos");
                }
            }

            if (pay_keep.Substring(1, 1) == "1") // card
            {
                //#
                String url = "paymentCard?theNo=" + theNo + "&tranType=A";
                if (mRequestGet(url))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCards"].ToString();
                        add_listview(data);
                    }
                    else
                    {
                        MessageBox.Show("결제 데이터 오류. paymentCard\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. paymentCard\n\n" + mErrorMsg, "thepos");
                }
            }


            if (pay_keep.Substring(2, 1) == "1") // point
            {
                //#
                String url = "paymentPoint?theNo=" + theNo + "&tranType=A";
                if (mRequestGet(url))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentPoints"].ToString();
                        add_listview(data);
                    }
                    else
                    {
                        MessageBox.Show("결제 데이터 오류. paymentPoint\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. paymentPoint\n\n" + mErrorMsg, "thepos");
                }
            }




            if (pay_keep.Substring(3, 1) == "1") // easy
            {
                //#
                String url = "paymentEasy?theNo=" + theNo + "&tranType=A";
                if (mRequestGet(url))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentEasys"].ToString();
                        add_listview(data);
                    }
                    else
                    {
                        MessageBox.Show("결제 데이터 오류. paymentEasy\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. paymentEasy\n\n" + mErrorMsg, "thepos");
                }
            }


            nestAmount = netAmount - cancelAmount;

            lblNetAmount.Text = netAmount.ToString("N0");
            lblCancelAmount.Text = cancelAmount.ToString("N0");
            lblNestAmount.Text = nestAmount.ToString("N0");


            // 한건이상이면 선택한걸로
            if (lvwPay.Items.Count > 0)
            {
                lvwPay.Items[0].Selected = true;
            }



            //
            void add_listview(String data)
            {
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

                    if (arr[i]["isCancel"].ToString() == "Y") { cancelAmount += convert_number(arr[i]["amount"].ToString()); }
                }
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwPay.SelectedItems.Count == 0) { return; }

            String the_no = lvwPay.SelectedItems[0].SubItems[lvwPay.Columns.IndexOf(t_no)].Text.ToString();
            String pay_type = lvwPay.SelectedItems[0].SubItems[lvwPay.Columns.IndexOf(paytype)].Text.ToString();
            int pay_seq = int.Parse(lvwPay.SelectedItems[0].Text);
            int idx = 0;


            if (lvwPay.SelectedItems[0].SubItems[lvwPay.Columns.IndexOf(cc)].Text == "Y" | lvwPay.SelectedItems[0].SubItems[lvwPay.Columns.IndexOf(cc)].Text == "취소됨")
            {
                SetDisplayAlarm("W", "기취소건.");
                return;  // 취소건, 취소된 승인건 - 제외
            }


            //
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
                        cancel_order_and_payments(pCardAuth.amount);


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
                                is_apply = true;
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
                            is_apply = true;
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
                                is_apply = true;
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
                            is_apply = true;
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
            else if (pay_type == "E1")
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                PaymentEasy pEasyAuth = new PaymentEasy();

                String sUrl = "paymentEasy?siteId=" + mSiteId + "&theNo=" + theNo + "&tranType=A&paySeq=" + pay_seq;
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
                        MessageBox.Show("결제자료 오류. paymentEasy\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
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
                    //?
                    PaymentEasy pEasyCancel = new PaymentEasy();

                    if (requestEasyCancel(pEasyAuth, out pEasyCancel) != 0)  // Toss process
                    {
                        display_error_msg(mErrorMsg);
                    }
                    else
                    {
                        cancel_order_and_payments(pEasyAuth.amount);


                        parameters["siteId"] = mSiteId;
                        parameters["posNo"] = mPosNo;
                        parameters["bizDt"] = mBizDate;
                        parameters["theNo"] = pEasyAuth.the_no;
                        parameters["refNo"] = pEasyAuth.ref_no;
                        parameters["payDate"] = get_today_date();
                        parameters["payTime"] = get_today_time();
                        parameters["payType"] = "E1";       // 결제구분 : , 간편결제(E1)
                        parameters["tranType"] = "C";       // 승인 A 취소 C
                        parameters["payClass"] = mPayClass;
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
                        parameters["isCancel"] = "Y";
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
                                MessageBox.Show("오류 paymentEasy\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
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
                        parameters["theNo"] = pEasyAuth.the_no;
                        parameters["payType"] = "E1";
                        parameters["tranType"] = "A";
                        parameters["paySeq"] = pEasyAuth.pay_seq + "";
                        parameters["isCancel"] = "Y";

                        if (mRequestPatch("paymentEasy", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                            }
                            else
                            {
                                MessageBox.Show("오류. paymentEasy\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("시스템오류. paymentEasy\n\n" + mErrorMsg, "thepos");
                            return;
                        }


                        SetDisplayAlarm("I", "간편결제 취소.");
                        MessageBox.Show("간편결제 취소 성공", "thepos");
                    }
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

                //?  서버전환
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



                //?
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


            //? 다시 불러오기
            if (is_apply == true)
            {
                viewPayList();
            }


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

                        if (arr.Count > 0)
                        {
                            parameters["siteId"] = mSiteId;
                            parameters["posNo"] = mPosNo;
                            parameters["bizDt"] = mBizDate;
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
            else if (mVanCode == "KOVAN")
            {
                paymentKovan p = new paymentKovan();
                //ret = p.requestKovanCardCancel(pCardAuth, out pCardCancel);
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
            else if (mVanCode == "KOVAN")
            {
                paymentKovan p = new paymentKovan();
                //ret = p.requestKovanCashCancel(paymentCash, out pCashCancel);
            }

            return ret;
        }


        int requestEasyCancel(PaymentEasy paymentEasy, out PaymentEasy pEasyCancel)
        {
            int ret = 0;
            PaymentEasy easyCancel = new PaymentEasy();
            pEasyCancel = easyCancel;

            if (mVanCode == "KCP")
            {
                paymentKCP p = new paymentKCP();
                ret = p.requestKcpEasyCancel(paymentEasy, out pEasyCancel);
            }
            else if (mVanCode == "NICE")
            {
                paymentNice p = new paymentNice();
                ret = p.requestNiceEasyCancel(paymentEasy, out pEasyCancel);
            }
            else if (mVanCode == "KOVAN")
            {
                paymentKovan p = new paymentKovan();
             //   ret = p.requestKovanEasyCancel(paymentEasy, out pEasyCancel);
            }

            return ret;
        }


        void display_error_msg(string msg)
        {
            MessageBox.Show(msg, "thepos");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayCancel_FormClosed(object sender, FormClosedEventArgs e)
        {
            mPanelCancel.Visible = false;
            mPanelCancel.Controls.Clear();


            // 취소action이 있었으면 manager화면의 갱신이 필요하다.
            if (is_apply == true)
            {
                reviewList(theNo, selectIdx);
            }


        }
    }
}
