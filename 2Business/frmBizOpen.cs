using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.frmBusiness;

namespace thepos._2Business
{
    public partial class frmBizOpen : Form
    {
        public frmBizOpen()
        {
            InitializeComponent();

            mTbKeyController = tbBizOpenAmount;
        }

        private void btnBizOpenInput_Click(object sender, EventArgs e)
        {
            



        }

        private void tbBizOpenAmount_Click(object sender, EventArgs e)
        {
            mTbKeyController = tbBizOpenAmount;
        }
    }
}
