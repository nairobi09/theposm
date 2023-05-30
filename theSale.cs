using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static thepos.theSale;


namespace thepos
{
    public class theSale
    {
        // 토스결제Agent연동
        [DllImport("C:\\TossPGPos\\TossPGPOSClient64.dll", EntryPoint = "UPay_Init", CallingConvention = CallingConvention.StdCall)]
        extern static int UPay_Init();
        [DllImport("C:\\TossPGPos\\TossPGPOSClient64.dll", EntryPoint = "UPay_Set", CallingConvention = CallingConvention.StdCall)]
        extern static int UPay_Set(string name, string value);
        [DllImport("C:\\TossPGPos\\TossPGPOSClient64.dll", EntryPoint = "UPay_TX", CallingConvention = CallingConvention.StdCall)]
        extern static int UPay_TX();
        [DllImport("C:\\TossPGPos\\TossPGPOSClient64.dll", EntryPoint = "UPayResNameCount", CallingConvention = CallingConvention.StdCall)]
        extern static int UPayResNameCount();
        [DllImport("C:\\TossPGPos\\TossPGPOSClient64.dll", EntryPoint = "UPayResName", CallingConvention = CallingConvention.StdCall)]
        extern static IntPtr UPayResName(int index);
        [DllImport("C:\\TossPGPos\\TossPGPOSClient64.dll", EntryPoint = "UPayResponse", CallingConvention = CallingConvention.StdCall)]
        extern static IntPtr UPayResponse(int index);
        [DllImport("C:\\TossPGPos\\TossPGPOSClient64.dll", EntryPoint = "UPayFinal", CallingConvention = CallingConvention.StdCall)]
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




        public static Font font8;
        public static Font font9;
        public static Font font10;
        public static Font font12;
        public static Font font14;
        public static Font font16;
        public static Font font20;

        public static PrivateFontCollection fontCollection = new PrivateFontCollection();



        // //////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // 로그인후 다운로드되어야할 환경값들
        //
        public static String mCustomerId = "";
        public static String mPosNo = "";
        public static String mBussinessDate = "";

        // mTheNo : 선생성 - 후반영
        public static String mTheNo = "";


        // (후불) 발권  사용  정산 [락커]
        // (선불) 발권 [충전] 사용  정산

        // 발권형태 : 선불형 AP-advanced payment  후불형 DP-deferred payment
        public static String mTicketType;  // "AP" "DP"

        // 가맹점의 POS_ID 목록
        public static String[] mCustomerPosNOs;




        //
        // 서버관리
        public struct GoodsGroup
        {
            public string code;  // 3
            public string name;
            public int column;
            public int row;
            public int columnspan;
            public int rowspan;
        }
        public static GoodsGroup[] mGoodsGroup;

        public struct GoodsItem
        {
            public string code;  // 6
            public string name;
            public int amt;
            public String ticket; // 일반상품 0 티켓상품 1
            public String taxfree; // 면세품:"1", 과세:"" 등
            public int column;
            public int row;
            public int columnspan;
            public int rowspan;
        }
        public static  GoodsItem[] mGoodsItem;



        public struct Order
        {
            public int order_no;        // 대기번호 [대기]을 위해
            public DateTime dt;         // 대기일시
            public int cnt;             // 항목수
            public int amount;          // 합계
        }
        public static List<Order> listWaiting = new List<Order>();

        public struct OrderItem
        {
            public int order_no;       // 대기번호 [대기]을 위해
            public String code;         // 상품code(6) or 전체할인코드고정("EDC")
            public String name;         // 상품name or 전체할인명("할인")
            public int cnt;
            public int amt;
            public String ticket;
            public String taxfree;
            public int dc_amount;       // 실할인금액
            public String dcr_type;     // type - "A" : 정액, "R" : 정율 
            public String dcr_des;      // 전체"E", 선택"S"
            public int dcr_value;       // 할인금액 or 할인율
        }
        public static List<OrderItem> listWaitingItem = new List<OrderItem>();


        //? 서버API로 대체한다.
        public struct dbOrder
        {
            public String the_no;          // 
            public DateTime dt;         // 대기일시
            public String customer_id;
            public String pos_no;
            public int cnt;             // 항목수
        }
        public static List<dbOrder> listOrder = new List<dbOrder>();

        public struct dbOrderItem
        {
            public String the_no;       // 
            public String code;         // 상품code(6) or 전체할인코드고정("EDC")
            public String name;         // 상품name or 전체할인명("할인")
            public int cnt;
            public int amt;
            public String ticket;
            public String taxfree;
            public int dc_amount;       // 실할인금액
            public String dcr_type;     // type - "A" : 정액, "R" : 정율 
            public String dcr_des;      // 전체"E", 선택"S"
            public int dcr_value;       // 할인금액 or 할인율
        }
        public static List<dbOrderItem> listOrderItem = new List<dbOrderItem>();


