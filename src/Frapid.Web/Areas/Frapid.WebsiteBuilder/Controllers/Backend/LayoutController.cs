using System.Net;
using System.Web.Mvc;
using Frapid.Areas.Authorization;
using Frapid.Areas.CSRF;
using Frapid.Dashboard;
using Frapid.Dashboard.Controllers;
using Frapid.WebsiteBuilder.Models;

namespace Frapid.WebsiteBuilder.Controllers.Backend
{
    [AntiForgery]
    public class LayoutController: DashboardController
    {
        [Route("dashboard/website/layouts")]
        [RestrictAnonymous]
        [MenuPolicy]
        public ActionResult Master()
        {
            return this.FrapidView(this.GetRazorView<AreaRegistration>("Backend/Layout/Index.cshtml", this.Tenant));
        }

        [Route("dashboard/website/layouts/save")]
        [HttpPost]
        [RestrictAnonymous]
        public ActionResult SaveLayoutFile(string theme, string fileName, string contents)
        {
            bool result = LayoutManagerModel.SaveLayoutFile(this.Tenant, theme, fileName, contents);

            if(!result)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return this.Json("OK");
        }
    }
}