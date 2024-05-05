using Newtonsoft.Json.Linq;
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

namespace thepos._9SysAdmin
{
    public partial class frmSysShop : Form
    {

        String[] mPrinterTypeCode = new string[3];
        String[] mPrinterTypeName = new string[3];


        public frmSysShop()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();

            reload_server();
        }


        private void initialize_font()
        {
            lblTitle.Font = font10;
            lvwList.Font = font10;

            lblGoodsNameTitle.Font = font10;
            tbShopCode.Font = font10;

            lblGoodsAmtTitle.Font = font10;
            tbShopName.Font = font10;

            lblPrinterTypeTitle.Font = font10;
            cbPrinterType.Font = font10;
            lblNetworkPrinterName.Font = font10;
            tbNetworkPrinterName.Font = font10;


            btnAdd.Font = font10;
            btnUpdate.Font = font10;
            btnDelete.Font = font10;
        }

        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 24);

            lvwList.SmallImageList = imgList;
            lvwList.HideSelection = true;

            mPrinterTypeCode[0] = "";
            mPrinterTypeCode[1] = "N";
            mPrinterTypeCode[2] = "L";

            mPrinterTypeName[0] = "";
            mPrinterTypeName[1] = "네트워크프린터";
            mPrinterTypeName[2] = "영수증프린터";


            cbPrinterType.Items.Clear();
            for (int i = 0; i < mPrinterTypeCode.Length; i++) 
            {
                cbPrinterType.Items.Add(mPrinterTypeName[i]);
            }

            cbPrinterType.SelectedIndex = 0;

        }


        private void reload_server()
        {
            lvwList.Items.Clear();

            tbShopCode.Text = "";
            tbShopName.Text = "";
            cbPrinterType.SelectedIndex = 0;
            tbNetworkPrinterName.Text = "";


            String sUrl = "shop?siteId=" + mSiteId;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String pos = mObj["shops"].ToString();
                    JArray arr = JArray.Parse(pos);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["shopCode"].ToString();
                        lvItem.SubItems.Add(arr[i]["shopName"].ToString());
                        lvItem.SubItems.Add(arr[i]["printerType"].ToString());
                        lvItem.SubItems.Add(get_printer_type_name(arr[i]["printerType"].ToString()));
                        lvItem.SubItems.Add(arr[i]["networkPrinterName"].ToString());

                        lvwList.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("샵정보 오류. shop\n\n " + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. shop\n\n" + mErrorMsg, "thepos");
                return;
            }




        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (tbShopCode.Text.Trim().Length != 2)
            {
                MessageBox.Show("업장코드 오류.", "thepos");
                return;
            }

            if (tbShopName.Text.Trim().Length < 1)
            {
                MessageBox.Show("업장명 오류.", "thepos");
                return;
            }

            if (cbPrinterType.SelectedIndex < 0)
            {
                MessageBox.Show("주문서출력 오류.", "thepos");
                return;
            }


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = tbShopCode.Text.Trim();
            parameters["shopName"] = tbShopName.Text.Trim();
            parameters["printerType"] = mPrinterTypeCode[cbPrinterType.SelectedIndex];
            parameters["networkPrinterName"] = tbNetworkPrinterName.Text;


            if (mRequestPost("shop", parameters))  //? Add시 2개필들 누락되는것같음. 서버쪽 확인필요
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 등록 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("업장정보 오류. shop\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. shop\n\n" + mErrorMsg, "thepos");
                return;
            }

            //
            set_version_basic_db_change();


            reload_server();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            if (tbShopCode.Text.Trim().Length != 2)
            {
                MessageBox.Show("업장코드 오류.", "thepos");
                return;
            }

            if (tbShopName.Text.Trim().Length < 1)
            {
                MessageBox.Show("업장명 오류.", "thepos");
                return;
            }

            if (cbPrinterType.SelectedIndex < 0)
            {
                MessageBox.Show("주문서출력 오류.", "thepos");
                return;
            }


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = tbShopCode.Text.Trim();
            parameters["shopName"] = tbShopName.Text.Trim();
            parameters["printerType"] = mPrinterTypeCode[cbPrinterType.SelectedIndex];
            parameters["networkPrinterName"] = tbNetworkPrinterName.Text;

            if (mRequestPatch("shop", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 수정 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("오류. shop\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. shop\n\n" + mErrorMsg, "thepos");
                return;
            }

            //
            set_version_basic_db_change();


            reload_server();
        }

        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            tbShopCode.Text = lvwList.SelectedItems[0].Text;
            tbShopName.Text = lvwList.SelectedItems[0].SubItems[1].Text;


            String code = lvwList.SelectedItems[0].SubItems[2].Text;

            for (int i = 0; i < cbPrinterType.Items.Count; i++)
            {
                if (code == mPrinterTypeCode[i])
                {
                    cbPrinterType.SelectedIndex = i;
                }
            }

            tbNetworkPrinterName.Text = lvwList.SelectedItems[0].SubItems[4].Text;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) { return; }

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["siteId"] = mSiteId;
            parameters["shopCode"] = tbShopCode.Text.Trim();


            if (mRequestDelete("shop", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    //MessageBox.Show("정상 삭제 완료.", "thepos");
                }
                else
                {
                    MessageBox.Show("업장정보 오류. shop\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. shop\n\n" + mErrorMsg, "thepos");
                return;
            }

            reload_server();


        }

        String get_printer_type_name(String code)
        {
            for (int i = 0; i < mPrinterTypeCode.Length; i++)
            {
                if (mPrinterTypeCode[i] == code)
                {
                    return mPrinterTypeName[i];
                }
            }

            return code;
        }
    }
}
