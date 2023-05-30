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


namespace thepos
{
    public partial class frmPayManager : Form
    {



        public frmPayManager()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();
        }

        private void initialize_font()
        {
            lblTitle.Font = font12;
            dtBusiness.Font = font10;

            lbl1.Font = font9;
            lbl2.Font = font9;
            lbl3.Font = font9;

            dtBusiness.Font = font10;
            cbPosNo.Font = font10;
            tbBillNo.Font = font10;

            btnKeyInput.Font = font10;
            btnView.Font = font10;
            lvwPayManager.Font = font10;


            btnClose.Font = font12;

        }
        private void initialize_the()
        {
            dtBusiness.Value = DateTime.Now;


            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 30);

            lvwPayManager.SmallImageList = imgList;

            cbPosNo.Items.Clear();
            for (int i = 0; i < mCustomerPosNOs.Length; i++)
            {
                cbPosNo.Items.Add(mCustomerPosNOs[i]);
            }
            

        }


        private void btnKeyInput_Click(object sender, EventArgs e)
        {
            tbBillNo.Text = mLblKeyDisplay.Text;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            lvwPayManager.Items.Clear();

            for (int i = 0; i < mPayments.Count; i++)
            {
                ListViewItem lvItem = new ListViewItem();

                lvItem.Tag = mPayments[i].the_no;
                lvItem.Text = (i + 1).ToString();
                lvItem.SubItems.Add(mPayments[i].dt.ToString("hh:mm:dd"));

                String tran_type_name = "";
                if (mPayments[i].tran_type == "A") tran_type_name = "승인";
                else if (mPayments[i].tran_type == "C") tran_type_name = "취소";
                lvItem.SubItems.Add(tran_type_name);

                lvItem.SubItems.Add(mPayments[i].pos_no);
                lvItem.SubItems.Add(mPayments[i].serial_no);

                lvItem.SubItems.Add(mPayments[i].amount_cash.ToString("N0"));
                lvItem.SubItems.Add(mPayments[i].amount_card.ToString("N0"));
                lvItem.SubItems.Add(mPayments[i].amount_point.ToString("N0"));

                lvItem.SubItems.Add(mPayments[i].is_dc);
                lvItem.SubItems.Add(mPayments[i].is_cancel);

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

            String tOrderDt = "";


            int tax_amount = 0;
            int tfree_amount = 0;
            int dc_amount = 0;




            for (int i = 0; i < listOrder.Count; i++)
            {
                if (listOrderItem[i].the_no == tTheNo)
                {
                    tOrderDt = listOrder[i].dt.ToString("yyyy/MM/dd HH:mm:ss");
                }
            }

            String tStr = mTheNo.Substring(4, 8) + "-" + mTheNo.Substring(12, 2) + "-" + mTheNo.Substring(14, 4);
            int space_cnt = 44 - (encodelen(tOrderDt) + encodelen(tStr));
            String strPrintOrder = tOrderDt + Space(space_cnt) + tStr;
            strPrintOrder += "--------------------------------------------\r\n";  // 44
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

            strPrintOrder += "--------------------------------------------\r\n";  // 44


            if (tfree_amount > 0)
            {
                tStr = "*면세품목가액";
                strPrintOrder += tStr + Space(22 - encodelen(tStr));

                tStr = (tfree_amount).ToString("N0");
                strPrintOrder += Space(22 - encodelen(tStr)) + tStr;

                strPrintOrder += "\r\n";
            }

            if (tax_amount > 0)
            {
                int t_tax = tax_amount / 11;   // 부가세액
                int t_amt = tax_amount - t_tax; // 공급가액

                tStr = " 과세품목가액";
                strPrintOrder += tStr + Space(22 - encodelen(tStr));
                tStr = (t_amt).ToString("N0");
                strPrintOrder += Space(22 - encodelen(tStr)) + tStr;
                strPrintOrder += "\r\n";

                tStr = " 부 가 세 액";
                strPrintOrder += tStr + Space(22 - encodelen(tStr));
                tStr = (t_tax).ToString("N0");
                strPrintOrder += Space(22 - encodelen(tStr)) + tStr;
                strPrintOrder += "\r\n";
            }

            strPrintOrder += "--------------------------------------------\r\n";  // 44

            int tsum = tfree_amount + tax_amount;
            int tnet = tsum - dc_amount;


            tStr = "총합계";
            strPrintOrder += tStr + Space(22 - encodelen(tStr));
            tStr = (tsum).ToString("N0");
            strPrintOrder += Space(22 - encodelen(tStr)) + tStr;
            strPrintOrder += "\r\n";

            tStr = "할인계";
            strPrintOrder += tStr + Space(22 - encodelen(tStr));
            tStr = (-dc_amount).ToString("N0");
            strPrintOrder += Space(22 - encodelen(tStr)) + tStr;
            strPrintOrder += "\r\n";

            tStr = "결제대상금액";
            strPrintOrder += tStr + Space(22 - encodelen(tStr));
            tStr = (tnet).ToString("N0");
            strPrintOrder += Space(22 - encodelen(tStr)) + tStr;
            strPrintOrder += "\r\n";

            strPrintOrder += "--------------------------------------------\r\n";  // 44



            // 현금결제
            for (int i = 0; i < mPaymentCashs.Count; i++)
            {
                if (mPaymentCashs[i].the_no == tTheNo)
                {
                    if (mPaymentCashs[i].pay_type == "R0") tStr = "현금";           // 단순현금
                    else if (mPaymentCashs[i].pay_type == "R1") tStr = "현금영수증"; // 
                    else if (mPaymentCashs[i].pay_type == "R9") tStr = "현금";      //? 임의등록

                    strPrintOrder += tStr + Space(22 - encodelen(tStr));
                    tStr = mPaymentCashs[i].amount.ToString("N0");
                    strPrintOrder += Space(22 - encodelen(tStr)) + tStr;
                    
                    //? 현금 영수증 추가필요
                    //

                    strPrintOrder += "\r\n";
                    strPrintOrder += "\r\n";
                }
            }


            // 카드결제
            for (int i = 0; i < mPaymentCards.Count; i++)
            {
                if (mPaymentCards[i].the_no == tTheNo)
                {
                    if (mPaymentCards[i].pay_type == "C0") tStr = "카드결제";
                    else if (mPaymentCards[i].pay_type == "C9") tStr = "카드결제";  //? 임의등록
                    strPrintOrder += tStr + Space(22 - encodelen(tStr));
                    tStr = mPaymentCards[i].amount.ToString("N0");
                    strPrintOrder += Space(22 - encodelen(tStr)) + tStr;
                    strPrintOrder += "\r\n";

                    tStr = mPaymentCards[i].card_name;
                    strPrintOrder += tStr + Space(22 - encodelen(tStr));
                    tStr = mPaymentCards[i].card_no;
                    strPrintOrder += Space(22 - encodelen(tStr)) + tStr;
                    strPrintOrder += "\r\n";

                    tStr = "할부개월:" + mPaymentCards[i].install;
                    strPrintOrder += tStr + Space(22 - encodelen(tStr));
                    tStr = "승인번호:" + mPaymentCards[i].auth_no;
                    strPrintOrder += Space(22 - encodelen(tStr)) + tStr;
                    strPrintOrder += "\r\n";
                    strPrintOrder += "\r\n";
                }
            }


            strPrintOrder += "--------------------------------------------\r\n";  // 44



            lblLayoutBill.Text = strPrintOrder;

        }

        public string Space(int count)
        {
            return new String(' ', count);
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

            if (lvwPayManager.SelectedItems.Count < 1) { return; }


            frmPayCancel fPayCancel = new frmPayCancel("fjdsofidsf");

            fPayCancel.Left += this.Location.X;
            fPayCancel.Top += this.Location.Y;


            fPayCancel.ShowDialog();


        }






    }
}
