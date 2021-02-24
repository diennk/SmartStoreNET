using System;
using System.Web.Mvc;
using SmartStore.Slider.Models;
using SmartStore.ComponentModel;
using SmartStore.Core.Plugins;
using SmartStore.Web.Framework.Controllers;
using SmartStore.Web.Framework.Filters;
using SmartStore.Web.Framework.Security;
using SmartStore.Web.Framework.Settings;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using SmartStore.Services.Media;
using SmartStore.Core.Domain.Media;

namespace SmartStore.Slider.Controllers
{
    [AdminAuthorize]
    public class SliderController : PluginControllerBase
    {
        private readonly IPluginFinder _pluginFinder;
        private readonly SliderSettings _sliderSettings;
        private readonly IMediaService _mediaService;
        private readonly MediaSettings mediaSettings;

        public SliderController(IPluginFinder pluginFinder, SliderSettings sliderSettings, IMediaService mediaService, MediaSettings mediaSettings)
        {
            _pluginFinder = pluginFinder;
            _sliderSettings = sliderSettings;
            this._mediaService = mediaService;
            this.mediaSettings = mediaSettings;
        }

        [LoadSetting]
        public ActionResult Configure(SliderSettings settings)
        {
            var model = new SliderModel();
            MiniMapper.Map(settings, model);
            if (!string.IsNullOrEmpty(settings.Json))
            {
                model.Slides = JsonConvert.DeserializeObject<List<SlideSettingModel>>(settings.Json);
            }

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
            settings.Json = JsonConvert.SerializeObject(model.Slides);

            NotifySuccess(T("Admin.Common.DataSuccessfullySaved"));

            return RedirectToConfiguration(Slider.SystemName);
        }


        [ChildActionOnly]
        [AllowAnonymous]
        public ActionResult Render(string widgetZone)
        {
            var model = new SliderRenderModel();
            model.SlideModels = new List<SlideModel>();

            if (!string.IsNullOrEmpty(_sliderSettings.Json))
            {
                var settingModels = JsonConvert.DeserializeObject<List<SlideSettingModel>>(_sliderSettings.Json);
                foreach(var settingModel in settingModels)
                {
                    var file = _mediaService.GetFileById(settingModel.PictureId ?? 0, MediaLoadFlags.AsNoTracking);
                    var pictureUrl = _mediaService.GetUrl(file, mediaSettings.MaximumImageSize, null);
                    model.SlideModels.Add(new SlideModel
                    {
                        PictureUrl = pictureUrl,
                        Link = settingModel.Link
                    });
                }
            }
            return View(model);
        }
    }
}