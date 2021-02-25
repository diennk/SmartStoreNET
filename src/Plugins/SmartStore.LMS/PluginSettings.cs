using SmartStore.Core.Configuration;
using SmartStore.LMS.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SmartStore.LMS
{
    public class PluginSettings : ISettings
    {
        /// <summary>
        /// Gets or sets the value indicting whether this Plugin is enabled
        /// </summary>
        public bool Enabled { get; set; }
    }
}