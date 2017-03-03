using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneywave.Net.Responses
{
    public class ChargeResponse
    {
        //the total amount we will send to the recipient
        [JsonProperty("amountToSend")]
        public decimal AmountToSend { get; set; }

        // the total amount we will charge the card
        [JsonProperty("amountChargeable")]
        public decimal AmountChargeable { get; set; }

        // your commission
        [JsonProperty("merchantCommission")]
        public decimal MerchantCommission { get; set; }
    }
}
