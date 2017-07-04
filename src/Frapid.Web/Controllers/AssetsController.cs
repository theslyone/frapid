using System;
using System.Web.Mvc;
using System.Web.UI;
using Frapid.Areas;
using Frapid.Areas.Caching;
using Frapid.AssetBundling;
using Frapid.Configuration;
using Frapid.Framework.Extensions;
using Frapid.Framework.StaticContent;
using Serilog;
using System.IO;
using System.Text;
using System.Web;

namespace Frapid.Web.Controllers
{
    //[Route("assets")]
    public sealed class AssetsController : BaseController
    {
        private bool IsDevelopment()
        {
            string value = ConfigurationManager.GetConfigurationValue("ParameterConfigFileLocation", "IsDevelopment");
            return value.Or("").ToUpperInvariant().StartsWith("T");
        }


        private Bundler GetStyleBundler(Asset asset)
        {
            if (this.IsDevelopment())
            {
                return new DevelopmentStyleBundler(Log.Logger, asset);
            }

            return new ProductionStyleBundler(Log.Logger, asset);
        }

        private Bundler GetScriptBundler(Asset asset)
        {
            if (this.IsDevelopment())
            {
                return new DevelopmentScriptBundler(Log.Logger, asset);
            }

            return new ProductionScriptBundler(Log.Logger, asset);
        }        

        [Route("assets/js/{*name}")]
        [FileOutputCache(ProfileName = "StaticFile.xml", Duration = 60 * 60, Location = OutputCacheLocation.Client)]
        public ActionResult Js(string name)
        {
            var asset = AssetDiscovery.FindByName(name);

            if (asset == null)
            {
                return this.HttpNotFound();
            }


            var compressor = this.GetScriptBundler(asset);
            string contents = compressor.Compress();

            this.Response.Cache.SetMaxAge(TimeSpan.FromMinutes(asset.CacheDurationInMinutes));
            return this.Content(contents, "text/javascript");
        }

        [Route("assets/css/{*name}")]
        [FileOutputCache(ProfileName = "StaticFile.xml", Duration = 60 * 60, Location = OutputCacheLocation.Client)]
        public ActionResult Css(string name)
        {
            var asset = AssetDiscovery.FindByName(name);

            var compressor = this.GetStyleBundler(asset);
            string contents = compressor.Compress();

            this.Response.Cache.SetMaxAge(TimeSpan.FromMinutes(asset.CacheDurationInMinutes));
            return this.Content(contents, "text/css");
        }

        [Route("assets/scripts/{*name}")]
        //[Route("~/scripts/{*name}")]
        [FileOutputCache(ProfileName = "StaticFile.xml", Duration = 60 * 60, Location = OutputCacheLocation.Client)]
        public ActionResult Scripts(string name)
        {
            string scriptsDirectory = PathMapper.MapPath(Configs.ScriptsDirectory);
            string path = Path.Combine(scriptsDirectory, name);

            if (!Storage.FileExists(path))
            {
                return this.HttpNotFound();
            }

            string contents = Storage.ReadAllText(path, Encoding.UTF8);

            Response.Cache.SetMaxAge(TimeSpan.FromMinutes(10080));
            string mimeType = this.GetMimeType(path);

            return Content(contents, mimeType);
        }

        [Route("assets/Areas/{*name}")]
        //[Route("~/Areas/{*name}")]
        [FileOutputCache(ProfileName = "StaticFile.xml", Duration = 60 * 60, Location = OutputCacheLocation.Client)]
        public ActionResult Areas(string name)
        {
            string areasDirectory = PathMapper.MapPath(Configs.AreasDirectory);
            string path = Path.Combine(areasDirectory, name);

            if (!Storage.FileExists(path))
            {
                return this.HttpNotFound();
            }

            string contents = Storage.ReadAllText(path, Encoding.UTF8);

            this.Response.Cache.SetMaxAge(TimeSpan.FromMinutes(10080));
            return this.Content(contents, this.GetMimeType(path));
        }

        private string GetMimeType(string fileName)
        {
            return MimeMapping.GetMimeMapping(fileName);
        }
    }
}