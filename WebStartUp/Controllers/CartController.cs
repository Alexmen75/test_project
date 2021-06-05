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
using WebStartUp.kaspi.lab.Order;
using WebStartUp.kaspi.lab.CartService;

namespace WebStartUp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        // GET: Cart
        [HttpGet]
        public ActionResult Cart()
        {
            CartServiceClient order = new CartServiceClient();
            IEnumerable<kaspi.lab.CartService.ProductDTO> cartList = order.GetCart(User.Identity.Name).AsEnumerable();
            return View(cartList);
        }
        [HttpGet]
        public ActionResult CreateOrder()
        {
            OrderServiceSoapClient order = new OrderServiceSoapClient();
            string Email = User.Identity.Name;
            order.CreateOrderAsync(Email);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult DeleteCartItem(ShoppingCartItem Cart)
        {
            CartServiceClient cartService = new CartServiceClient();
            string Email = User.Identity.Name;
            cartService.DeleteItem(Email, Cart.ProductID);
            return View();
        }
        public ActionResult DeleteCart()
        {
            CartServiceClient CartService = new CartServiceClient();
            string Email = User.Identity.Name;
            CartService.DeleteCartAsync(Email);
            return RedirectToAction("Index", "Home");
        }
    }
}