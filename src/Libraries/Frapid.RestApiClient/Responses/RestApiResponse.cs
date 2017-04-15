using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Frapid.RestApi.Responses
{
    public class RestApiResponse<T> where T : class
    {
        [JsonProperty("status")]
        //[JsonConverter(typeof(StringEnumConverter))]
        public string Status { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
        
    }

    public enum Status {
        [EnumMember(Value = "success")]
        Success,
        [EnumMember(Value = "fail")]
        Error
    }
}
