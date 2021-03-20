using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Objects
{
    class ClosedStorage : Storage
    {
       override public bool Add_product(ref Product prod, int count)
        {
            foreach (KeyValuePair<Product, int> P in products)
            {
                if (prod.SKU == P.Key.SKU)
                {
                    
                    products[P.Key] += count;
                    return true;
                }
            }
            products.Add(prod, count);
            return true;
        }

        public override bool Add_product(Product prod, int count)
        {
            return Add_product(ref prod, count);
        }
    }
}
