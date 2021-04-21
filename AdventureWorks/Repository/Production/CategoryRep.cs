
using AdventureWorks.DataBase;
using AdventureWorks.Intrface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Repository
{
   public class CategoryRep : IRepository<ProductCategory>
    {
        private ModelAW db;

        public CategoryRep()
        {
            this.db = new ModelAW();
            
        }

        public void Ceate(ProductCategory item)
        {
            db.ProductCategories.Add(item);
        }

        public void Delete(int id)
        {
            ProductCategory cat = db.ProductCategories.Find(id);
            if(cat != null)
            {
                db.ProductCategories.Remove(cat);
            }
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
        public ProductCategory Get(int id)
        {
            return db.ProductCategories.Find(id);
        }

        public IEnumerable<ProductCategory> GetList()
        {
            return db.ProductCategories;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(ProductCategory item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
