using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebStartUp.DTO;
using WebStartUp.Repository;

namespace WebStartUp
{
    /// <summary>
    /// Сводное описание для WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public List<ProductDTO> GetProductList()
        {
            RProductDTO prod = new RProductDTO();
            return prod.GetList().ToList();
        }
        [WebMethod]
        public CurrentProductDTO GetProduct(int id)
        {
            RProductDTO prod = new RProductDTO();
            return prod.Get(id);
        }
    }
}
