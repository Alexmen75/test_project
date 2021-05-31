using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStartUp.DTO
{
    public class OrderDTO
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int Vendor { get; set; }
        public int CartID { get; set; }
        public decimal UnitPrice { get; set; }
    }
}