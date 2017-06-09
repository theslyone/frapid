using System.Globalization;
using System.IO;
using System.Web.Hosting;
using Frapid.Configuration;
using static System.String;

namespace Frapid.Dashboard
{
    public class Configuration
    {
        private const string Path = "~/Tenants/{0}/Areas/Frapid.Dashboard/";
        private const string ConfigFile = "Dashboard.config";
        private const string DefaultThemeKey = "DefaultTheme";

        public static string GetCurrentThemePath(string tenant)
        {
            string path = Path + "Themes/{1}/";
            string theme = GetDefaultTheme(tenant);

            return Format(CultureInfo.InvariantCulture, path, tenant, theme);
        }

        public static string GetDashboardPath(string tenant)
        {
            return Storage.MapPath(Format(CultureInfo.InvariantCulture, Path, tenant));
        }
    
        public static string GetDefaultTheme(string tenant)
        {
            return Get(tenant, DefaultThemeKey);
        }

        public static string Get(string tenant, string key)
        {
            string path = GetDashboardPath(tenant) + "/" + ConfigFile;
            return ConfigurationManager.ReadConfigurationValue(path, key);
        }
    }
}