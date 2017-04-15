using Frapid.RestApi;
using Frapid.RestApi.Responses;
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
    public class MoneywaveClient : RestApiClient
    {
        private const string TestUrl = "https://moneywave.herokuapp.com/";
        private const string ProductionUrl = "https://live.moneywaveapi.co";
        
        public MoneywaveClient(ClientMode mode = ClientMode.Test) : base(GetUrl(mode))
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

        protected static string ApiKey { get; set; }
        protected static string Secret { get; set; }
        public string WalletLock { get; set; }

        protected string GetToken()
        {
            //[POST] /v1/merchant/verify
            var request = new RestRequest();
            request.AddHeader("content-type", "application/json");
            request.Resource = "v1/merchant/verify";
            request.AddParameter("apiKey", ApiKey);
            request.AddParameter("secret", Secret);


            var client = new RestClient();
            client.BaseUrl = new Uri(BaseUrl);
            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<dynamic>(request);
            if (response.ErrorException != null)
            {
                var moneywaveException = new RestApiException("Access token exception", response.ErrorException);
                throw moneywaveException;
            }

            return response.Data["token"];
        }

        protected override RestApiResponse<T> ProcessResponse<T>(IRestResponse<RestApiResponse<dynamic>> response)
        {
            if (response.ErrorException != null || response.Data.Status != "success"/*Status.Success*/)
            {
                string message = response.Data != null
                    ? !string.IsNullOrEmpty(response.Data.Code) ? response.Data.Code
                    : !string.IsNullOrEmpty(response.Data.Data) ? response.Data.Data
                    : !string.IsNullOrEmpty(response.Data.Message) ? response.Data.Message
                    : "Freebe encountered an error while processing your request."
                    : "Freebe encountered an error while processing your request.";
                var moneywaveException = new MoneywaveException(message, response.ErrorException);
                throw moneywaveException;
            }
            MoneywaveResponse<T> moneywaveResponse = JsonConvert.DeserializeObject<MoneywaveResponse<T>>(response.Content);
            return moneywaveResponse;
        }
    }
}
