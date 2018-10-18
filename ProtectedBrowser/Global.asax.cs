using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using ProtectedBrowser.App_Start;
using Autofac.Integration.WebApi;
using ProtectedBrowser.Core.Infrastructure;

namespace ProtectedBrowser
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var engine = EngineContext.Initialize(false);
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(engine.ContainerManager.Container);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (this.Context.Request.Path.Contains("signalr/"))
            {
                this.Context.Response.AddHeader("Access-Control-Allow-Headers", "accept,origin,authorization,content-type");
            }
            //SqlDependency.Stop(connString);
            if (ReferenceEquals(null, HttpContext.Current.Request.Headers["Authorization"]))
            {
                var token = HttpContext.Current.Request.Params["a_t"];
                if (!string.IsNullOrEmpty(token))
                {
                    HttpContext.Current.Request.Headers.Add("Authorization", "Bearer " + token);
                }
            }
            //Response.Redirect(""),j
        }
    }
}
