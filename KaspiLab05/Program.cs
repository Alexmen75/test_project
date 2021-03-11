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

        static Random S = new Random();
        static Random N = new Random();
        static Random P = new Random();

        static void Main(string[] args)
        {
            string[] surname = new string[5] {"Букин", "Софиулин","Кузнецов","Ледошляп","Захаранс"};
            string[] name = new string[5] { "Генадий", "Анатолий", "Игорь", "Артем", "Максим" };
            string[] patronymic = new string[5] { "Артемович", "Михайлович", "Алесандрович", "Русланович", "Павлович" };

            Storage Damu_Logistic = new ClosedStorage() { adress = " Где-то за городом", sqгare = 230};
            Storage ZIP_Logistic = new OpenStorage() { adress = " Достык 128", sqгare = 530};
            Storage Admart = new ClosedStorage() { adress = "Казыбаева 61а", sqгare = 320 };



            for(int i = 0; i<4;i++)
            {
                Person Damu = new Employee(surname[S.Next(0, 5)], name[N.Next(0, 5)], patronymic[P.Next(0, 5)], i);
            }
            

            List<Storage> storages = new List<Storage>() { Damu_Logistic, ZIP_Logistic, Admart };


            Product whater = new Liquid(123412, "BonAqua", 100, "Водичка",ZIP_Logistic);
            Product cola = new Liquid(123945,"Coca-Cola", 150 , "Счастье к нам приходит", Damu_Logistic);
            Product buckwheat = new Granular( 62356, "King food",  110,"Греча простая", Admart) ;
            Product rice = new Granular( 68932, "King food", 120 , "Рис королей", Damu_Logistic) { };

            Product cookies= new Solid(823949, "Nestle Oreo", 330, "Оторви, обмакни, лизни", ZIP_Logistic);
            Product chips = new Solid(67654, "Lays chips", 420, "Чепсики", Admart) ;

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

                        //Console.WriteLine("\t {0}\t {1}\t {2}тнг/{3}\t{4}{3}\t {5}", liquid.SKU, liquid.name, liquid.cost, liquid.unit, storages[check].product_count[num], liquid.description);
                        Console.Write("\t " + p[num].SKU);
                        Console.Write("\t " + p[num].name);
                        Console.Write("\t " + p[num].cost);
                        if (p[num] is Liquid liquid)
                        {
                             Console.Write("/" + liquid.unit);
                        }
                        else if (p[num] is Solid solid)
                        {
                            Console.Write("/" + solid.unit);
                        }
                        else if (p[num] is Granular granular)
                        {
                            Console.Write("/" + granular.unit);
                        }
                        Console.Write("\t\t " + storages[check].product_count[num]);
                        Console.Write("\t\t " + p[num].description+"\n");


                    
                }
            }
        }
    }
}
