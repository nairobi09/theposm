using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;



/* 과제

    + 마우스 포인터 표시 : pc pos 구분필요 
    1. 리스트뷰 아이템외 클릭시 selected item의 highlight(backcolor)가 사라지는 현상 수정필요
    2. 




*/

// ▲△◀◁▶▷▼▽  <＋－＜＞↵ ↵ ⏎
//   ＋
//  ＜＜＞
//  △	▲	▽	▼

namespace thepos
{
    public partial class frmSale : Form
    {
        global mGloval = new global();

        PrivateFontCollection fontCollectionThin = new PrivateFontCollection();
        PrivateFontCollection fontCollectionMedium = new PrivateFontCollection();
        PrivateFontCollection fontCollectionBold = new PrivateFontCollection();

        //Font fontThin;
        Font fontMedium;
        Font fontBold;


        System.Windows.Forms.Button[] btnGoodsGroup = new System.Windows.Forms.Button[10];
        System.Windows.Forms.Button[] btnGoodsItem = new System.Windows.Forms.Button[25];


        String last_groupcode = "";  // 상품그룹을 클릭했을 경우 눌려진버튼을 또 눌렀는지 비교하기 위함.


        struct OrderItemInfo
        {
            public String code;     // 상품code(6) or 전체할인코드고정("DC")
            public String name;     // 상품name or 전체할인명("할인")
            public int cnt;
            public int amt;
            public int amount;      // 실결제금액*
            public int dc_amount;   // 실할인금액
            public String dc_type;  // type - "A" : 정액, "B" : 정율 
            public String dc_rate;     // 정액: "" or 정율값("20") - 20%경우
        }





        public frmSale()
        {
            InitializeComponent();

            //? PC가 아니면 마우스 포인터 표시안함.
            //Cursor.Hide();

            initialize_the();

            mGloval.get_goodsgroup();
            mGloval.get_goodsitem();


            display_goodsgroup();
            ClickedGoodsGroup(mGloval.mGoodsGroup[0].code);   // 최초실행후 첮 구룹을 선택한 화면을 보여주자...

        }



        private void initialize_the()
        {
            //fontCollectionThin.AddFontFile("SpoqaHanSansNeo-Thin.ttf");
            //fontCollection.AddFontFile("SpoqaHanSansNeo-Light.ttf");
            //fontCollection.AddFontFile("SpoqaHanSansNeo-Regular.ttf");

            //fontCollectionMedium.AddFontFile("SpoqaHanSansNeo-Medium.ttf");
            //fontCollectionBold.AddFontFile("SpoqaHanSansNeo-Bold.ttf");


            fontCollectionMedium.AddFontFile("Pretendard-Medium.ttf");
            fontCollectionBold.AddFontFile("Pretendard-Bold.ttf");


            //fontThin = new Font(fontCollectionThin.Families[0], 14f);
            fontMedium = new Font(fontCollectionMedium.Families[0], 10f);
            fontBold = new Font(fontCollectionBold.Families[0], 14f);


            lvwOrderItem.Font = fontMedium;

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 32);
            lvwOrderItem.SmallImageList = imgList;


            lblDate.Font = fontMedium;
            lblTime.Font = fontBold;

            lblDisplayAlarm.Font = fontMedium;

            btnOrderCancelAll.Font = fontMedium;
            btnOrderCancelSelect.Font = fontMedium;
            btnOrderCntDn.Font = fontMedium;
            btnOrderCntUp.Font = fontMedium;
            btnOrderCntChange.Font = fontMedium;
            btnOrderAmountDC.Font = fontMedium;
            btnOrderWating.Font = fontMedium;
            btnOrderItemScrollUp.Font = fontMedium;
            btnOrderItemScrollDn.Font = fontMedium;

