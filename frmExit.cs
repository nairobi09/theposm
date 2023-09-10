using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static thepos.thePos;

namespace thepos
{
    public partial class frmExit : Form
    {
        public frmExit()
        {
            InitializeComponent();
            initialize_font();
        }

        private void initialize_font()
        {
            btnLogout.Font = font14;
            btnRestart.Font = font14;
            btnExit.Font = font14;
            btnCancel.Font = font14;
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;   // 로그아웃
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;    // 종료
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;    // 취소
            Close();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}

