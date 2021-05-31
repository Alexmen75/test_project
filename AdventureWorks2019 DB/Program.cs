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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            BusinessEntity b = new BusinessEntity() { rowguid = Guid.NewGuid(), ModifiedDate = DateTime.Now };
            ModelAW db = new ModelAW();
            db.BusinessEntities.Add(b);
            db.SaveChanges();
            db.Entry(b).Reload();
            int id = b.BusinessEntityID;
            Person P = new Person() { rowguid = Guid.NewGuid(), FirstName ="Alex", LastName = "Belov", BusinessEntityID = id, ModifiedDate = DateTime.Now };
            EmailAddress E = new EmailAddress() { rowguid = Guid.NewGuid(), BusinessEntityID = id, EmailAddress1 = "jepppa@mail.ru", ModifiedDate = DateTime.Now };
            Customer C = new Customer() { PersonID = id, TerritoryID =10, rowguid = Guid.NewGuid(), ModifiedDate = DateTime.Now };
            db.People.Add(P);
            db.EmailAddresses.Add(E);
            db.Customers.Add(C);
            db.SaveChanges();
            db.Dispose();
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds);
            Console.WriteLine("SYNC RunTime " + elapsedTime);
        }
       
    }
}
