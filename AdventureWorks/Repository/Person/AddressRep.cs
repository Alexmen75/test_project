using AdventureWorks.DataBase;
using AdventureWorks.Intrface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository.Person
{
    
    class AddressRep : Repository<Address>, IRepository<Address>
    {
        public void Ceate(Address item)
        {
            db.Addresses.Add(item);
        }

        public void Delete(int id)
        {
            var address = Get(id);
            if(address != null)
            {
                db.Addresses.Remove(address);
            }
        }

        public Address Get(int id)
        {
            return db.Addresses.Find(id);
        }

        public IEnumerable<Address> GetList()
        {
            return db.Addresses;
        }
    }
}
