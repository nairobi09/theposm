using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thepos
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process[] procs = Process.GetProcessesByName("theposMain");

            if (procs.Length > 1)
            {
                //중복 실행 방지
                MessageBox.Show("'프로세스 이름'는 실행 중 입니다.");
                return;
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
        }
    }
}
