using System.Web.Mvc;
using Frapid.Areas.Authorization;
using Frapid.Dashboard;
using Frapid.Dashboard.Controllers;

namespace Frapid.WebsiteBuilder.Controllers.Backend
{
    public class MenuItemController : DashboardController
    {
        [Route("dashboard/website/menus/items")]
        [RestrictAnonymous]
        [MenuPolicy(OverridePath = "/dashboard/website/menus")]
        public ActionResult Index()
        {
            return this.FrapidView(this.GetRazorView<AreaRegistration>("Backend/MenuItem/Index.cshtml", this.Tenant));
        }
    }
}