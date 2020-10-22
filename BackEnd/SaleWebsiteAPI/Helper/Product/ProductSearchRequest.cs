using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebsiteAPI.Helper.Product
{
    public class ProductSearchRequest
    {
        public int? categoryId { get; set; }
        public int? providerId { get; set; }
        public string? searchKey { get; set; }
    }
}
