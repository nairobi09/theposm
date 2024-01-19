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
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Drawing2D;
using System.Data.SQLite;

namespace thepos
{
    public partial class frmPayCancel : Form
    {
        String the_no;
        String pos_no;
        String selected_biz_date;
        String pay_keep = "";

        int netAmount = 0;
        int cancelAmount = 0;
        int nestAmount = 0;

        bool is_apply = false;
        int select_idx;

        public frmPayCancel(String the_no, String pos_no, String selected_biz_date, String pay_keep, int select_idx)
        {
            InitializeComponent();
            initialize_font();
            initial_the();

            this.the_no = the_no;
            this.pos_no = pos_no;
            this.selected_biz_date = selected_biz_date;
            this.pay_keep = pay_keep;
            this.select_idx= select_idx;

            viewList();
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

            
            // pay_keep = is_cash + is_card + is_point + is_easy;
            if (pay_keep.Substring(0, 1) == "1") // cash
            {
                //#
                if (mTheMode == "Local")
                {
                    string sql = "SELECT * FROM paymentCash WHERE siteId='" + mSiteId + "' AND bizDt='" + selected_biz_date + "' AND theNo='" + the_no + "' AND tranType='A'";
                    SQLiteDataReader dr = sql_select_local_db(sql);
                    add_listview_local(dr);
                    dr.Close();
                }
                else
                {
                    String url = "paymentCash?siteId=" + mSiteId + "&bizDt=" + selected_biz_date + "&theNo=" + the_no + "&tranType=A";
                    if (mRequestGet(url))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                            String data = mObj["paymentCashs"].ToString();
                            add_listview_server(data);
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

            }

            if (pay_keep.Substring(1, 1) == "1") // card
            {
                //#
                if (mTheMode == "Local")
                {
                    string sql = "SELECT * FROM paymentCard WHERE siteId='" + mSiteId + "' AND bizDt='" + selected_biz_date + "' AND theNo='" + the_no + "' AND tranType='A'";
                    SQLiteDataReader dr = sql_select_local_db(sql);
                    add_listview_local(dr);
                    dr.Close();
                }
                else
                {
                    String url = "paymentCard?siteId=" + mSiteId + "&bizDt=" + selected_biz_date + "&theNo=" + the_no + "&tranType=A";
                    if (mRequestGet(url))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                            String data = mObj["paymentCards"].ToString();
                            add_listview_server(data);
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
            }

            if (pay_keep.Substring(2, 1) == "1") // point
            {
                //#
                String url = "paymentPoint?siteId=" + mSiteId + "&bizDt=" + selected_biz_date + "&theNo=" + the_no;
                if (mRequestGet(url))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentPoints"].ToString();
                        add_listview_server(data);
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
                String url = "paymentEasy?siteId=" + mSiteId + "&bizDt=" + selected_biz_date + "&theNo=" + the_no + "&tranType=A";
                if (mRequestGet(url))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentEasys"].ToString();
                        add_listview_server(data);
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


            // 한건이면 선택한걸로
            if (lvwList.Items.Count == 1)
            {
                lvwList.Items[0].Selected = true;
            }



            //
            void add_listview_local(SQLiteDataReader dr)
            {
                while (dr.Read())
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Tag = dr["theNo"].ToString();

                    lvItem.SubItems.Add(get_MMddHHmm(dr["payDate"].ToString(), dr["payTime"].ToString()));
                    lvItem.SubItems.Add(get_pay_type_name(dr["payType"].ToString()));
                    lvItem.SubItems.Add(convert_number(dr["amount"].ToString()).ToString("N0"));


                    if (dr["isCancel"].ToString() == "Y")
                        lvItem.SubItems.Add("취소됨");
                    else if (dr["isCancel"].ToString() == "0")
                        lvItem.SubItems.Add("취소중");
                    else
                        lvItem.SubItems.Add("");


                    lvItem.SubItems.Add(dr["theNo"].ToString());
                    lvItem.SubItems.Add(dr["payType"].ToString());


                    if (dr["payType"].ToString() == "PA" | dr["payType"].ToString() == "PD")
                        lvItem.Text = "1";
                    else
                        lvItem.Text = dr["paySeq"].ToString();



                    if (dr["isCancel"].ToString() == "Y")
                    {
                        lvItem.ForeColor = Color.Gray;
                        lvItem.SubItems[1].ForeColor = Color.Gray;
                        lvItem.SubItems[2].ForeColor = Color.Gray;
                        lvItem.SubItems[3].ForeColor = Color.Gray;
                        lvItem.SubItems[4].ForeColor = Color.Gray;
                        lvItem.SubItems[5].ForeColor = Color.Gray;
                        lvItem.SubItems[6].ForeColor = Color.Gray;
                    }

                    lvwList.Items.Add(lvItem);

                    netAmount += convert_number(dr["amount"].ToString());

                    if (dr["isCancel"].ToString() == "Y") { cancelAmount += convert_number(dr["amount"].ToString()); }
                }
            }

            //
            void add_listview_server(String data)
            {
                JArray arr = JArray.Parse(data);

                for (int i = 0; i < arr.Count; i++)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Tag = arr[i]["theNo"].ToString();

                    lvItem.SubItems.Add(get_MMddHHmm(arr[i]["payDate"].ToString(), arr[i]["payTime"].ToString()));
                    lvItem.SubItems.Add(get_pay_type_name(arr[i]["payType"].ToString()));
                    lvItem.SubItems.Add(convert_number(arr[i]["amount"].ToString()).ToString("N0"));


                    if (arr[i]["isCancel"].ToString() == "Y" | arr[i]["isCancel"].ToString() == "y")
                        lvItem.SubItems.Add("취소됨");
                    else if (arr[i]["isCancel"].ToString() == "0")
                        lvItem.SubItems.Add("취소중");
                    else
                        lvItem.SubItems.Add("");


                    lvItem.SubItems.Add(arr[i]["theNo"].ToString());
                    lvItem.SubItems.Add(arr[i]["payType"].ToString());


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
                    }

                    lvwList.Items.Add(lvItem);

                    netAmount += convert_number(arr[i]["amount"].ToString());

                    if (arr[i]["isCancel"].ToString() == "Y" | arr[i]["isCancel"].ToString() == "y")
                    {
                        cancelAmount += convert_number(arr[i]["amount"].ToString()); 
                    }
                }
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            the_no = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(theno)].Text.ToString();
            String pay_type = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(paytype)].Text.ToString();
            int pay_seq = int.Parse(lvwList.SelectedItems[0].Text);
            int cancel_amt = convert_number(lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(amount)].Text.ToString().Replace(",",""));



