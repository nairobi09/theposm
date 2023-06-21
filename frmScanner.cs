using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static thepos.theSale;


namespace thepos
{
    public partial class frmScanner : Form
    {
        String ScanString = "";
        int scanLength;

        public frmScanner(int scan_length)
        {
            InitializeComponent();

            mIsScanOK = false;
            mScanString = "";
            
            scanLength = scan_length;

            tbScanning.MaxLength = scan_length;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            mScanString = tbScanning.Text;
            mIsScanOK = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mScanString = "";
            mIsScanOK = false;
            Close();
        }

        private void tbScanning_TextChanged(object sender, EventArgs e)
        {
            if (tbScanning.Text.Length == scanLength)
            {
                if (tbScanning.Text.Substring(0,4) == mSiteId)
                {
                    mScanString = tbScanning.Text;





                    mIsScanOK = true;
                    Close();
                }
            }
        }



    }
}
