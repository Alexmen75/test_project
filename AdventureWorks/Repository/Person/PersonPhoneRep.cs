using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.DataBase;
using AdventureWorks.Intrface;

namespace AdventureWorks.Repository.Person
{
    class PersonPhoneRep : Repository<PersonPhone>, IRepository<PersonPhone>
    {
        public void Ceate(PersonPhone item)
        {
            db.PersonPhones.Add(item);
        }

        public void Delete(int id)
        {
            var Phone = Get(id);
            if (Phone != null)
            {
                db.PersonPhones.Remove(Phone);
            }

        }

        public PersonPhone Get(int id)
        {
            return db.PersonPhones.Find(id);
        }

        public IEnumerable<PersonPhone> GetList()
        {
            return db.PersonPhones;
        }
    }
}
