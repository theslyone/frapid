using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutterwave.BillPayment.Models
{
    public class Product
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("productcode")]
        public string Code { get; set; }

        [JsonProperty("merchant_id")]
        public string MerchantId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("cost")]
        public decimal Cost { get; set; }

        [JsonProperty("isFixedCost")]
        public bool IsFixedCost { get; set; }

        [JsonProperty("when")]
        public string When { get; set; }

        [JsonProperty("where")]
        public string Where { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("ticket")]
        public bool Ticket { get; set; }

        [JsonProperty("commission")]
        public decimal Commission { get; set; }

        [JsonProperty("hookurl")]
        public string HookUrl { get; set; }

        [JsonProperty("hookdata")]
        public dynamic HookData { get; set; } 
    }

    public class HookData
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("recipient_phone_number")]
        public string RecipientPhoneNumber { get; set; }

        
    }
}
