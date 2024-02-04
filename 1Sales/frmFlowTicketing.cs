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
        public frmFlowTicketing()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();
        }

        private void initialize_font()
        {
            lblTitle.Font = font10;
            btnClose.Font = font12;

            lblBusinessTitle.Font = font10;
            dtBusiness.Font = font10;

            btnView.Font = font10;
            lvwList.Font = font10;

            btnTicketReact.Font = font10;

        }
        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwList.SmallImageList = imgList;
            
            dtBusiness.Value = new DateTime(convert_number(mBizDate.Substring(0,4)), convert_number(mBizDate.Substring(4,2)), convert_number(mBizDate.Substring(6,2)));


            if (mTicketMedia == "RF")  // 띠지BC   팔찌RF
            {
                btnTicketReact.Text = "팔찌등록";
            }
            else
            {
                // 띠지는 디폴트
                btnTicketReact.Text = "띠지출력";
            }



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmFlowTicketing_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSales.ConsoleEnable();

            mPanelMiddle.Visible = false;
            mPanelMiddle.Controls.Clear();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            lvwList.Items.Clear();

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
                        //String bangle_no = arr[i]["bangleNo"].ToString(); 

                        if (tStat == "0") tStat = "접수";
                        else if (tStat == "1") tStat = "발권";
                        else if (tStat == "2") tStat = "충전";
                        else if (tStat == "3") tStat = "사용중";
                        else if (tStat == "4") tStat = "정산중";
                        else if (tStat == "9") tStat = "정산완료";

                        item.Text = tStat;


                        item.SubItems.Add(get_goods_name(arr[i]["goodsCode"].ToString()));
                        item.SubItems.Add(ticketing_dt.Substring(4, 2) + "-" +
                                          ticketing_dt.Substring(6, 2) + " " +
                                          ticketing_dt.Substring(8, 2) + ":" +
                                          ticketing_dt.Substring(10, 2));

                        item.SubItems.Add(ticket_no.Substring(14, 6) + "-" + ticket_no.Substring(20, 2));
                        
                        item.SubItems.Add("");  // bangle_no 들어갈 자리
                        item.SubItems.Add(arr[i]["goodsCode"].ToString());

                        item.Tag = ticket_no;

                        lvwList.Items.Add(item);

                    }

                }
                else
                {
                    MessageBox.Show("티켓데이터 오류.\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. ticketFlow\n\n" + mErrorMsg, "thepos");
            }


        }

        private void btnTicketReact_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count < 1)
            {
                return;
            }




            if (mTicketMedia == "RF")  // 띠지BC   팔찌RF
            {
                // 팔찌등록




            }
            else
            {
                // 티켓출력

                String ticket_no = lvwList.SelectedItems[0].Tag.ToString();
                String goods_code = lvwList.SelectedItems[0].SubItems[5].Text.ToString();

                print_ticket(ticket_no, goods_code);

            }
        }
    }
}
