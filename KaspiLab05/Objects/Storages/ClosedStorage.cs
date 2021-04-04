using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Objects
{
    class ClosedStorage : Storage
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        override public bool Add_product(int SKU, int count)
        {
            foreach (KeyValuePair<int, int> P in products)
            {
                if (SKU == P.Key)
                {
                    logger.Debug("{0}: пополнение товара {1}({2})", this.name, P.Key, P.Value);
                    products[P.Key] += count;
                    return true;
                }
            }
            Product foundProd = AllProducts.Where(p => p.SKU == SKU).First();
            foundProd.storages.Add(this);
            logger.Debug("{0}: поступил новый товар  {1}({2})", this.name, foundProd.name, count);
            products.Add(SKU, count);
            return true;
        }

    }
}
