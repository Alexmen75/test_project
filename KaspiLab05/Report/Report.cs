using KaspiLab05.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaspiLab05.Exceptions;

namespace KaspiLab05.Report
{
   static class Report
    {
        public static void LesserAmount(this Storage storage)
        {
            var report = storage.products
                .OrderBy(s => s.Value)
                .ThenBy(s=> s.Value)
                .Where(s => s.Value < 20).ToList();
            Console.WriteLine("недостающих товаров на складе "+ report.Count());
            foreach(var rep in report)
            {
                Console.WriteLine(rep.Key.name+" "+ rep.Value+rep.Key.unit);
            }
        }
        public static void ProductList(this Storage storage)//я понял, что надо использовать Distinct, но у меня автоматом убирваются дубликаты при добавлении товаров на склад
        {
            var report = storage.products
                .OrderBy(s => s.Key.name)
                .ToList();
            foreach (var rep in report)
            {
                Console.Write("\t " + rep.Key.SKU);
                Console.Write("\t " + rep.Key.name);
                Console.Write("\t " + rep.Key.cost + "тнг");
                if (rep.Key is Liquid liquid)
                {
                    Console.Write("/" + liquid.unit);
                }
                else if (rep.Key is Solid solid)
                {
                    Console.Write("/" + solid.unit);
                }
                else if (rep.Key is Granular granular)
                {
                    Console.Write("/" + granular.unit);
                }
                Console.Write("\t " + rep.Value);
                Console.Write("\t\t " + rep.Key.description + "\n");
            }
        }

        public static void MaxProduct(this Storage storage)
        {
            var report = storage.products
                .OrderByDescending(s => s.Value)
                //.ThenByDescending(s => s.Value)
                .Take(3)
                .ToList();
            foreach (var rep in report)
            {
                Console.WriteLine(rep.Key.SKU + " " + rep.Key.name + " " + rep.Value + rep.Key.unit);
            }
        }

        public static Predicate<Product> check;

        public static void MissGranular(this List<Storage> storages)
        {
            check = ExceptionType.Check_type;
            var report = storages
                .Where(s => s.products
                .All(P => !check(P.Key)))
                .ToList();
            foreach (var rep in report)
            {
                Console.WriteLine(rep.name);
            }
        }
        public static void AverageQuantity(this List<Product> products)
        {
            List<int> report = new List<int>();
            foreach (var P in products)
            {
               int count = 0;
                foreach(var S in P.storages)
                {
                    report = S.products.Where(prod=> prod.Key == P).Select(prod=> prod.Value).ToList();
                }
                foreach(int rep in report)
                {
                    count += rep;
                }
                Console.WriteLine(P.name+"  "+count/report.Count()+P.unit);
            }
        }
    }
}
