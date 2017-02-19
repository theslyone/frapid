using Frapid.Events.Interfaces;

namespace Frapid.Events.EventPublishers
{
    public class DefaultEventPublisher
    {
        public static IEventPublisher GetInstance()
        {
            return new EasyMQEventPublisher();
        }
    }
}
