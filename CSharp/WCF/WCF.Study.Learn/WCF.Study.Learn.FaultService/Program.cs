using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WCF.Study.Learn.FaultService
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080");
            ServiceHost host = new ServiceHost(typeof(FaultServiceImp), baseAddress);
            host.AddServiceEndpoint(typeof(IFaultService), new BasicHttpBinding(), baseAddress);
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);
            host.Open();
            Console.WriteLine("The service is ready!(Please Enter a exit.)");
            Console.ReadKey();
        }
    }
}
