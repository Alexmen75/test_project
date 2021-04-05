using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DisplayAttribute(Name = "SKU")]
        public int SKU { get; set; }
        [DisplayAttribute(Name = "Name")]
        public string name { get; set; }

        [DisplayAttribute(Name = "Cost")]
        public decimal cost { get; set; }

        public string description { get; set; }
        public Unit unit { get; set; }
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
