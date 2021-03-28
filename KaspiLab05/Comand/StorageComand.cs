using KaspiLab05.Catalog;
using KaspiLab05.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Comand
{
    public delegate void AddHandler(string massage);
    interface IStorageComand
    {
        void Execute();
        void Undo();
    }

    class ProductMoving : IStorageComand
    {
        protected static List<Product> AllProducts = ProductList.Instance.ProductCatalog;
        public event AddHandler Info;
        Storage storage;
        public int SKU;
        public int count;
        public ProductMoving(Storage s)
        {
            storage = s;
        }
        public void Execute()
        {
            storage.Add_product(SKU, count);
            Product FoundProd = AllProducts.Where(Prod => Prod.SKU == SKU).First();
            Info?.Invoke($"на склад {storage.name} добавлен продукт {FoundProd.name} в количестве {count}{FoundProd.unit}");
        }
        public void Undo()
        {

        }
    }
    class Invoker
    {
        IStorageComand command;
        public void SetCommand (IStorageComand Com)
        {
            command = Com;
        }
        public void Run()
        {
            command.Execute();
        }
        public void Cancel()
        {
            command.Undo();
        }
    }

}
