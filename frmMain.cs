using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Data.SQLite;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;
using System.Net.Sockets;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace thepos
{
    public partial class frmMain : Form
    {
        public static Panel mPanelDivision;
        TextBox mTbKeyDisplayController;  // 공용컨트롤러

        String in_patern = "";

        public frmMain()
        {
            Screen[] scr = Screen.AllScreens;
            this.Location = scr[0].Bounds.Location;

            InitializeComponent();

            initialize_font();

            initialize_the();

        }


        private void initialize_font()
        {
            //fontCollection.AddFontFile("Font\\Pretendard-Regular.ttf");
            fontCollection.AddFontFile("Font\\Pretendard-Medium.ttf");
            //fontCollection.AddFontFile("Font\\TossProductSansTTF-Medium.ttf");


            font5 = new Font(fontCollection.Families[0], 5f);
            font8 = new Font(fontCollection.Families[0], 8f);
            font9 = new Font(fontCollection.Families[0], 9f);
            font10 = new Font(fontCollection.Families[0], 10f);
            font10bold = new Font(fontCollection.Families[0], 10f, FontStyle.Bold);
            font12 = new Font(fontCollection.Families[0], 12f);
            font12bold = new Font(fontCollection.Families[0], 12f, FontStyle.Bold);
            font13 = new Font(fontCollection.Families[0], 12f);
            font14 = new Font(fontCollection.Families[0], 14f);
            font16 = new Font(fontCollection.Families[0], 16f);
            font20 = new Font(fontCollection.Families[0], 20f);
            font24 = new Font(fontCollection.Families[0], 24f);


            btnClose.Font = font12;


            lblSiteAlias.Font = font16;
            lblSiteName.Font = font10;

            lblPosNoTitle.Font = font10;
            lblPosNo.Font = font10;

            lblUserNameTitle.Font = font10;
            lblUserName.Font = font9;



            btnSales.Font = font14;
            btnBusiness.Font = font14;
            btnReports.Font = font14;
            btnSetup.Font = font12;
            btnSupport.Font = font12;
            btnExit.Font = font12;

            lblCallCenterNo.Font = font10;

            // 로그인

            lblID.Font = font10;
            lblPW.Font = font10;

            tbID.Font = font14;
            tbPW.Font = font14;

            btnKey1.Font = font14;
            btnKey2.Font = font14;
            btnKey3.Font = font14;
            btnKey4.Font = font14;
            btnKey5.Font = font14;
            btnKey6.Font = font14;
            btnKey7.Font = font14;
            btnKey8.Font = font14;
            btnKey9.Font = font14;
            btnKey0.Font = font14;
            btnKeyBS.Font = font14;
            btnKeyClear.Font = font14;
            btnKeyLogin.Font = font12;

            lblLocalMode.Font = font10;
            lblReqUser.Font = font10;

        }

        private void initialize_the()
        {

            //? Cursor.Hide();

            mPanelDivision = panelDivision;

            mPanelDivision.Width = 1024;
            mPanelDivision.Height = 768;
            mPanelDivision.Visible = false;


            clear_login_init();


            lblSiteAlias.Text = mSiteAlias;
            lblSiteName.Text = mSiteName;
            lblPosNo.Text = mPosNo;
            lblUserName.Text = mUserName;


            btnKey1.Click += (sender, args) => ClickedKey("1");
            btnKey2.Click += (sender, args) => ClickedKey("2");
            btnKey3.Click += (sender, args) => ClickedKey("3");
            btnKey4.Click += (sender, args) => ClickedKey("4");
            btnKey5.Click += (sender, args) => ClickedKey("5");
            btnKey6.Click += (sender, args) => ClickedKey("6");
            btnKey7.Click += (sender, args) => ClickedKey("7");
            btnKey8.Click += (sender, args) => ClickedKey("8");
            btnKey9.Click += (sender, args) => ClickedKey("9");
            btnKey0.Click += (sender, args) => ClickedKey("0");
            btnKeyBS.Click += (sender, args) => ClickedKey("BS");
            btnKeyClear.Click += (sender, args) => ClickedKey("Clear");


            tbID.Text = get_registry_id();
            tbID.Tag = tbID.Text;



            if (tbID.Text.Length == 4)
            {
                mTbKeyDisplayController = tbPW;
            }
            else
            {
                mTbKeyDisplayController = tbID;
            }

            // 기동시 MAC값 구하기 및 보관
            mMacAddr = NetworkInterface.GetAllNetworkInterfaces()
                      .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                      .Select(nic => nic.GetPhysicalAddress().ToString()).FirstOrDefault();



            // Session key 로그인관련 
            handler.CookieContainer = cookies;

            mHttpClient = new HttpClient(handler);


            // local DB
            String cs = "";
#if DEBUG
            var enviroment = System.Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(enviroment).Parent.FullName;
            cs = @"URI=file:" + projectDirectory + "\\local_thepos.db";

#else
            cs = @"URI=file:" + System.Windows.Forms.Application.StartupPath + "\\local_thepos.db";
#endif


            mConn = new SQLiteConnection(cs);
            mConn.Open();



        }


        private void start_sub_screen()
        {
            Screen[] scr = Screen.AllScreens;

            if (scr.Length > 1)
            {
                fSub = new frmSub();
                fSub.Location = scr[1].Bounds.Location; // 두번째 스크린에 뛰움
                fSub.Show();
            }

        }


        private void clear_login_init()
        {
            mSiteAlias = "";
            mSiteName = "";
            mPosNo = "";
            mUserName = "";

            mSiteId = "";
            mSiteName = "";         // 매장명
            mSiteAlias = "";        // 매장명
            mCapName = "";          // 대표자명
            mRegistNo = "";         // 사업자번호
            mBizAddr = "";          // 주소
            mBizTelNo = "";         // 대표전화

            mTicketType = "";  // ""미사용, "PA"선불, "PD"후불
            mTicketMedia = "";  // 띠지BC   팔찌RF
            mVanCode = "";
            mCallCenterNo = "";



            mCornerType = "";  // 주문서 관리 - ""미사용, "E"단순일체형, "P"분리형

            mPosNo = "";
            mBizDate = "";


            // 이사업자의 포스번호 목록
            //mPosNoList.Initialize();
            //mCornerCode.Initialize(); // 코너 코드
            //mCornerName.Initialize(); // 코너 명





            mUserID = "";
            mUserName = "";

            tbPW.Text = "";

            lblSiteAlias.Text = "";
            lblSiteName.Text = "";
            lblPosNo.Text = "";
            lblUserName.Text = "";


        }


        private void ClickedKey(string sKey)
        {
            if (sKey == "BS")
            {
                if (mTbKeyDisplayController.Text.Length > 0)
                {
                    mTbKeyDisplayController.Text = mTbKeyDisplayController.Text.Substring(0, mTbKeyDisplayController.Text.Length - 1);
                }
            }
            else if (sKey == "Clear")
            {
                mTbKeyDisplayController.Text = "";
            }
            else
            {
                mTbKeyDisplayController.Text += sKey;
            }
        }


        private void btnKeyLogin_Click(object sender, EventArgs e)
        {

            // 로그인
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["userId"] = tbID.Text;
            parameters["userPw"] = SHA1HashCrypt(tbPW.Text);
            parameters["macAddr"] = mMacAddr;

            if (mRequestPost("login", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    mSiteId = mObj["siteId"].ToString();
                    mUserID = tbID.Text;
                    mUserName = mObj["userName"].ToString();
                    mPosNo = mObj["posNo"].ToString();
                }
                else
                {
                    MessageBox.Show("로그인오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }




            // 다운로드 : 서버버전 로컬버전 비교하여 필요하면 다운...
            if (is_need_download_server_db())
            {
                
            }

            //? 임시
            download_server_basic_db();


            // 로컬DB에서 메모리도 로드
            load_local_basic_db();




            //////////////////////////////
            //? 로그인 성공
            panelLogin.Visible = false;

            lblSiteAlias.Text = mSiteAlias;
            lblSiteName.Text = mSiteName;
            lblPosNo.Text = mPosNo;
            lblUserName.Text = mUserName;

            lblCallCenterNo.Text = mCallCenterNo;

            save_registry_info();



            //////////////////////////////////
            //? 개시마감 
            String biz_date = "";
            String biz_status = "";
            mBizDate = "";

            if (get_bizdate_status(ref biz_status, ref biz_date))
            {
                if (biz_status == "A")   // A영업중 F영업마감
                {
                    mBizDate = biz_date;
                }
                else if (biz_status == "F")  // 마감
                {
                    //? 개시화면으로 이동?

                    return;
                }
            }
            else
            {
                MessageBox.Show("개시마감관리 오류\n서버에서 정보를 읽어오지 못했습니다.", "thepos");
                return;
            }



            // sub screen
            if (mCustomerMonitor == "Y")
            {
                start_sub_screen();
            }



            //? 데이터 체크 임시
            //Form f = new frmCheckData();
            //f.Show();

        }





        private bool is_need_download_server_db()
        {
            String local_version = "";
            String server_version = "";



            SQLiteDataReader dr = sql_select_local_db("SELECT * FROM site");
            while (dr.Read())
            {
                local_version = dr["basicDbVer"].ToString();
            }
            dr.Close();



            if (local_version == "") local_version = "0";



            String sUrl = "site?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["sites"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count == 1)
                    {
                        server_version = arr[0]["basicDbVer"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("사이트정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("사이트정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return false;
            }


            if (long.Parse(local_version) < long.Parse(server_version))
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        private void download_server_basic_db()
        {
            String sUrl = "goodsGroup?siteId=" + mSiteId + "&posNo=" + mPosNo;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    // Delete
                    sql_excute_local_db("DELETE FROM goodsGroup");

                    //
                    String data = mObj["goodsGroups"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        String siteId = arr[i]["siteId"].ToString();
                        String posNo = arr[i]["posNo"].ToString();
                        String groupCode = arr[i]["groupCode"].ToString();
                        String groupName = arr[i]["groupName"].ToString();
                        int locateX = int.Parse(arr[i]["locateX"].ToString());
                        int locateY = int.Parse(arr[i]["locateY"].ToString());
                        int sizeX = int.Parse(arr[i]["sizeX"].ToString());
                        int sizeY = int.Parse(arr[i]["sizeY"].ToString());

                        // Insert
                        String sql = "INSERT INTO goodsGroup (siteId, posNo, groupCode, groupName, locateX, locateY, sizeX, sizeY) " +
                        "values ('" + siteId + "','" + posNo + "','" + groupCode + "','" + groupName + "'," + locateX + "," + locateY + "," + sizeX + "," + sizeY + ")";
                        sql_excute_local_db(sql);
                    }
                }
                else
                {
                    MessageBox.Show("상품그룹정보 오류. goodsGroup\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. goodsGroup\n\n" + mErrorMsg, "thepos");
                return;
            }

            
            //
            sUrl = "goodsItemAndGoods?siteId=" + mSiteId + "&posNo=" + mPosNo;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    // Delete
                    sql_excute_local_db("DELETE FROM goodsItemAndGoods");

                    //
                    String data = mObj["goodsItems"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        String siteId = arr[i]["siteId"].ToString();
                        String posNo = arr[i]["posNo"].ToString();
                        String groupCode = arr[i]["groupCode"].ToString();
                        String itemCode = arr[i]["itemCode"].ToString();
                        String itemName = arr[i]["itemName"].ToString();
                        String shopCode = arr[i]["shopCode"].ToString();
                        int amt = int.Parse(arr[i]["amt"].ToString());
                        String ticketYn = arr[i]["ticketYn"].ToString();
                        String taxFree = arr[i]["taxFree"].ToString();
                        String soldout = arr[i]["soldout"].ToString();
                        int locateX = int.Parse(arr[i]["locateX"].ToString());
                        int locateY = int.Parse(arr[i]["locateY"].ToString());
                        int sizeX = int.Parse(arr[i]["sizeX"].ToString());
                        int sizeY = int.Parse(arr[i]["sizeY"].ToString());

                        String sql = "INSERT INTO goodsItemAndGoods (siteId, posNo, groupCode, itemCode, itemName, shopCode, amt, ticketYn, taxFree, soldout, locateX, locateY, sizeX, sizeY) " +
                            "values ('" + siteId + "','" + posNo + "','" + groupCode + "','" + itemCode + "','" + itemName + "','" + shopCode + "'," + amt + ",'" + ticketYn + "','" + taxFree + "','" + soldout + "'," + locateX + "," + locateY + "," + sizeX + "," + sizeY + ")";
                        sql_excute_local_db(sql);
                    }
                }
                else
                {
                    MessageBox.Show("상품정보 오류. goodsItemAndGoods\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. goodsItemAndGoods\n\n" + mErrorMsg, "thepos");
                return;
            }









            // site -- 는 제일 마지막에.. 버전때문.
            sUrl = "site?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["sites"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count == 1)
                    {
                        String siteId = arr[0]["siteId"].ToString();
                        String siteName = arr[0]["siteName"].ToString();
                        String siteAlias = arr[0]["siteAlias"].ToString();
                        String registNo = arr[0]["registNo"].ToString();
                        String capName = arr[0]["capName"].ToString();
                        String bizAddr = arr[0]["bizAddr"].ToString();
                        String bizTelNo = arr[0]["bizTelNo"].ToString();
                        String ticketType = arr[0]["ticketType"].ToString();
                        String ticketMedia = arr[0]["ticketMedia"].ToString();
                        String vanCode = arr[0]["vanCode"].ToString();
                        String callCenterNo = arr[0]["callCenterNo"].ToString();
                        String basicDbVer = arr[0]["basicDbVer"].ToString();

                        // Delete
                        sql_excute_local_db("DELETE FROM site");

                        // Insert
                        String sql = "INSERT INTO site (siteId, siteName, siteAlias, registNo, capName, bizAddr, bizTelNo, ticketType, ticketMedia, vanCode, callCenterNo, basicDbVer) " +
                                     "values ('" + siteId + "','" + siteName + "','" + siteAlias + "','" + registNo + "','" + capName + "','" + bizAddr + "','" + bizTelNo + "','" + ticketType + "','" + ticketMedia + "','" + vanCode + "','" + callCenterNo + "','" + basicDbVer + "')";
                        sql_excute_local_db(sql);
                    }
                }
                else
                {
                    MessageBox.Show("사이트정보 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류. site\n\n" + mErrorMsg, "thepos");
                return;
            }

        }



        private void load_local_basic_db()
        {

            SQLiteDataReader dr = sql_select_local_db("SELECT * FROM site");
            while (dr.Read())
            {
                mSiteName = dr["siteName"].ToString();
                mSiteAlias = dr["siteAlias"].ToString();
                mRegistNo = dr["registNo"].ToString();
                mCapName = dr["capName"].ToString();
                mBizAddr = dr["bizAddr"].ToString();
                mBizTelNo = dr["bizTelNo"].ToString();
                mTicketType = dr["ticketType"].ToString();
                mTicketMedia = dr["ticketMedia"].ToString();
                mVanCode = dr["vanCode"].ToString();
                mCallCenterNo = dr["callCenterNo"].ToString();
            }
            dr.Close();


            //
            if (true)
            {
                int rowcnt = 0;
                dr = sql_select_local_db("SELECT count(*) as cnt FROM goodsGroup");
                if (dr.Read())
                {
                    rowcnt = int.Parse(dr["cnt"].ToString());
                }
                dr.Close();


                mGoodsGroup = new GoodsGroup[rowcnt];

                dr = sql_select_local_db("SELECT * FROM goodsGroup");
                int i = 0;
                while (dr.Read())
                {
                    mGoodsGroup[i].group_code = dr["groupCode"].ToString();
                    mGoodsGroup[i].group_name = dr["groupName"].ToString();
                    mGoodsGroup[i].column = int.Parse(dr["locateX"].ToString());
                    mGoodsGroup[i].row = int.Parse(dr["locateY"].ToString());
                    mGoodsGroup[i].columnspan = int.Parse(dr["sizeX"].ToString());
                    mGoodsGroup[i].rowspan = int.Parse(dr["sizeY"].ToString());
                    i++;
                }
                dr.Close();
            }


            //
            if (true)
            {
                int rowcnt = 0;
                dr = sql_select_local_db("SELECT count(*) as cnt FROM goodsItemAndGoods");
                if (dr.Read())
                {
                    rowcnt = int.Parse(dr["cnt"].ToString());
                }
                dr.Close();

                mGoodsItem = new GoodsItem[rowcnt];


                dr = sql_select_local_db("SELECT * FROM goodsItemAndGoods");

                int i = 0;
                while (dr.Read())
                {
                    mGoodsItem[i].group_code = dr["groupCode"].ToString();
                    mGoodsItem[i].item_code = dr["itemCode"].ToString();
                    mGoodsItem[i].item_name = dr["itemName"].ToString();
                    mGoodsItem[i].shop_code = dr["shopCode"].ToString();
                    mGoodsItem[i].amt = int.Parse(dr["amt"].ToString());
                    mGoodsItem[i].ticket = dr["ticketYn"].ToString();
                    mGoodsItem[i].taxfree = dr["taxFree"].ToString();
                    mGoodsItem[i].soldout = dr["soldout"].ToString();
                    mGoodsItem[i].column = int.Parse(dr["locateX"].ToString());
                    mGoodsItem[i].row = int.Parse(dr["locateY"].ToString());
                    mGoodsItem[i].columnspan = int.Parse(dr["sizeX"].ToString());
                    mGoodsItem[i].rowspan = int.Parse(dr["sizeY"].ToString());

                    // 면세상픔은 상품명앞에 *을 붙인다.
                    if (mGoodsItem[i].taxfree == "1")
                    {
                        mGoodsItem[i].item_name = "*" + mGoodsItem[i].item_name;
                    }

                    i++;
                }
                dr.Close();
            }










            // setup pos
            String sUrl = "setupPos?siteId=" + mSiteId + "&posNo=" + mPosNo;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["setupPos"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        if (arr[i]["setupCode"].ToString() == "BillPrinterPort") mBillPrinterPort = arr[i]["setupValue"].ToString();
                        else if (arr[i]["setupCode"].ToString() == "TicketPrinterPort") mTicketPrinterPort = arr[i]["setupValue"].ToString();
                        else if (arr[i]["setupCode"].ToString() == "ScannerPort") mScannerPort = arr[i]["setupValue"].ToString();
                        else if (arr[i]["setupCode"].ToString() == "PosType") mPosType = arr[i]["setupValue"].ToString();
                        else if (arr[i]["setupCode"].ToString() == "CustomerMonitor") mCustomerMonitor = arr[i]["setupValue"].ToString();
                    }
                }
            }

            // 포스
            sUrl = "pos?siteId=" + mSiteId + "&posStatus=Y";
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["pos"].ToString();
                    JArray arr = JArray.Parse(data);

                    mPosNoList = new String[arr.Count];

                    for (int i = 0; i < arr.Count; i++)
                    {
                        mPosNoList[i] = arr[i]["posNo"].ToString();

                    }
                }
                else
                {
                    MessageBox.Show("포스정보 오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }



            // 샵
            sUrl = "shop?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["shops"].ToString();
                    JArray arr = JArray.Parse(data);

                    mShop = new Shop[arr.Count];

                    for (int i = 0; i < arr.Count; i++)
                    {
                        mShop[i].shop_code = arr[i]["shopCode"].ToString();
                        mShop[i].shop_name = arr[i]["shopName"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("샵정보 오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }


        }







        // 판매관리
        private void btnSales_Click(object sender, EventArgs e)
        {
            //? 영업상태
            // 영업중상태: 개시후 마감전
            // 영업마감상태 : 마감이후 개시전


            // 1. 영업상태 구함

            String biz_Status = "";
            String biz_date = "";

            if (get_bizdate_status(ref biz_Status, ref biz_date))
            {
                if (biz_Status == "A")   // A영업중 F영업마감
                {
                    // 영업중이면 그대로 판매관리로 진행
                    mBizDate = biz_date;

                    panelDivision.Visible = true;
                    panelDivision.Controls.Clear();

                    frmSales fForm = new frmSales() { TopLevel = false, TopMost = true };
                    panelDivision.Controls.Add(fForm);
                    fForm.Show();


                }
                else if (biz_Status == "F")  // 마감
                {
                    MessageBox.Show("영업개시전입니다. 영업개시 입력바랍니다.", "thepos");
                    return;
                }
            }
            else
            {
                // 서버루틴에서 에러메시지 기표시...
                return;
            }
        }


        // 영업관리
        private void btnBusiness_Click(object sender, EventArgs e)
        {
            panelDivision.Visible = true;
            panelDivision.Controls.Clear();

            frmBusiness fForm = new frmBusiness() { TopLevel = false, TopMost = true };
            panelDivision.Controls.Add(fForm);
            fForm.Show();

        }

        // 매출관리
        private void btnReports_Click(object sender, EventArgs e)
        {
            panelDivision.Visible = true;
            panelDivision.Controls.Clear();

            frmReports fForm = new frmReports() { TopLevel = false, TopMost = true };
            panelDivision.Controls.Add(fForm);
            fForm.Show();

        }

        // 환경설정
        private void btnSetup_Click(object sender, EventArgs e)
        {
            panelDivision.Visible = true;
            panelDivision.Controls.Clear();

            frmSetupPos fForm = new frmSetupPos() { TopLevel = false, TopMost = true };
            panelDivision.Controls.Add(fForm);
            fForm.Show();

        }




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {


            frmExit fExit = new frmExit();
            DialogResult ret =  fExit.ShowDialog();

            if (ret == DialogResult.Yes)  // 로그아웃
            {
                //? 로그아웃 프로세스 필요




                 
                clear_login_init();  // 초기화

                panelLogin.Visible = true;


            }
            else if (ret == DialogResult.Retry)
            {
                //?





            }
            else if (ret == DialogResult.OK)  // 종료
            {
                this.Close();
            }

                
        }

        private void tbID_Click(object sender, EventArgs e)
        {
            mTbKeyDisplayController = tbID;
        }

        private void tbPW_Click(object sender, EventArgs e)
        {
            mTbKeyDisplayController = tbPW;
        }


        private String get_registry_id()
        {

            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("thepos");

            return reg.GetValue("ID", "").ToString();
        }



        private void save_registry_info()
        {

            String dID = tbID.Text;
            String tID = (tbID.Tag + "").ToString();

            if ( dID == tID)
            {
                return;
            }


            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("thepos");


            reg.SetValue("ID", dID);

        }

        private void lblReqUser_Click(object sender, EventArgs e)
        {
            frmReqUser fReqUser = new frmReqUser();
            fReqUser.ShowDialog();
        }

        private void picLogo_Click(object sender, EventArgs e)
        {

            frmSysAdmin frmSysAdmin = new frmSysAdmin(in_patern);
            frmSysAdmin.ShowDialog();

            in_patern = "";
        }

        private void lblSiteAlias_Click(object sender, EventArgs e)
        {
            in_patern = "";
        }

        private void lblPosNoTitle_Click(object sender, EventArgs e)
        {
            in_patern += "1";
        }

        private void lblUserNameTitle_Click(object sender, EventArgs e)
        {
            in_patern += "2";
        }

        private void lblLocalMode_Click(object sender, EventArgs e)
        {
            frmLocalModeInfo frm = new frmLocalModeInfo();
            frm.ShowDialog();

            if (mLocalMode == true)
            {
                set_local_mode();

            }

        }


        void set_local_mode()
        {
            //?
            // 사이트 정보
            // 기초원장
            // 





        }

    }
}
