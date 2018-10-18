using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProtectedBrowser
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
           
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "custom",
              url: "custom",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "dashboard",
              url: "dashboard",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
	        );	
            routes.MapRoute(
                name: "changePassword",
                url: "dashboard/changePassword",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "recoverPassword",
                url: "recoverPassword",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "accountSettings",
                url: "dashboard/accountSettings",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "signIn",
                url: "signIn",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "404",
                url: "404",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "403",
                url: "403",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
			routes.MapRoute(
	            name: "DirectoryList",
	            url: "dashboard/DirectoryList",
	            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
	        );
	        routes.MapRoute(
	            name: "DirectoryEdit",
	            url: "dashboard/Directory/edit/{id}",
	            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
	        );
	        routes.MapRoute(
	            name: "DirectoryDetail",
	            url: "dashboard/Directory/detail/{id}",
	            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
	        );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
