using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int categoryId);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
        IDataResult<Product> GetById(int productId);
        IResult AddTransactionalTest(Product product);
        IDataResult<List<ProductDetailDto>> GetProductDetailsByProductId(int productId);
        IDataResult<List<ProductDetailDto>> GetProductDetailsByCategoryId(int categoryId);


    }
}
