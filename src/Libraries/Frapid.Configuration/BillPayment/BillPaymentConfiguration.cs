using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frapid.Configuration.BillPayment
{
    public static class BillPaymentConfiguration
    {
        public static BillPaymentConfig GetConnectionParamaters()
        {
            string path = PathMapper.MapPath("/Resources/Configs/BillPaymentConfig.json");
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
    }

    public class BillPaymentParam
    {
        public string Url { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }

}
