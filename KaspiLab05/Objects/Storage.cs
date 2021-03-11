using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Objects
{
    class Storage : IStorage
    {
        internal string adress;
        internal int sqгare;
        internal string manager;
        readonly public List<Product> products = new List<Product>() { null };
        readonly public List<int> product_count = new List<int>() { 0 };
        internal bool is_Open;

        

        public bool Add_product(Product prod, int count)
        {
            if (prod is Granular)
            {
                if (is_Open)
                {
                    return false;
                }
            }

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


        public decimal Cost_ptoduct()
        {
            decimal sum = 0;
            for (int i = 0; i < products.Count();i++)
            {
                sum += products[i].cost * product_count[i];
            }
            return sum;
            
        }

        public Tuple<Product, int> Search_SKU(int SKU)
        {
            for (int i = 0; i < products.Count(); i++)
            {
                if(products[i].SKU == SKU )
                {
                    return Tuple.Create(products[i], product_count[i]);
                }
            }
            return Tuple.Create(products[0], 0);//вроде здоровый человек, а костылями пользуюсь, как это исправить ?
        }

        public void Set_Manager()
        {
            throw new NotImplementedException();
        }

        public bool Transfer(Storage storage, Product prod, int count) //получился гавнокод , какие альтернативные способы решения можно использовать ? 
        {
            for (int i = 1; i < products.Count(); i++)
            {
                if (prod.SKU == products[i].SKU)
                {
                    if (product_count[i]>= count)
                    {
                        product_count[i] -= count;
                        if (storage.Add_product(prod,count)==true)
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
