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
    public partial class frmReqUser : Form
    {
        public frmReqUser()
        {
            InitializeComponent();

            initialize_font();



        }

        private void initialize_font()
        {

            lblTitle.Font = font14;

            lblID.Font = font10;
            lblPW.Font = font10;

            tbID.Font = font14;
            tbPW1.Font = font14;
            tbPW2.Font = font14;

            lblName.Font = font10;
            tbName.Font = font14;


            btnEnter.Font = font10;
            btnCancel.Font = font10;

            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
