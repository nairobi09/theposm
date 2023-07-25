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
    public partial class frmSysPayConsole : Form
    {
        public frmSysPayConsole()
        {
            InitializeComponent();

            initialize_font();

            initialize_the();
        }


        private void initialize_font()
        {
            lvwButton.Font = font10;
        }

        public void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 32);

            lvwButton.SmallImageList = imgList;
            lvwButton.HideSelection = true;


        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //? 서버에서 다운로드 


            //? 임시로 기본세팅
            set_origin_layout();

        }

        private void btnOrigin_Click(object sender, EventArgs e)
        {
            set_origin_layout();
        }

        void set_origin_layout()
        {
            String[,] console = new String[5, 7] {  {"CASH", "현금결제", "0", "0", "3", "4", "Y" },
                                                    {"CARD", "카드결제", "3", "0", "3","4", "Y" },
                                                    {"POINT", "포인트결제", "6", "0", "2","4", "Y" },
                                                    { "COMPLEX", "복합결제", "8", "0", "2","2", "Y" },
                                                    { "EASY", "간편결제", "8", "2", "2","2", "Y" } };

            lvwButton.Items.Clear();

            for (int i = 0; i < 5; i++)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Tag = console[i, 0];
                lvItem.Text = console[i, 1];
                lvItem.SubItems.Add(console[i, 2]);
                lvItem.SubItems.Add(console[i, 3]);
                lvItem.SubItems.Add(console[i, 4]);
                lvItem.SubItems.Add(console[i, 5]);
                lvItem.SubItems.Add(console[i, 6]);
                lvwButton.Items.Add(lvItem);
            }




            System.Windows.Forms.Button btnPayItem;

            tableLayoutPanelPayControl.Controls.Clear();

            this.tableLayoutPanelPayControl.VerticalScroll.Value = 0;
            tableLayoutPanelPayControl.PerformLayout();

            for (int i = 0; i < 5; i++)
            {

                btnPayItem = new Button();
                btnPayItem.Tag = console[i, 0];
                btnPayItem.FlatStyle = FlatStyle.Flat;
                btnPayItem.TabStop = false;
                btnPayItem.Margin = new Padding(2, 2, 2, 2);
                btnPayItem.Padding = new Padding(0, 0, 0, 0);
                btnPayItem.Dock = DockStyle.Fill;
                btnPayItem.ForeColor = Color.White;
                btnPayItem.BackColor = Color.FromArgb(68, 87, 96);

                btnPayItem.Font = font12;
                btnPayItem.Text = console[i, 1];


                tableLayoutPanelPayControl.Controls.Add(btnPayItem, convert_number(console[i, 2]), convert_number(console[i, 3]));
                tableLayoutPanelPayControl.SetColumnSpan(btnPayItem, convert_number(console[i, 4]));
                tableLayoutPanelPayControl.SetRowSpan(btnPayItem, convert_number(console[i, 5]));



            }

        }
    }
}
