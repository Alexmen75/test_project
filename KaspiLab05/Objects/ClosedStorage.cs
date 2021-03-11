﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Objects
{
    class ClosedStorage : Storage
    {
       override public bool Add_product(Product prod, int count)
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
        
    }
}
