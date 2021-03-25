using KaspiLab05.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaspiLab05.Report;
using KaspiLab05.Catalog;

namespace KaspiLab05
{
    enum Reports
    {
        Lesser =1,
        Max,
        MissGranular,
        AverageQuantity
    }

    class ConsoleWriter// Класс просто для вывода информации на консоль
    {
        static int SKU;
        static int count;
        static int check;

        static int cursor_L;
        static int cursor_T;
        public static void ShowStorage(int select)
        {
            Console.Clear();
            Console.WriteLine(Program.storages[select].name);
            Console.WriteLine("Адрес: {0} {1} {2}", Program.storages[select].adress.city, Program.storages[select].adress.street, Program.storages[select].adress.num);
            Console.WriteLine("Площадь: {0}", Program.storages[select].sqгare);
            Console.WriteLine("Тип склада: {0}", (Program.storages[select] is OpenStorage ? ("Открытый") : ("Закрытый")));
            Console.WriteLine("Ответственный: {0} {1} {2}", Program.storages[select].manager.surname, Program.storages[select].manager.name, Program.storages[select].manager.patronymic);
            Console.WriteLine("Список продуктов:");
            Console.WriteLine("\t SKU\t Наименование\t Цена за ед\t Количество\t Описание\n");
        }

        public static void ShowProducts(int select)
        {

            Program.storages[select].ProductList();

            Console.WriteLine("\n\n Общая сумма товаров:   " + Program.storages[select].Cost_ptoduct() + "тнг");
            cursor_L = Console.CursorLeft;
            cursor_T = Console.CursorTop;
            Console.SetCursorPosition(0, cursor_T + 5);
            Console.Write("1- Поиск товара\t 2-Добавить товар\t3-Переместить товар\t4-Сумма всех складов \n");
            Console.Write("5-Сравнить склады\t 6-Сбалансировать склады\t 7-Отчеты\t0-назад\n");

        }

        private static List<Product> AllProducts = ProductList.Instance.ProductCatalog;

        public static void Search(int select)
        {
            Console.Clear();
            foreach (Product prod in AllProducts)
            {
                Console.WriteLine(prod.GetInfo());
            }
            Console.WriteLine("\nВведите SKU товара, который хотите найти");
            SKU = Convert.ToInt32(Console.ReadLine());
            var found_select_prod = Program.storages[select].Search_SKU(SKU);
            if (Program.storages[select].Search_SKU(SKU) == null)
            {
                Console.WriteLine("Указанного товара нет на данном складе");
                Console.WriteLine("Найти товар на других складах?\t1-Да\t2-Нет");
                if (Convert.ToInt32(Console.ReadLine()) == 1)
                {
                    foreach (Storage S in Program.storages)//есть вариант, как это улучшить, займусь этим завтра
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
                Console.WriteLine(Program.storages[select].name+": " 
                    + found_select_prod.Item1.name + " " 
                    + found_select_prod.Item2+found_select_prod.Item1.unit);
            }
        }

        public static void Add(int select)
        {
            Console.Clear();
            foreach (Product prod in AllProducts)
            {
                Console.WriteLine(prod.GetInfo());
            }
            Console.WriteLine("Введите SKU товара, который хотите добавить");
            SKU = Convert.ToInt32(Console.ReadLine());
            foreach (Product P in AllProducts)//изменить
            {
                if (P.SKU == SKU)
                {
                    Console.WriteLine(P.name + " Введите количество");
                    count = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(Program.storages[select].Add_product(P.SKU, count) == true ? ("Товар добавлен") : ("ошибка"));
                    break;
                }
            }
        }

        public static void Transfer(int select)
        {
            Console.WriteLine("Введите SKU товара:");
            SKU = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество товара:");
            count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Выберите место доставки:");
            for (int i = 0; i < Program.storages.Count(); i++)
            {
                Console.WriteLine(i + 1 + " " + Program.storages[i].name);
            }
            check = Convert.ToInt32(Console.ReadLine()) - 1;

            Program.storages[select].Transfer(Program.storages[check], Program.storages[select].Search_SKU(SKU).Item1, count);
        }

        public static void Sum()
        {
            decimal sum = 0;
            Console.Write("\nСумма всех складов равна: ");
            foreach (Storage stor in Program.storages)
            {
                sum += stor.Cost_ptoduct();
            }
            Console.Write(sum + "тнг\n");
            sum = 0;
        }

        public static void Compare(int select)
        {
            Console.WriteLine("Выберите склад");
            for (int i = 0; i < Program.storages.Count(); i++)
            {
                Console.WriteLine(i + 1 + " " + Program.storages[i].name);
            }
            check = Convert.ToInt32(Console.ReadLine())-1;
            foreach (var P in Program.storages[select].Compare(Program.storages[check]))
            {
                string foundProd = AllProducts.Where(Prod=>Prod.SKU == P).Select(Prod=>Prod.name).First();
                Console.WriteLine(foundProd);
                foundProd = null;
            }
        }

        public static void Balans(int select)
        {
            Console.WriteLine("Выберите склад");
            for (int i = 0; i < Program.storages.Count(); i++)
            {
                Console.WriteLine(i + 1 + " " + Program.storages[i].name);
            }
            check = Convert.ToInt32(Console.ReadLine());
            Program.storages[select].Balans(Program.storages[check - 1]);
        }

        public static void ShowReports(int select)
        {
            Console.Clear();
            Console.WriteLine("1-Список недостающих продуктов\n2-Список продуктов с избытком" +
                "\n3-Список складов, на которых отсутствуют сыпучие продукты" +
                "\n4-Среднее количество продуктов на всех складах");
            check = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (check)
            {
                case (int)Reports.Lesser:
                    {
                        Console.WriteLine(Program.storages[select].name + ":");
                        Program.storages[select].LesserAmount();
                        break;
                    }
                case (int)Reports.Max:
                    {
                        Console.WriteLine(Program.storages[select].name + ":");
                        Program.storages[select].MaxProduct();
                        break;
                    }
                case (int)Reports.MissGranular:
                    {
                        Program.storages.MissGranular();
                        break; 
                    }
                case (int)Reports.AverageQuantity:
                    {
                        AllProducts.AverageQuantity();//изменить
                        break;
                    }

            }
        }
    }
}
