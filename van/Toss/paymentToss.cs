using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static thepos.thePos;

namespace thepos
{
    internal class paymentToss
    {
        // 토스결제Agent연동

        [DllImport("C:\\TossPGPos\\TossPGPOSClient.dll", EntryPoint = "UPay_Init", CallingConvention = CallingConvention.StdCall)]
        extern static int UPay_Init();
        [DllImport("C:\\TossPGPos\\TossPGPOSClient.dll", EntryPoint = "UPay_Set", CallingConvention = CallingConvention.StdCall)]
        extern static int UPay_Set(string name, string value);
        [DllImport("C:\\TossPGPos\\TossPGPOSClient.dll", EntryPoint = "UPay_TX", CallingConvention = CallingConvention.StdCall)]
        extern static int UPay_TX();
        [DllImport("C:\\TossPGPos\\TossPGPOSClient.dll", EntryPoint = "UPayResNameCount", CallingConvention = CallingConvention.StdCall)]
        extern static int UPayResNameCount();
        [DllImport("C:\\TossPGPos\\TossPGPOSClient.dll", EntryPoint = "UPayResName", CallingConvention = CallingConvention.StdCall)]
        extern static IntPtr UPayResName(int index);
        [DllImport("C:\\TossPGPos\\TossPGPOSClient.dll", EntryPoint = "UPayResponse", CallingConvention = CallingConvention.StdCall)]
        extern static IntPtr UPayResponse(int index);
        [DllImport("C:\\TossPGPos\\TossPGPOSClient.dll", EntryPoint = "UPayFinal", CallingConvention = CallingConvention.StdCall)]
        extern static int UPayFinal();




        public struct TossResponse
        {
            public String Respcode;
            public string Msg;
            public string Trancode;
            public string Mid;
            public string Oid;
            public string Tamt;
            public string Tran_serial;
            public string Trandate;
            public string Financecode;
            public string Financename;
            public string Cardno;
            public string Halbu;
            public string Authno;
            public string Stlinst;
            public string Reqinst;
            public string Merno;
            public string Signpath;
            public string Cardgubun;
            public string Giftchange;
        }
        public static TossResponse mTossResponse = new TossResponse();



        public int requestTossCardAuth(int tAmount, int tFreeAmount, int tTaxAmount, int tTax, int tServiceAmt, int install, out PaymentCard mPaymentCard)
        {
            int ret = 0;

            PaymentCard paymentCard = new PaymentCard();
            mPaymentCard = paymentCard;



            try
            {
                ret = UPay_Init();
            }
            catch (Exception e)
            {
                mErrorMsg = e.Message;
                return -1;
            }

            if (ret == -9)
            {
                mErrorMsg = "Toss DLL 초기화 오류";
                return -1;
            }

            Random random = new Random();
            int randomValue = random.Next(10000000, 99999999);

            ret = UPay_Set("LGD_TXNAME", "CardAuthOfflinePos");
            ret = UPay_Set("LGD_REQTYPE", "APPR");
            //ret = UPay_Set("LGD_MID", "");
            ret = UPay_Set("LGD_OID", mSiteId + mPosNo + randomValue);
            ret = UPay_Set("LGD_AMOUNT", tAmount.ToString());
            ret = UPay_Set("LGD_INSTALL", install.ToString("00"));


            ret = UPay_Set("LGD_TAXFREEAMOUNT", tFreeAmount.ToString());
            ret = UPay_Set("LGD_VAT", tTax.ToString());
            ret = UPay_Set("VAN_SFEEAMOUNT", tServiceAmt.ToString());
            ret = UPay_Set("VAN_TRANTYPE", "S0");  // S0 승인

            ret = UPay_TX();

            if (ret != 0)
            {
                if (ret == -9) mErrorMsg = "Toss 내부 클래스 없음";
                else if (ret == -2) mErrorMsg = "TossPaymentsPOS와 connect 실패";
                else if (ret == -3) mErrorMsg = "TossPaymentsPOS에 전송 실패";
                else if (ret == -4) mErrorMsg = "TossPaymentsPOS 결과 대기 타임아웃";
                else if (ret == -5) mErrorMsg = "TossPaymentsPOS 결과 수신 실패";

                return -1;
            }

            int cnt = UPayResNameCount();

            string display_msg = "";

            String name;
            String value;

            for (int i = 0; i < cnt; i++)
            {
                name = Marshal.PtrToStringAnsi(UPayResName(i));
                value = Marshal.PtrToStringAnsi(UPayResponse(i));

                // 응답메시지 파싱
                if (name == "Respcode") mTossResponse.Respcode = value;
                else if (name == "Msg") mTossResponse.Msg = value;
                else if (name == "Trancode") mTossResponse.Trancode = value;
                else if (name == "Mid") mTossResponse.Mid = value;
                else if (name == "Oid") mTossResponse.Oid = value;
                else if (name == "Tamt") mTossResponse.Tamt = value;
                else if (name == "Tran_serial") mTossResponse.Tran_serial = value; //최소필요 TID
                else if (name == "Trandate") mTossResponse.Trandate = value;       //취소필요 원거래일
                else if (name == "Financecode") mTossResponse.Financecode = value; // 카드사코드
                else if (name == "Financename") mTossResponse.Financename = value; // 카드명
                else if (name == "Cardno") mTossResponse.Cardno = value;
                else if (name == "Halbu") mTossResponse.Halbu = value;
                else if (name == "Authno") mTossResponse.Authno = value;
                else if (name == "Stlinst") mTossResponse.Stlinst = value;
                else if (name == "Reqinst") mTossResponse.Reqinst = value;
                else if (name == "Merno") mTossResponse.Merno = value;
                else if (name == "Signpath") mTossResponse.Signpath = value;
                else if (name == "Cardgubun") mTossResponse.Cardgubun = value;
                else if (name == "Giftchange") mTossResponse.Giftchange = value;

                display_msg += name + ": " + value + "\n";
            }
            // TossPaymentsPOS_Client 자원반환
            ret = UPayFinal();

            if (mTossResponse.Respcode == "0000")
            {
                mPaymentCard.tran_date = mTossResponse.Trandate;
                mPaymentCard.amount = int.Parse(mTossResponse.Tamt);
                mPaymentCard.install = mTossResponse.Halbu;
                mPaymentCard.auth_no = mTossResponse.Authno;
                mPaymentCard.card_no = mTossResponse.Cardno;
                mPaymentCard.card_name = mTossResponse.Financename;

                //? 발급사,매입사 코드 -> 공통관리코드로 변환 필요
                mPaymentCard.isu_code = mTossResponse.Stlinst;
                mPaymentCard.acq_code = mTossResponse.Reqinst;

                mPaymentCard.merchant_no = mTossResponse.Merno;
                mPaymentCard.tran_serial = mTossResponse.Tran_serial;              // tran_serial -> 취소시 tid입력
                mPaymentCard.sign_path = mTossResponse.Signpath;


                return 0;
            }
            else
            {
                mErrorMsg = mTossResponse.Msg;
                return -1;
            }
        }



