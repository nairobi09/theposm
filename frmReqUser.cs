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

            lblTitle.Font = font10;

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



            // 사용자 등록 신청
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["serialKey"] = get_today_date().Substring(3,5) + get_today_time().Substring(0,5);
            parameters["userId"] = tbID.Text;
            parameters["userPw"] = SHA1HashCrypt(tbPW1.Text);//? SHA1 변경
            parameters["siteId"] = "0000"; // -> 신청시는 "" : 이후 인증시 ID를 선택함.
            parameters["userName"] = tbName.Text;
            parameters["userStatus"] = "0";
            parameters["initDt"] = get_today_date() + get_today_time();
            //parameters["registDt"] = "";



            if (mRequestPost("userTemp", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("등록신청완료\n\n" + "관리자의 인증심사 후 사용가능합니다.", "thepos");
                    return;
                }
                else
                {
                    MessageBox.Show("등록신청오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
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
