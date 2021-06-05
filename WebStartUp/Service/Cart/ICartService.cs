using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebStartUp.DTO;

namespace WebStartUp.Service.Cart
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "ICartService" в коде и файле конфигурации.
    [ServiceContract]
    public interface ICartService
    {
        [OperationContract]
        List<ProductDTO> GetCart(string Email);
        List<ProductDTO> GetPhoto(List<ProductDTO> Prod);
        [OperationContract]
        void DeleteItem(string Email, int ProductID);
        [OperationContract]
        void DeleteCart(string Email);
        [OperationContract]
        void AddToCart(CurrentProductDTO prod, int UserID);
    }
}
