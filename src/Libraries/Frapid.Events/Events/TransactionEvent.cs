using Frapid.Events.Interfaces;
using System;
using Frapid.Events.Models;

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

        public User FromCustomer {get;set;}
        public User ToCustomer { get; set; }
        public int FromSubaccountId { get; set; }
        public int? ToSubaccountId { get; set; }
       
        public string Reference { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }
        public string Tenant { get; set; }

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
