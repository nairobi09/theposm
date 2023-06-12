using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using PrinterUtility;

using static thepos.theSale;
using static thepos.frmSale;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace thepos
{
    public partial class frmPayManager : Form
    {

        System.Windows.Forms.TextBox saveKeyDisplay;





        public frmPayManager()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();
        }

        private void initialize_font()
        {
            lblTitle.Font = font12;
            btnClose.Font = font12;

            dtBusiness.Font = font10;

            lbl1.Font = font9;
            lbl2.Font = font9;
            lbl3.Font = font9;

            dtBusiness.Font = font10;
            cbPosNo.Font = font10;
            tbBillNo.Font = font14;

            btnView.Font = font10;
            lvwPayManager.Font = font10;


        }
        private void initialize_the()
        {
            dtBusiness.Value = DateTime.Now;


            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);
            lvwPayManager.SmallImageList = imgList;

            cbPosNo.Items.Clear();
            for (int i = 0; i < mPosNoList.Length; i++)
            {
                cbPosNo.Items.Add(mPosNoList[i]);

                if (mPosNoList[i] == mPosNo) cbPosNo.SelectedIndex = i;
            }


            saveKeyDisplay = mTbKeyDisplayController;
            mTbKeyDisplayController = tbBillNo;

        }


        private void btnView_Click(object sender, EventArgs e)
        {

            viewList();
        }

        private void viewList()
        { 

            lvwPayManager.Items.Clear();

            for (int i = 0; i < mPayments.Count; i++)
            {
                ListViewItem lvItem = new ListViewItem();

                lvItem.Tag = mPayments[i].the_no;
                lvItem.Text = (i + 1).ToString();
                lvItem.SubItems.Add(get_MMddHHmm(mPayments[i].pay_date, mPayments[i].pay_time));

                lvItem.SubItems.Add(get_tran_type_name(mPayments[i].tran_type));

                lvItem.SubItems.Add(mPayments[i].pos_no);
                lvItem.SubItems.Add(mPayments[i].bill_no);

                if (mPayments[i].tran_type == "C")
                    lvItem.SubItems.Add((-mPayments[i].net_amount).ToString("N0"));
                else
                    lvItem.SubItems.Add(mPayments[i].net_amount.ToString("N0"));

                //? 할인내용 적용 필요
                lvItem.SubItems.Add(mPayments[i].is_dc);
                lvItem.SubItems.Add(get_is_cancel_name(mPayments[i].is_cancel));
                lvItem.SubItems.Add(mPayments[i].tran_type);

                //? mPayments[i].is_cancel == "Y" 명 Strikeout으로 바꾼다.
                //lvItem.Font = new Font(lvItem.Font, FontStyle.Strikeout);

                lvwPayManager.Items.Add(lvItem);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPayManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSale.ConsoleEnable();
            mTbKeyDisplayController = saveKeyDisplay;
            
        }

        private void lvwPayManager_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvwPayManager.Columns[e.ColumnIndex].Width;
        }

        private void lvwPayManager_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblLayoutBill.Text = "";

            if (lvwPayManager.SelectedItems.Count <= 0)
            {
                return;
            }



            String tTheNo = lvwPayManager.SelectedItems[0].Tag.ToString();
            String tranType = lvwPayManager.SelectedItems[0].SubItems[8].Text;


            lblLayoutBill.Text = make_bill_body(tTheNo, tranType, "");
        }


        private String make_bill_body(String tTheNo, String tranType, String except_order)
        {

            String strPrintTitle = "";
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
            int space_cnt = 44 - (encodelen(tOrderDt) + encodelen(tStr));
            strPrintTitle = tOrderDt + Space(space_cnt) + tStr;


            strPrintOrder = "--------------------------------------------\r\n";  // 44
            strPrintOrder += "상품명                   단가  수량     금액\r\n";
            strPrintOrder += "--------------------------------------------\r\n";  // 44
            

            for (int i = 0; i < listOrderItem.Count; i++)
            {
                if (listOrderItem[i].the_no == tTheNo)
                {

                    if (listOrderItem[i].dcr_des == "E") // 전체할인
                    {
                        if (listOrderItem[i].dcr_type == "A")
                        {
                            tStr = "전체할인";
                            strPrintOrder += tStr + Space(22 - encodelen(tStr));

                            tStr = (-listOrderItem[i].dc_amount).ToString("N0");        // 할인 정액
                            strPrintOrder += Space(22 - encodelen(tStr)) + tStr;
                        }
                        else if (listOrderItem[i].dcr_type == "R")
                        {
                            tStr = "전체할인-" + listOrderItem[i].dcr_value + "%";
                            strPrintOrder += tStr + Space(22 - encodelen(tStr));

                            tStr = (-listOrderItem[i].dc_amount).ToString("N0");        // 할인 정액
                            strPrintOrder += Space(22 - encodelen(tStr)) + tStr;
                        }
                        strPrintOrder += "\r\n";
                    }
                    else                                 // 일반상품항목
                    {
                        tStr = listOrderItem[i].name;
                        strPrintOrder += tStr + Space(20 - encodelen(tStr));

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
                            strPrintOrder += tStr + Space(22 - encodelen(tStr));

                            tStr = (-listOrderItem[i].dc_amount).ToString("N0");        // 할인 정액
                            strPrintOrder += Space(22 - encodelen(tStr)) + tStr;

                            strPrintOrder += "\r\n";
                        }
                        else if (listOrderItem[i].dcr_type == "R")
                        {
                            tStr = "    할인-" + listOrderItem[i].dcr_value + "%";
                            strPrintOrder += tStr + Space(22 - encodelen(tStr));

                            tStr = (-listOrderItem[i].dc_amount).ToString("N0");        // 할인 정액
                            strPrintOrder += Space(22 - encodelen(tStr)) + tStr;

                            strPrintOrder += "\r\n";
                        }
                    }

                    if (listOrderItem[i].taxfree == "1") tfree_amount += (listOrderItem[i].cnt * listOrderItem[i].amt);
                    else tax_amount += (listOrderItem[i].cnt * listOrderItem[i].amt);

                    dc_amount += listOrderItem[i].dc_amount;
                }
            }


            ////
            strPrintPayment = "--------------------------------------------\r\n";  // 44

            if (tfree_amount > 0)
            {
                tStr = "*면세품목가액";
                strPrintPayment += tStr + Space(22 - encodelen(tStr));

                tStr = (tfree_amount).ToString("N0");
                strPrintPayment += Space(22 - encodelen(tStr)) + tStr;

                strPrintPayment += "\r\n";
            }

            if (tax_amount > 0)
            {
                int t_tax = tax_amount / 11;   // 부가세액
                int t_amt = tax_amount - t_tax; // 공급가액

                tStr = "과세품목가액";
                strPrintPayment += tStr + Space(22 - encodelen(tStr));
                tStr = (t_amt).ToString("N0");
                strPrintPayment += Space(22 - encodelen(tStr)) + tStr;
                strPrintPayment += "\r\n";

                tStr = "부 가 세 액";
                strPrintPayment += tStr + Space(22 - encodelen(tStr));
                tStr = (t_tax).ToString("N0");
                strPrintPayment += Space(22 - encodelen(tStr)) + tStr;
                strPrintPayment += "\r\n";
            }

            strPrintPayment += "--------------------------------------------\r\n";  // 44

            int tsum = tfree_amount + tax_amount;
            int tnet = tsum - dc_amount;


            tStr = "총합계";
            strPrintPayment += tStr + Space(22 - encodelen(tStr));
            tStr = (tsum).ToString("N0");
            strPrintPayment += Space(22 - encodelen(tStr)) + tStr;
            strPrintPayment += "\r\n";

            tStr = "할인계";
            strPrintPayment += tStr + Space(22 - encodelen(tStr));
            tStr = (-dc_amount).ToString("N0");
            strPrintPayment += Space(22 - encodelen(tStr)) + tStr;
            strPrintPayment += "\r\n";

            tStr = "결제대상금액";
            strPrintPayment += tStr + Space(22 - encodelen(tStr));
            tStr = (tnet).ToString("N0");
            strPrintPayment += Space(22 - encodelen(tStr)) + tStr;
            strPrintPayment += "\r\n";

            strPrintPayment += "--------------------------------------------\r\n";  // 44



            // 현금결제
            for (int i = 0; i < mPaymentCashs.Count; i++)
            {
                if (mPaymentCashs[i].the_no == tTheNo & mPaymentCashs[i].tran_type == tranType)
                {
                    if (mPaymentCashs[i].pay_type == "R0")           // 단순현금
                    {
                        tStr = "현금";
                        strPrintPayment += tStr + Space(22 - encodelen(tStr));

                        if (tranType == "C")
                            tStr = (-mPaymentCashs[i].amount).ToString("N0");
                        else
                            tStr = mPaymentCashs[i].amount.ToString("N0");

                        strPrintPayment += Space(22 - encodelen(tStr)) + tStr;

                    }
                    else if (mPaymentCashs[i].pay_type == "R1")     // 
                    {
                        tStr = "현금영수증";
                        strPrintPayment += tStr + Space(22 - encodelen(tStr));

                        if (tranType == "C")
                            tStr = (-mPaymentCashs[i].amount).ToString("N0");
                        else
                            tStr = mPaymentCashs[i].amount.ToString("N0");

                        strPrintPayment += Space(22 - encodelen(tStr)) + tStr;
                        strPrintPayment += "\r\n";

                        if (mPaymentCashs[i].receipt_type == "1") // 소득공제
                        {
                            tStr = "소득공제";
                        }
                        else if (mPaymentCashs[i].receipt_type == "2") // 지출증빙
                        {
                            tStr = "지출증빙";
                        }
                        strPrintPayment += tStr + Space(22 - encodelen(tStr));


                        String no = mPaymentCashs[i].issued_method_no;
                        if (no.Length == 16)
                        {
                            tStr = no.Substring(0, 4) + "-" + no.Substring(4, 4) + "-****-" + no.Substring(12, 3) + "*";
                        }
                        else if (no.Length == 11 & no.Substring(0,3) == "010")
                        {
                            tStr = no.Substring(0, 3) + "-****-" + no.Substring(6,4);
                        }
                        else if (no.Length > 8)
                        {
                            tStr = no.Substring(0, 8) + CharCount('*', no.Length - 8);
                        }
                        else
                        {
                            tStr = no;
                        }

                        strPrintPayment += Space(22 - encodelen(tStr)) + tStr;
                    }
                    else if (mPaymentCashs[i].pay_type == "R0")     //  자진발급
                    {
                        tStr = "현금영수증";
                        strPrintPayment += tStr + Space(22 - encodelen(tStr));

                        if (tranType == "C")
                            tStr = (-mPaymentCashs[i].amount).ToString("N0");
                        else
                            tStr = mPaymentCashs[i].amount.ToString("N0");

                        strPrintPayment += Space(22 - encodelen(tStr)) + tStr;

                        tStr = "자진발급";
                        strPrintPayment += tStr + Space(22 - encodelen(tStr));
                        tStr = mPaymentCashs[i].issued_method_no;
                        strPrintPayment += Space(22 - encodelen(tStr)) + tStr;
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
                        

                    strPrintPayment += tStr + Space(22 - encodelen(tStr));

                    if (tranType == "C")
                        tStr = (-mPaymentCards[i].amount).ToString("N0");
                    else
                        tStr = mPaymentCards[i].amount.ToString("N0");

                    strPrintPayment += Space(22 - encodelen(tStr)) + tStr;
                    strPrintPayment += "\r\n";

                    tStr = mPaymentCards[i].card_name;
                    strPrintPayment += tStr + Space(22 - encodelen(tStr));

                    String no = mPaymentCards[i].card_no;

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



                    strPrintPayment += Space(22 - encodelen(tStr)) + tStr;
                    strPrintPayment += "\r\n";

                    
                    if (mPaymentCards[i].install == "00")
                        tStr = "할부개월:일시불";
                    else
                        tStr = "할부개월:" + mPaymentCards[i].install;

                    strPrintPayment += tStr + Space(22 - encodelen(tStr));
                    tStr = "승인번호:" + mPaymentCards[i].auth_no;
                    strPrintPayment += Space(22 - encodelen(tStr)) + tStr;
                    strPrintPayment += "\r\n";
                    strPrintPayment += "\r\n";
                }
            }


            strPrintPayment += "--------------------------------------------\r\n";  // 44

            if (except_order == "Y")
            {
                return strPrintTitle + strPrintPayment;
            }
            else
            {
                return strPrintTitle + strPrintOrder + strPrintPayment;
            }
        }


        public string Space(int count)
        {
            return new String(' ', count);
        }

        public string CharCount(char c, int count)
        {
            return new String(c, count);
        }


        private int encodelen(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }



        private void btnPrint_Click(object sender, EventArgs e)
        {



            PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();
            byte[] BytesValue = new byte[0];  // 바이트크기는 0세팅부터 시작

            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

            string str = Encoding.Default.GetString(BytesValue);

            lblLayoutBill.Text = str;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            if (lvwPayManager.SelectedItems.Count < 1)
            {
                SetDisplayAlarm("W", "대상거래 선택요망.");
                return; 
            }

            String the_no = lvwPayManager.SelectedItems[0].Tag.ToString();
            Payment payment = get_payment_by_theno(the_no);

            /* //? 제외
            if (payment.is_cancel == "Y")
            {
                SetDisplayAlarm("W", "기취소건.");
                return;
            }
            */

            int sel_idx = lvwPayManager.SelectedItems[0].Index;

            frmPayCancel fPayCancel = new frmPayCancel(the_no);
            fPayCancel.Left += this.Location.X;
            fPayCancel.Top += this.Location.Y;
            fPayCancel.ShowDialog();


            payment = get_payment_by_theno(the_no);

            //? 취소여부 화면갱신
            //lvwPayManager.Items[sel_idx].SubItems[7].Text = payment.is_cancel.ToString();
            viewList();


        }

        private Payment get_payment_by_theno(String the_no)
        {
            Payment p = new Payment();

            for (int i = 0; i < mPayments.Count; i++)
            {
                if (mPayments[i].the_no == the_no)
                {
                    p = mPayments[i];
                    return p;
                }
            }

            return p;
        }

        private void cbwithoutGoods_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
