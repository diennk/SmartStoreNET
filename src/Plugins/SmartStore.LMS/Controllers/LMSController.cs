using System;
using System.Web.Mvc;
using SmartStore.LMS.Models;
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
using SmartStore.Services;
using SmartStore.Services.Common;
using SmartStore.LMS.Settings;

namespace SmartStore.LMS.Controllers
{
    public class LMSController : AdminControllerBase
    {
        private readonly ICommonServices _services;
        private readonly IGenericAttributeService _genericAttributeService;

        public LMSController(
            ICommonServices services,
            IGenericAttributeService genericAttributeService)
        {
            _services = services;
            _genericAttributeService = genericAttributeService;
        }

        [AdminAuthorize]
        [ChildActionOnly]
        [LoadSetting]
        public ActionResult Configure(LMSSettings settings)
        {
            var model = new ConfigurationModel();
            MiniMapper.Map(settings, model);



            return View(model);
        }

        [HttpPost]
        [AdminAuthorize]
        [ChildActionOnly]
        [SaveSetting]
        public ActionResult Configure(LMSSettings settings, ConfigurationModel model, FormCollection form)
        {
            if (!ModelState.IsValid)
            {
                return Configure(settings);
            }


            MiniMapper.Map(model, settings);
            return RedirectToConfiguration("SmartStore.LMS");
        }




        [AdminAuthorize]
        public ActionResult AdminEditTab(int entityId, string entityName)
        {
            var model = new AdminEditTabModel();

            // Simple values can be stored and obtained as GenericAttributes. More complex values should implement their own domain objects.
            // Get saved value from GenericAttribute. (Value persitence can be found in the ModelBoundEventConsumer.)
            model.IsActive = _genericAttributeService.GetAttribute<bool>(entityName, entityId, "LMSIsActive");
            model.EntityId = entityId;
            model.EntityName = entityName;

            var result = PartialView(model);
            result.ViewData.TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "CustomProperties[LMS]" };
            return result;
        }

        public ActionResult ReplaceAdminLogo()
        {
            return View();
        }
    }
}