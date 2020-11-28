using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WcfUdpLib;

namespace UdpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceAddress = "soap.udp://224.0.0.1:40000";
            UdpBinding myBinding = new UdpBinding();
            ChannelFactory<IServiceUdp> cf = new ChannelFactory<IServiceUdp>(myBinding,
                            new EndpointAddress(serviceAddress));
            IServiceUdp serv = cf.CreateChannel();

            while (true)
            {
                Console.WriteLine(serv.GetTime());
                Thread.Sleep(1000);
            }
            Console.ReadKey();
            
        }
    }
}
