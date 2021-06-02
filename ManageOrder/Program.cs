using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderManagerService.Service1Client client = new OrderManagerService.Service1Client();
            Console.WriteLine(client.SendOeder());
            Console.WriteLine(client.SetManager());
            client.Close();
            Console.ReadKey();

        }
    }
}
