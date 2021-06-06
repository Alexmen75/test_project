using AdventureWorks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.Repository.Production;
using AdventureWorks.Repository;
using System.Data.Entity;
using System.Data.Entity.Validation;
using Ubiety.Dns.Core;
using System.Data.Entity.Infrastructure;
using WebStartUp.DTO;
using System.Diagnostics;
using AdventureWorks2019_DB.ServiceReference1;

namespace AdventureWorks2019_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelAW db = new ModelAW();
            var products = db.ProductProductPhotoes
                  .Include(m => m.Product)
                  .Include(m => m.Product.ProductInventories)
                  .Include(m => m.ProductPhoto)
                  .Where(m => (m.Product.ProductInventories.Sum(c => c.Quantity) -
                  (from PurchaseOrderDetail Detail in db.PurchaseOrderDetails
                   join PurchaseOrderHeader Header in db.PurchaseOrderHeaders on Detail.PurchaseOrderID equals Header.PurchaseOrderID
                   where Detail.ProductID == m.ProductID && Header.Status == 1
                   select Detail.OrderQty).Sum(v => v)
                  ) > 1 || (from PurchaseOrderDetail Detail in db.PurchaseOrderDetails
                            join PurchaseOrderHeader Header in db.PurchaseOrderHeaders on Detail.PurchaseOrderID equals Header.PurchaseOrderID
                            where Header.Status == 1 && Detail.ProductID == m.ProductID
                            select Detail.PurchaseOrderDetailID).Count()==0)
                  .OrderBy(m => m.ProductID)
                  .Skip(0 * 50)
                  .Take(50)
                  .Select(m => new ProductDTO
                  {
                      ProductName = m.Product.Name,
                      ThumbNailPhoto = m.ProductPhoto.ThumbNailPhoto,
                      ThumbNailPhotoFileName = m.ProductPhoto.ThumbnailPhotoFileName,
                      ProductID = m.ProductID,
                      ProductOnInventory = m.Product.ProductInventories.Sum(c => c.Quantity)
                  });
            var prod = (from PurchaseOrderDetail Detail in db.PurchaseOrderDetails
                        join PurchaseOrderHeader Header in db.PurchaseOrderHeaders on Detail.PurchaseOrderID equals Header.PurchaseOrderID
                        where Detail.ProductID == 1 && Header.Status == 1
                        select Detail.OrderQty).Sum(v => v);
            Console.WriteLine(prod);
            foreach(var i in products)
            {
                Console.WriteLine(i.ProductID + "    "+i.ProductName + " Количество  " + i.ProductOnInventory);
            }
        }
      
    }
}
