using Moneywave.Net.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Moneywave.Net.Transactions;

namespace Moneywave.Net.Responses
{
    public class TransferResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("transfer")]
        public Transfer Transfer { get; set; }

        [JsonProperty("pendingValidation")]
        public bool PendingValidation { get; set; }

        [JsonProperty("responsehtml")]
        public string ResponseHtml { get; set; }

        [JsonProperty("authurl")]
        public string AuthUrl { get; set; }

        [JsonProperty("authparams")]
        public List<AuthParameter> AuthParams { get; set; }
    }

    public class Transfer
    {
        [JsonProperty("amountToSend")]
        public decimal AmountToSend { get; set; }

        [JsonProperty("amountToCharge")]
        public decimal AmountToCharge { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("flutterChargeReference")]
        public string FlutterChargeReference { get; set; }

        [JsonProperty("flutterChargeResponseCode")]
        public string FlutterChargeResponseCode { get; set; }

        [JsonProperty("flutterChargeResponseMessage")]
        public string FlutterChargeResponseMessage { get; set; }

        
        
        [JsonProperty("flutterDisburseReference")]
        public string FlutterDisburseReference { get; set; }

        [JsonProperty("flutterDisburseResponseCode")]
        public string FlutterDisburseResponseCode { get; set; }

        [JsonProperty("flutterDisburseResponseMessage")]
        public string FlutterDisburseResponseMessage { get; set; }


        [JsonProperty("isCardValidationSuccessful")]
        public bool IsCardValidationSuccessful { get; set; }

        [JsonProperty("isDeliverySuccessful")]
        public bool IsDeliverySuccessful { get; set; }

        [JsonProperty("chargedFee")]
        public double Fee { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("account")]
        public Account Account { get; set; }

        [JsonProperty("beneficiary")]
        public Account Beneficiary { get; set; }
        
        [JsonProperty("merchantCommission")]
        public int MerchantCommission { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }

    public class AuthParameter
    {
        [JsonProperty("validateparameter")]
        public AuthType ValidateParameter { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
