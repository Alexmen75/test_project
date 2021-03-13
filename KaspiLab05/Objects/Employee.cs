using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Objects
{
    enum post
    {
        Manager,
        Storekeeper,
        Driver,
        Loader

    }
    class Employee : Person
    {
       public post pos = new post();
        public Employee(string s, string n, string p, post Pos) : base(s, n, p)
        {
            pos = Pos;
        }
    }
}
