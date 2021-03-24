using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaspiLab05;
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
        public Unit unit;
        public List<Storage> storages = new List<Storage>();
        public Product()
        {
            Product Prod = this;
            //Program.list_prod.Add(Prod);
        }
    }
    class Liquid : Product
    {
        public Liquid()
        {
            unit = Unit.L;
        }
    }
    class Granular : Product
    {
        public Granular()
        {
            unit = Unit.Kg;
        }
    }
    class Solid : Product
    {
        public Solid()
        {
            unit = Unit.Pc;
        }
    }
    static class ProductInfo
    {
        public static string GetInfo(this Product product)
        {
            return $"{product.SKU} {product.name}";
        }
    }
}
