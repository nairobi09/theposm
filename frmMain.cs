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

namespace thepos
{
    public partial class frmMain : Form
    {

        TextBox mTbKeyDisplayController;  // 공용컨트롤러

        int AdminClickCount = 0;



        public frmMain()
        {
            InitializeComponent();

            initialize_font();

            initialize_the();
        }


        private void initialize_font()
        {
            //fontCollection.AddFontFile("Font\\Pretendard-Regular.ttf");
            fontCollection.AddFontFile("Font\\Pretendard-Medium.ttf");

            font8 = new Font(fontCollection.Families[0], 8f);
            font9 = new Font(fontCollection.Families[0], 9f);
            font10 = new Font(fontCollection.Families[0], 10f);
            font12 = new Font(fontCollection.Families[0], 12f);
            font12bold = new Font(fontCollection.Families[0], 12f, FontStyle.Bold);
            font13 = new Font(fontCollection.Families[0], 12f);
            font14 = new Font(fontCollection.Families[0], 14f);
            font16 = new Font(fontCollection.Families[0], 16f);
            font20 = new Font(fontCollection.Families[0], 20f);


            btnClose.Font = font12;


            lblSiteAlias.Font = font16;
            lblSiteName.Font = font10;

            lblPosNoTitle.Font = font10;
            lblPosNo.Font = font10;

            lblUserNameTitle.Font = font10;
            lblUserName.Font = font10;



            btnSales.Font = font14;
            btnBusiness.Font = font14;
            btnReports.Font = font14;
            btnSetup.Font = font12;
            btnSupport.Font = font12;
            btnExit.Font = font12;

            lblCallCenter.Font = font10;





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


            //? Cursor.Hide();


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


        }

