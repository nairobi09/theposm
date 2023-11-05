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
using Newtonsoft.Json.Linq;
using System.Data.SQLite;

namespace thepos
{
    public partial class frmSetupDbSync : Form
    {
        public frmSetupDbSync()
        {
            InitializeComponent();
            initialize_font();

        }


        private void initialize_font()
        {
            lblTitle.Font = font10;

            lblVersionTitle.Font = font10;

            lblServerTitle.Font = font10;
            lblServerVersion.Font = font10;
            lblLocalTitle.Font = font10;
            lblLocalVersion.Font = font10;

            btnView.Font = font10;
            btnDownload.Font = font10;

        }


        private void btnView_Click(object sender, EventArgs e)
        {
            view_version();
        }

        private void view_version()
        { 
            String sUrl = "site?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["sites"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count > 0)
                    {
                        String dt = arr[0]["basicDbVer"].ToString();
                        lblServerVersion.Text = dt.Substring(0, 4) + "-" + dt.Substring(4, 2) + "-" + dt.Substring(6, 2) + "  " + dt.Substring(8, 2) + ":" + dt.Substring(10, 2) + ":" + dt.Substring(12, 2);
                    }
                    else
                    {
                        MessageBox.Show("데이터 오류. site", "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("사업자정보 오류. site\n\n " + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. site\n\n" + mErrorMsg, "thepos");
                return;
            }

            //
            String sql = "SELECT * FROM site";
            SQLiteDataReader dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                String dt = dr["basicDbVer"].ToString();
                lblLocalVersion.Text = dt.Substring(0, 4) + "-" + dt.Substring(4, 2) + "-" + dt.Substring(6, 2) + "  " + dt.Substring(8, 2) + ":" + dt.Substring(10, 2) + ":" + dt.Substring(12, 2);
            }
        }


        private void btnDownload_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("다운로드 확인.\r\n서버로부터 기초원장을 로컬DB로 다운로드합니다.", "thepos", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                sync_data_server_to_local();

                view_version();

                //MessageBox.Show("다운로드 완료", "thepos");

            }
        }
    }
}
