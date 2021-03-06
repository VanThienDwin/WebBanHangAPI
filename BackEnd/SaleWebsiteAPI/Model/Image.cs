﻿using SaleWebsiteAPI.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebsiteAPI.Model
{
    public class Image
    {
        public int id { get; set; }
        public string urlImage { get; set; }
        [DefaultValue(ActionStatus.Display)]
        public ActionStatus status { get; set; }
        public int? productId { get; set; }
        public Product product { get; set; }
    }
}
