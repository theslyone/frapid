using System;
using System.Threading.Tasks;

namespace Frapid.Configuration.Events.Interfaces
{
    public interface IEventSubscriber
    {
        void Register(IEventManager eventManager);
        string Description { get; }
    }
}
