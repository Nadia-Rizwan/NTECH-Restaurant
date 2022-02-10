using RestaurantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantWebApp.Repositories
{
    public class CustomerRepository
    {


        private RestaurantDBEntities objRestaurantDBEntities;

        public CustomerRepository()
        {

            objRestaurantDBEntities = new RestaurantDBEntities();
        }

        public IEnumerable<SelectListItem> GetAllCustomers()
        {

            IEnumerable<SelectListItem> objselectlistitem = new List<SelectListItem>();
            objselectlistitem = (from obj in objRestaurantDBEntities.Customers
                                 select new SelectListItem()
                                 {
                                     Text = obj.CustomerName,
                                     Value = obj.CustomerID.ToString(),
                                     Selected = false



                                 }).ToList();


            return objselectlistitem;



        }
    }






}
