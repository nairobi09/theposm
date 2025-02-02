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

namespace thepos._1Sales
{
    public partial class frmYesNo : Form
    {
        public frmYesNo(String[] order_no_arr)
        {
            InitializeComponent();

            initialize_font();

            lblOrderNo.Text = order_no_arr[0];


            if (order_no_arr[0] == order_no_arr[1])
            {

            }
            else if (order_no_arr[1] == "")
            {

            }
            else
            {
                lblOrderNo2.Visible = true;
                lblFromToChar.Visible = true;
                lblOrderNo2.Text = order_no_arr[1];
            }

        }

        private void initialize_font()
        {
            //lblTitle.Font = font16;
            btnYes.Font = font12;
            btnNo.Font = font12;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

    }
}
