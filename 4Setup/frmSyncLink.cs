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
using System.Data.SQLite;
using static thepos.ClsWin32Api;
using System.Security.Policy;

namespace thepos
{
    public partial class frmSyncLink : Form
    {
        public frmSyncLink()
        {
            InitializeComponent();
            initialize_font();

            dtViewDate.Value = DateTime.Now;
        }


        private void initialize_font()
        {

            lblTitle.Font = font10;


            //
            lblDetail.Font = font10;
            btnSyncLink.Font = font9;
            btnDeleteLog.Font = font9;
            lvwSyncLink.Font = font9;

            //
            lblTitle2.Font = font10;
            lblVersionTitle.Font = font10;
            lblServerTitle.Font = font10;
            lblServerVersion.Font = font10;
            lblLocalTitle.Font = font10;
            lblLocalVersion.Font = font10;
            btnViewVer.Font = font10;

            //
            lblTitle3.Font = font10;
            lblCntTitle.Font = font10;
            lblOrdersTitle.Font = font10;
            lblOrdersCnt.Font = font10;
            lblOrderItemTitle.Font = font10;
            lblOrderItemCnt.Font = font10;
            lblOrderOptionItemTitle.Font = font10;
            lblOrderOptionItemCnt.Font = font10;

            lblPaymentTitle.Font = font10;
            lblPaymentCnt.Font = font10;
            lblPaymentCashTitle.Font = font10;
            lblPaymentCashCnt.Font = font10;
            lblPaymentCardTitle.Font = font10;
            lblPaymentCardCnt.Font = font10;
            lblPaymentCertTitle.Font = font10;
            lblPaymentCertCnt.Font = font10;

            btnViewRecord.Font = font10;

        }

        private void btnViewVer_Click(object sender, EventArgs e)
        {
            // 1.서버원장 다운로드
            String dt = get_version_server();
            if (dt.Length == 14)
            {
                lblServerVersion.Text = dt.Substring(0, 4) + "-" + dt.Substring(4, 2) + "-" + dt.Substring(6, 2) + "  " + dt.Substring(8, 2) + ":" + dt.Substring(10, 2) + ":" + dt.Substring(12, 2);
            }
            else
            {
                lblServerVersion.Text = dt;
            }
            

            dt = get_version_local();
            if (dt.Length == 14)
            {
                lblLocalVersion.Text = dt.Substring(0, 4) + "-" + dt.Substring(4, 2) + "-" + dt.Substring(6, 2) + "  " + dt.Substring(8, 2) + ":" + dt.Substring(10, 2) + ":" + dt.Substring(12, 2);
            }
            else
            {
                lblLocalVersion.Text = dt;
            }

        }

        private void btnViewRecord_Click(object sender, EventArgs e)
        {
            String sql = "SELECT count(*) as cnt FROM orders";
            SQLiteDataReader dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                lblOrdersCnt.Text = dr["cnt"].ToString();
            }
            dr.Close();


            sql = "SELECT count(*) as cnt FROM orderItem";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                lblOrderItemCnt.Text = dr["cnt"].ToString();
            }
            dr.Close();


            sql = "SELECT count(*) as cnt FROM orderOptionItem";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                lblOrderOptionItemCnt.Text = dr["cnt"].ToString();
            }
            dr.Close();


            //
            sql = "SELECT count(*) as cnt FROM payment";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                lblPaymentCnt.Text = dr["cnt"].ToString();
            }
            dr.Close();


            //
            sql = "SELECT count(*) as cnt FROM paymentCash";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                lblPaymentCashCnt.Text = dr["cnt"].ToString();
            }
            dr.Close();


            //
            sql = "SELECT count(*) as cnt FROM paymentCard";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                lblPaymentCardCnt.Text = dr["cnt"].ToString();
            }
            dr.Close();


            //
            sql = "SELECT count(*) as cnt FROM paymentCert";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                lblPaymentCertCnt.Text = dr["cnt"].ToString();
            }
            dr.Close();
        }

        private void btnSyncLink_Click(object sender, EventArgs e)
        {
            lvwSyncLink.Items.Clear();


            string sl_date = dtViewDate.Value.ToString("yyyyMMdd");

            String sql = "SELECT * FROM syncLink WHERE sl_date = '" + sl_date + "' ORDER BY sl_time";
            SQLiteDataReader dr = sql_select_local_db(sql);
            while (dr.Read())
            {
                ListViewItem lvItem = new ListViewItem();

                String t = dr["sl_time"].ToString();

                lvItem.Text = t.Substring(0,2) + ":" + t.Substring(2, 2) + ":" + t.Substring(4, 2);
                lvItem.SubItems.Add(dr["msg"].ToString());
                lvwSyncLink.Items.Add(lvItem);
            }
            dr.Close();

            if (lvwSyncLink.Items.Count > 0)
            {
                lvwSyncLink.EnsureVisible(lvwSyncLink.Items.Count - 1);
            }
            
        }

        private void btnDeleteLog_Click(object sender, EventArgs e)
        {
            //int ret = sql_excute_local_db("TRUNCATE TABLE syncLink");  // 권한필요
            int ret = sql_excute_local_db("DELETE FROM syncLink");

            lvwSyncLink.Items.Clear();
        }

        private void btnDbLoad_Click(object sender, EventArgs e)
        {
            mSyncLinkWaitCnt = 10000;

            MessageBox.Show("수동 업로드/다운로드 작업이 시작됩니다.", "thepos");

        }

    }
}
