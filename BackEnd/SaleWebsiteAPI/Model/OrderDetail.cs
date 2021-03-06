﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebsiteAPI.Model
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public int unitPrice { get; set; }
        public int sale { get; set; }
        //foreign key
        public int productId { get; set; }
        public Product product { get; set; }
        //foreign key
        public int orderId { get; set; }
        public Order order { get; set; }
    }
}
