using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Frapid.Configuration;
using Frapid.i18n;
using Serilog;

namespace Frapid.Areas.Conventions.Attachments
{
    public class Uploader
    {
        public Uploader(ILogger logger, AreaRegistration area, HttpFileCollectionBase files, string tenant, string[] allowedExtensions)
        {
            this.Logger = logger;
            this.Area = area;
            this.Files = files;
            this.Tenant = tenant;
            this.AllowedExtensions = allowedExtensions;
        }

        public ILogger Logger { get; }
        public AreaRegistration Area { get; }
        public HttpFileCollectionBase Files { get; }
        public string Tenant { get; }
        public string[] AllowedExtensions { get; }

        public string Upload()
        {
            if (this.Files.Count > 1)
            {
                throw new UploadException(Resources.OnlyASingleFileMayBeUploaded);
            }

            var file = this.Files[0];

            if (file == null)
            {
                throw new UploadException(Resources.NoFileWasUploaded);
            }

            string path = PathMapper.MapPath($"/Tenants/{this.Tenant}/Areas/{this.Area.AreaName}/attachments/");

            if (path == null)
            {
                this.Logger.Warning("The attachment directory could not be located.");
            }

            if (!Directory.Exists(path))
            {
                this.Logger.Warning("The attachment directory \"{path}\" does not exist.", path);

                if (path != null)
                {
                    Directory.CreateDirectory(path);
                }
            }

            string fileName = Path.GetFileName(file.FileName);

            if (fileName == null)
            {
                this.Logger.Verbose("Could not upload resource because the posted attachment file name is null or invalid.");
                throw new UploadException("Invalid data.");
            }

            string extension = Path.GetExtension(fileName);

            if (!this.AllowedExtensions.Contains(extension))
            {
                this.Logger.Warning("Could not upload avatar resource because the uploaded file {file} has invalid extension.",
                    fileName);
                throw new UploadException("Invalid data.");
            }

            var stream = file.InputStream;

            fileName = Guid.NewGuid() + extension;

            if (path == null)
            {
                return fileName;
            }

            path = Path.Combine(path, fileName);

            using (var fileStream = File.Create(path))
            {
                stream.CopyTo(fileStream);
            }

            return fileName;
        }
    }
}