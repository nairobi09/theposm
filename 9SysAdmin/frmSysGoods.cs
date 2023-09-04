using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;


namespace thepos._9SysAdmin
{
    public partial class frmSysGoods : Form
    {
        private BindingList<object> shopList = new BindingList<object>();


        int max_goodscode = 100000;  // 6자리

        private int sortColumn = -1;


        public frmSysGoods()

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


            lblGoodsNameTitle.Font = font12;
            tbGoodsName.Font = font12;

            lblGoodsAmtTitle.Font = font12;
            tbGoodsAmt.Font = font12;

            lblTicketTitle.Font = font12;
            lblTaxFreeTitle.Font = font12;

            lblShopTitle.Font = font12;
            cbShop.Font = font12;

            lblActiveTitle.Font = font12;

            lblMemoTitle.Font = font12;
            tbMemo.Font = font12;

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


            cbShop.Items.Clear();
            for (int i = 0; i < mShop.Length; i++)
            {
                cbShop.Items.Add(mShop[i].shop_name);
            }

        }


        private void reload_server()
        {
            lvwList.Items.Clear();

            tbGoodsName.Text = "";
            tbGoodsName.Tag = "";
            tbGoodsAmt.Text = "";
            cbTicket.Checked = false;
            cbTaxFree.Checked = false;
            cbActive.Checked = false;
            tbMemo.Text = "";


            String tTicket, tTaxFree, tActive = "";


            String sUrl = "goods?siteId=" + mSiteId;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["goods"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();

                        lvItem.Tag = arr[i]["itemCode"].ToString();

                        lvItem.Text = arr[i]["itemName"].ToString();

                        lvItem.SubItems.Add(arr[i]["amt"].ToString());

                        lvItem.SubItems.Add(arr[i]["shopCode"].ToString());
                        lvItem.SubItems.Add(get_shop_name(arr[i]["shopCode"].ToString()));


                        tTicket = "";
                        tTaxFree = "";
                        tActive = "";

                        if (arr[i]["ticketYn"].ToString() == "Y") tTicket = "Y";
                        if (arr[i]["taxFree"].ToString() == "Y") tTaxFree = "Y";
                        if (arr[i]["active"].ToString() == "Y") tActive = "Y";

                        lvItem.SubItems.Add(tTicket);
                        lvItem.SubItems.Add(tTaxFree);
                        lvItem.SubItems.Add(tActive);

                        lvItem.SubItems.Add(arr[i]["memo"].ToString());

                        

                        if (tActive != "Y")
                        {
                            lvItem.ForeColor = Color.Silver;
                            lvItem.SubItems[1].ForeColor = Color.Silver;
                            lvItem.SubItems[2].ForeColor = Color.Silver;
                            lvItem.SubItems[3].ForeColor = Color.Silver;
                            lvItem.SubItems[4].ForeColor = Color.Silver;
                            lvItem.SubItems[5].ForeColor = Color.Silver;
                        }


                        lvwList.Items.Add(lvItem);






                        int code_num = 0;
                        if (get_number(arr[i]["itemCode"].ToString(), ref code_num))
                        {
                            if (max_goodscode < code_num)
                            {
                                max_goodscode = code_num;
                            }
                        }

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

        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            tbGoodsName.Text = lvwList.SelectedItems[0].Text;
            tbGoodsName.Tag = lvwList.SelectedItems[0].Tag;
            tbGoodsAmt.Text = lvwList.SelectedItems[0].SubItems[1].Text;

            String shop_code = lvwList.SelectedItems[0].SubItems[2].Text;


            cbShop.SelectedIndex = -1;
            for (int i = 0; i < mShop.Length; i++)
            {
                if (mShop[i].shop_code == shop_code)
                {
                    cbShop.SelectedIndex = i;
                }
            }


            if (lvwList.SelectedItems[0].SubItems[4].Text == "Y")
                cbTicket.Checked = true;
            else
                cbTicket.Checked = false;

            if (lvwList.SelectedItems[0].SubItems[5].Text == "Y")
                cbTaxFree.Checked = true;
            else
                cbTaxFree.Checked = false;

            if (lvwList.SelectedItems[0].SubItems[6].Text == "Y")
                cbActive.Checked = true;
            else
                cbActive.Checked = false;

            tbMemo.Text = lvwList.SelectedItems[0].SubItems[7].Text;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }


            if (tbGoodsName.Text.Trim().Length == 0) 
            {
                MessageBox.Show("상품명 오류.", "thepos");
                return;  
            }


            if (!is_number(tbGoodsAmt.Text.Trim()))
            {
                MessageBox.Show("상품단가 오류.", "thepos");
                return;
            }

            if (cbShop.SelectedIndex == -1) return;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["itemCode"] = tbGoodsName.Tag.ToString();
            parameters["itemName"] = tbGoodsName.Text.Trim();
            parameters["amt"] = tbGoodsAmt.Text;

            parameters["shopCode"] = mShop[cbShop.SelectedIndex].shop_code;


            if (cbTicket.Checked)
                parameters["ticketYn"] = "Y";
            else
                parameters["ticketYn"] = "N";

            if (cbTaxFree.Checked)
                parameters["taxFree"] = "Y";
            else
                parameters["taxFree"] = "N";

            if (cbActive.Checked)
                parameters["active"] = "Y";
            else
                parameters["active"] = "N";

            parameters["memo"] = tbMemo.Text;



            if (mRequestPatch("goods", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("정상 수정 완료.", "thepos");
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


            reload_server();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (tbGoodsName.Text.Trim().Length == 0)
            {
                MessageBox.Show("상품명 오류.", "thepos");
                return;
            }

            if (!is_number(tbGoodsAmt.Text.Trim()))
            {
                MessageBox.Show("상품단가 오류.", "thepos");
                return;
            }

            if (cbShop.SelectedIndex == -1) return;



            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["itemCode"] = (max_goodscode + 1).ToString();
            parameters["itemName"] = tbGoodsName.Text.Trim();
            parameters["amt"] = tbGoodsAmt.Text;

            parameters["shopCode"] = mShop[cbShop.SelectedIndex].shop_code;


            if (cbTicket.Checked)
                parameters["ticketYn"] = "Y";
            else
                parameters["ticketYn"] = "N";

            if (cbTaxFree.Checked)
                parameters["taxFree"] = "Y";
            else
                parameters["taxFree"] = "N";

            if (cbActive.Checked)
                parameters["active"] = "Y";
            else
                parameters["active"] = "N";

            parameters["memo"] = tbMemo.Text;


            if (mRequestPost("goods", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("정상 등록 완료.", "thepos");
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


            reload_server();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }


            if (MessageBox.Show("선택 상품을 삭제합니다.\n연결된 상품정보가 있을경우 사용체크 제외로 수정하세요.", "thwpos", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
            else
            {
                return;
            }



            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["itemCode"] = lvwList.SelectedItems[0].Tag.ToString();


            if (mRequestDelete("goods", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    MessageBox.Show("정상 삭제 완료.", "thepos");
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


            reload_server();
        }


        private void lvwList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //? 숫자컬럼(단가) Sorting 고려하기

            if (e.Column != sortColumn)
            {
                sortColumn = e.Column;
                lvwList.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (lvwList.Sorting == SortOrder.Ascending)
                {
                    lvwList.Sorting = SortOrder.Descending;
                }
                else
                {
                    lvwList.Sorting = SortOrder.Ascending; 
                }
            }

            
            lvwList.Sort();
            this.lvwList.ListViewItemSorter = new MyListViewComparer(e.Column, lvwList.Sorting);
        }

        class MyListViewComparer : IComparer

        {

            private int col; private SortOrder order; public MyListViewComparer() { col = 0; order = SortOrder.Ascending; }

            public MyListViewComparer(int column, SortOrder order) { col = column; this.order = order; }

            public int Compare(object x, object y)

            {

                int returnVal = -1; returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);

                // Determine whether the sort order is descending. 

                if (order == SortOrder.Descending)

                    returnVal *= -1; // Invert the value returned by String.Compare. 

                return returnVal;



            }





        }


    }
}
