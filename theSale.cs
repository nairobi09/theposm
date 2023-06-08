using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;



namespace thepos
{
    public class theSale
    {


        public struct CardTemp
        {
            public int amount;
            public string card_no;
            public string auth_no;
            public string install;
            public string card_name;
            public string isu_code;
        }



        public static Font font8;
        public static Font font9;
        public static Font font10;
        public static Font font12;
        public static Font font13;
        public static Font font14;
        public static Font font16;
        public static Font font20;

        public static PrivateFontCollection fontCollection = new PrivateFontCollection();



        // //////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // 로그인후 다운로드되어야할 환경값들
        //


        //인증후 로컬저장
        public static String mSiteId = "";
        public static String mPosNo = "";



        // 실행시 로컬 생성데이터
        public static String mBussinessDate = "";
        public static String mMacAddr = "";
        public static String mTheNo = "";  // mTheNo : 선생성 - 후반영



        //------------------------------------------------------------------------------
        // 서버다운로드
        public static String[] mPosNoList; // 이사업자의 포스번호 목록

        public static String mSiteName;         // 매장명

        public static String mRepresentativeName;   // 대표자명
        public static String mRegistrationNo;       // 사업자번호
        public static String mAddress;              // 주소

        // (후불) 발권  사용  정산 [락커]
        // (선불) 발권 [충전] 사용  정산
        // 발권형태 : 선불형 AP-advanced payment  후불형 DP-deferred payment
        public static String mTicketType;  // ""미사용, "AP"선불, "DP"후불

        // 주문서 - 상품정보 필드관리
        public static String mCornerType;  // 주문서 관리 - ""미사용, "E"단순일체형, "P"분리형
        public static String[] mCornerCode; // 코너 코드
        public static String[] mCornerName; // 코너 명






        //-------------------------------------------------------------------------------------





        //
        // 로컬 + 서버
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
            public String ticket; // 일반상품 0. 티켓상품 1
            public String taxfree; // 과세품 0, 면세품 1
            public int column;
            public int row;
            public int columnspan;
            public int rowspan;
        }
        public static  GoodsItem[] mGoodsItem;


        // 로컬
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


        //? 서버
        public struct dbOrder
        {
            public String the_no;       // 
            public String order_date;
            public String order_time;
            public String customer_id;
            public String pos_no;
            public int cnt;             // 항목수
            public String is_cancel;    // Y
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
            public String is_cancel;    // Y
        }
        public static List<dbOrderItem> listOrderItem = new List<dbOrderItem>();



        // 서버
        public struct Payment
        {
            public String the_no;
            public String business_dt;  // yyyyMMdd
            public String pay_date;
            public String pay_time;
            public String tran_type;    // 승인 A, 취소 C
            public String pay_class;    // Order 0, charge 1, settlement 2
            public string pos_no;
            public String serial_no;    // 4자리 
            public int net_amount;
            public int amount_cash;
            public int amount_card;
            public int amount_easy;
            public String is_dc;       // 할인여부
            public String is_cancel;   // 취소여부 : 미취소"", 취소중0, 취소1
        }
        public static List<Payment> mPayments = new List<Payment>();

        public struct PaymentCard
        {
            public String the_no;
            public int pay_seq;
            public String business_dt;
            public String pay_date;
            public String pay_time;
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
            public String tran_serial;          // tran_serial -> 취소시 tid입력
            public String sign_path;
            public String is_cancel;    // 취소여부 : "" or "1"
        }
        public static List<PaymentCard> mPaymentCards = new List<PaymentCard>();

        public struct PaymentCash
        {
            public String the_no;
            public int pay_seq;
            public String business_dt;
            public String pay_date;
            public String pay_time;
            public String pay_type;     // 결제구분 : 단순현금(R0), 현금영수중(R1), 임의등록(R9)
            public String tran_type;    // 승인 A 취소 C
            public String tran_date;
            public int amount;          // 결제금액
            public String receipt_type; // 현금영수증 : 개인 소득공제 1 사업자 지출증빙 2
            public String issued_method_no;  // 현금영수증 고객 식별번호
            public String auth_no;      // 승인번호
            public String tran_serial;          // tran_serial -> 취소시 tid입력
            public String is_cancel;    // 취소여부
        }
        public static List<PaymentCash> mPaymentCashs = new List<PaymentCash>();




        public struct PaymentPoint           // 선불 포인트 사용
        {
            public String ticket_no;
            public String the_no;
            public String pay_date;
            public String pay_time;
            public String pay_type;     // 결제구분 : 포인트(P1)
            public String tran_type;    // 승인 A 취소 C
            public int amount;          // 금액
            public String is_cancel;    // 취소여부


        }





        public struct Cert
        {
            public String the_no;       // 
        }




        // 발권상품(Order), 인증(Cert)시점 -> TicketFlow 레코드 생성(초기값)
        public struct TicketFlow
        {
            public String the_no;           
            public String ticket_no;
            public String business_dt;

            public DateTime ticketing_dt;   // 발권일시
            public DateTime charge_dt;      // 충전일시
            public DateTime settlement_dt;  // 정산일시

            public int point_charge;        // 충전금액
            public int point_usage;         // 사용금액(누적)

            public String flow_step;      // 진행상황 : 접수0 - 발급1 - *충전2 - 사용3 - 정산(완료)4 : 정산완료일 경우 라커를 오픈한다.
            
            public String locker_no;        // 추가
            public String open_locker;      // 락커 수동 설정 : 0 폐쇄(기본값), 1 개방
                                            // 정산완료  or 수동 개방상태 -> 락커오픈
        }
        public static List<TicketFlow> mTicketFlow = new List<TicketFlow>();







        //
        public static Boolean mReturn = false;
        public static string mErrorMsg = "";


        public static String get_MMddHHmm(String d, String t)
        {
            return d.Substring(4,2) + "-" + d.Substring(6, 2) + " " + t.Substring(0, 2) + ":" + t.Substring(2, 2);
        }

        public static String get_today_date()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }

        public static String get_today_time()
        {
            return DateTime.Now.ToString("HHmmss");
        }



        public static String get_pay_type_name(String code)
        {
            String name = "";
            if (code == "C1") name = "카드승인결제";
            else if (code == "C9") name = "카드임의등록";
            else if (code == "R0") name = "단순현금";
            else if (code == "R1") name = "현금영수증";
            else if (code == "R9") name = "임의등록";
            return name;
        }

        public static String get_tran_type_name(String code)
        {
            String name = "";
            if (code == "A") name = "승인";
            else if (code == "C") name = "취소";
            return name;
        }

        public static String get_is_cancel_name(String code)
        {
            String name = "";
            if (code == "0") name = "취소중";
            //else if (code == "Y") name = "Y";
            else name = code;

            return name;
        }


    }
}
