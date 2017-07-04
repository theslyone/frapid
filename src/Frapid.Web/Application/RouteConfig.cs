﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Frapid.Web.Application
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.RouteExistingFiles = false;
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute
            (
                    "Dashboard",
                    "dashboard/{controller}/{action}/{id}",
                    new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}