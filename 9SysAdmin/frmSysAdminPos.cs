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

namespace thepos._9SysAdmin
{
    public partial class frmSysAdminPos : Form
    {

        TextBox mTbKeyDisplayController;  // 공용컨트롤러



        public frmSysAdminPos()
        {
            InitializeComponent();
            initialize_font();

            initialize_the();

        }

        private void initialize_font()
        {
            lblTitle.Font = font14;
            lblInfo.Font = font12;


            lblSiteIdTitle.Font = font12;
            tbSiteId.Font = font12;

            lblPosNoTitle.Font = font12;
            tbPosNo.Font = font12;

            btnEnter.Font = font12;


            btnKey1.Font = font14;
            btnKey2.Font = font14;
            btnKey3.Font = font14;
            btnKey4.Font = font14;
            btnKey5.Font = font14;
            btnKey6.Font = font14;
            btnKey7.Font = font14;
            btnKey8.Font = font14;
            btnKey9.Font = font14;
            btnKey0.Font = font14;
            btnKeyBS.Font = font14;
            btnKeyClear.Font = font14;


        }


        private void initialize_the()
        {
            mTbKeyDisplayController = tbSiteId;

            btnKey1.Click += (sender, args) => ClickedKey("1");
            btnKey2.Click += (sender, args) => ClickedKey("2");
            btnKey3.Click += (sender, args) => ClickedKey("3");
            btnKey4.Click += (sender, args) => ClickedKey("4");
            btnKey5.Click += (sender, args) => ClickedKey("5");
            btnKey6.Click += (sender, args) => ClickedKey("6");
            btnKey7.Click += (sender, args) => ClickedKey("7");
            btnKey8.Click += (sender, args) => ClickedKey("8");
            btnKey9.Click += (sender, args) => ClickedKey("9");
            btnKey0.Click += (sender, args) => ClickedKey("0");
            btnKeyBS.Click += (sender, args) => ClickedKey("BS");
            btnKeyClear.Click += (sender, args) => ClickedKey("Clear");


        }

        private void ClickedKey(string sKey)
        {

            if (sKey == "BS")
            {
                if (mTbKeyDisplayController.Text.Length > 0)
                {
                    mTbKeyDisplayController.Text = mTbKeyDisplayController.Text.Substring(0, mTbKeyDisplayController.Text.Length - 1);
                }
            }
            else if (sKey == "Clear")
            {
                mTbKeyDisplayController.Text = "";
            }
            else
            {
                mTbKeyDisplayController.Text += sKey;
            }
        }



        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (tbSiteId.Text.Length < 4)
            {
                MessageBox.Show("기관코드.(4자리)", "thepos");
                return;
            }


            if (tbPosNo.Text.Length < 2)
            {
                MessageBox.Show("포스번호 입력오류.(2자리)", "thepos");
                return;
            }


            JObject obj = new JObject();
            String err_msg = "";

            // 사용자 등록 신청
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = tbSiteId.Text;
            parameters["posNo"] = tbPosNo.Text;
            parameters["macAddr"] = mMacAddr;
            parameters["posStatus"] = "0";
            parameters["initDt"] = get_today_date() + get_today_time();
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

        private void tbSiteId_Click(object sender, EventArgs e)
        {
            mTbKeyDisplayController = tbSiteId;
        }

        private void tbPosNo_Click(object sender, EventArgs e)
        {
            mTbKeyDisplayController = tbPosNo;
        }
    }
}
