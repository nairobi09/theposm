using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static thepos.frmSale;
using static thepos.thepos;



// %₩




namespace thepos
{
    public partial class frmAmountDC : Form
    {

        Font fontMedium_10;
        Font fontBold_12;


        struct DCR
        {
            public string dcr_code;
            public string dcr_des;
            public string dcr_type;
            public int dcr_value;
        }

        DCR[] mDCR;

        System.Windows.Forms.Button[] btnDCR;

        public frmAmountDC()
        {
            InitializeComponent();

            //initialize_font();
            initialize_the();

            getDCRule();

            displayDCR();

        }


        // 할인 즐겨찾기 - 서버에서 가져오기
        private void getDCRule()
        {
            // 할인울

            // 할인룰코드 : 
            // 할인대상 : 선택(S), 전체(E)
            // 할인형식 : 정액형(A:Amount), 정율형(R:Rate)
            // 할인값   : 정액 - 금액, 정율 - 할인율(%)

            String[,] dcr = new String[,]
            {
                {"001","S","A", "500"},
                {"002","S","R", "20"},
                {"003","E","A", "1000"},
                {"004","E","R", "10"}
            };


            int len = dcr.Length / 4;


            mDCR = new DCR[len];

            for (int i = 0; i < len; i++)
            {
                mDCR[i].dcr_code = dcr[i, 0];
                mDCR[i].dcr_des = dcr[i, 1];
                mDCR[i].dcr_type = dcr[i, 2];
                mDCR[i].dcr_value = Int32.Parse(dcr[i, 3]);
            }

        }


        void initialize_font()
        {
            PrivateFontCollection fontCollectionMedium = new PrivateFontCollection();
            PrivateFontCollection fontCollectionBold = new PrivateFontCollection();

            fontCollectionMedium.AddFontFile("Font\\Pretendard-Medium.ttf");
            fontCollectionBold.AddFontFile("Font\\Pretendard-Bold.ttf");

            fontMedium_10 = new Font(fontCollectionMedium.Families[0], 10f);
            fontBold_12 = new Font(fontCollectionBold.Families[0], 12f);


            lblTitle.Font = fontBold_12;
            lblTitle1.Font = fontBold_12;
            lblTitle2.Font = fontBold_12;

            btnSelAmount.Font = fontMedium_10;
            btnSelRate.Font = fontMedium_10;
            btnAllAmount.Font = fontMedium_10;
            btnAllRate.Font = fontMedium_10;

            btnDCCancel.Font = fontMedium_10;
            btnClose.Font = fontMedium_10;

        }

        void displayDCR()
        {
            btnDCR = new System.Windows.Forms.Button[mDCR.Length];

            flowLayoutPanelDCR.Controls.Clear();

            String des = "";
            String type = "";

            for (int i = 0; i < mDCR.Length; i++)
            {
                int dcr_idx = i;
                btnDCR[i] = new System.Windows.Forms.Button();

                if (mDCR[i].dcr_type == "R") type = "%";
                else type = "원";

                if (mDCR[i].dcr_des == "E") des = "전체 ";
                else des = "선택 ";

                String btn_title = des + mDCR[i].dcr_value.ToString("N0") + type + " 할인";

                btnDCR[i].Text = btn_title;
                btnDCR[i].Height = 50;
                btnDCR[i].Width = 180;
                //btnDCR[i].Font = fontBold_12;

                btnDCR[i].FlatStyle = FlatStyle.Flat;
                btnDCR[i].ForeColor = Color.White;
                btnDCR[i].BackColor = Color.SteelBlue;
                btnDCR[i].FlatAppearance.BorderSize = 2;

                btnDCR[i].Margin = new Padding(3, 3, 3, 3);

                btnDCR[i].Click += (sender, args) => ClickedDCR(dcr_idx);
                flowLayoutPanelDCR.Controls.Add(btnDCR[i]);
            }
        }





        private void initialize_the()
        {


        }



        private void ClickedDCR(int dcr_idx)
        {
            String des = mDCR[dcr_idx].dcr_des;
            String type = mDCR[dcr_idx].dcr_type;
            int value = mDCR[dcr_idx].dcr_value;

            applyDCR(des, type, value);

        }


        private void btnSelAmount_Click(object sender, EventArgs e) { applyDCR("S", "A", -1); }
        private void btnSelRate_Click(object sender, EventArgs e) { applyDCR("S", "R", -1); }
        private void btnAllAmount_Click(object sender, EventArgs e) { applyDCR("E", "A", -1); }
        private void btnAllRate_Click(object sender, EventArgs e) { applyDCR("E", "R", -1); }

