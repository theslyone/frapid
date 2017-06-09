using System.IO;
using System.Text;
using System.Web.Hosting;
using Newtonsoft.Json;
using Frapid.Configuration;

namespace Frapid.Messaging
{
    public sealed class MessagingConfig
    {
        public bool TestMode { get; set; }

        public static MessagingConfig Get(string tenant)
        {
            string path = $"/Tenants/{tenant}/Configs/Smtp.json";
            path = Storage.MapPath(path);

            if (path != null &&
                Storage.FileExists(path))
            {
                string contents = Storage.ReadAllText(path, Encoding.UTF8);
                return JsonConvert.DeserializeObject<MessagingConfig>(contents);
            }

            return new MessagingConfig();
        }
    }
}