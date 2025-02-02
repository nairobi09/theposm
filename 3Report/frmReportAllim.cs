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
    public partial class frmReportAllim : Form
    {

        String thisBizDt = "";


        public frmReportAllim()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {


            thisBizDt = dtpBizDate.Value.ToString("yyyyMMdd");

            lvwList.Items.Clear();


            String sUrl = "allim?siteId=" + mSiteId + "&bizDt=" + thisBizDt;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["allim"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem Item = new ListViewItem();
                        Item.Text = arr[i]["orderTime"].ToString();
                        Item.SubItems.Add(arr[i]["orderNo"].ToString());
                        Item.SubItems.Add(arr[i]["allimTelNo"].ToString());
                        Item.SubItems.Add(arr[i]["siteName"].ToString());
                        Item.SubItems.Add(arr[i]["allimType"].ToString());

                        lvwList.Items.Add(Item);
                    }

                }
                else
                {
                    MessageBox.Show(mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. allim\n\n" + mErrorMsg, "thepos");
            }
        }
    }
}
