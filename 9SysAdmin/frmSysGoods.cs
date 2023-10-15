using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static thepos.thePos;


namespace thepos._9SysAdmin
{
    public partial class frmSysGoods : Form
    {
        private BindingList<object> shopList = new BindingList<object>();


        int max_goodscode = 100000;  // 6자리

        private int sortColumn = -1;


        String sv_itemName = "";
        String sv_itemNameEN = "";
        String sv_itemNameCH = "";
        String sv_itemNameJP = "";

        String sv_amt = "";
        String sv_shopCode = "";
        String sv_ticketYn = "";
        String sv_taxFree = "";
        String sv_active = "";
        String sv_soldout = "";
        String sv_memo = "";
        String ch_imagePath = "";



        public frmSysGoods()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();

            reload_all();
        }

        private void initialize_font()
        {
            lblTitle.Font = font14;
            lvwList.Font = font10;

            lblGoodsNameTitle.Font = font9;
            tbGoodsName.Font = font10;
            tbGoodsNameEN.Font = font10;
            tbGoodsNameCH.Font = font10;
            tbGoodsNameJP.Font = font10;

            cbTicket.Font = font10;
            cbTaxFree.Font = font10;
            cbActive.Font = font10;
            cbSoldout.Font = font10;

            lblGoodsAmtTitle.Font = font9;
            tbGoodsAmt.Font = font10;

            lblShopTitle.Font = font10;
            cbShop.Font = font10;

            lblMemoTitle.Font = font9;
            tbMemo.Font = font10;

            lblImageTitle.Font = font9;
            btnX.Font = font9;

            btnAdd.Font = font12;
            btnUpdate.Font = font12;
            btnDelete.Font = font12;
        }

        private void initialize_the()
        {
            lvwList.HideSelection = true;


            cbShop.Items.Clear();
            for (int i = 0; i < mShop.Length; i++)
            {
                cbShop.Items.Add(mShop[i].shop_name);
            }
        }

        private void clear_console()
        {
            tbGoodsName.Text = "";
            tbGoodsNameEN.Text = "";
            tbGoodsNameCH.Text = "";
            tbGoodsNameJP.Text = "";

            tbGoodsName.Tag = "";
            tbGoodsAmt.Text = "";
            cbShop.SelectedIndex = -1;
            cbTicket.Checked = false;
            cbTaxFree.Checked = false;
            cbActive.Checked = false;
            tbMemo.Text = "";
            pbImage.Image = null;
        }


