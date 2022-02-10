using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantWebApp.ViewModels
{
    public class OrderDetailviewModel
    {

        public int OrderDetailId { get; set; }
        public decimal quantity { get; set; }
        public int ItemID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }


    }
}