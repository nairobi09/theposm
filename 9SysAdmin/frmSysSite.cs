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
    public partial class frmSysSite : Form
    {

        String[] tmTicketType;
        String[] tmTicketTypeText;
        String[] tmTicketMedia;
        String[] tmTicketMediaText;
        String[] tmVanCode;


        public frmSysSite()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();

            reload_server();
        }


        private void initialize_font()
        {
            lblTitle.Font = font14;

            lblSiteName.Font = font12;
            lblSiteAlias.Font = font12;
            lblRegistNo.Font = font12;

            lblCapName.Font = font12;
            lblBizAddr.Font = font12;
            lblBizTelNo.Font = font12;

            lblTicketType.Font = font12;
            lblTicketMedia.Font = font12;
            lblVanCode.Font = font12;

            lblCallCenter.Font = font12;


            tbSiteName.Font = font12;
            tbSiteAlias.Font = font12;
            tbRegistNo.Font = font12;

            tbCapName.Font = font12;
            tbBizAddr.Font = font12;
            tbBizTelNo.Font = font12;


            cbTicketType.Font = font12;
            cbTicketMedia.Font = font12;
            cbVanCode.Font = font12;
            tbCallCenter.Font = font12;

            btnUpdate.Font = font12;


        }

        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 32);


            tmTicketType = new String[2] { "PA", "PD" };
            tmTicketTypeText = new String[2] { "선불", "후불" };

            tmTicketMedia = new String[2] { "BC", "RF" };
            tmTicketMediaText = new String[2] { "띠지", "팔찌" };

            tmVanCode = new String[3] { "KCP", "NICE", "KOVAN" };



            cbTicketType.Items.Clear();
            for (int i = 0; i < tmTicketTypeText.Length; i++)
            {
                cbTicketType.Items.Add(tmTicketTypeText[i]);
            }

            cbTicketMedia.Items.Clear();
            for (int i = 0; i < tmTicketMediaText.Length; i++)
            {
                cbTicketMedia.Items.Add(tmTicketMediaText[i]);
            }

            cbVanCode.Items.Clear();
            for (int i = 0; i < tmVanCode.Length; i++)
            {
                cbVanCode.Items.Add(tmVanCode[i]);
            }


        }


        private void reload_server()
        {

            String sUrl = "site?siteId=" + mSiteId;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["sites"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count > 0)
                    {
                        tbSiteName.Text = arr[0]["siteName"].ToString();
                        tbSiteAlias.Text = arr[0]["siteAlias"].ToString();
                        tbRegistNo.Text = arr[0]["registNo"].ToString();

                        tbCapName.Text = arr[0]["capName"].ToString();
                        tbBizAddr.Text = arr[0]["bizAddr"].ToString();
                        tbBizTelNo.Text = arr[0]["bizTelNo"].ToString();

                        // AP AD
                        String ticketType = arr[0]["ticketType"].ToString();
                        for (int i = 0; i < ticketType.Length; i++)
                        {
                            if (tmTicketType[i] == ticketType)
                            {
                                cbTicketType.SelectedIndex = i;
                            }
                        }

                        // 
                        String ticketMedia = arr[0]["ticketMedia"].ToString();
                        for (int i = 0; i < mTicketType.Length; i++)
                        {
                            if (tmTicketMedia[i] == ticketMedia)
                            {
                                cbTicketMedia.SelectedIndex = i;
                            }
                        }

                        //
                        String vanCode = arr[0]["vanCode"].ToString();
                        for (int i = 0; i < tmVanCode.Length; i++)
                        {
                            if (tmVanCode[i] == vanCode)
                            {
                                cbVanCode.SelectedIndex = i;
                            }
                        }

                        //
                        tbCallCenter.Text = arr[0]["callCenterNo"].ToString();

                    }
                }
                else
                {
                    MessageBox.Show("사업자정보 오류. site\n\n " + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. site\n\n" + mErrorMsg, "thepos");
                return;
            }

        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;

            parameters["siteName"] = tbSiteName.Text;
            parameters["siteAlias"] = tbSiteAlias.Text;
            parameters["registNo"] = tbRegistNo.Text;

            parameters["capName"] = tbCapName.Text;
            parameters["bizAddr"] = tbBizAddr.Text;
            parameters["bizTelNo"] = tbBizTelNo.Text;


            if (cbTicketType.SelectedIndex < 0)
                parameters["ticketType"] = "";
            else
                parameters["ticketType"] = tmTicketType[cbTicketType.SelectedIndex];

            if (cbTicketMedia.SelectedIndex < 0)
                parameters["ticketMedia"] = "";
            else
                parameters["ticketMedia"] = tmTicketMedia[cbTicketMedia.SelectedIndex];

            if (cbVanCode.SelectedIndex < 0)
                parameters["vanCode"] = "";
            else
                parameters["vanCode"] = tmVanCode[cbVanCode.SelectedIndex];

            parameters["callCenterNo"] = tbCallCenter.Text;
            
            
            if (mRequestPatch("site", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    mSiteName = tbSiteName.Text;
                    mSiteAlias = tbSiteAlias.Text;
                    mCapName = tbRegistNo.Text;
                    mRegistNo = tbCapName.Text;
                    mBizAddr = tbBizAddr.Text;
                    mBizTelNo = tbBizTelNo.Text;
                    mTicketType = tmTicketType[cbTicketType.SelectedIndex];
                    mTicketMedia = tmTicketMedia[cbTicketMedia.SelectedIndex];
                    mVanCode = tmVanCode[cbVanCode.SelectedIndex];
                    mCallCenterNo = tbCallCenter.Text;

                    MessageBox.Show("정상 수정 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("오류. site\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. site\n\n" + mErrorMsg, "thepos");
                return;
            }

        }

    }
}
