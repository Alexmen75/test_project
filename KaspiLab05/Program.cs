using KaspiLab05.Objects;
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
        static void Main(string[] args)
        {
            Product whater = new Liquid() {SKU = 123412, cost= 100, name = "BonAqua", description="Водичка" };
            Product cola = new Liquid() { SKU = 123945, cost = 150, name = "Coca-Cola", description = "Счастье к нам приходит"};

            Product buckwheat = new Granular() { SKU = 62356, cost = 110, name = "King", description = "Греча простая" };
            Product rice = new Granular() { SKU = 68932, cost = 120, name = "King", description = "Рис королей" };

            Product cookies= new Solid() { SKU = 823949, cost = 330, name = "Oreo", description = "Оторви, обмакни, лизни" };
            Product chips = new Solid() { SKU = 67654, cost = 420, name = "Lays", description = "Чепсики" };

            List < Product > products= new List<Product>() { whater, cola, buckwheat, rice, cookies, chips };

            Storage Damu_Logistic = new Storage() { adress = " Где-то за городом", sqгare = 230, is_Open = false };
            Storage ZIP_Logistic = new Storage() { adress = " Достык 128", sqгare = 530, is_Open = true };
            Storage Admart = new Storage() { adress = "Казыбаева 61а", sqгare = 320, is_Open = false };

            List<Storage> storages = new List<Storage>() { Damu_Logistic, ZIP_Logistic, Admart };

            Add_product(Damu_Logistic, products);
            Add_product(ZIP_Logistic, products);
            Add_product(Admart, products);


            while (true)
            {
                Console.WriteLine("Выберите склад");
                Console.WriteLine("1-Damu Logistic\n2-ZIP Logistic\n3 Admart");
                int check = Convert.ToInt32(Console.ReadLine())-1;
                Console.Clear();
                Console.WriteLine("Адрес: {0}",storages[check].adress);
                Console.WriteLine("Площадь: {0}", storages[check].sqгare);
                Console.WriteLine("Тип склада: {0}", (storages[check].is_Open==true? ("Открытый"):("Закрытый")));
                Console.WriteLine("Ответственный: {0}", storages[check].manager);
                Console.WriteLine("Список продуктов:");
                Console.WriteLine("\t SKU\t Наименование\t Цена за ед\t Количество\t Описание\n");
                for (int num=1; num<storages[check].products.Count;num++) // Вывод исправлю и сделаю более читаемым
                {
                    var p = storages[check].products;
                    if (p[num] is Liquid liquid)
                    {
                        Console.WriteLine("\t {0}\t {1}\t {2}тнг/{3}\t\t{4}{3}\t {5}", liquid.SKU, liquid.name, liquid.cost, liquid.unit, storages[check].product_count[num], liquid.description);
                    }
                    else if(p[num] is Granular granular)
                    {
                        Console.WriteLine("\t {0}\t {1}\t {2}тнг/{3}\t{4}{3}\t {5}", granular.SKU, granular.name, granular.cost, granular.unit, storages[check].product_count[num], granular.description);
                    }
                    else if (p[num] is Solid solid)
                    {
                        Console.WriteLine("\t {0}\t {1}\t {2}тнг/{3}\t\t{4}{3}\t {5}", solid.SKU, solid.name, solid.cost, solid.unit, storages[check].product_count[num], solid.description);
                    }
                    
                }
                



            }
        }
        static void Add_product(Storage S, List<Product> P)
        {
            
            foreach(var prod in P)
            {
                S.Add_product(prod, rand.Next(1, 50));
            }
        }
    }
}
