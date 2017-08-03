using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCF.Study.Learn.IServiceConfig;

namespace WCF.Study.Learn.ServiceConfig
{
    public class Calculator:ICalculateable
    {
        public float Add(float num1, float num2)
        {
            throw new NotImplementedException();
        }

        public float Times(float num1, float num2)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }

        public System.Data.DataTable GetUserInfo()
        {
            throw new NotImplementedException();
        }
    }
}
