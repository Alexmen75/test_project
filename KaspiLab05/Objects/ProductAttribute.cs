using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Objects
{
    [AttributeUsage(AttributeTargets.Property)]
    class ProductsAttribute: Attribute
    {
        public ProductsAttribute()
        {

        }
    }
}
