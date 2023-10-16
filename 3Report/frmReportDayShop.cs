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
    public partial class frmReportDayShop : Form
    {
        String thisBizDt = "";


        public frmReportDayShop()
        {
            InitializeComponent();
            initialize_font();
            initialize_the();
        }

        private void initialize_font()
        {
            lblReportTitle.Font = font10;
            
            dtpBizDate.Font = font12;
            cbShop.Font = font12;

            btnView.Font = font10;


            lvwList.Font = font10;

        }

        private void initialize_the()
        {
            dtpBizDate.Value = new DateTime(convert_number(mBizDate.Substring(0, 4)), convert_number(mBizDate.Substring(4, 2)), convert_number(mBizDate.Substring(6, 2)));



            cbShop.Items.Clear();
            cbShop.Items.Add("");
            for (int i = 0; i < mPosNoList.Length; i++)
            {
                cbShop.Items.Add(mShop[i].shop_name);
            }
            cbShop.SelectedIndex = 0;


        }

        private void btnView_Click(object sender, EventArgs e)
        {

            thisBizDt = dtpBizDate.Value.ToString("yyyyMMdd");

            lvwList.Items.Clear();


            String sUrl = "reportDayShop?siteId=" + mSiteId + "&bizDt=" + thisBizDt;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["dayShops"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();

                        lvItem.Text = get_shop_name(arr[i]["shopCode"].ToString());
                        lvItem.SubItems.Add(get_goods_name(arr[i]["itemCode"].ToString()));
                        lvItem.SubItems.Add((convert_number(arr[i]["cnt"].ToString())).ToString("N0"));
                        lvItem.SubItems.Add((convert_number(arr[i]["amount"].ToString())).ToString("N0"));
                        lvItem.SubItems.Add((convert_number(arr[i]["dcAmount"].ToString())).ToString("N0"));
                        lvItem.SubItems.Add((convert_number(arr[i]["netAmount"].ToString())).ToString("N0"));

                        lvwList.Items.Add(lvItem);
                    }

                }
                else
                {
                    MessageBox.Show("결제데이터 오류. payment\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
            }



        }
    }
}
