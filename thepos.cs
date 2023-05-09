using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thepos
{
    class thepos
    {
        public Font fontMedium_8;
        public Font fontMedium_10;
        public Font fontMedium_12;
        public Font fontMedium_15;
        public Font fontMedium_18;

        public Font fontBold_12;
        public Font fontBold_14;

        public String mCustomerCode = "";
        public String mPosNo = "";

        public thepos()
        {
            PrivateFontCollection fontCollectionThin = new PrivateFontCollection();
            PrivateFontCollection fontCollectionMedium = new PrivateFontCollection();
            PrivateFontCollection fontCollectionBold = new PrivateFontCollection();

            fontCollectionThin.AddFontFile("Pretendard-Thin.ttf");
            fontCollectionMedium.AddFontFile("Pretendard-Medium.ttf");
            fontCollectionBold.AddFontFile("Pretendard-Bold.ttf");

            fontMedium_8 = new Font(fontCollectionMedium.Families[0], 8f);
            fontMedium_10 = new Font(fontCollectionMedium.Families[0], 10f);
            fontMedium_12 = new Font(fontCollectionMedium.Families[0], 12f);
            fontMedium_15 = new Font(fontCollectionMedium.Families[0], 15f);
            fontMedium_18 = new Font(fontCollectionMedium.Families[0], 18f);

            fontBold_12 = new Font(fontCollectionBold.Families[0], 12f);
            fontBold_14 = new Font(fontCollectionBold.Families[0], 14f);

            // 사업장코드, POS_NO
            mCustomerCode = "HUSN";
            mPosNo = "01";
        }




    }
}
