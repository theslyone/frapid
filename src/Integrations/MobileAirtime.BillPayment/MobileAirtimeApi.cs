using Frapid.RestApi;
using RestSharp;
using System.Collections.Generic;

namespace MobileAirtime.BillPayment
{
    public class MobileAirtimeApi : MobileAirtimeClient
    {
        
        public MobileAirtimeApi(string userId, string password) : this(userId, password, ClientMode.Test)
        {

        }

        public MobileAirtimeApi(string userId, string password, ClientMode mode) : base(mode)
        {
            UserId = userId;
            Password = password;       
        }        

        public dynamic CustomerInformation(string bill, string smartNo)
        {
            var request = new RestRequest();
            //request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.Resource = $"/blookup.php?userid={UserId}&pass={Password}&bill={bill}&smartno={smartNo}";         
            request.Method = Method.GET;

            return Execute<dynamic>(request).Data;
        }
    }
}
