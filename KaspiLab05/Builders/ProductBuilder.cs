using KaspiLab05.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaspiLab05.Catalog;

namespace KaspiLab05.Builders
{
    class ProductBuilder<T>
        where T : Product, new()// полтора часа ломал голову, как создать generic который будет создавать объект нужного мне класса, все оказалось проще , чем я думал

    {
        public static Random rand = new Random();
        private Product product;
        public ProductBuilder()
        {
            product = new T();
        }
        public ProductBuilder<T> SKU(int SKU)
        {
            product.SKU = SKU;
            return this;
        }
        public ProductBuilder<T> name(string name)
        {
            product.name = name;
            return this;
        }


        public ProductBuilder<T> cost(decimal cost)
        {
            product.cost = cost;
            return this;
        }
        public ProductBuilder<T> description(string description)
        {
            product.description = description;
            return this;
        }
        public ProductBuilder<T> storage(ref Storage storage)
        {
            ProductList.Instance.ProductCatalog.Add(product);
            storage.Add_product(product.SKU, rand.Next(10, 100));
            //product.storages.Add(storage);
            return this;
        }

        public Product Build()
        {
            
            return product;
        }

    }
}
