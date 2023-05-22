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
        //mNetAmount
        Int32 rcvAmount = 0;
        Int32 restAmount = 0;

        bool isReset = true;

        public frmPayCash()
        {
            InitializeComponent();

            initial_the();


            reset_amount();

        }

        private void initial_the()
        {

        }



        private void reset_amount()
        {
            rcvAmount = mNetAmount;
            restAmount = 0;

            lblNetAmount.Text = mNetAmount.ToString("N0");
            lblRcvAmount.Text = rcvAmount.ToString("N0");
            lblRestAmount.Text = "0";

            isReset = true;
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            reset_amount();
        }

        private void btn1t_Click(object sender, EventArgs e) { reDisplayAmount(1000); }
        private void btn5t_Click(object sender, EventArgs e) { reDisplayAmount(5000); }
        private void btn10t_Click(object sender, EventArgs e) { reDisplayAmount(10000); }
        private void btn50t_Click(object sender, EventArgs e) { reDisplayAmount(50000); }
        private void btn100t_Click(object sender, EventArgs e) { reDisplayAmount(100000); }

        private void reDisplayAmount(Int32 amount)
        {
            if (isReset)
            {
                isReset = false;
                rcvAmount = 0;
            }

            rcvAmount += amount;

            restAmount = rcvAmount - mNetAmount;
            lblRcvAmount.Text = rcvAmount.ToString("N0");
            lblRestAmount.Text = restAmount.ToString("N0");
        }


        private void cbtypeIndividual_CheckedChanged(object sender, EventArgs e)
        {
            cbTypeBusiness.Checked = !cbtypeIndividual.Checked;
        }

        private void cbTypeBusiness_CheckedChanged(object sender, EventArgs e)
        {
            cbtypeIndividual.Checked = !cbTypeBusiness.Checked;
        }



        private void btnKeyInput_Click(object sender, EventArgs e)
        {
            lblIssuedMethodNo.Text = mLblKeyDisplay.Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayCash_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSale.ConsoleEnable();
        }



    }
}
