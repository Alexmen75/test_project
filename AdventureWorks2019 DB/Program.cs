using AdventureWorks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.Repository.Production;
using AdventureWorks.Repository;
using System.Data.Entity;

namespace AdventureWorks2019_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelAW db = new ModelAW();
            //var Prod = new ProductRep();
            //var p = Prod.GetList();
            //foreach (var a in p)
            //{
            //    Console.WriteLine(a.Name);
            //}
            var Prod = from Product Pro in db.Products
                       select Pro.ProductModel;
            foreach (var P in Prod)
            {
                Console.WriteLine(P);
            }
        }
    }
}
