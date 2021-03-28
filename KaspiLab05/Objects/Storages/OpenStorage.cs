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
        public static Predicate<int> check;
        override public bool Add_product(int SKU, int count)
        {
            check = ExceptionType.Check_type;
            if (check(SKU))
            {
                throw new ProductException("Нельзя добавлять сыпучие объекты на склад" + this.name);
                //return false;
            }
            foreach (KeyValuePair<int, int> P in products)
            {
                if (SKU == P.Key)
                {
                    products[P.Key] += count;
                    
                    return true;
                }
            }
            Product foundProd = AllProducts.Where(p => p.SKU == SKU).First();
            foundProd.storages.Add(this);

            products.Add(SKU, count);

            return true;
        }

    }
}
