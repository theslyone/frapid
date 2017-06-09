using Newtonsoft.Json;
using Frapid.RestApi.Responses;

namespace Bvn.Net
{
    public class BvnResponse<T> : RestApiResponse<T> where T : class
    {
    }

    public class VerificationResponse
    {
        [JsonProperty("transactionReference")]
        public string TransactionReference { get; set; }

        [JsonProperty("responseMessage")]
        public string ResponseMessage { get; set; }

        [JsonProperty("responseCode")]
        public string ResponseCode { get; set; }

    }

    public class ValidationResponse
    {
        [JsonProperty("transactionReference")]
        public string TransactionReference { get; set; }

        [JsonProperty("responseMessage")]
        public string ResponseMessage { get; set; }

        [JsonProperty("responseCode")]
        public string ResponseCode { get; set; }

    }
}
