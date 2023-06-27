using PrinterUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thepos.Setup
{
    public partial class frmSetup : Form
    {
        public frmSetup()
        {
            InitializeComponent();

            cbPort.SelectedIndex = 6;
            cbRate.SelectedIndex = 7;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string printerPort = "";
            string printertRate = "";



            printerPort = cbPort.SelectedItem.ToString();
            printertRate = cbRate.SelectedItem.ToString();


            try
            {

                SerialPort port = new SerialPort();

                if (port.IsOpen)
                    port.Close();


                port.PortName = printerPort;
                port.BaudRate = (int)9600; //고정
                port.DataBits = (int)8;
                port.Parity = Parity.None;
                port.StopBits = StopBits.One;

                port.Open();
                port.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("통신포트 에러.\r\n" + ex.Message);
                return;
            }



            try
            {


                const string ESC = "\u001B";
                const string InitializePrinter = ESC + "@";

                PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();

                byte[] BytesValue = new byte[100];

                BytesValue = PrintExtensions.AddBytes(BytesValue, InitializePrinter);

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.DoubleWidth2());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes("매출전표"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes("(카드사/가맹점)"));

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());


                string str1 = "";
                int len1 = 0;
                string str2 = "";
                int len2 = 0;




                str1 = "수기서명을 받으세요";
                len1 = 42 - enclen(str1);
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(string.Format("{0,-" + len1 + "}", str1)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                str1 = "[서 명]   ";
                str2 = "0001";
                len2 = str2.Length;
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(str1));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.DoubleWidth2());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(Space(16 - len2)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(str2));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());



                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());



                BytesValue = PrintExtensions.AddBytes(BytesValue, CutPage());

                PrintExtensions.Print(BytesValue, printerPort);
            }
            catch (Exception ex)
            {
                MessageBox.Show("인쇄중 에러.\r\n" + ex.Message);
                return;
            }
        }


        private int enclen(string str)
        {
            return Encoding.Default.GetBytes(str).Length - str.Length;
        }


        private string strPosTitle(string title)
        {
            int blen = Encoding.Default.GetBytes(title).Length;
            int slen = title.Length;
            int len = 16 - (blen - slen);

            return string.Format("{0,-" + len + "}{1,3}", title, 1) + " : ";
        }



        public byte[] CutPage()
        {

            byte[] partial_cut = new byte[3] { 0x1D, 0x56, 0x00 };

            return partial_cut;


        }
        public string Space(int count)
        {
            return new String(' ', count);
        }
    }
}
