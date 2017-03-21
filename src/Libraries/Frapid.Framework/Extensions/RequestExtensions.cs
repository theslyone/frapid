using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Controllers;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;

namespace Frapid.Framework.Extensions
{
    public static class RequestExtensions
    {
        public static readonly string[] IpAddressHeaders =
        {
            "CF-Connecting-IP",
            "HTTP_X_FORWARDED_FOR",
            "REMOTE_ADDR",
            "X-Forwarded-For"
        };
     
        private static string GetClientIpAddress(this HttpContextBase context, bool getLan = false)
        {
            string visitorIPAddress = context.Request.Headers["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(visitorIPAddress))
                visitorIPAddress = context.Request.Headers["REMOTE_ADDR"];

            if (string.IsNullOrEmpty(visitorIPAddress))
                visitorIPAddress = context.Request.UserHostAddress;

            if (string.IsNullOrEmpty(visitorIPAddress) || visitorIPAddress.Trim() == "::1")
            {
                getLan = true;
                visitorIPAddress = string.Empty;
            }

            if (getLan && string.IsNullOrEmpty(visitorIPAddress))
            {
                //This is for Local(LAN) Connected ID Address
                string stringHostName = Dns.GetHostName();
                //Get Ip Host Entry
                IPHostEntry ipHostEntries = Dns.GetHostEntry(stringHostName);
                //Get Ip Address From The Ip Host Entry Address List
                IPAddress[] arrIpAddress = ipHostEntries.AddressList;

                try
                {
                    visitorIPAddress = arrIpAddress[arrIpAddress.Length - 2].ToString();
                }
                catch
                {
                    try
                    {
                        visitorIPAddress = arrIpAddress[0].ToString();
                    }
                    catch
                    {
                        try
                        {
                            arrIpAddress = Dns.GetHostAddresses(stringHostName);
                            visitorIPAddress = arrIpAddress[0].ToString();
                        }
                        catch
                        {
                            visitorIPAddress = "127.0.0.1";
                        }
                    }
                }
            }
            return visitorIPAddress;
        }

        public static string GetClientIpAddress(this HttpContextBase context)
        {
            foreach (string ip in IpAddressHeaders.Select(header => context.Request.Headers[header]).Where(ip => !string.IsNullOrWhiteSpace(ip)))
            {
                return ip;
            }


            string ipAddress = context?.Request?.UserHostAddress != null ? IPAddress.Parse(context.Request.UserHostAddress).ToString() : null;

            if (!string.IsNullOrWhiteSpace(ipAddress))
            {
                return ipAddress;
            }

            return string.Empty;
        }

        public static string GetClientIpAddress(this IRequest request)
        {
            foreach (string ip in IpAddressHeaders.Select(header => request.Headers[header]).Where(ip => !string.IsNullOrWhiteSpace(ip)))
            {
                return ip;
            }

            object ipAddress;
            if (request.Environment.TryGetValue("server.RemoteIpAddress", out ipAddress))
            {
                return ipAddress as string;
            }

            return null;
        }

        public static string GetClientIpAddress(this HttpRequestMessage request)
        {
            var context = request.Properties["MS_HttpContext"] as HttpContextBase;
            string ipAddress = GetClientIpAddress(context);

            if (!string.IsNullOrWhiteSpace(ipAddress))
            {
                return ipAddress;
            }

            var owinContext = request.Properties["MS_OwinContext"] as OwinContext;

            foreach (string ip in IpAddressHeaders.Select(header => owinContext?.Request.Headers[header]).Where(ip => !string.IsNullOrWhiteSpace(ip)))
            {
                return ip;
            }


            return owinContext?.Request?.RemoteIpAddress != null ? IPAddress.Parse(owinContext.Request.RemoteIpAddress).ToString() : null;
        }

        public static string GetUserAgent(this HttpContextBase context)
        {
            string ua = context?.Request?.UserAgent;

            if (!string.IsNullOrWhiteSpace(ua))
            {
                return ua;
            }

            return string.Empty;
        }

        public static string GetUserAgent(this HttpRequestMessage request)
        {
            var context = request.Properties["MS_HttpContext"] as HttpContextBase;
            string ua = context?.Request?.UserAgent;

            if (!string.IsNullOrWhiteSpace(ua))
            {
                return ua;
            }

            var owinContext = request.Properties["MS_OwinContext"] as OwinContext;
            return owinContext?.Request?.Headers.Get("User-Agent");
        }

        public static string GetCountry(this HttpRequestBase request)
        {
            return request.ServerVariables["HTTP_CF_IPCOUNTRY"].Or("Country Data Not Available");
        }

        public static T ReadClaim<T>(this HttpRequestContext request, string type)
        {
            var principal = request.Principal as ClaimsPrincipal;
            var claim = principal?.Claims.FirstOrDefault(x => x.Type.Equals(type));

            return claim == null ? default(T) : claim.Value.To<T>();
        }

        public static T ReadClaim<T>(this HttpContextBase context, string type)
        {
            var principal = context.User as ClaimsPrincipal;
            var claim = principal?.Claims.FirstOrDefault(x => x.Type.Equals(type));

            return claim == null ? default(T) : claim.Value.To<T>();
        }

        //Web API
        public static string GetBearerToken(this HttpRequestMessage request)
        {
            var authHead = request.Headers.Authorization;
            return authHead?.ToString().Replace("Bearer ", "") ?? string.Empty;
        }

        //ASP.net MVC
        public static string GetClientToken(this HttpRequestBase request)
        {
            if (!request.Cookies.AllKeys.Contains("access_token"))
            {
                return string.Empty;
            }

            var cookie = request.Cookies["access_token"];
            return cookie == null ? string.Empty : cookie.Value;
        }

        public static string GetClientToken(this IRequest request)
        {
            if (!request.Cookies.ContainsKey("access_token") && string.IsNullOrEmpty(request.QueryString["access_token"]))
            {
                return string.Empty;
            }

            var accessToken = request.Cookies.ContainsKey("access_token") && request.Cookies["access_token"] != null 
                ? request.Cookies["access_token"].Value : request.QueryString["access_token"];
            return accessToken == null ? string.Empty : accessToken;
        }
    }
}