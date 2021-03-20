using KaspiLab05.Storage_Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KaspiLab05.Objects
{
   
    abstract class Storage : IStorage
    {
        public delegate void AddHandler(string massage);
        public event AddHandler AddProd;

        public string name; 
        internal int sqгare;
        internal Adress adress;
        public Person manager;
        public Employee[] employees = new Employee[4];
        public Dictionary<Product,int> products = new Dictionary<Product,int>();



        abstract public bool Add_product(ref Product prod, int count);
        abstract public bool Add_product(Product prod, int count);



        public decimal Cost_ptoduct()
        {
            decimal sum = 0;
            foreach (KeyValuePair<Product,int> prod in products)
            {
                sum += prod.Key.cost * prod.Value;
            }
            return sum;
        }

        public Tuple<Product, int> Search_SKU(int SKU)
        {
            foreach (KeyValuePair<Product, int> prod in products)
            {
                if(prod.Key.SKU==SKU)
                {
                    return Tuple.Create(prod.Key, prod.Value);
                }
            }
            return null;
        }

        public void Set_Manager(string S, string N, string P)
        {
            manager = new Employee(S, N, P, 0);
            employees[0] = (Employee)manager;
        }

        public void Set_Employee(string S, string N, string P, post pos)
        {
            employees[(int)pos] = new Employee(S, N, P, pos);
        }


        public bool Transfer(Storage storage,Product prod, int count) 
        {
            foreach (KeyValuePair<Product,int> P in products)
            {
                if (prod.SKU == P.Key.SKU)
                {
                    if (P.Value>=count)
                    {
                        
                        products[P.Key] -= count;
                        if (storage.Add_product(ref prod, count) == true)
                        {
                            AddProd?.Invoke($"на склад {storage.name} перемещен товар {prod.name} в количестве {count}{prod.unit}");
                            return true;
                        }
                        else
                        {
                            AddProd?.Invoke($"на склад {storage.name} нельзя добавлять сыпучие товары");
                            products[P.Key] += count;
                            return false;
                        }
                    }
                }
            }
            AddProd?.Invoke($"На складе {this.name} нет нужного количества товара");
            return false;
            
        }
    }
}
