using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Objects
{
    enum City
    {
        Almaty,
        Astana,
        Turkestan
    }
    enum Street
    {
        Sultan,
        Amangeldy,
        Suyunbaya
    }
    class Adress
    {
        public City city = new City();
        public Street street = new Street();
        public int num;
        public Adress(City C, Street S, int N)
        {
            city = C;
            street = S;
            num = N;

        }
    }
}
