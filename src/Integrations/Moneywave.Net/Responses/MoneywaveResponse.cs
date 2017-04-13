using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Frapid.RestApi.Responses;

namespace Moneywave.Net.Responses
{
    public class MoneywaveResponse<T> : RestApiResponse<T> where T : class
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }
    }
}
