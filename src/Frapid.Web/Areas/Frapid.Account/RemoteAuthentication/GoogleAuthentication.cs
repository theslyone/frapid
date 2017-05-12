using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Frapid.Account.DAL;
using Frapid.Account.DTO;
using Frapid.Account.Emails;
using Frapid.Account.InputModels;
using Frapid.Account.ViewModels;
using Frapid.Areas;
using Frapid.i18n;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Frapid.Events.EventPublishers;
using Frapid.Events;
using Frapid.Events.Interfaces;

namespace Frapid.Account.RemoteAuthentication
{
    public class GoogleAuthentication
    {
        private const string ProviderName = "Google";

        public GoogleAuthentication(string tenant)
        {
            this.Tenant = tenant;
            var profile = ConfigurationProfiles.GetActiveProfileAsync(tenant).GetAwaiter().GetResult();
            this.ClientId = profile.GoogleSigninClientId;
        }

        public string Tenant { get; }

        public string ClientId { get; set; }

        //https://developers.google.com/identity/sign-in/web/backend-auth
        private async Task<bool> ValidateAsync(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return false;
            }

            //var client = GlobalHttpClient.Get();
            var client = new HttpClient();
            client.DefaultRequestHeaders.ConnectionClose = true;

            string url = "https://www.googleapis.com";
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var sp = ServicePointManager.FindServicePoint(new Uri("http://foo.bar/baz/123?a=ab"));
            sp.ConnectionLeaseTimeout = 60 * 1000; // 1 minute

            using (var response = await client.GetAsync("/oauth2/v3/tokeninfo?id_token=" + token).ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<JObject>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    string aud = result["aud"].ToString();

                    if (aud == this.ClientId)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public async Task<LoginResult> AuthenticateAsync(GoogleAccount account, RemoteUser user)
        {
            bool validationResult = Task.Run(() => this.ValidateAsync(account.Token)).GetAwaiter().GetResult();

            if (!validationResult)
            {
                return new LoginResult
                {
                    Status = false,
                    Message = Resources.AccessIsDenied
                };
            }

            var gUser = new GoogleUserInfo
            {
                Email = account.Email,
                Name = account.Name
            };

            var result = await GoogleSignIn.SignInAsync(this.Tenant, account.Email, account.OfficeId, account.Name, account.Token, user.Browser, user.IpAddress, account.Culture).ConfigureAwait(false);

            if (result.Status)
            {
                UserEvent userEvent = new UserEvent();
                userEvent.User.Email = gUser.Email;
                userEvent.User.Name = gUser.Name;
                userEvent.CreationDate = DateTime.Now;
                userEvent.Tenant = this.Tenant;
                DefaultEventPublisher.GetInstance().EntityInserted(userEvent);

                if (!await Registrations.HasAccountAsync(this.Tenant, account.Email).ConfigureAwait(false))
                {
                    string template = "~/Tenants/{tenant}/Areas/Frapid.Account/EmailTemplates/welcome-email-other.html";
                    var welcomeEmail = new WelcomeEmail(gUser, template, ProviderName);
                    await welcomeEmail.SendAsync(this.Tenant).ConfigureAwait(false);
                }
            }

            return result;
        }
    }
}