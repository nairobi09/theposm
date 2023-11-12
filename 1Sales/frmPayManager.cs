using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using PrinterUtility;
using Newtonsoft.Json.Linq;
using static thepos.thePos;
using static thepos.frmSales;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.ComponentModel.Composition.Primitives;
using System.Data.SQLite;
using System.Web.UI.WebControls.Expressions;


namespace thepos
{
    public partial class frmPayManager : Form
    {

        System.Windows.Forms.TextBox saveKeyDisplay;

        String selected_biz_date = "";
        String selected_pos_no = "";
        String selected_the_no = "";

        public static System.Windows.Forms.ListView mLvwPayManager;


        public frmPayManager()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();
        }

        private void initialize_font()
        {
            lblTitle.Font = font10;
            btnClose.Font = font12;

            lbl1.Font = font9;
            lbl2.Font = font9;
            lbl3.Font = font9;

            //dtBizDt.Font = font10;
            cbPosNo.Font = font10;
            tbBillNo.Font = font10;

            btnView.Font = font10;
            lvwPayManager.Font = font10;

            // 폰트적용 제외
            //lblLayoutBill.Font = font12;

            cbGoodsExcept.Font = font10;
            btnPrint.Font = font10;
            btnCancel.Font = font10;

        }
        private void initialize_the()
        {
            //dtBusiness.Value = DateTime.Now;
            dtBizDt.Value = new DateTime(convert_number(mBizDate.Substring(0, 4)), convert_number(mBizDate.Substring(4, 2)), convert_number(mBizDate.Substring(6, 2)));


            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwPayManager.SmallImageList = imgList;

            cbPosNo.Items.Clear();
            for (int i = 0; i < mPosNoList.Length; i++)
            {
                cbPosNo.Items.Add(mPosNoList[i]);
            }

            for (int i = 0;i < cbPosNo.Items.Count;i++)
            {
                if (cbPosNo.Items[i].ToString() == mPosNo) 
                { 
                    cbPosNo.SelectedIndex = i; 
                    break; 
                }
            }


            saveKeyDisplay = mTbKeyDisplayController;
            mTbKeyDisplayController = tbBillNo;


            mPanelCancel.Width = 529;
            mPanelCancel.Height = 704;

            mLvwPayManager = lvwPayManager;


        }


        private void btnView_Click(object sender, EventArgs e)
        {
            String billNo = tbBillNo.Text;

            selected_biz_date = dtBizDt.Value.ToString("yyyyMMdd");
            selected_pos_no = cbPosNo.Text;

            if (billNo.Length == 6)
            {
                selected_the_no = mSiteId + selected_biz_date + selected_pos_no + billNo;
            }
            else
            {
                selected_the_no = "";
            }
            
            viewList(selected_biz_date, selected_pos_no, selected_the_no);
            lblLayoutBill.Text = "";
        }



        private void add_viewList(String t_theNo, String t_billNo, String t_payClass, int t_amountCash, int t_amountCard, int t_amountPoint, int t_amountEasy, String t_payDate, String t_payTime, String t_posNo, int t_netAmount, int t_dcAmount, String t_isCancel)
        {
            ListViewItem lvItem = new ListViewItem();

            lvItem.Tag = t_theNo;
            lvItem.Text = t_billNo;
            lvItem.SubItems.Add(get_pay_class_name(t_payClass));

            String is_cash = "0";
            String is_card = "0";
            String is_point = "0";
            String is_easy = "0";
            String pay_keep = "";

            if (t_amountCash > 0) is_cash = "1";
            if (t_amountCard > 0) is_card = "1";
            if (t_amountPoint > 0) is_point = "1";
            if (t_amountEasy > 0) is_easy = "1";

            pay_keep = is_cash + is_card + is_point + is_easy;


            lvItem.SubItems.Add(get_pay_type_group_name(pay_keep));


            lvItem.SubItems.Add(get_MMddHHmm(t_payDate, t_payTime));
            lvItem.SubItems.Add(t_posNo);
            lvItem.SubItems.Add(t_netAmount.ToString("N0"));


            if (t_dcAmount > 0)
            {
                lvItem.SubItems.Add("Y");
            }
            else
            {
                lvItem.SubItems.Add("");
            }

            if (t_isCancel == "Y")
                lvItem.SubItems.Add("취소됨");
            else if (t_isCancel == "0")
                lvItem.SubItems.Add("취소중");
            else
                lvItem.SubItems.Add("");


            lvItem.SubItems.Add(pay_keep);


            if (t_isCancel == "Y")
            {
                lvItem.ForeColor = Color.Gray;
                lvItem.SubItems[1].ForeColor = Color.Gray;
                lvItem.SubItems[2].ForeColor = Color.Gray;
                lvItem.SubItems[3].ForeColor = Color.Gray;
                lvItem.SubItems[4].ForeColor = Color.Gray;
                lvItem.SubItems[5].ForeColor = Color.Gray;
                lvItem.SubItems[6].ForeColor = Color.Gray;
                lvItem.SubItems[7].ForeColor = Color.Gray;
                lvItem.SubItems[8].ForeColor = Color.Gray;
            }

            lvwPayManager.Items.Add(lvItem);

        }



