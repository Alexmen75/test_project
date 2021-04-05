using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace ReflectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var t = Assembly.LoadFrom(@"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6.1\mscorlib.dll");

            var t = typeof(HashSet<>);
            var Path= Assembly.GetAssembly(t).Location;
            var r1 = Assembly.GetAssembly(t).GetExportedTypes()
                .Where(T=>T.Namespace.Contains("System.Collections.Generic" ) && T.IsClass)
                .ToList();
            var r2 = Assembly.GetAssembly(typeof(List<>)).GetExportedTypes()
                .Where(T => T.Namespace.Contains("System.Collections.Generic") && T.IsClass)
                .ToList();
            var r3 = Assembly.GetAssembly(typeof(Queue<>)).GetExportedTypes()
                .Where(T => T.Namespace.Contains("System.Collections.Generic") && T.IsClass)
                .ToList();
            //var r4 = Assembly.GetAssembly(System.Collections.Generic.)).GetExportedTypes()
            //    .Where(T => T.Namespace
            //    .Contains("System.Collections.Generic") && T.IsClass)
            //    .OrderBy(T => T.Namespace).ToList();
            var r = r1.Union(r2.Union(r3)).Distinct();
            r = r.OrderBy(T=>T.Name);
            Console.WriteLine("Список классов пространства имен System.Collections.Generic");
            foreach(var T in r)
            {
                Console.WriteLine(T.Name);
            }

            var tS = typeof(String);
            var rS = tS.GetInterfaces().ToList();
            Console.WriteLine("\nСписок реализованных интерфейсов класса String");
            foreach (var T in rS)
            {
                Console.WriteLine(T.FullName);
            }
        }
    }
}
