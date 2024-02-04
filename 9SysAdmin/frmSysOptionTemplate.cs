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


        List<String> link_option_id = new List<String>();
        List<String> link_option_name = new List<String>();


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
            chkInitDsp.Checked = false;
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

            String selected_option_templete_id = lvwTemplete.SelectedItems[0].Text;
            selected_option_id = "";

            tbOptionTemplateId.Text = lvwTemplete.SelectedItems[0].Text;
            tbOptionTemplateName.Text = lvwTemplete.SelectedItems[0].SubItems[1].Text;

            //
            clear_option_console();

            String sUrl = "tempOption?siteId=" + mSiteId + "&optionTemplateId=" + selected_option_templete_id;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["tempOption"].ToString();
                    JArray arr = JArray.Parse(pos);

                    max_option_id = 11;

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

                        if (max_option_id < t_no)
                        {
                            max_option_id = t_no;
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
            chkInitDsp.Checked = false;

            clear_option_item_console();


            if (lvwOption.SelectedItems.Count == 0) { return; }


            selected_option_id = lvwOption.SelectedItems[0].Tag.ToString();


            tbOptionName.Text = lvwOption.SelectedItems[0].SubItems[1].Text;
            tbOptionNameEN.Text = lvwOption.SelectedItems[0].SubItems[2].Text;
            tbOptionNameCH.Text = lvwOption.SelectedItems[0].SubItems[3].Text;
            tbOptionNameJP.Text = lvwOption.SelectedItems[0].SubItems[4].Text;
            if (lvwOption.SelectedItems[0].SubItems[5].Text == "Y")
            {
                chkInitDsp.Checked = true;
            }


            //
            String sUrl = "tempOptionItem?siteId=" + mSiteId + "&optionTemplateId=" + selected_option_template_id + "&optionId=" + selected_option_id;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["optionItem"].ToString();
                    JArray arr = JArray.Parse(pos);

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
            for (int i = 0; i < lvwOption.Items.Count; i++)
            {
                if (lvwOption.Items[i].Tag.ToString() == option_id)
                {
                    return lvwOption.Items[i].SubItems[1].Text;
                }
            }

            return option_id;
        }



        private void btnAdd1_Click(object sender, EventArgs e)
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
            lvItem.Tag = ++max_option_id;

            lvwOption.Items.Add(lvItem);


            set_link_option();

        }


        private void btnUpdate1_Click(object sender, EventArgs e)
        {
            if (lvwOption.SelectedItems.Count == 0) { return; }

            lvwOption.SelectedItems[0].SubItems[1].Text = tbOptionName.Text;
            lvwOption.SelectedItems[0].SubItems[2].Text = tbOptionNameEN.Text;
            lvwOption.SelectedItems[0].SubItems[3].Text = tbOptionNameCH.Text;
            lvwOption.SelectedItems[0].SubItems[4].Text = tbOptionNameJP.Text;

            set_link_option();
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

            set_link_option();
        }


        private void set_link_option()
        {
            link_option_id.Clear();
            link_option_name.Clear();

            for (int i = 0; i < lvwOption.Items.Count; i++) 
            {
                link_option_id.Add(lvwOption.Items[i].Tag.ToString());
                link_option_name.Add(lvwOptionItem.Items[i].SubItems[1].ToString());
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

            




        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate2_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {

        }



    }
}
