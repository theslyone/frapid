using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Frapid.ApplicationState.Cache;
using Frapid.Areas.CSRF;
using Frapid.Dashboard;
using Frapid.Dashboard.Controllers;
using Frapid.DataAccess.Models;
using MixERP.Social.DTO;
using MixERP.Social.Models;

namespace MixERP.Social.Controllers
{
    [AntiForgery]
    public sealed class DefaultController : DashboardController
    {
        [Route("dashboard/social")]
        [MenuPolicy]
        [AccessPolicy("social", "feeds", AccessTypeEnum.Read)]
        public ActionResult Index()
        {
            return this.FrapidView(this.GetRazorView<AreaRegistration>("Tasks/Index.cshtml", this.Tenant));
        }

        [Route("dashboard/social")]
        [MenuPolicy]
        [HttpPost]
        [AccessPolicy("social", "feeds", AccessTypeEnum.Create)]
        public async Task<ActionResult> PostAsync(Feed model)
        {
            var meta = await AppUsers.GetCurrentAsync().ConfigureAwait(true);
            var feedResult = await Feeds.PostAsync(this.Tenant, model, meta).ConfigureAwait(true);
            return this.Ok(feedResult);
        }

        [Route("dashboard/social/delete/{feedId}")]
        [MenuPolicy(OverridePath = "/dashboard/social")]
        [HttpDelete]
        [AccessPolicy("social", "feeds", AccessTypeEnum.Delete)]
        public async Task<ActionResult> DeleteAsync(long feedId)
        {
            var meta = await AppUsers.GetCurrentAsync().ConfigureAwait(true);

            try
            {
                await Feeds.DeleteAsync(this.Tenant, feedId, meta).ConfigureAwait(true);
                return this.Ok();
            }
            catch (FeedException ex)
            {
                return this.Failed(ex.Message, HttpStatusCode.Forbidden);
            }
        }

        [Route("dashboard/social/like/{feedId}")]
        [MenuPolicy(OverridePath = "/dashboard/social")]
        [HttpPut]
        [AccessPolicy("social", "feeds", AccessTypeEnum.Edit)]
        public async Task<ActionResult> LikeAsync(long feedId)
        {
            var meta = await AppUsers.GetCurrentAsync().ConfigureAwait(true);

            try
            {
                await Feeds.LikeAsync(this.Tenant, feedId, meta).ConfigureAwait(true);
                return this.Ok();
            }
            catch (FeedException ex)
            {
                return this.Failed(ex.Message, HttpStatusCode.Forbidden);
            }
        }

        [Route("dashboard/social/unlike/{feedId}")]
        [MenuPolicy(OverridePath = "/dashboard/social")]
        [HttpPut]
        [AccessPolicy("social", "feeds", AccessTypeEnum.Edit)]
        public async Task<ActionResult> UnlikeAsync(long feedId)
        {
            var meta = await AppUsers.GetCurrentAsync().ConfigureAwait(true);

            try
            {
                await Feeds.UnlikeAsync(this.Tenant, feedId, meta).ConfigureAwait(true);
                return this.Ok();
            }
            catch (FeedException ex)
            {
                return this.Failed(ex.Message, HttpStatusCode.Forbidden);
            }
        }

        [Route("dashboard/social/delete/{feedId}/attachment/{attachment}")]
        [MenuPolicy(OverridePath = "/dashboard/social")]
        [HttpDelete]
        [AccessPolicy("social", "feeds", AccessTypeEnum.Read)]
        public async Task<ActionResult> DeleteAttachmentAsync(long feedId, string attachment)
        {
            var meta = await AppUsers.GetCurrentAsync().ConfigureAwait(true);

            try
            {
                await Feeds.DeleteAttachmentAsync(this.Tenant, feedId, attachment, meta).ConfigureAwait(true);
                return this.Ok();
            }
            catch (FeedException ex)
            {
                return this.Failed(ex.Message, HttpStatusCode.Forbidden);
            }
        }

        [Route("dashboard/social/feeds")]
        [Route("dashboard/social/feeds/{lastFeedId}")]
        [Route("dashboard/social/feeds/{lastFeedId}/{parentFeedId}")]
        [MenuPolicy(OverridePath = "/dashboard/social")]
        [AccessPolicy("social", "feeds", AccessTypeEnum.Read)]
        public async Task<ActionResult> GetNextTopFeedsAsync(long lastFeedId = 0, long parentFeedId = 0)
        {
            var meta = await AppUsers.GetCurrentAsync().ConfigureAwait(true);
            var model = await Feeds.GetFeedsAsync(this.Tenant, meta.UserId, lastFeedId, parentFeedId).ConfigureAwait(true);

            return this.Ok(model);
        }
    }
}