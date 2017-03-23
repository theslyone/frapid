using Moneywave.Net.Requests;
using Moneywave.Net.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneywave.Net
{
    public class Transactions : MoneywaveClient
    {
        public ChargeResponse GetCharge(ChargeRequest getChargeRequest)
        {
            //[POST] /v1/get-charge
            var request = new RestRequest();
            request.JsonSerializer = new RestSharpJsonNetSerializer();
            request.Resource = "v1/get-charge";
            request.AddJsonBody(getChargeRequest);
            return Execute<ChargeResponse>(request).Data;

        }

        public Transfer Get(string id)
        {
            //[POST] /v1/transfer/:id
            var restRequest = new RestRequest();
            restRequest.Resource = "v1/transfer/{id}";
            restRequest.AddParameter("id", id, ParameterType.UrlSegment);
            return Execute<Transfer>(restRequest).Data;
        }

        public dynamic DisburseStatus(string id)
        {
            //[POST] /v1/disburse/status
            var restRequest = new RestRequest();
            restRequest.Resource = "v1/disburse/status";
            restRequest.AddParameter("ref", id);
            return Execute<dynamic>(restRequest).Data;
        }

        public TransferResponse Transfer(TransferRequest transferRequest)
        {
            //[POST] /v1/transfer
            transferRequest.ApiKey = ApiKey;
            transferRequest.SenderBank = transferRequest.SenderBank?.PadLeft(3, '0');
            transferRequest.RecipientBank = transferRequest.RecipientBank?.PadLeft(3, '0');
            var request = new RestRequest();
            request.JsonSerializer = new RestSharpJsonNetSerializer();

            request.Resource = "v1/transfer";
            request.AddJsonBody(transferRequest);
            var response = Execute<TransferResponse>(request).Data;
            if (!response.PendingValidation)
            {
                response.Transfer = Get(response.Id);
            }
            return response;
        }

        public DisburseResponse Disburse(DisburseRequest disburseRequest)
        {
            //[POST] /v1/disburse
            var request = new RestRequest();
            request.JsonSerializer = new RestSharpJsonNetSerializer();

            request.Resource = "v1/disburse";
            request.AddJsonBody(disburseRequest);
            return Execute<DisburseResponse>(request).Data;
        }

        public Transfer ValidateTransfer(ChargeType type, string transRef, string authValue, AuthType authType = AuthType.OTP)
        {
            //[GET]/v1/transfer/charge/auth/account
            //[GET]/v1/transfer/charge/auth/card
            var request = new RestRequest();
            request.Resource = $"v1/transfer/charge/auth/{type.ToString().ToLowerInvariant()}";
            request.AddParameter("transactionRef", transRef);
            //used for account validation
            request.AddParameter("authType", Enum.GetName(typeof(AuthType), authType));
            request.AddParameter("authValue", authValue);
            //used for card validation
            request.AddParameter("otp", authValue);
            return Execute<Transfer>(request).Data;

        }


        public dynamic RetryDisburse(string id, string recipientAccountNumber, string recipientBank)
        {
            //[POST] /v1/transfer/disburse/retry
            var restRequest = new RestRequest();
            restRequest.Resource = "v1/transfer/disburse/retry";
            restRequest.AddParameter("id", id);
            restRequest.AddParameter("recipient_account_number", recipientAccountNumber);
            restRequest.AddParameter("recipient_bank", recipientBank);
            return Execute<dynamic>(restRequest).Data;
        }

        public enum AuthType { OTP, ACCOUNT_CREDIT }
    }
}
