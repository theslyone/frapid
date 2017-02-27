using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Frapid.Areas.Authorization;
using Frapid.Areas.CSRF;
using Frapid.Authorization.Models;
using Frapid.Authorization.ViewModels;
using Frapid.Dashboard;
using Frapid.Dashboard.Controllers;

namespace Frapid.Authorization.Controllers
{
    [AntiForgery]
    public class EntityAccessPolicyController : DashboardController
    {
        [RestrictAnonymous]
        [Route("dashboard/authorization/entity-access/user-policy")]
        [MenuPolicy]
        public async Task<ActionResult> UserPolicyAsync()
        {
            var model = await EntityAccessPolicyModel.GetAsync(this.AppUser).ConfigureAwait(true);
            return this.FrapidView(this.GetRazorView<AreaRegistration>("AccessPolicy/Policy.cshtml", this.Tenant), model);
        }


        [RestrictAnonymous]
        [Route("dashboard/authorization/entity-access/user-policy/{officeId}/{userId}")]
        public async Task<ActionResult> GetPolicyAsync(int officeId, int userId)
        {
            var model = await EntityAccessPolicyModel.GetAsync(this.AppUser, officeId, userId).ConfigureAwait(true);
            return this.Ok(model);
        }


        [RestrictAnonymous]
        [Route("dashboard/authorization/entity-access/user-policy/{officeId}/{userId}")]
        [HttpPost]
        public async Task<ActionResult> SavePolicyAsync(int officeId, int userId, List<AccessPolicyInfo> model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.InvalidModelState(this.ModelState);
            }

            await EntityAccessPolicyModel.SaveAsync(this.AppUser, officeId, userId, model).ConfigureAwait(true);
            return this.Ok();
        }
    }
}