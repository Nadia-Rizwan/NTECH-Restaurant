using RestaurantWebApp.Models;
using RestaurantWebApp.Repositories;
using RestaurantWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantWebApp.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantDBEntities objRestaurantDBEntities;

        public HomeController()
        {
            objRestaurantDBEntities = new RestaurantDBEntities();

        }


        // GET: Home
        public ActionResult Index()
        {

            CustomerRepository objcustomerRepository = new CustomerRepository();
            ItemRepository objItemRepository = new ItemRepository();
            PaymentTypeRepository objPaymentTypeRepository = new PaymentTypeRepository();

            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>,IEnumerable<SelectListItem>>
                (objcustomerRepository.GetAllCustomers(), objItemRepository.GetAllItems(), objPaymentTypeRepository.GetAllPaymentTypes());

            return View(objMultipleModels);
        }

        [HttpGet]
        public JsonResult getItemUnitprice(int itemId)
        {
            decimal UnitPrice = objRestaurantDBEntities.Items.Single(model => model.ItemID == itemId).ItemPrice;


            return Json(UnitPrice, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
         public JsonResult Index(OrderViewModel objorderViewModel) {


            OrderRepository objorderRepository = new OrderRepository();
            objorderRepository.AddOrder(objorderViewModel);
           return Json( "Order has  been successfully placed", JsonRequestBehavior.AllowGet);



        }
             
    }
}