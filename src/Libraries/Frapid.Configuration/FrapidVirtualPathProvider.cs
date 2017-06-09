using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace Frapid.Configuration
{
    public class FrapidVirtualPathProvider : VirtualPathProvider
    {
        private static List<string> filters = new List<string>()
        {
            PathFormatter("Tenants")
        };

        public static string PathFormatter(string viewName)
        {
            return string.Format(@"/Views/Shared/{0}.cshtml", viewName);
        }

        public override bool DirectoryExists(string virtualDir)
        {
            return base.DirectoryExists(virtualDir) || Storage.DirectoryExists(virtualDir);
        }

        public override VirtualDirectory GetDirectory(string virtualDir)
        {
            if (Storage.DirectoryExists(virtualDir))
            {               
                return new FrapidVirtualDirectory(virtualDir);
            }

            return base.GetDirectory(virtualDir);
        }

        public override bool FileExists(string virtualPath)
        {
            return base.FileExists(virtualPath) || Storage.FileExists(virtualPath);
        }

        public override VirtualFile GetFile(string virtualPath)
        {
            if (Storage.FileExists(virtualPath))
            {
                var view = Storage.ReadAllText(virtualPath, Encoding.UTF8);
                byte[] content = Encoding.ASCII.GetBytes(view);
                return new FrapidVirtualFile(virtualPath, content);
            }

            return base.GetFile(virtualPath);
        }

        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            return Storage.FileExists(virtualPath)
                ? null
                : base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
        }
    }

    public class FrapidVirtualFile : VirtualFile
    {
        private byte[] viewContent;

        public FrapidVirtualFile(string virtualPath, byte[] viewContent) : base(virtualPath)
        {
            this.viewContent = viewContent;
        }

        public override Stream Open()
        {
            return new MemoryStream(viewContent);
        }
    }

    public class FrapidVirtualDirectory : VirtualDirectory
    {
        private string virtualDirectory;

        public FrapidVirtualDirectory(string virtualDirectory) : base(virtualDirectory)
        {
            this.virtualDirectory = virtualDirectory;
        }

        public override IEnumerable Children
        {
            get
            {
                return new List<string>();
            }
        }

        public override IEnumerable Directories
        {
            get
            {
                return Storage.GetDirectories(virtualDirectory).ToArray().AsEnumerable();
            }
        }

        public override IEnumerable Files
        {
            get
            {
                return Storage.GetFiles(virtualDirectory, "*").ToArray().AsEnumerable();
            }
        }        
    }
}
