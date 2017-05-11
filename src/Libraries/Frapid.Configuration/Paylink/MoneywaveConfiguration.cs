using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frapid.Configuration.Paylink
{
    public static class MoneywaveConfiguration
    {
        public static MoneywaveConfig GetConnectionParamaters()
        {
            string path = PathMapper.MapPath("/Resources/Configs/MoneywaveConfig.json");
            if (File.Exists(path))
            {
                string contents = File.ReadAllText(path, Encoding.UTF8);
                var config = JsonConvert.DeserializeObject<MoneywaveConfig>(contents);

                return config;
            }

            return null;
        }
    }
}
