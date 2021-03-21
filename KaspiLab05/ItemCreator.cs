using KaspiLab05.Builders;
using KaspiLab05.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05
{
    public class ItemCreator
    {
        public static Random rand = new Random();

        static Random S = new Random();
        static Random N = new Random();
        static Random P = new Random();

        static string[] surname = new string[5] { "Букин", "Софиулин", "Кузнецов", "Ледошляп", "Захаранс" };
        static string[] name = new string[5] { "Генадий", "Анатолий", "Игорь", "Артем", "Максим" };
        static string[] patronymic = new string[5] { "Артемович", "Михайлович", "Алесандрович", "Русланович", "Павлович" };


        static Storage Damu_Logistic = new ClosedStorage() { sqгare = 230, name = "Damu_Logistic" };
        static Storage ZIP_Logistic = new OpenStorage() { sqгare = 530, name = "ZIP_Logistic" };
        static Storage Admart = new ClosedStorage() { sqгare = 320, name = "Admart" };

        

        public static void AddStorage()
        {
            Damu_Logistic.Set_Manager(surname[S.Next(0, 5)], name[N.Next(0, 5)], patronymic[P.Next(0, 5)]);
            ZIP_Logistic.Set_Manager(surname[S.Next(0, 5)], name[N.Next(0, 5)], patronymic[P.Next(0, 5)]);
            Admart.Set_Manager(surname[S.Next(0, 5)], name[N.Next(0, 5)], patronymic[P.Next(0, 5)]);


            Program.storages.Add(Damu_Logistic);
            Program.storages.Add(ZIP_Logistic);
            Program.storages.Add(Admart);
            for (int i=0;i< Program.storages.Count();i++)
           {
               for (int j = 1; j < 4; j++) 
               {
                    Program.storages[i].Set_Employee(surname[S.Next(0, 5)], name[N.Next(0, 5)], patronymic[P.Next(0, 5)], (post)j);
               }
           }
            Damu_Logistic.Add_product(chips,30);
            Admart.Add_product(cola, 40);

           for (int i = 0; i < Program.storages.Count(); i++)
           {
                Program.storages[i].adress = new Adress((City)i, (Street)i, rand.Next(10,150));
               for (int j = 0; j < 4; j++)
               {
                    Program.storages[i].Set_Employee(surname[S.Next(0, 5)], name[N.Next(0, 5)], patronymic[P.Next(0, 5)], (post)j);
               }
           }
        }


        static Product whater = new ProductBuilder<Liquid>()
              .SKU(123412)
              .name("BonAqua")
              .cost(100)
              .description("Водичка")
              .storage(ref ZIP_Logistic)
              .Build();


        static Product cola = new ProductBuilder<Liquid>()
              .SKU(123945)
              .name("Coca-Cola")
              .cost(150)
              .description("Счастье к нам приходит")
              .storage(ref Damu_Logistic)
              .Build();

        static Product buckwheat = new ProductBuilder<Granular>()
              .SKU(62356)
              .name("King buckwheat")
              .cost(110)
              .description("Греча простая")
              .storage(ref Admart)
              .Build();

        static Product rice = new ProductBuilder<Granular>()
             .SKU(68932)
             .name("King rice")
             .cost(120)
             .description("Рис королей")
             .storage(ref Damu_Logistic)
             .Build();

        static Product cookies = new ProductBuilder<Solid>()
             .SKU(823949)
             .name("Nestle Oreo")
             .cost(330)
             .description("Оторви, обмакни, лизни")
             .storage(ref ZIP_Logistic)
             .Build();

        static Product chips = new ProductBuilder<Solid>()
             .SKU(67654)
             .name("Lays chips")
             .cost(420)
             .description("Чепсики")
             .storage(ref Admart)
             .Build();

        static Product burger = new ProductBuilder<Solid>()
             .SKU(42069)
             .name("Burger king")
             .cost(990)
             .description("Women belongs in the kitchen")// Sorry, i just like memes
             .storage(ref ZIP_Logistic)
             .Build();


    }
}
