using AdventureWorks.DataBase;
using AdventureWorks.Intrface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebStartUp.DTO;
using AdventureWorks.Repository;

namespace WebStartUp.Repository
{
    public class RProductDTO : Repository<ProductDTO>
    {
        public void Ceate(ProductDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CurrentProductDTO Get(int id)
        {
            IEnumerable<CurrentProductDTO> product = from ProductProductPhoto PPI in db.ProductProductPhotoes
                                                     join Product Prod in db.Products on PPI.ProductID equals Prod.ProductID
                                                     join ProductPhoto Photo in db.ProductPhotoes on PPI.ProductPhotoID equals Photo.ProductPhotoID
                                                     where Prod.ProductID == id
                                                     select new CurrentProductDTO
                                                     {
                                                         ProductID = Prod.ProductID,
                                                         ProductName = Prod.Name,
                                                         LargePhoto = Photo.LargePhoto,
                                                         ModelID = Prod.ProductModelID,
                                                         Class = Prod.Class,
                                                         Size = Prod.Size,
                                                         Color = Prod.Color,
                                                         ProductNumber = Prod.ProductNumber,
                                                         SizeUnit = Prod.SizeUnitMeasureCode,
                                                         ProductLine = Prod.ProductLine,
                                                         Weight = Prod.Weight,
                                                         Style = Prod.Style
                                                     };
            CurrentProductDTO fullInfo = product.FirstOrDefault();
            if (fullInfo.ModelID != null)
            {
                IEnumerable<CurrentProductDTO> Model = from ProductModelProductDescriptionCulture info in db.ProductModelProductDescriptionCultures
                                                       join ProductModel model in db.ProductModels on info.ProductModelID equals model.ProductModelID
                                                       join ProductDescription desk in db.ProductDescriptions on info.ProductDescriptionID equals desk.ProductDescriptionID
                                                       where model.ProductModelID == fullInfo.ModelID && info.CultureID == "en"
                                                       select new CurrentProductDTO
                                                       {
                                                           Model = model.Name,
                                                           Description = desk.Description
                                                       };
                fullInfo.Model = Model.Select(m => m.Model).FirstOrDefault();
                fullInfo.Description = Model.Select(m => m.Description).FirstOrDefault();
            }
            fullInfo.InventoryQ = db.ProductInventories.Where(m => m.ProductID == fullInfo.ProductID).Sum(m => m.Quantity);
            return fullInfo;
        }

        public List<ProductDTO> GetList(int PageNum)
        {
            var start = PageNum * 50;
            var products = db.ProductProductPhotoes
                   .Include(m => m.Product)
                   .Include(m => m.Product.ProductInventories)
                   .Include(m => m.ProductPhoto)
                   .Where(m => (m.Product.ProductInventories.Sum(c => c.Quantity) -
                   (from PurchaseOrderDetail Detail in db.PurchaseOrderDetails
                    join PurchaseOrderHeader Header in db.PurchaseOrderHeaders on Detail.PurchaseOrderID equals Header.PurchaseOrderID
                    where Detail.ProductID == m.ProductID && Header.Status == 1
                    select Detail.OrderQty).Sum(v => v)
                   ) > 1 || m.Product.ProductInventories.Where(c => c.ProductID == m.ProductID).Sum(c => c.Quantity) > 0)
                   .OrderBy(m => m.ProductID)
                   .Skip(start)
                   .Take(50)
                   .Select(m => new ProductDTO
                   {
                       ProductName = m.Product.Name,
                       ThumbNailPhoto = m.ProductPhoto.ThumbNailPhoto,
                       ThumbNailPhotoFileName = m.ProductPhoto.ThumbnailPhotoFileName,
                       ProductID = m.ProductID,
                   });
            List<ProductDTO> Prod = new List<ProductDTO>();
            foreach (var p in products)
            {
                Prod.Add(p);
            }
            db.Dispose();
            return Prod;
        }
        public int Pages()
        {
            int PageCount = db.ProductInventories.Where(m => m.Quantity > 1).Select(m => m.Product.Name).Distinct().Count();
            return PageCount / 50;
        }
        public IEnumerable<ProductDTO> GetTopProduct()
        {
            var products = db.ProductProductPhotoes
                   .Include(m => m.Product)
                   .Include(m => m.Product.ProductInventories)
                   .Include(m => m.ProductPhoto)
                   .Where(m => (m.Product.ProductInventories.Sum(c => c.Quantity) -
                   (from PurchaseOrderDetail Detail in db.PurchaseOrderDetails
                    join PurchaseOrderHeader Header in db.PurchaseOrderHeaders on Detail.PurchaseOrderID equals Header.PurchaseOrderID
                    where Detail.ProductID == m.ProductID && Header.Status == 1
                    select Detail.OrderQty).Sum(v => v)
                   ) > 1 || m.Product.ProductInventories.Where(c => c.ProductID == m.ProductID).Sum(c => c.Quantity) > 0)
                 .OrderBy(m => m.Product.ProductInventories.Sum(c => c.Quantity))
                 .Take(5)
                 .Select(m => new ProductDTO
                 {
                     ProductName = m.Product.Name,
                     ThumbNailPhoto = m.ProductPhoto.ThumbNailPhoto,
                     ThumbNailPhotoFileName = m.ProductPhoto.ThumbnailPhotoFileName,
                     ProductID = m.ProductID
                 });
           

            return products;
        }
        public IEnumerable<ProductDTO> GetMinProduct()
        {
            var products = db.ProductProductPhotoes
                   .Include(m => m.Product)
                   .Include(m => m.Product.ProductInventories)
                   .Include(m => m.ProductPhoto)
                   .Where(m => (m.Product.ProductInventories.Sum(c => c.Quantity) -
                   (from PurchaseOrderDetail Detail in db.PurchaseOrderDetails
                    join PurchaseOrderHeader Header in db.PurchaseOrderHeaders on Detail.PurchaseOrderID equals Header.PurchaseOrderID
                    where Detail.ProductID == m.ProductID && Header.Status == 1
                    select Detail.OrderQty).Sum(v => v)
                   ) > 1 || m.Product.ProductInventories.Where(c => c.ProductID == m.ProductID).Sum(c => c.Quantity) > 0)
                 .OrderByDescending(m => m.Product.ProductInventories.Sum(c => c.Quantity))
                 .Take(5)
                 .Select(m => new ProductDTO
                 {
                     ProductName = m.Product.Name,
                     ThumbNailPhoto = m.ProductPhoto.ThumbNailPhoto,
                     ThumbNailPhotoFileName = m.ProductPhoto.ThumbnailPhotoFileName,
                     ProductID = m.ProductID
                 });

            return products;
        }
    }
}
