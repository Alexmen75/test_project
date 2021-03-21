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
        Balans
    }


    class Program
    {
        
        static int cursor_L;
        static int cursor_T;

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
                    Console.Clear();
                    Console.WriteLine(storages[select].name);
                    Console.WriteLine("Адрес: {0} {1} {2}", storages[select].adress.city, storages[select].adress.street, storages[select].adress.num);
                    Console.WriteLine("Площадь: {0}", storages[select].sqгare);
                    Console.WriteLine("Тип склада: {0}", (storages[select] is OpenStorage ? ("Открытый") : ("Закрытый")));
                    Console.WriteLine("Ответственный: {0} {1} {2}", storages[select].manager.surname, storages[select].manager.name, storages[select].manager.patronymic);
                    Console.WriteLine("Список продуктов:");
                    Console.WriteLine("\t SKU\t Наименование\t Цена за ед\t Количество\t Описание\n");



                    foreach (var Prod in storages[select].products)
                    {
                        Console.Write("\t " + Prod.Key.SKU);
                        Console.Write("\t " + Prod.Key.name);
                        Console.Write("\t " + Prod.Key.cost + "тнг");
                        if (Prod.Key is Liquid liquid)
                        {
                            Console.Write("/" + liquid.unit);
                        }
                        else if (Prod.Key is Solid solid)
                        {
                            Console.Write("/" + solid.unit);
                        }
                        else if (Prod.Key is Granular granular)
                        {
                            Console.Write("/" + granular.unit);
                        }
                        Console.Write("\t " + Prod.Value);
                        Console.Write("\t\t " + Prod.Key.description + "\n");
                    }

                    Console.WriteLine("\n\n Общая сумма товаров:   " + storages[select].Cost_ptoduct() + "тнг");


                    cursor_L = Console.CursorLeft;
                    cursor_T = Console.CursorTop;
                    Console.SetCursorPosition(0, cursor_T + 5);
                    Console.Write("1- Поиск товара\t 2-Добавить товар\t3-Переместить товар\t4-Сумма всех складов \t0-назад\n");
                    int check = Convert.ToInt32(Console.ReadLine());
                    int SKU;
                    int count;
                    storages[select].AddProd += Storage_event.TransferProductHandler;
                    switch (check)
                    {
                        case (int)Switch.Back:
                            Console.Clear();
                            break;
                        case (int)Switch.search:
                            {
                                Console.Clear();
                                foreach (Product prod in list_prod)
                                {
                                    Console.WriteLine(prod.GetInfo());
                                }
                                Console.WriteLine("\nВведите SKU товара, который хотите найти");
                                SKU = Convert.ToInt32(Console.ReadLine());
                                if (storages[select].Search_SKU(SKU) == null)
                                {
                                    Console.WriteLine("Указанного товара нет на данном складе");
                                    Console.WriteLine("Найти товар на других складах?\t1-Да\t2-Нет");
                                    if (Convert.ToInt32(Console.ReadLine()) == 1)
                                    {
                                        foreach (Storage S in storages)//есть вариант, как это улучшить, займусь этим завтра
                                        {
                                            Tuple<Product, int> found_prod = S.Search_SKU(SKU);
                                            if (found_prod != null)
                                            {
                                                Console.Write(S.name + ": " + found_prod.Item1.name + " " + found_prod.Item2);//Добавлю имя склада
                                                if (found_prod.Item1 is Liquid liquid)
                                                {
                                                    Console.Write(liquid.unit);
                                                }
                                                else if (found_prod.Item1 is Solid solid)
                                                {
                                                    Console.Write(solid.unit);
                                                }
                                                else if (found_prod.Item1 is Granular granular)
                                                {
                                                    Console.Write(granular.unit);
                                                }
                                                Console.WriteLine();
                                            }
                                            else
                                            {
                                                Console.WriteLine(S.name + ": Данного товара нет");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine();
                                }
                                break;
                            }
                        case (int)Switch.Add:
                            {
                                Console.Clear();
                                foreach (Product prod in list_prod)
                                {
                                    Console.WriteLine(prod.GetInfo());
                                }
                                Console.WriteLine("Введите SKU товара, который хотите добавить");
                                SKU = Convert.ToInt32(Console.ReadLine());
                                foreach (Product P in list_prod)
                                {
                                    if (P.SKU == SKU)
                                    {



                                        Console.WriteLine(P.name + " Введите количество");
                                        count = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine(storages[select].Add_product(P, count) == true ? ("Товар добавлен") : ("ошибка"));

                                        break;
                                    }

                                }
                                break;
                            }
                        case (int)Switch.Transfer:
                            {
                                Console.WriteLine("Введите SKU товара:");
                                SKU = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите количество товара:");
                                count = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Выберите место доставки:");
                                for (int i = 0; i < storages.Count(); i++)
                                {
                                    Console.WriteLine(i + 1 + " " + storages[i].name);
                                }
                                check = Convert.ToInt32(Console.ReadLine()) - 1;
                               
                                storages[select].Transfer(storages[check], storages[select].Search_SKU(SKU).Item1, count);
                                break;
                            }
                        case (int)Switch.Sum:
                            {
                                decimal sum = 0;
                                Console.Write("\nСумма всех складов равна: ");
                                foreach (Storage stor in storages)
                                {
                                    sum += stor.Cost_ptoduct();
                                }
                                Console.Write(sum + "\n");

                                sum = 0;
                                break;
                            }
                        case (int)Switch.Compare:
                            {
                                Console.WriteLine("Выберите склад");
                                for (int i = 0; i < storages.Count(); i++)
                                {
                                    Console.WriteLine(i + 1 + " " + storages[i].name);
                                }
                                check = Convert.ToInt32(Console.ReadLine());
                                foreach (var P in storages[select].Compare(storages[check-1]))
                                {
                                    Console.WriteLine(P.name);
                                }
                                break;
                            }
                        case (int)Switch.Balans:
                            {
                                Console.WriteLine("Выберите склад");
                                for (int i = 0; i<storages.Count(); i++)
                                {
                                    Console.WriteLine(i + 1 + " " + storages[i].name);
                                }
                                check = Convert.ToInt32(Console.ReadLine());
                                storages[select].Balans(storages[check-1]);
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
