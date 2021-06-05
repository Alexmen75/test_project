using AdventureWorks.DataBase;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebStartUp.DTO;
using WebStartUp.Models;

namespace WebStartUp.Service
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "CustomerService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы CustomerService.svc или CustomerService.svc.cs в обозревателе решений и начните отладку.
    public class CustomerService : ICustomerService
    {
        private Logger DataLog = LogManager.GetLogger("serviceData");
        private Logger ErrorLog = LogManager.GetLogger("serviceError");
        int tryAgain = 0;
        public void CreateCustomer(RegisterViewModel model)
        {
            ModelAW db = new ModelAW();
            int id = GetNewID();
            try
            {
                EmailAddress E = new EmailAddress() { rowguid = Guid.NewGuid(), BusinessEntityID = id, EmailAddress1 = model.Email, ModifiedDate = DateTime.Now };
                Customer C = new Customer() { PersonID = id, TerritoryID = model.territoryID, rowguid = Guid.NewGuid(), ModifiedDate = DateTime.Now };
                Person P = new Person()
                {
                    rowguid = Guid.NewGuid(),
                    FirstName = model.Name,
                    LastName = model.LastName,
                    BusinessEntityID = id,
                    ModifiedDate = DateTime.Now,
                };
                db.People.Add(P);
                db.Customers.Add(C);
                db.EmailAddresses.Add(E);
                db.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                tryAgain += 1;
                ErrorLog.Error(ex.Source + " 43: "+ ex.Message + " " + ex.InnerException.Message);
                CreateCustomer(model,id);
            }
            DataLog.Info("Добавлен пользователь: " + db.EmailAddresses.Where(m=>m.BusinessEntityID == id).First().EmailAddress1);
        }
        public void CreateCustomer(RegisterViewModel model, int id)
        {
            ModelAW db = new ModelAW();
            try
            {
                EmailAddress E = new EmailAddress() { rowguid = Guid.NewGuid(), BusinessEntityID = id, EmailAddress1 = model.Email, ModifiedDate = DateTime.Now };
                Customer C = new Customer() { PersonID = id, TerritoryID = model.territoryID, rowguid = Guid.NewGuid(), ModifiedDate = DateTime.Now };
                Person P = new Person()
                {
                    rowguid = Guid.NewGuid(),
                    FirstName = model.Name,
                    LastName = model.LastName,
                    BusinessEntityID = id,
                    ModifiedDate = DateTime.Now,
                };
                db.People.Add(P);
                db.Customers.Add(C);
                db.EmailAddresses.Add(E);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tryAgain += 1;
                ErrorLog.Error(ex.Source + " 43: " + ex.Message);
                if(tryAgain<5)
                {
                    CreateCustomer(model, id);
                }
            }
        }
        public int GetNewID()
        {
            ModelAW db = new ModelAW();
            int ID=0;
            BusinessEntity b = new BusinessEntity() { rowguid = Guid.NewGuid(), ModifiedDate = DateTime.Now };
            try
            {
                db.BusinessEntities.Add(b);
                //db.BusinessEntities.Reload(b);
                db.SaveChanges();
                ID = b.BusinessEntityID;
                DataLog.Debug("Добавлена Сущьность BEntity: ID - " + ID);
            }
            catch(Exception ex)
            {
                ErrorLog.Error(ex.Source + " : " + ex.Message);
            }
            db.Dispose();
            return ID;
        }
        public List<TerritoryDTO> GetTerritories()
        {
            ModelAW db = new ModelAW();
            List<TerritoryDTO> territories = db.SalesTerritories
                .Select(m=> new TerritoryDTO
                {
                    Territory = m.Name,
                    TerritoryID = m.TerritoryID
                }).ToList();
            db.Dispose();
            return territories;
        }
    }
}
