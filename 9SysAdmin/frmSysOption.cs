using Newtonsoft.Json.Linq;
using System;
using System.Collections;
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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static thepos.thePos;

namespace thepos
{
    public partial class frmSysOption : Form
    {

        private int sortColumn = -1;

        String selected_goods_code = "";
        String selected_option_code = "";


        public frmSysOption()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();

            reload_all();
        }



        private void initialize_font()
        {
            lblTitle.Font = font10;
            lvwGoods.Font = font10;


            lvwOption.Font = font10;

            lblKR.Font = font9;
            lblEN.Font = font9;
            lblCH.Font = font9;
            lblJP.Font = font9;

            tbOptionName.Font = font10;
            tbOptionNameEN.Font = font10;
            tbOptionNameCH.Font = font10;
            tbOptionNameJP.Font = font10;

            btnAdd.Font = font10;
            btnUpdate.Font = font10;
            btnDelete.Font = font10;
            btnSave.Font = font10;

            lvwOptionItem.Font = font10;

            lblKR2.Font = font9;
            lblEN2.Font = font9;
            lblCH2.Font = font9;
            lblJP2.Font = font9;

            tbOptionItemName.Font = font10;
            tbOptionItemNameEN.Font = font10;
            tbOptionItemNameCH.Font = font10;
            tbOptionItemNameJP.Font = font10;

            lblAmtTitle.Font = font9;
            tbOptionItemAmt.Font = font10;

            btnOptionItemUp.Font = font10;
            btnOptionItemDn.Font = font10;

            btnAdd2.Font = font10;
            btnUpdate2.Font = font10;
            btnDelete2.Font = font10;
            btnSave2.Font = font10;


        }

        private void initialize_the()
        {



        }

        private void clear_console()
        {
            tbOptionName.Text = "";
            tbOptionNameEN.Text = "";
            tbOptionNameCH.Text = "";
            tbOptionNameJP.Text = "";

            tbOptionItemName.Text = "";
            tbOptionItemNameEN.Text = "";
            tbOptionItemNameCH.Text = "";
            tbOptionItemNameJP.Text = "";
            tbOptionItemAmt.Text = "0";

        }



        private void reload_all()
        {
            lvwGoods.Items.Clear();

            clear_console();



            String tCutout, tSoldout = "";

            String sUrl = "goods?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["goods"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem;

                        if (arr[0]["isOption"].ToString() == "Y")
                            lvItem = new ListViewItem(arr[0]["goodsName"].ToString(), 0);  // image index = 0
                        else
                            lvItem = new ListViewItem(arr[i]["goodsName"].ToString());



                        lvItem.SubItems.Add(arr[i]["amt"].ToString());
                        lvItem.SubItems.Add(get_shop_name(arr[i]["shopCode"].ToString()));
                        lvItem.Tag = arr[i]["goodsCode"].ToString();

                        tCutout = "";

                        if (arr[i]["cutout"].ToString() == "Y") tCutout = "Y";

                        if (tCutout == "Y")  // 중지
                        {
                            lvItem.ForeColor = Color.LightGray;
                            lvItem.SubItems[1].ForeColor = Color.LightGray;
                            lvItem.SubItems[2].ForeColor = Color.LightGray;
                        }
                        else
                        {
                            lvItem.ForeColor = Color.Black;
                            lvItem.SubItems[1].ForeColor = Color.Black;
                            lvItem.SubItems[2].ForeColor = Color.Black;
                        }

                        lvwGoods.Items.Add(lvItem);
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

        private void lvwGoods_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //? 숫자컬럼(단가) Sorting 고려하기

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

        private void lvwGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwGoods.SelectedItems.Count == 0) { return; }

            selected_goods_code = lvwGoods.SelectedItems[0].Tag.ToString();
            selected_option_code = "";

