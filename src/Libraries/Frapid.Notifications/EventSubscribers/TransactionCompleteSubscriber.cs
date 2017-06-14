using Frapid.Configuration;
using Frapid.Configuration.Events;
using Frapid.Configuration.Events.Interfaces;
using Frapid.Framework.Extensions;
using Newtonsoft.Json;
using OneSignal.CSharp.SDK;
using OneSignal.CSharp.SDK.Resources;
using OneSignal.CSharp.SDK.Resources.Notifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frapid.Notifications
{
    public class TransactionCompleteSubscriber : IEventSubscriber
    {
        private static string appId => "a6310169-4a52-4359-99d7-5ac8ee21ffd9";
        private static string apiKey => "MTEyODZjMDktOWEwYS00NDc2LThjZTEtMTUzMjM4M2QxOWRl";

        public string Description
        {
            get
            {
                return "Frapid.Notifications transaction event subscriber";
            }
        }

        private static readonly OneSignalClient client;

        static TransactionCompleteSubscriber()
        {
            client = new OneSignalClient(apiKey);
        }

        public Task Notify(EntityInserted<TransactionEvent> transactionEntity)
        {
            var transactionEvent = transactionEntity.Entity;
            int recipientCount = 0;
            if (!string.IsNullOrEmpty(transactionEvent.FromCustomer.DeviceId))
            {
                var options = new NotificationCreateOptions();
                options.AppId = new Guid(appId);
                options.Filters = new List<INotificationFilter>();
                //options.Filters.Add(new NotificationFilterField { Field = NotificationFilterFieldTypeEnum.Tag, Key = "email", Relation = "=", Value = transactionEvent.ToCustomer.Email });
                options.IncludePlayerIds = new List<string> { transactionEvent.FromCustomer.DeviceId };

                options.Contents.Add(LanguageCodes.English, $@"Transfer of {transactionEvent.Amount} NGN to 
                {transactionEvent?.ToCustomer?.Name.Or("someone")} completed. \nReference: {transactionEvent.Reference} 
                \nDate: {transactionEvent.TransactionDate.ToLongDateString()}");
                options.Headings.Add(LanguageCodes.English, $"Transfer completed");
                options.ActionButtons = new List<ActionButtonField>();
                options.ActionButtons.Add(new ActionButtonField { Id = "transfer", Text = "View" });

                options.Data = new Dictionary<string, string>();
                options.Data.Add("type", "transferNotification");
                options.Data.Add("mainSubaccountId", transactionEvent.SourceAccount.Id.ToString());
                options.Data.Add("transfer", JsonConvert.SerializeObject(transactionEvent, Formatting.None));

                NotificationCreateResult response = client.Notifications.Create(options);
                recipientCount = response.Recipients;
            }

            if (transactionEvent.ToCustomer != null && !string.IsNullOrEmpty(transactionEvent.ToCustomer.DeviceId))
            {
                var options = new NotificationCreateOptions();
                options.AppId = new Guid(appId);
                options.Filters = new List<INotificationFilter>();
                options.IncludePlayerIds = new List<string> { transactionEvent.ToCustomer.DeviceId };

                options.Contents.Add(LanguageCodes.English, $@"A transfer of {transactionEvent.Amount} NGN from 
                {transactionEvent.FromCustomer.Name} has just been received and deposited to your bank account. 
                \nReference: {transactionEvent.Reference}. \nDate: {transactionEvent.TransactionDate}");
                options.Headings.Add(LanguageCodes.English, "Transfer Received");
                options.ActionButtons = new List<ActionButtonField>();
                options.ActionButtons.Add(new ActionButtonField { Id = "transfer", Text = "View" });

                options.Data = new Dictionary<string, string>();
                options.Data.Add("type", "transferNotification");
                options.Data.Add("mainSubaccountId", transactionEvent.DestinationAccount.Id.ToString());
                options.Data.Add("transfer", JsonConvert.SerializeObject(transactionEvent, Formatting.None));

                var response = client.Notifications.Create(options);
                recipientCount += response.Recipients;
            }
            return Task.CompletedTask;
        }

        public void Register(IEventManager eventManager)
        {
            eventManager.Subscribe<EntityInserted<TransactionEvent>>(GetType().Assembly, Notify);
        }
    }
}