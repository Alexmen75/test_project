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

        public ProductDTO Get(int id)
        {
            //var prod = db.Products.Find(id).Name;
            //var PhotoId = db.ProductProductPhotoes.Find(id).ProductPhotoID;
            //var PhotoInfo = db.ProductPhotoes.Find(PhotoId);
            //var ProdInfo = new ProductDTO() {ProductID=id, ProductName=prod,PhotoName=PhotoInfo.LargePhotoFileName,Photo = PhotoInfo.LargePhoto };
            //return ProdInfo;

            var product = from ProductProductPhoto PPI in db.ProductProductPhotoes
                                              join Product Prod in db.Products on PPI.ProductID equals Prod.ProductID
                                              join ProductPhoto Photo in db.ProductPhotoes on PPI.ProductPhotoID equals Photo.ProductPhotoID
                                              join ProductModelProductDescriptionCulture info in db.ProductModelProductDescriptionCultures on Prod.ProductModelID equals info.ProductModelID
                                              join ProductDescription desk in db.ProductDescriptions on info.ProductDescriptionID equals desk.ProductDescriptionID
                                              where Prod.ProductID == id
                                              select new ProductDTO
                                              {
                                                  ProductID = Prod.ProductID,
                                                  ProductName = Prod.Name,
                                                  LargePhoto = Photo.LargePhoto,
                                                  Description = desk.Description
                                              };
            return product.FirstOrDefault();
        }

        public IEnumerable<ProductDTO> GetList()
        {

            IEnumerable<ProductDTO> product = from ProductProductPhoto PPI in db.ProductProductPhotoes
                                              join Product Prod in db.Products on PPI.ProductID equals Prod.ProductID
                                              join ProductPhoto Photo in db.ProductPhotoes on PPI.ProductPhotoID equals Photo.ProductPhotoID
                                              select new ProductDTO
                                              {
                                                  ProductID = Prod.ProductID,
                                                  ProductName = Prod.Name,
                                                  ThumbNailPhoto = Photo.ThumbNailPhoto
                                                  
                                              };
            return product;
        }
    }
}
