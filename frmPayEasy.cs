using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.theSale;
using static thepos.frmSale;
using static thepos.frmPayComplex;
using static thepos.paymentToss;

namespace thepos
{
    public partial class frmPayEasy : Form
    {

        TextBox saveKeyDisplay;


        public frmPayEasy()
        {
            InitializeComponent();

            initialize_font();



            saveKeyDisplay = mTbKeyDisplayController;
            mTbKeyDisplayController = tbCardNo;

        }
        private void initialize_font()
        {
            lblTitle.Font = font12;




            btnClose.Font = font12;
        }
        private void btnEasyAuth_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayEasy_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSale.ConsoleEnable();

            mTbKeyDisplayController = saveKeyDisplay;
        }
    }
}
