using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static thepos.thePos;

namespace thepos
{
    public partial class frmReportList1 : Form
    {
        double[] s_cnt = new double[32];  // 1 ~ 31
        double[] s_amount = new double[32];
        double[] s_dc_amount = new double[32];
        double[] s_net_amount = new double[32];

        double[] p_net_amount = new double[32];  // 1 ~ 31
        double[] p_amount_cash = new double[32];
        double[] p_amount_card = new double[32];
        double[] p_amount_easy = new double[32];
        double[] p_amount_cert = new double[32];


        int last_date = 0;

        String viewMode = "";
        String pos_no = "";
        String shop_code = "";
        String goods_code = "";

        String prev_mode = "";
        String prev_yyyymm = "";



        public frmReportList1()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();

        }


        private void initialize_font()
        {
            lblReportTitle.Font = font10;
            btnPrev.Font = font8;
            lblYYYYMM.Font = font10;
            btnNext.Font = font8;

            lblListPath.Font = font10;

            btnView.Font = font10;
        }

        private void initialize_the()
        {
            TreeNode[] nodeTop = new TreeNode[2];


            // 포스
            nodeTop[0] = new TreeNode();
            nodeTop[0].Text = "포스별";
            nodeTop[0].Tag = "POS";
            nodeTop[0].Expand();
            tvwList.Nodes.Add(nodeTop[0]);


            TreeNode[] nodePos = new TreeNode[mPosNoList.Length];

            for (int i = 0; i < mPosNoList.Length; i++)
            {
                nodePos[i] = new TreeNode();
                nodePos[i].Text = mPosNoList[i];
                nodePos[i].Tag = "P" + mPosNoList[i];
                nodeTop[0].Nodes.Add(nodePos[i]);
            }



            // 업장
            nodeTop[1] = new TreeNode();
            nodeTop[1].Text = "업장별";
            nodeTop[1].Tag = "SHOP";
            nodeTop[1].Expand();
            tvwList.Nodes.Add(nodeTop[1]);

            TreeNode[] nodeShop = new TreeNode[mShop.Length];

            for (int i = 0; i < mShop.Length; i++)
            {
                nodeShop[i] = new TreeNode();
                nodeShop[i].Text = mShop[i].shop_name;
                nodeShop[i].Tag = "S" + mShop[i].shop_code;
                nodeTop[1].Nodes.Add(nodeShop[i]);
            }


            for (int i = 0; i < mGoodsItem.Length; i++)
            {
                for (int shop_idx = 0; shop_idx < nodeShop.Length; shop_idx++)
                {
                    if (nodeShop[shop_idx].Tag.ToString() == "S" + mGoodsItem[i].shop_code)
                    {
                        TreeNode nodeGoods = new TreeNode();
                        nodeGoods.Text = mGoodsItem[i].goods_name;
                        nodeGoods.Tag = "G" + mGoodsItem[i].goods_code;

                        nodeShop[shop_idx].Nodes.Add(nodeGoods);
                    }
                }
            }





            String yyyymm = get_today_date().Substring(0, 6);

            lblYYYYMM.Text = yyyymm.Substring(0, 4) + "-" + yyyymm.Substring(4, 2);


        }


        private void btnView_Click(object sender, EventArgs e)
        {
            viewMonth();
        }

