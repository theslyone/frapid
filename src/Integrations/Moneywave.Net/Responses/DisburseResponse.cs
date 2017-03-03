using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneywave.Net.Responses
{
    public class DisburseResponse
    {
        [JsonProperty("responsecode")]
        public string ResponseCode { get; set; }

        [JsonProperty("responsemessage")]
        public string ResponseMessage { get; set; }

        [JsonProperty("uniquereference")]
        public string UniqueReference { get; set; }
    }
}
