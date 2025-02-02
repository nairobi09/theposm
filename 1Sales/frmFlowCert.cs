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
using static thepos.frmSales;
using System.Security.Policy;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
using static thepos.frmSub;
using System.Collections;
using System.Numerics;
using static System.Windows.Forms.AxHost;
using static thepos.ClsWin32Api;


namespace thepos
{
    public partial class frmFlowCert : Form
    {

        String PLACEM_URL = "https://gateway.sparo.cc/extra/kiosk/v1/";






        public frmFlowCert()
        {
            InitializeComponent();
            initialize_font();
            initialize_the();
        }

        private void initialize_font()
        {
            lblTitle.Font = font12;
            btnClose.Font = font12;

            lblNoTitle.Font = font10;
            tbNo.Font = font10;

            lblNoMemo.Font = font10;

            btnView.Font = font9;
            lvwList.Font = font10;

            btnPayCert.Font = font10;
            btnCoupon.Font = font10;
            btnCouponCancel.Font = font10;



        }
        private void initialize_the()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwList.SmallImageList = imgList;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (mLvwOrderItem.Items.Count > 0)
            {
                SetDisplayAlarm("W", "쿠폰사용 주문목록이 있으면 쿠폰창을 닫을 수 없습니다.");
                return;
            }

            this.Close();
        }

        private void frmFlowCert_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSales.ConsoleEnable();

            mPanelMiddle.Visible = false;
            mPanelMiddle.Controls.Clear();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //? 쿠폰업체 추가시 아래 구분필요
            if (mCouponChPM == "")
            {
                MessageBox.Show("쿠픈판매 업체코드 미등록상태입니다.", "thepos");
                return;
            }


