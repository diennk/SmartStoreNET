using SmartStore.Core.Configuration;
using SmartStore.Slider.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SmartStore.Slider
{
    public class SliderSettings : ISettings
    {
        /// <summary>
        /// Gets or sets the value indicting whether this Slider is enabled
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the slides
        /// </summary>
        public string Json { get; set; }
        public string WidgetZone { get;  set; }
    }
}