using Frapid.Configuration.Events.Interfaces;
using System;
using Frapid.Configuration.Events.Models;

namespace Frapid.Configuration.Events
{
    [Serializable]
    public class UserEvent : IMessageEvent
    {
        public UserEvent()
        {
            User = new User();
        }

        public Guid EventId { get; set; }
        public DateTime? CreationDate { get; set; }
        public User User {get;set;}       
        public string Type
        {
            get
            {
                return "UserEvent";
            }
        }

        public string Tenant { get; set; }
        
        public override string ToString()
        {
            return $"Type: {Type} User: {User.LastName} {User.Name} Date: {CreationDate.Value.ToShortDateString()}";
        }
    }
}
