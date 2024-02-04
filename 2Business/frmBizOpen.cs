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
using static thepos.frmBusiness;
using static thepos.thePos;

namespace thepos
{
    public partial class frmBizOpen : Form
    {
        public frmBizOpen()
        {
            InitializeComponent();
            initialize_font();
            initialize_the();
        }


        private void initialize_font()
        {
            lblTitle.Font = font10;

            lblT11.Font = font10;
            lblLastBizCloseDateTitle.Font = font10;
            lblLastBizDtInputTitle.Font = font10;
            lblBizCloseUserTitle.Font = font10;

            lblLastBizCloseDate.Font = font10;
            lblLastBizDtInput.Font = font10;
            lblBizCloseUser.Font = font10;

            lblBizDateTitle.Font = font10;
            lblBizOpenAmountTitle.Font = font10;
            lblBizOpenUserTitle.Font = font10;

            //dtpBizDate.Font = font12;
            tbBizOpenAmount.Font = font12;
            lblBizOpenUser.Font = font10;

            btnBizOpenInput.Font = font10;
        }

        private void initialize_the()
        {
            mTbKeyController = tbBizOpenAmount;

            lblLastBizCloseDate.Text = "";
            lblLastBizDtInput.Text = "";
            lblBizCloseUser.Text = "";

            //dtpBizDate.Text = "";
            tbBizOpenAmount.Text = "0";
            lblBizOpenUser.Text = "";


            String biz_status = "";
            String biz_date = "";
            String close_dt = "";

            String sUrl = "bizDateLast?siteId=" + mSiteId;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String cnt = mObj["bizDateCnt"].ToString();

                    if (cnt == "0")
                    {
                        biz_date = "";
                        biz_status = "X";
                    }
                    else
                    {
                        String data = mObj["bizDate"].ToString();
                        JArray arr = JArray.Parse(data);

                        biz_date = arr[0]["bizDt"].ToString();
                        biz_status = arr[0]["bizStatus"].ToString();
                        close_dt = arr[0]["closeDt"].ToString();
                    }


                    if (biz_status == "A")
                    {
                        
                    }
                    else if (biz_status == "F" | biz_status == "Y")
                    {
                        lblLastBizCloseDate.Text = biz_date.Substring(0, 4) + "-" + biz_date.Substring(4, 2) + "-" + biz_date.Substring(6, 2);
                        lblLastBizDtInput.Text = close_dt.Substring(0, 4) + "-" + close_dt.Substring(4, 2) + "-" + close_dt.Substring(6, 2) + " " + close_dt.Substring(8, 2) + ":" + close_dt.Substring(10, 2) + ":" + close_dt.Substring(12, 2);
                    }
                    else if (biz_status == "X")
                    {

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



        private void btnBizOpenInput_Click(object sender, EventArgs e)
        {

            String biz_status = "";
            String biz_date = "";
            String input_biz_date = "";

            String sUrl = "bizDateLast?siteId=" + mSiteId;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String cnt = mObj["bizDateCnt"].ToString();
                    if (cnt == "0")
                    {
                        biz_date = "";
                        biz_status = "X";
                    }
                    else
                    {
                        String data = mObj["bizDate"].ToString();
                        JArray arr = JArray.Parse(data);

                        biz_date = arr[0]["bizDt"].ToString();
                        biz_status = arr[0]["bizStatus"].ToString();
                        String close_dt = arr[0]["closeDt"].ToString();
                    }




                    if (biz_status == "A")
                    {
                        MessageBox.Show("영업개시 상태입니다. 마감입력후 개시입력할 수 있습니다.", "thepos");
                        return;
                    }
                    else if (biz_status == "F" | biz_status == "Y")
                    {
                        input_biz_date = dtpBizDate.Value.ToString("yyyyMMdd");

                        if (input_biz_date == biz_date)
                        {
                            MessageBox.Show("이미 마감된 영업일자입니다. 개시입력할 수 없습니다.", "thepos");
                            return;
                        }
                        else
                        {
                            int pre = 0;
                            int cur = 0;

                            if (!get_number(input_biz_date, ref cur))
                            {
                                MessageBox.Show("영업개시일자 오류.", "thepos");
                                return;
                            }

                            if (!get_number(biz_date, ref pre))
                            {
                                MessageBox.Show("최종 영업마감일자 오류.", "thepos");
                                return;
                            }

                            if (pre > cur)
                            {
                                MessageBox.Show("최종 영업마감일 이전일자로 개시입력할 수 없습니다.", "thepos");
                                return;
                            }
                            else
                            {
                                //ok
                            }
                        }
                    }
                    else if (biz_status == "X")
                    {
                        input_biz_date = dtpBizDate.Value.ToString("yyyyMMdd");

                        int cur = 0;

                        if (!get_number(input_biz_date, ref cur))
                        {
                            MessageBox.Show("영업개시일자 오류.", "thepos");
                            return;
                        }

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



            int cash_open_amt = 0;
            if (get_number(tbBizOpenAmount.Text, ref cash_open_amt))
            {

            }
            else
            {
                MessageBox.Show("개시준비금 오류", "thepos");
                return;
            }



            // 개시등록

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["bizDt"] = input_biz_date;
            parameters["bizStatus"] = "A";
            parameters["openDt"] = get_today_date() + get_today_time();
            //parameters["closeDt"] = "";   // 넣으면 서버에서 에러남.
            parameters["cashOpenAmt"] = cash_open_amt + "";
            parameters["cashCloseAmt"] = "0";


            if (mRequestPost("bizDate", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("정상 개시입력 완료.", "thepos");

                    // 정상 영업개시 -> 영업일자 세팅
                    mBizDate = input_biz_date;
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

        }

    }
}
