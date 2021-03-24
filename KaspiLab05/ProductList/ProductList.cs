using KaspiLab05.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.ProductList
{
   class ProductList
    {
        private static ProductList _instance = null;
        public List<Product> ProductCatalog;
        private ProductList()
            {
            ProductCatalog = new List<Product>();
            }
        public static ProductList Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProductList();
                }
                return _instance;
            }
        }

       
    }
}
