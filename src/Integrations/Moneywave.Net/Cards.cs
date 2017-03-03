using Moneywave.Net.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneywave.Net
{
    public class Cards : MoneywaveClient
    {

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
