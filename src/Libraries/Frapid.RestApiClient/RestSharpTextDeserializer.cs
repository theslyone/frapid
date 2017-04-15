using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frapid.RestApi
{
    public class RestSharpTextDeserializer : IDeserializer
    {
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
        
        public T Deserialize<T>(IRestResponse response)
        {
            T data = Activator.CreateInstance<T>();
            return data;
        }
    }

}
