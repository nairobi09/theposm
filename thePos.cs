using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using PrinterUtility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO.Ports;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Security.Policy;
using System.Collections;
using System.IO;



//? 개발수정항목
/*



[일반POS] 

- 다국어 지원 : 영어 중국어 일본어
- x86 x64 - 밴DLL 관리 
- 고객용 모니터 화면 - 주문내역 




운영관리


- 원격지원 솔루션 - 헬프?
- 환경정보 관리
- 로그인


영업관리

- 영업일자 : 영업개시, 영업마감 관리
- 일집계
- 영업개시(수동), 영업마감(수동,자동), 중간마감(수동)




판매관리

- 결제시 금액관련 세팅
- 복합결제, 정산 화면 : frmSale.ConsoleEnable(); frmSale.ConsoleDisable(); 관리 안됨. 창위헤 창뜰경우 콘트롤 꼬임.

- 상품주문 전체할인 아이템 맨아래줄로 배치할 수 있도록 변경
- 외부 연동 : 결제채널 3사 - KCP/나이스/코밴, 플레이스엠 
- 영수증프린터, 바코드티지프린터, 스캐너 
- 락커 연동 : 후불인 경우

- 영수증인쇄 : 바코드 문자출력문제, port설정-처음실행시 먹통문제

- 코너관리
- 할인정책




[키오스크]




[웹어드민]




[시스어드민]

 



*/




namespace thepos
{
    public class thePos
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
        public static Font font12bold;
        public static Font font13;
        public static Font font14;
        public static Font font16;
        public static Font font20;

        public static PrivateFontCollection fontCollection = new PrivateFontCollection();



        // //////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // 로그인후 다운로드되어야할 환경값들
        //


        // 사용자 인증 절차




        // //////////////////////////////////////////////////////////////////////////////////////////
        // thepos 전체 설정

        // 콜센터 연락처
        public static String mCallCenterNo = "";





        // //////////////////////////////////////////////////////////////////////////////////////////
        // 사이트 설정값
        public static String mSiteId = "";
        public static String mSiteName;         // 매장명
        public static String mSiteAlias;        // 매장명
        public static String mCapName;          // 대표자명
        public static String mRegistNo;         // 사업자번호
        public static String mBizAddr;          // 주소
        public static String mBizTelNo;         // 대표전화


        // (후불) 발권  사용  정산 [락커]
        // (선불) 발권 [충전] 사용  정산
        // 발권형태 : 선불형 AP-advanced payment  후불형 DP-deferred payment
        public static String mTicketType;  // ""미사용, "PA"선불, "PD"후불
        public static String mTicketMedia;  // 띠지BC   팔찌RF
        public static String mPayChannel = "";


        // 이사업자의 포스번호 목록
        public static String[] mPosNoList; 


        // 주문서 - 상품정보 필드관리
        //? 코너타입은 사이트별 or 포스별??
        public static String mCornerType;  // 주문서 관리 - ""미사용, "E"단순일체형, "P"분리형
        public static String[] mCornerCode; // 코너 코드
        public static String[] mCornerName; // 코너 명






        // //////////////////////////////////////////////////////////////////////////////////////////
        /// 포스 설정값
        public static String mPosNo = "";

        public static string mBillPrinterPort = "COM7";  // 영수증프린터
        public static string mTicketMediaPort = "COM7";  // 띠지 or 팔찌

        public static string mClientType = "";  // P:일반포스, K:키오스크







        // //////////////////////////////////////////////////////////////////////////////////////////
        // 실행시 로컬 생성데이터
        public static String mBizDate = "";
        public static String mMacAddr = "";
        public static String mTheNo = "";  // 결제단위
        public static String mRefNo = "";  // 주문단위 입장단위
        
        // 실행중 로컬 운영
        public static String mScanString;
        public static bool mIsScanOK;


        public static string mUserID = "";
        public static string mUserName = "";


        public static CookieContainer cookies = new CookieContainer();
        public static HttpClientHandler handler = new HttpClientHandler();

