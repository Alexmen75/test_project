using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStartUp.kaspi.lab.service;

namespace WebStartUp.Models.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            WebService1SoapClient Products = new WebService1SoapClient();
            ViewBag.TopProduct = Products.GetTopProduct().AsEnumerable();
            ViewBag.MinProduct = Products.GetMinProduct().AsEnumerable();
            Products.Close();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}