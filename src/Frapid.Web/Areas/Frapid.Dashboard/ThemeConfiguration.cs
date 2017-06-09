using System.IO;
using System.Web.Hosting;
using Frapid.Configuration;

namespace Frapid.Dashboard
{
    public class ThemeConfiguration
    {
        private const string LayoutFile = "LayoutFile";

        public static string GetLayout(string tenant, string theme)
        {
            return Get(tenant, theme, LayoutFile);
        }

        public static string Get(string tenant, string theme, string key)
        {
            string themePath = Configuration.GetCurrentThemePath(tenant);
            string path = themePath + "/Theme.config";
            path = Storage.MapPath(path);

            string value = !Storage.FileExists(path) ? string.Empty : ConfigurationManager.ReadConfigurationValue(path, key);
            if (!string.IsNullOrEmpty(value))
                Storage.GetLocalFilePath(Path.Combine(themePath, value));
            return value;
        }
    }
}