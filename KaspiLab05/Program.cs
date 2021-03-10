using KaspiLab05.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05
{
    class Program
    {
        static void Main(string[] args)
        {
            Product Whater = new Liquid() {SKU = 123412, cost= 155, name = "BonAqua", description="Водичка" };
            Product Buckwheat = new Granular() { SKU = 62356, cost = 110, name = "King", description = "Греча простая" };
            Product Oreo = new Solid() { SKU = 823949, cost = 330, name = "Oreo", description = "Оторви, обмакни, лизни" };
            Storage Damu_Logistic = new Storage() { adress = " Где-то за городом", sqгare = 130, is_Open = true };
            Storage Kam_Logistic = new Storage() { adress = " Назарбаева 165", sqгare = 530, is_Open = false };

            Damu_Logistic.Add_product(Whater, 360);
            foreach(Product p in Damu_Logistic.products)
            {
                if (p!=null)
                {
                    Console.WriteLine(p.name);
                }
                
            }
        }
    }
}
