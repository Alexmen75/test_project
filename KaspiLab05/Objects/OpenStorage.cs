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
        override public bool Add_product(ref Product prod, int count)
        {
            check = Exception_type.Check_type;
            if (check(prod))
            {
                return false;
            }
            //Exception_type ex = new Exception_type(prod,this.name);

            /*Exception_type check = new Exception_type();
            if (check.Check_type(prod))
            {
                return false;
            }*/

            foreach (KeyValuePair<Product, int> P in products)
            {
                if (prod.SKU==P.Key.SKU )
                {
                    products[P.Key] += count;
                    return true;
                }
            }
            products.Add(prod,count);
            return true;
        }

        public override bool Add_product(Product prod, int count)
        {
            return Add_product(ref prod, count);
        }
    }
}
