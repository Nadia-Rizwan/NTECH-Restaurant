using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

using RestaurantWebApp.Models;
using System.Web.Mvc;

namespace RestaurantWebApp.Repositories
{
    public class PaymentTypeRepository
    {

        private RestaurantDBEntities objRestaurantDBEntities;

        public PaymentTypeRepository()
        {

            objRestaurantDBEntities = new RestaurantDBEntities();
    }

public IEnumerable<SelectListItem> GetAllPaymentTypes()
        {

            IEnumerable<SelectListItem> objselectlistitem = new List<SelectListItem>();
            objselectlistitem = (from obj in objRestaurantDBEntities.PaymentTypes
                                 select new SelectListItem() { 
                                  Text=obj.PaymentTypeName,
                                  Value=obj.PaymentTypeID.ToString(),
                                  Selected=true
                                 
                                 
                                 
                                 }).ToList();


            return objselectlistitem;



        }
    


} 



}