        public static string mErrorMsg = "";






        public struct Cert
        {
            public String the_no;       // 
        }


        public struct FlowTicket
        {
            public String the_no;           // 

            public String ticket_no;

            public DateTime ticketing_dt;   // 발권일시
            public DateTime charge_dt;      // 충전일시
            public DateTime settlement_dt;  // 정산일시

            public int charge_point;        // 충전금액
            public int usage_point;         // 사용금액(누적)

            public String ticket_step;      // 진행상황 : 접수0 - 발급1 - *충전2 - 사용3 - 정산(완료)4 : 정산완료일 경우 라커를 오픈한다.
            public String open_locker;      // 락커 수기 개방 설정 0:폐쇄(기본값), 1:개방
        }




        public struct Payment
        {
            public String the_no;
            public String business_dt;  // yyyyMMdd
            public DateTime dt;
            public String tran_type;    // 승인 A, 취소 C
            public String pay_class;    // Order 0, charge 1, settlement 2
            public string pos_no;
            public String serial_no;    // 4자리 
            public int net_amount;
            public int amount_cash;
            public int amount_card;
            public int amount_point;
            public String is_dc;       // 할인여부
            public String is_cancel;   // 취소여부
        }
        public static List<Payment> mPayments = new List<Payment>();

        public struct PaymentCard
        {
            public String the_no;       // 
            public String business_dt;
            public DateTime dt;
            public String pay_type;     // 결제구분 : 신용카드(C1), 임의등록(C9)
            public String tran_type;    // 승인 A 취소 C
            public String tran_date;
            public int amount;          // 결제금액
            public String install;      // 할부개월 00 03
            public String auth_no;      // 승인번호
            public String card_no;      // 카드번호
            public String card_name;    // 카드종류
            public String isu_code;     // 발급사코드
            public String acq_code;     // 매입사코드
            public String merchant_no;  // 가맹점번호
            public String tid;          // tran_serial -> 취소시 tid입력
            public String is_cancel;    // 취소여부
        }
        public static List<PaymentCard> mPaymentCards = new List<PaymentCard>();

        public struct PaymentCash
        {
            public String the_no;       // 
            public String business_dt;
            public DateTime dt;
            public String pay_type;     // 결제구분 : 단순현금(R0), 현금영수중(R1), 임의등록(R9)
            public String tran_type;    // 승인 A 취소 C
            public String tran_date;
            public int amount;          // 결제금액
            public String receipt_type; // 현금영수증 : 개인 소득공제 1 사업자 지출증빙 2
            public String cashcard_no;  // 현금영수증 고객 식별번호
            public String auth_no;      // 승인번호
            public String tid;          // tran_serial -> 취소시 tid입력
            public String is_cancel;    // 취소여부
        }
        public static List<PaymentCash> mPaymentCashs = new List<PaymentCash>();

        public struct PaymentPoint           // 선불 후불 사용
        {
            public String the_no;       // 
            public DateTime dt;
            public String pay_type;     // 결제구분 : 포인트(P0)
            public String tran_type;    // 승인 A 취소 C
            public String tran_date;
            public int amount;          // 금액
            public String ticket_no;
            public String is_cancel;    // 취소여부
        }



        public static int requestTossCardAuth(int amount, int install)
        {
            int ret = 0;

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
            ret = UPay_Set("LGD_OID", mCustomerId + mPosNo + randomValue);
            ret = UPay_Set("LGD_AMOUNT", amount.ToString());
            ret = UPay_Set("LGD_INSTALL", install.ToString("00"));
            ret = UPay_Set("LGD_TAXFREEAMOUNT", "0");
            ret = UPay_Set("LGD_VAT", "0");
            ret = UPay_Set("VAN_SFEEAMOUNT", "0");
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

            if (mTossResponse.Respcode == "00")
            {
                return 0;
            }
            else
            {
                mErrorMsg = mTossResponse.Msg;
                return -1;
            }
        }


        public static int requestTossCardCancel(PaymentCard pCard)
        {
            int ret = 0;

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
            ret = UPay_Set("LGD_REQTYPE", "CANCEL");
            //ret = UPay_Set("LGD_MID", "");

            ret = UPay_Set("LGD_AMOUNT", pCard.amount.ToString());
            ret = UPay_Set("LGD_INSTALL", pCard.install);
            ret = UPay_Set("LGD_TID", pCard.tid);
            ret = UPay_Set("LGD_TAXFREEAMOUNT", "0");
            ret = UPay_Set("LGD_VAT", "0");
            ret = UPay_Set("VAN_SFEEAMOUNT", "0");
            ret = UPay_Set("VAN_TRANTYPE", "S1");  // S0 승인, S1 취소
            ret = UPay_Set("VAN_CAPDATE", pCard.tran_date);
            ret = UPay_Set("VAN_AUTHNO", pCard.auth_no);


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

            if (mTossResponse.Respcode == "00")
            {
                return 0;
            }
            else
            {
                mErrorMsg = mTossResponse.Msg;
                return -1;
            }
        }

