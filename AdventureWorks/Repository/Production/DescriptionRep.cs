using AdventureWorks.Intrface;
using AdventureWorks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AdventureWorks.Repository.Production
{
    public class DescriptionRep : Repository<ProductDescription>, IRepository<ProductDescription>
    {
        public void Ceate(ProductDescription item)
        {
            db.ProductDescriptions.Add(item);
        }

        public void Delete(int id)
        {
            ProductDescription Desc = Get(id);
            if(Desc != null)
            {
                db.ProductDescriptions.Remove(Desc);
            }
        }

        public ProductDescription Get(int id)
        {
            return db.ProductDescriptions.Find(id);
        }

        public IEnumerable<ProductDescription> GetList()
        {
            return db.ProductDescriptions;
        }

    }
}
