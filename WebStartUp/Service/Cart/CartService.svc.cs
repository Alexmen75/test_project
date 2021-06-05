using AdventureWorks.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebStartUp.DTO;
using System.Data.Entity;

namespace WebStartUp.Service.Cart
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "CartService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы CartService.svc или CartService.svc.cs в обозревателе решений и начните отладку.
    public class CartService : ICartService
    {
        public void DeleteCart(string Email)
        {
            ModelAW db = new ModelAW();
            string UserID = db.EmailAddresses
                .Where(m => m.EmailAddress1 == Email)
                .FirstOrDefault()
                .BusinessEntityID.ToString();
            var cart = db.ShoppingCartItems
                .Where(m => m.ShoppingCartID == UserID.ToString());
            db.ShoppingCartItems.RemoveRange(cart);
            db.SaveChangesAsync();
                
        }

        public void DeleteItem(string Email, int ProductID)
        {
            ModelAW db = new ModelAW();
            string UserID = db.EmailAddresses
               .Where(m => m.EmailAddress1 == Email)
               .First().BusinessEntityID.ToString();
            var Product = db.ShoppingCartItems
                .Where(m => m.ShoppingCartID == UserID && m.ProductID==ProductID).FirstOrDefault();
            db.ShoppingCartItems.Remove(Product);
            db.SaveChangesAsync();
        }

        public List<ProductDTO> GetCart(string UserEmail)
        {
            ModelAW db = new ModelAW();
            int UserID = db.EmailAddresses
               .Where(m => m.EmailAddress1 == UserEmail)
               .First().BusinessEntityID;
            var prod = db.ShoppingCartItems
                .Include(m => m.Product)
                .Where(m => m.ShoppingCartID == UserID.ToString())
                .Select(m => new ProductDTO
                {
                    ProductID = m.ProductID,
                    ProductName = m.Product.Name
                }).ToList();
            GetPhoto(prod);
            return prod;
        }

        public List<ProductDTO> GetPhoto(List<ProductDTO> Prod)
        {
            ModelAW db = new ModelAW();
            foreach (var photo in Prod)
            {
                photo.ThumbNailPhoto = db.ProductProductPhotoes
                    .Include(m => m.ProductPhoto)
                    .Where(m => m.ProductID == photo.ProductID)
                    .FirstOrDefault().ProductPhoto.ThumbNailPhoto;
            }
            return Prod.ToList();
        }
        public void AddToCart(CurrentProductDTO prod, int UserID)
        {
            ModelAW db = new ModelAW();
            ShoppingCartItem cart = new ShoppingCartItem()
            {
                ProductID = prod.ProductID,
                ShoppingCartID = UserID.ToString(),
                ModifiedDate = DateTime.Now,
                DateCreated = DateTime.Now,
                Quantity = prod.Count
            };
            db.ShoppingCartItems.Add(cart);
            db.SaveChanges();
        }
    }
}
