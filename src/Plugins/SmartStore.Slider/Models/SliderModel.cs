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

        public IList<SlideModel> Slides { get; set; } = new List<SlideModel> 
        {
            new SlideModel(),
            new SlideModel(),
            new SlideModel(),
            new SlideModel(),
            new SlideModel()
        };
    }

    public class SlideModel
    {
        [UIHint("Media"), AdditionalMetadata("gallery", "slider")]
        [SmartResourceDisplayName("Plugins.Slider.Fields.Picture")]
        public string PictureId { get; set; }

        [SmartResourceDisplayName("Plugins.Slider.Fields.Link")]
        public string Link { get; set; }
    }
}