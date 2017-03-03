using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Moneywave.Net.Requests
{
    public class TransferRequest
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }

        [JsonProperty("card_no")]
        public string CardNumber { get; set; }

        [JsonProperty("card_token")]
        public string CardToken { get; set; }

        [JsonProperty("charge_with")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ChargeType ChargeWith { get; set; }

        [JsonProperty("cvv")]
        public string Cvv { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("expiry_month")]
        public string ExpiryMonth { get; set; }

        [JsonProperty("expiry_year")]
        public string ExpiryYear { get; set; }

        [JsonProperty("fee")]
        public double Fee { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("passcode")]
        public string Passcode { get; set; }

        [JsonProperty("phonenumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("recipient")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RecipientType Recipient { get; set; }

        [JsonProperty("recipient_account_number")]
        public string RecipientAccountNumber { get; set; }

        [JsonProperty("recipient_bank")]
        public string RecipientBank { get; set; }

        [JsonProperty("redirecturl")]
        public string RedirectUrl { get; set; }

        [JsonProperty("sender_account_number")]
        public string SenderAccountNumber { get; set; }

        [JsonProperty("sender_bank")]
        public string SenderBank { get; set; }
    }

    public enum ChargeType {
        [EnumMember(Value = "card")]
        Card,
        [EnumMember(Value = "account")]
        Account,
        [EnumMember(Value = "token")]
        Token,
        [EnumMember(Value = "tokenized_card")]
        TokenizedCard
    }

    public enum RecipientType
    {
        [EnumMember(Value = "wallet")]
        Wallet,
        [EnumMember(Value = "account")]
        Account,
        [EnumMember(Value = "beneficiary")]
        Beneficiary,
        [EnumMember(Value = "bulk-account")]
        BulkAccount
    }
}
