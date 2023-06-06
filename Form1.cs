using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;
using PrinterUtility;

using System.Net;



namespace thepos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            cbPort.SelectedIndex = 2;
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
                string str3 = "";
                int len3 = 0;

                str1 = txt카드종류.Text;
                len1 = 22 - enclen(str1);
                str2 = txt거랭유형.Text;
                len2 = 20 - enclen(str2);
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(string.Format("{0,-" + len1 + "}{1," + len2 + "}", str1, str2)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                str1 = "거래일시";
                len1 = 16 - enclen(str1);
                str2 = txt거래일시.Text;
                len2 = 26 - enclen(str2);
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(string.Format("{0,-" + len1 + "}{1," + len2 + "}", str1, str2)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                str1 = "카드번호";
                len1 = 16 - enclen(str1);
                str2 = txt카드번호.Text;
                len2 = 26 - enclen(str2);
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(string.Format("{0,-" + len1 + "}{1," + len2 + "}", str1, str2)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                str1 = "유효기간(년/월) : **/**";
                len1 = 26 - enclen(str1);
                str2 = txt일시불할부.Text;
                len2 = 16 - enclen(str2);
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(string.Format("{0,-" + len1 + "}{1," + len2 + "}", str1, str2)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                str1 = "가맹점번호";
                len1 = 16 - enclen(str1);
                str2 = txt가맹점번호.Text;
                len2 = 26 - enclen(str2);
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(string.Format("{0,-" + len1 + "}{1," + len2 + "}", str1, str2)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());




                str2 = txt승인번호.Text;
                len2 = str2.Length;

                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes("승인번호"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.DoubleWidth2());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(Space(17 - len2)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(txt승인번호.Text));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                str1 = "매입사 : ";
                len1 = 10 - enclen(str1);
                str2 = txt매입사.Text;
                len2 = 32 - enclen(str2);
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(string.Format("{0,-" + len1 + "}{1,-" + len2 + "}", str1, str2)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());



                if (cb유종인쇄.Checked)
                {
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes("------------------------------------------"));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                    str1 = "유종명";
                    len1 = 14 - enclen(str1);
                    str2 = "수 량";
                    len2 = 14 - enclen(str2);
                    str3 = "단 가";
                    len3 = 14 - enclen(str3);
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(string.Format("{0,-" + len1 + "}{1," + len2 + "}{2," + len3 + "}", str1, str2, str3)));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes("------------------------------------------"));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                    str1 = txt유종명.Text;
                    len1 = 14 - enclen(str1);
                    str2 = txt수량.Text + "L";
                    len2 = 14 - enclen(str2);
                    str3 = txt단가.Text + "원";
                    len3 = 14 - enclen(str3);
                    BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(string.Format("{0,-" + len1 + "}{1," + len2 + "}{2," + len3 + "}", str1, str2, str3)));
                    BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
                }


                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes("------------------------------------------"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                str1 = "판매금액  ";
                str2 = txt판매금액.Text;
                len2 = str2.Length;
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(str1));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.DoubleWidth2());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(Space(15 - len2)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(str2));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes("원"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());



                str1 = "부가가치세";
                str2 = txt부가가치세.Text;
                len2 = str2.Length;
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(str1));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.DoubleWidth2());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(Space(15 - len2)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(str2));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes("원"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                str1 = "봉사료    ";
                str2 = txt봉사료.Text;
                len2 = str2.Length;
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(str1));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.DoubleWidth2());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(Space(15 - len2)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(str2));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes("원"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                str1 = "합계      ";
                str2 = txt합계.Text;
                len2 = str2.Length;
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(str1));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.DoubleWidth2());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(Space(15 - len2)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(str2));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.Nomarl());
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes("원"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes("------------------------------------------"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                str1 = "가맹점명";
                len1 = 16 - enclen(str1);
                str2 = txt가맹점명.Text;
                len2 = 26 - enclen(str2);
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(string.Format("{0,-" + len1 + "}{1," + len2 + "}", str1, str2)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                str1 = "사업자번호";
                len1 = 16 - enclen(str1);
                str2 = txt사업자번호.Text;
                len2 = 26 - enclen(str2);
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(string.Format("{0,-" + len1 + "}{1," + len2 + "}", str1, str2)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                str1 = "대표자명 : " + txt대표자명.Text;
                len1 = 22 - enclen(str1);
                str2 = "TEL : " + txtTEL.Text;
                len2 = 20 - enclen(str2);
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(string.Format("{0,-" + len1 + "}{1," + len2 + "}", str1, str2)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                str1 = "주소:" + txt주소.Text;
                len1 = 42 - enclen(str1);
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(string.Format("{0,-" + len1 + "}", str1)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes("------------------------------------------"));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                str1 = "CATID : " + txtCATID.Text;
                len1 = 20 - enclen(str1);
                str2 = "전표No " + txt전표No.Text;
                len2 = 22 - enclen(str2);
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(string.Format("{0,-" + len1 + "}{1," + len2 + "}", str1, str2)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());

                str1 = "수기서명을 받으세요";
                len1 = 42 - enclen(str1);
                BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.Default.GetBytes(string.Format("{0,-" + len1 + "}", str1)));
                BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());


                str1 = "[서 명]   ";
                str2 = txt전표순번.Text;
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
