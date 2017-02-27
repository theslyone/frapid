using System.Threading.Tasks;
using System.Web.Mvc;
using Frapid.Areas;
using Frapid.Areas.Authorization;
using Frapid.Dashboard.DAL;

namespace Frapid.Dashboard.Controllers
{
    public class MenuController : FrapidController
    {
        [Route("dashboard/my/menus")]
        [RestrictAnonymous]
        public async Task<ActionResult> GetMenusAsync()
        {
            int userId = this.AppUser.UserId;
            int officeId = this.AppUser.OfficeId;
            var model = await Menus.GetAsync(this.Tenant, userId, officeId).ConfigureAwait(true);

            return this.Ok(model);
        }
    }
}