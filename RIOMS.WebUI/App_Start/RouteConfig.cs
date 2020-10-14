using System.Web.Mvc;
using System.Web.Routing;

namespace RIOMS.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(name: "Home",
                 url: "{controller}/{action}",
                  defaults: new { controller = "Home", action = "Index" }
                 );
            routes.MapRoute(
                name: "Khatas",
                url: "Khatas/{action}/{vid}/{khataNo}",
                defaults: new { controller = "Khatas", action = "Index", vid = UrlParameter.Optional, khataNo = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "RIOMS",
                url: "{controller}/{action}/{year}/{vid}/{iformNo}/{kisam}",
                defaults: new { controller = "VillageWari", action = "index", year = UrlParameter.Optional, iformNo = UrlParameter.Optional, vid = UrlParameter.Optional, kisam = UrlParameter.Optional }
            );
          //  routes.MapRoute(
          //    name: "MFORM",
          //    url: "{controller}/{action}/{year}/{vid}/{arrear}",
          //    defaults: new { controller = "VillageWari", action = "index", year = UrlParameter.Optional, arrear = UrlParameter.Optional, vid = UrlParameter.Optional, }
          //);
        }
    }
}