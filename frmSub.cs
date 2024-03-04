using BrightIdeasSoftware;
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
        public struct OrderItem
        {
            public int lv_order_no;             // 
            public String lv_goods_name;        // 상품name or 전체할인명("할인")
            public String lv_cnt;
            public String lv_amt;
            public String lv_dc_amount;         // 실할인금액
            public String lv_net_amount;        // 결제금액

            public String option_name_description;          // render를 통한 옵션 표시
            public String option_amt_description;          // render를 통한 옵션 표시

            public String lv_memo;
        }
        public static List<OrderItem> mOrrdeItemList = new List<OrderItem>();


        public frmSub()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();

        }


        private void initialize_font()
        {
            //lvwOrderItem.Font = font16;

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

        }

        private void initialize_the()
        {
            lvwOrderItem.HideSelection = true;

            mPanelOrderInfo = panelOrderInfo;
            mSublvwOrderItem = lvwOrderItem;


            mSublblOrderAmount = lblOrderAmount;
            mSublblOrderAmountDC = lblOrderAmountDC;
            mSublblOrderAmountNet = lblOrderAmountNet;
            mSublblOrderAmountReceive = lblOrderAmountReceive;
            mSublblOrderAmountRest = lblOrderAmountRest;



            this.lv_name.Renderer = rendererName();
            this.lv_amt.Renderer = rendererAmt();
        }

        public DescribedTaskRenderer rendererName()
        {
            DescribedTaskRenderer renderer = new DescribedTaskRenderer();
            renderer.DescriptionAspectName = "option_name_description";

            renderer.TitleFont = new Font("굴림", 15, FontStyle.Regular);
            renderer.DescriptionFont = new Font("굴림", 10, FontStyle.Regular);
            renderer.DescriptionColor = Color.Gray;
            renderer.ImageTextSpace = 0;
            renderer.TitleDescriptionSpace = 0;
            renderer.UseGdiTextRendering = false;

            return (renderer);
        }

        public DescribedTaskRenderer rendererAmt()
        {
            DescribedTaskRenderer renderer = new DescribedTaskRenderer();
            renderer.DescriptionAspectName = "option_amt_description";

            renderer.TitleFont = new Font("굴림", 15, FontStyle.Regular);
            renderer.DescriptionFont = new Font("굴림", 10, FontStyle.Regular);
            renderer.DescriptionColor = Color.Gray;
            renderer.ImageTextSpace = 0;
            renderer.TitleDescriptionSpace = 0;
            renderer.UseGdiTextRendering = false;

            return (renderer);
        }

        private void frmSub_FormClosed(object sender, FormClosedEventArgs e)
        {
            fSub = null;
        }
    }
}
