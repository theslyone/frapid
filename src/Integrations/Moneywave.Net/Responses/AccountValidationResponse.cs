using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moneywave.Net.Responses
{
    public class AccountValidationResponse
    {
        [JsonProperty("account_name")]
        public string AccountName { get; set; } 
    }
}
