using Frapid.Configuration.Events.Interfaces;
using Serilog;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Frapid.Configuration.Events
{
    public class EasyMQEventManager : IEventManager
	{                
        public void Publish<T>(T eventMessage) where T : class
        {
            try
            {
                Startup.SubscriberBus.Publish(eventMessage);                
                Log.Information($"RabbitMQ Publishing: '{eventMessage}'");
            }
            catch (Exception exc)
            {
                Log.Error($"RabbitMQ Publish Error: '{exc}'");
            }
        }
        
        public void Subscribe<T>(Assembly assembly, Func<T, Task> action) where T : class
        {
            var type = typeof(T);
            var subscriptionId = $"{assembly.GetName().Name}";
            Startup.SubscriberBus.SubscribeAsync(subscriptionId, action);
        }
    }
}
