using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Objects
{
    class OpenStorage : Storage
    {
       override public bool Add_product(ref Product prod, int count)
        {
            if (prod is Granular)
            {
               // Transfer(,prod, count);
                return false;
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
            return true;
        }
        
    }
}
