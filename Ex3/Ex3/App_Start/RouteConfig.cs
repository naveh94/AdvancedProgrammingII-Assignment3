using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ex3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            const string IP_PATTERN = @"\d+\.\d+\.\d+\.\d+";
            const string NUM_PATTERN = @"\d+";

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Display",
                url: "display/{ip}/{port}",
                defaults: new { controller = "Display", action = "DisplayRoute" },
                constraints: new { ip = IP_PATTERN, port = NUM_PATTERN }
                );

            routes.MapRoute(
                name: "DisplayFreq",
                url: "display/{ip}/{port}/{freq}",
                defaults: new { controller = "Display", action = "DisplayFreq" },
                constraints: new { ip = IP_PATTERN, port = NUM_PATTERN, freq = NUM_PATTERN }
                );

            routes.MapRoute(
                name: "DisplayFile",
                url: "display/{filename}/{freq}",
                defaults: new { controller = "Display", action = "DisplayFile" },
                constraints: new { freq = NUM_PATTERN }
                );

            routes.MapRoute(
                name: "SaveFile",
                url: "save/{ip}/{port}/{freq}/{time}/{filename}",
                defaults: new { controller = "Display", action = "SaveFile" },
                constraints: new { ip = IP_PATTERN, port = NUM_PATTERN, freq = NUM_PATTERN, time = NUM_PATTERN }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Display", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
