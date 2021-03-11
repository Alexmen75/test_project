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
     class Product
    {
       

        public int SKU;
        public string name;
        public decimal cost;
        public string description;
        public Storage storage;
        //List<Storage> storages = new List<Storage>();

    }
    class Liquid : Product
    {
       public Unit unit = Unit.L;
        Random rand = new Random();
        public Liquid(int code, string n, decimal c, string d, Storage s)
        {
            this.SKU = code;
            this.name=n;
            this.cost=c;
            this.description=d;
            this.storage=s;
            if (s is OpenStorage open)
            {
                open.Add_product(this, rand.Next(0, 30));
            }
            else if( s is ClosedStorage closed)
            {
                closed.Add_product(this, rand.Next(0,30));
            }
        }
    }
    class Granular : Product
    {
       public Unit unit = Unit.Kg;
        Random rand = new Random();
        public Granular(int code, string n, decimal c, string d, Storage s)
        {
            this.SKU = code;
            this.name = n;
            this.cost = c;
            this.description = d;
            this.storage = s;
            if (s is OpenStorage open)
            {
                open.Add_product(this, rand.Next(0, 30));
            }
            else if (s is ClosedStorage closed)
            {
                closed.Add_product(this, rand.Next(0, 30));
            }
        }
    }
    class Solid : Product
    {
       public Unit unit = Unit.Pc;
        Random rand = new Random();
        public Solid(int code, string n, decimal c, string d, Storage s)
        {
            this.SKU = code;
            this.name = n;
            this.cost = c;
            this.description = d;
            this.storage = s;
            if (s is OpenStorage open)
            {
                open.Add_product(this, rand.Next(0, 30));
            }
            else if (s is ClosedStorage closed)
            {
                closed.Add_product(this, rand.Next(0, 30));
            }
        }
    }
}
