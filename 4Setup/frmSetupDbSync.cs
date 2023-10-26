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
using static thepos.frmMain;

namespace thepos
{
    public partial class frmSetupDbSync : Form
    {
        public frmSetupDbSync()
        {
            InitializeComponent();
        }

        private void btnSyncDataServerToLocalAndMemory_Click(object sender, EventArgs e)
        {
            // 서버 -> 로걸
            sync_data_server_to_local();
        }
    }
}
