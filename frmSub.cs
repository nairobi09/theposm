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

            lblSiteAlias.Text = mSiteAlias;
            lblSiteName.Text = mSiteName;

        }


        private void initialize_font()
        {
            lvwOrderItem.Font = font20;

            lblOrderAmountSumTitle.Font = font20;
            lblOrderAmountDCTitle.Font = font20;
            lblOrderAmountChargeTitle.Font = font20;
            lblOrderAmountReceiveTitle.Font = font20;
            lblOrderAmountRestTitle.Font = font20;

            lblOrderAmount.Font = font24;
            lblOrderAmountDC.Font = font24;
            lblOrderAmountNet.Font = font24;
            lblOrderAmountReceive.Font = font24;
            lblOrderAmountRest.Font = font24;

            lblSiteAlias.Font = font24;
            lblSiteName.Font = font12;


        }

        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 60);

            lvwOrderItem.SmallImageList = imgList;
            lvwOrderItem.HideSelection = true;


            mPanelOrderInfo = panelOrderInfo;
            mSublvwOrderItem = lvwOrderItem;


            mSublblOrderAmount = lblOrderAmount;
            mSublblOrderAmountDC = lblOrderAmountDC;
            mSublblOrderAmountNet = lblOrderAmountNet;
            mSublblOrderAmountReceive = lblOrderAmountReceive;
            mSublblOrderAmountRest = lblOrderAmountRest;



        }


    }
}
