using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.frmSales;
using static thepos.thePos;

namespace thepos
{
    public partial class frmAllim : Form
    {

        List<shop_order_pack> shopOrderPackList;

        public frmAllim(List<shop_order_pack> list)
        {
            InitializeComponent();

            shopOrderPackList = list;

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < shopOrderPackList.Count; i++)
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                parameters.Clear();
                parameters["siteId"] = mSiteId;
                parameters["posNo"] = mPosNo;
                parameters["bizDt"] = mBizDate;
                parameters["theNo"] = mTheNo;
                parameters["senderProfile"] = mAllimSenderProfile;
                parameters["allimType"] = "OR";
                parameters["allimTelNo"] = txtMobileNo.Text.ToString();
                parameters["siteName"] = get_shop_name(shopOrderPackList[i].shop_code);

                parameters["orderDate"] = get_today_date();
                parameters["orderTime"] = get_today_time();

                parameters["orderNo"] = shopOrderPackList[i].order_no;


                String t_detail = "";

                for (int j = 0; j < shopOrderPackList[i].orderPackList.Count; j++)
                {
                    t_detail += shopOrderPackList[i].orderPackList[j].goods_name + "  " + shopOrderPackList[i].orderPackList[j].goods_cnt + "\r\n";

                    for (int k = 0; k < shopOrderPackList[i].orderPackList[j].option_name.Count - 1; k++)
                    {
                        t_detail += "  - " + shopOrderPackList[i].orderPackList[j].option_name[k] + "  " + shopOrderPackList[i].orderPackList[j].option_item_name[k] + "\r\n";
                    }
                }

                parameters["orderDetail"] = t_detail;


                if (mRequestPost("allim", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {

                    }
                    else
                    {
                        MessageBox.Show("오류 allim\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }

            }


            this.Close();
        }
    }
}
