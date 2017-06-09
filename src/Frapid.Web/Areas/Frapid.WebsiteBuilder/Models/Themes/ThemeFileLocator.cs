using Frapid.Configuration;
using System.Web.Hosting;

namespace Frapid.WebsiteBuilder.Models.Themes
{
    public sealed class ThemeFileLocator
    {
        public ThemeFileLocator(string themeName, string file)
        {
            this.ThemeName = themeName;
            this.File = file;
        }

        public string ThemeName { get; }
        public string File { get; }

        public string Locate(string tenant)
        {
            string path = $"~/Tenants/{tenant}/Areas/Frapid.WebsiteBuilder/Themes/{this.ThemeName}/{this.File}";
            path = Storage.MapPath(path);

            if (!Storage.FileExists(path))
            {
                throw new ThemeFileLocationException(Resources.CouldNotLocateRequestedFile);
            }

            return path;
        }
    }
}