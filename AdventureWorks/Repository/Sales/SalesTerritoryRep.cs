using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.DataBase;
using AdventureWorks.Intrface;

namespace AdventureWorks.Repository.Sales
{
    class SalesTerritoryRep : Repository<SalesTerritory>, IRepository<SalesTerritory>
    {
        public void Ceate(SalesTerritory item)
        {
            db.SalesTerritories.Add(item);
        }

        public void Delete(int id)
        {
            var Terr = Get(id);
            if(Terr !=null)
            {
                db.SalesTerritories.Remove(Terr);
            }
        }

        public SalesTerritory Get(int id)
        {
            return db.SalesTerritories.Find(id);
        }

        public IEnumerable<SalesTerritory> GetList()
        {
            return db.SalesTerritories;
        }
    }
}
