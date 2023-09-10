using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;




//? 포스별 설정 항목

/*


 * 
 * 컴포트 : 영수증프린터, 라벨프린터 
 * 클라이언트유형? : PC, 포스, 키오스크 -> 마우스포인터 표시여부
 * 





*/


namespace thepos
{
    public partial class frmSetupPos : Form
    {
        struct Setup
        {
            public String code;
            public String name;
            public String value;
            public String memo;
        }
        Setup[] listSetup = new Setup[5];


        bool isAdd = false;


        public frmSetupPos()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();


            Setup setupItem = new Setup();


            setupItem.code = "BillPrinterPort";     setupItem.name = "영수증프린터포트";    setupItem.value = "";   setupItem.memo = "";    listSetup[0] = setupItem;
            setupItem.code = "TicketPrinterPort";   setupItem.name = "티켓바코드프린터포트";setupItem.value = "";   setupItem.memo = "";    listSetup[1] = setupItem;
            setupItem.code = "ScannerPort";         setupItem.name = "스캐너포트";          setupItem.value = "";   setupItem.memo = "";    listSetup[2] = setupItem;
            setupItem.code = "PosType";             setupItem.name = "기기유형";            setupItem.value = "";   setupItem.memo = "";    listSetup[3] = setupItem;
            setupItem.code = "CustomerMonitor";     setupItem.name = "고객용모니터사용";    setupItem.value = "";   setupItem.memo = "";    listSetup[4] = setupItem;


            reload_setup_pos();
        }


        private void initialize_font()
        {
            lvwList.Font = font12;

            lblSiteNameTitle.Font = font12;
            lblPosNoTitle.Font = font12;

            lblSiteName.Font = font12;
            lblPosNo.Font = font12;

            lblNameTitle.Font = font12;
            lblName.Font = font12;

            lblValueTitle.Font = font12;
            lblValue.Font = font12;

            lblValueTitle2.Font = font12;
            cbValue.Font = font12;

            btnAdd.Font = font12;

            btnLoad.Font = font12;
            btnSave.Font = font12;

        }

        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 32);

            lvwList.SmallImageList = imgList;
            lvwList.HideSelection = true;

            lblSiteName.Text = mSiteAlias;
            lblPosNo.Text = mPosNo;

        }


        private void reload_setup_pos()
        {

            String sUrl = "setupPos?siteId=" + mSiteId + "&posNo=" + mPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["setupPos"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        for (int j = 0; j < listSetup.Length; j++)
                        {
                            if (listSetup[j].code == arr[i]["setupCode"].ToString())
                            {
                                listSetup[j].value = arr[i]["setupValue"].ToString();
                            }
                        }

                    }
                }
            }


            lvwList.Items.Clear();
            for (int i = 0; i < listSetup.Length; i++)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = listSetup[i].name;
                lvItem.SubItems.Add(listSetup[i].value);
                lvItem.SubItems.Add(listSetup[i].memo);
                lvItem.Tag = listSetup[i].code;
                lvwList.Items.Add(lvItem);
            }

        }



        private void lvwOrderItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) return;


            String code = lvwList.SelectedItems[0].Tag.ToString();

            lblName.Text = lvwList.SelectedItems[0].Text;
            lblValue.Text = lvwList.SelectedItems[0].SubItems[1].Text.ToString();


            
            if (code == listSetup[0].code | code == listSetup[1].code | code == listSetup[2].code) // BillPrinterPort TicketPrinterPort ScannerPort
            {
                cbValue.Enabled = true;

                cbValue.Items.Clear ();
                cbValue.Items.Add("");
                foreach (string s in SerialPort.GetPortNames())
                {
                    cbValue.Items.Add(s);
                }
            }
            else if (code == listSetup[3].code)  // PosType
            {
                cbValue.Enabled = true;

                cbValue.Items.Clear();
                cbValue.Items.Add("");
                cbValue.Items.Add("POS");
                cbValue.Items.Add("PC");
                cbValue.Items.Add("KIOSK");
            }
            else if (code == listSetup[4].code)  // CustomerMonitor
            {
                cbValue.Enabled = true;

                cbValue.Items.Clear();
                cbValue.Items.Add("");
                cbValue.Items.Add("Y");
                cbValue.Items.Add("N");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lvwList.SelectedItems[0].SubItems[2].Text = cbValue.Text;

            isAdd = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isAdd == false) return;

            //
            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                if (lvwList.Items[i].SubItems[2].Text != "")
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters["siteId"] = mSiteId;
                    parameters["posNo"] = mPosNo;
                    parameters["setupCode"] = lvwList.Items[i].Tag.ToString();
                    parameters["setupName"] = lvwList.Items[i].Text;
                    parameters["setupValue"] = lvwList.Items[i].SubItems[2].Text;
                    parameters["memo"] = "";

                    if (mRequestPost("setupPos", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                            
                        }
                        else
                        {
                            MessageBox.Show("포스정보 오류. setupPos\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류. setupPos\n\n" + mErrorMsg, "thepos");
                        return;
                    }
                }
            }

            //
            MessageBox.Show("포스정보 저장완료.", "thepos");
            isAdd = false;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            reload_setup_pos();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
