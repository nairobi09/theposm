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
using static thepos.frmMain;
using thepos._1Sales;

namespace thepos
{
    public partial class frmReports : Form
    {
        String mThisButtonClick = "";


        public frmReports()
        {
            InitializeComponent();

            initialize_font();


        }

        private void initialize_font()
        {
            lblReportTitle.Font = font14;
            btnClose.Font = font12;

            //
            btnReportDayPos.Font = font10;
            btnReportDayShop.Font = font10;
            btnReportDayDetail.Font = font10;

            btnReportCalendar1.Font = font10;
            btnReportChart1.Font = font10;
            btnReportList1.Font = font10;


        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();

            mPanelDivision.Visible = false;
        }

        private void btnReportDayPos_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "DayPos") return;

            mThisButtonClick = "DayPos";
            panelReport.Controls.Clear();

            frmReportDayPos fBiz = new frmReportDayPos() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }

        private void btnReportDayShop_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "DayShop") return;

            mThisButtonClick = "DayShop";
            panelReport.Controls.Clear();

            frmReportDayShop fBiz = new frmReportDayShop() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }

        private void btnReportDayDetail_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "DayDetail") return;

            mThisButtonClick = "DayDetail";
            panelReport.Controls.Clear();

            frmReportDayDetail fBiz = new frmReportDayDetail() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }



        private void btnReportCalendar1_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Calemdar1") return;

            mThisButtonClick = "Calemdar1";
            panelReport.Controls.Clear();

            frmReportCalendar1 fBiz = new frmReportCalendar1() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }

        private void btnReportChart1_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Chart1") return;

            mThisButtonClick = "Chart1";
            panelReport.Controls.Clear();

            frmReportChart1 fBiz = new frmReportChart1() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }


        private void btnReportList1_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "List1") return;

            mThisButtonClick = "List1";
            panelReport.Controls.Clear();

            frmReportList1 fBiz = new frmReportList1() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }

        private void btnReportShopOreder_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "ShopOrder") return;

            mThisButtonClick = "ShopOrder";
            panelReport.Controls.Clear();

            frmReportShopOrder fBiz = new frmReportShopOrder() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }

        private void btnReportCoupon_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "CouponCert") return;

            mThisButtonClick = "CouponCert";
            panelReport.Controls.Clear();

            frmReportCoupon fBiz = new frmReportCoupon() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }

        private void btnReportAllim_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Allim") return;

            mThisButtonClick = "Allim";
            panelReport.Controls.Clear();

            frmReportAllim fBiz = new frmReportAllim() { TopLevel = false, TopMost = true };
            panelReport.Controls.Add(fBiz);
            fBiz.Show();
        }
    }
}
