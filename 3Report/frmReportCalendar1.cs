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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static thepos.thePos;

namespace thepos
{
    public partial class frmReportCalendar1 : Form
    {

        Panel[] panelPixel = new Panel[43];
        Label[] lblDate = new Label[43];
        Label[] lblAmt = new Label[43];

        int[] day_amount = new int[32];  // 1 ~ 31


        public frmReportCalendar1()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();

            viewMonth();

        }


        private void initialize_font()
        {
            lblReportTitle.Font = font10;
            btnPrev.Font = font10;
            lblYYYYMM.Font = font10;
            btnNext.Font = font10;

            lblPosNoTitle.Font = font10;
            cbPosNo.Font = font10;

            lblShopTitle.Font = font10;
            cbShop.Font = font10;

            btnView.Font = font10;



            d01.Font = font10; a01.Font = font10;
            d02.Font = font10; a02.Font = font10;
            d03.Font = font10; a03.Font = font10;
            d04.Font = font10; a04.Font = font10;
            d05.Font = font10; a05.Font = font10;
            d06.Font = font10; a06.Font = font10;
            d07.Font = font10; a07.Font = font10;
            d08.Font = font10; a08.Font = font10;
            d09.Font = font10; a09.Font = font10;
            d10.Font = font10; a10.Font = font10;

            d11.Font = font10; a11.Font = font10;
            d12.Font = font10; a12.Font = font10;
            d13.Font = font10; a13.Font = font10;
            d14.Font = font10; a14.Font = font10;
            d15.Font = font10; a15.Font = font10;
            d16.Font = font10; a16.Font = font10;
            d17.Font = font10; a17.Font = font10;
            d18.Font = font10; a18.Font = font10;
            d19.Font = font10; a19.Font = font10;
            d20.Font = font10; a20.Font = font10;

            d21.Font = font10; a21.Font = font10;
            d22.Font = font10; a22.Font = font10;
            d23.Font = font10; a23.Font = font10;
            d24.Font = font10; a24.Font = font10;
            d25.Font = font10; a25.Font = font10;
            d26.Font = font10; a26.Font = font10;
            d27.Font = font10; a27.Font = font10;
            d28.Font = font10; a28.Font = font10;
            d29.Font = font10; a29.Font = font10;
            d30.Font = font10; a30.Font = font10;

            d31.Font = font10; a31.Font = font10;
            d32.Font = font10; a32.Font = font10;
            d33.Font = font10; a33.Font = font10;
            d34.Font = font10; a34.Font = font10;
            d35.Font = font10; a35.Font = font10;
            d36.Font = font10; a36.Font = font10;
            d37.Font = font10; a37.Font = font10;
            d38.Font = font10; a38.Font = font10;
            d39.Font = font10; a39.Font = font10;
            d40.Font = font10; a40.Font = font10;

            d41.Font = font10; a41.Font = font10;
            d42.Font = font10; a42.Font = font10;


            ra1.Font = font10;
            ra2.Font = font10;
            ra3.Font = font10;
            ra4.Font = font10;
            ra5.Font = font10;
            ra6.Font = font10;
            ra7.Font = font10;

            wa1.Font = font10;
            wa2.Font = font10;
            wa3.Font = font10;
            wa4.Font = font10;
            wa5.Font = font10;
            wa6.Font = font10;

            ma.Font = font10;



        }

