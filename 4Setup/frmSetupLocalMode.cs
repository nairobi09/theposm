using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.thePos;

namespace thepos
{
    public partial class frmSetupLocalMode : Form
    {

        int upload_cnt = 0;
        public frmSetupLocalMode()
        {
            InitializeComponent();

            initialize_font();

        }


        private void initialize_font()
        {
            lblTitle.Font = font10;

            lblCntTitle.Font = font10;
            lblCnt0Title.Font = font10;
            
            lblOrdersTitle.Font = font10;
            lblOrdersCnt.Font = font10;
            lblOrdersCnt0.Font = font10;

            lblOrderItemTitle.Font = font10;
            lblOrderItemCnt.Font = font10;
            lblOrderItemCnt0.Font = font10;

            lblPaymentTitle.Font = font10;
            lblPaymentCnt.Font = font10;
            lblPaymentCnt0.Font = font10;

            lblPaymentCashTitle.Font = font10;
            lblPaymentCashCnt.Font = font10;
            lblPaymentCashCnt0.Font = font10;

            lblPaymentCardTitle.Font = font10;
            lblPaymentCardCnt.Font = font10;
            lblPaymentCardCnt0.Font = font10;

            btnView.Font = font10;
            btnUpload.Font = font10;
            btnDelete.Font = font10;
        }



        private void btnView_Click(object sender, EventArgs e)
        {
            view_local();


        }

        private void view_local()
        { 
            //
            String sql = "SELECT count(*) as cnt FROM orders";
            SQLiteDataReader dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                lblOrdersCnt.Text = dr["cnt"].ToString();
            }
            dr.Close();


            sql = "SELECT count(*) as cnt FROM orderItem";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                lblOrderItemCnt.Text = dr["cnt"].ToString();
            }
            dr.Close();


