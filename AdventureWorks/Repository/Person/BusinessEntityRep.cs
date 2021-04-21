using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.DataBase;
using AdventureWorks.Intrface;

namespace AdventureWorks.Repository.Person
{
    class BsinessEntityRep : Repository<BusinessEntity>, IRepository<BusinessEntity>
    {
        public void Ceate(BusinessEntity item)
        {
            db.BusinessEntities.Add(item);
        }

        public void Delete(int id)
        {
            var Business = Get(id);
            if (Business != null)
            {
                db.BusinessEntities.Remove(Business);
            }
        }

        public BusinessEntity Get(int id)
        {
            return db.BusinessEntities.Find(id);
        }

        public IEnumerable<BusinessEntity> GetList()
        {
            return db.BusinessEntities;
        }
    }
}
