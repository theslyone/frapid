using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Frapid.Account.DAL;
using Frapid.Account.ViewModels;
using Frapid.ApplicationState.Cache;
using Frapid.Areas.Authorization;
using Frapid.Dashboard;
using Frapid.Dashboard.Controllers;
using Frapid.Areas.CSRF;

namespace Frapid.Account.Controllers.Backend
{
    [AntiForgery]
    public class ChangePasswordController : DashboardController
    {
        [Route("dashboard/account/user/change-password")]
        [RestrictAnonymous]
        [MenuPolicy]
        public ActionResult ChangePassword()
        {
            if (!AppUsers.GetCurrent().IsAdministrator)
            {
                return this.AccessDenied();
            }

            return this.FrapidView(this.GetRazorView<AreaRegistration>("User/ChangePassword.cshtml", this.Tenant));
        }

        [Route("dashboard/account/user/change-password")]
        [RestrictAnonymous]
        [HttpPost]
        public async Task<ActionResult> ChangePasswordAsync(ChangePasswordInfo model)
        {
            var user = await AppUsers.GetCurrentAsync(this.Tenant).ConfigureAwait(true);

            if (!user.IsAdministrator)
            {
                return this.AccessDenied();
            }

            if (!this.ModelState.IsValid)
            {
                return this.InvalidModelState(this.ModelState);
            }


            if (model.Password != model.ConfirmPassword)
            {
                return this.Failed(I18N.ConfirmPasswordDoesNotMatch, HttpStatusCode.BadRequest);
            }

            try
            {
                await Users.ChangePasswordAsync(this.Tenant, user.UserId, model).ConfigureAwait(true);
                return this.Ok("OK");
            }
            catch (Exception ex)
            {
                return this.Failed(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}