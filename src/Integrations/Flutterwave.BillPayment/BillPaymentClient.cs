using Flutterwave.BillPayment.Responses;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace Flutterwave.BillPayment
{
    public enum ClientMode { Test, Production}
    public class BillPaymentClient
    {
        private string TestUrl => "https://pwcstaging.herokuapp.com/";
        private string ProductionUrl => "";

        public string BaseUrl = "";

        public BillPaymentClient(ClientMode mode = ClientMode.Test)
        {
            if (mode == ClientMode.Production)
                BaseUrl = ProductionUrl;
            else if (mode == ClientMode.Test)
                BaseUrl = TestUrl;
        }
        
        protected static string ClientId { get; set; }
        protected static string ClientSecret { get; set; }
        protected static string Token { get; set; }

        protected string GetToken()
        {
            var request = new RestRequest();
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.Resource = "oauth/token ";
            request.AddParameter("client_id", ClientId);
            request.AddParameter("client_secret", ClientSecret);
            request.AddParameter("grant_type", "client_credentials");

            var client = new RestClient();
            client.BaseUrl = new Uri(BaseUrl);
            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<dynamic>(request);
            if (response.ErrorException != null)
            {
                var moneywaveException = new BillPaymentException("Access token exception", response.ErrorException);
                throw moneywaveException;
            }

            return response.Data["access_token"];
        }

        protected BillPaymentResponse<T> Execute<T>(RestRequest request) where T : class
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(BaseUrl);
            request.RequestFormat = DataFormat.Json;

            request.AddHeader("Authorization", $"Bearer {Token}");
            request.AddHeader("content-type", "application/json");
            var response = client.Execute<BillPaymentResponse<dynamic>>(request);
            
            if (response.ErrorException != null || response.Data.Status != "success"/*response.Data.Status != Status.Success*/)
            {
                string message = response.Data != null 
                    ? !string.IsNullOrEmpty(response.Data.Data) ? response.Data.Data
                    : "Bill payment exception"
                    : "Bill payment exception";
                var billPaymentException = new BillPaymentException(message, response.ErrorException);
                throw billPaymentException;
            }
            BillPaymentResponse<T> billPaymentResponse = JsonConvert.DeserializeObject<BillPaymentResponse<T>>(response.Content);         
            return billPaymentResponse;
        }
    }
}
