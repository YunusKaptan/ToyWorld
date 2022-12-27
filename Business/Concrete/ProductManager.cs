using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
         IProductDal _productDal;

         public ProductManager(IProductDal productDal)
         {
             _productDal = productDal;
         }
        [CacheAspect]
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

         //[SecuredOperation("product.add,admin")]
         [ValidationAspect(typeof(ProductValidator))]
         [CacheRemoveAspect("IProductService.Get")]
         public IResult Add(Product product)
         {

             _productDal.Add(product);
             return new SuccessResult(Messages.ProductAdded);
         }

        [SecuredOperation("product.update,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
         {
             _productDal.Update(product);
             return new SuccessResult(Messages.ProductUpdated );

        }

         [SecuredOperation("product.delete,admin")]
         public IResult Delete(Product product)
         {
             _productDal.Delete(product);
             return new SuccessResult(Messages.ProductDeleted);

        }

         [CacheAspect]
         [PerformanceAspect(10)]
         public IDataResult<Product> GetById(int productId)
         {
             return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
         }

         [TransactionScopeAspect]
         public IResult AddTransactionalTest(Product product)
         {
             throw new NotImplementedException();
         }

         public IDataResult<List<ProductDetailDto>> GetProductDetailsByProductId(int productId)
         {
             return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetailsByProductId(productId));
         }

         public IDataResult<List<ProductDetailDto>> GetProductDetailsByCategoryId(int categoryId)
         {
             return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetailsByCategoryId(categoryId));
         }
    }
}
