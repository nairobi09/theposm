using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thepos._9SysAdmin
{
    public partial class frmSysAdminUser : Form
    {
        public frmSysAdminUser()
        {
            InitializeComponent();
            initial_the();
        }

        private void initial_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwList.SmallImageList = imgList;



            //? 서버에서 가져오기
            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = "접수";
            lvItem.SubItems.Add("01");
            lvItem.SubItems.Add("김토스");
            lvItem.SubItems.Add("일반");
            lvItem.SubItems.Add("");
            lvwList.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "등록";
            lvItem.SubItems.Add("02");
            lvItem.SubItems.Add("나이스");
            lvItem.SubItems.Add("일반");
            lvItem.SubItems.Add("2023-07-11");
            lvwList.Items.Add(lvItem);


        }
    }
}