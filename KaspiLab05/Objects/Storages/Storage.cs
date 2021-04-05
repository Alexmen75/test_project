using KaspiLab05.StorageHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaspiLab05.Catalog;
using KaspiLab05.Exceptions;
using NLog;
using KaspiLab05.Comand;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace KaspiLab05.Objects
{
   
    abstract class Storage : IStorage
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public delegate void AddHandler(string massage);
        public event AddHandler AddProd;

        [Display(Name = "name")]
        public string name { get; set; }
        
        public int sqгare { get; set; }
        public Adress adress { get; set; }
        public Person manager { get; set; }
        public Employee[] employees = new Employee[4];
        public Dictionary<int,int> products = new Dictionary<int,int>();
        protected static List<Product> AllProducts = ProductList.Instance.ProductCatalog;

        public Queue<ProductMoving> Comand = new Queue<ProductMoving>();

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
                            //AddProd?.Invoke($"на склад {storage.name} перемещен товар {prod.name} в количестве {count}{prod.unit}");
                            logger.Info($"на склад {storage.name} перемещен товар {prod.name} в количестве {count}{prod.unit}");
                            
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
                            //AddProd?.Invoke($"на склад {storage.name} нельзя добавлять сыпучие товары");
                            logger.Error($"попытка добавить на склад {storage.name} сыпучий товар({P.Key})");// по идее эта часть кода не запускается, так как метод добавления ничего не возвращает из-за ex
                            products[P.Key] += count;
                            return false;
                        }
                    }
                }
            }
            //AddProd?.Invoke($"На складе {this.name} нет нужного количества товара");
            logger.Error($"попытка перемесить на склад {storage.name} несуществующий товар");
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
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static List<Product> AllProducts = ProductList.Instance.ProductCatalog;
        public static void Balans(this Storage storage1, Storage storage2)
        {
            var stor = storage1.products
                .Where(s=> !storage2.products.ContainsKey(s.Key))
                .ToList();
            logger.Debug("Запуск балансировки продуктов из склада "+ storage1.name + " на склад "+  storage2.name);
            foreach(KeyValuePair<int,int> P in stor)
            {
                Product foundProd = AllProducts.Where(p => p.SKU == P.Key).First();
                try
                {
                    storage1.Transfer(storage2, foundProd, P.Value / 2);
                }
                catch(ProductException ex)
                {
                    logger.Error(ex.Message);
                }

            }
            logger.Debug("Балансировка закончена");
        }
    }
}
