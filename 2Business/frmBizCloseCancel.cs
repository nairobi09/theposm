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
    public partial class frmBizCloseCancel : Form
    {
        String biz_status = "";
        String biz_date = "";


        public frmBizCloseCancel()
        {
            InitializeComponent();

            initialize_font();

            initialize_the();

        }


        private void initialize_font()
        {
            lblTitle.Font = font12;

            lblBizStatusTitle.Font = font10;
            lblBizStatus.Font = font12bold;

            lblBizDateTitle.Font = font10;
            lblBizDate.Font = font12bold;

            lblOpenInputTitle.Font = font10;
            lblOpenInput.Font = font12;

            lblBiCloseInputTitle.Font = font10;
            lblCloseInput.Font = font12;

            lblCloseUserTitle.Font = font10;
            lblCloseUser.Font = font12;

            btnBizOpenInput.Font = font12;
        }

        private void initialize_the()
        {
            get_bizstatus();
        }


        private void get_bizstatus()
        {
            lblBizDate.Text = "";
            lblOpenInput.Text = "";
            lblCloseInput.Text = "";
            lblCloseUser.Text = "";


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


                    lblBizDate.Text = biz_date.Substring(0, 4) + "-" + biz_date.Substring(4, 2) + "-" + biz_date.Substring(6, 2);

                    lblOpenInput.Text = open_dt.Substring(0, 4) + "-" + open_dt.Substring(4, 2) + "-" + open_dt.Substring(6, 2) + " " + open_dt.Substring(8, 2) + ":" + open_dt.Substring(10, 2) + ":" + open_dt.Substring(12, 2);


                    if (biz_status == "A")
                    {
                        lblBizStatus.Text = "영업개시";
                    }
                    else if (biz_status == "F")
                    {
                        lblBizStatus.Text = "영업마감";
                        lblCloseInput.Text = close_dt.Substring(0, 4) + "-" + close_dt.Substring(4, 2) + "-" + close_dt.Substring(6, 2) + " " + close_dt.Substring(8, 2) + ":" + close_dt.Substring(10, 2) + ":" + close_dt.Substring(12, 2);
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

        private void btnBizOpenInput_Click(object sender, EventArgs e)
        {
            get_bizstatus();


            if (biz_status == "A")
            {
                MessageBox.Show("영업개시 상태입니다. 마감취소 입력할 수 없습니다.");
                return;
            }

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["bizDt"] = biz_date;
            parameters["bizStatus"] = "A";
            parameters["closeDt"] = "";
            parameters["cashCloseAmt"] = "0";

            if (mRequestPatch("bizDate", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("정상 마감취소등록 완료.", "thepos");
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



            get_bizstatus();



        }
    }
}
