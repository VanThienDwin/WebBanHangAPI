﻿using Microsoft.AspNetCore.Http;
using SaleWebsiteAPI.Enums;
using SaleWebsiteAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebsiteAPI.Helper.Product
{
    public class ProductCreateRequest
    {
        public string name { get; set; }
        public int importPrice { get; set; }
        public int price { get; set; }

        public int sale { get; set; }
        public string description { get; set; }

        public ActionStatus status { get; set; }
        public Size? size { get; set; }
        public Color? color { get; set; }
        public int amount { get; set; }
        //

        public IEnumerable<IFormFile> images { get; set; }
        //foreign key
        public int? categoryId { get; set; }
        //
        public int? providerId { get; set; }
    }
}
