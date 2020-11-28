using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfTcpLib
{
    [ServiceContract]
    public interface IServiceTcp
    {
        [OperationContract]
        string GetBase64Encode(string fileName, int offset, int size);

        [OperationContract]
        string SaveFileBlock(byte[] block);

        [OperationContract]
        int GetWordsCount(List<string> text);

        [OperationContract]
        string GetTime();
    }

}
