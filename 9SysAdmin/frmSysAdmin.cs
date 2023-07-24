using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thepos._9SysAdmin;

namespace thepos
{
    public partial class frmSysAdmin : Form
    {
        String mThisButtonClick = "";


        public frmSysAdmin()
        {
            InitializeComponent();
        }

        private void btnSite_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Site") return;

            mThisButtonClick = "Site";
            panelView.Controls.Clear();

            frmSysAdminSite fSysAdmin = new frmSysAdminSite() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnPos_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Pos") return;

            mThisButtonClick = "Pos";
            panelView.Controls.Clear();

            frmSysAdminPos fSysAdmin = new frmSysAdminPos() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnPosMac_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Mac") return;

            mThisButtonClick = "Mac";
            panelView.Controls.Clear();

            frmSysAdminMac fSysAdmin = new frmSysAdminMac() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "User") return;

            mThisButtonClick = "User";
            panelView.Controls.Clear();

            frmSysAdminUser fSysAdmin = new frmSysAdminUser() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }
    }
}
