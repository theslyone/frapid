using EasyNetQ.AutoSubscribe;
using Frapid.Events;
using Frapid.Events.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frapid.Events.EventSubscribers
{
    public class TransactionSubscriber : IEventSubscriber, IConsumeAsync<EntityInserted<TransactionEvent>>
    {
        [AutoSubscriberConsumer(SubscriptionId = "events_transaction_completed")]
        public Task Consume(EntityInserted<TransactionEvent> transactionInsertedEvent)
        {
            try
            {
                string tenant = transactionInsertedEvent.Entity.Tenant;
                Log.Information($"{tenant}: Received {transactionInsertedEvent}");

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Log.Error("Exception: {Exception}", ex);
                throw ex;
            }
        }
    }
}
