using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebsiteAPI.Helper.Product
{
    public class GetProductPagingRequest: PagingRequestBase
    {
        public string keyword { get; set; }
        public int? categoryId { get; set; }
    }
}
