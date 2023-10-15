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
    public partial class frmSysShop : Form
    {
        public frmSysShop()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();

            reload_server();
        }


        private void initialize_font()
        {
            lblTitle.Font = font14;
            lvwList.Font = font12;

            lblGoodsNameTitle.Font = font10;
            tbShopCode.Font = font12;

            lblGoodsAmtTitle.Font = font10;
            tbShopName.Font = font12;

            btnAdd.Font = font12;
            btnUpdate.Font = font12;
            btnDelete.Font = font12;
        }

        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 32);

            lvwList.SmallImageList = imgList;
            lvwList.HideSelection = true;


        }


        private void reload_server()
        {
            lvwList.Items.Clear();

            tbShopCode.Text = "";
            tbShopName.Text = "";


            String sUrl = "shop?siteId=" + mSiteId;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["shops"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["shopCode"].ToString();
                        lvItem.SubItems.Add(arr[i]["shopName"].ToString());

                        lvwList.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("샵정보 오류. shop\n\n " + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. shop\n\n" + mErrorMsg, "thepos");
                return;
            }




        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (tbShopCode.Text.Trim().Length != 2)
            {
                MessageBox.Show("업장코드 오류.", "thepos");
                return;
            }

            if (tbShopName.Text.Trim().Length < 1)
            {
                MessageBox.Show("업장명 오류.", "thepos");
                return;
            }



            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = tbShopCode.Text.Trim();
            parameters["shopName"] = tbShopName.Text.Trim();

            if (mRequestPost("shop", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("정상 등록 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("업장정보 오류. shop\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. shop\n\n" + mErrorMsg, "thepos");
                return;
            }

            reload_server();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            if (tbShopCode.Text.Trim().Length != 2)
            {
                MessageBox.Show("업장코드 오류.", "thepos");
                return;
            }

            if (tbShopName.Text.Trim().Length < 1)
            {
                MessageBox.Show("업장명 오류.", "thepos");
                return;
            }



            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = tbShopCode.Text.Trim();
            parameters["shopName"] = tbShopName.Text.Trim();

            if (mRequestPatch("shop", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("정상 수정 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("오류. shop\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. shop\n\n" + mErrorMsg, "thepos");
                return;
            }

            reload_server();
        }

        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            tbShopCode.Text = lvwList.SelectedItems[0].Text;
            tbShopName.Text = lvwList.SelectedItems[0].SubItems[1].Text;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = tbShopCode.Text.Trim();


            if (mRequestDelete("shop", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("정상 삭제 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("업장정보 오류. shop\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. shop\n\n" + mErrorMsg, "thepos");
                return;
            }

            reload_server();


        }
    }
}
