using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfTcpLib;

namespace HostTcp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ServiceTcp));
            host.AddServiceEndpoint(typeof(IServiceTcp), new NetTcpBinding(), "net.tcp://localhost:8001/tcp");
            host.Open();
            Console.WriteLine("Press ENTER to stop the service");
            Console.ReadLine();
            host.Close();
        }
    }
}
