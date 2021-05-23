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
                fullInfo.Model = Model.Select(m=>m.Model).FirstOrDefault();
                fullInfo.Description = Model.Select(m => m.Description).FirstOrDefault();
            }
            return fullInfo;
        }

        public IEnumerable<ProductDTO> GetList(int PageNum)
        {

            //IEnumerable<ProductDTO> product = from ProductProductPhoto PPI in db.ProductProductPhotoes
            //                                  join Product Prod in db.Products on PPI.ProductID equals Prod.ProductID
            //                                  join ProductPhoto Photo in db.ProductPhotoes on PPI.ProductPhotoID equals Photo.ProductPhotoID
            //                                  orderby Photo.ThumbNailPhoto
            //                                  select new ProductDTO
            //                                  {
            //                                      ProductID = Prod.ProductID,
            //                                      ProductName = Prod.Name,
            //                                      ThumbNailPhoto = Photo.ThumbNailPhoto
            //                                  };
            var start = PageNum * 50;
            var products = db.ProductProductPhotoes.Include(u => u.Product).Include(u => u.ProductPhoto).OrderByDescending(t => t.ProductID)
                .Skip(start)
                .Take(50)
                .Select(prod => new ProductDTO { ProductName = prod.Product.Name, ProductID = prod.ProductID, ThumbNailPhoto = prod.ProductPhoto.ThumbNailPhoto })
                .ToList();
            return products;
        }
    }
}
