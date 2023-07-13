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

namespace thepos._2Business
{
    public partial class frmBizClose : Form
    {
        public frmBizClose()
        {
            InitializeComponent();

            initialize_font();

            initialize_the();


        }



        private void initialize_font()
        {

            lblTitle.Font = font12;

            lblBizDate0.Font = font10;
            lblBizDate.Font = font12bold;

            lblBizDateNo0.Font = font10;
            lblBizDateNo.Font = font12bold;

            lblLastBizDtInput0.Font = font10;
            lblLastBizDtInput.Font = font10;

        }

        private void initialize_the()
        {

            

        }



    }
}
