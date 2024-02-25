using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;


namespace thepos
{
    public partial class frmSysOptionTemplate : Form
    {

        String selected_option_template_id = "";
        String selected_option_id = "";
        
        int max_option_id = 0;
        int max_option_item_id = 0;


        List<String> this_option_id = new List<String>();
        List<String> this_option_name = new List<String>();


        public frmSysOptionTemplate()
        {
            InitializeComponent();


            load_template();

        }



        private void load_template()
        {
            lvwTemplete.Items.Clear();

            clear_option_console();
            clear_option_item_console();


            String sUrl = "optionTemplate?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["optionTemp"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem;
                        lvItem = new ListViewItem(arr[i]["optionTemplateId"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionTemplateName"].ToString());
                        lvwTemplete.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("옵션템플릿정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }
        }

        private void clear_option_console()
        {
            //
            lvwOption.Items.Clear();
            chkTurnoff.Checked = false;
            tbOptionName.Text = "";
            tbOptionNameEN.Text = "";
            tbOptionNameCH.Text = "";
            tbOptionNameJP.Text = "";
        }

        private void clear_option_item_console()
        {
            //
            lvwOptionItem.Items.Clear();
            tbOptionItemName.Text = "";
            tbOptionItemNameEN.Text = "";
            tbOptionItemNameCH.Text = "";
            tbOptionItemNameJP.Text = "";
            tbOptionItemAmt.Text = "";
            cbLinkOption.SelectedIndex = -1;

        }


        private void lvwTemplete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwTemplete.SelectedItems.Count == 0) { return; }

            selected_option_template_id = lvwTemplete.SelectedItems[0].Text;
            selected_option_id = "";

            tbOptionTemplateId.Text = lvwTemplete.SelectedItems[0].Text;
            tbOptionTemplateName.Text = lvwTemplete.SelectedItems[0].SubItems[1].Text;

            //
            clear_option_console();

            String sUrl = "tempOption?siteId=" + mSiteId + "&optionTemplateId=" + selected_option_template_id;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["tempOption"].ToString();
                    JArray arr = JArray.Parse(pos);

                    max_option_id = 10;

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem;
                        lvItem = new ListViewItem(arr[i]["optionSeq"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionName"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionNameEn"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionNameCh"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionNameJp"].ToString());

                        lvItem.SubItems.Add(arr[i]["nextOptionId"].ToString());
                        lvItem.SubItems.Add(get_temp_option_name(arr[i]["nextOptionId"].ToString()));
                        lvItem.SubItems.Add(arr[i]["isTurnoff"].ToString());

                        lvItem.Tag = arr[i]["optionId"].ToString();

                        lvwOption.Items.Add(lvItem);

                        int t_no = convert_number(arr[i]["optionId"].ToString());

                        if (max_option_id < t_no)
                        {
                            max_option_id = t_no;
                        }
                    }

                    //
                    set_this_option();

                    for (int i = 0; i < lvwOption.Items.Count; i++)
                    {
                        if (lvwOption.Items[i].SubItems[lvwOption.Columns.IndexOf(next_option_id)].Text != "")
                        {
                            lvwOption.Items[i].SubItems[lvwOption.Columns.IndexOf(next_option_name)].Text = get_temp_option_name(lvwOption.Items[i].SubItems[lvwOption.Columns.IndexOf(next_option_id)].Text);
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



        private void btnAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvwTemplete.Items.Count; i++)
            {
                if (lvwTemplete.Items[i].Text.Trim() == tbOptionTemplateId.Text.Trim())
                {
                    MessageBox.Show("동일한 템플릿ID가 이미 있습니다..", "thepos");
                    return;
                }
            }

            for (int i = 0; i < lvwTemplete.Items.Count; i++)
            {
                if (lvwTemplete.Items[i].SubItems[1].Text.Trim() == tbOptionTemplateName.Text.Trim())
                {
                    MessageBox.Show("동일한 템플릿명이 이미 있습니다..", "thepos");
                    return;
                }
            }





            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["optionTemplateId"] = tbOptionTemplateId.Text;
            parameters["optionTemplateName"] = tbOptionTemplateName.Text;

            if (mRequestPost("optionTemplate", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    load_template();
                }
                else
                {
                    MessageBox.Show("옵션템프릿정보 입력오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbOptionTemplateId.Text.Trim() != lvwTemplete.SelectedItems[0].Text.Trim())
            {
                MessageBox.Show("템프릿ID는 수정할 수 없습니다.", "thepos");
                return;
            }



            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["optionTemplateId"] = tbOptionTemplateId.Text;
            parameters["optionTemplateName"] = tbOptionTemplateName.Text;

            if (mRequestPatch("optionTemplate", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    load_template();
                }
                else
                {
                    MessageBox.Show("옵션템프릿정보 수정오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["optionTemplateId"] = tbOptionTemplateId.Text;

            if (mRequestDelete("optionTemplate", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    load_template();
                }
                else
                {
                    MessageBox.Show("옵션템프릿정보 수정오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
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
            chkTurnoff.Checked = false;

            clear_option_item_console();


            if (lvwOption.SelectedItems.Count == 0) { return; }


            selected_option_id = lvwOption.SelectedItems[0].Tag.ToString();


            tbOptionName.Text = lvwOption.SelectedItems[0].SubItems[lvwOption.Columns.IndexOf(option_name)].Text;
            tbOptionNameEN.Text = lvwOption.SelectedItems[0].SubItems[lvwOption.Columns.IndexOf(option_name_en)].Text;
            tbOptionNameCH.Text = lvwOption.SelectedItems[0].SubItems[lvwOption.Columns.IndexOf(option_name_ch)].Text;
            tbOptionNameJP.Text = lvwOption.SelectedItems[0].SubItems[lvwOption.Columns.IndexOf(option_name_jp)].Text;

            //
            for (int i = 0; i < this_option_id.Count; i++)
            {
                if (lvwOption.SelectedItems[0].SubItems[lvwOption.Columns.IndexOf(next_option_id)].Text == this_option_id[i])
                {
                    cbNextOption.SelectedIndex = i;
                }
            }

            //
            if (lvwOption.SelectedItems[0].SubItems[lvwOption.Columns.IndexOf(is_turnoff)].Text.ToString() == "Y")
            {
                chkTurnoff.Checked = true;
            }


            //
            String sUrl = "tempOptionItem?siteId=" + mSiteId + "&optionTemplateId=" + selected_option_template_id + "&optionId=" + selected_option_id;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["optionItem"].ToString();
                    JArray arr = JArray.Parse(pos);

                    max_option_item_id = 20;


                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem;
                        lvItem = new ListViewItem(arr[i]["optionItemSeq"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionItemName"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionItemNameEn"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionItemNameCh"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionItemNameJp"].ToString());
                        lvItem.SubItems.Add(arr[i]["optionItemAmt"].ToString());
                        lvItem.SubItems.Add(arr[i]["linkOptionId"].ToString());

                        lvItem.SubItems.Add(get_temp_option_name(arr[i]["linkOptionId"].ToString()));

                        lvItem.Tag = arr[i]["optionItemId"].ToString();
                        lvwOptionItem.Items.Add(lvItem);


                        int t_no = convert_number(arr[i]["optionItemId"].ToString());

                        if (max_option_item_id < t_no)
                        {
                            max_option_item_id = t_no;
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
        }



        private String get_temp_option_name(String option_id)
        {
            for (int i = 0; i < this_option_id.Count; i++)
            {
                if (this_option_id[i] == option_id)
                {
                    return this_option_name[i];
                }
            }
            return option_id;
        }



        private void btnAdd1_Click(object sender, EventArgs e)
        {
            if (lvwOption.Items.Count >= 10)
            {
                MessageBox.Show("옵션은 최대 5개까지 입력가능합니다.", "thepos");
                return;
            }

            ListViewItem lvItem = new ListViewItem("");
            lvItem.SubItems.Add(tbOptionName.Text);
            lvItem.SubItems.Add(tbOptionNameEN.Text);
            lvItem.SubItems.Add(tbOptionNameCH.Text);
            lvItem.SubItems.Add(tbOptionNameJP.Text);

            if (cbNextOption.SelectedIndex == -1) cbNextOption.SelectedIndex = 0;

            lvItem.SubItems.Add(this_option_id[cbNextOption.SelectedIndex]);
            lvItem.SubItems.Add(this_option_name[cbNextOption.SelectedIndex]);


            if (chkTurnoff.Checked)
            {
                lvItem.SubItems.Add("Y");
            }
            else
            {
                lvItem.SubItems.Add("");
            }

            lvItem.Tag = ++max_option_id;

            lvwOption.Items.Add(lvItem);

        }


        private void btnUpdate1_Click(object sender, EventArgs e)
        {
            if (lvwOption.SelectedItems.Count == 0) { return; }

            lvwOption.SelectedItems[0].SubItems[1].Text = tbOptionName.Text;
            lvwOption.SelectedItems[0].SubItems[2].Text = tbOptionNameEN.Text;
            lvwOption.SelectedItems[0].SubItems[3].Text = tbOptionNameCH.Text;
            lvwOption.SelectedItems[0].SubItems[4].Text = tbOptionNameJP.Text;

            lvwOption.SelectedItems[0].SubItems[5].Text = this_option_id[cbNextOption.SelectedIndex];
            lvwOption.SelectedItems[0].SubItems[6].Text = this_option_name[cbNextOption.SelectedIndex];

            if (chkTurnoff.Checked)
            {
                lvwOption.SelectedItems[0].SubItems[7].Text = "Y";
            }
            else
            {
                lvwOption.SelectedItems[0].SubItems[7].Text = "";
            }

        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (lvwOption.SelectedItems.Count == 0) { return; }

            if (lvwOptionItem.Items.Count > 0)
            {
                MessageBox.Show("연결된 [옵션항목]이 있습니다. [옵션항목]삭제후 [옵션]삭제 가능합니다.", "thepos");
                return;
            }

            lvwOption.SelectedItems[0].Remove();

            set_this_option();
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


        private void btnSave1_Click(object sender, EventArgs e)
        {
            // 전체 삭제
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["optionTemplateId"] = selected_option_template_id;

            if (mRequestDelete("tempOption", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                }
                else
                {
                    MessageBox.Show("옵션정보 삭제오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }


            // 정렬
            for (int i = 0; i < lvwOption.Items.Count; i++)
            {
                lvwOption.Items[i].Text = (i + 1).ToString();
            }


            // 차례로 추가
            for (int i = 0; i < lvwOption.Items.Count; i++)
            {
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["optionTemplateId"] = selected_option_template_id;
                parameters["optionId"] = lvwOption.Items[i].Tag.ToString();
                parameters["optionSeq"] = lvwOption.Items[i].Text;

                parameters["isTurnoff"] = lvwOption.Items[i].SubItems[lvwOption.Columns.IndexOf(is_turnoff)].Text;
                parameters["nextOptionId"] = lvwOption.Items[i].SubItems[lvwOption.Columns.IndexOf(next_option_id)].Text;

                parameters["optionName"] = lvwOption.Items[i].SubItems[1].Text;
                parameters["optionNameEn"] = lvwOption.Items[i].SubItems[2].Text;
                parameters["optionNameCh"] = lvwOption.Items[i].SubItems[3].Text;
                parameters["optionNameJp"] = lvwOption.Items[i].SubItems[4].Text;

                if (mRequestPost("tempOption", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {

                    }
                    else
                    {
                        MessageBox.Show("옵션정보 입력오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }

            set_this_option();

            //
            set_version_basic_db_change();

            MessageBox.Show("정상 저장 완료.", "thepos");

        }




        private void set_this_option()
        {
            //
            this_option_id.Clear();
            this_option_name.Clear();

            this_option_id.Add("");
            this_option_name.Add("");

            for (int i = 0; i < lvwOption.Items.Count; i++) 
            {
                this_option_id.Add(lvwOption.Items[i].Tag.ToString());
                this_option_name.Add(lvwOption.Items[i].SubItems[1].Text);
            }

            //
            cbNextOption.Items.Clear();
            cbNextOption.Text = "";

            cbLinkOption.Items.Clear();
            cbLinkOption.Text = "";

            for (int i = 0; i < this_option_id.Count; i++)
            {
                cbNextOption.Items.Add(this_option_name[i]);
                cbLinkOption.Items.Add(this_option_name[i]);
            }
        }




        private void lvwOptionItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwOptionItem.SelectedItems.Count == 0) { return; }


            //
            tbOptionItemName.Text = lvwOptionItem.SelectedItems[0].SubItems[1].Text;
            tbOptionItemNameEN.Text = lvwOptionItem.SelectedItems[0].SubItems[2].Text;
            tbOptionItemNameCH.Text = lvwOptionItem.SelectedItems[0].SubItems[3].Text;
            tbOptionItemNameJP.Text = lvwOptionItem.SelectedItems[0].SubItems[4].Text;
            tbOptionItemAmt.Text = lvwOptionItem.SelectedItems[0].SubItems[5].Text;

            for (int i = 0; i < this_option_id.Count; i++)
            {
                if (lvwOptionItem.SelectedItems[0].SubItems[6].Text == this_option_id[i])
                {
                    cbLinkOption.SelectedIndex = i;
                }
            }
            




        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (lvwOptionItem.Items.Count >= 4)
            {
                MessageBox.Show("옵션항목은 최대 4개까지 입력가능합니다.", "thepos");
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

            if (cbLinkOption.SelectedIndex > -1)
            {
                lvItem.SubItems.Add(this_option_id[cbLinkOption.SelectedIndex]);
                lvItem.SubItems.Add(this_option_name[cbLinkOption.SelectedIndex]);
            }
            else
            {
                lvItem.SubItems.Add("");
                lvItem.SubItems.Add("");
            }

            lvItem.Tag = ++max_option_item_id;

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

            if (cbLinkOption.SelectedIndex > -1)
            {
                lvwOptionItem.SelectedItems[0].SubItems[lvwOptionItem.Columns.IndexOf(link_option_id1)].Text = this_option_id[cbLinkOption.SelectedIndex];
                lvwOptionItem.SelectedItems[0].SubItems[lvwOptionItem.Columns.IndexOf(link_option_name1)].Text = this_option_name[cbLinkOption.SelectedIndex];
            }
            else
            {
                lvwOptionItem.SelectedItems[0].SubItems[lvwOptionItem.Columns.IndexOf(link_option_id1)].Text = "";
                lvwOptionItem.SelectedItems[0].SubItems[lvwOptionItem.Columns.IndexOf(link_option_name1)].Text = "";
            }

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
            parameters["optionTemplateId"] = selected_option_template_id;
            parameters["optionId"] = selected_option_id;

            if (mRequestDelete("tempOptionItem", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                }
                else
                {
                    MessageBox.Show("옵션아이템 정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }


            // 정렬
            for (int i = 0; i < lvwOptionItem.Items.Count; i++)
            {
                lvwOptionItem.Items[i].Text = (i + 1).ToString();
            }

            // 차례로 추가
            for (int i = 0; i < lvwOptionItem.Items.Count; i++)
            {
                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["optionTemplateId"] = selected_option_template_id;
                parameters["optionId"] = selected_option_id;
                parameters["optionItemId"] = lvwOptionItem.Items[i].Tag.ToString();
                parameters["optionItemSeq"] = lvwOptionItem.Items[i].Text;
                parameters["linkOptionId"] = lvwOptionItem.Items[i].SubItems[6].Text;

                parameters["optionItemName"] = lvwOptionItem.Items[i].SubItems[1].Text;
                parameters["optionItemNameEn"] = lvwOptionItem.Items[i].SubItems[2].Text;
                parameters["optionItemNameCh"] = lvwOptionItem.Items[i].SubItems[3].Text;
                parameters["optionItemNameJp"] = lvwOptionItem.Items[i].SubItems[4].Text;
                parameters["optionItemAmt"] = lvwOptionItem.Items[i].SubItems[5].Text;

                if (mRequestPost("tempOptionItem", parameters))
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


    }
}
