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
using Newtonsoft.Json.Linq;

namespace thepos
{
    public partial class frmFlowTicketing : Form
    {
        TextBox saveKeyDisplay;


        public frmFlowTicketing()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();
        }

        private void initialize_font()
        {
            lblTitle.Font = font12;
            btnClose.Font = font12;

            lblBusinessTitle.Font = font9;
            dtBusiness.Font = font10;

            btnView.Font = font10;
            lvwFlow.Font = font10;


        }
        private void initialize_the()
        {
            //dtBusiness.Value = DateTime.Now;


            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwFlow.SmallImageList = imgList;

            saveKeyDisplay = mTbKeyDisplayController;

            dtBusiness.Value = new DateTime(convert_number(mBizDate.Substring(0,4)), convert_number(mBizDate.Substring(4,2)), convert_number(mBizDate.Substring(6,2)));

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFlowTicketing_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSales.ConsoleEnable();
            mTbKeyDisplayController = saveKeyDisplay;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            lvwFlow.Items.Clear();

            String biz_date = dtBusiness.Value.ToString("yyyyMMdd");
            
            String sUrl = "ticketFlow?siteId=" + mSiteId + "&bizDt=" + biz_date;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["ticketFlows"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        String ticket_no = arr[i]["ticketNo"].ToString();
                        String tStat = arr[i]["flowStep"].ToString();
                        String ticketing_dt = arr[i]["ticketingDt"].ToString();

                        if (tStat == "0") tStat = "접수";
                        else if (tStat == "1") tStat = "발권";
                        else if (tStat == "2") tStat = "충전";
                        else if (tStat == "3") tStat = "사용중";
                        else if (tStat == "4") tStat = "정산완료";

                        item.Text = tStat;
                        item.SubItems.Add(get_goods_name(arr[i]["itemCode"].ToString()));
                        item.SubItems.Add(ticket_no.Substring(14, 4) + "-" + ticket_no.Substring(18, 3));
                        item.SubItems.Add(ticketing_dt.Substring(8, 2) + ":" +
                                          ticketing_dt.Substring(10, 2) + ":" +
                                          ticketing_dt.Substring(12, 2));

                        item.Tag = ticket_no;

                        lvwFlow.Items.Add(item);

                    }

                }
                else
                {
                    MessageBox.Show("티켓데이터 오류.\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. ticketFlow\n\n" + mErrorMsg, "thepos");
            }






            for (int i = 0; i < mTicketFlowList.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = mTicketFlowList[i].ticket_no;

                String tStat = "";

                if (mTicketFlowList[i].flow_step == "0") tStat = "접수";
                else if (mTicketFlowList[i].flow_step == "1") tStat = "발권";
                else if (mTicketFlowList[i].flow_step == "2") tStat = "충전";
                else if (mTicketFlowList[i].flow_step == "3") tStat = "사용중";
                else if (mTicketFlowList[i].flow_step == "4") tStat = "정산완료";

                item.Text = tStat;
                item.SubItems.Add(get_goods_name(mTicketFlowList[i].goods_code));
                item.SubItems.Add(mTicketFlowList[i].ticket_no.Substring(14,4) + "-" + mTicketFlowList[i].ticket_no.Substring(18,3));
                item.SubItems.Add(mTicketFlowList[i].ticketing_dt.Substring(8, 2) + ":" +
                                  mTicketFlowList[i].ticketing_dt.Substring(10, 2) + ":" +
                                  mTicketFlowList[i].ticketing_dt.Substring(12, 2));

                lvwFlow.Items.Add(item);
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

    }
}
