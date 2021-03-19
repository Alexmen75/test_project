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
        
        public static bool Check_type(Product P)
        {
            return P is Granular;
        }
            
    }
}