        public int requestTossCardCancel(PaymentCard pCardAuth, out PaymentCard pCardCancel)
        {
            int ret = 0;
            pCardCancel = pCardAuth;


            try
            {
                ret = UPay_Init();
            }
            catch (Exception e)
            {
                mErrorMsg = e.Message;
                return -1;
            }


            if (ret == -9)
            {
                mErrorMsg = "Toss DLL 초기화 오류";
                return -1;
            }


            ret = UPay_Set("LGD_TXNAME", "CardAuthOfflinePos");
            ret = UPay_Set("LGD_REQTYPE", "CANCEL");
            //ret = UPay_Set("LGD_MID", "");

            ret = UPay_Set("LGD_AMOUNT", pCardAuth.amount.ToString());
            ret = UPay_Set("LGD_INSTALL", pCardAuth.install);
            ret = UPay_Set("LGD_TID", pCardAuth.tran_serial);
            ret = UPay_Set("LGD_TAXFREEAMOUNT", "0");
            ret = UPay_Set("LGD_VAT", "0");
            ret = UPay_Set("VAN_SFEEAMOUNT", "0");
            ret = UPay_Set("VAN_TRANTYPE", "S1");  // S0 승인, S1 취소
            ret = UPay_Set("VAN_CAPDATE", pCardAuth.tran_date);
            ret = UPay_Set("VAN_AUTHNO", pCardAuth.auth_no);


            ret = UPay_TX();

            if (ret != 0)
            {
                if (ret == -9) mErrorMsg = "Toss 내부 클래스 없음";
                else if (ret == -2) mErrorMsg = "TossPaymentsPOS와 connect 실패";
                else if (ret == -3) mErrorMsg = "TossPaymentsPOS에 전송 실패";
                else if (ret == -4) mErrorMsg = "TossPaymentsPOS 결과 대기 타임아웃";
                else if (ret == -5) mErrorMsg = "TossPaymentsPOS 결과 수신 실패";

                return -1;
            }

            int cnt = UPayResNameCount();

            string display_msg = "";

            String name;
            String value;

            for (int i = 0; i < cnt; i++)
            {
                name = Marshal.PtrToStringAnsi(UPayResName(i));
                value = Marshal.PtrToStringAnsi(UPayResponse(i));

                // 응답메시지 파싱
                //? 할부 승인번호 등 파싱 추가검증 필요
                if (name == "Respcode") mTossResponse.Respcode = value;
                else if (name == "Msg") mTossResponse.Msg = value;
                else if (name == "Trancode") mTossResponse.Trancode = value;
                else if (name == "Mid") mTossResponse.Mid = value;
                else if (name == "Oid") mTossResponse.Oid = value;
                else if (name == "Tamt") mTossResponse.Tamt = value;
                else if (name == "Tran_serial") mTossResponse.Tran_serial = value; //최소필요 TID
                else if (name == "Trandate") mTossResponse.Trandate = value;       //취소필요 원거래일
                else if (name == "Financecode") mTossResponse.Financecode = value; // 카드사코드
                else if (name == "Financename") mTossResponse.Financename = value; // 카드명
                else if (name == "Cardno") mTossResponse.Cardno = value;
                else if (name == "Halbu") mTossResponse.Halbu = value;
                else if (name == "Authno") mTossResponse.Authno = value;
                else if (name == "Stlinst") mTossResponse.Stlinst = value;
                else if (name == "Reqinst") mTossResponse.Reqinst = value;
                else if (name == "Merno") mTossResponse.Merno = value;
                else if (name == "Signpath") mTossResponse.Signpath = value;
                else if (name == "Cardgubun") mTossResponse.Cardgubun = value;
                else if (name == "Giftchange") mTossResponse.Giftchange = value;

                display_msg += name + ": " + value + "\n";
            }
            // TossPaymentsPOS_Client 자원반환
            ret = UPayFinal();

            if (mTossResponse.Respcode == "0000")
            {
                pCardCancel.tran_date = mTossResponse.Trandate;
                pCardCancel.amount = int.Parse(mTossResponse.Tamt);
                pCardCancel.card_no = mTossResponse.Cardno;
                pCardCancel.isu_code = mTossResponse.Stlinst;
                pCardCancel.acq_code = mTossResponse.Reqinst;
                pCardCancel.merchant_no = mTossResponse.Merno;
                pCardCancel.tran_serial = mTossResponse.Tran_serial;     // tran_serial -> 취소시 tid입력


                return 0;
            }
            else
            {
                mErrorMsg = mTossResponse.Msg;
                return -1;
            }
        }


