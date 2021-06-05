using AdventureWorks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebStartUp.DTO;
using WebStartUp.Models;

namespace WebStartUp.Service
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "ICustomerService" в коде и файле конфигурации.
    [ServiceContract]
    public interface ICustomerService
    {
        int GetNewID();
        [OperationContract]
        void CreateCustomer(RegisterViewModel model);
        [OperationContract]
        List<TerritoryDTO> GetTerritories();

    }
}
