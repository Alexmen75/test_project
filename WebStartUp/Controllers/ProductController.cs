using AdventureWorks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStartUp.Models;
using System.Data.Entity;

namespace WebStartUp.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult ProductList()
        {
            ModelAW db = new ModelAW();
            var ProdInfo = db.ProductProductPhotoes.Include(c => c.Product).Include(c=>c.ProductPhoto).AsEnumerable();
            
            return View(ProdInfo);
        }
    }
}