using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using Frapid.Account.DAL;
using Frapid.ApplicationState.CacheFactory;

namespace Frapid.Account.Controllers
{
    public class SignOutController : BaseAuthenticationController
    {
        [Route("account/sign-out")]
        [Route("account/log-out")]
        public async Task<ActionResult> SignOutAsync()
        {
            if (!string.IsNullOrWhiteSpace(this.AppUser?.ClientToken))
            {
                await AccessTokens.RevokeAsync(this.Tenant, this.AppUser.ClientToken).ConfigureAwait(true);
                string key = "access_tokens_" + this.Tenant;
                var factory = new DefaultCacheFactory();
                factory.Remove(key);
            }

            FormsAuthentication.SignOut();
            return this.View(this.GetRazorView<AreaRegistration>("SignOut/Index.cshtml", this.Tenant));
        }

        [Route("account/sign-out-mobile")]
        [Route("account/log-out-mobile")]
        public async Task<ActionResult> SignOutMobileAsync()
        {
            if (!string.IsNullOrWhiteSpace(this.AppUser?.ClientToken))
            {
                await AccessTokens.RevokeAsync(this.Tenant, this.AppUser.ClientToken).ConfigureAwait(true);
                string key = "access_tokens_" + this.Tenant;
                var factory = new DefaultCacheFactory();
                factory.Remove(key);
            }

            FormsAuthentication.SignOut();
            return this.Ok();
        }
    }
}