using KaspiLab05.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05
{
    interface IStorage
    {
        bool Add_product(Product prod, int count);

        bool Transfer(Storage S, Product prod, int count);
        Tuple<Product, int> Search_SKU(int SKU);
        decimal Cost_ptoduct();
        void Set_Manager();
    }
}
