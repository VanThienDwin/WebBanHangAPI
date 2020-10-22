using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebsiteAPI.Exception
{
    public class ShopException : System.Exception
    {
        public ShopException()
        {
        }

        public ShopException(string message)
            : base(message)
        {
        }

        public ShopException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
