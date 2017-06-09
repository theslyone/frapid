using System.IO;
using System.Linq;
using System.Net;
using System.Web.Hosting;
using System.Web.Mvc;
using Frapid.Areas;
using Frapid.Areas.Authorization;
using Frapid.Areas.CSRF;
using Frapid.Configuration;

namespace Frapid.Dashboard.Controllers
{
    [AntiForgery]
    public class ThemeController: FrapidController
    {
        [RestrictAnonymous]
        [Route("dashboard/my/themes")]
        public ActionResult GetThemes()
        {
            string path = $"~/Tenants/{this.Tenant}/Areas/Frapid.Dashboard/Themes";
            path = Storage.MapPath(path);

            if(path == null ||
               !Storage.DirectoryExists(path))
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var templates = Storage.GetDirectories(path);

            return this.Ok(templates);
        }

        [RestrictAnonymous]
        [Route("dashboard/my/themes/set-default/{themeName}")]
        [HttpPost]
        public ActionResult SetAsDefault(string themeName)
        {
            if(string.IsNullOrEmpty(themeName))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string path = $"~/Tenants/{this.Tenant}/Areas/Frapid.Dashboard/Themes/{themeName}";
            path = Storage.MapPath(path);

            if(path == null ||
               !Storage.DirectoryExists(path))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            path = $"~/Tenants/{this.Tenant}/Areas/Frapid.Dashboard/Dashboard.config";
            path = Storage.MapPath(path);

            if(path == null || !Storage.FileExists(path))
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }


            ConfigurationManager.SetConfigurationValue(path, "DefaultTheme", themeName);
            return this.Ok();
        }
    }
}