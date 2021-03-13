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



            Storage Damu_Logistic = new ClosedStorage() { sqгare = 230};
            Storage ZIP_Logistic = new OpenStorage() { sqгare = 530};
            Storage Admart = new ClosedStorage() {  sqгare = 320 };



            List<Storage> storages = new List<Storage>() { Damu_Logistic, ZIP_Logistic, Admart };



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

            Product whater = new Liquid(123412, "BonAqua", 100, "Водичка",ZIP_Logistic);
            Product cola = new Liquid(123945,"Coca-Cola", 150 , "Счастье к нам приходит", Damu_Logistic);



            Product buckwheat = new Granular( 62356, "King buckwheat",  110,"Греча простая", Admart) ;
            Product rice = new Granular( 68932, "King rice", 120 , "Рис королей", Damu_Logistic) { };



            Product cookies= new Solid(823949, "Nestle Oreo", 330, "Оторви, обмакни, лизни", ZIP_Logistic);
            Product chips = new Solid(67654, "Lays chips", 420, "Чепсики", Admart) ;


            Product burger = new Solid(42069, "Burger king", 990, "Women belongs in the kitchen", storages[rand.Next(0, 3)]);// Sorry, i just like memes



            while (true)
            {
                Console.WriteLine("Выберите склад");
                Console.WriteLine("1-Damu Logistic\n2-ZIP Logistic\n3 Admart");
                int select = Convert.ToInt32(Console.ReadLine())-1;
                Console.Clear();
                Console.WriteLine("Адрес: {0} {1} {2}",storages[select].adress.city, storages[select].adress.street, storages[select].adress.num);
                Console.WriteLine("Площадь: {0}", storages[select].sqгare);
                Console.WriteLine("Тип склада: {0}", (storages[select] is OpenStorage? ("Открытый"):("Закрытый")));
                Console.WriteLine("Ответственный: {0} {1} {2}", storages[select].manager.surname, storages[select].manager.name, storages[select].manager.patronymic);
                Console.WriteLine("Список продуктов:");
                Console.WriteLine("\t SKU\t Наименование\t Цена за ед\t Количество\t Описание\n");
                


                foreach(var Prod in storages[select].products)
                {
                    Console.Write("\t " + Prod.Key.SKU);
                    Console.Write("\t " + Prod.Key.name);
                    Console.Write("\t " + Prod.Key.cost);
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
                    Console.Write("\t\t " + Prod.Value);
                    Console.Write("\t\t " + Prod.Key.description + "\n");
                }



                
                Console.SetCursorPosition(0, 30);
                Console.Write("1- Поиск товара\t2-Сумма всех товаров\t3-Добавить товар\t4-Переместить товар");
                /*switch(Convert.ToInt32(Console.ReadKey()))
                {
                    case 1:
                        {
                            if (storages[check].Search_SKU(Convert.ToInt32(Console.ReadLine()))
                            break;
                        }
                }*/
            }
        }
    }
}
