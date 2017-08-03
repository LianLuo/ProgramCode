using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WCF.Study.Learn.ServiceModule
{
    /// <summary>
    /// 服务契约
    /// </summary>
    [ServiceContract]
    public interface ISayHelloable
    {
        /// <summary>
        /// 服务操作
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [OperationContract]
        string SayHello(string msg);
    }
}