        private void reload_all()
        {
            lvwList.Items.Clear();

            clear_console();



            String tTicket, tTaxFree, tActive, tSoldout = "";

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

                        if (arr[i]["imagePath"].ToString() == "")
                            lvItem = new ListViewItem(arr[i]["itemName"].ToString());
                        else
                            lvItem = new ListViewItem(arr[i]["itemName"].ToString(), 0);  // image index = 0

                        lvItem.SubItems.Add(arr[i]["itemNameEn"].ToString());
                        lvItem.SubItems.Add(arr[i]["itemNameCh"].ToString());
                        lvItem.SubItems.Add(arr[i]["itemNameJp"].ToString());

                        // itemcode
                        lvItem.SubItems.Add(arr[i]["itemCode"].ToString());
                        lvItem.SubItems.Add(arr[i]["amt"].ToString());
                        lvItem.SubItems.Add(arr[i]["shopCode"].ToString());
                        lvItem.SubItems.Add(get_shop_name(arr[i]["shopCode"].ToString()));

                        tTicket = "";
                        tTaxFree = "";
                        tActive = "";
                        tSoldout = "";

                        if (arr[i]["ticketYn"].ToString() == "Y") tTicket = "Y";
                        if (arr[i]["taxFree"].ToString() == "Y") tTaxFree = "Y";
                        if (arr[i]["active"].ToString() == "Y") tActive = "Y";
                        if (arr[i]["soldout"].ToString() == "Y") tSoldout = "Y";

                        lvItem.SubItems.Add(tTicket);
                        lvItem.SubItems.Add(tTaxFree);
                        lvItem.SubItems.Add(tActive);
                        lvItem.SubItems.Add(tSoldout);
                        lvItem.SubItems.Add(arr[i]["memo"].ToString());

                        if (tActive != "Y")
                        {
                            lvItem.ForeColor = Color.Gray;
                            lvItem.SubItems[1].ForeColor = Color.Gray;
                            lvItem.SubItems[2].ForeColor = Color.Gray;
                            lvItem.SubItems[3].ForeColor = Color.Gray;
                            lvItem.SubItems[4].ForeColor = Color.Gray;
                            lvItem.SubItems[5].ForeColor = Color.Gray;
                        }


                        lvItem.Tag = arr[i]["imagePath"].ToString();



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


        private ListViewItem reload_select(string code)
        {
            String tTicket, tTaxFree, tActive, tSoldout = "";

            String sUrl = "goods?siteId=" + mSiteId + "&itemCode=" + code;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["goods"].ToString();
                    JArray arr = JArray.Parse(pos);

                    if (arr.Count > 0)
                    {
                        ListViewItem lvItem;

                        if (arr[0]["imagePath"].ToString() == "")
                            lvItem = new ListViewItem(arr[0]["itemName"].ToString());
                        else
                            lvItem = new ListViewItem(arr[0]["itemName"].ToString(), 0);  // image index = 0

                        lvItem.SubItems.Add(arr[0]["itemNameEn"].ToString());
                        lvItem.SubItems.Add(arr[0]["itemNameCh"].ToString());
                        lvItem.SubItems.Add(arr[0]["itemNameJp"].ToString());

                        // itemcode
                        lvItem.SubItems.Add(arr[0]["itemCode"].ToString());
                        lvItem.SubItems.Add(arr[0]["amt"].ToString());
                        lvItem.SubItems.Add(arr[0]["shopCode"].ToString());
                        lvItem.SubItems.Add(get_shop_name(arr[0]["shopCode"].ToString()));

                        tTicket = "";
                        tTaxFree = "";
                        tActive = "";
                        tSoldout = "";

                        if (arr[0]["ticketYn"].ToString() == "Y") tTicket = "Y";
                        if (arr[0]["taxFree"].ToString() == "Y") tTaxFree = "Y";
                        if (arr[0]["active"].ToString() == "Y") tActive = "Y";
                        if (arr[0]["soldout"].ToString() == "Y") tSoldout = "Y";

                        lvItem.SubItems.Add(tTicket);
                        lvItem.SubItems.Add(tTaxFree);
                        lvItem.SubItems.Add(tActive);
                        lvItem.SubItems.Add(tSoldout);
                        lvItem.SubItems.Add(arr[0]["memo"].ToString());

                        if (tActive != "Y")
                        {
                            lvItem.ForeColor = Color.Gray;
                            lvItem.SubItems[1].ForeColor = Color.Gray;
                            lvItem.SubItems[2].ForeColor = Color.Gray;
                            lvItem.SubItems[3].ForeColor = Color.Gray;
                            lvItem.SubItems[4].ForeColor = Color.Gray;
                            lvItem.SubItems[5].ForeColor = Color.Gray;
                        }

                        lvItem.Tag = arr[0]["imagePath"].ToString();


                        int code_num = 0;
                        if (get_number(arr[0]["itemCode"].ToString(), ref code_num))
                        {
                            if (max_goodscode < code_num)
                            {
                                max_goodscode = code_num;
                            }
                        }

                        return lvItem;

                    }
                }
                else
                {
                    MessageBox.Show("상품정보 오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return null;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return null;
            }

            return null;

        }


        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            tbGoodsName.Tag = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(goodscode)].Text;  // code