        private void clear_login_init()
        {
            mSiteAlias = "";
            mSiteName = "";
            mPosNo = "";
            mUserName = "";

            lblSiteAlias.Text = "";
            lblSiteName.Text = "";
            lblPosNo.Text = "";
            lblUserName.Text = "";


            mSiteId = "";
            mSiteName = "";         // 매장명
            mSiteAlias = "";        // 매장명
            mCapName = "";          // 대표자명
            mRegistNo = "";         // 사업자번호
            mBizAddr = "";          // 주소
            mBizTelNo = "";         // 대표전화


            mTicketType = "";  // ""미사용, "PA"선불, "PD"후불
            mTicketMedia = "";  // 띠지BC   팔찌RF
            mPayChannel = "";


            // 이사업자의 포스번호 목록
            //mPosNoList.Initialize();

            mCornerType = "";  // 주문서 관리 - ""미사용, "E"단순일체형, "P"분리형
            //mCornerCode.Initialize(); // 코너 코드
            //mCornerName.Initialize(); // 코너 명

            mPosNo = "";

            mBillPrinterPort = "";  // 영수증프린터
            mTicketMediaPort = "";  // 띠지 or 팔찌

            mUserID = "";
            mUserName = "";

            mBizDate = "";


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

            //? 서버 
            JObject obj = new JObject();
            String err_msg = "";

            // 로그인
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["loginId"] = tbID.Text;
            //? SHA1 변경
            parameters["userPw"] = tbPW.Text;
            //parameters["userPw"] = SHA1HashCrypt(tbPW.Text);



            parameters["macAddr"] = mMacAddr;

            if (mRequestPost("login", parameters, ref obj, ref err_msg))
            {
                if (obj["resultCode"].ToString() == "200")
                {
                    mSiteId = obj["siteId"].ToString();
                    mUserID = tbID.Text;
                    mUserName = obj["userName"].ToString();
                    mPosNo = obj["posNo"].ToString();
                }
                else
                {
                    MessageBox.Show("로그인오류\n\n" + obj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + err_msg, "thepos");
                return;
            }


            // 사이트
            String sUrl = "site?siteId=" + mSiteId;

            if (mRequestGet(sUrl, ref obj, ref err_msg))
            {
                if (obj["resultCode"].ToString() == "200")
                {
                    String sites = obj["sites"].ToString();
                    JArray arr = JArray.Parse(sites);

                    mSiteName = arr[0]["siteName"].ToString();
                    mSiteAlias = arr[0]["siteAlias"].ToString();
                    mCapName = arr[0]["capName"].ToString();
                    //?
                    //mCallCenterNo = arr[0]["callCenterNo"].ToString();
                }
                else
                {
                    MessageBox.Show("사이트정보 오류\n\n" + obj["resultMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + err_msg, "thepos");
                return;
            }



            // 포스
            sUrl = "pos?siteId=" + mSiteId;

            if (mRequestGet(sUrl, ref obj, ref err_msg))
            {
                if (obj["resultCode"].ToString() == "200")
                {
                    String pos = obj["pos"].ToString();
                    JArray arr = JArray.Parse(pos);

                    mPosNoList = new String[arr.Count];

                    for (int i = 0; i < arr.Count; i++)
                    {
                        mPosNoList[i] = arr[i]["posNo"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("포스정보 오류\n\n" + obj["resultMsg"].ToString() + "\n" + obj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + err_msg, "thepos");
                return;
            }



            //? 개시마감 
            //mBizDate = "";
            mBizDate = DateTime.Now.ToString("yyyyMMdd");






            //////////////////////////////
            //? 로그인 성공
            panelLogin.Visible = false;

            //get_site_pos_user_info();

            lblSiteAlias.Text = mSiteAlias;
            lblSiteName.Text = mSiteName;
            lblPosNo.Text = mPosNo;
            lblUserName.Text = mUserName;


            lblCallCenter.Text = "콜센터: " + mCallCenterNo;


            //
            save_registry_info();

        }









        private void get_site_pos_user_info()
        {

            //? 서버에서 GET 구현 필요

            /*
            mCallCenterNo = "02-1234-5678";



            mBizDate = DateTime.Now.ToString("yyyyMMdd");
            mSiteId = "9011";
            mPosNo = "01";

            mSiteAlias = "한국스파월드";
            mSiteName = "주식회사 한국스파월드";
            mCapName = "김동슈";
            mRegistNo = "3770110382";
            mBizAddr = "경기도 광명시 일직로 101-22";
            mBizTelNo = "031-954-4938";


            mTicketType = "PA"; // PA선불
            //mTicketType = "PD"; // PD후불

            mTicketMedia = "BC";  // BC:BarCode 띠지
            //mTicketMedia = "RF";  // RF 팔찌

            //mPayChannel = "KCP";
            mPayChannel = "TOSS";


            mPosNoList = new string[4];
            mPosNoList[0] = "01";
            mPosNoList[1] = "02";
            mPosNoList[2] = "03";
            mPosNoList[3] = "04";


            mUserID = "";
            mUserName = "김토스";
            */
        }







        // 판매관리
        private void btnSales_Click(object sender, EventArgs e)
        {
            Form fFlow;
            fFlow = new frmSales();
            fFlow.ShowDialog();

        }

        // 영업관리
        private void btnBusiness_Click(object sender, EventArgs e)
        {
            Form fFlow;
            fFlow = new frmBusiness();
            fFlow.ShowDialog();
        }

        // 매출관리
        private void btnReports_Click(object sender, EventArgs e)
        {
            Form fFlow;
            fFlow = new frmReports();
            fFlow.ShowDialog();
        }

        // 환경설정
        private void btnSetup_Click(object sender, EventArgs e)
        {

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

        private void picLogo_Click(object sender, EventArgs e)
        {

            frmSysAdminGate fSysAdminGate = new frmSysAdminGate();
            DialogResult ret = fSysAdminGate.ShowDialog();

            if (ret == DialogResult.OK)
            {
                frmSysAdmin frmSysAdmin = new frmSysAdmin();
                frmSysAdmin.ShowDialog();

            }



        }

        private void lblReqUser_Click(object sender, EventArgs e)
        {
            frmReqUser fReqUser = new frmReqUser();
            fReqUser.ShowDialog();
        }

        private void lblReqPos_Click(object sender, EventArgs e)
        {
            frmReqPos fReqPos = new frmReqPos();
            fReqPos.ShowDialog();
        }
    }
}
