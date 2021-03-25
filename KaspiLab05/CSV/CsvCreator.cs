using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using KaspiLab05.Objects;

namespace KaspiLab05.CSV
{
    class CsvCreator
    {
        static List<Product> AllProducts = Catalog.ProductList.Instance.ProductCatalog;
        public static void CreateStorageInfo(Storage storage)
        {
            using (StreamWriter info = new StreamWriter(Program.directory+"/CSV/" + storage.name + ".csv", false))
            {
                info.WriteLine("Name;" + storage.name);
                info.WriteLine("Adress;" + storage.adress.city + storage.adress.street + storage.adress.num);
                //info.WriteLine("Manager;" + storage.manager.surname +";"+ storage.manager.name + ";" + storage.manager.patronymic);
                //кирилицу не принимает
                info.WriteLine("Список товаров:");
                info.WriteLine("SKU;Name;Count");
                List<Product> products = AllProducts.Where(P => storage.products.ContainsKey(P.SKU) ).ToList();
                var prodList = products
                    .OrderBy(s => s.name)
                    .ToList();
                foreach (var product in prodList)
                {
                    info.Write(
                        product.SKU + ";"
                        + product.name + ";" 
                        + storage.products[product.SKU] + product.unit);
                    info.WriteLine();
                }
                
            }
        }
    }
}
