using Frapid.Configuration.Events.Interfaces;
using Frapid.Configuration.Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frapid.Configuration.Events
{
    public class UserUpdateRequiredEvent : IMessageEvent
    {
        public UserUpdateRequiredEvent()
        {
            User = new User();
        }

        public string Type
        {
            get
            {
                return "UserUpdateRequiredEvent";
            }
        }

        public Guid EventId { get; set; }
        public DateTime? CreationDate { get; set; }

        public override string ToString()
        {
            return $"Type: {Type} User: {User.LastName} {User.Name} Date: {CreationDate.Value.ToShortDateString()}";
        }

        public User User { get; set;  }

        public string Tenant
        {
            get;set;
        }
    }
}
