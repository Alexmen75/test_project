using AdventureWorks.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository
{
   public abstract class Repository<T> 
    {
        protected ModelAW db;
        public Repository()
        {
            this.db = new ModelAW();
        }
        public void Save()
        {
             db.SaveChanges();
        }
        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

    }
}
