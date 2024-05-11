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

namespace thepos._1Sales
{
    public partial class frmReportCoupon : Form
    {
        public frmReportCoupon()
        {
            InitializeComponent();
            initialize_font();
            initialize_the();
        }

        private void initialize_font()
        {
            lblReportTitle.Font = font10;
            cbCoupon.Font = font10;
            dtpFrom.Font = font10;
            dtpTo.Font = font10;

            lvwList.Font = font10;
            btnView.Font = font10;
        }

        private void initialize_the()
        {

            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;


            cbCoupon.Items.Clear();
            cbCoupon.Items.Add("플레이스엠");
            cbCoupon.SelectedIndex = 0;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //? 쿠폰업체 추가시 아래 구분필요
            if (mCouponChPM == "")
            {
                MessageBox.Show("쿠픈판매 업체코드 미등록상태입니다.", "thepos");
                return;
            }



            String from_dt = dtpFrom.Value.ToString("yyyy-MM-dd");
            String to_dt = dtpTo.Value.ToString("yyyy-MM-dd");


            lvwList.Items.Clear();



            if (cbCoupon.SelectedIndex == 0)   // 플레이스엠
            {
                couponPM p = new couponPM();
                int ret = p.requestPmReportView(from_dt, to_dt);


                if (ret == 0)
                {
                    for (int i = 0; i < mCertOrders.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = mCertOrders[i].coupon_no;
                        lvItem.SubItems.Add(mCertOrders[i].menu_code);
                        lvItem.SubItems.Add(get_goods_name(mCertOrders[i].menu_code));
                        lvItem.SubItems.Add(mCertOrders[i].qty.ToString());
                        lvItem.SubItems.Add(mCertOrders[i].exp_date);

                        lvwList.Items.Add(lvItem);
                    }
                }

            }

        }
    }
}
