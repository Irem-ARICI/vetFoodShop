﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetFoodShop.Order.Domain.Entities
{
    internal class Ordering
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
