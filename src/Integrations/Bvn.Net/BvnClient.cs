using Frapid.RestApi;
using Frapid.RestApi.Responses;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace Bvn.Net
{
    public class BvnClient : RestApiClient
    {
        private const string TestUrl = "https://authbvn.herokuapp.com/authbvn/api/v1.0/";
        private const string ProductionUrl = "https://authbvn.herokuapp.com/authbvn/api/v1.0/";

        public BvnClient(ClientMode mode = ClientMode.Test) : base(GetUrl(mode))
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
            return "";
        }

        protected override RestApiResponse<T> ProcessResponse<T>(IRestResponse<RestApiResponse<dynamic>> response)
        {
            if(response.ErrorException != null || response.Data.Status != "success")
            {
                string message = "BVN verification exception";
                var bvnException = new BvnException(message, response.ErrorException);
                throw bvnException;
            }
            BvnResponse<T> bvnResponse = JsonConvert.DeserializeObject<BvnResponse<T>>(response.Content);
            return bvnResponse;
        }
    }
}
