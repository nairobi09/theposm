using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;

namespace thepos._9SysAdmin
{
    public partial class frmSysAdminPosCert : Form
    {
        public frmSysAdminPosCert()
        {
            InitializeComponent();

            initialize_font();
            initial_the();

            reload_server();

        }

        private void initialize_font()
        {
            lblTitle.Font = font10;
            lvwList.Font = font10;

            btnEnter.Font = font10;
            btnStop.Font = font10;

        }

        private void initial_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 28);
            lvwList.SmallImageList = imgList;
        }


        private void reload_server()
        {
            lvwList.Items.Clear();

            String sUrl = "pos?siteId=" + mSiteId + "&posStatus=0";

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["pos"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["posNo"].ToString();
                        lvItem.SubItems.Add(arr[i]["macAddr"].ToString());
                        lvItem.SubItems.Add(arr[i]["initDt"].ToString());
                        lvItem.Tag = arr[i]["siteId"].ToString();

                        lvwList.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("포스정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }



        }

        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) {  return; }



            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = lvwList.SelectedItems[0].Text;
            parameters["posStatus"] = "Y";


            //? bizDt 추가요망
            if (mRequestPatch("pos", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("정상 인증등록 완료.", "thepos");
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


            reload_server();

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = lvwList.SelectedItems[0].Text;
            parameters["posStatus"] = "9"; // 정지

            //? bizDt 추가요망
            if (mRequestPatch("pos", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("정상 정지등록 완료.", "thepos");
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


            reload_server();
        }
    }
}
