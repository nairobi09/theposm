using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using thepos._1Sales;
using thepos._9SysAdmin;
using static thepos.thePos;

namespace thepos
{
    public partial class frmSysAdmin : Form
    {
        String mThisButtonClick = "";


        public frmSysAdmin(String in_patern)
        {
            InitializeComponent();

            initialize_font();


            if (mSiteId != "") // 로그인되었다면 panel보이기
            {
                panelAdminConsole.Visible = true;


                if (in_patern == "1122")
                {
                    panelCertConsole.Visible = true;
                }
            }

        }

        void initialize_font()
        {
            btnPos.Font = font10;

            btnSysSite.Font = font10;

            btnSysShop.Font = font10;
            btnSysGoods.Font = font10;

            btnSysOption.Font = font10;

            btnSysGoodsGroup.Font = font10;
            btnSysGoodsGroup2.Font = font10;

            btnSysGoodsItem.Font = font10;
            btnSysGoodsItem2.Font = font10;

            btnSysSoldout.Font = font10;

            btnDcrFavorite.Font = font10;

            btnSysPayConsole.Font = font10;

            btnPosMac.Font = font10;
            btnUser.Font = font10;

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

        private void btnSysOption_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Option") return;

            mThisButtonClick = "Option";
            panelView.Controls.Clear();

            frmSysOptionTemplate fSysAdmin = new frmSysOptionTemplate() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnSysGoodsGroup_Click(object sender, EventArgs e)  // POS
        {
            if (mThisButtonClick == "GoodsGroup") return;

            mThisButtonClick = "GoodsGroup";
            panelView.Controls.Clear();

            frmSysGoodsGroup fSysAdmin = new frmSysGoodsGroup() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnSysGoodsGroup2_Click(object sender, EventArgs e)  // KIOSK
        {
            if (mThisButtonClick == "GoodsGroup2") return;

            mThisButtonClick = "GoodsGroup2";
            panelView.Controls.Clear();

            frmSysGoodsGroup2 fSysAdmin = new frmSysGoodsGroup2() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }



        private void btnSysGoodsItem_Click(object sender, EventArgs e)  // POS
        {
            if (mThisButtonClick == "GoodsItem") return;

            mThisButtonClick = "GoodsItem";
            panelView.Controls.Clear();

            frmSysGoodsItem fSysAdmin = new frmSysGoodsItem() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnSysGoodsItem2_Click(object sender, EventArgs e)   // KIOSK
        {
            if (mThisButtonClick == "GoodsItem2") return;

            mThisButtonClick = "GoodsItem2";
            panelView.Controls.Clear();

            frmSysGoodsItem2 fSysAdmin = new frmSysGoodsItem2() { TopLevel = false, TopMost = true };
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

        private void btnDcrFavorite_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "DcrFavorite") return;

            mThisButtonClick = "DcrFavorite";
            panelView.Controls.Clear();

            frmSysDcrFavorite fSysAdmin = new frmSysDcrFavorite() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }

        private void btnSoldout_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "Soldout") return;

            mThisButtonClick = "Soldout";
            panelView.Controls.Clear();

            frmSysSoldout fSysAdmin = new frmSysSoldout() { TopLevel = false, TopMost = true };
            panelView.Controls.Add(fSysAdmin);
            fSysAdmin.Show();
        }


    }
}
