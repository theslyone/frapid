﻿using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Frapid.Account.DAL;
using Frapid.Account.DTO;
using Frapid.Account.InputModels;
using Frapid.ApplicationState.Cache;
using Frapid.Configuration;
using Frapid.Framework.Extensions;
using Frapid.TokenManager;
using Frapid.WebsiteBuilder.Controllers;
using Newtonsoft.Json;
using Frapid.Configuration.Events;
using System.Collections.Specialized;

namespace Frapid.Account.Controllers
{
    public class BaseAuthenticationController : WebsiteBuilderController
    {
        protected async Task<bool> CheckPasswordAsync(string tenant, string email, string plainPassword)
        {
            var user = await Users.GetAsync(tenant, email).ConfigureAwait(false);

            return user != null && PasswordManager.ValidateBcrypt(email, plainPassword, user.Password);
        }

        protected async Task<ActionResult> OnAuthenticatedAsync(LoginResult result, SignInInfo model = null)
        {
            if (!result.Status)
            {
                int delay = new Random().Next(1, 5) * 1000;

                await Task.Delay(delay).ConfigureAwait(false);
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, JsonConvert.SerializeObject(result));
            }
        

            Guid? applicationId = null;

            if (model != null)
            {
                applicationId = model.ApplicationId;
            }

            var loginView = await AppUsers.GetCurrentAsync(this.Tenant, result.LoginId).ConfigureAwait(false);

            var manager = new Provider(this.Tenant, applicationId, result.LoginId, loginView.UserId, loginView.OfficeId);
            var token = manager.GetToken();

            await AccessTokens.SaveAsync(this.Tenant, token, this.RemoteUser.IpAddress, this.RemoteUser.UserAgent).ConfigureAwait(true);
            //AccessTokens.Save(this.Tenant, token, this.RemoteUser.IpAddress, this.RemoteUser.UserAgent);
            
            //time to propagate and save access token to database
            await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(true);

            string domain = TenantConvention.GetDomain();

            this.AddAuthenticationCookie(domain, token);
            this.AddAuthenticationHeader(domain, token);
            this.AddCultureCookie(domain, model?.Culture.Or("en-US"));

            LoginEvent loginEvent = new LoginEvent();
            loginEvent.User.Email = loginView.Email;
            loginEvent.User.Name = loginView.Name;
            loginEvent.Tenant = this.Tenant;
            loginEvent.CreationDate = DateTime.Now;
            DefaultEventManager.GetInstance().Publish(loginEvent);
            
            var appUser = new AppUser() {
                ClientToken = token.ClientToken,
                LoginId = loginView.LoginId,
                Email = loginView.Email,
                Name = loginView.Name
            };
            return OkResponse(appUser);
        }

        protected ActionResult OnValidateToken(AppUser appUser)
        {
            var provider = new Provider();
            var token = provider.GetToken(AppUser.ClientToken);

            string domain = TenantConvention.GetDomain();
            //AddAuthenticationCookie(domain, token);
            AddAuthenticationHeader(domain, token);

            return OkResponse(appUser);
        }

        private ActionResult OkResponse(AppUser appUser)
        {
            return this.Ok(
                new
                {
                    token = appUser?.ClientToken,
                    data = new
                    {
                        loginId = appUser.LoginId,
                        email = appUser?.Email,
                        name = appUser?.Name
                    }
                });
        }

        private void AddCultureCookie(string domain, string culture)
        {
            var cookie = new HttpCookie("culture")
            {
                Value = culture,
                HttpOnly = false,
                Expires = DateTime.Now.AddDays(1)
            };

            //localhost cookie is not supported by most browsers.
            if (domain.ToLower() != "localhost")
            {
                cookie.Domain = domain;
            }

            this.Response.Cookies.Add(cookie);
        }

        private void AddAuthenticationCookie(string domain, Token token)
        {
            var cookie = new HttpCookie("access_token")
            {
                Value = token.ClientToken,
                HttpOnly = true,
                Expires = token.ExpiresOn.DateTime
            };

            //localhost cookie is not supported by most browsers.
            if (domain.ToLower() != "localhost")
            {
                cookie.Domain = domain;
            }

            this.Response.Cookies.Add(cookie);
        }

        private void AddAuthenticationHeader(string domain, Token token)
        {
            var customHeader = new NameValueCollection();
            customHeader.Add("access-token", token.ClientToken);
            customHeader.Add("expiry", token.ExpiresOn.ToUnixTimeMilliseconds().ToString());
            customHeader.Add("clientId", token.LoginId.ToString());            
            this.Response.Headers.Add(customHeader);
        }
    }
}