        public static void SaveTossCardAuth(TossResponse mTossResponse)
        {
            Payment mPayment = new Payment();
            mPayment.the_no = mTheNo;
            mPayment.dt = DateTime.Now;
            mPayment.business_dt = mBussinessDate;
            mPayment.tran_type = "A";
            mPayment.pay_class = "0";    // Order 0, charge 1, settlement 2
            mPayment.pos_no = mPosNo;
            mPayment.serial_no = mTheNo.Substring(14, 4);
            mPayment.net_amount += int.Parse(mTossResponse.Tamt);
            mPayment.amount_cash = 0;
            mPayment.amount_card += int.Parse(mTossResponse.Tamt);
            mPayment.amount_point = 0;
            mPayment.is_dc = "";       // 할인여부
            mPayment.is_cancel = "";   // 취소여부
            mPayments.Add(mPayment);

            PaymentCard mPaymentCard = new PaymentCard();
            mPaymentCard.the_no = mTheNo;
            mPaymentCard.business_dt = mBussinessDate;
            mPaymentCard.dt = DateTime.Now;
            mPaymentCard.pay_type = "C1";       // 결제구분 : , 현금영수중(C1), 임의등록(C9)
            mPaymentCard.tran_type = "A";       // 승인 A 취소 C
            mPaymentCard.tran_date = mTossResponse.Trandate;
            mPaymentCard.amount = int.Parse(mTossResponse.Tamt);
            mPaymentCard.card_no = mTossResponse.Cardno;
            mPaymentCard.auth_no = mTossResponse.Authno;
            mPaymentCard.install = mTossResponse.Halbu;
            mPaymentCard.card_name = mTossResponse.Financename;
            mPaymentCard.isu_code = mTossResponse.Stlinst;
            mPaymentCard.acq_code = mTossResponse.Reqinst;
            mPaymentCard.merchant_no = mTossResponse.Merno;
            mPaymentCard.tid = mTossResponse.Tran_serial;              // tran_serial -> 취소시 tid입력
            mPaymentCard.is_cancel = "";        // 취소여부
            mPaymentCards.Add(mPaymentCard);
        }

        public static void SaveTossCardCancel(PaymentCard mPaymentCardOriginAuth, TossResponse mTossResponse)
        {
            // mPaymentCardOriginAuth  <- 원승인거래

            Payment mPayment = new Payment();
            mPayment.the_no = mTheNo;
            mPayment.dt = DateTime.Now;
            mPayment.business_dt = mPaymentCardOriginAuth.business_dt;
            mPayment.tran_type = "C";
            mPayment.pay_class = "0";    // Order 0, charge 1, settlement 2
            mPayment.pos_no = mPosNo;
            mPayment.serial_no = mTheNo.Substring(14, 4);
            mPayment.net_amount += int.Parse(mTossResponse.Tamt);
            mPayment.amount_cash = 0;
            mPayment.amount_card += int.Parse(mTossResponse.Tamt);
            mPayment.amount_point = 0;
            mPayment.is_dc = "";       // 할인여부
            mPayment.is_cancel = "";   // 취소여부
            mPayments.Add(mPayment);

            PaymentCard mPaymentCard = new PaymentCard();
            mPaymentCard.the_no = mTheNo;
            mPaymentCard.business_dt = mPaymentCardOriginAuth.business_dt;
            mPaymentCard.dt = DateTime.Now;
            mPaymentCard.pay_type = "C1";       // 결제구분 : , 카드승인(C1), 임의등록(C9)
            mPaymentCard.tran_type = "C";       // 승인 A 취소 C
            mPaymentCard.tran_date = mTossResponse.Trandate;
            mPaymentCard.amount = int.Parse(mTossResponse.Tamt);
            mPaymentCard.card_no = mTossResponse.Cardno;
            mPaymentCard.auth_no = mTossResponse.Authno;
            mPaymentCard.install = mTossResponse.Halbu;
            mPaymentCard.card_name = mTossResponse.Financename;
            mPaymentCard.isu_code = mTossResponse.Stlinst;
            mPaymentCard.acq_code = mTossResponse.Reqinst;
            mPaymentCard.merchant_no = mTossResponse.Merno;
            mPaymentCard.tid = mTossResponse.Tran_serial;              // tran_serial -> 취소시 tid입력
            mPaymentCard.is_cancel = "";        // 취소여부
            mPaymentCards.Add(mPaymentCard);
        }

        public static void SetCancelOrderAndPayment(String theno)
        {




        }

    }
}
