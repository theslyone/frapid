using System;
using Frapid.Configuration.Events.Interfaces;
using Frapid.Configuration.Events.Models;

namespace Frapid.Configuration.Events
{
    public class LoginEvent : IMessageEvent
    {
        public LoginEvent()
        {
            User = new User();
        }

        public string Tenant { get; set; }
        public User User { get; set; }
        public string Type
        {
            get
            {
                return "LoginEvent";
            }
        }

        public Guid EventId { get; set; }
        public DateTime? CreationDate { get; set; }

        public override string ToString()
        {
            return $"Type: {Type} User: {User.LastName} {User.Name} Date: {CreationDate.Value.ToShortDateString()}";
        }
    }
}
