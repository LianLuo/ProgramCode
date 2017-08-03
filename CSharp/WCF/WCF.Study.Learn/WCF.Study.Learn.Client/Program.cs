using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WCF.Study.Learn.ServiceModule;
using System.ServiceModel.Channels;

namespace WCF.Study.Learn.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (HelloProxy proxy = new HelloProxy())
            {
                Console.WriteLine(proxy.Say("Lucy"));
                Console.ReadKey();
            }
        }
    }

    [ServiceContract]
    interface IService
    {
        [OperationContract]
        string Say(string name);
    }

    public class HelloProxy : ClientBase<ISayHelloable>, IService
    {
        /// <summary>
        /// 硬编码定义绑定
        /// </summary>
        public static readonly Binding HelloBinding = new NetNamedPipeBinding();
        /// <summary>
        /// 硬编码定义地址
        /// </summary>
        public static readonly EndpointAddress HelloAddress = new EndpointAddress(new Uri("net.pipe://localhost/Hello"));
        /// <summary>
        /// 构造函数
        /// </summary>
        public HelloProxy() : base(HelloBinding, HelloAddress) { }

        public string Say(string name)
        {
            // 使用Channel属性对服务进行调用
            return Channel.SayHello(name);
        }
    }
}
