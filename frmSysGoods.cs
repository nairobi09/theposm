using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;

namespace thepos
{
    public partial class frmSysGoods : Form
    {
        public frmSysGoods()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {

            String responseString = "";
            String URL = "http://211.42.156.219:8080/goodsItem?siteId=sh01&posNo=01";

            int err = mGetAsync(URL, ref responseString);

            if (err == 0)
            {
                int g = responseString.Length;

                MessageBox.Show(responseString);



            }

        }


    }
}
