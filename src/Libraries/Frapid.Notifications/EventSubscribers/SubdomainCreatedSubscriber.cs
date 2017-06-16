using OneSignal.CSharp.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frapid.Notifications.EventSubscribers
{
    public class SubdomainCreatedSubscriber
    {
        private static string appId => "a6310169-4a52-4359-99d7-5ac8ee21ffd9";
        private static string apiKey => "MTEyODZjMDktOWEwYS00NDc2LThjZTEtMTUzMjM4M2QxOWRl";

        private static readonly OneSignalClient client;
        static SubdomainCreatedSubscriber()
        {
            client = new OneSignalClient(apiKey);
        }

        public static bool PushSubdomainCreated(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.DeviceId))
                return false;

            var options = new NotificationCreateOptions();
            options.AppId = new Guid(appId);
            options.Filters = new List<INotificationFilter>();
            options.IncludePlayerIds = new List<string> { customer.DeviceId };

            options.Contents.Add(LanguageCodes.English, $@"{customer.Subdomain}.{TenantConvention.GetDefaultTenantName()} has been 
                set up and provisioned for you on Freebe");
            options.Headings.Add(LanguageCodes.English, $"Freebe sub account provisioned successfully.");
            options.Data = new Dictionary<string, string>();
            options.Data.Add("type", "subdomainCreateNotification");
            options.Data.Add("customer", JsonConvert.SerializeObject(customer, Formatting.None));
            NotificationCreateResult response = client.Notifications.Create(options);
            return response.Recipients > 0;
        }

        public static bool PushSubdomainError(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.DeviceId))
                return false;

            var options = new NotificationCreateOptions();
            options.AppId = new Guid(appId);
            options.Filters = new List<INotificationFilter>();
            options.IncludePlayerIds = new List<string> { customer.DeviceId };

            options.Contents.Add(LanguageCodes.English, $@"An error occured while provisioning 
                {customer.Subdomain}.{TenantConvention.GetDefaultTenantName()} for you on Freebe, 
                please contact support to investigate this. We apologize for this inconveniency.");
            options.Headings.Add(LanguageCodes.English, $"Freebe sub account provision error.");
            options.Data = new Dictionary<string, string>();
            options.Data.Add("type", "subdomainCreateNotification");
            options.Data.Add("customer", JsonConvert.SerializeObject(customer, Formatting.None));
            NotificationCreateResult response = client.Notifications.Create(options);
            return response.Recipients > 0;
        }
    }
}
