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
    }
}
