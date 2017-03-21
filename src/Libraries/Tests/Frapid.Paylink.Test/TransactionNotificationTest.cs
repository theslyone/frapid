using System;
using Frapid.Paylink.DTO;
using Frapid.Events;
using Xunit;

namespace Frapid.Paylink.Test
{
    public class TransactionNotificationTest
    {
        [Fact]
        public void SendNotification()
        {
            Customer fromCustomer = new Customer();
            fromCustomer.LastName = "Okonkwo";
            fromCustomer.CreatedAt = DateTime.Now;
            fromCustomer.CustomerCode = "CUST_2345TGIFVM";
            fromCustomer.CustomerId = 1;
            fromCustomer.DeviceId = "177ad012-6f64-4213-98e0-1b6eb9d87dea";
            fromCustomer.Email = "thelslyguy@icloud.com";
            fromCustomer.FirstName = "Sylvester";
            fromCustomer.Phone = "+2340803456754";


            Customer toCustomer = new Customer();
            toCustomer.LastName = "Unegbu";
            toCustomer.CreatedAt = DateTime.Now;
            toCustomer.CustomerCode = "CUST_25TGIFVddM";
            toCustomer.CustomerId = 2;
            toCustomer.DeviceId = "92b4d57e-d0b1-40bb-a62d-a1d1f822d581";
            toCustomer.Email = "donuzo84@yahoo.co.uk";
            toCustomer.FirstName = "Uzochukwu";
            toCustomer.Phone = "+2340803456754";
            
            TransactionEvent transactionEvent = new TransactionEvent();
            transactionEvent.FromCustomer = new Events.Models.User();
            transactionEvent.FromCustomer.Id = fromCustomer.CustomerId.ToString();
            transactionEvent.FromCustomer.Email = fromCustomer.Email;
            transactionEvent.FromCustomer.Name = $"{fromCustomer.LastName} {fromCustomer.FirstName}";
            transactionEvent.FromCustomer.FirstName = fromCustomer.FirstName;
            transactionEvent.FromCustomer.LastName = fromCustomer.LastName;
            transactionEvent.FromSubaccountId = 5;
            transactionEvent.FromCustomer.DeviceId = fromCustomer.DeviceId;

            transactionEvent.ToCustomer = new Events.Models.User();
            transactionEvent.ToCustomer.Id = toCustomer.CustomerId.ToString();
            transactionEvent.ToCustomer.Email = toCustomer.Email;
            transactionEvent.ToCustomer.Name = $"{toCustomer.LastName} {toCustomer.FirstName}";
            transactionEvent.ToCustomer.FirstName = toCustomer.FirstName;
            transactionEvent.ToCustomer.LastName = toCustomer.LastName;
            transactionEvent.ToSubaccountId = 6;
            transactionEvent.ToCustomer.DeviceId = toCustomer.DeviceId;

            transactionEvent.Reference = "MWV-1489567229576";

            transactionEvent.CreationDate = DateTime.Now;
            transactionEvent.TransactionDate = DateTime.Now;
            transactionEvent.Amount = 1200;
            transactionEvent.Tenant = "sqlserver.localhost";
           
            bool result = Notification.PushTransactionComplete(transactionEvent);
            Assert.True(result);
        }
    }
}
