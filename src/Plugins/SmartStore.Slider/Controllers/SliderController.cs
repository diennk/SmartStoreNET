using System;
using System.Web.Mvc;
using SmartStore.Slider.Models;
using SmartStore.ComponentModel;
using SmartStore.Core.Plugins;
using SmartStore.Web.Framework.Controllers;
using SmartStore.Web.Framework.Filters;
using SmartStore.Web.Framework.Security;
using SmartStore.Web.Framework.Settings;

namespace SmartStore.Slider.Controllers
{
    [AdminAuthorize]
    public class SliderController : PluginControllerBase
    {
        private readonly IPluginFinder _pluginFinder;

        public SliderController(IPluginFinder pluginFinder)
        {
            _pluginFinder = pluginFinder;
        }

        [LoadSetting]
        public ActionResult Configure(SliderSettings settings)
        {
            var model = new SliderModel();
            //MiniMapper.Map(settings, model);

            return View(model);
        }

        [HttpPost, SaveSetting, FormValueRequired("save")]
        [ValidateAntiForgeryToken]
        public ActionResult Configure(SliderSettings settings, SliderModel model)
        {
            if (!ModelState.IsValid)
            {
                return Configure(settings);
            }

            MiniMapper.Map(model, settings);

            NotifySuccess(T("Admin.Common.DataSuccessfullySaved"));

            return RedirectToConfiguration(Slider.SystemName);
        }

        [HttpPost, ActionName("Configure"), FormValueRequired("test-sms")]
        [ValidateAntiForgeryToken]
        public ActionResult TestSms(SliderModel model)
        {
            
            return View("Configure", model);
        }
    }
}