            lblKeyDisplay.Font = fontBold;
            btnKey1.Font = fontMedium; btnKey1.Click += (sender, args) => ClickedKey("1");
            btnKey2.Font = fontMedium; btnKey2.Click += (sender, args) => ClickedKey("2");
            btnKey3.Font = fontMedium; btnKey3.Click += (sender, args) => ClickedKey("3");
            btnKey4.Font = fontMedium; btnKey4.Click += (sender, args) => ClickedKey("4");
            btnKey5.Font = fontMedium; btnKey5.Click += (sender, args) => ClickedKey("5");
            btnKey6.Font = fontMedium; btnKey6.Click += (sender, args) => ClickedKey("6");
            btnKey7.Font = fontMedium; btnKey7.Click += (sender, args) => ClickedKey("7");
            btnKey8.Font = fontMedium; btnKey8.Click += (sender, args) => ClickedKey("8");
            btnKey9.Font = fontMedium; btnKey9.Click += (sender, args) => ClickedKey("9");
            btnKey0.Font = fontMedium; btnKey0.Click += (sender, args) => ClickedKey("0");
            btnKey00.Font = fontMedium; btnKey00.Click += (sender, args) => ClickedKey("00");
            btnKeyBS.Font = fontMedium; btnKeyBS.Click += (sender, args) => ClickedKey("BS");
            btnKeyClear.Font = fontMedium; btnKeyClear.Click += (sender, args) => ClickedKey("Clear");
            btnKeyEnter.Font = fontMedium;

            btnFunction2.Font = fontMedium;
            btnFunction3.Font = fontMedium;
            btnFunction4.Font = fontMedium;
            btnFunction5.Font = fontMedium;

            btnPayCashReceipt.Font = fontMedium;
            btnPayCash.Font = fontMedium;
            btnPayCredit.Font = fontMedium;
            btnPaySimple.Font = fontMedium;
            btnPayComplex.Font = fontMedium;
            btnOrderManager.Font = fontMedium;

            lblOrderAmountSumTitle.Font = fontMedium;
            lblOrderAmountDCTitle.Font = fontMedium;
            lblOrderAmountChargeTitle.Font = fontMedium;
            lblOrderAmountReceiveTitle.Font = fontMedium;
            lblOrderAmountRestTitle.Font = fontMedium;
            lblOrderGoodsAmount.Font = fontBold;
            lblOrderAmountDC.Font = fontBold;
            lblOrderAmountCharge.Font = fontBold;
            lblOrderAmountReceive.Font = fontBold;
            lblOrderAmountRest.Font = fontBold;

            // item 클릭시 선택바 (backcolor=blue) 표시를 위해서...
            lvwOrderItem.HideSelection = true;

        }



        private void display_goodsgroup()
        {
            flowLayoutPanelGoodsGroup.Controls.Clear();

            for (int i = 0; i < mGloval.mGoodsGroup.Length; i++)
            {
                String groupcode = mGloval.mGoodsGroup[i].code;
                btnGoodsGroup[i] = new System.Windows.Forms.Button();
                btnGoodsGroup[i].Text = mGloval.mGoodsGroup[i].name;
                btnGoodsGroup[i].Tag = mGloval.mGoodsGroup[i].code;
                btnGoodsGroup[i].Height = 60;
                btnGoodsGroup[i].Width = 90;
                btnGoodsGroup[i].Font = fontMedium;

                btnGoodsGroup[i].FlatStyle = FlatStyle.Flat;
                btnGoodsGroup[i].ForeColor = Color.Navy;
                btnGoodsGroup[i].BackColor = Color.Transparent;
                btnGoodsGroup[i].Margin = new Padding(2, 2, 2, 2);

                btnGoodsGroup[i].Click += (sender, args) => ClickedGoodsGroup(groupcode);
                flowLayoutPanelGoodsGroup.Controls.Add(btnGoodsGroup[i]);
            }
        }




