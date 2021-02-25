using SmartStore.Web.Framework;
using SmartStore.Web.Framework.Modelling;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SmartStore.LMS.Models
{
    public class SettingModel : ModelBase
    {
        [SmartResourceDisplayName("Plugins.LMS.Fields.Enabled")]
        public bool Enabled { get; set; }
    }
}