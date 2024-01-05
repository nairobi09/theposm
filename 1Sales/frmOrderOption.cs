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

namespace thepos
{
    public partial class frmOrderOption : Form
    {
        Panel[] mPanelOption = new Panel[4];

        Label[] mLblOptionName = new Label[4];

        RadioButton[ , ] mRbOptionItemName = new RadioButton[4, 3];
        Label[ , ] mLblOrderItemAmt = new Label[4, 3];


        GoodsItem goodsItem = new GoodsItem();

        int goods_cnt = 0;
        int goods_amount = 0;


        public frmOrderOption(GoodsItem goods_item)
        {
            InitializeComponent();

            initialize_font();
            initialize_the();

            goodsItem = goods_item;


            lblGoodsInfo.Text = goodsItem.goods_name;


            load_option_item(goodsItem.goods_code);

            //
            goods_cnt = 1;

            calculate_amount();


        }


        private void initialize_font()
        {
            lblTitle.Font = font10;

            lblGoodsInfo.Font = font10;

            lblCnt.Font = font10;
            lblCntDn.Font = font12;
            lblCntUp.Font = font12;

            lblAmount.Font = font10;

            lblOption0Name.Font = font10;
            lblOption1Name.Font = font10;
            lblOption2Name.Font = font10;
            lblOption3Name.Font = font10;

            rbOption0Item0Name.Font = font10;
            rbOption0Item1Name.Font = font10;
            rbOption0Item2Name.Font = font10;

            rbOption1Item0Name.Font = font10;
            rbOption1Item1Name.Font = font10;
            rbOption1Item2Name.Font = font10;

            rbOption2Item0Name.Font = font10;
            rbOption2Item1Name.Font = font10;
            rbOption2Item2Name.Font = font10;

            rbOption3Item0Name.Font = font10;
            rbOption3Item1Name.Font = font10;
            rbOption3Item2Name.Font = font10;

            lblOrder0Item0Amt.Font = font10;
            lblOrder0Item1Amt.Font = font10;
            lblOrder0Item2Amt.Font = font10;

            lblOrder1Item0Amt.Font = font10;
            lblOrder1Item1Amt.Font = font10;
            lblOrder1Item2Amt.Font = font10;

            lblOrder2Item0Amt.Font = font10;
            lblOrder2Item1Amt.Font = font10;
            lblOrder2Item2Amt.Font = font10;

            lblOrder3Item0Amt.Font = font10;
            lblOrder3Item1Amt.Font = font10;
            lblOrder3Item2Amt.Font = font10;


            btnOK.Font = font10;
            btnCancel.Font = font10;

        }

