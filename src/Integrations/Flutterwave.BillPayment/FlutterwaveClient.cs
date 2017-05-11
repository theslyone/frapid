using Flutterwave.BillPayment.Responses;
using Frapid.RestApi;
using Frapid.RestApi.Responses;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace Flutterwave.BillPayment
{
    public enum ClientMode { Test, Production}
    public abstract class FlutterwaveClient : RestApiClient
    {
        private const string TestUrl = "https://pwcstaging.herokuapp.com/";
        private const string ProductionUrl = "";

        protected static string ClientId { get; set; }
        protected static string ClientSecret { get; set; }


        public FlutterwaveClient(ClientMode mode = ClientMode.Test) : base(GetUrl(mode))
        {
            
        }

        private static string GetUrl(ClientMode mode)
        {
            if (mode == ClientMode.Production)
                return ProductionUrl;
            else if (mode == ClientMode.Test)
                return TestUrl;
            return "";
        }
        
        protected override string GetToken()
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
                var moneywaveException = new FlutterwaveException("Access token exception", response.ErrorException);
                throw moneywaveException;
            }

            return response.Data["access_token"];
        }

        protected new RestApiResponse<T> Execute<T>(RestRequest request) where T : class
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(BaseUrl);
            //request.Method = Method.POST;
            request.RequestFormat = DataFormat.Json;

            request.AddHeader("Authorization", $"Bearer {GetToken()}");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Cache-Control", "no-cache");
            var response = client.Execute<RestApiResponse<dynamic>>(request);

            RestApiResponse<T> restApiResponse = ProcessResponse<T>(response);
            return restApiResponse;
        }

        protected override RestApiResponse<T> ProcessResponse<T>(IRestResponse<RestApiResponse<dynamic>> response)
        {
            if (response.ErrorException != null || response.Data.Status != "success"/*Status.Success*/)
            {
                string message = "Error processing request";/*response.Data != null
                   ? response.Data.Data ? response.Data.Data["error_description"] != null
                   : "Bill payment exception"
                   : "Bill payment exception";*/
                var billPaymentException = new RestApiException(message, response.ErrorException);
                throw billPaymentException;
            }
            RestApiResponse<T> RestApiResponse = JsonConvert.DeserializeObject<RestApiResponse<T>>(response.Content);
            return RestApiResponse;
        }
    }
}
