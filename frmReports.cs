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
            btnReportDay1.Font = font10;
            btnReportDay2.Font = font10;
            btnReportDay3.Font = font10;

            btnReportCalendar1.Font = font10;
            btnReportChart1.Font = font10;
            btnReportMonth3.Font = font10;

            btnKey1.Font = font14;
            btnKey2.Font = font14;
            btnKey3.Font = font14;
            btnKey4.Font = font14;
            btnKey5.Font = font14;
            btnKey6.Font = font14;
            btnKey7.Font = font14;
            btnKey8.Font = font14;
            btnKey9.Font = font14;
            btnKey0.Font = font14;
            btnKeyBS.Font = font14;
            btnKeyClear.Font = font14;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();

            mPanelDivision.Visible = false;
        }

        private void btnReportDay1_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Day1") return;

            mThisButtonClick = "Day1";
            panelReport.Controls.Clear();

            frmReportDay1 fBiz = new frmReportDay1() { TopLevel = false, TopMost = true };
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
    }
}
