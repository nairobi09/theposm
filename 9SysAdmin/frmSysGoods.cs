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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static thepos.thePos;


namespace thepos._9SysAdmin
{
    public partial class frmSysGoods : Form
    {
        private BindingList<object> shopList = new BindingList<object>();


        int max_goodscode = 100000;  // 6자리

        private int sortColumn = -1;


        String sv_goodsName = "";
        String sv_goodsNameEN = "";
        String sv_goodsNameCH = "";
        String sv_goodsNameJP = "";

        String sv_amt = "";
        String sv_shopCode = "";
        String sv_ticketYn = "";
        String sv_taxFree = "";
        String sv_cutout = "";
        String sv_soldout = "";
        String sv_option_template_id = "";
        String sv_badges_id = "";
        String sv_memo = "";
        String ch_imagePath = "";



        public frmSysGoods()
        {
            InitializeComponent();

            //initialize_font();
            initialize_the();

            reload_all();
        }

        private void initialize_font()
        {
            lblTitle.Font = font10;
            lvwList.Font = font10;

            lblKR.Font = font9;
            lblEN.Font = font9;
            lblCH.Font = font9;
            lblJP.Font = font9;
            lblNoticeTitle.Font = font9;

            tbGoodsName.Font = font10;
            tbGoodsNameEN.Font = font10;
            tbGoodsNameCH.Font = font10;
            tbGoodsNameJP.Font = font10;
            tbGoodsNotice.Font = font10;

            cbTicket.Font = font10;
            cbTaxFree.Font = font10;
            cbCutout.Font = font10;
            cbSoldout.Font = font10;

            lblGoodsAmtTitle.Font = font10;
            tbGoodsAmt.Font = font10;

            lblShopTitle.Font = font10;
            cbShop.Font = font10;

            lblOptionTitle.Font = font10;
            cbOptionTemplate.Font = font10;

            lblBadgesTitle.Font = font10;
            cbBadges.Font = font10;

            lblMemoTitle.Font = font10;
            tbMemo.Font = font10;

            btnX.Font = font10;

            btnAdd.Font = font10;
            btnUpdate.Font = font10;
            btnDelete.Font = font10;
        }

