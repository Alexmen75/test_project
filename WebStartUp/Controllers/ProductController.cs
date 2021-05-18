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
        public ActionResult ProductList()
        {
            WebService1SoapClient Product = new WebService1SoapClient();
            IEnumerable<ProductDTO> p = Product.GetProductList().AsEnumerable();
            return View(p);
        }
    }
}