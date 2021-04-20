using AdventureWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks2019_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var DB = new Model1())
            {
                try
                {
                    Console.WriteLine("Code    \tName\n");
                    foreach (var Prod in DB.Product)
                    {
                        Console.WriteLine(Prod.ProductNumber + "    \t" + Prod.Name);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }
    }
}
