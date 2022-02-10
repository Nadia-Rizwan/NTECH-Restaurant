using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantWebApp.ViewModels
{
    public class OrderViewModel
    {
      public int OrderId { get; set; }
        public int CustomerID { get; set; }
        public int PaymentTypeID { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OredrDate { get; set; }
        public decimal FinalTotal { get; set; }
        public IEnumerable<OrderDetailviewModel> ListofOrderDetailViewModel { get; set; }





    }
}