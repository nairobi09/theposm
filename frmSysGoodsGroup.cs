using System;

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;


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
            string httpsUrl = "https://jsonplaceholder.typicode.com/todos/1";
            string httpUrl = "http://jsonplaceholder.typicode.com/todos/2";

            Console.WriteLine($" -------- HTTPS ------------");

            Test(httpsUrl).GetAwaiter().GetResult();  // Main함수에서 await Test(httpsUrl) 사용못하므로, 이를 대신함

            Console.WriteLine($"\n\n\n --------- HTTP ------------");

            Test(httpUrl).GetAwaiter().GetResult();

            Console.WriteLine($" ---------- END ------------");
            Console.Read();
        }

        static async Task Test(string url)
        {
            try
            {
                using (var response = await httpClient.GetAsync(url))
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
                Console.WriteLine($"ex.Message={ex.Message}");
                Console.WriteLine($"ex.InnerException.Message = {ex.InnerException.Message}");

                Console.WriteLine($"----------- 서버에 연결할수없습니다 ---------------------");
            }
            catch (Exception ex2)
            {
                Console.WriteLine($"Exception={ex2.Message}");
            }
        }
    }
}
