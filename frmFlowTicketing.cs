using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.theSale;
using static thepos.frmSale;

namespace thepos
{
    public partial class frmFlowTicketing : Form
    {
        TextBox saveKeyDisplay;


        public frmFlowTicketing()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();
        }

        private void initialize_font()
        {
            lblTitle.Font = font12;
            btnClose.Font = font12;

            dtBusiness.Font = font10;

            lbl1.Font = font9;
            lbl2.Font = font9;
            lbl3.Font = font9;

            dtBusiness.Font = font10;
            cbPosNo.Font = font10;
            tbTicketNo.Font = font10;

            btnView.Font = font10;
            lvwFlow.Font = font10;


        }
        private void initialize_the()
        {
            dtBusiness.Value = DateTime.Now;


            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwFlow.SmallImageList = imgList;

            cbPosNo.Items.Clear();
            cbPosNo.Items.Add("");
            for (int i = 0; i < mPosNoList.Length; i++)
            {
                cbPosNo.Items.Add(mPosNoList[i]);
            }


            saveKeyDisplay = mTbKeyDisplayController;
            mTbKeyDisplayController = tbTicketNo;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFlowTicketing_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSale.ConsoleEnable();
            mTbKeyDisplayController = saveKeyDisplay;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mTicketFlow.Count; i++)
            {



            }




        }
    }
}
