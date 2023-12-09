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
using thepos._9SysAdmin;

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
            lblInfo.Font = font10;

            lblBizDtTitle.Font = font10;

            btnOK.Font = font10;
            btnCancel.Font = font10;

        }


        private void initialize_the()
        {
            dtpBizDate.Value = DateTime.Now;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mReturn = false;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SQLiteDataReader dr = sql_select_local_db("SELECT * FROM site");
            if (dr.Read())
            {
                mSiteId = dr.GetString(0);
                mBizDate = dtpBizDate.Value.ToString("yyyyMMdd");

                mReturn = true;
            }
            else
            {
                mReturn = false;
                MessageBox.Show("로컬 데이터 오류.\r\n로컬모드 사용을 할 수 없습니다.", "thepos");
            }
            dr.Close();


            Close();
        }
    }
}
