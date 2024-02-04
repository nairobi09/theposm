using Newtonsoft.Json.Linq;
using System;
using System.Collections;
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

namespace thepos._9SysAdmin
{
    public partial class frmSysSoldout : Form
    {
        private int sortColumn = -1;


        public frmSysSoldout()
        {
            InitializeComponent();

            initialize_font();

            reload_goods();

            reload_group();
        }

        private void initialize_font()
        {
            lblGoodsTitle.Font = font10;
            lvwGoodsList.Font = font10;
            cbGoodsSoldout.Font = font10;
            btnGoodsUpdate.Font = font10;

            lblGroupTitle.Font = font10;
            lvwGroupList.Font = font10;
            cbGroupSoldout.Font = font10;
            btnGroupUpdate.Font = font10;


        }



        private void reload_goods()
        {
            lvwGoodsList.Items.Clear();


            String sUrl = "goods?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["goods"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = get_shop_name(arr[i]["shopCode"].ToString());
                        lvItem.SubItems.Add(arr[i]["goodsName"].ToString());
                        lvItem.SubItems.Add(arr[i]["amt"].ToString());
                        lvItem.SubItems.Add(arr[i]["soldout"].ToString());
                        lvItem.Tag = arr[i]["goodsCode"].ToString();

                        if (arr[i]["soldout"].ToString() == "Y")
                        {
                            lvItem.ForeColor = Color.Gray;
                            lvItem.SubItems[1].ForeColor = Color.Gray;
                            lvItem.SubItems[2].ForeColor = Color.Gray;
                            lvItem.SubItems[3].ForeColor = Color.Gray;
                        }
                        else
                        {
                            lvItem.ForeColor = Color.Blue;
                            lvItem.SubItems[1].ForeColor = Color.Blue;
                            lvItem.SubItems[2].ForeColor = Color.Blue;
                            lvItem.SubItems[3].ForeColor = Color.Blue;
                        }

                        lvwGoodsList.Items.Add(lvItem);

                    }
                }
                else
                {
                    MessageBox.Show("상품정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }




        }


        private void reload_group()
        {
            lvwGroupList.Items.Clear();


            for (int pos_idx = 0; pos_idx < mPosNoList.Length; pos_idx++)
            {
                String sUrl = "goodsGroup?siteId=" + mSiteId + "&posNo=" + mPosNoList[pos_idx];

                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["goodsGroups"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            ListViewItem lvItem = new ListViewItem();
                            lvItem.Text = mPosNoList[pos_idx];
                            lvItem.SubItems.Add(arr[i]["groupName"].ToString());

                            if (arr[i]["soldout"].ToString() == "Y")
                            {
                                lvItem.SubItems.Add("Y");
                            }
                            else
                            {
                                lvItem.SubItems.Add("");
                            }
                            
                            lvItem.Tag = arr[i]["groupCode"].ToString();


                            if (arr[i]["soldout"].ToString() == "Y")
                            {
                                lvItem.ForeColor = Color.Gray;
                                lvItem.SubItems[1].ForeColor = Color.Gray;
                                lvItem.SubItems[2].ForeColor = Color.Gray;
                            }
                            else
                            {
                                lvItem.ForeColor = Color.Blue;
                                lvItem.SubItems[1].ForeColor = Color.Blue;
                                lvItem.SubItems[2].ForeColor = Color.Blue;
                            }



                            lvwGroupList.Items.Add(lvItem);

                        }
                    }
                    else
                    {
                        MessageBox.Show("상품그룹정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }

            }
        }

        private void lvwGoodsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwGoodsList.SelectedItems.Count == 0)
            {
                cbGoodsSoldout.Checked = false;
                return; 
            }

            if (lvwGoodsList.SelectedItems[0].SubItems[lvwGoodsList.Columns.IndexOf(goods_soldout)].Text == "Y")
            {
                cbGoodsSoldout.Checked = true;
            }
            else
            {
                cbGoodsSoldout.Checked = false;
            }

        }

