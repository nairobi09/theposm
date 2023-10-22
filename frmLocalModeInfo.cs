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
using System.Data.SQLite;
using System.IO;

namespace thepos
{
    public partial class frmLocalModeInfo : Form
    {
        public frmLocalModeInfo()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();
        }

        private void initialize_font()
        {
            lblTitle.Font = font10bold;

            lblPW.Font = font10;
            tbPW.Font = font10;

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

            lblInfo.Font = font10;


            lblLocalDbVersionTitle.Font = font10;
            lblLocalDbVersion.Font = font10;


            lblBizDtTitle.Font = font10;

            btnOK.Font = font10;
            btnCancel.Font = font10;

        }


        private void initialize_the()
        {
            mLocalMode = false;


            dtpBizDate.Value = DateTime.Now;



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
            if (sKey == "BS")
            {
                if (tbPW.Text.Length > 0)
                {
                    tbPW.Text = tbPW.Text.Substring(0, tbPW.Text.Length - 1);
                }
            }
            else if (sKey == "Clear")
            {
                tbPW.Text = "";
            }
            else
            {
                tbPW.Text += sKey;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            String siteId = "";

            String path = "local_thepos.db";


            String cs = "";


            // Degugging
            var enviroment = System.Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(enviroment).Parent.FullName;
            cs = @"URI=file:" + projectDirectory + "\\local_thepos.db";

            // Live
            cs = @"URI=file:" + Application.StartupPath + "\\local_thepos.db";





            SQLiteConnection con;
            SQLiteCommand cmd;
            SQLiteDataReader dr;

            con = new SQLiteConnection(cs);
            con.Open();

            String stm = "SELECT * FROM site";
            cmd = new SQLiteCommand(stm, con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                siteId = dr.GetString(0);
            }





            if (tbPW.Text == mSiteId)
            {
                mLocalMode = true;
                Close();
            }
            else
            {
                MessageBox.Show("인증번호 오류.", "thepos");
                return;
            }
        }
    }
}
