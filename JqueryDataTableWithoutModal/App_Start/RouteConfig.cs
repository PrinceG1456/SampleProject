using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JqueryDataTableWithoutModal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "List", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Edit",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "AddorEdit", action = "AddEdit", id = UrlParameter.Optional }
           );


        }
    }
}
