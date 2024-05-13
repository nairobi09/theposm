using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;


namespace thepos
{
    public partial class frmSysGoodsItem : Form
    {
        private int sortColumn = -1;

        String mSelectedPosNo = "";
        String mSelectedGroupCode = "";

        private BindingList<object> selected_groupList = new BindingList<object>();
        private BindingList<object> source_groupList = new BindingList<object>();


        List<String> pos_no = new List<String>();
        List<String> pos_type = new List<String>();


        public frmSysGoodsItem()
        {
            InitializeComponent();
            initialize_font();
            initialize_the();

            get_goods();
            get_posno_from_setupPos();

            /*
            for (int i = 0; i < mPosNoList.Length; i++)
            {
                cbPosNo.Items.Add(mPosNoList[i]);
                cbSourcePosNo.Items.Add(mPosNoList[i]);
            }
            */

        }

        private void initialize_font()
        {
            lblTitle.Font = font10;

            lblPosNoTitle.Font = font10;
            cbPosNo.Font = font10;

            lblGroupTitle.Font = font10;
            cbGroup.Font = font10;

            btnView.Font = font10;

            lvwGoods.Font = font10;
            lvwGoodsLink.Font = font10;

            lblT3.Font = font10;
            lblT4.Font = font10;
            lblT5.Font = font10;
            lblT6.Font = font10;

            tbLocateX.Font = font10;
            tbLocateY.Font = font10;
            tbSizeX.Font = font10;
            tbSizeY.Font = font10;

            btnUpdate.Font = font10;
            btnDelete.Font = font10;
            btnLink.Font = font10;
            btnApply.Font = font10;


            lblCopyPosNoTitle.Font = font10;
            cbSourcePosNo.Font = font10;

            lblCopyGroupTitle.Font = font10;
            cbSourceGroup.Font = font10;

            btnView.Font = font10;


        }


        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 28);

