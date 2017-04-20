using Newtonsoft.Json;
using System;
using Frapid.RestApi;
using Frapid.RestApi.Responses;
using RestSharp;
using RestSharp.Deserializers;
using Newtonsoft.Json.Linq;

namespace MobileAirtime.BillPayment
{
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
            //client.AddHandler("text/plain", new JsonDeserializer());
            request.RequestFormat = DataFormat.Json;
            request.OnBeforeDeserialization = resp => 
            {
                if (resp.ContentType.Equals("text/html"))
                {
                    JObject data = new JObject();
                    //resp.Content = 
                    resp.ContentType = "application/json";
                }                
            };
            
            request.AddHeader("Authorization", Token);
            request.AddHeader("content-type", "application/json");
            var response = client.Execute<RestApiResponse<dynamic>>(request);

            RestApiResponse<T> restApiResponse = ProcessResponse<T>(response);
            return restApiResponse;
        }


        protected override RestApiResponse<T> ProcessResponse<T>(IRestResponse<RestApiResponse<dynamic>> response)
        {
            if (response.ErrorException != null || response.Data.Status != "success"/*Status.Success*/)
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

        protected override string GetToken()
        {
            return "";
        }
    }
}
