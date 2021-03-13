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
        public static Random rand = new Random();
        public int SKU;
        public string name;
        public decimal cost;
        public string description;
        public Storage storage;
        public List<Storage> storages = new List<Storage>();

    }
    class Liquid : Product
    {
       public Unit unit = Unit.L;
        
        public Liquid(int code, string n, decimal c, string d,ref Storage s)
        {
            
            this.SKU = code;
            this.name=n;
            this.cost=c;
            this.description=d;
            this.storage=s;
            Product Prod = this;
            if (s is OpenStorage open)
            {
                open.Add_product(ref Prod , rand.Next(0, 30));
            }
            else if( s is ClosedStorage closed)
            {
                closed.Add_product(ref Prod, rand.Next(0,30));
            }
            storages.Add(s);
            
        }
    }
    class Granular : Product
    {
       public Unit unit = Unit.Kg;
        
        public Granular(int code, string n, decimal c, string d,ref Storage s)
        {
            this.SKU = code;
            this.name = n;
            this.cost = c;
            this.description = d;
            this.storage = s;
            Product Prod = this;
            if (s is OpenStorage open)
            {
                open.Add_product(ref Prod, rand.Next(1, 30));
            }
            else if (s is ClosedStorage closed)
            {
                closed.Add_product(ref Prod, rand.Next(1, 30));
            }
        }
    }
    class Solid : Product
    {
       public Unit unit = Unit.Pc;
        
        public Solid(int code, string n, decimal c, string d,ref Storage s)
        {
            this.SKU = code;
            this.name = n;
            this.cost = c;
            this.description = d;
            this.storage = s;
            Product Prod = this;
            if (s is OpenStorage open)
            {
                open.Add_product(ref Prod, rand.Next(1, 30));
            }
            else if (s is ClosedStorage closed)
            {
                closed.Add_product(ref Prod, rand.Next(1, 30));
            }
        }
    }
}
