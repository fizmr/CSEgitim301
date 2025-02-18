using CSEgitim301_DataAccessLayer.Abstract;
using CSEgitim301_DataAccessLayer.Context;
using CSEgitim301_DataAccessLayer.Repositories;
using CSEgitim301_entityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEgitim301_DataAccessLayer.EntityFramework
{
    public class EFProductDal : GenericRepo<Product>, IProductDal
    {
        public List<Object> GetProductsWithCategory()
        {
            var context = new CampContext();
            var values = context.Products
                .Select(x => new 
                {
                    ProductID = x.ProductID,
                    ProductName = x.ProductName,
                    ProductStatus = x.ProductStatus,
                    ProductPrice = x.ProductPrice,
                    ProductDescription = x.ProductDescription,
                    CategoryName = x.Category.CategoryName
                }).ToList();
            return values.Cast<object>().ToList();
        }
    }
}
