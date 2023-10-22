using System;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Policy;
using System.Linq;
using static thepos.thePos;
using Newtonsoft.Json.Linq;
using System.Drawing;

namespace thepos
{
    public partial class frmSysGoodsGroup : Form
    {
        
        int max_groupcode = 100;  // 3자리

        String mSelectedPosNo = "";


        public frmSysGoodsGroup()
        {
            InitializeComponent();
            initialize_font();

            get_posno();

        }

        private void initialize_font()
        {
            lblTitle.Font = font14;
            lvwList.Font = font12;

            lblPosNo.Font = font12;
            comboPosNo.Font = font12;
            btnViewPosNo.Font = font12;

            lblGroupNameTitle.Font = font12;
            tbGroupName.Font = font12;

            lblLocXTitle.Font = font12;
            lblLocYTitle.Font = font12;
            lblSzXTitle.Font = font12;
            lblSzYTitle.Font = font12;

            tbLocateX.Font = font12;
            tbLocateY.Font = font12;
            tbSizeX.Font = font12;
            tbSizeY.Font = font12;

            btnApply.Font = font12;

            btnInput.Font = font12;
            btnUpdate.Font = font12;
            btnDelete.Font = font12;
            

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

            display_all_console();
        }



        private void reload_server()
        {

            lvwList.Items.Clear();
            tableLayoutPanelGroup.Controls.Clear();

            tbGroupName.Text = "";
            tbLocateX.Text = "";
            tbLocateY.Text = "";
            tbSizeX.Text = "";
            tbSizeY.Text = "";



            String sUrl = "goodsGroup?siteId=" + mSiteId + "&posNo=" + mSelectedPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goodsGroups"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["groupName"].ToString();
                        lvItem.SubItems.Add(arr[i]["locateX"].ToString());
                        lvItem.SubItems.Add(arr[i]["locateY"].ToString());
                        lvItem.SubItems.Add(arr[i]["sizeX"].ToString());
                        lvItem.SubItems.Add(arr[i]["sizeY"].ToString());
                        lvItem.Tag = arr[i]["groupCode"].ToString();

                        lvwList.Items.Add(lvItem);

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

        }

