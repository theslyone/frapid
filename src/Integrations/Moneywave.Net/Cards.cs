using Frapid.RestApi;
using Moneywave.Net.Models;
using RestSharp;

namespace Moneywave.Net
{
    public class Cards : MoneywaveClient
    {
        public CardDetail Validate(string cardNumber)
        {
            //[POST] /v1/user/card/check
            var request = new RestRequest();
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.Resource = "v1/user/card/check";
            request.AddJsonBody(new { cardNumber = cardNumber });
            return Execute<CardDetail>(request).Data;
        }

        public string Tokenize(Card card)
        {
            //[POST] /v1/transfer/charge/tokenize/card
            var request = new RestRequest();
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.Resource = "v1/transfer/charge/tokenize/card";
            request.AddJsonBody(card);
            return Execute<dynamic>(request).Data["cardToken"];
        }

    }
}
