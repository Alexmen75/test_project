using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DTO
{
    [Serializable]
    public class CustomerDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public CustomerDTO () { }
    }
}
