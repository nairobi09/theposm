using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thepos._1Sales;
using thepos._9SysAdmin;

namespace thepos
{
    public partial class frmSysAdmin : Form
    {
        String mThisButtonClick = "";


        public frmSysAdmin()
        {
            InitializeComponent();
        }

        private void btnSite_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Site") return;

            mThisButtonClick = "Site";
            panelView.Controls.Clear();

            frmSysAdminSite fSysAdmin = new frmSysAdminSite() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnPos_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Pos") return;

            mThisButtonClick = "Pos";
            panelView.Controls.Clear();

            frmSysAdminPos fSysAdmin = new frmSysAdminPos() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnPosMac_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Mac") return;

            mThisButtonClick = "Mac";
            panelView.Controls.Clear();

            frmSysAdminMac fSysAdmin = new frmSysAdminMac() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "User") return;

            mThisButtonClick = "User";
            panelView.Controls.Clear();

            frmSysAdminUser fSysAdmin = new frmSysAdminUser() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }



        private void btnSysGoodsGroup_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "GoodsGroup") return;

            mThisButtonClick = "GoodsGroup";
            panelView.Controls.Clear();

            frmSysGoodsGroup fSysAdmin = new frmSysGoodsGroup() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnSysGoods_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Goods") return;

            mThisButtonClick = "Goods";
            panelView.Controls.Clear();

            frmSysGoods fSysAdmin = new frmSysGoods() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnSysGoodsLayout_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "GoodsLayout") return;

            mThisButtonClick = "GoodsLayout";
            panelView.Controls.Clear();

            frmSysGoods fSysAdmin = new frmSysGoods() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnSysPayConsole_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "PayConsole") return;

            mThisButtonClick = "PayConsole";
            panelView.Controls.Clear();

            frmSysPayConsole fSysAdmin = new frmSysPayConsole() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }
    }
}
