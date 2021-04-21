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
            var Prod = new ProductRep();
            var p = Prod.GetList();
            foreach (var a in p)
            {
                Console.WriteLine(a.Name);
            }
        }
    }
}
