using Newtonsoft.Json.Linq;
using System;
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
        String mSelectedPosNo = "";
        String mSelectedGroupCode = "";

        private BindingList<object> groupList = new BindingList<object>();


        public frmSysGoodsItem()
        {
            InitializeComponent();
            initialize_font();

            get_goods();


            for (int i = 0; i < mPosNoList.Length; i++)
            {
                comboPosNo.Items.Add(mPosNoList[i]);
            }
            

        }

        private void initialize_font()
        {
            lblTitle.Font = font14;

            lblT1.Font = font12;
            comboPosNo.Font = font12;

            lblT2.Font = font12;
            comboGroup.Font = font12;

            btnView.Font = font10;

            lvwGoods.Font = font10;
            lvwGoodsLink.Font = font12;

            lblT3.Font = font10;
            lblT4.Font = font10;
            lblT5.Font = font10;
            lblT6.Font = font10;

            tbLocateX.Font = font12;
            tbLocateY.Font = font12;
            tbSizeX.Font = font12;
            tbSizeY.Font = font12;

            btnUpdate.Font = font10;
            btnDelete.Font = font10;
            btnLink.Font = font10;
            btnApply.Font = font10;

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
                        if (arr[i]["active"].ToString() == "Y")
                        {
                            ListViewItem lvItem = new ListViewItem();
                            lvItem.Text = arr[i]["itemName"].ToString();
                            lvItem.SubItems.Add(arr[i]["amt"].ToString());

                            tTicket = "";
                            tTaxFree = "";

                            if (arr[i]["ticketYn"].ToString() == "Y") tTicket = "Y";
                            if (arr[i]["taxFree"].ToString() == "Y") tTaxFree = "Y";

                            lvItem.SubItems.Add(tTicket);
                            lvItem.SubItems.Add(tTaxFree);
                            lvItem.SubItems.Add(arr[i]["memo"].ToString());

                            lvItem.Tag = arr[i]["itemCode"].ToString();

                            lvwGoods.Items.Add(lvItem);
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


        private void comboPosNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSelectedPosNo = comboPosNo.SelectedItem.ToString();


            String sUrl = "goodsGroup?siteId=" + mSiteId + "&posNo=" + mSelectedPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["goodsGroups"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        groupList.Add(new { Text = arr[i]["goodsGroupName"].ToString(), Value = arr[i]["groupCode"].ToString() });
                    }

                    comboGroup.DataSource = groupList;
                    comboGroup.DisplayMember = "Text";
                    comboGroup.ValueMember = "Value";

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



        private void btnView_Click(object sender, EventArgs e)
        {
            mSelectedGroupCode = comboGroup.SelectedValue.ToString();

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
                        lvItem.Text = arr[i]["itemName"].ToString();
                        lvItem.SubItems.Add(arr[i]["amt"].ToString());
                        lvItem.SubItems.Add(arr[i]["locateX"].ToString());
                        lvItem.SubItems.Add(arr[i]["locateY"].ToString());
                        lvItem.SubItems.Add(arr[i]["sizeX"].ToString());
                        lvItem.SubItems.Add(arr[i]["sizeY"].ToString());
                        lvItem.Tag = arr[i]["itemCode"].ToString();

                        lvwGoodsLink.Items.Add(lvItem);

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
                    btnItem.Text = lvwGoodsLink.Items[i].Text;
                    btnItem.Dock = DockStyle.Fill;

                    int locX = convert_number(lvwGoodsLink.Items[i].SubItems[2].Text);
                    int locY = convert_number(lvwGoodsLink.Items[i].SubItems[3].Text);
                    int szX = convert_number(lvwGoodsLink.Items[i].SubItems[4].Text);
                    int szY = convert_number(lvwGoodsLink.Items[i].SubItems[5].Text);

                    if (szX == 1) { btnItem.Font = font5; }
                    else if (szX >= 3 & szY >= 2) { btnItem.Font = font10; }
                    else { btnItem.Font = font8; }

                    tableLayoutPanelItem.Controls.Add(btnItem, locX, locY);
                    tableLayoutPanelItem.SetColumnSpan(btnItem, szX);
                    tableLayoutPanelItem.SetRowSpan(btnItem, szY);
                }
                catch (Exception ex)
                {

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
                tbLocateX.Text = lvwGoodsLink.SelectedItems[0].SubItems[2].Text;
                tbLocateY.Text = lvwGoodsLink.SelectedItems[0].SubItems[3].Text;
                tbSizeX.Text = lvwGoodsLink.SelectedItems[0].SubItems[4].Text;
                tbSizeY.Text = lvwGoodsLink.SelectedItems[0].SubItems[5].Text;

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
                btnGroupBlue.Text = lvwGoodsLink.SelectedItems[0].Text + "\n" + lvwGoodsLink.SelectedItems[0].SubItems[1].Text;
                btnGroupBlue.Dock = DockStyle.Fill;

                if (szX == 1 | szY == 1) { btnGroupBlue.Font = font9; }
                else if (szY == 2) { btnGroupBlue.Font = font14; }
                else { btnGroupBlue.Font = font20; }

                tableLayoutPanelItemSelected.Controls.Add(btnGroupBlue, locX, locY);
                tableLayoutPanelItemSelected.SetColumnSpan(btnGroupBlue, szX);
                tableLayoutPanelItemSelected.SetRowSpan(btnGroupBlue, szY);
            }
            catch (Exception ex)
            {

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
            parameters["itemCode"] = lvwGoodsLink.SelectedItems[0].Tag.ToString();
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



            String mSelecteditemCode = lvwGoodsLink.SelectedItems[0].Tag.ToString();


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = mSelectedPosNo;
            parameters["groupCode"] = mSelectedGroupCode;
            parameters["itemCode"] = mSelecteditemCode;


            if (mRequestDelete("goodsItem", parameters))
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


            String mSelecteditemCode = lvwGoods.SelectedItems[0].Tag.ToString();


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = mSelectedPosNo;
            parameters["groupCode"] = mSelectedGroupCode;
            parameters["itemCode"] = lvwGoods.SelectedItems[0].Tag.ToString();
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

            display_all_console();


            //
            for (int i = 0; i < lvwGoodsLink.Items.Count; i++)
            {
                if (lvwGoodsLink.Items[i].Tag.ToString() == mSelecteditemCode)
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


    }
}
