using KaspiLab05.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Exceptions
{
    
    class ProductException : Exception
      
    {
        public ProductException(string massage) : base (massage)
        {
        }
    }
    class ExceptionType
    {
        
        public static bool Check_type(Product P)
        {
            return P is Granular;
        }
            
    }
}