        private void initialize_the()
        {
            lvwList.HideSelection = true;


            cbShop.Items.Clear();
            for (int i = 0; i < mShop.Length; i++)
            {
                cbShop.Items.Add(mShop[i].shop_name);
            }

            cbOptionTemplate.Items.Clear();
            for (int i = 0; i < mOptionTemplate.Length; i++)
            {
                cbOptionTemplate.Items.Add(mOptionTemplate[i].option_template_name);
            }




            cbBadges.Items.Clear();
            for (int i = 0; i < mBadges.Length; i++)
            {
                cbBadges.Items.Add(mBadges[i].badges_name);
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
            cbCutout.Checked = false;

            tbMemo.Text = "";
            pbImage.Image = null;
        }


        private void reload_all()
        {
            lvwList.Items.Clear();

            clear_console();



            String tTicket, tTaxFree, tCutout, tSoldout = "";

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
                            lvItem = new ListViewItem(arr[i]["goodsName"].ToString());
                        else
                            lvItem = new ListViewItem(arr[i]["goodsName"].ToString(), 0);  // image index = 0

                        lvItem.SubItems.Add(arr[i]["goodsNameEn"].ToString());
                        lvItem.SubItems.Add(arr[i]["goodsNameCh"].ToString());
                        lvItem.SubItems.Add(arr[i]["goodsNameJp"].ToString());


                        // goodscode
                        lvItem.SubItems.Add(arr[i]["goodsCode"].ToString());

                        lvItem.SubItems.Add(arr[i]["amt"].ToString());
                        lvItem.SubItems.Add(arr[i]["shopCode"].ToString());
                        lvItem.SubItems.Add(get_shop_name(arr[i]["shopCode"].ToString()));

                        tTicket = "";
                        tTaxFree = "";
                        tCutout = "";
                        tSoldout = "";

                        if (arr[i]["ticketYn"].ToString() == "Y") tTicket = "Y";
                        if (arr[i]["taxFree"].ToString() == "Y") tTaxFree = "Y";
                        if (arr[i]["cutout"].ToString() == "Y") tCutout = "Y";
                        if (arr[i]["soldout"].ToString() == "Y") tSoldout = "Y";

                        lvItem.SubItems.Add(tTicket);
                        lvItem.SubItems.Add(tTaxFree);
                        lvItem.SubItems.Add(tCutout);
                        lvItem.SubItems.Add(tSoldout);

                        lvItem.SubItems.Add(arr[i]["optionTemplateId"].ToString());
                        lvItem.SubItems.Add(get_option_template_name(arr[i]["optionTemplateId"].ToString()));

                        lvItem.SubItems.Add(arr[i]["badgesId"].ToString());
                        lvItem.SubItems.Add(get_badges_name(arr[i]["badgesId"].ToString()));


                        lvItem.SubItems.Add(arr[i]["memo"].ToString());

                        if (tCutout == "Y")  // 중지
                        {
                            lvItem.ForeColor = Color.LightGray;
                            lvItem.SubItems[1].ForeColor = Color.LightGray;
                            lvItem.SubItems[2].ForeColor = Color.LightGray;
                            lvItem.SubItems[3].ForeColor = Color.LightGray;
                            lvItem.SubItems[4].ForeColor = Color.LightGray;
                            lvItem.SubItems[5].ForeColor = Color.LightGray;
                        }
                        else if (tSoldout == "Y")  // 품절
                        {
                            lvItem.ForeColor = Color.Red;
                            lvItem.SubItems[1].ForeColor = Color.Red;
                            lvItem.SubItems[2].ForeColor = Color.Red;
                            lvItem.SubItems[3].ForeColor = Color.Red;
                            lvItem.SubItems[4].ForeColor = Color.Red;
                            lvItem.SubItems[5].ForeColor = Color.Red;
                        }
                        else
                        {
                            lvItem.ForeColor = Color.Black;
                            lvItem.SubItems[1].ForeColor = Color.Black;
                            lvItem.SubItems[2].ForeColor = Color.Black;
                            lvItem.SubItems[3].ForeColor = Color.Black;
                            lvItem.SubItems[4].ForeColor = Color.Black;
                            lvItem.SubItems[5].ForeColor = Color.Black;
                        }


                        lvItem.Tag = arr[i]["imagePath"].ToString();



                        lvwList.Items.Add(lvItem);


                        int code_num = 0;
                        if (get_number(arr[i]["goodsCode"].ToString(), ref code_num))
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


        private ListViewItem reload_select(string code)
        {
            String tTicket, tTaxFree, tCutout, tSoldout = "";

            String sUrl = "goods?siteId=" + mSiteId + "&goodsCode=" + code;
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
                            lvItem = new ListViewItem(arr[0]["goodsName"].ToString());
                        else
                            lvItem = new ListViewItem(arr[0]["goodsName"].ToString(), 0);  // image index = 0

                        lvItem.SubItems.Add(arr[0]["goodsNameEn"].ToString());
                        lvItem.SubItems.Add(arr[0]["goodsNameCh"].ToString());
                        lvItem.SubItems.Add(arr[0]["goodsNameJp"].ToString());

                        // goodscode
                        lvItem.SubItems.Add(arr[0]["goodsCode"].ToString());
                        lvItem.SubItems.Add(arr[0]["amt"].ToString());
                        lvItem.SubItems.Add(arr[0]["shopCode"].ToString());
                        lvItem.SubItems.Add(get_shop_name(arr[0]["shopCode"].ToString()));

                        tTicket = "";
                        tTaxFree = "";
                        tCutout = "";
                        tSoldout = "";

                        if (arr[0]["ticketYn"].ToString() == "Y") tTicket = "Y";
                        if (arr[0]["taxFree"].ToString() == "Y") tTaxFree = "Y";
                        if (arr[0]["cutout"].ToString() == "Y") tCutout = "Y";
                        if (arr[0]["soldout"].ToString() == "Y") tSoldout = "Y";

                        lvItem.SubItems.Add(tTicket);
                        lvItem.SubItems.Add(tTaxFree);
                        lvItem.SubItems.Add(tCutout);
                        lvItem.SubItems.Add(tSoldout);

                        lvItem.SubItems.Add(arr[0]["optionTemplateId"].ToString());
                        lvItem.SubItems.Add(get_option_template_name(arr[0]["optionTemplateId"].ToString()));

                        lvItem.SubItems.Add(arr[0]["badgesId"].ToString());
                        lvItem.SubItems.Add(get_badges_name(arr[0]["badgesId"].ToString()));


                        lvItem.SubItems.Add(arr[0]["memo"].ToString());



                        if (tCutout == "Y")  // 중지
                        {
                            lvItem.ForeColor = Color.LightGray;
                            lvItem.SubItems[1].ForeColor = Color.LightGray;
                            lvItem.SubItems[2].ForeColor = Color.LightGray;
                            lvItem.SubItems[3].ForeColor = Color.LightGray;
                            lvItem.SubItems[4].ForeColor = Color.LightGray;
                            lvItem.SubItems[5].ForeColor = Color.LightGray;
                        }
                        else if (tSoldout == "Y")  // 품절
                        {
                            lvItem.ForeColor = Color.Red;
                            lvItem.SubItems[1].ForeColor = Color.Red;
                            lvItem.SubItems[2].ForeColor = Color.Red;
                            lvItem.SubItems[3].ForeColor = Color.Red;
                            lvItem.SubItems[4].ForeColor = Color.Red;
                            lvItem.SubItems[5].ForeColor = Color.Red;
                        }
                        else
                        {
                            lvItem.ForeColor = Color.Black;
                            lvItem.SubItems[1].ForeColor = Color.Black;
                            lvItem.SubItems[2].ForeColor = Color.Black;
                            lvItem.SubItems[3].ForeColor = Color.Black;
                            lvItem.SubItems[4].ForeColor = Color.Black;
                            lvItem.SubItems[5].ForeColor = Color.Black;
                        }

                        lvItem.Tag = arr[0]["imagePath"].ToString();


                        int code_num = 0;
                        if (get_number(arr[0]["goodsCode"].ToString(), ref code_num))
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
                    MessageBox.Show("상품정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
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



            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(ticket)].Text == "Y")
                cbTicket.Checked = true;
            else
                cbTicket.Checked = false;

            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(taxfree)].Text == "Y")
                cbTaxFree.Checked = true;
            else
                cbTaxFree.Checked = false;

            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(cutout)].Text == "Y")
                cbCutout.Checked = true;
            else
                cbCutout.Checked = false;

            if (lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(soldout)].Text == "Y")
                cbSoldout.Checked = true;
            else
                cbSoldout.Checked = false;


            //
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

            //

            String id = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(option_id)].Text;

            if (id == "")
            {
                cbOptionTemplate.SelectedIndex = -1;
            }
            else
            {
                for (int i = 0; i < mOptionTemplate.Length; i++)
                {
                    if (mOptionTemplate[i].option_template_id == id)
                    {
                        cbOptionTemplate.SelectedIndex = i;
                    }
                }
            }


            // 배지
            id = lvwList.SelectedItems[0].SubItems[lvwList.Columns.IndexOf(badges_id)].Text;

            for (int i = 0; i < mBadges.Length; i++)
            {
                if (mBadges[i].badges_id == id)
                {
                    cbBadges.SelectedIndex = i;
                }
            }



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
            sv_goodsName = tbGoodsName.Text;
            sv_goodsNameEN = tbGoodsNameEN.Text;
            sv_goodsNameCH = tbGoodsNameCH.Text;
            sv_goodsNameJP = tbGoodsNameJP.Text;

            sv_amt = tbGoodsAmt.Text;
            sv_shopCode = cbShop.SelectedIndex + "";
            sv_ticketYn = cbTicket.Checked + "";
            sv_taxFree = cbTaxFree.Checked + "";
            sv_cutout = cbCutout.Checked + "";
            sv_soldout = cbSoldout.Checked + "";

            sv_option_template_id = cbOptionTemplate.SelectedIndex + "";
            sv_badges_id = cbBadges.SelectedIndex + "";

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
            parameters["goodsCode"] = select_goodscode;

            // 변경된 항목만 파라메터에 넣는다.
            // 
            if (sv_goodsName != tbGoodsName.Text.Trim())
                parameters["goodsName"] = tbGoodsName.Text.Trim();

            if (sv_goodsNameEN != tbGoodsNameEN.Text.Trim())
                parameters["goodsNameEn"] = tbGoodsNameEN.Text.Trim();

            if (sv_goodsNameCH != tbGoodsNameCH.Text.Trim())
                parameters["goodsNameCh"] = tbGoodsNameCH.Text.Trim();

            if (sv_goodsNameJP != tbGoodsNameJP.Text.Trim())
                parameters["goodsNameJp"] = tbGoodsNameJP.Text.Trim();

            // notice



            //
            if (sv_ticketYn != cbTicket.Checked + "")
            {
                if (cbTicket.Checked)
                    parameters["ticketYn"] = "Y";
                else
                    parameters["ticketYn"] = "";
            }

            //
            if (sv_taxFree != cbTaxFree.Checked + "")
            {
                if (cbTaxFree.Checked)
                    parameters["taxFree"] = "Y";
                else
                    parameters["taxFree"] = "";
            }

            //
            if (sv_cutout != cbCutout.Checked + "")
            {
                if (cbCutout.Checked)
                    parameters["cutout"] = "Y";
                else
                    parameters["cutout"] = "";
            }

            //
            if (sv_soldout != cbSoldout.Checked + "")
            {
                if (cbSoldout.Checked)
                    parameters["soldout"] = "Y";
                else
                    parameters["soldout"] = "";
            }


            //
            if (sv_amt != tbGoodsAmt.Text)
                parameters["amt"] = tbGoodsAmt.Text;

            //
            if (sv_shopCode != cbShop.SelectedIndex + "")
                parameters["shopCode"] = mShop[cbShop.SelectedIndex].shop_code;


            //
            if (sv_option_template_id != cbOptionTemplate.SelectedIndex + "")
            {
                if (cbOptionTemplate.SelectedIndex > -1)
                {
                    parameters["optionTemplateId"] = mOptionTemplate[cbOptionTemplate.SelectedIndex].option_template_id;
                }
                else
                {
                    parameters["optionTemplateId"] = "";
                }
            }


            // 배지
            if (sv_badges_id != cbBadges.SelectedIndex + "")
            {
                if (cbBadges.SelectedIndex > -1)
                {
                    parameters["badgesId"] = mBadges[cbBadges.SelectedIndex].badges_id;
                }
                else
                {
                    parameters["badgesId"] = "";
                }
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
            ListViewItem lvItem = reload_select(select_goodscode);

            if (lvItem != null)
            {
                lvwList.Items[select_index] = lvItem;
                lvItem.Selected = true;
                lvwList.Select();
                lvwList.EnsureVisible(select_index);
            }

            //
            set_version_basic_db_change();


            //MessageBox.Show("정상 수정 완료.", "thepos");
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
            parameters["goodsCode"] = max_goodscode.ToString();

            parameters["goodsName"] = tbGoodsName.Text.Trim();
            parameters["goodsNameEN"] = tbGoodsNameEN.Text.Trim();
            parameters["goodsNameCH"] = tbGoodsNameCH.Text.Trim();
            parameters["goodsNameJP"] = tbGoodsNameJP.Text.Trim();




            if (cbTicket.Checked)
                parameters["ticketYn"] = "Y";
            else
                parameters["ticketYn"] = "N";

            if (cbTaxFree.Checked)
                parameters["taxFree"] = "Y";
            else
                parameters["taxFree"] = "N";

            if (cbCutout.Checked)
                parameters["cutout"] = "Y";
            else
                parameters["cutout"] = "N";

            if (cbSoldout.Checked)
                parameters["soldout"] = "Y";
            else
                parameters["soldout"] = "N";


            parameters["amt"] = tbGoodsAmt.Text;

            parameters["shopCode"] = mShop[cbShop.SelectedIndex].shop_code;



            //
            if (cbOptionTemplate.SelectedIndex > -1)
            {
                parameters["optionTemplateId"] = mOptionTemplate[cbOptionTemplate.SelectedIndex].option_template_id;
            }
            else
            {
                parameters["optionTemplateId"] = "";
            }


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
                    //MessageBox.Show("정상 등록 완료.", "thepos");
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
            ListViewItem lvItem = reload_select(max_goodscode.ToString());

            if (lvItem != null)
            {
                lvItem.Selected = true;
                lvwList.Items.Add(lvItem);
                lvwList.Select();

                lvwList.EnsureVisible(lvwList.Items.Count - 1);
            }

            //
            set_version_basic_db_change();

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
            parameters["goodsCode"] = tbGoodsName.Tag.ToString();


            if (mRequestDelete("goods", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 삭제 완료.", "thepos");
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
            lvwList.Items[select_index].Remove();

            //
            set_version_basic_db_change();

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
                if (order == SortOrder.Descending) returnVal *= -1; // Invert the value returned by String.Compare. 

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
