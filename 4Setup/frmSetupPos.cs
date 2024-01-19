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
using static thepos.frmMain;
using System.Data.SQLite;



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
        Setup[] listSetup = new Setup[6];


        bool isAdd = false;


        public frmSetupPos()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();

            Setup setupItem = new Setup();

            setupItem.code = "PosType";               setupItem.name = "기기유형";          setupItem.value = "";   setupItem.memo = "";    listSetup[0] = setupItem;
            setupItem.code = "CustomerMonitor";       setupItem.name = "고객용모니터사용";  setupItem.value = "";   setupItem.memo = "";    listSetup[1] = setupItem;
            setupItem.code = "BillPrinterPort";       setupItem.name = "영수증프린터포트";  setupItem.value = "";   setupItem.memo = "";    listSetup[2] = setupItem;
            setupItem.code = "OrderPrinterPort";      setupItem.name = "주문서프린터포트";  setupItem.value = "";   setupItem.memo = "";    listSetup[3] = setupItem;
            setupItem.code = "TicketPrinterPort";     setupItem.name = "티켓프린터포트";    setupItem.value = "";   setupItem.memo = "";    listSetup[4] = setupItem;
            setupItem.code = "VanTID";                setupItem.name = "결제밴 T-ID";       setupItem.value = "";   setupItem.memo = "미입력시 밴결제모듈내 입력된 T-ID로 설정됩니다.\r\nKovan의 경우 필수입력항목입니다.";    listSetup[5] = setupItem;


            reload_setup_pos();
        }


        private void initialize_font()
        {
            lblTitle.Font = font10;
            lvwList.Font = font10;

            lblSiteNameTitle.Font = font10;
            lblPosNoTitle.Font = font10;

            lblSiteName.Font = font10;
            lblPosNo.Font = font10;

            lblNameTitle.Font = font10;
            lblName.Font = font10;

            lblValueTitle.Font = font10;
            lblValue.Font = font10;

            lblValueTitle2.Font = font10;
            cbValue.Font = font10;
            tbValue.Font = font10;
            lblMemo.Font = font10;

            btnAdd.Font = font10;

            btnLoad.Font = font10;
            btnSave.Font = font10;

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

            if (mTheMode == "Local")
            {
                lblLocalMode.Visible = true;


                String sql = "SELECT * FROM setupPos";
                SQLiteDataReader dr = sql_select_local_db(sql);
                while (dr.Read())
                {
                    for (int j = 0; j < listSetup.Length; j++)
                    {
                        if (listSetup[j].code == dr["setupCode"].ToString())
                        {
                            listSetup[j].value = dr["setupValue"].ToString();
                        }
                    }
                }
                dr.Close();
            }
            else
            {
                lblLocalMode.Visible = false;


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
                    else
                    {
                        MessageBox.Show("설정정보 오류. setupPos\n\n " + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. setupPos\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }




            lvwList.Items.Clear();
            for (int i = 0; i < listSetup.Length; i++)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = listSetup[i].name;
                lvItem.SubItems.Add(listSetup[i].value);
                lvItem.SubItems.Add("");
                lvItem.SubItems.Add(listSetup[i].memo);
                lvItem.SubItems.Add("");
                lvItem.Tag = listSetup[i].code;
                lvwList.Items.Add(lvItem);
            }

        }



        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.SelectedItems.Count == 0) return;


            String code = lvwList.SelectedItems[0].Tag.ToString();

            lblName.Text = lvwList.SelectedItems[0].Text;
            lblValue.Text = lvwList.SelectedItems[0].SubItems[1].Text.ToString();
            lblMemo.Text = lvwList.SelectedItems[0].SubItems[3].Text.ToString();

            cbValue.Visible = false;
            tbValue.Visible = false;



            cbValue.SelectedIndex = -1;

            
            if (code == listSetup[0].code)  // PosType
            {
                cbValue.Visible = true;

                cbValue.Items.Clear();
                cbValue.Items.Add("");
                cbValue.Items.Add("POS");
                cbValue.Items.Add("POS-Ticket");
                cbValue.Items.Add("PC");
                cbValue.Items.Add("PC-Ticket");
                cbValue.Items.Add("KIOSK");
            }
            else if (code == listSetup[1].code)  // CustomerMonitor
            {
                cbValue.Visible = true;

                cbValue.Items.Clear();
                cbValue.Items.Add(" ");
                cbValue.Items.Add("Y");
                cbValue.Items.Add("N");
            }
            else if (code == listSetup[2].code | code == listSetup[3].code | code == listSetup[4].code) // BillPrinterPort TicketPrinterPort ScannerPort
            {
                cbValue.Visible = true;

                cbValue.Items.Clear ();
                cbValue.Items.Add(" ");
                foreach (string s in SerialPort.GetPortNames())
                {
                    cbValue.Items.Add(s);
                }
            }
            else if (code == listSetup[5].code)  // t-id
            {
                tbValue.Visible = true;

            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbValue.Visible)
            {
                lvwList.SelectedItems[0].SubItems[2].Text = cbValue.Text;
                lvwList.SelectedItems[0].SubItems[4].Text = "변경";
            }
            else
            {
                lvwList.SelectedItems[0].SubItems[2].Text = tbValue.Text;
                lvwList.SelectedItems[0].SubItems[4].Text = "변경";
            }
                
            isAdd = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isAdd == false) return;

            if (mTheMode == "Local")
            {
                DialogResult ret = MessageBox.Show("로컬사용모드. \r\n로컬DB에만 저장됩니다.", "thepos", MessageBoxButtons.OKCancel);

                if (ret == DialogResult.OK)
                {
                    int result = sql_excute_local_db("DELETE FROM setupPos");


                    for (int i = 0; i < lvwList.Items.Count; i++)
                    {
                        String t_value = "";

                        if (lvwList.Items[i].SubItems[4].Text == "변경")
                        {
                            t_value = lvwList.Items[i].SubItems[2].Text;
                        }
                        else
                        {
                            t_value = lvwList.Items[i].SubItems[1].Text;
                        }

                        
                        String sql = "INSERT INTO setupPos (siteId, posNo, setupCode, setupName, setupValue, memo) " +
                                "values ('" + mSiteId + "','" + mPosNo + "','" + lvwList.Items[i].Tag.ToString() + "','" + lvwList.Items[i].Text + "','" + t_value + "','')";
                        result = sql_excute_local_db(sql);


                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                //
                for (int i = 0; i < lvwList.Items.Count; i++)
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>();

                    parameters["siteId"] = mSiteId;
                    parameters["posNo"] = mPosNo;
                    parameters["setupCode"] = lvwList.Items[i].Tag.ToString();
                    parameters["setupName"] = lvwList.Items[i].Text;


                    if (lvwList.Items[i].SubItems[4].Text == "변경")
                    {
                        parameters["setupValue"] = lvwList.Items[i].SubItems[2].Text;
                    }
                    else
                    {
                        parameters["setupValue"] = lvwList.Items[i].SubItems[1].Text;
                    }
                        
                        
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

                //
                MessageBox.Show("포스정보 저장완료.", "thepos");

            }


            isAdd = false;


            reload_setup_pos();


            for (int i = 0; i < lvwList.Items.Count; i++)
            {
                if (lvwList.Items[i].Tag.ToString() == "PosType") mPosType = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "CustomerMonitor") mCustomerMonitor = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "BillPrinterPort") mBillPrinterPort = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "OrderPrinterPort") mOrderPrinterPort = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "TicketPrinterPort") mTicketPrinterPort = lvwList.Items[i].SubItems[1].Text;
                else if (lvwList.Items[i].Tag.ToString() == "VanTID") mVanTID = lvwList.Items[i].SubItems[1].Text;

            }


        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            reload_setup_pos();
        }

    }
}
