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
using System.Windows.Forms.DataVisualization.Charting;
using static thepos.thePos;

namespace thepos
{
    public partial class frmBizClose : Form
    {

        Label[] lbl_pos_no = new Label[10];
        Label[] lbl_pos_amount = new Label[10];


        public frmBizClose()
        {
            InitializeComponent();

            initialize_font();

            initialize_the();


            load_biz_data();


        }



        private void initialize_font()
        {
            lblTitle.Font = font10;

            //
            lblAmountPaymentTitle.Font = font10;
            lblAmountCashTitle.Font = font10;
            lblAmountCardTitle.Font = font10;
            lblAmountEasyTitle.Font = font10;
            lblAmountNetTitle.Font = font10;

            lblAmountTitle.Font = font10;
            lblAmountCash.Font = font10;
            lblAmountCard.Font = font10;
            lblAmountEasy.Font = font10;
            lblAmountNet.Font = font10;

            //
            lblPosTitle.Font = font10;
            lblPosTitle0.Font = font10;
            lblPosTitle1.Font = font10;
            lblPosTitle2.Font = font10;
            lblPosTitle3.Font = font10;
            lblPosTitle4.Font = font10;
            lblPosTitle5.Font = font10;
            lblPosTitle6.Font = font10;
            lblPosTitle7.Font = font10;
            lblPosTitle8.Font = font10;
            lblPosTitle9.Font = font10;

            lblPosAmountTitle.Font = font10;
            lblPosAmount0.Font = font10;
            lblPosAmount1.Font = font10;
            lblPosAmount2.Font = font10;
            lblPosAmount3.Font = font10;
            lblPosAmount4.Font = font10;
            lblPosAmount5.Font = font10;
            lblPosAmount6.Font = font10;
            lblPosAmount7.Font = font10;
            lblPosAmount8.Font = font10;
            lblPosAmount9.Font = font10;

            //
            lblBizDateTitle.Font = font10;
            lblBizDate.Font = font10;

            lblBizStatusTitle.Font = font10;
            lblBizStatus.Font = font10;

            lblLastBizOpenDtInputTitle.Font = font10;
            lblLastBizOpenDtInput.Font = font10;

            lblLastBizCloseDtInputTitle.Font = font10;
            lblLastBizCloseDtInput.Font = font10;

            btnBizCloseInput.Font = font10;

        }



        private void initialize_the()
        {
            lbl_pos_no[0] = lblPosTitle0;
            lbl_pos_no[1] = lblPosTitle1;
            lbl_pos_no[2] = lblPosTitle2;
            lbl_pos_no[3] = lblPosTitle3;
            lbl_pos_no[4] = lblPosTitle4;
            lbl_pos_no[5] = lblPosTitle5;
            lbl_pos_no[6] = lblPosTitle6;
            lbl_pos_no[7] = lblPosTitle7;
            lbl_pos_no[8] = lblPosTitle8;
            lbl_pos_no[9] = lblPosTitle9;

            lbl_pos_amount[0] = lblPosAmount0;
            lbl_pos_amount[1] = lblPosAmount1;
            lbl_pos_amount[2] = lblPosAmount2;
            lbl_pos_amount[3] = lblPosAmount3;
            lbl_pos_amount[4] = lblPosAmount4;
            lbl_pos_amount[5] = lblPosAmount5;
            lbl_pos_amount[6] = lblPosAmount6;
            lbl_pos_amount[7] = lblPosAmount7;
            lbl_pos_amount[8] = lblPosAmount8;
            lbl_pos_amount[9] = lblPosAmount9;

        }