        private void ClickedGoodsGroup(String groupcode)
        {
            if (last_groupcode == groupcode)
            {
                return;
            }

            flowLayoutPanelGoodsItem.Controls.Clear();
            setGroupButtonColor(last_groupcode, false);
            setGroupButtonColor(groupcode, true);

            int lv_item_idx = 0;

            for (int i = 0; i < mGloval.mGoodsItem.Length; i++)
            {
                if (groupcode == mGloval.mGoodsItem[i].code.Substring(0,3))
                {
                    int idx = i;
                    btnGoodsItem[lv_item_idx] = new System.Windows.Forms.Button();
                    btnGoodsItem[lv_item_idx].Text = mGloval.mGoodsItem[i].name + "\n" + mGloval.mGoodsItem[i].amt.ToString("N0");
                    btnGoodsItem[lv_item_idx].Tag = mGloval.mGoodsItem[i].code;
                    btnGoodsItem[lv_item_idx].Height = 70;
                    btnGoodsItem[lv_item_idx].Width = 90;
                    btnGoodsItem[lv_item_idx].Font = fontMedium;

                    btnGoodsItem[lv_item_idx].FlatStyle = FlatStyle.Flat;
                    btnGoodsItem[lv_item_idx].ForeColor = Color.Maroon;
                    btnGoodsItem[lv_item_idx].BackColor = Color.Transparent;

                    btnGoodsItem[lv_item_idx].TabStop = false;
                    btnGoodsItem[lv_item_idx].Margin = new Padding(2, 2, 2, 2);

                    btnGoodsItem[lv_item_idx].Click += (sender, args) => ClickedGoodsItem(idx);
                    flowLayoutPanelGoodsItem.Controls.Add(btnGoodsItem[lv_item_idx]);
                }
            }
 
            last_groupcode = groupcode;
        }

        private void ClickedGoodsItem(int i)
        {

            OrderItemInfo orderItemInfo = new OrderItemInfo();


            int lv_idx = (get_lvitem_idx(mGloval.mGoodsItem[i].code));  // 이미  동일 상품이 주문리스트뷰에 있는지

            if (lv_idx == -1)
            {
                ListViewItem item = new ListViewItem();

                orderItemInfo.code = mGloval.mGoodsItem[i].code.ToString();
                orderItemInfo.name = mGloval.mGoodsItem[i].name.ToString();
                orderItemInfo.amt = mGloval.mGoodsItem[i].amt;
                orderItemInfo.cnt = 1;
                orderItemInfo.dc_amount = 0;
                orderItemInfo.amount = mGloval.mGoodsItem[i].amt;
                orderItemInfo.dc_type = "";
                orderItemInfo.dc_rate = "";

                item.Tag = orderItemInfo;

                item.Text = (lvwOrderItem.Items.Count + 1).ToString();
                item.SubItems.Add(mGloval.mGoodsItem[i].name);                // 1: name 상품명
                item.SubItems.Add(mGloval.mGoodsItem[i].amt.ToString("N0"));  // 2: amt 단가
                item.SubItems.Add("1");                                       // 3: cnt 수량
                item.SubItems.Add("");                                        // 4: dc_amount 할인
                item.SubItems.Add(mGloval.mGoodsItem[i].amt.ToString("N0"));  // 5: amount 금액
                item.SubItems.Add("");          

                lvwOrderItem.Items.Add(item);
                lvwOrderItem.Items[lvwOrderItem.Items.Count - 1].EnsureVisible();
                lvwOrderItem.Items[lvwOrderItem.Items.Count - 1].Selected = true;
            }
            else
            {

                set_item_change_ordercnt(lv_idx, "add", 1);

                lvwOrderItem.Items[lv_idx].Selected = true;
            }

            ReCalculateAmount();
        }



        // OrderItem ListView 관련 버튼들

        private void btnOrderCancelAll_Click(object sender, EventArgs e)
        {
            lvwOrderItem.Items.Clear();

            ReCalculateAmount();
        }

