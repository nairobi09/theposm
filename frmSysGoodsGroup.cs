using System;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Policy;
using System.Linq;

namespace thepos
{
    public partial class frmSysGoodsGroup : Form
    {
        static readonly HttpClient httpClient = new HttpClient();


        public frmSysGoodsGroup()
        {
            InitializeComponent();
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            String responseString = "";

            int err = GetAsync(ref responseString);

            if (err == 0)
            {
                int g = responseString.Length;
            }

        }

        public int GetAsync(ref String responseString)
        {

            String URL = "http://211.42.156.219:8080/goods?siteId=sh01&posNo=01";

            try
            {
                HttpResponseMessage response = httpClient.GetAsync(URL).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    responseString = responseContent.ReadAsStringAsync().Result;

                    return 0;
                }
                else
                {
                    responseString = response.ReasonPhrase;
                    return -1;
                }

            }
            catch (HttpRequestException ex)
            {
                responseString = "서버에 연결할수없습니다";
                return -1;
            }
            catch (Exception ex2)
            {
                responseString = ex2.Message;
                return -1;
            }

        }


    }
}
