using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Moneywave.Net.Responses
{
    public class MoneywaveResponse<T> where T : class
    {
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

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
        [EnumMember(Value = "error")]
        Error
    }
}
