using KaspiLab05.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Objects
{
    class OpenStorage : Storage
    {
        public static Predicate<Product> check;
        override public bool Add_product(Product prod, int count)
        {
            check = ExceptionType.Check_type;
            if (check(prod))
            {
                throw new ProductException("Нельзя добавлять сыпучие объекты на склад" + this.name);
                //return false;
            }
            foreach (KeyValuePair<Product, int> P in products)
            {
                if (prod.SKU==P.Key.SKU )
                {
                    products[P.Key] += count;
                    return true;
                }
            }
            products.Add(prod,count);
         
            prod.storages.Add(this);
            
            return true;
        }

    }
}
