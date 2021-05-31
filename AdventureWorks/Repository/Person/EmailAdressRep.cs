using AdventureWorks.DataBase;
using AdventureWorks.Intrface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository.Person
{
  public  class EmailAdressRep : Repository<EmailAddress>, IRepository<EmailAddress>
    {
        public void Ceate(EmailAddress item)
        {
            db.EmailAddresses.Add(item);
        }

        public void Delete(int id)
        {
            var Email = Get(id);
            if (Email != null)
            {
                db.EmailAddresses.Remove(Email);
            }
        }

        public EmailAddress Get(int id)
        {
            return db.EmailAddresses.Find(id);
        }
        public int GetID(string Email)
        {
            int id = db.EmailAddresses.Where(E => E.EmailAddress1 == Email).Select(E => E.BusinessEntityID).FirstOrDefault();
            return id;
        }

        public IEnumerable<EmailAddress> GetList()
        {
            return db.EmailAddresses;
        }
    }
}
