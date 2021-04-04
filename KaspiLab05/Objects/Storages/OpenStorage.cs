using KaspiLab05.Exceptions;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Objects
{
    class OpenStorage : Storage
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static Predicate<int> check;
        override public bool Add_product(int SKU, int count)
        {
            check = ExceptionType.Check_type;
            if (check(SKU))
            {
                throw new ProductException("попытка добавить товар сыпучего типа на склад " + this.name +$" (SKU={SKU})" );
                //return false;
            }
            foreach (KeyValuePair<int, int> P in products)
            {
                if (SKU == P.Key)
                {
                    products[P.Key] += count;
                    logger.Info("{0}: пополнение товара {1}({2})", this.name, P.Key, P.Value);
                    return true;
                }
            }
            Product foundProd = AllProducts.Where(p => p.SKU == SKU).First();
            foundProd.storages.Add(this);
            logger.Info("{0}: поступил новый товар  {1}({2})", this.name, foundProd.name, count);
            products.Add(SKU, count);

            return true;
        }

    }
}
