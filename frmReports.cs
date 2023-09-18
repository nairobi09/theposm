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
        public frmReports()
        {
            InitializeComponent();
        }















        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();

            mPanelDivision.Visible = false;
        }

    }
}
