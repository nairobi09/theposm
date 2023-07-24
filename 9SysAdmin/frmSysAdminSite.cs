using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static thepos.thePos;

namespace thepos._9SysAdmin
{
    public partial class frmSysAdminSite : Form
    {
        public frmSysAdminSite()
        {
            InitializeComponent();
            initialize_font();



        }

        private void initialize_font()
        {

            lblTitle.Font = font14;

            lblSiteID.Font = font10;
            lblFullName.Font = font10;
            lblAliasName.Font = font10;
            lblRegistNo.Font = font10;
            lblCapName.Font = font10;
            lblTelNo.Font = font10;
            lblAddr.Font = font10;

            tbSiteID.Font = font14;
            tbFullName.Font = font14;
            tbAliasName.Font = font14;
            tbRegistNo.Font = font14;
            tbCapName.Font = font14;
            tbTelNo.Font = font14;
            tbAddr.Font = font14;

            btnEnter.Font = font10;
            btnCancel.Font = font10;
        }
    }
}
