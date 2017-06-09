using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrations.Test.Models
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

        private string phoneNumber = "";
        [JsonProperty("recipient_phone_number")]
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }

        [JsonProperty("phone")]
        public string Phone { get { return phoneNumber; } set { phoneNumber = value; } }

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
