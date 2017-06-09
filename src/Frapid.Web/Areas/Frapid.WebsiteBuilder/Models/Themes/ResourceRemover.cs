using Frapid.Configuration;
using System.IO;
using System.Web.Hosting;

namespace Frapid.WebsiteBuilder.Models.Themes
{
    public sealed class ResourceRemover
    {
        public ResourceRemover(string themeName, string resource)
        {
            this.ThemeName = themeName;
            this.Resource = resource;
        }

        public string ThemeName { get; }
        public string Resource { get; }

        public void Delete(string tenant)
        {
            string path = $"~/Tenants/{tenant}/Areas/Frapid.WebsiteBuilder/Themes/{this.ThemeName}";
            path = Storage.MapPath(path);

            if (path == null)
            {
                throw new ResourceRemoveException(Resources.PathToFileOrDirectoryInvalid);
            }

            path = Path.Combine(path, this.Resource);

            if (Storage.DirectoryExists(path))
            {
                Storage.DeleteDirectory(path, true);
                return;
            }

            if (Storage.FileExists(path))
            {
                Storage.DeleteFile(path);
                return;
            }

            throw new ResourceRemoveException(Resources.FileOrDirectoryNotFound);
        }
    }
}