using System.Web.Mvc;
using System.Web.Routing;
using SmartStore.Web.Framework.Routing;

namespace SmartStore.Slider
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("SmartStore.Slider",
                 "Plugins/SmartStore.Slider/{action}",
                 new { controller = "Slider", action = "Configure" },
                 new[] { "SmartStore.Slider.Controllers" }
            )
            .DataTokens["area"] = Slider.SystemName;
        }

        public int Priority => 0;
    }
}
