using Frapid.Configuration.Events;
using Frapid.Configuration.Events.Interfaces;
using System.Threading.Tasks;
using Serilog;
using Frapid.Configuration.Events.Models;
using System;
using OneSignal.CSharp.SDK.Resources.Notifications;
using System.Collections.Generic;
using OneSignal.CSharp.SDK.Resources;
using OneSignal.CSharp.SDK;

namespace Frapid.Notifications.EventSubscribers
{
    public class UserUpdateRequiredEventSubscriber : IEventSubscriber
    {
        private static string appId => "a6310169-4a52-4359-99d7-5ac8ee21ffd9";
        private static string apiKey => "MTEyODZjMDktOWEwYS00NDc2LThjZTEtMTUzMjM4M2QxOWRl";
        private static readonly OneSignalClient client = new OneSignalClient(apiKey);

        public void Register(IEventManager eventManager)
        {
            eventManager.Subscribe<UserUpdateRequiredEvent>(GetType().Assembly, EventHandler);
        }

        public string Description
        {
            get
            {
                return "Frapid.Notifications profile update event subscriber";
            }
        }

        public Task EventHandler(UserUpdateRequiredEvent userUpdateRequiredEvent)
        {
            try
            {
                Log.Information($"User Update Event Received {userUpdateRequiredEvent}");
                var user = userUpdateRequiredEvent.User;

                var options = new NotificationCreateOptions();
                //options.SendAfter = DateTime.Now.AddSeconds(5);
                options.AppId = new Guid(appId);
                options.Filters = new List<INotificationFilter>();
                options.Filters.Add(new NotificationFilterField
                {
                    Field = NotificationFilterFieldTypeEnum.Email,
                    Key = "email",
                    Relation = "=",
                    Value = user.Email
                });
                options.Filters.Add(new NotificationFilterField
                {
                    Field = NotificationFilterFieldTypeEnum.Tag,
                    Key = "email",
                    Relation = "=",
                    Value = user.Email
                });
                if (!string.IsNullOrEmpty(user.DeviceId))
                    options.IncludePlayerIds = new List<string> { user.DeviceId };

                options.Contents.Add(LanguageCodes.English, $"We would like to know more about you before activating your account for transactions. \nPlease update your profile information");
                options.Headings.Add(LanguageCodes.English, $"Welcome to freebe");
                options.ActionButtons = new List<ActionButtonField>();
                options.ActionButtons.Add(new ActionButtonField { Id = "profile", Text = "Profile" });
                options.Data = new Dictionary<string, string>();
                options.Data.Add("type", "profileUpdateNotification");

                NotificationCreateResult response = client.Notifications.Create(options);

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