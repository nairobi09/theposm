using Newtonsoft.Json.Linq;
using System;
using System.Collections;
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
    public partial class frmSysGoodsItem2 : Form
    {
        private int sortColumn = -1;

        String mSelectedPosNo = "";
        String mSelectedGroupCode = "";

        private BindingList<object> selected_groupList = new BindingList<object>();
        private BindingList<object> source_groupList = new BindingList<object>();

        List<String> pos_no = new List<String>();
        List<String> pos_type = new List<String>();


        public frmSysGoodsItem2()
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
            btnDelete.Font = font10;
            btnLink.Font = font10;

            btnSave.Font = font10;

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

                            tTicket = "";
                            tTaxFree = "";

                            if (arr[i]["ticketYn"].ToString() == "Y") tTicket = "Y";
                            if (arr[i]["taxFree"].ToString() == "Y") tTaxFree = "Y";

                            lvItem.SubItems.Add(tTicket);
                            lvItem.SubItems.Add(tTaxFree);
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

        private void cbPosNo_SelectedIndexChanged(object sender, EventArgs e)
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

                    if (selected_groupList.Count > 0)
                    {
                        cbGroup.DataSource = selected_groupList;
                        cbGroup.DisplayMember = "Text";
                        cbGroup.ValueMember = "Value";
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

        private void btnView_Click(object sender, EventArgs e)
        {
            mSelectedPosNo = pos_no[cbPosNo.SelectedIndex];


            if (pos_type[cbPosNo.SelectedIndex] != "KIOSK")
            {
                MessageBox.Show("KIOSK로 등록된 포스가 아닙니다.\r\n상품배치(POS) 메뉴에서 수정가능합니다.", "thepos");

                return;
            }


            if (cbGroup.SelectedIndex >= 0)
            {
                mSelectedGroupCode = cbGroup.SelectedValue.ToString();
            }



            reload_server();
        }


        private void reload_server()
        {
            lvwGoodsLink.Items.Clear();

            int[] item_seq;
            String[] item_code;
            String[] item_name;
            int[] item_amt;


            String sUrl = "goodsItemAndGoods?siteId=" + mSiteId + "&posNo=" + mSelectedPosNo + "&groupCode=" + mSelectedGroupCode;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goodsItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    item_seq = new int[arr.Count];
                    item_code = new String[arr.Count];
                    item_name = new String[arr.Count];
                    item_amt = new int[arr.Count];

                    for (int i = 0; i < arr.Count; i++)
                    {
                        item_seq[i] = convert_number(arr[i]["locateX"].ToString());
                        item_code[i] = arr[i]["goodsCode"].ToString();
                        item_name[i] = arr[i]["goodsName"].ToString();
                        item_amt[i] = convert_number(arr[i]["amt"].ToString());
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




            bool sort_complete = false;

            int temp_int = 0;
            String temp_str = "";


            while (!sort_complete)
            {
                sort_complete = true;
                for (int i = 0; i < item_seq.Length - 1; i++)
                {
                    if (item_seq[i] > item_seq[i + 1])
                    {
                        temp_int = item_seq[i];
                        item_seq[i] = item_seq[i + 1];
                        item_seq[i + 1] = temp_int;

                        temp_str = item_code[i];
                        item_code[i] = item_code[i + 1];
                        item_code[i + 1] = temp_str;

                        temp_str = item_name[i];
                        item_name[i] = item_name[i + 1];
                        item_name[i + 1] = temp_str;

                        temp_int = item_amt[i];
                        item_amt[i] = item_amt[i + 1];
                        item_amt[i + 1] = temp_int;

                        sort_complete = false;
                    }
                }
            }



            for (int i = 0; i < item_seq.Length; i++)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = (i + 1).ToString();
                lvItem.SubItems.Add(item_name[i]);
                lvItem.SubItems.Add(item_amt[i] + "");
                lvItem.Tag = item_code[i];

                lvwGoodsLink.Items.Add(lvItem);
            }


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
            parameters["locateX"] = (lvwGoodsLink.Items.Count + 1).ToString();
            parameters["locateY"] = "0";
            parameters["sizeX"] = "0";
            parameters["sizeY"] = "0";


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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwGoodsLink.SelectedItems.Count == 0) { return; }


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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            resort_listview_no();


            for (int i = 0; i < lvwGoodsLink.Items.Count; i++)
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["siteId"] = mSiteId;
                parameters["posNo"] = mSelectedPosNo;
                parameters["groupCode"] = mSelectedGroupCode;
                parameters["goodsCode"] = lvwGoodsLink.Items[i].Tag.ToString();

                parameters["locateX"] = lvwGoodsLink.Items[i].Text;
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


            //
            set_version_basic_db_change();


            MessageBox.Show("저장완료", "thepos");

        }

        private void resort_listview_no()
        {
            for (int i = 0; i < lvwGoodsLink.Items.Count; i++)
            {
                lvwGoodsLink.Items[i].Text = (i + 1).ToString();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lvwGoodsLink.SelectedItems.Count == 0) { return; }

            if (lvwGoodsLink.SelectedItems[0].Index == 0) { return; }


            ListViewItem items = new ListViewItem();

            items = lvwGoodsLink.SelectedItems[0];
            int idx = lvwGoodsLink.SelectedItems[0].Index;

            lvwGoodsLink.Items[idx].Remove();
            lvwGoodsLink.Items.Insert(idx - 1, items);

            lvwGoodsLink.Items[idx - 1].Selected = true;
            lvwGoodsLink.Select();
        }

        private void btnDn_Click(object sender, EventArgs e)
        {
            if (lvwGoodsLink.SelectedItems.Count == 0) { return; }

            if (lvwGoodsLink.SelectedItems[0].Index == lvwGoodsLink.Items.Count - 1) { return; }


            ListViewItem items = new ListViewItem();

            items = lvwGoodsLink.SelectedItems[0];
            int idx = lvwGoodsLink.SelectedItems[0].Index;

            lvwGoodsLink.Items[idx].Remove();
            lvwGoodsLink.Items.Insert(idx + 1, items);

            lvwGoodsLink.Items[idx + 1].Selected = true;
            lvwGoodsLink.Select();
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
