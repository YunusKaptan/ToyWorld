using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
         IProductDal _productDal;

         public ProductManager(IProductDal productDal)
         {
             _productDal = productDal;
         }

         public List<Product> GetAll()
         {
             return _productDal.GetAll();
         }

         public List<Product> GetAllByCategoryId(int categoryId)
         {
             return _productDal.GetAll(p=>p.CategoryId==categoryId);
         }

         public List<ProductDetailDto> GetProductDetails()
         {
             return _productDal.GetProductDetails();
         }

         public void Add(Product product)
         {
             _productDal.Add(product);
         }

         public void Update(Product product)
         {
             _productDal.Update(product);
         }

         public void Delete(Product product)
         {
             _productDal.Delete(product);
         }

         public Product GetById(int productId)
         {
             return _productDal.Get(p => p.ProductId == productId);
         }
    }
}
