using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.frmSale;

namespace thepos
{
    public partial class frmProductWaiting : Form
    {
        thepos the = new thepos();

        //public int limit_waiting_no = 0;


        public frmProductWaiting(Point p)
        {
            InitializeComponent();

            // 488, 56 529, 547
            this.Location = new Point(p.X + 488, p.Y + 56);


            initialize_the();


            for (int i = 0; i < the.listWaiting.Count ; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = the.listWaiting[i].waiting_no.ToString();
                item.SubItems.Add(the.listWaiting[i].cnt.ToString("N0"));
                item.SubItems.Add(the.listWaiting[i].dt.ToString("hh:mm:ss"));
                item.SubItems.Add(the.listWaiting[i].amount.ToString("N0"));
                item.SubItems.Add(the.listWaiting[i].rcv_amount.ToString("N0"));

                String strType = "";
                if (the.listWaiting[i].type == "1") strType = "주문중";
                else if (the.listWaiting[i].type == "2") strType = "결제중";

                item.SubItems.Add(strType);

                lvwWaiting.Items.Add(item);
            }





        }


        private void initialize_the()
        {
            //기본폰트
            this.Font = the.fontMedium_10;


            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 32);
            lvwWaiting.SmallImageList = imgList;
            // item 클릭시 선택바 (backcolor=blue) 표시를 위해서...
            lvwWaiting.HideSelection = true;
            





        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
