using Flutterwave.BillPayment.Models;
using Flutterwave.BillPayment.Requests;
using Flutterwave.BillPayment.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutterwave.BillPayment
{
    public class BillPaymentApi : BillPaymentClient
    {
        public BillPaymentApi(string clientId, string clientSecret) : this(clientId, clientSecret, ClientMode.Test)
        {

        }

        public BillPaymentApi(string clientId, string clientSecret, ClientMode mode) : base(mode)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Token = GetToken();           
        }


        public List<Merchant> GetMerchants()
        {
            var request = new RestRequest();
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.Resource = "user/billers";
            request.Method = Method.GET;

            return Execute<List<Merchant>>(request).Data;
        }
        
        public List<Product> GetProducts(string merchantId)
        {
            var request = new RestRequest();
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.Resource = $"user/{merchantId}/products";
            request.Method = Method.GET;

            return Execute<List<Product>>(request).Data;
        }

        public PayResponse Pay(string merchantId, PayRequest payRequest)
        {
            var request = new RestRequest();
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.Resource = $"orders/makeBillPayment";
            request.AddJsonBody(payRequest);            
            request.Method = Method.POST;
            return Execute<PayResponse>(request).Data;
        }

        public dynamic Status(string transactionId)
        {
            var request = new RestRequest();
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.Resource = $"orders/transactions?transaction_id={transactionId}";         
            request.Method = Method.GET;

            return Execute<dynamic>(request).Data;
        }
    }
}
