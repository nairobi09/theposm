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

using static thepos.theSale;
using static thepos.frmSale;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.ComponentModel.Composition.Primitives;


namespace thepos
{
    public partial class frmPayManager : Form
    {

        System.Windows.Forms.TextBox saveKeyDisplay;





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
            dtBusiness.Value = DateTime.Now;


            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwPayManager.SmallImageList = imgList;

            cbPosNo.Items.Clear();
            for (int i = 0; i < mPosNoList.Length; i++)
            {
                cbPosNo.Items.Add(mPosNoList[i]);

                if (mPosNoList[i] == mPosNo) cbPosNo.SelectedIndex = i;
            }


            saveKeyDisplay = mTbKeyDisplayController;
            mTbKeyDisplayController = tbBillNo;

        }


        private void btnView_Click(object sender, EventArgs e)
        {

            String theNo = "";
            String billNo = tbBillNo.Text;

            if (billNo.Length == 4)
            {
                theNo = mSiteId + dtBusiness.Value.ToString("yyyyMMdd") + cbPosNo.Text + billNo;
            }

            
            viewList(theNo);
        }

        private void viewList(String the_no)
        { 

            lvwPayManager.Items.Clear();

            for (int i = 0; i < mPayments.Count; i++)
            {

                if (the_no == "" | mPayments[i].the_no == the_no)
                {
                    ListViewItem lvItem = new ListViewItem();

                    lvItem.Tag = mPayments[i].the_no;

                    lvItem.Text = mPayments[i].bill_no;

                    lvItem.SubItems.Add(get_pay_class_name(mPayments[i].pay_class));

                    lvItem.SubItems.Add(get_MMddHHmm(mPayments[i].pay_date, mPayments[i].pay_time));
                    lvItem.SubItems.Add(get_tran_type_name(mPayments[i].tran_type));

                    lvItem.SubItems.Add(mPayments[i].pos_no);
                

                    if (mPayments[i].tran_type == "C")
                        lvItem.SubItems.Add((-mPayments[i].net_amount).ToString("N0"));
                    else
                        lvItem.SubItems.Add(mPayments[i].net_amount.ToString("N0"));

                    //? 할인내용 적용 필요
                    lvItem.SubItems.Add(mPayments[i].is_dc);
                    lvItem.SubItems.Add(get_is_cancel_name(mPayments[i].is_cancel));
                    lvItem.SubItems.Add(mPayments[i].tran_type);

                    //? mPayments[i].is_cancel == "Y" 명 Strikeout으로 바꾼다.
                    //lvItem.Font = new Font(lvItem.Font, FontStyle.Strikeout);

                    lvwPayManager.Items.Add(lvItem);
                }
            }

            if (lvwPayManager.Items.Count == 1)
            {
                lvwPayManager.Items[0].Selected = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSale.ConsoleEnable();
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
            Payment payment = get_payment_by_theno(the_no);

            /* //? 제외
            if (payment.is_cancel == "Y")
            {
                SetDisplayAlarm("W", "기취소건.");
                return;
            }
            */

            int sel_idx = lvwPayManager.SelectedItems[0].Index;

            frmPayCancel fPayCancel = new frmPayCancel(the_no, "");
            fPayCancel.Left += this.Location.X;
            fPayCancel.Top += this.Location.Y;
            fPayCancel.ShowDialog();


            //payment = get_payment_by_theno(the_no);

            //? 취소여부 화면갱신
            //lvwPayManager.Items[sel_idx].SubItems[7].Text = payment.is_cancel.ToString();
            viewList(the_no);


        }

        private Payment get_payment_by_theno(String the_no)
        {
            Payment p = new Payment();

            for (int i = 0; i < mPayments.Count; i++)
            {
                if (mPayments[i].the_no == the_no)
                {
                    p = mPayments[i];
                    return p;
                }
            }

            return p;
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

                    viewList(mScanString);

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