        private void initialize_the()
        {
            mPanelOption[0] = panelOption0;
            mPanelOption[1] = panelOption1;
            mPanelOption[2] = panelOption2;
            mPanelOption[3] = panelOption3;

            mLblOptionName[0] = lblOption0Name;
            mLblOptionName[1] = lblOption1Name;
            mLblOptionName[2] = lblOption2Name;
            mLblOptionName[3] = lblOption3Name;


            mRbOptionItemName[0, 0] = rbOption0Item0Name;
            mRbOptionItemName[0, 1] = rbOption0Item1Name;
            mRbOptionItemName[0, 2] = rbOption0Item2Name;

            mRbOptionItemName[1, 0] = rbOption1Item0Name;
            mRbOptionItemName[1, 1] = rbOption1Item1Name;
            mRbOptionItemName[1, 2] = rbOption1Item2Name;

            mRbOptionItemName[2, 0] = rbOption2Item0Name;
            mRbOptionItemName[2, 1] = rbOption2Item1Name;
            mRbOptionItemName[2, 2] = rbOption2Item2Name;

            mRbOptionItemName[3, 0] = rbOption3Item0Name;
            mRbOptionItemName[3, 1] = rbOption3Item1Name;
            mRbOptionItemName[3, 2] = rbOption3Item2Name;


            mLblOrderItemAmt[0, 0] = lblOrder0Item0Amt;
            mLblOrderItemAmt[0, 1] = lblOrder0Item1Amt;
            mLblOrderItemAmt[0, 2] = lblOrder0Item2Amt;

            mLblOrderItemAmt[1, 0] = lblOrder1Item0Amt;
            mLblOrderItemAmt[1, 1] = lblOrder1Item1Amt;
            mLblOrderItemAmt[1, 2] = lblOrder1Item2Amt;

            mLblOrderItemAmt[2, 0] = lblOrder2Item0Amt;
            mLblOrderItemAmt[2, 1] = lblOrder2Item1Amt;
            mLblOrderItemAmt[2, 2] = lblOrder2Item2Amt;

            mLblOrderItemAmt[3, 0] = lblOrder3Item0Amt;
            mLblOrderItemAmt[3, 1] = lblOrder3Item1Amt;
            mLblOrderItemAmt[3, 2] = lblOrder3Item2Amt;


            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    mRbOptionItemName[i, k].Click += (sender, args) => calculate_amount();
                }
            }

        }

        private void load_option_item(String goods_code)
        {
            int option_idx = 0;

            for (int i = 0; i < mGoodsOption.Length; i++) 
            {
                if (mGoodsOption[i].goods_code == goods_code)
                {
                    mPanelOption[option_idx].Visible = true;
                    mLblOptionName[option_idx].Text = mGoodsOption[i].option_name; 
                    mLblOptionName[option_idx].Tag = mGoodsOption[i].option_code;

                    int item_idx = 0;

                    for (int k = 0; k < mGoodsOptionItem.Length; k++)
                    {
                        if (mGoodsOptionItem[k].goods_code == goods_code & mGoodsOptionItem[k].option_code == mGoodsOption[i].option_code)
                        {
                            mRbOptionItemName[option_idx, item_idx].Visible = true;
                            mRbOptionItemName[option_idx, item_idx].Text = mGoodsOptionItem[k].option_item_name;
                            mRbOptionItemName[option_idx, item_idx].Tag = mGoodsOptionItem[k].option_item_no;


                            if (mGoodsOptionItem[k].option_item_amt > 0)
                            {
                                mLblOrderItemAmt[option_idx, item_idx].Visible = true;
                                mLblOrderItemAmt[option_idx, item_idx].Text = "₩ " + mGoodsOptionItem[k].option_item_amt.ToString("N0");
                            }
                            mLblOrderItemAmt[option_idx, item_idx].Tag = mGoodsOptionItem[k].option_item_amt;

                            item_idx++;
                        }
                    }

                    option_idx++;
                }
            }
        }


        private void calculate_amount()
        {
            int option_item_amt = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (mRbOptionItemName[i, k].Visible)
                    {
                        if (mRbOptionItemName[i, k].Checked)
                        {
                            if (is_number(mLblOrderItemAmt[i, k].Tag.ToString()))
                            {
                                option_item_amt += (int)mLblOrderItemAmt[i, k].Tag;
                            }
                        }
                    }
                }            
            }

            goods_amount = (goodsItem.amt + option_item_amt ) * goods_cnt;

            lblAmount.Text = "₩ " + goods_amount.ToString("N0");
        }

        private void lblCntDn_Click(object sender, EventArgs e)
        {
            if (goods_cnt > 1)
            {
                goods_cnt--;
                lblCnt.Text = goods_cnt.ToString();

                calculate_amount();
            }
        }

        private void lblCntUp_Click(object sender, EventArgs e)
        {
            goods_cnt++;
            lblCnt.Text = goods_cnt.ToString();

            calculate_amount();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            mOrderOptionItemList.Clear();

            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (mRbOptionItemName[i, k].Visible)
                    {
                        if (mRbOptionItemName[i, k].Checked)
                        {
                            orderOptionItem orderOptionItem = new orderOptionItem();
                            orderOptionItem.option_item_no = (int)mRbOptionItemName[i, k].Tag;
                            orderOptionItem.option_item_name = mRbOptionItemName[i, k].Text;
                            orderOptionItem.option_code = mLblOptionName[i].Tag.ToString();
                            orderOptionItem.option_name = mLblOptionName[i].Text;
                            orderOptionItem.amt = (int)mLblOrderItemAmt[i, k].Tag;

                            mOrderOptionItemList.Add(orderOptionItem);
                        }
                    }
                }
            }

            // 수량을 전역변수로 전달 : fk30fgu9w04ufgw
            mOrderCntInOption = goods_cnt;


            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


    }
}
