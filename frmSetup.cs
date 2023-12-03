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


            if (mTheMode == "Local")
            {
                btnBasicDbDown.Enabled = false;
                btnLocalDbUp.Enabled = false;
            }
            else
            {
                btnBasicDbDown.Enabled = true;
                btnLocalDbUp.Enabled = true;
            }

        }

        private void initialize_font()
        {
            lblTitle.Font = font14;
            btnClose.Font = font12;

            btnSetupPos.Font = font10;
            btnBasicDbDown.Font = font10;
            btnLocalDbUp.Font = font10;

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

        private void btnSetupDbSync_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "setupDbSync") return;

            mThisButtonClick = "setupDbSync";
            panelSetup.Controls.Clear();

            frmSetupDbSync fSetup = new frmSetupDbSync() { TopLevel = false, TopMost = true };
            panelSetup.Controls.Add(fSetup);
            fSetup.Show();
        }

        private void btnSetupLocalMode_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "setupLocalMode") return;

            mThisButtonClick = "setupLocalMode";
            panelSetup.Controls.Clear();

            frmSetupLocalMode fSetup = new frmSetupLocalMode() { TopLevel = false, TopMost = true };
            panelSetup.Controls.Add(fSetup);
            fSetup.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            mPanelDivision.Visible = false;
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
    }
}
