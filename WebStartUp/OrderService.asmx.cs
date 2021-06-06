using AdventureWorks.DataBase;
using AdventureWorks.Repository.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using System.Web.Services;
using WebStartUp.DTO;
using NLog;

namespace WebStartUp
{
    /// <summary>
    /// Сводное описание для OrderService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class OrderService : System.Web.Services.WebService
    {
        private static  Logger DataLog = LogManager.GetLogger("serviceData");
        private static  Logger ErrorLog = LogManager.GetLogger("serviceError");
        public static void GetPrice(OrderDTO order)
        {
            ModelAW db = new ModelAW();
            try
            {
                decimal UnitPrice = db.ProductVendors
                    .Where(m => m.BusinessEntityID == order.Vendor && m.ProductID == order.ProductID)
                    .Select(m => m.StandardPrice)
                    .Single();
                order.UnitPrice = UnitPrice;
            }
            catch (System.InvalidOperationException ex)
            {
                order.UnitPrice = 20;
                ErrorLog.Error(ex.Message);
            }
        }

        public static void GetVendor(OrderDTO order)
        {
            ModelAW db = new ModelAW();
            try
            {
                var vendor = db.ProductVendors
                    .Where(m => m.ProductID == order.ProductID);
                if (vendor.Count() == 0)
                {
                    order.Vendor = 1552;
                }
                else
                {
                    order.Vendor = vendor.First().BusinessEntityID;
                }
            }
            catch(Exception ex)
            {
                ErrorLog.Error(ex.Message);
            }
            
            
        }
        [WebMethod]
        public void CreateOrder(string Email)
        {
            ModelAW db = new ModelAW();
            int UserID = db.EmailAddresses
               .Where(m => m.EmailAddress1 == Email)
               .First().BusinessEntityID;
            var orders = db.ShoppingCartItems
                .Include(m => m.Product.ProductInventories)
                .Where(m => m.Product.ProductInventories.Sum(c => c.Quantity) > 1 && UserID.ToString() == m.ShoppingCartID)
                .Select(m => new OrderDTO
                {
                    ProductID = m.ProductID,
                    Quantity = m.Quantity,
                    CartID = m.ShoppingCartItemID
                }).ToArray();
            //var orders = (from ShoppingCartItem Cart in db.ShoppingCartItems
            //             where Cart.ShoppingCartID == UserID.ToString()
            //              select new OrderDTO
            //              {
            //                  ProductID = Cart.ProductID,
            //                  Quantity = Cart.Quantity,
            //                  CartID = Cart.ShoppingCartItemID
            //              }).ToArray();
            foreach (var order in orders)
            {
                GetVendor(order);
                GetPrice(order);
            }
            var ord = orders.GroupBy(m => m.Vendor);
            foreach (var O in ord)
            {
                PurchaseOrderHeader newOrder = new PurchaseOrderHeader()
                {
                    PersonID = UserID,
                    VendorID = O.Key,
                    ModifiedDate = DateTime.Now,
                    OrderDate = DateTime.Now,
                    ShipMethodID = 1,
                    Status = 1
                };
                db.PurchaseOrderHeaders.Add(newOrder);
                db.SaveChanges();
                db.Entry(newOrder).Reload();
                foreach (var i in O)
                {
                    int id = newOrder.PurchaseOrderID;
                    PurchaseOrderDetail Order = new PurchaseOrderDetail()
                    {
                        PurchaseOrderID = id,
                        OrderQty = (short)i.Quantity,
                        ProductID = i.ProductID,
                        DueDate = DateTime.Now,
                        ReceivedQty = 0,
                        RejectedQty = 0,
                        UnitPrice = i.UnitPrice,
                        ModifiedDate = DateTime.Now
                    };
                    db.PurchaseOrderDetails.Add(Order);
                    ShoppingCartItemRep cartItemRep = new ShoppingCartItemRep();
                    cartItemRep.Delete(i.CartID);
                    DataLog.Info("Добавлен Заказ:  OrderID - " + id);
                }
                db.SaveChanges();
            }
            
        }
    }
}
