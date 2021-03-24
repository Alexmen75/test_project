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
        public static void CreateStorageInfo(Storage storage)
        {
            using (StreamWriter info = new StreamWriter(Program.directory+"/CSV/" + storage.name + ".csv", false))
            {
                info.WriteLine("Name;" + storage.name);
                info.WriteLine("Adress;" + storage.adress.city + storage.adress.street + storage.adress.num);
                //info.WriteLine("Manager;" + storage.manager.surname +";"+ storage.manager.name + ";" + storage.manager.patronymic);
                //кирилицу не принимает
                info.WriteLine();
                info.WriteLine("SKU;Name;Count");
                foreach (var product in storage.products)
                {
                    var productKey = product.Key;
                    info.Write(
                        productKey.SKU + ";"
                        + productKey.name + ";" 
                        + product.Value + productKey.unit);
                    info.WriteLine();
                }
                
            }
        }
    }
}
