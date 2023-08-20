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




//? 포스별 설정 항목

/*

 * 상품그룹 배치유형 : 0:Flow형, 1:Table형    -> 상품 배치유형: 상품그룹테이블에 저장
 * 
 * 컴포트 : 영수증프린터, 라벨프린터 
 * 결제밴사구분 : TOSS KCP NICE KOVAN
 * 클라이언트유형? : PC, 포스, 키오스크 -> 마우스포인터 표시여부
 * 













*/


namespace thepos
{
    public partial class frmSetupPos : Form
    {
        public frmSetupPos()
        {
            InitializeComponent();

            initialize_font();

            initialize_the();

            set_setup_pos();
            reload_setup_pos();
        }


        private void initialize_font()
        {
            lvwList.Font = font12;




        }

        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 32);

            lvwList.SmallImageList = imgList;
            lvwList.HideSelection = true;





        }


        private void set_setup_pos()
        {

            // 설정항목 정의











        }


        private void reload_setup_pos()
        {
            String sUrl = "bizDateLast?siteId=" + mSiteId + "&posNo=" + mPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["setupPos"].ToString();
                    JArray arr = JArray.Parse(data);

                    for (int i = 0; i < arr.Count; i++)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = arr[i]["setupName"].ToString();
                        lvItem.SubItems.Add(arr[i]["setupValue"].ToString());
                        lvItem.SubItems.Add("");
                        lvItem.SubItems.Add(arr[i]["memo"].ToString());
                        lvItem.Tag = arr[i]["setupCode"].ToString();
                        lvwList.Items.Add(lvItem);
                    }
                }
                else
                {
                    MessageBox.Show("포스설정 오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
            }

        }



        private void lvwOrderItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }
    }
}
