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
    public partial class frmFlowTicketing : Form
    {
        TextBox saveKeyDisplay;


        public frmFlowTicketing()
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
            lvwFlow.Font = font10;


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

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFlowTicketing_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSales.ConsoleEnable();
            mTbKeyDisplayController = saveKeyDisplay;
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
                item.SubItems.Add(mTicketFlowList[i].ticket_no.Substring(14,4) + "-" + mTicketFlowList[i].ticket_no.Substring(18,3));
                item.SubItems.Add(mTicketFlowList[i].ticketing_dt.Substring(8, 2) + ":" +
                                  mTicketFlowList[i].ticketing_dt.Substring(10, 2) + ":" +
                                  mTicketFlowList[i].ticketing_dt.Substring(12, 2));

                lvwFlow.Items.Add(item);
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnReader_Click(object sender, EventArgs e)
        {

        }
    }
}
