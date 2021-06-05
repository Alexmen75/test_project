using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DTO
{
    [Serializable]
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public  decimal TotalPrice { get; set; }
        public List<ProductDTO> Products { get; set; }
        public CustomerDTO Customer { get; set; }
        public OrderDTO() { }
    }
}
