using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneywave.Net.Models
{
    public class Card
    {
        [JsonProperty("card_no")]
        public string CardNumber { get; set; }

        [JsonProperty("expiry_year")]
        public string ExpiryYear { get; set; }

        [JsonProperty("expiry_month")]
        public string ExpiryMonth { get; set; }

        [JsonProperty("cvv")]
        public string Cvv { get; set; }
    }
}
