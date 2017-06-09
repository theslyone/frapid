using MobileAirtime.BillPayment;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Integrations.Test
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
        public void ResolveCustomerInfo()
        {
            var customerInfo = Api.Resolve("dstv", "41192391344");
            //customerInfo = Api.CustomerInformation("dstv", "42909174908");
            Assert.NotNull(customerInfo);
        }

        [Fact]
        public void TopUp()
        {
            var topUpResponse = Api.TopUp(AirTimeCode.Airtel, "08030469664", 1);
            Assert.NotNull(topUpResponse);
        }

        [Fact]
        public void Pay()
        {
            var customerInfo = Api.Pay("dstv", "plan", "08030469664", "41192391344", 10);
            Assert.NotNull(customerInfo);
        }
    }
}
