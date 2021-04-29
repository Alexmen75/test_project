using AdventureWorks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace WebStartUp.Controllers
{
    public class CurrentProductController : Controller
    {
        // GET: CurrentProduct
        [HttpGet]
        public ActionResult ShowProduct(int id)
        {
            ModelAW db = new ModelAW();
            var ProdInfo = db.ProductProductPhotoes.Include(c => c.Product).Include(c => c.ProductPhoto).AsEnumerable();
            ViewBag.Product = db.Products.Find(id).Name;
            var info = db.ProductProductPhotoes.First(t => t.ProductID == id).ProductPhotoID;
            ViewBag.Photo = db.ProductPhotoes.Find(info).LargePhoto;
            return View();
        }
    }
}