using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCF.Study.Learn.ServiceModule
{
    public class MyHelloInstance:ISayHelloable
    {
        public string SayHello(string msg)
        {
            return string.Format("{0} Say: Hello world.", msg);
        }

    }
}
