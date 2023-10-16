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


/*
 
로그인 정보



"userId": "1111",
"userPw": "ARyUXzDOLLr8RS85hA8CVpMznEI=",
"macAddr": "023006617873"

 
 
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


        public static Font font5;
        public static Font font8;
        public static Font font9;
        public static Font font10;
        public static Font font10bold;
        public static Font font12;
        public static Font font12bold;
        public static Font font13;
        public static Font font14;
        public static Font font16;
        public static Font font20;
        public static Font font24;

        public static PrivateFontCollection fontCollection = new PrivateFontCollection();



        // //////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // 로그인후 다운로드되어야할 환경값들
        //

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
        public static String mTicketType;   //발권형태: ""미사용, "PA"선불, "PD"후불// 발권형태 : 선불형 AP-advanced payment  후불형 DP-deferred payment
        public static String mTicketMedia;  // 띠지BC   팔찌RF
        public static String mVanCode = "";

        // 콜센터 연락처
        public static String mCallCenterNo = "";





        public static String mPosNo = "";       // 내 포스번호
        public static String[] mPosNoList;      // Site내 포스번호 목록





        // 주문서 - 상품정보 필드관리
        //? 코너타입은 사이트별 or 포스별??
        public static String mCornerType;  // 주문서 관리 - ""미사용, "E"단순일체형, "P"분리형
        public static String[] mCornerCode; // 코너 코드
        public static String[] mCornerName; // 코너 명







        public static String mLanguage = ""; // KR EN CH



        // //////////////////////////////////////////////////////////////////////////////////////////
        /// 포스 설정값 <summary>
        /// 포스 설정값
        public static string mClientType = "";  // PC:PC, POS:포스, KIOSK:키오스크







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

        public static String mBaseUri = "http://211.42.156.219:8080/";



        public static frmSub fSub;
        public static Panel mPanelOrderInfo;
        public static ListView mSublvwOrderItem;

        public static Label mSublblOrderAmount;
        public static Label mSublblOrderAmountDC;
        public static Label mSublblOrderAmountNet;
        public static Label mSublblOrderAmountReceive;
        public static Label mSublblOrderAmountRest;



        // //////////////////////////////////////////////////////////////////////////////////////////
        // 로컬 + 서버
        public struct Shop
        {
            public string shop_code;
            public string shop_name;
        }
        public static Shop[] mShop;


        public struct GoodsGroup
        {
            public string group_code;
            public string group_name;
            public int column;
            public int row;
            public int columnspan;
            public int rowspan;
        }
        public static GoodsGroup[] mGoodsGroup;


        public struct GoodsItem
        {
            public string group_code;
            public string item_code;
            public string item_name;
            public int amt;
            public String ticket; // 일반상품 0. 티켓상품 1
            public String taxfree; // 과세품 0, 면세품 1
            public String shop_code;
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
            public String shop_code;
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
            public int dc_amount;       // 할인금액
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
            public String pay_type;     // 결제구분 : 신용카드(C1), 임의등록(C0)
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
            public String tran_serial;  // tran_serial -> 취소시 tid입력
            public String sign_path;
            public int gift_change;     // 기프트 잔액
            public String is_cancel;    // 취소여부 : "" or "1"
            public String van_code;
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
            public String pay_type;     // 결제구분 : 신용카드(C1), 임의등록(C0)
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
            public String van_code;
        }
        public static List<PaymentCash> mPaymentCashs = new List<PaymentCash>();


        public struct PaymentEasy
        {
            public String site_id;
            public String biz_dt;  // yyyyMMdd
            public string pos_no;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위
            public String pay_date;
            public String pay_time;
            public String pay_type;     // 결제구분 : 간편결제(ㄸ1)
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
            public String tran_serial;  // tran_serial -> 취소시 tid입력
            public String sign_path;
            public int gift_change;     // 기프트 잔액
            public String is_cancel;    // 취소여부 : "" or "1"
            public String van_code;

            public String pay_type2;  // KKP
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
            public String site_id;
            public String biz_dt;  // yyyyMMdd
            public string pos_no;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위
            public String pay_date;
            public String pay_time;
            public String pay_type;     // 결제구분 : 인증(T1)
            public String isu_code;     // M0 플레이스엠
            public String ticket_no;

            public String order_no;     // 주문번호
            public String coupon_no;    // 쿠폰번호
            public String menu_code;    // 메뉴코드 - 상품코드
            public string menu_name;    // 메뉴명   - 상품명
            public string qty;          // 수량
            public string exp_date;     // 유효기간, 이용일
            public String state;        // 예약상태 (예약완료, 완료, , 취소 )
            public String ustate;       // 사용상태 (1: 사용, 2: 미사용)
            public String cusnm;        // 고객명
            public String cushp;        // 고객연락처
            public String cusopt;       // 주문옵션
        }




        // 발권상품(Order), 인증(Cert)시점 -> TicketFlow 레코드 생성(초기값)
        public struct TicketFlow
        {
            public String site_id;
            public String biz_dt;
            public String the_no;   // 결제단위
            public String ref_no;   // 입장단위
            
            public String ticket_no;
            public String ticketing_dt;   // 발권일시
            public String charge_dt;      // 충전일시
            public String settlement_dt;  // 정산일시

            public int point_charge_cnt;        // 충전횟수
            public int point_usage_cnt;         // 사용횟수

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

        public static JObject mObj = new JObject();



        // 포스별 설정
        public static String mBillPrinterPort = "";
        public static String mTicketPrinterPort = "";
        public static String mScannerPort = "";
        public static String mPosType = ""; // 기종 : POS PC KIOSK
        public static String mCustomerMonitor = "";  // Y N




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
            if (code == "OR") name = "구매";
            else if (code == "CH") name = "충전";
            else if (code == "US")
            {
                if (mTicketType == "PA") name = "선불";
                else if (mTicketType == "PD") name = "후불";
                else name = code;
            }
            else if (code == "ST") name = "정산";
            else name = code;

            return name;
        }



        public static String get_pay_type_group_name(String group)
        {
            //is_cash + is_card + is_point + is_easy;
            if (group == "1000") return "현금";
            else if (group == "0100") return "카드";
            else if (group == "0010") return "포인트";
            else if (group == "0001") return "간편";
            else if (group == "0000") return group;
            else return "복합";
        }


        public static String get_pay_type_name(String code)
        {
            String name = "";
            if (code == "C1") name = "카드승인결제";
            else if (code == "C0") name = "카드임의등록";
            else if (code == "R0") name = "단순현금";
            else if (code == "R1") name = "현금영수증";
            else if (code == "R9") name = "임의등록";
            else if (code == "PA") name = "포인트선불";
            else if (code == "PD") name = "포인트후불";
            else if (code == "E1") name = "간편";
            else name = code;

            return name;
        }

        public static String get_tran_type_name(String code)
        {
            String name = "";
            if (code == "A") name = "승인";
            else if (code == "C") name = "취소";
            else name = code;

            return name;
        }


        public static String get_ticket_type_name(String code)
        {
            String name = "";
            if (code == "PA") name = "선불";
            else if (code == "PD") name = "후불";
            else name = code;

            return name;
        }


        public static String get_receipt_type_name(String code)
        {
            String name = "";
            if (code == "1") name = "개인소득공제";
            else if (code == "2") name = "사업지출증빙";
            else if (code == "3") name = "자진발급";
            else name = code;

            return name;
        }



        public static String get_dcr_des_name(String code)
        {
            String name = "";
            if (code == "E") name = "전체";
            else if (code == "S") name = "선택";
            else name = code;

            return name;
        }

        public static String get_dcr_type_name(String code)
        {
            String name = "";
            if (code == "A") name = "정액(W)";
            else if (code == "R") name = "정율(%)";
            else name = code;

            return name;
        }

        public static String get_is_cancel_name(String code)
        {
            String name = "";
            if (code == "1") name = "취소중";
            else if (code == "Y") name = "취소됨";
            else name = code;

            return name;
        }

        public static String get_goods_name(String code)
        {
            for (int i = 0; i < mGoodsItem.Length; i++)
            {
                if (mGoodsItem[i].item_code == code)
                {
                    return mGoodsItem[i].item_name;
                }
            }

            return code;
        }

        public static String get_shop_name(String shop_code)
        {
            for (int i = 0; i < mShop.Length; i++)
            {
                if (mShop[i].shop_code == shop_code)
                {
                    return mShop[i].shop_name;
                }
            }

            return shop_code;
        }

        public static bool is_number(String str)
        {
            int tNum;
            if (int.TryParse(str, out tNum))
            {
                return true;
            }

            return false;
        }

        public static bool get_number(String str, ref int num)
        {
            if (int.TryParse(str, out num))
            {
                return true;
            }

            return false;
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

        public static bool mRequestGet(String sUrl)
        {
            try
            {
                var response = mHttpClient.GetAsync(mBaseUri + sUrl).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                mObj = JObject.Parse(responseString);

                return true;
            }
            catch (Exception ex)
            {
                mErrorMsg = ex.Message;
                return false;
            }
        }

        public static bool mRequestPost(String sUrl, Dictionary<string, string> parameters)
        {
            try
            {
                var json = JsonConvert.SerializeObject(parameters);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = mHttpClient.PostAsync(mBaseUri + sUrl, data).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                mObj = JObject.Parse(responseString);

                return true;
            }
            catch(Exception ex) 
            {
                mErrorMsg = ex.Message;
                return false;
            }
        }


        public static bool mRequestPatch(String sUrl, Dictionary<string, string> parameters)
        {
            try
            {
                var json = JsonConvert.SerializeObject(parameters);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var method = new HttpMethod("PATCH");
                var request = new HttpRequestMessage(method, mBaseUri + sUrl);
                request.Content = data;


                var response = mHttpClient.SendAsync(request).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                mObj = JObject.Parse(responseString);

                return true;
            }
            catch (Exception ex)
            {
                mErrorMsg = ex.Message;
                return false;
            }
        }

        public static bool mRequestDelete(String sUrl, Dictionary<string, string> parameters)
        {
            try
            {
                var json = JsonConvert.SerializeObject(parameters);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var method = new HttpMethod("DELETE");
                var request = new HttpRequestMessage(method, mBaseUri + sUrl);
                request.Content = data;


                var response = mHttpClient.SendAsync(request).Result;

                var responseContent = response.Content;
                string responseString = responseContent.ReadAsStringAsync().Result;

                mObj = JObject.Parse(responseString);

                return true;
            }
            catch (Exception ex)
            {
                mErrorMsg = ex.Message;
                return false;
            }
        }


        public static string SHA1HashCrypt(string val)
        {
            //고정로직
            byte[] data = Encoding.ASCII.GetBytes(val);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(data);
            return Convert.ToBase64String(result);
        }


        public static bool get_bizdate_status(ref String biz_status, ref String biz_date)
        {
            String sUrl = "bizDateLast?siteId=" + mSiteId;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String data = mObj["bizDate"].ToString();
                    JArray arr = JArray.Parse(data);

                    biz_date = arr[0]["bizDt"].ToString();
                    biz_status = arr[0]["bizStatus"].ToString();

                    return true;
                }
                else
                {
                    MessageBox.Show("영업개시마감 오류\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    //MessageBox.Show("영업개시마감 오류\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return false;
            }

        }


        public static void get_goodsgroup()
        {
            String sUrl = "goodsGroup?siteId=" + mSiteId + "&posNo=" + mPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String goods_group = mObj["goodsGroups"].ToString();
                    JArray arr = JArray.Parse(goods_group);

                    mGoodsGroup = new GoodsGroup[arr.Count];

                    for (int i = 0; i < arr.Count; i++)
                    {
                        mGoodsGroup[i].group_code = arr[i]["groupCode"].ToString();
                        mGoodsGroup[i].group_name = arr[i]["groupName"].ToString();
                        mGoodsGroup[i].column = int.Parse(arr[i]["locateX"].ToString());
                        mGoodsGroup[i].row = int.Parse(arr[i]["locateY"].ToString());
                        mGoodsGroup[i].columnspan = int.Parse(arr[i]["sizeX"].ToString());
                        mGoodsGroup[i].rowspan = int.Parse(arr[i]["sizeY"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("상품그룹정보 오류. goodsGroup\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }
        }


        public static void get_goodsitem()
        {
            String sUrl = "goodsItemAndGoods?siteId=" + mSiteId + "&posNo=" + mPosNo;

            if (mRequestGet(sUrl))
            {
                if (mObj["resultCode"].ToString() == "200")
                {
                    String goods_item = mObj["goodsItems"].ToString();
                    JArray arr = JArray.Parse(goods_item);

                    mGoodsItem = new GoodsItem[arr.Count];

                    for (int i = 0; i < arr.Count; i++)
                    {
                        mGoodsItem[i].group_code = arr[i]["groupCode"].ToString();
                        mGoodsItem[i].item_code = arr[i]["itemCode"].ToString();
                        mGoodsItem[i].item_name = arr[i]["itemName"].ToString();
                        mGoodsItem[i].shop_code = arr[i]["shopCode"].ToString();
                        mGoodsItem[i].amt = int.Parse(arr[i]["amt"].ToString());
                        mGoodsItem[i].ticket = arr[i]["ticketYn"].ToString();
                        mGoodsItem[i].taxfree = arr[i]["taxFree"].ToString();
                        mGoodsItem[i].column = int.Parse(arr[i]["locateX"].ToString());
                        mGoodsItem[i].row = int.Parse(arr[i]["locateY"].ToString());
                        mGoodsItem[i].columnspan = int.Parse(arr[i]["sizeX"].ToString());
                        mGoodsItem[i].rowspan = int.Parse(arr[i]["sizeY"].ToString());

                        // 면세상픔은 상품명앞에 *을 붙인다.
                        if (mGoodsItem[i].taxfree == "1")
                        {
                            mGoodsItem[i].item_name = "*" + mGoodsItem[i].item_name;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("상품정보 오류. goodsItemAndGoods\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                    return;
                }
            }
            else
            {
                MessageBox.Show("시스템오류\n\n" + mErrorMsg, "thepos");
                return;
            }

        }

    }
}