            lvwGoodsLink.SmallImageList = imgList;
            lvwGoodsLink.HideSelection = true;


        }

        private void get_posno_from_setupPos()
        {
            String sUrl = "setupPos?siteId=" + mSiteId + "&setupCode=PosType";

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["setupPos"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        cbPosNo.Items.Add(arr[i]["posNo"].ToString() + " - " + arr[i]["setupValue"].ToString());
                        cbSourcePosNo.Items.Add(arr[i]["posNo"].ToString() + " - " + arr[i]["setupValue"].ToString());


                        pos_no.Add(arr[i]["posNo"].ToString());
                        pos_type.Add(arr[i]["setupValue"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("상품정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }
        }

        private void get_goods()
        {
            String tTicket, tTaxFree = "";

            String sUrl = "goods?siteId=" + mSiteId;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goods"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        if (arr[i]["cutout"].ToString() != "Y")
                        {
                            ListViewItem lvItem = new ListViewItem();
                            lvItem.Text = arr[i]["goodsName"].ToString();
                            lvItem.SubItems.Add(arr[i]["amt"].ToString());
                            lvItem.SubItems.Add(get_shop_name(arr[i]["shopCode"].ToString()));

                            lvItem.SubItems.Add(arr[i]["memo"].ToString());

                            lvItem.Tag = arr[i]["goodsCode"].ToString();

                            lvwGoods.Items.Add(lvItem);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("상품정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

        }


        private void comboPosNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSelectedPosNo = pos_no[cbPosNo.SelectedIndex];


            String sUrl = "goodsGroup?siteId=" + mSiteId + "&posNo=" + mSelectedPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goodsGroups"].ToString();
                    JArray arr = JArray.Parse(data);

                    selected_groupList.Clear();
                    for (int i = 0; i < arr.Count; i++)
                    {
                        selected_groupList.Add(new { Text = arr[i]["groupName"].ToString(), Value = arr[i]["groupCode"].ToString() });
                    }

                    cbGroup.DataSource = selected_groupList;
                    cbGroup.DisplayMember = "Text";
                    cbGroup.ValueMember = "Value";

                }
                else
                {
                    MessageBox.Show("상품정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }
        }



        private void btnView_Click(object sender, EventArgs e)
        {
            mSelectedPosNo = pos_no[cbPosNo.SelectedIndex];


            if (pos_type[cbPosNo.SelectedIndex] == "KIOSK")
            {
                MessageBox.Show("KIOSK로 등록된 포스입니다.\r\n상품배치(KIOSK) 메뉴에서 수정가능합니다.", "thepos");

                return;
            }



            mSelectedGroupCode = cbGroup.SelectedValue.ToString();

            reload_server();

            display_all_console();

        }

        private void reload_server()
        {
            lvwGoodsLink.Items.Clear();

            tbLocateX.Text = "";
            tbLocateY.Text = "";
            tbSizeX.Text = "";
            tbSizeY.Text = "";

            tableLayoutPanelItemSelected.Controls.Clear();


            String sUrl = "goodsItemAndGoods?siteId=" + mSiteId + "&posNo=" + mSelectedPosNo + "&groupCode=" + mSelectedGroupCode;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goodsItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["goodsName"].ToString();
                        lvItem.SubItems.Add(arr[i]["amt"].ToString());
                        lvItem.SubItems.Add(arr[i]["locateX"].ToString());
                        lvItem.SubItems.Add(arr[i]["locateY"].ToString());
                        lvItem.SubItems.Add(arr[i]["sizeX"].ToString());
                        lvItem.SubItems.Add(arr[i]["sizeY"].ToString());
                        lvItem.Tag = arr[i]["goodsCode"].ToString();

                        lvwGoodsLink.Items.Add(lvItem);

                    }
                }
                else
                {
                    MessageBox.Show("상품정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }


        }

        private void display_all_console()
        {
            tableLayoutPanelItem.Controls.Clear();

            for (int i = 0; i < lvwGoodsLink.Items.Count; i++)
            {
                try
                {
                    Button btnItem = new Button();
                    btnItem.FlatStyle = FlatStyle.Flat;
                    btnItem.ForeColor = Color.White;
                    btnItem.BackColor = Color.Gray;
                    btnItem.TabStop = false;
                    btnItem.Margin = new Padding(2, 2, 2, 2);
                    btnItem.Padding = new Padding(0, 0, 0, 0);
                    btnItem.Text = lvwGoodsLink.Items[i].Text + "\n" + lvwGoodsLink.Items[i].SubItems[1].Text;
                    btnItem.Dock = DockStyle.Fill;

                    int loc_x = convert_number(lvwGoodsLink.Items[i].SubItems[lvwGoodsLink.Columns.IndexOf(locX)].Text);
                    int loc_y = convert_number(lvwGoodsLink.Items[i].SubItems[lvwGoodsLink.Columns.IndexOf(locY)].Text);
                    int sz_x = convert_number(lvwGoodsLink.Items[i].SubItems[lvwGoodsLink.Columns.IndexOf(szX)].Text);
                    int sz_y = convert_number(lvwGoodsLink.Items[i].SubItems[lvwGoodsLink.Columns.IndexOf(szY)].Text);

                    if (sz_x == 1 | sz_y == 1) { btnItem.Font = font8; }
                    else if (sz_x >= 3 & sz_y >= 2) { btnItem.Font = font16; }
                    else { btnItem.Font = font10; }

                    tableLayoutPanelItem.Controls.Add(btnItem, loc_x, loc_y);
                    tableLayoutPanelItem.SetColumnSpan(btnItem, sz_x);
                    tableLayoutPanelItem.SetRowSpan(btnItem, sz_y);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류. display all console()\n\n" + ex.Message, "thepos");
                    return;
                }
            }
        }

        private void lvwGoodsLink_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwGoodsLink.SelectedItems.Count == 0)
            {
                tbLocateX.Text = "";
                tbLocateY.Text = "";
                tbSizeX.Text = "";
                tbSizeY.Text = "";

                tableLayoutPanelItemSelected.Controls.Clear();
            }
            else
            {
                tbLocateX.Text = lvwGoodsLink.SelectedItems[0].SubItems[lvwGoodsLink.Columns.IndexOf(locX)].Text;
                tbLocateY.Text = lvwGoodsLink.SelectedItems[0].SubItems[lvwGoodsLink.Columns.IndexOf(locY)].Text;
                tbSizeX.Text = lvwGoodsLink.SelectedItems[0].SubItems[lvwGoodsLink.Columns.IndexOf(szX)].Text;
                tbSizeY.Text = lvwGoodsLink.SelectedItems[0].SubItems[lvwGoodsLink.Columns.IndexOf(szY)].Text;

                display_selected_console();
            }
        }


        private void display_selected_console()
        {
            tableLayoutPanelItemSelected.Controls.Clear();

            try
            {
                int locX = convert_number(tbLocateX.Text);
                int locY = convert_number(tbLocateY.Text);
                int szX = convert_number(tbSizeX.Text);
                int szY = convert_number(tbSizeY.Text);

                Button btnGroupBlue = new Button();

                btnGroupBlue.FlatStyle = FlatStyle.Flat;
                btnGroupBlue.ForeColor = Color.White;
                btnGroupBlue.BackColor = SystemColors.Highlight;
                btnGroupBlue.TabStop = false;
                btnGroupBlue.Margin = new Padding(2, 2, 2, 2);
                btnGroupBlue.Padding = new Padding(0, 0, 0, 0);
                btnGroupBlue.Text = lvwGoodsLink.SelectedItems[0].Text + "\n" + lvwGoodsLink.SelectedItems[0].SubItems[lvwGoodsLink.Columns.IndexOf(amt)].Text;
                btnGroupBlue.Dock = DockStyle.Fill;

                if (szX == 1 | szY == 1) { btnGroupBlue.Font = font8; }
                else if (szX >= 3 & szY >= 2) { btnGroupBlue.Font = font16; }
                else { btnGroupBlue.Font = font10; }

                tableLayoutPanelItemSelected.Controls.Add(btnGroupBlue, locX, locY);
                tableLayoutPanelItemSelected.SetColumnSpan(btnGroupBlue, szX);
                tableLayoutPanelItemSelected.SetRowSpan(btnGroupBlue, szY);
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류. display selected console()\n\n" + ex.Message, "thepos");
                return;

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvwGoodsLink.SelectedItems.Count == 0) { return; }

            if (!check_data())
            {
                return;
            }

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = mSelectedPosNo;
            parameters["groupCode"] = mSelectedGroupCode;
            parameters["goodsCode"] = lvwGoodsLink.SelectedItems[0].Tag.ToString();
            parameters["locateX"] = tbLocateX.Text;
            parameters["locateY"] = tbLocateY.Text;
            parameters["sizeX"] = tbSizeX.Text;
            parameters["sizeY"] = tbSizeY.Text;

            if (mRequestPatch("goodsItem", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {

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

            //
            set_version_basic_db_change();


            reload_server();

            display_all_console();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwGoodsLink.SelectedItems.Count == 0) { return; }

            if (MessageBox.Show("선택 상품연결정보를 삭제합니다.", "thwpos", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
            else
            {
                return;
            }



            String mSelectedGoodsCode = lvwGoodsLink.SelectedItems[0].Tag.ToString();


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = mSelectedPosNo;
            parameters["groupCode"] = mSelectedGroupCode;
            parameters["goodsCode"] = mSelectedGoodsCode;


            if (mRequestDelete("goodsItem", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {

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

            //
            set_version_basic_db_change();


            reload_server();

            display_all_console();

        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            if (lvwGoods.SelectedItems.Count == 0) { return; }


            if (mSelectedGroupCode == "") 
            {
                MessageBox.Show("포스 그룹 조회 해주세요.", "thepos");
                return; 
            }


            for (int i = 0; i < lvwGoodsLink.Items.Count; i++)
            {
                if (lvwGoods.SelectedItems[0].Tag.ToString() == lvwGoodsLink.Items[i].Tag.ToString())
                {
                    MessageBox.Show("이미 등록된 상품입니다.", "thepos");
                    return;
                }
            }


            String mSelectedGoodsCode = lvwGoods.SelectedItems[0].Tag.ToString();


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = mSelectedPosNo;
            parameters["groupCode"] = mSelectedGroupCode;
            parameters["goodsCode"] = lvwGoods.SelectedItems[0].Tag.ToString();
            parameters["locateX"] = "7";
            parameters["locateY"] = "7";
            parameters["sizeX"] = "1";
            parameters["sizeY"] = "1";


            if (mRequestPost("goodsItem", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    
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

            display_all_console();


            //
            for (int i = 0; i < lvwGoodsLink.Items.Count; i++)
            {
                if (lvwGoodsLink.Items[i].Tag.ToString() == mSelectedGoodsCode)
                {
                    lvwGoodsLink.Items[i].Selected = true; //
                    return;
                }
            }



        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            apply_console();
        }

        private void apply_console()
        { 
            if (!check_data())
            {
                return;
            }

            display_selected_console();
        }


        private bool check_data()
        {
            int tNum = 0;
            int locX, locY, szX, szY;

            if (!get_number(tbLocateX.Text, ref tNum)) { MessageBox.Show("LocX 오류.", "thepos"); return false; }
            if (tNum > 7) { MessageBox.Show("LocX 오류.", "thepos"); return false; }
            locX = tNum;

            if (!get_number(tbLocateY.Text, ref tNum)) { MessageBox.Show("LocY 오류.", "thepos"); return false; }
            if (tNum > 7) { MessageBox.Show("LocY 오류.", "thepos"); return false; }
            locY = tNum;

            if (!get_number(tbSizeX.Text, ref tNum)) { MessageBox.Show("SizeX 오류.", "thepos"); return false; }
            if (tNum > 8) { MessageBox.Show("SizeX 오류.", "thepos"); return false; }
            szX = tNum;

            if (!get_number(tbSizeY.Text, ref tNum)) { MessageBox.Show("SizeY 오류.", "thepos"); return false; }
            if (tNum > 8) { MessageBox.Show("SizeY 오류.", "thepos"); return false; }
            szY = tNum;


            if (locX + szX > 8) { MessageBox.Show("X범위 오류.", "thepos"); return false; }
            if (locY + szY > 8) { MessageBox.Show("Y범위 오류.", "thepos"); return false; }

            return true;
        }

        private void cbSourcePosNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            String copyPosNo = cbSourcePosNo.SelectedItem.ToString();


            String sUrl = "goodsGroup?siteId=" + mSiteId + "&posNo=" + copyPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goodsGroups"].ToString();
                    JArray arr = JArray.Parse(data);

                    cbSourceGroup.Items.Clear();
                    source_groupList.Clear();
                    for (int i = 0; i < arr.Count; i++)
                    {
                        source_groupList.Add(new { Text = arr[i]["groupName"].ToString(), Value = arr[i]["groupCode"].ToString() });
                    }

                    cbSourceGroup.DataSource = source_groupList;
                    cbSourceGroup.DisplayMember = "Text";
                    cbSourceGroup.ValueMember = "Value";

                }
                else
                {
                    MessageBox.Show("상품정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }
        }


        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (mSelectedGroupCode == "")
            {
                return;
            }


            if (cbSourcePosNo.SelectedIndex == -1) return;
            if (cbSourceGroup.SelectedIndex == -1) return;


            String sourcePosNo = cbSourcePosNo.SelectedItem.ToString();
            String sourceGroupCode = cbSourceGroup.SelectedValue.ToString();





            if (MessageBox.Show("기존의 연결상품을 모두 삭제하고, 선택한 그룹의 상품을 복사해옵니다.", "thepos", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // delete
                for (int i = 0; i < lvwGoodsLink.Items.Count; i++)
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters["siteId"] = mSiteId;
                    parameters["posNo"] = mSelectedPosNo;
                    parameters["groupCode"] = mSelectedGroupCode;
                    parameters["goodsCode"] = lvwGoodsLink.Items[i].Tag.ToString(); ;

                    if (mRequestDelete("goodsItem", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {

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
                }
            }
            else
            {
                return;
            }


            // copy
            String sUrl = "goodsItemAndGoods?siteId=" + mSiteId + "&posNo=" + sourcePosNo + "&groupCode=" + sourceGroupCode;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goodsItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        Dictionary<string, string> parameters = new Dictionary<string, string>();
                        parameters["siteId"] = mSiteId;
                        parameters["posNo"] = mSelectedPosNo;
                        parameters["groupCode"] = mSelectedGroupCode;
                        parameters["goodsCode"] = arr[i]["goodsCode"].ToString();
                        parameters["locateX"] = arr[i]["locateX"].ToString();
                        parameters["locateY"] = arr[i]["locateY"].ToString();
                        parameters["sizeX"] = arr[i]["sizeX"].ToString();
                        parameters["sizeY"] = arr[i]["sizeY"].ToString();
                        
                        if (mRequestPost("goodsItem", parameters))
                        {
                            if (mObj["resultCode"].ToString() == "200")
                            {

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
                    }
                }
                else
                {
                    MessageBox.Show("상품정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }



            MessageBox.Show("복사완료", "thepos");

            reload_server();

            display_all_console();


        }

        private void lvwGoods_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sortColumn)
            {
                sortColumn = e.Column;
                lvwGoods.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (lvwGoods.Sorting == SortOrder.Ascending)
                {
                    lvwGoods.Sorting = SortOrder.Descending;
                }
                else
                {
                    lvwGoods.Sorting = SortOrder.Ascending;
                }
            }


            lvwGoods.Sort();
            this.lvwGoods.ListViewItemSorter = new MyListViewComparer(e.Column, lvwGoods.Sorting);
        }

        class MyListViewComparer : IComparer
        {
            private int col; private SortOrder order; public MyListViewComparer() { col = 0; order = SortOrder.Ascending; }

            public MyListViewComparer(int column, SortOrder order) { col = column; this.order = order; }

            public int Compare(object x, object y)
            {
                int returnVal = -1; returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);

                // Determine whether the sort order is descending. 
                if (order == SortOrder.Descending) returnVal *= -1; // Invert the value returned by String.Compare. 

                return returnVal;
            }
        }

    }
}
