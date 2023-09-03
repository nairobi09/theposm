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


namespace thepos
{
    public partial class frmPayManager : Form
    {

        System.Windows.Forms.TextBox saveKeyDisplay;

        String selected_biz_date = "";
        String selected_pos_no = "";
        String selected_the_no = "";



        public frmPayManager()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();
        }

        private void initialize_font()
        {
            lblTitle.Font = font12;
            btnClose.Font = font12;

            dtBusiness.Font = font10;

            lbl1.Font = font9;
            lbl2.Font = font9;
            lbl3.Font = font9;

            dtBusiness.Font = font10;
            cbPosNo.Font = font10;
            tbBillNo.Font = font14;

            btnView.Font = font10;
            lvwPayManager.Font = font10;


        }
        private void initialize_the()
        {
            //dtBusiness.Value = DateTime.Now;
            dtBusiness.Value = new DateTime(convert_number(mBizDate.Substring(0, 4)), convert_number(mBizDate.Substring(4, 2)), convert_number(mBizDate.Substring(6, 2)));


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

        }


        private void btnView_Click(object sender, EventArgs e)
        {
            String billNo = tbBillNo.Text;

            selected_biz_date = dtBusiness.Value.ToString("yyyyMMdd");
            selected_pos_no = cbPosNo.Text;

            if (billNo.Length == 4)
            {
                selected_the_no = mSiteId + selected_biz_date + selected_pos_no + billNo;
            }
            
            viewList(selected_biz_date, selected_pos_no, selected_the_no);
        }


        private void viewList(String biz_date, String pos_no, String the_no)
        { 
            lvwPayManager.Items.Clear();


            //!
            String sUrl = "payment?siteId=" + mSiteId + "&bizDt=" + biz_date + "&posNo=" + pos_no + "&theNo=" + the_no;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["payments"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();

                        lvItem.Tag = arr[i]["theNo"].ToString();
                        lvItem.Text = arr[i]["billNo"].ToString();
                        lvItem.SubItems.Add(get_pay_class_name(arr[i]["payClass"].ToString()));
                        lvItem.SubItems.Add(get_MMddHHmm(arr[i]["payDate"].ToString(), arr[i]["payTime"].ToString()));
                        lvItem.SubItems.Add(get_tran_type_name(arr[i]["tranType"].ToString()));
                        lvItem.SubItems.Add(arr[i]["posNo"].ToString());

                        if (arr[i]["tranType"].ToString() == "C")
                            lvItem.SubItems.Add((-convert_number(arr[i]["netAmount"].ToString())).ToString("N0"));
                        else
                            lvItem.SubItems.Add((convert_number(arr[i]["netAmount"].ToString())).ToString("N0"));

                        //? 할인내용 적용 필요
                        lvItem.SubItems.Add(arr[i]["isDc"].ToString());

                        lvItem.SubItems.Add(arr[i]["isCancel"].ToString());
                        lvItem.SubItems.Add(arr[i]["tranType"].ToString());

                        if (arr[i]["isCancel"].ToString() == "Y")
                        {
                            lvItem.ForeColor = Color.Silver;
                            lvItem.SubItems[1].ForeColor = Color.Silver;
                            lvItem.SubItems[2].ForeColor = Color.Silver;
                            lvItem.SubItems[3].ForeColor = Color.Silver;
                            lvItem.SubItems[4].ForeColor = Color.Silver;
                            lvItem.SubItems[5].ForeColor = Color.Silver;
                            lvItem.SubItems[6].ForeColor = Color.Silver;
                            lvItem.SubItems[7].ForeColor = Color.Silver;
                            lvItem.SubItems[8].ForeColor = Color.Silver;
                        }

                        lvwPayManager.Items.Add(lvItem);
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


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSales.ConsoleEnable();
            mTbKeyDisplayController = saveKeyDisplay;
            
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
            String tranType = lvwPayManager.SelectedItems[0].SubItems[8].Text;


            lblLayoutBill.Text = make_bill_header() + make_bill_body(tTheNo, tranType, "") + make_bill_trailer();


        }



        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (lvwPayManager.SelectedItems.Count < 1)
            {
                return;
            }


            String tTheNo = lvwPayManager.SelectedItems[0].Tag.ToString();
            String tranType = lvwPayManager.SelectedItems[0].SubItems[8].Text;




            String headerBill = make_bill_header();
            String bodyBill = make_bill_body(tTheNo, tranType, "");
            String trailerBill = make_bill_trailer();


            PrintBill(headerBill, bodyBill, trailerBill, tTheNo);


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            if (lvwPayManager.SelectedItems.Count < 1)
            {
                SetDisplayAlarm("W", "대상거래 선택요망.");
                return; 
            }

            String the_no = lvwPayManager.SelectedItems[0].Tag.ToString();
            

            int sel_idx = lvwPayManager.SelectedItems[0].Index;

            frmPayCancel fPayCancel = new frmPayCancel(the_no, "");
            fPayCancel.Left += this.Location.X;
            fPayCancel.Top += this.Location.Y;
            fPayCancel.ShowDialog();

            
            
            viewList(selected_biz_date, selected_pos_no, selected_the_no);

        }


        private void cbwithoutGoods_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnScanner_Click(object sender, EventArgs e)
        {
            btnScanner.Enabled = false;


            Form fFlow;
            fFlow = new frmScanner(18);  // ticket_no
            fFlow.ShowDialog();


            if (mIsScanOK)
            {
                lvwPayManager.Items.Clear();
                lblLayoutBill.Text = "";

                try
                {
                    String dt = mScanString.Substring(4, 8);
                    String posno = mScanString.Substring(12, 2);
                    String billno = mScanString.Substring(14, 4);

                    int yyyy = int.Parse(dt.Substring(0, 4));
                    int mm = int.Parse(dt.Substring(4, 2));
                    int dd = int.Parse(dt.Substring(6, 2));

                    dtBusiness.Value = new DateTime(yyyy, mm, dd);

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
