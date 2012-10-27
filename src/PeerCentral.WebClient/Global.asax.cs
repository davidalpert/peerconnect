﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using PeerCentral.WebClient.App_Start;
using PeerCentral.WebClient.Configuration;
using RestfulRouting;

namespace PeerCentral.WebClient
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteTable.Routes.MapRoutes<Routes>();
            DisplayModeConfig.RegisterDisplayModes(DisplayModeProvider.Instance.Modes);
            AuthConfig.RegisterAuth();
        }
    }
}