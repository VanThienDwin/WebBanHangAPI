﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebsiteAPI.Helper.Product
{
    public class ProductPagingRequest
    {
        public SearchProductRequest search { get; set; }
        public int pageCurrent { get; set; }
        public int pageSize { get; set; }
    }
}
