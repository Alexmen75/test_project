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
            int id = GetNewID();
            ModelAW db = new ModelAW();
            EmailAddress E = new EmailAddress() { rowguid = Guid.NewGuid(), BusinessEntityID = id, EmailAddress1 = "4753829@mail.ru", ModifiedDate = DateTime.Now };
            Customer C = new Customer() { PersonID = id, TerritoryID = 3, rowguid = Guid.NewGuid(), ModifiedDate = DateTime.Now };
            Person P = new Person()
            {
                rowguid = Guid.NewGuid(),
                FirstName = "test",
                LastName = "test",
                BusinessEntityID = id,
                ModifiedDate = DateTime.Now,
            };
            db.People.Add(P);
            db.Customers.Add(C);
            db.EmailAddresses.Add(E);
            db.SaveChanges();
        }
        public static int GetNewID()
        {
            ModelAW db = new ModelAW();
            int ID;
            BusinessEntity b = new BusinessEntity() { rowguid = Guid.NewGuid(), ModifiedDate = DateTime.Now };
            db.BusinessEntities.Add(b);
            //db.BusinessEntities.Reload(b);
            db.SaveChanges();
            ID = b.BusinessEntityID;
                //DataLog.Debug("Добавлена Сущьность BEntity: ID - " + ID);

            db.Dispose();
            return ID;
        }
    }
}
