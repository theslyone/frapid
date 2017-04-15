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

        public dynamic Resolve(string bill, string smartNo)
        {
            var request = new RestRequest();
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.Resource = $"/blookup.php?userid={UserId}&pass={Password}&bill={bill}&smartno={smartNo}";         
            request.Method = Method.GET;

            return Execute<dynamic>(request).Data;
        }

        public dynamic TopUp(AirTimeCode network, string phoneNumber, decimal amount)
        {
            var request = new RestRequest();
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.Resource = $"/?userid={UserId}&pass={Password}&network={network}&phone={phoneNumber}&amt={amount}";
            request.Method = Method.GET;

            return Execute<dynamic>(request).Data;
        }

        public dynamic MtnData(AirTimeCode network, string phoneNumber, int dataSize)
        {
            var request = new RestRequest();
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.Resource = $"/datashare.php?userid={UserId}&pass={Password}&network={network}&phone={phoneNumber}&datasize={dataSize}";
            request.Method = Method.GET;

            return Execute<dynamic>(request).Data;
        }

        public dynamic Pay(string merchantName, string productId, string phoneNumber, string smartCardNumber, decimal amount)
        {
            var request = new RestRequest();
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            switch (merchantName.ToLower())
            {
                case "startimes":
                    request.Resource = $"/startimes.php?userid={UserId}&pass={Password}&phone={phoneNumber}&amt={amount}&smartno={smartCardNumber}";
                    break;
                case "dstv":
                    request.Resource = $"/startimes.php?userid={UserId}&pass={Password}&phone={phoneNumber}&amt={amount}&smartno={smartCardNumber}";
                    break;
                case "gotv":
                    request.Resource = $"/gotv.php?userid={UserId}&pass={Password}&phone={phoneNumber}&plan={productId}&smartno={smartCardNumber}";
                    break;
            }
            request.Method = Method.GET;

            return Execute<dynamic>(request).Data;
        }
    }
    
    public enum AirTimeCode
    {
        Airtel = 1, Etisalat = 2, Visaphone = 4, MTN = 15, Glo = 6
    }
}
