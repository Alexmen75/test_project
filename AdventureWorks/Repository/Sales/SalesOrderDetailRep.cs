using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.DataBase;
using AdventureWorks.Intrface;

namespace AdventureWorks.Repository.Sales
{
    class SalesOrderDetailRep : Repository<SalesOrderDetail>, IRepository<SalesOrderDetail>
    {
        public void Ceate(SalesOrderDetail item)
        {
            db.SalesOrderDetails.Add(item);
        }

        public void Delete(int id)
        {
            var SOD = Get(id);
            if (SOD !=null)
            {
                db.SalesOrderDetails.Remove(SOD);
            }
        }

        public SalesOrderDetail Get(int id)
        {
            return db.SalesOrderDetails.Find(id);
        }

        public IEnumerable<SalesOrderDetail> GetList()
        {
            return db.SalesOrderDetails;
        }
    }
}
