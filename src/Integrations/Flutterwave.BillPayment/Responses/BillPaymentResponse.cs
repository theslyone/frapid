using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Flutterwave.BillPayment.Responses
{
    public class BillPaymentResponse<T> where T : class
    {
        [JsonProperty("status")]
        //[JsonConverter(typeof(StringEnumConverter))]
        public string Status { get; set; }

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
