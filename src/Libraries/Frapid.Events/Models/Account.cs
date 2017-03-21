using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frapid.Events.Models
{
    public class Account
    {
        [JsonProperty("accountName")]
        public string AccountName { get; set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("bankCode")]
        public string SettlementBankCode { get; set; }

        [JsonProperty("bankName")]
        public string SettlementBank { get; set; }
        
    }
}