            view_reload();
        }


        private void view_reload()
        { 

            if (tbNo.Text.Length == 4 |  tbNo.Text.Length >= 8)
            {

            }
            else
            {
                SetDisplayAlarm("W", "검색번호 : 4자리 or 8자리이상.");
                return;
            }



            mCertOrders.Clear();
            lvwList.Items.Clear();
            clear_info();



            couponPM p = new couponPM();
            int ret = p.requestPmCertView(tbNo.Text);

            if (ret == 0)
            {
                for (int i = 0; i < mCertOrders.Count; i++)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Text = mCertOrders[i].state;

                    String ustate_name = "";

                    // (1: 사용, 2: 미사용)
                    if (mCertOrders[i].ustate == "2")
                        ustate_name = "미사용";
                    else if (mCertOrders[i].ustate == "1")
                        ustate_name = "사용";
                    else
                        ustate_name = "";

                    lvItem.SubItems.Add(ustate_name);


                    lvItem.SubItems.Add(mCertOrders[i].coupon_no);
                    lvItem.SubItems.Add(mCertOrders[i].menu_name);
                    lvItem.SubItems.Add(mCertOrders[i].qty.ToString());
                    
                    lvItem.SubItems.Add(mCertOrders[i].cus_nm);
                    lvItem.SubItems.Add(mCertOrders[i].cus_hp);
                    lvItem.SubItems.Add(mCertOrders[i].menu_code);
                    lvItem.SubItems.Add(mCertOrders[i].ustate);
                    lvItem.SubItems.Add(mCertOrders[i].exp_date);

                    lvItem.SubItems.Add(mCertOrders[i].is_usage);

                    lvwList.Items.Add(lvItem);
                }

            }

        }

        private void clear_info()
        {
            lblState.Text = "";
            lblUstate.Text = "";
            lblCouponNo.Text = "";
            lblExpdate.Text = "";
            lblCusnm.Text = "";
            lblCushp.Text = "";
            lblGoodsName.Text = "";
            lblQty.Text = "";

        }


        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t_coupon_no = "";
            String t_menu_code = "";
            int t_qty = 1;



            if (lvwList.SelectedItems.Count < 1)
            {
                clear_info();
                return;
            }



            lblState.Text = lvwList.Items[lvwList.SelectedItems[0].Index].SubItems[lvwList.Columns.IndexOf(state)].Text;
            lblUstate.Text = lvwList.Items[lvwList.SelectedItems[0].Index].SubItems[lvwList.Columns.IndexOf(ustate_name)].Text;
            lblCouponNo.Text = lvwList.Items[lvwList.SelectedItems[0].Index].SubItems[lvwList.Columns.IndexOf(coupon_no)].Text;
            lblExpdate.Text = lvwList.Items[lvwList.SelectedItems[0].Index].SubItems[lvwList.Columns.IndexOf(exp_date)].Text;
            lblCusnm.Text = lvwList.Items[lvwList.SelectedItems[0].Index].SubItems[lvwList.Columns.IndexOf(cus_nm)].Text;
            lblCushp.Text = lvwList.Items[lvwList.SelectedItems[0].Index].SubItems[lvwList.Columns.IndexOf(cus_hp)].Text;
            lblQty.Text = lvwList.Items[lvwList.SelectedItems[0].Index].SubItems[lvwList.Columns.IndexOf(qty)].Text;


            String isUsage = lvwList.Items[lvwList.SelectedItems[0].Index].SubItems[lvwList.Columns.IndexOf(is_usage)].Text;

            t_menu_code = lvwList.Items[lvwList.SelectedItems[0].Index].SubItems[lvwList.Columns.IndexOf(menu_code)].Text;



            //? 이후 삭제
            /***** 임시 테스트 ****/
            if (t_menu_code == "1234") t_menu_code = "100001";






            int goods_idx = -1;

            for (int i = 0; i < mGoodsItem.Length; i++)
            {
                if (t_menu_code == mGoodsItem[i].goods_code)
                {
                    goods_idx = i;
                }
            }

            if (goods_idx == -1)
            {
                lblGoodsName.Text = "";

                SetDisplayAlarm("W", "상품정보 연결 오류.");
                return;
            }


            lblGoodsName.Text = mGoodsItem[goods_idx].goods_name;

        }



        private void btnCoupon_Click(object sender, EventArgs e)
        {

            String t_coupon_no = "";
            String t_coupon_goods_code = "";
            int t_coupon_cnt = 1;


            String rcode = "";
            String rmsg = "";
            String rcnt = "";


            if (lvwList.SelectedItems.Count < 1)
            {
                return;
            }


            if (mLvwOrderItem.Items.Count > 0)
            {
                SetDisplayAlarm("W", "쿠폰인증은 1건씩만 가능합니다.");
                return;
            }




            if (lvwList.Items[lvwList.SelectedItems[0].Index].SubItems[lvwList.Columns.IndexOf(ustate_code)].Text == "2")   // 미사용
            {

                t_coupon_goods_code = lvwList.Items[lvwList.SelectedItems[0].Index].SubItems[lvwList.Columns.IndexOf(menu_code)].Text;
                t_coupon_cnt = convert_number(lvwList.Items[lvwList.SelectedItems[0].Index].SubItems[lvwList.Columns.IndexOf(qty)].Text);

                
                
                //? 이후 삭제
                /***** 임시 테스트 ****/
                if (t_coupon_goods_code == "1234")  t_coupon_goods_code = "100001";





                int goods_idx = -1;

                for (int i = 0; i < mGoodsItem.Length; i++)
                {
                    if (t_coupon_goods_code == mGoodsItem[i].goods_code)
                    {
                        goods_idx = i;
                    }
                }




                String isUsage = lvwList.Items[lvwList.SelectedItems[0].Index].SubItems[lvwList.Columns.IndexOf(is_usage)].Text;

                if (goods_idx == -1)
                {
                    SetDisplayAlarm("W", "상품정보 연결오류.\r\n관리자 문의바랍니다.");
                    return;
                }
                else if (isUsage != "Y")
                {
                    SetDisplayAlarm("W", "선택 쿠폰은 사용요청할 수 없습니다.");
                    return;
                }




                t_coupon_no = lvwList.Items[lvwList.SelectedItems[0].Index].SubItems[lvwList.Columns.IndexOf(coupon_no)].Text;


                couponPM p = new couponPM();
                if (p.requestPmCertAuth(t_coupon_no) == 0)
                {
                    
                    // 옵션항목 목록: frmOrderOption에서 채운다.
                    mOrderOptionItemList.Clear();

                    int order_cnt = 1;

                    if (mGoodsItem[goods_idx].option_template_id != "")
                    {
                        frmOrderOption fForm = new frmOrderOption(mGoodsItem[goods_idx]);
                        DialogResult ret = fForm.ShowDialog();

                        if (ret == DialogResult.Cancel)
                        {
                            return;
                        }

                        // 수량을 전역변수에서 받음 : fk30fgu9w04ufgw
                        order_cnt = mOrderCntInOption;

                    }



                    MemOrderItem orderItem = new MemOrderItem();


                    orderItem.option_name_description = "";   // 리스트뷰 상품항목 아랫줄에 표시
                    orderItem.option_amt_description = "";    // 리스트뷰 단가항목 아랫줄에 표시



                    //
                    orderItem.option_item_cnt = mOrderOptionItemList.Count;
                    orderItem.option_no = "";
                    orderItem.orderOptionItemList = mOrderOptionItemList.ToList();  // ToList() : 리스트 복사, 참조가 아니고..

                    orderItem.order_no = mOrderItemList.Count + 1;
                    orderItem.goods_code = mGoodsItem[goods_idx].goods_code.ToString();
                    orderItem.goods_name = mGoodsItem[goods_idx].goods_name;
                    orderItem.ticket = mGoodsItem[goods_idx].ticket;
                    orderItem.taxfree = mGoodsItem[goods_idx].taxfree;


                    orderItem.cnt = t_coupon_cnt;

                    orderItem.amt = mGoodsItem[goods_idx].amt;
                    //orderItem.option_amt    // 위에서 세팅

                    orderItem.dcr_type = "";
                    orderItem.dcr_des = "";
                    orderItem.dcr_value = 0;
                    orderItem.shop_code = mGoodsItem[goods_idx].shop_code;

                    orderItem.coupon_no = t_coupon_no;



                    //
                    replace_mem_order_item(ref orderItem, "add");

                    mOrderItemList.Add(orderItem);
                    mLvwOrderItem.SetObjects(mOrderItemList);

                    mLvwOrderItem.Items[mLvwOrderItem.Items.Count - 1].EnsureVisible();
                    mLvwOrderItem.Items[mLvwOrderItem.Items.Count - 1].Selected = true;



                    view_reload();


                    ReCalculateAmount();

                }
            }
            else
            {
                SetDisplayAlarm("W", "사용요청할 수 없는 쿠폰입니다.");
                return;

            }

        }

        private void btnCouponCancel_Click(object sender, EventArgs e)
        {
            String t_coupon_no = "";

            String rcode = "";
            String rmsg = "";
            String rcnt = "";


            if (mLvwOrderItem.SelectedItems.Count != 1)
            {
                SetDisplayAlarm("W", "주문목록에 추가된 사용쿠폰만 사용취소할 수 있습니다.");
                return;
            }


            t_coupon_no = mOrderItemList[0].coupon_no;


            //? 쿠폰 판매회사 구분 필요

            couponPM p = new couponPM();
            if (p.requestPmCertCancel(t_coupon_no) == 0)
            {
                mOrderItemList.Clear();
                mLvwOrderItem.SetObjects(mOrderItemList);

                view_reload();

                ReCalculateAmount();

            }


        }




        private void btnPayCert_Click(object sender, EventArgs e)
        {
            //
            String ticketNo = "";


            if (mOrderItemList.Count == 0)
            {
                return;
            }


            if (mNetAmount < 0)
            {
                SetDisplayAlarm("W", "유효한 결제금액인지 확인요망.");
                return;
            }


            if (!get_amounts(out int t과세금액, out int t면세금액))
            {
                MessageBox.Show("과세금액, 면세금액 계산오류");
                return;
            }


            // 영업일자 등 선체크 
            if (!isPreCheck(out String error_msg))
            {
                MessageBox.Show(error_msg, "thepos");
                return;
            }


            countup_the_no();





            //!
            int order_cnt = 0;
            int dcAmount = 0;


            // 리스트뷰 -> 메모리배열 생성 : [ 업장코드로 정렬 + 업장주문번호 부여 ]
            //MemOrderItem[] memOrderItemArr = getMemOrderItemArr(out dcAmount);

            set_shop_order_no_on_orderitem(out dcAmount);



            // orders, orderItem 
            order_cnt = SaveOrder(ticketNo);  // order. orderitem  ->  업장주문서 출력은 제외
            if (order_cnt == -1)
            {
                return; // 재로그인 요구
            }


            //  payment
            if (!SavePayment(1, "Cert", mNetAmount, dcAmount))
            {
                return;
            }


            PaymentCert mPaymentCert = new PaymentCert();
            mPaymentCert.site_id = mSiteId;
            mPaymentCert.biz_dt = mBizDate;
            mPaymentCert.pos_no = mPosNo;
            mPaymentCert.the_no = mTheNo;
            mPaymentCert.ref_no = mRefNo; // 

            mPaymentCert.pay_date = get_today_date();
            mPaymentCert.pay_time = get_today_time();
            mPaymentCert.pay_type = "M0";       // 결제구분 : 쿠폰인증(M0)
            mPaymentCert.tran_type = "A";       // 승인 A 취소 C
            mPaymentCert.pay_class = mPayClass;

            mPaymentCert.ticket_no = ticketNo;
            mPaymentCert.pay_seq = 1; // 
            mPaymentCert.tran_date = "";
            mPaymentCert.amount = mNetAmount;    // 결제금액
            mPaymentCert.coupon_no = mOrderItemList[0].coupon_no;   //?  쿠폰인증 멀티 발권가능하도록 할것인가?
            mPaymentCert.is_cancel = "";         // 취소여부
            mPaymentCert.van_code = "PM";        // PM : 플레이스엠


            
            // 결제 항목 저장
            if (mTheMode == "Local")
            {
                if (!SavePaymentCert_Local(mPaymentCert))
                {
                    return;
                }
            }
            else
            {
                if (!SavePaymentCert_Server(mPaymentCert))
                {
                    return;
                }
            }




            String strAlarm = "";
            strAlarm = "쿠폰인증 주문완료.";

            SetDisplayAlarm("I", strAlarm);



            int settel_amt = mNetAmount;


            // 티켓 저장
            int ticket_cnt = SaveTicketFlow(ticketNo, mPayClass, "US", settel_amt);

            if (ticket_cnt > 0)
            {

            }




            // 주문서 출력 : 업장용 + 고객용
            // 주문서 출력
            String[] order_no_from_to = new String[2];

            order_no_from_to[0] = "";
            order_no_from_to[1] = "";

            if (mPayClass == "OR")
            {
                List<shop_order_pack> shopOrderPackList = new List<shop_order_pack>();

                order_no_from_to = print_order(ref shopOrderPackList);


                //
                //frmAllim fAllim = new frmAllim(shopOrderPackList);
                //fAllim.ShowDialog();
            }


            // 영수증 출력
            _print_bill(mTheNo, "A", "", "00001", true); // cert



            mClearSaleForm();




            this.Close();


        }

        private bool SavePaymentCert_Local(PaymentCert mPaymentCert)
        {

            String sql = "INSERT INTO paymentCert (siteId, posNo, bizDt, theNo, refNo, payDate, payTime, payType, tranType, payClass, ticketNo, paySeq, tranDate, amount, couponNo, isCancel, vanCode) " +
                "values ('" + mPaymentCert.site_id + "','" + mPaymentCert.pos_no + "','" + mPaymentCert.biz_dt + "','" + mPaymentCert.the_no + "','" + mPaymentCert.ref_no + "','" + mPaymentCert.pay_date + "','" + mPaymentCert.pay_time + "','" + mPaymentCert.pay_type + "','" + mPaymentCert.tran_type + "','" + mPaymentCert.pay_class + "','" +
                              mPaymentCert.ticket_no + "'," + mPaymentCert.pay_seq + ",'" + mPaymentCert.tran_date + "'," + mPaymentCert.amount + ",'" + mPaymentCert.coupon_no + "','" + mPaymentCert.is_cancel + "','" + mPaymentCert.van_code + "')";
            int ret = sql_excute_local_db(sql);


            return true;

        }


        private bool SavePaymentCert_Server(PaymentCert mPaymentCert)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Clear();
            parameters["siteId"] = mPaymentCert.site_id;
            parameters["posNo"] = mPaymentCert.pos_no;
            parameters["bizDt"] = mPaymentCert.biz_dt;
            parameters["theNo"] = mPaymentCert.the_no;
            parameters["refNo"] = mPaymentCert.ref_no;

            parameters["payDate"] = mPaymentCert.pay_date;
            parameters["payTime"] = mPaymentCert.pay_time;
            parameters["payType"] = mPaymentCert.pay_type;
            parameters["tranType"] = mPaymentCert.tran_type;
            parameters["payClass"] = mPaymentCert.pay_class;

            parameters["ticketNo"] = mPaymentCert.ticket_no;
            parameters["paySeq"] = mPaymentCert.pay_seq + "";
            parameters["tranDate"] = mPaymentCert.tran_date;
            parameters["amount"] = mPaymentCert.amount + "";

            parameters["couponNo"] = mPaymentCert.coupon_no;
            parameters["isCancel"] = mPaymentCert.is_cancel;
            parameters["vanCode"] = mPaymentCert.van_code; ;

            if (mRequestPost("paymentCert", parameters))
            {
                if (mObj["resultCode"].ToString() == "200")
                {

                }
                else
                {
                    MessageBox.Show("오류 paymentCert\n\n" + mObj["resultMsg"].ToString(), "thepos");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("시스템오류 paymentCert\n\n" + mErrorMsg, "thepos");
                return false;
            }

            return true;

        }


    }
}
