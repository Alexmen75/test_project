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
            string newstring = "Give me two number nine, a number nine large, a number six with extra dip, a number seven , two number fortifive , one with chees, and a large soda.... diet";
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Task.WaitAll(GetHash(6000, newstring));
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadKey();
            stopwatch.Reset();
            stopwatch.Start();
            GetHashSync(6000, newstring);
            stopwatch.Stop();
            ts = stopwatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadKey();
        }
        
        public static async Task GetHash(int count, string input)
        {
            byte[] hash = null;
            int i=0;
            Task[] tasks = new Task[count];
            await Task.Run(() =>
            {
                while (i < count)
                {
                    //Console.WriteLine("i= "+ i);
                    tasks[i] = (Task.Run(() =>
                    {
                        var md5 = MD5.Create();
                        hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                        Console.WriteLine(Task.CurrentId-2 + "\t" + Convert.ToBase64String(hash));
                    }));
                    i++;
                }
            });
            //Task.WaitAll(tasks);
        }
        public static void GetHashSync(int count, string input)
        {
            byte[] hash = null;
            int i = 0;

            while (i < count)
            {
                //Console.WriteLine("i= "+ i);
                var md5 = MD5.Create();
                hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                Console.WriteLine(Task.CurrentId-2 + "\t" + Convert.ToBase64String(hash));
                i++;
            }

        }
    }
}