        private void btnOrderCancelSelect_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.SelectedItems.Count > 0)
            {
                int idx = lvwOrderItem.SelectedItems[0].Index;

                lvwOrderItem.SelectedItems[0].Remove();

                if (idx == lvwOrderItem.Items.Count & idx == 0)
                {
                    // 
                }
                else if (idx == lvwOrderItem.Items.Count)
                {
                    lvwOrderItem.Items[idx - 1].Selected = true;
                }
                else
                {
                    lvwOrderItem.Items[idx].Selected = true;
                }


                // renumbering
                for (int i = idx; i < lvwOrderItem.Items.Count; i++)
                {
                    lvwOrderItem.Items[i].Text = (i+1).ToString();
                }



                ReCalculateAmount();
            }
        }

        private void btnOrderAmountDC_Click(object sender, EventArgs e)
        {

        }

        private void btnOrderWating_Click(object sender, EventArgs e)
        {

        }

        private void btnOrderCntDn_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.SelectedItems.Count > 0)
            {
                int lv_idx = lvwOrderItem.SelectedItems[0].Index;
                set_item_change_ordercnt(lv_idx, "add", -1);
                ReCalculateAmount();
            }
        }

        private void btnOrderCntUp_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.SelectedItems.Count > 0)
            {
                int lv_idx = lvwOrderItem.SelectedItems[0].Index;
                set_item_change_ordercnt(lv_idx, "add", 1);
                ReCalculateAmount();
            }
        }

        private void btnOrderCntChange_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.SelectedItems.Count > 0)
            {
                if (lblKeyDisplay.Text.Length > 3) return;

                int cnt = 0;
                bool result = int.TryParse(lblKeyDisplay.Text, out cnt);

                if (result)
                {
                    if (cnt > 0 & cnt < 1000)
                    {
                        set_item_change_ordercnt(lvwOrderItem.SelectedItems[0].Index, "set", cnt);
                        lblKeyDisplay.Text = "";
                        ReCalculateAmount();
                    }
                }
            }
        }



        private void set_item_change_ordercnt(int lv_idx, String jobtype, int cnt)
        {
            OrderItemInfo orderItemInfo = (OrderItemInfo)lvwOrderItem.Items[lv_idx].Tag;

            if (jobtype == "add")
            {
                orderItemInfo.cnt += cnt;
            }
            else if (jobtype == "set")
            {
                orderItemInfo.cnt = cnt;
            }
            else
            {
                return;
            }

            orderItemInfo.amount = (orderItemInfo.cnt * orderItemInfo.amt) - orderItemInfo.dc_amount;

            lvwOrderItem.Items[lv_idx].SubItems[3].Text = orderItemInfo.cnt.ToString("N0");           // cnt
            lvwOrderItem.Items[lv_idx].SubItems[5].Text = orderItemInfo.amount.ToString("N0");        // amount

            lvwOrderItem.Items[lv_idx].Tag = orderItemInfo;
        }

        private void ReCalculateAmount()
        {
            Int32 goodsAmount = 0;
            Int32 dcAmount = 0;
            Int32 Amount = 0;

            OrderItemInfo orderItemInfo;

            for (int i = 0; i < lvwOrderItem.Items.Count; i++)
            {
                orderItemInfo = (OrderItemInfo)lvwOrderItem.Items[i].Tag;
                goodsAmount += (orderItemInfo.cnt * orderItemInfo.amt);
                dcAmount += orderItemInfo.dc_amount;
                Amount += orderItemInfo.amount;
            }

            lblOrderGoodsAmount.Text = goodsAmount.ToString("N0");
            lblOrderAmountDC.Text = dcAmount.ToString("N0");
            lblOrderAmountCharge.Text = Amount.ToString("N0");

        }



        //  스크롤 selected up down
        private void btnOrderItemScrollUp_Click(object sender, EventArgs e)
        {
            if (lvwOrderItem.SelectedItems.Count > 0)
            {
                int sel_idx = lvwOrderItem.SelectedItems[0].Index;

                if (sel_idx > 0)
                {
                    lvwOrderItem.Items[sel_idx - 1].Selected = true;

                    if (lvwOrderItem.TopItem.Index > sel_idx - 1)
                    {
                        lvwOrderItem.TopItem = lvwOrderItem.Items[sel_idx - 1];
                    }
                }
            }
            else
            {
                int top_idx = this.lvwOrderItem.TopItem.Index;
                if (top_idx > 0 & top_idx < lvwOrderItem.Items.Count - 1)
                {
                    lvwOrderItem.TopItem = lvwOrderItem.Items[top_idx - 1];
                }
            }
        }

        private void btnOrderItemScrollDn_Click(object sender, EventArgs e)
        {

            if (lvwOrderItem.SelectedItems.Count > 0)
            {
                int sel_idx = lvwOrderItem.SelectedItems[0].Index;

                if (sel_idx < lvwOrderItem.Items.Count - 1)
                {
                    lvwOrderItem.Items[sel_idx + 1].Selected = true;

                    int top_idx = this.lvwOrderItem.TopItem.Index;
                    if (sel_idx - top_idx > 6 & sel_idx < lvwOrderItem.Items.Count - 1)
                    {
                        lvwOrderItem.TopItem = lvwOrderItem.Items[top_idx + 1];
                    }
                }
            }
            else
            {
                int curItem = this.lvwOrderItem.TopItem.Index;
                if (curItem < this.lvwOrderItem.Items.Count - 1)
                {
                    this.lvwOrderItem.TopItem = this.lvwOrderItem.Items[curItem + 1];
                }
            }
        }




        //  지원서브루트

        private void ClickedKey(string sKey)
        {
            if (sKey == "BS")
            {
                if (lblKeyDisplay.Text.Length > 0 )
                {
                    lblKeyDisplay.Text = lblKeyDisplay.Text.Substring(0, lblKeyDisplay.Text.Length - 1);
                }
            }
            else if (sKey == "Clear")
            {
                lblKeyDisplay.Text = "";
            }
            else if (sKey == "0" | sKey == "00")
            {
                if (lblKeyDisplay.Text.Length > 0)
                {
                    lblKeyDisplay.Text += sKey;
                }
            }
            else
            {
                lblKeyDisplay.Text += sKey;
            }
        }

        private void setGroupButtonColor(String groupcode, bool isPressed)
        {
            int button_idx = -1;

            for (int i = 0; i < mGloval.mGoodsGroup.Length; i++)
            {
                if (mGloval.mGoodsGroup[i].code == groupcode)
                {
                    button_idx = i;
                }
            }

            if (button_idx == -1)
                return;

            if (!isPressed)
            {
                btnGoodsGroup[button_idx].ForeColor = Color.Navy;
                btnGoodsGroup[button_idx].BackColor = Color.Transparent;
                btnGoodsGroup[button_idx].FlatAppearance.BorderSize = 1;
            }
            else
            {
                btnGoodsGroup[button_idx].ForeColor = Color.Transparent;
                btnGoodsGroup[button_idx].BackColor = Color.Navy;
                btnGoodsGroup[button_idx].FlatAppearance.BorderSize = 0;
            }
        }

        private int get_lvitem_idx(string code)
        {
            for (int i = 0; i < lvwOrderItem.Items.Count; i++)
            {
                if (code == ((OrderItemInfo)(lvwOrderItem.Items[i].Tag)).code)
                { return i; }
            }
            return -1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Tag.ToString() == "0")
            {
                lblTime.Text = DateTime.Now.ToString("HH:mm");
                timer1.Tag = "1";
            }
            else
            {
                lblTime.Text = DateTime.Now.ToString("HH mm");
                timer1.Tag = "0";
            }


            String strWeek = "";
            DateTime nowDt = DateTime.Now;

            if (nowDt.DayOfWeek == DayOfWeek.Monday) strWeek = "월";
            else if (nowDt.DayOfWeek == DayOfWeek.Tuesday) strWeek ="화";
            else if (nowDt.DayOfWeek == DayOfWeek.Wednesday) strWeek ="수";
            else if (nowDt.DayOfWeek == DayOfWeek.Thursday) strWeek ="목";
            else if (nowDt.DayOfWeek == DayOfWeek.Friday) strWeek ="금";
            else if (nowDt.DayOfWeek == DayOfWeek.Saturday) strWeek ="토";
            else if (nowDt.DayOfWeek == DayOfWeek.Sunday) strWeek ="일";

            lblDate.Text = DateTime.Now.ToString("yyyy.MM.dd") + " [" + strWeek + "]";

        }

        private void lvwOrderItem_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvwOrderItem.Columns[e.ColumnIndex].Width;
        }

        private void lvwOrderItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lvwOrderItem.Items.Cast<ListViewItem>()
                .ToList().ForEach(item =>
                {
                    item.BackColor = SystemColors.Window;
                    item.ForeColor = SystemColors.WindowText;
                });
            this.lvwOrderItem.SelectedItems.Cast<ListViewItem>()
                .ToList().ForEach(item =>
                {
                    item.BackColor = SystemColors.Highlight;
                    item.ForeColor = SystemColors.HighlightText;
                });
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
