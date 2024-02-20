using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;

namespace thepos
{
    public partial class frmReportShopOrder : Form
    {
        String thisBizDt = "";

        public frmReportShopOrder()
        {
            InitializeComponent();
            initialize_font();
            initialize_the();
        }

        private void initialize_font()
        {
            lblReportTitle.Font = font10;
            dtpBizDate.Font = font10;
            cbShop.Font = font10;

            lvwList.Font = font10;
            btnView.Font = font10;
        }

        private void initialize_the()
        {
            if (mBizDate == "")
            {

            }
            else
            {
                dtpBizDate.Value = new DateTime(convert_number(mBizDate.Substring(0, 4)), convert_number(mBizDate.Substring(4, 2)), convert_number(mBizDate.Substring(6, 2)));
            }


            cbShop.Items.Clear();
            for (int i = 0; i < mShop.Length; i++)
            {
                cbShop.Items.Add(mShop[i].shop_name);
            }
            cbShop.SelectedIndex = 0;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            thisBizDt = dtpBizDate.Value.ToString("yyyyMMdd");

            String shop_code = "";

            if (cbShop.SelectedIndex > 0)
            {
                shop_code = mShop[cbShop.SelectedIndex - 1].shop_code;
            }

            lvwList.Items.Clear();


            String sUrl = "orderItem?siteId=" + mSiteId + "&bizDt=" + thisBizDt + "&shopCode=" + shop_code;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orderItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                    ///    if (arr[i]["shopOrderNo"].ToString().Length >= 4)
                        {
                            if (shop_code == "" | (shop_code != "" & shop_code == arr[i]["shopCode"].ToString()))
                            {
                                String is_cancel = arr[i]["isCancel"].ToString();



                                if (arr[i]["tranType"].ToString() == "A")
                                {
                                    ListViewItem lvItem = new ListViewItem();

                                    lvItem.Text = arr[i]["shopOrderNo"].ToString();
                                    lvItem.SubItems.Add(get_shop_name(arr[i]["shopCode"].ToString()));
                                    lvItem.SubItems.Add(get_MMddHHmm(arr[i]["orderDate"].ToString(), arr[i]["orderTime"].ToString()));
                                    lvItem.SubItems.Add(arr[i]["posNo"].ToString());
                                    lvItem.SubItems.Add(arr[i]["goodsName"].ToString());
                                    lvItem.SubItems.Add(arr[i]["cnt"].ToString());
                                    //lvItem.SubItems.Add(get_tran_type_name(arr[i]["tranType"].ToString()));
                                    lvItem.SubItems.Add(is_cancel);

                                    if (is_cancel == "Y" | is_cancel == "y")
                                    {
                                        lvItem.ForeColor = Color.Gray;
                                        lvItem.SubItems[1].ForeColor = Color.Gray;
                                        lvItem.SubItems[2].ForeColor = Color.Gray;
                                        lvItem.SubItems[3].ForeColor = Color.Gray;
                                        lvItem.SubItems[4].ForeColor = Color.Gray;
                                        lvItem.SubItems[5].ForeColor = Color.Gray;
                                        lvItem.SubItems[6].ForeColor = Color.Gray;
                                    }

                                    lvwList.Items.Add(lvItem);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
            }


        }

    }
}