            String sUrl = "goodsOption?siteId=" + mSiteId + "&goodsCode=" + selected_goods_code;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["goodsOption"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem;
                        lvItem = new ListViewItem(arr[i]["optionName"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionNameEn"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionNameCh"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionNameJp"].ToString());
                        lvItem.Tag = arr[i]["optionCode"].ToString();

                        lvwGoods.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("상품옵션정보 오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

        }

        private void lvwOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwOption.SelectedItems.Count == 0) { return; }

            selected_option_code = lvwGoods.SelectedItems[0].Tag.ToString();


            //
            tbOptionName.Text = lvwOption.SelectedItems[0].Text;
            tbOptionNameEN.Text = lvwOption.SelectedItems[0].SubItems[1].Text;
            tbOptionNameCH.Text = lvwOption.SelectedItems[0].SubItems[2].Text;
            tbOptionNameJP.Text = lvwOption.SelectedItems[0].SubItems[3].Text;


            //
            String sUrl = "goodsOptionItem?siteId=" + mSiteId + "&goodsCode=" + selected_goods_code + "&optionCode=" + selected_option_code;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["goodsOptionItem"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem;
                        lvItem = new ListViewItem(arr[i]["optionItemNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionItemName"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionItemNameEn"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionItemNameCh"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionItemNameJp"].ToString());

                        lvwGoods.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("상품옵션아이템 오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }




        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ListViewItem lvItem = new ListViewItem(tbOptionName.Text);
            lvItem.SubItems.Add(tbOptionNameEN.Text);
            lvItem.SubItems.Add(tbOptionNameCH.Text);
            lvItem.SubItems.Add(tbOptionNameJP.Text);
            lvwOption.Items.Add(lvItem);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvwGoods.SelectedItems.Count == 0) { return; }

            lvwOption.SelectedItems[0].Text = tbOptionName.Text;
            lvwOption.SelectedItems[0].SubItems[1].Text = tbOptionNameEN.Text;
            lvwOption.SelectedItems[0].SubItems[2].Text = tbOptionNameCH.Text;
            lvwOption.SelectedItems[0].SubItems[3].Text = tbOptionNameJP.Text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwGoods.SelectedItems.Count == 0) { return; }

            lvwGoods.SelectedItems[0].Remove();
        }

        private void btnOptionUp_Click(object sender, EventArgs e)
        {
            if (lvwGoods.SelectedItems.Count == 0) { return; }

            if (lvwGoods.SelectedItems[0].Index == 0) { return; }

            ListViewItem items = new ListViewItem();

            items = lvwGoods.SelectedItems[0];
            int idx = lvwGoods.SelectedItems[0].Index;

            lvwGoods.Items[idx].Remove();
            lvwGoods.Items.Insert(idx - 1, items);

            lvwGoods.Items[idx - 1].Selected = true;
            lvwGoods.Select();
        }

        private void btnOptionDn_Click(object sender, EventArgs e)
        {
            if (lvwGoods.SelectedItems.Count == 0) { return; }

            if (lvwGoods.SelectedItems[0].Index == lvwGoods.Items.Count - 1) { return; }

            ListViewItem items = new ListViewItem();

            items = lvwGoods.SelectedItems[0];
            int idx = lvwGoods.SelectedItems[0].Index;

            lvwGoods.Items[idx].Remove();
            lvwGoods.Items.Insert(idx + 1, items);

            lvwGoods.Items[idx + 1].Selected = true;
            lvwGoods.Select();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            String goods_code = lvwGoods.SelectedItems[0].Tag.ToString();


            // 전체 삭제
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["goodsCode"] = goods_code;

            if (mRequestDelete("goodsOption", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                }
                else
                {
                    MessageBox.Show("상품옵션정보 삭제오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }


            // 정렬
            resort_listview_option();

            // 차례로 추가
            for (int i = 0; i < lvwOption.Items.Count; i++)
            {
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["goodsCode"] = goods_code;
                parameters["optionCode"] = lvwOption.Items[i].Text;
                parameters["optionNo"] = lvwOption.Items[i].Text;

                parameters["optionName"] = lvwOption.Items[i].SubItems[1].Text;
                parameters["optionNameEn"] = lvwOption.Items[i].SubItems[2].Text;
                parameters["optionNameCh"] = lvwOption.Items[i].SubItems[3].Text;
                parameters["optionNameJp"] = lvwOption.Items[i].SubItems[4].Text;

                if (mRequestPost("goodsOption", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {

                    }
                    else
                    {
                        MessageBox.Show("상품옵션정보 입력오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            // goods 테이블에 isOption 마킹
            if (lvwOption.Items.Count > 0)
            {
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["goodsCode"] = selected_goods_code;
                parameters["isOption"] = "Y";

                if (mRequestPatch("goods", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
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



            MessageBox.Show("정상 저장 완료.", "thepos");


            //
            set_version_basic_db_change();
        }

        private void resort_listview_option()
        {
            for (int i = 0; i < lvwOption.Items.Count; i++)
            {
                lvwOption.Items[i].Text = (i + 1).ToString();
            }
        }



        //
        private void lvwOptionItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwOptionItem.SelectedItems.Count == 0) { return; }

            //
            tbOptionItemName.Text = lvwOptionItem.SelectedItems[0].SubItems[1].Text;
            tbOptionItemNameEN.Text = lvwOptionItem.SelectedItems[0].SubItems[2].Text;
            tbOptionItemNameCH.Text = lvwOptionItem.SelectedItems[0].SubItems[3].Text;
            tbOptionItemNameJP.Text = lvwOptionItem.SelectedItems[0].SubItems[4].Text;

            tbOptionItemAmt.Text = lvwOptionItem.SelectedItems[0].SubItems[5].Text;
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (!is_number(tbOptionItemAmt.Text))
            {
                MessageBox.Show("단가 입력 오류", "thepos");
                return;
            }
            

            ListViewItem lvItem = new ListViewItem("");
            lvItem.SubItems.Add(tbOptionItemName.Text);
            lvItem.SubItems.Add(tbOptionItemNameEN.Text);
            lvItem.SubItems.Add(tbOptionItemNameCH.Text);
            lvItem.SubItems.Add(tbOptionItemNameJP.Text);
            lvItem.SubItems.Add(tbOptionItemAmt.Text);
            lvwOptionItem.Items.Add(lvItem);
        }

        private void btnUpdate2_Click(object sender, EventArgs e)
        {
            if (lvwOptionItem.SelectedItems.Count == 0) { return; }

            if (!is_number(tbOptionItemAmt.Text))
            {
                MessageBox.Show("단가 입력 오류", "thepos");
                return;
            }

            lvwOptionItem.SelectedItems[0].SubItems[lvwOptionItem.Columns.IndexOf(option_item_name_kr)].Text = tbOptionItemName.Text;
            lvwOptionItem.SelectedItems[0].SubItems[lvwOptionItem.Columns.IndexOf(option_item_name_en)].Text = tbOptionItemNameEN.Text;
            lvwOptionItem.SelectedItems[0].SubItems[lvwOptionItem.Columns.IndexOf(option_item_name_ch)].Text = tbOptionItemNameCH.Text;
            lvwOptionItem.SelectedItems[0].SubItems[lvwOptionItem.Columns.IndexOf(option_item_name_jp)].Text = tbOptionItemNameJP.Text;
            lvwOptionItem.SelectedItems[0].SubItems[lvwOptionItem.Columns.IndexOf(option_item_amt)].Text = tbOptionItemAmt.Text;
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (lvwOptionItem.SelectedItems.Count == 0) { return; }

            lvwOptionItem.SelectedItems[0].Remove();
        }

        private void btnOptionItemUp_Click(object sender, EventArgs e)
        {
            if (lvwOptionItem.SelectedItems.Count == 0) { return; }

            if (lvwOptionItem.SelectedItems[0].Index == 0) { return; }

            ListViewItem items = new ListViewItem();

            items = lvwOptionItem.SelectedItems[0];
            int idx = lvwOptionItem.SelectedItems[0].Index;

            lvwOptionItem.Items[idx].Remove();
            lvwOptionItem.Items.Insert(idx - 1, items);

            lvwOptionItem.Items[idx - 1].Selected = true;
            lvwOptionItem.Select();
        }

        private void btnOptionItemDn_Click(object sender, EventArgs e)
        {
            if (lvwOptionItem.SelectedItems.Count == 0) { return; }

            if (lvwOptionItem.SelectedItems[0].Index == lvwOptionItem.Items.Count - 1) { return; }

            ListViewItem items = new ListViewItem();

            items = lvwOptionItem.SelectedItems[0];
            int idx = lvwOptionItem.SelectedItems[0].Index;

            lvwOptionItem.Items[idx].Remove();
            lvwOptionItem.Items.Insert(idx + 1, items);

            lvwOptionItem.Items[idx + 1].Selected = true;
            lvwOptionItem.Select();
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {

            // 전체 삭제
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["goodsCode"] = selected_goods_code;
            parameters["optionCode"] = selected_option_code;

            if (mRequestDelete("goodsOptionItem", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                }
                else
                {
                    MessageBox.Show("상품옵션아이템 정보 오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }


            // 정렬
            resort_listview_option_item();

            // 차례로 추가
            for (int i = 0; i < lvwOption.Items.Count; i++)
            {
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["goodsCode"] = selected_goods_code;
                parameters["optionCode"] = selected_option_code;
                parameters["optionNo"] = lvwOption.Items[i].Text;

                parameters["optionName"] = lvwOption.Items[i].SubItems[1].Text;
                parameters["optionNameEn"] = lvwOption.Items[i].SubItems[2].Text;
                parameters["optionNameCh"] = lvwOption.Items[i].SubItems[3].Text;
                parameters["optionNameJp"] = lvwOption.Items[i].SubItems[4].Text;

                if (mRequestPost("goodsOption", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {

                    }
                    else
                    {
                        MessageBox.Show("상품옵션정보 입력오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
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

            //
            set_version_basic_db_change();
        }

        private void resort_listview_option_item()
        {
            for (int i = 0; i < lvwOptionItem.Items.Count; i++)
            {
                lvwOptionItem.Items[i].Text = (i + 1).ToString();
            }
        }
    }
}
