using System;

namespace Frapid.Events.Interfaces
{
    public interface IMessageEvent
    {
        Guid EventId { get; set; }
        DateTime? CreationDate { get; set; }
        string Type { get; }
        string Tenant { get; set; }

    }
}
