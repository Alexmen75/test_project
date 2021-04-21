using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.DataBase;
using AdventureWorks.Intrface;

namespace AdventureWorks.Repository.Sales
{
    class SalesOrderHeaderRep : Repository<SalesOrderHeader>, IRepository<SalesOrderHeader>
    {
        public void Ceate(SalesOrderHeader item)
        {
            db.SalesOrderHeaders.Add(item);
        }

        public void Delete(int id)
        {
            var SOH = Get(id);
            if (SOH != null)
            {
                db.SalesOrderHeaders.Remove(SOH);
            }
        }

        public SalesOrderHeader Get(int id)
        {
            return db.SalesOrderHeaders.Find(id);
        }

        public IEnumerable<SalesOrderHeader> GetList()
        {
            return db.SalesOrderHeaders;
        }
    }
}
