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
            var Order = db.PurchaseOrderHeaders.Where(m => m.PurchaseOrderID == 4027).First();
            Order.Status = 2;
            db.SaveChanges();
        }
       
    }
}
