using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStartUp.DTO
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public byte[] ThumbNailPhoto { get; set; }
        public string ThumbNailPhotoFileName { get; set; }
        public int ProductOnInventory { get; set; }
    }
}
