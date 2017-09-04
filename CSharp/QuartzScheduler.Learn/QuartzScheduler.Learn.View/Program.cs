using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System;

namespace QuartzScheduler.Learn.View
{
    static class Program
    {
        public static MainView MainForm;
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new MainView();
            Application.Run(MainForm);
        }
    }
}
