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

namespace thepos
{
    public partial class frmSysMemoryStatus : Form
    {
        public frmSysMemoryStatus()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            lvwInfo.Items.Clear();


            ListViewItem item = new ListViewItem();


            item.SubItems.Add("");
            lvwInfo.Items.Add(item);

            item = new ListViewItem();
            item.SubItems.Add("<goodsGroup>");
            lvwInfo.Items.Add(item);

            item = new ListViewItem();
            item.SubItems.Add("group_code");
            item.SubItems.Add("group_name");
            item.SubItems.Add("column");
            item.SubItems.Add("row");
            item.SubItems.Add("columnspan");
            item.SubItems.Add("rowspan");
            lvwInfo.Items.Add(item);


            for (int i = 0; i < mGoodsGroup.Length; i++)
            {
                item = new ListViewItem();
                item.SubItems.Add(mGoodsGroup[i].group_code);
                item.SubItems.Add(mGoodsGroup[i].group_name);
                item.SubItems.Add(mGoodsGroup[i].column.ToString());
                item.SubItems.Add(mGoodsGroup[i].row.ToString());
                item.SubItems.Add(mGoodsGroup[i].columnspan.ToString());
                item.SubItems.Add(mGoodsGroup[i].rowspan.ToString());
                lvwInfo.Items.Add(item);
            }


            item = new ListViewItem();
            item.SubItems.Add("");
            lvwInfo.Items.Add(item);

            item = new ListViewItem();
            item.SubItems.Add("<goodsItem>");
            lvwInfo.Items.Add(item);




            item = new ListViewItem();
            item.SubItems.Add("group_code");
            item.SubItems.Add("item_code");
            item.SubItems.Add("item_name");
            item.SubItems.Add("amt");
            item.SubItems.Add("ticket");
            item.SubItems.Add("taxfree");
            item.SubItems.Add("column");
            item.SubItems.Add("row");
            item.SubItems.Add("columnspan");
            item.SubItems.Add("rowspan");
            lvwInfo.Items.Add(item);


            for (int i = 0; i < mGoodsItem.Length; i++)
            {
                item = new ListViewItem();
                item.SubItems.Add(mGoodsItem[i].group_code);
                item.SubItems.Add(mGoodsItem[i].item_code);
                item.SubItems.Add(mGoodsItem[i].item_name);
                item.SubItems.Add(mGoodsItem[i].amt.ToString());
                item.SubItems.Add(mGoodsItem[i].ticket);
                item.SubItems.Add(mGoodsItem[i].taxfree);
                item.SubItems.Add(mGoodsItem[i].column.ToString());
                item.SubItems.Add(mGoodsItem[i].row.ToString());
                item.SubItems.Add(mGoodsItem[i].columnspan.ToString());
                item.SubItems.Add(mGoodsItem[i].rowspan.ToString());
                lvwInfo.Items.Add(item);
            }



            item = new ListViewItem();
            item.SubItems.Add("");
            lvwInfo.Items.Add(item);

            item = new ListViewItem();
            item.SubItems.Add("<Order>");
            lvwInfo.Items.Add(item);

            item = new ListViewItem();
            item.SubItems.Add("site_id");
            item.SubItems.Add("biz_dt");
            item.SubItems.Add("pos_no");
            item.SubItems.Add("the_no");
            item.SubItems.Add("ref_no");

            item.SubItems.Add("order_date");
            item.SubItems.Add("order_time");
            item.SubItems.Add("cnt");
            item.SubItems.Add("is_cancel");
            lvwInfo.Items.Add(item);


            for (int i = 0; i < listOrder.Count; i++)
            {
                item = new ListViewItem();
                item.SubItems.Add(listOrder[i].site_id);
                item.SubItems.Add(listOrder[i].biz_dt);
                item.SubItems.Add(listOrder[i].pos_no);
                item.SubItems.Add(listOrder[i].the_no);
                item.SubItems.Add(listOrder[i].ref_no);

                item.SubItems.Add(listOrder[i].order_date);
                item.SubItems.Add(listOrder[i].order_time);
                item.SubItems.Add(listOrder[i].cnt + "");
                item.SubItems.Add(listOrder[i].is_cancel);
                lvwInfo.Items.Add(item);
            }


            item = new ListViewItem();
            lvwInfo.Items.Add(item);

            item = new ListViewItem();
            item.SubItems.Add("<OrderItem>");
            lvwInfo.Items.Add(item);

            //
            item = new ListViewItem();
            item.SubItems.Add("site_id");
            item.SubItems.Add("biz_dt");
            item.SubItems.Add("pos_no");
            item.SubItems.Add("the_no");
            item.SubItems.Add("ref_no");

