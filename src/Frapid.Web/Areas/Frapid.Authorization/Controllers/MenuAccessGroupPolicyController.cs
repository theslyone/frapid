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
    public class MenuAccessGroupPolicyController : DashboardController
    {
        [RestrictAnonymous]
        [Route("dashboard/authorization/menu-access/group-policy")]
        [MenuPolicy]
        public async Task<ActionResult> GroupPolicyAsync()
        {
            var model = await GroupMenuPolicyModel.GetAsync(this.AppUser).ConfigureAwait(true);
            return this.FrapidView(this.GetRazorView<AreaRegistration>("MenuPolicy/GroupPolicy.cshtml", this.Tenant), model);
        }

        [RestrictAnonymous]
        [Route("dashboard/authorization/menu-access/group-policy/{officeId}/{roleId}")]
        public async Task<ActionResult> GetGroupPolicyAsync(int officeId, int roleId)
        {
            var model = await GroupMenuPolicyModel.GetAsync(this.AppUser, officeId, roleId).ConfigureAwait(true);
            return this.Ok(model);
        }


        [RestrictAnonymous]
        [HttpPut]
        [Route("dashboard/authorization/menu-access/group-policy")]
        public async Task<ActionResult> SaveGroupPolicyAsync(GroupMenuPolicyInfo model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.InvalidModelState(this.ModelState);
            }

            await GroupMenuPolicyModel.SaveAsync(this.AppUser, model).ConfigureAwait(true);
            return this.Ok("OK");
        }
    }
}