            //
            sql = "SELECT count(*) as cnt FROM payment";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                lblPaymentCnt.Text = dr["cnt"].ToString();
            }
            dr.Close();


            //
            sql = "SELECT count(*) as cnt FROM paymentCash";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                lblPaymentCashCnt.Text = dr["cnt"].ToString();
            }
            dr.Close();


            //
            sql = "SELECT count(*) as cnt FROM paymentCard";
            dr = sql_select_local_db(sql);
            if (dr.Read())
            {
                lblPaymentCardCnt.Text = dr["cnt"].ToString();
            }
            dr.Close();


        }


        private void btnUpload_Click(object sender, EventArgs e)
        {
            upload_cnt = 0;


            // orders
            String sql = "SELECT * FROM orders";
            SQLiteDataReader dr = sql_select_local_db(sql);
            while (dr.Read())
            {
                String seq_key = dr["seq_key"].ToString();
                String send_YN = dr["send_YN"].ToString();
                String send_dt = dr["send_dt"].ToString();

                if (send_YN == "Y")
                {
                    // 
                }
                else
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Clear();
                    parameters["siteId"] = dr["siteId"].ToString();
                    parameters["posNo"] = dr["posNo"].ToString();
                    parameters["bizDt"] = dr["bizDt"].ToString();
                    parameters["theNo"] = dr["theNo"].ToString();
                    parameters["refNo"] = dr["refNo"].ToString();

                    parameters["orderDate"] = dr["orderDate"].ToString();
                    parameters["orderTime"] = dr["orderTime"].ToString();
                    parameters["tranType"] = dr["tranType"].ToString();
                    parameters["cnt"] = dr["cnt"].ToString();
                    parameters["isCancel"] = dr["isCancel"].ToString();

                    if (mRequestPost("orders", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                            sql = "UPDATE orders SET send_YN = 'Y' WHERE seq_key = '" + seq_key + "'";
                            int ret = sql_excute_local_db(sql);

                            upload_cnt++;

                        }
                        else
                        {
                            MessageBox.Show("오류 orders\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류 orders\n\n" + mErrorMsg, "thepos");
                        return;
                    }

                    
                }
            }
            dr.Close();

            
            // orderItem
            sql = "SELECT * FROM orderItem";
            dr = sql_select_local_db(sql);
            while (dr.Read())
            {
                String seq_key = dr["seq_key"].ToString();
                String send_YN = dr["send_YN"].ToString();
                String send_dt = dr["send_dt"].ToString();

                if (send_YN == "Y")
                {
                    // 
                }
                else
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Clear();
                    parameters["siteId"] = dr["siteId"].ToString();
                    parameters["posNo"] = dr["posNo"].ToString();
                    parameters["bizDt"] = dr["bizDt"].ToString();
                    parameters["theNo"] = dr["theNo"].ToString();
                    parameters["refNo"] = dr["refNo"].ToString();

                    parameters["orderDate"] = dr["orderDate"].ToString();
                    parameters["orderTime"] = dr["orderTime"].ToString();
                    parameters["tranType"] = dr["tranType"].ToString();
                    parameters["itemCode"] = dr["itemCode"].ToString();
                    parameters["itemName"] = dr["itemName"].ToString();

                    parameters["cnt"] = dr["cnt"].ToString();
                    parameters["amt"] = dr["amt"].ToString();
                    parameters["ticketYn"] = dr["ticketYn"].ToString();
                    parameters["taxFree"] = dr["taxFree"].ToString();
                    parameters["dcAmount"] = dr["dcAmount"].ToString();

                    parameters["dcrType"] = dr["dcrType"].ToString();
                    parameters["dcrDes"] = dr["dcrDes"].ToString();
                    parameters["dcrValue"] = dr["dcrValue"].ToString();
                    parameters["payClass"] = dr["payClass"].ToString();
                    parameters["ticketNo"] = dr["ticketNo"].ToString();

                    parameters["isCancel"] = dr["isCancel"].ToString();
                    parameters["shopCode"] = dr["shopCode"].ToString();
                    parameters["shopOrderNo"] = dr["shopOrderNo"].ToString();

                    if (mRequestPost("orderItem", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                            sql = "UPDATE orderItem SET send_YN = 'Y' WHERE seq_key = '" + seq_key + "'";
                            int ret = sql_excute_local_db(sql);

                            upload_cnt++;
                        }
                        else
                        {
                            MessageBox.Show("오류 orderItem\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류 orderItem\n\n" + mErrorMsg, "thepos");
                        return;
                    }
                }
            }
            dr.Close();


            // payment
            sql = "SELECT * FROM payment";
            dr = sql_select_local_db(sql);
            while (dr.Read())
            {
                String seq_key = dr["seq_key"].ToString();
                String send_YN = dr["send_YN"].ToString();
                String send_dt = dr["send_dt"].ToString();

                if (send_YN == "Y")
                {
                    // 
                }
                else
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Clear();
                    parameters["siteId"] = dr["siteId"].ToString();
                    parameters["posNo"] = dr["posNo"].ToString();
                    parameters["bizDt"] = dr["bizDt"].ToString();
                    parameters["theNo"] = dr["theNo"].ToString();
                    parameters["refNo"] = dr["refNo"].ToString();

                    parameters["payDate"] = dr["payDate"].ToString();
                    parameters["payTime"] = dr["payTime"].ToString();
                    parameters["tranType"] = dr["tranType"].ToString();
                    parameters["payClass"] = dr["payClass"].ToString();
                    parameters["billNo"] = dr["billNo"].ToString();

                    parameters["netAmount"] = dr["netAmount"].ToString();
                    parameters["amountCash"] = dr["amountCash"].ToString();
                    parameters["amountCard"] = dr["amountCard"].ToString();
                    parameters["amountEasy"] = dr["amountPoint"].ToString();
                    parameters["amountPoint"] = dr["amountEasy"].ToString();

                    parameters["dcAmount"] = dr["dcAmount"].ToString();
                    parameters["isCancel"] = dr["isCancel"].ToString();

                    if (mRequestPost("payment", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                            sql = "UPDATE payment SET send_YN = 'Y' WHERE seq_key = '" + seq_key + "'";
                            int ret = sql_excute_local_db(sql);

                            upload_cnt++;
                        }
                        else
                        {
                            MessageBox.Show("오류 payment\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류 payment\n\n" + mErrorMsg, "thepos");
                        return;
                    }
                }
            }
            dr.Close();


            // paymentCash
            sql = "SELECT * FROM paymentCash";
            dr = sql_select_local_db(sql);
            while (dr.Read())
            {
                String seq_key = dr["seq_key"].ToString();
                String send_YN = dr["send_YN"].ToString();
                String send_dt = dr["send_dt"].ToString();

                if (send_YN == "Y")
                {
                    // 
                }
                else
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Clear();
                    parameters["siteId"] = dr["siteId"].ToString();
                    parameters["posNo"] = dr["posNo"].ToString();
                    parameters["bizDt"] = dr["bizDt"].ToString();
                    parameters["theNo"] = dr["theNo"].ToString();
                    parameters["refNo"] = dr["refNo"].ToString();

                    parameters["payDate"] = dr["payDate"].ToString();
                    parameters["payTime"] = dr["payTime"].ToString();
                    parameters["payType"] = dr["payType"].ToString();
                    parameters["tranType"] = dr["tranType"].ToString();
                    parameters["payClass"] = dr["payClass"].ToString();

                    parameters["ticketNo"] = dr["ticketNo"].ToString();
                    parameters["paySeq"] = dr["paySeq"].ToString();
                    parameters["tranDate"] = dr["tranDate"].ToString();
                    parameters["amount"] = dr["amount"].ToString();
                    parameters["receiptType"] = dr["receiptType"].ToString();

                    parameters["issuedMethodNo"] = dr["issuedMethodNo"].ToString();
                    parameters["authNo"] = dr["authNo"].ToString();
                    parameters["tranSerial"] = dr["tranSerial"].ToString();
                    parameters["isCancel"] = dr["isCancel"].ToString();
                    parameters["vanCode"] = dr["vanCode"].ToString();

                    if (mRequestPost("paymentCash", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                            sql = "UPDATE paymentCash SET send_YN = 'Y' WHERE seq_key = '" + seq_key + "'";
                            int ret = sql_excute_local_db(sql);

                            upload_cnt++;
                        }
                        else
                        {
                            MessageBox.Show("오류 paymentCash\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류 paymentCash\n\n" + mErrorMsg, "thepos");
                        return;
                    }
                }
            }
            dr.Close();


            // paymentCard
            sql = "SELECT * FROM paymentCard";
            dr = sql_select_local_db(sql);
            while (dr.Read())
            {
                String seq_key = dr["seq_key"].ToString();
                String send_YN = dr["send_YN"].ToString();
                String send_dt = dr["send_dt"].ToString();

                if (send_YN == "Y")
                {
                    // 
                }
                else
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Clear();
                    parameters["siteId"] = dr["siteId"].ToString();
                    parameters["posNo"] = dr["posNo"].ToString();
                    parameters["bizDt"] = dr["bizDt"].ToString();
                    parameters["theNo"] = dr["theNo"].ToString();
                    parameters["refNo"] = dr["refNo"].ToString();

                    parameters["payDate"] = dr["payDate"].ToString();
                    parameters["payTime"] = dr["payTime"].ToString();
                    parameters["payType"] = dr["payType"].ToString();
                    parameters["tranType"] = dr["tranType"].ToString();
                    parameters["payClass"] = dr["payClass"].ToString();

                    parameters["ticketNo"] = dr["ticketNo"].ToString();
                    parameters["paySeq"] = dr["paySeq"].ToString();
                    parameters["tranDate"] = dr["tranDate"].ToString();
                    parameters["amount"] = dr["amount"].ToString();
                    parameters["taxAmount"] = dr["taxAmount"].ToString();

                    parameters["freeAmount"] = dr["freeAmount"].ToString();
                    parameters["serviceAmt"] = dr["serviceAmt"].ToString();
                    parameters["tax"] = dr["tax"].ToString();
                    parameters["install"] = dr["install"].ToString();
                    parameters["authNo"] = dr["authNo"].ToString();

                    parameters["cardNo"] = dr["cardNo"].ToString();
                    parameters["cardName"] = dr["cardName"].ToString();
                    parameters["isuCode"] = dr["isuCode"].ToString();
                    parameters["acqCode"] = dr["acqCode"].ToString();
                    parameters["merchantNo"] = dr["merchantNo"].ToString();

                    parameters["tranSerial"] = dr["tranSerial"].ToString();
                    parameters["signPath"] = dr["signPath"].ToString();
                    parameters["giftChange"] = dr["giftChange"].ToString();
                    parameters["isCancel"] = dr["isCancel"].ToString();
                    parameters["vanCode"] = dr["vanCode"].ToString();

                    if (mRequestPost("paymentCard", parameters))
                    {
                        if (mObj["resultCode"].ToString() == "200")
                        {
                            sql = "UPDATE paymentCard SET send_YN = 'Y' WHERE seq_key = '" + seq_key + "'";
                            int ret = sql_excute_local_db(sql);
                            
                            upload_cnt++;

                        }
                        else
                        {
                            MessageBox.Show("오류 paymentCard\n\n" + mObj["resultMsg"].ToString() + "\n" + mObj["detailMsg"].ToString(), "thepos");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("시스템오류 paymentCard\n\n" + mErrorMsg, "thepos");
                        return;
                    }
                }
            }
            dr.Close();


            MessageBox.Show("업로드 완료. 건수 = " + upload_cnt);


            view_local();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("삭제확인\r\n삭제후 원복이 불가합니다.", "thepos", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                String sql = "DELETE FROM orders";
                int ret = sql_excute_local_db(sql);

                sql = "DELETE FROM orderItem";
                ret = sql_excute_local_db(sql);

                sql = "DELETE FROM payment";
                ret = sql_excute_local_db(sql);

                sql = "DELETE FROM paymentCash";
                ret = sql_excute_local_db(sql);

                sql = "DELETE FROM paymentCard";
                ret = sql_excute_local_db(sql);

                MessageBox.Show("로컬 데이터 삭제 완료.");


                view_local();
            }



        }
    }
}
