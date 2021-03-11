using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Objects
{
    public enum posts
    {
        Manager,
        Storekeeper,
        Loader,
        Driver
        
    }
    class Employee : Person
    {

        

        public Employee(string s, string n, string p , int i) : base(n, s, p)
        {

        }
    }
}
