using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebAppTest
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DisplayFreq",
                url: "display/{ip}/{port}/{freq}",
                defaults: new { controller = "Home", action = "DisplayFreq" },
                constraints: new { ip = @"\d+.\d+.\d+.\d+", port= @"\d+", freq = @"\d+" }
                );

            routes.MapRoute(
                name: "Display",
                url: "display/{ip}/{port}",
                defaults: new { controller = "Home", action = "Display" },
                constraints: new { ip = @"\d+.\d+.\d+.\d+" }
                );

            routes.MapRoute(
                name: "DisplayFile",
                url: "display/{filename}/{freq}",
                defaults: new { controller = "Home", action = "DisplayFile" },
                constraints: new { freq = @"\d+" }
                );

            routes.MapRoute(
                name: "Save",
                url: "save/{ip}/{port}/{freq}/{time}/{filename}",
                defaults: new { controller = "Home", action = "Save" },
                constraints: new { ip = @"\d+.\d+.\d+.\d+", port = @"\d+", freq = @"\d+", time = @"\d+" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
