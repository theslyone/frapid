using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutterwave.BillPayment.Responses
{
    public class PayResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("merchant_id")]
        public string MerchantId { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("cost")]
        public decimal Cost { get; set; }

        [JsonProperty("recurring")]
        public bool Recurring { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("card_id")]
        public string CardId { get; set; }

        [JsonProperty("nextDue")]
        public DateTime? NextDue { get; set; }

        [JsonProperty("stopDate")]
        public DateTime? StopDate { get; set; }

        [JsonProperty("ref")]
        public string Reference { get; set; }

        [JsonProperty("linking_ref")]
        public string LinkingReference { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("paid")]
        public bool Paid { get; set; }

        [JsonProperty("settled")]
        public bool Settled { get; set; }

        [JsonProperty("delivered")]
        public bool Delivered { get; set; }

        [JsonProperty("merchant_fee")]
        public decimal MerchantFee { get; set; }

        [JsonProperty("actual_cost")]
        public decimal ActualCost { get; set; }

        [JsonProperty("balance")]
        public decimal Balance { get; set; }
    }
}
