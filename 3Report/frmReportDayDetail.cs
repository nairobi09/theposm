using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;

namespace thepos
{
    public partial class frmReportDayDetail : Form
    {
        String thisBizDt = "";

        public frmReportDayDetail()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();
        }

        private void initialize_font()
        {
            lblReportTitle.Font = font10;
            dtpBizDate.Font = font10;

            lvwList.Font = font10;
            lvwOrder.Font = font10;
            lvwPayment.Font = font10;

            btnView.Font = font10;
        }

        private void initialize_the()
        {
            if (mBizDate == "")
            {

            }
            else
            {
                dtpBizDate.Value = new DateTime(convert_number(mBizDate.Substring(0, 4)), convert_number(mBizDate.Substring(4, 2)), convert_number(mBizDate.Substring(6, 2)));
            }

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            thisBizDt = dtpBizDate.Value.ToString("yyyyMMdd");

            lvwList.Items.Clear();
            lvwOrder.Items.Clear();
            lvwPayment.Items.Clear();


            String sUrl = "payment?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&isCancel=";
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["payments"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();

                        lvItem.Tag = arr[i]["theNo"].ToString();
                        lvItem.Text = arr[i]["billNo"].ToString();

                        lvItem.SubItems.Add(get_tran_type_name(arr[i]["tranType"].ToString()));

                        lvItem.SubItems.Add(arr[i]["posNo"].ToString());

                        lvItem.SubItems.Add(get_MMddHHmm(arr[i]["payDate"].ToString(), arr[i]["payTime"].ToString()));

                        lvItem.SubItems.Add(get_pay_class_name(arr[i]["payClass"].ToString()));


                        String is_cash = "0";
                        String is_card = "0";
                        String is_point = "0";
                        String is_easy = "0";
                        String is_cert = "0";
                        String pay_keep = "";
                        if (convert_number(arr[i]["amountCash"].ToString()) > 0) is_cash = "1";
                        if (convert_number(arr[i]["amountCard"].ToString()) > 0) is_card = "1";
                        if (convert_number(arr[i]["amountPoint"].ToString()) > 0) is_point = "1";
                        if (convert_number(arr[i]["amountEasy"].ToString()) > 0) is_easy = "1";
                        if (convert_number(arr[i]["amountCert"].ToString()) > 0) is_cert = "1";
                        pay_keep = is_cash + is_card + is_point + is_easy + is_cert;
                        lvItem.SubItems.Add(get_pay_type_group_name(pay_keep));

                        lvItem.SubItems.Add((convert_number(arr[i]["dcAmount"].ToString())).ToString("N0"));
                        lvItem.SubItems.Add((convert_number(arr[i]["netAmount"].ToString())).ToString("N0"));


                        if (arr[i]["isCancel"].ToString() == "Y" | arr[i]["isCancel"].ToString() == "y")
                            lvItem.SubItems.Add("취소됨");
                        else if (arr[i]["isCancel"].ToString() == "0")
                            lvItem.SubItems.Add("취소중");
                        else
                            lvItem.SubItems.Add("");

                        lvItem.SubItems.Add(pay_keep);
                        lvItem.SubItems.Add(arr[i]["tranType"].ToString());



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
                else
                {
                    MessageBox.Show(mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
            }




        }

        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count <= 0)
            {
                return;
            }


            lvwOrder.Items.Clear();
            lvwPayment.Items.Clear();

            String tTheNo = lvwList.SelectedItems[0].Tag.ToString();
            String pay_keep = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(paykeep)].Text;
            String tran_type = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(trantype)].Text;


            // order
            String sUrl = "orderItem?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&theNo=" + tTheNo + "&tranType=" + tran_type;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orderItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        int cnt = convert_number(arr[i]["cnt"].ToString());
                        int amt = convert_number(arr[i]["amt"].ToString());
                        int option_amt = convert_number(arr[i]["optionAmt"].ToString());
                        int dc_amt = convert_number(arr[i]["dcAmount"].ToString());
                        int net_amt = ((amt + option_amt) * cnt) - dc_amt;
                        String dcr_des = arr[i]["dcrDes"].ToString();
                        String dcr_type = arr[i]["dcrType"].ToString();
                        String dcr_value = arr[i]["dcrValue"].ToString();

                        ListViewItem lvItem = new ListViewItem();
                        //lvItem.Text = (i + 1).ToString();
                        lvItem.Text = arr[i]["shopOrderNo"].ToString();
                        lvItem.SubItems.Add(arr[i]["goodsName"].ToString());
                        lvItem.SubItems.Add(amt.ToString("N0"));
                        lvItem.SubItems.Add(cnt.ToString("N0"));
                        lvItem.SubItems.Add(dc_amt.ToString("N0"));
                        lvItem.SubItems.Add(net_amt.ToString("N0"));

                        String memo = "";
                        if (dcr_type == "R")
                        {
                            memo += dcr_value + "%";
                        }
                        else if (dcr_type == "A")
                        {
                            memo += "₩" + dcr_value;
                        }

                        lvItem.SubItems.Add(memo);

                        lvwOrder.Items.Add(lvItem);

                        
                        // 옵션아이템 보기
                        if (arr[i]["optionNo"].ToString() != "")
                        {
                            sUrl = "orderOptionItem?siteId=" + mSiteId + "&optionNo=" + arr[i]["optionNo"].ToString();
                            if (mRequestGet(sUrl))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {
                                    String data2 = mObj["orderOptionItems"].ToString();
                                    JArray arr2 = JArray.Parse(data2);

                                    String t_option_name = "";

                                    for (int k = 0; k < arr2.Count; k++)
                                    {
                                        t_option_name += arr2[k]["optionItemName"].ToString() + " ";
                                    }

                                    ListViewItem lvItem2 = new ListViewItem();
                                    lvItem2.Text = "";
                                    lvItem2.SubItems.Add("- " + t_option_name);
                                    lvItem2.SubItems.Add(option_amt.ToString("N0"));
                                    lvItem2.SubItems.Add("");
                                    lvItem2.SubItems.Add("");
                                    lvItem2.SubItems.Add("");
                                    lvItem2.SubItems.Add("");

                                    lvwOrder.Items.Add(lvItem2);

                                }
                            }
                        }

                    }
                }
                else
                {
                    MessageBox.Show("데이터 오류. orderItem\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orderItem\n\n" + mErrorMsg, "thepos");
                return;
            }




            // payment

            int seq_no = 0;


            String pay_keep_cash = pay_keep.Substring(0, 1);
            String pay_keep_card = pay_keep.Substring(1, 1);
            String pay_keep_point = pay_keep.Substring(2, 1);
            String pay_keep_easy = pay_keep.Substring(3, 1);
            String pay_keep_cert = pay_keep.Substring(4, 1);


            if (pay_keep_cash == "1")
            {
                sUrl = "paymentCash?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&theNo=" + tTheNo + "&tranType=" + tran_type;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCashs"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            ListViewItem lvItem = new ListViewItem();

                            lvItem.Text = (++seq_no).ToString();
                            lvItem.SubItems.Add(get_tran_type_name(arr[i]["tranType"].ToString()));
                            lvItem.SubItems.Add(get_pay_type_name(arr[i]["payType"].ToString()));

                            lvItem.SubItems.Add(convert_number(arr[i]["amount"].ToString()).ToString("N0"));

                            lvItem.SubItems.Add(arr[i]["issuedMethodNo"].ToString());
                            lvItem.SubItems.Add(get_receipt_type_name(arr[i]["receiptType"].ToString()));

                            lvItem.SubItems.Add("");
                            lvItem.SubItems.Add(arr[i]["authNo"].ToString());

                            if (arr[i]["isCancel"].ToString() == "Y" | arr[i]["isCancel"].ToString() == "y")
                                lvItem.SubItems.Add("취소됨");
                            else if (arr[i]["isCancel"].ToString() == "0")
                                lvItem.SubItems.Add("취소중");
                            else
                                lvItem.SubItems.Add("");


                            lvwPayment.Items.Add(lvItem);
                        }
                    }
                    else
                    {
                        MessageBox.Show("데이터 오류. paymentCash\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. paymentCash\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }

            if (pay_keep_card == "1")
            {
                sUrl = "paymentCard?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&theNo=" + tTheNo + "&tranType=" + tran_type;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCards"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            ListViewItem lvItem = new ListViewItem();
                            lvItem.Text = (++seq_no).ToString();
                            lvItem.SubItems.Add(get_tran_type_name(arr[i]["tranType"].ToString()));
                            lvItem.SubItems.Add(get_pay_type_name(arr[i]["payType"].ToString()));
                            lvItem.SubItems.Add(convert_number(arr[i]["amount"].ToString()).ToString("N0"));
                            lvItem.SubItems.Add(arr[i]["cardNo"].ToString());

                            String temp = "";
                            if (arr[i]["install"].ToString() == "00")
                            {
                                temp = "일시불";
                            }
                            else
                            {
                                temp = arr[i]["install"].ToString() + "개월";
                            }

                            lvItem.SubItems.Add(temp);

                            lvItem.SubItems.Add(arr[i]["cardName"].ToString());
                            lvItem.SubItems.Add(arr[i]["authNo"].ToString());

                            if (arr[i]["isCancel"].ToString() == "Y" | arr[i]["isCancel"].ToString() == "y")
                                lvItem.SubItems.Add("취소됨");
                            else if (arr[i]["isCancel"].ToString() == "0")
                                lvItem.SubItems.Add("취소중");
                            else
                                lvItem.SubItems.Add("");

                            lvwPayment.Items.Add(lvItem);
                        }
                    }
                    else
                    {
                        MessageBox.Show("데이터 오류. paymentCard\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. paymentCard\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            if (pay_keep_easy == "1")
            {
                sUrl = "paymentEasy?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&theNo=" + tTheNo + "&tranType=" + tran_type;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentEasys"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            ListViewItem lvItem = new ListViewItem();
                            lvItem.Text = (++seq_no).ToString();
                            lvItem.SubItems.Add(get_tran_type_name(arr[i]["tranType"].ToString()));
                            lvItem.SubItems.Add(get_pay_type_name(arr[i]["payType"].ToString()));
                            lvItem.SubItems.Add(convert_number(arr[i]["amount"].ToString()).ToString("N0"));
                            lvItem.SubItems.Add(arr[i]["cardNo"].ToString());

                            String temp = "";
                            if (arr[i]["install"].ToString() == "00")
                            {
                                temp = "일시불";
                            }
                            else
                            {
                                temp = arr[i]["install"].ToString() + "개월";
                            }

                            lvItem.SubItems.Add(temp);

                            lvItem.SubItems.Add(arr[i]["cardName"].ToString());
                            lvItem.SubItems.Add(arr[i]["authNo"].ToString());

                            if (arr[i]["isCancel"].ToString() == "Y" | arr[i]["isCancel"].ToString() == "y")
                                lvItem.SubItems.Add("취소됨");
                            else if (arr[i]["isCancel"].ToString() == "0")
                                lvItem.SubItems.Add("취소중");
                            else
                                lvItem.SubItems.Add("");

                            lvwPayment.Items.Add(lvItem);
                        }
                    }
                    else
                    {
                        MessageBox.Show("데이터 오류, paymentEasy\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. paymentEasy\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }

            if (pay_keep_point == "1")
            {
                sUrl = "paymentPoint?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&theNo=" + tTheNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentPoints"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            ListViewItem lvItem = new ListViewItem();
                            lvItem.Text = (++seq_no).ToString();
                            lvItem.SubItems.Add("");
                            lvItem.SubItems.Add(get_pay_type_name(arr[i]["payType"].ToString()));
                            lvItem.SubItems.Add(convert_number(arr[i]["amount"].ToString()).ToString("N0"));
                            lvItem.SubItems.Add(arr[i]["ticketNo"].ToString());
                            lvItem.SubItems.Add("");
                            lvItem.SubItems.Add("");
                            lvItem.SubItems.Add(arr[i]["usageNo"].ToString());

                            if (arr[i]["isCancel"].ToString() == "Y" | arr[i]["isCancel"].ToString() == "y")
                                lvItem.SubItems.Add("취소됨");
                            else if (arr[i]["isCancel"].ToString() == "0")
                                lvItem.SubItems.Add("취소중");
                            else
                                lvItem.SubItems.Add("");

                            lvwPayment.Items.Add(lvItem);
                        }
                    }
                    else
                    {
                        MessageBox.Show("데이터 오류, paymentEasy\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. paymentEasy\n\n" + mErrorMsg, "thepos");
                    return;
                }

            }


            if (pay_keep_cert == "1")
            {
                sUrl = "paymentCert?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&theNo=" + tTheNo + "&tranType=" + tran_type;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCerts"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            ListViewItem lvItem = new ListViewItem();
                            lvItem.Text = (++seq_no).ToString();
                            lvItem.SubItems.Add(get_tran_type_name(arr[i]["tranType"].ToString()));
                            lvItem.SubItems.Add(get_pay_type_name(arr[i]["payType"].ToString()));
                            lvItem.SubItems.Add(convert_number(arr[i]["amount"].ToString()).ToString("N0"));
                            lvItem.SubItems.Add(arr[i]["couponNo"].ToString());
                            lvItem.SubItems.Add("");
                            lvItem.SubItems.Add(arr[i]["vanCode"].ToString());
                            lvItem.SubItems.Add("");

                            if (arr[i]["isCancel"].ToString() == "Y" | arr[i]["isCancel"].ToString() == "y")
                                lvItem.SubItems.Add("취소됨");
                            else if (arr[i]["isCancel"].ToString() == "0")
                                lvItem.SubItems.Add("취소중");
                            else
                                lvItem.SubItems.Add("");

                            lvwPayment.Items.Add(lvItem);
                        }
                    }
                    else
                    {
                        MessageBox.Show("데이터 오류, paymentEasy\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. paymentEasy\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }

        }
    }
}
