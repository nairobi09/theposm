using Newtonsoft.Json.Linq;
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


namespace thepos
{
    public partial class frmCheckData : Form
    {
        public frmCheckData()
        {
            InitializeComponent();




        }

        private void btnView_Click(object sender, EventArgs e)
        {

            get_order();
            get_order_Item();
            get_order_option_Item();

            get_payment();
            get_payment_cash();
            get_payment_card();
            get_payment_easy();
            get_payment_point();
            get_payment_cert();
            get_ticket_flow();

        }


        private void get_order()
        {
            lvwOrder.Items.Clear();

            String sUrl = "orders?siteId=" + mSiteId + "&refNo=" + tbTheNo.Text;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orders"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["siteId"].ToString();
                        lvItem.SubItems.Add(arr[i]["posNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["bizDt"].ToString());
                        lvItem.SubItems.Add(arr[i]["theNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["refNo"].ToString());

                        lvItem.SubItems.Add(arr[i]["tranType"].ToString());
                        lvItem.SubItems.Add(arr[i]["orderDate"].ToString());
                        lvItem.SubItems.Add(arr[i]["orderTime"].ToString());
                        lvItem.SubItems.Add(arr[i]["cnt"].ToString());
                        lvItem.SubItems.Add(arr[i]["isCancel"].ToString());
                        lvwOrder.Items.Add(lvItem);
                    }
                }
            }
        }

        private void get_order_Item()
        {
            lvwOrderItem.Items.Clear();

            String sUrl = "orderItem?siteId=" + mSiteId + "&refNo=" + tbTheNo.Text;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orderItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["siteId"].ToString();
                        lvItem.SubItems.Add(arr[i]["posNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["bizDt"].ToString());
                        lvItem.SubItems.Add(arr[i]["theNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["refNo"].ToString());

                        lvItem.SubItems.Add(arr[i]["tranType"].ToString());
                        lvItem.SubItems.Add(arr[i]["orderDate"].ToString());
                        lvItem.SubItems.Add(arr[i]["orderTime"].ToString());
                        lvItem.SubItems.Add(arr[i]["goodsCode"].ToString());
                        lvItem.SubItems.Add(arr[i]["goodsName"].ToString());
                        lvItem.SubItems.Add(arr[i]["cnt"].ToString());
                        lvItem.SubItems.Add(arr[i]["amt"].ToString());
                        lvItem.SubItems.Add(arr[i]["ticketYn"].ToString());
                        lvItem.SubItems.Add(arr[i]["taxFree"].ToString());
                        lvItem.SubItems.Add(arr[i]["dcAmount"].ToString());
                        lvItem.SubItems.Add(arr[i]["dcrType"].ToString());
                        lvItem.SubItems.Add(arr[i]["dcrDes"].ToString());
                        lvItem.SubItems.Add(arr[i]["dcrValue"].ToString());
                        lvItem.SubItems.Add(arr[i]["payClass"].ToString());
                        lvItem.SubItems.Add(arr[i]["ticketNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["isCancel"].ToString());

                        lvItem.SubItems.Add(arr[i]["shopCode"].ToString());
                        lvItem.SubItems.Add(arr[i]["shopOrderNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionNo"].ToString());

                        lvwOrderItem.Items.Add(lvItem);
                    }
                }
            }
        }

        private void get_order_option_Item()
        {
            lvwOrderIOptiontem.Items.Clear();

            String sUrl = "orderOptionItem?siteId=" + mSiteId + "&refNo=" + tbTheNo.Text;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orderOptionItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["siteId"].ToString();
                        lvItem.SubItems.Add(arr[i]["posNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["bizDt"].ToString());
                        lvItem.SubItems.Add(arr[i]["theNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["refNo"].ToString());

                        lvItem.SubItems.Add(arr[i]["optionNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["orderDate"].ToString());
                        lvItem.SubItems.Add(arr[i]["orderTime"].ToString());
                        lvItem.SubItems.Add(arr[i]["goodsCode"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionCode"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionItemNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionItemName"].ToString());
                        lvItem.SubItems.Add(arr[i]["cnt"].ToString());
                        lvItem.SubItems.Add(arr[i]["amt"].ToString());
                        lvItem.SubItems.Add(arr[i]["isCancel"].ToString());

                        lvwOrderIOptiontem.Items.Add(lvItem);
                    }
                }
            }
        }

        private void get_payment()
        {
            lvwPayment.Items.Clear();

            String sUrl = "payment?siteId=" + mSiteId + "&refNo=" + tbTheNo.Text;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["payments"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["siteId"].ToString();
                        lvItem.SubItems.Add(arr[i]["posNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["bizDt"].ToString());
                        lvItem.SubItems.Add(arr[i]["theNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["refNo"].ToString());

                        lvItem.SubItems.Add(arr[i]["tranType"].ToString());
                        lvItem.SubItems.Add(arr[i]["payDate"].ToString());
                        lvItem.SubItems.Add(arr[i]["payTime"].ToString());
                        lvItem.SubItems.Add(arr[i]["payClass"].ToString());
                        lvItem.SubItems.Add(arr[i]["billNo"].ToString());

                        lvItem.SubItems.Add(arr[i]["netAmount"].ToString());
                        lvItem.SubItems.Add(arr[i]["amountCash"].ToString());
                        lvItem.SubItems.Add(arr[i]["amountCard"].ToString());
                        lvItem.SubItems.Add(arr[i]["amountEasy"].ToString());
                        lvItem.SubItems.Add(arr[i]["amountPoint"].ToString());
                        lvItem.SubItems.Add(arr[i]["amountCert"].ToString());

                        lvItem.SubItems.Add(arr[i]["dcAmount"].ToString());
                        lvItem.SubItems.Add(arr[i]["isCancel"].ToString());

                        lvwPayment.Items.Add(lvItem);
                    }
                }
            }
        }

        private void get_payment_cash()
        {
            lvwPaymentCash.Items.Clear();

            String sUrl = "paymentCash?siteId=" + mSiteId + "&refNo=" + tbTheNo.Text;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["paymentCashs"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["siteId"].ToString();
                        lvItem.SubItems.Add(arr[i]["posNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["bizDt"].ToString());
                        lvItem.SubItems.Add(arr[i]["theNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["refNo"].ToString());

                        lvItem.SubItems.Add(arr[i]["payDate"].ToString());
                        lvItem.SubItems.Add(arr[i]["payTime"].ToString());
                        lvItem.SubItems.Add(arr[i]["payType"].ToString());
                        lvItem.SubItems.Add(arr[i]["tranType"].ToString());
                        lvItem.SubItems.Add(arr[i]["payClass"].ToString());
                        lvItem.SubItems.Add(arr[i]["ticketNo"].ToString());

                        lvItem.SubItems.Add(arr[i]["paySeq"].ToString());
                        lvItem.SubItems.Add(arr[i]["tranDate"].ToString());
                        lvItem.SubItems.Add(arr[i]["amount"].ToString());
                        lvItem.SubItems.Add(arr[i]["receiptType"].ToString());
                        lvItem.SubItems.Add(arr[i]["issuedMethodNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["authNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["tranSerial"].ToString());

                        lvItem.SubItems.Add(arr[i]["isCancel"].ToString());
                        lvItem.SubItems.Add(arr[i]["vanCode"].ToString());

                        lvwPaymentCash.Items.Add(lvItem);
                    }
                }
            }
        }

        private void get_payment_card()
        {
            lvwPaymentCard.Items.Clear();

            String sUrl = "paymentCard?siteId=" + mSiteId + "&refNo=" + tbTheNo.Text;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["paymentCards"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["siteId"].ToString();
                        lvItem.SubItems.Add(arr[i]["posNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["bizDt"].ToString());
                        lvItem.SubItems.Add(arr[i]["theNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["refNo"].ToString());

                        lvItem.SubItems.Add(arr[i]["payDate"].ToString());
                        lvItem.SubItems.Add(arr[i]["payTime"].ToString());
                        lvItem.SubItems.Add(arr[i]["payType"].ToString());
                        lvItem.SubItems.Add(arr[i]["tranType"].ToString());
                        lvItem.SubItems.Add(arr[i]["payClass"].ToString());
                        lvItem.SubItems.Add(arr[i]["ticketNo"].ToString());

                        lvItem.SubItems.Add(arr[i]["paySeq"].ToString());
                        lvItem.SubItems.Add(arr[i]["tranDate"].ToString());
                        lvItem.SubItems.Add(arr[i]["amount"].ToString());

                        lvItem.SubItems.Add(arr[i]["taxAmount"].ToString());
                        lvItem.SubItems.Add(arr[i]["freeAmount"].ToString());
                        lvItem.SubItems.Add(arr[i]["serviceAmt"].ToString());
                        lvItem.SubItems.Add(arr[i]["tax"].ToString());
                        lvItem.SubItems.Add(arr[i]["install"].ToString());
                        lvItem.SubItems.Add(arr[i]["authNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["cardNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["cardName"].ToString());
                        lvItem.SubItems.Add(arr[i]["isuCode"].ToString());
                        lvItem.SubItems.Add(arr[i]["acqCode"].ToString());
                        lvItem.SubItems.Add(arr[i]["merchantNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["tranSerial"].ToString());
                        lvItem.SubItems.Add(arr[i]["signPath"].ToString());
                        lvItem.SubItems.Add(arr[i]["giftChange"].ToString());

                        lvItem.SubItems.Add(arr[i]["isCancel"].ToString());
                        lvItem.SubItems.Add(arr[i]["vanCode"].ToString());

                        lvwPaymentCard.Items.Add(lvItem);
                    }
                }
            }
        }

        private void get_payment_easy()
        {
            lvwPaymentEasy.Items.Clear();

            String sUrl = "paymentEasy?siteId=" + mSiteId + "&refNo=" + tbTheNo.Text;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["paymentEasys"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["siteId"].ToString();
                        lvItem.SubItems.Add(arr[i]["posNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["bizDt"].ToString());
                        lvItem.SubItems.Add(arr[i]["theNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["refNo"].ToString());

                        lvItem.SubItems.Add(arr[i]["payDate"].ToString());
                        lvItem.SubItems.Add(arr[i]["payTime"].ToString());
                        lvItem.SubItems.Add(arr[i]["payType"].ToString());
                        lvItem.SubItems.Add(arr[i]["tranType"].ToString());
                        lvItem.SubItems.Add(arr[i]["payClass"].ToString());
                        lvItem.SubItems.Add(arr[i]["ticketNo"].ToString());

                        lvItem.SubItems.Add(arr[i]["paySeq"].ToString());
                        lvItem.SubItems.Add(arr[i]["tranDate"].ToString());
                        lvItem.SubItems.Add(arr[i]["amount"].ToString());

                        lvItem.SubItems.Add(arr[i]["taxAmount"].ToString());
                        lvItem.SubItems.Add(arr[i]["freeAmount"].ToString());
                        lvItem.SubItems.Add(arr[i]["serviceAmt"].ToString());
                        lvItem.SubItems.Add(arr[i]["tax"].ToString());
                        lvItem.SubItems.Add(arr[i]["install"].ToString());
                        lvItem.SubItems.Add(arr[i]["authNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["cardNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["cardName"].ToString());
                        lvItem.SubItems.Add(arr[i]["isuCode"].ToString());
                        lvItem.SubItems.Add(arr[i]["acqCode"].ToString());
                        lvItem.SubItems.Add(arr[i]["merchantNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["tranSerial"].ToString());
                        lvItem.SubItems.Add(arr[i]["signPath"].ToString());
                        lvItem.SubItems.Add(arr[i]["giftChange"].ToString());

                        lvItem.SubItems.Add(arr[i]["isCancel"].ToString());
                        lvItem.SubItems.Add(arr[i]["vanCode"].ToString());
                        lvItem.SubItems.Add(arr[i]["payType2"].ToString());

                        lvwPaymentEasy.Items.Add(lvItem);
                    }
                }
            }
        }
        private void get_payment_point()
        {
            lvwPaymentPoint.Items.Clear();

            String sUrl = "paymentPoint?siteId=" + mSiteId + "&refNo=" + tbTheNo.Text;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["paymentPoints"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["siteId"].ToString();
                        lvItem.SubItems.Add(arr[i]["posNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["bizDt"].ToString());
                        lvItem.SubItems.Add(arr[i]["theNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["refNo"].ToString());

                        lvItem.SubItems.Add(arr[i]["payDate"].ToString());
                        lvItem.SubItems.Add(arr[i]["payTime"].ToString());
                        lvItem.SubItems.Add(arr[i]["payType"].ToString());
                        lvItem.SubItems.Add(arr[i]["payClass"].ToString());
                        lvItem.SubItems.Add(arr[i]["ticketNo"].ToString());

                        lvItem.SubItems.Add(arr[i]["usageNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["amount"].ToString());
                        lvItem.SubItems.Add(arr[i]["isCancel"].ToString());

                        lvwPaymentPoint.Items.Add(lvItem);
                    }
                }
            }
        }

        private void get_payment_cert()
        {
            lvwPaymentCert.Items.Clear();

            String sUrl = "paymentCert?siteId=" + mSiteId + "&refNo=" + tbTheNo.Text;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["paymentCerts"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["siteId"].ToString();
                        lvItem.SubItems.Add(arr[i]["posNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["bizDt"].ToString());
                        lvItem.SubItems.Add(arr[i]["theNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["refNo"].ToString());

                        lvItem.SubItems.Add(arr[i]["payDate"].ToString());
                        lvItem.SubItems.Add(arr[i]["payTime"].ToString());
                        lvItem.SubItems.Add(arr[i]["payType"].ToString());
                        lvItem.SubItems.Add(arr[i]["tranType"].ToString());
                        lvItem.SubItems.Add(arr[i]["payClass"].ToString());
                        lvItem.SubItems.Add(arr[i]["ticketNo"].ToString());

                        lvItem.SubItems.Add(arr[i]["paySeq"].ToString());
                        lvItem.SubItems.Add(arr[i]["tranDate"].ToString());
                        lvItem.SubItems.Add(arr[i]["amount"].ToString());
                        lvItem.SubItems.Add(arr[i]["couponNo"].ToString());

                        lvItem.SubItems.Add(arr[i]["isCancel"].ToString());
                        lvItem.SubItems.Add(arr[i]["vanCode"].ToString());

                        lvwPaymentCert.Items.Add(lvItem);
                    }
                }
            }
        }

        private void get_ticket_flow()
        {
            lvwTicketFlow.Items.Clear();

            String sUrl = "ticketFlow?siteId=" + mSiteId + "&refNo=" + tbTheNo.Text;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["ticketFlows"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["siteId"].ToString();
                        lvItem.SubItems.Add(arr[i]["bizDt"].ToString());
                        lvItem.SubItems.Add(arr[i]["theNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["refNo"].ToString());

                        lvItem.SubItems.Add(arr[i]["ticketNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["ticketingDt"].ToString());
                        lvItem.SubItems.Add(arr[i]["chargeDt"].ToString());
                        lvItem.SubItems.Add(arr[i]["settlementDt"].ToString());
                        lvItem.SubItems.Add(arr[i]["pointChargeCnt"].ToString());
                        lvItem.SubItems.Add(arr[i]["pointUsageCnt"].ToString());
                        lvItem.SubItems.Add(arr[i]["pointCharge"].ToString());
                        lvItem.SubItems.Add(arr[i]["pointUsage"].ToString());
                        lvItem.SubItems.Add(arr[i]["settlePointCharge"].ToString());
                        lvItem.SubItems.Add(arr[i]["settlePointUsage"].ToString());
                        lvItem.SubItems.Add(arr[i]["goodsCode"].ToString());
                        lvItem.SubItems.Add(arr[i]["flowStep"].ToString());
                        lvItem.SubItems.Add(arr[i]["lockerNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["openLocker"].ToString());


                        lvwTicketFlow.Items.Add(lvItem);
                    }
                }
            }
        }


    }
}
