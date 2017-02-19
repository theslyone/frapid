using Frapid.Events.Interfaces;
using Serilog;
using EasyNetQ;

namespace Frapid.Events.EventPublishers
{
    public class EasyMQEventPublisher : IEventPublisher
	{                
        public void Publish<T>(T eventMessage) where T : class
        {
            try
            {
                var bus = RabbitHutch.CreateBus("host=localhost");
                bus.Publish(eventMessage);                
                Log.Information($"RabbitMQ Publishing: '{eventMessage}'");
            }
            catch (System.Exception exc)
            {
                Log.Error($"RabbitMQ Publish Error: '{exc}'");
            }
        }        
    }
}
