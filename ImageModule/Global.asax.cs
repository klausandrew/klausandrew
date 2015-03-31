using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Http;
using System.Web.Http.WebHost;
using System.Web.Mvc;
using System.Web.Optimization;
using WebMatrix.WebData;


namespace ImageModule {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            //GlobalConfiguration.Configuration(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            BootstrapSupport.BootstrapBundleConfig.RegisterBundles(System.Web.Optimization.BundleTable.Bundles);
            BootstrapMvcSample.ExampleLayoutsRouteConfig.RegisterRoutes(RouteTable.Routes);
            BootstrapSupport.BootstrapBundleConfig.RegisterBundles(System.Web.Optimization.BundleTable.Bundles);
            BootstrapMvcSample.ExampleLayoutsRouteConfig.RegisterRoutes(RouteTable.Routes);
            BootstrapSupport.BootstrapBundleConfig.RegisterBundles(System.Web.Optimization.BundleTable.Bundles);
            BootstrapMvcSample.ExampleLayoutsRouteConfig.RegisterRoutes(RouteTable.Routes);
            BootstrapSupport.BootstrapBundleConfig.RegisterBundles(System.Web.Optimization.BundleTable.Bundles);
            BootstrapMvcSample.ExampleLayoutsRouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        //Redirect all ASPX pages to home controller
        protected void Application_BeginRequest(Object sender, EventArgs e) {
            if (Request.RawUrl.ToUpper().EndsWith("ASPX") == true) {
                Response.Redirect("Home");
            } else { 
            
            };
        }
    }
}