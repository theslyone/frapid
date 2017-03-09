using Moneywave.Net.Responses;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneywave.Net
{
    public enum ClientMode { Test, Production}
    public class MoneywaveClient
    {
        private string TestUrl => "https://moneywave.herokuapp.com/";
        private string ProductionUrl => "https://live.moneywaveapi.co";

        public string BaseUrl = "";

        public MoneywaveClient(ClientMode mode = ClientMode.Test)
        {
            if (mode == ClientMode.Production)
                BaseUrl = ProductionUrl;
            else if (mode == ClientMode.Test)
                BaseUrl = TestUrl;
        }
        
        protected static string ApiKey { get; set; }
        protected static string Secret { get; set; }
        protected static string Token { get; set; }

        protected string GetToken()
        {
            //[POST] /v1/merchant/verify
            var request = new RestRequest();
            request.Resource = "v1/merchant/verify";
            request.AddParameter("apiKey", ApiKey);
            request.AddParameter("secret", Secret);

            return Execute<dynamic>(request).Token;
        }

        protected MoneywaveResponse<T> Execute<T>(RestRequest request) where T : class
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(BaseUrl);
            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Json;

            request.AddHeader("Authorization", Token);
            request.AddHeader("content-type", "application/json");
            var response = client.Execute<MoneywaveResponse<dynamic>>(request);
            
            if (response.ErrorException != null || response.Data.Status != Status.Success)
            {
                string message = response.Data != null 
                    ? !string.IsNullOrEmpty(response.Data.Code) ? response.Data.Code
                    : !string.IsNullOrEmpty(response.Data.Data) ? response.Data.Data
                    : !string.IsNullOrEmpty(response.Data.Message) ? response.Data.Message 
                    : "Freebe encountered an error while processing your request. It is very likely that your account has been charged, please do not try again"
                    : "Freebe encountered an error while processing your request. It is very likely that your account has been charged, please do not try again";
                var moneywaveException = new MoneywaveException(message, response.ErrorException);
                throw moneywaveException;
            }
            MoneywaveResponse<T> moneywaveResponse = JsonConvert.DeserializeObject<MoneywaveResponse<T>>(response.Content);         
            return moneywaveResponse;
        }
    }
}
