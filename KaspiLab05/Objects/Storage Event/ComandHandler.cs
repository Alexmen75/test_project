using KaspiLab05.Comand;
using KaspiLab05.StorageHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KaspiLab05.Objects.Storage_Event
{
    class ComandHandler
    {
        public static void Handler(Storage storage)
        {
                Invoker invoker = new Invoker();
                
                while (storage.Comand.Count != 0)
                {
                    invoker.SetCommand(storage.Comand.Peek());
                    invoker.Run();
                    storage.Comand.Dequeue();
                }
        }
    }
}
