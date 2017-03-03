using Moneywave.Net.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneywave.Net
{
    public class Accounts : MoneywaveClient
    {
        public string Validate(string accountNumber, string bankCode)
        {
            //[POST] /v1/resolve/account
            var restRequest = new RestRequest();
            restRequest.Resource = "v1/resolve/account";
            restRequest.AddParameter("account_number", accountNumber);
            restRequest.AddParameter("bank_code", bankCode);
            var response = Execute<AccountValidationResponse>(restRequest);
            return response.Data.AccountName;
        }


    }
}