            // 이창을 닫으면 기존화면의 목록을 갱신하기 위해서?
            int selected_idx = 0;


            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(cc)].Text == "Y" | lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(cc)].Text == "취소됨")
            {
                SetDisplayAlarm("W", "기취소건.");
                return;  // 취소건, 취소된 승인건 - 제외
            }


            // 최종 마지막 취소건인지 

            String is_cancel_stat = "1";

            if (nestAmount == cancel_amt) is_cancel_stat = "Y";


            //
            if (pay_type == "C1" | pay_type == "C0")
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                PaymentCard pCardAuth = new PaymentCard();


                //#
                if (mTheMode == "Local")
                {
                    String sql = "SELECT * FROM paymentCard WHERE bizDt= '" + selected_biz_date + "' AND theNo='" + the_no + "' AND tranType='A' AND patSeq=" + pay_seq;
                    SQLiteDataReader dr = sql_select_local_db(sql);
                    if (dr.Read())
                    {
                        pCardAuth.site_id = dr["siteId"].ToString();
                        pCardAuth.biz_dt = dr["bizDt"].ToString();
                        pCardAuth.pos_no = dr["posNo"].ToString();
                        pCardAuth.the_no = dr["theNo"].ToString();
                        pCardAuth.ref_no = dr["refNo"].ToString();

                        pCardAuth.pay_date = dr["payDate"].ToString();
                        pCardAuth.pay_time = dr["payTime"].ToString();
                        pCardAuth.pay_type = dr["payType"].ToString();
                        pCardAuth.tran_type = dr["tranType"].ToString();
                        pCardAuth.pay_class = dr["payClass"].ToString();

                        pCardAuth.ticket_no = dr["ticketNo"].ToString();
                        pCardAuth.pay_seq = convert_number(dr["paySeq"].ToString());
                        pCardAuth.tran_date = dr["tranDate"].ToString();
                        pCardAuth.amount = convert_number(dr["amount"].ToString());
                        pCardAuth.install = dr["install"].ToString();

                        pCardAuth.auth_no = dr["authNo"].ToString();
                        pCardAuth.card_no = dr["cardNo"].ToString();

                        pCardAuth.card_name = dr["cardName"].ToString();
                        pCardAuth.isu_code = dr["isuCode"].ToString();
                        pCardAuth.acq_code = dr["acqCode"].ToString();
                        pCardAuth.merchant_no = dr["merchantNo"].ToString();
                        pCardAuth.tran_serial = dr["tranSerial"].ToString();
                        pCardAuth.is_cup = dr["isCup"].ToString();

                        pCardAuth.tax_amount = 0;
                        pCardAuth.tfree_amount = 0;
                        pCardAuth.service_amount = 0;
                        pCardAuth.tax = 0;

                        dr.Close();
                    }
                    else
                    {
                        dr.Close();
                        MessageBox.Show("결제자료 오류. paymentCard\n\n", "thepos");
                        return;
                    }
                }
                else
                {
                    String sUrl = "paymentCard?siteId=" + mSiteId + "&bizDt=" + selected_biz_date + "&theNo=" + the_no + "&tranType=A&paySeq=" + pay_seq;
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

                                pCardAuth.is_cup = arr[0]["isCup"].ToString();

                                pCardAuth.tax_amount = 0;
                                pCardAuth.tfree_amount = 0;
                                pCardAuth.service_amount = 0;
                                pCardAuth.tax = 0;
                            }
                            else
                            {
                                MessageBox.Show("결제자료 오류. paymentCard\n\n", "thepos");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("결제자료 오류. paymentCard\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류. paymentCard\n\n" + mErrorMsg, "thepos");
                        return;
                    }
                }



                // 티켓 확인 및 취소
                if (mTheMode == "Local")
                {
                    // PASS
                }
                else
                {
                    int ret = CheckCancelTicketFlow(pCardAuth.pay_class, pCardAuth.the_no, "");
                    if (ret < 0)
                    {
                        return;
                    }
                }


                if (pCardAuth.pay_type == "C1")  // 카드결제취소
                {
                    //
                    PaymentCard pCardCancel = new PaymentCard();

                    if (requestCardCancel(pCardAuth, out pCardCancel) != 0)  // Toss process
                    {
                        display_error_msg(mErrorMsg);
                        return;
                    }
                    else
                    {
                        cancel_orders(pay_seq, pCardAuth.amount);

                        cancel_payment(pay_seq, pCardAuth.amount, pay_type, is_cancel_stat);


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
                        parameters["bizDt"] = selected_biz_date;
                        parameters["theNo"] = pCardAuth.the_no;
                        parameters["payType"] = "C1";
                        parameters["tranType"] = "A";
                        parameters["paySeq"] = pCardAuth.pay_seq + "";
                        parameters["isCancel"] = "Y";

                        if (mRequestPatch("paymentCard", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                                is_apply = true;
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
                        //MessageBox.Show("카드결제 취소 성공", "thepos");
                    }
                }
                else if (pCardAuth.pay_type == "C0")  // 임의 등록
                {
                    cancel_orders(pay_seq, pCardAuth.amount);

                    cancel_payment(pay_seq, pCardAuth.amount, pay_type, is_cancel_stat);


                    //# 취소건 추가
                    if (mTheMode == "Local")
                    {
                        String sql = "INSERT INTO paymentCard (siteId, posNo, bizDt, theNo, refNo, payDate, payTime, payType, tranType, payClass, ticketNo, paySeq, tranDate, amount, taxAmount, freeAmount, serviceAmt, tax, install, authNo, cardNo, cardName, isuCode, acqCode, merchantNo, tranSerial, signPath, giftChange, isCancel, vanCode) " +
                            "values ('" + mSiteId + "','" + mPosNo + "','" + mBizDate + "','" + pCardAuth.the_no + "','" + pCardAuth.ref_no + "'," +
                                    "'" + get_today_date() + "','" + get_today_time() + "','" + "C0" + "','" + "C" + "','" + pCardAuth.pay_class + "'," +
                                    "'" + pCardAuth.ticket_no + "'," + pCardAuth.pay_seq + ",'" + pCardAuth.tran_date + "'," + pCardAuth.amount + "," + pCardAuth.tax_amount + "," +
                                    "" + pCardAuth.tfree_amount + "," + pCardAuth.service_amount + "," + pCardAuth.tax + ",'" + pCardAuth.install + "','" + pCardAuth.auth_no + "'," +
                                    "'" + pCardAuth.card_no + "','" + pCardAuth.card_name + "','" + pCardAuth.isu_code + "','" + pCardAuth.acq_code + "','" + pCardAuth.merchant_no + "'," +
                                    "'" + pCardAuth.tran_serial + "','" + pCardAuth.sign_path + "','" + pCardAuth.gift_change + "','" + "Y" + "','" + "" + "')";
                        int ret = sql_excute_local_db(sql);

                        is_apply = true;

                    }
                    else
                    {
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
                        parameters["tranDate"] = pCardAuth.tran_date;
                        parameters["amount"] = pCardAuth.amount + "";
                        parameters["taxAmount"] = pCardAuth.tax_amount + "";

                        parameters["freeAmount"] = pCardAuth.tfree_amount + "";
                        parameters["serviceAmt"] = pCardAuth.service_amount + "";
                        parameters["tax"] = pCardAuth.tax + "";
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
                        parameters["vanCode"] = "";

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
                    }


                    //# 승인건에 취소마킹
                    if (mTheMode == "Local")
                    {
                        String sql = "UPDATE paymentCard SET isCancel = 'Y' WHERE bizDt = '" + selected_biz_date + "' AND theNo ='" + pCardAuth.the_no + "' AND tranType = 'A' AND paySeq=" + pCardAuth.pay_seq;
                        int ret = sql_excute_local_db(sql);

                    }
                    else
                    {
                        parameters.Clear();
                        parameters["siteId"] = mSiteId;
                        parameters["bizDt"] = selected_biz_date;
                        parameters["theNo"] = pCardAuth.the_no;
                        parameters["payType"] = "C0";
                        parameters["tranType"] = "A";
                        parameters["paySeq"] = pCardAuth.pay_seq + "";
                        parameters["isCancel"] = "Y";

                        if (mRequestPatch("paymentCard", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                                is_apply = true;
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
                    }


                    SetDisplayAlarm("I", "카드임의등록 취소.");
                    MessageBox.Show("카드임의등록 취소 성공", "thepos");
                }


                // 티켓 취소
                if (mTheMode == "Local")
                {
                }
                else
                {
                    CancelTicketFlow(pCardAuth.pay_class, pCardAuth.the_no, pCardAuth.ticket_no, pCardAuth.amount);
                }


                // 영수증인쇄
                if (is_cancel_stat == "Y")
                {
                    print_bill(pCardAuth.the_no, "C", "", "1101", true);
                }

            }
            else if (pay_type == "R0" | pay_type == "R1")
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                PaymentCash pCashAuth = new PaymentCash();


                //#
                if (mTheMode == "Local")
                {
                    String sql = "SELECT * FROM paymentCash WHERE bizDt= '" + selected_biz_date + "' AND theNo='" + the_no + "' AND tranType='A' AND paySeq=" + pay_seq;
                    SQLiteDataReader dr = sql_select_local_db(sql);
                    if (dr.Read())
                    {
                        pCashAuth.site_id = dr["siteId"].ToString();
                        pCashAuth.pos_no = dr["posNo"].ToString();
                        pCashAuth.biz_dt = dr["bizDt"].ToString();
                        pCashAuth.the_no = dr["theNo"].ToString();
                        pCashAuth.ref_no = dr["refNo"].ToString();
                        pCashAuth.pay_date = dr["payDate"].ToString();
                        pCashAuth.pay_time = dr["payTime"].ToString();
                        pCashAuth.pay_type = dr["payType"].ToString();
                        pCashAuth.tran_type = dr["tranType"].ToString();
                        pCashAuth.pay_class = dr["payClass"].ToString();
                        pCashAuth.ticket_no = dr["ticketNo"].ToString();
                        pCashAuth.pay_seq = convert_number(dr["paySeq"].ToString());
                        pCashAuth.tran_date = dr["tranDate"].ToString();
                        pCashAuth.amount = convert_number(dr["amount"].ToString());
                        pCashAuth.receipt_type = dr["receiptType"].ToString();
                        pCashAuth.issued_method_no = dr["issuedMethodNo"].ToString();
                        pCashAuth.auth_no = dr["authNo"].ToString();
                        pCashAuth.tran_serial = dr["tranSerial"].ToString();
                        pCashAuth.is_cancel = dr["isCancel"].ToString();
                        pCashAuth.van_code = dr["vanCode"].ToString();

                        dr.Close();
                    }
                    else
                    {
                        dr.Close();
                        MessageBox.Show("결제자료 오류. paymentCash\n\n", "thepos");
                        return;
                    }
                    
                }
                else
                {
                    String sUrl = "paymentCash?siteId=" + mSiteId + "&bizDt=" + selected_biz_date + "&theNo=" + the_no + "&tranType=A&paySeq=" + pay_seq;
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
                            MessageBox.Show("결제자료 오류. paymentCash\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류. paymentCash\n\n" + mErrorMsg, "thepos");
                        return;
                    }
                }




                // 티켓 확인 및 취소
                if (mTheMode == "Local")
                {
                    // PASS
                }
                else
                {
                    int ret = CheckCancelTicketFlow(pCashAuth.pay_class, pCashAuth.the_no, pCashAuth.ticket_no);
                    if (ret < 0)
                    {
                        return;
                    }
                }


                if (pCashAuth.pay_type == "R1")  // 현금영수증 취소
                {

                    //? input_type을 구하는 창이 필요한가?

                    PaymentCash pCashCancel = new PaymentCash();

                    if (requestCashCancel(pCashAuth, out pCashCancel) != 0)  // Toss process
                    {
                        display_error_msg(mErrorMsg);
                        return;
                    }
                    else
                    {
                        //
                        cancel_orders(pay_seq, pCashAuth.amount);

                        cancel_payment(pay_seq, pCashAuth.amount, pay_type, is_cancel_stat);


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
                        parameters["bizDt"] = selected_biz_date;
                        parameters["theNo"] = the_no;
                        parameters["payType"] = "R1";
                        parameters["tranType"] = "A";
                        parameters["paySeq"] = pCashAuth.pay_seq + "";
                        parameters["isCancel"] = "Y";

                        if (mRequestPatch("paymentCash", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                                is_apply = true;
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
                        //MessageBox.Show("현금영수증 취소 성공", "thepos");
                    }
                }
                else if (pCashAuth.pay_type == "R0")  // 단순현금
                {
                    // 단순현금은 자동취소

                    cancel_orders(pay_seq, pCashAuth.amount);

                    cancel_payment(pay_seq, pCashAuth.amount, pay_type, is_cancel_stat);


                    //# paymentCash 취소건 추가
                    if (mTheMode == "Local")
                    {
                        String sql = "INSERT INTO paymentCash (siteId, posNo, bizDt, theNo, refNo, payDate, payTime, payType, tranType, payClass, ticketNo, paySeq, tranDate, amount, receiptType, issuedMethodNo, authNo, tranSerial, isCancel, vanCode) " +
                            "values ('" + mSiteId + "','" + mPosNo + "','" + mBizDate + "','" + pCashAuth.the_no + "','" + pCashAuth.ref_no + "','" + pCashAuth.pay_date + "','" + pCashAuth.pay_time + "','" + pCashAuth.pay_type + "','" + pCashAuth.tran_type + "','" + pCashAuth.pay_class + "','" +
                                          pCashAuth.ticket_no + "'," + pCashAuth.pay_seq + ",'" + pCashAuth.tran_date + "'," + pCashAuth.amount + ",'" + pCashAuth.receipt_type + "','" + pCashAuth.issued_method_no + "','" + pCashAuth.auth_no + "','" + pCashAuth.tran_serial + "','" + pCashAuth.is_cancel + "','" + pCashAuth.van_code + "')";
                        int ret = sql_excute_local_db(sql);

                        is_apply = true;
                    }
                    else
                    {
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
                        parameters["isCancel"] = "Y";
                        parameters["vanCode"] = "";

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
                    }



                    //# 승인건에 취소마킹
                    if (mTheMode == "Local")
                    {
                        String sql = "UPDATE paymentCash SET isCancel = 'Y' WHERE bizDt = '" + selected_biz_date + "' AND theNo ='" + pCashAuth.the_no + "' AND tranType = 'A' AND paySeq=" + pCashAuth.pay_seq;
                        int ret = sql_excute_local_db(sql);

                    }
                    else
                    {
                        parameters.Clear();
                        parameters["siteId"] = mSiteId;
                        parameters["bizDt"] = selected_biz_date;
                        parameters["theNo"] = the_no;
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
                    }


                    SetDisplayAlarm("I", "단순현금 취소.");
                    //MessageBox.Show("단순현금 취소 성공", "thepos");
                }


                // 티켓 취소
                if (mTheMode == "Local")
                {
                    // PASS
                }
                else
                {
                    CancelTicketFlow(pCashAuth.pay_class, pCashAuth.the_no, pCashAuth.ticket_no, pCashAuth.amount);
                }


                // 영수증인쇄
                if (is_cancel_stat == "Y")
                {
                    print_bill(pCashAuth.the_no, "C", "", "1101", true);
                }

            }
            else if (pay_type == "E1")
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                PaymentEasy pEasyAuth = new PaymentEasy();

                String sUrl = "paymentEasy?siteId=" + mSiteId + "&bizDt=" + selected_biz_date + "&theNo=" + the_no + "&tranType=A&paySeq=" + pay_seq;
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
                            pEasyAuth.barcode_no = arr[0]["barcodeNo"].ToString();
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


                // 티켓 확인 및 취소
                if (mTheMode == "Local")
                {
                    // PASS
                }
                else
                {
                    int ret = CheckCancelTicketFlow(pEasyAuth.pay_class, pEasyAuth.the_no, "");
                    if (ret < 0)
                    {
                        return;
                    }
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
                        cancel_orders(pay_seq, pEasyAuth.amount);

                        cancel_payment(pay_seq, pEasyAuth.amount, pay_type, is_cancel_stat);


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
                        parameters["isCancel"] = "Y";
                        parameters["vanCode"] = mVanCode;
                        parameters["PatTypr2"] = pEasyCancel.pay_type2;
                        parameters["barcodeNo"] = pEasyCancel.barcode_no;

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
                        parameters["bizDt"] = selected_biz_date;
                        parameters["theNo"] = pEasyAuth.the_no;
                        parameters["payType"] = "E1";
                        parameters["tranType"] = "A";
                        parameters["paySeq"] = pEasyAuth.pay_seq + "";
                        parameters["isCancel"] = "Y";

                        if (mRequestPatch("paymentEasy", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {
                                is_apply = true;
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
                        //MessageBox.Show("간편결제 취소 성공", "thepos");


                        // 티켓 취소
                        if (mTheMode == "Local")
                        {
                            // PASS
                        }
                        else
                        {
                            CancelTicketFlow(pEasyAuth.pay_class, pEasyAuth.the_no, pEasyAuth.ticket_no, pEasyAuth.amount);
                        }

                        // 영수증인쇄
                        if (is_cancel_stat == "Y")
                        {
                            print_bill(pEasyAuth.the_no, "C", "", "1101", true);
                        }

                    }
                }

            }
            else if (pay_type == "PA" | pay_type == "PD")
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                PaymentPoint pPointAuth = new PaymentPoint();

                String sUrl = "paymentPoint?siteId=" + mSiteId + "&bizDt=" + selected_biz_date + "&theNo=" + the_no;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentPoints"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count == 1)
                        {
                            pPointAuth.site_id = arr[0]["siteId"].ToString();
                            pPointAuth.biz_dt = arr[0]["bizDt"].ToString();
                            pPointAuth.pos_no = arr[0]["posNo"].ToString();
                            pPointAuth.the_no = arr[0]["theNo"].ToString();
                            pPointAuth.ref_no = arr[0]["refNo"].ToString();

                            pPointAuth.pay_date = arr[0]["payDate"].ToString();
                            pPointAuth.pay_time = arr[0]["payTime"].ToString();
                            pPointAuth.pay_type = arr[0]["payType"].ToString();
                            pPointAuth.pay_class = arr[0]["payClass"].ToString();
                            pPointAuth.ticket_no = arr[0]["ticketNo"].ToString();
                            pPointAuth.usage_no = arr[0]["usageNo"].ToString();
                            pPointAuth.amount = convert_number(arr[0]["amount"].ToString());
                            pPointAuth.is_cancel = arr[0]["isCancel"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("결제자료 오류. paymentPoint\n\n", "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("결제자료 오류. paymentPoint\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. paymentPoint\n\n" + mErrorMsg, "thepos");
                    return;
                }


                // 티켓 취소여부 확인
                int ret = CheckCancelTicketFlow(pPointAuth.pay_class, pPointAuth.the_no, pPointAuth.ticket_no);
                if (ret < 0)
                {
                    return;
                }



                //if (pPointAuth.pay_type == "PA")  // PA or PD
                {
                    // 자동취소
                    cancel_orders(pay_seq, pPointAuth.amount);

                    cancel_payment(pay_seq, pPointAuth.amount, pay_type, is_cancel_stat);


                    // 포인트취소는 paymentPoint테이블에 취소건을 추가하지 않는다. 20231004
                    /*
                    parameters.Clear();
                    parameters["siteId"] = mSiteId;
                    parameters["bizDt"] = mBizDate;
                    parameters["posNo"] = mPosNo;
                    parameters["theNo"] = pPointAuth.the_no;
                    parameters["refNo"] = pPointAuth.ref_no;

                    parameters["payDate"] = get_today_date();
                    parameters["payTime"] = get_today_time();
                    parameters["payType"] = pPointAuth.pay_type;
                    parameters["tranType"] = "C";
                    parameters["payClass"] = pPointAuth.pay_class;

                    parameters["ticketNo"] = pPointAuth.ticket_no;
                    parameters["usageNo"] = pPointAuth.usage_no;
                    parameters["amount"] = pPointAuth.amount + "";
                    parameters["isCancel"] = "Y";

                    if (mRequestPost("paymentPoint", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                            is_apply = true;
                        }
                        else
                        {
                            MessageBox.Show("오류 paymentPoint\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류 paymentPoint\n\n" + mErrorMsg, "thepos");
                        return;
                    }
                    */


                    // 승인건에 취소마킹
                    parameters.Clear();
                    parameters["siteId"] = mSiteId;
                    parameters["bizDt"] = selected_biz_date;
                    parameters["theNo"] = pPointAuth.the_no; ;
                    parameters["payType"] = pPointAuth.pay_type;
                    parameters["isCancel"] = "Y";

                    if (mRequestPatch("paymentPoint", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                            is_apply = true;
                        }
                        else
                        {
                            MessageBox.Show("오류. paymentPoint\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류. paymentPoint\n\n" + mErrorMsg, "thepos");
                        return;
                    }


                    // 티켓 취소
                    CancelTicketFlow(pPointAuth.pay_class, pPointAuth.the_no, pPointAuth.ticket_no, pPointAuth.amount);


                    // 영수증인쇄
                    if (is_cancel_stat == "Y")
                    {
                        print_bill(pPointAuth.the_no, "C", "", "0010", true); // 
                    }

                }

            }



            if (is_cancel_stat == "Y")
            {
                print_cancel_order(the_no);
            }



            // 다시 불러오기
            if (is_apply == true)
            {
                viewList();
            }
        }



        void cancel_orders(int pay_seq, int amount)
        {
            if (pay_seq != 1)  // 복합결제 취소인 경우 첫번째 건만
            {
                return;
            }


            // orders
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            //# 승인건 취소 마킹
            if (mTheMode == "Local")
            {
                String sql = "UPDATE orders SET isCancel = 'Y' WHERE bizDt = '" + selected_biz_date + "' AND theNo ='" + the_no + "' AND tranType = 'A'";
                int ret = sql_excute_local_db(sql);

            }
            else
            {
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["bizDt"] = selected_biz_date;
                parameters["theNo"] = the_no;
                parameters["tranType"] = "A";
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
            }



            //# orders 취소건 추가
            if (mTheMode == "Local")
            {
                String sql = "SELECT * FROM orders WHERE bizDt= '" + selected_biz_date + "' AND theNo='" + the_no + "' AND tranType='A'";
                SQLiteDataReader dr = sql_select_local_db(sql);
                if (dr.Read())
                {
                    //
                    sql = "INSERT INTO orders (siteId, posNo, bizDt, theNo, refNo, tranType, orderDate, orderTime, cnt, isCancel) " +
                                    "values ('" + mSiteId + "','" + mPosNo + "','" + mBizDate + "','" + the_no + "','" + dr["refNo"].ToString() + "','C','" + get_today_date() + "','" + get_today_time() + "'," + dr["cnt"].ToString() + ", 'Y')";
                    sql_excute_local_db(sql);
                }
                else
                {
                    MessageBox.Show("주문자료 오류. orders\n\n", "thepos");
                    return;
                }
                dr.Close();
            }
            else
            {
                String sUrl = "orders?siteId=" + mSiteId + "&bizDt=" + selected_biz_date + "&theNo=" + the_no + "&tranType=A";
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["orders"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count == 1)
                        {
                            parameters.Clear();
                            parameters["siteId"] = mSiteId;
                            parameters["posNo"] = mPosNo;
                            parameters["bizDt"] = mBizDate;
                            parameters["theNo"] = the_no;
                            parameters["refNo"] = arr[0]["refNo"].ToString();
                            parameters["tranType"] = "C";
                            parameters["orderDate"] = get_today_date();
                            parameters["orderTime"] = get_today_time();
                            parameters["cnt"] = arr[0]["cnt"].ToString();
                            parameters["isCancel"] = "Y";

                            if (mRequestPost("orders", parameters))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {
                                }
                                else
                                {
                                    MessageBox.Show("오류 order\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("주문자료 오류. orders\n\n", "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("주문자료 오류. orders\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. orders\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }




            // orderItem


            //# orderItem 승인건 취소마킹
            if (mTheMode == "Local")
            {
                String sql = "UPDATE orderItem SET isCancel = 'Y' WHERE bizDt = '" + selected_biz_date + "' AND theNo ='" + the_no + "'";
                int ret = sql_excute_local_db(sql);

            }
            else
            {
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["bizDt"] = selected_biz_date;
                parameters["theNo"] = the_no;
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
            }


            //# orderItem 취소건 추가
            if (mTheMode == "Local")
            {
                String sql = "SELECT * FROM orderItem WHERE bizDt= '" + selected_biz_date + "' AND theNo='" + the_no + "' AND tranType='A'";
                SQLiteDataReader dr = sql_select_local_db(sql);
                while (dr.Read())
                {
                    sql = "INSERT INTO orderItem (siteId, posNo, bizDt, theNo, refNo, tranType, orderDate, orderTime, goodsCode, goodsName, cnt, amt, optionAmt, shopCode, ticketYn, taxFree, dcAmount, dcrType, dcrDes, dcrValue, payClass, ticketNo, isCancel, shopCode, shopOrderNo, optionNo) " +
                                "values ('" + mSiteId + "','" + mPosNo + "','" + mBizDate + "','" + the_no + "','" + dr["refNo"].ToString() + "','C','" + get_today_date() + "','" + get_today_time() + "','" + dr["goodsCode"].ToString() + "','" + dr["goodsName"].ToString() + "'," + dr["cnt"].ToString() + "," + dr["amt"].ToString() + "," + dr["optionAmt"].ToString() + "," +
                                "'" + dr["shopCode"].ToString() + "','" + dr["ticketNo"].ToString() + "','" + dr["taxFree"].ToString() + "'," + dr["dcAmount"].ToString() + ",'" + dr["dcrType"].ToString() + "','" + dr["dcrDes"].ToString() + "'," + dr["dcrValue"].ToString() + ",'" + dr["payClass"].ToString() + "','" + dr["ticketNo"].ToString() + "','Y', '" + dr["shopCode"].ToString() + "','" + dr["shopOrderNo"].ToString() + "','" + dr["optionNo"].ToString() + "')";
                    sql_excute_local_db(sql);
                }
            }
            else
            {
                String sUrl = "orderItem?siteId=" + mSiteId + "&bizDt=" + selected_biz_date + "&theNo=" + the_no + "&tranType=A";
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["orderItems"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            parameters.Clear();
                            parameters["siteId"] = mSiteId;
                            parameters["posNo"] = mPosNo;
                            parameters["bizDt"] = mBizDate;
                            parameters["theNo"] = the_no;
                            parameters["refNo"] = arr[i]["refNo"].ToString();

                            parameters["tranType"] = "C";
                            parameters["orderDate"] = get_today_date();
                            parameters["orderTime"] = get_today_time();

                            parameters["goodsCode"] = arr[i]["goodsCode"].ToString();
                            parameters["goodsName"] = arr[i]["goodsName"].ToString();

                            parameters["cnt"] = arr[i]["cnt"].ToString();
                            parameters["amt"] = arr[i]["amt"].ToString();
                            parameters["optionAmt"] = arr[i]["optionAmt"].ToString();  // 

                            parameters["ticketYn"] = arr[i]["ticketYn"].ToString();
                            parameters["taxFree"] = arr[i]["taxFree"].ToString();
                            parameters["dcAmount"] = arr[i]["dcAmount"].ToString();

                            parameters["dcrType"] = arr[i]["dcrType"].ToString();
                            parameters["dcrDes"] = arr[i]["dcrDes"].ToString();
                            parameters["dcrValue"] = arr[i]["dcrValue"].ToString();

                            parameters["payClass"] = arr[i]["payClass"].ToString();
                            parameters["ticketNo"] = arr[i]["ticketNo"].ToString();

                            parameters["isCancel"] = "Y";
                            parameters["shopCode"] = arr[i]["shopCode"].ToString();
                            parameters["shopOrderNo"] = arr[i]["shopOrderNo"].ToString();
                            parameters["optionNo"] = arr[i]["optionNo"].ToString();

                            if (mRequestPost("orderItem", parameters))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {
                                }
                                else
                                {
                                    MessageBox.Show("오류 orderItem\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("주문자료 오류. orderItem\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. orderItem\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            //# orderOptionItem 승인건 취소마킹
            if (mTheMode == "Local")
            {
                String sql = "UPDATE orderOptionItem SET isCancel = 'Y' WHERE bizDt = '" + selected_biz_date + "' AND theNo ='" + the_no + "'";
                int ret = sql_excute_local_db(sql);
            }
            else
            {
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["bizDt"] = selected_biz_date;
                parameters["theNo"] = the_no;
                parameters["isCancel"] = "Y";

                if (mRequestPatch("orderOptionItem", parameters))
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
            }
        }


        void cancel_payment(int pay_seq, int amount, String pay_type, String is_cancel)
        {
            // payment
            Payment paymentAuth = new Payment();

            if (get_payment("A", selected_biz_date,  the_no, out paymentAuth) == 1)  // 선택일자의 승인건
            {
                //# 승인건 취소마킹
                if (mTheMode == "Local")
                {
                    String t_cancel = "";
                    if (netAmount == cancelAmount + amount)
                        t_cancel = "Y";
                    else
                        t_cancel = "1";

                    String sql = "UPDATE payment SET isCancel = '" + t_cancel + "' WHERE bizDt = '" + selected_biz_date + "' AND theNo ='" + the_no + "' AND tranType = 'A'";
                    int ret = sql_excute_local_db(sql);

                }
                else
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Clear();
                    parameters["siteId"] = mSiteId;
                    parameters["bizDt"] = selected_biz_date;
                    parameters["theNo"] = the_no;
                    parameters["tranType"] = "A";

                    if (netAmount == cancelAmount + amount)
                        parameters["isCancel"] = "Y";
                    else
                        parameters["isCancel"] = "1";

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


            //
            Payment paymentCancel = new Payment();
            int c_cnt = get_payment("C", mBizDate, the_no, out paymentCancel);  // 오늘자의 취소건
            
            if (c_cnt == 0) 
            {
                int amount_cash = 0, amount_card = 0, amount_easy = 0, amount_point = 0;
                String pay_type1 = pay_type.Substring(0, 1);

                if (pay_type1 == "R") amount_cash = amount;
                else if (pay_type1 == "C") amount_card = amount;
                else if (pay_type1 == "E") amount_easy = amount;
                else if (pay_type1 == "P") amount_point = amount;

                if (mTheMode == "Local")
                {
                    String sql = "INSERT INTO payment (siteId, posNo, bizDt, theNo, refNo, payDate, payTime, tranType, payClass, billNo, netAmount, amountCash, amountCard, amountEasy, amountPoint, dcAmount, isCancel) " +
                                        "values ('" + mSiteId + "','" + mPosNo + "','" + mBizDate + "','" + paymentAuth.the_no + "','" + paymentAuth.ref_no + "','" + get_today_date() + "','" + get_today_time() + "','C','" + paymentAuth.pay_class + "','" + paymentAuth.bill_no + "'," + 
                                        "" + amount + "," + amount_cash + "," + amount_card + "," + amount_easy + "," + amount_point + "," + paymentAuth.dc_amount + ",'" + is_cancel + "')";
                    sql_excute_local_db(sql);

                }
                else
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Clear();
                    parameters["siteId"] = mSiteId;
                    parameters["posNo"] = mPosNo;
                    parameters["bizDt"] = mBizDate;
                    parameters["theNo"] = paymentAuth.the_no;
                    parameters["refNo"] = paymentAuth.ref_no;
                    parameters["payDate"] = get_today_date();
                    parameters["payTime"] = get_today_time();
                    parameters["tranType"] = "C";
                    parameters["payClass"] = paymentAuth.pay_class;
                    parameters["billNo"] = paymentAuth.bill_no;

                    parameters["netAmount"] = amount + "";
                    parameters["amountCash"] = amount_cash + "";
                    parameters["amountCard"] = amount_card + "";
                    parameters["amountEasy"] = amount_easy + "";
                    parameters["amountPoint"] = amount_point + "";
                    parameters["dcAmount"] = paymentAuth.dc_amount + "";
                    parameters["isCancel"] = is_cancel;
                    if (mRequestPost("payment", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                        }
                        else
                        {
                            MessageBox.Show("오류 payment\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류 payment\n\n" + mErrorMsg, "thepos");
                        return;
                    }
                }
            }
            else if (c_cnt == 1) 
            {
                int t_net_amount = paymentCancel.net_amount + amount;
                int t_amount_cash = paymentCancel.amount_cash;
                int t_amount_card = paymentCancel.amount_card;
                int t_amount_easy = paymentCancel.amount_easy;
                int t_amount_point = paymentCancel.amount_point;

                String pay_type1 = pay_type.Substring(0, 1);

                if (pay_type1 == "R") t_amount_cash += amount;
                else if (pay_type1 == "C") t_amount_card += amount;
                else if (pay_type1 == "E") t_amount_easy += amount;
                else if (pay_type1 == "P") t_amount_point += amount;


                if (mTheMode == "Local")
                {
                    String sql = "UPDATE payment SET netAmount = " + t_net_amount + ", amountCash = " + t_amount_cash + ", amountCard = " + t_amount_card + ", amountEasy = " + t_amount_easy + ", amountPoint = " + t_amount_point + ", isCancel = 'Y' WHERE bizDt = '" + mBizDate + "' AND theNo ='" + paymentAuth.the_no + "' AND tranType = 'C'";
                    int ret = sql_excute_local_db(sql);
                }
                else
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Clear();
                    parameters["siteId"] = mSiteId;
                    parameters["bizDt"] = mBizDate;
                    parameters["theNo"] = paymentAuth.the_no;
                    parameters["tranType"] = "C";

                    parameters["netAmount"] = t_net_amount.ToString();
                    parameters["amountCash"] = t_amount_cash.ToString();
                    parameters["amountCard"] = t_amount_card.ToString();
                    parameters["amountEasy"] = t_amount_easy.ToString();
                    parameters["amountPoint"] = t_amount_point.ToString();
                    parameters["isCancel"] = is_cancel;
                    if (mRequestPatch("payment", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                        }
                        else
                        {
                            MessageBox.Show("오류 payment\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류 payment\n\n" + mErrorMsg, "thepos");
                        return;
                    }
                }
            }


        }
        


        // //////////////////////////////////////////////////////////////////
        private int get_payment(String tran_type, String biz_date, String tho_no, out Payment payment)
        {
            payment = new Payment();

            if (mTheMode == "Local")
            {
                String sql = "SELECT * FROM payment WHERE bizDt= '" + biz_date + "' AND theNo='" + tho_no + "' AND tranType='" + tran_type + "'";
                SQLiteDataReader dr = sql_select_local_db(sql);
                if (dr.Read())
                {
                    payment.site_id = dr["siteId"].ToString();
                    payment.pos_no = dr["posNo"].ToString();
                    payment.biz_dt = dr["bizDt"].ToString();
                    payment.the_no = dr["theNo"].ToString();
                    payment.ref_no = dr["refNo"].ToString();

                    payment.pay_date = dr["payDate"].ToString();
                    payment.pay_time = dr["payTime"].ToString();
                    payment.tran_type = dr["tranType"].ToString();
                    payment.pay_class = dr["payClass"].ToString();
                    payment.bill_no = dr["billNo"].ToString();

                    payment.net_amount = convert_number(dr["netAmount"].ToString());
                    payment.amount_cash = convert_number(dr["amountCash"].ToString());
                    payment.amount_card = convert_number(dr["amountCard"].ToString());
                    payment.amount_easy = convert_number(dr["amountEasy"].ToString());
                    payment.amount_point = convert_number(dr["amountPoint"].ToString());

                    payment.dc_amount = convert_number(dr["dcAmount"].ToString());
                    payment.is_cancel = dr["isCancel"].ToString();

                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                String sUrl = "payment?siteId=" + mSiteId + "&bizDt=" + biz_date + "&theNo=" + tho_no + "&tranType=" + tran_type;
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
                            payment.pos_no = arr[0]["posNo"].ToString();
                            payment.biz_dt = arr[0]["bizDt"].ToString();
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
                            MessageBox.Show("오류. payment\n\n" + "arr.Count=" + arr.Count, "thepos");
                            return -1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("오류. payment\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return -1;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
                    return -1;
                }
            }

        }


        public static void print_cancel_order(String tTheNo)
        {
            // [취소 주문서/교환권]은 주문옵션아이템 항목은 제외한다.


            List<MemOrderItem> MemOrderItemList = new List<MemOrderItem>();

            if (mTheMode == "Local")
            {
                SQLiteDataReader dr = sql_select_local_db("SELECT * FROM orderItem WHERE theNo='" + tTheNo + "' AND tranType='C'");
                while (dr.Read())
                {
                    if (dr["shopOrderNo"].ToString() != "")
                    {
                        MemOrderItem memOrderItem = new MemOrderItem();

                        memOrderItem.shop_order_no = dr["shopOrderNo"].ToString();
                        memOrderItem.shop_code = dr["shopCode"].ToString();
                        memOrderItem.goods_name = dr["goodsName"].ToString();
                        memOrderItem.cnt = convert_number(dr["cnt"].ToString());

                        MemOrderItemList.Add(memOrderItem);
                    }
                }

                dr.Close();
            }
            else
            {
                String sUrl = "orderItem?siteId=" + mSiteId + "&theNo=" + tTheNo + "&tranType=C";
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["orderItems"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            String shop_order_no = arr[i]["shopOrderNo"].ToString();

                            if (shop_order_no != "")
                            {
                                MemOrderItem memOrderItem = new MemOrderItem();

                                memOrderItem.shop_order_no = shop_order_no;
                                memOrderItem.shop_code = arr[i]["shopCode"].ToString();
                                memOrderItem.goods_name = arr[i]["goodsName"].ToString();
                                memOrderItem.cnt = convert_number(arr[i]["cnt"].ToString());

                                MemOrderItemList.Add(memOrderItem);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("취소주문서 출력오류\n\n핼프데스크로 문의바랍니다.", "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("취소주문서 출력오류\n\n핼프데스크로 문의바랍니다.", "thepos");
                    return;
                }
            }




            if (MemOrderItemList.Count == 0)
                return;





            //
            String t_shop_code = "";
            String t_order_no = "";
            String t_order_dt = get_today_date() + get_today_time();

            List<String> t_good_name = new List<String>();
            List<int> t_good_cnt = new List<int>();

            t_shop_code = MemOrderItemList[0].shop_code;
            t_order_no = MemOrderItemList[0].shop_order_no;
            
            t_good_name.Add(MemOrderItemList[0].goods_name);
            t_good_cnt.Add(MemOrderItemList[0].cnt);






            for (int i = 0; i < MemOrderItemList.Count - 1; i++)
            {
                if (string.Compare(MemOrderItemList[i].shop_code, MemOrderItemList[i + 1].shop_code) == 0)
                {
                    t_good_name.Add(MemOrderItemList[i + 1].goods_name);
                    t_good_cnt.Add(MemOrderItemList[i + 1].cnt);
                }
                else
                {
                    // 업장주문서 출력 -> shop 등록정보 프린터
                    print_order_str("to_shop", t_shop_code, "취소주문서", t_order_no, t_good_name, t_good_cnt, t_order_dt);

                    // 주문교환권 출력 -> 영수증프린터
                    print_order_str("to_local", t_shop_code, "취소교환권", t_order_no, t_good_name, t_good_cnt, t_order_dt);


                    t_good_name.Clear();
                    t_good_cnt.Clear();
                    t_shop_code = MemOrderItemList[i + 1].shop_code;
                    t_order_no = MemOrderItemList[i + 1].shop_order_no;
                    t_good_name.Add(MemOrderItemList[i + 1].goods_name);
                    t_good_cnt.Add(MemOrderItemList[i + 1].cnt);
                }
            }

            // 업장주문서 출력 -> shop 등록정보 프린터
            print_order_str("to_shop", t_shop_code, "취소주문서", t_order_no, t_good_name, t_good_cnt, t_order_dt);

            // 주문교환권 출력 -> 영수증프린터
            print_order_str("to_local", t_shop_code, "취소교환권", t_order_no, t_good_name, t_good_cnt, t_order_dt);

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
                reviewList(selected_biz_date, pos_no, the_no, select_idx);
            }


        }

        private void lblNestAmount_Click(object sender, EventArgs e)
        {

        }

        private void lblCancelAmount_Click(object sender, EventArgs e)
        {

        }

        private void lblT3_Click(object sender, EventArgs e)
        {

        }

        private void lblNetAmount_Click(object sender, EventArgs e)
        {

        }

        private void lblT2_Click(object sender, EventArgs e)
        {

        }

        private void lblT1_Click(object sender, EventArgs e)
        {

        }

        private void panelback_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lvwPay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
