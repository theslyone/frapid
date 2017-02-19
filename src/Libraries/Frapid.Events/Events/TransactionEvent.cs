using Frapid.Events.Interfaces;
using System;
using Frapid.Events.Models;

namespace Frapid.Events
{
    [Serializable]
    public class TransactiontEvent : IMessageEvent
    {
        public TransactiontEvent()
        {
            Customer = new User();
        }

        public Guid EventId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? CreationDate { get; set; }

        public User Customer {get;set;}
        public string SubAccountId { get; set; }

        public string Reference { get; set; }

        public decimal Amount { get; set; }
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
            return $"Type: {Type} Amount: {Amount} Date: {Date.Value.ToShortDateString()}";
        }
    }
}
