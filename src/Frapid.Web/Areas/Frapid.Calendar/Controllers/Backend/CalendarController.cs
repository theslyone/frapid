using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Frapid.ApplicationState.Cache;
using Frapid.Areas.CSRF;
using Frapid.Calendar.DAL;
using Frapid.Calendar.Models;
using Frapid.Calendar.QueryModels;
using Frapid.Calendar.ViewModels;
using Frapid.Dashboard;

namespace Frapid.Calendar.Controllers.Backend
{
    [AntiForgery]
    public sealed class CalendarController : CalendarBackendController
    {
        [Route("dashboard/calendar")]
        [MenuPolicy]
        public async Task<ActionResult> IndexAsync()
        {
            var meta = await AppUsers.GetCurrentAsync().ConfigureAwait(true);
            var model = await Categories.GetMyCategoriesAsync(this.Tenant, meta.UserId).ConfigureAwait(true);
            return this.FrapidView(this.GetRazorView<AreaRegistration>("Backend/Index.cshtml", this.Tenant), model);
        }

        [Route("dashboard/calendar/my")]
        [MenuPolicy(OverridePath = "/dashboard/calendar")]
        [HttpPost]
        public async Task<ActionResult> MyAsync(EventQuery query)
        {
            if (!this.ModelState.IsValid)
            {
                return this.InvalidModelState(this.ModelState);
            }

            var meta = await AppUsers.GetCurrentAsync().ConfigureAwait(true);

            try
            {
                var model = await CalendarEventModel.GetMyEventsAsync(this.Tenant, query.Start, query.End, meta.UserId, query.CategoryIds).ConfigureAwait(true);
                return this.Ok(model);
            }
            catch (Exception ex)
            {
                return this.Failed(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        [Route("dashboard/calendar/{eventId:guid}")]
        [HttpDelete]
        [MenuPolicy(OverridePath = "/dashboard/calendar")]
        public async Task<ActionResult> DeleteAsync(Guid eventId)
        {
            var meta = await AppUsers.GetCurrentAsync().ConfigureAwait(true);

            try
            {
                await CalendarEventModel.DeleteAsync(this.Tenant, meta, eventId).ConfigureAwait(true);
                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.Failed(ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        [Route("dashboard/calendar")]
        [HttpPost]
        [MenuPolicy]
        public async Task<ActionResult> PostAsync(CalendarEvent calendarEvent)
        {
            if (!this.ModelState.IsValid)
            {
                return this.InvalidModelState(this.ModelState);
            }

            var meta = await AppUsers.GetCurrentAsync().ConfigureAwait(true);

            calendarEvent.UserId = meta.UserId;

            try
            {
                var eventId = await CalendarEventModel.AddOrEditEntryAsync(this.Tenant, meta, calendarEvent).ConfigureAwait(true);
                return this.Ok(eventId);
            }
            catch (Exception ex)
            {
                return this.Failed(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}