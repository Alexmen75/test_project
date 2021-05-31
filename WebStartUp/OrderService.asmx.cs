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
            }
        }

        public static void GetVendor(OrderDTO order)
        {
            ModelAW db = new ModelAW();
            try
            {
                int vendor = db.ProductVendors
                    .Where(m => m.ProductID == order.ProductID)
                    .FirstOrDefault().BusinessEntityID;
                order.Vendor = vendor;
            }
            catch(System.NullReferenceException ex)
            {
                order.Vendor = 1522;
            }
            
            
        }
        [WebMethod]
        public void CreateOrder(int CustomerID)
        {
            ModelAW db = new ModelAW();
            var orders = (from ShoppingCartItem Cart in db.ShoppingCartItems
                         where Cart.ShoppingCartID == CustomerID.ToString()
                          select new OrderDTO
                          {
                              ProductID = Cart.ProductID,
                              Quantity = Cart.Quantity,
                              CartID = Cart.ShoppingCartItemID
                          }).ToArray();
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
                    PersonID = CustomerID,
                    VendorID = O.Key,
                    ModifiedDate = DateTime.Now,
                    OrderDate = DateTime.Now,
                    ShipMethodID = 1
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
                    db.SaveChanges();
                }
            }
        }
        
    }
}
