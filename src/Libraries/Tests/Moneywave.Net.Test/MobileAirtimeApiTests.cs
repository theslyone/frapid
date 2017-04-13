using MobileAirtime.BillPayment;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Moneywave.Net.Test
{
    public class MobileAirtimeFixture : IDisposable
    {
        public MobileAirtimeFixture()
        {
            Api = new MobileAirtimeApi("08036382343", "0b37d0e2f6426c3a4fc0");
        }

        public void Dispose()
        {

        }

        public MobileAirtimeApi Api { get; private set; }
    }

    public sealed class MobileAirtimeApiTests : IClassFixture<MobileAirtimeFixture>
    {
        MobileAirtimeApi Api;
        public MobileAirtimeApiTests(MobileAirtimeFixture fixture)
        {
            this.Api = fixture.Api;
        }

        [Fact]
        public void GetCustomerInformation()
        {
            var customerInfo = Api.CustomerInformation("startimes", "42909174908");
            //customerInfo = Api.CustomerInformation("startimes", "41192391344");
            Assert.NotNull(customerInfo);
        }
    }
}
