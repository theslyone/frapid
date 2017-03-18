using Frapid.Events.Interfaces;
using Frapid.Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frapid.Events
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
