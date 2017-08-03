using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Data;

namespace WCF.Study.Learn.IServiceConfig
{
    [ServiceContract]
    public interface ICalculateable
    {
        [OperationContract]
        float Add(float num1, float num2);

        [OperationContract]
        float Times(float num1, float num2);

        [OperationContract]
        DateTime GetDateTime();

        [OperationContract]
        DataTable GetUserInfo();
    }
}
