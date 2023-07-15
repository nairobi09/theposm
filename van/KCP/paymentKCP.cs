using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static thepos.thePos;

namespace thepos
{
    internal class paymentKCP
    {
        ClsSecureDLL clsSecureDLL = new ClsSecureDLL();


        public paymentKCP()
        {
            clsSecureDLL.LoadLibrary();

        }




        public int requestKcpCardAuth(int tAmount, int tFreeAmount, int tTaxAmount, int tTax, int tServiceAmt, int install, out PaymentCard paymentCard)
        {

            PaymentCard mPaymentCard = new PaymentCard();
            paymentCard = mPaymentCard;



            // 요청 데이터 초기화
            clsSecureDLL.InitData();

            clsSecureDLL.SetData("WORK_CODE", "0100");
            clsSecureDLL.SetData("PROC_CODE", "A01");

            
            // 총거래 금액
            clsSecureDLL.SetData("TOT_AMT", tAmount + "");
            // 과세 금액
            clsSecureDLL.SetData("ORG_AMT", tTaxAmount + "");
            // 면세 금액
            clsSecureDLL.SetData("DUTY_AMT", tFreeAmount + "");
            // 봉사료
            clsSecureDLL.SetData("SVC_AMT", tServiceAmt + "");
            // 세금
            clsSecureDLL.SetData("TAX_AMT", tTax + "");
            // 신용 할부 설정
            clsSecureDLL.SetData("INS_MON", install + "");



            int nRet = clsSecureDLL.TransData_Modal();

            // TransData 리턴값이 "-99"일 경우 거래중단
            if (nRet == -99)
            {

                mErrorMsg = "KCP TransData_Modal 오류.";
                return -1;
            }



            // 응답

            String id = clsSecureDLL.GetData("TERM_ID");

            // 업체 코드
            //clsSecureDLL.GetData("POS_CD");

            // 요청 구분
            //strWorkCd = clsSecureDLL.GetData("WORK_CODE");
            
            // 전문 코드
            //strProcCd = clsSecureDLL.GetData("PROC_CODE");
            
            // 유니크거래번호 생성여부
            clsSecureDLL.GetData("UTRANS_NO_YN");
            // 결제대기창 숨김여부
            clsSecureDLL.GetData("FORM_HIDE_YN");

            // 응답 코드
            String ResCd = clsSecureDLL.GetData("RES_CD");
            // 응답 메세지
            String ResMag = clsSecureDLL.GetData("RES_MSG");

            // 커넥션 ID 반환
            //String ConnID = clsSecureDLL.GetData("CONN_ID");

            // 정상 응답
            if (ResCd == "0000")
            {
                // 거래 유형
                clsSecureDLL.GetData("TX_TYPE");

                // 마스킹 카드번호
                mPaymentCard.card_no = clsSecureDLL.GetData("CARD_BIN");
                // 거래번호
                mPaymentCard.tran_serial = clsSecureDLL.GetData("TRANS_NO");  // tran_serial -> 취소시 사용

                // 간편결제 OTC번호
                //String OtcNo = clsSecureDLL.GetData("OTC_NO");

                // 할부개월
                mPaymentCard.install = clsSecureDLL.GetData("INS_MON");
                // 총거래 금액
                mPaymentCard.amount = int.Parse(clsSecureDLL.GetData("TOT_AMT"));
                // 과세 금액
                clsSecureDLL.GetData("ORG_AMT");
                // 면세 금액
                clsSecureDLL.GetData("DUTY_AMT");
                // 봉사료
                clsSecureDLL.GetData("SVC_AMT");
                // 세금
                clsSecureDLL.GetData("TAX_AMT");
                // 자원순환 보증금
                clsSecureDLL.GetData("RESERVED_3");

                // 사용자 데이터
                String UserData = clsSecureDLL.GetData("USER_DATA");
                // 예비
                clsSecureDLL.GetData("RESERVED");
                // 예비1
                clsSecureDLL.GetData("RESERVED_1");

                // 고객 서명 여부
                clsSecureDLL.GetData("SIGN_YN");
                // 고객 서명 데이터
                String Sign = clsSecureDLL.GetData("SIGN_DATA");

                // 거래일시
                mPaymentCard.tran_date = clsSecureDLL.GetData("OTX_DT");  // 응답시 12자리 -> 취소시 6자리
                // 승인번호
                mPaymentCard.auth_no = clsSecureDLL.GetData("AUTH_NO");
                // 포인트 승인번호
                clsSecureDLL.GetData("POINT_AUTH_NO");

                // 매입사 코드
                mPaymentCard.acq_code = clsSecureDLL.GetData("AC_CODE");
                // 매입사 명
                String AcName = clsSecureDLL.GetData("AC_NAME");
                // 발급사 코드
                mPaymentCard.isu_code = clsSecureDLL.GetData("CC_CODE");
                // 발급사 명
                mPaymentCard.card_name = clsSecureDLL.GetData("CC_NAME");
                // 가맹점 번호
                mPaymentCard.merchant_no = clsSecureDLL.GetData("MCHT_NO");

                // 처리 포인트
                clsSecureDLL.GetData("POINT_INFO");
                // 자동 이체 구분
                clsSecureDLL.GetData("AT_TYPE");
                // 카드구분/거래자 구분
                clsSecureDLL.GetData("CARD_TYPE");

                // 프린트 메시지
                clsSecureDLL.GetData("PRTMSG_1");
                clsSecureDLL.GetData("PRTMSG_2");
                clsSecureDLL.GetData("PRTMSG_3");
                clsSecureDLL.GetData("PRTMSG_4");

                return 0;
            }
            else
            {
                mErrorMsg = ResMag;
                return -1;
            }
        }


        public int requestKcpCardCancel(PaymentCard pCard, out PaymentCard pCardCancel)
        {
            pCardCancel = pCard;



            // 요청 데이터 초기화
            clsSecureDLL.InitData();

            clsSecureDLL.SetData("WORK_CODE", "0420");
            clsSecureDLL.SetData("PROC_CODE", "A01");

            clsSecureDLL.SetData("SCREEN_FLAG", "0");  //일반취소

            clsSecureDLL.SetData("TRAN_NO", pCard.tran_serial);

            clsSecureDLL.SetData("TOT_AMT", pCard.amount + "");


            clsSecureDLL.SetData("OTX_DT", pCard.tran_date.Substring(0, 6));

            clsSecureDLL.SetData("AUTH_NO", pCard.auth_no);



            int nRet = clsSecureDLL.TransData_Modal();

            // TransData 리턴값이 "-99"일 경우 거래중단
            if (nRet == -99)
            {

                mErrorMsg = "KCP TransData_Modal 오류.";
                return -1;
            }



            // 응답

            String ResCd = clsSecureDLL.GetData("RES_CD");
            String ResMag = clsSecureDLL.GetData("RES_MSG");

            
            // 정상 응답
            if (ResCd == "0000")
            {
                pCardCancel.biz_dt = mBizDate;
                pCardCancel.tran_type = "C";

                pCardCancel.tran_date = clsSecureDLL.GetData("OTX_DT");

                return 0;
            }
            else
            {
                mErrorMsg = ResMag;
                return -1;
            }
        }




    }
}