            tbGoodsName.Text = lvwList.SelectedItems[0].Text;
            tbGoodsNameEN.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(goodsnameEN)].Text;
            tbGoodsNameCH.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(goodsnameCH)].Text;
            tbGoodsNameJP.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(goodsnameJP)].Text;

            tbGoodsAmt.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(amt)].Text;

            String shop_code = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(shopcode)].Text;


            cbShop.SelectedIndex = -1;
            for (int i = 0; i < mShop.Length; i++)
            {
                if (mShop[i].shop_code == shop_code)
                {
                    cbShop.SelectedIndex = i;
                }
            }


            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(ticket)].Text == "Y")
                cbTicket.Checked = true;
            else
                cbTicket.Checked = false;

            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(taxfree)].Text == "Y")
                cbTaxFree.Checked = true;
            else
                cbTaxFree.Checked = false;

            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(active)].Text == "Y")
                cbActive.Checked = true;
            else
                cbActive.Checked = false;

            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(soldout)].Text == "Y")
                cbSoldout.Checked = true;
            else
                cbSoldout.Checked = false;


            tbMemo.Text = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(memo)].Text;

            pbImage.Image = null;

            if (lvwList.SelectedItems[0].Tag.ToString().Trim() != "")
            {
                try
                {
                    byte[] imgBytes = Convert.FromBase64String(lvwList.SelectedItems[0].Tag.ToString());
                
                    MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                    ms.Write(imgBytes, 0, imgBytes.Length);

                    pbImage.Image = System.Drawing.Image.FromStream(ms, true);
                }
                catch
                {

                }
            }


            // 보관
            sv_itemName = tbGoodsName.Text;
            sv_itemNameEN = tbGoodsNameEN.Text;
            sv_itemNameCH = tbGoodsNameCH.Text;
            sv_itemNameJP = tbGoodsNameJP.Text;

            sv_amt = tbGoodsAmt.Text;
            sv_shopCode = cbShop.SelectedIndex + "";
            sv_ticketYn = cbTicket.Checked + "";
            sv_taxFree = cbTaxFree.Checked + "";
            sv_active = cbActive.Checked + "";
            sv_soldout = cbSoldout.Checked + "";
            sv_memo = tbMemo.Text;
            ch_imagePath = "0";


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


            //
            String select_goodscode = tbGoodsName.Tag.ToString();
            int select_index = lvwList.SelectedItems[0].Index;



            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["itemCode"] = select_goodscode;

            // 변경된 항목만 파라메터에 넣는다.
            // 
            if (sv_itemName != tbGoodsName.Text.Trim())
                parameters["itemName"] = tbGoodsName.Text.Trim();

            if (sv_itemNameEN != tbGoodsNameEN.Text.Trim())
                parameters["itemNameEn"] = tbGoodsNameEN.Text.Trim();

            if (sv_itemNameCH != tbGoodsNameCH.Text.Trim())
                parameters["itemNameCh"] = tbGoodsNameCH.Text.Trim();

            if (sv_itemNameJP != tbGoodsNameJP.Text.Trim())
                parameters["itemNameJp"] = tbGoodsNameJP.Text.Trim();


            //
            if (sv_amt != tbGoodsAmt.Text)
                parameters["amt"] = tbGoodsAmt.Text;

            //
            if (sv_shopCode != cbShop.SelectedIndex + "")
                parameters["shopCode"] = mShop[cbShop.SelectedIndex].shop_code;

            //
            if (sv_ticketYn != cbTicket.Checked + "")
            {
                if (cbTicket.Checked)
                    parameters["ticketYn"] = "Y";
                else
                    parameters["ticketYn"] = "N";
            }

            //
            if (sv_taxFree != cbTaxFree.Checked + "")
            {
                if (cbTaxFree.Checked)
                    parameters["taxFree"] = "Y";
                else
                    parameters["taxFree"] = "N";
            }

            //
            if (sv_active != cbActive.Checked + "")
            {
                if (cbActive.Checked)
                    parameters["active"] = "Y";
                else
                    parameters["active"] = "N";
            }

            //
            if (sv_soldout != cbSoldout.Checked + "")
            {
                if (cbSoldout.Checked)
                    parameters["soldout"] = "Y";
                else
                    parameters["soldout"] = "N";
            }

            //
            if (sv_memo != tbMemo.Text)
                parameters["memo"] = tbMemo.Text;

            //
            if (ch_imagePath == "1")
            {
                if (pbImage.Image == null)
                {
                    parameters["imagePath"] = "";
                }
                else
                {
                    var ms = new MemoryStream();
                    pbImage.Image.Save(ms, pbImage.Image.RawFormat);
                    parameters["imagePath"] = Convert.ToBase64String(ms.ToArray());
                }
            }



            if (mRequestPatch("goods", parameters))
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
            ListViewItem lvItem = reload_select(select_goodscode);

            if (lvItem != null)
            {
                lvwList.Items[select_index] = lvItem;
                lvItem.Selected = true;
                lvwList.Select();
                lvwList.EnsureVisible(select_index);
            }

            MessageBox.Show("정상 수정 완료.", "thepos");
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


            //
            max_goodscode++;

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["itemCode"] = max_goodscode.ToString();

            parameters["itemName"] = tbGoodsName.Text.Trim();
            parameters["itemNameEN"] = tbGoodsNameEN.Text.Trim();
            parameters["itemNameCH"] = tbGoodsNameCH.Text.Trim();
            parameters["itemNameJP"] = tbGoodsNameJP.Text.Trim();

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

            if (cbSoldout.Checked)
                parameters["soldout"] = "Y";
            else
                parameters["soldout"] = "N";


            parameters["memo"] = tbMemo.Text;

            if (pbImage.Image == null)
            {
                parameters["imagePath"] = "";
            }
            else
            {
                var ms = new MemoryStream();
                pbImage.Image.Save(ms, pbImage.Image.RawFormat);
                parameters["imagePath"] = Convert.ToBase64String(ms.ToArray());
            }



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


            //
            ListViewItem lvItem = reload_select(max_goodscode.ToString());

            if (lvItem != null)
            {
                lvItem.Selected = true;
                lvwList.Items.Add(lvItem);
                lvwList.Select();

                lvwList.EnsureVisible(lvwList.Items.Count - 1);
            }

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


            int select_index = lvwList.SelectedItems[0].Index;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["itemCode"] = tbGoodsName.Tag.ToString();


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

            // 
            lvwList.Items[select_index].Remove();

            clear_console();

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


        private void pbImage_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog.ShowDialog();

            //OK버튼 클릭시
            if (dr == DialogResult.OK)
            {
                string fileFullName = openFileDialog.FileName;

                System.Drawing.Image image = System.Drawing.Image.FromFile(fileFullName);
                this.pbImage.Image = image;

                ch_imagePath = "1";
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            pbImage.Image = null;
            ch_imagePath = "1";
        }
    }
}
