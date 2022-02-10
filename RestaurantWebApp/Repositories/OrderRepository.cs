using RestaurantWebApp.Models;
using RestaurantWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace RestaurantWebApp.Repositories
{
    public class OrderRepository
    {
        private RestaurantDBEntities objRestaurantDBEntities;
        public OrderRepository()
        {

            objRestaurantDBEntities = new RestaurantDBEntities();
        }

        public bool AddOrder(OrderViewModel objorderViewModel)
        {

            using (DbContextTransaction dbTran = objRestaurantDBEntities.Database.BeginTransaction()) 
            { 
            
            try {
                    Order objorder = new Order();
                    objorder.CustomerID = objorderViewModel.CustomerID;
                    objorder.FinalTotal = objorderViewModel.FinalTotal;
                    objorder.OredrDate = DateTime.Now;
                    objorder.OrderNumber = string.Format("{0:ddmmmyyyyhhmmss}", DateTime.Now);
                    objorder.PaymentTypeID = objorderViewModel.PaymentTypeID;
                    objRestaurantDBEntities.Orders.Add(objorder);
                    //objRestaurantDBEntities.SaveChanges();
               
                    int orderid = objorder.OrderId;
                    foreach (var item in objorderViewModel.ListofOrderDetailViewModel)
                    {
                        OrderDetail objorderDetail = new OrderDetail();
                        objorderDetail.OrderId = orderid;
                        objorderDetail.Discount = item.Discount;
                        objorderDetail.ItemID = item.ItemID;
                        objorderDetail.Total = item.Total;
                        objorderDetail.UnitPrice = item.UnitPrice;
                        objorderDetail.Quantity = item.quantity;
                        objRestaurantDBEntities.OrderDetails.Add(objorderDetail);
                        //objRestaurantDBEntities.SaveChanges();

                        Transaction objtransaction = new Transaction();
                        objtransaction.ItemID = item.ItemID;
                        objtransaction.Quantity = (-1) * item.quantity;
                        objtransaction.TransactionDate = DateTime.Now;
                        objtransaction.TypeId = 2;
                        objRestaurantDBEntities.Transactions.Add(objtransaction);
                        objRestaurantDBEntities.SaveChanges();
                        dbTran.Commit();
                    }


                }
                catch (DbEntityValidationException ex)
                {
                    dbTran.Rollback();
                    throw;
                }
            
            
            
            
            }
           
            return true;
        }


    }
}