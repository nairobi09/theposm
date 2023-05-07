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


        public struct GoodsGroup
        {
            public string code;  // 3
            public string name;
            public string type;  // 사용가능한 pos_type : 모든POS = "ALL", 그룹POS= "G00"
        }

        public struct GoodsItem
        {
            public string code;  // 6
            public string name;
            public int amt;
            public int column;
            public int row;
            public int columnspan;
            public int rowspan;
        }


        public thepos()
        {
            PrivateFontCollection fontCollectionThin = new PrivateFontCollection();
            PrivateFontCollection fontCollectionMedium = new PrivateFontCollection();
            PrivateFontCollection fontCollectionBold = new PrivateFontCollection();

            //fontCollectionThin.AddFontFile("SpoqaHanSansNeo-Thin.ttf");
            //fontCollection.AddFontFile("SpoqaHanSansNeo-Light.ttf");
            //fontCollection.AddFontFile("SpoqaHanSansNeo-Regular.ttf");

            //fontCollectionMedium.AddFontFile("SpoqaHanSansNeo-Medium.ttf");
            //fontCollectionBold.AddFontFile("SpoqaHanSansNeo-Bold.ttf");

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
        }


        public GoodsGroup[] mGoodsGroup;
        public GoodsItem[] mGoodsItem;




        public void get_goodsgroup()
        {

            String[,] group = new String[,]
            {
                {"101","커피","G01"},
                {"100","티켓","ALL"},
                {"102","식사","G02"},
                {"103","후식","G01"},
                {"104","직원방문","G01"},
                {"105","야간","G01"},
                {"106","VIP","G01"},
                {"107","장애인","G01"},
                {"108","단체","G01"},
                {"109","기본","G01"},
                {"110","기부","G01"},
                {"111","서비스","G01"},
                {"112","학습","G01"},
                {"113","온라인","G01"},
                {"114","이벤트","G01"},
                {"115","","G01"},
                {"116","단체","G01"},
                {"117","임시권","G01"},
                {"118","주차","G01"},
                {"119","단체","G01"},
                {"120","일반","G01"},
                {"121","단체","G01"},
                {"122","아동","G01"},
                {"123","청소년","G01"},
                {"124","출근","G01"},
                {"125","연예인","G01"},
                {"126","정기권","G01"}
            };


            int len = group.Length / 3;


            mGoodsGroup = new GoodsGroup[len];

            for (int i = 0; i < len ; i++)
            {
                mGoodsGroup[i].code = group[i, 0];
                mGoodsGroup[i].name = group[i, 1];
                mGoodsGroup[i].type = group[i, 2];
            }


            
        }

        public void get_goodsitem()
        {
            mGoodsItem = new GoodsItem[11];

            String[,] item = new String[,]
            {
                /*
                { "101101","바닐라라떼","8000", "0","0", "2","2"},
                { "101102","카푸치노","6000", "2","0", "2","2"},
                { "101103","에스프레소","7000", "4","0", "2","2"},
                { "101104","아이스라떼","6500", "6","0", "2","2"},
                { "101105","아메리카노","5000", "0","2", "2","2"},
                { "101106","맥심커피","8000", "2","2", "2","2"},
                { "101108","카페라떼","7000", "4","2", "2","2"},
                { "101107","캬라멜","6000", "6","2", "2","2"},
                { "101109","모카","5000", "0","4", "2","2"},
                { "101110","아리스카페모카","5000", "2","4", "2","2"},

                { "100001","종일자유","10000", "0","0", "2","2"},
                { "100002","종일어린이","8000", "2","0", "2","2"},
                */
                
                { "101101","바닐라라떼","8000", "0","0", "2","2"},
                { "101102","카푸치노","6000", "2","0", "1","2"},
                { "101103","에스프레소","7000", "3","0", "3","2"},
                { "101104","아이스라떼","6500", "6","1", "2","1"},
                { "101105","아메리카노","5000", "0","2", "4","3"},
                { "101106","맥심커피","8000", "4","2", "4","4"},
                { "101108","카페라떼","7000", "0","5", "3","3"},
                { "101107","캬라멜","6000", "3","5", "1","3"},
                { "101109","모카","5000", "4","6", "1","1"},
                { "101110","아리스카페모카","5000", "4","7", "3","1"},

                { "100001","종일성인","10000", "0","1", "4","5"},
                { "100002","종일어린이","8000", "4","1", "4","5"},

            };


            int len = item.Length / 7;


            mGoodsItem = new GoodsItem[len];

            for (int i = 0; i < len; i++)
            {
                mGoodsItem[i].code = item[i, 0];
                mGoodsItem[i].name = item[i, 1];
                mGoodsItem[i].amt = Int32.Parse(item[i, 2]);

                mGoodsItem[i].column = Int32.Parse(item[i, 3]);
                mGoodsItem[i].row = Int32.Parse(item[i, 4]);
                mGoodsItem[i].columnspan = Int32.Parse(item[i, 5]);
                mGoodsItem[i].rowspan = Int32.Parse(item[i, 6]);
            }



        }

    }
}
