using Newtonsoft.Json;
using RestSharp;

namespace Frapid.RestApi
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
