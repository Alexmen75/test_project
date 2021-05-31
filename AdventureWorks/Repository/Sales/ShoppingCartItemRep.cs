using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.DataBase;
using AdventureWorks.Intrface;

namespace AdventureWorks.Repository.Sales
{
    public class ShoppingCartItemRep : Repository<ShoppingCartItem>, IRepository<ShoppingCartItem>
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
                db.SaveChanges();
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

        public IEnumerable<ShoppingCartItem> GetList(Expression<Func<ShoppingCartItem, bool>> predicate)
        {
            return db.ShoppingCartItems.Where(predicate);
        }
    }
}
