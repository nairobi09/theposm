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
    public partial class frmSetup : Form
    {
        String mThisButtonClick = "";


        public frmSetup()
        {
            InitializeComponent();

            initialize_font();


        }

        private void initialize_font()
        {
            lblTitle.Font = font14;
            btnClose.Font = font12;

            btnSetupPos.Font = font10;
            btnSyncLink.Font = font10;

        }



        private void btnSetupPos_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "setupPos") return;

            mThisButtonClick = "setupPos";
            panelSetup.Controls.Clear();

            frmSetupPos fSetup = new frmSetupPos() { TopLevel = false, TopMost = true };
            panelSetup.Controls.Add(fSetup);
            fSetup.Show();
        }

        private void btnSyncLink_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "setupSyncLink") return;

            mThisButtonClick = "setupSyncLink";
            panelSetup.Controls.Clear();

            frmSyncLink fSetup = new frmSyncLink() { TopLevel = false, TopMost = true };
            panelSetup.Controls.Add(fSetup);
            fSetup.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            mPanelDivision.Visible = false;
        }


    }
}
