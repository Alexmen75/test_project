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
            Storage Damu_Logistic = new ClosedStorage() { adress = " Где-то за городом", sqгare = 230};
            Storage ZIP_Logistic = new OpenStorage() { adress = " Достык 128", sqгare = 530};
            Storage Admart = new ClosedStorage() { adress = "Казыбаева 61а", sqгare = 320 };

            List<Storage> storages = new List<Storage>() { Damu_Logistic, ZIP_Logistic, Admart };


            Product whater = new Liquid() { SKU = 123412, cost = 100, name = "BonAqua", description = "Водичка" , storage=Admart };
            Product cola = new Liquid() { SKU = 123945, cost = 150, name = "Coca-Cola", description = "Счастье к нам приходит", storage = Damu_Logistic};

            Product buckwheat = new Granular() { SKU = 62356, cost = 110, name = "King food", description = "Греча простая", storage = ZIP_Logistic };
            Product rice = new Granular() { SKU = 68932, cost = 120, name = "King food", description = "Рис королей", storage = Admart};

            Product cookies= new Solid() { SKU = 823949, cost = 330, name = "Nestle Oreo", description = "Оторви, обмакни, лизни", storage = ZIP_Logistic };
            Product chips = new Solid() { SKU = 67654, cost = 420, name = "Lays", description = "Чепсики", storage = Damu_Logistic};


            


            while (true)
            {
                Console.WriteLine("Выберите склад");
                Console.WriteLine("1-Damu Logistic\n2-ZIP Logistic\n3 Admart");
                int check = Convert.ToInt32(Console.ReadLine())-1;
                Console.Clear();
                Console.WriteLine("Адрес: {0}",storages[check].adress);
                Console.WriteLine("Площадь: {0}", storages[check].sqгare);
                Console.WriteLine("Тип склада: {0}", (storages[check] is OpenStorage? ("Открытый"):("Закрытый")));
                Console.WriteLine("Ответственный: {0}", storages[check].manager);
                Console.WriteLine("Список продуктов:");
                Console.WriteLine("\t SKU\t Наименование\t Цена за ед\t Количество\t Описание\n");
                for (int num=1; num<storages[check].products.Count;num++) // Вывод исправлю и сделаю более читаемым
                {
                    var p = storages[check].products;
                    if (p[num] is Liquid liquid)
                    {
                        Console.WriteLine("\t {0}\t {1}\t {2}тнг/{3}\t{4}{3}\t {5}", liquid.SKU, liquid.name, liquid.cost, liquid.unit, storages[check].product_count[num], liquid.description);
                    }
                    else if(p[num] is Granular granular)
                    {
                        Console.WriteLine("\t {0}\t {1}\t {2}тнг/{3}\t{4}{3}\t {5}", granular.SKU, granular.name, granular.cost, granular.unit, storages[check].product_count[num], granular.description);
                    }
                    else if (p[num] is Solid solid)
                    {
                        Console.WriteLine("\t {0}\t {1}\t {2}тнг/{3}\t{4}{3}\t {5}", solid.SKU, solid.name, solid.cost, solid.unit, storages[check].product_count[num], solid.description);
                    }
                    
                }
                



            }
        }
    }
}
