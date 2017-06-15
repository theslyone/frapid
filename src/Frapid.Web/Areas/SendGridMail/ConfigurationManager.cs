﻿using System.IO;
using System.Text;
using Frapid.Configuration;
using Newtonsoft.Json;

namespace SendGridMail
{
    public sealed class ConfigurationManager
    {
        private const string ConfigFile = "/Tenants/{tenant}/Configs/SMTP/SendGrid.json";

        public static void Set(string tenant, Config config)
        {
            if (config == null)
            {
                return;
            }

            string path = ConfigFile.Replace("{tenant}", tenant);
            path = PathMapper.MapPath(path);

            if (!Storage.FileExists(path))
            {
                string directory = new FileInfo(path).Directory?.FullName;
                if (!string.IsNullOrWhiteSpace(directory))
                {
                    Storage.CreateDirectory(directory);
                }
            }

            string contents = JsonConvert.SerializeObject(config, Formatting.Indented);
            Storage.WriteAllText(path, contents, new UTF8Encoding(false));
        }

        public static Config Get(string tenant)
        {
            string path = ConfigFile.Replace("{tenant}", tenant);
            path = PathMapper.MapPath(path);

            if (path == null || !Storage.FileExists(path))
            {
                return new Config();
            }

            string contents =   Storage.ReadAllText(path, Encoding.UTF8);
            return string.IsNullOrWhiteSpace(contents) ? new Config() : JsonConvert.DeserializeObject<Config>(contents);
        }
    }
}