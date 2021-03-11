using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Objects
{
    class ClosedStorage : Storage
    {
        public bool Add_product(Product prod, int count)
        {
            for (int i = 1; i < products.Count(); i++)
            {
                if (prod.SKU == products[i].SKU)
                {
                    product_count[i] += count;
                    return true;
                }
            }
            products.Add(prod);
            product_count.Add(count);
            return true;
        }
        public bool Transfer(ClosedStorage storage, Product prod, int count) //получился гавнокод , какие альтернативные способы решения можно использовать ? 
        {
            for (int i = 1; i < products.Count(); i++)
            {
                if (prod.SKU == products[i].SKU)
                {
                    if (product_count[i] >= count)
                    {
                        product_count[i] -= count;
                        if (storage.Add_product(prod, count) == true)
                        {
                            return true;
                        }
                        else
                        {
                            product_count[i] += count;
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return false;
        }
    }
}
