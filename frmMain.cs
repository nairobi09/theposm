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
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Management;
using System.Collections;
using System.Drawing.Imaging;
using System.Threading;

namespace thepos
{
    public partial class frmMain : Form
    {
        public static Panel mPanelDivision;
        TextBox mTbKeyDisplayController;  // 공용컨트롤러

        String sysadmin_pw_patern = "";

        Thread threadSyncLink;




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
            //fontCollection.AddFontFile("Font\\Pretendard-Medium.ttf");
            //fontCollection.AddFontFile("Font\\TossProductSansTTF-Medium.ttf");
            fontCollection.AddFontFile("Font\\SpoqaHanSansNeo-Medium.ttf");


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

            lblLocalModeTitle.Font = font10;

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

            lblReqUser.Font = font10;

        }

        private void initialize_the()
        {

            mLblTheModeStatus = lblLocalModeTitle;


            mLblTheModeStatus.Visible = false;



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
            var nics = NetworkInterface.GetAllNetworkInterfaces();
            var selectedNic = nics.First();
            mMacAddr = selectedNic.GetPhysicalAddress().ToString();




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



            // Session key 로그인관련 
            handler.CookieContainer = cookies;
            mHttpClient = new HttpClient(handler);




        }

        private void frmMain_Shown(object sender, EventArgs e)
        {

            // 네트워크 상태 : 정상이미지를 보이기/숨기기
            pbNetworkConn.Visible = NetworkInterface.GetIsNetworkAvailable();


            // 서버 상태 : 최초 서버 테스트콜
            bool statusServer = check_server_status();
            if (statusServer == false)
            {
                change_mode_server_to_local();
            }
            else if (statusServer == true)
            {
                change_mode_local_to_server();
            }



            // SyncLink 쓰레드
            threadSyncLink = new Thread(SyncLink);
            threadSyncLink.Start();

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            threadSyncLink.Abort();
        }


        private void SyncLink()
        {
            // 3가지 기능
            // 1. 테스트콜 -> 모드 자동전환
            // 2. 서버원장 자동다운로드
            // 3. 로컬레코드 자동업로드

            while(true)
            {
                //
                Thread.Sleep(1000 * 10); // XX초


                // 네트워크 상태 : 정상이미지를 보이기/숨기기
                pbNetworkConn.BeginInvoke(new Action(() => pbNetworkConn.Visible = NetworkInterface.GetIsNetworkAvailable()));
                pbNetworkDisconn.BeginInvoke(new Action(() => pbNetworkDisconn.Visible = !pbNetworkDisconn.Visible));


                // 서버 상태 : 최초 서버 테스트콜
                bool statusServer = check_server_status();

                if (mTheMode == "Server" & statusServer == true)
                {
                    // Skip
                }
                else if (mTheMode == "Server" & statusServer == false)
                {
                    // Server -> Local
                    change_mode_server_to_local();
                }
                else if (mTheMode == "Local" & statusServer == true)
                {
                    // Local -> Server
                    change_mode_local_to_server();
                }
                else if (mTheMode == "Local" & statusServer == false)
                {
                    // Skip
                }


                //
                if (mTheMode == "Server")
                {

                    if (mSiteId == "")
                    {
                        //
                    }
                    else
                    {
                        // 1.서버원장 다운로드
                        String ver_server = get_version_server();
                        String ver_local = get_version_local();

                        if (ver_server == "" | ver_local == "")
                        {
                            // 에러
                        }
                        else
                        {
                            if (string.Compare(ver_server, ver_local) == 1)
                            {
                                sync_data_server_to_local();
                            }
                        }


                        // 2. 로컬레코드 업로드
                        int local_record_cnt = get_local_record_cnt();

                        if (local_record_cnt > 0)
                        {
                            int upload_cnt = upload_local_record();
                        }

                    }

                }
                else if (mTheMode == "Local")
                {
                    // 할일없음.
                }

            }

        }





        private void change_mode_server_to_local()
        {
            mTheMode = "Local";

            // "로컬모드"
            lblLocalModeTitle.BeginInvoke(new Action(() => lblLocalModeTitle.Visible = true));
            // 로컬모드 테마 적용
            btnBusiness.BeginInvoke(new Action(() => btnBusiness.Enabled = false));
            btnReports.BeginInvoke(new Action(() => btnReports.Enabled = false));
            btnSupport.BeginInvoke(new Action(() => btnSupport.Enabled = false));
        }

        private void change_mode_local_to_server()
        {
            mTheMode = "Server";

            // "로컬모드"
            lblLocalModeTitle.BeginInvoke(new Action(() => lblLocalModeTitle.Visible = false));
            // 로컬모드 테마 적용
            btnBusiness.BeginInvoke(new Action(() => btnBusiness.Enabled = true));
            btnReports.BeginInvoke(new Action(() => btnReports.Enabled = true));
            btnSupport.BeginInvoke(new Action(() => btnSupport.Enabled = true));
        }

        public static String get_version_server()
        {
            String sUrl = "site?siteId=" + mSiteId;
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["sites"].ToString();
                    JArray arr = JArray.Parse(data);

                    if (arr.Count > 0)
                    {
                        return arr[0]["basicDbVer"].ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }


        public static String get_version_local()
        {
            String sql = "SELECT * FROM site";
            SQLiteDataReader dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                return dr["basicDbVer"].ToString();
            }

            return "";

        }

