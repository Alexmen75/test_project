using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.DataBase;
using AdventureWorks.Intrface;
namespace AdventureWorks.Repository.Sales
{
    class SalesPersonRep : Repository<SalesPerson>, IRepository<SalesPerson>
    {
        public void Ceate(SalesPerson item)
        {
            db.SalesPersons.Add(item);
        }

        public void Delete(int id)
        {
            var Person = Get(id);
            if(Person != null)
            {
                db.SalesPersons.Remove(Person);
            }    
        }

        public SalesPerson Get(int id)
        {
            return db.SalesPersons.Find(id);
        }

        public IEnumerable<SalesPerson> GetList()
        {
            return db.SalesPersons;
        }
    }
}
