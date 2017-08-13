using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCF.Study.Learn.FaultService;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WCF.Study.Learn.FaultClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("When the service is ready, press any key to exit.");
            Console.ReadKey(true);

            ServiceToClient client = new ServiceToClient();
            client.Endpoint.Behaviors.Add(new MessageInspector());

            client.Open();
            try
            {
                int result = client.CauseExceptionByDivideZero(10, 0);
                Console.WriteLine("The result is :{0}", result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:{0}", e.Message);
            }
            finally
            {
                client.Close();
            }
            Console.WriteLine(true);
        }
    }

    public class ServiceToClient : ClientBase<IFaultService>,IFaultService
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
        public ServiceToClient() : base(HelloBinding, HelloAddress) { }

        public int CauseExceptionByDivideZero(int x, int y)
        {
            return Channel.CauseExceptionByDivideZero(x, y);
        }
    }
}
