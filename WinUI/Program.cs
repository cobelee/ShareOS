using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinUI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MDIMain());
            //Application.Run(new ImportIdentityCard());
            //Application.Run(new ShareholderBarCode());
        }
    }
}
