using AdventureWorks.Intrface;
using AdventureWorks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository.Production
{
    class PriceHistoryRep : Repository<ProductListPriceHistory>, IRepository<ProductListPriceHistory>
    {
        public void Ceate(ProductListPriceHistory item)
        {
            db.ProductListPriceHistories.Add(item);
        }

        public void Delete(int id)
        {
            var PriceHis = Get(id);
            if (PriceHis != null)
            {
                db.ProductListPriceHistories.Remove(PriceHis);
            }
        }
        public ProductListPriceHistory Get(int id)
        {
            return db.ProductListPriceHistories.Find(id);
        }

        public IEnumerable<ProductListPriceHistory> GetList()
        {
            return db.ProductListPriceHistories;
        }
    }
}
