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
using static thepos.thePos;

namespace thepos
{
    public partial class frmSysAdmin : Form
    {
        String mThisButtonClick = "";


        public frmSysAdmin(String pass_patern)
        {
            InitializeComponent();


            if (mSiteId != "") // 로그인되었다면 panel보이기
            {
                panelAdminConsole.Visible = true;

                String m1 = get_today_date().Substring(2,1);
                String m2 = get_today_date().Substring(3, 1);
                String d1 = get_today_date().Substring(4, 1);
                String d2 = get_today_date().Substring(5, 1);

                여기를 고치자...



                if (pass_patern == "1123")
                {
                    panelCertConsole.Visible = true;
                }
            }
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

            frmSysAdminPosCert fSysAdmin = new frmSysAdminPosCert() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "User") return;

            mThisButtonClick = "User";
            panelView.Controls.Clear();

            frmSysAdminUserCert fSysAdmin = new frmSysAdminUserCert() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }


        private void btnSysShop_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Shop") return;

            mThisButtonClick = "Shop";
            panelView.Controls.Clear();

            frmSysShop fSysAdmin = new frmSysShop() { TopLevel = false, TopMost = true };
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


        private void btnSysGoodsGroup_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "GoodsGroup") return;

            mThisButtonClick = "GoodsGroup";
            panelView.Controls.Clear();

            frmSysGoodsGroup fSysAdmin = new frmSysGoodsGroup() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }



        private void btnSysGoodsItem_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "GoodsItem") return;

            mThisButtonClick = "GoodsItem";
            panelView.Controls.Clear();

            frmSysGoodsItem fSysAdmin = new frmSysGoodsItem() { TopLevel = false, TopMost = true };
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

        private void btnSysSite_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Site") return;

            mThisButtonClick = "Site";
            panelView.Controls.Clear();

            frmSysSite fSysAdmin = new frmSysSite() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }


    }
}
