using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.frmSale;

namespace thepos
{
    public partial class frmPayManager : Form
    {



        public frmPayManager()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();
        }

        private void initialize_font()
        {
            lblTitle.Font = font12;
            dtBusiness.Font = font10;
            btnView.Font = font10;
            lvwPayment.Font = font10;


            btnClose.Font = font20;

        }
        private void initialize_the()
        {
            dtBusiness.Value = DateTime.Now;

        }

        private void btnView_Click(object sender, EventArgs e)
        {

            String dt = dtBusiness.Value.ToString("yyyyMMdd");










        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSale.ConsoleEnable();
        }


    }
}

