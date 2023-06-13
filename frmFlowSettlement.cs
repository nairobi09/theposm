using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.theSale;
using static thepos.frmSale;

namespace thepos
{
    public partial class frmFlowSettlement : Form
    {
        TextBox saveKeyDisplay;

        public frmFlowSettlement()
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
            lbl4.Font = font9;

            dtBusiness.Font = font10;
            cbPosNo.Font = font10;
            tbBillNo.Font = font14;

            btnView.Font = font10;
            lvwFlow.Font = font10;

            btnSettlement.Font = font10;


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
            mTbKeyDisplayController = tbBillNo;

            mPayClass = "2"; // 정산 settement

        }



        private void btnView_Click(object sender, EventArgs e)
        {
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
                item.SubItems.Add(get_goods_name(mTicketFlowList[i].goods_code));
                item.SubItems.Add(mTicketFlowList[i].ticket_no.Substring(14, 4) + "-" + mTicketFlowList[i].ticket_no.Substring(18, 3));

                item.SubItems.Add(mTicketFlowList[i].point_charge.ToString("N0"));
                item.SubItems.Add(mTicketFlowList[i].point_usage.ToString("N0"));

                item.SubItems.Add(get_goods_name(mTicketFlowList[i].point_charge.ToString("N0")));

                lvwFlow.Items.Add(item);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFlowSettlement_FormClosed(object sender, FormClosedEventArgs e)
        {
            mClearSaleForm();

            mTbKeyDisplayController = saveKeyDisplay;
            mPayClass = "0"; // 원복: order
        }

        private void lvwFlow_SelectedIndexChanged(object sender, EventArgs e)
        {



        }
    }
}
