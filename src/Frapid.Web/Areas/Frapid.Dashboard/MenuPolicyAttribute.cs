using System.Linq;
using System.Web.Mvc;
using Frapid.ApplicationState.Cache;
using Frapid.Configuration;
using Frapid.Dashboard.DAL;
using Frapid.Framework.Extensions;
using Frapid.i18n;

namespace Frapid.Dashboard
{
    public class MenuPolicyAttribute : ActionFilterAttribute
    {
        public string OverridePath { get; set; }
        public bool StatusResponse { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string path = this.OverridePath.Or(filterContext.HttpContext.Request.FilePath);

            var my = AppUsers.GetCurrentAsync().GetAwaiter().GetResult();
            int userId = my.UserId;
            int officeId = my.OfficeId;

            string tenant = TenantConvention.GetTenant();

            var policy = Menus.GetAsync(tenant, userId, officeId).GetAwaiter().GetResult();

            if (!policy.Any(x => x.Url.Equals(path)))
            {
                if (this.StatusResponse)
                {
                    filterContext.Result = new HttpUnauthorizedResult(Resources.AccessIsDenied);
                }
                else
                {
                    filterContext.Result = new RedirectResult("/account/sign-in");
                }
            }
        }
    }
}