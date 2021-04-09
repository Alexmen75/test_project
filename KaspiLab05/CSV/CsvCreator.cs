using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using KaspiLab05.Objects;
using KaspiLab05.StorageHandler;
using System.Threading;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace KaspiLab05.CSV
{
    class CsvCreator
    {
        static List<Product> AllProducts = Catalog.ProductList.Instance.ProductCatalog;

        public delegate void InfoHandler(string massage);
        public static event InfoHandler sucsessCreat; 
        public static void CreateStorageInfo(Storage storage)
        {
            using (StreamWriter info = new StreamWriter(Program.directory+"/CSV/" + storage.name + ".csv", false))
            {
                info.WriteLine("Name;" + storage.name);
                info.WriteLine("Adress;" + storage.adress.city + storage.adress.street + storage.adress.num);
                info.WriteLine("Product List:");
                List<Product> products = AllProducts.Where(P => storage.products.ContainsKey(P.SKU) ).ToList();
                var prodList = products
                    .OrderBy(s => s.name)
                    .ToList();

                var type = typeof(Product);
                var membersInfo = type.GetMembers();
                foreach(var T in membersInfo)
                {
                    var att = T.GetCustomAttributes(typeof(DisplayAttribute), false);
                    if(att.FirstOrDefault() != null)
                    {
                        Console.WriteLine(((DisplayAttribute)att.FirstOrDefault()).GetName());
                        info.Write(((DisplayAttribute)att.FirstOrDefault()).GetName() + ";");
                    }
                }
                info.WriteLine();
                foreach (var product in prodList)
                {
                    foreach(var field in membersInfo)
                    {
                        var att = field.GetCustomAttributes(typeof(DisplayAttribute), false);
                        if (att.FirstOrDefault() != null)
                        {
                            var p1 = product.GetType();
                            var p2 = p1.GetField(field.Name);
                            var p3 = p2.GetValue(product);
                            info.Write(p3+";");
                        }
                    }
                    info.WriteLine();
                }
            }
            
            sucsessCreat?.Invoke($"Завершено создания таблицы слада {storage.name}");
            sucsessCreat-= StorageHelper.TransferProductHandler;
        }
    }
}
