using Frapid.Events.Interfaces;
using System;
using Frapid.Events.Models;
using Newtonsoft.Json;

namespace Frapid.Events
{
    [Serializable]
    public class TransactionEvent : IMessageEvent
    {
        public TransactionEvent()
        {
            
        }

        public Guid EventId { get; set; }
        public DateTime? CreationDate { get; set; }

        [JsonProperty("fromCustomer")]
        public User FromCustomer {get;set;}

        [JsonProperty("toCustomer")]
        public User ToCustomer { get; set; }

        [JsonProperty("fromSubaccountId")]
        public int FromSubaccountId { get; set; }

        [JsonProperty("toSubaccountId")]
        public int? ToSubaccountId { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("date")]
        public DateTime TransactionDate { get; set; }

        [JsonProperty("tenant")]
        public string Tenant { get; set; }

        [JsonProperty("type")]
        public string Type
        {
            get
            {
                return "TransactiontEvent";
            }
        }

        public override string ToString()
        {
            return $"Type: {Type} Amount: {Amount} Date: {CreationDate.Value.ToShortDateString()}";
        }
    }
}
