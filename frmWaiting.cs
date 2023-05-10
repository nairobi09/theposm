using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thepos;
using static thepos.frmSale;

namespace thepos
{
    public partial class frmWaiting : Form
    {
        thepos the = new thepos();

        public frmWaiting()
        {
            InitializeComponent();



            lblTitle.Font = the.fontBold_12;
            lvwWaiting.Font = the.fontMedium_10;
            btnWaitingDelete.Font = the.fontMedium_10;
            btnWaitingOK.Font = the.fontMedium_10;
            btnWaitingClose.Font = the.fontMedium_10;

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 40);
            lvwWaiting.SmallImageList = imgList;
            lvwWaiting.HideSelection = true;


            lvwWaiting.Items.Clear();

            for (int i = 0; i < listWaiting.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = listWaiting[i].waiting_no.ToString();
                item.Tag = listWaiting[i].order_no.ToString();
                item.SubItems.Add(listWaiting[i].cnt.ToString("N0"));
                item.SubItems.Add(listWaiting[i].dt.ToString("MM.dd HH:mm:ss"));
                item.SubItems.Add(listWaiting[i].amount.ToString("N0"));
                item.SubItems.Add(listWaiting[i].rcv_amount.ToString("N0"));

                String strType = "";
                if (listWaiting[i].type == "1") strType = "주문중";
                else if (listWaiting[i].type == "2") strType = "결제중";

                item.SubItems.Add(strType);

                lvwWaiting.Items.Add(item);
            }

            if (lvwWaiting.Items.Count > 0)
            {
                lvwWaiting.Items[0].Selected = true;
            }


        }

        private void btnWaitingOK_Click(object sender, EventArgs e)
        {
            if (lvwWaiting.SelectedItems.Count < 1) return;

            
            runningOrderNo = lvwWaiting.SelectedItems[0].Tag.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnWaitingDelete_Click(object sender, EventArgs e)
        {
            if (lvwWaiting.SelectedItems.Count > 0)
            {
                String order_no = lvwWaiting.SelectedItems[0].Tag.ToString();

                for (int i = listWaiting.Count - 1; i >= 0; i--)
                {
                    if (listWaiting[i].order_no == order_no)
                    {
                        listWaiting.RemoveAt(i);
                    }
                }

                for (int i = listWaitingItem.Count - 1; i >= 0; i--)
                {
                    if (listWaitingItem[i].order_no == order_no)
                    {
                        listWaitingItem.RemoveAt(i);
                    }
                }

                lvwWaiting.SelectedItems[0].Remove();
            }
        }

        private void btnWaitingClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lvwWaiting_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvwWaiting.Columns[e.ColumnIndex].Width;
        }
    }
}
