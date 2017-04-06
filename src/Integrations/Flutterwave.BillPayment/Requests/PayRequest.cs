using Flutterwave.BillPayment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutterwave.BillPayment.Requests
{
    public class PayRequest
    {
        public PayRequest()
        {
            HookData = new ExpandoObject();
        }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("hookdata")]
        public dynamic HookData { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("processor")]
        public string Processor { get; set; }
        
    }
}