        private void initialize_the()
        {
            panelPixel[01] = p01; lblDate[01] = d01; lblAmt[01] = a01;
            panelPixel[02] = p02; lblDate[02] = d02; lblAmt[02] = a02;
            panelPixel[03] = p03; lblDate[03] = d03; lblAmt[03] = a03;
            panelPixel[04] = p04; lblDate[04] = d04; lblAmt[04] = a04;
            panelPixel[05] = p05; lblDate[05] = d05; lblAmt[05] = a05;
            panelPixel[06] = p06; lblDate[06] = d06; lblAmt[06] = a06;
            panelPixel[07] = p07; lblDate[07] = d07; lblAmt[07] = a07;
            panelPixel[08] = p08; lblDate[08] = d08; lblAmt[08] = a08;
            panelPixel[09] = p09; lblDate[09] = d09; lblAmt[09] = a09;
            panelPixel[10] = p10; lblDate[10] = d10; lblAmt[10] = a10;

            panelPixel[11] = p11; lblDate[11] = d11; lblAmt[11] = a11;
            panelPixel[12] = p12; lblDate[12] = d12; lblAmt[12] = a12;
            panelPixel[13] = p13; lblDate[13] = d13; lblAmt[13] = a13;
            panelPixel[14] = p14; lblDate[14] = d14; lblAmt[14] = a14;
            panelPixel[15] = p15; lblDate[15] = d15; lblAmt[15] = a15;
            panelPixel[16] = p16; lblDate[16] = d16; lblAmt[16] = a16;
            panelPixel[17] = p17; lblDate[17] = d17; lblAmt[17] = a17;
            panelPixel[18] = p18; lblDate[18] = d18; lblAmt[18] = a18;
            panelPixel[19] = p19; lblDate[19] = d19; lblAmt[19] = a19;
            panelPixel[20] = p20; lblDate[20] = d20; lblAmt[20] = a20;

            panelPixel[21] = p21; lblDate[21] = d21; lblAmt[21] = a21;
            panelPixel[22] = p22; lblDate[22] = d22; lblAmt[22] = a22;
            panelPixel[23] = p23; lblDate[23] = d23; lblAmt[23] = a23;
            panelPixel[24] = p24; lblDate[24] = d24; lblAmt[24] = a24;
            panelPixel[25] = p25; lblDate[25] = d25; lblAmt[25] = a25;
            panelPixel[26] = p26; lblDate[26] = d26; lblAmt[26] = a26;
            panelPixel[27] = p27; lblDate[27] = d27; lblAmt[27] = a27;
            panelPixel[28] = p28; lblDate[28] = d28; lblAmt[28] = a28;
            panelPixel[29] = p29; lblDate[29] = d29; lblAmt[29] = a29;
            panelPixel[30] = p30; lblDate[30] = d30; lblAmt[30] = a30;

            panelPixel[31] = p31; lblDate[31] = d31; lblAmt[31] = a31;
            panelPixel[32] = p32; lblDate[32] = d32; lblAmt[32] = a32;
            panelPixel[33] = p33; lblDate[33] = d33; lblAmt[33] = a33;
            panelPixel[34] = p34; lblDate[34] = d34; lblAmt[34] = a34;
            panelPixel[35] = p35; lblDate[35] = d35; lblAmt[35] = a35;
            panelPixel[36] = p36; lblDate[36] = d36; lblAmt[36] = a36;
            panelPixel[37] = p37; lblDate[37] = d37; lblAmt[37] = a37;
            panelPixel[38] = p38; lblDate[38] = d38; lblAmt[38] = a38;
            panelPixel[39] = p39; lblDate[39] = d39; lblAmt[39] = a39;
            panelPixel[40] = p40; lblDate[40] = d40; lblAmt[40] = a40;

            panelPixel[41] = p41; lblDate[41] = d41; lblAmt[41] = a41;
            panelPixel[42] = p42; lblDate[42] = d42; lblAmt[42] = a42;



            String yyyymm = get_today_date().Substring(0, 6);

            lblYYYYMM.Text = yyyymm.Substring(0, 4) + "-" + yyyymm.Substring(4,2);

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



            for (int i = 1; i <= 31; i++)
            {
                day_amount[i] = 0;
            }




            String sUrl = "";

            if (shop_code != "")
                sUrl = "reportMonthShop?siteId=" + mSiteId + "&bizDtMon=" + yyyymm + "&shopCode=" + shop_code + "&runningBizDt=" + mBizDate;
            else
                sUrl = "reportMonthPos?siteId=" + mSiteId + "&bizDtMon=" + yyyymm + "&posNo=" + pos_no + "&runningBizDt=" + mBizDate;




            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["monthArr"].ToString();
                    JArray arr = JArray.Parse(data);


                    for (int i = 0; i < arr.Count; i++)
                    {
                        int day_idx = convert_number(arr[i]["bizDt"].ToString().Substring(6,2));
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


            int start_col = 0;


            int sum_ma = 0;


            if (MonthFirstDay.DayOfWeek == DayOfWeek.Sunday) start_col = 1;
            else if (MonthFirstDay.DayOfWeek == DayOfWeek.Monday) start_col = 2;
            else if (MonthFirstDay.DayOfWeek == DayOfWeek.Tuesday) start_col = 3;
            else if (MonthFirstDay.DayOfWeek == DayOfWeek.Wednesday) start_col = 4;
            else if (MonthFirstDay.DayOfWeek == DayOfWeek.Thursday) start_col = 5;
            else if (MonthFirstDay.DayOfWeek == DayOfWeek.Friday) start_col = 6;
            else if (MonthFirstDay.DayOfWeek == DayOfWeek.Saturday) start_col = 7;



            int last_date = convert_number(MonthLastDay.ToString("dd"));



            for (int i = 1; i < start_col; i++)
            {
                panelPixel[i].Visible = false;
                lblAmt[i].Tag = 0;
            }

            Random rand = new Random();

            for (int i = start_col; i < last_date + start_col; i++)
            {
                panelPixel[i].Visible = true;
                lblDate[i].Text = (i - start_col + 1) + "";

                lblAmt[i].Text = (day_amount[i - start_col + 1]).ToString("N0");
                lblAmt[i].Tag = day_amount[i - start_col + 1];

                sum_ma += day_amount[i - start_col + 1];


            }

            for (int i = last_date + start_col; i <= 42; i++)
            {
                panelPixel[i].Visible = false;
                lblAmt[i].Tag = 0;
            }


            //
            int ws = 0;
            for (int i = 1; i <= 7; i++)
            {
                ws += convert_number(lblAmt[i].Tag.ToString());
            }
            wa1.Text = ws.ToString("N0");

            ws = 0;
            for (int i = 8; i <= 14; i++)
            {
                ws += convert_number(lblAmt[i].Tag.ToString());
            }
            wa2.Text = ws.ToString("N0");

            ws = 0;
            for (int i = 15; i <= 21; i++)
            {
                ws += convert_number(lblAmt[i].Tag.ToString());
            }
            wa3.Text = ws.ToString("N0");

            ws = 0;
            for (int i = 22; i <= 28; i++)
            {
                ws += convert_number(lblAmt[i].Tag.ToString());
            }
            wa4.Text = ws.ToString("N0");

            ws = 0;
            for (int i = 29; i <= 35; i++)
            {
                ws += convert_number(lblAmt[i].Tag.ToString());
            }
            wa5.Text = ws.ToString("N0");

            ws = 0;
            for (int i = 36; i <= 42; i++)
            {
                ws += convert_number(lblAmt[i].Tag.ToString());
            }
            wa6.Text = ws.ToString("N0");


            //
            int rs = 0;
            for (int i = 1; i <= 6; i++)
            {
                rs += convert_number(lblAmt[(i - 1) * 7 + 1].Tag.ToString());
            }
            ra1.Text = rs.ToString("N0");

            rs = 0;
            for (int i = 1; i <= 6; i++)
            {
                rs += convert_number(lblAmt[(i - 1) * 7 + 2].Tag.ToString());
            }
            ra2.Text = rs.ToString("N0");

            rs = 0;
            for (int i = 1; i <= 6; i++)
            {
                rs += convert_number(lblAmt[(i - 1) * 7 + 3].Tag.ToString());
            }
            ra3.Text = rs.ToString("N0");

            rs = 0;
            for (int i = 1; i <= 6; i++)
            {
                rs += convert_number(lblAmt[(i - 1) * 7 + 4].Tag.ToString());
            }
            ra4.Text = rs.ToString("N0");

            rs = 0;
            for (int i = 1; i <= 6; i++)
            {
                rs += convert_number(lblAmt[(i - 1) * 7 + 5].Tag.ToString());
            }
            ra5.Text = rs.ToString("N0");

            rs = 0;
            for (int i = 1; i <= 6; i++)
            {
                rs += convert_number(lblAmt[(i - 1) * 7 + 6].Tag.ToString());
            }
            ra6.Text = rs.ToString("N0");

            rs = 0;
            for (int i = 1; i <= 6; i++)
            {
                rs += convert_number(lblAmt[(i - 1) * 7 + 7].Tag.ToString());
            }
            ra7.Text = rs.ToString("N0");


            ma.Text = sum_ma.ToString("N0");

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
