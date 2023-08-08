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
using System.Xml.Linq;
using static thepos.thePos;

namespace thepos
{
    public partial class frmReqPos : Form
    {
        public frmReqPos()
        {
            InitializeComponent();

            initialize_font();





        }

        private void initialize_font()
        {
            lblTitle.Font = font14;

            tbPosNo.Font = font10;
            lblPosNoTitle.Font = font10;

            btnEnter.Font = font10;
            btnCancel.Font = font10;

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (tbPosNo.Text.Length < 2)
            {
                MessageBox.Show("포스번호 입력오류.(2자리)", "thepos");
                return;
            }


            JObject obj = new JObject();
            String err_msg = "";

            // 사용자 등록 신청
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = "";
            parameters["posNo"] = tbPosNo.Text;
            parameters["macAddr"] = mMacAddr;
            parameters["status"] = "0";
            parameters["initDt"] = get_today_date() + get_today_time();
            parameters["lastDt"] = "";
            parameters["conCnt"] = "0";


            if (mRequestPost("pos", parameters, ref obj, ref err_msg))
            {
                if (obj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("포스기기등록신청완료\n\n" + "관리자의 인증심사 후 사용가능합니다.", "thepos");
                    return;
                }
                else
                {
                    MessageBox.Show("등록신청오류\n\n" + obj["resultMsg"].ToString() + "\n" + obj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + err_msg, "thepos");
                return;
            }
        }
    }
}
