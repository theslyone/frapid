using Moneywave.Net.Models;
using Moneywave.Net.Requests;
using Moneywave.Net.Responses;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneywave.Net
{
    public class MoneywaveApi : MoneywaveClient
    {
        
        public MoneywaveApi(string apiKey, string secret)
        {
            ApiKey = apiKey;
            Secret = secret;
            Token = GetToken();

            Transactions = new Transactions();
            Cards = new Cards();
            Accounts = new Accounts();
        }        

        public List<Bank> GetBanks()
        {
            //[POST] /banks
            var request = new RestRequest();
            request.Resource = "banks";
            
            var response = Execute<Dictionary<int, string>>(request);
            
            List<Bank> banks = new List<Bank>();
            foreach (var kvp in response.Data)
            {
                banks.Add(new Bank { Code = kvp.Key.ToString(), Name = kvp.Value });
            }
            return banks;
        }

        public Transactions Transactions { get; }
        public Cards Cards { get; }
        public Accounts Accounts { get; }   
    }
}
