using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.ClsWin32Api;
using static thepos.thePos;

namespace thepos
{
    public partial class frmDevAdmin : Form
    {
        public frmDevAdmin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (cbTest.Checked)
            {
                // TEST
                mBaseUri = "http://211.42.156.219:8080/";
                DialogResult = DialogResult.Yes;  // TEST
            }
            else
            {
                DialogResult = DialogResult.OK;  // REAL
            }


            // 로그인
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = tbSiteID.Text;
            parameters["posNo"] = tbPosNo.Text;

            if (mRequestPost("loginDev", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    mSiteId = mObj["siteId"].ToString();
                    mUserID = "";
                    mUserName = "";
                    mPosNo = mObj["posNo"].ToString();

                    Close();
                }
                else
                {
                    MessageBox.Show("로그인오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
            }


        }
    }
}
