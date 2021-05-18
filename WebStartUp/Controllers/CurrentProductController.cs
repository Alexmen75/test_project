using AdventureWorks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebStartUp.kaspi.lab.service;

namespace WebStartUp.Controllers
{
    public class CurrentProductController : Controller
    {
        // GET: CurrentProduct
        [HttpGet]
        public ActionResult ShowProduct(int id)
        {
            WebService1SoapClient Product = new WebService1SoapClient();
            var p = Product.GetProduct(id);
            return View(p);
        }
    }
}