        private void viewList(String biz_date, String pos_no, String the_no)
        { 
            lvwPayManager.Items.Clear();

            //!
            if (mTheMode == "Local")
            {

                String sql = "SELECT * FROM payment WHERE bizDt= '" + biz_date + "' AND posNo='" + pos_no + "' AND tranType='A'";

                if (the_no == "")
                {

                }
                else
                {
                    sql += " AND theNo = '" + the_no + "'";
                }
                

                SQLiteDataReader dr = sql_select_local_db(sql);
                while (dr.Read())
                {
                    String t_theNo = dr["theNo"].ToString();
                    String t_billNo = dr["billNo"].ToString();
                    String t_payClass = dr["payClass"].ToString();
                    int t_amountCash = convert_number(dr["amountCash"].ToString());
                    int t_amountCard = convert_number(dr["amountCard"].ToString());
                    int t_amountPoint = convert_number(dr["amountPoint"].ToString());
                    int t_amountEasy = convert_number(dr["amountEasy"].ToString());
                    String t_payDate = dr["payDate"].ToString();
                    String t_payTime = dr["payTime"].ToString();
                    String t_posNo = dr["posNo"].ToString();
                    int t_netAmount = convert_number(dr["netAmount"].ToString());
                    int t_dcAmount = convert_number(dr["dcAmount"].ToString());
                    String t_isCancel = dr["isCancel"].ToString();

                    add_viewList(t_theNo, t_billNo, t_payClass, t_amountCash, t_amountCard, t_amountPoint, t_amountEasy, t_payDate, t_payTime, t_posNo, t_netAmount, t_dcAmount, t_isCancel);
                }
                dr.Close();

            }
            else
            {
                String sUrl = "payment?siteId=" + mSiteId + "&bizDt=" + biz_date + "&posNo=" + pos_no + "&theNo=" + the_no + "&tranType=A";
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["payments"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            String t_theNo = arr[i]["theNo"].ToString();
                            String t_billNo = arr[i]["billNo"].ToString();
                            String t_payClass = arr[i]["payClass"].ToString();
                            int t_amountCash = convert_number(arr[i]["amountCash"].ToString());
                            int t_amountCard = convert_number(arr[i]["amountCard"].ToString());
                            int t_amountPoint = convert_number(arr[i]["amountPoint"].ToString());
                            int t_amountEasy = convert_number(arr[i]["amountEasy"].ToString());
                            String t_payDate = arr[i]["payDate"].ToString();
                            String t_payTime = arr[i]["payTime"].ToString();
                            String t_posNo = arr[i]["posNo"].ToString();
                            int t_netAmount = convert_number(arr[i]["netAmount"].ToString());
                            int t_dcAmount = convert_number(arr[i]["dcAmount"].ToString());
                            String t_isCancel = arr[i]["isCancel"].ToString();

                            add_viewList(t_theNo, t_billNo, t_payClass, t_amountCash, t_amountCard, t_amountPoint, t_amountEasy, t_payDate, t_payTime, t_posNo, t_netAmount, t_dcAmount, t_isCancel);
                        }
                    }
                    else
                    {
                        MessageBox.Show("데이터 오류. payment\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. payment\n\n" + mErrorMsg, "thepos");
                }
            }


        }


        public static void reviewList(String biz_date, String pos_no, String the_no, int select_index)
        {
            String t_theNo = "";
            String t_billNo = "";
            String t_payClass = "";
            int t_amountCash = 0;
            int t_amountCard = 0;
            int t_amountPoint = 0;
            int t_amountEasy = 0;
            String t_payDate = "";
            String t_payTime = "";
            String t_posNo = "";
            int t_netAmount = 0;
            int t_dcAmount = 0;
            String t_isCancel = "";


            if (mTheMode == "Local")
            {
                String sql = "SELECT * FROM payment WHERE bizDt= '" + biz_date + "' AND posNo='" + pos_no + "' AND tranType='A' AND theNo = '" + the_no + "'";
                SQLiteDataReader dr = sql_select_local_db(sql);
                if (dr.Read())
                {
                    t_theNo = dr["theNo"].ToString();
                    t_billNo = dr["billNo"].ToString();
                    t_payClass = dr["payClass"].ToString();
                    t_amountCash = convert_number(dr["amountCash"].ToString());
                    t_amountCard = convert_number(dr["amountCard"].ToString());
                    t_amountPoint = convert_number(dr["amountPoint"].ToString());
                    t_amountEasy = convert_number(dr["amountEasy"].ToString());
                    t_payDate = dr["payDate"].ToString();
                    t_payTime = dr["payTime"].ToString();
                    t_posNo = dr["posNo"].ToString();
                    t_netAmount = convert_number(dr["netAmount"].ToString());
                    t_dcAmount = convert_number(dr["dcAmount"].ToString());
                    t_isCancel = dr["isCancel"].ToString();
                }
                dr.Close();

            }
            else
            {
                String sUrl = "payment?siteId=" + mSiteId + "&bizDt=" + biz_date + "&posNo=" + pos_no + "&theNo=" + the_no + "&tranType=A";
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["payments"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count > 0)
                        {
                            t_theNo = arr[0]["theNo"].ToString();
                            t_billNo = arr[0]["billNo"].ToString();
                            t_payClass = arr[0]["payClass"].ToString();
                            t_amountCash = convert_number(arr[0]["amountCash"].ToString());
                            t_amountCard = convert_number(arr[0]["amountCard"].ToString());
                            t_amountPoint = convert_number(arr[0]["amountPoint"].ToString());
                            t_amountEasy = convert_number(arr[0]["amountEasy"].ToString());
                            t_payDate = arr[0]["payDate"].ToString();
                            t_payTime = arr[0]["payTime"].ToString();
                            t_posNo = arr[0]["posNo"].ToString();
                            t_netAmount = convert_number(arr[0]["netAmount"].ToString());
                            t_dcAmount = convert_number(arr[0]["dcAmount"].ToString());
                            t_isCancel = arr[0]["isCancel"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("영업개시마감 데이터 오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                }
            }



            ListViewItem lvItem = new ListViewItem();

            lvItem.Tag = t_theNo;
            lvItem.Text = t_billNo;
            lvItem.SubItems.Add(get_pay_class_name(t_payClass));

            String is_cash = "0";
            String is_card = "0";
            String is_point = "0";
            String is_easy = "0";
            String pay_keep = "";

            if (t_amountCash > 0) is_cash = "1";
            if (t_amountCard > 0) is_card = "1";
            if (t_amountPoint > 0) is_point = "1";
            if (t_amountEasy > 0) is_easy = "1";

            pay_keep = is_cash + is_card + is_point + is_easy;


            lvItem.SubItems.Add(get_pay_type_group_name(pay_keep));


            lvItem.SubItems.Add(get_MMddHHmm(t_payDate, t_payTime));
            lvItem.SubItems.Add(t_posNo);
            lvItem.SubItems.Add(t_netAmount.ToString("N0"));


            //
            if (t_dcAmount > 0)
                lvItem.SubItems.Add("Y");
            else
                lvItem.SubItems.Add("");

            //
            if (t_isCancel == "Y")
                lvItem.SubItems.Add("취소됨");
            else if (t_isCancel == "0")
                lvItem.SubItems.Add("취소중");
            else
                lvItem.SubItems.Add("");


            lvItem.SubItems.Add(pay_keep);


            if (t_isCancel == "Y")
            {
                lvItem.ForeColor = Color.Gray;
                lvItem.SubItems[1].ForeColor = Color.Gray;
                lvItem.SubItems[2].ForeColor = Color.Gray;
                lvItem.SubItems[3].ForeColor = Color.Gray;
                lvItem.SubItems[4].ForeColor = Color.Gray;
                lvItem.SubItems[5].ForeColor = Color.Gray;
                lvItem.SubItems[6].ForeColor = Color.Gray;
                lvItem.SubItems[7].ForeColor = Color.Gray;
                lvItem.SubItems[8].ForeColor = Color.Gray;
            }

            mLvwPayManager.Items[select_index] = lvItem;
            lvItem.Selected = true;
            mLvwPayManager.Select();
            mLvwPayManager.EnsureVisible(select_index);

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSales.ConsoleEnable();
            mTbKeyDisplayController = saveKeyDisplay;
            
            mPanelMiddle.Visible = false;
            mPanelMiddle.Controls.Clear();
        }

        private void lvwPayManager_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvwPayManager.Columns[e.ColumnIndex].Width;
        }

        private void lvwPayManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblLayoutBill.Text = "";

            if (lvwPayManager.SelectedItems.Count <= 0)
            {
                return;
            }

            String tTheNo = lvwPayManager.SelectedItems[0].Tag.ToString();
            String pay_keep = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(paykeep)].Text;

            // 취소된 건을 선택하면 취소전표를 출력한다.. 아래와 동일
            String cancel_name = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(cancel)].Text;

            String tran_type = "A";
            if (cancel_name == "Y" | cancel_name == "취소됨")
            {
                tran_type = "C";
            }

            lblLayoutBill.Text = make_bill_header() + make_bill_body(tTheNo, tran_type, "", pay_keep) + make_bill_trailer();

        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwPayManager.SelectedItems.Count < 1)
            {
                return;
            }

            String tTheNo = lvwPayManager.SelectedItems[0].Tag.ToString();
            String pay_keep = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(paykeep)].Text;


            // 취소된 건을 선택하면 취소전표를 출력한다.. 위와 동일
            String cancel_name = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(cancel)].Text;

            String tran_type = "A";
            if (cancel_name == "Y" | cancel_name == "취소됨")
            {
                tran_type = "C";
            }

            String except_order = "";
            if (cbGoodsExcept.Checked) except_order = "Y";


            print_bill(tTheNo, tran_type, except_order, pay_keep, false);

        }




        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwPayManager.SelectedItems.Count < 1)
            {
                SetDisplayAlarm("W", "대상거래 선택요망.");
                return; 
            }

            String the_no = lvwPayManager.SelectedItems[0].Tag.ToString();
            String pay_keep = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(paykeep)].Text;

            int select_idx = lvwPayManager.SelectedItems[0].Index;


            //#
            mPanelCancel.Controls.Clear();
            mPanelCancel.Visible = true;

            Form fForm = new frmPayCancel(the_no, selected_pos_no, selected_biz_date, pay_keep, select_idx) { TopLevel = false, TopMost = true };

            mPanelCancel.Controls.Add(fForm);
            fForm.Show();

            mPanelCancel.BringToFront();

        }


        private void btnScanner_Click(object sender, EventArgs e)
        {
            btnScanner.Enabled = false;


            Form fFlow;
            fFlow = new frmScanner(20);  // ticket_no
            fFlow.ShowDialog();


            if (mIsScanOK)
            {
                lvwPayManager.Items.Clear();
                lblLayoutBill.Text = "";

                try
                {
                    String dt = mScanString.Substring(4, 8);
                    String posno = mScanString.Substring(12, 2);
                    String billno = mScanString.Substring(14, 6);

                    int yyyy = int.Parse(dt.Substring(0, 4));
                    int mm = int.Parse(dt.Substring(4, 2));
                    int dd = int.Parse(dt.Substring(6, 2));

                    dtBizDt.Value = new DateTime(yyyy, mm, dd);

                    for (int i = 0; i < cbPosNo.Items.Count; i++)
                    {
                        if (cbPosNo.Items[i].ToString() == posno)
                        {
                            cbPosNo.SelectedIndex = i;
                        }
                    }

                    tbBillNo.Text = billno;

                    viewList(dt, posno, mScanString);

                }
                catch
                {
                    SetDisplayAlarm("W", "스캔데이터 포멧 오류.");
                    return;
                }
            }

            btnScanner.Enabled = true;
        }
    }
}
