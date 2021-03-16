using KaspiLab05.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Exceptions
{
    class Product_exception : Exception
      
    {
        public Product_exception(string massage) : base (massage)
        {
            throw this;
        }
    }
    class Exception_type
    {
        bool type;
        public Exception_type(Product P, string name)
        {
            type = P is Granular;
            if (type)
            {
                Product_exception ex = new Product_exception("Недопустимый вид товара для данного склада "+ name);
            }
        }
            
    }
}
