using Moneywave.Net.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneywave.Net
{
    public class MoneywaveClient
    {
        private string BaseUrl => "https://moneywave.herokuapp.com/";
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

            var response = client.Execute<MoneywaveResponse<T>>(request);

            if (response.ErrorException != null || response.Data.Status != Status.Success)
            {
                string message = response.Data != null ? response.Data.Code || response.Data.Message : "Unknown exception";
                var moneywaveException = new MoneywaveException(message, response.ErrorException);
                throw moneywaveException;
            }
            return response.Data;
        }
    }
}