        private int get_local_record_cnt()
        {
            int local_cnt = 0;

            //
            String sql = "SELECT count(*) as cnt FROM orders";
            SQLiteDataReader dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                local_cnt += convert_number(dr["cnt"].ToString());
            }
            dr.Close();

            sql = "SELECT count(*) as cnt FROM orders";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                local_cnt += convert_number(dr["cnt"].ToString());
            }
            dr.Close();

            sql = "SELECT count(*) as cnt FROM orderItem";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                local_cnt += convert_number(dr["cnt"].ToString());
            }
            dr.Close();

            sql = "SELECT count(*) as cnt FROM orderItem WHERE send_YN != 'Y' ";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                local_cnt += convert_number(dr["cnt"].ToString());
            }
            dr.Close();


            //
            sql = "SELECT count(*) as cnt FROM payment";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                local_cnt += convert_number(dr["cnt"].ToString());
            }
            dr.Close();

            sql = "SELECT count(*) as cnt FROM payment WHERE send_YN != 'Y' ";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                local_cnt += convert_number(dr["cnt"].ToString());
            }
            dr.Close();

            //
            sql = "SELECT count(*) as cnt FROM paymentCash";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                local_cnt += convert_number(dr["cnt"].ToString());
            }
            dr.Close();

            sql = "SELECT count(*) as cnt FROM paymentCash WHERE send_YN != 'Y' ";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                local_cnt += convert_number(dr["cnt"].ToString());
            }
            dr.Close();

            //
            sql = "SELECT count(*) as cnt FROM paymentCard";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                local_cnt += convert_number(dr["cnt"].ToString());
            }
            dr.Close();

            sql = "SELECT count(*) as cnt FROM paymentCard WHERE send_YN != 'Y' ";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                local_cnt += convert_number(dr["cnt"].ToString());
            }
            dr.Close();

            return local_cnt;

        }

        private int upload_local_record()
        {
            int upload_cnt = 0;
            int error_cnt = 0;

            // orders
            String sql = "SELECT * FROM orders";
            SQLiteDataReader dr = sql_select_local_db(sql);
            while (dr.Read())
            {
                String seq_key = dr["seq_key"].ToString();

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = dr["siteId"].ToString();
                parameters["posNo"] = dr["posNo"].ToString();
                parameters["bizDt"] = dr["bizDt"].ToString();
                parameters["theNo"] = dr["theNo"].ToString();
                parameters["refNo"] = dr["refNo"].ToString();

                parameters["orderDate"] = dr["orderDate"].ToString();
                parameters["orderTime"] = dr["orderTime"].ToString();
                parameters["tranType"] = dr["tranType"].ToString();
                parameters["cnt"] = dr["cnt"].ToString();
                parameters["isCancel"] = dr["isCancel"].ToString();

                if (mRequestPost("orders", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        sql = "DELETE FROM orders WHERE seq_key = " + seq_key + "";
                        int ret = sql_excute_local_db(sql);

                        upload_cnt++;
                    }
                    else
                    {
                        error_cnt++;
                    }
                }
                else
                {
                    error_cnt++;
                }

            }
            dr.Close();


            // orderItem
            sql = "SELECT * FROM orderItem";
            dr = sql_select_local_db(sql);
            while (dr.Read())
            {
                String seq_key = dr["seq_key"].ToString();

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = dr["siteId"].ToString();
                parameters["posNo"] = dr["posNo"].ToString();
                parameters["bizDt"] = dr["bizDt"].ToString();
                parameters["theNo"] = dr["theNo"].ToString();
                parameters["refNo"] = dr["refNo"].ToString();

                parameters["orderDate"] = dr["orderDate"].ToString();
                parameters["orderTime"] = dr["orderTime"].ToString();
                parameters["tranType"] = dr["tranType"].ToString();
                parameters["itemCode"] = dr["itemCode"].ToString();
                parameters["itemName"] = dr["itemName"].ToString();

                parameters["cnt"] = dr["cnt"].ToString();
                parameters["amt"] = dr["amt"].ToString();
                parameters["ticketYn"] = dr["ticketYn"].ToString();
                parameters["taxFree"] = dr["taxFree"].ToString();
                parameters["dcAmount"] = dr["dcAmount"].ToString();

                parameters["dcrType"] = dr["dcrType"].ToString();
                parameters["dcrDes"] = dr["dcrDes"].ToString();
                parameters["dcrValue"] = dr["dcrValue"].ToString();
                parameters["payClass"] = dr["payClass"].ToString();
                parameters["ticketNo"] = dr["ticketNo"].ToString();

                parameters["isCancel"] = dr["isCancel"].ToString();
                parameters["shopCode"] = dr["shopCode"].ToString();
                parameters["shopOrderNo"] = dr["shopOrderNo"].ToString();

                if (mRequestPost("orderItem", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        sql = "DELETE FROM orderItem WHERE seq_key = " + seq_key + "";
                        int ret = sql_excute_local_db(sql);

                        upload_cnt++;
                    }
                    else
                    {
                        error_cnt++;
                    }
                }
                else
                {
                    error_cnt++;
                }
            }
            dr.Close();


            // payment
            sql = "SELECT * FROM payment";
            dr = sql_select_local_db(sql);
            while (dr.Read())
            {
                String seq_key = dr["seq_key"].ToString();

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = dr["siteId"].ToString();
                parameters["posNo"] = dr["posNo"].ToString();
                parameters["bizDt"] = dr["bizDt"].ToString();
                parameters["theNo"] = dr["theNo"].ToString();
                parameters["refNo"] = dr["refNo"].ToString();

                parameters["payDate"] = dr["payDate"].ToString();
                parameters["payTime"] = dr["payTime"].ToString();
                parameters["tranType"] = dr["tranType"].ToString();
                parameters["payClass"] = dr["payClass"].ToString();
                parameters["billNo"] = dr["billNo"].ToString();

                parameters["netAmount"] = dr["netAmount"].ToString();
                parameters["amountCash"] = dr["amountCash"].ToString();
                parameters["amountCard"] = dr["amountCard"].ToString();
                parameters["amountEasy"] = dr["amountPoint"].ToString();
                parameters["amountPoint"] = dr["amountEasy"].ToString();

                parameters["dcAmount"] = dr["dcAmount"].ToString();
                parameters["isCancel"] = dr["isCancel"].ToString();

                if (mRequestPost("payment", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        sql = "DELETE FROM payment WHERE seq_key = " + seq_key + "";
                        int ret = sql_excute_local_db(sql);

                        upload_cnt++;
                    }
                    else
                    {
                        error_cnt++;
                    }
                }
                else
                {
                    error_cnt++;
                }
            }
            dr.Close();


            // paymentCash
            sql = "SELECT * FROM paymentCash";
            dr = sql_select_local_db(sql);
            while (dr.Read())
            {
                String seq_key = dr["seq_key"].ToString();

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = dr["siteId"].ToString();
                parameters["posNo"] = dr["posNo"].ToString();
                parameters["bizDt"] = dr["bizDt"].ToString();
                parameters["theNo"] = dr["theNo"].ToString();
                parameters["refNo"] = dr["refNo"].ToString();

                parameters["payDate"] = dr["payDate"].ToString();
                parameters["payTime"] = dr["payTime"].ToString();
                parameters["payType"] = dr["payType"].ToString();
                parameters["tranType"] = dr["tranType"].ToString();
                parameters["payClass"] = dr["payClass"].ToString();

                parameters["ticketNo"] = dr["ticketNo"].ToString();
                parameters["paySeq"] = dr["paySeq"].ToString();
                parameters["tranDate"] = dr["tranDate"].ToString();
                parameters["amount"] = dr["amount"].ToString();
                parameters["receiptType"] = dr["receiptType"].ToString();

                parameters["issuedMethodNo"] = dr["issuedMethodNo"].ToString();
                parameters["authNo"] = dr["authNo"].ToString();
                parameters["tranSerial"] = dr["tranSerial"].ToString();
                parameters["isCancel"] = dr["isCancel"].ToString();
                parameters["vanCode"] = dr["vanCode"].ToString();

                if (mRequestPost("paymentCash", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        sql = "DELETE FROM paymentCash WHERE seq_key = " + seq_key + "";
                        int ret = sql_excute_local_db(sql);

                        upload_cnt++;
                    }
                    else
                    {
                        error_cnt++;
                    }
                }
                else
                {
                    error_cnt++;
                }
            }
            dr.Close();


            // paymentCard
            sql = "SELECT * FROM paymentCard";
            dr = sql_select_local_db(sql);
            while (dr.Read())
            {
                String seq_key = dr["seq_key"].ToString();

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Clear();
                parameters["siteId"] = dr["siteId"].ToString();
                parameters["posNo"] = dr["posNo"].ToString();
                parameters["bizDt"] = dr["bizDt"].ToString();
                parameters["theNo"] = dr["theNo"].ToString();
                parameters["refNo"] = dr["refNo"].ToString();

                parameters["payDate"] = dr["payDate"].ToString();
                parameters["payTime"] = dr["payTime"].ToString();
                parameters["payType"] = dr["payType"].ToString();
                parameters["tranType"] = dr["tranType"].ToString();
                parameters["payClass"] = dr["payClass"].ToString();

                parameters["ticketNo"] = dr["ticketNo"].ToString();
                parameters["paySeq"] = dr["paySeq"].ToString();
                parameters["tranDate"] = dr["tranDate"].ToString();
                parameters["amount"] = dr["amount"].ToString();
                parameters["taxAmount"] = dr["taxAmount"].ToString();

                parameters["freeAmount"] = dr["freeAmount"].ToString();
                parameters["serviceAmt"] = dr["serviceAmt"].ToString();
                parameters["tax"] = dr["tax"].ToString();
                parameters["install"] = dr["install"].ToString();
                parameters["authNo"] = dr["authNo"].ToString();

                parameters["cardNo"] = dr["cardNo"].ToString();
                parameters["cardName"] = dr["cardName"].ToString();
                parameters["isuCode"] = dr["isuCode"].ToString();
                parameters["acqCode"] = dr["acqCode"].ToString();
                parameters["merchantNo"] = dr["merchantNo"].ToString();

                parameters["tranSerial"] = dr["tranSerial"].ToString();
                parameters["signPath"] = dr["signPath"].ToString();
                parameters["giftChange"] = dr["giftChange"].ToString();
                parameters["isCancel"] = dr["isCancel"].ToString();
                parameters["vanCode"] = dr["vanCode"].ToString();

                if (mRequestPost("paymentCard", parameters))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        sql = "DELETE FROM paymentCard WHERE seq_key = " + seq_key + "";
                        int ret = sql_excute_local_db(sql);

                        upload_cnt++;

                    }
                    else
                    {
                        error_cnt++;
                    }
                }
                else
                {
                    error_cnt++;
                }
            }
            dr.Close();

            if (error_cnt > 0)
            {
                
            }



            return upload_cnt;
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

            if (mTheMode == "Server")
            {
                server_login();

            }
            else if (mTheMode == "Local")
            {
                local_mode();
            }
            else
            {
                MessageBox.Show("네트워크 모드 오류", "thepos");
                return;
            }


            // sub screen
            if (mCustomerMonitor == "Y")
            {
                start_sub_screen();
            }


            // 마우스 커서
            if (mPosType == "POS")
            {
                Cursor.Hide();
            }




            //? 데이터 체크 임시
            //Form f = new frmCheckData();
            //f.Show();

        }



        private void server_login()
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


            // 서버 -> 메모리
            sync_data_server_to_memory();



            // 일반(서버) 테마 적용
            btnBusiness.Enabled = true;
            btnReports.Enabled = true;
            btnSupport.Enabled = true;



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

        }



        private void local_mode()
        {
            frmLocalModeInfo frm = new frmLocalModeInfo();
            frm.ShowDialog();

            if (!mReturn)
            {
                return;
            }


            mUserID = "";
            mUserName = "";
            mPosNo = "";


            //?
            mPayClass = "OR";



            // 로컬DB -> 메모리 
            sync_data_local_to_memory();  // 함수내에서 mPosNo를 구한다.


            lblLocalModeTitle.Visible = true;  // 로컬모드 표시

            panelLogin.Visible = false;

            lblSiteAlias.Text = mSiteAlias;
            lblSiteName.Text = mSiteName;
            lblPosNo.Text = mPosNo;
            lblUserName.Text = "";
            lblCallCenterNo.Text = mCallCenterNo;


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



        private void sync_data_server_to_memory()
        {
            // 1. 사이트
            if (true)
            {
                String sUrl = "site?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["sites"].ToString();
                        JArray arr = JArray.Parse(data);

                        if (arr.Count == 1)
                        {
                            mSiteName = arr[0]["siteName"].ToString();
                            mSiteAlias = arr[0]["siteAlias"].ToString();
                            mRegistNo = arr[0]["registNo"].ToString();
                            mCapName = arr[0]["capName"].ToString();
                            mBizAddr = arr[0]["bizAddr"].ToString();
                            mBizTelNo = arr[0]["bizTelNo"].ToString();
                            mTicketType = arr[0]["ticketType"].ToString();
                            mTicketMedia = arr[0]["ticketMedia"].ToString();
                            mVanCode = arr[0]["vanCode"].ToString();
                            mCallCenterNo = arr[0]["callCenterNo"].ToString();

                            String image_str = arr[0]["billImage"].ToString();

                            if (image_str == "")
                            {
                                mByteLogoImage = null;
                            }
                            else
                            {
                                try
                                {
                                    byte[] mBillImageByte = Convert.FromBase64String(image_str);

                                    MemoryStream ms = new MemoryStream(mBillImageByte, 0, mBillImageByte.Length);
                                    ms.Write(mBillImageByte, 0, mBillImageByte.Length);

                                    Bitmap bitmap_bill = new Bitmap(ms);


                                    mByteLogoImage = GetImage(bitmap_bill, 500);
                                }
                                catch
                                {
                                    mByteLogoImage = null;
                                }
                            }


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
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }

            // 2. goodsGroup
            if (true)
            {
                String sUrl = "goodsGroup?siteId=" + mSiteId + "&posNo=" + mPosNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String goods_group = mObj["goodsGroups"].ToString();
                        JArray arr = JArray.Parse(goods_group);

                        mGoodsGroup = new GoodsGroup[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mGoodsGroup[i].group_code = arr[i]["groupCode"].ToString();
                            mGoodsGroup[i].group_name = arr[i]["groupName"].ToString();
                            mGoodsGroup[i].soldout = arr[i]["soldout"].ToString();
                            mGoodsGroup[i].column = int.Parse(arr[i]["locateX"].ToString());
                            mGoodsGroup[i].row = int.Parse(arr[i]["locateY"].ToString());
                            mGoodsGroup[i].columnspan = int.Parse(arr[i]["sizeX"].ToString());
                            mGoodsGroup[i].rowspan = int.Parse(arr[i]["sizeY"].ToString());
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
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            // 3. goodsItemAndGoods
            if (true)
            {
                String sUrl = "goodsItemAndGoods?siteId=" + mSiteId + "&posNo=" + mPosNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String goods_item = mObj["goodsItems"].ToString();
                        JArray arr = JArray.Parse(goods_item);

                        mGoodsItem = new GoodsItem[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mGoodsItem[i].group_code = arr[i]["groupCode"].ToString();
                            mGoodsItem[i].item_code = arr[i]["itemCode"].ToString();
                            mGoodsItem[i].item_name = arr[i]["itemName"].ToString();
                            mGoodsItem[i].shop_code = arr[i]["shopCode"].ToString();
                            mGoodsItem[i].amt = int.Parse(arr[i]["amt"].ToString());
                            mGoodsItem[i].ticket = arr[i]["ticketYn"].ToString();
                            mGoodsItem[i].taxfree = arr[i]["taxFree"].ToString();
                            mGoodsItem[i].cutout = arr[i]["cutout"].ToString();
                            mGoodsItem[i].soldout = arr[i]["soldout"].ToString();
                            mGoodsItem[i].column = int.Parse(arr[i]["locateX"].ToString());
                            mGoodsItem[i].row = int.Parse(arr[i]["locateY"].ToString());
                            mGoodsItem[i].columnspan = int.Parse(arr[i]["sizeX"].ToString());
                            mGoodsItem[i].rowspan = int.Parse(arr[i]["sizeY"].ToString());

                            // 면세상픔은 상품명앞에 *을 붙인다.
                            if (mGoodsItem[i].taxfree == "1")
                            {
                                mGoodsItem[i].item_name = "*" + mGoodsItem[i].item_name;
                            }
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
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }

            // 4. 샵
            if (true)
            {
                String sUrl = "shop?siteId=" + mSiteId;
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
                            mShop[i].printer_type = arr[i]["printerType"].ToString();
                            mShop[i].network_printer_name = arr[i]["networkPrinterName"].ToString();
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


            // 5. 포스
            if (true)
            {
                String sUrl = "pos?siteId=" + mSiteId + "&posStatus=Y";
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String pos = mObj["pos"].ToString();
                        JArray arr = JArray.Parse(pos);

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
            }


            // 6. setupPos
            if (true)
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
                            if (arr[i]["setupCode"].ToString() == "BillPrinterPort") mBillPrinterPort = arr[i]["setupValue"].ToString();
                            else if (arr[i]["setupCode"].ToString() == "OrderPrinterPort") mOrderPrinterPort = arr[i]["setupValue"].ToString();
                            else if (arr[i]["setupCode"].ToString() == "TicketPrinterPort") mTicketPrinterPort = arr[i]["setupValue"].ToString();
                            else if (arr[i]["setupCode"].ToString() == "PosType") mPosType = arr[i]["setupValue"].ToString();
                            else if (arr[i]["setupCode"].ToString() == "CustomerMonitor") mCustomerMonitor = arr[i]["setupValue"].ToString();
                        }
                    }
                }
            }


            // 7. dcrFavorite
            if (true)
            {
                String sUrl = "dcrFavorite?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String pos = mObj["dcr"].ToString();
                        JArray arr = JArray.Parse(pos);

                        mDCR = new DCR[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mDCR[i].dcr_code = arr[i]["dcrCode"].ToString();
                            mDCR[i].dcr_name = arr[i]["dcrName"].ToString();
                            mDCR[i].dcr_des = arr[i]["dcrDes"].ToString();
                            mDCR[i].dcr_type = arr[i]["dcrType"].ToString();
                            mDCR[i].dcr_value = Int32.Parse(arr[i]["dcrValue"].ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("할인즐겨찾기정보 오류. shop\n\n " + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류. shop\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }


            // 8. paymentConsole
            if (true)
            {
                String sUrl = "paymentConsole?siteId=" + mSiteId + "&posNo=" + mPosNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        String data = mObj["paymentConsoles"].ToString();
                        JArray arr = JArray.Parse(data);

                        mPayConsol = new PayConsol[arr.Count];

                        for (int i = 0; i < arr.Count; i++)
                        {
                            mPayConsol[i].column = int.Parse(arr[i]["locateX"].ToString());
                            mPayConsol[i].row = int.Parse(arr[i]["locateY"].ToString());
                            mPayConsol[i].columnspan = int.Parse(arr[i]["sizeX"].ToString());
                            mPayConsol[i].rowspan = int.Parse(arr[i]["sizeY"].ToString());
                            mPayConsol[i].code = arr[i]["buttonCode"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("상품정보 오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                    return;
                }
            }

        }




        public static byte[] GetImage(Bitmap bill_image, int printWidth)
        {
            List<byte> byteList = new List<byte>();

            BitmapData data = GetBitmapData(bill_image, printWidth);


            BitArray dots = data.Dots;
            byte[] width = BitConverter.GetBytes(data.Width);

            int offset = 0;
            //byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
            //byteList.Add(Convert.ToByte('@'));
            byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
            byteList.Add(Convert.ToByte('3'));
            byteList.Add((byte)24);
            while (offset < data.Height)
            {
                byteList.Add(Convert.ToByte(Convert.ToChar(0x1B)));
                byteList.Add(Convert.ToByte('*'));
                byteList.Add((byte)33);
                byteList.Add(width[0]);
                byteList.Add(width[1]);

                for (int x = 0; x < data.Width; ++x)
                {
                    for (int k = 0; k < 3; ++k)
                    {
                        byte slice = 0;
                        for (int b = 0; b < 8; ++b)
                        {
                            int y = (((offset / 8) + k) * 8) + b;
                            int i = (y * data.Width) + x;

                            bool v = false;
                            if (i < dots.Length)
                                v = dots[i];

                            slice |= (byte)((v ? 1 : 0) << (7 - b));
                        }
                        byteList.Add(slice);
                    }
                }
                offset += 24;
                byteList.Add(Convert.ToByte(0x0A));
            }
            byteList.Add(Convert.ToByte(0x1B));
            byteList.Add(Convert.ToByte('3'));
            byteList.Add((byte)30);
            return byteList.ToArray();
        }

        private static BitmapData GetBitmapData(Bitmap bill_image, int width)
        {
            using (var bitmap = bill_image)
            {
                var threshold = 127;
                var index = 0;
                double multiplier = width; // 이미지 width조정
                double scale = (double)(multiplier / (double)bitmap.Width);
                int xheight = (int)(bitmap.Height * scale);
                int xwidth = (int)(bitmap.Width * scale);
                var dimensions = xwidth * xheight;
                var dots = new BitArray(dimensions);

                for (var y = 0; y < xheight; y++)
                {
                    for (var x = 0; x < xwidth; x++)
                    {
                        var _x = (int)(x / scale);
                        var _y = (int)(y / scale);
                        var color = bitmap.GetPixel(_x, _y);
                        var luminance = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                        dots[index] = (luminance < threshold);
                        index++;
                    }
                }

                return new BitmapData()
                {
                    Dots = dots,
                    Height = (int)(bitmap.Height * scale),
                    Width = (int)(bitmap.Width * scale)
                };
            }
        }


        private class BitmapData
        {
            public BitArray Dots
            {
                get;
                set;
            }

            public int Height
            {
                get;
                set;
            }

            public int Width
            {
                get;
                set;
            }
        }



        public static void sync_data_server_to_local()
        {
            // 1. site -> 마지막에 다운. 에러감안한 버전관리


            // 2. goodsGroup
            if (true)
            {
                String sUrl = "goodsGroup?siteId=" + mSiteId + "&posNo=" + mPosNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        // Delete
                        int ret = sql_excute_local_db("DELETE FROM goodsGroup");

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
                            String soldout = arr[i]["soldout"].ToString();

                            // Insert
                            String sql = "INSERT INTO goodsGroup (siteId, posNo, groupCode, groupName, locateX, locateY, sizeX, sizeY, soldout) " +
                            "values ('" + siteId + "','" + posNo + "','" + groupCode + "','" + groupName + "'," + locateX + "," + locateY + "," + sizeX + "," + sizeY + ",'" + soldout + "')";
                            ret = sql_excute_local_db(sql);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }


            // 3. goodsItemAndGoods
            if (true)
            {
                String sUrl = "goodsItemAndGoods?siteId=" + mSiteId + "&posNo=" + mPosNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        // Delete
                        int ret = sql_excute_local_db("DELETE FROM goodsItemAndGoods");

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
                            String cutout = arr[i]["cutout"].ToString();
                            String soldout = arr[i]["soldout"].ToString();
                            int locateX = int.Parse(arr[i]["locateX"].ToString());
                            int locateY = int.Parse(arr[i]["locateY"].ToString());
                            int sizeX = int.Parse(arr[i]["sizeX"].ToString());
                            int sizeY = int.Parse(arr[i]["sizeY"].ToString());

                            String sql = "INSERT INTO goodsItemAndGoods (siteId, posNo, groupCode, itemCode, itemName, shopCode, amt, ticketYn, taxFree, cutout, soldout, locateX, locateY, sizeX, sizeY) " +
                                "values ('" + siteId + "','" + posNo + "','" + groupCode + "','" + itemCode + "','" + itemName + "','" + shopCode + "'," + amt + ",'" + ticketYn + "','" + taxFree + "','" + cutout + "','" + soldout + "'," + locateX + "," + locateY + "," + sizeX + "," + sizeY + ")";
                            ret = sql_excute_local_db(sql);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }


            // 4. shop
            if (true)
            {
                String sUrl = "shop?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        // Delete
                        int ret = sql_excute_local_db("DELETE FROM shop");

                        //
                        String data = mObj["shops"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            String siteId = arr[i]["siteId"].ToString();
                            string shopCode = arr[i]["shopCode"].ToString();
                            String shopName = arr[i]["shopName"].ToString();
                            String printerType = arr[i]["printerType"].ToString();
                            String networkPrinterName = arr[i]["networkPrinterName"].ToString();

                            String sql = "INSERT INTO shop (siteId, shopCode, shopName, printerType, networkPrinterName) " +
                                         "values ('" + siteId + "','" + shopCode + "','" + shopName + "','" + printerType + "','" + networkPrinterName + "')";
                            ret = sql_excute_local_db(sql);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }


            // 5. pos
            if (true)
            {
                String sUrl = "pos?siteId=" + mSiteId + "&posStatus=Y";
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        // Delete
                        int ret = sql_excute_local_db("DELETE FROM pos");

                        //
                        String data = mObj["pos"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            String siteId = arr[i]["siteId"].ToString();
                            String posNo = arr[i]["posNo"].ToString();
                            String macAddr = arr[i]["macAddr"].ToString();
                            String posStatus = arr[i]["posStatus"].ToString();

                            String sql = "INSERT INTO pos (siteId, posNo, macAddr, posStatus) " +
                                        "values ('" + siteId + "','" + posNo + "','" + macAddr + "','" + posStatus + "')";
                            ret = sql_excute_local_db(sql);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }


            // 6. setupPos
            if (true)
            {
                String sUrl = "setupPos?siteId=" + mSiteId + "&posNo=" + mPosNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        // Delete
                        int ret = sql_excute_local_db("DELETE FROM setupPos");

                        //
                        String data = mObj["setupPos"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            String siteId = arr[i]["siteId"].ToString();
                            String posNo = arr[i]["posNo"].ToString();
                            String setupCode = arr[i]["setupCode"].ToString();
                            String setupName = arr[i]["setupName"].ToString();
                            String setupValue = arr[i]["setupValue"].ToString();
                            String memo = arr[i]["memo"].ToString();

                            String sql = "INSERT INTO setupPos (siteId, posNo, setupCode, setupName, setupValue, memo) " +
                                    "values ('" + siteId + "','" + posNo + "','" + setupCode + "','" + setupName + "','" + setupValue + "','" + memo + "')";
                            ret = sql_excute_local_db(sql);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }


            // 7. dcrFavority
            if (true)
            {
                String sUrl = "dcrFavorite?siteId=" + mSiteId;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        // Delete
                        int ret = sql_excute_local_db("DELETE FROM dcrFavorite");

                        //
                        String data = mObj["dcr"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            String siteId = arr[i]["siteId"].ToString();
                            int sortNo = int.Parse(arr[i]["sortNo"].ToString());
                            String dcrCode = arr[i]["dcrCode"].ToString();
                            String dcrName = arr[i]["dcrName"].ToString();
                            String dcrDes = arr[i]["dcrDes"].ToString();
                            String dcrType = arr[i]["dcrType"].ToString();
                            int dcrValue = int.Parse(arr[i]["dcrValue"].ToString());

                            String sql = "INSERT INTO dcrFavorite (siteId, sortNo, dcrCode, dcrName, dcrDes, dcrType, dcrValue) " +
                                    "values ('" + siteId + "'," + sortNo + ",'" + dcrCode + "','" + dcrName + "','" + dcrDes + "','" + dcrType + "'," + dcrValue + ")";
                            ret = sql_excute_local_db(sql);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }


            // 8. paymentConsole
            if (true)
            {
                String sUrl = "paymentConsole?siteId=" + mSiteId + "&posNo=" + mPosNo;
                if (mRequestGet(sUrl))
                {
                    if (mObj["resultCode"].ToString() == "200")
                    {
                        // Delete
                        int ret = sql_excute_local_db("DELETE FROM paymentConsole");

                        String data = mObj["paymentConsoles"].ToString();
                        JArray arr = JArray.Parse(data);

                        for (int i = 0; i < arr.Count; i++)
                        {
                            String siteId = arr[i]["siteId"].ToString();
                            String posNo = arr[i]["posNo"].ToString();
                            String buttonCode = arr[i]["buttonCode"].ToString();
                            String buttonName = arr[i]["buttonName"].ToString();
                            int locateX = int.Parse(arr[i]["locateX"].ToString());
                            int locateY = int.Parse(arr[i]["locateY"].ToString());
                            int sizeX = int.Parse(arr[i]["sizeX"].ToString());
                            int sizeY = int.Parse(arr[i]["sizeY"].ToString());
                            String usage = arr[i]["usage"].ToString();

                            String sql = "INSERT INTO paymentConsole (siteId, posNo, buttonCode, buttonName, locateX, locateY, sizeX, sizeY, usage) " +
                                    "values ('" + siteId + "'," + posNo + ",'" + buttonCode + "','" + buttonName + "'," + locateX + "," + locateY + "," + sizeX + "," + sizeY + ",'" + usage + "')";
                            ret = sql_excute_local_db(sql);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }


            // 1. site -- 는 제일 마지막에.. 에러감안한 버전관리
            if (true)
            {
                String sUrl = "site?siteId=" + mSiteId;
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
                            int ret = sql_excute_local_db("DELETE FROM site");

                            // Insert
                            String sql = "INSERT INTO site (siteId, siteName, siteAlias, registNo, capName, bizAddr, bizTelNo, ticketType, ticketMedia, vanCode, callCenterNo, basicDbVer) " +
                                         "values ('" + siteId + "','" + siteName + "','" + siteAlias + "','" + registNo + "','" + capName + "','" + bizAddr + "','" + bizTelNo + "','" + ticketType + "','" + ticketMedia + "','" + vanCode + "','" + callCenterNo + "','" + basicDbVer + "')";
                            ret = sql_excute_local_db(sql);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }


            //
            MessageBox.Show("다운로드 완료.", "thepos");

        }



        private void sync_data_local_to_memory ()
        {
            SQLiteDataReader dr;

            // 1. site
            if (true)
            {
                dr = sql_select_local_db("SELECT * FROM site");
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
            }


            // 2. goodsGroup
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
                    mGoodsGroup[i].soldout = dr["soldout"].ToString();
                    i++;
                }
                dr.Close();
            }


            // 3. goodsItemAndGoods
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
                    mGoodsItem[i].cutout = dr["cutout"].ToString();
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


            // 4. shop
            if (true)
            {
                int rowcnt = 0;
                dr = sql_select_local_db("SELECT count(*) as cnt FROM shop");
                if (dr.Read())
                {
                    rowcnt = int.Parse(dr["cnt"].ToString());
                }
                dr.Close();

                mShop = new Shop[rowcnt];


                dr = sql_select_local_db("SELECT * FROM shop");
                int i = 0;
                while (dr.Read())
                {
                    mShop[i].shop_code = dr["shopCode"].ToString();
                    mShop[i].shop_name = dr["shopName"].ToString();
                    mShop[i].printer_type = dr["printerType"].ToString();
                    mShop[i].network_printer_name = dr["networkPrinterName"].ToString();

                    i++;
                }
                dr.Close();
            }


            // 5. pos
            if (true)
            {
                int rowcnt = 0;
                dr = sql_select_local_db("SELECT count(*) as cnt FROM pos");
                if (dr.Read())
                {
                    rowcnt = int.Parse(dr["cnt"].ToString());
                }
                dr.Close();

                mPosNoList = new String[rowcnt];


                dr = sql_select_local_db("SELECT * FROM pos");
                int i = 0;
                while (dr.Read())
                {
                    mPosNoList[i] = dr["posNo"].ToString();

                    // 내 포스번호 구하기
                    if (mMacAddr == dr["macAddr"].ToString())
                    {
                        mPosNo = dr["posNo"].ToString();
                    }

                    i++;
                }
                dr.Close();
            }


            // 6. setupPos
            if (true)
            {
                dr = sql_select_local_db("SELECT * FROM setupPos");
                int i = 0;
                while (dr.Read())
                {
                    if (dr["setupCode"].ToString() == "BillPrinterPort") mBillPrinterPort = dr["setupValue"].ToString();
                    else if (dr["setupCode"].ToString() == "TicketPrinterPort") mTicketPrinterPort = dr["setupValue"].ToString();
                    else if (dr["setupCode"].ToString() == "OrderPrinterPort") mOrderPrinterPort = dr["setupValue"].ToString();
                    else if (dr["setupCode"].ToString() == "PosType") mPosType = dr["setupValue"].ToString();
                    else if (dr["setupCode"].ToString() == "CustomerMonitor") mCustomerMonitor = dr["setupValue"].ToString();
                    i++;
                }
                dr.Close();
            }


            // 7. dcrFavorite
            if (true)
            {
                int rowcnt = 0;
                dr = sql_select_local_db("SELECT count(*) as cnt FROM dcrFavorite");
                if (dr.Read())
                {
                    rowcnt = int.Parse(dr["cnt"].ToString());
                }
                dr.Close();

                mDCR = new DCR[rowcnt];


                dr = sql_select_local_db("SELECT * FROM dcrFavorite");
                int i = 0;
                while (dr.Read())
                {
                    mDCR[i].dcr_code = dr["dcrCode"].ToString();
                    mDCR[i].dcr_name = dr["dcrName"].ToString();
                    mDCR[i].dcr_des = dr["dcrDes"].ToString();
                    mDCR[i].dcr_type = dr["dcrType"].ToString();
                    mDCR[i].dcr_value = Int32.Parse(dr["dcrValue"].ToString());
                    i++;
                }
                dr.Close();
            }


            // 8. paymentConsole
            if (true)
            {
                int rowcnt = 0;
                dr = sql_select_local_db("SELECT count(*) as cnt FROM paymentConsole");
                if (dr.Read())
                {
                    rowcnt = int.Parse(dr["cnt"].ToString());
                }
                dr.Close();

                mPayConsol = new PayConsol[rowcnt];


                dr = sql_select_local_db("SELECT * FROM paymentConsole");
                int i = 0;
                while (dr.Read())
                {
                    mPayConsol[i].column = int.Parse(dr["locateX"].ToString());
                    mPayConsol[i].row = int.Parse(dr["locateY"].ToString());
                    mPayConsol[i].columnspan = int.Parse(dr["sizeX"].ToString());
                    mPayConsol[i].rowspan = int.Parse(dr["sizeY"].ToString());
                    mPayConsol[i].code = dr["buttonCode"].ToString();
                    i++;
                }
                dr.Close();
            }
        }




        // 판매관리
        private void btnSales_Click(object sender, EventArgs e)
        {
            //? 영업상태
            // 영업중상태: 개시후 마감전
            // 영업마감상태 : 마감이후 개시전



            if (mTheMode == "Local")  // 긴급사용모드
            {
                // 영업일자 입력받은 그대로 사용... 
                //mBizDate = ;

                panelDivision.Visible = true;
                panelDivision.Controls.Clear();

                frmSales fForm = new frmSales() { TopLevel = false, TopMost = true };
                panelDivision.Controls.Add(fForm);
                fForm.Show();


            }
            else if (mTheMode == "Server")
            {
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
            else
            {

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

            frmSetup fForm = new frmSetup() { TopLevel = false, TopMost = true };
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


        private void lblSiteAlias_Click(object sender, EventArgs e)
        {
            sysadmin_pw_patern = "";
        }

        private void lblPosNoTitle_Click(object sender, EventArgs e)
        {
            sysadmin_pw_patern += "1";
        }

        private void lblUserNameTitle_Click(object sender, EventArgs e)
        {
            sysadmin_pw_patern += "2";
        }

        private void lblCallCenterNo_Click(object sender, EventArgs e)
        {
            frmSysAdmin frmSysAdmin = new frmSysAdmin(sysadmin_pw_patern);
            frmSysAdmin.ShowDialog();

            sysadmin_pw_patern = "";
        }


        private bool check_server_status()
        {
            String sUrl = "testCall?siteId=" + mSiteId + "&posNo=" + mPosNo + "&testDt=" + get_today_date() + get_today_time();
            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}
