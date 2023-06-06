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

namespace thepos
{
    public partial class frmPayPoint : Form
    {
        TextBox saveKeyDisplay;

        int netAmount = 0;



        public frmPayPoint()
        {
            InitializeComponent();

            initialize_font();
            initial_the();


            netAmount = mNetAmount;

            lblNetAmount.Text = netAmount.ToString("N0");


        }


        void initialize_font()
        {
            lblTitle.Font = font12;
            btnClose.Font = font12;

            lblNetAmount.Font = font10;

            lblT1.Font = font10;

        }

        private void initial_the()
        {

            saveKeyDisplay = mTbKeyDisplayController;
            mTbKeyDisplayController = tbTicketNo;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayPoint_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSale.ConsoleEnable();

            mTbKeyDisplayController = saveKeyDisplay;
        }
    }
}
