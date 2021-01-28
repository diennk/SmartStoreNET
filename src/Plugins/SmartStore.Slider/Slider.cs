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
using SmartStore.Services.Localization;

namespace SmartStore.Slider
{
    public class Slider : BasePlugin, IConfigurable
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

        public void SendSms(string text)
        {
            
        }
    }
}
