using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.DataBase;
using AdventureWorks.Intrface;

namespace AdventureWorks.Repository.Person
{
    class BusinessEntityAddressRep : Repository<BusinessEntityAddress>, IRepository<BusinessEntityAddress>
    {
        public void Ceate(BusinessEntityAddress item)
        {
            db.BusinessEntityAddresses.Add(item);
        }

        public void Delete(int id)
        {
            var BEA = Get(id);
            if (BEA != null)
            {
                db.BusinessEntityAddresses.Remove(BEA);
            }
        }
        public BusinessEntityAddress Get(int id)
        {
            return db.BusinessEntityAddresses.Find(id);
        }

        public IEnumerable<BusinessEntityAddress> GetList()
        {
            return db.BusinessEntityAddresses;
        }
    }
}
