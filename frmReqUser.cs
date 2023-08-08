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
    public partial class frmReqUser : Form
    {
        public frmReqUser()
        {
            InitializeComponent();

            initialize_font();



        }

        private void initialize_font()
        {

            lblTitle.Font = font14;

            lblID.Font = font10;
            lblPW.Font = font10;

            tbID.Font = font14;
            tbPW1.Font = font14;
            tbPW2.Font = font14;

            lblName.Font = font10;
            tbName.Font = font14;


            btnEnter.Font = font10;
            btnCancel.Font = font10;

            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (tbID.Text.Length < 4)
            {
                MessageBox.Show("ID 입력오류.(4자리)", "thepos");
                return;
            }


            if (tbPW1.Text.Length < 4)
            {
                MessageBox.Show("비밀번호 입력오류.(4자리)", "thepos");
                return;
            }


            if (tbPW1.Text != tbPW2.Text)
            {
                MessageBox.Show("비밀번호 비교오류", "thepos");
                return;
            }

            if (tbName.Text.Length <1)
            {
                MessageBox.Show("담당자명 입력오휴", "thepos");
                return;
            }


            JObject obj = new JObject();
            String err_msg = "";

            // 사용자 등록 신청
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["loginId"] = tbID.Text;
            parameters["userPw"] = SHA1HashCrypt(tbPW1.Text);//? SHA1 변경
            parameters["siteId"] = "";
            parameters["userName"] = tbName.Text;
            parameters["userStatus"] = "0";
            parameters["userAuth"] = "";
            parameters["initDt"] = get_today_date() + get_today_time();
            parameters["registDt"] = "";
            parameters["lastDt"] = "";
            parameters["conCnt"] = "0";


            if (mRequestPost("user", parameters, ref obj, ref err_msg))
            {
                if (obj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("등록신청완료\n\n" + obj["resultMsg"].ToString(), "thepos");
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
