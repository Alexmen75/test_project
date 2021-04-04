using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MD5_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string newstring = "Hellow world";
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Task t = new  Task(()=> GetHash(32, newstring));
            t.Start();
            Task.WaitAll(t);

            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds);
            Console.WriteLine("RunTime " + elapsedTime);
            Task.WaitAll();
            Console.ReadKey();
        }
        
        public static async Task GetHash(int count, string input)
        {
            byte[] hash = null;
            int i=0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (i < count)
            {
                
                await Task.Run(() =>
                {
                    
                    var md5 = MD5.Create();
                    hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                    Console.WriteLine(i + " " + Convert.ToBase64String(hash));
                    stopwatch.Stop();
                    i++;
                });

                
            }
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds);
            Console.WriteLine("RunTime " + elapsedTime);
            Task.WaitAll();
        }
    }
}
