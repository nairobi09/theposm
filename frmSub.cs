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
            lblTitle1.Font = font10;
            lvwOrderItem.Font = font16;

            lblOrderAmountSumTitle.Font = font14;
            lblOrderAmountDCTitle.Font = font14;
            lblOrderAmountReceiveTitle.Font = font14;
            lblOrderAmountRestTitle.Font = font14;
            lblOrderAmountNetTitle.Font = font20;

            lblOrderAmount.Font = font16;
            lblOrderAmountDC.Font = font16;
            lblOrderAmountReceive.Font = font16;
            lblOrderAmountRest.Font = font16;
            lblOrderAmountNet.Font = font24;

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
