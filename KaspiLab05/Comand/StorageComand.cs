using KaspiLab05.Catalog;
using KaspiLab05.Exceptions;
using KaspiLab05.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

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
        private static Logger logger = LogManager.GetCurrentClassLogger();
        protected static List<Product> AllProducts = ProductList.Instance.ProductCatalog;
        Storage storage;
        public int SKU;
        public int count;
        public ProductMoving(Storage s)
        {
            storage = s;
        }
        public void Execute()
        {
            try
            {
                storage.Add_product(SKU, count);
            }
            catch(ProductException ex)
            {
                logger.Error(ex.Message);
            }
            
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