            item.SubItems.Add("order_date");
            item.SubItems.Add("order_time");
            item.SubItems.Add("code");
            item.SubItems.Add("name");
            item.SubItems.Add("cnt");
            item.SubItems.Add("amt");
            item.SubItems.Add("ticket");
            item.SubItems.Add("taxfree");
            item.SubItems.Add("dc_amount");
            item.SubItems.Add("dcr_type");
            item.SubItems.Add("dcr_des");
            item.SubItems.Add("dcr_value");
            item.SubItems.Add("pay_class");
            item.SubItems.Add("ticket_no");
            item.SubItems.Add("is_cancel");
            lvwInfo.Items.Add(item);


            for (int i = 0; i < listOrderItem.Count; i++)
            {
                item = new ListViewItem();
                item.SubItems.Add(listOrderItem[i].site_id);
                item.SubItems.Add(listOrderItem[i].biz_dt);
                item.SubItems.Add(listOrderItem[i].pos_no);
                item.SubItems.Add(listOrderItem[i].the_no);
                item.SubItems.Add(listOrderItem[i].ref_no);

                item.SubItems.Add(listOrderItem[i].order_date);
                item.SubItems.Add(listOrderItem[i].order_time);
                item.SubItems.Add(listOrderItem[i].code);
                item.SubItems.Add(listOrderItem[i].name);
                item.SubItems.Add(listOrderItem[i].cnt + "");
                item.SubItems.Add(listOrderItem[i].amt + "");
                item.SubItems.Add(listOrderItem[i].ticket);
                item.SubItems.Add(listOrderItem[i].taxfree);
                item.SubItems.Add(listOrderItem[i].dc_amount + "");
                item.SubItems.Add(listOrderItem[i].dcr_type);
                item.SubItems.Add(listOrderItem[i].dcr_des);
                item.SubItems.Add(listOrderItem[i].dcr_value + "");
                item.SubItems.Add(listOrderItem[i].pay_class);
                item.SubItems.Add(listOrderItem[i].ticket_no);
                item.SubItems.Add(listOrderItem[i].is_cancel);
                lvwInfo.Items.Add(item);
            }



            item = new ListViewItem();
            lvwInfo.Items.Add(item);

            item = new ListViewItem();
            item.SubItems.Add("<Payment>");
            lvwInfo.Items.Add(item);

            //
            item = new ListViewItem();
            item.SubItems.Add("site_id");
            item.SubItems.Add("biz_dt");
            item.SubItems.Add("pos_no");
            item.SubItems.Add("the_no");
            item.SubItems.Add("ref_no");

            item.SubItems.Add("pay_date");
            item.SubItems.Add("pay_time");
            item.SubItems.Add("tran_type");
            item.SubItems.Add("pay_class");
            item.SubItems.Add("bill_no");
            item.SubItems.Add("net_amount");
            item.SubItems.Add("amount_cash");
            item.SubItems.Add("amount_card");
            item.SubItems.Add("amount_easy");
            item.SubItems.Add("amount_point");
            item.SubItems.Add("is_dc");
            item.SubItems.Add("is_cancel");
            lvwInfo.Items.Add(item);


            for (int i = 0; i < mPayments.Count; i++)
            {
                item = new ListViewItem();
                item.SubItems.Add(mPayments[i].site_id);
                item.SubItems.Add(mPayments[i].biz_dt);
                item.SubItems.Add(mPayments[i].pos_no);
                item.SubItems.Add(mPayments[i].the_no);
                item.SubItems.Add(mPayments[i].ref_no);

                item.SubItems.Add(mPayments[i].pay_date);
                item.SubItems.Add(mPayments[i].pay_time);
                item.SubItems.Add(mPayments[i].tran_type);
                item.SubItems.Add(mPayments[i].pay_class);
                item.SubItems.Add(mPayments[i].bill_no);
                item.SubItems.Add(mPayments[i].net_amount+"");
                item.SubItems.Add(mPayments[i].amount_cash + "");
                item.SubItems.Add(mPayments[i].amount_card + "");
                item.SubItems.Add(mPayments[i].amount_easy + "");
                item.SubItems.Add(mPayments[i].amount_point + "");
                item.SubItems.Add(mPayments[i].is_dc);
                item.SubItems.Add(mPayments[i].is_cancel);
                lvwInfo.Items.Add(item);
            }



            item = new ListViewItem();
            lvwInfo.Items.Add(item);

            item = new ListViewItem();
            item.SubItems.Add("<PaymentCard>");
            lvwInfo.Items.Add(item);

            //
            item = new ListViewItem();
            item.SubItems.Add("site_id");
            item.SubItems.Add("biz_dt");
            item.SubItems.Add("pos_no");
            item.SubItems.Add("the_no");
            item.SubItems.Add("ref_no");

