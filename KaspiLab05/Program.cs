﻿using KaspiLab05.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05
{

    class Program
    {
        static Random rand = new Random();

        static Random S = new Random();
        static Random N = new Random();
        static Random P = new Random();
        public static List<Product> list_prod = new List<Product>();
        static int cursor_L;
        static int cursor_T;
        static void Main(string[] args)
        {


            string[] surname = new string[5] {"Букин", "Софиулин","Кузнецов","Ледошляп","Захаранс"};
            string[] name = new string[5] { "Генадий", "Анатолий", "Игорь", "Артем", "Максим" };
            string[] patronymic = new string[5] { "Артемович", "Михайлович", "Алесандрович", "Русланович", "Павлович" };



            Storage Damu_Logistic = new ClosedStorage() { sqгare = 230, name = "Damu_Logistic" };
            Storage ZIP_Logistic = new OpenStorage() { sqгare = 530, name = "ZIP_Logistic" };
            Storage Admart = new ClosedStorage() {  sqгare = 320, name = "Admart" };



            List <Storage> storages = new List<Storage>() { Damu_Logistic,ZIP_Logistic,Admart };



            Damu_Logistic.Set_Manager(surname[S.Next(0, 5)], name[N.Next(0, 5)], patronymic[P.Next(0, 5)]);
            ZIP_Logistic.Set_Manager(surname[S.Next(0, 5)], name[N.Next(0, 5)], patronymic[P.Next(0, 5)]);
            Admart.Set_Manager(surname[S.Next(0, 5)], name[N.Next(0, 5)], patronymic[P.Next(0, 5)]);


            for (int i=0;i<storages.Count();i++)
            {
                for (int j = 1; j < 4; j++) 
                {
                    storages[i].Set_Employee(surname[S.Next(0, 5)], name[N.Next(0, 5)], patronymic[P.Next(0, 5)], (post)j);
                }
            }

            for (int i = 0; i < storages.Count(); i++)
            {
                storages[i].adress = new Adress((City)i, (Street)i, rand.Next(10,150));
                for (int j = 0; j < 4; j++)
                {
                    storages[i].Set_Employee(surname[S.Next(0, 5)], name[N.Next(0, 5)], patronymic[P.Next(0, 5)], (post)j);
                }
            }

            Product whater = new Liquid(123412, "BonAqua", 100, "Водичка",ref ZIP_Logistic);
            Product cola = new Liquid(123945,"Coca-Cola", 150 , "Счастье к нам приходит",ref Damu_Logistic);



            Product buckwheat = new Granular( 62356, "King buckwheat",  110,"Греча простая",ref Admart) ;
            Product rice = new Granular( 68932, "King rice", 120 , "Рис королей",ref  Damu_Logistic) { };



            Product cookies= new Solid(823949, "Nestle Oreo", 330, "Оторви, обмакни, лизни",ref ZIP_Logistic);
            Product chips = new Solid(67654, "Lays chips", 420, "Чепсики",ref Admart) ;

            Product burger = new Solid(42069, "Burger king", 990, "Women belongs in the kitchen",ref ZIP_Logistic);// Sorry, i just like memes

            //KeyValuePair<Product,int> pro = Damu_Logistic.products.First();
            //Console.WriteLine(list_prod[1].cost);
           // Console.WriteLine(pro.Key.cost);
            // cola.cost = 200;
            //Console.WriteLine(pro.Key.cost);
            //Console.WriteLine(list_prod[1].cost);

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
                    switch (check)
                    {
                        case 0:
                            Console.Clear();
                            break;
                        case 1:
                            {
                                Console.Clear();
                                foreach (Product prod in list_prod)
                                {
                                    Console.WriteLine(prod.SKU + " " + prod.name);
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
                        case 2:
                            {
                                Console.Clear();
                                foreach (Product prod in list_prod)
                                {
                                    Console.WriteLine(prod.SKU + " " + prod.name);
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


                                        // KeyValuePair<Product, int> pro = Damu_Logistic.products.Last();

                                        // Console.WriteLine(pro.Key.cost);
                                        // burger.cost = 10;
                                        // Console.WriteLine(pro.Key.cost);
                                        // Console.ReadLine();
                                        // Закоменчена проверка на то, что класс склада хранит только ссылку на объект
                                        break;
                                    }

                                }
                                break;
                            }
                        case 3:
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
                                // buckwheat.cost = 20; просто поверка ссылки
                                break;
                            }
                        case 4:
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
                    }
                }
                catch(ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                catch(FormatException ex)
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
