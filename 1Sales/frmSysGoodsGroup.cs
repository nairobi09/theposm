using System;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Policy;
using System.Linq;
using static thepos.thePos;
using Newtonsoft.Json.Linq;
using System.Drawing;

namespace thepos
{
    public partial class frmSysGoodsGroup : Form
    {
        GoodsGroup goodsGroup;


        public frmSysGoodsGroup()
        {
            InitializeComponent();
            initialize_font();
        }

        private void initialize_font()
        {
            lvwGoodsGroup.Font = font10;
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            lvwGoodsGroup.Items.Clear();
            tableLayoutPanelGoodsGroup.Controls.Clear();

            String jsonData = "";
            String URL = "http://211.42.156.219:8080/goodsGroup?siteId=sh01&posNo=01";

            int err = mGetAsync(URL, ref jsonData);

            if (err == 0)
            {
                JObject jObject = JObject.Parse(jsonData);
                String rCode = jObject["resultCode"].ToString();

                var groupData = jObject.SelectToken("goodsGroups");

                foreach (var itemGroup in groupData)
                {
                    String siteId = itemGroup.SelectToken("siteId").ToString();
                    String posNo = itemGroup.SelectToken("posNo").ToString();
                    String groupCode = itemGroup.SelectToken("groupCode").ToString();
                    String goodsGroupName = itemGroup.SelectToken("goodsGroupName").ToString();

                    String locateX = itemGroup.SelectToken("locateX").ToString();
                    String locateY = itemGroup.SelectToken("locateY").ToString();
                    String sizeX = itemGroup.SelectToken("sizeX").ToString();
                    String sizeY = itemGroup.SelectToken("sizeY").ToString();


                    ListViewItem item = new ListViewItem();

                    item.Text = groupCode;
                    item.SubItems.Add(goodsGroupName);

                    item.SubItems.Add(locateX);
                    item.SubItems.Add(locateY);
                    item.SubItems.Add(sizeX);
                    item.SubItems.Add(sizeY);
                    lvwGoodsGroup.Items.Add(item);



                    //

                    Button btnGoodsItem = new Button();

                    btnGoodsItem.FlatStyle = FlatStyle.Flat;
                    btnGoodsItem.ForeColor = Color.White;
                    btnGoodsItem.BackColor = Color.Gray;
                    btnGoodsItem.TabStop = false;
                    btnGoodsItem.Margin = new Padding(2, 2, 2, 2);
                    btnGoodsItem.Padding = new Padding(0, 0, 0, 0);
                    btnGoodsItem.Text = goodsGroupName;
                    btnGoodsItem.Dock = DockStyle.Fill;


                    int locX = convert_number(locateX);
                    int locY = convert_number(locateY);
                    int szX = convert_number(sizeX);
                    int szY = convert_number(sizeY);


                    if (szX == 1 | szY == 1)
                    {
                        btnGoodsItem.Font = font8;
                    }
                    else if (szX == 2 | szY == 2)
                    {
                        btnGoodsItem.Font = font14;
                    }
                    else
                    {
                        btnGoodsItem.Font = font20;
                    }


                    tableLayoutPanelGoodsGroup.Controls.Add(btnGoodsItem, locX, locY);
                    tableLayoutPanelGoodsGroup.SetColumnSpan(btnGoodsItem, szX);
                    tableLayoutPanelGoodsGroup.SetRowSpan(btnGoodsItem, szY);

                }






            }

        }

        private void lvwGoodsGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwGoodsGroup.SelectedItems.Count == 0) return;

            String code = lvwGoodsGroup.SelectedItems[0].Text;
            String name = lvwGoodsGroup.SelectedItems[0].SubItems[1].Text;
            int locX = convert_number(lvwGoodsGroup.SelectedItems[0].SubItems[2].Text);
            int locY = convert_number(lvwGoodsGroup.SelectedItems[0].SubItems[3].Text);
            int szX = convert_number(lvwGoodsGroup.SelectedItems[0].SubItems[4].Text);
            int szY = convert_number(lvwGoodsGroup.SelectedItems[0].SubItems[5].Text);



            Button btnGoodsItem = new Button();

            btnGoodsItem.FlatStyle = FlatStyle.Flat;
            btnGoodsItem.ForeColor = Color.White;
            btnGoodsItem.BackColor = SystemColors.Highlight;
            btnGoodsItem.TabStop = false;
            btnGoodsItem.Margin = new Padding(2, 2, 2, 2);
            btnGoodsItem.Padding = new Padding(0, 0, 0, 0);
            btnGoodsItem.Text = name;
            btnGoodsItem.Dock = DockStyle.Fill;

            if (szX == 1 | szY == 1)
            {
                btnGoodsItem.Font = font8;
            }
            else if (szX == 2 | szY == 2)
            {
                btnGoodsItem.Font = font14;
            }
            else
            {
                btnGoodsItem.Font = font20;
            }

            tableLayoutPanelGoodsGroup.Controls.Clear();

            tableLayoutPanelGoodsGroup.Controls.Add(btnGoodsItem, locX, locY);
            tableLayoutPanelGoodsGroup.SetColumnSpan(btnGoodsItem, szX);
            tableLayoutPanelGoodsGroup.SetRowSpan(btnGoodsItem, szY);



            tbGroupCode.Text = code;
            tbGroupName.Text = name;

            tbLocateX.Text = locX + "";
            tbLocateY.Text = locY + "";
            tbSizeX.Text = szX + "";
            tbSizeY.Text = szY + "";


        }
    }
}
