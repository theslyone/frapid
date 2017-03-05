﻿using System.Web.Mvc;
using Frapid.Areas;

namespace TestApp
{
    public class AreaRegistration : FrapidAreaRegistration
    {
        public override string AreaName => "TestApp";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.LowercaseUrls = true;
            context.Routes.MapMvcAttributeRoutes();
        }
    }
}