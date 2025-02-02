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
using System.Security.Policy;
using thepos._1Sales;

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

            dtBizDt.Font = font10;
            cbPosNo.Font = font10;
            tbBillNo.Font = font10;

            btnView.Font = font10;
            lvwPayManager.Font = font10;
            lvwPayOrder.Font = font10;

            btnPrintBill.Font = font10;
            btnPrintBillex.Font = font9;
            btnPrintBilldisp.Font = font10;

            btnPrintOrder.Font = font9;

            btnCancel.Font = font9;

        }
        private void initialize_the()
        {
            //dtBusiness.Value = DateTime.Now;
            dtBizDt.Value = new DateTime(convert_number(mBizDate.Substring(0, 4)), convert_number(mBizDate.Substring(4, 2)), convert_number(mBizDate.Substring(6, 2)));

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwPayManager.SmallImageList = imgList;
            lvwPayOrder.SmallImageList = imgList;

            cbPosNo.Items.Clear();

            cbPosNo.Items.Add("");

            for (int i = 0; i < mPosNoList.Length; i++)
            {
                cbPosNo.Items.Add(mPosNoList[i]);
            }

            cbPosNo.SelectedIndex = 0;


            saveKeyDisplay = mTbKeyDisplayController;
            mTbKeyDisplayController = tbBillNo;


            mPanelCancel.Width = 529;
            mPanelCancel.Height = 704;

            mLvwPayManager = lvwPayManager;

        }





        private void add_viewList(String t_theNo, String t_billNo, String t_payClass, int t_amountCash, int t_amountCard, int t_amountPoint, int t_amountEasy, int t_amountCert, String t_payDate, String t_payTime, String t_posNo, int t_netAmount, int t_dcAmount, String t_isCancel)
        {
            ListViewItem lvItem = new ListViewItem();

            lvItem.Tag = t_theNo;
            lvItem.Text = t_billNo;
            lvItem.SubItems.Add(get_pay_class_name(t_payClass));

            String is_cash = "0";
            String is_card = "0";
            String is_point = "0";
            String is_easy = "0";
            String is_cert = "0";
            String pay_keep = "";

            if (t_amountCash > 0) is_cash = "1";
            if (t_amountCard > 0) is_card = "1";
            if (t_amountPoint > 0) is_point = "1";
            if (t_amountEasy > 0) is_easy = "1";
            if (t_amountCert > 0) is_cert = "1";

            pay_keep = is_cash + is_card + is_point + is_easy + is_cert;


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

            if (t_isCancel == "y")
                lvItem.SubItems.Add("취소:");
            else if (t_isCancel == "Y")
                lvItem.SubItems.Add("취소");
            else if (t_isCancel == "0")
                lvItem.SubItems.Add("취소중");
            else
                lvItem.SubItems.Add("");


            lvItem.SubItems.Add(pay_keep);
            lvItem.SubItems.Add(t_payClass);
            lvItem.SubItems.Add(t_isCancel);


            if (t_isCancel == "Y" | t_isCancel == "y")
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
            lvwPayOrder.Items.Clear();

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
                    int t_amountCert = convert_number(dr["amountCert"].ToString());
                    String t_payDate = dr["payDate"].ToString();
                    String t_payTime = dr["payTime"].ToString();
                    String t_posNo = dr["posNo"].ToString();
                    int t_netAmount = convert_number(dr["netAmount"].ToString());
                    int t_dcAmount = convert_number(dr["dcAmount"].ToString());
                    String t_isCancel = dr["isCancel"].ToString();

                    add_viewList(t_theNo, t_billNo, t_payClass, t_amountCash, t_amountCard, t_amountPoint, t_amountEasy, t_amountCert, t_payDate, t_payTime, t_posNo, t_netAmount, t_dcAmount, t_isCancel);
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
                            int t_amountCert = convert_number(arr[i]["amountCert"].ToString());
                            String t_payDate = arr[i]["payDate"].ToString();
                            String t_payTime = arr[i]["payTime"].ToString();
                            String t_posNo = arr[i]["posNo"].ToString();
                            int t_netAmount = convert_number(arr[i]["netAmount"].ToString());
                            int t_dcAmount = convert_number(arr[i]["dcAmount"].ToString());
                            String t_isCancel = arr[i]["isCancel"].ToString();

                            add_viewList(t_theNo, t_billNo, t_payClass, t_amountCash, t_amountCard, t_amountPoint, t_amountEasy, t_amountCert, t_payDate, t_payTime, t_posNo, t_netAmount, t_dcAmount, t_isCancel);
                        }
                    }
                    else
                    {
                        MessageBox.Show("데이터 오류. payment\n\n" + mObj["resultMsg"].ToString(), "thepos");
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
            int t_amountCert = 0;
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
                    t_amountCert = convert_number(dr["amountCert"].ToString());
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
                            t_amountCert = convert_number(arr[0]["amountCert"].ToString());
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
                        MessageBox.Show("영업개시마감 데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
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
            String is_cert = "0";
            String pay_keep = "";

            if (t_amountCash > 0) is_cash = "1";
            if (t_amountCard > 0) is_card = "1";
            if (t_amountPoint > 0) is_point = "1";
            if (t_amountEasy > 0) is_easy = "1";
            if (t_amountCert > 0) is_cert = "1";

            pay_keep = is_cash + is_card + is_point + is_easy + is_cert;


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
            if (t_isCancel == "y")
                lvItem.SubItems.Add("취소:");
            else if (t_isCancel == "Y")
                lvItem.SubItems.Add("취소");
            else if (t_isCancel == "0")
                lvItem.SubItems.Add("취소중");
            else
                lvItem.SubItems.Add("");



            lvItem.SubItems.Add(pay_keep);
            lvItem.SubItems.Add(t_payClass);
            lvItem.SubItems.Add(t_isCancel);


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
            if (lvwPayManager.SelectedItems.Count <= 0)
            {
                return;
            }

            String tTheNo = lvwPayManager.SelectedItems[0].Tag.ToString();
            String pay_keep = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(paykeep)].Text;

            // 취소된 건을 선택하면 취소전표를 출력한다.. 아래와 동일
            String isCancel = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(cancel_code)].Text;


            String tran_type = "A";
            if (isCancel == "Y" | isCancel == "y")
            {
                tran_type = "C";
            }

            view_list_pay_order(tTheNo, tran_type, pay_keep);
            
        }


        private void view_list_pay_order(String tTheNo, String tranType, String pay_keep)
        {
            lvwPayOrder.Items.Clear();

            //
            if (mTheMode == "Local")
                view_list_order_local(tTheNo, tranType);
            else
                view_list_order_server(tTheNo, tranType);

            //
            if (mTheMode == "Local")
                view_list_pay_local(tTheNo, tranType, pay_keep);
            else
                view_list_pay_server(tTheNo, tranType, pay_keep);


        }
        private void view_list_order_local(String tTheNo, String tranType)
        {
            SQLiteDataReader dr = sql_select_local_db("SELECT * FROM orderItem WHERE theNo='" + tTheNo + "' AND tranType='" + tranType + "'");
            while (dr.Read())
            {
                ListViewItem lvItem = new ListViewItem();

                String shop_order_no = dr["shopOrderNo"].ToString();

                if (shop_order_no.Length >= 4)
                    lvItem.Tag = "O";
                else
                    lvItem.Tag = "";

                lvItem.Text = dr["shopOrderNo"].ToString();
                lvItem.SubItems.Add(dr["goodsName"].ToString());
                lvItem.SubItems.Add(convert_number(dr["cnt"].ToString()).ToString("N0"));
                lvItem.SubItems.Add(get_shop_name(dr["shopCode"].ToString()));
                lvwPayOrder.Items.Add(lvItem);
            }

            dr.Close();
        }

        private void view_list_order_server(String tTheNo, String tranType)
        {
            String sUrl = "orderItem?siteId=" + mSiteId + "&theNo=" + tTheNo + "&tranType=" + tranType;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["orderItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        //
                        ListViewItem lvItem = new ListViewItem();

                        String shop_order_no = arr[i]["shopOrderNo"].ToString();

                        if (shop_order_no.Length >= 4)
                            lvItem.Tag = "O";
                        else
                            lvItem.Tag = "";

                        lvItem.Text = arr[i]["shopOrderNo"].ToString();
                        lvItem.SubItems.Add(arr[i]["goodsName"].ToString());
                        lvItem.SubItems.Add(convert_number(arr[i]["cnt"].ToString()).ToString("N0"));
                        lvItem.SubItems.Add(get_shop_name(arr[i]["shopCode"].ToString()));
                        lvwPayOrder.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("주문 데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류. orderItem\n\n" + mErrorMsg, "thepos");
            }
        }


        private void view_list_pay_local(String tTheNo, String tranType, String pay_keep)
        {
            String pay_keep_cash = pay_keep.Substring(0, 1);
            String pay_keep_card = pay_keep.Substring(1, 1);
            String pay_keep_point = pay_keep.Substring(2, 1);
            String pay_keep_easy = pay_keep.Substring(3, 1);

            String pay_name = "";
            int pay_amount = 0;


            //! 현금결제
            if (pay_keep_cash == "1")
            {
                SQLiteDataReader dr = sql_select_local_db("SELECT * FROM paymentCash WHERE theNo='" + tTheNo + "'");
                while (dr.Read())
                {
                    if (dr["tranType"].ToString() == tranType)
                    {
                        pay_name = get_pay_type_name(dr["payType"].ToString());
                        pay_amount = convert_number(dr["amount"].ToString());

                        if (tranType == "C") 
                            pay_amount = -pay_amount;

                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Tag = "P";
                        lvItem.Text = "(결제)";
                        lvItem.SubItems.Add(pay_name);
                        lvItem.SubItems.Add(pay_amount.ToString("N0"));
                        lvItem.SubItems.Add("");
                        lvwPayOrder.Items.Add(lvItem);
                    }
                }

                dr.Close();
            }


            //! 카드결제
            if (pay_keep_card == "1")
            {
                SQLiteDataReader dr = sql_select_local_db("SELECT * FROM paymentCard WHERE theNo='" + tTheNo + "'");
                while (dr.Read())
                {
                    if (dr["tranType"].ToString() == tranType)
                    {
                        pay_name = get_pay_type_name(dr["payType"].ToString());
                        pay_amount = convert_number(dr["amount"].ToString());

                        if (tranType == "C")
                            pay_amount = -pay_amount;

                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Tag = "P";
                        lvItem.Text = "(결제)";
                        lvItem.SubItems.Add(pay_name);
                        lvItem.SubItems.Add(pay_amount.ToString("N0"));
                        lvItem.SubItems.Add("");
                        lvwPayOrder.Items.Add(lvItem);
                    }
                }

                dr.Close();
            }


            //! 포인트
            if (pay_keep_point == "1")
            {
                SQLiteDataReader dr = sql_select_local_db("SELECT * FROM paymentPoint WHERE theNo='" + tTheNo + "'");
                while (dr.Read())
                {
                    if (dr["tranType"].ToString() == tranType)
                    {
                        pay_name = get_pay_type_name(dr["payType"].ToString());
                        pay_amount = convert_number(dr["amount"].ToString());

                        if (tranType == "C")
                            pay_amount = -pay_amount;

                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Tag = "P";
                        lvItem.Text = "(결제)";
                        lvItem.SubItems.Add(pay_name);
                        lvItem.SubItems.Add(pay_amount.ToString("N0"));
                        lvItem.SubItems.Add("");
                        lvwPayOrder.Items.Add(lvItem);
                    }
                }

                dr.Close();
            }


            // 간편결제
            if (pay_keep_easy == "1")
            {
                SQLiteDataReader dr = sql_select_local_db("SELECT * FROM paymentEasy WHERE theNo='" + tTheNo + "'");
                while (dr.Read())
                {
                    if (dr["tranType"].ToString() == tranType)
                    {
                        pay_name = get_pay_type_name(dr["payType"].ToString());
                        pay_amount = convert_number(dr["amount"].ToString());

                        if (tranType == "C")
                            pay_amount = -pay_amount;

                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Tag = "P";
                        lvItem.Text = "(결제)";
                        lvItem.SubItems.Add(pay_name);
                        lvItem.SubItems.Add(pay_amount.ToString("N0"));
                        lvItem.SubItems.Add("");
                        lvwPayOrder.Items.Add(lvItem);
                    }
                }

                dr.Close();
            }
        }

        private void view_list_pay_server(String tTheNo, String tranType, String pay_keep)
        {
            String pay_keep_cash = pay_keep.Substring(0, 1);
            String pay_keep_card = pay_keep.Substring(1, 1);
            String pay_keep_point = pay_keep.Substring(2, 1);
            String pay_keep_easy = pay_keep.Substring(3, 1);
            String pay_keep_cert = pay_keep.Substring(4, 1);

            String sUrl = "";
            String pay_name = "";
            int pay_amount = 0;


            //! 현금결제
            if (pay_keep_cash == "1")
            {
                sUrl = "paymentCash?siteId=" + mSiteId + "&theNo=" + tTheNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCashs"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i]["tranType"].ToString() == tranType)
                            {
                                pay_name = get_pay_type_name(arr[i]["payType"].ToString());
                                pay_amount = convert_number(arr[i]["amount"].ToString());

                                if (tranType == "C")
                                    pay_amount = -pay_amount;

                                //
                                ListViewItem lvItem = new ListViewItem();
                                lvItem.Tag = "P";
                                lvItem.Text = "(결제)";
                                lvItem.SubItems.Add(pay_name);
                                lvItem.SubItems.Add(pay_amount.ToString("N0"));
                                lvItem.SubItems.Add("");
                                lvwPayOrder.Items.Add(lvItem);
                            }
                        }
                    }
                }
            }


            //! 카드결제
            if (pay_keep_card == "1")
            {
                sUrl = "paymentCard?siteId=" + mSiteId + "&theNo=" + tTheNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCards"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i]["tranType"].ToString() == tranType)
                            {
                                pay_name = get_pay_type_name(arr[i]["payType"].ToString());
                                pay_amount = convert_number(arr[i]["amount"].ToString());

                                if (tranType == "C")
                                    pay_amount = -pay_amount;

                                //
                                ListViewItem lvItem = new ListViewItem();
                                lvItem.Tag = "P";
                                lvItem.Text = "(결제)";
                                lvItem.SubItems.Add(pay_name);
                                lvItem.SubItems.Add(pay_amount.ToString("N0"));
                                lvItem.SubItems.Add("");
                                lvwPayOrder.Items.Add(lvItem);
                            }
                        }
                    }
                }
            }


            //! 포인트
            if (pay_keep_point == "1")
            {
                sUrl = "paymentPoint?siteId=" + mSiteId + "&theNo=" + tTheNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentPoints"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            //? 포인트 취소인 경우 잘되는지 다시 확인바람
                            pay_name = get_pay_type_name(arr[i]["payType"].ToString());
                            pay_amount = convert_number(arr[i]["amount"].ToString());

                            if (tranType == "C")
                                pay_amount = -pay_amount;

                            //
                            ListViewItem lvItem = new ListViewItem();
                            lvItem.Tag = "P";
                            lvItem.Text = "(결제)";
                            lvItem.SubItems.Add(pay_name);
                            lvItem.SubItems.Add(pay_amount.ToString("N0"));
                            lvItem.SubItems.Add("");
                            lvwPayOrder.Items.Add(lvItem);
                        }
                    }
                }
            }


            // 간편결제
            if (pay_keep_easy == "1")
            {
                sUrl = "paymentEasy?siteId=" + mSiteId + "&theNo=" + tTheNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentEasys"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i]["tranType"].ToString() == tranType)
                            {
                                pay_name = get_pay_type_name(arr[i]["payType"].ToString());
                                pay_amount = convert_number(arr[i]["amount"].ToString());

                                if (tranType == "C")
                                    pay_amount = -pay_amount;

                                //
                                ListViewItem lvItem = new ListViewItem();
                                lvItem.Tag = "P";
                                lvItem.Text = "(결제)";
                                lvItem.SubItems.Add(pay_name);
                                lvItem.SubItems.Add(pay_amount.ToString("N0"));
                                lvItem.SubItems.Add("");
                                lvwPayOrder.Items.Add(lvItem);
                            }
                        }
                    }
                }
            }

            //! 쿠폰인증
            if (pay_keep_cert == "1")
            {
                sUrl = "paymentCert?siteId=" + mSiteId + "&theNo=" + tTheNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentCerts"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i]["tranType"].ToString() == tranType)
                            {
                                pay_name = get_pay_type_name(arr[i]["payType"].ToString());
                                pay_amount = convert_number(arr[i]["amount"].ToString());
                                String coupon_no = arr[i]["couponNo"].ToString();

                                if (tranType == "C")
                                    pay_amount = -pay_amount;

                                //
                                ListViewItem lvItem = new ListViewItem();
                                lvItem.Tag = "P";
                                lvItem.Text = "(결제)";
                                lvItem.SubItems.Add(pay_name + " " + coupon_no);
                                lvItem.SubItems.Add(pay_amount.ToString("N0"));
                                lvItem.SubItems.Add("");
                                lvwPayOrder.Items.Add(lvItem);
                            }
                        }
                    }
                }
            }
        }





        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            if (lvwPayManager.SelectedItems.Count < 1)
            {
                return;
            }

            String tTheNo = lvwPayManager.SelectedItems[0].Tag.ToString();
            String pay_keep = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(paykeep)].Text;


            // 취소된 건을 선택하면 취소전표를 출력한다.. 위와 동일
            String isCancel = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(cancel_code)].Text;

            String tran_type = "A";
            if (isCancel == "Y" | isCancel == "y")
            {
                tran_type = "C";
            }

            _print_bill(tTheNo, tran_type, "", pay_keep, false);

        }

        private void btnPrintBillex_Click(object sender, EventArgs e)
        {
            if (lvwPayManager.SelectedItems.Count < 1)
            {
                return;
            }

            String tTheNo = lvwPayManager.SelectedItems[0].Tag.ToString();
            String pay_keep = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(paykeep)].Text;


            // 취소된 건을 선택하면 취소전표를 출력한다.. 위와 동일
            String isCancel = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(cancel_code)].Text;

            String tran_type = "A";
            if (isCancel == "Y" | isCancel == "y")
            {
                tran_type = "C";
            }

            _print_bill(tTheNo, tran_type, "Y", pay_keep, false);  // Y 상품정보제외

        }


        private void btnPrintBilldisp_Click(object sender, EventArgs e)
        {
            if (lvwPayManager.SelectedItems.Count <= 0)
            {
                return;
            }

            String tTheNo = lvwPayManager.SelectedItems[0].Tag.ToString();
            String pay_keep = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(paykeep)].Text;

            // 취소된 건을 선택하면 취소전표를 출력한다.. 아래와 동일
            String isCancel = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(cancel_code)].Text;



            String tran_type = "A";
            if (isCancel == "Y" | isCancel == "y")
            {
                tran_type = "C";
            }



            //String str_bill = make_bill_header() + make_bill_body(tTheNo, tran_type, "", pay_keep) + make_bill_trailer();


            frmDisplayBill f = new frmDisplayBill(tTheNo, tran_type, pay_keep);
            f.ShowDialog();

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





        private void btnView_Click(object sender, EventArgs e)
        {
            //
            String billNo = tbBillNo.Text;

            if (billNo.Length == 6)
            {
                if (cbPosNo.Text.Length == 2)
                {

                }
                else
                {
                    SetDisplayAlarm("I", "포스번호 입력 누락.");
                    return;
                }

            }
            else if (billNo.Length == 0)
            {

            }
            else
            {
                SetDisplayAlarm("I", "주문번호 입력오류: 6자리.");
                return;
            }


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

            if (lvwPayManager.Items.Count == 1)
            {
                lvwPayManager.Items[0].Selected = true;
            }

        }

        private void btnPrintOrder_Click(object sender, EventArgs e)
        {
            if (lvwPayOrder.SelectedItems.Count < 1)
            {
                SetDisplayAlarm("I", "주문항목 선택 필요.");
                return;
            }

            if (lvwPayOrder.SelectedItems[0].Tag.ToString() != "O")  // O 주문, P 결제
            {
                SetDisplayAlarm("I", "#주문번호가 포함된 주문건 선택 필요.");
                return;
            }



            String tran_type = "A";
            String isCancel = lvwPayManager.SelectedItems[0].SubItems[lvwPayManager.Columns.IndexOf(cancel_code)].Text;
            if (isCancel == "Y" | isCancel == "y")
            {
                tran_type = "C";
            }


            String tTheNo = lvwPayManager.SelectedItems[0].Tag.ToString();




            shop_order_pack shopOrderPack = new shop_order_pack();

            List<order_pack> orderPackList = new List<order_pack>();
            order_pack orderPack = new order_pack();



            List<String> option_name_list = new List<String>();
            List<String> option_item_name_list = new List<String>();

            String t_order_no = lvwPayOrder.SelectedItems[0].Text;
            String t_shop_code = "";
            String t_order_dt = "";

            List<String> t_good_name = new List<String>();
            List<int> t_good_cnt = new List<int>();



            if (mTheMode == "Local")
            {
                SQLiteDataReader dr = sql_select_local_db("SELECT * FROM orderItem WHERE theNo='" + tTheNo + "' AND tranType='" + tran_type + "'");
                while (dr.Read())
                {
                    if (dr["shopOrderNo"].ToString() == t_order_no)
                    {
                        t_shop_code = dr["shopCode"].ToString();
                        t_order_dt = dr["orderDate"].ToString() + dr["orderTime"].ToString();

                        orderPack.goods_name = dr["goodsName"].ToString();
                        orderPack.goods_cnt = convert_number(dr["cnt"].ToString());


                        option_name_list.Clear();
                        option_item_name_list.Clear();

                        //
                        if (dr["optionNo"].ToString() != "")
                        {
                            SQLiteDataReader dr2 = sql_select_local_db("SELECT * FROM orderOptionItem WHERE optionNo='" + dr["optionNo"].ToString() + "'");
                            while (dr2.Read())
                            {
                                option_name_list.Add(dr2["optionName"].ToString());
                                option_item_name_list.Add(dr2["optionItemName"].ToString());
                            }
                        }
                        orderPack.option_name = option_name_list.ToList();
                        orderPack.option_item_name = option_item_name_list.ToList();
                        orderPackList.Add(orderPack);


                        //
                        shopOrderPack.order_no = t_order_no;
                        shopOrderPack.shop_code = t_shop_code;
                        shopOrderPack.order_dt = t_order_dt;
                        shopOrderPack.orderPackList = orderPackList;
                    }
                }
                dr.Close();
            }
            else
            {
                String sUrl = "orderItem?siteId=" + mSiteId + "&theNo=" + tTheNo + "&tranType=" + tran_type;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["orderItems"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i]["shopOrderNo"].ToString() == t_order_no)
                            {
                                t_shop_code = arr[i]["shopCode"].ToString();
                                t_order_dt = arr[i]["orderDate"].ToString() + arr[i]["orderTime"].ToString();

                                orderPack.goods_name = arr[i]["goodsName"].ToString();
                                orderPack.goods_cnt = convert_number(arr[i]["cnt"].ToString());


                                option_name_list.Clear();
                                option_item_name_list.Clear();

                                //
                                if (arr[i]["optionNo"].ToString() != "")
                                {
                                    sUrl = "orderOptionItem?siteId=" + mSiteId + "&bizDt=" + selected_biz_date + "&optionNo=" + arr[i]["optionNo"].ToString();
                                    if (mRequestGet(sUrl))
                                    {
                                        if (mObj["resultCode"].ToString() == "200")
                                        {
                                            String data2 = mObj["orderOptionItems"].ToString();
                                            JArray arr2 = JArray.Parse(data2);

                                            for (int k = 0; k < arr2.Count; k++)
                                            {
                                                option_name_list.Add(arr2[k]["optionName"].ToString());
                                                option_item_name_list.Add(arr2[k]["optionItemName"].ToString());
                                            }
                                        }
                                    }
                                }

                                orderPack.option_name = option_name_list.ToList();
                                orderPack.option_item_name = option_item_name_list.ToList();
                                orderPackList.Add(orderPack);

                                shopOrderPack.order_no = t_order_no;
                                shopOrderPack.shop_code = t_shop_code;
                                shopOrderPack.order_dt = t_order_dt;
                                shopOrderPack.orderPackList = orderPackList;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("주문 데이터 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. orderItem\n\n" + mErrorMsg, "thepos");
                    return;
                }

            }
                


            if (tran_type == "A")
            {
                // 업장주문서 출력 -> shop 등록정보 프린터
                print_order_str("to_shop", "주문서[재발급]", shopOrderPack);

                // 주문교환권 출력 -> 영수증프린터
                print_order_str("to_local", "교환권[재발급]", shopOrderPack);
            }
            else
            {
                // 업장주문서 출력 -> shop 등록정보 프린터
                print_order_str("to_shop", "취소주문서[재발급]", shopOrderPack);

                //주문교환권 출력 -> 영수증프린터
                print_order_str("to_local", "취소교환권[재발급]", shopOrderPack);
            }



        }

        private void btnScanner_Click(object sender, EventArgs e)
        {
            btnScanner.Enabled = false;

            Form f = new frmScanner(20);
            f.ShowDialog();

            if (mIsScanOK)
            {
                lvwPayManager.Items.Clear();

                try
                {
                    String dt = mScanString.Substring(4, 8);
                    String posno = mScanString.Substring(12, 2);
                    String t6no = mScanString.Substring(14, 6);

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

                    tbBillNo.Text = t6no;



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

                    if (lvwPayManager.Items.Count == 1)
                    {
                        lvwPayManager.Items[0].Selected = true;
                    }

                }
                catch
                {
                    SetDisplayAlarm("W", "스캔데이터 포멧 오류.");
                    //return;
                }
            }

            btnScanner.Enabled = true;
        }


    }
}
