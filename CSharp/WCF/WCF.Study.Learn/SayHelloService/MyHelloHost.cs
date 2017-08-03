using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace WCF.Study.Learn.ServiceModule
{
   
    public class MyHelloHost:IDisposable
    {
        /// <summary>
        /// 定义一个服务对象
        /// </summary>
        private ServiceHost m_ServiceHost;

        public ServiceHost ServiceHost
        {
            get
            {
                return m_ServiceHost;
            }
        }

        /// <summary>
        /// 定义一个基地址
        /// </summary>
        public const string m_BaseAddress = "net.pipe://localhost";

        /// <summary>
        /// 可选地址
        /// </summary>
        public const string m_HelloServiceAddress = "Hello";

        // 服务契约实现类型
        public static readonly Type ServiceType = typeof(MyHelloInstance);
        // 服务契约(接口)
        public static readonly Type ContractType = typeof(ISayHelloable);

        /// <summary>
        /// 服务定义一个绑定
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

        /// <summary>
        /// 打开服务
        /// </summary>
        public void OpenService()
        {
            Console.WriteLine("service starting...");
            m_ServiceHost.Open();
            Console.WriteLine("service started.");
        }

        public MyHelloHost()
        {
            CreateHelloServiceHost();
        }

        /// <summary>
        /// 销毁对象
        /// </summary>
        public void Dispose()
        {
            if (null != m_ServiceHost)
            {
                m_ServiceHost.Close();
            }
        }
    }
}
