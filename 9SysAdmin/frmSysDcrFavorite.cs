using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static thepos.thePos;

namespace thepos._1Sales
{
    public partial class frmSysDcrFavorite : Form
    {
        public frmSysDcrFavorite()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();

            reload_server();
        }

        void initialize_font()
        {
            lblTitle.Font = font14;

            lvwList.Font = font12;

            lblNameTitle.Font = font12;
            tbName.Font = font12;

            lblDesTitle.Font = font12;
            cbDes.Font = font12;

            lblTypeTitle.Font = font12;
            cbType.Font = font12;

            lblValueTitle.Font = font12;
            tbValue.Font = font12;

            btnAdd.Font = font12;
            btnUpdate.Font = font12;
            btnDelete.Font = font12;

            btnSave.Font = font12;

            lblInfo.Font = font10;
        }

        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 32);

            lvwList.SmallImageList = imgList;
            lvwList.HideSelection = true;


            cbDes.Items.Clear();
            cbDes.Items.Add("선택");
            cbDes.Items.Add("전체");

            cbType.Items.Clear();
            cbType.Items.Add("정액(W)");
            cbType.Items.Add("정율(%)");
        }

        private void reload_server()
        {
            lvwList.Items.Clear();


            String sUrl = "dcrFavorite?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["dcr"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["sortNo"].ToString();
                        lvItem.SubItems.Add(arr[i]["dcrName"].ToString());

                        lvItem.SubItems.Add(get_dcr_des_name(arr[i]["dcrDes"].ToString()));
                        lvItem.SubItems.Add(get_dcr_type_name(arr[i]["dcrType"].ToString()));

                        lvItem.SubItems.Add(arr[i]["dcrValue"].ToString());
                        lvItem.SubItems.Add(arr[i]["dcrDes"].ToString());
                        lvItem.SubItems.Add(arr[i]["dcrType"].ToString());
                        lvwList.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("할인즐겨찾기정보 오류. shop\n\n " + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. shop\n\n" + mErrorMsg, "thepos");
                return;
            }
        }

        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            tbName.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(name)].Text;

            cbDes.SelectedIndex = -1;
            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(des1)].Text == "S") cbDes.SelectedIndex = 0;
            else if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(des1)].Text == "E") cbDes.SelectedIndex = 1;

            cbType.SelectedIndex = -1;
            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(type1)].Text == "A") cbType.SelectedIndex = 0;
            else if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(type1)].Text == "R") cbType.SelectedIndex = 1;

            tbValue.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(value)].Text;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (check_data() == false)
            {
                MessageBox.Show("데이터 오류가 있습니다.", "thepos");
                return;
            }

            if (lvwList.Items.Count >= 8)
            {
                MessageBox.Show("최대 8개 항목 등록할 수 있습니다.");
                return;
            }


            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = "";
            lvItem.SubItems.Add(tbName.Text);

            String dcr_des = "";
            if (cbDes.SelectedIndex == 0) dcr_des = "S";
            else if (cbDes.SelectedIndex == 1) dcr_des = "E";
            lvItem.SubItems.Add(get_dcr_des_name(dcr_des));

            String dcr_type = "";
            if (cbType.SelectedIndex == 0) dcr_type = "A";
            else if (cbType.SelectedIndex == 1) dcr_type = "R";
            lvItem.SubItems.Add(get_dcr_type_name(dcr_type));

            lvItem.SubItems.Add(tbValue.Text);
            lvItem.SubItems.Add(dcr_des);
            lvItem.SubItems.Add(dcr_type);
            lvwList.Items.Add(lvItem);

            resort_listview_no();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            if (check_data() == false)
            {
                MessageBox.Show("데이터 오류가 있습니다.", "thepos");
                return;
            }

            lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(name)].Text = tbName.Text;

            String dcr_des = "";
            if (cbDes.SelectedIndex == 0) dcr_des = "S";
            else if (cbDes.SelectedIndex == 1) dcr_des = "E";
            lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(des)].Text = get_dcr_des_name(dcr_des);

            String dcr_type = "";
            if (cbType.SelectedIndex == 0) dcr_type = "A";
            else if (cbType.SelectedIndex == 1) dcr_type = "R";
            lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(type)].Text = get_dcr_type_name(dcr_type);

            lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(value)].Text = tbValue.Text;
            lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(des1)].Text = dcr_des;
            lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(type1)].Text = dcr_type;

        }

        private bool check_data()
        {
            if (tbName.Text.Trim().Length < 1) return false;
            if (cbDes.SelectedIndex < 0) return false;
            if (cbType.SelectedIndex < 0) return false;

            if (!is_number(tbValue.Text)) return false;

            int value = convert_number(tbValue.Text);

            if (value < 1) return false;

            if (cbType.SelectedIndex == 1)  // 정율
            {
                if (value > 100) return false;
            }

            return true;
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            lvwList.SelectedItems[0].Remove();


            clear_console();

            resort_listview_no();
        }

        private void clear_console()
        {
            tbName.Text = "";
            cbDes.SelectedIndex = -1;
            cbType.SelectedIndex = -1;
            tbValue.Text = "";
        }


        private void resort_listview_no()
        {
            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                lvwList.Items[i].Text = (i + 1).ToString();
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            // 전체 삭제
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;

            if (mRequestDelete("dcrFavorite", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                }
                else
                {
                    MessageBox.Show("할인정보 삭제오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }


            // 차례로 추가
            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["sortNo"] = lvwList.Items[i].Text;
                parameters["dcrName"] = lvwList.Items[i].SubItems[lvwList.Columns.IndexOf(name)].Text;
                parameters["dcrDes"] = lvwList.Items[i].SubItems[lvwList.Columns.IndexOf(des1)].Text;
                parameters["dcrType"] = lvwList.Items[i].SubItems[lvwList.Columns.IndexOf(type1)].Text;
                parameters["dcrValue"] = lvwList.Items[i].SubItems[lvwList.Columns.IndexOf(value)].Text;

                if (mRequestPost("dcrFavorite", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {

                    }
                    else
                    {
                        MessageBox.Show("할인정보 입력오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }

            MessageBox.Show("정상 저장 완료.", "thepos");

            reload_server();

            clear_console();

            //
            set_version_basic_db_change();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            if (lvwList.SelectedItems[0].Index == 0) { return; }


            ListViewItem items = new ListViewItem();

            items = lvwList.SelectedItems[0];
            int idx = lvwList.SelectedItems[0].Index;

            lvwList.Items[idx].Remove();
            lvwList.Items.Insert(idx - 1, items);

            lvwList.Items[idx-1].Selected = true;
            lvwList.Select();

            resort_listview_no();


        }

        private void btnDn_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            if (lvwList.SelectedItems[0].Index == lvwList.Items.Count - 1) { return; }


            ListViewItem items = new ListViewItem();

            items = lvwList.SelectedItems[0];
            int idx = lvwList.SelectedItems[0].Index;

            lvwList.Items[idx].Remove();
            lvwList.Items.Insert(idx + 1, items);

            lvwList.Items[idx+1].Selected = true;
            lvwList.Select();

            resort_listview_no();
        }
    }
}
