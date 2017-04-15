using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frapid.Configuration.BillPayment
{
    public static class FlutterwaveBillPaymentConfiguration
    {
        public static BillPaymentConfig GetConnectionParamaters()
        {
            string path = PathMapper.MapPath("/Resources/Configs/FlutterwaveBillPaymentConfig.json");
            if (File.Exists(path))
            {
                string contents = File.ReadAllText(path, Encoding.UTF8);
                var config = JsonConvert.DeserializeObject<BillPaymentConfig>(contents);

                return config;
            }

            return null;
        }
    }

    public class BillPaymentConfig
    {
        public string Env { get; set; }
        public BillPaymentParam Test { get; set; }
        public BillPaymentParam Live { get; set; }
        public List<Merchant> Merchants { get; set; }
    }

    public class BillPaymentParam
    {
        public string Url { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }

    public class Merchant
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("products")]
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("productcode")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("sub_description")]
        public string SubDescription { get; set; }

        [JsonProperty("cost")]
        public decimal Cost { get; set; }

        [JsonProperty("hookdata")]
        public dynamic HookData { get; set; }

    }

}
