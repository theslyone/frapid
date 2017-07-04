using Flutterwave.BillPayment;
using Flutterwave.BillPayment.Models;
using Flutterwave.BillPayment.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.CSharp;
using Xunit;
using Integrations.Test.Models;
using System.Dynamic;
using Newtonsoft.Json.Converters;
using Bvn.Net;

namespace Integrations.Test
{
    public class BvnFixture : IDisposable
    {
        public BvnFixture()
        {
            Api = new BvnApi();
        }

        public void Dispose()
        {

        }

        public BvnApi Api { get; private set; }
    }

    public sealed class BvnApiTests : IClassFixture<BvnFixture>
    {
        BvnApi Api;
        public BvnApiTests(BvnFixture fixture)
        {
            this.Api = fixture.Api;
        }

        [Fact]
        public void Verify()
        {
            
            var response = Api.Verify("12345678901");
            Assert.NotNull(response.TransactionReference);

            response = Api.Verify("221869359924"); //invalid bvn
            Assert.Equal(response.TransactionReference, "");
        }

        [Fact]
        public void Validate()
        {
            string transactionReference = Api.Verify("12345678901").TransactionReference;
            var status = Api.Resend(transactionReference);
            var response = Api.Validate("22186935992", "12345", transactionReference);
            Assert.NotNull(response.TransactionReference);
        }
    }
}
