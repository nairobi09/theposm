using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;

namespace thepos._9SysAdmin
{
    public partial class frmSysAdminUserCert : Form
    {
        public frmSysAdminUserCert()
        {
            InitializeComponent();

            initialize_font();
            initial_the();
        }

        private void initialize_font()
        {
            lblTitle.Font = font14;
            lvwList.Font = font12;

            btnEnter.Font = font12;
        }
        
        private void initial_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwList.SmallImageList = imgList;


            reload_server();


        }


        private void reload_server()
        {
            lvwList.Items.Clear();

            String sUrl = "userTemp?siteId=" + "0000";

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["userTemps"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["serialKey"].ToString();
                        lvItem.SubItems.Add("대기");
                        lvItem.SubItems.Add(arr[i]["userId"].ToString());
                        lvItem.SubItems.Add(arr[i]["userName"].ToString());
                        lvItem.SubItems.Add(arr[i]["initDt"].ToString());
                        lvItem.Tag = arr[i]["userPw"].ToString();
                        lvwList.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("포스정보 오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }



        }


        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }


            // user 추가
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            
            parameters["userId"] = lvwList.SelectedItems[0].SubItems[2].Text.ToString();
            parameters["userPw"] = lvwList.SelectedItems[0].Tag.ToString();
            parameters["siteId"] = mSiteId;
            parameters["userName"] = lvwList.SelectedItems[0].SubItems[3].Text.ToString();
            parameters["userStatus"] = "Y";
            parameters["userAuth"] = "U";
            parameters["registDt"] = get_today_date() + get_today_time();
            parameters["conCnt"] = "0";


            if (mRequestPost("user", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("정상 인증등록 완료[1/2].", "thepos");
                }
                else
                {
                    MessageBox.Show("오류1\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류1\n\n" + mErrorMsg, "thepos");
                return;
            }

            

            // userTemp 수정
            parameters.Clear();
            parameters["serialKey"] = lvwList.SelectedItems[0].Text.ToString();
            parameters["siteId"] = mSiteId;
            parameters["userStatus"] = "Y";
            parameters["registDt"] = get_today_date() + get_today_time();

            if (mRequestPatch("userTemp", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("정상 인증등록 완료[2/2].", "thepos");
                }
                else
                {
                    MessageBox.Show("오류2\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류2\n\n" + mErrorMsg, "thepos");
                return;
            }


            reload_server();

        }

    }
}