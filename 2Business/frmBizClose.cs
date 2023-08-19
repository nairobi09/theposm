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
    public partial class frmBizClose : Form
    {
        public frmBizClose()
        {
            InitializeComponent();

            initialize_font();

            initialize_the();


        }



        private void initialize_font()
        {

            lblTitle.Font = font12;

            lblBizDateTitle.Font = font12;
            lblBizDate.Font = font12bold;

            lblBizStatus.Font = font12bold;


            lblLastBizOpenDtInputTitle.Font = font10;
            lblLastBizOpenDtInput.Font = font10;

            lblLastBizCloseDtInputTitle.Font = font10;
            lblLastBizCloseDtInput.Font = font10;

            btnBizCloseInput.Font = font12;

        }

        private void initialize_the()
        {
            lblBizDate.Text = "";
            lblLastBizOpenDtInput.Text = "";
            lblLastBizCloseDtInput.Text = "";



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
                    else if (biz_status == "F")
                    {
                        lblBizStatus.Text = "영업마감";
                        lblLastBizCloseDtInput.Text = close_dt.Substring(0, 4) + "-" + close_dt.Substring(4, 2) + "-" + close_dt.Substring(6, 2) + " " + close_dt.Substring(8, 2) + ":" + close_dt.Substring(10, 2) + ":" + close_dt.Substring(12, 2);
                    }
                }
                else
                {
                    MessageBox.Show("영업개시마감 데이터 오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
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
                    else if (biz_status == "F")  // F영업마감
                    {
                        MessageBox.Show("이미 마감입력이 완료된 상태입니다.", "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("영업개시마감 데이터 오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
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
                    MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
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
}
