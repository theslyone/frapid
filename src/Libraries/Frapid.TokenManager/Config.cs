using System.IO;
using System.Text;
using System.Web.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Frapid.Configuration;

namespace Frapid.TokenManager
{
    public static class Config
    {
        public static JObject Get()
        {
            string path = "~/Resources/Configs/JwtConfig.json";
            path = Storage.MapPath(path);

            if (string.IsNullOrWhiteSpace(path) ||
                !Storage.FileExists(path))
            {
                return new JObject();
            }

            string contents = Storage.ReadAllText(path, Encoding.UTF8);
            return JsonConvert.DeserializeObject<JObject>(contents);
        }
    }
}