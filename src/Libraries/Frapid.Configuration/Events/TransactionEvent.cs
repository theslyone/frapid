using Frapid.Configuration.Events.Interfaces;
using System;
using Frapid.Configuration.Events.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Frapid.Configuration.Events
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

        [JsonProperty("sourceAccount")]
        public Account SourceAccount { get; set; }

        [JsonProperty("destinationAccount")]
        public Account DestinationAccount { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("fees")]
        public decimal Fees { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("date")]
        public DateTime TransactionDate { get; set; }

        [JsonProperty("tenant")]
        public string Tenant { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("purpose")]
        public string Purpose { get; set; }

        [JsonProperty("type")]
        public string Type
        {
            get
            {
                return "TransactiontEvent";
            }
        }

        [JsonProperty("metaData")]
        public Dictionary<string, string> MetaData { get; set; }


        public override string ToString()
        {
            return $"Type: {Type} Amount: {Amount} Date: {CreationDate.Value.ToShortDateString()}";
        }
    }
}
