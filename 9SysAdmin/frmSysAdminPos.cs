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

namespace thepos._9SysAdmin
{
    public partial class frmSysAdminPos : Form
    {
        public frmSysAdminPos()
        {
            InitializeComponent();
            initialize_font();



        }

        private void initialize_font()
        {

            lblTitle.Font = font14;

            lblPosNo.Font = font10;



            btnEnter.Font = font10;
            btnCancel.Font = font10;
        }
    }
}
