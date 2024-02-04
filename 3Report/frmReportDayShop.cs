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
            dtpBizDate.Font = font10;
            btnView.Font = font10;

            lvwList.Font = font10;

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

        }

        private void btnView_Click(object sender, EventArgs e)
        {

            String save_shopcode = "";
            int cnt = 0;
            int amount = 0;
            int dcAmount = 0;
            int netAmount = 0;

            int sum_cnt = 0;
            int sum_amount = 0;
            int sum_dcAmount = 0;
            int sum_netAmount = 0;

            int tot_cnt = 0;
            int tot_amount = 0;
            int tot_dcAmount = 0;
            int tot_netAmount = 0;



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
                        cnt = convert_number(arr[i]["cnt"].ToString());
                        amount = convert_number(arr[i]["amount"].ToString());
                        dcAmount = convert_number(arr[i]["dcAmount"].ToString());
                        netAmount = convert_number(arr[i]["netAmount"].ToString());

                        if (save_shopcode != arr[i]["shopCode"].ToString() & save_shopcode != "")
                        {
                            // 업장합계 표시
                            ListViewItem sumItem = new ListViewItem();
                            sumItem.Text = "[" + get_shop_name(save_shopcode) + "] 합계";
                            sumItem.SubItems.Add(sum_cnt.ToString("N0"));
                            sumItem.SubItems.Add(sum_amount.ToString("N0"));
                            sumItem.SubItems.Add(sum_dcAmount.ToString("N0"));
                            sumItem.SubItems.Add(sum_netAmount.ToString("N0"));
                            lvwList.Items.Add(sumItem);
                            
                            sum_cnt = 0;
                            sum_amount = 0;
                            sum_dcAmount = 0;
                            sum_netAmount = 0;
                        }

                        ListViewItem Item = new ListViewItem();
                        Item.Text = get_goods_name(arr[i]["goodsCode"].ToString());
                        Item.SubItems.Add(cnt.ToString("N0"));
                        Item.SubItems.Add(amount.ToString("N0"));
                        Item.SubItems.Add(dcAmount.ToString("N0"));
                        Item.SubItems.Add(netAmount.ToString("N0"));

                        Item.ForeColor = Color.Gray;
                        Item.SubItems[1].ForeColor = Color.Gray;
                        Item.SubItems[2].ForeColor = Color.Gray;
                        Item.SubItems[3].ForeColor = Color.Gray;
                        Item.SubItems[4].ForeColor = Color.Gray;

                        lvwList.Items.Add(Item);


                        sum_cnt += cnt;
                        sum_amount += amount;
                        sum_dcAmount += dcAmount;
                        sum_netAmount += netAmount;

                        tot_cnt += cnt;
                        tot_amount += amount;
                        tot_dcAmount += dcAmount;
                        tot_netAmount += netAmount;


                        save_shopcode = arr[i]["shopCode"].ToString();
                    }


                    if (save_shopcode != "")
                    {
                        // 업장합계 표시
                        ListViewItem sumItem = new ListViewItem();
                        sumItem.Text = "[" + get_shop_name(save_shopcode) + "] 합계";
                        sumItem.SubItems.Add(sum_cnt.ToString("N0"));
                        sumItem.SubItems.Add(sum_amount.ToString("N0"));
                        sumItem.SubItems.Add(sum_dcAmount.ToString("N0"));
                        sumItem.SubItems.Add(sum_netAmount.ToString("N0"));
                        lvwList.Items.Add(sumItem);

                        ListViewItem Item = new ListViewItem();
                        Item.Text = "[전체] 합계";
                        Item.SubItems.Add(tot_cnt.ToString("N0"));
                        Item.SubItems.Add(tot_amount.ToString("N0"));
                        Item.SubItems.Add(tot_dcAmount.ToString("N0"));
                        Item.SubItems.Add(tot_netAmount.ToString("N0"));
                        lvwList.Items.Add(Item);
                    }

                }
                else
                {
                    //MessageBox.Show(mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. reportDayShop\n\n" + mErrorMsg, "thepos");
            }



        }
    }
}
