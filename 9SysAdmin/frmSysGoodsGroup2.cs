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
using Newtonsoft.Json.Linq;

namespace thepos._9SysAdmin
{
    public partial class frmSysGoodsGroup2 : Form
    {
        int max_groupcode = 100;  // 3자리

        String mSelectedPosNo = "";

        public frmSysGoodsGroup2()
        {
            InitializeComponent();
            initialize_font();

            get_posno();

        }

        private void initialize_font()
        {
            lblTitle.Font = font10;
            lvwList.Font = font10;

            lblPosNo.Font = font10;
            comboPosNo.Font = font10;
            btnViewPosNo.Font = font10;

            lblGroupNameTitle.Font = font10;
            tbGroupName.Font = font10;

            btnInput.Font = font10;
            btnUpdate.Font = font10;
            btnDelete.Font = font10;

            btnSave.Font = font10;
        }

        private void get_posno()
        {
            String sUrl = "pos?siteId=" + mSiteId;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["pos"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        comboPosNo.Items.Add(arr[i]["posNo"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("상품정보 오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }
        }

        private void btnViewPosNo_Click(object sender, EventArgs e)
        {
            if (comboPosNo.SelectedIndex == -1) { return; }

            mSelectedPosNo = comboPosNo.SelectedItem.ToString();


            reload_server();

        }

        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0)
            {
                tbGroupName.Text = "";

            }
            else
            {
                tbGroupName.Text = lvwList.SelectedItems[0].SubItems[1].Text;
            }
        }


        private void reload_server()
        {

            lvwList.Items.Clear();

            tbGroupName.Text = "";


            int[] group_seq;
            String[] group_code;
            String[] group_name;


            String sUrl = "goodsGroup?siteId=" + mSiteId + "&posNo=" + mSelectedPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goodsGroups"].ToString();
                    JArray arr = JArray.Parse(data);

                    group_seq = new int[arr.Count];
                    group_code = new String[arr.Count];
                    group_name = new String[arr.Count];

                    for (int i = 0; i < arr.Count; i++)
                    {
                        group_seq[i] = convert_number(arr[i]["locateX"].ToString());
                        group_name[i] = arr[i]["groupName"].ToString();
                        group_code[i] = arr[i]["groupCode"].ToString();

                        int code_num = 0;
                        if (get_number(arr[i]["groupCode"].ToString(), ref code_num))
                        {
                            if (max_groupcode < code_num)
                            {
                                max_groupcode = code_num;
                            }
                        }
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



            bool sort_complete = false;

            int temp_int = 0;
            String temp_str = "";


            while(!sort_complete)
            {
                sort_complete = true;
                for (int i = 0; i < group_seq.Length - 1; i++)
                {
                    if (group_seq[i] > group_seq[i+1])
                    {
                        temp_int = group_seq[i];
                        group_seq[i] = group_seq[i + 1];
                        group_seq[i + 1] = temp_int;

                        temp_str = group_code[i];
                        group_code[i] = group_code[i + 1];
                        group_code[i + 1] = temp_str;

                        temp_str = group_name[i];
                        group_name[i] = group_name[i + 1];
                        group_name[i + 1] = temp_str;

                        sort_complete = false;
                    }
                }
            }



            for (int i = 0; i < group_seq.Length; i++)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = (i + 1).ToString();
                lvItem.SubItems.Add(group_name[i]);
                lvItem.Tag = group_code[i];

                lvwList.Items.Add(lvItem);
            }


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

            lvwList.Items[idx - 1].Selected = true;
            lvwList.Select();



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

            lvwList.Items[idx + 1].Selected = true;
            lvwList.Select();

        }



        private void btnInput_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = mSelectedPosNo;
            parameters["groupCode"] = (++max_groupcode).ToString();
            parameters["groupName"] = tbGroupName.Text;

            parameters["locateX"] = (lvwList.Items.Count + 1).ToString();
            parameters["locateY"] = "0";
            parameters["sizeX"] = "0";
            parameters["sizeY"] = "0";

            if (mRequestPost("goodsGroup", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("그룹버튼 입력 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

            //
            set_version_basic_db_change();

            reload_server();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = mSelectedPosNo;
            parameters["groupCode"] = lvwList.SelectedItems[0].Tag.ToString();
            parameters["groupName"] = tbGroupName.Text;

            parameters["locateX"] = lvwList.SelectedItems[0].Text;
            parameters["locateY"] = "0";
            parameters["sizeX"] = "0";
            parameters["sizeY"] = "0";

            if (mRequestPatch("goodsGroup", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 그룹수정 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

            //
            set_version_basic_db_change();


            reload_server();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = mSelectedPosNo;
            parameters["groupCode"] = lvwList.SelectedItems[0].Tag.ToString();


            if (mRequestDelete("goodsGroup", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {

                }
                else
                {
                    MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

            //
            set_version_basic_db_change();

            reload_server();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            resort_listview_no();


            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["siteId"] = mSiteId;
                parameters["posNo"] = mSelectedPosNo;
                parameters["groupCode"] = lvwList.Items[i].Tag.ToString();

                parameters["locateX"] = lvwList.Items[i].Text;
                parameters["locateY"] = "0";
                parameters["sizeX"] = "0";
                parameters["sizeY"] = "0";

                if (mRequestPatch("goodsItem", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                    }
                    else
                    {
                        MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            //
            set_version_basic_db_change();


        }

        private void resort_listview_no()
        {
            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                lvwList.Items[i].Text = (i + 1).ToString();
            }
        }
    
    }


}
