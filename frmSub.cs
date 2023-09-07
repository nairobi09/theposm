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


namespace thepos
{
    public partial class frmSub : Form
    {
        public frmSub()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();
        }


        private void initialize_font()
        {
            lvwOrderItem.Font = font20;

            lblOrderAmountSumTitle.Font = font14;
            lblOrderAmountDCTitle.Font = font14;
            lblOrderAmountChargeTitle.Font = font14;
            lblOrderAmountReceiveTitle.Font = font14;
            lblOrderAmountRestTitle.Font = font14;

            lblOrderAmount.Font = font20;
            lblOrderAmountDC.Font = font20;
            lblOrderAmountNet.Font = font20;
            lblOrderAmountReceive.Font = font20;
            lblOrderAmountRest.Font = font20;


        }

        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 32);







        }


    }
}