        public int requestTossCashAuth(int amount, String receipt_type, String issued_method_no, out PaymentCash mPaymentCash)
        {
            int ret = 0;

            PaymentCash paymentCash = new PaymentCash();
            mPaymentCash = paymentCash;


            try
            {
                ret = UPay_Init();
            }
            catch (Exception e)
            {
                mErrorMsg = e.Message;
                return -1;
            }

            if (ret == -9)
            {
                mErrorMsg = "Toss DLL 초기화 오류";
                return -1;
            }

            Random random = new Random();
            int randomValue = random.Next(10000000, 99999999);

            ret = UPay_Set("LGD_TXNAME", "CardAuthOfflinePos");
            ret = UPay_Set("LGD_REQTYPE", "CASHAPPR");
            ret = UPay_Set("LGD_PAYTYPE", "SC0100");
            //ret = UPay_Set("LGD_MID", "");
            ret = UPay_Set("LGD_OID", mSiteId + mPosNo + randomValue);
            ret = UPay_Set("LGD_AMOUNT", amount.ToString());


            if (issued_method_no != "")
            {
                ret = UPay_Set("LGD_CASHCARDNUM", issued_method_no);
            }


            ret = UPay_Set("LGD_CASHRECEIPTUSE", receipt_type);
            //ret = UPay_Set("LGD_CUSTOM_BUSINESSNUM", "");

            ret = UPay_Set("LGD_SEQNO", "001");

            ret = UPay_Set("LGD_TAXFREEAMOUNT", "0");
            ret = UPay_Set("LGD_VAT", "0");
            ret = UPay_Set("VAN_SFEEAMOUNT", "0");
            ret = UPay_Set("VAN_TRANTYPE", "41");

            ret = UPay_TX();

            if (ret != 0)
            {
                if (ret == -9) mErrorMsg = "Toss 내부 클래스 없음";
                else if (ret == -2) mErrorMsg = "TossPaymentsPOS와 connect 실패";
                else if (ret == -3) mErrorMsg = "TossPaymentsPOS에 전송 실패";
                else if (ret == -4) mErrorMsg = "TossPaymentsPOS 결과 대기 타임아웃";
                else if (ret == -5) mErrorMsg = "TossPaymentsPOS 결과 수신 실패";

                return -1;
            }

            int cnt = UPayResNameCount();

            string display_msg = "";

            String name;
            String value;

            for (int i = 0; i < cnt; i++)
            {
                name = Marshal.PtrToStringAnsi(UPayResName(i));
                value = Marshal.PtrToStringAnsi(UPayResponse(i));

                // 응답메시지 파싱
                if (name == "Respcode") mTossResponse.Respcode = value;
                else if (name == "Msg") mTossResponse.Msg = value;
                else if (name == "Trancode") mTossResponse.Trancode = value;
                else if (name == "Mid") mTossResponse.Mid = value;
                else if (name == "Oid") mTossResponse.Oid = value;
                else if (name == "Tamt") mTossResponse.Tamt = value;
                else if (name == "Tran_serial") mTossResponse.Tran_serial = value; //최소필요 TID
                else if (name == "Trandate") mTossResponse.Trandate = value;       //취소필요 원거래일
                else if (name == "Cardno") mTossResponse.Cardno = value;
                else if (name == "Authno") mTossResponse.Authno = value;

                display_msg += name + ": " + value + "\n";
            }
            // TossPaymentsPOS_Client 자원반환
            ret = UPayFinal();

            if (mTossResponse.Respcode == "0000")
            {
                paymentCash.tran_date = mTossResponse.Trandate;
                paymentCash.issued_method_no = mTossResponse.Cardno;
                paymentCash.auth_no = mTossResponse.Authno;
                paymentCash.tran_serial = mTossResponse.Tran_serial;

                return 0;
            }
            else
            {
                mErrorMsg = mTossResponse.Msg;
                return -1;
            }
        }