            item.SubItems.Add("pay_date");
            item.SubItems.Add("pay_time");
            item.SubItems.Add("pay_type");
            item.SubItems.Add("tran_type");
            item.SubItems.Add("pay_class");
            item.SubItems.Add("ticket_no");
            item.SubItems.Add("pay_seq");
            item.SubItems.Add("tran_date");
            item.SubItems.Add("amount");
            item.SubItems.Add("install");
            item.SubItems.Add("auth_no");
            item.SubItems.Add("card_no");
            item.SubItems.Add("card_name");
            item.SubItems.Add("isu_code");
            item.SubItems.Add("acq_code");
            item.SubItems.Add("merchant_no");
            item.SubItems.Add("tran_serial");
            item.SubItems.Add("is_cancel");
            lvwInfo.Items.Add(item);


            for (int i = 0; i < mPaymentCards.Count; i++)
            {
                item = new ListViewItem();
                item.SubItems.Add(mPaymentCards[i].site_id);
                item.SubItems.Add(mPaymentCards[i].biz_dt);
                item.SubItems.Add(mPaymentCards[i].pos_no);
                item.SubItems.Add(mPaymentCards[i].the_no);
                item.SubItems.Add(mPaymentCards[i].ref_no);

                item.SubItems.Add(mPaymentCards[i].pay_date);
                item.SubItems.Add(mPaymentCards[i].pay_time);
                item.SubItems.Add(mPaymentCards[i].pay_type);
                item.SubItems.Add(mPaymentCards[i].tran_type);
                item.SubItems.Add(mPaymentCards[i].pay_class);
                item.SubItems.Add(mPaymentCards[i].ticket_no);
                item.SubItems.Add(mPaymentCards[i].pay_seq+"");
                item.SubItems.Add(mPaymentCards[i].tran_date);
                item.SubItems.Add(mPaymentCards[i].amount+"");          // 결제금액
                item.SubItems.Add(mPaymentCards[i].install);      // 할부개월 00 03
                item.SubItems.Add(mPaymentCards[i].auth_no);      // 승인번호
                item.SubItems.Add(mPaymentCards[i].card_no);      // 카드번호
                item.SubItems.Add(mPaymentCards[i].card_name);    // 카드종류
                item.SubItems.Add(mPaymentCards[i].isu_code);     // 발급사코드
                item.SubItems.Add(mPaymentCards[i].acq_code);     // 매입사코드
                item.SubItems.Add(mPaymentCards[i].merchant_no);  // 가맹점번호
                item.SubItems.Add(mPaymentCards[i].tran_serial);          // tran_serial -> 취소시 tid입력
                item.SubItems.Add(mPaymentCards[i].is_cancel);
                lvwInfo.Items.Add(item);
            }



            item = new ListViewItem();
            lvwInfo.Items.Add(item);

            item = new ListViewItem();
            item.SubItems.Add("<PaymentCash>");
            lvwInfo.Items.Add(item);

            //
            item = new ListViewItem();
            item.SubItems.Add("site_id");
            item.SubItems.Add("biz_dt");
            item.SubItems.Add("pos_no");
            item.SubItems.Add("the_no");
            item.SubItems.Add("ref_no");

            item.SubItems.Add("pay_date");
            item.SubItems.Add("pay_time");
            item.SubItems.Add("pay_type");
            item.SubItems.Add("tran_type");
            item.SubItems.Add("pay_class");
            item.SubItems.Add("ticket_no");
            item.SubItems.Add("pay_seq");
            item.SubItems.Add("tran_date");
            item.SubItems.Add("amount");
            item.SubItems.Add("receipt_type");
            item.SubItems.Add("issued_method_no");
            item.SubItems.Add("auth_no");
            item.SubItems.Add("tran_serial");
            item.SubItems.Add("is_cancel");
            lvwInfo.Items.Add(item);


            for (int i = 0; i < mPaymentCashs.Count; i++)
            {
                item = new ListViewItem();
                item.SubItems.Add(mPaymentCashs[i].site_id);
                item.SubItems.Add(mPaymentCashs[i].biz_dt);
                item.SubItems.Add(mPaymentCashs[i].pos_no);
                item.SubItems.Add(mPaymentCashs[i].the_no);
                item.SubItems.Add(mPaymentCashs[i].ref_no);

                item.SubItems.Add(mPaymentCashs[i].pay_date);
                item.SubItems.Add(mPaymentCashs[i].pay_time);
                item.SubItems.Add(mPaymentCashs[i].pay_type);
                item.SubItems.Add(mPaymentCashs[i].tran_type);
                item.SubItems.Add(mPaymentCashs[i].pay_class);
                item.SubItems.Add(mPaymentCashs[i].ticket_no);
                item.SubItems.Add(mPaymentCashs[i].pay_seq + "");
                item.SubItems.Add(mPaymentCashs[i].tran_date);
                item.SubItems.Add(mPaymentCashs[i].amount + "");
                item.SubItems.Add(mPaymentCashs[i].receipt_type);
                item.SubItems.Add(mPaymentCashs[i].issued_method_no);
                item.SubItems.Add(mPaymentCashs[i].auth_no);
                item.SubItems.Add(mPaymentCashs[i].tran_serial);          // tran_serial -> 취소시 tid입력
                item.SubItems.Add(mPaymentCashs[i].is_cancel);
                lvwInfo.Items.Add(item);
            }