        void applyDCR(String des, String type, int value)
        {
            if (value == -1 )  // Keypad의 입력값을 Value로..
            {
                if (int.TryParse(mLblKeyDisplay.Text, out int n))
                {
                    value = n;
                }
                else
                {
                    return;
                }
            }


            if (des == "S")   // 선택항목 할인
            {
                if (mLvwOrderItem.SelectedItems.Count > 0)
                {
                    OrderItem orderItem = (OrderItem)mLvwOrderItem.SelectedItems[0].Tag;

                    orderItem.dcr_des = des;
                    orderItem.dcr_type = type;
                    orderItem.dcr_value = value;

                    int amount = orderItem.amt * orderItem.cnt;
                    
                    if (type == "A") orderItem.dc_amount = value;
                    else　if(type == "R") orderItem.dc_amount = (amount * value) / 100;
                    else return;

                    int net_amount = amount - orderItem.dc_amount;

                    mLvwOrderItem.SelectedItems[0].SubItems[4].Text = orderItem.dc_amount.ToString("N0");  // dc_amount
                    mLvwOrderItem.SelectedItems[0].SubItems[5].Text = net_amount.ToString("N0");  // net_amount
                    mLvwOrderItem.SelectedItems[0].SubItems[6].Text = getDCRmemo(orderItem);
                    mLvwOrderItem.SelectedItems[0].Tag = orderItem;

                    frmSale.ReCalculateAmount();
                }

            }
            else if (des == "E")  // 전체할인
            {
                int t_count = 0;
                int t_dc_amount = 0;
                bool isExist_E = false;

                if (((OrderItem)mLvwOrderItem.Items[mLvwOrderItem.Items.Count - 1].Tag).dcr_des == "E")
                {
                    isExist_E = true;
                    t_count = mLvwOrderItem.Items.Count - 1;
                }
                else
                {
                    t_count = mLvwOrderItem.Items.Count;
                }


                if (type == "A")
                {
                    t_dc_amount = value;
                }
                else 
                if (type == "R")
                {
                    int t_amount = 0;
                    for (int i = 0; i < t_count; i++)
                    {
                        t_amount += (((OrderItem)mLvwOrderItem.Items[i].Tag).cnt * ((OrderItem)mLvwOrderItem.Items[i].Tag).amt);
                    }
                    t_dc_amount = (t_amount * value) / 100;
                }
                else return;


                OrderItem orderItem = new OrderItem();
                orderItem.dcr_des = des;
                orderItem.dcr_type = type;
                orderItem.dcr_value = value;
                orderItem.cnt = 0;
                orderItem.amt = 0;
                orderItem.dc_amount = t_dc_amount;
                orderItem.code = "DCRE";  // 전체할인을 나타내는 코드값!
                orderItem.name = "[할인]";

                if (isExist_E == true)
                {
                    mLvwOrderItem.Items[t_count].Text = (t_count + 1).ToString();
                    mLvwOrderItem.Items[t_count].SubItems[1].Text = orderItem.name;
                    mLvwOrderItem.Items[t_count].SubItems[2].Text = "";
                    mLvwOrderItem.Items[t_count].SubItems[3].Text = "";
                    mLvwOrderItem.Items[t_count].SubItems[4].Text = orderItem.dc_amount.ToString("N0");   // dc_amount
                    mLvwOrderItem.Items[t_count].SubItems[5].Text = "";                                   // net_amount
                    mLvwOrderItem.Items[t_count].SubItems[6].Text = getDCRmemo(orderItem);
                    mLvwOrderItem.Items[t_count].Tag = orderItem;
                }
                else
                {
                    ListViewItem lvItem = new ListViewItem();

                    lvItem.Text = (t_count + 1).ToString();
                    lvItem.SubItems.Add(orderItem.name);                            // 1: name 상품명
                    lvItem.SubItems.Add("");                                        // 2: amt 단가
                    lvItem.SubItems.Add("");                                        // 3: cnt 수량
                    lvItem.SubItems.Add(orderItem.dc_amount.ToString("#,###"));     // 4: dc_amount 할인
                    lvItem.SubItems.Add("");                                        // 5: net_amount 금액
                    lvItem.SubItems.Add(getDCRmemo(orderItem));                     // 6: 메모
                    lvItem.Tag = orderItem;

                    mLvwOrderItem.Items.Add(lvItem);
                    mLvwOrderItem.Items[mLvwOrderItem.Items.Count - 1].EnsureVisible();
                }

                frmSale.ReCalculateAmount();
            }
        }

        private void btnDCCancel_Click(object sender, EventArgs e)
        {
            if (mLvwOrderItem.SelectedItems.Count > 0)
            {
                OrderItem orderItem = (OrderItem)mLvwOrderItem.SelectedItems[0].Tag;

                orderItem.dcr_des = "";
                orderItem.dcr_type = "";
                orderItem.dcr_value = 0;
                orderItem.dc_amount = 0;

                mLvwOrderItem.SelectedItems[0].SubItems[4].Text = "";       // dc_amount
                mLvwOrderItem.SelectedItems[0].SubItems[5].Text = (orderItem.cnt * orderItem.amt).ToString("N0");  // net_amount
                mLvwOrderItem.SelectedItems[0].SubItems[6].Text = "";
                mLvwOrderItem.SelectedItems[0].Tag = orderItem;

                frmSale.ReCalculateAmount();
            }
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            frmSale.ConsoleEnable();
        }

        private void frmAmountDC_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            frmSale.ConsoleEnable();
        }




    }
}
