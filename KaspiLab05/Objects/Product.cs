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
        public string unit = "Л";
    }
    class Granular : Product
    {
        public string unit = "КГ";
    }
    class Solid : Product
    {
        public string unit = "ШТ";
    }
}
