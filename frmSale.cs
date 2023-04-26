using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ▲△◀◁▶▷▼▽  <＋－＜＞↵ ↵ ⏎

namespace thepos
{
    public partial class frmSale : Form
    {
        public frmSale()
        {
            InitializeComponent();
        }

        private void btnItemScrollUp_Click(object sender, EventArgs e)
        {
            int change = flowLayoutPanelIGoodsItem.VerticalScroll.Value - flowLayoutPanelIGoodsItem.HorizontalScroll.LargeChange * 10;
            flowLayoutPanelIGoodsItem.AutoScrollPosition = new Point(0, change);
        }

        private void btnItemScrollDn_Click(object sender, EventArgs e)
        {
            int change = flowLayoutPanelIGoodsItem.VerticalScroll.Value + flowLayoutPanelIGoodsItem.HorizontalScroll.LargeChange * 10;
            flowLayoutPanelIGoodsItem.AutoScrollPosition = new Point(0, change);
        }
    }
}
