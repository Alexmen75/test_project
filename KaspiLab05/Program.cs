using KaspiLab05.Exceptions;
using KaspiLab05.Objects;
using KaspiLab05.Report;
using KaspiLab05.StorageHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KaspiLab05
{
    enum Switch
    {
        Back,
        search,
        Add,
        Transfer,
        Sum,
        Compare,
        Balans,
        Reports,
        CSV
    }


    class Program
    {
       // public static List<Product> list_prod = new List<Product>();
        public static List<Storage> storages = new List<Storage>();
       
        public static string directory = Directory.GetCurrentDirectory();
        static void Main(string[] args)
        {
            List<Product> prod = Catalog.ProductList.Instance.ProductCatalog;
            string path = "./CSV";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory("./CSV");
            }
            ItemCreator.AddStorage();
            //list_prod.AverageQuantity();
            while (true)
            {
                try
                {
                    Console.WriteLine("Выберите склад");
                    Console.WriteLine("1-Damu Logistic\n2-ZIP Logistic\n3 Admart");
                    int select = Convert.ToInt32(Console.ReadLine()) - 1;
                    ConsoleWriter.ShowStorage(select);
                    ConsoleWriter.ShowProducts(select);
                    Switch check = (Switch) Convert.ToInt32(Console.ReadLine());
                    storages[select].AddProd += StorageHelper.TransferProductHandler;
                    switch (check)
                    {
                        case Switch.Back:
                            Console.Clear();
                            break;
                        case Switch.search:
                                ConsoleWriter.Search(select);
                                break;
                        case Switch.Add:
                                ConsoleWriter.Add(select);
                                break;
                        case Switch.Transfer:
                                ConsoleWriter.Transfer(select);
                                break;
                        case Switch.Sum:
                                ConsoleWriter.Sum();
                                break;
                        case Switch.Compare:
                                ConsoleWriter.Compare(select);
                                break;
                        case Switch.Balans:
                                ConsoleWriter.Balans(select);
                                break;
                        case Switch.Reports:
                                ConsoleWriter.ShowReports(select);
                                break;
                        case Switch.CSV:
                            CSV.CsvCreator.CreateStorageInfo(storages[select]);
                            break;
                    }
                    storages[select].AddProd -= StorageHelper.TransferProductHandler;
                }
                /*catch(ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                catch(ProductException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }*/
                finally//Нашел применение этой функции ))
                {
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
