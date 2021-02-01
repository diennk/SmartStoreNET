using SmartStore.Web.Framework;
using SmartStore.Web.Framework.Modelling;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SmartStore.Slider.Models
{
    public class SliderModel : ModelBase
    {
        [SmartResourceDisplayName("Plugins.Slider.Fields.Enabled")]
        public bool Enabled { get; set; }

        //[UIHint("Media"), AdditionalMetadata("album", "catalog")]
        //[SmartResourceDisplayName("Plugins.Slider.Fields.Picture")]
        //public string PictureId { get; set; }

        public IList<SlideSettingModel> Slides { get; set; } = new List<SlideSettingModel> 
        {
            new SlideSettingModel(),
            new SlideSettingModel(),
            new SlideSettingModel(),
            new SlideSettingModel(),
            new SlideSettingModel()
        };

        [SmartResourceDisplayName("Plugins.Slider.Fields.WidgetZone")]
        public string WidgetZone { get; set; }

    }

    public class SlideSettingModel
    {
        [UIHint("Media"), AdditionalMetadata("album", "slider")]
        [SmartResourceDisplayName("Plugins.Slider.Fields.Picture")]
        public int? PictureId { get; set; }

        [SmartResourceDisplayName("Plugins.Slider.Fields.Link")]
        public string Link { get; set; }
    }
    public class SlideModel
    {
        public string PictureUrl { get; set; }

        public string Link { get; set; }
    }

    public class SliderRenderModel
    {
        public IList<SlideModel> SlideModels { get; set; }
    }
}