        public static HttpClient mHttpClient;


        //public static HttpClient mHttpClient = new HttpClient();

        public static String mBaseUri = "http://211.42.156.219:8080/";



        // //////////////////////////////////////////////////////////////////////////////////////////
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
        public struct MemOrder
        {
            public int order_no;        // 대기번호 [대기]을 위해
            public DateTime dt;         // 대기일시
            public int cnt;             // 항목수
            public int amount;          // 합계
        }
        public static List<MemOrder> listWaiting = new List<MemOrder>();

        public struct MemOrderItem
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
            public String pay_class;
            public String ticket_no;     // 충전, 사용인경우
        }
        public static List<MemOrderItem> listWaitingItem = new List<MemOrderItem>();


        //? 서버
        public struct dbOrder
        {
            public String site_id;
            public String biz_dt;       // yyyyMMdd
            public String pos_no;
            public String the_no;       // 
            public String ref_no;       // 
            public String order_date;
            public String order_time;
            public int cnt;             // 항목수
            public String is_cancel;    // Y
        }
        public static List<dbOrder> listOrder = new List<dbOrder>();

        public struct dbOrderItem
        {
            public String site_id;
            public String biz_dt;       // yyyyMMdd
            public String pos_no;
            public String the_no;       // 
            public String ref_no;       // 
            public String order_date;
            public String order_time;
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
            public String pay_class;
            public String ticket_no;
            public String is_cancel;    // Y
        }
        public static List<dbOrderItem> listOrderItem = new List<dbOrderItem>();



        // 서버
        public struct Payment
        {
            public String site_id;
            public String biz_dt;  // yyyyMMdd
            public string pos_no;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위
            public String pay_date;
            public String pay_time;
            public String tran_type;    // 승인 A, 취소 C
            public String pay_class;    // Order 0, charge 1, settlement 2
            public String bill_no;    // 4자리 
            public int net_amount;
            public int amount_cash;
            public int amount_card;
            public int amount_easy;
            public int amount_point;
            public String is_dc;       // 할인여부
            public String is_cancel;   // 취소여부 : 미취소"", 취소중0, 취소1
        }
        public static List<Payment> mPayments = new List<Payment>();

        public struct PaymentCard
        {
            public String site_id;
            public String biz_dt;  // yyyyMMdd
            public string pos_no;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위
            public String pay_date;
            public String pay_time;
            public String pay_type;     // 결제구분 : 신용카드(C1), 임의등록(C9)
            public String tran_type;    // 승인 A 취소 C
            public String pay_class;
            public String ticket_no;
            public int pay_seq;
            public String tran_date;
            public int amount;          // 결제금액 과세금액 면세금액 봉사료 세금
            public int tax_amount;
            public int tfree_amount;
            public int service_amount;
            public int tax;


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
            public String site_id;
            public String biz_dt;  // yyyyMMdd
            public string pos_no;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위
            public String pay_date;
            public String pay_time;
            public String pay_type;     // 결제구분 : 신용카드(C1), 임의등록(C9)
            public String tran_type;    // 승인 A 취소 C
            public String pay_class;
            public String ticket_no;
            public int pay_seq;
            public String tran_date;
            public int amount;          // 결제금액
            public String receipt_type; // 현금영수증 : 개인 소득공제 1 사업자 지출증빙 2
            public String issued_method_no;  // 현금영수증 고객 식별번호
            public String auth_no;      // 승인번호
            public String tran_serial;          // tran_serial -> 취소시 tid입력
            public String is_cancel;    // 취소여부
        }
        public static List<PaymentCash> mPaymentCashs = new List<PaymentCash>();

        public struct PaymentEasy
        {

        }
        public static List<PaymentEasy> mPaymentEasys = new List<PaymentEasy>();


        public struct PaymentPoint           // 선불 포인트 사용
        {
            public String site_id;
            public String biz_dt;  // yyyyMMdd
            public string pos_no;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위
            public String pay_date;
            public String pay_time;
            public String pay_type;     // 결제구분 : 포인트 선불(PA), 후불(PD)
            public String tran_type;    // 승인 A 취소 C
            public String pay_class;
            public String ticket_no;
            public String usage_no;
            public int amount;
            public String is_cancel;



        }
        public static List<PaymentPoint> mPaymentPoints = new List<PaymentPoint>();





        public struct Cert
        {
            public String the_no;       // 
        }




        // 발권상품(Order), 인증(Cert)시점 -> TicketFlow 레코드 생성(초기값)
        public struct TicketFlow
        {
            public String site_id;
            public String biz_dt;  // yyyyMMdd
            public string pos_no;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위
            
            public String ticket_no;
            public String ticketing_dt;   // 발권일시
            public String charge_dt;      // 충전일시
            public String settlement_dt;  // 정산일시

            public int point_charge;        // 충전금액
            public int point_usage;         // 사용금액(누적)

            public int settle_point_charge;        // 충전금액
            public int settle_point_usage;         // 사용금액(누적)

            public String goods_code;
            public String flow_step;      // 진행상황 : 접수0 - 발급1 - *충전2 - 사용3 - 정산(완료)4 : 사용중인 경우 locker close, 정산완료 locker open.
            
            public String locker_no;        // 추가
            public String open_locker;      // 락커 수동 설정 : 0 폐쇄(기본값), 1 개방
                                            // 정산완료  or 수동 개방상태 -> 락커오픈
        }
        public static List<TicketFlow> mTicketFlowList = new List<TicketFlow>();







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


        
        public static String get_pay_class_name(String code)
        {
            String name = "";
            if (code == "OR") name = "일반";
            else if (code == "CH") name = "충전";
            else if (code == "US") name = "포인트";
            else if (code == "ST") name = "정산";
            return name;
        }



        public static String get_pay_type_name(String code)
        {
            String name = "";
            if (code == "C1") name = "카드승인결제";
            else if (code == "C9") name = "카드임의등록";
            else if (code == "R0") name = "단순현금";
            else if (code == "R1") name = "현금영수증";
            else if (code == "R9") name = "임의등록";
            else if (code == "PA") name = "포인트선불";
            else if (code == "PD") name = "포인트후불";

            return name;
        }

        public static String get_tran_type_name(String code)
        {
            String name = "";
            if (code == "A") name = "승인";
            else if (code == "C") name = "취소";
            return name;
        }


        public static String get_ticket_type_name(String code)
        {
            String name = "";
            if (code == "PA") name = "선불";
            else if (code == "PD") name = "후불";
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

        public static String get_goods_name(String code)
        {
            for (int i = 0; i < mGoodsItem.Length; i++)
            {
                if (mGoodsItem[i].code == code)
                {
                    return mGoodsItem[i].name;
                }
            }

            return "";
        }


        public static int convert_number(String str)
        {
            int out_number;
            if (int.TryParse(str.Replace(",", ""), out out_number))
            {
                return out_number;
            }

            return -1;
        }


        public static String make_bill_header()
        {
            String strPrint = "";

            String tStr = mSiteName + " " + mBizTelNo;
            strPrint += tStr;
            strPrint += "\r\n";

            tStr = mBizAddr;
            strPrint += tStr;
            strPrint += "\r\n";

            tStr = mCapName + " ";

            if (mRegistNo.Length == 10)
            {
                tStr += mRegistNo.Substring(0, 3) + "-" + mRegistNo.Substring(3, 2) + "-" + mRegistNo.Substring(5, 5);
            }
            else
            {
                tStr += mRegistNo;
            }

            strPrint += tStr;
            strPrint += "\r\n";
            strPrint += "\r\n";


            return strPrint;
        }

        public static String make_bill_trailer()
        {
            String strPrint = "";

            String tStr = "  물품반품시 본 영수증을 필히 지참하여";
            strPrint += tStr;
            strPrint += "\r\n";

            tStr = "  주시기 바랍니다.";
            strPrint += tStr;
            strPrint += "\r\n";

            return strPrint;

        }



        public static String make_bill_body(String tTheNo, String tranType, String except_order)
        {

            String strPrintHeader = "";
            String strPrintOrder = "";
            String strPrintPayment = "";

            String tOrderDt = "";
            int tax_amount = 0;
            int tfree_amount = 0;
            int dc_amount = 0;


            for (int i = 0; i < listOrder.Count; i++)
            {
                if (listOrder[i].the_no == tTheNo)
                {
                    tOrderDt = listOrder[i].order_date.Substring(0, 4) + "/" +
                               listOrder[i].order_date.Substring(4, 2) + "/" +
                               listOrder[i].order_date.Substring(6, 2) + " " +
                               listOrder[i].order_time.Substring(0, 2) + ":" +
                               listOrder[i].order_time.Substring(2, 2) + ":" +
                               listOrder[i].order_time.Substring(4, 2);
                }
            }

            String tStr = tTheNo.Substring(4, 8) + "-" + tTheNo.Substring(12, 2) + "-" + tTheNo.Substring(14, 4);
            int space_cnt = 42 - (encodelen(tOrderDt) + encodelen(tStr));
            strPrintHeader = tOrderDt + Space(space_cnt) + tStr;
            strPrintHeader += "\r\n";

            strPrintOrder = "==========================================\r\n";  // 42
            strPrintOrder += "상품명                 단가  수량     금액\r\n";
            strPrintOrder += "------------------------------------------\r\n";  // 42


            for (int i = 0; i < listOrderItem.Count; i++)
            {
                if (listOrderItem[i].the_no == tTheNo)
                {

                    if (listOrderItem[i].dcr_des == "E") // 전체할인
                    {
                        if (listOrderItem[i].dcr_type == "A")
                        {
                            tStr = "전체할인";
                            strPrintOrder += tStr + Space(21 - encodelen(tStr));

                            tStr = (-listOrderItem[i].dc_amount).ToString("N0");        // 할인 정액
                            strPrintOrder += Space(21 - encodelen(tStr)) + tStr;
                        }
                        else if (listOrderItem[i].dcr_type == "R")
                        {
                            tStr = "전체할인-" + listOrderItem[i].dcr_value + "%";
                            strPrintOrder += tStr + Space(21 - encodelen(tStr));

                            tStr = (-listOrderItem[i].dc_amount).ToString("N0");        // 할인 정액
                            strPrintOrder += Space(21 - encodelen(tStr)) + tStr;
                        }
                        strPrintOrder += "\r\n";
                    }
                    else                                 // 일반상품항목
                    {
                        tStr = listOrderItem[i].name;
                        strPrintOrder += tStr + Space(18 - encodelen(tStr));

                        tStr = listOrderItem[i].amt.ToString("N0");     //단가
                        strPrintOrder += Space(9 - encodelen(tStr)) + tStr;

                        tStr = listOrderItem[i].cnt.ToString("N0");     // 수량
                        strPrintOrder += Space(6 - encodelen(tStr)) + tStr;

                        tStr = (listOrderItem[i].amt * listOrderItem[i].cnt).ToString("N0");     // 금액 = 단가*수량
                        strPrintOrder += Space(9 - encodelen(tStr)) + tStr;

                        strPrintOrder += "\r\n";

                        if (listOrderItem[i].dcr_type == "A")
                        {
                            tStr = "    할인";
                            strPrintOrder += tStr + Space(21 - encodelen(tStr));

                            tStr = (-listOrderItem[i].dc_amount).ToString("N0");        // 할인 정액
                            strPrintOrder += Space(21 - encodelen(tStr)) + tStr;

                            strPrintOrder += "\r\n";
                        }
                        else if (listOrderItem[i].dcr_type == "R")
                        {
                            tStr = "    할인-" + listOrderItem[i].dcr_value + "%";
                            strPrintOrder += tStr + Space(21 - encodelen(tStr));

                            tStr = (-listOrderItem[i].dc_amount).ToString("N0");        // 할인 정액
                            strPrintOrder += Space(21 - encodelen(tStr)) + tStr;

                            strPrintOrder += "\r\n";
                        }
                    }

                    if (listOrderItem[i].taxfree == "1") tfree_amount += (listOrderItem[i].cnt * listOrderItem[i].amt);
                    else tax_amount += (listOrderItem[i].cnt * listOrderItem[i].amt);

                    dc_amount += listOrderItem[i].dc_amount;
                }
            }


            ////
            strPrintPayment = "------------------------------------------\r\n";  // 42

            if (tfree_amount > 0)
            {
                tStr = "*면세품목가액";
                strPrintPayment += tStr + Space(21 - encodelen(tStr));

                tStr = (tfree_amount).ToString("N0");
                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;

                strPrintPayment += "\r\n";
            }

            if (tax_amount > 0)
            {
                int t_tax = tax_amount / 11;   // 부가세액
                int t_amt = tax_amount - t_tax; // 공급가액

                tStr = "과세품목가액";
                strPrintPayment += tStr + Space(21 - encodelen(tStr));
                tStr = (t_amt).ToString("N0");
                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                strPrintPayment += "\r\n";

                tStr = "부 가 세 액";
                strPrintPayment += tStr + Space(21 - encodelen(tStr));
                tStr = (t_tax).ToString("N0");
                strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                strPrintPayment += "\r\n";
            }

            strPrintPayment += "------------------------------------------\r\n";  // 42

            int tsum = tfree_amount + tax_amount;
            int tnet = tsum - dc_amount;


            tStr = "총합계";
            strPrintPayment += tStr + Space(21 - encodelen(tStr));
            tStr = (tsum).ToString("N0");
            strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
            strPrintPayment += "\r\n";

            tStr = "할인계";
            strPrintPayment += tStr + Space(21 - encodelen(tStr));
            tStr = (-dc_amount).ToString("N0");
            strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
            strPrintPayment += "\r\n";

            tStr = "결제대상금액";
            strPrintPayment += tStr + Space(21 - encodelen(tStr));
            tStr = (tnet).ToString("N0");
            strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
            strPrintPayment += "\r\n";

            strPrintPayment += "------------------------------------------\r\n";  // 42



            // 현금결제
            for (int i = 0; i < mPaymentCashs.Count; i++)
            {
                if (mPaymentCashs[i].the_no == tTheNo & mPaymentCashs[i].tran_type == tranType)
                {
                    if (mPaymentCashs[i].pay_type == "R0")           // 단순현금
                    {
                        tStr = "현금";
                        strPrintPayment += tStr + Space(21 - encodelen(tStr));

                        if (tranType == "C")
                            tStr = (-mPaymentCashs[i].amount).ToString("N0");
                        else
                            tStr = mPaymentCashs[i].amount.ToString("N0");

                        strPrintPayment += Space(21 - encodelen(tStr)) + tStr;

                    }
                    else if (mPaymentCashs[i].pay_type == "R1")     // 
                    {
                        tStr = "현금영수증";
                        strPrintPayment += tStr + Space(21 - encodelen(tStr));

                        if (tranType == "C")
                            tStr = (-mPaymentCashs[i].amount).ToString("N0");
                        else
                            tStr = mPaymentCashs[i].amount.ToString("N0");

                        strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                        strPrintPayment += "\r\n";

                        if (mPaymentCashs[i].receipt_type == "1") // 소득공제
                        {
                            tStr = "소득공제";
                        }
                        else if (mPaymentCashs[i].receipt_type == "2") // 지출증빙
                        {
                            tStr = "지출증빙";
                        }
                        strPrintPayment += tStr + Space(21 - encodelen(tStr));


                        String no = mPaymentCashs[i].issued_method_no + "";
                        if (no.Length == 16)
                        {
                            tStr = no.Substring(0, 4) + "-" + no.Substring(4, 4) + "-****-" + no.Substring(12, 3) + "*";
                        }
                        else if (no.Length == 11 & no.Substring(0, 3) == "010")
                        {
                            tStr = no.Substring(0, 3) + "-****-" + no.Substring(6, 4);
                        }
                        else if (no.Length > 8)
                        {
                            tStr = no.Substring(0, 8) + CharCount('*', no.Length - 8);
                        }
                        else
                        {
                            tStr = no;
                        }

                        strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                    }
                    else if (mPaymentCashs[i].pay_type == "R0")     //  자진발급
                    {
                        tStr = "현금영수증";
                        strPrintPayment += tStr + Space(21 - encodelen(tStr));

                        if (tranType == "C")
                            tStr = (-mPaymentCashs[i].amount).ToString("N0");
                        else
                            tStr = mPaymentCashs[i].amount.ToString("N0");

                        strPrintPayment += Space(21 - encodelen(tStr)) + tStr;

                        tStr = "자진발급";
                        strPrintPayment += tStr + Space(21 - encodelen(tStr));
                        tStr = mPaymentCashs[i].issued_method_no;
                        strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                    }

                    strPrintPayment += "\r\n";
                    strPrintPayment += "\r\n";
                }
            }


            // 카드결제
            for (int i = 0; i < mPaymentCards.Count; i++)
            {
                if (mPaymentCards[i].the_no == tTheNo & mPaymentCards[i].tran_type == tranType)
                {
                    if (mPaymentCards[i].pay_type == "C1") tStr = "카드결제";
                    else if (mPaymentCards[i].pay_type == "C9") tStr = "카드결제";  //? 임의등록

                    if (tranType == "C")
                    {
                        tStr += "취소";
                    }


                    strPrintPayment += tStr + Space(21 - encodelen(tStr));

                    if (tranType == "C")
                        tStr = (-mPaymentCards[i].amount).ToString("N0");
                    else
                        tStr = mPaymentCards[i].amount.ToString("N0");

                    strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                    strPrintPayment += "\r\n";

                    tStr = mPaymentCards[i].card_name + "";
                    strPrintPayment += tStr + Space(21 - encodelen(tStr));

                    String no = mPaymentCards[i].card_no + "";

                    if (no.Length == 16)
                    {
                        tStr = no.Substring(0, 4) + "-" + no.Substring(4, 4) + "-****-" + no.Substring(12, 3) + "*";
                    }
                    else if (no.Length > 8)
                    {
                        tStr = no.Substring(0, 8) + CharCount('*', no.Length - 8);
                    }
                    else
                    {
                        tStr = no;
                    }



                    strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                    strPrintPayment += "\r\n";


                    if (mPaymentCards[i].install == "00")
                        tStr = "할부개월:일시불";
                    else
                        tStr = "할부개월:" + mPaymentCards[i].install;

                    strPrintPayment += tStr + Space(21 - encodelen(tStr));
                    tStr = "승인번호:" + mPaymentCards[i].auth_no;
                    strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                    strPrintPayment += "\r\n";
                    strPrintPayment += "\r\n";
                }
            }


            // 포인트
            for (int i = 0; i < mPaymentPoints.Count; i++)
            {
                if (mPaymentPoints[i].the_no == tTheNo & mPaymentPoints[i].tran_type == tranType)
                {
                    if (mPaymentPoints[i].pay_type == "PA")           // 선불 포인트
                    {
                        tStr = "포인트(선불)";
                        strPrintPayment += tStr + Space(21 - encodelen(tStr));

                        if (tranType == "C")
                            tStr = (-mPaymentCashs[i].amount).ToString("N0");
                        else
                            tStr = mPaymentCashs[i].amount.ToString("N0");

                        strPrintPayment += Space(21 - encodelen(tStr)) + tStr;

                    }
                    else if (mPaymentCashs[i].pay_type == "PD")     // 후불 포인트
                    {
                        tStr = "포인트(후불)";
                        strPrintPayment += tStr + Space(21 - encodelen(tStr));

                        if (tranType == "C")
                            tStr = (-mPaymentCashs[i].amount).ToString("N0");
                        else
                            tStr = mPaymentCashs[i].amount.ToString("N0");

                        strPrintPayment += Space(21 - encodelen(tStr)) + tStr;
                    }

                    strPrintPayment += "\r\n";
                    strPrintPayment += "\r\n";
                }
            }


            strPrintPayment += "------------------------------------------\r\n";  // 42

            if (except_order == "Y")
            {
                return strPrintHeader + strPrintPayment;
            }
            else
            {
                return strPrintHeader + strPrintOrder + strPrintPayment;
            }
        }


        public static string Space(int count)
        {
            return new String(' ', count);
        }

        public static string CharCount(char c, int count)
        {
            return new String(c, count);
        }


        public static int encodelen(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }



        public static void PrintBill(String headerBill, String bodyBill, String trailerBill,  String theNo)
        {

            try
            {

                SerialPort port = new SerialPort();

               if (port.IsOpen)
                    port.Close();


                port.PortName = mBillPrinterPort;
                port.BaudRate = (int)9600; //고정
                port.DataBits = (int)8;
                port.Parity = Parity.None;
                port.StopBits = StopBits.One;

                port.Open();
                port.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("영수증프린터 통신포트 에러.\r\n" + ex.Message);
                return;
            }


            try
            {
                const string ESC = "\u001B";
                const string InitializePrinter = ESC + "@";

                PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();

                byte[] BytesValue = new byte[100];

                BytesValue = PrintExtensions.AddBytes(BytesValue, InitializePrinter);

                //
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(headerBill));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());

                //              
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(bodyBill));

                //
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(trailerBill));



                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                // 바코드
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.BarCode.Code128(theNo));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());



                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());



                BytesValue = PrintExtensions.AddBytes(BytesValue, CutPage());

                PrintExtensions.Print(BytesValue, mBillPrinterPort);
            }
            catch (Exception ex)
            {
                MessageBox.Show("인쇄중 에러.\r\n" + ex.Message);
                return;
            }



        }




        private static string strPosTitle(string title)
        {
            int blen = Encoding.Default.GetBytes(title).Length;
            int slen = title.Length;
            int len = 16 - (blen - slen);

            return string.Format("{0,-" + len + "}{1,3}", title, 1) + " : ";
        }



        public static byte[] CutPage()
        {

            byte[] partial_cut = new byte[3] { 0x1D, 0x56, 0x00 };

            return partial_cut;


        }

        // 
        public static int mGetAsync(String URL, ref String responseString)
        {

            try
            {
                HttpResponseMessage response = mHttpClient.GetAsync(URL).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    responseString = responseContent.ReadAsStringAsync().Result;

                    return 0;
                }
                else
                {
                    responseString = response.ReasonPhrase;
                    return -1;
                }

            }
            catch (HttpRequestException ex)
            {
                responseString = "서버에 연결할수없습니다";
                return -1;
            }
            catch (Exception ex2)
            {
                responseString = ex2.Message;
                return -1;
            }
        }

        public static bool mRequestGet(String sUrl, ref JObject obj)
        {

            var response = mHttpClient.GetAsync(mBaseUri + sUrl).Result;

            var responseContent = response.Content;
            string responseString = responseContent.ReadAsStringAsync().Result;


            obj = JObject.Parse(responseString);

            return response.IsSuccessStatusCode;
        }

        public static bool mRequestPost(String sUrl, Dictionary<string, string> parameters, ref JObject obj)
        {






            var json = JsonConvert.SerializeObject(parameters);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = mHttpClient.PostAsync(mBaseUri + sUrl, data).Result;

            var responseContent = response.Content;
            string responseString = responseContent.ReadAsStringAsync().Result;

            obj = JObject.Parse(responseString);

            return response.IsSuccessStatusCode;
        }


    }
}
