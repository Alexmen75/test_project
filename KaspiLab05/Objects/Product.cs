using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Objects
{
    enum Unit
    {
        L,
        Kg,
        Pc
    }
    abstract class Product
    {
        Random rand = new Random();

        public int SKU;
        public string name;
        public decimal cost;
        public string description;
        public Storage storage;
        List<Storage> storages = new List<Storage>();
        public Product()
        {
            if(storage is ClosedStorage closed)// я понял, почему это не работает , но не могу понять, как сделать так, что б работало 
            {
                closed.Add_product(this, rand.Next(15,100));
            }
            else if(storage is OpenStorage open)
            {
                open.Add_product(this, rand.Next(15, 100));
            }
            storages.Add(storage);
            storage = null;
        }
    }
    class Liquid : Product
    {
       public Unit unit = Unit.L;
    }
    class Granular : Product
    {
       public Unit unit = Unit.Kg;
    }
    class Solid : Product
    {
       public Unit unit = Unit.Pc;
    }
}
