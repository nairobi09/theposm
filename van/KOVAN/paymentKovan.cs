using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static thepos.thePos;

namespace thepos
{
    internal class paymentKovan
    {


        public struct KovanResponse
        {
            public String t거래구분;
            public String t거래유형;
            public String t응답코드;
            public String t거래금액;
            public String t부가세;
            public String t봉사료;
            public String t할부;
            public String t승인번호;
            public String t승인일시;
            public String t발급사코드;
            public String t발급사명;
            public String t매입사코드;
            public String t매입사명;
            public String t가맹점번호;
            public String t승인CATID;
            public String t잔액;
            public String t응답메시지;
            public String t카드BIN;
            public String t카드구분;
            public String t전문관리번호;
            public String t거래일련번호;
            public String t발생포인트;
            public String t가용포인트;
            public String t누적포인트;
            public String t캐시백가맹점포멧;
            public String t캐시백승인번호;
            public String t기기번호;
        }
        public static KovanResponse mNiceResponse = new KovanResponse();

        public int requestNiceCardAuth(int tAmount, int tFreeAmount, int tTaxAmount, int tTax, int tServiceAmt, int install, String is_cup, out PaymentCard pCard)
        {
            PaymentCard paymentCard = new PaymentCard();
            pCard = paymentCard;

           
            return 0;


        }


        public int requestKovanCardCancel(PaymentCard pCardAuth, out PaymentCard pCardCancel)
        {
            pCardCancel = pCardAuth;


            return 0;

        }

    }
}
