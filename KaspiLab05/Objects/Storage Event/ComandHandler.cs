using KaspiLab05.Comand;
using KaspiLab05.StorageHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiLab05.Objects.Storage_Event
{
    class ComandHandler
    {
        public static void Handler(Queue<ProductMoving> productMovings)
        {
            Invoker invoker = new Invoker();
            while (productMovings.Count != 0)
            {
                productMovings.Peek().Info += StorageHelper.TransferProductHandler;
                invoker.SetCommand(productMovings.Peek());
                invoker.Run();
                productMovings.Dequeue().Info -= StorageHelper.TransferProductHandler;
            }
        }
    }
}
