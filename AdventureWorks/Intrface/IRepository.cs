using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Intrface
{
    interface IRepository<E> : IDisposable
        where E : class
    {
        IEnumerable<E> GetList();
        E Get(int id);
        //void GetList();
        void Update(E item);
        void Ceate(E item);
        void Delete(int id);
        void Save();
    }
}
