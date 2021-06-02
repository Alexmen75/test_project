using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AdventureWorks.DataBase;

namespace OrderManager
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string SendOeder()
        {
            ModelAW db = new ModelAW();
            var Order = db.PurchaseOrderHeaders.Where(m => m.Status == 2 && m.PurchaseOrderID >4020 );
            foreach (var ord in Order)
            {
                ord.Status = 3;
                ord.ShipDate = DateTime.Now;
            }
            
            string massege = "Отправленно заказов:" + Order.Count();
            db.SaveChanges();
            db.Dispose();
            return massege;
        }

        public string SetManager()
        {
            ModelAW db = new ModelAW();
            ModelAW db2 = new ModelAW();
            var Order = db.PurchaseOrderHeaders.Where(m => m.EmployeeID == 0);
            var Customer = db.Customers;
            foreach (var Ord in Order)
            {
                int PersonID = Ord.PersonID;
                int? Territory = db2.Customers.Find(PersonID).TerritoryID;
                decimal? MinSales = db2.SalesPersons
                    .Where(M => M.TerritoryID == Territory)
                    .Min(M => M.SalesQuota);
                int EmployeeID = db2.SalesPersons.Where(m => m.TerritoryID == Territory && m.SalesQuota == MinSales).First().BusinessEntityID;
                Ord.Status = 2;
                Ord.EmployeeID = EmployeeID;

            }
            
            string massege = "назначенно менеджеров :" + Order.Count();
            db.SaveChanges();
            db.Dispose();
            return massege;
        }
    }
}
