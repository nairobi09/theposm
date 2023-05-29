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
using System.Drawing.Text;

namespace thepos
{
    public partial class frmOrderWaiting : Form
    {
        //thepos the = new thepos();

        public frmOrderWaiting()
        {
            InitializeComponent();
            initialize_font();
            
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 40);
            lvwWaiting.SmallImageList = imgList;
            lvwWaiting.HideSelection = true;

            lvwWaiting.Items.Clear();

            for (int i = 0; i < listWaiting.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = listWaiting[i].order_no.ToString();
                item.Tag = listWaiting[i].order_no.ToString();
                item.SubItems.Add(listWaiting[i].dt.ToString("MM.dd HH:mm:ss"));
                item.SubItems.Add(listWaiting[i].cnt.ToString("N0"));
                item.SubItems.Add(listWaiting[i].amount.ToString("N0"));

                lvwWaiting.Items.Add(item);
            }

            if (lvwWaiting.Items.Count > 0)
            {
                lvwWaiting.Items[0].Selected = true;
            }
        }


        void initialize_font()
        {
            lblTitle.Font = font12;
            lvwWaiting.Font = font12;
            btnDelete.Font = font10;
            btnOK.Font = font10;
            btnClose.Font = font12;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvwWaiting.SelectedItems.Count < 1) return;


            mSelectedWaitingNo = int.Parse(lvwWaiting.SelectedItems[0].Tag.ToString());

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwWaiting.SelectedItems.Count > 0)
            {
                int order_no = int.Parse(lvwWaiting.SelectedItems[0].Tag.ToString());

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

        private void btnClose_Click(object sender, EventArgs e)
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
