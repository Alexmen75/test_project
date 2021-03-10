using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Objects
{
    abstract class Product
    {
        public int SKU;
        public string name;
        public decimal cost;
        public string description;
    }
    class Liquid : Product
    {
        string unit = "Л";
    }
    class Granular : Product
    {
        string unit = "КГ";
    }
    class Solid : Product
    {
        string unit = "ШТ";
    }
}
