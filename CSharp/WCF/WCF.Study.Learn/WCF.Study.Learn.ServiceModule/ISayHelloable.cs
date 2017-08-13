using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WCF.Study.Learn.ServiceModule
{
    /// <summary>
    /// 服务操作
    /// </summary>
    [ServiceContract]
    public interface ISayHelloable
    {
        [OperationContract]
        string SayHello(string msg);
    }

    public class HelloHost : IDisposable
    {
        private ServiceHost m_ServiceHost;

        public ServiceHost ServiceHost
        {
            get
            {
                return m_ServiceHost;
            }
        }

        /// <summary>
        /// 基地址
        /// </summary>
        private const string m_BaseAddress = "net.pipe://localhost";

        /// <summary>
        /// 可选地址
        /// </summary>
        private const string m_HelloServiceAddress = "Hello";

        /// <summary>
        /// 服务契约实现类型
        /// </summary>
        public static readonly Type ServiceType = typeof(HelloInstance);

        /// <summary>
        /// 服务契约（接口）
        /// </summary>
        public static readonly Type ContractType = typeof(ISayHelloable);

        /// <summary>
        /// 为服务定义一个绑定
        /// </summary>
        public static readonly Binding HelloBinding = new NetNamedPipeBinding();

        /// <summary>
        /// 构造一个服务对象
        /// </summary>
        protected void CreateHelloServiceHost()
        {
            // 创建服务对象
            m_ServiceHost = new ServiceHost(ServiceType, new Uri[] { new Uri(m_BaseAddress) });
            // 添加一个终结点
            m_ServiceHost.AddServiceEndpoint(ContractType, HelloBinding, m_HelloServiceAddress);
        }

        public void OpenService()
        {
            Console.WriteLine("service starting.");
            m_ServiceHost.Open();
            Console.WriteLine("service started.");
        }

        public HelloHost()
        {
            CreateHelloServiceHost();
        }

        public void Dispose()
        {
            if (null != m_ServiceHost)
            {
                m_ServiceHost.Close();
            }
        }
    }

    public class HelloInstance : ISayHelloable
    {

        public string SayHello(string msg)
        {
            return string.Format("{0} Says: Hello,world", msg);
        }
    }
}
