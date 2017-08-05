using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jewelry.DTO.Model.DTO
{
    public class ShoppingCartDTO
    {
        public int? CustomerID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public short Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductPhoto { get; set; }
        public decimal? Discount { get; set; }
        public short? UnitsInStock { get; set; }
        public decimal TotalPrice { get { return UnitPrice * Quantity; } }

    }
}