using Frapid.RestApi;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bvn.Net
{
    public class BvnApi : BvnClient
    {
        public VerificationResponse Verify(string bvnNumber, string verifyUsing = "SMS", string country = "NGN")
        {
            var request = new RestRequest();
            request.Resource = "verify";
            
            request.JsonSerializer = new RestSharpJsonNetSerializer();

            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();

            request.AddParameter("bvn", bvnNumber);
            request.AddParameter("verifyUsing", verifyUsing);
            request.AddParameter("country", country);
            
            var response = Execute<VerificationResponse>(request);
            return response.Data;
        }

        public dynamic Resend(string transactionReference, string verifyUsing = "SMS", string country = "NGN")
        {
            var request = new RestRequest();
            request.Resource = "resendOtp";

            request.JsonSerializer = new RestSharpJsonNetSerializer();

            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();

            request.AddParameter("transactionReference", transactionReference);
            request.AddParameter("verifyUsing", verifyUsing);
            request.AddParameter("country", country);

            var response = Execute<dynamic>(request);
            return response.Data;
        }

        public ValidationResponse Validate(string bvn, string otp, string transactionReference, string country = "NGN")
        {
            var request = new RestRequest();
            request.Resource = "validate";
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.AddParameter("bvn", bvn);
            request.AddParameter("country", country);
            request.AddParameter("otp", otp);
            request.AddParameter("transactionReference", transactionReference);
            
            var response = Execute<ValidationResponse>(request);
            return response.Data;
        }
    }
}
