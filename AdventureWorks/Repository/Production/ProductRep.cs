using AdventureWorks.DataBase;
using AdventureWorks.Intrface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository.Production
{
   public class ProductRep : Repository<Product>, IRepository<Product>
    {
        public void Ceate(Product product)
        {
            db.Products.Add(product);
        }

        public void Delete(int id)
        {
            Product prod = db.Products.Find(id);
            if(prod != null)
            {
                db.Products.Remove(prod);
            }
        }
        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<Product> GetList()
        {
            return db.Products;
        }
        //public IEnumerable<Product> GetList(Expression<Predicate<Product>> predicate)
        //{
        //    return predicate;
        //}

    }
}
