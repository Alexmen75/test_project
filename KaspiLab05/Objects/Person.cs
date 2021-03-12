using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Objects
{
    class Person
    {
        public string name, surname, patronymic;

        public Person(string s,string n, string p)
        {
            this.name = n;
            this.surname = s;
            this.patronymic = p;
        }
    }
}
