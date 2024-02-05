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
    public partial class frmSysOptionXXXX : Form
    {

        private int sortColumn = -1;

        String selected_goods_code = "";
        String selected_option_code = "";

        int max_option_code = 0;

        List<String> lst_goods = new List<String>();



        public frmSysOptionXXXX()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();

            load_goods();
        }



        private void initialize_font()
        {
            lblTitle.Font = font10;
            lvwGoods.Font = font10;

            cbSourceGoods.Font = font10;
            btnOptionCopy.Font = font10;

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



        private void load_goods()
        {
            lvwGoods.Items.Clear();
            cbSourceGoods.Items.Clear();


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


                        if (arr[i]["isOption"].ToString() == "Y")
                        {
                            //
                            lvItem = new ListViewItem(arr[i]["goodsName"].ToString(), 0);  // image index = 0

                            //
                            cbSourceGoods.Items.Add(arr[i]["goodsName"].ToString());
                            lst_goods.Add(arr[i]["goodsCode"].ToString());

                        }
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


            display_goods_option(selected_goods_code);

        }


        private void display_goods_option(String goods_code)
        { 
            
            lvwOption.Items.Clear();
            lvwOptionItem.Items.Clear();

            tbOptionName.Text = "";
            tbOptionNameEN.Text = "";
            tbOptionNameCH.Text = "";
            tbOptionNameJP.Text = "";

            tbOptionItemName.Text = "";
            tbOptionItemNameEN.Text = "";
            tbOptionItemNameCH.Text = "";
            tbOptionItemNameJP.Text = "";
            tbOptionItemAmt.Text = "";





            String sUrl = "goodsOption?siteId=" + mSiteId + "&goodsCode=" + goods_code;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["goodsOption"].ToString();
                    JArray arr = JArray.Parse(pos);


                    max_option_code = 101;

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem;
                        lvItem = new ListViewItem(arr[i]["optionSeq"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionName"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionNameEn"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionNameCh"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionNameJp"].ToString());
                        lvItem.Tag = arr[i]["optionCode"].ToString();

                        lvwOption.Items.Add(lvItem);


                        int t_no = convert_number(arr[i]["optionCode"].ToString());

                        if (max_option_code < t_no)
                        {
                            max_option_code = t_no;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("상품옵션정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
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
            tbOptionName.Text = "";
            tbOptionNameEN.Text = "";
            tbOptionNameCH.Text = "";
            tbOptionNameJP.Text = "";

            lvwOptionItem.Items.Clear();
            tbOptionItemName.Text = "";
            tbOptionItemNameEN.Text = "";
            tbOptionItemNameCH.Text = "";
            tbOptionItemNameJP.Text = "";
            tbOptionItemAmt.Text = "";

            if (lvwOption.SelectedItems.Count == 0) { return; }


            selected_option_code = lvwOption.SelectedItems[0].Tag.ToString();


            //
            tbOptionName.Text = lvwOption.SelectedItems[0].SubItems[1].Text;
            tbOptionNameEN.Text = lvwOption.SelectedItems[0].SubItems[2].Text;
            tbOptionNameCH.Text = lvwOption.SelectedItems[0].SubItems[3].Text;
            tbOptionNameJP.Text = lvwOption.SelectedItems[0].SubItems[4].Text;


            //
            String sUrl = "goodsOptionItem?siteId=" + mSiteId + "&goodsCode=" + selected_goods_code + "&optionCode=" + selected_option_code;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["optionItem"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem;
                        lvItem = new ListViewItem(arr[i]["optionItemNo"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionItemName"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionItemNameEn"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionItemNameCh"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionItemNameJp"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionItemAmt"].ToString());
                        lvwOptionItem.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("상품옵션아이템 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
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
            if (lvwOption.Items.Count >= 4)
            {
                MessageBox.Show("옵션은 최대 4개까지 입력가능합니다.", "thepos");
                return;
            }


            ListViewItem lvItem = new ListViewItem("");
            lvItem.SubItems.Add(tbOptionName.Text);
            lvItem.SubItems.Add(tbOptionNameEN.Text);
            lvItem.SubItems.Add(tbOptionNameCH.Text);
            lvItem.SubItems.Add(tbOptionNameJP.Text);
            lvItem.Tag = ++max_option_code;

            lvwOption.Items.Add(lvItem);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvwOption.SelectedItems.Count == 0) { return; }

            lvwOption.SelectedItems[0].SubItems[1].Text = tbOptionName.Text;
            lvwOption.SelectedItems[0].SubItems[2].Text = tbOptionNameEN.Text;
            lvwOption.SelectedItems[0].SubItems[3].Text = tbOptionNameCH.Text;
            lvwOption.SelectedItems[0].SubItems[4].Text = tbOptionNameJP.Text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwOption.SelectedItems.Count == 0) { return; }


            if (lvwOptionItem.Items.Count > 0)
            {
                MessageBox.Show("연결된 [옵션항목]이 있습니다. [옵션항목]삭제후 [옵션]삭제 가능합니다.", "thepos");
                return;
            }

            lvwOption.SelectedItems[0].Remove();
        }

        private void btnOptionUp_Click(object sender, EventArgs e)
        {
            if (lvwOption.SelectedItems.Count == 0) { return; }

            if (lvwOption.SelectedItems[0].Index == 0) { return; }

            ListViewItem items = new ListViewItem();

            items = lvwOption.SelectedItems[0];
            int idx = lvwOption.SelectedItems[0].Index;

            lvwOption.Items[idx].Remove();
            lvwOption.Items.Insert(idx - 1, items);

            lvwOption.Items[idx - 1].Selected = true;
            lvwOption.Select();
        }

        private void btnOptionDn_Click(object sender, EventArgs e)
        {
            if (lvwOption.SelectedItems.Count == 0) { return; }

            if (lvwOption.SelectedItems[0].Index == lvwOption.Items.Count - 1) { return; }

            ListViewItem items = new ListViewItem();

            items = lvwOption.SelectedItems[0];
            int idx = lvwOption.SelectedItems[0].Index;

            lvwOption.Items[idx].Remove();
            lvwOption.Items.Insert(idx + 1, items);

            lvwOption.Items[idx + 1].Selected = true;
            lvwOption.Select();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            // 전체 삭제
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["goodsCode"] = selected_goods_code;

            if (mRequestDelete("goodsOption", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                }
                else
                {
                    MessageBox.Show("상품옵션정보 삭제오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
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
                parameters["goodsCode"] = selected_goods_code;
                parameters["optionCode"] = lvwOption.Items[i].Tag.ToString();
                parameters["optionSeq"] = lvwOption.Items[i].Text;

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
                        MessageBox.Show("상품옵션정보 입력오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
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
            parameters.Clear();
            parameters["siteId"] = mSiteId;
            parameters["goodsCode"] = selected_goods_code;

            if (lvwOption.Items.Count > 0)
            {
                parameters["isOption"] = "Y";
            }
            else
            {
                parameters["isOption"] = "N";
            }



            if (mRequestPatch("goods", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
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
            if (lvwOptionItem.Items.Count >= 3)
            {
                MessageBox.Show("옵션항목은 최대 3개까지 입력가능합니다.", "thepos");
                return;
            }

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
                    MessageBox.Show("상품옵션아이템 정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
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
            for (int i = 0; i < lvwOptionItem.Items.Count; i++)
            {
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["goodsCode"] = selected_goods_code;
                parameters["optionCode"] = selected_option_code;
                parameters["optionItemNo"] = lvwOptionItem.Items[i].Text;

                parameters["optionItemName"] = lvwOptionItem.Items[i].SubItems[1].Text;
                parameters["optionItemNameEn"] = lvwOptionItem.Items[i].SubItems[2].Text;
                parameters["optionItemNameCh"] = lvwOptionItem.Items[i].SubItems[3].Text;
                parameters["optionItemNameJp"] = lvwOptionItem.Items[i].SubItems[4].Text;
                parameters["optionItemAmt"] = lvwOptionItem.Items[i].SubItems[5].Text;

                if (mRequestPost("goodsOptionItem", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {

                    }
                    else
                    {
                        MessageBox.Show("상품옵션정보 입력오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
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

        private void btnOptionCopy_Click(object sender, EventArgs e)
        {
            if (cbSourceGoods.SelectedIndex >= 0)
            {
                DialogResult ret = MessageBox.Show("기존의 옵션정보는 삭제되고 선택한 상품의 옵션정보를 동일하게 복사합니다.", "thepos", MessageBoxButtons.OKCancel);

                if (ret == DialogResult.Cancel)
                {
                    return;
                }

                // Option 삭제
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["siteId"] = mSiteId;
                parameters["goodsCode"] = selected_goods_code;

                if (mRequestDelete("goodsOption", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                    }
                    else
                    {
                        MessageBox.Show("상품옵션정보 삭제오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }

                // OptionItem 삭제
                // 파라메터 동일
                if (mRequestDelete("goodsOptionItem", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                    }
                    else
                    {
                        MessageBox.Show("상품옵션아이템 정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }


                // Option 복사
                String sUrl = "goodsOption?siteId=" + mSiteId + "&goodsCode=" + lst_goods[cbSourceGoods.SelectedIndex];
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String pos = mObj["goodsOption"].ToString();
                        JArray arr = JArray.Parse(pos);


                        max_option_code = 101;

                        for (int i = 0; i < arr.Count; i++)
                        {
                            parameters.Clear();
                            parameters["siteId"] = mSiteId;
                            parameters["goodsCode"] = selected_goods_code;
                            parameters["optionCode"] = arr[i]["optionCode"].ToString();
                            parameters["optionSeq"] = arr[i]["optionSeq"].ToString();

                            parameters["optionName"] = arr[i]["optionName"].ToString();
                            parameters["optionNameEn"] = arr[i]["optionNameEn"].ToString();
                            parameters["optionNameCh"] = arr[i]["optionNameCh"].ToString();
                            parameters["optionNameJp"] = arr[i]["optionNameJp"].ToString();

                            if (mRequestPost("goodsOption", parameters))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {

                                }
                                else
                                {
                                    MessageBox.Show("상품옵션정보 입력오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
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
                        MessageBox.Show("상품옵션정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }


                // OptionItem 복사
                sUrl = "goodsOptionItem?siteId=" + mSiteId + "&goodsCode=" + lst_goods[cbSourceGoods.SelectedIndex];
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String pos = mObj["optionItem"].ToString();
                        JArray arr = JArray.Parse(pos);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            parameters.Clear();
                            parameters["siteId"] = mSiteId;
                            parameters["goodsCode"] = selected_goods_code;
                            parameters["optionCode"] = arr[i]["optionCode"].ToString();
                            parameters["optionItemNo"] = arr[i]["optionItemNo"].ToString();

                            parameters["optionItemName"] = arr[i]["optionItemName"].ToString();
                            parameters["optionItemNameEn"] = arr[i]["optionItemNameEn"].ToString();
                            parameters["optionItemNameCh"] = arr[i]["optionItemNameCh"].ToString();
                            parameters["optionItemNameJp"] = arr[i]["optionItemNameJp"].ToString();
                            parameters["optionItemAmt"] = arr[i]["optionItemAmt"].ToString();

                            if (mRequestPost("goodsOptionItem", parameters))
                            {
                                if (mObj["resultCode"].ToString() == "200")
                                {

                                }
                                else
                                {
                                    MessageBox.Show("상품옵션정보 입력오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
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
                        MessageBox.Show("상품옵션아이템 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }

                //
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
                        MessageBox.Show("상품정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }

                // 표시 업데이트
                lvwGoods.SelectedItems[0].ImageIndex = 0;
                display_goods_option(selected_goods_code);



                MessageBox.Show("정상 복사 완료.", "thepos");


            }
        }
    }
}
