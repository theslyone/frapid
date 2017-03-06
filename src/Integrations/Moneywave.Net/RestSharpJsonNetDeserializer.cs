using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneywave.Net
{
    public class RestSharpJsonNetDeserializer
    {
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }

        public T Deserialize<T>(RestResponse response) where T : new()
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
