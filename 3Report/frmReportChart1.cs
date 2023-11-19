using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static thepos.thePos;

namespace thepos
{
    public partial class frmReportChart1 : Form
    {
        double[] day_amount = new double[32];  // 1 ~ 31


        public frmReportChart1()
        {
            InitializeComponent();


            initialize_font();
            initialize_the();

            viewMonth();

        }


        private void initialize_font()
        {
            lblReportTitle.Font = font10;
            btnPrev.Font = font8;
            lblYYYYMM.Font = font10;
            btnNext.Font = font8;

            lblPosNoTitle.Font = font10;
            cbPosNo.Font = font10;

            lblShopTitle.Font = font10;
            cbShop.Font = font10;

            btnView.Font = font10;



        }

        private void initialize_the()
        {
            

            String yyyymm = get_today_date().Substring(0, 6);

            lblYYYYMM.Text = yyyymm.Substring(0, 4) + "-" + yyyymm.Substring(4, 2);

            cbPosNo.Items.Clear();
            cbPosNo.Items.Add("");
            for (int i = 0; i < mPosNoList.Length; i++)
            {
                cbPosNo.Items.Add(mPosNoList[i]);
            }
            cbPosNo.SelectedIndex = 0;


            cbShop.Items.Clear();
            cbShop.Items.Add("");
            for (int i = 0; i < mShop.Length; i++)
            {
                cbShop.Items.Add(mShop[i].shop_name);
            }
            cbShop.SelectedIndex = 0;



        }

        private void btnView_Click(object sender, EventArgs e)
        {
            viewMonth();

        }


        void viewMonth()
        {
            String yyyymm = lblYYYYMM.Text.Replace("-", ""); ;

            String pos_no = cbPosNo.Text; ;

            String shop_code = "";

            if (cbShop.SelectedIndex > 0)
            {
                shop_code = mShop[cbShop.SelectedIndex - 1].shop_code;
            }

            for (int i = 0;i < day_amount.Length;i++)
            {
                day_amount[i] = 0;
            }
            

            String sUrl = "";

            if (shop_code != "")
                sUrl = "reportMonthShop?siteId=" + mSiteId + "&bizDtMon=" + yyyymm + "&shopCode=" + shop_code;
            else
                sUrl = "reportMonthPos?siteId=" + mSiteId + "&bizDtMon=" + yyyymm + "&posNo=" + pos_no;


            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["monthArr"].ToString();
                    JArray arr = JArray.Parse(data);


                    for (int i = 0; i < arr.Count; i++)
                    {
                        int day_idx = convert_number(arr[i]["bizDt"].ToString().Substring(6, 2));
                        day_amount[day_idx] = convert_number(arr[i]["netAmount"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("상품정보 오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }



            // 1일 구하기
            DateTime MonthFirstDay = Convert.ToDateTime(lblYYYYMM.Text + "-01");


            //말일구하기
            DateTime MonthLastDay = MonthFirstDay.AddMonths(1).AddDays(-1);



            int last_date = convert_number(MonthLastDay.ToString("dd"));



            chart.Series[0].Points.Clear();

            for (int i = 1; i <= last_date; i++)
            {
                DataPoint dp = new DataPoint();

                dp.XValue = i;
                dp.YValues[0] = day_amount[i];

                chart.Series[0].Points.Add(dp);

            }



        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            DateTime CurrMonth = Convert.ToDateTime(lblYYYYMM.Text + "-01");

            DateTime PrevMonth = CurrMonth.AddMonths(-1);

            lblYYYYMM.Text = PrevMonth.ToString("yyyy-MM");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            DateTime CurrMonth = Convert.ToDateTime(lblYYYYMM.Text + "-01");

            DateTime NextMonth = CurrMonth.AddMonths(1);

            lblYYYYMM.Text = NextMonth.ToString("yyyy-MM");

        }

        private void cbPosNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPosNo.SelectedIndex > 0)
            {
                cbShop.SelectedIndex = 0;
            }
        }

        private void cbShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbShop.SelectedIndex > 0)
            {
                cbPosNo.SelectedIndex = 0;
            }
        }
    }
}