        public int requestTossCashCancel(PaymentCash pCash, out PaymentCash pCashCancel)
        {
            int ret = 0;
            PaymentCash cashCancel = new PaymentCash();
            pCashCancel = cashCancel;


            try
            {
                ret = UPay_Init();
            }
            catch (Exception e)
            {
                mErrorMsg = e.Message;
                return -1;
            }


            if (ret == -9)
            {
                mErrorMsg = "Toss DLL 초기화 오류";
                return -1;
            }


            ret = UPay_Set("LGD_TXNAME", "CardAuthOfflinePos");
            ret = UPay_Set("LGD_REQTYPE", "CASHCANCEL");
            //ret = UPay_Set("LGD_MID", "");
            ret = UPay_Set("LGD_PAYTYPE", "SC0100");
            ret = UPay_Set("LGD_AMOUNT", pCash.amount.ToString());
            ret = UPay_Set("LGD_CASHRECEIPTUSE", pCash.issued_method_no);
            ret = UPay_Set("LGD_TID", pCash.tran_serial);
            ret = UPay_Set("LGD_SEQNO", "001");
            ret = UPay_Set("LGD_TAXFREEAMOUNT", "0");
            ret = UPay_Set("LGD_VAT", "0");
            ret = UPay_Set("VAN_SFEEAMOUNT", "0");
            ret = UPay_Set("VAN_TRANTYPE", "42");
            ret = UPay_Set("VAN_CAPDATE", pCash.tran_date);
            ret = UPay_Set("VAN_AUTHNO", pCash.auth_no);

            ret = UPay_TX();

            if (ret != 0)
            {
                if (ret == -9) mErrorMsg = "Toss 내부 클래스 없음";
                else if (ret == -2) mErrorMsg = "TossPaymentsPOS와 connect 실패";
                else if (ret == -3) mErrorMsg = "TossPaymentsPOS에 전송 실패";
                else if (ret == -4) mErrorMsg = "TossPaymentsPOS 결과 대기 타임아웃";
                else if (ret == -5) mErrorMsg = "TossPaymentsPOS 결과 수신 실패";

                return -1;
            }

            int cnt = UPayResNameCount();

            string display_msg = "";

            String name;
            String value;

            for (int i = 0; i < cnt; i++)
            {
                name = Marshal.PtrToStringAnsi(UPayResName(i));
                value = Marshal.PtrToStringAnsi(UPayResponse(i));

                // 응답메시지 파싱
                //? 할부 승인번호 등 파싱 추가검증 필요
                if (name == "Respcode") mTossResponse.Respcode = value;
                else if (name == "Msg") mTossResponse.Msg = value;
                else if (name == "Trancode") mTossResponse.Trancode = value;
                else if (name == "Mid") mTossResponse.Mid = value;
                else if (name == "Tran_serial") mTossResponse.Tran_serial = value; //최소필요 TID
                else if (name == "Trandate") mTossResponse.Trandate = value;       //취소필요 원거래일
                else if (name == "Cardno") mTossResponse.Cardno = value;
                else if (name == "Authno") mTossResponse.Authno = value;

                display_msg += name + ": " + value + "\n";
            }
            // TossPaymentsPOS_Client 자원반환
            ret = UPayFinal();

            if (mTossResponse.Respcode == "0000")
            {
                pCashCancel.tran_date = mTossResponse.Trandate;
                pCashCancel.issued_method_no = mTossResponse.Cardno;
                pCashCancel.auth_no = mTossResponse.Authno;

                return 0;
            }
            else
            {
                mErrorMsg = mTossResponse.Msg;
                return -1;
            }
        }
    }
}