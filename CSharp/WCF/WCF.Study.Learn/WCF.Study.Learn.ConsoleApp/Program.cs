using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCF.Study.Learn.ServiceModule;

namespace WCF.Study.Learn.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var helloHost = new MyHelloHost())
            {

                helloHost.OpenService();
                Console.ReadKey();
            }
        }
    }
}
