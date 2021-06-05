using AdventureWorks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebStartUp.kaspi.lab.service;
using AdventureWorks.Repository.Person;
using Microsoft.AspNet.Identity;
using WebStartUp.kaspi.lab.CartService;

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
        [HttpPost]
        public ActionResult AddToCart(kaspi.lab.service.CurrentProductDTO prod)
        {
            int ID;
            ModelAW db = new ModelAW();
            EmailAdressRep email = new EmailAdressRep();
            ID = email.GetID(User.Identity.GetUserName());
            kaspi.lab.CartService.CartServiceClient cart = new kaspi.lab.CartService.CartServiceClient();
            kaspi.lab.CartService.CurrentProductDTO product = new kaspi.lab.CartService.CurrentProductDTO();
            product.ProductID = prod.ProductID;
            product.Count = prod.Count;
            cart.AddToCart(product,ID);
            return View(prod);
        }

    }
}