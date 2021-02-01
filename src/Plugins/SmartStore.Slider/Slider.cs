using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartStore.Core.Logging;
using SmartStore.Core.Plugins;
using SmartStore.Services.Cms;
using SmartStore.Services.Localization;

namespace SmartStore.Slider
{
    public class Slider : BasePlugin, IWidget, IConfigurable
    {
        private readonly SliderSettings _sliderSettings;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger _logger;

        public Slider(
            SliderSettings clickatellSettings,
            ILocalizationService localizationService,
            ILogger logger)
        {
            _sliderSettings = clickatellSettings;
            _localizationService = localizationService;
            _logger = logger;
        }

        public static string SystemName => "SmartStore.Slider";

        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "Slider";
            routeValues = new RouteValueDictionary { { "area", SystemName } };
        }

        public override void Install()
        {
            _localizationService.ImportPluginResourcesFromXml(PluginDescriptor);

            base.Install();
        }

        public override void Uninstall()
        {
            _localizationService.DeleteLocaleStringResources(PluginDescriptor.ResourceRootKey);

            base.Uninstall();
        }


        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            var zones = new List<string> { "home_page_after_categories" };
            if (_sliderSettings.WidgetZone.HasValue())
            {
                zones = new List<string>
                {
                    _sliderSettings.WidgetZone
                };
            }

            return zones;
        }

        public void GetDisplayWidgetRoute(string widgetZone, object model, int storeId, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Render";
            controllerName = "Slider";
            routeValues = new RouteValueDictionary()
            {
                {"area", SystemName },
                //{"widgetZone", widgetZone}
            };
        }
    }
}
