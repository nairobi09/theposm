using Newtonsoft.Json.Linq;
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
using static thepos.frmSales;
using static thepos.thePos;



// %₩




namespace thepos
{
    public partial class frmOrderDCR : Form
    {

        System.Windows.Forms.Button[] btnDCR;

        public frmOrderDCR()
        {
            InitializeComponent();

            initialize_font();
            initialize_the();

            displayDCR();

        }


        void initialize_font()
        {
            lblTitle.Font = font10bold;
            lblTitle1.Font = font10;
            lblTitle2.Font = font10;

            btnSelAmount.Font = font10;
            btnSelRate.Font = font10;
            btnAllAmount.Font = font10;
            btnAllRate.Font = font10;

            btnDCCancel.Font = font10;
            btnClose.Font = font10;

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

                String btn_title = mDCR[i].dcr_name + "\n" + des + mDCR[i].dcr_value.ToString("N0") + type + " 할인";

                btnDCR[i].Text = btn_title;
                btnDCR[i].Height = 50;
                btnDCR[i].Width = 230;
                btnDCR[i].Font = font10;

                btnDCR[i].FlatStyle = FlatStyle.Flat;
                btnDCR[i].ForeColor = Color.White;
                btnDCR[i].BackColor = Color.SteelBlue;
                btnDCR[i].FlatAppearance.BorderSize = 2;

                btnDCR[i].Margin = new Padding(5, 5, 5, 5);

                btnDCR[i].Click += (sender, args) => ClickedDCR(dcr_idx);
                flowLayoutPanelDCR.Controls.Add(btnDCR[i]);
            }
        }





        private void initialize_the()
        {


        }



        private void ClickedDCR(int dcr_idx)
        {
            String code = mDCR[dcr_idx].dcr_code;
            String name = mDCR[dcr_idx].dcr_name;
            String des = mDCR[dcr_idx].dcr_des;
            String type = mDCR[dcr_idx].dcr_type;
            int value = mDCR[dcr_idx].dcr_value;

            applyDCR(des, type, value, code, name);
        }


        private void btnSelAmount_Click(object sender, EventArgs e) { applyDCR("S", "A", -1, "", ""); }
        private void btnSelRate_Click(object sender, EventArgs e) { applyDCR("S", "R", -1, "", ""); }
        private void btnAllAmount_Click(object sender, EventArgs e) { applyDCR("E", "A", -1, "DCRE", "[전체할인]"); }
        private void btnAllRate_Click(object sender, EventArgs e) { applyDCR("E", "R", -1, "DCRE", "[전체할인]"); }

        void applyDCR(String des, String type, int value, String e_dcr_code, String e_dcr_name)
        {
            if (value == -1 )  // Keypad의 입력값을 Value로..
            {
                if (int.TryParse(mTbKeyDisplaySales.Text, out int n))
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

                if (isExist_DCR("E"))
                {
                    SetDisplayAlarm("W", "[전체할인]이 적용된경우 선택할인 불가.");
                    return;
                }

                if (mLvwOrderItem.SelectedItems.Count > 0)
                {
                    MemOrderItem orderItem = (MemOrderItem)mLvwOrderItem.SelectedItems[0].Tag;

                    orderItem.dcr_des = des;
                    orderItem.dcr_type = type;
                    orderItem.dcr_value = value;


                    orderItem.dc_amount = frmSales.get_dc_amount(orderItem);


                    int net_amount = (orderItem.cnt * orderItem.amt) - orderItem.dc_amount;

                    mLvwOrderItem.SelectedItems[0].SubItems[4].Text = orderItem.dc_amount.ToString("N0");  // dc_amount
                    mLvwOrderItem.SelectedItems[0].SubItems[5].Text = net_amount.ToString("N0");  // net_amount
                    mLvwOrderItem.SelectedItems[0].SubItems[6].Text = getDCRmemo(orderItem);
                    mLvwOrderItem.SelectedItems[0].Tag = orderItem;

                    ReCalculateAmount();
                }

            }
            else if (des == "E")  // 전체할인
            {
                int t_count = 0;
                int t_dc_amount = 0;
                bool isExist_E = false;


                if (isExist_DCR("S"))
                {
                    SetDisplayAlarm("W", "[선택할인]이 적용된경우 전체할인 불가.");
                    return;
                }


                
                if (isExist_DCR("E"))
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
                        t_amount += (((MemOrderItem)mLvwOrderItem.Items[i].Tag).cnt * ((MemOrderItem)mLvwOrderItem.Items[i].Tag).amt);
                    }
                    t_dc_amount = (t_amount * value) / 100;
                }
                else return;


                MemOrderItem orderItem = new MemOrderItem();
                orderItem.dcr_des = des;
                orderItem.dcr_type = type;
                orderItem.dcr_value = value;
                orderItem.cnt = 0;
                orderItem.amt = 0;
                orderItem.dc_amount = t_dc_amount;
                orderItem.code = e_dcr_code;  // 전체 할인코드
                orderItem.name = e_dcr_name;

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
                    mLvwOrderItem.Items[t_count].Selected = true;
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
                    mLvwOrderItem.Items[mLvwOrderItem.Items.Count - 1].Selected = true;

                    //? 전체할인항목을 맨아래 추가후 -> 이후에도 맨아래줄을 유지할 수 있는 방안 필요.
                }

                ReCalculateAmount();
            }

            mTbKeyDisplaySales.Text = "";
        }

        private void btnDCCancel_Click(object sender, EventArgs e)
        {

            if (mLvwOrderItem.SelectedItems.Count > 0)
            {
                MemOrderItem orderItem = (MemOrderItem)mLvwOrderItem.SelectedItems[0].Tag;

                if (orderItem.dcr_des == "S")
                {
                    orderItem.dcr_des = "";
                    orderItem.dcr_type = "";
                    orderItem.dcr_value = 0;
                    orderItem.dc_amount = 0;

                    mLvwOrderItem.SelectedItems[0].SubItems[4].Text = "";       // dc_amount
                    mLvwOrderItem.SelectedItems[0].SubItems[5].Text = (orderItem.cnt * orderItem.amt).ToString("N0");  // net_amount
                    mLvwOrderItem.SelectedItems[0].SubItems[6].Text = "";
                    mLvwOrderItem.SelectedItems[0].Tag = orderItem;

                    SetDisplayAlarm("I", "선택할인 취소");
                    ReCalculateAmount();
                }
                else if (orderItem.dcr_des == "E")
                {
                    mLvwOrderItem.SelectedItems[0].Remove();

                    SetDisplayAlarm("I", "전체할인 취소");
                    ReCalculateAmount();

                }
                else
                {
                    SetDisplayAlarm("W", "할인취소 대상이 아닙니다.");
                }
            }
            
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void frmAmountDC_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSales.ConsoleEnable();

            mPanelMiddle.Visible = false;
            mPanelMiddle.Controls.Clear();
        }


    }
}
