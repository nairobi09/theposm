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

            applyDCR(des, type, value, code, "[전체할인]", name);
        }


        private void btnSelAmount_Click(object sender, EventArgs e) { applyDCR("S", "A", -1, "", "", ""); }
        private void btnSelRate_Click(object sender, EventArgs e) { applyDCR("S", "R", -1, "", "", ""); }
        private void btnAllAmount_Click(object sender, EventArgs e) { applyDCR("E", "A", -1, "DCRE", "[전체할인]", ""); }
        private void btnAllRate_Click(object sender, EventArgs e) { applyDCR("E", "R", -1, "DCRE", "[전체할인]", ""); }

        void applyDCR(String des, String type, int value, String e_dcr_code, String e_dcr_name, String description_name)
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
                    int sel_idx = mLvwOrderItem.SelectedItems[0].Index;

                    MemOrderItem orderItem = mOrderItemList[sel_idx];

                    orderItem.dcr_des = des;
                    orderItem.dcr_type = type;
                    orderItem.dcr_value = value;


                    // 
                    replace_mem_order_item(ref orderItem, "update");

                    mOrderItemList[sel_idx] = orderItem;
                    mLvwOrderItem.SetObjects(mOrderItemList);
                    mLvwOrderItem.Items[sel_idx].Selected = true;

                    ReCalculateAmount();
                }

            }
            else if (des == "E")  // 전체할인
            {
                int t_dc_amount = 0;
                bool isExist_E = false;


                if (isExist_DCR("S"))
                {
                    SetDisplayAlarm("W", "[선택할인]이 적용된경우 전체할인 불가.");
                    return;
                }


                int dcr_e_idx = get_lv_DCR("E");

                if (dcr_e_idx >= 0)  // 
                {
                    isExist_E = true;
                }


                if (type == "A")
                {
                    t_dc_amount = value;
                }
                else 
                if (type == "R")
                {
                    int t_amount = 0;
                    for (int i = 0; i < mOrderItemList.Count; i++)
                    {
                        if (dcr_e_idx != i)  // 전체할인항목 레코드는 합계에서 제외
                        {
                            t_amount += ((mOrderItemList[i].amt + mOrderItemList[i].option_amt) + mOrderItemList[i].cnt);
                        }
                    }
                    t_dc_amount = (t_amount * value) / 100;
                }
                else return;



                MemOrderItem orderItem = new MemOrderItem();

                if (isExist_E == true)
                {
                    orderItem = mOrderItemList[dcr_e_idx];
                }


                mOrderOptionItemList.Clear();

                orderItem.option_item_cnt = mOrderOptionItemList.Count;
                orderItem.orderOptionItemList = mOrderOptionItemList.ToList();  // ToList() : 리스트 복사, 참조가 아니고..


                orderItem.dcr_des = des;
                orderItem.dcr_type = type;
                orderItem.dcr_value = value;
                orderItem.cnt = 0;
                orderItem.amt = 0;
                orderItem.option_amt = 0;
                orderItem.dc_amount = t_dc_amount;
                orderItem.net_amount = -t_dc_amount;
                orderItem.goods_code = e_dcr_code;  // 전체 할인코드
                orderItem.goods_name = e_dcr_name;
                orderItem.option_name_description = description_name;



                if (isExist_E == true)
                {
                    //
                    replace_mem_order_item(ref orderItem, "update");

                    mOrderItemList[dcr_e_idx] = orderItem;
                    mLvwOrderItem.SetObjects(mOrderItemList);

                    mLvwOrderItem.Items[dcr_e_idx].Selected = true;
                }
                else
                {
                    //
                    replace_mem_order_item(ref orderItem, "add");

                    mOrderItemList.Add(orderItem);
                    mLvwOrderItem.SetObjects(mOrderItemList);

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
                int sel_idx = mLvwOrderItem.SelectedItems[0].Index;


                MemOrderItem orderItem = mOrderItemList[sel_idx];

                if (orderItem.dcr_des == "S")
                {
                    orderItem.dcr_des = "";
                    orderItem.dcr_type = "";
                    orderItem.dcr_value = 0;
                    orderItem.dc_amount = 0;


                    replace_mem_order_item(ref orderItem, "update");

                    
                    mOrderItemList[sel_idx] = orderItem;

                    mLvwOrderItem.SetObjects(mOrderItemList);


                    SetDisplayAlarm("I", "선택할인 취소");
                    ReCalculateAmount();
                }
                else if (orderItem.dcr_des == "E")
                {
                    mOrderItemList.RemoveAt(sel_idx);
                    mLvwOrderItem.SetObjects(mOrderItemList);


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
