using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.DataBase;
using AdventureWorks.Intrface;

namespace AdventureWorks.Repository.Sales
{
    class ShoppingCartItemRep : Repository<ShoppingCartItem>, IRepository<ShoppingCartItem>
    {
        public void Ceate(ShoppingCartItem item)
        {
            db.ShoppingCartItems.Add(item);
        }

        public void Delete(int id)
        {
            var Items = Get(id);
            if (Items != null)
            {
                db.ShoppingCartItems.Remove(Items);
            }
        }

        public ShoppingCartItem Get(int id)
        {
            return db.ShoppingCartItems.Find(id);
        }

        public IEnumerable<ShoppingCartItem> GetList()
        {
            return db.ShoppingCartItems;
        }
    }
}
