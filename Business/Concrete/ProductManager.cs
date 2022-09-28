using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

         public IDataResult<List<Product>> GetAll()
         {
             return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
         }

         public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
         {
             return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==categoryId),Messages.ProductsListed);
         }

         public IDataResult<List<ProductDetailDto>> GetProductDetails()
         {
             if (DateTime.Now.Hour==24)
             {
                 return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
             }
             return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
         }

         public IResult Add(Product product)
         {
             if (product.ProductName.Length<2)
             {
                 return new ErrorResult(Messages.ProductNameInValid);
             }
             _productDal.Add(product);
             return new SuccessResult(Messages.ProductAdded);
         }

         public IResult Update(Product product)
         {
             _productDal.Update(product);
             return new SuccessResult(Messages.ProductUpdated );

        }

        public IResult Delete(Product product)
         {
             _productDal.Delete(product);
             return new SuccessResult(Messages.ProductDeleted);

        }

        public IDataResult<Product> GetById(int productId)
         {
             return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
         }
    }
}
