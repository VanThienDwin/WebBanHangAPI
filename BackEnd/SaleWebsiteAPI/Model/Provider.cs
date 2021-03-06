﻿using SaleWebsiteAPI.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebsiteAPI.Model
{
    public class Provider
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [DefaultValue(ActionStatus.Display)]
        public ActionStatus status { get; set; }
    }
}