        private void btnGoodsUpdate_Click(object sender, EventArgs e)
        {
            String t_soldout = "";

            if (cbGoodsSoldout.Checked == true)
            {
                t_soldout = "Y";
            }
            else
            {
                t_soldout = "";
            }

            if (lvwGoodsList.SelectedItems[0].SubItems[lvwGoodsList.Columns.IndexOf(goods_soldout)].Text == t_soldout)
            {
                return;
            }


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["goodsCode"] = lvwGoodsList.SelectedItems[0].Tag.ToString();
            parameters["soldout"] = t_soldout;

            if (mRequestPatch("goods", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    // 화면 업데이트 -> 전체 reload하지 않는다...
                    lvwGoodsList.SelectedItems[0].SubItems[lvwGoodsList.Columns.IndexOf(goods_soldout)].Text = t_soldout;

                    if (t_soldout == "Y")
                    {
                        lvwGoodsList.SelectedItems[0].ForeColor = Color.Gray;
                        lvwGoodsList.SelectedItems[0].SubItems[1].ForeColor = Color.Gray;
                        lvwGoodsList.SelectedItems[0].SubItems[2].ForeColor = Color.Gray;
                        lvwGoodsList.SelectedItems[0].SubItems[3].ForeColor = Color.Gray;
                    }
                    else
                    {
                        lvwGoodsList.SelectedItems[0].ForeColor = Color.Blue;
                        lvwGoodsList.SelectedItems[0].SubItems[1].ForeColor = Color.Blue;
                        lvwGoodsList.SelectedItems[0].SubItems[2].ForeColor = Color.Blue;
                        lvwGoodsList.SelectedItems[0].SubItems[3].ForeColor = Color.Blue;
                    }
                }
                else
                {
                    MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

        }

        private void lvwGroupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwGroupList.SelectedItems.Count == 0)
            {
                cbGoodsSoldout.Checked = false;
                return;
            }

            if (lvwGroupList.SelectedItems[0].SubItems[lvwGroupList.Columns.IndexOf(group_soldout)].Text == "Y")
            {
                cbGroupSoldout.Checked = true;
            }
            else
            {
                cbGroupSoldout.Checked = false;
            }
        }

        private void btnGroupUpdate_Click(object sender, EventArgs e)
        {
            String t_soldout = "";

            if (cbGroupSoldout.Checked == true)
            {
                t_soldout = "Y";
            }
            else
            {
                t_soldout = "";
            }

            if (lvwGroupList.SelectedItems[0].SubItems[lvwGroupList.Columns.IndexOf(group_soldout)].Text == t_soldout)
            {
                return;
            }


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["posNo"] = lvwGroupList.SelectedItems[0].Text;
            parameters["groupCode"] = lvwGroupList.SelectedItems[0].Tag.ToString();
            parameters["soldout"] = t_soldout;

            if (mRequestPatch("goodsGroup", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    // 화면 업데이트 -> 전체 reload하지 않는다...
                    lvwGroupList.SelectedItems[0].SubItems[lvwGroupList.Columns.IndexOf(group_soldout)].Text = t_soldout;

                    if (t_soldout == "Y")
                    {
                        lvwGroupList.SelectedItems[0].ForeColor = Color.Gray;
                        lvwGroupList.SelectedItems[0].SubItems[1].ForeColor = Color.Gray;
                        lvwGroupList.SelectedItems[0].SubItems[2].ForeColor = Color.Gray;
                    }
                    else
                    {
                        lvwGroupList.SelectedItems[0].ForeColor = Color.Blue;
                        lvwGroupList.SelectedItems[0].SubItems[1].ForeColor = Color.Blue;
                        lvwGroupList.SelectedItems[0].SubItems[2].ForeColor = Color.Blue;
                    }
                }
                else
                {
                    MessageBox.Show("오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }
        }

        private void lvwGoodsList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //? 숫자컬럼(단가) Sorting 고려하기

            if (e.Column != sortColumn)
            {
                sortColumn = e.Column;
                lvwGoodsList.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (lvwGoodsList.Sorting == SortOrder.Ascending)
                {
                    lvwGoodsList.Sorting = SortOrder.Descending;
                }
                else
                {
                    lvwGoodsList.Sorting = SortOrder.Ascending;
                }
            }


            lvwGoodsList.Sort();
            this.lvwGoodsList.ListViewItemSorter = new MyListViewComparer(e.Column, lvwGoodsList.Sorting);
        }

        class MyListViewComparer : IComparer
        {
            private int col; private SortOrder order; public MyListViewComparer() { col = 0; order = SortOrder.Ascending; }

            public MyListViewComparer(int column, SortOrder order) { col = column; this.order = order; }

            public int Compare(object x, object y)
            {
                int returnVal = -1; returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);

                // Determine whether the sort order is descending. 
                if (order == SortOrder.Descending) returnVal *= -1; // Invert the value returned by String.Compare. 

                return returnVal;
            }
        }
    }
}
