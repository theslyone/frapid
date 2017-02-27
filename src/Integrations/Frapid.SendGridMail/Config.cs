using System.Globalization;
using System.IO;
using System.Text;
using System.Web.Hosting;
using Frapid.Messaging;
using Newtonsoft.Json;

namespace Frapid.SendGridMail
{
    public class Config : IEmailConfig
    {
        public string ApiUser { get; set; }
        public string ApiKey { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public bool Enabled { get; set; }

        public static Config Get(string tenant)
        {
            string path = "~/Tenants/{0}/Configs/SMTP/SendGrid.json";
            path = string.Format(CultureInfo.InvariantCulture, path, tenant);
            path = HostingEnvironment.MapPath(path);

            if (path == null ||
                !File.Exists(path))
            {
                return new Config();
            }

            string contents = File.ReadAllText(path, Encoding.UTF8);

            var config = JsonConvert.DeserializeObject<Config>(contents);
            return config;
        }
    }
}