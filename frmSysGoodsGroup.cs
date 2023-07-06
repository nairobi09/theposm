using System;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Policy;
using System.Linq;
using static thepos.thePos;
using Newtonsoft.Json.Linq;


namespace thepos
{
    public partial class frmSysGoodsGroup : Form
    {
        GoodsGroup goodsGroup;


        public frmSysGoodsGroup()
        {
            InitializeComponent();
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            String jsonData = "";
            String URL = "http://211.42.156.219:8080/goodsGroup?siteId=sh01&posNo=01";

            int err = mGetAsync(URL, ref jsonData);

            if (err == 0)
            {
                JObject jObject = JObject.Parse(jsonData);
                String rCode = jObject["resultCode"].ToString();






            }

        }


    }
}
