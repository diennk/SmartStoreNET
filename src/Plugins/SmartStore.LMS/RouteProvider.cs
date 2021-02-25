using System.Web.Mvc;
using System.Web.Routing;
using SmartStore.Web.Framework.Routing;

namespace SmartStore.LMS
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("SmartStore.LMS",
                 "Plugins/LMS/{action}",
                 new { controller = "LMS", action = "Configure" },
                 new[] { "SmartStore.LMS.Controllers" }
            )
            .DataTokens["area"] = Plugin.SystemName;
        }

        public int Priority => 0;
    }
}