        void viewMonth()
        {


            String yyyymm = lblYYYYMM.Text.Replace("-", ""); ;





            for (int i = 1; i <= 31; i++)
            {
                s_cnt[i] = 0;
                s_amount[i] = 0;
                s_dc_amount[i] = 0;
                s_net_amount[i] = 0;

                p_net_amount[i] = 0;
                p_amount_cash[i] = 0;
                p_amount_card[i] = 0;
                p_amount_easy[i] = 0;
                p_amount_cert[i] = 0;

            }




            if (prev_mode != viewMode)
            {
                redraw_column(viewMode);
                prev_mode = viewMode;
            }



            if (yyyymm != prev_yyyymm)
            {
                // 1일 구하기
                DateTime MonthFirstDay = Convert.ToDateTime(lblYYYYMM.Text + "-01");

                //말일구하기
                DateTime MonthLastDay = MonthFirstDay.AddMonths(1).AddDays(-1);

                last_date = convert_number(MonthLastDay.ToString("dd"));


                prev_yyyymm = yyyymm;

            }


                



            String sUrl = "";

            lblListPath.Text = "";


            if (viewMode == "POS")
            {
                lblListPath.Text += "포스전체";

                if (pos_no != "")
                {
                    lblListPath.Text = "포스 > " + pos_no;
                }


                sUrl = "reportMonthListPos?siteId=" + mSiteId + "&bizDtMon=" + yyyymm + "&posNo=" + pos_no;

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["pos"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            int day_idx = convert_number(arr[i]["bizDt"].ToString().Substring(6, 2));
                            p_amount_cash[day_idx] = convert_number(arr[i]["amountCash"].ToString());
                            p_amount_card[day_idx] = convert_number(arr[i]["amountCard"].ToString());
                            p_amount_easy[day_idx] = convert_number(arr[i]["amountEasy"].ToString());
                            p_amount_cert[day_idx] = convert_number(arr[i]["amountCert"].ToString());
                            p_net_amount[day_idx] = convert_number(arr[i]["netAmount"].ToString());
                        }

                        lvwList.Items.Clear();
                        for (int i = 1;i <= last_date;i++) 
                        {
                            ListViewItem Item = new ListViewItem();
                            Item.Text = lblYYYYMM.Text + "-" + i.ToString("00");
                            Item.SubItems.Add(p_amount_cash[i].ToString("N0"));
                            Item.SubItems.Add(p_amount_card[i].ToString("N0"));
                            Item.SubItems.Add(p_amount_easy[i].ToString("N0"));
                            Item.SubItems.Add(p_amount_cert[i].ToString("N0"));
                            Item.SubItems.Add(p_net_amount[i].ToString("N0"));
                            lvwList.Items.Add(Item);
                        }

                    }
                    else
                    {
                        MessageBox.Show(mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. reportMonthListPos\n\n" + mErrorMsg, "thepos");
                    return;
                }


            }
            else if (viewMode == "SHOP")
            {

                lblListPath.Text += "업장전체";

                if (shop_code != "")
                {
                    lblListPath.Text = "업장 > " + get_shop_name(shop_code);
                }

                if (goods_code != "")
                {
                    lblListPath.Text += " > " + get_goods_name(goods_code);
                }


                sUrl = "reportMonthListShop?siteId=" + mSiteId + "&bizDtMon=" + yyyymm + "&shopCode=" + shop_code + "&goodsCode=" + goods_code;

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["shops"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            int day_idx = convert_number(arr[i]["bizDt"].ToString().Substring(6, 2));
                            s_cnt[day_idx] = convert_number(arr[i]["cnt"].ToString());
                            s_amount[day_idx] = convert_number(arr[i]["amount"].ToString());
                            s_dc_amount[day_idx] = convert_number(arr[i]["dcAmount"].ToString());
                            s_net_amount[day_idx] = convert_number(arr[i]["netAmount"].ToString());
                        }

                        lvwList.Items.Clear();

                        for (int i = 1;i <= last_date;i++) 
                        {
                            ListViewItem Item = new ListViewItem();
                            Item.Text = lblYYYYMM.Text + "-" + i.ToString("00");
                            Item.SubItems.Add(s_cnt[i].ToString("N0"));
                            Item.SubItems.Add(s_amount[i].ToString("N0"));
                            Item.SubItems.Add(s_dc_amount[i].ToString("N0"));
                            Item.SubItems.Add(s_net_amount[i].ToString("N0"));
                            lvwList.Items.Add(Item);
                        }
                    }
                    else
                    {
                        MessageBox.Show(mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. reportMonthListShop\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }
            else
            {
                return;
            }
        }


        private void btnPrev_Click(object sender, EventArgs e)
        {
            DateTime CurrMonth = Convert.ToDateTime(lblYYYYMM.Text + "-01");

            DateTime PrevMonth = CurrMonth.AddMonths(-1);

            lblYYYYMM.Text = PrevMonth.ToString("yyyy-MM");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            DateTime CurrMonth = Convert.ToDateTime(lblYYYYMM.Text + "-01");

            DateTime NextMonth = CurrMonth.AddMonths(1);

            lblYYYYMM.Text = NextMonth.ToString("yyyy-MM");

        }

        private void tvwList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            String selectNode = tvwList.SelectedNode.Tag.ToString();

            if (selectNode.Substring(0,1) == "P")
            {
                viewMode = "POS";

                if (selectNode == "POS")
                    pos_no = "";
                else
                    pos_no = selectNode.Substring(1, 2);

            }
            else if(selectNode.Substring(0, 1) == "S" | selectNode.Substring(0, 1) == "G")
            {
                viewMode = "SHOP";

                if (selectNode == "SHOP")
                    shop_code = "";
                else if (selectNode.Substring(0,1) == "S")
                {
                    shop_code = selectNode.Substring(1);
                    goods_code = "";
                }
                else if (selectNode.Substring(0, 1) == "G")
                {
                    shop_code = tvwList.SelectedNode.Parent.Tag.ToString().Substring(1);
                    goods_code = selectNode.Substring(1);
                }
            }

            viewMonth();
        }


        void redraw_column(String mode)
        {
            if (mode == "POS")
            {
                lvwList.Columns[1].Text = "현금금액";
                lvwList.Columns[2].Text = "카드금액";
                lvwList.Columns[3].Text = "간편금액";
                lvwList.Columns[4].Text = "쿠폰금액";
                lvwList.Columns[5].Text = "매출금액";
            }
            else if (mode == "SHOP")
            {
                lvwList.Columns[1].Text = "수량";
                lvwList.Columns[2].Text = "상품금액";
                lvwList.Columns[3].Text = "할인금액";
                lvwList.Columns[4].Text = "매출금액";
                lvwList.Columns[5].Text = "";
            }

        }
    }
}
