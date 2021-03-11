using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Objects
{
   abstract class Storage : IStorage
    {
        internal string adress;
        internal int sqгare;
        internal string manager;
        readonly public List<Product> products = new List<Product>() { null };
        readonly public List<int> product_count = new List<int>() { 0 };
        //internal bool is_Open;

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
    }
}
