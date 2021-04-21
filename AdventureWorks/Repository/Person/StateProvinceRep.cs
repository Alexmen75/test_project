using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.DataBase;
using AdventureWorks.Intrface;

namespace AdventureWorks.Repository.Person
{
    class StateProvinceRep : Repository<StateProvince>, IRepository<StateProvince>
    {
        public void Ceate(StateProvince item)
        {
            db.StateProvinces.Add(item);
        }

        public void Delete(int id)
        {
            var StateP = Get(id);
            if ( StateP != null)
            {
                db.StateProvinces.Remove(StateP);
            }
        }

        public StateProvince Get(int id)
        {
            return db.StateProvinces.Find(id);
        }

        public IEnumerable<StateProvince> GetList()
        {
            return db.StateProvinces;
        }
    }
}
