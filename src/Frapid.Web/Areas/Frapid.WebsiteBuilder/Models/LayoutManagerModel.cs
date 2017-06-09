using Frapid.Configuration;
using System.IO;
using System.Text;

namespace Frapid.WebsiteBuilder.Models
{
    public static class LayoutManagerModel
    {
        public static bool SaveLayoutFile(string tenant, string theme, string fileName, string contents)
        {
            string path = Storage.MapPath(Configuration.GetThemeDirectory(tenant));

            if (path != null)
            {
                path += Path.Combine(path, theme);

                if (!Storage.DirectoryExists(path))
                {
                    return false;
                }

                path += Path.Combine(path, fileName);

                if (!Storage.FileExists(path))
                {
                    return false;
                }

                Storage.WriteAllText(path, contents, new UTF8Encoding(false));
            }

            return true;
        }
    }
}