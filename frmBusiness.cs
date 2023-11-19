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
    public partial class frmBusiness : Form
    {

        public static TextBox mTbKeyController;



        String mThisButtonClick = "";


        public frmBusiness()
        {
            InitializeComponent();

            initialize_font();

            initialize_the();

        }



        private void initialize_font()
        {

            lblTitle.Font = font14;
            btnClose.Font = font12;

            btnBizOpen.Font = font12;
            btnBizClose.Font = font12;

            btnKey1.Font = font14;
            btnKey2.Font = font14;
            btnKey3.Font = font14;
            btnKey4.Font = font14;
            btnKey5.Font = font14;
            btnKey6.Font = font14;
            btnKey7.Font = font14;
            btnKey8.Font = font14;
            btnKey9.Font = font14;
            btnKey0.Font = font14;
            btnKeyBS.Font = font14;
            btnKeyClear.Font = font14;

        }

        private void initialize_the()
        {

            btnKey1.Click += (sender, args) => ClickedKey("1");
            btnKey2.Click += (sender, args) => ClickedKey("2");
            btnKey3.Click += (sender, args) => ClickedKey("3");
            btnKey4.Click += (sender, args) => ClickedKey("4");
            btnKey5.Click += (sender, args) => ClickedKey("5");
            btnKey6.Click += (sender, args) => ClickedKey("6");
            btnKey7.Click += (sender, args) => ClickedKey("7");
            btnKey8.Click += (sender, args) => ClickedKey("8");
            btnKey9.Click += (sender, args) => ClickedKey("9");
            btnKey0.Click += (sender, args) => ClickedKey("0");
            btnKeyBS.Click += (sender, args) => ClickedKey("BS");
            btnKeyClear.Click += (sender, args) => ClickedKey("Clear");

        }

        private void ClickedKey(string sKey)
        {

            if (mTbKeyController == null) return;

            if (sKey == "BS")
            {
                if (mTbKeyController.Text.Length > 0)
                {
                    mTbKeyController.Text = mTbKeyController.Text.Substring(0, mTbKeyController.Text.Length - 1);
                }
            }
            else if (sKey == "Clear")
            {
                mTbKeyController.Text = "";
            }
            else
            {
                mTbKeyController.Text += sKey;
            }
        }




        // 메뉴버튼

        // 1.개시
        private void btnBizOpen_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "BizOpen") return;

            mThisButtonClick = "BizOpen";
            panelBiz.Controls.Clear();

            frmBizOpen fBiz = new frmBizOpen() { TopLevel = false, TopMost = true };
            panelBiz.Controls.Add(fBiz);
            fBiz.Show();
        }

        // 마감
        private void btnBizClose_Click(object sender, EventArgs e)
        {
            if (mThisButtonClick == "BizClose") return;

            mThisButtonClick = "BizClose";
            panelBiz.Controls.Clear();

            frmBizClose fBiz = new frmBizClose() { TopLevel = false, TopMost = true };
            panelBiz.Controls.Add(fBiz);
            fBiz.Show();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {

            Close();

            mPanelDivision.Visible = false;
        }

    }
}
