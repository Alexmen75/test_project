using AdventureWorks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStartUp.Models;
using System.Data.Entity;
using WebStartUp.kaspi.lab.service;

namespace WebStartUp.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult ProductList(int PageNum)
        {
            ModelAW db = new ModelAW();
            WebService1SoapClient Products = new WebService1SoapClient();
            IEnumerable<ProductDTO> P = Products.GetProductList(PageNum);
            ViewBag.Pages =(int) db.Products.Count()/50;
            return View(P);
        }
    }
}