        private void load_biz_data()
        {
            lblBizDate.Text = "";
            lblLastBizOpenDtInput.Text = "";



            String biz_status = "";
            String biz_date = "";


            String sUrl = "bizDateLast?siteId=" + mSiteId;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["bizDate"].ToString();
                    JArray arr = JArray.Parse(data);

                    biz_date = arr[0]["bizDt"].ToString();
                    biz_status = arr[0]["bizStatus"].ToString();

                    String open_dt = arr[0]["openDt"].ToString();
                    String close_dt = arr[0]["closeDt"].ToString();


                    lblBizDate.Text = biz_date.Substring(0,4) + "-" + biz_date.Substring(4, 2) + "-" + biz_date.Substring(6, 2);

                    lblLastBizOpenDtInput.Text = open_dt.Substring(0,4) + "-" + open_dt.Substring(4, 2) + "-" + open_dt.Substring(6, 2) + " " + open_dt.Substring(8, 2) + ":" + open_dt.Substring(10, 2) + ":" + open_dt.Substring(12, 2);
                    

                    if (biz_status == "A")
                    {
                        lblBizStatus.Text = "영업개시";
                    }
                    else if (biz_status == "F" | biz_status == "Y")
                    {
                        lblBizStatus.Text = "영업마감";
                        lblLastBizCloseDtInput.Text = close_dt.Substring(0, 4) + "-" + close_dt.Substring(4, 2) + "-" + close_dt.Substring(6, 2) + " " + close_dt.Substring(8, 2) + ":" + close_dt.Substring(10, 2) + ":" + close_dt.Substring(12, 2);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("영업개시마감 데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }






            //

            int net_amt = 0;
            int cash_amt = 0;
            int card_amt = 0;
            int easy_amt = 0;

            int tot_net_amt = 0;
            int tot_cash_amt = 0;
            int tot_card_amt = 0;
            int tot_easy_amt = 0;



            if (biz_status == "A")
            {
                sUrl = "reportDayPos?siteId=" + mSiteId + "&bizDt=" + mBizDate + "&runningBizDt=" + mBizDate;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["dayPos"].ToString();
                        JArray arr = JArray.Parse(data);

                        int[] pos_amount = new int[mPosNoList.Length];


                        for (int i = 0; i < arr.Count; i++)
                        {
                            net_amt = convert_number(arr[i]["netAmount"].ToString());
                            cash_amt = convert_number(arr[i]["amountCash"].ToString());
                            card_amt = convert_number(arr[i]["amountCard"].ToString());
                            easy_amt = convert_number(arr[i]["amountEasy"].ToString());

                            for (int pos_idx = 0; pos_idx < mPosNoList.Length; pos_idx++)
                            {
                                if (arr[i]["posNo"].ToString() == mPosNoList[pos_idx])
                                {
                                    pos_amount[pos_idx] += net_amt;
                                }
                            }

                            tot_net_amt += net_amt;
                            tot_cash_amt += cash_amt;
                            tot_card_amt += card_amt;
                            tot_easy_amt += easy_amt;
                        }

                        // 표시
                        lblAmountCash.Text = tot_cash_amt.ToString("N0");
                        lblAmountCard.Text = tot_card_amt.ToString("N0");
                        lblAmountEasy.Text = tot_easy_amt.ToString("N0");
                        lblAmountNet.Text = tot_net_amt.ToString("N0");


                        for (int pos_idx = 0; pos_idx < mPosNoList.Length; pos_idx++)
                        {
                            if (pos_idx < 10)
                            {
                                lbl_pos_no[pos_idx].Visible = true;
                                lbl_pos_amount[pos_idx].Visible = true;

                                lbl_pos_no[pos_idx].Text = mPosNoList[pos_idx];
                                lbl_pos_amount[pos_idx].Text = pos_amount[pos_idx].ToString("N0");
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("결제데이터 오류. reportDayPos\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. reportDayShop\n\n" + mErrorMsg, "thepos");
                }


            }




        }

        private void btnBizCloseInput_Click(object sender, EventArgs e)
        {

            String biz_status = "";
            String biz_date = "";


            String sUrl = "bizDateLast?siteId=" + mSiteId;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["bizDate"].ToString();
                    JArray arr = JArray.Parse(data);

                    biz_date = arr[0]["bizDt"].ToString();
                    biz_status = arr[0]["bizStatus"].ToString();

                    if (biz_status == "A")  // A영업중 
                    {
                        if (biz_date == mBizDate)
                        {
                            // ok
                        }
                        else
                        {
                            MessageBox.Show("영업일자 관리 오류가능성 발생. 재로그인 바랍니다.", "thepos");
                            return;
                        }
                    }
                    else if (biz_status == "F" | biz_status == "Y")  // F영업마감
                    {
                        MessageBox.Show("이미 마감입력이 완료된 상태입니다.", "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("영업개시마감 데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }






            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["bizDt"] = mBizDate;
            parameters["bizStatus"] = "F";
            parameters["closeDt"] = get_today_date() + get_today_time();
            parameters["cashCloseAmt"] = "0";

            if (mRequestPatch("bizDate", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("정상 마감등록 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }



            sUrl = "bizDateLast?siteId=" + mSiteId;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["bizDate"].ToString();
                    JArray arr = JArray.Parse(data);

                    biz_date = arr[0]["bizDt"].ToString();
                    biz_status = arr[0]["bizStatus"].ToString();

                    String open_dt = arr[0]["openDt"].ToString();
                    String close_dt = arr[0]["closeDt"].ToString();


                    lblBizDate.Text = biz_date.Substring(0, 4) + "-" + biz_date.Substring(4, 2) + "-" + biz_date.Substring(6, 2);

                    lblLastBizOpenDtInput.Text = open_dt.Substring(0, 4) + "-" + open_dt.Substring(4, 2) + "-" + open_dt.Substring(6, 2) + " " + open_dt.Substring(8, 2) + ":" + open_dt.Substring(10, 2) + ":" + open_dt.Substring(12, 2);


                    if (biz_status == "A")
                    {
                        lblBizStatus.Text = "영업개시";
                    }
                    else if (biz_status == "F" | biz_status == "Y")
                    {
                        lblBizStatus.Text = "영업마감";
                        lblLastBizCloseDtInput.Text = close_dt.Substring(0, 4) + "-" + close_dt.Substring(4, 2) + "-" + close_dt.Substring(6, 2) + " " + close_dt.Substring(8, 2) + ":" + close_dt.Substring(10, 2) + ":" + close_dt.Substring(12, 2);
                    }
                }
                else
                {
                    MessageBox.Show("영업개시마감 데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
            }




        }
    }
}
