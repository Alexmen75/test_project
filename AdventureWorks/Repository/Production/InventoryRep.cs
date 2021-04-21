using AdventureWorks.DataBase;
using AdventureWorks.Intrface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository.Production
{
    class InventoryRep : Repository<ProductInventory>, IRepository<ProductInventory>
    {
        public void Ceate(ProductInventory item)
        {
            db.ProductInventories.Add(item);
        }

        public void Delete(int id)
        {
            ProductInventory Inv = Get(id);
            if(Inv != null)
            {
                db.ProductInventories.Remove(Inv);
            }
        }

        public ProductInventory Get(int id)
        {
            return db.ProductInventories.Find(id);
        }

        public IEnumerable<ProductInventory> GetList()
        {
            return db.ProductInventories;
        }
    }
}
