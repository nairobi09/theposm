using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static thepos.thePos;

namespace thepos._9SysAdmin
{
    public partial class frmSysSite : Form
    {
        String ch_image = "";

        String[] tmTicketType;
        String[] tmTicketTypeText;
        String[] tmTicketMedia;
        String[] tmTicketMediaText;
        String[] tmVanCode;
        String[] tmCutoffType;
        String[] tmCutoffTypeText;

        public frmSysSite()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();

            reload_server();
        }


        private void initialize_font()
        {
            lblTitle.Font = font10;

            lblSiteName.Font = font10;
            lblSiteAlias.Font = font10;
            lblRegistNo.Font = font10;

            lblCapName.Font = font10;
            lblBizAddr.Font = font10;
            lblBizTelNo.Font = font10;

            lblTicketType.Font = font10;
            lblTicketMedia.Font = font10;
            lblVanCode.Font = font10;

            lblCallCenter.Font = font10;


            tbSiteName.Font = font10;
            tbSiteAlias.Font = font10;
            tbRegistNo.Font = font10;

            tbCapName.Font = font10;
            tbBizAddr.Font = font10;
            tbBizTelNo.Font = font10;


            cbTicketType.Font = font10;
            cbTicketMedia.Font = font10;
            cbVanCode.Font = font10;
            tbCallCenter.Font = font10;


            lblCutoffType.Font = font10;
            cbCutoffType.Font = font10;

            lblCutoffTime.Font = font10;
            tbCutoffTime.Font = font10;

            lblCutoffTime1.Font = font10;
            lblCutoffTime2.Font = font10;






            lblBillImage.Font = font10;
            btnX.Font = font10;

            btnUpdate.Font = font10;


        }

        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 32);


            tmTicketType = new String[2] { "PA", "PD" };
            tmTicketTypeText = new String[2] { "선불", "후불" };

            tmTicketMedia = new String[2] { "BC", "RF" };
            tmTicketMediaText = new String[2] { "띠지", "팔찌" };

            tmVanCode = new String[3] { "NICE", "KCP", "KOVAN" };


            tmCutoffType = new String[2] { "A", "M" };
            tmCutoffTypeText = new String[2] { "자동", "수동" };

            
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

            cbCutoffType.Items.Clear();
            for (int i = 0; i < tmCutoffTypeText.Length; i++)
            {
                cbCutoffType.Items.Add(tmCutoffTypeText[i]);
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

                        // A M
                        String cutoffType = arr[0]["cutoffType"].ToString();
                        for (int i = 0; i < tmCutoffType.Length; i++)
                        {
                            if (tmCutoffType[i] == cutoffType)
                            {
                                cbCutoffType.SelectedIndex = i;
                            }
                        }

                        tbCutoffTime.Text = arr[0]["cutoffTime"].ToString();



                        tbBizTelNo.Text = arr[0]["bizTelNo"].ToString();



                        //
                        tbCallCenter.Text = arr[0]["callCenterNo"].ToString();

                        // 이미지
                        String image_str = arr[0]["billImage"].ToString();

                        try
                        {
                            byte[] imgBytes = Convert.FromBase64String(image_str);

                            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                            ms.Write(imgBytes, 0, imgBytes.Length);

                            pbBillImage.Image = System.Drawing.Image.FromStream(ms, true);
                        }
                        catch
                        {

                        }

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

            if (tbCutoffTime.Text.Length != 4)
            {


                MessageBox.Show("마감시간 오류.", "thepos");
                return;
            }




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

            //
            parameters["cutoffType"] = tmCutoffType[cbCutoffType.SelectedIndex];
            parameters["cutoffTime"] = tbCutoffTime.Text;



            parameters["callCenterNo"] = tbCallCenter.Text;

            //
            if (ch_image == "1")
            {
                if (pbBillImage.Image == null)
                {
                    parameters["billImage"] = "";
                }
                else
                {
                    var ms = new MemoryStream();
                    pbBillImage.Image.Save(ms, pbBillImage.Image.RawFormat);
                    parameters["billImage"] = Convert.ToBase64String(ms.ToArray());
                }
            }



            // 
            parameters["basicDbVer"] = get_today_date() + get_today_time();


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

            // site 수정을 같은 테이블이라 한번에 한다.
            //set_version_basic_db_change();

        }

        private void pbBillImage_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog.ShowDialog();

            //OK버튼 클릭시
            if (dr == DialogResult.OK)
            {
                string fileFullName = openFileDialog.FileName;

                System.Drawing.Image image = System.Drawing.Image.FromFile(fileFullName);
                this.pbBillImage.Image = image;

                ch_image = "1";
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            pbBillImage.Image = null;
            ch_image = "1";
        }
    }
}
