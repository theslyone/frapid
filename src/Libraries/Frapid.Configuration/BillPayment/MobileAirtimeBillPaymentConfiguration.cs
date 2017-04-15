
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace Frapid.Configuration.BillPayment
{
    public static class MobileAirtimeBillPaymentConfiguration
    {
        public static BillPaymentConfig GetConnectionParamaters()
        {
            string path = PathMapper.MapPath("/Resources/Configs/MobileAirtimeBillPaymentConfig.json");
            if (File.Exists(path))
            {
                string contents = File.ReadAllText(path, Encoding.UTF8);
                var config = JsonConvert.DeserializeObject<BillPaymentConfig>(contents);

                return config;
            }

            return null;
        }
    }
}
