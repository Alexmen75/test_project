using System;
using AdventureWorks.DataBase;
using AdventureWorks.Intrface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository.Production
{
    class ProductPhotoRep : Repository<ProductProductPhoto>, IRepository<ProductProductPhoto>
    {
        public void Ceate(ProductProductPhoto item)
        {
            db.ProductProductPhotoes.Add(item);
        }

        public void Delete(int id)
        {
            var Photo = Get(id);
            if (Photo != null)
            {
                db.ProductProductPhotoes.Remove(Photo);
            }
        }

        public ProductProductPhoto Get(int id)
        {
            return db.ProductProductPhotoes.Find(id);
        }

        public IEnumerable<ProductProductPhoto> GetList()
        {
            return db.ProductProductPhotoes;
        }
    }
}
