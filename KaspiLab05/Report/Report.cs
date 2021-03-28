using KaspiLab05.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaspiLab05.Exceptions;
using KaspiLab05.Catalog;

namespace KaspiLab05.Report
{
   static class Report
    {
         static List<Product> AllProducts = Catalog.ProductList.Instance.ProductCatalog;
        public static void LesserAmount(this Storage storage)
        {
            var report = storage.products
                .OrderBy(s => s.Value)
                .ThenBy(s=> s.Value)
                .Where(s => s.Value < 20).ToList();
            Console.WriteLine("недостающих товаров на складе "+ report.Count());
            foreach(var rep in report)
            {
                Product foundProd = AllProducts.Where(p => p.SKU == rep.Key).First();
                Console.WriteLine(foundProd.name+" "+ rep.Value+foundProd.unit);
            }
        }
        public static void ProductList<T>(this T Item)
        {
            List<Product> report = null;
            if (Item is Storage storage)
            {
                List<Product> product = AllProducts.Where(P => storage.products.ContainsKey(P.SKU)).ToList();
                  report = product
                    .OrderBy(s => s.name)
                    .ToList();
            }
            else if (Item is List<Product> products)
            {
                report = products;
            }
            foreach (var rep in report)
            {
                Console.Write("\t " + rep.SKU);
                Console.Write("\t " + rep.name);
                Console.Write("\t " + rep.cost + "тнг");
                if (rep is Liquid liquid)
                {
                    Console.Write("/" + liquid.unit);
                }
                else if (rep is Solid solid)
                {
                    Console.Write("/" + solid.unit);
                }
                else if (rep is Granular granular)
                {
                    Console.Write("/" + granular.unit);
                }
                if (Item is Storage stor)
                {
                    Console.Write("\t " + stor.products[rep.SKU]);
                    Console.Write("\t\t " + rep.description );
                }
                Console.WriteLine();
                
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
                Product foundProd = AllProducts.Where(p => p.SKU == rep.Key).First();
                Console.WriteLine(rep.Key + " " + foundProd.name + " " + rep.Value + foundProd.unit);
            }
        }

        public static Predicate<int> check;

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
                    report = S.products.Where(prod=> prod.Key == P.SKU).Select(prod=> prod.Value).ToList();
                }
                foreach(int rep in report)
                {
                    count += rep;
                }
                Console.WriteLine(P.name+"  "+count/report.Count()+P.unit);
            }
        }

        public static bool Check(this List<Product> products,int SKU)
        {
            var report = products.Contains(products.Where(P => P.SKU == SKU).First());
            return report;
        }
    }
}
