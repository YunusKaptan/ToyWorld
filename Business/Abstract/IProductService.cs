using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int categoryId);
        List<ProductDetailDto> GetProductDetails();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        Product GetById(int productId);

    }
}
