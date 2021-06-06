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
using System.Data.SqlClient;

namespace AdventureWorks2019_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelAW db = new ModelAW();
            string Conect = "Data Source=DESKTOP-0R2DTHM;Initial Catalog=AdventureWorks2019;Integrated Security=True;App=EntityFramework";
            string Get = "select prod.ProductID, prod.Name,sum(inv.Quantity),photo.ThumbNailPhoto " +
"from (" +
  "SELECT " +
    "ROW_NUMBER() OVER (ORDER BY ProductID ASC) AS rownumber, " +
    "ProductID, ProductPhotoID " +
  "FROM Production.ProductProductPhoto " +
") AS info " +
"join Production.Product prod on prod.ProductID = info.ProductID " +
"join Production.ProductPhoto photo on info.ProductPhotoID = photo.ProductPhotoID " +
"join Production.ProductInventory inv on inv.ProductID = info.ProductID " +
"where Quantity>0 or Quantity - (Select sum(D.OrderQty) " +
"				from Purchasing.PurchaseOrderDetail D " +
"				join Purchasing.PurchaseOrderHeader H on H.PurchaseOrderID = D.PurchaseOrderID " +
"				where Status = 1  and prod.ProductID = D.ProductID " +
"				group by ProductID) > 0 " +
"group by rownumber, prod.ProductID, prod.Name, photo.ThumbNailPhoto " +
                "Having (rownumber>@START and rownumber<@STOP) ";
            using (SqlConnection connect = new SqlConnection(Conect))
            {
                SqlCommand command = new SqlCommand(Get, connect);
                connect.Open();
                command.Parameters.AddWithValue("@START", 0);
                command.Parameters.AddWithValue("@STOP", 100);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine(reader[i] + "\t");
                    }
                }
            }
            //var products = db.ProductProductPhotoes
            //                  .Include(m => m.Product)
            //                  .Include(m => m.Product.ProductInventories)
            //                  .Include(m => m.ProductPhoto)
            //                  .Where(m => ((m.Product.ProductInventories.Sum(c => c.Quantity) -
            //                  (from PurchaseOrderDetail Detail in db.PurchaseOrderDetails
            //                   join PurchaseOrderHeader Header in db.PurchaseOrderHeaders on Detail.PurchaseOrderID equals Header.PurchaseOrderID
            //                   where Detail.ProductID == m.ProductID && Header.Status == 1
            //                   select Detail.OrderQty).Sum(v => v)
            //                  ) > 1) || (m.Product.ProductInventories.Where(c => c.ProductID == m.ProductID).Sum(c => c.Quantity) > 0))
            //                  .OrderBy(m => m.ProductID)
            //                  .Skip(0)
            //                  .Take(50)
            //                  .Select(m => new ProductDTO
            //                  {
            //                      ProductName = m.Product.Name,
            //                      ThumbNailPhoto = m.ProductPhoto.ThumbNailPhoto,
            //                      ThumbNailPhotoFileName = m.ProductPhoto.ThumbnailPhotoFileName,
            //                      ProductID = m.ProductID,
            //                  });
            //foreach (var p in products)
            //{
            //    Console.WriteLine(p.ProductID+ "    :   "+ p.ProductName);
            //}
            //Console.WriteLine(products.Count());
        }
      
    }
}
