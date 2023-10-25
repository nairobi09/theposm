using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thepos
{
    public partial class frmSetup : Form
    {
        String mThisButtonClick = "";


        public frmSetup()
        {
            InitializeComponent();
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
    }
}
