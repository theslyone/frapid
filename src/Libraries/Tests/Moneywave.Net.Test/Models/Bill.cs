using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneywave.Net.Test.Models
{
    public class Bill
    {
        [JsonProperty("fromSubaccountId")]
        public string FromSubaccountId { get; set; }

        [JsonProperty("fromSubaccountPin")]
        public string FromSubaccountPin { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("recipient_phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("smart_card_number")]
        public string SmartCardNumber { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
