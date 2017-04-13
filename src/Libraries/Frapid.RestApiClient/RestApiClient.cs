using Frapid.RestApi.Responses;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace Frapid.RestApi
{
    public enum ClientMode { Test, Production }

    public abstract class RestApiClient
    {
        public string BaseUrl = "";
        protected static string Token { get; set; }

        public RestApiClient(string url)
        {
            BaseUrl = url;
        }

        protected RestApiResponse<T> Execute<T>(RestRequest request) where T : class
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(BaseUrl);
            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Json;

            request.AddHeader("Authorization", Token);
            request.AddHeader("content-type", "application/json");
            var response = client.Execute<RestApiResponse<dynamic>>(request);

            RestApiResponse<T> restApiResponse = ProcessResponse<T>(response);
            return restApiResponse;
        }

        protected Task<RestApiResponse<T>> ExecuteAync<T>(RestRequest request) where T : class
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(BaseUrl);
            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Json;

            request.AddHeader("Authorization", Token);
            request.AddHeader("content-type", "application/json");

            var taskCompletionSource = new TaskCompletionSource<RestApiResponse<T>>();

            client.ExecuteAsync<RestApiResponse<dynamic>>(request, (response) => {
                RestApiResponse<T> restApiResponse = ProcessResponse<T>(response);
                taskCompletionSource.SetResult(restApiResponse);
            });
            return taskCompletionSource.Task;
        }

        protected abstract RestApiResponse<T> ProcessResponse<T>(IRestResponse<RestApiResponse<dynamic>> response) where T : class;
    }
}
