using System;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Policy;

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

            GetAsync();


        }

        static async Task GetAsync()
        {

            String URL = "http://211.42.156.219:8080/goods?siteId=sh01&posNo=01";

            try
            {
                using (var response = await httpClient.GetAsync(URL))
                {
                    Console.WriteLine(response.StatusCode);

                    if (HttpStatusCode.OK == response.StatusCode)
                    {
                        string body = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(body);
                    }
                    else
                    {
                        Console.WriteLine($" -- response.ReasonPhrase ==> {response.ReasonPhrase}");
                    }
                }

            }
            catch (HttpRequestException ex)
            {

                Console.WriteLine($"----------- 서버에 연결할수없습니다 ---------------------");
            }
            catch (Exception ex2)
            {
                Console.WriteLine($"Exception={ex2.Message}");
            }

        }


    }
}
