using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Frapid.Configuration
{
    public static class RedisConnectionString
    {
        public static string GetConnectionString()
        {
            string path = PathMapper.MapPath("/Resources/Configs/RedisConfig.json");
            if (Storage.FileExists(path))
            {
                string contents = Storage.ReadAllText(path, Encoding.UTF8);
                var config = JsonConvert.DeserializeObject<RedisConfig>(contents);

                return config.ConfigString;
            }

            return string.Empty;
        }
    }
}