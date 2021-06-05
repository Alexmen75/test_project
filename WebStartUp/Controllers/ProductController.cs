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
            WebService1SoapClient Products = new WebService1SoapClient();
            IEnumerable<ProductDTO> P = Products.GetProductList(PageNum);
            ViewBag.Pages =Products.Pages();
            ViewBag.Page = PageNum+1;
            return View(P);
        }
    }
}