using KaspiLab05.Exceptions;
using KaspiLab05.Objects;
using KaspiLab05.Report;
using KaspiLab05.Storage_Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        Reports
    }


    class Program
    {
        
        

        public static List<Product> list_prod = new List<Product>();

        public static List<Storage> storages = new List<Storage>();
        
        static void Main(string[] args)
        {

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


                    int check = Convert.ToInt32(Console.ReadLine());

                    storages[select].AddProd += Storage_event.TransferProductHandler;

                    switch (check)
                    {
                        case (int)Switch.Back:
                            Console.Clear();
                            break;


                        case (int)Switch.search:
                            {
                                ConsoleWriter.Search(select);
                                break;
                            }


                        case (int)Switch.Add:
                            {

                                ConsoleWriter.Add(select);

                                break;
                            }


                        case (int)Switch.Transfer:
                            {
                                ConsoleWriter.Transfer(select);
                                break;
                            }


                        case (int)Switch.Sum:
                            {
                                ConsoleWriter.Sum();
                                break;
                            }


                        case (int)Switch.Compare:
                            {
                                ConsoleWriter.Compare(select);
                                break;
                            }


                        case (int)Switch.Balans:
                            {
                                ConsoleWriter.Balans(select);
                                break;
                            }
                        case (int)Switch.Reports:
                            {
                                ConsoleWriter.ShowReports(select);
                                break;
                            }


                    }
                    storages[select].AddProd -= Storage_event.TransferProductHandler;
                }



                catch(ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                catch(Product_exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
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
