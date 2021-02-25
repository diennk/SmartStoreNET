﻿using SmartStore.Web.Framework.Modelling;

namespace SmartStore.LMS.Models
{
    [CustomModelPart]
    public class AdminEditTabModel : ModelBase
    {
        public int EntityId { get; set; }

        public string EntityName { get; set; }

        public bool IsActive { get; set; }
    }
}