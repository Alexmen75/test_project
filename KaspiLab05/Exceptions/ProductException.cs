using KaspiLab05.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaspiLab05.Catalog;

namespace KaspiLab05.Exceptions
{
    
    class ProductException : Exception
      
    {
        public ProductException(string massage) : base (massage)
        {
        }
    }
    class ExceptionType
    {
        protected static List<Product> AllProducts = ProductList.Instance.ProductCatalog;
        public static bool Check_type(int SKU)
        {
            Product foundProd = AllProducts.Where(p => p.SKU == SKU).First();
            return foundProd is Granular;
        }
            
    }
}