        private void lvwGoodsGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0)
            {
                tbGroupName.Text = "";
                tbLocateX.Text = "";
                tbLocateY.Text = "";
                tbSizeX.Text = "";
                tbSizeY.Text = "";

                tableLayoutPanelGroupSelected.Controls.Clear();
            }
            else
            {
                tbGroupName.Text = lvwList.SelectedItems[0].Text;
                tbLocateX.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(locX)].Text;
                tbLocateY.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(locY)].Text;
                tbSizeX.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(szX)].Text;
                tbSizeY.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(szY)].Text;

                display_selected_console();
            }

        }


        private void display_selected_console()
        {
            tableLayoutPanelGroupSelected.Controls.Clear();

            try
            {
                int loc_x = convert_number(lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(locX)].Text);
                int loc_y = convert_number(lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(locY)].Text);
                int sz_x = convert_number(lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(szX)].Text);
                int sz_y = convert_number(lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(szY)].Text);

                Button btnGroupBlue = new Button();

                btnGroupBlue.FlatStyle = FlatStyle.Flat;
                btnGroupBlue.ForeColor = Color.White;
                btnGroupBlue.BackColor = SystemColors.Highlight;
                btnGroupBlue.TabStop = false;
                btnGroupBlue.Margin = new Padding(2, 2, 2, 2);
                btnGroupBlue.Padding = new Padding(0, 0, 0, 0);
                btnGroupBlue.Text = lvwList.SelectedItems[0].Text; ;
                btnGroupBlue.Dock = DockStyle.Fill;

                if (sz_x == 1)                      { btnGroupBlue.Font = font9; }
                else if (sz_x >= 3 & sz_y == 2)     { btnGroupBlue.Font = font20; }
                else                                { btnGroupBlue.Font = font14; }


                tableLayoutPanelGroupSelected.Controls.Add(btnGroupBlue, loc_x, loc_y);
                tableLayoutPanelGroupSelected.SetColumnSpan(btnGroupBlue, sz_x);
                tableLayoutPanelGroupSelected.SetRowSpan(btnGroupBlue, sz_y);
            }
            catch (Exception ex) 
            {
                MessageBox.Show("오류. display selected console()\n\n" + ex.Message, "thepos");
                return;
            }

        }

        private void display_one_console(String name, int locX, int locY, int szX, int szY)
        {
            tableLayoutPanelGroupSelected.Controls.Clear();

            try
            {
                Button btnGroupBlue = new Button();

                btnGroupBlue.FlatStyle = FlatStyle.Flat;
                btnGroupBlue.ForeColor = Color.White;
                btnGroupBlue.BackColor = SystemColors.Highlight;
                btnGroupBlue.TabStop = false;
                btnGroupBlue.Margin = new Padding(2, 2, 2, 2);
                btnGroupBlue.Padding = new Padding(0, 0, 0, 0);
                btnGroupBlue.Text = name;
                btnGroupBlue.Dock = DockStyle.Fill;

                if (szX == 1) { btnGroupBlue.Font = font9; }
                else if (szX >= 3 & szY == 2) { btnGroupBlue.Font = font20; }
                else { btnGroupBlue.Font = font14; }


                tableLayoutPanelGroupSelected.Controls.Add(btnGroupBlue, locX, locY);
                tableLayoutPanelGroupSelected.SetColumnSpan(btnGroupBlue, szX);
                tableLayoutPanelGroupSelected.SetRowSpan(btnGroupBlue, szY);
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류. display one console()\n\n" + ex.Message, "thepos");
                return;

            }

        }


        private void display_all_console()
        {
            tableLayoutPanelGroup.Controls.Clear();

            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                try
                {
                    Button btnGroup = new Button();
                    btnGroup.FlatStyle = FlatStyle.Flat;
                    btnGroup.ForeColor = Color.White;
                    btnGroup.BackColor = Color.Gray;
                    btnGroup.TabStop = false;
                    btnGroup.Margin = new Padding(2, 2, 2, 2);
                    btnGroup.Padding = new Padding(0, 0, 0, 0);
                    btnGroup.Text = lvwList.Items[i].Text;
                    btnGroup.Dock = DockStyle.Fill;

                    int loc_x = convert_number(lvwList.Items[i].SubItems[lvwList.Columns.IndexOf(locX)].Text);
                    int loc_y = convert_number(lvwList.Items[i].SubItems[lvwList.Columns.IndexOf(locY)].Text);
                    int sz_x = convert_number(lvwList.Items[i].SubItems[lvwList.Columns.IndexOf(szX)].Text);
                    int sz_y = convert_number(lvwList.Items[i].SubItems[lvwList.Columns.IndexOf(szY)].Text);

                    if (sz_x == 1)                   { btnGroup.Font = font9; }
                    else if (sz_x >= 3 & sz_y == 2)   { btnGroup.Font = font20; }
                    else                            { btnGroup.Font = font14; }

                    tableLayoutPanelGroup.Controls.Add(btnGroup, loc_x, loc_y);
                    tableLayoutPanelGroup.SetColumnSpan(btnGroup, sz_x);
                    tableLayoutPanelGroup.SetRowSpan(btnGroup, sz_y);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("오류. display all console()\n\n" + ex.Message, "thepos");
                    return;
                }

            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }


            int locX = 0, locY = 0, SzX = 0, SzY = 0;

            if (!check_data(ref locX, ref locY, ref SzX, ref SzY))
            {
                return;
            }



            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = mSelectedPosNo;
            parameters["groupCode"] = lvwList.SelectedItems[0].Tag.ToString();
            parameters["groupName"] = tbGroupName.Text;

            parameters["locateX"] = locX.ToString();
            parameters["locateY"] = locY.ToString();
            parameters["sizeX"] = SzX.ToString();
            parameters["sizeY"] = SzY.ToString();



            if (mRequestPatch("goodsGroup", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("정상 그룹수정 완료.", "thepos");
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

            tableLayoutPanelGroupSelected.Controls.Clear();
            display_all_console();

        }

        private void btnInput_Click(object sender, EventArgs e)
        {

            int locX = 0, locY = 0, SzX = 0, SzY = 0;

            if (!check_data(ref locX, ref locY, ref SzX, ref SzY))
            {
                return;
            }


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = mSelectedPosNo;
            parameters["groupCode"] = (max_groupcode + 1).ToString();
            parameters["groupName"] = tbGroupName.Text;

            parameters["locateX"] = locX.ToString();
            parameters["locateY"] = locY.ToString();
            parameters["sizeX"] = SzX.ToString();
            parameters["sizeY"] = SzY.ToString();


            if (mRequestPost("goodsGroup", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("그룹버튼 입력 완료.", "thepos");
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

            tableLayoutPanelGroupSelected.Controls.Clear();
            display_all_console();
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }


            if (MessageBox.Show("선택 그룹버튼을 삭제합니다.\n상품 연결정보가 있으면 같이 삭제됩니다.", "thwpos", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
            }
            else
            {
                return;
            }


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

            tableLayoutPanelGroupSelected.Controls.Clear();
            display_all_console();

        }



        private bool check_data(ref int locX, ref int locY, ref int szX, ref int szY)
        {

            if (tbGroupName.Text.Trim().Length == 0)
            {
                MessageBox.Show("그룹명 오류.", "thepos");
                return false;
            }

            int tNum = 0;

            if (!get_number(tbLocateX.Text, ref tNum)) { MessageBox.Show("LocX 오류.", "thepos"); return false; }
            if (tNum > 7) { MessageBox.Show("LocX 오류.", "thepos"); return false; }
            locX = tNum;

            if (!get_number(tbLocateY.Text, ref tNum)) { MessageBox.Show("LocY 오류.", "thepos"); return false; }
            if (tNum > 2) { MessageBox.Show("LocY 오류.", "thepos"); return false; }
            locY = tNum;

            if (!get_number(tbSizeX.Text, ref tNum)) { MessageBox.Show("SizeX 오류.", "thepos"); return false; }
            if (tNum > 8) { MessageBox.Show("SizeX 오류.", "thepos"); return false; }
            szX = tNum;

            if (!get_number(tbSizeY.Text, ref tNum)) { MessageBox.Show("SizeY 오류.", "thepos"); return false; }
            if (tNum > 2) { MessageBox.Show("SizeY 오류.", "thepos"); return false; }
            szY = tNum;


            if (locX + szX > 8) { MessageBox.Show("X범위 오류.", "thepos"); return false; }
            if (locY + szY > 2) { MessageBox.Show("Y범위 오류.", "thepos"); return false; }

            return true;
        }




        private void btnApply_Click(object sender, EventArgs e)
        {
            int locX = 0, locY = 0, SzX = 0, SzY = 0;

            if (!check_data(ref locX, ref locY, ref SzX, ref SzY))
            {
                return;
            }


            display_one_console(tbGroupName.Text, locX, locY, SzX, SzY);
        }

    }
}
