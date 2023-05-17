using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.frmSale;

namespace thepos.pay
{
    public partial class frmPayCash : Form
    {
        public frmPayCash()
        {
            InitializeComponent();









        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayCash_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSale.ConsoleEnable();
        }

        private void btnKeyInput_Click(object sender, EventArgs e)
        {
            btnKeyInput.Text = mLblKeyDisplay.Text;
        }
    }
}
