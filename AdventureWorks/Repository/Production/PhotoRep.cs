using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.DataBase;
using AdventureWorks.Intrface;

namespace AdventureWorks.Repository.Production
{
    class PhotoRep : Repository<ProductPhoto>, IRepository<ProductPhoto>

    {
        public void Ceate(ProductPhoto item)
        {
            db.ProductPhotoes.Add(item);
        }
         
        public void Delete(int id)
        {
            var Photo = Get(id);
            if (Photo != null)
            {
                db.ProductPhotoes.Remove(Photo);
            }
        }

        public ProductPhoto Get(int id)
        {
            return db.ProductPhotoes.Find(id);
        }

        public IEnumerable<ProductPhoto> GetList()
        {
            return db.ProductPhotoes;
        }
    }
}
