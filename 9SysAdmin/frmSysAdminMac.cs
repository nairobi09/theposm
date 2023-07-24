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
    public partial class frmSysAdminMac : Form
    {
        public frmSysAdminMac()
        {
            InitializeComponent();

            initial_the();
        }

        private void initial_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwList.SmallImageList = imgList;



            // my max address..
            string macAddress = NetworkInterface.GetAllNetworkInterfaces()
                                  .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                                  .Select(nic => nic.GetPhysicalAddress().ToString()).FirstOrDefault();

            lblMacValue.Text = macAddress;


            //? 서버에서 가져오기
            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = "01";
            lvItem.SubItems.Add("023006617873");
            lvwList.Items.Add(lvItem);

            lvItem = new ListViewItem();
            lvItem.Text = "02";
            lvItem.SubItems.Add("");
            lvwList.Items.Add(lvItem);




        }
    }
}
