using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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





        }


        private void initialize_the()
        {

            lblTitle.Font = the.fontBold_12;
            btnClose.Font = the.fontMedium_10;


            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 32);
            lvwWaiting.SmallImageList = imgList;
            // item 클릭시 선택바 (backcolor=blue) 표시를 위해서...
            lvwWaiting.HideSelection = true;
            lvwWaiting.Font = the.fontMedium_12;





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
