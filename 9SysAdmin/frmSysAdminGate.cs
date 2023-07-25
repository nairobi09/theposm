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



        public frmSysAdminGate()
        {
            InitializeComponent();

            initialize_font();
        }

        private void initialize_font()
        {
            lblTitle.Font = font14;

            lblID.Font = font12;
            lblPW.Font = font12;

            tbID.Font = font14;
            tbPW.Font = font14;


            btnOK.Font = font12;
            btnCancel.Font = font12;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            //? if (strPW == "743905")   // thepos

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
