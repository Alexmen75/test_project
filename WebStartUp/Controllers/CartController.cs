using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AdventureWorks.DataBase;
using AdventureWorks.Repository.Person;
using AdventureWorks.Repository.Sales;
using Microsoft.AspNet.Identity;
using WebStartUp.DTO;
using WebStartUp.kaspi.lab.service;

namespace WebStartUp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        // GET: Cart
        [HttpGet] 
        public ActionResult Cart()
        {
            EmailAdressRep email = new EmailAdressRep();
            int ID = email.GetID(User.Identity.GetUserName());
            ModelAW db = new ModelAW();
            var productList = from ShoppingCartItem cart in db.ShoppingCartItems
                              where cart.ShoppingCartID == ID.ToString()
                              select cart.ProductID;
            WebService1SoapClient Product = new WebService1SoapClient();
            List<kaspi.lab.service.CurrentProductDTO> Products = new List<kaspi.lab.service.CurrentProductDTO>();
            foreach(int i  in productList)
            {
                Products.Add(Product.GetProduct(i));
            }
            return View(Products.AsEnumerable());
        }
        [HttpGet]
        public ActionResult CreateOrder()
        {
            ModelAW db = new ModelAW();
            OrderService order = new OrderService();
            string Email = User.Identity.Name;
            int UserID = db.EmailAddresses
                .Where(m => m.EmailAddress1 == Email)
                .First().BusinessEntityID;
            order.CreateOrder(UserID);
            return RedirectToAction("Index", "Home");
        }
    }
}