            item = new ListViewItem();
            lvwInfo.Items.Add(item);

            item = new ListViewItem();
            item.SubItems.Add("<PaymentPoint>");
            lvwInfo.Items.Add(item);

            //
            item = new ListViewItem();
            item.SubItems.Add("site_id");
            item.SubItems.Add("biz_dt");
            item.SubItems.Add("pos_no");
            item.SubItems.Add("the_no");
            item.SubItems.Add("ref_no");

            item.SubItems.Add("pay_date");
            item.SubItems.Add("pay_time");
            item.SubItems.Add("pay_type");
            item.SubItems.Add("tran_type");
            item.SubItems.Add("pay_class");
            item.SubItems.Add("ticket_no");
            item.SubItems.Add("usage_no");
            item.SubItems.Add("amount");
            item.SubItems.Add("is_cancel");
            lvwInfo.Items.Add(item);


            for (int i = 0; i < mPaymentPoints.Count; i++)
            {
                item = new ListViewItem();
                item.SubItems.Add(mPaymentPoints[i].site_id);
                item.SubItems.Add(mPaymentPoints[i].biz_dt);
                item.SubItems.Add(mPaymentPoints[i].pos_no);
                item.SubItems.Add(mPaymentPoints[i].the_no);
                item.SubItems.Add(mPaymentPoints[i].ref_no);

                item.SubItems.Add(mPaymentPoints[i].pay_date);
                item.SubItems.Add(mPaymentPoints[i].pay_time);
                item.SubItems.Add(mPaymentPoints[i].pay_type);
                item.SubItems.Add(mPaymentPoints[i].tran_type);
                item.SubItems.Add(mPaymentPoints[i].pay_class);
                item.SubItems.Add(mPaymentPoints[i].ticket_no);
                item.SubItems.Add(mPaymentPoints[i].usage_no);
                item.SubItems.Add(mPaymentPoints[i].amount + "");
                item.SubItems.Add(mPaymentPoints[i].is_cancel);
                lvwInfo.Items.Add(item);
            }



            item = new ListViewItem();
            lvwInfo.Items.Add(item);

            item = new ListViewItem();
            item.SubItems.Add("<TicketFlow>");
            lvwInfo.Items.Add(item);

            //
            item = new ListViewItem();
            item.SubItems.Add("site_id");
            item.SubItems.Add("biz_dt");
            item.SubItems.Add("the_no");
            item.SubItems.Add("ref_no");

            item.SubItems.Add("ticket_no");
            item.SubItems.Add("ticketing_dt");
            item.SubItems.Add("charge_dt");
            item.SubItems.Add("settlement_dt");
            item.SubItems.Add("point_charge");
            item.SubItems.Add("point_usage");

            item.SubItems.Add("settle_point_charge");
            item.SubItems.Add("settle_point_usage");

            item.SubItems.Add("goods_code");
            item.SubItems.Add("flow_step");
            item.SubItems.Add("locker_no");
            item.SubItems.Add("open_locker");
            lvwInfo.Items.Add(item);


            for (int i = 0; i < mTicketFlowList.Count; i++)
            {
                item = new ListViewItem();
                item.SubItems.Add(mTicketFlowList[i].site_id);
                item.SubItems.Add(mTicketFlowList[i].biz_dt);
                item.SubItems.Add(mTicketFlowList[i].the_no);
                item.SubItems.Add(mTicketFlowList[i].ref_no);

                item.SubItems.Add(mTicketFlowList[i].ticket_no);
                item.SubItems.Add(mTicketFlowList[i].ticketing_dt);
                item.SubItems.Add(mTicketFlowList[i].charge_dt);
                item.SubItems.Add(mTicketFlowList[i].settlement_dt);
                item.SubItems.Add(mTicketFlowList[i].point_charge+"");
                item.SubItems.Add(mTicketFlowList[i].point_usage+"");
                item.SubItems.Add(mTicketFlowList[i].settle_point_charge + "");
                item.SubItems.Add(mTicketFlowList[i].settle_point_usage + "");
                item.SubItems.Add(mTicketFlowList[i].goods_code);
                item.SubItems.Add(mTicketFlowList[i].flow_step);
                item.SubItems.Add(mTicketFlowList[i].locker_no);
                item.SubItems.Add(mTicketFlowList[i].open_locker);
                lvwInfo.Items.Add(item);
            }

        }
    }
}
