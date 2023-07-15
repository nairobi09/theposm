using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;

namespace thepos
{
    public partial class frmMain : Form
    {
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




            // 로그인

            lblID.Font = font12;
            lblPW.Font = font12;

            tbID.Font = font14;
            tbPW.Font = font14;

            cbSaveID.Font = font10;

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
            btnKeyLogin.Font = font14;

            lblCallCenter.Font = font10;

        }

        private void initialize_the()
        {
            lblSiteAlias.Text = mSiteAlias;
            lblSiteName.Text = mSiteName;
            lblPosNo.Text = mPosNo;
            lblUserName.Text = mUserName;


        }

        private void btnKeyLogin_Click(object sender, EventArgs e)
        {
            String id = tbID.Text;
            String pw = tbPW.Text;


            //? 서버 로그인








            //? 로그인 성공
            panelLogin.Visible = false;

            get_site_pos_user_info();

            lblSiteAlias.Text = mSiteAlias;
            lblSiteName.Text = mSiteName;
            lblPosNo.Text = mPosNo;
            lblUserName.Text = mUserName;


            lblCallCenter.Text = "콜센터: " + mCallCenterNo;


        }



        private void get_site_pos_user_info()
        {

            //? 서버에서 GET 구현 필요


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

            mPayChannel = "KCP";
            //mPayChannel = "TOSS";


            mPosNoList = new string[4];
            mPosNoList[0] = "01";
            mPosNoList[1] = "02";
            mPosNoList[2] = "03";
            mPosNoList[3] = "04";


            mUserID = "0012";
            mUserName = "김토스";

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
            fExit.ShowDialog();


            //? 종료 재기동 로그아웃


            this.Close();
        }

    }
}
