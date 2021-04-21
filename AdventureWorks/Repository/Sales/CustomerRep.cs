using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.DataBase;
using AdventureWorks.Intrface;

namespace AdventureWorks.Repository.Sales
{
    class CustomerRep : Repository<Customer>, IRepository<Customer>
    {
        public void Ceate(Customer item)
        {
            db.Customers.Add(item);
        }

        public void Delete(int id)
        {
            var Customer = Get(id);
            if ( Customer != null)
            {
                db.Customers.Remove(Customer);
            }
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        public IEnumerable<Customer> GetList()
        {
            return db.Customers;
        }
    }
}
