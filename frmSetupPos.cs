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


        }


        private void initialize_font()
        {
            lvwOrderItem.Font = font10;




        }

        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 32);

            lvwOrderItem.SmallImageList = imgList;
            lvwOrderItem.HideSelection = true;





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
