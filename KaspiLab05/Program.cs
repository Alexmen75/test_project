using KaspiLab05.Catalog;
using KaspiLab05.Comand;
using KaspiLab05.Exceptions;
using KaspiLab05.Objects;
using KaspiLab05.Objects.Storage_Event;
using KaspiLab05.Report;
using KaspiLab05.StorageHandler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

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

        public static Queue<ProductMoving> productMovings = new Queue<ProductMoving>();


        static void Main(string[] args)
        {
            Task task;
            task = new Task(() => ComandHandler.Handler(productMovings));

            //ProductMoving DamuComand = new ProductMoving(storages[0]);
            //ProductMoving ZIPComand = new ProductMoving(storages[1]);
            //ProductMoving AdmartComand = new ProductMoving(storages[2]);
            ItemCreator.AddStorage();
            Queue<ProductMoving> DamuComand = new Queue<ProductMoving>() ;
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            DamuComand.Enqueue(new ProductMoving(storages[0]) { SKU = 123412, count = 20 });
            Queue<ProductMoving> ZIPComand = new Queue<ProductMoving>();
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });
            ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 62356, count = 30 });
            ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 62356, count = 30 });
            ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 62356, count = 30 });
            //ZIPComand.Enqueue(new ProductMoving(storages[1]) { SKU = 123412, count = 30 });


            Queue<ProductMoving> AdmartComand = new Queue<ProductMoving>();
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });
            AdmartComand.Enqueue(new ProductMoving(storages[2]) { SKU = 123412, count = 40 });


            List<Queue<ProductMoving>> StoragesComand = new List<Queue<ProductMoving>>() { DamuComand, ZIPComand, AdmartComand };

            List<Product> Allproduct = ProductList.Instance.ProductCatalog;

            
            
            string path = "./CSV";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory("./CSV");
            }
            
            while (true)
            {
                try
                {
                    Console.WriteLine("Выберите склад");
                    Console.WriteLine("1-Damu Logistic\n2-ZIP Logistic\n3 Admart\n4-Добавление товаров");

                    int select = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (select + 1 == 4)
                    {
                        int check = -1;

                        while (check != 0)
                        {
                            Console.WriteLine("Ввеедите SKU продукта \n");
                            Allproduct.ProductList();
                            int SKU = Convert.ToInt32(Console.ReadLine());
                            if (SKU == 0)
                            {
                                break;
                            }
                            else if (!Allproduct.Check(SKU))
                            {
                                Console.WriteLine("Товара {0} не существует", SKU);
                                Console.ReadKey();
                                continue;
                            }

                            Console.WriteLine("Введите количество");
                            int count = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            Console.WriteLine("Выберите склад");
                            foreach (Storage stor in storages)
                            {
                                Console.WriteLine(stor.name);
                            }
                            select = Convert.ToInt32(Console.ReadLine());

                            StoragesComand[select].Enqueue(new ProductMoving(storages[select]) { SKU = SKU, count = count });
                            //productMovings.Enqueue(new ProductMoving(storages[select]) { SKU = SKU, count = count });
                        }
                        Console.Clear();
                        //Console.ReadKey();
                    }
                    else
                    {
                        bool run = true;
                        while (run == true)
                        {


                            ConsoleWriter.ShowStorage(select);
                            ConsoleWriter.ShowProducts(select);
                            Switch check = (Switch)Convert.ToInt32(Console.ReadLine());
                            storages[select].AddProd += StorageHelper.TransferProductHandler;
                            switch (check)
                            {
                                case Switch.Back:
                                    Console.Clear();
                                    run = false;
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
                                    Console.Clear();
                                    //ConsoleWriter.ShowReports(select);
                                    Task avarage = new Task(() => Allproduct.AverageQuantity());
                                    Task less = new Task(() => Report.Report.LesserAmount(storages[select]));
                                    Task max = new Task(() => Report.Report.MaxProduct(storages[select]));
                                    Task.Run(() => Parallel.Invoke(
                                        () => avarage.Start(),
                                        () => less.Start(),
                                        () => max.Start()));
                                    Task.WaitAll(avarage, less, max);
                                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                            }
                        }
                            storages[select].AddProd -= StorageHelper.TransferProductHandler;
                        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
                        CancellationToken token = cancelTokenSource.Token;
                        //new Task(() =>
                        //{
                        //    cancelTokenSource.Cancel();
                        //}).Start();
                        try
                        {
                            Parallel.ForEach(StoragesComand,
                                        new ParallelOptions { CancellationToken = token }, ComandHandler.Handler);
                        }
                        catch (OperationCanceledException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (ProductException ex)
                        {
                            Console.WriteLine( ex.Message);
                        }
                    }
                }
                catch(ArgumentException ex)
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
                }
                finally
                {
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
