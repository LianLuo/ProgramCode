using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.AppStore.Views
{
    static class Program
    {
        public static GlobalControl gc = new GlobalControl();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            gc.View = new MainView();
            Application.Run(gc.View);
        }
    }
}
