﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();
        List<ProductDetailDto> GetProductDetailsByProductId(int carId);
        List<ProductDetailDto> GetProductDetailsByCategoryId(int categoryId);


    }
}
