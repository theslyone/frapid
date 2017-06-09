using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Frapid.Areas;
using Frapid.Areas.Authorization;
using Frapid.Configuration;
using System.IO;

namespace Frapid.Dashboard.Controllers
{
    [RestrictAnonymous]
    public class BackgroundController : FrapidController
    {
        [Route("dashboard/backgrounds")]
        public ActionResult Get()
        {
            string resourceDirectory = Storage.MapPath("~/Tenants/{0}/Areas/Frapid.Dashboard/Resources", this.Tenant);
            string directory = "~/Tenants/{0}/Areas/Frapid.Dashboard/Resources/backgrounds";
            directory = Storage.MapPath(directory, this.Tenant);

            if (directory == null)
            {
                return this.HttpNotFound();
            }

            if (!Storage.DirectoryExists(directory))
            {
                return this.HttpNotFound();
            }

            var images = this.GetImages(directory, resourceDirectory);
            return this.Ok(images);
        }

        public static IEnumerable<T> Shuffle<T>(IEnumerable<T> source, Random generator = null)
        {
            if (generator == null)
            {
                generator = new Random();
            }

            var elements = source.ToArray();
            for (int i = elements.Length - 1; i >= 0; i--)
            {
                int swapIndex = generator.Next(i + 1);
                yield return elements[swapIndex];
                elements[swapIndex] = elements[i];
            }
        }

        public IEnumerable<string> GetImages(string path, string resourceDirectory)
        {
            var imageFormats = new[] {".jpg", ".jpeg", ".png", ".gif", ".tiff", ".bmp"};
            return Shuffle(Storage.GetFiles(path, imageFormats).Select(file => "/dashboard/resources/backgrounds/" + Path.GetFileName(file)));
        }
    }
}