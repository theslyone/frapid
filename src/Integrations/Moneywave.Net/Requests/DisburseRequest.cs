using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneywave.Net.Requests
{
    public class DisburseRequest
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("lock")]
        public string Lock { get; set; }

        [JsonProperty("bankcode")]
        public string BankCode { get; set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("currency")]
        public string Currency { get { return "NGN"; } }

        [JsonProperty("senderName")]
        public string SenderName { get; set; }

        [JsonProperty("ref")]
        public string Ref { get; set; }
    }
}
