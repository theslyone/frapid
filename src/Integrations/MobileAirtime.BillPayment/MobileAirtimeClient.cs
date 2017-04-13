using Newtonsoft.Json;
using System;
using Frapid.RestApi;
using Frapid.RestApi.Responses;
using RestSharp;

namespace MobileAirtime.BillPayment
{
    public enum ClientMode { Test, Production}
    public class MobileAirtimeClient : RestApiClient
    {
        private const string Url = "https://mobileairtimeng.com/httpapi";
        protected static string UserId { get; set; }
        protected static string Password { get; set; }


        public MobileAirtimeClient(ClientMode mode = ClientMode.Test) : base (Url)
        {
            
        }

        protected new RestApiResponse<T> Execute<T>(RestRequest request) where T : class
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(BaseUrl);
            //request.Method = Method.POST;
            //request.RequestFormat = DataFormat.Json;

            request.AddHeader("Authorization", Token);
            request.AddHeader("content-type", "text/html");
            var response = client.Execute<RestApiResponse<dynamic>>(request);

            RestApiResponse<T> restApiResponse = ProcessResponse<T>(response);
            return restApiResponse;
        }


        protected override RestApiResponse<T> ProcessResponse<T>(IRestResponse<RestApiResponse<dynamic>> response)
        {
            if (response.ErrorException != null || response.Data.Status != Status.Success)
            {
                string message = response.Data != null
                   ? !string.IsNullOrEmpty(response.Data.Data) ? response.Data.Data
                   : "Mobile airtime payment exception"
                   : "Mobile airtime payment exception";
                var billPaymentException = new RestApiException(message, response.ErrorException);
                throw billPaymentException;
            }
            RestApiResponse<T> RestApiResponse = JsonConvert.DeserializeObject<RestApiResponse<T>>(response.Content);
            return RestApiResponse;
        }
    }
}
