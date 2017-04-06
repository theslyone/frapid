using Flutterwave.BillPayment;
using Flutterwave.BillPayment.Models;
using Flutterwave.BillPayment.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.CSharp;
using Xunit;

namespace Moneywave.Net.Test
{
    public class BillPaymentFixture : IDisposable
    {
        public BillPaymentFixture()
        {
            Api = new BillPaymentApi("57503cb75d1a5111002cfa5a", "Zs0PavPCFWPXZeHOA1ZgU92K6P3X3c1ogTye18RmvGJglwBsthcyW97rKxWHbFLJmJn9QWqA9sOg2HINR3uH9SgaI7dD04R3GaIk");
        }

        public void Dispose()
        {

        }

        public BillPaymentApi Api { get; private set; }
    }

    public sealed class BillPaymentApiTests : IClassFixture<BillPaymentFixture>
    {
        BillPaymentApi Api;
        public BillPaymentApiTests(BillPaymentFixture fixture)
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
            var merchant = Api.GetMerchants()[0];
            var products = Api.GetProducts(merchant.Id);
            PayRequest pay = new PayRequest();
            pay.ProductId = products[0].Id;

            pay.HookData.amount = "500.00";
            pay.HookData.recipient_phone_number = "2348064678376";
            /*pay.HookData.phone = "2348064678376";
            pay.HookData.email = "theslyguy@icloud.com";
            pay.HookData.account_id = "2345678987654";
            */
            pay.Description = "test for bills payment - airtime purchase";
            pay.TransactionId = "BILLS-01900";
            pay.Processor = "wallet";
            var response = Api.Pay(merchant.Id, pay);
            Assert.Equal(1, 1);
        }
    }
}
