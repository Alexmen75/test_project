using AdventureWorks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebStartUp.Controllers.Order
{
    public class Order : Controller
    {
        ModelAW db = new ModelAW();

        public ActionResult OrderView()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<ActionResult> CreatOrder()
        //{

        //}
    }
}