using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Frapid.AddressBook.Models;
using Frapid.AddressBook.QueryModels;
using Frapid.ApplicationState.Cache;
using Frapid.Areas.CSRF;
using Frapid.Dashboard;

namespace Frapid.AddressBook.Controllers.Backend
{
    [AntiForgery]
    public sealed class ExportController : AddressBookBackendController
    {
        [Route("dashboard/address-book/export/vcard")]
        [MenuPolicy(OverridePath = "/dashboard/address-book")]
        [HttpPost]
        public async Task<ActionResult> ExportAsync(AddressBookQuery query)
        {
            if (!this.ModelState.IsValid)
            {
                return this.InvalidModelState(this.ModelState);
            }

            var meta = await AppUsers.GetCurrentAsync().ConfigureAwait(true);
            query.UserId = meta.UserId;

            try
            {
                string path = await VCardExporter.ExportAsync(this.Tenant, query, this.Request).ConfigureAwait(true);
                return this.Ok(path);
            }
            catch (Exception ex)
            {
                this.Failed(ex.Message, HttpStatusCode.InternalServerError);
                throw;
            }
        }
    }
}