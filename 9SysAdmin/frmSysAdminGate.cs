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


namespace thepos
{
    public partial class frmSysAdminGate : Form
    {

        String strPW = "";


        public frmSysAdminGate()
        {
            InitializeComponent();

            initialize_font();
        }

        private void initialize_font()
        {
            lblTitle.Font = font14;

            btnKey1.Font = font14;
            btnKey2.Font = font14;
            btnKey3.Font = font14;
            btnKey4.Font = font14;
            btnKey5.Font = font14;
            btnKey6.Font = font14;
            btnKey7.Font = font14;
            btnKey8.Font = font14;
            btnKey9.Font = font14;
            btnKey0.Font = font14;
            btnKeyBS.Font = font14;
            btnKeyClear.Font = font14;

            btnOK.Font = font12;
            btnCancel.Font = font12;
        }

        private void btnKey1_Click(object sender, EventArgs e)
        {
            strPW += "1";
        }

        private void btnKey2_Click(object sender, EventArgs e)
        {
            strPW += "2";
        }

        private void btnKey3_Click(object sender, EventArgs e)
        {
            strPW += "3";
        }

        private void btnKey4_Click(object sender, EventArgs e)
        {
            strPW += "4";
        }

        private void btnKey5_Click(object sender, EventArgs e)
        {
            strPW += "5";
        }

        private void btnKey6_Click(object sender, EventArgs e)
        {
            strPW += "6";
        }

        private void btnKey7_Click(object sender, EventArgs e)
        {
            strPW += "7";
        }

        private void btnKey8_Click(object sender, EventArgs e)
        {
            strPW += "8";
        }

        private void btnKey9_Click(object sender, EventArgs e)
        {
            strPW += "9";
        }

        private void btnKey0_Click(object sender, EventArgs e)
        {
            strPW += "0";
        }

        private void btnKeyClear_Click(object sender, EventArgs e)
        {
            strPW = "";
        }

        private void btnKeyBS_Click(object sender, EventArgs e)
        {
            int len = strPW.Length;

            if (len > 0 )
            {
                strPW = strPW.Substring(0, strPW.Length - 1);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //? if (strPW == "743905")   // thepos
            if (strPW == "1111")
            {
                this.Close();

                frmSysAdmin frmSysAdmin = new frmSysAdmin();
                frmSysAdmin.ShowDialog();



            }
            else
            {
                strPW = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
