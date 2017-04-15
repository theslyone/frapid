using Flutterwave.BillPayment;
using Flutterwave.BillPayment.Models;
using Flutterwave.BillPayment.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.CSharp;
using Xunit;
using Moneywave.Net.Test.Models;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using Newtonsoft.Json.Converters;

namespace Moneywave.Net.Test
{
    public class BillPaymentFixture : IDisposable
    {
        public BillPaymentFixture()
        {
            Api = new FlutterwaveApi("57503cb75d1a5111002cfa5a", "Zs0PavPCFWPXZeHOA1ZgU92K6P3X3c1ogTye18RmvGJglwBsthcyW97rKxWHbFLJmJn9QWqA9sOg2HINR3uH9SgaI7dD04R3GaIk");
        }

        public void Dispose()
        {

        }

        public FlutterwaveApi Api { get; private set; }
    }

    public sealed class FlutterwaveApiTests : IClassFixture<BillPaymentFixture>
    {
        FlutterwaveApi Api;
        public FlutterwaveApiTests(BillPaymentFixture fixture)
        {
            this.Api = fixture.Api;
        }

        [Fact]
        public void GetMerchants()
        {
            var merchants = Api.GetMerchants();
            string merchantStr = JsonConvert.SerializeObject(merchants, Formatting.Indented);
            File.WriteAllText(@"C:\Users\mc\Documents\GitHub\Merchants.json", merchantStr);

            Assert.NotEmpty(merchants);
        }

        [Fact]
        public void GetProducts()
        {
            List<Product> products = new List<Product>();
            var merchants = Api.GetMerchants();
            foreach(var merchant in merchants)
            {
                products.AddRange(Api.GetProducts(merchant.Id));
            }
            string productsStr = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(@"C:\Users\mc\Documents\GitHub\Products.json", productsStr);

            Assert.NotEmpty(products);
        }

        [Fact]
        public void Pay()
        {
            Bill bill = new Bill() { Amount = 500, PhoneNumber = "2348064678376" };

            var merchant = Api.GetMerchants()[0];
            var products = Api.GetProducts(merchant.Id);
            PayRequest pay = new PayRequest();
            pay.ProductId = products[0].Id;

            string hookData = JsonConvert.SerializeObject(bill, Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            pay.HookData = JsonConvert.DeserializeObject<ExpandoObject>(hookData, new ExpandoObjectConverter());

            /*pay.HookData.amount = "500.00";
            pay.HookData.recipient_phone_number = "2348064678376";
            pay.HookData.phone = "2348064678376";
            pay.HookData.email = "theslyguy@icloud.com";
            pay.HookData.account_id = "2345678987654";
            */
            pay.Description = "test for bills payment - airtime purchase";
            pay.TransactionId = $"BILLS-{KeyGenerator.GetUniqueAlphaNumericCode(6)}";
            pay.Processor = "wallet";
            var response = Api.Pay(pay);
            Assert.True(response.Paid);
        }
    }
}
