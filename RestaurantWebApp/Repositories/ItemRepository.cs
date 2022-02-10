using RestaurantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantWebApp.Repositories
{
    public class ItemRepository
    {


        private RestaurantDBEntities objRestaurantDBEntities;

        public ItemRepository()
        {

            objRestaurantDBEntities = new RestaurantDBEntities();
        }

        public IEnumerable<SelectListItem> GetAllItems()
        {

            IEnumerable<SelectListItem> objselectlistitem = new List<SelectListItem>();
            objselectlistitem = (from obj in objRestaurantDBEntities.Items
                                 select new SelectListItem()
                                 {
                                     Text = obj.ItemName,
                                     Value = obj.ItemID.ToString(),
                                     Selected = false



                                 }).ToList();


            return objselectlistitem;



        }
    }
}