using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneywave.Net.Responses
{
    public class DisburseResponse
    {
        [JsonProperty("data")]
        public DisburseData Data { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
    }

    public class DisburseData
    {
        [JsonProperty("responsecode")]
        public string ResponseCode { get; set; }

        [JsonProperty("responsemessage")]
        public string ResponseMessage { get; set; }

        [JsonProperty("uniquereference")]
        public string UniqueReference { get; set; }
    }
}
