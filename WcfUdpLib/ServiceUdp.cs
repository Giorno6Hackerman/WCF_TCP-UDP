using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfUdpLib
{
    public class ServiceUdp : IServiceUdp
    {
        public string GetTime()
        {
            return DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss.ffffff K");
        }


    }


}
