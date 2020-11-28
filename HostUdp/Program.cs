using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfUdpLib;

namespace HostUdp
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceAddress = "soap.udp://224.0.0.1:40000";
            UdpBinding myBinding = new UdpBinding();
            ServiceHost host = new ServiceHost(typeof(ServiceUdp), new Uri(serviceAddress));
            host.AddServiceEndpoint(typeof(IServiceUdp), myBinding, string.Empty);
            host.Open();
            Console.WriteLine("Press ENTER to stop the service");
            Console.ReadLine();
            host.Close();
        }
    }
}
