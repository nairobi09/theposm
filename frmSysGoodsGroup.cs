using System;

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace thepos
{
    public partial class frmSysGoodsGroup : Form
    {
        HttpClient httpClient = new HttpClient();


        public frmSysGoodsGroup()
        {
            InitializeComponent();
        }




        private void btnView_Click(object sender, EventArgs e)
        {

            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://www.microsoft.com/");
            string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
        }


    }
}
