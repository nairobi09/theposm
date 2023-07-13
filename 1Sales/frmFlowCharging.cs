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
using static thepos.frmSales;

namespace thepos
{
    public partial class frmFlowCharging : Form
    {
        TextBox saveKeyDisplay;


        int mChargeAmt = 0;

        public frmFlowCharging()
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
            tbTicketNo.Font = font14;

            btnView.Font = font10;
            lvwFlow.Font = font10;


            tbChargeAmt.Font = font14;
            btnCharge.Font = font10;
            btn1t.Font = font10;
            btn5t.Font = font10;
            btn10t.Font = font10;
            btn50t.Font = font10;
            btn100t.Font = font10;



        }
        private void initialize_the()
        {
            dtBusiness.Value = DateTime.Now;


            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwFlow.SmallImageList = imgList;

            cbPosNo.Items.Clear();
            for (int i = 0; i < mPosNoList.Length; i++)
            {
                cbPosNo.Items.Add(mPosNoList[i]);
                if (mPosNoList[i] == mPosNo) cbPosNo.SelectedIndex = i;
            }


            saveKeyDisplay = mTbKeyDisplayController;
            mTbKeyDisplayController = tbTicketNo;


            mPayClass = "CH"; // 충전 charge

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFlowCharging_FormClosed(object sender, FormClosedEventArgs e)
        {
            mClearSaleForm();

            mTbKeyDisplayController = saveKeyDisplay;
            mPayClass = "OR"; // 원복: order
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            String ticketNo = "";
            String t7No = tbTicketNo.Text;

            if (t7No.Length == 7)
            {
                ticketNo = mSiteId + dtBusiness.Value.ToString("yyyyMMdd") + cbPosNo.Text + t7No;
            }

            view_flow(ticketNo);

        }


        public void view_flow(String ticket_no)
        {

            lvwFlow.Items.Clear();

            for (int i = 0; i < mTicketFlowList.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = mTicketFlowList[i].ticket_no;

                String tStat = "";

                if (mTicketFlowList[i].flow_step == "0") tStat = "접수";
                else if (mTicketFlowList[i].flow_step == "1") tStat = "발권";
                else if (mTicketFlowList[i].flow_step == "2") tStat = "충전";
                else if (mTicketFlowList[i].flow_step == "3") tStat = "사용중";
                else if (mTicketFlowList[i].flow_step == "4") tStat = "정산완료";

                item.Text = tStat;
                item.Tag = mTicketFlowList[i].ticket_no;
                item.SubItems.Add(get_goods_name(mTicketFlowList[i].goods_code));
                item.SubItems.Add(mTicketFlowList[i].ticket_no.Substring(14, 4) + "-" + mTicketFlowList[i].ticket_no.Substring(18, 3));

                String tStr = "";

                if (mTicketFlowList[i].charge_dt != "")
                {
                    tStr = mTicketFlowList[i].charge_dt.Substring(8, 2) + ":" +
                                  mTicketFlowList[i].charge_dt.Substring(10, 2) + ":" +
                                  mTicketFlowList[i].charge_dt.Substring(12, 2);
                }

                item.SubItems.Add(tStr);
                item.SubItems.Add(mTicketFlowList[i].point_charge.ToString("N0"));
                lvwFlow.Items.Add(item);

                if (mTicketFlowList[i].ticket_no == ticket_no)
                {
                    lvwFlow.Items[i].Selected = true;
                }
            }
        }

        private void btnScanner_Click(object sender, EventArgs e)
        {
            btnScanner.Enabled = false;

            Form fFlow;
            fFlow = new frmScanner(21);  // ticket_no
            fFlow.ShowDialog();


            if (mIsScanOK)
            {
                try
                {
                    String dt = mScanString.Substring(4, 8);
                    String posno = mScanString.Substring(12, 2);
                    String t7no = mScanString.Substring(14, 7);

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

                    tbTicketNo.Text = t7no;

                    view_flow(mScanString);

                }
                catch
                {
                    SetDisplayAlarm("W", "스캔데이터 포멧 오류.");
                    return;
                }
            }

            btnScanner.Enabled = true;
        }




        private void btnCharge_Click(object sender, EventArgs e)
        {

            if (lvwFlow.SelectedItems.Count == 0)
            {
                SetDisplayAlarm("W", "항목선택 요망.");
                return;
            }


            int charge_amt = convert_number(tbChargeAmt.Text);
            if (charge_amt < 1)
            {
                SetDisplayAlarm("W", "금액오류");
                return;
            }



            MemOrderItem memOrderItem = new MemOrderItem();

            int lv_idx = (frmSales.get_lvitem_idx("CHARGE"));  // 이미  동일 상품이 주문리스트뷰에 있는지

            if (lv_idx == -1)
            {

                memOrderItem.code = "CHARGE";
                memOrderItem.name = "충전";
                memOrderItem.cnt = 1;
                memOrderItem.amt = charge_amt;
                memOrderItem.dc_amount = 0;
                memOrderItem.dcr_des = "";
                memOrderItem.dcr_type = "";
                memOrderItem.dcr_value = 0;
                memOrderItem.ticket = "";
                memOrderItem.pay_class = "CH";
                memOrderItem.ticket_no = lvwFlow.SelectedItems[0].Tag.ToString();


                ListViewItem item = new ListViewItem();
                item.Tag = memOrderItem;

                item.Text = "1";
                item.SubItems.Add(memOrderItem.name);                            // 1: name 상품명
                item.SubItems.Add(memOrderItem.amt.ToString("N0"));              // 2: amt 단가
                item.SubItems.Add(memOrderItem.cnt.ToString());                  // 3: cnt 수량
                item.SubItems.Add(memOrderItem.dc_amount.ToString("#,###"));     // 4: dc_amount 할인

                int net_amount = (memOrderItem.amt * memOrderItem.cnt) - memOrderItem.dc_amount;
                item.SubItems.Add(net_amount.ToString("N0"));                 // 5: net_amount 금액
                item.SubItems.Add(getDCRmemo(memOrderItem));                     // 6: 메모
                item.SubItems.Add(lvwFlow.SelectedItems[0].Tag.ToString());
                mLvwOrderItem.Items.Add(item);

                mLvwOrderItem.Items[0].Selected = true;

            }
            else
            {
                memOrderItem = (MemOrderItem)mLvwOrderItem.Items[lv_idx].Tag;

                memOrderItem.amt = charge_amt;
                mLvwOrderItem.Items[lv_idx].SubItems[2].Text = memOrderItem.amt.ToString("N0");     // 2: amt 단가

                int net_amount = (memOrderItem.cnt * memOrderItem.amt) - memOrderItem.dc_amount;
                mLvwOrderItem.Items[lv_idx].SubItems[5].Text = net_amount.ToString("N0");        // net_amount
                mLvwOrderItem.Items[lv_idx].SubItems[6].Text = lvwFlow.SelectedItems[0].Tag.ToString();
                mLvwOrderItem.Items[lv_idx].Tag = memOrderItem;

                mLvwOrderItem.Items[lv_idx].Selected = true;

            }

            mChargeAmt = 0;
            tbChargeAmt.Text = string.Empty;


            ReCalculateAmount();


        }

        private void btn10t_Click(object sender, EventArgs e)
        {
            mChargeAmt += 10000;
            tbChargeAmt.Text = mChargeAmt.ToString("N0");
        }

        private void btn50t_Click(object sender, EventArgs e)
        {
            mChargeAmt += 50000;
            tbChargeAmt.Text = mChargeAmt.ToString("N0");
        }

        private void btn100t_Click(object sender, EventArgs e)
        {
            mChargeAmt += 100000;
            tbChargeAmt.Text = mChargeAmt.ToString("N0");
        }

        private void btn1t_Click(object sender, EventArgs e)
        {
            mChargeAmt += 1000;
            tbChargeAmt.Text = mChargeAmt.ToString("N0");
        }

        private void btn5t_Click(object sender, EventArgs e)
        {
            mChargeAmt += 5000;
            tbChargeAmt.Text = mChargeAmt.ToString("N0");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            mChargeAmt = 0;
            tbChargeAmt.Text = mChargeAmt.ToString("N0");
        }


    }
}
