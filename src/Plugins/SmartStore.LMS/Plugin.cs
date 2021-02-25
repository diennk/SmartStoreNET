using SmartStore.Core.Plugins;
using SmartStore.LMS;
using SmartStore.LMS.Settings;
using SmartStore.Services;
using SmartStore.Services.Cms;
using SmartStore.Services.Configuration;
using SmartStore.Services.Tasks;
using System;
using System.Collections.Generic;
using System.Web.Routing;

namespace SmartStore.LMS
{
    public class Plugin : BasePlugin, IConfigurable, IWidget
    {
        private readonly ISettingService _settingService;
        private readonly ICommonServices _services;
        private readonly IScheduleTaskService _scheduleTaskService;

        public Plugin(ISettingService settingService,
            ICommonServices services,
            IScheduleTaskService scheduleTaskService)
        {
            _settingService = settingService;
            _services = services;
            _scheduleTaskService = scheduleTaskService;
        }
        public static string SystemName => "SmartStore.LMS";

        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "LMS";
            routeValues = new RouteValueDictionary() { { "area", "SmartStore.LMS" } };
        }

        public void GetDisplayWidgetRoute(string widgetZone, object model, int storeId, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "ReplaceAdminLogo";
            controllerName = "LMS";
            routeValues = new RouteValueDictionary()
            {
                {"area", SystemName },
                //{"widgetZone", widgetZone}
            };
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string> { "admin_menu_before" };
        }

        public override void Install()
        {
            // Save settings with default values.
            _services.Settings.SaveSetting(new LMSSettings());

            // Import localized plugin resources (you can edit or add these in /Localization/resources.[Culture].xml).
            _services.Localization.ImportPluginResourcesFromXml(this.PluginDescriptor);

            _scheduleTaskService.GetOrAddTask<MyFirstTask>(x =>
            {
                x.Name = "SmartStore.LMS.Tasks.MyFirstTask";
                x.CronExpression = "*/30 * * * *"; // every 30 min.
                x.Enabled = true;
                x.RunPerMachine = true;
            });

            base.Install();
        }

        public override void Uninstall()
        {
            _services.Settings.DeleteSetting<LMSSettings>();
            _services.Localization.DeleteLocaleStringResources(this.PluginDescriptor.ResourceRootKey);

            _scheduleTaskService.TryDeleteTask<MyFirstTask>();

            base.Uninstall();
        }
    }
}
