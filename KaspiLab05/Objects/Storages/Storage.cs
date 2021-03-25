﻿using KaspiLab05.StorageHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaspiLab05.Catalog;


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
        public Dictionary<int,int> products = new Dictionary<int,int>();//Изменю на int int <SKU,count>
        protected static List<Product> AllProducts = ProductList.Instance.ProductCatalog;

        abstract public bool Add_product(int SKU, int count);
        public decimal Cost_ptoduct()
        {
            decimal sum = 0;
            foreach (KeyValuePair<int,int> prod in products)
            {
                Product foundProd = AllProducts.Where(p => p.SKU == prod.Key).First();
                sum += foundProd.cost * prod.Value;
            }
            return sum;
        }
        public Tuple<Product, int> Search_SKU(int SKU)
        {
            foreach (KeyValuePair<int, int> prod in products)
            {

                if(prod.Key==SKU)
                {
                    Product foundProd = AllProducts.Where(p => p.SKU == SKU).First();
                    return Tuple.Create(foundProd, prod.Value);
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
            foreach (KeyValuePair<int,int> P in products)
            {
                if (prod.SKU == P.Key)
                {
                    if (P.Value>=count)
                    {
                        products[P.Key] -= count;
                        if (storage.Add_product(prod.SKU, count) == true)
                        {
                            AddProd?.Invoke($"на склад {storage.name} перемещен товар {prod.name} в количестве {count}{prod.unit}");
                            if (products[P.Key]==0)
                            {
                                Product foundProd = (Product)AllProducts.Where(p => p.SKU == P.Key);
                                foundProd.storages.Remove(this);
                                products.Remove(P.Key);
                            }
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

    static class CompareStorages
    {
        public static List<int> Compare(this Storage storage1, Storage storage2)
        {
            var stor = storage1.products.Keys
                .Where(s => storage2.products.ContainsKey(s))
                .ToList();
            return stor;
        }
    }
    static class BalansProduct
    {
        private static List<Product> AllProducts = ProductList.Instance.ProductCatalog;
        public static void Balans(this Storage storage1, Storage storage2)
        {
            var stor = storage1.products
                .Where(s=> !storage2.products.ContainsKey(s.Key))
                .ToList();
            foreach(KeyValuePair<int,int> P in stor)
            {
                Product foundProd = AllProducts.Where(p => p.SKU == P.Key).First();
                storage1.Transfer(storage2, foundProd, P.Value/2);
            }
        }
    }
}
